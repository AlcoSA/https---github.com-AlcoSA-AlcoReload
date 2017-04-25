Imports Datos

Public Class ClsProveedores
#Region "Variables"
    Private taProveedor As New dsAlcoComercial2TableAdapters.tc086_ProveedoresTableAdapter
#End Region
#Region "Procedimientos"
    Public Function TraerTodosUnoee(Optional ByRef dt As DataTable = Nothing) As List(Of proveedores)
        Try
            TraerTodosUnoee = New List(Of proveedores)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t200_UnoeeProveedoresTableAdapter
            Dim txAll As dsBUnoee.sp_t200_UnoeeProveedoresDataTable = taAll.GetData()
            For Each prov As dsBUnoee.sp_t200_UnoeeProveedoresRow In txAll
                TraerTodosUnoee.Add(New proveedores(prov.idProveedor, prov.nit, prov.digitoVerificacion, prov.nombreProveedor,
                                              prov.telefono, prov.direccion, prov.correo, prov.nombreContacto,
                                              prov.nombreEstablecimiento, prov.regionUnoee))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerProveedorUnoeexNit(nit As String) As proveedores
        Try
            TraerProveedorUnoeexNit = New proveedores
            Dim lista As List(Of proveedores) = TraerTodosUnoee()
            TraerProveedorUnoeexNit = lista.FirstOrDefault(Function(a) a.Nit = nit)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerProveedorUnoeexNombre(nombreProveedor As String) As proveedores
        Try
            TraerProveedorUnoeexNombre = New proveedores
            Dim lista As List(Of proveedores) = TraerTodosUnoee()
            TraerProveedorUnoeexNombre = lista.FirstOrDefault(Function(a) a.NombreProveedor = nombreProveedor)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Insert(usuario As String, idSiesa As Integer, nit As String, descripcion As String,
                           representante As String, direccion As String, telefono As String, idRegion As String, idEstado As Integer)
        Try
            taProveedor.Insert(DateTime.Now, usuario, idSiesa, nit, descripcion, representante, direccion,
                               telefono, idRegion, usuario, DateTime.Now, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(idProveedor As Integer, idSiesa As Integer, nit As String, nombreProveedor As String,
                         nombreRepresentante As String, direccion As String, telefono As String, idRegion As String,
                         Usuario As String, idEstado As Integer)
        Try
            taProveedor.sp_tc086_update(idProveedor, idSiesa, nit, nombreProveedor, nombreRepresentante, direccion,
                                        telefono, idRegion, Usuario, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of proveedores)
        Try
            TraerTodos = New List(Of proveedores)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc086_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc086_selectAllDataTable = taAll.GetData()
            For Each prov As dsAlcoComercial2.sp_tc086_selectAllRow In txAll
                TraerTodos.Add(New proveedores(prov.id, prov.fechaCreacion, prov.usuarioCreacion, prov.idSiesa, prov.nit,
                                               prov.nombreProveedor, prov.nombreEstablecimiento, prov.nombreContacto,
                                               prov.direccion, prov.telefono, prov.idRegionUnoee, prov.regionUnoee,
                                               prov.usuarioModi, prov.fechaModi, prov.idEstado, prov.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteProveedor(idSiesa As Integer) As Boolean
        Try
            Dim lista As List(Of proveedores) = TraerTodos().Where(Function(a) a.IdSiesa = idSiesa).ToList
            If lista.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class proveedores
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idSiesa As Integer
    Private _nit As String
    Private _digitoVerificacion As String
    Private _nombreProveedor As String
    Private _telefono As String
    Private _direccion As String
    Private _correo As String
    Private _nombreContacto As String
    Private _nombreEstablecimiento As String
    Private _idRegionUnoee As String
    Private _region As String
#End Region
#Region "Propiedades"
    Public Property IdSiesa() As Integer
        Get
            Return _idSiesa
        End Get
        Set(ByVal value As Integer)
            _idSiesa = value
        End Set
    End Property
    Public Property Nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Public Property DigitoVerificacion() As String
        Get
            Return _digitoVerificacion
        End Get
        Set(ByVal value As String)
            _digitoVerificacion = value
        End Set
    End Property
    Public Property NombreProveedor() As String
        Get
            Return _nombreProveedor
        End Get
        Set(ByVal value As String)
            _nombreProveedor = value
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
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Public Property Correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
        End Set
    End Property
    Public Property NombreContacto() As String
        Get
            Return _nombreContacto
        End Get
        Set(ByVal value As String)
            _nombreContacto = value
        End Set
    End Property
    Public Property NombreEstablecimiento() As String
        Get
            Return _nombreEstablecimiento
        End Get
        Set(ByVal value As String)
            _nombreEstablecimiento = value
        End Set
    End Property
    Public Property IdRegionUnoee() As String
        Get
            Return _idRegionUnoee
        End Get
        Set(ByVal value As String)
            _idRegionUnoee = value
        End Set
    End Property
    Public Property Region() As String
        Get
            Return _region
        End Get
        Set(ByVal value As String)
            _region = value
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
    Public Sub New(idProveedor As Integer, nit As String, Dv As String, nombreProveedor As String,
                   telefono As String, direccion As String, correo As String, nombreContacto As String,
                   nombreEstablecimiento As String, region As String)
        Try
            _idSiesa = idProveedor
            _nit = nit
            _digitoVerificacion = Dv
            _nombreProveedor = nombreProveedor
            _telefono = telefono
            _direccion = direccion
            _correo = correo
            _nombreContacto = nombreContacto
            _nombreEstablecimiento = nombreEstablecimiento
            _region = region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idSiesa As Integer,
                   nit As String, nombreProveedor As String, nombreEstablecimiento As String, nombreContacto As String,
                   direccion As String, telefono As String, idRegion As String, region As String, usuarioModi As String,
                   fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idSiesa = idSiesa
            _nit = nit
            _nombreProveedor = nombreProveedor
            _nombreEstablecimiento = nombreEstablecimiento
            _nombreContacto = nombreContacto
            _direccion = direccion
            _telefono = telefono
            _idRegionUnoee = idRegion
            _region = region
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
