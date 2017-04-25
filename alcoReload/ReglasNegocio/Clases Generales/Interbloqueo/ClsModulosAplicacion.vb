Imports Datos
Public Class ClsModulosAplicacion
#Region "Variables"
    Private tamodulos As New dsGeneralesAplicacionTableAdapters.tg001_modulosAplicacionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, nombre As String, estado As Integer)
        Try
            tamodulos.Insert(usuario, nombre, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modificar(id As Integer, usuario As String, nombre As String, estado As Integer)
        Try
            tamodulos.Update(nombre, usuario, estado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of ModuloAplicacion)
        TraerTodos = New List(Of ModuloAplicacion)
        Try
            Dim dsg As New dsGeneralesAplicacionTableAdapters.sp_tg001_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg001_selectAllDataTable = dsg.GetData()
            For Each m As dsGeneralesAplicacion.sp_tg001_selectAllRow In tb.Rows
                TraerTodos.Add(New ModuloAplicacion(m.Id, m.Fecha_creacion, m.Usuario_creacion,
                                                    m.Nombre, m.Fecha_modificacion,
                                                    m.Usuario_modificacion, m.Id_estado, m.Estado))
            Next
            tabla = tb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxEstado(estado As Integer) As List(Of ModuloAplicacion)
        TraerxEstado = New List(Of ModuloAplicacion)
        Try
            Dim tb As dsGeneralesAplicacion.tg001_modulosAplicacionDataTable = tamodulos.TraerporEstado(estado)
            For Each m As dsGeneralesAplicacion.tg001_modulosAplicacionRow In tb.Rows
                TraerxEstado.Add(New ModuloAplicacion(m.fg001_rowid, m.fg001_fechacreacion, m.fg001_usuariocreacion,
                                                    m.fg001_nombre, m.fg001_fechamodificacion,
                                                    m.fg001_usuariomodificacion, m.fg001_rowidestado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class ModuloAplicacion
    Inherits ClsBaseParametros
#Region "Variables"
    Dim _nombre As String
#End Region

#Region "Propiedades"
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
#End Region

    Public Sub New()

    End Sub

    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   nombre As String, fechamodificacion As DateTime, usuariomodificacion As String,
                   idestado As Integer, estado As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = usuariocreacion
        _nombre = nombre
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = usuariomodificacion
        Me.IdEstado = idestado
        Me.Estado = estado
    End Sub

End Class
