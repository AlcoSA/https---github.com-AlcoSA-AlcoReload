Imports Datos
Public Class ClsNivelesFamilias
#Region "Variables"
    Private taniveles As New dsAlcoComercialTableAdapters.tc003_nivelesTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Ingresa un nuevo registro de niveles familia en la base de datos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="versioncosto"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, descripcion As String, versioncosto As Integer, estado As Integer)
        Try
            taniveles.sp_tc003_insert(descripcion, versioncosto, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Modifica la información del registro indicado
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="versioncosto"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, descripcion As String, versioncosto As Integer, estado As Integer)
        Try
            taniveles.sp_tc003_update(descripcion, versioncosto, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Obtiene todos los registro de niveles
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of NivelFamilia)
        Try
            TraerTodos = New List(Of NivelFamilia)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc003_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc003_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc003_selectAllRow In txAll.Rows
                TraerTodos.Add(New NivelFamilia(ti.idNivel, ti.usuarioCreacion, ti.fechaCreacion, ti.descripcion,
                                                    ti.versionCosto, ti.usuarioModi, ti.fechaModi, ti.idEstado, ti.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene la última versión de los niveles
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerMaxVersion() As Integer
        Try
            Return Convert.ToInt32(taniveles.sp_tc003_selectMaxVersionNiveles())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene los niveles que se encuentren activos
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of NivelFamilia)
        TraerxEstado = New List(Of NivelFamilia)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc003_selectByestadoTableAdapter
            For Each ti As dsAlcoComercial.sp_tc003_selectByestadoRow In taAll.GetData(estado).Rows
                TraerxEstado.Add(New NivelFamilia(ti.idNivel, ti.usuarioCreacion, ti.fechaCreacion,
                                           ti.descripcion, ti.versionCosto, ti.usuarioModi,
                                          ti.fechaModi, ti.estado, ""))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxDescripcion(descripcion As String) As List(Of NivelFamilia)
        TraerxDescripcion = New List(Of NivelFamilia)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc003_selectByDescripcionTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc003_selectByDescripcionDataTable = taAll.GetData(descripcion)
            For Each ti As dsAlcoComercial.sp_tc003_selectByDescripcionRow In txAll.Rows
                TraerxDescripcion.Add(New NivelFamilia(ti.idNivel, ti.usuarioCreacion, ti.fechaCreacion,
                                           ti.descripcion, ti.versionCosto, ti.usuarioModi,
                                          ti.fechaModi, ti.estado, ""))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxId(id As Integer) As NivelFamilia
        TraerxId = New NivelFamilia()
        Try
            Dim taxId As New dsAlcoComercialTableAdapters.sp_tc003_selectByIdTableAdapter
            Dim txid As dsAlcoComercial.sp_tc003_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim ti As dsAlcoComercial.sp_tc003_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc003_selectByIdRow)
                TraerxId = New NivelFamilia(ti.idNivel, ti.usuarioCreacion, ti.fechaCreacion,
                                           ti.descripcion, ti.versionCosto, ti.usuarioModi,
                                          ti.fechaModi, ti.estado, "")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class
Public Class NivelFamilia
    Inherits ClsBaseParametros
#Region "Variables"
    Private _descripcion As String = String.Empty
    Private _versioncosto As Integer = 0
#End Region
#Region "Propiedades"
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property VersionCosto As Integer
        Get
            Return _versioncosto
        End Get
        Set(value As Integer)
            _versioncosto = value
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
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date,
                   descripcion As String, versioncosto As Integer, usuariomodificacion As String,
                       fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _descripcion = Trim(descripcion)
            _versioncosto = versioncosto
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class