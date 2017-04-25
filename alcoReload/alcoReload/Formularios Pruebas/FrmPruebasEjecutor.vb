Imports Formulador
Public Class FrmPruebasEjecutor
#Region "Variables"
    Private formu As Ejecutor
#End Region
    Private Sub FrmPruebasEjecutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            formu = New Ejecutor()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btncalcular_Click(sender As Object, e As EventArgs) Handles btncalcular.Click
        Try
            If Not String.IsNullOrEmpty(txtformula.Text) Then
                lbresultado.Text = formu.Parse(txtformula.Text)
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class