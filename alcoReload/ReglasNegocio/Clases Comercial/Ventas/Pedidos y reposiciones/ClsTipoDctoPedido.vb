Imports Datos

Public Class ClsTipoDctoPedido
#Region "Procedimientos"
    Public Function traerTodos() As List(Of tipoDcto)
        Try
            traerTodos = New List(Of tipoDcto)
            Dim taAll As New dsBUnoeeTableAdapters.alco_documentosAlcoTableAdapter
            Dim txAll As dsBUnoee.alco_documentosAlcoDataTable = taAll.GetData
            For Each doc As dsBUnoee.alco_documentosAlcoRow In txAll
                traerTodos.Add(New tipoDcto(doc.Id, doc.descripcion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerConsecutivo(idTipoDocto As String) As Integer
        TraerConsecutivo = 0
        Try
            Dim taAll As New dsBUnoeeTableAdapters.sp_t022_Unoee_ConsecutivoTableAdapter
            Dim txAll As dsBUnoee.sp_t022_Unoee_ConsecutivoDataTable = taAll.GetData(idTipoDocto)
            If txAll.Rows.Count > 0 Then
                Dim con As dsBUnoee.sp_t022_Unoee_ConsecutivoRow = DirectCast(txAll.Rows(0), dsBUnoee.sp_t022_Unoee_ConsecutivoRow)
                TraerConsecutivo = con.consecutivo
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class tipoDcto
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
            _id = id
            _descripcion = descripcion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class