Imports Datos

Public Class ClsCondicionesPago
#Region "Procedimientos"
    Public Function TraerTodos() As List(Of condicionPago)
        Try
            TraerTodos = New List(Of condicionPago)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t208_Unoee_CondicionesPagoTableAdapter
            Dim txAll As dsBUnoee.sp_t208_Unoee_CondicionesPagoDataTable = taAll.GetData()
            For Each cpg As dsBUnoee.sp_t208_Unoee_CondicionesPagoRow In txAll
                TraerTodos.Add(New condicionPago(cpg.id, cpg.descripcion, cpg.dias, cpg.diasProntoPago, cpg.tasaDescuento))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(id As String) As condicionPago
        Try
            TraerxId = New condicionPago
            Dim taAll As New dsBUnoeeTableAdapters.sp_t208_Unoee_CondicionesPagoByIdTableAdapter
            Dim txAll As dsBUnoee.sp_t208_Unoee_CondicionesPagoByIdDataTable = taAll.GetData(id)
            If txAll.Rows.Count > 0 Then
                Dim cpg As dsBUnoee.sp_t208_Unoee_CondicionesPagoByIdRow = DirectCast(txAll.Rows(0), dsBUnoee.sp_t208_Unoee_CondicionesPagoByIdRow)
                TraerxId = New condicionPago(cpg.id, cpg.descripcion, cpg.dias, cpg.diasProntoPago, cpg.tasaDescuento)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class condicionPago
#Region "Variables"
    Private _id As String
    Private _descripcion As String
    Private _dias As Integer
    Private _diasProntoPago As Integer
    Private _tasaDcto As Decimal
#End Region
#Region "Propiedades"
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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
    Public Property Dias() As Integer
        Get
            Return _dias
        End Get
        Set(ByVal value As Integer)
            _dias = value
        End Set
    End Property
    Public Property DiasProntoPago() As Integer
        Get
            Return _diasProntoPago
        End Get
        Set(ByVal value As Integer)
            _diasProntoPago = value
        End Set
    End Property
    Public Property TasaDescuento() As Decimal
        Get
            Return _tasaDcto
        End Get
        Set(ByVal value As Decimal)
            _tasaDcto = value
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
    Public Sub New(id As String, descripcion As String, dias As Integer, diasProntoPago As Integer, tasaDescuento As Decimal)
        Try
            _id = id
            _descripcion = descripcion
            _dias = dias
            _diasProntoPago = diasProntoPago
            _tasaDcto = tasaDescuento
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
