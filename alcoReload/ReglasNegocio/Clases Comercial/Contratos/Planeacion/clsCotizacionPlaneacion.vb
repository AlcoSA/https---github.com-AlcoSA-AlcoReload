Imports Datos

Public Class clsCotizacionPlaneacion
#Region "Variables"
#End Region
#Region "Procedimientos"
    Public Function TraerItemsContratados(idContrato As Integer) As List(Of cotizaPlaneacion)
        Try
            TraerItemsContratados = New List(Of cotizaPlaneacion)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc083_selectItemsContratadosTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc083_selectItemsContratadosDataTable = taAll.GetData(idContrato)
            For Each cot As dsAlcoContratos.sp_tc083_selectItemsContratadosRow In txAll
                TraerItemsContratados.Add(New cotizaPlaneacion(cot.id, cot.ubicacion, cot.descripcion, cot.idCotiza, cot.cotiza,
                                                               cot.idVendedor, cot.vendedor, cot.idAcabado, cot.acabado, cot.metros,
                                                               Convert.ToInt32(cot.puntos), cot.puntosPlaneados, cot.unidades,
                                                               cot.precioInstalacion, cot.idEstado, cot.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerItemsPendientes(idPendiente As Integer) As List(Of cotizaPlaneacion)
        Try
            TraerItemsPendientes = New List(Of cotizaPlaneacion)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc083_selectItemsPendientesTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc083_selectItemsPendientesDataTable = taAll.GetData(idPendiente)
            For Each cot As dsAlcoContratos.sp_tc083_selectItemsPendientesRow In txAll
                TraerItemsPendientes.Add(New cotizaPlaneacion(cot.id, cot.ubicacion, cot.descripcion, cot.idCotiza, cot.cotiza,
                                                               cot.idVendedor, cot.vendedor, cot.idAcabado, cot.acabado, cot.metros,
                                                               Convert.ToInt32(cot.puntos), cot.puntosPlaneados, cot.unidades,
                                                              cot.precioInstalacion, cot.idEstado, cot.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class cotizaPlaneacion
#Region "Variables"
    Private _id As Integer
    Private _ubicacion As String
    Private _descripcion As String
    Private _idCotiza As Integer
    Private _cotiza As String
    Private _idVendedor As Integer
    Private _vendedor As String
    Private _idAcabado As Integer
    Private _acabado As String
    Private _metros As Decimal
    Private _puntos As Integer
    Private _puntosPlaneados As Integer
    Private _unidades As Integer
    Private _precioInstalacion As Decimal
    Private _idEstado As Integer
    Private _estado As String
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
    Public Property Ubicacion() As String
        Get
            Return _ubicacion
        End Get
        Set(ByVal value As String)
            _ubicacion = value
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
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property Cotiza() As String
        Get
            Return _cotiza
        End Get
        Set(ByVal value As String)
            _cotiza = value
        End Set
    End Property
    Public Property IdVendedor() As Integer
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As Integer)
            _idVendedor = value
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
    Public Property IdAcabado() As Integer
        Get
            Return _idAcabado
        End Get
        Set(ByVal value As Integer)
            _idAcabado = value
        End Set
    End Property
    Public Property Acabado() As String
        Get
            Return _acabado
        End Get
        Set(ByVal value As String)
            _acabado = value
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
    Public Property Puntos() As Integer
        Get
            Return _puntos
        End Get
        Set(ByVal value As Integer)
            _puntos = value
        End Set
    End Property
    Public Property PuntosPlaneados() As Integer
        Get
            Return _puntosPlaneados
        End Get
        Set(ByVal value As Integer)
            _puntosPlaneados = value
        End Set
    End Property
    Public Property Unidades() As Integer
        Get
            Return _unidades
        End Get
        Set(ByVal value As Integer)
            _unidades = value
        End Set
    End Property
    Public Property PrecioInstalacion() As Decimal
        Get
            Return _precioInstalacion
        End Get
        Set(ByVal value As Decimal)
            _precioInstalacion = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
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
    Public Sub New(id As Integer, ubicacion As String, descripcion As String, idCotiza As Integer, cotiza As String,
                   idVendedor As Integer, vendedor As String, idAcabado As Integer, acabado As String, metros As Decimal,
                   puntos As Integer, puntosPlaneados As Integer, unidades As Integer, precioInstalacion As Decimal,
                   idEstado As Integer, estado As String)
        Try
            _id = id
            _ubicacion = ubicacion
            _descripcion = descripcion
            _idCotiza = idCotiza
            _cotiza = cotiza
            _idVendedor = idVendedor
            _vendedor = vendedor
            _idAcabado = idAcabado
            _acabado = acabado
            _metros = metros
            _puntos = puntos
            _puntosPlaneados = puntosPlaneados
            _unidades = unidades
            _precioInstalacion = precioInstalacion
            _idEstado = idEstado
            _estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class