Imports Datos
Public Class clsCiudadesCamaraComercio
#Region "Variables"
    Private _objCamaraC As dsAlcoContratosTableAdapters.tc060_ciudadesCamaraComercioTableAdapter
#End Region
#Region "Porpiedades"

#End Region
#Region "Procedimientos"
    Public Sub insert(usuarioCreacion As String, descripcion As String, idEstado As Integer)
        Try
            _objCamaraC = New dsAlcoContratosTableAdapters.tc060_ciudadesCamaraComercioTableAdapter
            _objCamaraC.Insert(Now(), usuarioCreacion, descripcion, Now(), usuarioCreacion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, descripcion As String, usuarioModi As String, idEstado As Integer)
        Try
            _objCamaraC = New dsAlcoContratosTableAdapters.tc060_ciudadesCamaraComercioTableAdapter
            _objCamaraC.sp_tc060_update(descripcion, usuarioModi, idEstado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of objetoContrato)
        Try
            traerTodos = New List(Of objetoContrato)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc060_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc060_selectAllDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each _objeto As dsAlcoContratos.sp_tc060_selectAllRow In txAll
                    traerTodos.Add(New objetoContrato(_objeto.id, _objeto.Ciudad, _objeto.FechaCreacion, _objeto.UsuarioCreacion, _objeto.UsuarioModi, _objeto.FechaModi, _objeto.idEstado, _objeto.Estado))
                Next
            End If
            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
    Public Class camarasComercio : Inherits ClsBaseParametros
#Region "Propiedades"

        Private _usuarioModi As String
        Public Property usuarioModi() As String
            Get
                Return _usuarioModi
            End Get
            Set(ByVal value As String)
                _usuarioModi = value
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
        Sub New(Id As Integer, descripcion As String, FechaCreacion As DateTime, UsuarioCreacion As String,
            UsuarioModi As String, FechaModi As DateTime, idEstado As Integer, estado As String)
            Try
                Me.Id = Id
                Me.FechaCreacion = FechaCreacion
                Me.UsuarioCreacion = RTrim(UsuarioCreacion)
                Me.FechaModificacion = FechaModi
                _usuarioModi = RTrim(UsuarioModi)
                _descripcion = RTrim(descripcion)
                Me.IdEstado = idEstado
                Me.Estado = RTrim(estado)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Class
