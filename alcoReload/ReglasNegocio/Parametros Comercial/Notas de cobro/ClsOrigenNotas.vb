Imports Datos

Public Class ClsOrigenNotas
#Region "Variables"
    Private mOrigenNota As New dsAlcoContratosTableAdapters.tc052_OrigenNotasCobroTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Ingresa un nuevo registro de origen notas a la base de datos
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idEstado"></param>
    Public Sub Insertar(usuarioCreacion As String, nombre As String, descripcion As String, idEstado As Integer)
        Try
            mOrigenNota.sp_tc052_insert(usuarioCreacion, nombre, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Actualiza el registro de origen de notas correspondiente al id
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="usuarioModi"></param>
    ''' <param name="idEstado"></param>
    Public Sub Modificar(id As Integer, nombre As String, descripcion As String, usuarioModi As String, idEstado As Integer)
        Try
            mOrigenNota.sp_tc052_update(id, nombre, descripcion, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Obtiene todos los registros de origenes de notas
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of origen)
        Try
            traerTodos = New List(Of origen)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc052_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc052_selectAllDataTable = taAll.GetData()
            For Each ogn As dsAlcoContratos.sp_tc052_selectAllRow In txAll
                traerTodos.Add(New origen(ogn.id, ogn.fechaCreacion, ogn.usuarioCreacion, ogn.nombre, ogn.descripcion,
                                          ogn.usuarioModi, ogn.fechaModi, ogn.idEstado, ogn.estado))
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
Public Class origen
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombre As String
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
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
#End Region
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, nombre As String,
                   descripcion As String, usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _nombre = nombre
            _descripcion = descripcion
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

