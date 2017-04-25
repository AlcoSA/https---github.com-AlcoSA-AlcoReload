Imports Datos
Public Class ClsModulosPermisoExtra
#Region "Variables"
    Private tamod As New dsGeneralesAplicacionTableAdapters.tg009_modulopermisoextraTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, modulo As String,
                        descripcionmodulo As String, codigo As String, idestado As Integer) As Integer
        Try
            Return tamod.Insert(usuario, modulo, descripcionmodulo, codigo, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(usuario As String, modulo As String,
                    descripcionmodulo As String, codigo As String, idestado As Integer, id As Integer)
        Try
            tamod.Update(modulo, descripcionmodulo, codigo, usuario, idestado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

#Region "Funciones"

    Public Function TraerTodosTabla() As DataTable
        Try
            Dim tam As New dsGeneralesAplicacionTableAdapters.sp_tg009_selectAllTableAdapter
            Return tam.GetData().Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerTodosLista() As List(Of ModuloPermisoExtra)
        TraerTodosLista = New List(Of ModuloPermisoExtra)
        Try
            Dim tam As New dsGeneralesAplicacionTableAdapters.sp_tg009_selectAllTableAdapter
            Dim t As dsGeneralesAplicacion.sp_tg009_selectAllDataTable = tam.GetData()
            For Each mp As dsGeneralesAplicacion.sp_tg009_selectAllRow In t.Rows
                TraerTodosLista.Add(New ModuloPermisoExtra(mp.Id, mp.Usuario_creacion, mp.Fecha_creacion, mp.Modulo,
                                                            mp.Descripcion, mp.Codigo, mp.Fecha_modificacion, mp.Usuario_modificacion, mp.Id_estado,
                                                            mp.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

End Class

Public Class ModuloPermisoExtra
    Inherits ClsBaseParametros
#Region "Variables"
    Private _modulo As String
    Private _descripcionmodulo As String
    Private _codigo As String
#End Region
#Region "Propiedades"
    Public Property Modulo As String
        Get
            Return _modulo
        End Get
        Set(value As String)
            _modulo = value
        End Set
    End Property
    Public Property DescripcionModulo As String
        Get
            Return _descripcionmodulo
        End Get
        Set(value As String)
            _descripcionmodulo = value
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
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date,
                   modulo As String, descripcionmodulo As String, codigo As String,
                   fechamodificacion As Date, usuarioModificacion As String,
                   id_estado As Integer, estado As String)
        Me.Id = id
        Me.UsuarioCreacion = usuariocreacion
        Me.FechaCreacion = fechacreacion
        _modulo = Trim(modulo)
        _descripcionmodulo = Trim(descripcionmodulo)
        _codigo = Trim(codigo)
        Me.UsuarioModificacion = Trim(usuarioModificacion)
        Me.FechaModificacion = fechamodificacion
        Me.IdEstado = id_estado
        Me.Estado = Trim(estado)
    End Sub
#End Region
End Class
