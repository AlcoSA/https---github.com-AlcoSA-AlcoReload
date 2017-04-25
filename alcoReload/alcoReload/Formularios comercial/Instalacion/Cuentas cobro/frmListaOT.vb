Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class frmListaOT
#Region "Variables"
    Private loadCompleted As Boolean = False
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Procedimientos"
    Private Sub ObjetoyPara()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim mContrato As New clsContratos
            Dim cont As contrato = mContrato.TraerObjetoYPara(r.Cells(idContrato.DataPropertyName).Value)
            Dim info As New ContextMenuStrip
            info.Items.Add("Contrato: " & cont.nContrato)
            info.Items.Add("Objeto: " & cont.Objeto)
            info.Items.Add("Para: " & cont.Para)
            info.Show(MousePosition)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub abrirCuentaCobro()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New frmCuentaCobroContrato
            frm.obra = r.Cells(obra.DataPropertyName).Value
            frm.IdContrato = r.Cells(idContrato.DataPropertyName).Value
            frm.IdProveedor = r.Cells(idProveedor.DataPropertyName).Value
            frm.Proveedor = r.Cells(proveedor.DataPropertyName).Value
            If frm.ShowDialog() = DialogResult.OK Then
                frmListaOT_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmListaOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mOrdenTrabajo As New ClsOrdenTrabajo
            mOrdenTrabajo.TraerObras(dwItems.TablaDatos)
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
                    menu.Items.Add("Mostrar objeto y para", Nothing, AddressOf ObjetoyPara)
                    menu.Items.Add("Realizar cuenta de cobro", Nothing, AddressOf abrirCuentaCobro)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class