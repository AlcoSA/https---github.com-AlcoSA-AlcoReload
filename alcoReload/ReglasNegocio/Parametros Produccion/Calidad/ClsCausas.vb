Imports Datos

Public Class ClsCausas
#Region "Variables"
    Private taCausas As New dsAlcoProduccionTableAdapters.tp017_causasTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, nombre As String, descripcion As String, idEstado As Integer)
        Try
            taCausas.Insert(usuario, nombre, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(nombre As String, descripcion As String, Usuario As String,
                         idEstado As Integer, id As Integer)
        Try
            taCausas.Update(nombre, descripcion, Usuario, idEstado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of causa)
        Try
            TraerTodos = New List(Of causa)
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp017_selectAllTableAdapter
            Dim txAll As dsAlcoProduccion.sp_tp017_selectAllDataTable = taAll.GetData()
            For Each cau As dsAlcoProduccion.sp_tp017_selectAllRow In txAll
                TraerTodos.Add(New causa(cau.id, cau.fechaCreacion, cau.usuarioCreacion, cau.nombre, cau.descripcion,
                                         cau.usuarioModi, cau.fechaModi, cau.idEstado, cau.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteRegistro(nombre As String) As Boolean
        Try
            Dim list As List(Of causa) = TraerTodos().Where(Function(a) a.Nombre = RTrim(nombre)).ToList
            If list.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class causa
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombre As String
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, nombre As String,
                   descripcion As String, usuarioModi As String, fechaModi As DateTime, idEstado As Integer,
                   estado As String)
        Me.Id = id
        Me.FechaCreacion = fechaCreacion
        Me.UsuarioCreacion = usuarioCreacion
        _nombre = nombre
        _descripcion = descripcion
        Me.UsuarioModificacion = usuarioModi
        Me.FechaModificacion = fechaModi
        Me.IdEstado = idEstado
        Me.Estado = estado
    End Sub
#End Region
End Class