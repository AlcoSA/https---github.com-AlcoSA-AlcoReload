Imports Datos
Public Class clsAseguradoras
#Region "Variables"
    Private _objAseguradora As dsAlcoContratosTableAdapters.tc045_aseguradorasTableAdapter

#End Region
#Region "Porpiedades"

#End Region
#Region "Procedimientos"
    Public Sub insert(usuarioCreacion As String, nit As String, razonSocial As String, idEstado As Integer)
        Try
            _objAseguradora = New dsAlcoContratosTableAdapters.tc045_aseguradorasTableAdapter
            _objAseguradora.sp_tc045_insert(usuarioCreacion, nit, razonSocial, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, nit As String, razonSocial As String, usuarioModi As String, idEstado As Integer)
        Try
            _objAseguradora = New dsAlcoContratosTableAdapters.tc045_aseguradorasTableAdapter
            _objAseguradora.sp_tc045_update(id, nit, razonSocial, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of aseguradora)

        Try
            traerTodos = New List(Of aseguradora)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc045_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc045_selectAllDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each _aseguradora As dsAlcoContratos.sp_tc045_selectAllRow In txAll
                    traerTodos.Add(New aseguradora(_aseguradora.Id, _aseguradora.FechaCreacion, _aseguradora.UsuarioCreacion, _aseguradora.Nit,
                                                   _aseguradora.RazonSocial, _aseguradora.UsuarioModif, _aseguradora.FechaModi, _aseguradora.idEstado, _aseguradora.Estado))
                Next
            End If

            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class aseguradora : Inherits ClsBaseParametros
#Region "Propiedades"
       Private _nit As String
    Public Property nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Private _razonSocial As String
    Public Property razonSocial() As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal value As String)
            _razonSocial = value
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
    Sub New(Id As Integer, FechaCreacion As DateTime, UsuarioCreacion As String, nit As String,
            razonSocial As String, UsuarioModi As String, FechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.id = Id
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = UsuarioCreacion
            _nit = RTrim(nit)
            _razonSocial = RTrim(razonSocial)
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

