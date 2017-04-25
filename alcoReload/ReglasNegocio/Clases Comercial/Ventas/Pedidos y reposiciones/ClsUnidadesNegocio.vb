Imports Datos

Public Class ClsUnidadesNegocio
#Region "Procedimientos"
    Public Function TraerTodos() As List(Of unidadNegocio)
        Try
            TraerTodos = New List(Of unidadNegocio)
            Dim taAll As New dsBUnoeeTableAdapters.alco_cargar_uNegocioTableAdapter
            Dim txAll As dsBUnoee.alco_cargar_uNegocioDataTable = taAll.GetData()
            For Each un As dsBUnoee.alco_cargar_uNegocioRow In txAll
                TraerTodos.Add(New unidadNegocio(un.f281_id, un.f281_descripcion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class unidadNegocio
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
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As String, descripcion As String)
        Try
            _id = Trim(id)
            _descripcion = Trim(descripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
