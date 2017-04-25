Imports ReglasNegocio

Public Class FrmRegistroPolizas
#Region "Variables"
    Private fuenteInicial As DataTable
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub PrepararDatos()
        Try
            Dim mPolizaContrato As New clsPolizasContratos
            mPolizaContrato.TraerTodosParaPoliza(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub AgregarPoliza()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New FrmAddPoliza
            frm.IdContrato = r.Cells(id.DataPropertyName).Value
            frm.NumContrato = r.Cells(nContrato.DataPropertyName).Value
            frm.Nit = r.Cells(nit.DataPropertyName).Value
            frm.Cliente = r.Cells(cliente.DataPropertyName).Value
            frm.CodSuc = r.Cells(codObra.DataPropertyName).Value
            frm.Sucursal = r.Cells(obra.DataPropertyName).Value

            If frm.ShowDialog() = DialogResult.OK Then
                PrepararDatos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ModificarPoliza()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New FrmAddPoliza
            frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
            frm.IdContrato = r.Cells(id.DataPropertyName).Value
            frm.NumContrato = r.Cells(nContrato.DataPropertyName).Value
            frm.Nit = r.Cells(nit.DataPropertyName).Value
            frm.Cliente = r.Cells(cliente.DataPropertyName).Value
            frm.CodSuc = r.Cells(codObra.DataPropertyName).Value
            frm.Sucursal = r.Cells(obra.DataPropertyName).Value

            If frm.ShowDialog() = DialogResult.OK Then
                PrepararDatos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmRegistroPolizas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PrepararDatos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.Button = MouseButtons.Right Then
                Dim col As DataGridViewColumn = dwItems.Columns(e.ColumnIndex)
                dwItems.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Agregar póliza", Nothing, AddressOf AgregarPoliza)
                menu.Items.Add("Modificar póliza", Nothing, AddressOf ModificarPoliza)
                menu.Items.Add("Activar contrato", Nothing)

                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class