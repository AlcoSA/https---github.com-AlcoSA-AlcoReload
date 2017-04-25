Public Class FrmPeticionNumeroCuerposNorma
#Region "props"
    Public Property Numero_Cuerpos As Integer
        Get
            Return Convert.ToInt32(nudnumerocuerpos.Value)
        End Get
        Set(value As Integer)
            If value >= 1 Then
                nudnumerocuerpos.Value = value
            End If
        End Set
    End Property
#End Region
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class