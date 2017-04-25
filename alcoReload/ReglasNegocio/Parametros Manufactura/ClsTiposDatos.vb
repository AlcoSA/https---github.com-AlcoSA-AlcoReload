Imports Datos
Public Class ClsTiposDatos
#Region "Variables"
    Private tatiposDatos As New dsbAlcoIngenieriaTableAdapters.ti020_tiposdedatosTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar un nuevo tipo de dato
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, nombre As String, descripcion As String, estado As Integer)
        Try
            tatiposDatos.sp_ti020_insert(usuario, nombre, descripcion, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar un tipo de dato registrado
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, nombre As String, descripcion As String, estado As Integer)
        Try
            tatiposDatos.sp_ti020_updateById(nombre, descripcion, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los tipos de datos registrados
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of TipoDato)
        TraerTodos = New List(Of TipoDato)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti020_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti020_selectAllDataTable = taAll.GetData()
            For Each td As dsbAlcoIngenieria.sp_ti020_selectAllRow In txall.Rows
                TraerTodos.Add(New TipoDato(td.Id, td.Usuario_Creacion, td.Fecha_Creacion, td.Nombre, td.Descripcion, td.Usuario_Modificacion, td.Fecha_Modificacion, td.Id_Estado, td.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener tipos de datos filtrados por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As TipoDato
        TraerxId = New TipoDato
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti020_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti020_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim td As dsbAlcoIngenieria.sp_ti020_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti020_selectByIdRow)
                TraerxId = New TipoDato(td.Id, td.Usuario_Creacion, td.Fecha_Creacion, td.Nombre, td.Descripcion, td.Usuario_Modificacion, td.Fecha_Modificacion, td.Id_Estado, td.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener tipos de datos asociados a un estado
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of TipoDato)
        TraerxEstado = New List(Of TipoDato)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti020_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti020_selectByEstadoDataTable = taAll.GetData(estado)
            For Each td As dsbAlcoIngenieria.sp_ti020_selectByEstadoRow In txall.Rows
                TraerxEstado.Add(New TipoDato(td.Id, td.Usuario_Creacion, td.Fecha_Creacion, td.Nombre, td.Descripcion, td.Usuario_Modificacion, td.Fecha_Modificacion, td.Id_Estado, td.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class TipoDato
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombre As String = String.Empty
    Private _descripcion As String = String.Empty
#End Region

#Region "Propiedades"

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, nombre As String, descripcion As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
            _descripcion = Trim(descripcion)
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
