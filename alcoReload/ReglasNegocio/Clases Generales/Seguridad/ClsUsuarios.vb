
Imports Datos

Public Class ClsUsuarios
#Region "Variables"
    Private tausuarios As New dsGeneralesAplicacionTableAdapters.tg004_usuariosTableAdapter
#End Region

#Region "Procedimientos"
    Public Sub Insertar(usuariocreacion As String, iddepartamento As Integer, idgrupo As Integer, idunoee As Integer,
                        usuario As String, idestado As Integer)
        Try
            tausuarios.Insert(usuariocreacion, iddepartamento, idgrupo, idunoee,
                              usuario, usuariocreacion, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(usuariomodificacion As String, iddepartamento As Integer, idgrupo As Integer, idunoee As Integer,
                        usuario As String, idestado As Integer, id As Integer)
        Try
            tausuarios.Update(iddepartamento, idgrupo, idunoee, usuario, usuariomodificacion, idestado, id)

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of Usuario)
        TraerTodos = New List(Of Usuario)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg004_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg004_selectAllDataTable = ta.GetData()

            For Each u As dsGeneralesAplicacion.sp_tg004_selectAllRow In tb.Rows
                TraerTodos.Add(New Usuario(u.Id, u.Fecha_creacion, u.Usuario_creacion, u.idunoee, u.unoee,
                                           u.iddepartamento, u.departamento, u.Id_grupo, u.Grupo, u.usuario, u.Fecha_modificacion, u.Usuario_modificacion,
                                           u.Id_Estado, u.Estado))
            Next
            tabla = tb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerpoUsuarioNt(usuario As String) As Usuario
        TraerpoUsuarioNt = New Usuario
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg004_selectAllTableAdapter
            Dim u As dsGeneralesAplicacion.sp_tg004_selectAllRow = ta.GetData().FirstOrDefault(Function(x) x.usuario.Trim() = usuario And x.Id_Estado = ClsEnums.Estados.ACTIVO)
            If Not IsNothing(u) Then
                TraerpoUsuarioNt = New Usuario(u.Id, u.Fecha_creacion, u.Usuario_creacion, u.idunoee, u.unoee,
                                           u.iddepartamento, u.departamento, u.Id_grupo, u.Grupo, u.usuario, u.Fecha_modificacion, u.Usuario_modificacion,
                                           u.Id_Estado, u.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerUsuariosUnoee() As DataTable
        Try
            Dim ta As New dsBUnoeeTableAdapters.sp_t522_UnoeeusuariosTableAdapter
            Return ta.GetData()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class Usuario
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idunoee As Integer = 0
    Private _unoee As String = String.Empty
    Private _iddepartamento As Integer = 0
    Private _departamento As String = String.Empty
    Private _idgrupo As Integer = 0
    Private _grupo As String = String.Empty
    Private _usuario As String = String.Empty
#End Region
#Region "Propiedades"
    Public Property IdUnoee As Integer
        Get
            Return _idunoee
        End Get
        Set(value As Integer)
            _idunoee = value
        End Set
    End Property
    Public Property Unoee As String
        Get
            Return _unoee
        End Get
        Set(value As String)
            _unoee = value
        End Set
    End Property
    Public Property IdDepartamento As Integer
        Get
            Return _iddepartamento
        End Get
        Set(value As Integer)
            _iddepartamento = value
        End Set
    End Property
    Public Property Departamento As String
        Get
            Return _departamento
        End Get
        Set(value As String)
            _departamento = value
        End Set
    End Property
    Public Property IdGrupo As Integer
        Get
            Return _idgrupo
        End Get
        Set(value As Integer)
            _idgrupo = value
        End Set
    End Property
    Public Property Grupo As String
        Get
            Return _grupo
        End Get
        Set(value As String)
            _departamento = value
        End Set
    End Property
    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub

    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idunoee As Integer, unoee As String, iddepartamento As Integer,
                   departamento As String, idgrupo As Integer, grupo As String, usuario As String, fechamodificacion As DateTime, usuariomodificacion As String,
                   idestado As Integer, estado As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = RTrim(usuariocreacion)
        _idunoee = idunoee
        _unoee = RTrim(unoee)
        _iddepartamento = iddepartamento
        _departamento = RTrim(departamento)
        _idgrupo = idgrupo
        _grupo = RTrim(grupo)
        _usuario = RTrim(usuario)
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = RTrim(usuariomodificacion)
        Me.IdEstado = idestado
        Me.Estado = RTrim(estado)
    End Sub
#End Region
End Class
