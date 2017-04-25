Imports Datos
Public Class clsTipoEscritura
#Region "Variables"
    Private _objAseguradora As dsAlcoContratosTableAdapters.tc048_TiposEscriturasTableAdapter

#End Region
#Region "Porpiedades"

#End Region
#Region "Procedimientos"
    Public Sub insert(usuarioCreacion As String, descripcion As String, idEstado As Integer)
        Try
            _objAseguradora = New dsAlcoContratosTableAdapters.tc048_TiposEscriturasTableAdapter
            _objAseguradora.sp_tc048_insert(usuarioCreacion, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, descripcion As String, usuarioModi As String, idEstado As Integer)
        Try
            _objAseguradora = New dsAlcoContratosTableAdapters.tc048_TiposEscriturasTableAdapter
            _objAseguradora.sp_tc048_update(id, descripcion, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tipoEscritura)

        Try
            traerTodos = New List(Of tipoEscritura)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc048_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc048_selectAllDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each _tipoEscritura As dsAlcoContratos.sp_tc048_selectAllRow In txAll
                    traerTodos.Add(New tipoEscritura(_tipoEscritura.Id, _tipoEscritura.FechaCreacion, _tipoEscritura.UsuarioCreacion, _tipoEscritura.Descripcion,
                                                    _tipoEscritura.usuarioModif, _tipoEscritura.FechaModi, _tipoEscritura.IdEstado, _tipoEscritura.Estado))
                Next
            End If
            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class tipoEscritura : Inherits ClsBaseParametros
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
    Private _usuarioModi As String
    Public Property usuarioModi() As String
        Get
            Return _usuarioModi
        End Get
        Set(ByVal value As String)
            _usuarioModi = value
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
    Sub New(Id As Integer, FechaCreacion As DateTime, UsuarioCreacion As String,
            descripcion As String, UsuarioModi As String, FechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = Id
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = UsuarioCreacion
            _descripcion = RTrim(descripcion)
            _usuarioModi = RTrim(UsuarioModi)
            Me.FechaModificacion = FechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

End Class


