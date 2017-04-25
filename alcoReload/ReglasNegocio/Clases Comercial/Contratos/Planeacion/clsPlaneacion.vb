Imports Datos

Public Class clsPlaneacion
#Region "Variables"
    Private taPlaneacion As New dsAlcoContratosTableAdapters.tc083_planeacionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idContrato As Integer, idPendiente As Integer, idPadreCotiza As Integer,
                        idVendedor As String, cantidadPuntos As Integer, semana As String, numSemana As Integer,
                        mes As Integer, anio As Integer, idConcepto As Integer, idEstado As Integer)
        Try
            taPlaneacion.sp_tc083_insert(usuario, idContrato, idPendiente, idPadreCotiza, idVendedor, cantidadPuntos, semana,
                                         numSemana, mes, anio, idConcepto, idEstado)

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(idPlaneacion As Integer, idContrato As Integer, idPendiente As Integer, puntos As Integer,
                         semana As String, numSemana As Integer, mes As Integer, anio As Integer, idConcepto As Integer,
                         usuario As String)
        Try
            taPlaneacion.sp_tc083_update(idPlaneacion, idContrato, idPendiente, puntos, semana, numSemana, mes,
                                         anio, idConcepto, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(idPlaneacion As Integer, usuario As String, idEstado As Integer)
        Try
            taPlaneacion.sp_tc083_updateEstado(idPlaneacion, usuario, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of planeacion)
        Try
            TraerTodos = New List(Of planeacion)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc083_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc083_selectAllDataTable = taAll.GetData()
            For Each plan As dsAlcoContratos.sp_tc083_selectAllRow In txAll
                TraerTodos.Add(New planeacion(plan.id, plan.fechaCreacion, plan.usuarioCreacion, plan.idContrato,
                                              plan.idPendiente, plan.idPadre, plan.ubicacion, plan.descripcion,
                                              plan.idVendedor, plan.Puntos, 0, 0, plan.semana,
                                              plan.numSemana, plan.mes, plan.anio, plan.idConcepto, plan.concepto,
                                              plan.usuarioModi, plan.fechaModi, plan.idEstado, plan.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdContrato(idContrato As Integer) As List(Of planeacion)
        Try
            TraerxIdContrato = New List(Of planeacion)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc083_selectByIdContratoTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc083_selectByIdContratoDataTable = taAll.GetData(idContrato)
            For Each plan As dsAlcoContratos.sp_tc083_selectByIdContratoRow In txAll
                TraerxIdContrato.Add(New planeacion(plan.id, plan.fechaCreacion, plan.usuarioCreacion, plan.idContrato,
                                              plan.idPendiente, plan.idPadre, plan.ubicacion, plan.descripcion,
                                              plan.idVendedor, plan.Puntos, plan.totalPuntos, plan.PuntosSinPlanear, plan.semana,
                                              plan.numSemana, plan.mes, plan.anio, plan.idConcepto, plan.concepto,
                                              plan.usuarioModi, plan.fechaModi, plan.idEstado, plan.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdPendiente(idPendiente As Integer) As List(Of planeacion)
        Try
            TraerxIdPendiente = New List(Of planeacion)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc083_selectByIdPendienteTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc083_selectByIdPendienteDataTable = taAll.GetData(idPendiente)
            For Each plan As dsAlcoContratos.sp_tc083_selectByIdPendienteRow In txAll
                TraerxIdPendiente.Add(New planeacion(plan.id, plan.fechaCreacion, plan.usuarioCreacion, plan.idContrato,
                                              plan.idPendiente, plan.idPadre, plan.ubicacion, plan.descripcion,
                                              plan.idVendedor, plan.Puntos, plan.totalPuntos, plan.PuntosSinPlanear, plan.semana,
                                              plan.numSemana, plan.mes, plan.anio, plan.idConcepto, plan.concepto,
                                              plan.usuarioModi, plan.fechaModi, plan.idEstado, plan.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerConceptoxIDPadreAndIDContrato(idContrato As Integer, idItemPadre As Integer) As Integer
        Try
            Return Convert.ToInt32(taPlaneacion.sp_tc083_selectConceptoDefByIdContrato(idContrato, idItemPadre))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerConceptoxIDPendiente(idPendiente As Integer) As Integer
        Try
            Return Convert.ToInt32(taPlaneacion.sp_tc083_selectConceptoDefByIdPendiente(idPendiente))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class planeacion
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idContrato As Integer
    Private _idPendiente As Integer
    Private _idPadre As Integer
    Private _ubicacion As String
    Private _descripcion As String
    Private _idVendedor As String
    Private _puntos As Integer
    Private _totalPuntos As Integer
    Private _puntosSinPlanear As Integer
    Private _semana As String
    Private _numSemana As Integer
    Private _mes As Integer
    Private _anio As Integer
    Private _idConcepto As Integer
    Private _concepto As String
#End Region
#Region "Propiedades"
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property IdPendiente() As Integer
        Get
            Return _idPendiente
        End Get
        Set(ByVal value As Integer)
            _idPendiente = value
        End Set
    End Property
    Public Property IdPadre() As Integer
        Get
            Return _idPadre
        End Get
        Set(ByVal value As Integer)
            _idPadre = value
        End Set
    End Property
    Public Property Ubicacion() As String
        Get
            Return _ubicacion
        End Get
        Set(ByVal value As String)
            _ubicacion = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property IdVendedor() As String
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As String)
            _idVendedor = value
        End Set
    End Property
    Public Property Puntos() As Integer
        Get
            Return _puntos
        End Get
        Set(ByVal value As Integer)
            _puntos = value
        End Set
    End Property
    Public Property TotalPuntos() As Integer
        Get
            Return _totalPuntos
        End Get
        Set(ByVal value As Integer)
            _totalPuntos = value
        End Set
    End Property
    Public Property PuntosSinPlanear() As Integer
        Get
            Return _puntosSinPlanear
        End Get
        Set(ByVal value As Integer)
            _puntosSinPlanear = value
        End Set
    End Property
    Public Property Semana() As String
        Get
            Return _semana
        End Get
        Set(ByVal value As String)
            _semana = value
        End Set
    End Property
    Public Property NumSemana() As Integer
        Get
            Return _numSemana
        End Get
        Set(ByVal value As Integer)
            _numSemana = value
        End Set
    End Property
    Public Property Mes() As Integer
        Get
            Return _mes
        End Get
        Set(ByVal value As Integer)
            _mes = value
        End Set
    End Property
    Public Property Anio() As Integer
        Get
            Return _anio
        End Get
        Set(ByVal value As Integer)
            _anio = value
        End Set
    End Property
    Public Property IdConcepto() As Integer
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As Integer)
            _idConcepto = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idContrato As Integer,
                   idPendiente As Integer, idPadre As Integer, ubicacion As String, descripcion As String,
                   idVendedor As String, puntos As Integer, totalPuntos As Integer, puntosSinPlanear As Integer,
                   semana As String, numSemana As Integer, mes As Integer, anio As Integer, idConcepto As Integer,
                   concepto As String, usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idContrato = idContrato
            _idPendiente = idPendiente
            _idPadre = idPadre
            _ubicacion = ubicacion
            _descripcion = descripcion
            _idVendedor = idVendedor
            _puntos = puntos
            _totalPuntos = totalPuntos
            _puntosSinPlanear = puntosSinPlanear
            _semana = Trim(semana)
            _numSemana = numSemana
            _mes = mes
            _anio = anio
            _idConcepto = idConcepto
            _concepto = Trim(concepto)
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(idConcepto As Integer, concepto As String)
        Try
            _idConcepto = idConcepto
            _concepto = concepto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class