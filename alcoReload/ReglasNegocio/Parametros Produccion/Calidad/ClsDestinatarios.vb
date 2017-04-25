Imports Datos

Public Class ClsDestinatarios
#Region "Variables"
    Private taDestinatarios As New dsAlcoProduccionTableAdapters.tp019_destinatariosTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idSeccion As Integer, nombre As String,
                        correo As String, idEstado As Integer)
        Try
            taDestinatarios.Insert(usuario, idSeccion, nombre, correo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(idSeccion As Integer, nombre As String, correo As String,
                         usuario As String, idEstado As Integer, id As Integer)
        Try
            taDestinatarios.sp_tp019_update(id, idSeccion, nombre, correo, usuario, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of destinatario)
        Try
            TraerTodos = New List(Of destinatario)
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp019_selectAllTableAdapter
            Dim txAll As dsAlcoProduccion.sp_tp019_selectAllDataTable = taAll.GetData()
            For Each des As dsAlcoProduccion.sp_tp019_selectAllRow In txAll
                TraerTodos.Add(New destinatario(des.id, des.fechaCreacion, des.usuarioCreacion, des.idSeccion,
                                                des.prefijoSeccion, des.seccion, des.nombre, des.correo,
                                                des.usuarioModi, des.fechaModi, des.idEstado, des.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteRegistro(idSeccion As Integer, correo As String) As Boolean
        Try
            Dim list As List(Of destinatario) = TraerTodos().Where(Function(a) a.IdSeccion = idSeccion And
                                                                       a.Correo = correo).ToList
            If list.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class destinatario
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idSeccion As Integer
    Private _prefijoSeccion As String
    Private _seccion As String
    Private _nombre As String
    Private _correo As String
#End Region
#Region "Propiedades"
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
    Public Property Seccion() As String
        Get
            Return _seccion
        End Get
        Set(ByVal value As String)
            _seccion = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property Correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
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
                   prefijoSeccion As String, seccion As String, nombre As String, correo As String,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idSeccion = idSeccion
            _prefijoSeccion = prefijoSeccion
            _seccion = seccion
            _nombre = nombre
            _correo = correo
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
