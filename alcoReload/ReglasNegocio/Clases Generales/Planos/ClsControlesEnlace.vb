Imports Datos
Public Class ClsControlesEnlace
#Region "Variables"
    Private taforms As New dsGeneralesAplicacionTableAdapters.tg013_controlesenlaceconectoresTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, control As String, idestado As Integer)
        Try
            taforms.sp_tg013_insert(usuario, control, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, usuario As String, control As String, idestado As Integer)
        Try
            taforms.sp_tg013_update(id, usuario, control, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(Optional ByRef tb As DataTable = Nothing) As List(Of ControlEnlace)
        TraerTodos = New List(Of ControlEnlace)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg013_selectAllTableAdapter
            Dim dt As dsGeneralesAplicacion.sp_tg013_selectAllDataTable = ta.GetData()
            If dt.Rows.Count > 0 Then
                dt.Rows.Cast(Of dsGeneralesAplicacion.sp_tg013_selectAllRow).ToList.ForEach(Sub(r)
                                                                                                TraerTodos.Add(New ControlEnlace(r.Id, r.UsuarioCreacion, r.FechaCreacion,
                                                                                                                              r.Control, r.UsuarioModificacion, r.FechaModificacion, r.Id_Estado,
                                                                                                                              r.Estado))
                                                                                            End Sub)
                tb = dt.Copy()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerporIdEstado(idestado As Integer) As List(Of ControlEnlace)
        TraerporIdEstado = New List(Of ControlEnlace)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg013_selectByEstadoTableAdapter
            Dim dt As dsGeneralesAplicacion.sp_tg013_selectByEstadoDataTable = ta.GetData(idestado)
            If dt.Rows.Count > 0 Then
                dt.Rows.Cast(Of dsGeneralesAplicacion.sp_tg013_selectByEstadoRow).ToList.ForEach(Sub(r)
                                                                                                     TraerporIdEstado.Add(New ControlEnlace(r.Id, r.UsuarioCreacion, r.FechaCreacion,
                                                                                                                              r.Control, r.UsuarioModificacion, r.FechaModificacion, r.Id_Estado,
                                                                                                                              r.Estado))
                                                                                                 End Sub)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class ControlEnlace
    Inherits ClsBaseParametros
#Region "Variables"
    Private _control As String
#End Region
#Region "Propiedades"
    Public Property Control As String
        Get
            Return _control
        End Get
        Set(value As String)
            _control = value
        End Set
    End Property
#End Region
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As DateTime,
                   control As String, usuariomodificacion As String, fechamodificacion As DateTime,
                   idestado As Integer, estado As String)
        Me.Id = id
        Me.UsuarioCreacion = usuariocreacion
        Me.FechaCreacion = fechacreacion
        _control = control
        Me.UsuarioModificacion = usuariomodificacion
        Me.FechaModificacion = fechamodificacion
        Me.IdEstado = idestado
        Me.Estado = estado
    End Sub
End Class
