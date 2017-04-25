Imports Datos
Public Class ClsCaracteristicasAdicionales
#Region "Variables"
    Private tacaracteristicasadicionales As New dsbAlcoIngenieriaTableAdapters.ti023_caracteristicasadicionalesTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva característica adicional al sistema
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, prefijo As String, descripcion As String, estado As Integer)
        Try
            tacaracteristicasadicionales.sp_ti023_insert(usuario, prefijo, descripcion, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar una característica adicional en el sistema
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, prefijo As String, descripcion As String, estado As Integer)
        Try
            tacaracteristicasadicionales.sp_ti023_updateById(prefijo, descripcion, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las características adicionales registradas en el sistema
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of CaracteristicaAdicional)
        TraerTodos = New List(Of CaracteristicaAdicional)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti023_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti023_selectAllDataTable = taAll.GetData()
            For Each ca As dsbAlcoIngenieria.sp_ti023_selectAllRow In txall.Rows
                TraerTodos.Add(New CaracteristicaAdicional(ca.Id, ca.Usuario_Creacion, ca.Fecha_Creacion, ca.Prefijo, ca.Descripcion, ca.Usuario_Modificacion, ca.Fecha_Modificacion, ca.Id_Estado, ca.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener características adicionales filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As CaracteristicaAdicional
        TraerxId = New CaracteristicaAdicional
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti023_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti023_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim ca As dsbAlcoIngenieria.sp_ti023_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti023_selectByIdRow)
                TraerxId = New CaracteristicaAdicional(ca.Id, ca.Usuario_Creacion, ca.Fecha_Creacion, ca.Prefijo, ca.Descripcion, ca.Usuario_Modificacion, ca.Fecha_Modificacion, ca.Id_Estado, ca.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Funcion que devuelve una lista de las características adicionales según su estado
    ''' </summary>
    ''' <param name="estado">Valor del estado [Activo=1, Inactivo=2]</param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of CaracteristicaAdicional)
        TraerxEstado = New List(Of CaracteristicaAdicional)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti023_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti023_selectByEstadoDataTable = taAll.GetData(estado)
            For Each ca As dsbAlcoIngenieria.sp_ti023_selectByEstadoRow In txall.Rows
                TraerxEstado.Add(New CaracteristicaAdicional(ca.Id, ca.Usuario_Creacion, ca.Fecha_Creacion, ca.Prefijo, ca.Descripcion, ca.Usuario_Modificacion, ca.Fecha_Modificacion, ca.Id_Estado, ca.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class CaracteristicaAdicional
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, prefijo As String, descripcion As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
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
