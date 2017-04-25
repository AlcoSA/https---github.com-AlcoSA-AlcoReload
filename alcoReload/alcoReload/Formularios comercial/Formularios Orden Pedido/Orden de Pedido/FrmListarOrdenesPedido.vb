Imports ReglasNegocio
Public Class FrmListarOrdenesPedido
#Region "Variables"
    Private mOrdenDeProduccion As New ClsOrdenDePedido
    Private mPadresOP As New ClsItemsOped
    Private mHijosOp As New ClsItemsHijoOped

#End Region

#Region "Procedimientos"
    Private Sub modificar()
        Try
            Dim objOrden As New OrdenDePedido
            Dim objItemsOp As New List(Of ItemsOp)
            Dim objItemsHijosOp As New List(Of ItemHijoOp)
            Dim curid As Integer = Convert.ToInt32(dwItem.SelectedRows(0).Cells(id.Index).Value)
            objOrden = mOrdenDeProduccion.TraerxIdOrden(curid) ' mOrdenDeProduccion.TraerTodos.Where(Function(a) a.Id = curid).ToList.First()
            objItemsOp = mPadresOP.TraerxIdOrdenPedido(curid) '.AddRange(mPadresOP.TraerTodos().Where(Function(a) a.IdEncabeOp = objOrden.Id).ToArray)
            objItemsOp.ForEach(Sub(a)
                                   objItemsHijosOp.AddRange(mHijosOp.TraerxIdPadre(a.Id)) 'mHijosOp.TraerTodos().Where(Function(b) b.IdItemPadre = a.Id).ToArray)
                               End Sub)
            Dim utilserv As New ClsUtilidadesServidor
            Dim us As String = Trim(ClsInterbloqueos.ElementoBloqueado(curid, ClsEnums.ModulosAplicacion.MODULO_GENERACION_ORDEN_PED))
            If String.IsNullOrEmpty(us) Or My.Settings.UsuarioActivo.Equals(us) Or My.Settings.Es_Desarrollador Then
                If Not My.Settings.Es_Desarrollador And String.IsNullOrEmpty(us) Then
                    ClsInterbloqueos.Bloquear(Convert.ToInt32(curid),
                                              ClsEnums.ModulosAplicacion.MODULO_GENERACION_ORDEN_PED,
                                              My.Settings.UsuarioActivo)
                End If
                Dim frmGenerarOp As New frmGenerarOP
                With frmGenerarOp
                    .ordenPedido = objOrden
                    .Tipo_Operacion = ClsEnums.TiOperacion.MODIFICAR
                    .Id_Actual = curid
                    .listOfPadres = objItemsOp
                    .listoOfHijos = objItemsHijosOp
                    .IdContrato = Convert.ToInt32(objOrden.IdContrato)
                    .WindowState = FormWindowState.Maximized
                    .MdiParent = Me.MdiParent
                End With
                frmGenerarOp.Show()
            Else
                MsgBox("Este contrato esta siendo utilizado por el usuario: " &
                       utilserv.TraerNombreDirectorio(us), MsgBoxStyle.Information)
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
                If CInt(r.Cells(Idestado.Index).Value) = ClsEnums.Estados.RECHAZADO_PRODUCCION Then
                    r.Cells(seleccion.Index).Value = False
                End If
                If CBool(r.Cells(seleccion.Index).EditedFormattedValue) = True Then
                    If prevCliente <> String.Empty And prevCliente <> r.Cells(Cliente.Index).Value.ToString() Then
                        conteo += 1
                    End If
                    prevCliente = r.Cells(Cliente.Index).Value
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
    Private Sub EnviarCorreoCliente()
        Try
            If Not mismoCliente() Then
                MsgBox("Para enviar varias ordenes de pedido, debe seleccionar el mismo cliente")
                Exit Sub
            End If
            Dim listIdPedidos As New List(Of Integer)
            For Each r As DataGridViewRow In dwItem.Rows
                If CInt(r.Cells(seleccion.Index).EditedFormattedValue) = True And CInt(r.Cells(Idestado.Index).Value) <> ClsEnums.Estados.RECHAZADO_PRODUCCION Then
                    listIdPedidos.Add(r.Cells(id.Index).Value)
                End If
            Next
            Dim frmEnvio As New FrmEnvioPedidoaCliente
            frmEnvio.ListIdPedidos = listIdPedidos
            If frmEnvio.ShowDialog() = DialogResult.OK Then
                MessageBox.Show("La información se ha enviado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                For Each r As DataGridViewRow In dwItem.Rows
                    r.Cells(seleccion.Index).Value = False
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub generarOp()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim utilserv As New ClsUtilidadesServidor
            Dim us As String = Trim(ClsInterbloqueos.ElementoBloqueado(Convert.ToInt32(r.Cells(id.Index).Value), ClsEnums.ModulosAplicacion.MODULO_GENERACION_ORDEN_PED))
            If String.IsNullOrEmpty(us) Or My.Settings.UsuarioActivo.Equals(us) Or My.Settings.Es_Desarrollador Then
                If Not My.Settings.Es_Desarrollador And String.IsNullOrEmpty(us) Then
                    ClsInterbloqueos.Bloquear(Convert.ToInt32(r.Cells(id.Index).Value),
                                              ClsEnums.ModulosAplicacion.MODULO_GENERACION_ORDEN_PED,
                                              My.Settings.UsuarioActivo)
                End If
                Dim frmGenerarOp As New frmGenerarOP
                With frmGenerarOp
                    .IdContrato = Convert.ToInt32(r.Cells(id.Index).Value)
                    .Tipo_Operacion = ClsEnums.TiOperacion.MODIFICAR
                    .WindowState = FormWindowState.Maximized
                    .MdiParent = Me.MdiParent
                End With
                frmGenerarOp.Show()
            Else
                MsgBox("Este contrato esta siendo utilizado por el usuario: " &
                       utilserv.TraerNombreDirectorio(us), MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmListarOrdenesPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mOrdenDeProduccion = New ClsOrdenDePedido
            mOrdenDeProduccion.traerActivos(dwItem.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseClick
        Try
            If e.Button = MouseButtons.Right And e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItem.Rows(e.RowIndex)
                For Each row As DataGridViewRow In dwItem.Rows
                    If row.Index <> r.Index Then
                        row.Selected = False
                    End If
                Next
                r.Selected = True

                Dim menu As New ContextMenuStrip
                If CInt(r.Cells(Idestado.Index).Value) = ClsEnums.Estados.PARCIAL Then
                    menu.Items.Add("Modificar", Nothing, AddressOf modificar)
                End If
                If CInt(r.Cells(seleccion.Index).EditedFormattedValue) = True Then
                    If CInt(r.Cells(Idestado.Index).Value) <> ClsEnums.Estados.RECHAZADO_PRODUCCION Then
                        menu.Items.Add("Enviar a Cliente", Nothing, AddressOf EnviarCorreoCliente)
                    End If
                End If
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class