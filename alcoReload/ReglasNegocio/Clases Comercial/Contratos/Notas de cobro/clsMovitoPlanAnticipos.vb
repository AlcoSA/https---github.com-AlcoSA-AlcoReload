Imports Datos
Public Class clsMovitoPlanAnticipos
#Region "Variables"
    Private _objCouta As New dsAlcoContratosTableAdapters.tc058_movitoAnticipoContratosTableAdapter
#End Region
#Region "Procedimientos y funciones"
    Public Sub Insertar(usuarioCreacion As String, idPlanAnticipo As Integer, numeroCouta As Integer, porceCouta As Decimal,
                            valorCouta As Decimal, fechaCuota As DateTime)
        Try
            _objCouta.sp_tc058_insert(usuarioCreacion, idPlanAnticipo, numeroCouta, porceCouta, valorCouta, fechaCuota)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, idPlanAnticipos As Integer, numeroCuota As Integer, porcentaje As Decimal,
                            valorCuota As Decimal, idEstado As Integer, fechaCuota As DateTime)
        Try
            _objCouta.sp_tc058_update(id, idPlanAnticipos, numeroCuota, porcentaje, valorCuota, idEstado, fechaCuota)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(idMovitoAnticipo As Integer, idEstado As Integer)
        Try
            _objCouta.sp_tc058_updateEstado(idMovitoAnticipo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerNumeroPendientes(idPlanAnticipo As Integer) As Integer
        Try
            Return Convert.ToInt32(_objCouta.sp_tc058_selectPendientes(idPlanAnticipo))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerTodas() As List(Of cuota)
        traerTodas = New List(Of cuota)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc058_selectAllTableAdapter
            Dim td As dsAlcoContratos.sp_tc058_selectAllDataTable = ta.GetData()

            If td.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc058_selectAllRow In td.Rows
                    traerTodas.Add(New cuota(fila.Id, fila.idPlanAnticipo, fila.numeroCuota, fila.porcentajeCuota, fila.valorCuota,
                                            fila.usuarioCreacion, fila.fechaModificacion, fila.usuarioCreacion, fila.fechaModificacion,
                                            fila.idEstado, fila.Estado, fila.FechaCuota))
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerxId(id As Integer) As cuota
        Try
            traerxId = traerTodas().FirstOrDefault(Function(a) a.Id = id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerxIdAnticipo(idanticipo As Integer) As List(Of cuota)
        traerxIdAnticipo = New List(Of cuota)
        Try
            traerxIdAnticipo.AddRange(traerTodas().Where(Function(a) a.idPlananticipo = idanticipo And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

End Class
Public Class cuota : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _idPlanAnticipo As Integer
    Public Property idPlananticipo() As Integer
        Get
            Return _idPlanAnticipo
        End Get
        Set(ByVal value As Integer)
            _idPlanAnticipo = value
        End Set
    End Property
    Private _NumeroCuota As Integer
    Public Property NumeroCuota() As Integer
        Get
            Return _NumeroCuota
        End Get
        Set(ByVal value As Integer)
            _NumeroCuota = value
        End Set
    End Property
    Private _porcentajeCuota As Decimal
    Public Property porcentajeCuota() As Decimal
        Get
            Return _porcentajeCuota
        End Get
        Set(ByVal value As Decimal)
            _porcentajeCuota = value
        End Set
    End Property
    Private _valorCuota As Decimal
    Public Property valorCuota() As Decimal
        Get
            Return _valorCuota
        End Get
        Set(ByVal value As Decimal)
            _valorCuota = value
        End Set
    End Property
    Private _fechaCuota As DateTime
    Public Property fechaCuota() As DateTime
        Get
            Return _fechaCuota
        End Get
        Set(ByVal value As DateTime)
            _fechaCuota = value
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
    Public Sub New(id As Integer, idPlanAnticipos As Integer, numeroCuota As Integer, porcentaje As Decimal, valorCuota As Decimal,
                   usuarioCreacion As String, fechaCreacion As DateTime, usuarioModi As String, fechaModificacion As DateTime,
                   idEstado As Integer, estado As String, fechaCuota As DateTime)
        Try
            Me.Id = id
            _idPlanAnticipo = idPlanAnticipos
            _NumeroCuota = numeroCuota
            _porcentajeCuota = porcentaje
            _valorCuota = valorCuota
            _fechaCuota = fechaCuota
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModificacion
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
