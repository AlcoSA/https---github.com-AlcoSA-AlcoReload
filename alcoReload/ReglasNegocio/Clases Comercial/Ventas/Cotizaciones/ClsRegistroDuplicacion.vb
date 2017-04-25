Imports Datos
Public Class ClsRegistroDuplicacion

    Public Function TraerporIdBase(idbase As Integer) As List(Of RegistroDuplicacion)
        TraerporIdBase = New List(Of RegistroDuplicacion)
        Try
            Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc093_selectByIdCotizaBaseTableAdapter
            Dim txall As dsAlcoCotizaciones.sp_tc093_selectByIdCotizaBaseDataTable = taAll.GetData(idbase)
            For Each ti As dsAlcoCotizaciones.sp_tc093_selectByIdCotizaBaseRow In txall.Rows
                TraerporIdBase.Add(New RegistroDuplicacion(0, ti.fc016_rowid, ti.fc016_nombreCotiza))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporIdDuplicado(idduplicada As Integer) As RegistroDuplicacion
        TraerporIdDuplicado = New RegistroDuplicacion
        Try
            Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc093_selectByIdCotizaduplicadaTableAdapter
            Dim txall As dsAlcoCotizaciones.sp_tc093_selectByIdCotizaduplicadaDataTable = taAll.GetData(idduplicada)
            For Each ti As dsAlcoCotizaciones.sp_tc093_selectByIdCotizaduplicadaRow In txall.Rows
                TraerporIdDuplicado = New RegistroDuplicacion(ti.fc016_rowid, 0, ti.fc016_nombreCotiza)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class

Public Class RegistroDuplicacion
#Region "Variables"
    Private _idcotizabase As Integer = 0
    Private _idcotizaduplicada As Integer = 0
    Private _nombrecotiza As String = "--"
#End Region
#Region "Propiedades"
    Public Property IdCotizaBase As Integer
        Get
            Return _idcotizabase
        End Get
        Set(value As Integer)
            _idcotizabase = value
        End Set
    End Property
    Public Property IdCotizaDuplicada As Integer
        Get
            Return _idcotizaduplicada
        End Get
        Set(value As Integer)
            _idcotizaduplicada = value
        End Set
    End Property
    Public Property Nombre_Cotiza As String
        Get
            Return _nombrecotiza
        End Get
        Set(value As String)
            _nombrecotiza = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub

    Public Sub New(idcotizabase As Integer, idcotizaduplicada As Integer, nombrecotiza As String)
        _idcotizabase = idcotizabase
        _idcotizaduplicada = idcotizaduplicada
        _nombrecotiza = Trim(nombrecotiza)
    End Sub

#End Region

End Class
