Imports Datos
Public Class ClsMovitoMotivoDevolucionOped
#Region "Variables"
    Private tamovitodevol As New dsAlcoProduccionTableAdapters.tp014_MovitoDevMotivosTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(idop As Integer, idmotivo As Integer, usuario As String)
        Try
            tamovitodevol.Insert(usuario, idop, idmotivo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(idop As Integer, idmotivo As Integer, usuario As String, id As Integer)
        Try
            tamovitodevol.Update(idop, idmotivo, usuario, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarporIdOp(idop As Integer)
        Try
            tamovitodevol.Delete(idop)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdOp(idop As Integer) As List(Of MvtoMotivoDevolucionOP)
        TraerporIdOp = New List(Of MvtoMotivoDevolucionOP)
        Try
            Dim ta As New dsAlcoProduccionTableAdapters.sp_tp014_selectByIdOpTableAdapter
            Dim tmov As dsAlcoProduccion.sp_tp014_selectByIdOpDataTable = ta.GetData(idop)
            For Each m As dsAlcoProduccion.sp_tp014_selectByIdOpRow In tmov.Rows
                TraerporIdOp.Add(New MvtoMotivoDevolucionOP(m.id, m.idop, m.id_motivo, m.motivo,
                                                            m.usuario_creacion, m.fecha_creacion, m.usuario_modificacion,
                                                            m.fecha_modificacion, 1, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class MvtoMotivoDevolucionOP
    Inherits MotivoDevolucionOp
#Region "Variables"
    Private _idop As Integer = 0
    Private _idmotivo As Integer = 0
#End Region
#Region "Propiedades"
    Public Property IdMotivo As Integer
        Get
            Return _idmotivo
        End Get
        Set(value As Integer)
            _idmotivo = value
        End Set
    End Property
    Public Property IdOP As Integer
        Get
            Return _idop
        End Get
        Set(value As Integer)
            _idop = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idop As Integer, idmotivo As Integer, motivo As String, usuarioCreacion As String,
                   fechaCreacion As DateTime, usuariomodificacion As String,
                   fechamodificacion As DateTime, idestado As Integer, estado As String)
        Try
            Me.Id = id
            _idop = idop
            _idmotivo = idmotivo
            Descripcion = motivo
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = usuariomodificacion
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

End Class
