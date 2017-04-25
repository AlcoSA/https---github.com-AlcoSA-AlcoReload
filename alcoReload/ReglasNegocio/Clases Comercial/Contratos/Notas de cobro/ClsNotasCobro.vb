Imports Datos

Public Class ClsNotasCobro
#Region "Variables"
    Private taNotasCobro As New dsAlcoContratosTableAdapters.tc053_notasCobroObrasTableAdapter
    Private tfunction As New dsAlcoContratosTableAdapters.fnc_traerYo
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuarioCreacion As String, idOrigen As Integer, fecha As DateTime, nit As String, cliente As String,
                             codObra As String, obra As String, idTipoNota As Integer, nContrato As String, valorNota As Decimal,
                             valorContrato As Decimal, idVendedoresSiesa As String, porcentajeAnticipo As Decimal, numeroCuota As String,
                             totalCuotas As String, calculaIvaSobreUtilidad As Boolean, observaciones As String, idEstadoImpresion As Integer,
                             numeroImpresiones As Integer, usuarioModi As String, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taNotasCobro.sp_tc053_insert(usuarioCreacion, idOrigen, fecha, nit, cliente, codObra, obra, idTipoNota, nContrato,
                                                                valorNota, valorContrato, idVendedoresSiesa, porcentajeAnticipo, numeroCuota, totalCuotas,
                                                                calculaIvaSobreUtilidad, observaciones, idEstadoImpresion, numeroImpresiones, usuarioModi, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstado(idNotaCobro As Integer, idEstado As Integer)
        Try
            taNotasCobro.sp_tc053_updateEstado(idNotaCobro, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarNumImpresiones(idNota As Integer, numImpresiones As Integer)
        Try
            taNotasCobro.sp_tc053_updateImpresion(idNota, numImpresiones)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of notaCobro)
        Try
            TraerTodos = New List(Of notaCobro)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc053_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc053_selectAllDataTable = taAll.GetData()
            For Each nt As dsAlcoContratos.sp_tc053_selectAllRow In txAll
                TraerTodos.Add(New notaCobro(nt.id, nt.usuarioCreacion, nt.fechaCreacion, nt.idOrigen, nt.origen, nt.fechaNota,
                                             nt.nit, nt.cliente, nt.codigoObra, nt.obra, nt.idTipoNota, nt.tipoNota, nt.numeroContrato,
                                             nt.valorNota, nt.valorContrato, nt.idVendedor, nt.porcentAnticipo, nt.numeroCuota,
                                             nt.totalCuotas, nt.ivaSobreUtilidad, nt.observaciones, nt.idEstadoImpresion, nt.estadoImpresion,
                                             nt.numeroImpresiones, nt.regionUnoee, nt.fechaModi, nt.usuarioModi, nt.idEstado, nt.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerMaxId() As Integer
        Try
            Return Convert.ToInt32(taNotasCobro.sp_tc053_selectMaxId())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerNumeroImpresiones(idNota As Integer) As Integer
        Try
            Dim listNota As List(Of notaCobro) = TraerTodos()
            Dim nota As notaCobro = listNota.FirstOrDefault(Function(a) a.Id = idNota)
            Return nota.NumeroImpresiones
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerYoByNitCodObra(nit As String, codObra As String, datoBusqueda As String) As String
        Try
            traerYoByNitCodObra = String.Empty
            traerYoByNitCodObra = tfunction.fnc_traerYO(nit, codObra, datoBusqueda)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class notaCobro
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idOrigen As Integer
    Private _origen As String
    Private _fechaNota As DateTime
    Private _nit As String
    Private _cliente As String
    Private _codigoSucursal As String
    Private _obra As String
    Private _idTipoNota As Integer
    Private _tipoNota As String
    Private _numeroContrato As String
    Private _valorNota As Decimal
    Private _valorContrato As Decimal
    Private _idVendedor As String
    Private _porcentajeAnticipo As Decimal
    Private _numeroCuota As String
    Private _totalCuotas As String
    Private _ivaSobreUtilidad As Boolean
    Private _observaciones As String
    Private _numeroImpresiones As Integer
    Private _idEstadoImpresion As Integer
    Private _estadoImpresion As String
    Private _region As String
#End Region
#Region "Propiedades"
    Public Property IdOrigen() As Integer
        Get
            Return _idOrigen
        End Get
        Set(ByVal value As Integer)
            _idOrigen = value
        End Set
    End Property
    Public Property Origen() As String
        Get
            Return _origen
        End Get
        Set(ByVal value As String)
            _origen = value
        End Set
    End Property
    Public Property FechaNota() As DateTime
        Get
            Return _fechaNota
        End Get
        Set(ByVal value As DateTime)
            _fechaNota = value
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
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodigoSucursal() As String
        Get
            Return _codigoSucursal
        End Get
        Set(ByVal value As String)
            _codigoSucursal = value
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
    Public Property IdTipoNota() As Integer
        Get
            Return _idTipoNota
        End Get
        Set(ByVal value As Integer)
            _idTipoNota = value
        End Set
    End Property
    Public Property TipoNota() As String
        Get
            Return _tipoNota
        End Get
        Set(ByVal value As String)
            _tipoNota = value
        End Set
    End Property
    Public Property NumeroContrato() As String
        Get
            Return _numeroContrato
        End Get
        Set(ByVal value As String)
            _numeroContrato = value
        End Set
    End Property
    Public Property ValorNota() As Decimal
        Get
            Return _valorNota
        End Get
        Set(ByVal value As Decimal)
            _valorNota = value
        End Set
    End Property
    Public Property ValorContrato() As Decimal
        Get
            Return _valorContrato
        End Get
        Set(ByVal value As Decimal)
            _valorContrato = value
        End Set
    End Property
    Public Property IdVendedor() As String
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As String)
            _idVendedor = value
        End Set
    End Property
    Public Property PorcentajeAnticipo() As Decimal
        Get
            Return _porcentajeAnticipo
        End Get
        Set(ByVal value As Decimal)
            _porcentajeAnticipo = value
        End Set
    End Property
    Public Property NumeroCuota() As String
        Get
            Return _numeroCuota
        End Get
        Set(ByVal value As String)
            _numeroCuota = value
        End Set
    End Property
    Public Property TotalCuotas() As String
        Get
            Return _totalCuotas
        End Get
        Set(ByVal value As String)
            _totalCuotas = value
        End Set
    End Property
    Public Property IvaSobreUtilidad() As Boolean
        Get
            Return _ivaSobreUtilidad
        End Get
        Set(ByVal value As Boolean)
            _ivaSobreUtilidad = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property
    Public Property NumeroImpresiones() As Integer
        Get
            Return _numeroImpresiones
        End Get
        Set(ByVal value As Integer)
            _numeroImpresiones = value
        End Set
    End Property
    Public Property IdEstadoImpresion() As Integer
        Get
            Return _idEstadoImpresion
        End Get
        Set(ByVal value As Integer)
            _idEstadoImpresion = value
        End Set
    End Property
    Public Property EstadoImpresion() As String
        Get
            Return _estadoImpresion
        End Get
        Set(ByVal value As String)
            _estadoImpresion = value
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
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, idOrigen As Integer, origen As String,
                   fechaNota As DateTime, nit As String, cliente As String, codigoSucursal As String, obra As String, idTipoNota As Integer,
                   tipoNota As String, numeroContrato As String, valorNota As Decimal, valorContrato As Decimal, idVendedor As String,
                   porcentAnticipo As Decimal, numeroCuota As String, totalCuotas As String, ivaSobreUtilidad As Boolean, observaciones As String,
                   idEstadoImpresion As Integer, estadoImpresion As String, numeroImpresiones As Integer, region As String, fechaModi As DateTime,
                   usuarioModi As String, idEstado As Integer, estado As String)
        Me.Id = id
        Me.UsuarioCreacion = Trim(usuarioCreacion)
        Me.FechaCreacion = fechaCreacion
        _idOrigen = idOrigen
        _origen = Trim(origen)
        _fechaNota = fechaNota
        _nit = Trim(nit)
        _cliente = Trim(cliente)
        _codigoSucursal = Trim(codigoSucursal)
        _obra = Trim(obra)
        _idTipoNota = idTipoNota
        _tipoNota = Trim(tipoNota)
        _numeroContrato = Trim(numeroContrato)
        _valorNota = valorNota
        _valorContrato = valorContrato
        _idVendedor = Trim(idVendedor)
        _porcentajeAnticipo = porcentAnticipo
        _numeroCuota = Trim(numeroCuota)
        _totalCuotas = Trim(totalCuotas)
        _ivaSobreUtilidad = ivaSobreUtilidad
        _observaciones = Trim(observaciones)
        _idEstadoImpresion = idEstadoImpresion
        _estadoImpresion = Trim(estadoImpresion)
        _numeroImpresiones = numeroImpresiones
        _region = Trim(region)
        Me.FechaModificacion = fechaModi
        Me.UsuarioModificacion = Trim(usuarioModi)
        Me.IdEstado = idEstado
        Me.Estado = Trim(estado)
    End Sub
#End Region
End Class