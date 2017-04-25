Public Class frmPeticionCadenaTexto
#Region "vars"

#End Region
#Region "props"
    Public Property Mensaje As String
        Get
            Return lbmensaje.Text
        End Get
        Set(value As String)
            lbmensaje.Text = value
        End Set
    End Property
    Public Property Dato As String
        Get
            Return txtdato.Text
        End Get
        Set(value As String)
            txtdato.Text = value
        End Set
    End Property

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

End Class