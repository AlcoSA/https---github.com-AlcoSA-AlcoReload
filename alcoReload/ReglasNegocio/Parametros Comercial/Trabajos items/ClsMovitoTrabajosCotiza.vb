Imports Datos

Public Class ClsMovitoTrabajosCotiza
#Region "Variables"
    Private taMovitoTrabajoCotiza As New dsAlcoComercial2TableAdapters.tc092_movitoTrabajoItemTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idHijoCotiza As Integer, idTrabajo As Integer, cantidad As Integer, idEstado As Integer)
        Try
            taMovitoTrabajoCotiza.sp_tc092_insert(usuario, idHijoCotiza, idTrabajo, cantidad, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, cantidad As Integer)
        Try
            taMovitoTrabajoCotiza.sp_tc092_update(id, cantidad)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taMovitoTrabajoCotiza.sp_tc092_updsteEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdHijo(idHijoCotiza As Integer) As List(Of movitoTrabajoCotiza)
        Try
            TraerxIdHijo = New List(Of movitoTrabajoCotiza)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc092_selectByIdHijoTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc092_selectByIdHijoDataTable = taAll.GetData(idHijoCotiza)
            For Each mov As dsAlcoComercial2.sp_tc092_selectByIdHijoRow In txAll.Rows
                TraerxIdHijo.Add(New movitoTrabajoCotiza(mov.id, mov.fechaCreacion, mov.usuarioCreacion, mov.idHijoCotiza, mov.idTrabajo,
                                                         mov.prefijo, mov.descripcion, mov.unidadMedida, mov.cantidad, mov.idEstado, mov.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoTrabajoCotiza
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idHijoCotiza As Integer
    Private _idTrabajo As Integer
    Private _prefijo As String
    Private _descripcion As String
    Private _unidadMedida As String
    Private _cantidad As Integer
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
    Public Property IdHijoCotiza() As Integer
        Get
            Return _idHijoCotiza
        End Get
        Set(ByVal value As Integer)
            _idHijoCotiza = value
        End Set
    End Property
    Public Property IdTrabajo() As Integer
        Get
            Return _idTrabajo
        End Get
        Set(ByVal value As Integer)
            _idTrabajo = value
        End Set
    End Property
    Public Property Prefijo() As String
        Get
            Return _prefijo
        End Get
        Set(ByVal value As String)
            _prefijo = value
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
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idHijoCotiza As Integer,
                   idTrabajo As Integer, prefijo As String, descripcion As String, unidadMedida As String,
                   cantidad As Integer, idEstado As Integer, estado As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idHijoCotiza = idHijoCotiza
            _idTrabajo = idTrabajo
            _prefijo = prefijo
            _descripcion = descripcion
            _unidadMedida = unidadMedida
            _cantidad = cantidad
            _idEstado = idEstado
            _estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
