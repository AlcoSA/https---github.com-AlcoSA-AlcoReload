Imports ReglasNegocio
Public Class FrmConectoresDisponibles
#Region "vars"
    Private _idconector As Integer = 0
    Private _idplano As Integer = 0
#End Region
#Region "props"
    Public WriteOnly Property IdConector As Integer
        Set(value As Integer)
            _idconector = value
        End Set
    End Property
    Public ReadOnly Property IdPlano As Integer
        Get
            Return _idplano
        End Get
    End Property
#End Region
    Private Sub FrmConectoresDisponibles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim enc As New ClsEncabeEnlaceConector
            Dim l_enc = enc.TraerporIdConector(_idconector)
            Dim enc_item As New EncabezadoEnlaceConector()
            enc_item.NombrePlano = "Nuevo"
            l_enc.Insert(0, enc_item)
            l_enc.ForEach(Sub(x)
                              Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                              r.Cells(id.Index).Value = x.Id
                              r.Cells(nombreplano.Index).Value = x.NombrePlano
                          End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwitems.CellMouseDoubleClick
        Try
            If e.RowIndex >= 0 Then
                _idplano = Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value)
                DialogResult = DialogResult.OK
                Close()
            End If
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
            _idplano = Convert.ToInt32(dwitems.SelectedRows(0).Cells(id.Index).Value)
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class