Imports Datos
Public Class ClsPaises
#Region "Variables"

#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
    Public Function TraerTodos() As List(Of Pais)
        Try
            TraerTodos = New List(Of Pais)
            Dim TaAll As New dsAlcoComercialTableAdapters.sp_tc032_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc032_selectAllDataTable = TaAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc032_selectAllRow In txAll.Rows
                    TraerTodos.Add(New Pais(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idSiesa,
                                            ti.descripcion, ti.usuarioModi, ti.fechaModi, ti.valorDefecto))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ExisteValorDefecto() As Boolean
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc032_selectExisteValorDefectoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc032_selectExisteValorDefectoDataTable = taAll.GetData()
            If txAll.Rows.Count <= 0 Then Return False
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxValorDefecto() As List(Of Pais)
        Try
            TraerxValorDefecto = New List(Of Pais)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc032_selectByValorDefectoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc032_selectByValorDefectoDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc032_selectByValorDefectoRow In txAll.Rows
                    TraerxValorDefecto.Add(New Pais(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idSiesa,
                                                    ti.descripcion, ti.usuarioModi, ti.fechaModi, ti.valorDefecto))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdSiesa(idSiesa As Integer) As Pais
        Try
            TraerxIdSiesa = New Pais
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc032_selectByIdSiesaTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc032_selectByIdSiesaDataTable = taAll.GetData(idSiesa)
            If txAll.Rows.Count > 0 Then
                Dim ti As dsAlcoComercial.sp_tc032_selectByIdSiesaRow = DirectCast(txAll.Rows(0), dsAlcoComercial.sp_tc032_selectByIdSiesaRow)
                TraerxIdSiesa = New Pais(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idSiesa, ti.descripcion,
                                         ti.usuarioModi, ti.fechaModi, ti.valorDefecto)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class Pais
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idSiesa As Integer
    Private _descripcion As String
    Private _valorDefecto As Integer
#End Region
#Region "Propiedades"
    Public Property idSiesa() As Integer
        Get
            Return _idSiesa
        End Get
        Set(ByVal value As Integer)
            _idSiesa = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property valorDefecto() As Integer
        Get
            Return _valorDefecto
        End Get
        Set(ByVal value As Integer)
            _valorDefecto = value
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

    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idSiesa As Integer,
                   descripcion As String, usuarioModificacion As String, fechaModificacion As DateTime, valorDefecto As Integer)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idSiesa = idSiesa
            _descripcion = descripcion
            Me.UsuarioModificacion = usuarioModificacion
            Me.FechaModificacion = fechaModificacion
            _valorDefecto = valorDefecto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
