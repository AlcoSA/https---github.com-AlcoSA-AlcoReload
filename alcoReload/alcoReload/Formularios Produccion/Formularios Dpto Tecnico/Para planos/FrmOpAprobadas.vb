Imports ReglasNegocio
Imports Informes

Public Class FrmOpAprobadas
#Region "Variables"
    Private idOp As Integer
#End Region
#Region "Procedimientos"

#End Region
    Private Sub FrmOpAprobadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mParaPlanos As New ClsEncabeOrdenProd
            dwItem.TablaDatos = mParaPlanos.TraerOrdenesPedidoAprobadas()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub generarplanos()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim genplano As FrmGenerarPlanos = Nothing
            For Each f As Form In My.Application.OpenForms
                If (TypeOf f Is FrmGenerarPlanos) Then
                    If DirectCast(f, FrmGenerarPlanos).IdOrdenPedido = Convert.ToInt32(r.Cells(idOped.Index).Value) Then
                        genplano = f
                    End If
                End If
            Next
            If genplano Is Nothing Then
                genplano = New FrmGenerarPlanos()
                genplano.MdiParent = Me.MdiParent
                genplano.IdOrdenPedido = Convert.ToInt32(r.Cells(idOped.Index).Value)
                genplano.IdOrdenProduccion = Convert.ToInt32(r.Cells(id.Index).Value)
                genplano.Show()
            Else
                genplano.BringToFront()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseDown
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 And e.Button = MouseButtons.Right Then
                dwItem.Rows(e.RowIndex).Selected = True
                idOp = dwItem.Rows(e.RowIndex).Cells(id.Index).Value
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Generar Planos", Nothing, AddressOf generarplanos)
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class