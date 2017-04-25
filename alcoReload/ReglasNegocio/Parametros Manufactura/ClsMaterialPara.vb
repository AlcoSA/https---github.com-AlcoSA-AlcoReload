Imports Datos
Public Class ClsMaterialPara
#Region "Variables"
    Private tamaterialPara As New dsbAlcoIngenieriaTableAdapters.ti009_materialparaTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva ubicación del material
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, nombre As String, estado As Integer)
        Try
            tamaterialPara.sp_ti009_insert(usuario, nombre, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar la ubicación del material
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, nombre As String, estado As Integer)
        Try
            tamaterialPara.sp_ti009_updateById(id, nombre, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las unbicaciones de los materiales
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of MaterialPara)
        TraerTodos = New List(Of MaterialPara)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti009_selectAllTableAdapter
            For Each var As dsbAlcoIngenieria.sp_ti009_selectAllRow In taAll.GetData().Rows
                TraerTodos.Add(New MaterialPara(var.Id, var.Usuario_Creacion, var.Fecha_Creacion, var.Nombre, var.Usuario_Modifiacion,
                                                var.Fecha_Modificacion, var.Id_estado, var.Estado))
            Next
            If taAll.GetData().Rows.Count > 0 Then
                dt = taAll.GetData().CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las ubicaciones de los materiales filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As MaterialPara
        TraerxId = New MaterialPara
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti009_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti009_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim var As dsbAlcoIngenieria.sp_ti009_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti009_selectByIdRow)
                TraerxId = New MaterialPara(var.Id, var.Usuario_Creacion, var.Fecha_Creacion, var.Nombre, var.Usuario_Modifiacion,
                                                var.Fecha_Modificacion, var.Id_estado, var.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxEstado(estado As Integer) As List(Of MaterialPara)
        TraerxEstado = New List(Of MaterialPara)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti009_selectByEstadoTableAdapter
            For Each var As dsbAlcoIngenieria.sp_ti009_selectByEstadoRow In taAll.GetData(estado).Rows
                TraerxEstado.Add(New MaterialPara(var.Id, var.Usuario_Creacion, var.Fecha_Creacion, var.Nombre, var.Usuario_Modifiacion,
                                                var.Fecha_Modificacion, var.Id_estado, var.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class MaterialPara
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombre As String = String.Empty
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

#End Region

#Region "Constructor"

    Public Sub New()
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, nombre As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
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
