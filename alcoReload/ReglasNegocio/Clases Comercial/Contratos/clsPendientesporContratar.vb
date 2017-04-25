Imports Datos
Public Class clsPendientesporContratar
#Region "Variables"
    Private dapendientes As New dsAlcoContratosTableAdapters.tc059_cotizacionespendientesporcontratarTableAdapter
#End Region

#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idcotizacion As Integer, idestado As Integer)
        Try
            dapendientes.sp_tc059_insert(usuario, idcotizacion, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modificar(id As Integer, usuario As String, idcotizacion As Integer, idestado As Integer)
        Try
            dapendientes.Update(idcotizacion, usuario, idestado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Eliminar(id As Integer)
        Try
            dapendientes.Delete(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

    Public Function TraerTodas() As DataTable
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc059_selectparaContratarTableAdapter
            Return ta.GetData().Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
