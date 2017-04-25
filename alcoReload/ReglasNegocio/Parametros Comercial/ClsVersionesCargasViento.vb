Imports Datos
Public Class ClsVersionesCargasViento
#Region "Variables"
    Private taversiones As New dsAlcoComercialTableAdapters.tc037_versionescargasVientoTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="version"></param>
    ''' <param name="estado"></param>
    Public Sub Insertar(usuarioCreacion As String, version As String, descripcion As String, estado As Integer)
        Try
            taversiones.sp_tc037_insert(usuarioCreacion, version, descripcion, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="version"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idEstado"></param>
    Public Sub Modificar(id As Integer, version As String, descripcion As String, usuario As String, idEstado As Integer)
        Try
            taversiones.sp_tc037_update(id, usuario, version, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de aluminios
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of VersionCargasViento)
        Try
            TraerTodos = New List(Of VersionCargasViento)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc037_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc037_selectAllDataTable = taAll.GetData()
            For Each tv As dsAlcoComercial.sp_tc037_selectAllRow In txAll.Rows
                TraerTodos.Add(New VersionCargasViento(tv.Id, tv.Fecha_Creacion, tv.Usuario_Creacion, tv.Version, tv.Descripcion,
                                                tv.Usuario_Modificacion, tv.Fecha_Modificacion, tv.fc037_estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todos los registros de aluminios
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerxEstado(idestado As Integer) As List(Of VersionCargasViento)
        Try
            TraerxEstado = New List(Of VersionCargasViento)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc037_selectbyEstadoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc037_selectbyEstadoDataTable = taAll.GetData(idestado)
            If txAll.Rows.Count > 0 Then
                For Each tv As dsAlcoComercial.sp_tc037_selectbyEstadoRow In txAll.Rows
                    TraerxEstado.Add(New VersionCargasViento(tv.fc037_rowid, tv.fc037_fechacreacion, tv.fc037_usuariocreacion, tv.fc037_version, tv.fc037_descripcion,
                                                tv.fc037_usuariomodificacion, tv.fc037_fechamodificacion, tv.fc037_estado))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class VersionCargasViento
    Inherits ClsBaseParametros
#Region "Variables"
    Private _version As String
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
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

    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, version As String, descripcion As String,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _descripcion = Trim(descripcion)
            _version = Trim(version)
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class