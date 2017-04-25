Imports Datos

Public Class clsContratosPlaneacion
#Region "Variables"
#End Region
#Region "Procedimientos"
    Public Function TraerContratos(idVendedor As String) As List(Of contratoPlaneacion)
        Try
            TraerContratos = New List(Of contratoPlaneacion)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc083_selectContratosTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc083_selectContratosDataTable = taAll.GetData(idVendedor)
            For Each cont As dsAlcoContratos.sp_tc083_selectContratosRow In txAll
                TraerContratos.Add(New contratoPlaneacion(Convert.ToInt32(cont.Item("idContrato")), Convert.ToInt32(cont.Item("idPendiente")),
                                                          Convert.ToString(cont.Item("cliente")), Convert.ToString(cont.Item("codSucursal")),
                                                          Convert.ToString(cont.Item("sucursal")), Convert.ToString(cont.Item("numContrato")),
                                                          Convert.ToDateTime(cont.Item("fechaInicial")),
                                                          If(IsDBNull(cont.Item("fechaFin")), Nothing, Convert.ToDateTime(cont.Item("fechaFin"))),
                                                          Convert.ToInt32(cont.Item("puntosTotales")), Convert.ToInt32(cont.Item("puntosProgramados")),
                                                          Convert.ToInt32(cont.Item("unidadesTotales")), Convert.ToInt32(cont.Item("idEstadoPlaneacion")),
                                                          Convert.ToString(cont.Item("region")), Convert.ToDecimal(cont.Item("valorContrato")),
                                                          Convert.ToDecimal(cont.Item("metros"))))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class contratoPlaneacion
#Region "Variables"
    Private _idContrato As Integer
    Private _idPendiente As Integer
    Private _cliente As String
    Private _codSucursal As String
    Private _sucursal As String
    Private _numContrato As String
    Private _fechaInicial As DateTime
    Private _fechaFin As DateTime
    Private _puntosTotales As Integer
    Private _puntosProgramados As Integer
    Private _unidadesTotales As Integer
    Private _idEstadoPlaneacion As Integer
    Private _region As String
    Private _valorContrato As Decimal
    Private _metros As Decimal
#End Region
#Region "Propiedades"
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property IdPendiente() As Integer
        Get
            Return _idPendiente
        End Get
        Set(ByVal value As Integer)
            _idPendiente = value
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
    Public Property CodSucursal() As String
        Get
            Return _codSucursal
        End Get
        Set(ByVal value As String)
            _codSucursal = value
        End Set
    End Property
    Public Property Sucursal() As String
        Get
            Return _sucursal
        End Get
        Set(ByVal value As String)
            _sucursal = value
        End Set
    End Property
    Public Property NumContrato() As String
        Get
            Return _numContrato
        End Get
        Set(ByVal value As String)
            _numContrato = value
        End Set
    End Property
    Public Property FechaInicial() As DateTime
        Get
            Return _fechaInicial
        End Get
        Set(ByVal value As DateTime)
            _fechaInicial = value
        End Set
    End Property
    Public Property FechaFin() As DateTime
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As DateTime)
            _fechaFin = value
        End Set
    End Property
    Public Property PuntosTotales() As Integer
        Get
            Return _puntosTotales
        End Get
        Set(ByVal value As Integer)
            _puntosTotales = value
        End Set
    End Property
    Public Property PuntosProgramados() As Integer
        Get
            Return _puntosProgramados
        End Get
        Set(ByVal value As Integer)
            _puntosProgramados = value
        End Set
    End Property
    Public Property UnidadesTotales() As Integer
        Get
            Return _unidadesTotales
        End Get
        Set(ByVal value As Integer)
            _unidadesTotales = value
        End Set
    End Property
    Public Property IdEstadoPlaneacion() As Integer
        Get
            Return _idEstadoPlaneacion
        End Get
        Set(ByVal value As Integer)
            _idEstadoPlaneacion = value
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
    Public Property ValorContrato() As Decimal
        Get
            Return _valorContrato
        End Get
        Set(ByVal value As Decimal)
            _valorContrato = value
        End Set
    End Property
    Public Property Metros() As Decimal
        Get
            Return _metros
        End Get
        Set(ByVal value As Decimal)
            _metros = value
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
    Public Sub New(idContrato As Integer, idPendiente As Integer, cliente As String, codSucursal As String,
                   sucursal As String, numContrato As String, fechaInicial As DateTime, fechaFin As DateTime,
                   puntosTotales As Integer, puntosProgramados As Integer, unidadesTotales As Integer,
                   idEstadoPlaneacion As Integer, region As String, valorContrato As Decimal, metros As Decimal)
        Try
            _idContrato = idContrato
            _idPendiente = idPendiente
            _cliente = cliente
            _codSucursal = codSucursal
            _sucursal = sucursal
            _numContrato = numContrato
            _fechaInicial = fechaInicial
            _fechaFin = fechaFin
            _puntosTotales = puntosTotales
            _puntosProgramados = puntosProgramados
            _unidadesTotales = unidadesTotales
            _idEstadoPlaneacion = idEstadoPlaneacion
            _region = region
            _valorContrato = valorContrato
            _metros = metros
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
