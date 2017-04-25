Imports Datos

Public Class ClsEsquemaInforme
#Region "Variables"
    Private taEsquemaInforme As New dsAlcoContratosTableAdapters.tc066_esquemaInformeTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta el nuevo registro de esquema de informe
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="IdTipoNota"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="pieDePagina"></param>
    ''' <param name="valorDefecto"></param>
    Public Sub Insertar(usuarioCreacion As String, IdTipoNota As Integer, descripcion As String,
                        pieDePagina As String, valorDefecto As Boolean)
        Try
            taEsquemaInforme.sp_tc066_insert(usuarioCreacion, IdTipoNota, descripcion,
                                             pieDePagina, valorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Actualiza el registro de esquema informe correspondiente al id indicado
    ''' </summary>
    ''' <param name="idTipoNota"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="pieDePagina"></param>
    ''' <param name="usuarioModi"></param>
    ''' <param name="valorDefecto"></param>
    Public Sub Modificar(id As Integer, idTipoNota As Integer, descripcion As String, pieDePagina As String,
                         usuarioModi As String, valorDefecto As Boolean)
        Try
            taEsquemaInforme.sp_tc066_update(id, idTipoNota, descripcion, pieDePagina, usuarioModi, valorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Obtiene todos los registros de esquema informe
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos() As List(Of esquemaInforme)
        Try
            traerTodos = New List(Of esquemaInforme)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc066_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc066_selectAllDataTable = taAll.GetData()
            For Each esq As dsAlcoContratos.sp_tc066_selectAllRow In txAll
                traerTodos.Add(New esquemaInforme(esq.Id, esq.fechaCreacion, esq.usuarioCreacion, esq.idTipoNota, esq.tipoNota,
                                           esq.descripcion, esq.pieDePagina, esq.fechaModi, esq.usuarioModi, esq.valorDefecto))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene todos los registros corespondientes al tipo de nota indicado
    ''' </summary>
    ''' <param name="idTipoNota"></param>
    ''' <returns></returns>
    Public Function traerByTipoNota(idTipoNota As Integer) As List(Of esquemaInforme)
        Try
            traerByTipoNota = New List(Of esquemaInforme)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc066_selectByTipoNotaTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc066_selectByTipoNotaDataTable = taAll.GetData(idTipoNota)
            For Each esq As dsAlcoContratos.sp_tc066_selectByTipoNotaRow In txAll
                traerByTipoNota.Add(New esquemaInforme(esq.Id, esq.fechaCreacion, esq.usuarioCreacion, esq.idTipoNota, esq.tipoNota,
                                                esq.descripcion, esq.pieDePagina, esq.fechaModi, esq.usuarioModi, esq.valorDefecto))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerValorDefectoByTipoNota(idTipoNota As Integer) As esquemaInforme
        Try
            traerValorDefectoByTipoNota = New esquemaInforme
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc066_selectValorDefectoByTipoNotaTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc066_selectValorDefectoByTipoNotaDataTable = taAll.GetData(idTipoNota)
            If txAll.Rows.Count > 0 Then
                Dim esq As dsAlcoContratos.sp_tc066_selectValorDefectoByTipoNotaRow = DirectCast(txAll.Rows(0), dsAlcoContratos.sp_tc066_selectValorDefectoByTipoNotaRow)
                traerValorDefectoByTipoNota = New esquemaInforme(esq.Id, esq.fechaCreacion, esq.usuarioCreacion, esq.idTipoNota,
                                                                 esq.tipoNota, esq.descripcion, esq.pieDePagina, esq.fechaModi,
                                                                 esq.usuarioModi, esq.valorDefecto)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class esquemaInforme
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idTipoNota As Integer
    Private _tipoNota As String
    Private _descripcion As String
    Private _pieDePagina As String
    Private _valorDefecto As Boolean
#End Region
#Region "Propiedades"
    Public Property idTipoNota() As Integer
        Get
            Return _idTipoNota
        End Get
        Set(ByVal value As Integer)
            _idTipoNota = value
        End Set
    End Property
    Public Property tipoNota() As String
        Get
            Return _tipoNota
        End Get
        Set(ByVal value As String)
            _tipoNota = value
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
    Public Property pieDePagina() As String
        Get
            Return _pieDePagina
        End Get
        Set(ByVal value As String)
            _pieDePagina = value
        End Set
    End Property
    Public Property valorDefecto() As Boolean
        Get
            Return _valorDefecto
        End Get
        Set(ByVal value As Boolean)
            _valorDefecto = value
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
    Public Sub New(Id As Integer, FechaCreacion As DateTime, UsuarioCreacion As String, IdTipoNota As Integer,
                   TipoNota As String, Descripcion As String, PieDePagina As String, FechaModi As DateTime,
                   UsuarioModi As String, valorDefecto As Boolean)
        Try
            Me.Id = Id
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = UsuarioCreacion
            _idTipoNota = IdTipoNota
            _tipoNota = TipoNota
            _descripcion = Descripcion
            _pieDePagina = PieDePagina
            Me.FechaModificacion = FechaModi
            Me.UsuarioModificacion = UsuarioModi
            _valorDefecto = valorDefecto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
