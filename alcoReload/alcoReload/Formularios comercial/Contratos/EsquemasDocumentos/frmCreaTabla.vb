Public Class frmCreaTabla

    Private Sub btonCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btonCancelar.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btonAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btonAceptar.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class