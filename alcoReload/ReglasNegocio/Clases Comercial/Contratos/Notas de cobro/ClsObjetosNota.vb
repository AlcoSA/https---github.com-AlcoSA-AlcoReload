Imports Datos

Public Class ClsObjetosNota
#Region "Variables"
    Private taObjetosNota As New dsAlcoContratosTableAdapters.tc054_objetosNotasTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuarioCreacion As String, idNotaCobro As Integer, idObjeto As Integer)
        Try
            taObjetosNota.sp_tc054_insert(usuarioCreacion, idNotaCobro, idObjeto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
