Imports Datos

Public Class ClsMotivos
#Region "Procedimientos"
    Public Function TraerTodos(idUsuarioUnoee As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of motivo)
        Try
            TraerTodos = New List(Of motivo)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t146_motivosxUsuarioTableAdapter
            Dim txAll As dsBUnoee.sp_t146_motivosxUsuarioDataTable = taAll.GetData(76)
            For Each mot As dsBUnoee.sp_t146_motivosxUsuarioRow In txAll
                TraerTodos.Add(New motivo(mot.Código, mot.Descripcion, mot.Concepto, mot.cod_desc))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxDescripcion(idUsuarioUnoee As Integer, descripcion As String) As motivo
        Try
            Dim lista As List(Of motivo) = TraerTodos(idUsuarioUnoee)
            TraerxDescripcion = lista.FirstOrDefault(Function(a) a.Descripcion = descripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class motivo
#Region "Variables"
    Private _codigo As String
    Private _descripcion As String
    Private _idConcepto As Integer
    Private _codigoDescripcion As String
#End Region
#Region "Propiedades"
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
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
    Public Property IdConcepto() As Integer
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As Integer)
            _idConcepto = value
        End Set
    End Property
    Public Property CodigoDescripcion() As String
        Get
            Return _codigoDescripcion
        End Get
        Set(ByVal value As String)
            _codigoDescripcion = value
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
    Public Sub New(codigo As String, descripcion As String, idConcepto As Integer, codigoDescripcion As String)
        Try
            _codigo = RTrim(codigo)
            _descripcion = RTrim(descripcion)
            _idConcepto = idConcepto
            _codigoDescripcion = RTrim(codigoDescripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class