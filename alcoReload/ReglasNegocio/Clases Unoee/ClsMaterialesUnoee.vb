Imports Datos
Public Class ClsMaterialesUnoee
#Region "Variables"

#End Region

#Region "Funciones"
    Public Function TraerMaterialesxTipo(tipo As Integer) As List(Of MaterialUnoee)
        TraerMaterialesxTipo = New List(Of MaterialUnoee)()
        Try
            Dim taTipo As New dsBUnoeeTableAdapters.alco_TraerItemsSeguntipoTableAdapter
            Dim txTipo As dsBUnoee.alco_TraerItemsSeguntipoDataTable = taTipo.GetData(tipo)
            For Each mxt As dsBUnoee.alco_TraerItemsSeguntipoRow In txTipo.Rows
                TraerMaterialesxTipo.Add(New MaterialUnoee(mxt.Id, mxt.Referencia, mxt.Descripcion_Corta, mxt.Descripcion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

End Class

Public Class MaterialUnoee
#Region "Variables"
    Private _id As Integer = 0
    Private _nombrematerial As String = String.Empty
    Private _descripcioncorta As String = String.Empty
    Private _descripcion As String = String.Empty
#End Region
#Region "Propiedades"
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property NombreMaterial As String
        Get
            Return _nombrematerial
        End Get
        Set(value As String)
            _nombrematerial = value
        End Set
    End Property

    Public Property DescripcionCorta As String
        Get
            Return _descripcioncorta
        End Get
        Set(value As String)
            _descripcioncorta = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, nombrematerial As String, descripcioncorta As String, descripcion As String)
        Try
            _id = id
            _nombrematerial = Trim(nombrematerial)
            _descripcioncorta = Trim(descripcioncorta)
            _descripcion = Trim(descripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class
