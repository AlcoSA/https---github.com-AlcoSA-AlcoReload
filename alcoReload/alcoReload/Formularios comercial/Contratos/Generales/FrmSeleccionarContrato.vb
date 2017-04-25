Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class FrmSeleccionarContrato

#Region "Variables"
    Private mContrato As clsContratos
    Private fuenteInicial As DataTable = Nothing
    Private _idcontrato As Integer = 0
#End Region
#Region "Propiedades"
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub FrmSeleccionarContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mContrato = New clsContratos
            fuenteInicial = New DataTable
            mContrato.TraerTodos(dwItem.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            DialogResult = DialogResult.Cancel
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            If dwItem.Rows.Count > 0 Then
                If dwItem.SelectedRows.Count >= 0 Then
                    dwItem.Rows(0).Selected = True
                End If
                Dim r As DataGridViewRow = dwItem.SelectedRows(0)
                _idcontrato = Convert.ToInt32(r.Cells(id.Index).Value)
                DialogResult = DialogResult.OK
            Else
                DialogResult = DialogResult.Cancel
            End If
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseDoubleClick
        Try
            _idcontrato = Convert.ToInt32(dwItem.Item(id.Index, e.RowIndex).Value)
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
End Class