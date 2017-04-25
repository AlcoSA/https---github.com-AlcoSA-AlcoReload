Imports Datos

Public Class ClsVendedoresSiesa
#Region "Variables"
    Private taVendedores As New dsAlcoComercialTableAdapters.tc026_vendedoresSiesaTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Actualiza el registro correspondiente al Id en la base de datos
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="idEstado"></param>
    ''' <param name="idDirector"></param>
    Public Sub Modificar(id As Integer, idEstado As Integer, idDirector As Integer, valorDefecto As Integer)
        Try
            taVendedores.sp_tc026_update(id, idEstado, idDirector, valorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Obtiene todos los registros de vendedores activos e inactivos
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of vendedor)
        Try
            TraerTodos = New List(Of vendedor)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc026_selectVendedoresSiesaTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc026_selectVendedoresSiesaDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc026_selectVendedoresSiesaRow In txAll.Rows
                TraerTodos.Add(New vendedor(ti.IdAlcoSys, ti.IdSiesa, ti.Nombre, ti.IdDirector, ti.NombreDirector,
                                                ti.idEstado, ti.estado, ti.valorPorDefecto))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene todos los registros de vendedores según el estado indicado
    ''' </summary>
    ''' <param name="idEstado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(idEstado As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of vendedor)
        Try
            TraerxEstado = New List(Of vendedor)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc026_selectByEstadoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc026_selectByEstadoDataTable = taAll.GetData(idEstado)
            For Each ti As dsAlcoComercial.sp_tc026_selectByEstadoRow In txAll
                TraerxEstado.Add(New vendedor(ti.IdAlcoSys, ti.IdSiesa, ti.Nombre, ti.IdDirector, ti.NombreDirector,
                                                  ti.idEstado, ti.estado, ti.valorPorDefecto))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene el vendedor correspondiente al id Siesa indicado
    ''' </summary>
    ''' <param name="idSiesa"></param>
    ''' <returns></returns>
    Public Function TraerxIdSiesa(idSiesa As String) As vendedor
        Try
            TraerxIdSiesa = New vendedor
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc026_selectByIdSiesaTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc026_selectByIdSiesaDataTable = taAll.GetData(idSiesa)
            If txAll.Rows.Count > 0 Then
                Dim ti As dsAlcoComercial.sp_tc026_selectByIdSiesaRow =
                    DirectCast(txAll.Rows(0), dsAlcoComercial.sp_tc026_selectByIdSiesaRow)
                TraerxIdSiesa = New vendedor(ti.IdAlcoSys, ti.IdSiesa, ti.Nombre, ti.IdDirector, ti.NombreDirector,
                                             ti.idEstado, ti.estado, ti.valorPorDefecto)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerVendedoresDetalle(idSiesa As String) As vendedorDetalle
        Try
            Dim ta As New dsAlcoComercialTableAdapters.sp_tc026_selectVendedorDetalleTableAdapter
            Dim tx As dsAlcoComercial.sp_tc026_selectVendedorDetalleDataTable = ta.GetData(idSiesa)
            If tx.Rows.Count > 0 Then
                Dim ven As dsAlcoComercial.sp_tc026_selectVendedorDetalleRow = DirectCast(tx.Rows(0), dsAlcoComercial.sp_tc026_selectVendedorDetalleRow)
                TraerVendedoresDetalle = New vendedorDetalle(ven.id, ven.idSiesa, ven.nombreVendedor, ven.telefono, ven.celular,
                                                                   ven.mail, ven.idDirector, ven.director, ven.idEstado, ven.estado)
            Else
                TraerVendedoresDetalle = Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class vendedor
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idSiesa As String = String.Empty
    Private _Nombre As String = String.Empty
    Private _ValorxDefecto As Integer = 0
    Private _idDirector As Integer
    Private _nombreDirector As String
#End Region
#Region "Propiedades"
    Public Property idSiesa() As String
        Get
            Return _idSiesa
        End Get
        Set(ByVal value As String)
            _idSiesa = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property valorPorDefecto() As Integer
        Get
            Return _ValorxDefecto
        End Get
        Set(ByVal value As Integer)
            _ValorxDefecto = value
        End Set
    End Property

    Public Property idDirector() As Integer
        Get
            Return _idDirector
        End Get
        Set(ByVal value As Integer)
            _idDirector = value
        End Set
    End Property

    Public Property nombreDirector() As String
        Get
            Return _nombreDirector
        End Get
        Set(ByVal value As String)
            _nombreDirector = value
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
    Public Sub New(id As Integer, idSiesa As String, Nombre As String, idDirector As Integer, nombreDirector As String,
                   idEstado As Integer, estado As String, valorxDefecto As Integer)
        Try
            Me.Id = id
            _idSiesa = idSiesa
            _Nombre = Nombre
            _idDirector = idDirector
            _nombreDirector = nombreDirector
            _ValorxDefecto = valorxDefecto
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class vendedorDetalle
#Region "Variables"
    Private _id As Integer
    Private _idSiesa As String
    Private _vendedor As String
    Private _telefono As String
    Private _celular As String
    Private _mail As String
    Private _idDirector As Integer
    Private _director As String
    Private _idEstado As Integer
    Private _estado As String
#End Region
#Region "Propiedades"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property IdSiesa() As String
        Get
            Return _idSiesa
        End Get
        Set(ByVal value As String)
            _idSiesa = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Public Property Celular() As String
        Get
            Return _celular
        End Get
        Set(ByVal value As String)
            _celular = value
        End Set
    End Property
    Public Property Mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = value
        End Set
    End Property
    Public Property IdDirector() As Integer
        Get
            Return _idDirector
        End Get
        Set(ByVal value As Integer)
            _idDirector = value
        End Set
    End Property
    Public Property Director() As String
        Get
            Return _director
        End Get
        Set(ByVal value As String)
            _director = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
#End Region
#Region "Procedimiento"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idSiesa As String, nombre As String, telefono As String, celular As String,
                   mail As String, idDirector As Integer, director As String, idEstado As Integer, estado As String)
        Try
            _id = id
            _idSiesa = idSiesa
            _vendedor = nombre
            _telefono = telefono
            _celular = celular
            _mail = mail
            _idDirector = idDirector
            _director = director
            _idEstado = idEstado
            _estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
