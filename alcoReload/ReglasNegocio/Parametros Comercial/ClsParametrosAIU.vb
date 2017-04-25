Imports Datos

Public Class ClsParametrosAIU
#Region "Variables"
    Private taParametrosAIU As New dsAlcoComercialTableAdapters.tc036_parametrosIVATableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Ingresa un nuevo registro en la tabla de parámetros IVA
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="porcAdministracion"></param>
    ''' <param name="porcImprovistos"></param>
    ''' <param name="porcUtilidad"></param>
    Public Sub Insertar(usuarioCreacion As String, porcAdministracion As Decimal,
                        porcImprovistos As Decimal, porcUtilidad As Decimal)
        Try
            taParametrosAIU.sp_tc036_insert(usuarioCreacion, porcAdministracion, porcImprovistos, porcUtilidad)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los porcentajes registrados en parámetros IVA
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of parametroIVA)
        Try
            traerTodos = New List(Of parametroIVA)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc036_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc036_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc036_selectAllRow In txAll.Rows
                traerTodos.Add(New parametroIVA(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.porcAdministracion,
                                                 ti.porcImprovistos, ti.porcUtilidad))
            Next
            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene los porcentajes correspondientes al último registro de parámetros IVA
    ''' </summary>
    ''' <returns></returns>
    Public Function traerUltimo() As parametroIVA
        Try
            traerUltimo = New parametroIVA
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc036_selectUltimoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc036_selectUltimoDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc036_selectUltimoRow In txAll.Rows
                    traerUltimo = New parametroIVA(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.porcAdministracion,
                                                 ti.porcImprovistos, ti.porcUtilidad)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class parametroIVA
    Inherits ClsBaseParametros
#Region "Variables"
    Private _porcAdministracion As Decimal
    Private _porcImprovistos As Decimal
    Private _porcUtilidad As Decimal
#End Region
#Region "Propiedades"
    Public Property porcentajeAdministracion() As Decimal
        Get
            Return _porcAdministracion
        End Get
        Set(ByVal value As Decimal)
            _porcAdministracion = value
        End Set
    End Property

    Public Property porcentajeImprovistos() As Decimal
        Get
            Return _porcImprovistos
        End Get
        Set(ByVal value As Decimal)
            _porcImprovistos = value
        End Set
    End Property

    Public Property porcentajeUtilidad() As Decimal
        Get
            Return _porcUtilidad
        End Get
        Set(ByVal value As Decimal)
            _porcUtilidad = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, porcAdministracion As Decimal,
                   porcImprovistos As Decimal, porcUtilidad As Decimal)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _porcAdministracion = porcAdministracion
            _porcImprovistos = porcImprovistos
            _porcUtilidad = porcUtilidad
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
