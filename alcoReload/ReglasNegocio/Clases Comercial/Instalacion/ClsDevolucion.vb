Imports Datos

Public Class ClsDevolucion
#Region "Variables"
    Private taDevolucion As New dsAlcoComercial2TableAdapters.tc106_devolucionTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, idCuentaCobro As Integer, idDocumento As Integer,
                             consecutivo As Integer, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taDevolucion.sp_tc106_insert(usuario, idCuentaCobro, idDocumento, consecutivo, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer, usuario As String)
        Try
            taDevolucion.sp_tc106_updateEstado(id, idEstado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of devolucion)
        Try
            TraerTodos = New List(Of devolucion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc106_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc106_selectAllDataTable = taAll.GetData()
            For Each dev As dsAlcoComercial2.sp_tc106_selectAllRow In txAll
                TraerTodos.Add(New devolucion(dev.id, dev.fechaCreacion, dev.usuarioCreacion, dev.idCuentaCobro, dev.idDocumento,
                                              dev.documento, dev.consecutivo, dev.idProveedor, dev.proveedor, dev.idEncargado,
                                              dev.encargado, dev.codigoObra, dev.obra, dev.vendedor, dev.usuarioModi, dev.fechaModi,
                                              dev.idEstado, dev.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class devolucion
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idCuentaCobro As Integer
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _idProveedor As Integer
    Private _proveedor As String
    Private _idEncargado As Integer
    Private _encargado As String
    Private _codigoObra As String
    Private _obra As String
    Private _vendedor As String
#End Region
#Region "Propiedades"
    Public Property IdCuentaCobro() As Integer
        Get
            Return _idCuentaCobro
        End Get
        Set(ByVal value As Integer)
            _idCuentaCobro = value
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
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCuentaCobro As Integer,
                   idDocumento As Integer, documento As String, consecutivo As Integer, idProveedor As Integer,
                   proveedor As String, idEncargado As Integer, encargado As String, codigoObra As String, obra As String,
                   vendedor As String, usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idCuentaCobro = idCuentaCobro
            _idDocumento = idDocumento
            _documento = documento
            _consecutivo = consecutivo
            _idProveedor = idProveedor
            _proveedor = proveedor
            _idEncargado = idEncargado
            _encargado = encargado
            _codigoObra = codigoObra
            _obra = obra
            _vendedor = vendedor
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