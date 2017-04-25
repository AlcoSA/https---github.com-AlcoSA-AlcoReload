Imports Datos

Public Class ClsCentroOperaciones
#Region "Procedimientos"
    Public Function traerTodos() As List(Of centroOperacion)
        Try
            traerTodos = New List(Of centroOperacion)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t285_UnoeeCentrosOperacionesTableAdapter
            Dim txAll As dsBUnoee.sp_t285_UnoeeCentrosOperacionesDataTable = taAll.GetData()
            For Each co As dsBUnoee.sp_t285_UnoeeCentrosOperacionesRow In txAll
                traerTodos.Add(New centroOperacion(co.idCia, co.id, co.descripcion, co.idContacto, co.contacto))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class centroOperacion
#Region "Variables"
    Private _idCia As Integer
    Private _id As String
    Private _descripcion As String
    Private _idContacto As Integer
    Private _contacto As String
#End Region
#Region "Propiedades"
    Public Property IdCia() As Integer
        Get
            Return _idCia
        End Get
        Set(ByVal value As Integer)
            _idCia = value
        End Set
    End Property
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
    Public Property IdContacto() As Integer
        Get
            Return _idContacto
        End Get
        Set(ByVal value As Integer)
            _idContacto = value
        End Set
    End Property
    Public Property Contacto() As String
        Get
            Return _contacto
        End Get
        Set(ByVal value As String)
            _contacto = value
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
    Public Sub New(idCia As Integer, id As String, descripcion As String, idContacto As Integer, contacto As String)
        Try
            _idCia = idCia
            _id = id
            _descripcion = descripcion
            _idContacto = idContacto
            _contacto = contacto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
