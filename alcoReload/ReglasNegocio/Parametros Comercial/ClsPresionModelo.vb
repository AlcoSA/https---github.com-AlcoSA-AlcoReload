Imports Datos

Public Class ClsPresionModelo
#Region "Variables"
    Private tapresionModelo As New dsAlcoComercialTableAdapters.tc014_presionModeloTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de presión modelo en la base de datos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idEstado"></param>
    Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer, valorxdefecto As Boolean)
        Try
            tapresionModelo.Insertar(usuario, descripcion, idEstado, valorxdefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el registro correspondiente al Id en la base de datos
    ''' </summary>
    ''' <param name="descripcion"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idestado"></param>
    ''' <param name="id"></param>
    Public Sub modificar(descripcion As String, usuario As String, idestado As Integer, id As Integer, valorxdefecto As Boolean)
        Try
            tapresionModelo.Modificar(descripcion, usuario, idestado, id, valorxdefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de presión modelos activos e inactivos
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of presionModelos)
        traerTodos = New List(Of presionModelos)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc014_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc014_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc014_selectAllRow In txAll
                traerTodos.Add(New presionModelos(ti.id, ti.usuarioCreacion, ti.fechaCreacion, ti.descripcion,
                                                  ti.usuarioModi, ti.fechaModi, ti.valorDefecto, ti.idEstado, ti.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de presión modelo correspondiente al Id
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As presionModelos
        Try
            TraerxId = New presionModelos
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc014_selectByIdTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc014_selectByIdDataTable = taAll.GetData(id)
            For Each ti As dsAlcoComercial.sp_tc014_selectByIdRow In txAll
                TraerxId = New presionModelos(ti.id, ti.usuarioCreacion, ti.fechaCreacion, ti.descripcion, ti.usuarioModi,
                                              ti.fechaModi, ti.valorDefecto, ti.idEstado, ti.estado)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de presión modelo con la descripción indicada
    ''' </summary>
    ''' <param name="descripcion"></param>
    ''' <returns></returns>
    Public Function TraerxDescripcion(descripcion As String) As Boolean
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc014_selectByDescripcionTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc014_selectByDescripcionDataTable = taAll.GetData(descripcion)
            If txAll.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todos los registros de presión modelos según el estado indicado
    ''' </summary>
    ''' <param name="idEstado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(idEstado As Integer) As List(Of presionModelos)
        Try
            TraerxEstado = New List(Of presionModelos)

            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc014_selectByEstadoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc014_selectByEstadoDataTable = taAll.GetData(idEstado)
            For Each ti As dsAlcoComercial.sp_tc014_selectByEstadoRow In txAll
                TraerxEstado.Add(New presionModelos(ti.id, ti.usuarioCreacion, ti.fechaCreacion, ti.descripcion, ti.usuarioModi,
                                                    ti.fechaModi, ti.valorDefecto, ti.idEstado, ti.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
#Region "Funciones"

#End Region
End Class
Public Class presionModelos
    Inherits ClsBaseParametros
#Region "Variables"
    Private _Descripcion As String = String.Empty
    Private _valordefecto As Boolean = False
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
    Public Property ValorDefecto As Boolean
        Get
            Return _valordefecto
        End Get
        Set(value As Boolean)
            _valordefecto = value
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
    Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, descripcion As String,
                       usuarioModi As String, fechaModi As DateTime, valordefecto As Boolean,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            Me.FechaCreacion = fechaCreacion
            _Descripcion = Trim(descripcion)
            _valordefecto = valordefecto
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = Convert.ToInt32(Not Convert.ToBoolean(idEstado - 1))
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class


