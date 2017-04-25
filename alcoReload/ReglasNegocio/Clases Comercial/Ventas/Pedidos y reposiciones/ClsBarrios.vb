Imports Datos

Public Class ClsBarrios
#Region "Procedimientos"
    ''' <summary>
    ''' Obtiene los barrios correspondientes al país, departamento y ciudad indicados
    ''' </summary>
    ''' <param name="idPais"></param>
    ''' <param name="idDepto"></param>
    ''' <param name="idCiudad"></param>
    ''' <returns></returns>
    Public Function traerTodos(idPais As String, idDepto As String, idCiudad As String) As List(Of barrio)
        Try
            traerTodos = New List(Of barrio)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t014_UnoeeBarriosTableAdapter
            Dim txAll As dsBUnoee.sp_t014_UnoeeBarriosDataTable = taAll.GetData(idPais, idDepto, idCiudad)
            For Each br As dsBUnoee.sp_t014_UnoeeBarriosRow In txAll
                traerTodos.Add(New barrio(br.idPais, br.idDepto, br.idCiudad, br.idBarrio, br.nombreBarrio))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class barrio
#Region "Variables"
    Private _idPaisSiesa As String
    Private _idDeptoSiesa As String
    Private _idCiudadSiesa As String
    Private _idBarrio As String
    Private _nombreBarrio As String
#End Region
#Region "Propiedades"
    Public Property IdPaisSiesa() As String
        Get
            Return _idPaisSiesa
        End Get
        Set(ByVal value As String)
            _idPaisSiesa = value
        End Set
    End Property
    Public Property IdDeptoSiesa() As String
        Get
            Return _idDeptoSiesa
        End Get
        Set(ByVal value As String)
            _idDeptoSiesa = value
        End Set
    End Property
    Public Property IdCiudadSiesa() As String
        Get
            Return _idCiudadSiesa
        End Get
        Set(ByVal value As String)
            _idCiudadSiesa = value
        End Set
    End Property
    Public Property IdBarrio() As String
        Get
            Return _idBarrio
        End Get
        Set(ByVal value As String)
            _idBarrio = value
        End Set
    End Property
    Public Property NombreBarrio() As String
        Get
            Return _nombreBarrio
        End Get
        Set(ByVal value As String)
            _nombreBarrio = value
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
    Public Sub New(idPais As String, idDepto As String, idCiudad As String,
                   idBarrio As String, nombreBarrio As String)
        Try
            _idPaisSiesa = idPais
            _idDeptoSiesa = idDepto
            _idCiudadSiesa = idCiudad
            _idBarrio = idBarrio
            _nombreBarrio = nombreBarrio
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
