Imports Datos

Public Class ClsTiposNotas
#Region "Variables"
    Private taTiposNotas As New dsAlcoContratosTableAdapters.tc051_TiposNotasCobroTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de tipos de notas en base de datos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idEstado"></param>
    Public Sub Insertar(usuario As String, nombre As String, descripcion As String, idEstado As Integer)
        Try
            taTiposNotas.sp_tc051_insert(usuario, nombre, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Actualiza el registro correspondiente al id indicado
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idEstado"></param>
    Public Sub Modificar(Id As Integer, nombre As String, descripcion As String,
                         usuario As String, idEstado As Integer)
        Try
            taTiposNotas.sp_tc051_update(Id, nombre, descripcion, usuario, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Obtiene todos los registros de tipos notas
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tipoNota)
        Try
            TraerTodos = New List(Of tipoNota)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc051_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc051_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoContratos.sp_tc051_selectAllRow In txAll
                TraerTodos.Add(New tipoNota(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.nombre, ti.descripcion,
                                            ti.usuarioModi, ti.fechaModi, ti.idEstado, ti.estado))
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
Public Class tipoNota
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
                   descripcion As String, usuarioModi As String, fechaModi As DateTime,
                   idEstado As Integer, estado As String)
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
