Public Class FrmPruebasColumnasGrid
    Private Sub FrmPruebasColumnasGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dwcolumnas.Rows.Add(10)
            dwcolumnas.Item(1, 0).Value = 45
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class