Imports Datos
Public Class ClsEspesores

#Region "Variables"
    Private taEspesores As New dsbAlcoIngenieriaTableAdapters.ti025_espesoresTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para ingresar un nuevo acabado
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, prefijo As String, descripcion As String, estado As Integer)
        Try
            taEspesores.sp_ti025_insert(usuario, prefijo, descripcion, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar algún acabado existente en el sistema
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, prefijo As String, descripcion As String, estado As Integer)
        Try
            taEspesores.sp_ti025_updateById(prefijo, descripcion, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados registrados
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Espesor)
        TraerTodos = New List(Of Espesor)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti025_selectAllTableAdapter
            For Each esp As dsbAlcoIngenieria.sp_ti025_selectAllRow In taAll.GetData().Rows
                TraerTodos.Add(New Espesor(esp.Id, esp.UsuarioCreacion, esp.FechaCreacion, esp.Prefijo, esp.Descripcion, esp.FechaModificacion, esp.UsuarioModificacion, esp.Id_Estado, esp.Estado))
            Next
            If taAll.GetData().Rows.Count > 0 Then
                dt = taAll.GetData().CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados filtrados por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As Espesor
        TraerxId = New Espesor
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti025_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti025_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim esp As dsbAlcoIngenieria.sp_ti025_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti025_selectByIdRow)
                TraerxId = New Espesor(esp.Id, esp.UsuarioCreacion, esp.FechaCreacion, esp.Prefijo, esp.Descripcion, esp.FechaModificacion, esp.UsuarioCreacion, esp.Id_Estado, esp.Estado)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados asociados a un estado
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of Espesor)
        TraerxEstado = New List(Of Espesor)
        Try
            Dim taEstado As New dsbAlcoIngenieriaTableAdapters.sp_ti025_selectByEstadoTableAdapter
            Dim txEstado As dsbAlcoIngenieria.sp_ti025_selectByEstadoDataTable = taEstado.GetData(estado)
            For Each esp As dsbAlcoIngenieria.sp_ti025_selectByEstadoRow In txEstado.Rows
                TraerxEstado.Add(New Espesor(esp.Id, esp.UsuarioCreacion, esp.FechaCreacion, esp.Prefijo, esp.Descripcion, esp.FechaModificacion, esp.UsuarioCreacion, esp.Id_Estado, esp.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados filtrados por un prefijo
    ''' </summary>
    ''' <param name="prefijo"></param>
    ''' <returns></returns>
    Public Function TraerxPrefijo(prefijo As String) As Espesor
        TraerxPrefijo = New Espesor
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti025_selectByPrefijoTableAdapter
            For Each esp As dsbAlcoIngenieria.sp_ti025_selectByPrefijoRow In taAll.GetData(prefijo).Rows
                TraerxPrefijo = (New Espesor(esp.Id, esp.UsuarioCreacion, esp.FechaCreacion, esp.Prefijo, esp.Descripcion, esp.FechaModificacion, esp.UsuarioCreacion, esp.Id_Estado, esp.Estado))

            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados asociados a un nombre
    ''' </summary>
    ''' <param name="Descripcion"></param>
    ''' <returns></returns>
    Public Function TraerxDescripcion(descripcion As String) As List(Of Espesor)
        TraerxDescripcion = New List(Of Espesor)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti025_selectByDescripcionTableAdapter
            For Each esp As dsbAlcoIngenieria.sp_ti025_selectByDescripcionRow In taAll.GetData(descripcion).Rows
                TraerxDescripcion.Add(New Espesor(esp.Id, esp.UsuarioCreacion, esp.FechaCreacion, esp.Prefijo, esp.Descripcion, esp.FechaModificacion, esp.UsuarioCreacion, esp.Id_Estado, esp.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

End Class

Public Class Espesor
    Inherits ClsBaseParametros
#Region "Variables"
    Private _prefijo As String = String.Empty
    Private _descripcion As String = String.Empty
#End Region

#Region "Propiedades"

    Public Property Prefijo As String
        Get
            Return _prefijo
        End Get
        Set(value As String)
            _prefijo = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, prefijo As String, descripcion As String,
                   fechamodificacion As Date, usuarioModificacion As String, id_estado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _prefijo = Trim(prefijo)
            _descripcion = Trim(descripcion)
            Me.UsuarioModificacion = usuarioModificacion
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = id_estado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

End Class
