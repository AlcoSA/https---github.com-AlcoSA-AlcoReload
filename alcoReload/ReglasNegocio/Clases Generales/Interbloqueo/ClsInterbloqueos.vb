Imports Datos
Public Class ClsInterbloqueos
    Public Shared Sub Bloquear(consecutivo As Integer, idmodulo As Integer, usuario As String)
        Try
            Dim tabloqueos As New dsGeneralesAplicacionTableAdapters.tg002_bloqueomodulosTableAdapter
            tabloqueos.Insert(consecutivo, idmodulo, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Shared Sub Desbloquear(consecutivo As Integer, idmodulo As Integer)
        Try
            Dim tabloqueos As New dsGeneralesAplicacionTableAdapters.tg002_bloqueomodulosTableAdapter
            tabloqueos.Delete(consecutivo, idmodulo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Shared Function ElementoBloqueado(consecutivo As Integer, idmodulo As Integer) As String
        Try
            Dim tabloqueos As New dsGeneralesAplicacionTableAdapters.tg002_bloqueomodulosTableAdapter
            Dim fint As dsGeneralesAplicacion.tg002_bloqueomodulosRow = tabloqueos.GetData().FirstOrDefault(Function(x) x.fg002_consecutivo = consecutivo And x.fg002_rowidmodulo = idmodulo)
            If fint IsNot Nothing Then
                Return fint.fg002_usuario
            End If
            Return String.Empty
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
