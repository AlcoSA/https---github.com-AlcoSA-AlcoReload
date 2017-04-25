Imports Datos

Public Class ClsEspesorTemporal
#Region "Variables"
    Private taEspesorTemporal As New dsbAlcoIngenieriaTableAdapters.ti036_espesoresTemporalTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, prefijo As String, descripcion As String,
                        idCotizacion As Integer, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taEspesorTemporal.sp_ti036_insert(usuario, prefijo, descripcion, idCotizacion, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, prefijo As String, descripcion As String, usuario As String)
        Try
            taEspesorTemporal.sp_ti036_update(id, prefijo, descripcion, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taEspesorTemporal.sp_ti036_updateEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function ExisteEspesor(idCotiza As Integer, prefijo As String) As Boolean
        Try
            If Convert.ToInt32(taEspesorTemporal.sp_ti036_selectExistByIdCotizaAndPrefijo(idCotiza, prefijo)) > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(idEspesor As Integer) As espesorTemporal
        Try
            TraerxId = New espesorTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti036_selectByIdTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti036_selectByIdDataTable = taAll.GetData(idEspesor)
            If txAll.Rows.Count > 0 Then
                Dim esp As dsbAlcoIngenieria.sp_ti036_selectByIdRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti036_selectByIdRow)
                TraerxId = New espesorTemporal(esp.id, True, esp.fechaCreacion, esp.usuarioCreacion, esp.prefijo, esp.descripcion, esp.idCotiza,
                                               esp.fechaModi, esp.usuarioModi, esp.idEstado, esp.estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdCotiza(idcotiza As Integer) As List(Of espesorTemporal)
        Try
            TraerxIdCotiza = New List(Of espesorTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti036_selectByIdCotizaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti036_selectByIdCotizaDataTable = taAll.GetData(idcotiza)
            For Each esp As dsbAlcoIngenieria.sp_ti036_selectByIdCotizaRow In txAll
                TraerxIdCotiza.Add(New espesorTemporal(esp.id, esp.fechaCreacion, esp.usuarioCreacion, esp.prefijo, esp.descripcion,
                                                       esp.idCotiza, esp.fechaModi, esp.usuarioModi, esp.idEstado, esp.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerConExistentes(idCotiza As Integer) As List(Of espesorTemporal)
        Try
            TraerConExistentes = New List(Of espesorTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti036_selectWithExistentesTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti036_selectWithExistentesDataTable = taAll.GetData(idCotiza)
            For Each esp As dsbAlcoIngenieria.sp_ti036_selectWithExistentesRow In txAll
                TraerConExistentes.Add(New espesorTemporal(Convert.ToInt32(esp.Item("Id")), Convert.ToInt32(esp.Item("Id_DB")),
                                                              Convert.ToDateTime(esp.Item("Fecha_Creacion")), Convert.ToString(esp.Item("Usuario_Creacion")),
                                                              Convert.ToString(esp.Item("Prefijo")), Convert.ToString(esp.Item("Descripcion")),
                                                              Convert.ToInt32(esp.Item("Id_Cotiza")), Convert.ToDateTime(esp.Item("Fecha_Modi")),
                                                              Convert.ToString(esp.Item("Usuario_Modi")), Convert.ToInt32(esp.Item("Id_Estado")),
                                                              Convert.ToString(esp.Item("Estado")), Convert.ToBoolean(esp.Item("Temporal"))))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerConExistentesByPrefijo(idCotiza As Integer, prefijo As String) As espesorTemporal
        Try
            TraerConExistentesByPrefijo = New espesorTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti036_selectWithExistentesByPrefijoTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti036_selectWithExistentesByPrefijoDataTable = taAll.GetData(idCotiza, prefijo)
            If txAll.Rows.Count > 0 Then
                Dim esp As dsbAlcoIngenieria.sp_ti036_selectWithExistentesByPrefijoRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti036_selectWithExistentesByPrefijoRow)
                TraerConExistentesByPrefijo = New espesorTemporal(Convert.ToInt32(esp.Item("Id")), Convert.ToBoolean(esp.Item("Temporal")), Convert.ToDateTime(esp.Item("Fecha_Creacion")),
                                                               Convert.ToString(esp.Item("Usuario_Creacion")), Convert.ToString(esp.Item("Prefijo")),
                                                               Convert.ToString(esp.Item("Descripcion")), Convert.ToInt32(esp.Item("Id_Cotiza")),
                                                               Convert.ToDateTime(esp.Item("Fecha_Modi")), Convert.ToString(esp.Item("Usuario_Modi")),
                                                               Convert.ToInt32(esp.Item("Id_Estado")), Convert.ToString(esp.Item("Estado")))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class espesorTemporal
    Inherits ClsBaseParametros
#Region "Variables"
    Private _id_Db As Integer
    Private _prefijo As String
    Private _descripcion As String
    Private _idCotiza As Integer
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
    Public Property Prefijo() As String
        Get
            Return _prefijo
        End Get
        Set(ByVal value As String)
            _prefijo = value
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
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
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
#End Region
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, prefijo As String,
                   descripcion As String, idCotiza As Integer, fechaModi As DateTime, usuarioModi As String,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _prefijo = Trim(prefijo)
            _descripcion = Trim(descripcion)
            _idCotiza = idCotiza
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.IdEstado = idEstado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, temporal As Boolean, fechaCreacion As DateTime, usuarioCreacion As String, prefijo As String,
                   descripcion As String, idCotiza As Integer, fechaModi As DateTime, usuarioModi As String,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.Temporal = temporal
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _prefijo = Trim(prefijo)
            _descripcion = Trim(descripcion)
            _idCotiza = idCotiza
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = usuarioModi
            Me.IdEstado = idEstado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idDb As Integer, fechaCreacion As DateTime, usuarioCreacion As String,
                   prefijo As String, descripcion As String, idCotiza As Integer, fechaModi As DateTime,
                   usuarioModi As String, idEstado As Integer, estado As String, temporal As Boolean)
        Try
            Me.Id = id
            _id_Db = idDb
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _prefijo = Trim(prefijo)
            _descripcion = Trim(descripcion)
            _idCotiza = idCotiza
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.IdEstado = idEstado
            Me.Estado = Trim(estado)
            _temporal = temporal
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
