Imports Datos
Public Class ClsEstados

#Region "Variables"

    Dim taEstados As New dsbAlcoIngenieriaTableAdapters.ti001_estadosTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para ingresar un nuevo estado
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="descripcion"></param>
    Public Sub Ingresar(usuarioCreacion As String, descripcion As String, valorPorDefecto As Integer, color As String)
        Try
            taEstados.sp_ti001_insert(usuarioCreacion, descripcion, valorPorDefecto, color)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los registros de los formularios existentes
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="usuarioModificacion"></param>
    Public Sub Modificar(id As Integer, descripcion As String, usuarioModificacion As String, valorPorDefecto As Integer, color As String)
        Try
            taEstados.sp_ti001_updateById(id, descripcion, usuarioModificacion, valorPorDefecto, color)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los estados registrados
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Estado)
        TraerTodos = New List(Of Estado)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti001_selectAllTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti001_selectAllDataTable = taAll.GetData()
            For Each est As dsbAlcoIngenieria.sp_ti001_selectAllRow In txAll
                TraerTodos.Add(New Estado(est.Id, est.Usuario_Creacion, est.Fecha_Creacion, est.Descripcion, est.Usuario_Modificacion,
                                          est.Fecha_Modificacion, est.valorPorDefecto, est.color))
            Next
            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los estados filtrados por un ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As Estado
        TraerxId = New Estado
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti001_selectByIdTableAdapter
            Dim txId As dsbAlcoIngenieria.sp_ti001_selectByIdDataTable = taxId.GetData(id)
            If txId.Rows.Count > 0 Then
                Dim est As dsbAlcoIngenieria.sp_ti001_selectByIdRow = DirectCast(txId.Rows(0), dsbAlcoIngenieria.sp_ti001_selectByIdRow)
                TraerxId = New Estado(est.Id, est.Usuario_Creacion, est.Fecha_Creacion, est.Descripcion, est.Usuario_Modificacion,
                                          est.Fecha_Modificacion, est.valorPorDefecto, est.color)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

End Class

Public Class Estado
    Inherits ClsBaseParametros

#Region "Variables"
    Private _descripcion As String = String.Empty
    Private _valorPorDefecto As Integer = 0
    Private _color As String = "white"
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
    Public Property valorPorDefecto As Integer
        Get
            Return _valorPorDefecto
        End Get
        Set(value As Integer)
            _valorPorDefecto = value
        End Set
    End Property
    Public Property Color As String
        Get
            Return _color
        End Get
        Set(value As String)
            _color = value
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
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, descripcion As String, usuariomodificacion As String,
                   fechamodificacion As Date, valorPorDefecto As Integer, color As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _descripcion = Trim(descripcion)
            _valorPorDefecto = valorPorDefecto
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            _color = color
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

End Class
