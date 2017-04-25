Imports Datos

Public Class ClsListaPrecios
#Region "Procedimientos"
    ''' <summary>
    ''' Obtieene los registros de listas precios de Unoee
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos() As List(Of lisPrecios)
        Try
            traerTodos = New List(Of lisPrecios)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t112_Unoee_ListasPreciosTableAdapter
            Dim txAll As dsBUnoee.sp_t112_Unoee_ListasPreciosDataTable = taAll.GetData()
            For Each lp As dsBUnoee.sp_t112_Unoee_ListasPreciosRow In txAll
                traerTodos.Add(New lisPrecios(lp.id, lp.descripcion, lp.idMoneda))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class lisPrecios
#Region "Variables"
    Private _id As String
    Private _descripcion As String
    Private _idMoneda As String
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
    Public Property IdMoneda() As String
        Get
            Return _idMoneda
        End Get
        Set(ByVal value As String)
            _idMoneda = value
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
    Public Sub New(id As String, descripcion As String, idMoneda As String)
        Try
            _id = Trim(id)
            _descripcion = Trim(descripcion)
            _idMoneda = Trim(idMoneda)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
