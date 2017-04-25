Imports Datos
Public Class ClsGruposSeguridad
#Region "Variables"
    Private tagrupos As New dsGeneralesAplicacionTableAdapters.tg006_gruposseguridadTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, grupo As String, descripcion As String, estado As Integer)
        Try
            tagrupos.Insert(usuario, grupo, descripcion, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(grupo As String, descripcion As String, usuario As String, estado As Integer, id As Integer)
        Try
            tagrupos.Update(grupo, descripcion, usuario, estado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of GrupoSeguridad)
        TraerTodos = New List(Of GrupoSeguridad)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg006_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg006_selectAllDataTable = ta.GetData()
            For Each d As dsGeneralesAplicacion.sp_tg006_selectAllRow In tb.Rows
                TraerTodos.Add(New GrupoSeguridad(d.Id, d.Fecha_creacion, d.Usuario_creacion, d.Grupo, d.Descripcion, d.Fecha_modificacion,
                                                    d.Usuario_modificacion, d.Id_Estado, d.Estado))
            Next
            tabla = tb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporEstado(estado As Integer) As List(Of GrupoSeguridad)
        TraerporEstado = New List(Of GrupoSeguridad)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg006_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg006_selectAllRow() = ta.GetData().Where(Function(x) x.Id_Estado = estado).ToArray()
            For Each d As dsGeneralesAplicacion.sp_tg006_selectAllRow In tb
                TraerporEstado.Add(New GrupoSeguridad(d.Id, d.Fecha_creacion, d.Usuario_creacion, d.Grupo, d.Descripcion, d.Fecha_modificacion,
                                                    d.Usuario_modificacion, d.Id_Estado, d.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class GrupoSeguridad
    Inherits ClsBaseParametros
#Region "Variables"
    Private _grupo As String
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property Grupo As String
        Get
            Return _grupo
        End Get
        Set(value As String)
            _grupo = value
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
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub

    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
               grupo As String, descripcion As String, fechamodificacion As DateTime, usuariomodificacion As String,
               idestado As Integer, estado As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = Trim(usuariocreacion)
        _grupo = Trim(grupo)
        _descripcion = Trim(descripcion)
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = Trim(usuariomodificacion)
        Me.IdEstado = idestado
        Me.Estado = Trim(estado)
    End Sub

#End Region
End Class
