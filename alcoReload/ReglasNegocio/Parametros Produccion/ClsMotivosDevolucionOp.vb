Imports Datos
Public Class ClsMotivosDevolucionOp
#Region "Variables"
    Private _objMovitoDescuento As New dsAlcoProduccionTableAdapters.tp010_motivosDevolucionTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(motivo As String, usuario As String, estado As Integer) As Integer
        Try
            Return _objMovitoDescuento.Insert(usuario, motivo, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, motivo As String, usuario As String, estado As Integer)
        Try
            _objMovitoDescuento.Update(motivo, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(ByRef Optional tb As DataTable = Nothing) As List(Of MotivoDevolucionOp)
        Try
            TraerTodos = New List(Of MotivoDevolucionOp)
            Dim ta As dsAlcoProduccion.tp010_motivosDevolucionDataTable = _objMovitoDescuento.GetData()
            ta.Rows.Cast(Of dsAlcoProduccion.tp010_motivosDevolucionRow).ToList.ForEach(
            Sub(mv)
                TraerTodos.Add(New MotivoDevolucionOp(mv.id, mv.Motivo, mv.usuario_creacion,
                                                      mv.fecha_creacion, mv.usuario_modificacion,
                                                      mv.fecha_modificacion, mv.id_estado,
                                                      mv.estado))
            End Sub)
            If ta.Count > 0 Then
                tb = ta.CopyToDataTable()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporEstado(estado As Integer) As List(Of MotivoDevolucionOp)
        Try
            TraerporEstado = New List(Of MotivoDevolucionOp)
            TraerporEstado.AddRange(TraerTodos().Where(Function(x) x.IdEstado = estado).ToArray())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class MotivoDevolucionOp : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _descripcion As String
    Public Property Descripcion() As String
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
    Public Sub New(id As Integer, descripcion As String, usuarioCreacion As String,
                   fechaCreacion As DateTime, usuariomodificacion As String,
                   fechamodificacion As DateTime, idestado As Integer, estado As String)
        Try
            Me.Id = id
            _descripcion = descripcion.Trim
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = usuariomodificacion
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
