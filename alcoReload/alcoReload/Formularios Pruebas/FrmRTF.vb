Public Class FrmRTF
    Private Sub rtxbase_TextChanged(sender As Object, e As EventArgs) Handles rtxbase.TextChanged
        Try
            rtxrtf.Text = rtxbase.Rtf
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class