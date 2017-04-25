Imports Datos

Public Class ClsDuracionDuplicacion
#Region "Variables"
    Private taDuracionCotiza As New dsAlcoCotizacionesTableAdapters.tc112_duracionDuplicaCotizaTableAdapter
    Private taFinDuplicacion As New dsAlcoCotizacionesTableAdapters.tc113_finDuplicacionTableAdapter
#End Region
#Region "Procedimientos DURACIÓN DUPLICACION COTIZA"
    Public Sub Insertar(usuario As String, dias As Integer, idEstado As Integer)
        Try
            taDuracionCotiza.sp_tc112_insert(usuario, dias, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, vigente As Boolean, idEstado As Integer, usuario As String)
        Try
            taDuracionCotiza.sp_tc112_update(id, vigente, idEstado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of duracionDuplicado)
        Try
            TraerTodos = New List(Of duracionDuplicado)
            Dim ta As New dsAlcoCotizacionesTableAdapters.sp_tc112_selectAllTableAdapter
            Dim tx As dsAlcoCotizaciones.sp_tc112_selectAllDataTable = ta.GetData()
            For Each r As dsAlcoCotizaciones.sp_tc112_selectAllRow In tx.Rows
                TraerTodos.Add(New duracionDuplicado(r.id, r.fechaCreacion, r.usuarioCreacion, r.dias, r.vigente,
                                                     r.usuarioModi, r.fechaModi, r.idEstado, r.estado))
            Next
            If tx.Rows.Count > 0 Then
                dt = tx.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
#Region "Procedimientos FIN DUPLICACION COTIZA"
    Public Sub InsertarFinDuplicacion(idContrato As Integer, fechaContrato As DateTime, usuario As String)
        Try
            taFinDuplicacion.sp_tc113_insert(idContrato, fechaContrato, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdCotiza(idCotizacion As Integer) As finDuplicacion
        Try
            Dim ta As New dsAlcoCotizacionesTableAdapters.sp_tc113_selectByIdCotizaTableAdapter
            Dim tx As dsAlcoCotizaciones.sp_tc113_selectByIdCotizaDataTable = ta.GetData(idCotizacion)
            If tx.Rows.Count > 0 Then
                Dim row As dsAlcoCotizaciones.sp_tc113_selectByIdCotizaRow = DirectCast(tx.Rows(0), dsAlcoCotizaciones.sp_tc113_selectByIdCotizaRow)
                TraerxIdCotiza = New finDuplicacion(row.id, row.fechaCreacion, row.usuarioCreacion, row.idCotiza, row.diasVigencia, row.fechaFinDuplicacion)
            Else
                TraerxIdCotiza = Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class duracionDuplicado
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _dias As Integer
    Private _vigente As Boolean
    Private _usuarioModi As String
    Private _fechaModi As DateTime
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
    Public Property Dias() As Integer
        Get
            Return _dias
        End Get
        Set(ByVal value As Integer)
            _dias = value
        End Set
    End Property
    Public Property Vigente() As Boolean
        Get
            Return _vigente
        End Get
        Set(ByVal value As Boolean)
            _vigente = value
        End Set
    End Property
    Public Property UsuarioModi() As String
        Get
            Return _usuarioModi
        End Get
        Set(ByVal value As String)
            _usuarioModi = value
        End Set
    End Property
    Public Property FechaModi() As DateTime
        Get
            Return _fechaModi
        End Get
        Set(ByVal value As DateTime)
            _fechaModi = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, dias As Integer, vigente As Boolean,
                   usuarioModificacion As String, fechaModificacion As DateTime, idEstado As Integer, estado As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _dias = dias
            _vigente = vigente
            _usuarioModi = usuarioModificacion
            _fechaModi = fechaModificacion
            _idEstado = idEstado
            _estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class finDuplicacion
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idCotiza As Integer
    Private _diasVigencia As Integer
    Private _fechaFinDuplicacion As DateTime
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
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property DiasVigencia() As Integer
        Get
            Return _diasVigencia
        End Get
        Set(ByVal value As Integer)
            _diasVigencia = value
        End Set
    End Property
    Public Property FechaFinDuplicacion() As DateTime
        Get
            Return _fechaFinDuplicacion
        End Get
        Set(ByVal value As DateTime)
            _fechaFinDuplicacion = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCotiza As Integer,
                   diasVigencia As Integer, fechaDuplicacion As DateTime)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idCotiza = idCotiza
            _diasVigencia = diasVigencia
            _fechaFinDuplicacion = fechaDuplicacion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class