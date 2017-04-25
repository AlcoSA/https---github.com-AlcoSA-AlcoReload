Imports Datos
Public Class ClstiposEscritura

#Region "Variables"

#End Region

#Region "Procedimientos"

    Public Sub Ingresar(tipo As String, estado As Integer)
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modificar(tipo As String, estado As Integer, id As Integer)
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

#Region "Funciones"

    Public Function TraerTodas() As DataTable
        TraerTodas = Nothing
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxEstado(estado As Integer) As DataTable
        TraerxEstado = Nothing
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class
