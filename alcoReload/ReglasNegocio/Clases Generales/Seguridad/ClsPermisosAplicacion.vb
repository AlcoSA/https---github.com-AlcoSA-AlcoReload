Imports Datos
Public Class ClsPermisosAplicacion
#Region "Variables"
    Private tapermiso As New dsGeneralesAplicacionTableAdapters.tg005_permisosAplicacionTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, codigo As String, permiso As String, idcontenedor As Integer, estado As Integer) As Integer
        Try
            Dim a = tapermiso.Insert(usuario, codigo, permiso, idcontenedor, usuario, estado)
            Return a
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(codigo As String, permiso As String, idcontendor As Integer, usuario As String, estado As Integer, id As Integer)
        Try
            tapermiso.Update(codigo, permiso, idcontendor, usuario, estado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos() As List(Of Permiso)
        TraerTodos = New List(Of Permiso)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg003_selectAllTableAdapter
            Dim tb As dsGeneralesAplicacion.tg005_permisosAplicacionDataTable = tapermiso.GetData()
            For Each p As dsGeneralesAplicacion.tg005_permisosAplicacionRow In tb.Rows
                TraerTodos.Add(New Permiso(p.fi005_rowid, p.fi005_fechacreacion, p.fi005_usuariocreacion, p.fi005_modulo, p.fi005_codigo,
                                           p.fi005_idcontenedor, p.fi005_fechamodificacion, p.fi005_usuariomodificacion, p.fi005_rowidestado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    'Public Function TraerporEstado(estado As Integer) As List(Of DepartamentoAlco)
    '    TraerporEstado = New List(Of DepartamentoAlco)
    '    Try
    '        Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg003_selectAllTableAdapter
    '        Dim tb As dsGeneralesAplicacion.sp_tg003_selectAllRow() = ta.GetData().Where(Function(x) x.Id_estado = estado).ToArray()
    '        For Each d As dsGeneralesAplicacion.sp_tg003_selectAllRow In tb
    '            TraerporEstado.Add(New DepartamentoAlco(d.Id, d.Fecha_creacion, d.Usuario_creacion, d.Departamento, d.Descripcion, d.Fecha_modificacion,
    '                                                d.Usuario_modificacion, d.Id_estado, d.Estado))
    '        Next
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Function
#End Region
End Class

Public Class Permiso
    Inherits ClsBaseParametros
#Region "Variables"
    Private _permiso As String
    Private _codigo As String
    Private _idcontenedor As Integer
#End Region
#Region "Propiedades"
    Public Property Permiso As String
        Get
            Return _permiso
        End Get
        Set(value As String)
            _permiso = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property
    Public Property IdContenedor As Integer
        Get
            Return _idcontenedor
        End Get
        Set(value As Integer)
            _idcontenedor = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub

    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
               permiso As String, codigo As String, idcontendor As Integer, fechamodificacion As DateTime, usuariomodificacion As String,
               idestado As Integer, estado As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = Trim(usuariocreacion)
        _permiso = Trim(permiso)
        _codigo = Trim(codigo)
        _idcontenedor = idcontendor
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = Trim(usuariomodificacion)
        Me.IdEstado = idestado
        Me.Estado = Trim(estado)
    End Sub

#End Region
End Class
