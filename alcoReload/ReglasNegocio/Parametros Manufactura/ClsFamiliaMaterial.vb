Imports Datos
Public Class ClsFamiliaMaterial
#Region "Variables"
    Private tafamiliaMaterial As New dsbAlcoIngenieriaTableAdapters.ti003_familiamaterialTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para ingresar una nueva familia de materiales
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="famialiaMaterial"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, famialiaMaterial As String, prefijo As String,
                         estado As Integer)
        Try
            tafamiliaMaterial.sp_ti003_insert(usuario, famialiaMaterial, prefijo, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar las familias de materiales registradas
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="famialiaMaterial"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, famialiaMaterial As String,
                         prefijo As String, estado As Integer)
        Try
            tafamiliaMaterial.sp_ti003_updateById(id, famialiaMaterial, prefijo, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las familias de materiales resgistradas
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of FamiliaMaterial)
        TraerTodos = New List(Of FamiliaMaterial)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti003_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti003_selectAllDataTable = taAll.GetData()
            For Each fm As dsbAlcoIngenieria.sp_ti003_selectAllRow In txall.Rows
                TraerTodos.Add(New FamiliaMaterial(fm.Id, fm.Usuario_Creacion, fm.Fecha_Creacion, fm.Prefijo,
                                                   fm.Familia_Materia, fm.Usuario_Modificacion, fm.Fecha_Modifiacion,
                                                   fm.Id_Estado, fm.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las familias de materiales filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As FamiliaMaterial
        TraerxId = New FamiliaMaterial
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti003_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti003_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim fm As dsbAlcoIngenieria.sp_ti002_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti002_selectByIdRow)
                TraerxId = New FamiliaMaterial(fm.Id, fm.Usuario_Creacion, fm.Fecha_Creacion, fm.Prefijo,
                                                   fm.Familia, fm.Usuario_Modifiacion, fm.Fecha_Modificacion,
                                                   fm.Id_Estado, fm.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las familias de materiales asociadas a un estado
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function TraexEstado(estado As Integer) As List(Of FamiliaMaterial)
        TraexEstado = New List(Of FamiliaMaterial)
        Try
            Dim taEstado As New dsbAlcoIngenieriaTableAdapters.sp_ti003_selectByEstadoTableAdapter
            Dim txEstado As dsbAlcoIngenieria.sp_ti003_selectByEstadoDataTable = taEstado.GetData(estado)
            For Each fm As dsbAlcoIngenieria.sp_ti003_selectByEstadoRow In txEstado.Rows
                TraexEstado.Add(New FamiliaMaterial(fm.Id, fm.Usuario_Creacion, fm.Fecha_Creacion, fm.Prefijo,
                                                   fm.Familia_Materia, fm.Usuario_Modificacion, fm.Fecha_Modifiacion,
                                                   fm.Id_Estado, fm.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class FamiliaMaterial
    Inherits ClsBaseParametros

#Region "Variables"

    Private _prefijo As String = String.Empty
    Private _familiamaterial As String = String.Empty

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

    Public Property FamiliaMaterial As String
        Get
            Return _familiamaterial
        End Get
        Set(value As String)
            _familiamaterial = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, prefijo As String, familiamaterial As String, usuariomodificacion As String, _
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _prefijo = Trim(prefijo)
            _familiamaterial = Trim(familiamaterial)
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
