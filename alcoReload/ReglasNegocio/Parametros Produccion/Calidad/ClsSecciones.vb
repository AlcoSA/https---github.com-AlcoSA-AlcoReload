Imports Datos

Public Class ClsSecciones
#Region "Variables"
    Private taSecciones As New dsAlcoProduccionTableAdapters.tp015_seccionesTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, prefijo As String, descripcion As String, encargado As String, idEstado As Integer)
        Try
            taSecciones.Insert(usuario, prefijo, descripcion, encargado, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(prefijo As String, descripcion As String, encargado As String, usuario As String,
                         idEstado As Integer, id As Integer)
        taSecciones.Update(prefijo, descripcion, encargado, usuario, idEstado, id, id)
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of seccion)
        Try
            TraerTodos = New List(Of seccion)
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp015_selectAllTableAdapter
            Dim txAll As dsAlcoProduccion.sp_tp015_selectAllDataTable = taAll.GetData()
            For Each sec As dsAlcoProduccion.sp_tp015_selectAllRow In txAll
                TraerTodos.Add(New seccion(sec.id, sec.fechaCreacion, sec.usuarioCreacion, sec.prefijo, sec.descripcion,
                                           sec.encargado, sec.usuarioModi, sec.fechaModi, sec.idEstado, sec.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(id As Integer) As seccion
        Try
            Dim lista As List(Of seccion) = TraerTodos()
            TraerxId = lista.FirstOrDefault(Function(a) a.Id = id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteRegistro(prefijo As String) As Boolean
        Try
            Dim list As List(Of seccion) = TraerTodos().Where(Function(a) a.Prefijo = prefijo).ToList
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
Public Class seccion
    Inherits ClsBaseParametros
#Region "Variables"
    Private _prefijo As String
    Private _descripcion As String
    Private _encargado As String
#End Region
#Region "Propiedades"
    Public Property Prefijo() As String
        Get
            Return _prefijo
        End Get
        Set(ByVal value As String)
            _prefijo = value
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
    Public Property Encargado() As String
        Get
            Return _encargado
        End Get
        Set(ByVal value As String)
            _encargado = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, prefijo As String, descripcion As String,
                   encargado As String, usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _prefijo = prefijo
            _descripcion = descripcion
            _encargado = encargado
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = FechaModificacion
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
