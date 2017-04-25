Imports Datos

Public Class ClsCostoTrabajoItem
#Region "Variables"
    Private taCostoTrabajo As New dsAlcoComercial2TableAdapters.tc091_costoTrabajoItemTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idTrabajo As Integer, costo As Decimal, version As Integer)
        Try
            taCostoTrabajo.sp_tc091_insert(usuario, idTrabajo, costo, version)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerMaxVersion() As Integer
        Try
            Return Convert.ToInt32(taCostoTrabajo.sp_tc091_selectMaxVersion())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxVersion(version As Integer) As List(Of costoTrabajoItem)
        Try
            TraerxVersion = New List(Of costoTrabajoItem)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc091_selectByVersionTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc091_selectByVersionDataTable = taAll.GetData(version)
            For Each cos As dsAlcoComercial2.sp_tc091_selectByVersionRow In txAll.Rows
                TraerxVersion.Add(New costoTrabajoItem(cos.id, cos.fechaCreacion, cos.usuarioCreacion, cos.idTrabajo,
                                                       cos.descripcion, cos.idFamiliaMaterial, cos.familiaMaterial,
                                                       cos.version, cos.costo))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerEspecifico(version As Integer, idTrabajo As Integer) As costoTrabajoItem
        Try
            Dim list As List(Of costoTrabajoItem) = TraerxVersion(version)
            TraerEspecifico = list.FirstOrDefault(Function(a) a.IdTrabajo = idTrabajo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class costoTrabajoItem
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idTrabajo As Integer
    Private _descripcion As String
    Private _idFamiliaMaterial As Integer
    Private _familiaMaterial As String
    Private _version As Integer
    Private _costo As Decimal
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
    Public Property IdTrabajo() As Integer
        Get
            Return _idTrabajo
        End Get
        Set(ByVal value As Integer)
            _idTrabajo = value
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
    Public Property IdFamiliaMaterial() As Integer
        Get
            Return _idFamiliaMaterial
        End Get
        Set(ByVal value As Integer)
            _idFamiliaMaterial = value
        End Set
    End Property
    Public Property FamiliaMaterial() As String
        Get
            Return _familiaMaterial
        End Get
        Set(ByVal value As String)
            _familiaMaterial = value
        End Set
    End Property
    Public Property Version() As Integer
        Get
            Return _version
        End Get
        Set(ByVal value As Integer)
            _version = value
        End Set
    End Property
    Public Property Costo() As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String,
                   idTrabajo As Integer, descripcion As String, idFamilia As Integer,
                   familia As String, version As Integer, costo As Decimal)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idTrabajo = idTrabajo
            _descripcion = descripcion
            _idFamiliaMaterial = idFamilia
            _familiaMaterial = familia
            _version = version
            _costo = costo
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
