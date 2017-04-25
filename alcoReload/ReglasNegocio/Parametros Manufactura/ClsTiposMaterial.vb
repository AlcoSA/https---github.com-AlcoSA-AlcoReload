Imports Datos
Public Class ClsTiposMaterial
#Region "Variables"
    Private tatiposmaterial As New dsbAlcoIngenieriaTableAdapters.ti022_tipomaterialTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para ingresar un nuevo tipo de material
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, nombre As String, estado As Integer)
        Try
            tatiposmaterial.sp_ti022_insert(usuario, nombre, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar un tipo de material registrado
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, nombre As String, estado As Integer)
        Try
            tatiposmaterial.sp_ti022_updateById(nombre, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los tipos de material
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of TipoMaterial)
        TraerTodos = New List(Of TipoMaterial)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti022_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti022_selectAllDataTable = taAll.GetData()
            For Each tm As dsbAlcoIngenieria.sp_ti022_selectAllRow In txall.Rows
                TraerTodos.Add(New TipoMaterial(tm.Id, tm.Usuario_Creacion, tm.Fecha_Creacion,
                                                tm.Nombre, tm.Usuario_Modificacion, tm.Fecha_Modificacion,
                                                tm.Id_Estado, tm.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener tipos de material filtrados por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As TipoMaterial
        TraerxId = New TipoMaterial()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti022_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti022_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim tm As dsbAlcoIngenieria.sp_ti022_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti022_selectByIdRow)
                TraerxId = New TipoMaterial(tm.Id, tm.Usuario_Creacion, tm.Fecha_Creacion,
                                                tm.Nombre, tm.Usuario_Modificacion, tm.Fecha_Modificacion,
                                                tm.Id_Estado, tm.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    '''Este procedimiento sirve para obtener tipos de material asociados a un estado
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of TipoMaterial)
        TraerxEstado = New List(Of TipoMaterial)()
        Try
            Dim taEstado As New dsbAlcoIngenieriaTableAdapters.sp_ti022_selectByEstadoTableAdapter
            Dim txEstado As dsbAlcoIngenieria.sp_ti022_selectByEstadoDataTable = taEstado.GetData(estado)
            For Each tm As dsbAlcoIngenieria.sp_ti022_selectByEstadoRow In txEstado.Rows
                TraerxEstado.Add(New TipoMaterial(tm.Id, tm.Usuario_Creacion, tm.Fecha_Creacion,
                                                tm.Nombre, tm.Usuario_Modificacion, tm.Fecha_Modificacion,
                                                tm.Id_Estado, tm.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para validar la información ingresada
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <param name="mensaje"></param>
    ''' <returns></returns>
    Public Function ValidarDatos(nombre As String, ByRef mensaje As String) As Boolean
        Try
            If String.IsNullOrEmpty(nombre) Then
                mensaje = "El nombre del tipo, es un dato obligatorio. Verifique la información"
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class TipoMaterial
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
