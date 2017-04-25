Imports Datos

Public Class ClsPlanAnticipos
#Region "Variables"
    Private taPlanesAnticipos As New dsAlcoContratosTableAdapters.tc057_planesAnticipoContratosTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuarioCreacion As String, idContrato As Integer, idTipoAnticipo As Integer,
                        numeroCuotas As Integer, porcAnticipo As Decimal, diasEntreCuotas As Integer, fechaPrimeraCuota As DateTime) As Integer
        Try
            Return Convert.ToInt32(taPlanesAnticipos.sp_tc057_insert(usuarioCreacion, idContrato, idTipoAnticipo, numeroCuotas, porcAnticipo,
                                                                     diasEntreCuotas, fechaPrimeraCuota))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(Id As Integer, idContrato As Integer, idTipoAnticipo As Integer, numeroCuotas As Integer,
                         porcAnticipo As Decimal, diasEntreCuotas As Integer, idEstado As Integer, fechaPrimeraCuota As DateTime)
        Try
            taPlanesAnticipos.sp_tc057_update(Id, idContrato, idTipoAnticipo, numeroCuotas, porcAnticipo,
                                              diasEntreCuotas, idEstado, fechaPrimeraCuota)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(idPlanAnticipo As Integer, idEstado As Integer)
        Try
            taPlanesAnticipos.sp_tc057_updateEstado(idPlanAnticipo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdContrato(idContrato As Integer) As anticipoNotaCobro
        Try
            TraerxIdContrato = Nothing
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc057_selectByIdContratoTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc057_selectByIdContratoDataTable = taAll.GetData(idContrato)
            If txAll.Rows.Count > 0 Then
                Dim pac As dsAlcoContratos.sp_tc057_selectByIdContratoRow = DirectCast(txAll.Rows(0), dsAlcoContratos.sp_tc057_selectByIdContratoRow)
                TraerxIdContrato = New anticipoNotaCobro(pac.id, pac.fechaCreacion, pac.usuarioCreacion, pac.idContrato, pac.idTipoAnticipo,
                                                    pac.tipoAnticipo, pac.numCuotas, pac.porcAnticipo, pac.diasEntreCuotas, pac.fechaModi,
                                                    pac.idEstado, pac.estado, pac.FechaPrimeraCuota)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerPlanesAnticipo() As List(Of anticipoNotaCobro)
        Try
            TraerPlanesAnticipo = New List(Of anticipoNotaCobro)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc057_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc057_selectAllDataTable = taAll.GetData()
            For Each ant As dsAlcoContratos.sp_tc057_selectAllRow In txAll
                TraerPlanesAnticipo.Add(New anticipoNotaCobro(ant.idPlanAnticipo, ant.fechaCreacion, ant.usuarioCreacion, ant.idContrato,
                                                              ant.nit, ant.cliente, ant.codigoSucursal, ant.obra, ant.numeroContrato,
                                                              ant.idTipoAnticipo, ant.tipoAnticipo, ant.porcentajeAnticipo,
                                                              ant.numeroCuotas, ant.rangoDias, ant.valorContratado, ant.idEstado, ant.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerPendientesxPagar(idPlanAnticipo As Integer) As Integer
        Try
            Return Convert.ToInt32(taPlanesAnticipos.sp_tc057_selectPendientesPorPagar(idPlanAnticipo))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class anticipoNotaCobro
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idPlanAnticipo As Integer
    Private _idContrato As Integer
    Private _nit As String
    Private _constructora As String
    Private _codigoSucursal As String
    Private _obra As String
    Private _numeroContrato As String
    Private _idTipoAnticipo As Integer
    Private _tipoAnticipo As String
    Private _porcentajeAnticipo As Decimal
    Private _numeroCuota As Integer
    Private _rangoDias As Integer
    Private _valorContratado As Decimal
    Private _fechaPrimeraCuota As DateTime
#End Region
#Region "Propiedades"
    Public Property IdPlanAnticipo() As Integer
        Get
            Return _idPlanAnticipo
        End Get
        Set(ByVal value As Integer)
            _idPlanAnticipo = value
        End Set
    End Property
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
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
    Public Property CodigoSucursal() As String
        Get
            Return _codigoSucursal
        End Get
        Set(ByVal value As String)
            _codigoSucursal = value
        End Set
    End Property
    Public Property Constructora() As String
        Get
            Return _constructora
        End Get
        Set(ByVal value As String)
            _constructora = value
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
    Public Property NumeroContrato() As String
        Get
            Return _numeroContrato
        End Get
        Set(ByVal value As String)
            _numeroContrato = value
        End Set
    End Property
    Public Property IdtipoAnticipo() As Integer
        Get
            Return _idTipoAnticipo
        End Get
        Set(ByVal value As Integer)
            _idTipoAnticipo = value
        End Set
    End Property
    Public Property TipoAnticipo() As String
        Get
            Return _tipoAnticipo
        End Get
        Set(ByVal value As String)
            _tipoAnticipo = value
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
    Public Property NumeroCuota() As Integer
        Get
            Return _numeroCuota
        End Get
        Set(ByVal value As Integer)
            _numeroCuota = value
        End Set
    End Property
    Public Property RangoDias() As Integer
        Get
            Return _rangoDias
        End Get
        Set(ByVal value As Integer)
            _rangoDias = value
        End Set
    End Property
    Public Property ValorContratado() As Decimal
        Get
            Return _valorContratado
        End Get
        Set(ByVal value As Decimal)
            _valorContratado = value
        End Set
    End Property
    Public Property FechaPrimeraCuota() As DateTime
        Get
            Return _fechaPrimeraCuota
        End Get
        Set(ByVal value As DateTime)
            _fechaPrimeraCuota = value
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
    Public Sub New(idPlanAnticipo As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idContrato As Integer,
                   nit As String, cliente As String, codigoSucursal As String, obra As String, numeroContrato As String,
                   idTipoAnticipo As Integer, tipoAnticipo As String, porcentajeAnticipo As Decimal, numeroCuota As Integer,
                   rangoDias As Integer, valorContratado As Decimal, idEstado As Integer, estado As String)
        Try
            _idPlanAnticipo = idPlanAnticipo
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _idContrato = idContrato
            _nit = Trim(nit)
            _constructora = Trim(cliente)
            _codigoSucursal = Trim(codigoSucursal)
            _obra = Trim(obra)
            _numeroContrato = Trim(numeroContrato)
            _idTipoAnticipo = idTipoAnticipo
            _tipoAnticipo = Trim(tipoAnticipo)
            _porcentajeAnticipo = porcentajeAnticipo
            _numeroCuota = numeroCuota
            _rangoDias = rangoDias
            _valorContratado = valorContratado
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idContrato As Integer,
                   idTipoAnticipo As Integer, tipoAnticipo As String, numCuotas As Integer, porcAnticipo As Decimal,
                   diasEntreCuotas As Integer, fechaModi As DateTime, idEstado As Integer, estado As String, fechaPrimeraCuota As DateTime)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idContrato = idContrato
            _idTipoAnticipo = idTipoAnticipo
            _tipoAnticipo = tipoAnticipo
            _numeroCuota = numCuotas
            _porcentajeAnticipo = porcAnticipo
            _rangoDias = diasEntreCuotas
            _fechaPrimeraCuota = fechaPrimeraCuota
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class