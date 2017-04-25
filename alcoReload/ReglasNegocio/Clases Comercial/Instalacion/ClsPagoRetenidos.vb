Imports Datos

Public Class ClsPagoRetenidos
#Region "Variables"
    Private taPagoRetenido As New dsAlcoComercial2TableAdapters.tc103_pagoRetenidosTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(Usuario As String, idDocumento As Integer, consecutivo As Integer, idProveedor As Integer,
                             idEncargado As Integer, idEstado As Integer, idEstadoImpresion As Integer) As Integer
        Try
            Return Convert.ToInt32(taPagoRetenido.sp_tc103_insert(Usuario, idDocumento, consecutivo, idProveedor,
                                                                  idEncargado, idEstado, idEstadoImpresion))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstado(ActualizarImpresion As Boolean, idRetenido As Integer, idEstado As Integer, usuario As String)
        Try
            taPagoRetenido.sp_tc103_updateEstado(ActualizarImpresion, idRetenido, idEstado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of pagoRetenido)
        Try
            TraerTodos = New List(Of pagoRetenido)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc103_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc103_selectAllDataTable = taAll.GetData()
            For Each pag As dsAlcoComercial2.sp_tc103_selectAllRow In txAll
                TraerTodos.Add(New pagoRetenido(pag.id, pag.fechaCreacion, pag.usuarioCreacion, pag.idDocumento, pag.documento,
                                                pag.consecutivo, pag.idProveedor, pag.proveedor, pag.idEncargado, pag.encargado,
                                                pag.usuarioModi, pag.fechaModi, pag.idEstado, pag.estado, pag.idEstadoImpresion, pag.estadoImpresion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class pagoRetenido
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _idProveedor As Integer
    Private _proveedor As String
    Private _idEncargado As Integer
    Private _encargado As String
    Private _idEstadoImpresion As Integer
    Private _estadoImpresion As String
#End Region
#Region "Propiedades"
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
    Public Property IdEncargado() As Integer
        Get
            Return _idEncargado
        End Get
        Set(ByVal value As Integer)
            _idEncargado = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idDocumento As Integer,
                   documento As String, consecutivo As Integer, idProveedor As Integer, proveedor As String,
                   idEncargado As Integer, encargado As String, usuarioModi As String, fechaModi As DateTime,
                   idEstado As Integer, estado As String, idEstadoImpresion As Integer, estadoImpresion As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idDocumento = idDocumento
            _documento = documento
            _consecutivo = consecutivo
            _idProveedor = idProveedor
            _proveedor = proveedor
            _idEncargado = idEncargado
            _encargado = encargado
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
            _idEstadoImpresion = idEstadoImpresion
            _estadoImpresion = estadoImpresion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
