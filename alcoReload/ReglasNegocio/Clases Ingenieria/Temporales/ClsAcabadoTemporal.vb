Imports Datos

Public Class ClsAcabadoTemporal
#Region "Variables"
    Private taAcabadoTemp As New dsbAlcoIngenieriaTableAdapters.ti037_acabadosTemporalTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, prefijo As String, nombre As String, idFamiliaMaterial As Integer,
                        idCotiza As Integer, costo As Decimal, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taAcabadoTemp.sp_ti037_insert(usuario, nombre, prefijo, idFamiliaMaterial, idCotiza, costo, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, nombre As String, prefijo As String, costo As Decimal, usuario As String)
        Try
            taAcabadoTemp.sp_ti037_update(id, nombre, prefijo, costo, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taAcabadoTemp.sp_ti037_updateEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function ExisteAcabado(idCotiza As Integer, prefijo As String, idFamiliaMaterial As Integer) As Boolean
        Try
            If Convert.ToInt32(taAcabadoTemp.sp_ti037_selectExist(idCotiza, prefijo, idFamiliaMaterial)) > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(idColor As Integer) As acabadoTemporal
        Try
            TraerxId = New acabadoTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti037_selectByIdTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti037_selectByIdDataTable = taAll.GetData(idColor)
            If txAll.Rows.Count > 0 Then
                Dim acb As dsbAlcoIngenieria.sp_ti037_selectByIdRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti037_selectByIdRow)
                TraerxId = New acabadoTemporal(acb.id, True, acb.fechaCreacion, acb.usuarioCreacion, acb.nombre, acb.prefijo, 0, acb.idFamiliaMaterial,
                                               acb.familiaMaterial, acb.idCotiza, acb.costo, acb.fechaModi, acb.usuarioModi, acb.idEstado, acb.estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdCotiza(idcotiza As Integer) As List(Of acabadoTemporal)
        Try
            TraerxIdCotiza = New List(Of acabadoTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti037_selectByIdCotizaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti037_selectByIdCotizaDataTable = taAll.GetData(idcotiza)
            For Each acb As dsbAlcoIngenieria.sp_ti037_selectByIdCotizaRow In txAll
                TraerxIdCotiza.Add(New acabadoTemporal(acb.id, acb.fechaCreacion, acb.usuarioCreacion, acb.nombre, acb.prefijo,
                                                       acb.idFamiliaMaterial, acb.familiaMaterial, acb.idCotiza, acb.costo,
                                                       acb.fechaModi, acb.usuarioModi, acb.idEstado, acb.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerconExistentes(idCotiza As Integer, idFamiliaMaterial As Integer) As List(Of acabadoTemporal)
        Try
            TraerconExistentes = New List(Of acabadoTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti037_selectWithExistentesTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti037_selectWithExistentesDataTable = taAll.GetData(idCotiza, idFamiliaMaterial)
            For Each acb As dsbAlcoIngenieria.sp_ti037_selectWithExistentesRow In txAll
                TraerconExistentes.Add(New acabadoTemporal(Convert.ToInt32(acb.Item("Id")), Convert.ToInt32(acb.Item("Id_DB")),
                                                              Convert.ToDateTime(acb.Item("Fecha_Creacion")), Convert.ToString(acb.Item("Usuario_Creacion")),
                                                              Convert.ToString(acb.Item("Nombre")), Convert.ToString(acb.Item("Prefijo")),
                                                              Convert.ToInt32(acb.Item("Id_Cotiza")), Convert.ToInt32(acb.Item("Version_Costo")),
                                                              Convert.ToDecimal(acb.Item("Costo")), Convert.ToInt32(acb.Item("Id_Familia_Material")),
                                                              Convert.ToString(acb.Item("Familia_Material")), Convert.ToDateTime(acb.Item("Fecha_Modi")),
                                                              Convert.ToString(acb.Item("Usuario_Modi")), Convert.ToInt32(acb.Item("Id_Estado")),
                                                              Convert.ToString(acb.Item("Estado")), Convert.ToBoolean(acb.Item("Temporal"))))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerConExistentesByPrefijo(idCotiza As Integer, idFamiliaMaterial As Integer, prefijo As String) As acabadoTemporal
        Try
            TraerConExistentesByPrefijo = New acabadoTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti037_selectWithExistentesByPrefijoTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti037_selectWithExistentesByPrefijoDataTable = taAll.GetData(idCotiza, idFamiliaMaterial, prefijo)
            Dim acb As dsbAlcoIngenieria.sp_ti037_selectWithExistentesByPrefijoRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti037_selectWithExistentesByPrefijoRow)
            TraerConExistentesByPrefijo = New acabadoTemporal(Convert.ToInt32(acb.Item("Id")), Convert.ToBoolean(acb.Item("Temporal")), Convert.ToDateTime(acb.Item("Fecha_Creacion")),
                                                           Convert.ToString(acb.Item("Usuario_Creacion")), Convert.ToString(acb.Item("Nombre")), Convert.ToString(acb.Item("Prefijo")),
                                                           Convert.ToInt32(acb.Item("Version_Costo")), Convert.ToInt32(acb.Item("Id_Familia_Material")), Convert.ToString(acb.Item("Familia_Material")),
                                                           Convert.ToInt32(acb.Item("Id_Cotiza")), Convert.ToDecimal(acb.Item("Costo")), Convert.ToDateTime(acb.Item("Fecha_Modi")),
                                                           Convert.ToString(acb.Item("Usuario_Modi")), Convert.ToInt32(acb.Item("Id_Estado")), Convert.ToString(acb.Item("Estado")))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class acabadoTemporal
    Inherits ClsBaseParametros
#Region "Variables"
    Private _id_Db As Integer
    Private _nombre As String
    Private _prefijo As String
    Private _idCotiza As Integer
    Private _versionCosto As Integer
    Private _costo As Decimal
    Private _idFamiliaMaterial As Integer
    Private _familiaMaterial As String
    Private _temporal As Boolean
#End Region
#Region "Propiedades"
    Public Property IdDb() As Integer
        Get
            Return _id_Db
        End Get
        Set(ByVal value As Integer)
            _id_Db = value
        End Set
    End Property
    Public Property Temporal() As Boolean
        Get
            Return _temporal
        End Get
        Set(ByVal value As Boolean)
            _temporal = value
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
    Public Property Prefijo() As String
        Get
            Return _prefijo
        End Get
        Set(ByVal value As String)
            _prefijo = value
        End Set
    End Property
    Public Property VersionCosto() As Integer
        Get
            Return _versionCosto
        End Get
        Set(ByVal value As Integer)
            _versionCosto = value
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
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
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
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, nombre As String,
                   prefijo As String, idFamiliaMaterial As Integer, familiaMaterial As String, idCotiza As Integer,
                   costo As Decimal, fechaModi As DateTime, usuarioModi As String, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            _temporal = Temporal
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _nombre = Trim(nombre)
            _prefijo = Trim(prefijo)
            _versionCosto = VersionCosto
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = familiaMaterial
            _idCotiza = idCotiza
            _costo = costo
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = usuarioModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, temporal As Boolean, fechaCreacion As DateTime, usuarioCreacion As String, nombre As String,
                   prefijo As String, versionCosto As Integer, idFamiliaMaterial As Integer, familiaMaterial As String, idCotiza As Integer,
                   costo As Decimal, fechaModi As DateTime, usuarioModi As String, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            _temporal = temporal
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _nombre = Trim(nombre)
            _prefijo = Trim(prefijo)
            _versionCosto = versionCosto
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = Trim(familiaMaterial)
            _idCotiza = idCotiza
            _costo = costo
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.IdEstado = idEstado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idDb As Integer, fechaCreacion As DateTime, usuarioCreacion As String, nombre As String,
                   prefijo As String, idCotiza As Integer, versionCosto As Integer, costo As Decimal, idFamiliaMaterial As Integer,
                   familiaMaterial As String, fechaModi As DateTime, usuarioModi As String, idEstado As Integer, estado As String,
                   temporal As Boolean)
        Try
            Me.Id = id
            _id_Db = idDb
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _nombre = Trim(nombre)
            _prefijo = Trim(prefijo)
            _idCotiza = idCotiza
            _versionCosto = versionCosto
            _costo = costo
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = Trim(familiaMaterial)
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = usuarioModi
            Me.IdEstado = idEstado
            Me.Estado = Trim(estado)
            _temporal = temporal
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
