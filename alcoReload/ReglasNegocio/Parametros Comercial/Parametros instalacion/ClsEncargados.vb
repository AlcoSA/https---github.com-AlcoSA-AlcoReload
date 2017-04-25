Imports Datos

Public Class ClsEncargados
#Region "Variables"
    Private taEncargado As New dsAlcoComercial2TableAdapters.tc087_EncargadosTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, nombreEncargado As String, idProveedor As Integer,
                        telefono As String, idEstado As Integer)
        Try
            taEncargado.Insert(DateTime.Now, usuario, nombreEncargado, idProveedor, telefono, usuario, DateTime.Now, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(idEncargado As Integer, nombreEncargado As String, idProveedor As Integer,
                         telefono As String, usuarioModi As String, idEstado As Integer)
        Try
            taEncargado.sp_tc087_update(idEncargado, nombreEncargado, idProveedor, telefono, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of encargado)
        Try
            TraerTodos = New List(Of encargado)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc087_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc087_selectAllDataTable = taAll.GetData()
            For Each enc As dsAlcoComercial2.sp_tc087_selectAllRow In txAll
                TraerTodos.Add(New encargado(enc.id, enc.fechaCreacion, enc.usuarioCreacion, enc.nombreEncargado, enc.idProveedor,
                                             enc.proveedor, enc.telefono, enc.usuarioModi, enc.fechaModi, enc.idEstado, enc.estado))
            Next
            If txAll.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteEncargado(nombreEncargado As String, nombreProveedor As String) As Boolean
        Try
            Dim lista As List(Of encargado) = TraerTodos().Where(Function(a) a.NombreEncargado = nombreEncargado And
                                                                     a.Proveedor = nombreProveedor).ToList
            If lista.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdProveedor(idProveedor As Integer) As List(Of encargado)
        Try
            Dim list As List(Of encargado) = TraerTodos().Where(Function(a) a.IdProveedor = idProveedor And
                                                                    a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
            TraerxIdProveedor = list
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class encargado
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombreEncargado As String
    Private _idProveedor As Integer
    Private _proveedor As String
    Private _telefono As String
#End Region
#Region "Propiedades"
    Public Property NombreEncargado() As String
        Get
            Return _nombreEncargado
        End Get
        Set(ByVal value As String)
            _nombreEncargado = value
        End Set
    End Property
    Public Property IdProveedor() As Integer
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Integer)
            _idProveedor = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, nombreEncargado As String,
                   idProveedor As Integer, proveedor As String, telefono As String, usuarioModi As String,
                   fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _nombreEncargado = nombreEncargado
            _idProveedor = idProveedor
            _proveedor = proveedor
            _telefono = telefono
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
