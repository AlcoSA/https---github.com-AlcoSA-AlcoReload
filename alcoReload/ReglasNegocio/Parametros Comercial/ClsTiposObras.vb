Imports Datos

Public Class ClsTiposObras
#Region "Variables"
    Private taTiposObras As New dsAlcoComercialTableAdapters.tc028_tipoObraTableAdapter
#End Region

#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de tipo de obra en la base de datos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idComponente"></param>
    ''' <param name="idEstado"></param>
    ''' <param name="valorDefecto"></param>
    Public Sub Ingresar(usuario As String, descripcion As String, idComponente As Integer, idEstado As Integer,
                        valorDefecto As Integer, tipoImpuesto As Integer, idParaSuministro As Integer, idParaInstalacion As Integer)
        Try
            taTiposObras.sp_tc028_insert(usuario, descripcion, idComponente, idEstado, valorDefecto, tipoImpuesto, idParaSuministro, idParaInstalacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el registro correspondiente al Id en la base de datos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idEstado"></param>
    ''' <param name="valorDefecto"></param>
    ''' <param name="id"></param>
    Public Sub Modificar(usuario As String, descripcion As String, idEstado As Integer, valorDefecto As Integer, id As Integer,
                         idComponente As Integer, tipoImpuesto As Integer, idParaSuministro As Integer, idParaInstalacion As Integer)
        Try
            taTiposObras.sp_tc028_update(descripcion, usuario, idEstado, valorDefecto, id, idComponente, tipoImpuesto, idParaSuministro, idParaInstalacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de tipos de obra activos e inactivos
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tipoObra)
        TraerTodos = New List(Of tipoObra)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc028_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc028_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc028_selectAllRow In txAll.Rows
                TraerTodos.Add(New tipoObra(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.descripcion, ti.usuarioModi,
                                            ti.fechaModi, ti.idEstado, ti.estado, ti.valorDefecto, ti.idComponente,
                                            ti.Componente, ti.tipoImpuesto, ti.IdParaSuministro, ti.ParaSuministro, ti.IdParaSuministro, ti.ParaInstalacion))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    '''' <summary>
    '''' Indica si en los registros ya existe alguno como valor por defecto
    '''' </summary>
    '''' <returns></returns>
    'Public Function ExisteValorDefecto() As Boolean
    '    Try
    '        Dim taAll As New dsAlcoComercialTableAdapters.sp_tc028_selectExistValorDefectoTableAdapter
    '        Dim txAll As dsAlcoComercial.sp_tc028_selectExistValorDefectoDataTable = taAll.GetData()
    '        If txAll.Rows.Count > 0 Then Return True
    '        Return False
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Function
    '''' <summary>
    '''' Trae todos los registros que estén activos con el valor por defecto como primer registro
    '''' </summary>
    '''' <returns></returns>
    'Public Function TraerxValorDefecto() As List(Of tipoObra)
    '    TraerxValorDefecto = New List(Of tipoObra)
    '    Try
    '        Dim taAll As New dsAlcoComercialTableAdapters.sp_tc028_selectByValorDefectoTableAdapter
    '        Dim txAll As dsAlcoComercial.sp_tc028_selectByValorDefectoDataTable = taAll.GetData()
    '        For Each ti As dsAlcoComercial.sp_tc028_selectByValorDefectoRow In txAll
    '            TraerxValorDefecto.Add(New tipoObra(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.descripcion, ti.usuarioModi,
    '                                                    ti.fechaMOdi, ti.estado, "", ti.valorDefecto, ti.idComponente, ti.Componente, ti.tipoImpuesto))
    '        Next
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Function

    ''' <summary>
    ''' Obtiene el registro de tipo obra correspondiente al Id
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Function TraerxId(Id As Integer) As tipoObra
        TraerxId = New tipoObra
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc028_selectByIdTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc028_selectByIdDataTable = taAll.GetData(Id)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc028_selectByIdRow In txAll
                    TraerxId = New tipoObra(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.descripcion, ti.usuarioModi, ti.fechaMOdi,
                                              ti.estado, "", ti.valorDefecto, ti.idComponente, ti.Componente, ti.tipoImpuesto, ti.IdParaSuministro, ti.ParaSuministro, ti.IdParaSuministro, ti.ParaInstalacion)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todos los registros de estados según el estado indicado
    ''' </summary>
    ''' <param name="idEstado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(idEstado As Integer) As List(Of tipoObra)
        TraerxEstado = New List(Of tipoObra)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc028_selectByEstadoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc028_selectByEstadoDataTable = taAll.GetData(idEstado)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc028_selectByEstadoRow In txAll
                    TraerxEstado.Add(New tipoObra(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.descripcion, ti.usuarioModi,
                                                  ti.fechaMOdi, ti.estado, "", ti.valorDefecto, ti.idComponente, ti.Componente, ti.tipoImpuesto, ti.IdParaSuministro, ti.ParaSuministro, ti.IdParaSuministro, ti.ParaInstalacion))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de tipos obras con la descripción indicada
    ''' </summary>
    ''' <param name="descripcion"></param>
    ''' <returns></returns>
    Public Function TraerxDescripcion(descripcion As String) As Boolean
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc028_selectByDescripcionTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc028_selectByDescripcionDataTable = taAll.GetData(descripcion)
            If txAll.Rows.Count > 0 Then Return True
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class tipoObra
    Inherits ClsBaseParametros
#Region "Variables"
    Private _Descripcion As String
    Private _valorDefecto As Integer
    Private _idComponente As Integer
    Private _Componente As String
    Private _tipoImpuesto As Integer
#End Region

#Region "Propiedades"
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
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

    Public Property idComponente() As Integer
        Get
            Return _idComponente
        End Get
        Set(ByVal value As Integer)
            _idComponente = value
        End Set
    End Property

    Public Property Componente() As String
        Get
            Return _Componente
        End Get
        Set(ByVal value As String)
            _Componente = value
        End Set
    End Property

    Public Property tipoImpuesto() As Integer
        Get
            Return _tipoImpuesto
        End Get
        Set(ByVal value As Integer)
            _tipoImpuesto = value
        End Set
    End Property
    Private _idParaSuministro As Integer
    Public Property idParaSuministro() As Integer
        Get
            Return _idParaSuministro
        End Get
        Set(ByVal value As Integer)
            _idParaSuministro = value
        End Set
    End Property

    Private _ParaSuministro As String
    Public Property ParaSuministro() As String
        Get
            Return _ParaSuministro
        End Get
        Set(ByVal value As String)
            _ParaSuministro = value
        End Set
    End Property
    Private _IdParaInstalacion As Integer
    Public Property idParaInstalacion() As Integer
        Get
            Return _IdParaInstalacion
        End Get
        Set(ByVal value As Integer)
            _IdParaInstalacion = value
        End Set
    End Property
    Private _ParaInstalacion As String
    Public Property ParaInstalacion() As String
        Get
            Return _ParaInstalacion
        End Get
        Set(ByVal value As String)
            _ParaInstalacion = value
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
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String,
                   valorDefecto As Integer, idComponente As Integer, componente As String, tipoImpuesto As Integer, idParaSuministro As Integer,
                   ParaSuministro As String, idParaInstalacion As Integer, ParaInstalacion As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _Descripcion = Trim(descripcion)
            _idComponente = idComponente
            _Componente = Trim(componente)
            _tipoImpuesto = tipoImpuesto
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
            _valorDefecto = valorDefecto
            _idParaSuministro = idParaSuministro
            _ParaSuministro = ParaSuministro
            _IdParaInstalacion = idParaInstalacion
            _ParaInstalacion = ParaInstalacion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
