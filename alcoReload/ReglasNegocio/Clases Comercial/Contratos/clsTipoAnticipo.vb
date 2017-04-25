Imports Datos

Public Class clsTipoAnticipo
#Region "Variables"
    Private _objTipoAnticipo As dsAlcoContratosTableAdapters.tc056_tipoAnticipoTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
    Public Sub insert(fc056_fechaCreacion As DateTime, fc056_usuarioCreacion As String, fc056_nombre As String,
                                    fc056_descripcion As String, fc056_usuarioModi As String, fc056_fechaModi As DateTime, fc056_rowidEstado As Integer)
        Try
            _objTipoAnticipo = New dsAlcoContratosTableAdapters.tc056_tipoAnticipoTableAdapter
            _objTipoAnticipo.Insert(fc056_fechaCreacion, fc056_usuarioCreacion, fc056_nombre,
                                    fc056_descripcion, fc056_usuarioModi, fc056_fechaModi, fc056_rowidEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Update(id As Integer, nombre As String, descripcion As String, usuarioModi As String, idEstado As Integer)
        Try
            _objTipoAnticipo = New dsAlcoContratosTableAdapters.tc056_tipoAnticipoTableAdapter
            _objTipoAnticipo.sp_tc056_update(id, nombre, descripcion, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function selectAll(Optional ByRef tb As DataTable = Nothing) As List(Of TipoAnticipos)
        selectAll = New List(Of TipoAnticipos)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc056_selectAllTableAdapter
            Dim tabla As dsAlcoContratos.sp_tc056_selectAllDataTable = ta.GetData()
            For Each item As dsAlcoContratos.sp_tc056_selectAllRow In tabla.Rows
                selectAll.Add(New TipoAnticipos(item.Id, item.FechaCreacion, item.UsuarioCreacion, item.Nombre, item.Descripcion, item.UsuarioModi, item.FechaModi, item.IdEstado, item.Estado))
            Next
            tb = If(tabla.Rows.Count > 0, tabla.CopyToDataTable, Nothing)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class TipoAnticipos : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set

    End Property
    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Sub New(Id As Integer, FechaCreacion As DateTime, UsuarioCreacion As String, nombre As String,
           descripcion As String, UsuarioModi As String, FechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.id = Id
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = UsuarioCreacion
            _nombre = RTrim(nombre)
            _descripcion = RTrim(descripcion)
            Me.UsuarioModificacion = RTrim(UsuarioModi)
            Me.FechaModificacion = FechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
