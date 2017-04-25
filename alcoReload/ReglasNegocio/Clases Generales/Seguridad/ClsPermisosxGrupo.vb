Imports Datos
Public Class ClsPermisosxGrupo
#Region "Variables"
    Private tausuarios As New dsGeneralesAplicacionTableAdapters.tg007_permisosxGruposTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuarioCreacion As String, idGrupo As Integer, codigoControl As String)
        Try
            tausuarios.sp_tg007_insert(usuarioCreacion, idGrupo, codigoControl)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(usuarioCreacion As String, idGrupo As Integer, codigoControl As String, id As Integer)
        Try
            tausuarios.sp_tg007_update(usuarioCreacion, idGrupo, codigoControl, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Delete(idGrupo As Integer)
        Try
            tausuarios.sp_tg007_deleteByIdGrupo(idGrupo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of permisoGrupo)
        TraerTodos = New List(Of permisoGrupo)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg007_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg007_selectAllDataTable = ta.GetData()

            For Each fila As dsGeneralesAplicacion.sp_tg007_selectAllRow In tb.Rows
                TraerTodos.Add(New permisoGrupo(fila.Id, fila.FechaCreacion, fila.UsuarioCreacion, fila.idGrupo, fila.CodigoControl))
            Next

            tabla = tb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class permisoGrupo
    Inherits ClsBaseParametros
#Region "Variables"

    Private _idGrupo As Integer
    Public Property idGrupo() As Integer
        Get
            Return _idGrupo
        End Get
        Set(ByVal value As Integer)
            _idGrupo = value
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
                  idgrupo As Integer, codigoControl As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = RTrim(usuariocreacion)
        _idGrupo = idgrupo
        _codigoControl = RTrim(codigoControl)
    End Sub
#End Region
End Class
