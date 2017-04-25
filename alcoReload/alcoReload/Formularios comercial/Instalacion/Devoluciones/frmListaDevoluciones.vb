Imports ReglasNegocio

Public Class frmListaDevoluciones
#Region "Variables"
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub verDevolucion()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New frmVistaDevoluciones
            frm.IdDevolucion = r.Cells(id.DataPropertyName).Value
            frm.IdDocumento = r.Cells(idDocumento.DataPropertyName).Value
            frm.Documento = r.Cells(documento.DataPropertyName).Value
            frm.Consecutivo = r.Cells(consecutivo.DataPropertyName).Value
            frm.Obra = r.Cells(obra.DataPropertyName).Value
            frm.Vendedor = r.Cells(vendedor.DataPropertyName).Value
            frm.FechaCreacion = r.Cells(fechaCreacion.DataPropertyName).Value
            frm.Proveedor = r.Cells(proveedor.DataPropertyName).Value
            frm.Encargado = r.Cells(encargado.DataPropertyName).Value
            frm.IdEstado = r.Cells(idEstado.DataPropertyName).Value

            If frm.ShowDialog = DialogResult.OK Then
                frmListaDevoluciones_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmListaDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mDevoluciones As New ClsDevolucion
            mDevoluciones.TraerTodos(dwItems.TablaDatos)
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
                    menu.Items.Add("Ver devolución", Nothing, AddressOf verDevolucion)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class