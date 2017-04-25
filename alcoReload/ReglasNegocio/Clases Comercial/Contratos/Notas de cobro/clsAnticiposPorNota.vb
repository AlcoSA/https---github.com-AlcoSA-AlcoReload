Imports Datos

Public Class clsAnticiposPorNota
#Region "Variables"
    Private _objMovitoxCuota As New dsAlcoContratosTableAdapters.tc077_NotasCobroAnticipoTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub InsertAnticipoxCuota(idNota As Integer, idMovitoAnticipo As Integer)
        Try
            _objMovitoxCuota.sp_tc077_insert(idMovitoAnticipo, idNota)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub UpdateAnticipoxCuota(idNota As Integer, idEstado As Integer)
        Try
            _objMovitoxCuota.sp_tc077_update(idNota, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of CuotaxNotaCobro)
        Try
            TraerTodos = New List(Of CuotaxNotaCobro)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc077_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc077_selectAllDataTable = taAll.GetData()
            For Each cta As dsAlcoContratos.sp_tc077_selectAllRow In txAll
                TraerTodos.Add(New CuotaxNotaCobro(cta.id, cta.idMovAnticipo, cta.idNotaCobro, cta.idEstado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdMovitoAnticipo(idMovitoAnticipo As Integer) As List(Of CuotaxNotaCobro)
        Try
            TraerxIdMovitoAnticipo = New List(Of CuotaxNotaCobro)
            Dim list As List(Of CuotaxNotaCobro) = TraerTodos()
            TraerxIdMovitoAnticipo = list.Where(Function(a) a.IdMovitoAnticipo = idMovitoAnticipo And a.IdEstado <> ClsEnums.Estados.ANULADO).ToList
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdNotaCobro(idNotaCobro As Integer) As List(Of CuotaxNotaCobro)
        Try
            TraerxIdNotaCobro = New List(Of CuotaxNotaCobro)
            Dim list As List(Of CuotaxNotaCobro) = TraerTodos()
            TraerxIdNotaCobro = list.Where(Function(a) a.IdNotaCobro = idNotaCobro And a.IdEstado <> ClsEnums.Estados.ANULADO).ToList
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerDetalleNotaCobro(idNotaCobro As Integer) As List(Of CuotaxNotaCobro)
        Try
            TraerDetalleNotaCobro = New List(Of CuotaxNotaCobro)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc077_selectDetalleTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc077_selectDetalleDataTable = taAll.GetData(idNotaCobro)
            For Each det As dsAlcoContratos.sp_tc077_selectDetalleRow In txAll
                TraerDetalleNotaCobro.Add(New CuotaxNotaCobro(det.numeroCuota, det.porcentCuota, det.fechaCuota,
                                                              det.valorCuota, det.idEstado, det.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class CuotaxNotaCobro
#Region "Variables"
    Private _id As Integer
    Private _idMovitoAnticipo As Integer
    Private _idNotaCobro As Integer
    Private _idEstado As Integer
    Private _estado As String
    Private _numeroCuota As Integer
    Private _porcentCuota As Decimal
    Private _fechaCuota As DateTime
    Private _valorCuota As Decimal
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
    Public Property IdMovitoAnticipo() As Integer
        Get
            Return _idMovitoAnticipo
        End Get
        Set(ByVal value As Integer)
            _idMovitoAnticipo = value
        End Set
    End Property
    Public Property IdNotaCobro() As Integer
        Get
            Return _idNotaCobro
        End Get
        Set(ByVal value As Integer)
            _idNotaCobro = value
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
    Public Property NumeroCuota() As Integer
        Get
            Return _numeroCuota
        End Get
        Set(ByVal value As Integer)
            _numeroCuota = value
        End Set
    End Property
    Public Property PorcentajeCuota() As Decimal
        Get
            Return _porcentCuota
        End Get
        Set(ByVal value As Decimal)
            _porcentCuota = value
        End Set
    End Property
    Public Property FechaCuota() As DateTime
        Get
            Return _fechaCuota
        End Get
        Set(ByVal value As DateTime)
            _fechaCuota = value
        End Set
    End Property
    Public Property ValorCuota() As Decimal
        Get
            Return _valorCuota
        End Get
        Set(ByVal value As Decimal)
            _valorCuota = value
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
    Public Sub New(id As Integer, idMovitoAnticipo As Integer, idNotaCobro As Integer, idEstado As Integer)
        Try
            _id = id
            _idMovitoAnticipo = idMovitoAnticipo
            _idNotaCobro = idNotaCobro
            _idEstado = idEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(numCuota As Integer, porcCuota As Decimal, fechaCuota As DateTime, valorCuota As Decimal,
                   idEstado As Integer, estado As String)
        _numeroCuota = numCuota
        _porcentCuota = porcCuota
        _fechaCuota = fechaCuota
        _valorCuota = valorCuota
        _idEstado = idEstado
        _estado = estado
    End Sub
#End Region
End Class
