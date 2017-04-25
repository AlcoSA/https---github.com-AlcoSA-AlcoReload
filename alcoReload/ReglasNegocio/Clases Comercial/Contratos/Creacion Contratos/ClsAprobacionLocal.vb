Imports Datos

Public Class ClsAprobacionLocal
#Region "Variables"
    Private taAprobacion As New dsAlcoComercial2TableAdapters.tc109_aprobacionLocalTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idCotiza As Integer, idEstadoAprobacion As Integer)
        Try
            taAprobacion.sp_tc109_insert(usuario, idCotiza, idEstadoAprobacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class