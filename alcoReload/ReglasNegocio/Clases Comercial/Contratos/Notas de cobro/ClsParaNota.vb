Imports Datos

Public Class ClsParaNota
#Region "Variables"
    Private taParaNota As New dsAlcoContratosTableAdapters.tc055_ParaNotasTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuarioCreacion As String, idNotaCobro As Integer, idTipoObra As Integer)
        Try
            taParaNota.sp_tc055_insert(usuarioCreacion, idNotaCobro, idTipoObra)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class