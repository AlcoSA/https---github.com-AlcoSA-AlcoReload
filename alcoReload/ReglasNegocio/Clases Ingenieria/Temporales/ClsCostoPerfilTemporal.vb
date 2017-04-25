Imports Datos

Public Class ClsCostoPerfilTemporal
#Region "Variables"
    Private taCostoPerfil As New dsbAlcoIngenieriaTableAdapters.ti039_costoPerfilTemporalTableAdapter
#End Region

#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idCotiza As Integer, perfilTemporal As Boolean, idArticulo As Integer,
                        acabadoTemporal As Boolean, idAcabado As Integer, idCostoAcabado As Integer,
                        idCostoNivel As Integer, idCostoAluminio As Integer, costo As Decimal, idEstado As Integer)
        Try
            taCostoPerfil.sp_ti039_insert(usuario, idCotiza, perfilTemporal, idArticulo, acabadoTemporal, idAcabado,
                                          idCostoAcabado, idCostoNivel, idCostoAluminio, costo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, idCostoAcabado As Integer, idCostoNivel As Integer, idCostoAluminio As Integer,
                         costo As Decimal, idEstado As Integer)
        Try
            taCostoPerfil.sp_ti039_update(id, idCostoAcabado, idCostoNivel, idCostoAluminio, costo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taCostoPerfil.sp_ti039_updateEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerCostoEspecifico(idCotiza As Integer, temp_perfil As Boolean, idPerfil As Integer,
                                temp_acabado As Boolean, idAcabado As Integer) As costoPerfilTemporal
        Try
            TraerCostoEspecifico = New costoPerfilTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti039_selectByItemsTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti039_selectByItemsDataTable = taAll.GetData(idCotiza, temp_perfil, idPerfil, temp_acabado, idAcabado)
            If txAll.Rows.Count > 0 Then
                Dim cos As dsbAlcoIngenieria.sp_ti039_selectByItemsRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti039_selectByItemsRow)
                TraerCostoEspecifico = New costoPerfilTemporal(cos.id, cos.fechaCreacion, cos.usuarioCreacion, cos.idCotiza, cos.perfilTemporal, cos.idPerfil,
                                                      cos.perfil, cos.acabadoTemporal, cos.idAcabado, cos.acabado, cos.idCostoAcabado, cos.idCostoNivel,
                                                      cos.idCostoAluminio, cos.costo, cos.idEstado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdCotiza(idCotiza As Integer) As List(Of costoPerfilTemporal)
        Try
            TraerxIdCotiza = New List(Of costoPerfilTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti039_selectByIdCotizaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti039_selectByIdCotizaDataTable = taAll.GetData(idCotiza)
            For Each cos As dsbAlcoIngenieria.sp_ti039_selectByIdCotizaRow In txAll.Rows
                TraerxIdCotiza.Add(New costoPerfilTemporal(cos.id, cos.fechaCreacion, cos.usuarioCreacion, cos.idCotiza, cos.perfilTemporal,
                                                           cos.idPerfil, cos.perfil, cos.acabadoTemporal, cos.idAcabado, cos.acabado,
                                                           cos.idCostoAcabado, cos.idCostoNivel, cos.idCostoAluminio, cos.costo, cos.idEstado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxPerfil(idCotiza As Integer, temporal As Boolean, idPerfil As Integer) As List(Of costoPerfilTemporal)
        Try
            Dim lista As List(Of costoPerfilTemporal) = TraerxIdCotiza(idCotiza).Where(Function(a)
                                                                                           Return a.PerfilTemporal = temporal And a.IdPerfil = idPerfil
                                                                                       End Function).ToList
            TraerxPerfil = lista
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxAcabado(idCotiza As Integer, temporal As Boolean, idAcabado As Integer) As List(Of costoPerfilTemporal)
        Try
            Dim lista As List(Of costoPerfilTemporal) = TraerxIdCotiza(idCotiza).Where(Function(a)
                                                                                           Return a.AcabadoTemporal = temporal And a.IdAcabado = idAcabado
                                                                                       End Function).ToList
            TraerxAcabado = lista
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class costoPerfilTemporal
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idCotiza As Integer
    Private _perfilTemporal As Boolean
    Private _idPerfil As Integer
    Private _perfil As String
    Private _acabadoTemporal As Boolean
    Private _idAcabado As Integer
    Private _acabado As String
    Private _idCostoAcabado As Integer
    Private _idCostoNivel As Integer
    Private _idCostoAluminio As Integer
    Private _costo As Decimal
    Private _idEstado As Integer
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
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property PerfilTemporal() As Boolean
        Get
            Return _perfilTemporal
        End Get
        Set(ByVal value As Boolean)
            _perfilTemporal = value
        End Set
    End Property
    Public Property IdPerfil() As Integer
        Get
            Return _idPerfil
        End Get
        Set(ByVal value As Integer)
            _idPerfil = value
        End Set
    End Property
    Public Property Perfil() As String
        Get
            Return _perfil
        End Get
        Set(ByVal value As String)
            _perfil = value
        End Set
    End Property
    Public Property AcabadoTemporal() As Boolean
        Get
            Return _acabadoTemporal
        End Get
        Set(ByVal value As Boolean)
            _acabadoTemporal = value
        End Set
    End Property
    Public Property IdAcabado() As Integer
        Get
            Return _idAcabado
        End Get
        Set(ByVal value As Integer)
            _idAcabado = value
        End Set
    End Property
    Public Property Acabado() As String
        Get
            Return _acabado
        End Get
        Set(ByVal value As String)
            _acabado = value
        End Set
    End Property
    Public Property IdCostoAcabado() As Integer
        Get
            Return _idCostoAcabado
        End Get
        Set(ByVal value As Integer)
            _idCostoAcabado = value
        End Set
    End Property
    Public Property IdCostoNivel() As Integer
        Get
            Return _idCostoNivel
        End Get
        Set(ByVal value As Integer)
            _idCostoNivel = value
        End Set
    End Property
    Public Property IdCostoAluminio() As Integer
        Get
            Return _idCostoAluminio
        End Get
        Set(ByVal value As Integer)
            _idCostoAluminio = value
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
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCotiza As Integer,
                   perfilTemporal As Boolean, idPerfil As Integer, perfil As String, acabadoTemporal As Boolean,
                   idAcabado As Integer, acabado As String, idCostoAcabado As Integer, idCostoNivel As Integer,
                   idCostoAluminio As Integer, costo As Decimal, idEstado As Integer)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _idCotiza = idCotiza
            _perfilTemporal = perfilTemporal
            _idPerfil = idPerfil
            _perfil = perfil
            _acabadoTemporal = acabadoTemporal
            _idAcabado = idAcabado
            _acabado = acabado
            _idCostoAcabado = idCostoAcabado
            _idCostoNivel = idCostoNivel
            _idCostoAluminio = idCostoAluminio
            _costo = costo
            _idEstado = idEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class