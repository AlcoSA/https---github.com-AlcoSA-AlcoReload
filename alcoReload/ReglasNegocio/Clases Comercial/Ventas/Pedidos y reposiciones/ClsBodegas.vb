Imports Datos

Public Class ClsBodegas
#Region "Procedimientos"
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of bodega)
        Try
            TraerTodos = New List(Of bodega)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t150_Unoee_BodegasTableAdapter
            Dim txAll As dsBUnoee.sp_t150_Unoee_BodegasDataTable = taAll.GetData()
            For Each bod As dsBUnoee.sp_t150_Unoee_BodegasRow In txAll
                TraerTodos.Add(New bodega(bod.id, bod.prefijo, bod.descripcion, bod.descripcion_Corta, bod.notas))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxPrefijo(prefijo As String) As bodega
        Try
            Dim lista As List(Of bodega) = TraerTodos()
            TraerxPrefijo = lista.FirstOrDefault(Function(a) a.Prefijo = prefijo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxDescripcion(descripcion As String) As bodega
        Try
            Dim lista As List(Of bodega) = TraerTodos()
            TraerxDescripcion = lista.FirstOrDefault(Function(a) a.Descripcion = descripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class bodega
#Region "Variables"
    Private _id As Integer
    Private _prefijo As String
    Private _descripcion As String
    Private _descripcionCorta As String
    Private _notas As String
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
    Public Property Prefijo() As String
        Get
            Return _prefijo
        End Get
        Set(ByVal value As String)
            _prefijo = value
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
    Public Property Descripcion_Corta() As String
        Get
            Return _descripcionCorta
        End Get
        Set(ByVal value As String)
            _descripcionCorta = value
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
#End Region
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, prefijo As String, descripcion As String,
                   descripcionCorta As String, notas As String)
        _id = id
        _prefijo = Trim(prefijo)
        _descripcion = Trim(descripcion)
        _descripcionCorta = descripcionCorta
        _notas = notas
    End Sub
#End Region
End Class
