Imports Datos
Public Class ClsVigencias
#Region "Variables"
    Private taVigencias As New dsAlcoComercialTableAdapters.tc023_VigenciaTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de vigencias
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idEstado"></param>
    ''' <param name="valorDefecto"></param>
    Public Sub Ingresar(usuario As String, descripcion As String, dias As Integer, idEstado As Integer,
                        valorDefecto As Integer)
        Try
            taVigencias.sp_tc023_insert(usuario, descripcion, dias, idEstado, valorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el estado del registro
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idEstado"></param>
    ''' <param name="valorDefecto"></param>
    Public Sub Modificar(id As Integer, usuario As String, idEstado As Integer, valorDefecto As Integer)
        Try
            taVigencias.sp_tc023_update(id, usuario, idEstado, valorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de vigencias
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Vigencia)
        Try
            traerTodos = New List(Of Vigencia)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc023_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc023_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc023_selectAllRow In txAll
                traerTodos.Add(New Vigencia(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.descripcion, ti.dias,
                                            ti.usuarioModi, ti.fechaModi, ti.idEstado, ti.estado, ti.valorDefecto))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene los registros en estado activo
    ''' </summary>
    ''' <param name="idEstado"></param>
    ''' <returns></returns>
    Public Function traerxEstado(idEstado As Integer) As List(Of Vigencia)
        Try
            traerxEstado = New List(Of Vigencia)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc023_selectByEstadoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc023_selectByEstadoDataTable = taAll.GetData(idEstado)
            For Each ti As dsAlcoComercial.sp_tc023_selectByEstadoRow In txAll
                traerxEstado.Add(New Vigencia(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.descripcion, ti.dias,
                                              ti.usuarioModi, ti.fechaModi, ti.idEstado, ti.estado, ti.valorDefecto))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class Vigencia
    Inherits ClsBaseParametros
#Region "Variables"
    Private _dias As Integer
    Private _valorDefecto As Integer
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property dias() As Integer
        Get
            Return _dias
        End Get
        Set(ByVal value As Integer)
            _dias = value
        End Set
    End Property
    Public Property valorDefecto() As Integer
        Get
            Return _valorDefecto
        End Get
        Set(ByVal value As Integer)
            _valorDefecto = value
        End Set
    End Property
    Public Property descripcion() As String
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

    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, descripcion As String,
                   meses As Integer, usuarioModi As String, fechaModi As DateTime, idEstado As Integer,
                   estado As String, valorDefecto As Integer)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _descripcion = descripcion
            _dias = meses
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = Trim(estado)
            _valorDefecto = valorDefecto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
