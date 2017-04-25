Imports Datos
Public Class clsMinutas
#Region "Variables"
    Private _objMinutas As New dsAlcoContratosTableAdapters.tc049_datosMinutasContratosTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub tc049_insert(fc049_usuarioCreacion As String, fc049_rowidContrato As Integer, fc049_rowidTipoEscritura As Integer, fc049_numeroEscritura As String, fc049_fechaRegistro As DateTime,
                                        fc049_numeroNotaria As String, fc049_ciudadNotaria As String, fc049_rowIdciudadCamaraComercio As Integer, fc049_representante As String,
                                        fc049_cedulaRepresentante As String, fc049_FormaPago As String, fc049_usuarioModi As String, fc049_direccionContratante As String)
        Try
            _objMinutas.sp_tc049_insert(fc049_usuarioCreacion, fc049_rowidContrato, fc049_rowidTipoEscritura, fc049_numeroEscritura, fc049_fechaRegistro,
                                        fc049_numeroNotaria, fc049_ciudadNotaria, fc049_rowIdciudadCamaraComercio, fc049_representante,
                                        fc049_cedulaRepresentante, fc049_FormaPago, fc049_usuarioModi, fc049_direccionContratante)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub tc049_update(fc049_rowid As Integer, fc049_rowidContrato As Integer, fc049_rowidTipoEscritura As Integer, fc049_numeroEscritura As String, fc049_fechaRegistro As DateTime,
                                        fc049_numeroNotaria As String, fc049_ciudadNotaria As String, fc049_rowIdciudadCamaraComercio As Integer, fc049_representante As String,
                                        fc049_cedulaRepresentante As String, fc049_FormaPago As String, fc049_usuarioModi As String, fc049_rowidEstado As Integer, fc049_direccionContratante As String)

        _objMinutas.sp_tc049_update(fc049_rowid, fc049_rowidContrato, fc049_rowidTipoEscritura, fc049_numeroEscritura, fc049_fechaRegistro, fc049_numeroNotaria,
                                    fc049_ciudadNotaria, fc049_rowIdciudadCamaraComercio, fc049_representante, fc049_cedulaRepresentante, fc049_FormaPago, fc049_usuarioModi, fc049_rowidEstado, fc049_direccionContratante)

    End Sub
    Public Function traerTodas() As List(Of minutas)
        traerTodas = New List(Of minutas)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc049_selectAllTableAdapter
            Dim dt As dsAlcoContratos.sp_tc049_selectAllDataTable = ta.GetData()
            If dt.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc049_selectAllRow In dt.Rows
                    traerTodas.Add(New minutas(fila.id, fila.UsuarioCreacion, fila.idContrato, fila.IdTipoEscritura, fila.Escritura,
                                               fila.FechaRegistro, fila.NumeroEscritura, fila.numeroNotaria, fila.CiudadNotaria, fila.idCiudadCamaraComercio, fila.CiudadCamaraComercio,
                                               fila.RepresentanteLegal, fila.CedulaRepresentante, fila.FormaPago, fila.UsuarioModificacion, fila.FechaCreacion, fila.FechaModi, fila.idEstado,
                                               fila.Estado, fila.DireccionContratante))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerById(id As Integer) As List(Of minutas)
        traerById = New List(Of minutas)
        Try
            traerById.AddRange(traerTodas().Where(Function(a) a.Id = id And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerByIdContrato(idContrato As Integer) As List(Of minutas)
        traerByIdContrato = New List(Of minutas)
        Try
            traerByIdContrato.AddRange(traerTodas().Where(Function(a) a.idContrato = idContrato And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerValoresMinuta(idcontrato As Integer) As DataTable
        TraerValoresMinuta = Nothing
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc049_ValoresMinutaTableAdapter
            TraerValoresMinuta = ta.GetData(idcontrato).CopyToDataTable()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporNit(nit As String) As List(Of minutas)
        TraerporNit = New List(Of minutas)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc049_selectByNitTableAdapter
            Dim dt As dsAlcoContratos.sp_tc049_selectByNitDataTable = ta.GetData(nit)
            If dt.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc049_selectByNitRow In dt.Rows
                    TraerporNit.Add(New minutas(fila.id, fila.UsuarioCreacion, fila.idContrato, fila.IdTipoEscritura, fila.Escritura,
                                               fila.FechaRegistro, fila.NumeroEscritura, fila.numeroNotaria, fila.CiudadNotaria, fila.idCiudadCamaraComercio, fila.CiudadCamaraComercio,
                                               fila.RepresentanteLegal, fila.CedulaRepresentante, fila.FormaPago, fila.UsuarioModificacion, fila.FechaCreacion, fila.FechaModi, fila.idEstado,
                                               fila.Estado, fila.DireccionContratante))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
#Region "procedimientos"

#End Region
End Class
Public Class minutas : Inherits ClsBaseParametros
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
    Private _idTipoEscritura As Integer
    Public Property idTipoEscritura() As Integer
        Get
            Return _idTipoEscritura
        End Get
        Set(ByVal value As Integer)
            _idTipoEscritura = value
        End Set
    End Property
    Private _tipoEscritura As String
    Public Property tipoEscritura() As String
        Get
            Return _tipoEscritura
        End Get
        Set(ByVal value As String)
            _tipoEscritura = value
        End Set
    End Property
    Private _numeroEscritura As String
    Public Property numeroEscritura() As String
        Get
            Return _numeroEscritura
        End Get
        Set(ByVal value As String)
            _numeroEscritura = value
        End Set
    End Property
    Private _fechaRegistro As DateTime
    Public Property fechaRegistro() As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
        End Set
    End Property
    Private _numeroNotaria As String
    Public Property NumeroNotaria() As String
        Get
            Return _numeroNotaria
        End Get
        Set(ByVal value As String)
            _numeroNotaria = value
        End Set
    End Property
    Private _CiudadNotaria As String
    Public Property ciudadNotaria() As String
        Get
            Return _CiudadNotaria
        End Get
        Set(ByVal value As String)
            _CiudadNotaria = value
        End Set
    End Property
    Private _idCiudadCamaraComercio As Integer
    Public Property idCiudadCamaraComercio() As Integer
        Get
            Return _idCiudadCamaraComercio
        End Get
        Set(ByVal value As Integer)
            _idCiudadCamaraComercio = value
        End Set
    End Property
    Private _CiudadCamaraComercion As String
    Public Property CiudadCamaraComercio() As String
        Get
            Return _CiudadCamaraComercion
        End Get
        Set(ByVal value As String)
            _CiudadCamaraComercion = value
        End Set
    End Property
    Private _representanteLegal As String
    Public Property representanteLegal() As String
        Get
            Return _representanteLegal
        End Get
        Set(ByVal value As String)
            _representanteLegal = value
        End Set
    End Property
    Private _cedulaRepresentante As String
    Public Property cedulaRepresentante() As String
        Get
            Return _cedulaRepresentante
        End Get
        Set(ByVal value As String)
            _cedulaRepresentante = value
        End Set
    End Property
    Private _formaPago As String
    Public Property formaPago() As String
        Get
            Return _formaPago
        End Get
        Set(ByVal value As String)
            _formaPago = value
        End Set
    End Property
    Private _direccionContratante As String
    Public Property DireccionContratante() As String
        Get
            Return _direccionContratante
        End Get
        Set(ByVal value As String)
            _direccionContratante = value
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
    Public Sub New(fc049_rowid As Integer, fc049_usuarioCreacion As String, fc049_rowidContrato As Integer, fc049_rowidTipoEscritura As Integer, fc049_TipoEscritura As String,
                   fc049_fechaRegistro As DateTime, fc049_numeroEscritura As String, fc049_numeroNotaria As String, fc049_ciudadNotaria As String, fc049_rowIdciudadCamaraComercio As Integer,
                   fc049_ciudadCamaraComercio As String, fc049_representante As String, fc049_cedulaRepresentante As String, fc049_FormaPago As String,
                   fc049_usuarioModi As String, fc049_fechaCreacion As DateTime, fc049_fechaModi As DateTime, fc049_idEstado As Integer, fc049_estado As String, fc049_direccionContratante As String)
        Me.Id = fc049_rowid
        Me.UsuarioCreacion = fc049_usuarioCreacion
        Me.UsuarioModificacion = fc049_usuarioModi
        Me.FechaCreacion = fc049_fechaCreacion
        Me.FechaModificacion = fc049_fechaModi
        Me.IdEstado = fc049_idEstado
        Me.Estado = fc049_estado
        _idContrato = fc049_rowidContrato
        _idTipoEscritura = fc049_rowidTipoEscritura
        _tipoEscritura = fc049_TipoEscritura
        _numeroEscritura = fc049_numeroEscritura
        _numeroNotaria = fc049_numeroNotaria
        _CiudadNotaria = fc049_ciudadNotaria
        _CiudadCamaraComercion = fc049_ciudadCamaraComercio
        _idCiudadCamaraComercio = fc049_rowIdciudadCamaraComercio
        _representanteLegal = fc049_representante
        _cedulaRepresentante = fc049_cedulaRepresentante
        _formaPago = fc049_FormaPago
        _fechaRegistro = fc049_fechaRegistro
        _direccionContratante = fc049_direccionContratante
    End Sub

#End Region
End Class
