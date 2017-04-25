Imports Datos
Public Class ClsFormatoDocxContrato

#Region "Variables"

#End Region

#Region "Procedimientos"

    Public Sub Ingresar(idcont As Integer, iddoc As Integer, header As String,
                        doc As String, footer As String, usuario As String, tipo As Integer,
                        altoencabe As Decimal, altofooter As Decimal)
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

#Region "Funciones"

    Public Function TraerxIdContrato(idc As Integer, tipo As Integer) As DataTable

        Try
            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerUltimoxIdContrato(idc As Integer, tipo As Integer) As DataTable
        Try
            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class

