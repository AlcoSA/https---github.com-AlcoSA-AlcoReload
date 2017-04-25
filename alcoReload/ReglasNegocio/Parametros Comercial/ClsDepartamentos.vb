Imports Datos
Public Class ClsDepartamentos
#Region "Procedimientos"
    Public Function TraerByIdPais(idPais As Integer) As List(Of Departamento)
        Try
            TraerByIdPais = New List(Of Departamento)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc033_selectByIdPaisTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc033_selectByIdPaisDataTable = taAll.GetData(idPais)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc033_selectByIdPaisRow In txAll.Rows
                    TraerByIdPais.Add(New Departamento(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idPais,
                                                       ti.idSiesa, ti.descripcion, ti.usuarioModi, ti.fechaModi, ti.valorDefecto))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ExisteValorDefecto() As Boolean
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc033_selectExisteValorDefectoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc033_selectExisteValorDefectoDataTable = taAll.GetData()
            If txAll.Rows.Count <= 0 Then Return False
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxValorDefectoAndIdPais(idPais As Integer) As List(Of Departamento)
        Try
            TraerxValorDefectoAndIdPais = New List(Of Departamento)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc033_selectByPaisAndValorDefectoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc033_selectByPaisAndValorDefectoDataTable = taAll.GetData(idPais)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc033_selectByPaisAndValorDefectoRow In txAll.Rows
                    TraerxValorDefectoAndIdPais.Add(New Departamento(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idPais,
                                                                     ti.idSiesa, ti.descripcion, ti.usuarioModi, ti.fechaModi, ti.valorDefecto))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdPaisAndIdSiesa(idPais As Integer, idDepto As String) As Departamento
        Try
            TraerxIdPaisAndIdSiesa = New Departamento
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc033_selectByIdPaisAndIdDeptoTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc033_selectByIdPaisAndIdDeptoDataTable = taAll.GetData(idPais, idDepto)
            If txAll.Rows.Count > 0 Then
                Dim ti As dsAlcoComercial.sp_tc033_selectByIdPaisAndIdDeptoRow = DirectCast(txAll.Rows(0), dsAlcoComercial.sp_tc033_selectByIdPaisAndIdDeptoRow)
                TraerxIdPaisAndIdSiesa = New Departamento(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idPais, ti.idSiesa,
                                                          ti.descripcion, ti.usuarioModi, ti.fechaModi, ti.valorDefecto)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class Departamento
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idPais As Integer
    Private _idSiesa As String
    Private _descripcion As String
    Private _valorDefecto As Integer
#End Region
#Region "Propiedades"

    Public Property idPais() As Integer
        Get
            Return _idPais
        End Get
        Set(ByVal value As Integer)
            _idPais = value
        End Set
    End Property

    Public Property idSiesa() As String
        Get
            Return _idSiesa
        End Get
        Set(ByVal value As String)
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
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idPais As Integer,
                   idSiesa As String, descripcion As String, usuarioModificacion As String, fechaModificacion As DateTime,
                   valorDefecto As Integer)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idPais = idPais
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
