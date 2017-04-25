Imports Datos
Public Class ClsUbicacionMaterial
#Region "Variables"
    Private taUbicacionMaterial As New dsbAlcoIngenieriaTableAdapters.ti008_ubicacionmaterialTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva ubicación del material en la estructura
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, nombre As String, descripcion As String, prefijo As String, estado As Integer)
        Try
            taUbicacionMaterial.sp_ti008_insert(usuario, nombre, descripcion, prefijo, estado)
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
    ''' <param name="descripcion"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, nombre As String, descripcion As String, prefijo As String, estado As Integer)
        Try
            taUbicacionMaterial.sp_ti008_updateById(id, nombre, descripcion, prefijo, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas la ubicaciones de material registradas
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of UbicacionMaterial)
        TraerTodos = New List(Of UbicacionMaterial)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti008_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti008_selectAllDataTable = taAll.GetData()
            For Each opm As dsbAlcoIngenieria.sp_ti008_selectAllRow In txall.Rows
                TraerTodos.Add(New UbicacionMaterial(opm.Id, opm.Usuario_Creacion, opm.Fecha_Creacion, opm.Prefijo, opm.Nombre, opm.Descripcion, opm.Usuario_Modifiacion, opm.Fecha_Modificacion, opm.Id_Estado, opm.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las ubicaciones de material filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As UbicacionMaterial
        TraerxId = New UbicacionMaterial
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti008_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti008_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim opm As dsbAlcoIngenieria.sp_ti008_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti008_selectByIdRow)
                TraerxId = New UbicacionMaterial(opm.Id, opm.Usuario_Creacion, opm.Fecha_Creacion, opm.Prefijo, opm.Nombre, opm.Descripcion, opm.Usuario_Modifiacion, opm.Fecha_Modificacion, opm.Id_Estado, opm.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


    Public Function TraerxEstado(estado As Integer) As List(Of UbicacionMaterial)
        TraerxEstado = New List(Of UbicacionMaterial)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti008_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti008_selectByEstadoDataTable = taAll.GetData(estado)
            For Each opm As dsbAlcoIngenieria.sp_ti008_selectByEstadoRow In txall.Rows
                TraerxEstado.Add(New UbicacionMaterial(opm.Id, opm.Usuario_Creacion, opm.Fecha_Creacion, opm.Prefijo, opm.Nombre, opm.Descripcion, opm.Usuario_Modifiacion, opm.Fecha_Modificacion, opm.Id_Estado, opm.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class UbicacionMaterial
    Inherits ClsBaseParametros
#Region "Variables"
    Private _prefijo As String = String.Empty
    Private _nombre As String = String.Empty
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, prefijo As String, nombre As String, descripcion As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = usuariocreacion
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
            _prefijo = Trim(prefijo)
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
