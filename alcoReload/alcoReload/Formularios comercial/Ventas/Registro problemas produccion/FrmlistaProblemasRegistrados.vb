Imports ReglasNegocio

Public Class FrmlistaProblemasRegistrados
#Region "Variables"
    Private actualizar As Boolean = False
#End Region
#Region "Procedimientos"
    Private Sub modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New FrmRegistroProblemasProduccion
            frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
            frm.Curid = r.Cells(id.Index).Value
            frm.MdiParent = Me.Parent.Parent
            frm.Show()
            actualizar = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verSolucion()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New FrmVerSolucion
            frm.IdEncabezado = r.Cells(id.Index).Value
            frm.Consecutivo = r.Cells(consecutivo.Index).Value
            frm.Estado = r.Cells(estado.Index).Value
            frm.FechaRegistro = r.Cells(fechaRegistro.Index).Value
            frm.Vendedor = r.Cells(vendedor.Index).Value
            frm.IdSeccion = r.Cells(idSeccion.Index).Value
            frm.Seccion = r.Cells(seccion.Index).Value
            frm.Nit = r.Cells(nit.Index).Value
            frm.Cliente = r.Cells(cliente.Index).Value
            frm.CodigoObra = r.Cells(codigoObra.Index).Value
            frm.Obra = r.Cells(obra.Index).Value
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmlistaProblemasRegistrados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mEncabezado As New ClsEncabezadoProblemasP
            mEncabezado.TraerTodos(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    If CInt(r.Cells(idEstadoSolucion.Index).Value) <> ClsEnums.Estados.ANULADO Then
                        If CInt(r.Cells(idEstadoSolucion.Index).Value) = ClsEnums.Estados.EN_ELABORACION And
                        CInt(r.Cells(idEstado.Index).Value) = ClsEnums.Estados.ACTIVO Then
                            menu.Items.Add("Modificar", Nothing, AddressOf modificar)
                        ElseIf CInt(r.Cells(idEstadoSolucion.Index).Value) = ClsEnums.Estados.SOLUCIONADO_PARCIAL OrElse
                            CInt(r.Cells(idEstadoSolucion.Index).Value) = ClsEnums.Estados.SOLUCIONADO Then
                            menu.Items.Add("Ver Solución", Nothing, AddressOf verSolucion)
                        End If
                        menu.Show(MousePosition)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmlistaProblemasRegistrados_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If actualizar Then
            Dim mEncabezado As New ClsEncabezadoProblemasP
            mEncabezado.TraerTodos(dwItems.TablaDatos)
        End If
        actualizar = False
    End Sub
End Class