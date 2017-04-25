Imports Datos

Public Class ClsArticulosUnoee
#Region "Procedimientos"
    Public Function TraerAccesorios(Optional ByRef dt As DataTable = Nothing) As List(Of ArticuloUnoee)
        Try
            TraerAccesorios = New List(Of ArticuloUnoee)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t120_Unoee_AccesoriosTableAdapter
            Dim txAll As dsBUnoee.sp_t120_Unoee_AccesoriosDataTable = taAll.GetData()
            For Each acc As dsBUnoee.sp_t120_Unoee_AccesoriosRow In txAll
                TraerAccesorios.Add(New ArticuloUnoee(acc.Item, acc.Referencia, acc.Descripcion, acc.Unidad_Inventario, acc.Unidad_Orden))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerAccesorioxRef(referencia As String) As ArticuloUnoee
        Try
            Dim lista As List(Of ArticuloUnoee) = TraerAccesorios()
            TraerAccesorioxRef = lista.FirstOrDefault(Function(a) a.Referencia = referencia)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerPerfiles(Optional ByRef dt As DataTable = Nothing) As List(Of ArticuloUnoee)
        Try
            TraerPerfiles = New List(Of ArticuloUnoee)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t120_Unoee_PerfilesTableAdapter
            Dim txAll As dsBUnoee.sp_t120_Unoee_PerfilesDataTable = taAll.GetData()
            For Each per As dsBUnoee.sp_t120_Unoee_PerfilesRow In txAll
                TraerPerfiles.Add(New ArticuloUnoee(per.Item, per.Referencia, per.Descripcion, per.Unidad_Inventario, per.Unidad_Orden))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerPerfilxRef(referencia As String) As ArticuloUnoee
        Try
            Dim lista As List(Of ArticuloUnoee) = TraerPerfiles()
            TraerPerfilxRef = lista.FirstOrDefault(Function(a) a.Referencia = referencia)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerVidrioCrudo(Optional ByRef dt As DataTable = Nothing) As List(Of ArticuloUnoee)
        Try
            TraerVidrioCrudo = New List(Of ArticuloUnoee)
            Dim taAll As New dsBUnoeeTableAdapters.sp_t120_Unoee_VidriosCrudosTableAdapter
            Dim txAll As dsBUnoee.sp_t120_Unoee_VidriosCrudosDataTable = taAll.GetData()
            For Each vid As dsBUnoee.sp_t120_Unoee_VidriosCrudosRow In txAll
                TraerVidrioCrudo.Add(New ArticuloUnoee(vid.Item, vid.Referencia, vid.Descripcion, vid.Unidad_Inventario, vid.Unidad_Orden))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerVidrioCrudoxRef(referencia As String) As ArticuloUnoee
        Try
            Dim lista As List(Of ArticuloUnoee) = TraerVidrioCrudo()
            TraerVidrioCrudoxRef = lista.FirstOrDefault(Function(a) a.Referencia = referencia)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class ArticuloUnoee
#Region "Variables"
    Private _idItem As Integer
    Private _referencia As String
    Private _descripcion As String
    Private _unidadInventario As String
    Private _unidadOrden As String
#End Region
#Region "Propiedades"
    Public Property IdItem() As Integer
        Get
            Return _idItem
        End Get
        Set(ByVal value As Integer)
            _idItem = value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
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
    Public Property UnidadInventario() As String
        Get
            Return _unidadInventario
        End Get
        Set(ByVal value As String)
            _unidadInventario = value
        End Set
    End Property
    Public Property UnidadOrden() As String
        Get
            Return _unidadOrden
        End Get
        Set(ByVal value As String)
            _unidadOrden = value
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
    Public Sub New(idItem As Integer, referencia As String, descripcion As String,
                   unidadInventario As String, unidadOrden As String)
        Try
            _idItem = idItem
            _referencia = Trim(referencia)
            _descripcion = Trim(descripcion)
            _unidadInventario = Trim(unidadInventario)
            _unidadOrden = Trim(unidadOrden)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
