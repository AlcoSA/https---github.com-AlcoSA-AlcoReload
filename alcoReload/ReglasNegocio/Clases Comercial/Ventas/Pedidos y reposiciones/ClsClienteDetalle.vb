Imports Datos

Public Class ClsClienteDetalle
    ''' <summary>
    ''' Obtiene la información detallada de los clientes según su Id y el Id de la sucursal
    ''' </summary>
    ''' <param name="idCliente"></param>
    ''' <param name="idObra"></param>
    ''' <returns></returns>
    Public Function TraerDetalleCliente(idCliente As Integer, idObra As String) As clienteDetalleUnoee
        Try
            TraerDetalleCliente = New clienteDetalleUnoee
            Dim taAll As New dsBUnoeeTableAdapters.sp_t201_UnoeeClientesTableAdapter
            Dim txAll As dsBUnoee.sp_t201_UnoeeClientesDataTable = taAll.GetData(idCliente, idObra)
            If txAll.Rows.Count > 0 Then
                Dim cli As dsBUnoee.sp_t201_UnoeeClientesRow = DirectCast(txAll.Rows(0), dsBUnoee.sp_t201_UnoeeClientesRow)
                TraerDetalleCliente = New clienteDetalleUnoee(cli.idCliente, cli.Cliente, cli.idObra, cli.Obra, cli.idMoneda, cli.idListaPrecio,
                                                              cli.idCondicionPago, cli.idBackorder, cli.idTipoCliente, cli.tipoCliente, cli.idVendedorSiesa,
                                                              cli.Vendedor, cli.idContacto, cli.nombreContacto, cli.direccion1, If(IsDBNull(cli.direccion2), String.Empty, cli.direccion2),
                                                              If(IsDBNull(cli.direccion3), String.Empty, cli.direccion3), cli.telefono, If(IsDBNull(cli.fax), String.Empty, cli.fax),
                                                              If(IsDBNull(cli.correo), String.Empty, cli.correo), cli.idPais, cli.pais, cli.idDepartamento, cli.departamento, cli.idCiudad,
                                                              cli.ciudad, If(cli.IsidBarrioNull(), String.Empty, cli.idBarrio), If(IsDBNull(cli.codigoPostal), String.Empty, cli.codigoPostal))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class clienteDetalleUnoee
#Region "Variables"
    Private _idCliente As Integer
    Private _cliente As String
    Private _idObra As String
    Private _obra As String
    Private _idMoneda As String
    Private _idListaPrecio As String
    Private _idCondPago As String
    Private _idBackorder As Integer
    Private _idTipoCliente As String
    Private _tipoCliente As String
    Private _idVendedorSiesa As String
    Private _vendedorSiesa As String
    Private _idContacto As Integer
    Private _nombreContacto As String
    Private _direccion1 As String
    Private _direccion2 As String
    Private _direccion3 As String
    Private _telefono As String
    Private _fax As String
    Private _correo As String
    Private _idPais As String
    Private _pais As String
    Private _idDepto As String
    Private _departamento As String
    Private _idCiudad As String
    Private _ciudad As String
    Private _idBarrio As String
    Private _codPostal As String
#End Region
#Region "Propiedades"
    Public Property IdCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property IdObra() As String
        Get
            Return _idObra
        End Get
        Set(ByVal value As String)
            _idObra = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property IdMoneda() As String
        Get
            Return _idMoneda
        End Get
        Set(ByVal value As String)
            _idMoneda = value
        End Set
    End Property
    Public Property IdListaPrecio() As String
        Get
            Return _idListaPrecio
        End Get
        Set(ByVal value As String)
            _idListaPrecio = value
        End Set
    End Property
    Public Property IdCondicionPago() As String
        Get
            Return _idCondPago
        End Get
        Set(ByVal value As String)
            _idCondPago = value
        End Set
    End Property
    Public Property IdBackorder() As Integer
        Get
            Return _idBackorder
        End Get
        Set(ByVal value As Integer)
            _idBackorder = value
        End Set
    End Property
    Public Property IdTipoCliente() As String
        Get
            Return _idTipoCliente
        End Get
        Set(ByVal value As String)
            _idTipoCliente = value
        End Set
    End Property
    Public Property TipoCliente() As String
        Get
            Return _tipoCliente
        End Get
        Set(ByVal value As String)
            _tipoCliente = value
        End Set
    End Property
    Public Property IdVendedorSiesa() As String
        Get
            Return _idVendedorSiesa
        End Get
        Set(ByVal value As String)
            _idVendedorSiesa = value
        End Set
    End Property
    Public Property VendedorSiesa() As String
        Get
            Return _vendedorSiesa
        End Get
        Set(ByVal value As String)
            _vendedorSiesa = value
        End Set
    End Property
    Public Property IdContacto() As Integer
        Get
            Return _idContacto
        End Get
        Set(ByVal value As Integer)
            _idContacto = value
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
    Public Property Direccion1() As String
        Get
            Return _direccion1
        End Get
        Set(ByVal value As String)
            _direccion1 = value
        End Set
    End Property
    Public Property Direccion2() As String
        Get
            Return _direccion2
        End Get
        Set(ByVal value As String)
            _direccion2 = value
        End Set
    End Property
    Public Property Direccion3() As String
        Get
            Return _direccion3
        End Get
        Set(ByVal value As String)
            _direccion3 = value
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
    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)
            _fax = value
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
    Public Property IdPais() As String
        Get
            Return _idPais
        End Get
        Set(ByVal value As String)
            _idPais = value
        End Set
    End Property
    Public Property Pais() As String
        Get
            Return _pais
        End Get
        Set(ByVal value As String)
            _pais = value
        End Set
    End Property
    Public Property IdDepartamento() As String
        Get
            Return _idDepto
        End Get
        Set(ByVal value As String)
            _idDepto = value
        End Set
    End Property
    Public Property Departamento() As String
        Get
            Return _departamento
        End Get
        Set(ByVal value As String)
            _departamento = value
        End Set
    End Property
    Public Property IdCiudad() As String
        Get
            Return _idCiudad
        End Get
        Set(ByVal value As String)
            _idCiudad = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Public Property IdBarrio() As String
        Get
            Return _idBarrio
        End Get
        Set(ByVal value As String)
            _idBarrio = value
        End Set
    End Property
    Public Property CodigoPostal() As String
        Get
            Return _codPostal
        End Get
        Set(ByVal value As String)
            _codPostal = value
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
    Public Sub New(idCliente As Integer, cliente As String, idObra As String, obra As String, idMoneda As String,
                   idListaPrecios As String, idCondPago As String, idBackorder As Integer, idTipoCliente As String,
                   tipoCliente As String, idVendedorSiesa As String, vendedorSiesa As String, idContacto As Integer,
                   nombreContacto As String, direccion1 As String, direccion2 As String, direccion3 As String,
                   telefono As String, fax As String, correo As String, idPais As String, pais As String, idDepto As String,
                   depto As String, IdCiudad As String, ciudad As String, idBarrio As String, codPostal As String)
        Try
            _idCliente = idCliente
            _cliente = cliente
            _idObra = idObra
            _obra = obra
            _idMoneda = idMoneda
            _idListaPrecio = idListaPrecios
            _idCondPago = idCondPago
            _idBackorder = idBackorder
            _idTipoCliente = idTipoCliente
            _tipoCliente = tipoCliente
            _idVendedorSiesa = idVendedorSiesa
            _vendedorSiesa = vendedorSiesa
            _idContacto = idContacto
            _nombreContacto = nombreContacto
            _direccion1 = direccion1
            _direccion2 = direccion2
            _direccion3 = direccion3
            _telefono = telefono
            _fax = fax
            _correo = correo
            _idPais = idPais
            _pais = pais
            _idDepto = idDepto
            _departamento = depto
            _idCiudad = IdCiudad
            _ciudad = ciudad
            _idBarrio = idBarrio
            _codPostal = codPostal
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class

