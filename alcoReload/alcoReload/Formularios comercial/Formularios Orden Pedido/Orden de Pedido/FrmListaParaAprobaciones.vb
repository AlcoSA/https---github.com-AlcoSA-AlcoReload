Imports ReglasNegocio
Public Class FrmListaParaAprobaciones
#Region "Variables"
    Private mOrdenDeProduccion As ClsOrdenDePedido
    Private _curId As Integer
    Private _datosEncabe As New Informes.datosInformesTableAdapters.sp_tp002_selectByIdXMLTableAdapter
    Private _datosPadre As New Informes.datosInformesTableAdapters.sp_tp003_SelectPadresByIdOpXMLTableAdapter
    Private _datosHijo As New Informes.datosInformesTableAdapters.sp_tp004_selectHijosByIdOpXMLTableAdapter
    Private _processCircle As New FrmCargaProceso
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
#End Region
#Region "Procedimientos"
    Private Sub caragarDatosIniciales()
        Try
            mOrdenDeProduccion = New ClsOrdenDePedido
            mOrdenDeProduccion.TraerparaAprobacion(dwItems.TablaDatos)
            If dwItems.TablaDatos.Rows.Count > 50 Then
                bwcargas.RunWorkerAsync()
            End If
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function cargarIdsForUpdate() As String
        cargarIdsForUpdate = String.Empty
        Try
            dwItems.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                     If r.Cells(seleccion.Index).Value Then
                                                                         cargarIdsForUpdate &= r.Cells(Id.Index).Value.ToString & ","
                                                                     End If
                                                                 End Sub)
            cargarIdsForUpdate = cargarIdsForUpdate.TrimEnd(",")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Function CrearXMLInforme() As DataSet
        CrearXMLInforme = New DataSet
        Try
            CrearXMLInforme.Tables.AddRange({_datosEncabe.GetData(_curId), _datosPadre.GetData(_curId), _datosHijo.GetData(_curId)})
            CrearXMLInforme.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "OrdenDePedido1.xml"))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Sub RechazarOrdenPedido()
        Try
            Dim mOrdenPedido As New ClsOrdenDePedido
            mOrdenPedido.updateParaAprobar(ClsEnums.Estados.RECHAZADO, My.Settings.UsuarioActivo, cargarIdsForUpdate())
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Procedimientos Controles"
    Private Sub FrmListaContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            caragarDatosIniciales()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub Guardar_todo(sender As System.Object, e As System.EventArgs)
        Try
            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CBool(r.Cells(seleccion.Index).Value) = True Then
                    conteo += 1
                End If
            Next
            If conteo = 0 Then
                ErrorProvider.SetError(lblError, "No ha seleccionado ninguna orden de pedido")
                Return
            End If
            ErrorProvider.Clear()
            If MsgBox("Está seguro de aprobar los datos seleccionados?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                bwcargas.RunWorkerAsync()
                mOrdenDeProduccion.updateParaAprobar(ClsEnums.Estados.APROBADO, My.Settings.UsuarioActivo, cargarIdsForUpdate)

                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'visroReportes.ReportSource = Nothing
                'caragarDatosIniciales()
                FrmListaContratos_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        Finally
            bwcargas_RunWorkerCompleted(Nothing, Nothing)
        End Try
    End Sub
    Private Sub dwitems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Left Then
                    ErrorProvider.Clear()
                    _curId = dwItems.Rows(e.RowIndex).Cells(Id.Index).Value

                    Dim infoOp As New Informes.ordenPedidoCliente
                    infoOp.SetDataSource(CrearXMLInforme)
                    visroReportes.ReportSource = infoOp
                    If e.ColumnIndex = seleccion.Index Then
                        If CBool(dwItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = True Then
                            dwItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                        Else
                            dwItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
                        End If
                    End If
                ElseIf e.Button = MouseButtons.Right Then
                    Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                    For Each row As DataGridViewRow In dwItems.Rows
                        If row.Index <> e.RowIndex Then
                            row.Selected = False
                        End If
                    Next
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Rechazar", Nothing, AddressOf RechazarOrdenPedido)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub chkSeleccion_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccion.CheckedChanged
        Try
            If chkSeleccion.Checked Then
                For Each r As DataGridViewRow In dwItems.Rows
                    r.Cells(seleccion.Index).Value = True
                Next
            Else
                For Each r As DataGridViewRow In dwItems.Rows
                    r.Cells(seleccion.Index).Value = False
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmListaParaAprobaciones_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            AddHandler btnguardar.Click, AddressOf Guardar_todo
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmListaParaAprobaciones_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            RemoveHandler btnguardar.Click, AddressOf Guardar_todo
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Application.Run(New FrmCargaProceso)
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