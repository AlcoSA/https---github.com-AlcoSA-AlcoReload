Imports Datos
Public Class clsPolizasContratos
#Region "Variables"
    Private _objPolizasContratoas As New dsAlcoContratosTableAdapters.tc046_ContratosPorcentajesPolizasTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub tc046_insert(usuarioCreacion As String, idContrato As Integer, idTipoPoliza As Integer, porcentaje As Decimal,
                            caduciada As String)
        Try
            _objPolizasContratoas.sp_tc046_insert(usuarioCreacion, idContrato, idTipoPoliza, porcentaje, caduciada,
                                                  usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub tc046_update(id As Integer, usuarioModi As String, idContrato As Integer, idTipoPoliza As Integer, porcentaje As Decimal,
                            caduciada As String, idEstado As Integer)
        Try
            _objPolizasContratoas.sp_tc046_update(id, idContrato, idTipoPoliza, porcentaje, caduciada, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarporIdContrato(idcontrato As Integer)
        Try
            _objPolizasContratoas.sp_tc046_deletebyIdContrato(idcontrato)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traerTodos() As List(Of polizasContratos)
        traerTodos = New List(Of polizasContratos)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc046_selectAllTableAdapter
            Dim td As dsAlcoContratos.sp_tc046_selectAllDataTable = ta.GetData()
            If td.Rows.Count() > 0 Then
                For Each fila As dsAlcoContratos.sp_tc046_selectAllRow In td.Rows
                    traerTodos.Add(New polizasContratos(fila.Id, fila.idContrato, fila.idTipoPoliza, fila.FechaCreacion,
                                                        fila.usuarioCreacion, fila.Porcentaje, fila.UsuarioModi, fila.FechaModi,
                                                        fila.idEstado, fila.Estado))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerById(id As Integer) As List(Of polizasContratos)
        traerById = New List(Of polizasContratos)
        Try
            traerById.AddRange(traerTodos().Where(Function(a) a.Id = id And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerByIdContrato(idContrato As Integer) As List(Of polizasContratos)
        traerByIdContrato = New List(Of polizasContratos)
        Try
            traerByIdContrato.AddRange(traerTodos().Where(Function(a) a.idContrato = idContrato And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerValoresMinuta(idcontrato As Integer) As DataTable
        TraerValoresMinuta = Nothing
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc046_ValoresMinutaTableAdapter
            TraerValoresMinuta = ta.GetData(idcontrato).Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub TraerTodosParaPoliza(ByRef dt As DataTable)
        Try
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc046_selectAllForPolizaTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc046_selectAllForPolizaDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class polizasContratos : Inherits poliza
#Region "Propiedades"
    Private _idContrato As Integer
    Public Property idContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Private _idTipoColiza As Integer
    Public Property idTipoPoliza() As Integer
        Get
            Return _idTipoColiza
        End Get
        Set(ByVal value As Integer)
            _idTipoColiza = value
        End Set
    End Property
    Private _porcentaje As Decimal
    Public Property Porcentaje() As Decimal
        Get
            Return _porcentaje
        End Get
        Set(ByVal value As Decimal)
            _porcentaje = value
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
    Public Sub New(Id As Integer, idContrato As Integer, idTipoPoliza As Integer, FechaCreacion As DateTime, UsuarioCreacion As String,
            Porcentaje As Decimal, UsuarioModi As String, FechaModi As DateTime, idEstado As Integer, estado As String)
        Me.Id = Id
        _idContrato = idContrato
        _idTipoColiza = idTipoPoliza
        Me.FechaCreacion = FechaCreacion
        Me.UsuarioCreacion = UsuarioCreacion
        _porcentaje = Porcentaje
        Me.UsuarioModificacion = UsuarioModi
        Me.FechaModificacion = FechaModi
        Me.IdEstado = idEstado
        Me.Estado = estado
    End Sub
#End Region
End Class
