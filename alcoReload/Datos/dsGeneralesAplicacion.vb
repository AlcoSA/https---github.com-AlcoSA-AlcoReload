Partial Class dsGeneralesAplicacion
    Partial Public Class sp_tg014_selectByIdEncabeDataTable
        Private Sub sp_tg014_selectByIdEncabeDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.fg012_indObligatorioColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class
End Class
