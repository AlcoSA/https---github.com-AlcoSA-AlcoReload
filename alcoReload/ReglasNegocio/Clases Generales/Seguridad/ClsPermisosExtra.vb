Imports Datos
Public Class ClsPermisosExtra
#Region "Variables"
    Private taperme As New dsGeneralesAplicacionTableAdapters.tg010_permisoextraTableAdapter
#End Region

#Region "Procedimientos"

    Public Function Insertar(idmodulo As Integer, permiso As String, descripcion As String,
                             codigo As String, idestado As Integer, usuario As String) As Integer
        Try
            Return taperme.Insert(idmodulo, usuario, permiso, descripcion, codigo, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(usuario As String, idmodulo As Integer, permiso As String, descripcion As String,
                         codigo As String, idestado As Integer, id As Integer)
        Try
            taperme.Update(idmodulo, permiso, descripcion, codigo, usuario, idestado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

#Region "Funciones"
    Public Function TraerTodos() As List(Of PermisoExtra)
        TraerTodos = New List(Of PermisoExtra)
        Try
            Dim tapx As New dsGeneralesAplicacionTableAdapters.sp_tg010_selectAllTableAdapter
            Dim t As dsGeneralesAplicacion.sp_tg010_selectAllDataTable = tapx.GetData()
            For Each px As dsGeneralesAplicacion.sp_tg010_selectAllRow In t.Rows
                TraerTodos.Add(New PermisoExtra(px.Id, px.Usuario_creacion, px.Fecha_creacion, px.Permiso,
                                                px.Descripcion, px.Codigo, px.Id_modulo, px.Modulo, px.Fecha_modificacion,
                                                px.Usuario_modificacion, px.Id_estado, px.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdModulo(idmodulo As Integer) As List(Of PermisoExtra)
        TraerxIdModulo = New List(Of PermisoExtra)
        Try
            Dim tapx As New dsGeneralesAplicacionTableAdapters.sp_tg010_selectbyIdModuloTableAdapter
            Dim t As dsGeneralesAplicacion.sp_tg010_selectbyIdModuloDataTable = tapx.GetData(idmodulo)
            For Each px As dsGeneralesAplicacion.sp_tg010_selectbyIdModuloRow In t.Rows
                TraerxIdModulo.Add(New PermisoExtra(px.Id, px.Usuario_creacion, px.Fecha_creacion, px.Permiso,
                                                px.Descripcion, px.Codigo, px.Id_modulo, px.Modulo, px.Fecha_modificacion,
                                                px.Usuario_modificacion, px.Id_estado, px.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class PermisoExtra
    Inherits ClsBaseParametros
#Region "Variables"
    Private _permiso As String
    Private _descripcion As String
    Private _codigo As String
    Private _modulo As String
#End Region
#Region "Propiedades"
    Public Property Permiso As String
        Get
            Return _permiso
        End Get
        Set(value As String)
            _permiso = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property
    Public Property Modulo As String
        Get
            Return _modulo
        End Get
        Set(value As String)
            _modulo = value
        End Set
    End Property

#End Region
#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date,
                   permiso As String, descripcion As String, codigo As String, idmodulo As Integer, modulo As String,
                   fechamodificacion As Date, usuarioModificacion As String,
                   id_estado As Integer, estado As String)
        Me.Id = id
        Me.UsuarioCreacion = Trim(usuariocreacion)
        Me.FechaCreacion = fechacreacion
        _permiso = Trim(permiso)
        _descripcion = Trim(descripcion)
        _codigo = Trim(codigo)
        _modulo = Trim(modulo)
        Me.UsuarioModificacion = Trim(usuarioModificacion)
        Me.FechaModificacion = fechamodificacion
        Me.IdEstado = id_estado
        Me.Estado = Trim(estado)
    End Sub
#End Region
End Class


