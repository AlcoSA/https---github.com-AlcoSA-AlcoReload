Imports Datos

Public Class ClsGeneralesReposicion
#Region "Variables"
    Private taGeneralReposicion As New dsAlcoComercial2TableAdapters.tc075_generales_reposicionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(idEncabezado As Integer, idCondicionPago As String, backorder As String, tipoCliente As String,
                        vendedor As String, notas As String, idPuntoEnvio As String, idContacto As Integer, direccion As String,
                        direccion2 As String, direccion3 As String, telefono As String, fax As String, correo As String,
                        idPais As String, idDepartamento As String, barrio As String, codigoPostal As String)
        Try
            taGeneralReposicion.sp_tc075_insert(idEncabezado, idCondicionPago, backorder, tipoCliente, vendedor, notas, idPuntoEnvio,
                                                idContacto, direccion, direccion2, direccion3, telefono, fax, correo, idPais,
                                                idDepartamento, barrio, codigoPostal)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(idReposicion As Integer) As List(Of generalReposicion)
        Try
            TraerTodos = New List(Of generalReposicion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc075_selectByIdReposicionTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc075_selectByIdReposicionDataTable = taAll.GetData(idReposicion)
            For Each grep As dsAlcoComercial2.sp_tc075_selectByIdReposicionRow In txAll.Rows
                TraerTodos.Add(New generalReposicion(grep.id, grep.idEncabezado, grep.idCondicionPago, grep.backorder, grep.tipoCliente,
                                                     grep.vendedor, grep.notas, grep.idPuntoEnvio, grep.idContacto, grep.direccion,
                                                     grep.direccion2, grep.direccion3, grep.telefono, grep.fax, grep.correo, grep.idPais,
                                                     grep.idDepartamento, grep.idCiudad, grep.barrio, grep.codigoPostal))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class generalReposicion
#Region "Variables"
    Private _id As Integer
    Private _idEncabezado As Integer
    Private _idCondicionPago As String
    Private _backorder As String
    Private _tipoCliente As String
    Private _notas As String
    Private _vendedor As String
    Private _idPuntoEnvio As String
    Private _idContacto As Integer
    Private _direccion As String
    Private _direccion2 As String
    Private _direccion3 As String
    Private _telefono As String
    Private _fax As String
    Private _correo As String
    Private _idPais As String
    Private _idDepartamento As String
    Private _idCiudad As String
    Private _barrio As String
    Private _codigoPostal As String
#End Region
#Region "Propiedades"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property IdEncabezado() As Integer
        Get
            Return _idEncabezado
        End Get
        Set(ByVal value As Integer)
            _idEncabezado = value
        End Set
    End Property
    Public Property IdCondicionPago() As String
        Get
            Return _idCondicionPago
        End Get
        Set(ByVal value As String)
            _idCondicionPago = value
        End Set
    End Property
    Public Property Backorder() As String
        Get
            Return _backorder
        End Get
        Set(ByVal value As String)
            _backorder = value
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
    Public Property Notas() As String
        Get
            Return _notas
        End Get
        Set(ByVal value As String)
            _notas = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property IdPuntoEnvio() As String
        Get
            Return _idPuntoEnvio
        End Get
        Set(ByVal value As String)
            _idPuntoEnvio = value
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
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
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
    Public Property IdDepartamento() As String
        Get
            Return _idDepartamento
        End Get
        Set(ByVal value As String)
            _idDepartamento = value
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
    Public Property Barrio() As String
        Get
            Return _barrio
        End Get
        Set(ByVal value As String)
            _barrio = value
        End Set
    End Property
    Public Property CodigoPostal() As String
        Get
            Return _codigoPostal
        End Get
        Set(ByVal value As String)
            _codigoPostal = value
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
    Public Sub New(id As Integer, idEncabezado As Integer, idCondicionPago As String, backorder As String, tipoCliente As String,
                   vendedor As String, notas As String, idPuntoEnvio As String, idContacto As Integer, direccion As String,
                   direccion2 As String, direccion3 As String, telefono As String, fax As String, correo As String, idPais As String,
                   idDepartamento As String, idCiudad As String, barrio As String, codigoPostal As String)
        Try
            _id = id
            _idEncabezado = idEncabezado
            _idCondicionPago = Trim(idCondicionPago)
            _backorder = Trim(backorder)
            _tipoCliente = Trim(tipoCliente)
            _vendedor = Trim(vendedor)
            _notas = Trim(notas)
            _idPuntoEnvio = Trim(idPuntoEnvio)
            _idContacto = idContacto
            _direccion = Trim(direccion)
            _direccion2 = Trim(direccion2)
            _direccion3 = Trim(direccion3)
            _telefono = Trim(telefono)
            _fax = Trim(fax)
            _correo = Trim(correo)
            _idPais = Trim(idPais)
            _idDepartamento = Trim(idDepartamento)
            _idCiudad = Trim(idCiudad)
            _barrio = Trim(barrio)
            _codigoPostal = Trim(codigoPostal)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
