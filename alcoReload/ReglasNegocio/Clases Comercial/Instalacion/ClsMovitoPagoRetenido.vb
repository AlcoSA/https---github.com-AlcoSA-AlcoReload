Imports Datos

Public Class ClsMovitoPagoRetenido
#Region "Variables"
    Private taMovitoPagoRetenido As New dsAlcoComercial2TableAdapters.tc104_movitoPagoRetenidosTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idPagoRetenido As Integer, idCuentaCobro As Integer, valor As Decimal, idEstado As Integer)
        Try
            taMovitoPagoRetenido.sp_tc104_insert(usuario, idPagoRetenido, idCuentaCobro, valor, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(idPagoRetenidos As Integer, idEstado As Integer, usuario As String)
        Try
            taMovitoPagoRetenido.sp_tc104_updateEstado(idPagoRetenidos, idEstado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub traerDetalle(ByRef dt As DataTable)
        Try
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc104_selectDetalleTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc104_selectDetalleDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdPagoRetenido(idPagoRetenido As Integer) As List(Of movitoPagoRet)
        Try
            TraerxIdPagoRetenido = New List(Of movitoPagoRet)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc104_selectByIdPagoRetenidoTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc104_selectByIdPagoRetenidoDataTable = taAll.GetData(idPagoRetenido)
            For Each mov As dsAlcoComercial2.sp_tc104_selectByIdPagoRetenidoRow In txAll
                TraerxIdPagoRetenido.Add(New movitoPagoRet(mov.id, mov.fechaCreacion, mov.usuarioCreacion, mov.idPagoRetenido, mov.idCuentaCobro,
                                                           mov.obra, mov.valorPagado, mov.usuarioModi, mov.fechaModificacion, mov.idEstado, mov.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerDetallexObra(obra As String) As List(Of detallePagoRet)
        Try
            TraerDetallexObra = New List(Of detallePagoRet)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc104_selectDetalleByObraTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc104_selectDetalleByObraDataTable = taAll.GetData(obra)
            For Each det As dsAlcoComercial2.sp_tc104_selectDetalleByObraRow In txAll
                TraerDetallexObra.Add(New detallePagoRet(det.fechaPagoRetenido, det.fechaCuenta, det.proveedor, det.encargado, det.subtotal,
                                                         det.retenido, det.total, det.pagado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoPagoRet
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idPagoRetenido As Integer
    Private _idCuentaCobro As Integer
    Private _obra As String
    Private _valorPagado As Decimal
#End Region
#Region "Propiedades"
    Public Property IdPagoRetenidos() As Integer
        Get
            Return _idPagoRetenido
        End Get
        Set(ByVal value As Integer)
            _idPagoRetenido = value
        End Set
    End Property
    Public Property IdCuentaCobro() As Integer
        Get
            Return _idCuentaCobro
        End Get
        Set(ByVal value As Integer)
            _idCuentaCobro = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property ValorPagado() As Decimal
        Get
            Return _valorPagado
        End Get
        Set(ByVal value As Decimal)
            _valorPagado = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idPagoRetenido As Integer,
                   idCuentaCobro As Integer, obra As String, valorPagado As Decimal, usuarioModi As String,
                   fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idPagoRetenido = idPagoRetenido
            _idCuentaCobro = idCuentaCobro
            _obra = obra
            _valorPagado = valorPagado
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class detallePagoRet
#Region "Variables"
    Private _fechaPagoRetenido As DateTime
    Private _fechaCuenta As DateTime
    Private _proveedor As String
    Private _encargado As String
    Private _subtotal As Decimal
    Private _retenido As Decimal
    Private _total As Decimal
    Private _pagado As Decimal
#End Region
#Region "Propiedades"
    Public Property FechaPagoRetenido() As DateTime
        Get
            Return _fechaPagoRetenido
        End Get
        Set(ByVal value As DateTime)
            _fechaPagoRetenido = value
        End Set
    End Property
    Public Property FechaCuenta() As DateTime
        Get
            Return _fechaCuenta
        End Get
        Set(ByVal value As DateTime)
            _fechaCuenta = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
    Public Property Encargado() As String
        Get
            Return _encargado
        End Get
        Set(ByVal value As String)
            _encargado = value
        End Set
    End Property
    Public Property Subtotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property
    Public Property Retenido() As Decimal
        Get
            Return _retenido
        End Get
        Set(ByVal value As Decimal)
            _retenido = value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property
    Public Property Pagado() As Decimal
        Get
            Return _pagado
        End Get
        Set(ByVal value As Decimal)
            _pagado = value
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
    Public Sub New(fechaPagoRetenido As DateTime, fechaCuenta As DateTime, proveedor As String, encargado As String,
                   subtotal As Decimal, retenido As Decimal, total As Decimal, pagado As Decimal)
        Try
            _fechaPagoRetenido = fechaPagoRetenido
            _fechaCuenta = fechaCuenta
            _proveedor = proveedor
            _encargado = encargado
            _subtotal = subtotal
            _retenido = retenido
            _total = total
            _pagado = pagado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
