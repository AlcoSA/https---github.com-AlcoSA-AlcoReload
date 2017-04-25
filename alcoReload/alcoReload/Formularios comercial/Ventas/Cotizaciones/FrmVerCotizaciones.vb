Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ReglasNegocio
Imports ReglasNegocio.cotizaciones

Public Class FrmVerCotizaciones
#Region "Variables"
    Private mCotizacion As ClsCostizaciones
    Private fuenteInicial As DataTable = Nothing
    Private idCotizaDuplicada As Integer

    Private datosEncabe As New Informes.datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter
    Private datosPadre As New Informes.datosInformesTableAdapters.sp_tc017_selectByIdCotizaXMLTableAdapter
    Private datosCondiciones As New Informes.datosInformesTableAdapters.sp_tc072_selectbyIdContizaXMLTableAdapter
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
#End Region
#Region "Procedimientos"
    Private Sub cargarListaCotiza()
        Try
            mCotizacion = New ClsCostizaciones()
            Dim dtable As DataTable = mCotizacion.traerTodosParaContratos()
            dwItem.TablaDatos = dtable.AsEnumerable().Where(Function(a) CInt(a.Item("idEstado")) <> ClsEnums.Estados.ARCHIVADO).CopyToDataTable
            dwItem.TablaDatos = dwItem.TablaDatos.AsEnumerable().Where(Function(a) CInt(a.Item("idaprobacioncliente")) <> ClsEnums.Estados.RECHAZADO).CopyToDataTable
            dwItem.TablaDatos = dwItem.TablaDatos.AsEnumerable().Where(Function(a) CInt(a.Item("idaprobacioncliente")) <> ClsEnums.Estados.RECHAZADO_CLIENTE).CopyToDataTable
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarRechazadas()
        Try
            mCotizacion = New ClsCostizaciones()
            Dim dtable As DataTable = mCotizacion.traerTodosParaContratos().AsEnumerable().Where(Function(a) CInt(a.Item("idaprobacioncliente")) = ClsEnums.Estados.RECHAZADO_CLIENTE).CopyToDataTable
            For Each column As DataColumn In dtable.Columns
                column.ColumnName = "rec_" + column.ColumnName
            Next
            dwRechazadas.TablaDatos = dtable
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarArchivadas()
        Try
            mCotizacion = New ClsCostizaciones()
            Dim dtable As DataTable = mCotizacion.traerTodosParaContratos().AsEnumerable().Where(Function(a) CInt(a.Item("idEstado")) = ClsEnums.Estados.ARCHIVADO).CopyToDataTable
            For Each column As DataColumn In dtable.Columns
                column.ColumnName = "arc_" + column.ColumnName
            Next
            dwArchivadas.TablaDatos = dtable
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function puedeDuplicar(idCotiza As Integer) As Boolean
        Try
            Dim mDuplicacion As New ClsDuracionDuplicacion
            Dim finVigencia As finDuplicacion = mDuplicacion.TraerxIdCotiza(idCotiza)
            If finVigencia IsNot Nothing Then
                If DateTime.Now.Date <= finVigencia.FechaFinDuplicacion.Date Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub duplicarCotizacion()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim idDuplicar As Integer = Convert.ToInt32(r.Cells("id").Value)
            If Not puedeDuplicar(idDuplicar) Then
                MsgBox("La cotización no puede ser duplicada porque supera el tiempo máximo para duplicar cotizaciones contratadas, esto es para evitar malos costos.")
                Return
            End If
            If MsgBox("Está seguro de duplicar la cotización?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                bwcargas.RunWorkerAsync()
                mCotizacion = New ClsCostizaciones
                idCotizaDuplicada = mCotizacion.Duplicar(idDuplicar, My.Settings.UsuarioActivo, "Copia", Convert.ToInt32(r.Cells(idAcabado.DataPropertyName).Value))
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
                If MsgBox("Desea abrir el documento?", MsgBoxStyle.YesNo, "Confirmación apertura") = MsgBoxResult.Yes Then
                    ClsInterbloqueos.Bloquear(idCotizaDuplicada, ClsEnums.ModulosAplicacion.MODULO_COTIZACIONES, My.Settings.UsuarioActivo)
                    editarCotizacion(idCotizaDuplicada)
                End If
                FrmVerCotizaciones_Activated(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub editaCotiza()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim utilserv As New ClsUtilidadesServidor
            Dim us As String = ClsInterbloqueos.ElementoBloqueado(Convert.ToInt32(r.Cells(id.Index).Value), ClsEnums.ModulosAplicacion.MODULO_COTIZACIONES)
            If String.IsNullOrEmpty(us) Or My.Settings.UsuarioActivo.Equals(us) Or My.Settings.Es_Desarrollador Then
                If Not My.Settings.Es_Desarrollador And String.IsNullOrEmpty(us) Then
                    ClsInterbloqueos.Bloquear(Convert.ToInt32(r.Cells(id.Index).Value),
                                              ClsEnums.ModulosAplicacion.MODULO_COTIZACIONES,
                                              My.Settings.UsuarioActivo)
                End If
                editarCotizacion(0)
            Else
                MsgBox("Esta cotización esta siendo utilizada por el usuario: " &
                       utilserv.TraerNombreDirectorio(us), MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub editarCotizacion(idCotizaaDuplicar As Integer)
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim cotiza As New FrmCotizaciones()
            If idCotizaaDuplicar <> 0 Then
                cotiza.IdActual = idCotizaaDuplicar
            Else
                cotiza.IdActual = Convert.ToInt32(r.Cells(id.Index).Value)
            End If
            If DirectCast(r.Cells(idEstado.Index).Value, ClsEnums.Estados) <> ClsEnums.Estados.ACTIVO And idCotizaaDuplicar = 0 Then
                cotiza.OperacionActual = ClsEnums.TiOperacion.SOLO_LECTURA
            Else
                cotiza.OperacionActual = ClsEnums.TiOperacion.MODIFICAR
            End If
            cotiza.MdiParent = Me.MdiParent
            cotiza.WindowState = FormWindowState.Maximized
            cotiza.Text &= " (" & r.Cells(id.Index).Value.ToString & ")"
            cotiza.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub actualizaVersion()
        Try
            mCotizacion = New ClsCostizaciones()
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            If MessageBox.Show("¿Está seguro de actualizar las versiones de costos a la última versión?",
                               "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                mCotizacion.ActualizarVersiones(Convert.ToInt32(r.Cells(id.Index).Value))
                MessageBox.Show("Las versiones de costo de " & r.Cells(nombreCotiza.Index).Value.ToString() &
                                ", se actualizaron correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub archivarCotizacion()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            If MessageBox.Show("¿Está seguro de archivar esta cotización?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim nombre As String = r.Cells(nombreCotiza.Index).Value.ToString()
                mCotizacion = New ClsCostizaciones
                mCotizacion.ModificarEstado(ClsEnums.Estados.ARCHIVADO, r.Cells(id.Index).Value.ToString())
                MessageBox.Show("La cotización " & nombre & ", se ha archivado exitosamente")
                FrmVerCotizaciones_Activated(Me, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function mismoCliente() As Boolean
        Try
            Dim prevCliente As String = String.Empty
            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItem.Rows
                If CInt(r.Cells(idEstado.Index).Value) <> ClsEnums.Estados.ACTIVO Then
                    r.Cells(seleccion.Index).Value = False
                End If
                If CBool(r.Cells(seleccion.Index).Value) = True Then
                    If prevCliente <> String.Empty And prevCliente <> r.Cells(cliente.Index).Value.ToString() Then
                        conteo += 1
                    End If
                    prevCliente = r.Cells(cliente.Index).Value
                End If
            Next
            If conteo > 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function disponibleAprobacion() As Boolean
        Try
            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItem.Rows
                If CBool(r.Cells(seleccion.Index).Value) = True And CInt(r.Cells(idaprobacioncliente.Index).Value) <> ClsEnums.Estados.ACTIVO Then
                    conteo += 1
                End If
            Next
            If conteo > 0 Then
                MsgBox("Entre las cotizaciones seleccionadas, hay algunas aprobadas o que ya fueron enviadas para aprobación")
                Return False
            End If
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub envioComoPDF()
        Try
            enviarCotizacion(False)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub envioParaAprobacion()
        Try
            If disponibleAprobacion() Then
                enviarCotizacion(True)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub enviarCotizacion(paraAprobacion As Boolean)
        Try
            If Not mismoCliente() Then
                MsgBox("Para enviar varias cotizaciones, debe seleccionar la misma constructora")
                Exit Sub
            End If
            bwcargas.RunWorkerAsync("Generando archivos")
            Dim listIdCotiza As New List(Of Integer)
            For Each row As DataGridViewRow In dwItem.Rows
                If CBool(row.Cells(seleccion.Index).Value) = True And CInt(row.Cells(idEstado.Index).Value) = ClsEnums.Estados.ACTIVO Then
                    listIdCotiza.Add(row.Cells(id.Index).Value)
                End If
            Next
            Dim adjuntos As String = String.Empty
            Dim listCorreos As New List(Of String)
            Dim mCotiza As New ClsCostizaciones
            For Each idCotiza As Integer In listIdCotiza
                Dim cotiza As New Informes.CotizacionClienteV
                cotiza.SetDataSource(CrearXMLInforme(idCotiza))
                Dim cot As cotizacion = mCotiza.TraerxId(idCotiza)
                adjuntos += ExportToPDF(cotiza, idCotiza & "-" & cot.nombreCotizacion & ".pdf") & ";"
                If String.IsNullOrEmpty(Trim(cot.mailObra)) Then
                    listCorreos.Add(cot.mailCliente)
                Else
                    listCorreos.Add(cot.mailObra)
                End If
            Next
            Dim destinos As String = String.Empty
            For Each c As String In listCorreos.Distinct().ToList
                destinos += c + ";"
            Next

            Dim frm As New FrmEnvio
            Dim objeto As String = String.Empty
            If paraAprobacion = True Then
                objeto += "APROBACIÓN "
                frm.ContieneURL = True
            Else
                frm.RutasAdujuntos = adjuntos
            End If

            If listIdCotiza.Count > 1 Then
                objeto += "COTIZACIONES ALCO"
            Else
                objeto += "COTIZACIÓN ALCO"
            End If
            frm.ObjetoEnvio = objeto
            frm.ListId = listIdCotiza
            frm.Destinatarios = destinos
            frm.Mensaje = "Cordial saludo.

Adjunto cotización de la obra en referencia

La cotizacion cumple con el decreto 340 que modificó la norma NSR 10 que tiene el análisis de carga combinado con cargas de viento de 120 y 150 kilometros por hora

Cualquier inquietud favor comunicarse con el asesor asignado en la cotización o a este correo.


Favor confirmar recibido por este mismo medio


En espera de sus comentarios"


            bwcargas_RunWorkerCompleted(Nothing, Nothing)
            If frm.ShowDialog() = DialogResult.OK Then
                MessageBox.Show("La información se ha enviado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                For Each r As DataGridViewRow In dwItem.Rows
                    r.Cells(seleccion.Index).Value = False
                Next
                cargarListaCotiza()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function CrearXMLInforme(idCotiza As Integer) As DataSet
        CrearXMLInforme = New DataSet
        Try
            CrearXMLInforme.Tables.AddRange({datosEncabe.GetData(idCotiza), datosPadre.GetData(idCotiza), datosCondiciones.GetData(idCotiza)})
            CrearXMLInforme.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "cotizaParaEnvio.xml"))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Try
            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            vFileName = "C:\Windows\Temp\" & NombreArchivo
            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If
            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()
        Catch ex As Exception
            Throw ex
        End Try
        Return vFileName
    End Function

    Private Sub PendienteporContratar()
        Try
            dwItem.EndEdit()
            If Not disponibleAprobacion() Then
                Return
            End If
            If MessageBox.Show("Las cotizaciones seleccionadas se pasarán a pendientes por contratar, ¿Desea continuar?",
                               "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim conteo As Integer = 0
                For Each row As DataGridViewRow In dwItem.Rows
                    If CBool(row.Cells(seleccion.Index).Value) = True Then
                        conteo += 1
                    End If
                Next
                If conteo > 0 Then
                    Dim pend As New clsPendientesporContratar
                    Dim mCotiza As New ClsCostizaciones
                    Dim seleccionados As DataGridViewRow() = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToBoolean(r.Cells(seleccion.Index).EditedFormattedValue)).ToArray()
                    For i As Integer = 0 To seleccionados.Length - 1
                        pend.Insertar(My.Settings.UsuarioActivo,
                                      Convert.ToInt32(seleccionados(i).Cells(id.Index).Value),
                                      ClsEnums.Estados.ACTIVO)
                    Next
                    MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargarListaCotiza()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub compararCotizaciones()
        Try
            Dim frm As New FrmComparacionCotiza
            Dim listId As New List(Of Integer)
            For Each r As DataGridViewRow In dwItem.Rows
                If CBool(r.Cells(seleccion.Index).Value) = True Then
                    listId.Add(CInt(r.Cells(id.Index).Value))
                End If
            Next
            frm.ListIdCotiza = listId
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Procedimientos Controles"
    Private Sub FrmVerCotizaciones_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            cargarListaCotiza()
            cargarArchivadas()
            cargarRechazadas()

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwitem_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseClick
        Try
            dwItem.EndEdit()
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim r As DataGridViewRow = dwItem.Rows(e.RowIndex)
                For Each row As DataGridViewRow In dwItem.Rows
                    If r.Index <> row.Index Then
                        row.Selected = False
                    End If
                Next
                r.Selected = True

                Dim menu As New ContextMenuStrip
                Select Case DirectCast(r.Cells(idEstado.Index).Value, ClsEnums.Estados)
                    Case ClsEnums.Estados.ACTIVO
                        menu.Items.Add("Editar cotización", Nothing, AddressOf editaCotiza)
                        menu.Items.Add("Duplicar", Nothing, AddressOf duplicarCotizacion)
                        menu.Items.Add("Actualizar versión", Nothing, AddressOf actualizaVersion)
                        menu.Items.Add("Archivar cotización", Nothing, AddressOf archivarCotizacion)

                        If CInt(dwItem.Rows(e.RowIndex).Cells(idEstado.Index).Value) <> ClsEnums.Estados.ANULADO And
                            CInt(dwItem.Rows(e.RowIndex).Cells(idEstado.Index).Value) <> ClsEnums.Estados.ARCHIVADO And
                            CBool(dwItem.Rows(e.RowIndex).Cells(seleccion.Index).Value) = True Then
                            menu.Items.Add("Enviar PDF", Nothing, AddressOf envioComoPDF)
                        End If
                    Case Is = ClsEnums.Estados.EN_CONTRATACION, ClsEnums.Estados.PENDIENTE_CONTRATAR, ClsEnums.Estados.CONTRATADO
                        menu.Items.Add("Mostrar cotización", Nothing, AddressOf editaCotiza)
                        menu.Items.Add("Duplicar", Nothing, AddressOf duplicarCotizacion)
                End Select
                If CBool(dwItem.Rows(e.RowIndex).Cells(seleccion.Index).Value) = True Then
                    If CInt(r.Cells(idaprobacioncliente.Index).Value) = ClsEnums.Estados.ACTIVO Then
                        menu.Items.Add("Enviar para aprobación", Nothing, AddressOf envioParaAprobacion)
                        If My.Settings.Permisos.Contains("101.1") Then
                            menu.Items.Add("Aprobar seleccionada(s)", Nothing, AddressOf PendienteporContratar)
                        End If
                    End If
                    menu.Items.Add("Comparar seleccionada(s)", Nothing, AddressOf compararCotizaciones)

                End If
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseDoubleClick
        Try
            dwItem.Rows(e.RowIndex).Selected = True
            editaCotiza()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Dim carga As New FrmCargaProceso
            carga.Proceso = e.Argument
            Application.Run(carga)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bwcargas_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwcargas.RunWorkerCompleted
        Try
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
End Class