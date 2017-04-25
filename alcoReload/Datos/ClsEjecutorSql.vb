Imports System.Data.SqlClient
Public Class ClsEjecutorSql


    Public Function EjecutarSP(ByVal nombre_procedimiento As String,
                                ByVal dicParametros As Dictionary(Of String, Object)) As DataTable
        Dim conSql As New SqlConnection(My.Settings.alcoingConnectionString)
        Dim dataAdapter As New SqlDataAdapter(nombre_procedimiento, conSql)
        EjecutarSP = New DataTable
        Try
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            dicParametros.ToList.ForEach(Sub(parametros)
                                             dataAdapter.SelectCommand.Parameters.AddWithValue(parametros.Key, parametros.Value)
                                         End Sub)
            dataAdapter.Fill(EjecutarSP)
        Catch ex As Exception
            Throw New Exception(ex.Message & ": " & nombre_procedimiento, ex.InnerException)
        Finally
            dataAdapter = Nothing
            conSql.Close()
        End Try
    End Function

End Class
