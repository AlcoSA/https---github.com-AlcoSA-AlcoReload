Imports Datos
Public Class ClsEjecucionSeguridad
    Public Function PermisosCompletosporidUsuario(idusuario As Integer) As String()
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg008_selectpermisosUsuarioTableAdapter
            Return ta.GetData(idusuario).Select(Function(p) p.Codigo).ToArray()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class


