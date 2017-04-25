Imports Datos
Public Class ClsDepartamentosAlco
#Region "Variables"
    Private tadepartamento As New dsGeneralesAplicacionTableAdapters.tg003_departamentosTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, departamento As String, descripcion As String, estado As Integer)
        Try
            tadepartamento.Insert(usuario, departamento, descripcion, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(departamento As String, descripcion As String, usuario As String, estado As Integer, id As Integer)
        Try
            tadepartamento.Update(departamento, descripcion, usuario, estado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of DepartamentoAlco)
        TraerTodos = New List(Of DepartamentoAlco)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg003_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg003_selectAllDataTable = ta.GetData()
            For Each d As dsGeneralesAplicacion.sp_tg003_selectAllRow In tb.Rows
                TraerTodos.Add(New DepartamentoAlco(d.Id, d.Fecha_creacion, d.Usuario_creacion, d.Departamento, d.Descripcion, d.Fecha_modificacion,
                                                    d.Usuario_modificacion, d.Id_estado, d.Estado))
            Next
            tabla = tb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporEstado(estado As Integer) As List(Of DepartamentoAlco)
        TraerporEstado = New List(Of DepartamentoAlco)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg003_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg003_selectAllRow() = ta.GetData().Where(Function(x) x.Id_estado = estado).ToArray()
            For Each d As dsGeneralesAplicacion.sp_tg003_selectAllRow In tb
                TraerporEstado.Add(New DepartamentoAlco(d.Id, d.Fecha_creacion, d.Usuario_creacion, d.Departamento, d.Descripcion, d.Fecha_modificacion,
                                                    d.Usuario_modificacion, d.Id_estado, d.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class DepartamentoAlco
    Inherits ClsBaseParametros
#Region "Variables"
    Private _departamento As String
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property Departamento As String
        Get
            Return _departamento
        End Get
        Set(value As String)
            _departamento = value
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

    End Sub

    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
               departamento As String, descripcion As String, fechamodificacion As DateTime, usuariomodificacion As String,
               idestado As Integer, estado As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = Trim(usuariocreacion)
        _departamento = Trim(departamento)
        _descripcion = Trim(descripcion)
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = Trim(usuariomodificacion)
        Me.IdEstado = idestado
        Me.Estado = Trim(estado)
    End Sub

#End Region
End Class
