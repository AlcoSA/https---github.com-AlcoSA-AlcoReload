Imports Datos

Public Class ClsTiposOrdenesTrabajo
#Region "Variables"
    Private taTiposOrdenes As New dsAlcoComercial2TableAdapters.tc095_tiposOrdenesTrabajoTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, descripcion As String, idEstado As Integer)
        Try
            taTiposOrdenes.Insert(usuario, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(descripcion As String, usuario As String, idEstado As Integer, id As Integer)
        Try
            taTiposOrdenes.Update(descripcion, usuario, idEstado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tipoOrdenTrabajo)
        Try
            TraerTodos = New List(Of tipoOrdenTrabajo)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc095_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc095_selectAllDataTable = taAll.GetData()
            For Each tot As dsAlcoComercial2.sp_tc095_selectAllRow In txAll
                TraerTodos.Add(New tipoOrdenTrabajo(tot.id, tot.fechaCreacion, tot.usuarioCreacion, tot.descripcion,
                                                    tot.usuarioModi, tot.fechaModi, tot.idEstado, tot.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteRegistro(descripcion As String) As Boolean
        Try
            Dim list As List(Of tipoOrdenTrabajo) = TraerTodos().Where(Function(a) a.Descripcion = descripcion).ToList
            If list.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class tipoOrdenTrabajo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, descripcion As String,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _descripcion = descripcion
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class