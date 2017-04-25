Public Class Permiso
#Region "Variables"
    Private _codigo As String = String.Empty
    Private _utilizado As Boolean = False
#End Region
#Region "Constructor"
    Public Sub New(codigo As String, utilizado As Boolean)
        Try
            _codigo = codigo
            _utilizado = utilizado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
#Region "Propiedades"
    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property
    Public Property Utilizado As Boolean
        Get
            Return _utilizado
        End Get
        Set(value As Boolean)
            _utilizado = value
        End Set
    End Property
#End Region
End Class
