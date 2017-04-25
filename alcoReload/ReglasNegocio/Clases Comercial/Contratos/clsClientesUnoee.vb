Imports Datos
Public Class clsClientesUnoee
#Region "Propiedades"

#End Region
#Region "Variables"
    Private dsUnoee As dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosTableAdapter
    Private dsUnoeeCliente As dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosByClienteTableAdapter
    Private dsUnoeeNIt As dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosByNitTableAdapter
#End Region
#Region "Procedimientos"
    Public Function t200_selectAllClientesUnoee(Optional ByRef tb As DataTable = Nothing) As List(Of clienteUnoee)
        t200_selectAllClientesUnoee = New List(Of clienteUnoee)
        dsUnoee = New dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosTableAdapter
        Try
            For Each cliente As dsBUnoee.sp_t200_UnoeeTercerosRow In dsUnoee.GetData.Rows
                t200_selectAllClientesUnoee.Add(New clienteUnoee(cliente.idCliente, cliente.tipoDocumento, cliente.nit,
                                                                 cliente.digitoVerificacion, cliente.nombreCliente, cliente.telefono, cliente.direccion,
                                                                 cliente.correo, cliente.nombreContacto, cliente.tipoTercero, cliente.nombreEstablecimiento))
            Next
            tb = dsUnoee.GetData().CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Devuelve una lista de clientes con el nombre indicado
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    Public Function t200_ClientesUnoeeByCliente(nombre As String) As List(Of clienteUnoee)
        t200_ClientesUnoeeByCliente = New List(Of clienteUnoee)
        dsUnoeeCliente = New dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosByClienteTableAdapter
        Try
            For Each cliente As dsBUnoee.sp_t200_UnoeeTercerosByClienteRow In dsUnoeeCliente.GetData(nombre).Rows
                t200_ClientesUnoeeByCliente.Add(New clienteUnoee(cliente.idCliente, cliente.tipoDocumento, cliente.nit,
                                                                 cliente.digitoVerificacion, cliente.nombreCliente, cliente.telefono, cliente.direccion,
                                                                 cliente.correo, cliente.nombreContacto, cliente.tipoTercero, cliente.nombreEstablecimiento))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Devuelve una lista de clientes asociados al nit indicado
    ''' </summary>
    ''' <param name="nit"></param>
    ''' <returns></returns>
    Public Function t200_ClientesUnoeeByNit(nit As String) As List(Of clienteUnoee)
        t200_ClientesUnoeeByNit = New List(Of clienteUnoee)
        dsUnoeeNIt = New dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosByNitTableAdapter
        Try
            For Each cliente As dsBUnoee.sp_t200_UnoeeTercerosByNitRow In dsUnoeeNIt.GetData(nit).Rows
                t200_ClientesUnoeeByNit.Add(New clienteUnoee(cliente.idCliente, cliente.tipoDocumento, cliente.nit,
                                                                 cliente.digitoVerificacion, cliente.nombreCliente, cliente.telefono, cliente.direccion,
                                                                 cliente.correo, cliente.nombreContacto, cliente.tipoTercero, cliente.nombreEstablecimiento))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Decvuelve la información del cliente con el nombre indicado
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    Public Function ClienteUnoeeByCliente(nombre As String) As clienteUnoee
        ClienteUnoeeByCliente = New clienteUnoee
        dsUnoeeCliente = New dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosByClienteTableAdapter
        Try
            For Each cliente As dsBUnoee.sp_t200_UnoeeTercerosByClienteRow In dsUnoeeCliente.GetData(nombre).Rows
                ClienteUnoeeByCliente = (New clienteUnoee(cliente.idCliente, cliente.tipoDocumento, cliente.nit,
                                                                 cliente.digitoVerificacion, cliente.nombreCliente, cliente.telefono, cliente.direccion,
                                                                 cliente.correo, cliente.nombreContacto, cliente.tipoTercero, cliente.nombreEstablecimiento))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Devuelve la información del cliene con el nit indicado
    ''' </summary>
    ''' <param name="nit"></param>
    ''' <returns></returns>
    Public Function ClienteUnoeeByNit(nit As String) As clienteUnoee
        ClienteUnoeeByNit = New clienteUnoee
        dsUnoeeNIt = New dsBUnoeeTableAdapters.sp_t200_UnoeeTercerosByNitTableAdapter
        Try
            For Each cliente As dsBUnoee.sp_t200_UnoeeTercerosByNitRow In dsUnoeeNIt.GetData(nit).Rows
                ClienteUnoeeByNit = (New clienteUnoee(cliente.idCliente, cliente.tipoDocumento, cliente.nit,
                                                                 cliente.digitoVerificacion, cliente.nombreCliente, cliente.telefono, cliente.direccion,
                                                                 cliente.correo, cliente.nombreContacto, cliente.tipoTercero, cliente.nombreEstablecimiento))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class clienteUnoee
#Region "Propiedades"
    Private _idCliente As Integer
    Public Property idCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
    Private _tipoDocumento As String
    Public Property tipoDocumento() As String
        Get
            Return _tipoDocumento
        End Get
        Set(ByVal value As String)
            _tipoDocumento = value
        End Set
    End Property
    Private _nit As String
    Public Property nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Private _digitoVerificacion As String
    Public Property digitoVerificacion() As String
        Get
            Return _digitoVerificacion
        End Get
        Set(ByVal value As String)
            _digitoVerificacion = value
        End Set
    End Property
    Private _nombreCliente As String
    Public Property nombreCliente() As String
        Get
            Return _nombreCliente
        End Get
        Set(ByVal value As String)
            _nombreCliente = value
        End Set
    End Property
    Private _telefono As String
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Private _direccion As String
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Private _Correo As String
    Public Property Correo() As String
        Get
            Return _Correo
        End Get
        Set(ByVal value As String)
            _Correo = value
        End Set
    End Property
    Private _nombreContacto As String
    Public Property nombreContacto() As String
        Get
            Return _nombreContacto
        End Get
        Set(ByVal value As String)
            _nombreContacto = value
        End Set
    End Property
    Private _tipoTercero As Integer
    Public Property tipoTercero() As Integer
        Get
            Return _tipoTercero
        End Get
        Set(ByVal value As Integer)
            _tipoTercero = value
        End Set
    End Property
    Private _nombreEstablecimiento As String
    Public Property nombreEstablecimiento() As String
        Get
            Return _nombreEstablecimiento
        End Get
        Set(ByVal value As String)
            _nombreEstablecimiento = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, tipoDocumento As String, nit As String, digitoV As String, nomCliente As String, telefono As String,
                   direccion As String, correo As String, nombreContacto As String, tipoCliente As Integer, nombreEstablecimiento As String)
        Try
            _idCliente = id
            _tipoDocumento = RTrim(tipoDocumento)
            _nit = RTrim(nit)
            _digitoVerificacion = RTrim(digitoV)
            _nombreCliente = RTrim(nomCliente)
            _telefono = RTrim(telefono)
            _direccion = RTrim(direccion)
            _Correo = RTrim(correo)
            _nombreContacto = RTrim(_nombreContacto)
            _tipoTercero = tipoCliente
            _nombreEstablecimiento = _nombreEstablecimiento
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class

