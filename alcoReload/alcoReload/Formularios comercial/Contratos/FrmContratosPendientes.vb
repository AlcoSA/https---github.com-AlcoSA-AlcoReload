Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class FrmContratosPendientes

#Region "Variables"
    Private _expresionConsulta As String
    Private _listOfSelectedRows As List(Of DataGridViewRow)
    Private pendientes As clsPendientesporContratar

#End Region

#Region "Propiedades"

#End Region

#Region "Procedimientos"
    Private Sub cargarEnContrato()
        Try
            Dim frmContract As New frmContratos
            _listOfSelectedRows = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToBoolean(r.Cells(selectToContract.Index).EditedFormattedValue) And
                                                                                 CInt(r.Cells(idEstado.Index).Value) <> ClsEnums.Estados.EN_CONTRATACION).ToList()
            Dim continuar As Boolean = True
            If validarNoRepetidos() Then
                If Not MsgBox("Seleccionó cotizaciones con diferentes nombres de obra, desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    continuar = False
                End If
            End If
            If continuar Then
                frmContract.operacionActual = ClsEnums.TiOperacion.INSERTAR
                frmContract.StartPosition = FormStartPosition.CenterScreen
                frmContract.expresionConsulta = crearStringContratos()
                frmContract.listaFilasSeleccionadas = _listOfSelectedRows
                frmContract.Size = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 25)
                frmContract.ShowDialog()
                Recargar()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validarNoRepetidos() As Boolean
        dwItem.EndEdit()
        validarNoRepetidos = False
        Try
            If _listOfSelectedRows.GroupBy(Function(a) a.Cells(nombreObra.Index).Value, Function(b) b.Cells(cliente.Index).Value).Count > 1 Then Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Function crearStringContratos() As String
        Try
            dwItem.EndEdit()
            Return String.Join(",", dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToBoolean(r.Cells(selectToContract.Index).EditedFormattedValue) And
                                                                                   CInt(r.Cells(idEstado.Index).Value) <> ClsEnums.Estados.EN_CONTRATACION).Select(Function(r) Convert.ToString(r.Cells(idcotizacion.Index).Value)).ToArray())
        Catch ex As Exception
            Throw New Exception("Error al crear la cadena de consulta de los" & vbLf &
                                "items de las cotizaciones seleccionadas.", ex.InnerException)
        End Try
    End Function

    Private Sub Pasar_a_Existentes()
        Try
            Dim fselcontrato As New FrmSeleccionarContrato
            If fselcontrato.ShowDialog() = DialogResult.OK Then
                Dim _idcontrato As Integer = fselcontrato.IdContrato
                Dim fotrosi As New FrmOtroSi
                fotrosi.IdContrato = _idcontrato
                If fotrosi.ShowDialog() = DialogResult.OK Then
                    Dim _idotrosi As Integer = fotrosi.IdOtroSi
                    Dim _objMovitoItems As New clsMovitoItemsContrato
                    Dim _cotizas As Integer() = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToBoolean(r.Cells(selectToContract.Index).EditedFormattedValue)).Select(Function(r) Convert.ToInt32(r.Cells(id.Index).Value And
                                                                                   CInt(r.Cells(idEstado.Index).Value) <> ClsEnums.Estados.EN_CONTRATACION)).ToArray()
                    Dim _movcot As New cotizaciones.ClsCostizaciones
                    For Each idc In _cotizas
                        _objMovitoItems.tc040_insert(_idcontrato, _idotrosi, idc,
                                                     My.Settings.UsuarioActivo)
                        _movcot.ModificarEstado(ClsEnums.Estados.CONTRATADO,
                                                idc.ToString())
                    Next
                    Recargar()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Reemplazar_en_Contrato()
        Try
            Dim fselcontrato As New FrmSeleccionarContrato
            If fselcontrato.ShowDialog() = DialogResult.OK Then
                Dim _idcontrato As Integer = fselcontrato.IdContrato
                Dim freemplazo As New FrmReemplazoItems
                freemplazo.IdContrato = _idcontrato
                freemplazo.ExpresionConsulta = crearStringContratos()
                If freemplazo.ShowDialog() = DialogResult.OK Then
                    Recargar()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub DevolveraOriginal()
        Try
            If MsgBox("Esta seguro de deshacer el registro y volver la cotización a su estado original?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim seleccionados = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToBoolean(r.Cells(selectToContract.Index).EditedFormattedValue) And
                                                                                   CInt(r.Cells(idEstado.Index).Value) <> ClsEnums.Estados.EN_CONTRATACION).ToArray()
                Dim cot As New cotizaciones.ClsCostizaciones
                For i As Integer = 0 To seleccionados.Length - 1
                    pendientes.Eliminar(Convert.ToInt32(seleccionados(i).Cells(id.Index).Value))
                    cot.ReiniciarEstadosxId(Convert.ToString(seleccionados(i).Cells(idcotizacion.Index).Value))
                Next
                Recargar()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Recargar()
        Try
            dwItem.TablaDatos = pendientes.TraerTodas()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
    Private Sub dwitem_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                If CInt(dwItem.Rows(e.RowIndex).Cells(idEstado.Index).Value) <> ClsEnums.Estados.EN_CONTRATACION Then
                    If dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToBoolean(r.Cells(selectToContract.Index).EditedFormattedValue)).Count > 0 Then
                        dwItem.Rows(e.RowIndex).Selected = True
                        menu.Items.Add("Diligenciar contrato", Nothing, AddressOf cargarEnContrato)
                        'menu.Items.Add("Pasar a Existente", Nothing, AddressOf Pasar_a_Existentes)
                        menu.Items.Add("Reemplazar En Contrato", Nothing, AddressOf Reemplazar_en_Contrato)
                        menu.Items.Add("Eliminar", Nothing, AddressOf DevolveraOriginal)
                        menu.Show(MousePosition)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmContratosPendientes_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            pendientes = New clsPendientesporContratar
            Recargar()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class