Imports Datos
Public Class ClsTercerosProduccion
#Region "Variables"
    Private taterceros As New dsAlcoProduccionTableAdapters.tp001_tercerosProduccionTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(tercero As String, direccion As String,
                             telefono As String, usuario As String,
                             estado As Integer) As Integer
        Try
            Return taterceros.Insert1(usuario, tercero, direccion, telefono, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(tercero As String, direccion As String, telefono As String,
                         usuario As String, estado As Integer, id As Integer)
        Try
            taterceros.Update1(tercero, direccion, telefono, usuario,
                               estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of TerceroProduccion)
        TraerTodos = New List(Of TerceroProduccion)
        Try
            Dim tb As dsAlcoProduccion.tp001_tercerosProduccionDataTable = taterceros.GetData()
            tb.Rows.Cast(Of dsAlcoProduccion.tp001_tercerosProduccionRow).ToList.ForEach(
                Sub(d)
                    TraerTodos.Add(New TerceroProduccion(d.Id, d.tercero, d.direccion,
                                                         d.telefono, d.usuario_creacion,
                                                         d.fecha_creacion, d.usuario_modificacion,
                                                         d.fecha_modificacion, d.id_estado,
                                                         d.estado))
                End Sub)
            If tb.Rows.Count > 0 Then
                tabla = tb.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporEstado(estado As Integer) As List(Of TerceroProduccion)
        TraerporEstado = New List(Of TerceroProduccion)
        Try
            TraerporEstado.AddRange(TraerTodos().Where(Function(x) x.IdEstado = estado).ToArray())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class TerceroProduccion : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Private _Telefono As String
    Public Property telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
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
    Public Sub New(id As Integer, descripcion As String, direccion As String, telefono As String,
                   usuarioCreacion As String, fechaCreacion As DateTime, usuarioModi As String, fechaModi As DateTime,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            _descripcion = descripcion
            _direccion = direccion
            _Telefono = telefono
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

End Class
