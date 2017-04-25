Imports Datos
Public Class ClsAdjuntosContratos
#Region "Variables"
    Private _objAdjuntoCotrato As dsAlcoContratosTableAdapters.tc068_adjuntoscontratosTableAdapter
#End Region
#Region "Procedimientos"

    Public Sub Insert(idcontrato As Integer, ruta As String, usuarioCreacion As String)
        Try
            _objAdjuntoCotrato = New dsAlcoContratosTableAdapters.tc068_adjuntoscontratosTableAdapter
            _objAdjuntoCotrato.sp_tc068_insert(idcontrato, ruta, 1, usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, idcontrato As Integer, ruta As String, version As Integer, usuarioCreacion As String)
        Try
            _objAdjuntoCotrato = New dsAlcoContratosTableAdapters.tc068_adjuntoscontratosTableAdapter
            _objAdjuntoCotrato.sp_tc068_update(id, idcontrato, ruta, version, usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
#Region "funciones"

    Public Function TraerTodas() As List(Of adjuntoContrato)
        TraerTodas = New List(Of adjuntoContrato)
        Try
            Dim txa As New dsAlcoContratosTableAdapters.sp_tc068_selectAllTableAdapter
            Dim tb As dsAlcoContratos.sp_tc068_selectAllDataTable = txa.GetData
            If tb.Rows.Count > 0 Then
                For Each _archivo As dsAlcoContratos.sp_tc068_selectAllRow In tb
                    TraerTodas.Add(New adjuntoContrato(_archivo.id, _archivo.idContrato, _archivo.Ruta, _archivo.UltFechaModi, _archivo.UltUsuarioModi))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerTodasxIdcontrato(idcontrato As Integer) As List(Of adjuntoContrato)
        TraerTodasxIdcontrato = New List(Of adjuntoContrato)
        Try
            TraerTodasxIdcontrato = TraerTodas().Where(Function(a) a.idContrato = idcontrato).ToList
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerUltimaxIdContrato(idcontrato As Integer) As List(Of adjuntoContrato)
        TraerUltimaxIdContrato = New List(Of adjuntoContrato)
        Try
            TraerUltimaxIdContrato.Add(TraerTodas.Find(Function(c) c.Id = TraerTodas().Where(Function(a) a.idContrato = idcontrato).Max(Function(b) b.Id)))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class
Public Class adjuntoContrato : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _ruta As String
    Public Property ruta() As String
        Get
            Return _ruta
        End Get
        Set(ByVal value As String)
            _ruta = value
        End Set
    End Property
    Private _idContrato As Integer
    Public Property idContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idContrato As Integer, ruta As String, fechaCreacion As DateTime, usuarioCreacion As String)
        Try
            Me.Id = id
            _idContrato = idContrato
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _ruta = ruta
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class

