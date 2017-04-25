Imports Datos
Imports Datos.dsAlcoContratosTableAdapters

Public Class clsObjetosContratos

#Region "Variables"
    Private _objObjetos As dsAlcoContratosTableAdapters.tc041_objetosContratosTableAdapter
#End Region

#Region "Procedimientos"
    Public Sub insert(usuarioCreacion As String, descripcion As String, idEstado As Integer)
        Try
            _objObjetos = New dsAlcoContratosTableAdapters.tc041_objetosContratosTableAdapter
            _objObjetos.sp_tc041_insert(usuarioCreacion, descripcion, idEstado, usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, descripcion As String, usuarioModi As String, idEstado As Integer)
        Try
            _objObjetos = New dsAlcoContratosTableAdapters.tc041_objetosContratosTableAdapter
            _objObjetos.sp_tc041_update(id, descripcion, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of objetoContrato)
        Try
            traerTodos = New List(Of objetoContrato)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc041_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc041_selectAllDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each _objeto As dsAlcoContratos.sp_tc041_selectAllRow In txAll
                    traerTodos.Add(New objetoContrato(_objeto.Id, _objeto.Descripcion, _objeto.FechaCreacion, _objeto.UsuarioCreacion, _objeto.usuarioModif, _objeto.FechaModi, _objeto.IdEstado, _objeto.Estado))
                Next
            End If
            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class objetoContrato : Inherits ClsBaseParametros
#Region "Propiedades"
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
    Sub New(Id As Integer, descripcion As String, FechaCreacion As DateTime, UsuarioCreacion As String,
            UsuarioModi As String, FechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = Id
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = RTrim(UsuarioCreacion)
            Me.FechaModificacion = FechaModi
            Me.UsuarioModificacion = RTrim(UsuarioModi)
            _descripcion = RTrim(descripcion)
            Me.IdEstado = idEstado
            Me.Estado = RTrim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class