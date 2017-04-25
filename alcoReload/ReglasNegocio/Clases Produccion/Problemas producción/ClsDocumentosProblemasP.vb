Imports Datos

Public Class ClsDocumentosProblemasP
#Region "Variables"
    Private taDocumentos As New dsAlcoProblemasProduccionTableAdapters.tpp006_documentosPpTableAdapter
#End Region
#Region "Procedimientos"
    Public Function InsertarDocumentos(usuario As String, idEncabezado As Integer, tipoMovito As Integer, nombreDocumento As String,
                                  ruta As String, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taDocumentos.sp_tpp006_insert(usuario, idEncabezado, tipoMovito, nombreDocumento, ruta, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstado(IdDocumento As Integer, idEstado As Integer)
        Try
            taDocumentos.sp_tpp006_updateEstado(IdDocumento, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarRuta(idDocumento As Integer, ruta As String)
        Try
            taDocumentos.sp_tpp006_updateRuta(ruta, idDocumento)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerAdjuntos(idEncabezado As Integer, tipoMovito As Integer) As List(Of documentoPP)
        Try
            TraerAdjuntos = New List(Of documentoPP)
            Dim ta As New dsAlcoProblemasProduccionTableAdapters.sp_tpp006_selectByEncabezadoAndTipoTableAdapter()
            Dim tx As dsAlcoProblemasProduccion.sp_tpp006_selectByEncabezadoAndTipoDataTable = ta.GetData(idEncabezado, tipoMovito)
            For Each adj As dsAlcoProblemasProduccion.sp_tpp006_selectByEncabezadoAndTipoRow In tx.Rows
                TraerAdjuntos.Add(New documentoPP(adj.id, adj.fechaCreacion, adj.usuarioCreacion, adj.idEncabezado, adj.tipoMovito,
                                                   adj.nombreArchivo, adj.rutaDocumento, adj.idEstado, adj.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class documentoPP
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idEncabezado As Integer
    Private _tipoMovito As Integer
    Private _nombreArchivo As String
    Private _rutaDocumento As String
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
    Public Property IdEncabezado() As Integer
        Get
            Return _idEncabezado
        End Get
        Set(ByVal value As Integer)
            _idEncabezado = value
        End Set
    End Property
    Public Property TipoMovito() As Integer
        Get
            Return _tipoMovito
        End Get
        Set(ByVal value As Integer)
            _tipoMovito = value
        End Set
    End Property
    Public Property NombreArchivo() As String
        Get
            Return _nombreArchivo
        End Get
        Set(ByVal value As String)
            _nombreArchivo = value
        End Set
    End Property
    Public Property RutaDocumento() As String
        Get
            Return _rutaDocumento
        End Get
        Set(ByVal value As String)
            _rutaDocumento = value
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
#Region "Procedimientos"
    Public Sub New()
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idEncabezado As Integer, tipoMovito As Integer,
                   nombreArchivo As String, rutaDocumento As String, idEstado As Integer, estado As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idEncabezado = idEncabezado
            _tipoMovito = tipoMovito
            _nombreArchivo = nombreArchivo
            _rutaDocumento = rutaDocumento
            _idEstado = idEstado
            _estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class