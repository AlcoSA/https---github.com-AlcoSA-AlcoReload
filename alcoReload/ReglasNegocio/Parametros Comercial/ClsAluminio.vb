Imports Datos
Public Class ClsAluminio
#Region "Variables"
    Private taAluminio As New dsAlcoComercialTableAdapters.tc019_AluminioTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Ingresa un nuevo registro de aluminio en la base de datos
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="version"></param>
    ''' <param name="estado"></param>
    Public Sub Insertar(usuarioCreacion As String, descripcion As String, version As Integer, estado As Integer)
        Try
            taAluminio.sp_tc019_insert(usuarioCreacion, descripcion, version, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el registro de aluminio correspondiente al id indicado
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="usuarioModi"></param>
    ''' <param name="idEstado"></param>
    Public Sub Modificar(id As Integer, descripcion As String, usuarioModi As String, idEstado As Integer)
        Try
            taAluminio.sp_tc019_update(id, descripcion, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de aluminios
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of aluminio)
        Try
            TraerTodos = New List(Of aluminio)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc019_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc019_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc019_selectAllRow In txAll.Rows
                TraerTodos.Add(New aluminio(ti.id_costo_Aluminio, ti.Fecha_Creacion, ti.Usuario_Creacion, ti.Descripcion, ti.Version,
                                                ti.Usuario_Modi, ti.Fecha_Modi, ti.Id_Estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la máxima versión de los registros de aluminio
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerMaxVersion() As Integer
        Try
            Return Convert.ToInt32(taAluminio.sp_tc019_selectMaxVersion())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class aluminio
    Inherits ClsBaseParametros
#Region "Variables"
    Private _descripcion As String
    Private _version As Integer
#End Region
#Region "Propiedades"
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property version() As Integer
        Get
            Return _version
        End Get
        Set(ByVal value As Integer)
            _version = value
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

    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, descripcion As String, version As Integer,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _descripcion = Trim(descripcion)
            _version = version
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
