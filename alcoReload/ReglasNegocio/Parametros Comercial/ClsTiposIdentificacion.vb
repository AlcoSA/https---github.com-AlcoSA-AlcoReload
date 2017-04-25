Imports Datos

Public Class ClsTiposIdentificacion
#Region "Variables"
        Private taTiposIdentificacion As New dsAlcoComercialTableAdapters.tc001_tiposIdentificacionTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de tipo identificación en la base de datos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idEstado"></param>
    Public Sub Ingresar(usuario As String, prefijo As String, descripcion As String, idEstado As Integer, valorPorDefecto As Integer)
        Try
            taTiposIdentificacion.sp_tc001_insert(usuario, prefijo, descripcion, idEstado, valorPorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el registro correspondiente al Id en la base de datos
    ''' </summary>
    ''' <param name="prefijo"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idestado"></param>
    ''' <param name="id"></param>
    Public Sub Modificar(prefijo As String, descripcion As String, usuario As String, idestado As Integer, id As Integer, valorPorDefecto As Integer)
        Try
            taTiposIdentificacion.sp_tc001_update(prefijo, descripcion, usuario, idestado, id, valorPorDefecto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de tipos identificación activos e inactivos
    ''' </summary>
    ''' <returns></returns>
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of TiposIdentificacion)
        traerTodos = New List(Of TiposIdentificacion)
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc001_selectAllTableAdapter
            Dim txall As dsAlcoComercial.sp_tc001_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc001_selectAllRow In txall.Rows
                traerTodos.Add(New TiposIdentificacion(ti.Id, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Prefijo, ti.Descripcion,
                                                       ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.valor_Defecto))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de tipo identificación correspondiente al Id
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As TiposIdentificacion
        Try
            TraerxId = New TiposIdentificacion
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc001_selectByIdTableAdapter
                Dim txid As dsAlcoComercial.sp_tc001_selectByIdDataTable = taAll.GetData(id)
                If txid.Rows.Count > 0 Then
                    Dim ti As dsAlcoComercial.sp_tc001_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc001_selectByIdRow)
                    TraerxId = New TiposIdentificacion(ti.Id, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Prefijo, ti.Descripcion, ti._Usuario_Ult__Modi,
                                                       ti._Fecha_Ult__Modi, ti.id_Estado, ti.Estado, ti.valorPorDefecto)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de tipo identificación con la descripción indicada
    ''' </summary>
    ''' <param name="descripcion"></param>
    ''' <returns></returns>
    Public Function TraerxDescripcion(descripcion As String) As Boolean
        Try
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc001_selectByDescripcionTableAdapter
                Dim txid As dsAlcoComercial.sp_tc001_selectByDescripcionDataTable = taAll.GetData(descripcion)
                If txid.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de tipo identificación con el prefijo indicado
    ''' </summary>
    ''' <param name="prefijo"></param>
    ''' <returns></returns>
    Public Function TraerxPrefijo(prefijo As String) As Boolean
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc001_selectByPrefijoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc001_selectByPrefijoDataTable = taAll.GetData(prefijo)
            If txAll.Rows.Count > 0 Then Return True
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todos los registros de tipos identificación según el estado indicado
    ''' </summary>
    ''' <param name="idEstado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(idEstado As Integer) As List(Of TiposIdentificacion)
            Try
                TraerxEstado = New List(Of TiposIdentificacion)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc001_selectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc001_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc001_selectByEstadoRow In txid.Rows
                        TraerxEstado.Add(New TiposIdentificacion(ti.Id, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Prefijo, ti.Descripcion,
                                                                     ti.Ult_Usuario_Modi, ti.Fecha_Modi, ti.Id_Estado, ti.Estado, ti.valorPorDefecto))
                    Next
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
#Region "Funciones"

#End Region
    End Class
    Public Class TiposIdentificacion
        Inherits ClsBaseParametros
#Region "Variables"
        Private _prefijo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _valorDefecto As Integer = 0
#End Region
#Region "Propiedades"


    Public Property prefijo() As String
            Get
                Return _prefijo
            End Get
            Set(ByVal value As String)
                _prefijo = value
            End Set
        End Property
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
#End Region
#Region "Constructor"
    Public Sub New()
            Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
    Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, prefijo As String, descripcion As String, usuarioModi As String,
                       fechaModi As DateTime, idEstado As Integer, estado As String, valorPorDefecto As Integer)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            Me.FechaCreacion = fechaCreacion
            _prefijo = Trim(prefijo)
            _Descripcion = Trim(descripcion)
            _valorDefecto = valorPorDefecto
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class


