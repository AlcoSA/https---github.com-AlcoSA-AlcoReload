Imports Datos

Public Class ClsMovitoAccionesDefinidasPp
#Region "Variables"
    Private taMovitoAccionesDefinidas As New dsAlcoProblemasProduccionTableAdapters.tpp005_movitoAccionesDefinidasTableAdapter
#End Region
#Region "Variables"
    Public Sub Insertar(usuario As String, idEncabezado As Integer, descripcion As String)
        Try
            taMovitoAccionesDefinidas.sp_tpp005_insert(usuario, idEncabezado, descripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Actualizar(descripcion As String, usuario As String, idEncabezado As Integer)
        Try
            taMovitoAccionesDefinidas.sp_tpp005_update(descripcion, usuario, idEncabezado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdEncabezado(idEncabezado As Integer) As movitoAccionDefinidaPp
        Try
            TraerxIdEncabezado = New movitoAccionDefinidaPp
            Dim ta As New dsAlcoProblemasProduccionTableAdapters.sp_tpp005_selectByIdEncabezadoTableAdapter
            Dim tx As dsAlcoProblemasProduccion.sp_tpp005_selectByIdEncabezadoDataTable = ta.GetData(idEncabezado)
            If tx.Rows.Count > 0 Then
                Dim mov As dsAlcoProblemasProduccion.sp_tpp005_selectByIdEncabezadoRow = DirectCast(tx.Rows(0), dsAlcoProblemasProduccion.sp_tpp005_selectByIdEncabezadoRow)
                TraerxIdEncabezado = New movitoAccionDefinidaPp(mov.id, mov.fechaCreacion, mov.usuarioCreacion, mov.idEncabezado,
                                                             mov.descripcion, mov.fechaModificacion, mov.usuarioModificacion)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoAccionDefinidaPp
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idEncabezado As Integer
    Private _descripcion As String
    Private _fechaModificacion As DateTime
    Private _usuarioModificacion As String
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
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property FechaModificacion() As DateTime
        Get
            Return _fechaModificacion
        End Get
        Set(ByVal value As DateTime)
            _fechaModificacion = value
        End Set
    End Property
    Public Property UsuarioModificacion() As String
        Get
            Return _usuarioModificacion
        End Get
        Set(ByVal value As String)
            _usuarioModificacion = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idEncabezado As Integer,
                   descripcion As String, fechaModificacion As DateTime, usuarioModificacion As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idEncabezado = idEncabezado
            _descripcion = descripcion
            _fechaModificacion = fechaModificacion
            _usuarioModificacion = usuarioModificacion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
