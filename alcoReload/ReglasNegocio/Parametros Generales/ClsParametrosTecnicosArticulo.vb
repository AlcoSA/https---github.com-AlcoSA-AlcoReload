Imports Datos
Public Class ClsParametrosTecnicosArticulo

#Region "Variables"
    Private taparam As New dsbAlcoIngenieriaTableAdapters.ti029_parametrosTecnicosArticuloTableAdapter
#End Region

#Region "Procedimientos"

    Public Sub Ingresar(usuario As String, nombre As String, descripcion As String, estado As Integer)
        Try
            taparam.sp_ti029_insert(usuario, nombre, descripcion, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modifcar(id As Integer, usuario As String, nombre As String, descripcion As String, estado As Integer)
        Try
            taparam.sp_ti029_update(id, usuario, nombre, descripcion, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of ParametrosTecnicosArticulo)
        TraerTodos = New List(Of ParametrosTecnicosArticulo)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti029_selectAllTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti029_selectAllDataTable = taAll.GetData()
            For Each pta As dsbAlcoIngenieria.sp_ti029_selectAllRow In txAll
                TraerTodos.Add(New ParametrosTecnicosArticulo(pta.Id, pta.Usuario_Creacion, pta.Fecha_Creacion, pta.Nombre,
                                                              pta.Descripcion, pta.Usuario_Modi, pta.Fecha_Modi, pta.Id_Estado, pta.Estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdEstado(idestado As Integer) As List(Of ParametrosTecnicosArticulo)
        TraerxIdEstado = New List(Of ParametrosTecnicosArticulo)()
        Try
            Dim txall As dsbAlcoIngenieria.ti029_parametrosTecnicosArticuloDataTable = taparam.TraerporEstado(idestado)
            For Each pta As dsbAlcoIngenieria.ti029_parametrosTecnicosArticuloRow In txall.Rows
                TraerxIdEstado.Add(New ParametrosTecnicosArticulo(pta.fi029_rowid, pta.fi029_usuariocreacion,
                                                              pta.fi029_fechacreacion, pta.fi029_nombre,
                                                              pta.fi029_descripcion, pta.fi029_usuariomodificacion,
                                                              pta.fi029_fechamodificacion, pta.fi029_rowidestado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class

Public Class ParametrosTecnicosArticulo
    Inherits ClsBaseParametros
#Region "Variables"

    Private _nombre As String
    Private _descripcion As String
#End Region
#Region "Propiedades"

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, nombre As String,
                   descripcion As String, usuariomodificacion As String, fechamodificacion As Date,
                   idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
            _descripcion = Trim(descripcion)
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class