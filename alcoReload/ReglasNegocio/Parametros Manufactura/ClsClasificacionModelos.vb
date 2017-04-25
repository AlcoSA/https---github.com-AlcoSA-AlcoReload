Imports Datos
Public Class ClsClasificacionModelos
#Region "Variables"
    Private taClasifModelos As New dsbAlcoIngenieriaTableAdapters.ti005_clasifmodelosTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva clasificación de modelos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="clasificacion"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, clasificacion As String, prefijo As String, estado As Integer)
        Try
            taClasifModelos.sp_ti005_insert(usuario, clasificacion, prefijo, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar alguna clasificación de modelos
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="clasificacion"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, clasificacion As String, prefijo As String, estado As Integer)
        Try
            taClasifModelos.sp_ti005_updateById(id, clasificacion, prefijo, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las clasificaciones de modelos registradas
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of ClasificacionModelo)
        TraerTodos = New List(Of ClasificacionModelo)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti005_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti005_selectAllDataTable = taAll.GetData()
            For Each cm As dsbAlcoIngenieria.sp_ti005_selectAllRow In txall.Rows
                TraerTodos.Add(New ClasificacionModelo(cm.Id, cm.Usuario_Creacion, cm.Fecha_Creacion, cm.Clasificacion, cm.Prefijo,
                                                        cm.Usuario_Modifiacion, cm.Fecha_Modifiacion, cm.Id_Estado, cm.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las clasificaciones de modelos filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As ClasificacionModelo
        TraerxId = New ClasificacionModelo
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti005_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti005_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim cm As dsbAlcoIngenieria.sp_ti005_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti005_selectByIdRow)
                TraerxId = New ClasificacionModelo(cm.Id, cm.Usuario_Creacion, cm.Fecha_Creacion, cm.Clasificacion, cm.Prefijo,
                                                        cm.Usuario_Modifiacion, cm.Fecha_Modifiacion, cm.Id_Estado, cm.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Trae todos los parámetros de la tabla clasificación modelo, según el estado
    ''' </summary>
    ''' <param name="estado">Valor del estado [Activo=1, Inactivo=2]</param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of ClasificacionModelo)
        TraerxEstado = New List(Of ClasificacionModelo)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti005_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti005_selectByEstadoDataTable = taAll.GetData(estado)
            For Each cm As dsbAlcoIngenieria.sp_ti005_selectByEstadoRow In txall.Rows
                TraerxEstado.Add(New ClasificacionModelo(cm.Id, cm.Usuario_Creacion, cm.Fecha_Creacion, cm.Clasificacion, cm.Prefijo,
                                                        cm.Usuario_Modifiacion, cm.Fecha_Modifiacion, cm.Id_Estado, cm.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class ClasificacionModelo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _clasificacion As String = String.Empty
    Private _prefijo As String = String.Empty
#End Region

#Region "Propiedades"

    Public Property Clasificacion As String
        Get
            Return _clasificacion
        End Get
        Set(value As String)
            _clasificacion = value
        End Set
    End Property

    Public Property Prefijo As String
        Get
            Return _prefijo
        End Get
        Set(value As String)
            _prefijo = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, clasificacion As String, prefijo As String, usuariomodificacion As String, _
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _clasificacion = Trim(clasificacion)
            _prefijo = Trim(prefijo)
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
