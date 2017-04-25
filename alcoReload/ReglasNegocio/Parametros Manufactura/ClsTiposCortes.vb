Imports Datos
Public Class ClsTiposCortes
#Region "Variables"
    Private tatiposcortes As New dsbAlcoIngenieriaTableAdapters.ti021_tiposdecortesTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar un nuevo tipo de corte
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="imagen"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, nombre As String, descripcion As String, imagen() As Byte, estado As Integer)
        Try
            tatiposcortes.sp_ti021_insert(usuario, nombre, descripcion, imagen, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar algún tipo de corte existente
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="imagen"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, nombre As String, descripcion As String, imagen() As Byte, estado As Integer)
        Try
            tatiposcortes.sp_ti021_updateById(nombre, descripcion, imagen, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los tipos de corte registrados
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of TipoCorte)
        TraerTodos = New List(Of TipoCorte)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti021_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti021_selectAllDataTable = taAll.GetData()
            For Each tc As dsbAlcoIngenieria.sp_ti021_selectAllRow In txall.Rows
                TraerTodos.Add(New TipoCorte(tc.Id, tc.Usuario_Creacion, tc.Fecha_Creacion, tc.Nombre, tc.Descripcion, tc.Imagen, tc.Usuario_Modificacion, tc.Fecha_Modificacion, tc.Id_Estado, tc.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener tipos de corte filtrados por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As TipoCorte
        TraerxId = New TipoCorte()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti021_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti021_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim tc As dsbAlcoIngenieria.sp_ti021_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti021_selectByIdRow)
                TraerxId = New TipoCorte(tc.Id, tc.Usuario_Creacion, tc.Fecha_Creacion, tc.Nombre, tc.Descripcion, tc.Imagen, tc.Usuario_Modificacion, tc.Fecha_Modificacion, tc.Id_Estado, tc.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxEstado(estado As Integer) As List(Of TipoCorte)
        TraerxEstado = New List(Of TipoCorte)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti021_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti021_selectByEstadoDataTable = taAll.GetData(estado)
            For Each tc As dsbAlcoIngenieria.sp_ti021_selectByEstadoRow In txall.Rows
                TraerxEstado.Add(New TipoCorte(tc.Id, tc.Usuario_Creacion, tc.Fecha_Creacion, tc.Nombre, tc.Descripcion, tc.Imagen, tc.Usuario_Modificacion, tc.Fecha_Modificacion, tc.Id_Estado, tc.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class TipoCorte
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombre As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _imagen() As Byte = Nothing
#End Region
#Region "Propiedades"

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Imagen As Byte()
        Get
            Return _imagen
        End Get
        Set(value As Byte())
            _imagen = value
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
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, nombre As String, descripcion As String, imagen() As Byte, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
            _descripcion = Trim(descripcion)
            _imagen = imagen
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
