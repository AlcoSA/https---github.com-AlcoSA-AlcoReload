Imports Datos

Public Class ClsHistModiCotiza
#Region "Variables"
    Private taHistModiCotizacion As New dsAlcoComercialTableAdapters.tc024_historialModiCotizaTableAdapter
#End Region
#Region "procedimientos"
    Public Sub Insert(fc024_rowidCotiza As Integer, fc024_usuarioModificacion As String, fc024_accion As String)
        Try
            taHistModiCotizacion.sp_tc024_insert(fc024_rowidCotiza, fc024_usuarioModificacion, fc024_accion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
