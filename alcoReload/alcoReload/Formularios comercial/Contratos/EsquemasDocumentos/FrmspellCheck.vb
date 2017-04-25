Public Class FrmspellCheck

#Region "Variables"
    Dim mwordind As Integer = 0
#End Region

#Region "Propiedades"

#End Region

#Region "Procedimientos"

    Private Sub marcarPalabra()
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

    Private Sub FrmspellCheck_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnignorar_Click(sender As Object, e As System.EventArgs) Handles btnignorar.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnignorartodo_Click(sender As Object, e As System.EventArgs) Handles btnignorartodo.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As System.EventArgs) Handles btnagregar.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnreemplazar_Click(sender As Object, e As System.EventArgs) Handles btnreemplazar.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnreemplazartodo_Click(sender As System.Object, e As System.EventArgs) Handles btnreemplazartodo.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub lbsugerencias_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lbsugerencias.SelectedIndexChanged
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class