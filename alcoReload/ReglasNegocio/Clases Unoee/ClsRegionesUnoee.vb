Imports Datos

Public Class ClsRegionesUnoee
#Region "Procedimientos"
    Public Function TraerTodos() As List(Of regionUnoee)
        Try
            TraerTodos = New List(Of regionUnoee)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t206_UnoeeRegionesTableAdapter
            Dim txAll As dsBUnoee.sp_t206_UnoeeRegionesDataTable = taAll.GetData()
            For Each reg As dsBUnoee.sp_t206_UnoeeRegionesRow In txAll
                TraerTodos.Add(New regionUnoee(reg.id, reg.descripcion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class regionUnoee
#Region "Variables"
    Private _id As String
    Private _descripcion As String
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
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As String, descripcion As String)
        Try
            _id = id
            _descripcion = descripcion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
