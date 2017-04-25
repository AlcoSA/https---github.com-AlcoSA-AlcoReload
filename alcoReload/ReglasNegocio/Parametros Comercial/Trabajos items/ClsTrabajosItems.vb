Imports Datos

Public Class ClsTrabajosItems
#Region "Variables"
    Private taTrabajosItems As New dsAlcoComercial2TableAdapters.tc090_trabajosItemsCotizaTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, prefijo As String, descripcion As String, uniMedida As String,
                             idFamiliaMaterial As Integer, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taTrabajosItems.sp_tc090_insert(usuario, prefijo, descripcion,
                                                                   uniMedida, idFamiliaMaterial, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, prefijo As String, descripcion As String, uniMedida As String,
                         idFamiliaMaterial As Integer, usuario As String, idEstado As Integer)
        Try
            taTrabajosItems.sp_tc090_update(id, prefijo, descripcion, uniMedida, idFamiliaMaterial, usuario, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taTrabajosItems.sp_tc090_updateEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of trabajoItems)
        Try
            TraerTodos = New List(Of trabajoItems)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc090_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc090_selectAllDataTable = taAll.GetData()
            For Each tra As dsAlcoComercial2.sp_tc090_selectAllRow In txAll
                TraerTodos.Add(New trabajoItems(tra.id, tra.fechaCreacion, tra.usuarioCreacion, tra.prefijo, tra.descripcion,
                                                tra.unidadMedida, tra.idFamiliaMaterial, tra.familiaMaterial, tra.usuarioModi,
                                                tra.fechaModi, tra.idEstado, tra.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxFamiliaMaterial(idFamiliaMaterial As Integer) As List(Of trabajoItems)
        Try
            TraerxFamiliaMaterial = New List(Of trabajoItems)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc090_selectByFamiliaTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc090_selectByFamiliaDataTable = taAll.GetData(idFamiliaMaterial)
            For Each tra As dsAlcoComercial2.sp_tc090_selectByFamiliaRow In txAll
                TraerxFamiliaMaterial.Add(New trabajoItems(tra.id, tra.fechaCreacion, tra.usuarioCreacion, tra.prefijo, tra.descripcion,
                                                           tra.unidadMedida, tra.idFamiliaMaterial, tra.familiaMaterial, tra.usuarioModi,
                                                           tra.fechaModi, tra.idEstado, tra.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteRegistro(prefijo As String, familiaMaterial As Integer) As Boolean
        Try
            Dim list As List(Of trabajoItems) = TraerTodos().Where(Function(a)
                                                                       Return a.Prefijo = prefijo And
                                                                       a.IdFamiliaMaterial = familiaMaterial And
                                                                       a.IdEstado = ClsEnums.Estados.ACTIVO
                                                                   End Function).ToList
            If list.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(idTrabajo As Integer) As trabajoItems
        Try
            Dim list As List(Of trabajoItems) = TraerTodos()
            TraerxId = list.FirstOrDefault(Function(a) a.Id = idTrabajo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class trabajoItems
    Inherits ClsBaseParametros
#Region "Variables"
    Private _prefijo As String
    Private _descripcion As String
    Private _idFamiliaMaterial As Integer
    Private _familiaMaterial As String
    Private _unidadMedida As String
#End Region
#Region "Propiedades"
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
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, prefijo As String,
                   descripcion As String, unidadMedida As String, idFamiliaMaterial As Integer,
                   familiaMaterial As String, usuarioModi As String, fechaModi As DateTime,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _prefijo = prefijo
            _descripcion = descripcion
            _unidadMedida = unidadMedida
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = familiaMaterial
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
