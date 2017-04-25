Imports Datos
Public Class ClsDirectores
#Region "Variables"
    Private taDirectores As New dsAlcoComercialTableAdapters.tc027_DirectoresTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de directores en la base de datos
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="nombres"></param>
    ''' <param name="telefono"></param>
    ''' <param name="movil"></param>
    ''' <param name="idEstado"></param>
    ''' <param name="valorDefecto"></param>
    Public Sub Ingresar(usuarioCreacion As String, nombres As String, telefono As String,
                        movil As String, correo As String, idEstado As Integer, valorDefecto As Integer)
        Try
            taDirectores.sp_tc027_insert(usuarioCreacion, nombres, telefono, movil, correo, idEstado, valorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el registro correspondiente al Id en la base de datos
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="nombres"></param>
    ''' <param name="telefono"></param>
    ''' <param name="movil"></param>
    ''' <param name="usuarioModi"></param>
    ''' <param name="idEstado"></param>
    ''' <param name="valorDefecto"></param>
    Public Sub Modificar(id As Integer, nombres As String, telefono As String, movil As String, correo As String,
                         usuarioModi As String, idEstado As Integer, valorDefecto As Integer)
        Try
            taDirectores.sp_tc027_update(id, nombres, telefono, movil, correo, usuarioModi, idEstado, valorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    '''' <summary>
    '''' Indica si en los registros ya existe alguno como valor por defecto
    '''' </summary>
    '''' <returns></returns>
    'Public Function ExisteValorDefecto() As Boolean
    '    Try
    '        Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc027_selectExistValorDefectoTableAdapter
    '        Dim txAll As dsAlcoCotizaciones.sp_tc027_selectExistValorDefectoDataTable = taAll.GetData()
    '        If txAll.Rows.Count > 0 Then Return True
    '        Return False
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Function

    ''' <summary>
    ''' Obtiene todos los registros de directores activos e inactivos
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef tb As DataTable = Nothing) As List(Of director)
        TraerTodos = New List(Of director)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc027_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc027_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc027_selectAllRow In txAll
                TraerTodos.Add(New director(ti.Id, ti.usuarioCreacion, ti.fechaCreacion, ti.nombres, ti.telFijo,
                                                ti.telMovil, ti.correo, ti.usuarioModi, ti.fechaModi, ti.idEstado, ti.valorDefecto))
            Next
            If txAll.Rows.Count > 0 Then
                tb = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    '''' <summary>
    '''' Obtien todos los registros que estén activos con el valor por defecto como primer registro
    '''' </summary>
    '''' <returns></returns>
    'Public Function TraerxValorDefecto() As List(Of director)
    '    TraerxValorDefecto = New List(Of director)
    '    Try
    '        Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc027_selectByValorDefectoTableAdapter
    '        Dim txAll As dsAlcoCotizaciones.sp_tc027_selectByValorDefectoDataTable = taAll.GetData()
    '        For Each ti As dsAlcoCotizaciones.sp_tc027_selectByValorDefectoRow In txAll
    '            TraerxValorDefecto.Add(New director(ti.rowid, ti.usuarioCreacion, ti.fechaCreacion, ti.nombres,
    '                                                    ti.telFijo, ti.telMovil, ti.usuarioModi, ti.fechaModi,
    '                                                    ti.rowidEstado, ti.valorDefecto))
    '        Next
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Function

    ''' <summary>
    ''' Obtiene el registro de directores correspondiente al Id
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As director
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc027_selectByIdTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc027_selectByIdDataTable = taAll.GetData(id)
            If txAll.Rows.Count > 0 Then
                Dim dir As dsAlcoComercial.sp_tc027_selectByIdRow = DirectCast(txAll.Rows(0), dsAlcoComercial.sp_tc027_selectByIdRow)
                TraerxId = New director(dir.rowid, dir.usuarioCreacion, dir.fechaCreacion, dir.nombres, dir.telFijo,
                                              dir.telMovil, dir.correo, dir.usuarioModi, dir.fechaModi, dir.rowidEstado,
                                              dir.valorDefecto)
            Else
                TraerxId = Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todos los registros de directores según el estado indicado
    ''' </summary>
    ''' <param name="idEstado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(idEstado As Integer) As List(Of director)
        TraerxEstado = New List(Of director)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc027_selectByIdEstadoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc027_selectByIdEstadoDataTable = taAll.GetData(idEstado)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc027_selectByIdEstadoRow In txAll
                    TraerxEstado.Add(New director(ti.rowid, ti.usuarioCreacion, ti.fechaCreacion, ti.nombres,
                                                  ti.telFijo, ti.telMovil, ti.correo, ti.usuarioModi, ti.fechaModi,
                                                  ti.rowidEstado, ti.valorDefecto))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de directores con el nombre indicado
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    Public Function TraerxNombre(nombre As String) As Boolean
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc027_selectByNombreTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc027_selectByNombreDataTable = taAll.GetData(nombre)
            If txAll.Rows.Count > 0 Then Return True
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class director
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombres As String
    Private _telefono As String
    Private _movil As String
    Private _correo As String
    Private _valorDefecto As Integer
#End Region
#Region "Propiedades"
    Public Property nombres() As String
        Get
            Return _nombres
        End Get
        Set(ByVal value As String)
            _nombres = value
        End Set
    End Property
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Public Property movil() As String
        Get
            Return _movil
        End Get
        Set(ByVal value As String)
            _movil = value
        End Set
    End Property
    Public Property Correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
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
#End Region
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, nombres As String,
                   telefono As String, movil As String, correo As String, usuarioModi As String,
                   fechaModi As DateTime, idEstado As Integer, valorDefecto As Integer)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            Me.FechaCreacion = fechaCreacion
            _nombres = Trim(nombres)
            _telefono = Trim(telefono)
            _movil = Trim(movil)
            _correo = Trim(correo)
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            _valorDefecto = valorDefecto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
