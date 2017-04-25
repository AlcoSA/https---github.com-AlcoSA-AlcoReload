Imports Datos
Public Class ClsTipoModelo
#Region "Variables"
    Dim tatipoModelo As New dsbAlcoIngenieriaTableAdapters.ti004_tipomodeloTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar un nuevo tipo de modelo
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="tipo"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, tipo As String, prefijo As String, estado As Integer)
        Try
            tatipoModelo.sp_ti004_insert(usuario, tipo, prefijo, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar los tipos de modelos registrados
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="tipo"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, tipo As String, prefijo As String, estado As Integer)
        Try
            tatipoModelo.sp_ti004_updateById(id, tipo, prefijo, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los tipo de modelos registrados
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of TipoModelo)
        TraerTodos = New List(Of TipoModelo)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti004_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti004_selectAllDataTable = taAll.GetData()
            For Each tm As dsbAlcoIngenieria.sp_ti004_selectAllRow In txall.Rows
                TraerTodos.Add(New TipoModelo(tm.Id, tm.Usuario_Creacion, tm.Fecha_Creacion, tm.Tipo, tm.Prefijo,
                                              tm.Usuario_Modifiacion, tm.Fecha_Modificacion, tm.Id_Estado, tm.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener los tipos de modelos filtrados por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As TipoModelo
        TraerxId = New TipoModelo
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti004_selectAllByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti004_selectAllByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim tm As dsbAlcoIngenieria.sp_ti004_selectAllByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti004_selectAllByIdRow)
                TraerxId = New TipoModelo(tm.Id, tm.Usuario_Creacion, tm.Fecha_Creacion, tm.Tipo, tm.Prefijo,
                                              tm.Usuario_Modifiacion, tm.Fecha_Modificacion, tm.Id_Estado, tm.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Trae todos los parámetros de la tabla tipos de modelo, según el estado
    ''' </summary>
    ''' <param name="estado">Valor del estado [Activo=1, Inactivo=2]</param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of TipoModelo)
        TraerxEstado = New List(Of TipoModelo)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti004_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti004_selectByEstadoDataTable = taAll.GetData(estado)
            For Each tm As dsbAlcoIngenieria.sp_ti004_selectByEstadoRow In txall.Rows
                TraerxEstado.Add(New TipoModelo(tm.Id, tm.Usuario_Creacion, tm.Fecha_Creacion, tm.Tipo, tm.Prefijo,
                                              tm.Usuario_Modifiacion, tm.Fecha_Modificacion, tm.Id_Estado, tm.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class TipoModelo
    Inherits ClsBaseParametros
#Region "Variables"

    Private _tipo As String = String.Empty
    Private _prefijo As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, tipo As String, prefijo As String, usuariomodificacion As String, _
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _tipo = Trim(tipo)
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