Imports Datos

Public Class ClsMotivosPorSeccion
#Region "Variables"
    Private taMotivosxSeccion As New dsAlcoProduccionTableAdapters.tp016_MotivosporSeccionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idSeccion As Integer, idConcepto As Integer,
                        codigoMotivo As String, idEstado As Integer)
        Try
            taMotivosxSeccion.Insert(usuario, idSeccion, idConcepto, codigoMotivo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, idEstado As Integer)
        Try
            taMotivosxSeccion.Update(idEstado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of motivoPorSeccion)
        Try
            TraerTodos = New List(Of motivoPorSeccion)
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp016_selectAllTableAdapter
            Dim txAll As dsAlcoProduccion.sp_tp016_selectAllDataTable = taAll.GetData()
            For Each mot As dsAlcoProduccion.sp_tp016_selectAllRow In txAll
                TraerTodos.Add(New motivoPorSeccion(mot.id, mot.fechaCreacion, mot.usuarioCreacion, mot.idSeccion,
                                                    mot.prefijoSeccion, mot.seccion, mot.idConcepto, mot.codigoMotivo,
                                                    mot.motivo, mot.idEstado, mot.estado))
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
Public Class motivoPorSeccion
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idSeccion As Integer
    Private _prefijoSeccion As String
    Private _descripcionSeccion As String
    Private _idConcepto As Integer
    Private _codigoMotivo As String
    Private _descripcionMotivo As String
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
    Public Property IdSeccion() As Integer
        Get
            Return _idSeccion
        End Get
        Set(ByVal value As Integer)
            _idSeccion = value
        End Set
    End Property
    Public Property PrefijoSeccion() As String
        Get
            Return _prefijoSeccion
        End Get
        Set(ByVal value As String)
            _prefijoSeccion = value
        End Set
    End Property
    Public Property DescripcionSeccion() As String
        Get
            Return _descripcionSeccion
        End Get
        Set(ByVal value As String)
            _descripcionSeccion = value
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
    Public Property DescripcionMotivo() As String
        Get
            Return _descripcionMotivo
        End Get
        Set(ByVal value As String)
            _descripcionMotivo = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idSeccion As Integer,
                   prefSeccion As String, descSeccion As String, idConcepto As Integer, codMotivo As String,
                   motivo As String, idEstado As Integer, estado As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idSeccion = idSeccion
            _prefijoSeccion = prefSeccion
            _descripcionSeccion = descSeccion
            _idConcepto = idConcepto
            _codigoMotivo = codMotivo
            _descripcionMotivo = motivo
            _idEstado = idEstado
            _estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
