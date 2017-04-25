Imports Datos
Public Class ClsPermisosxUsuario
#Region "Variables"
    Private tausuarios As New dsGeneralesAplicacionTableAdapters.tg008_permisosxUsuarioTableAdapter
#End Region

#Region "Procedimientos"
    Public Sub Insertar(usuarioCreacion As String, idUsuario As Integer, codigoControl As String)
        Try
            tausuarios.sp_tg008_insert(usuarioCreacion, idUsuario, codigoControl)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(usuarioCreacion As String, idUsuario As Integer, codigoControl As String, id As Integer)
        Try
            tausuarios.sp_tg008_update(usuarioCreacion, idUsuario, codigoControl, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Delete(idUsuario As Integer)
        Try
            tausuarios.sp_tg008_deleteByidUsuario(idUsuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of permisoUsuario)
        TraerTodos = New List(Of permisoUsuario)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg008_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg008_selectAllDataTable = ta.GetData()
            For Each fila As dsGeneralesAplicacion.sp_tg008_selectAllRow In tb.Rows
                TraerTodos.Add(New permisoUsuario(fila.id, fila.FechaCreacion, fila.usuarioCreacion, fila.idUsuario, fila.CodigoControl))
            Next
            tabla = tb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

End Class
Public Class permisoUsuario
    Inherits ClsBaseParametros
#Region "Variables"

    Private _idUsuario As Integer
    Public Property idUsuario() As Integer
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As Integer)
            _idUsuario = value
        End Set
    End Property
    Private _codigoControl As String
    Public Property codigoControl() As String
        Get
            Return _codigoControl
        End Get
        Set(ByVal value As String)
            _codigoControl = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
    End Sub

    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                  idusuario As Integer, codigoControl As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = RTrim(usuariocreacion)
        _idUsuario = idusuario
        _codigoControl = RTrim(codigoControl)
    End Sub
#End Region
End Class