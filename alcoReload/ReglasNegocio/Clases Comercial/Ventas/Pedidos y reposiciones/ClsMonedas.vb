Imports Datos

Public Class ClsMonedas
    ''' <summary>
    ''' Obtiene los tipos de moneda existentes en la base de datos Unoee
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos() As List(Of moneda)
        Try
            traerTodos = New List(Of moneda)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t017_Unoee_MonedasTableAdapter
            Dim txAll As dsBUnoee.sp_t017_Unoee_MonedasDataTable = taAll.GetData()
            For Each m As dsBUnoee.sp_t017_Unoee_MonedasRow In txAll
                traerTodos.Add(New moneda(m.id, m.descripcion, m.simbolo))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class moneda
#Region "Variables"
    Private _id As String
    Private _descripcion As String
    Private _simbolo As String
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
    Public Property Simbolo() As String
        Get
            Return _simbolo
        End Get
        Set(ByVal value As String)
            _simbolo = value
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
    Public Sub New(id As String, descripcion As String, simbolo As String)
        Try
            _id = id
            _descripcion = descripcion
            _simbolo = simbolo
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
