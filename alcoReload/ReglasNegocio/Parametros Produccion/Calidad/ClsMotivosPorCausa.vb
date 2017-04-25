Imports Datos

Public Class ClsMotivosPorCausa
#Region "Variables"
    Private taMotivosporCausa As New dsAlcoProduccionTableAdapters.tp018_MotivosporCausaTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idCausa As Integer, idconcepto As Integer,
                        codigoMotivo As String, idEstado As Integer)
        Try
            taMotivosporCausa.Insert(usuario, idCausa, idconcepto, codigoMotivo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, idEstado As Integer)
        Try
            taMotivosporCausa.Update(idEstado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of motivoporcausa)
        Try
            TraerTodos = New List(Of motivoporcausa)
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp018_selectAllTableAdapter
            Dim txAll As dsAlcoProduccion.sp_tp018_selectAllDataTable = taAll.GetData()
            For Each mot As dsAlcoProduccion.sp_tp018_selectAllRow In txAll
                TraerTodos.Add(New motivoporcausa(mot.id, mot.fechaCreacion, mot.usuarioCreacion, mot.idCausa,
                                                  mot.nombreCausa, mot.causa, mot.idConcepto, mot.codigoMotivo,
                                                  mot.motivo, mot.idEstado, mot.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class motivoporcausa
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idCausa As Integer
    Private _nombreCausa As String
    Private _causa As String
    Private _idConcepto As Integer
    Private _codigoMotivo As String
    Private _motivo As String
    Private _idEstado As Integer
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
    Private _estado As String
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
    Public Property IdCausa() As Integer
        Get
            Return _idCausa
        End Get
        Set(ByVal value As Integer)
            _idCausa = value
        End Set
    End Property
    Public Property NombreCausa() As String
        Get
            Return _nombreCausa
        End Get
        Set(ByVal value As String)
            _nombreCausa = value
        End Set
    End Property
    Public Property Causa() As String
        Get
            Return _causa
        End Get
        Set(ByVal value As String)
            _causa = value
        End Set
    End Property
    Public Property IdConcepto() As Integer
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As Integer)
            _idConcepto = value
        End Set
    End Property
    Public Property CodigoMotivo() As String
        Get
            Return _codigoMotivo
        End Get
        Set(ByVal value As String)
            _codigoMotivo = value
        End Set
    End Property
    Public Property Motivo() As String
        Get
            Return _motivo
        End Get
        Set(ByVal value As String)
            _motivo = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCausa As Integer,
                   nombreCausa As String, causa As String, idConcepto As Integer, codigoMotivo As String,
                   motivo As String, idEstado As Integer, estado As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idCausa = idCausa
            _nombreCausa = nombreCausa
            _causa = causa
            _idConcepto = idConcepto
            _codigoMotivo = codigoMotivo
            _motivo = motivo
            _idEstado = idEstado
            _estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
