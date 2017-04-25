Imports System.Linq
Public Class costo
#Region "Propiedades"
    Private _id As Integer
    Public Property idCosto() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _referencia As String
    Public Property referencia() As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
        End Set
    End Property
    Private _familiaMaterial As ClsEnums.FamiliasMateriales
    Public Property familiaMaterial() As ClsEnums.FamiliasMateriales
        Get
            Return _familiaMaterial
        End Get
        Set(ByVal value As ClsEnums.FamiliasMateriales)
            _familiaMaterial = value
        End Set
    End Property
    Private _cantidad As Decimal
    Public Property cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Private _unidadMedia As String
    Public Property und() As String
        Get
            Return _unidadMedia
        End Get
        Set(ByVal value As String)
            _unidadMedia = value
        End Set
    End Property
    Private _peso As Decimal
    Public Property peso() As Decimal
        Get
            Return _peso
        End Get
        Set(ByVal value As Decimal)
            _peso = value
        End Set
    End Property
    Private _costoUnitario As Decimal
    Public Property costoUnitario() As Decimal
        Get
            Return _costoUnitario
        End Get
        Set(ByVal value As Decimal)
            _costoUnitario = value
        End Set
    End Property
    Private _costoTotal As Decimal
    Public Property costoTotal() As Decimal
        Get
            Return _costoTotal
        End Get
        Set(ByVal value As Decimal)
            _costoTotal = value
        End Set
    End Property

#End Region
#Region "Constructor"
    Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Sub New(id As Integer, referencia As String, familiaMaterial As ClsEnums.FamiliasMateriales, cantidad As Decimal,
            und As String, peso As Decimal, costoUnitario As Decimal, costoTotal As Decimal)
        Try
            _id = id
            _referencia = referencia
            _familiaMaterial = familiaMaterial
            _cantidad = cantidad
            _unidadMedia = und
            _peso = peso
            _costoUnitario = costoUnitario
            _costoTotal = costoTotal
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class


