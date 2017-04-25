Imports Datos
Public Class clsPolizas
#Region "Variables"
    Private _objPolizas As dsAlcoContratosTableAdapters.tc044_tipoPolizasTableAdapter

#End Region
#Region "Porpiedades"

#End Region
#Region "Procedimientos"
    Public Sub insert(usuarioCreacion As String, descripcion As String, porcentajeDefect As Decimal, idEstado As Integer)
        Try
            _objPolizas = New dsAlcoContratosTableAdapters.tc044_tipoPolizasTableAdapter
            _objPolizas.sp_tc044_insert(usuarioCreacion, descripcion, porcentajeDefect, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, descripcion As String, porcentajeDefect As Decimal, usuarioModi As String, idEstado As Integer)
        Try
            _objPolizas = New dsAlcoContratosTableAdapters.tc044_tipoPolizasTableAdapter
            _objPolizas.sp_tc044_update(id, descripcion, porcentajeDefect, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of poliza)

        Try
            traerTodos = New List(Of poliza)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc044_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc044_selectAllDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each _poliza As dsAlcoContratos.sp_tc044_selectAllRow In txAll
                    traerTodos.Add(New poliza(_poliza.Id, _poliza.FechaCreacion, _poliza.UsuarioCreacion, _poliza.Descripcion, _poliza.PorcentajeDefecto,
                                          _poliza.UsuarioModif, _poliza.FechaModi, _poliza.idEstado))
                Next
            End If

            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class poliza : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _decripcion As String
    Public Property descripcion() As String
        Get
            Return _decripcion
        End Get
        Set(ByVal value As String)
            _decripcion = value
        End Set
    End Property
    Private _porcentajeDefecto As Decimal
    Public Property porcentajeDefecto() As Decimal
        Get
            Return _porcentajeDefecto
        End Get
        Set(ByVal value As Decimal)
            _porcentajeDefecto = value
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
    Sub New(Id As Integer, FechaCreacion As DateTime, UsuarioCreacion As String, Descripcion As String,
            PorcentajeDefecto As Decimal, UsuarioModi As String, FechaModi As DateTime, idEstado As Integer)
        Try
            Me.id = Id
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = Trim(UsuarioCreacion)
            _decripcion = Trim(Descripcion)
            _porcentajeDefecto = PorcentajeDefecto
            Me.FechaModificacion = FechaModi
            Me.UsuarioModificacion = Trim(UsuarioModi)
            Me.IdEstado = idEstado
            Me.Estado = Trim(Estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

End Class
