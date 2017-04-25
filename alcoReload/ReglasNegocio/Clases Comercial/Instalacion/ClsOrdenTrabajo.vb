Imports Datos

Public Class ClsOrdenTrabajo
#Region "Variables"
    Private taOrdenTrabajo As New dsAlcoComercial2TableAdapters.tc097_OrdenTrabajoTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, idContrato As Integer, idProveedor As Integer, idTipoOrden As Integer,
                             idDocumentoOT As Integer, consecutivo As Integer, notas As String, idEstadoImpresion As Integer, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taOrdenTrabajo.sp_tc097_insert(usuario, idContrato, idProveedor, idTipoOrden, idDocumentoOT,
                                                                  consecutivo, notas, idEstado, idEstadoImpresion))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstado(idOrdenTrabajo As Integer, idEstado As Integer)
        Try
            taOrdenTrabajo.sp_tc097_updateEstado(idOrdenTrabajo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function cuentasCobroRealizadas(idOrdenTrabajo As Integer) As Integer
        Try
            Return Convert.ToInt32(taOrdenTrabajo.sp_tc097_selectCuentasRealizadas(idOrdenTrabajo))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerContratos(Optional ByRef dt As DataTable = Nothing) As List(Of contratoOT)
        Try
            TraerContratos = New List(Of contratoOT)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc097_selectContratosTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc097_selectContratosDataTable = taAll.GetData()
            For Each con As dsAlcoComercial2.sp_tc097_selectContratosRow In txAll.Rows
                TraerContratos.Add(New contratoOT(con.idContrato, con.cliente, con.codigoSucursal, con.obra, con.fechaInicio,
                                                  con.fechaFin, con.metros, con.vendedor, con.regionUnoee))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TieneOTxContrato(idContrato As Integer) As Boolean
        Try
            Dim list As List(Of ordenTrabajo) = TraerTodos().Where(Function(a) a.IdContrato = idContrato And a.IdEstado <> 4).ToList
            If list.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of ordenTrabajo)
        Try
            TraerTodos = New List(Of ordenTrabajo)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc097_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc097_selectAllDataTable = taAll.GetData()
            For Each ord As dsAlcoComercial2.sp_tc097_selectAllRow In txAll.Rows
                TraerTodos.Add(New ordenTrabajo(ord.idOT, ord.fechaCreacion, ord.usuarioCreacion, ord.idDocumento, ord.documento, ord.consecutivo,
                                                ord.idProveedor, ord.proveedor, ord.codigoObra, ord.obra, ord.idContrato, ord.vendedor, ord.idTipoOrden,
                                                ord.tipoOrden, ord.notas, ord.idEstado, ord.estado, ord.idEstadoImpresion, ord.estadoImpresion))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub TraerObras(ByRef dt As DataTable)
        Try
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc097_selectObrasTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc097_selectObrasDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerIDContratoxConsecutivo(idDocumento As Integer, consecutivo As Integer) As Integer
        Try
            Return Convert.ToInt32(taOrdenTrabajo.sp_tc097_selectIdContratoByConsecutivo(idDocumento, consecutivo))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class ordenTrabajo
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _idProveedor As Integer
    Private _proveedor As String
    Private _codigoObra As String
    Private _idContrato As Integer
    Private _obra As String
    Private _vendedor As String
    Private _idTipoOrden As Integer
    Private _tipoOrden As String
    Private _notas As String
    Private _idEstado As Integer
    Private _estado As String
    Private _idEstadoImpresion As Integer
    Private _estadoImpresion As String
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
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property
    Public Property UsuarioCreacion() As String
        Get
            Return _usuarioCreacion
        End Get
        Set(ByVal value As String)
            _usuarioCreacion = value
        End Set
    End Property
    Public Property IdDocumento() As Integer
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As Integer)
            _idDocumento = value
        End Set
    End Property
    Public Property Documento() As String
        Get
            Return _documento
        End Get
        Set(ByVal value As String)
            _documento = value
        End Set
    End Property
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
        End Set
    End Property
    Public Property IdProveedor() As Integer
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Integer)
            _idProveedor = value
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
    Public Property CodigoObra() As String
        Get
            Return _codigoObra
        End Get
        Set(ByVal value As String)
            _codigoObra = value
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
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
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
    Public Property IdTipoOrden() As Integer
        Get
            Return _idTipoOrden
        End Get
        Set(ByVal value As Integer)
            _idTipoOrden = value
        End Set
    End Property
    Public Property TipoOrden() As String
        Get
            Return _tipoOrden
        End Get
        Set(ByVal value As String)
            _tipoOrden = value
        End Set
    End Property
    Public Property Notas() As String
        Get
            Return _notas
        End Get
        Set(ByVal value As String)
            _notas = value
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
    Public Property IdEstadoImpresion() As Integer
        Get
            Return _idEstadoImpresion
        End Get
        Set(ByVal value As Integer)
            _idEstadoImpresion = value
        End Set
    End Property
    Public Property EstadoImpresion() As String
        Get
            Return _estadoImpresion
        End Get
        Set(ByVal value As String)
            _estadoImpresion = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idDocuemnto As Integer,
                   documento As String, consecutivo As Integer, idProveedor As Integer, proveedor As String,
                   codigoObra As String, obra As String,
                   idContrato As Integer, vendedor As String, idTipoOrden As Integer, tipoOrden As String, notas As String,
                   idEstado As Integer, estado As String, idEstadoImpresion As Integer, estadoImpresion As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idDocumento = idDocuemnto
            _documento = documento
            _consecutivo = consecutivo
            _idProveedor = idProveedor
            _proveedor = proveedor
            _codigoObra = codigoObra
            _obra = obra
            _idContrato = idContrato
            _vendedor = vendedor
            _idTipoOrden = idTipoOrden
            _tipoOrden = tipoOrden
            _notas = notas
            _idEstado = idEstado
            _estado = estado
            _idEstadoImpresion = idEstadoImpresion
            _estadoImpresion = estadoImpresion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class contratoOT
#Region "Variables"
    Private _idContrato As Integer
    Private _cliente As String
    Private _codigoSucursal As String
    Private _obra As String
    Private _fechaInicio As DateTime
    Private _fechaFin As DateTime
    Private _metros As Decimal
    Private _vendedor As String
    Private _region As String
#End Region
#Region "Propiedades"
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodigoSucursal() As String
        Get
            Return _codigoSucursal
        End Get
        Set(ByVal value As String)
            _codigoSucursal = value
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
    Public Property FechaInicio() As DateTime
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As DateTime)
            _fechaInicio = value
        End Set
    End Property
    Public Property FechaFin() As DateTime
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As DateTime)
            _fechaFin = value
        End Set
    End Property
    Public Property Metros() As Decimal
        Get
            Return _metros
        End Get
        Set(ByVal value As Decimal)
            _metros = value
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
    Public Property Region() As String
        Get
            Return _region
        End Get
        Set(ByVal value As String)
            _region = value
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
    Public Sub New(idContrato As Integer, cliente As String, codSucursal As String, obra As String,
                   fechaInicio As DateTime, fechaFin As DateTime, metros As Decimal, vendedor As String, region As String)
        Try
            _idContrato = idContrato
            _cliente = cliente
            _codigoSucursal = codSucursal
            _obra = obra
            _fechaInicio = fechaInicio
            _fechaFin = fechaFin
            _metros = metros
            _vendedor = vendedor
            _region = region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class