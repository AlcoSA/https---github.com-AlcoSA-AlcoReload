Imports Datos

Public Class ClsCuentaCobro
#Region "Variables"
    Private taCuentaCobro As New dsAlcoComercial2TableAdapters.tc100_cuentaCobroTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, idContrato As Integer, idProveedor As Integer, idEncargado As Integer,
                             idDocumento As Integer, consecutivo As Integer, idTipoCuenta As Integer, nit As String,
                             cliente As String, codObra As String, obra As String, nitYO As String, clienteYO As String,
                             vendedor As String, observaciones As String, idEstado As Integer, idEstadoImpresion As Integer) As Integer
        Try
            Return Convert.ToInt32(taCuentaCobro.sp_tc100_insert(usuario, idContrato, idProveedor, idEncargado, idDocumento,
                                                                 consecutivo, idTipoCuenta, nit, cliente, codObra, obra,
                                                                 nitYO, clienteYO, vendedor, observaciones, idEstadoImpresion, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer, usuario As String)
        Try
            taCuentaCobro.sp_tc100_updateEstado(id, idEstado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerNumeroCuentasRealizadas(idContrato As Integer, idProveedor As Integer, idEncargado As Integer) As Integer
        Try
            TraerNumeroCuentasRealizadas = Convert.ToInt32(taCuentaCobro.sp_tc100_selectCuentasRealizadas(idContrato, idProveedor, idEncargado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TieneMovimientos(idCuentaCobro As Integer) As Boolean
        Try
            If Convert.ToInt32(taCuentaCobro.sp_tc100_selectCountMovimientos(idCuentaCobro)) > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerTodas(Optional ByRef dt As DataTable = Nothing) As List(Of cuentaCobroInst)
        Try
            TraerTodas = New List(Of cuentaCobroInst)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc100_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc100_selectAllDataTable = taAll.GetData()
            For Each cc As dsAlcoComercial2.sp_tc100_selectAllRow In txAll
                TraerTodas.Add(New cuentaCobroInst(cc.id, cc.fechaCreacion, cc.usuarioCreacion, cc.idContrato, cc.idDocumento,
                                                       cc.documento, cc.consecutivo, cc.idProveedor, cc.proveedor, cc.idEncargado,
                                                       cc.encargado, cc.codigoObra, cc.obra, cc.vendedor, cc.idEstadoImpresion,
                                                       cc.estadoImpresion, cc.usuarioModi, cc.fechaModi, cc.idEstado, cc.estado,
                                                       cc.observaciones))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerCuentasOT(Optional ByRef dt As DataTable = Nothing) As List(Of cuentaCobroInst)
        Try
            TraerCuentasOT = New List(Of cuentaCobroInst)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc100_selectCuentasxOTTableAdapter
            Dim txall As dsAlcoComercial2.sp_tc100_selectCuentasxOTDataTable = taAll.GetData()
            For Each cc As dsAlcoComercial2.sp_tc100_selectCuentasxOTRow In txall
                TraerCuentasOT.Add(New cuentaCobroInst(cc.id, cc.fechaCreacion, cc.usuarioCreacion, cc.idContrato, cc.idDocumento,
                                                       cc.documento, cc.consecutivo, cc.idProveedor, cc.proveedor, cc.idEncargado,
                                                       cc.encargado, cc.codigoObra, cc.obra, cc.vendedor, cc.idEstadoImpresion,
                                                       cc.estadoImpresion, cc.usuarioModi, cc.fechaModi, cc.idEstado, cc.estado, cc.observaciones))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerCuentasDirectas(Optional ByRef dt As DataTable = Nothing) As List(Of cuentaCobroInst)
        Try
            TraerCuentasDirectas = New List(Of cuentaCobroInst)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc100_selectCuentasDirectasTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc100_selectCuentasDirectasDataTable = taAll.GetData()
            For Each cc As dsAlcoComercial2.sp_tc100_selectCuentasDirectasRow In txAll
                TraerCuentasDirectas.Add(New cuentaCobroInst(cc.id, cc.fechaCreacion, cc.usuarioCreacion, cc.idContrato, cc.idDocumento,
                                                             cc.documento, cc.consecutivo, cc.idProveedor, cc.proveedor, cc.idEncargado,
                                                             cc.encargado, cc.codigoObra, cc.obra, cc.vendedor, cc.idEstadoImpresion,
                                                             cc.estadoImpresion, cc.usuarioModi, cc.fechaModi, cc.idEstado, cc.estado, cc.observaciones))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerObras(idProveedor As Integer, idEncargado As Integer) As List(Of obrasCuentaCobro)
        Try
            TraerObras = New List(Of obrasCuentaCobro)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc100_selectObrasTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc100_selectObrasDataTable = taAll.GetData(idProveedor, idEncargado)
            For Each obr As dsAlcoComercial2.sp_tc100_selectObrasRow In txAll
                TraerObras.Add(New obrasCuentaCobro(Convert.ToString(obr.Item("proveedor")), Convert.ToString(obr.Item("encargado")), Convert.ToString(obr.Item("codigoObra")),
                                                    Convert.ToString(obr.Item("obra")), Convert.ToString(obr.Item("vendedor"))))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxObra(idProveedor As Integer, idEncargado As Integer, nit As String, codigoObra As String) As List(Of obrasCuentaCobro)
        Try
            TraerxObra = New List(Of obrasCuentaCobro)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc100_selectByObrasTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc100_selectByObrasDataTable = taAll.GetData(idProveedor, idEncargado, nit, codigoObra)
            For Each obr As dsAlcoComercial2.sp_tc100_selectByObrasRow In txAll
                TraerxObra.Add(New obrasCuentaCobro(CInt(obr.Item("idCuentaCobro")), CInt(obr.Item("idDocumento")), Convert.ToString(obr.Item("documento")),
                                                    CInt(obr.Item("consecutivo")), Convert.ToDateTime(obr.Item("fecha")), CDec(obr.Item("totalCuentas")),
                                                    CDec(obr.Item("retenido")), CDec(obr.Item("valorPagado")), CBool(obr.Item("cuentaDirecta"))))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class cuentaCobroInst
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idContrato As Integer
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _idProveedor As Integer
    Private _proveedor As String
    Private _idEncargado As Integer
    Private _encargado As String
    Private _codigoObra As String
    Private _obra As String
    Private _vendedor As String
    Private _idEstadoImpresion As Integer
    Private _estadoImpresion As String
    Private _observaciones As String
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
    Public Property IdDocumento() As Integer
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As Integer)
            _idDocumento = value
        End Set
    End Property
    Public Property Documento() As String
        Get
            Return _documento
        End Get
        Set(ByVal value As String)
            _documento = value
        End Set
    End Property
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
        End Set
    End Property
    Public Property IdProveedor() As Integer
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Integer)
            _idProveedor = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
    Public Property IdEncargado() As Integer
        Get
            Return _idEncargado
        End Get
        Set(ByVal value As Integer)
            _idEncargado = value
        End Set
    End Property
    Public Property Encargado() As String
        Get
            Return _encargado
        End Get
        Set(ByVal value As String)
            _encargado = value
        End Set
    End Property
    Public Property CodigoObra() As String
        Get
            Return _codigoObra
        End Get
        Set(ByVal value As String)
            _codigoObra = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property IdEstadoImpresion() As Integer
        Get
            Return _idEstadoImpresion
        End Get
        Set(ByVal value As Integer)
            _idEstadoImpresion = value
        End Set
    End Property
    Public Property EstadoImpresion() As String
        Get
            Return _estadoImpresion
        End Get
        Set(ByVal value As String)
            _estadoImpresion = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
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
                   idDocumento As Integer, documento As String, consecutivo As Integer, idProveedor As Integer,
                   proveedor As String, idEncargado As Integer, encargado As String, codigoObra As String,
                   obra As String, vendedor As String, idEstadoImpresion As Integer, estadoImpresion As String,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String,
                   observaciones As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idContrato = idContrato
            _idDocumento = idDocumento
            _documento = documento
            _consecutivo = consecutivo
            _idProveedor = idProveedor
            _proveedor = proveedor
            _idEncargado = idEncargado
            _encargado = encargado
            _codigoObra = codigoObra
            _obra = obra
            _vendedor = vendedor
            _idEstadoImpresion = idEstadoImpresion
            _estadoImpresion = estadoImpresion
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = FechaModificacion
            Me.IdEstado = idEstado
            Me.Estado = estado
            _observaciones = observaciones
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class obrasCuentaCobro
#Region "Variables"
    Private _idCuentaCobro As Integer
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _proveedor As String
    Private _encargado As String
    Private _codigoObra As String
    Private _obra As String
    Private _fecha As DateTime
    Private _vendedor As String
    Private _totalCuentas As Decimal
    Private _retenido As Decimal
    Private _valorPagado As Decimal
    Private _cuentaDirecta As Boolean
#End Region
#Region "Propiedades"
    Public Property IdCuentaCobro() As Integer
        Get
            Return _idCuentaCobro
        End Get
        Set(ByVal value As Integer)
            _idCuentaCobro = value
        End Set
    End Property
    Public Property IdDocumento() As Integer
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As Integer)
            _idDocumento = value
        End Set
    End Property
    Public Property Documento() As String
        Get
            Return _documento
        End Get
        Set(ByVal value As String)
            _documento = value
        End Set
    End Property
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
    Public Property Encargado() As String
        Get
            Return _encargado
        End Get
        Set(ByVal value As String)
            _encargado = value
        End Set
    End Property
    Public Property CodigoObra() As String
        Get
            Return _codigoObra
        End Get
        Set(ByVal value As String)
            _codigoObra = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property TotalCuentas() As Decimal
        Get
            Return _totalCuentas
        End Get
        Set(ByVal value As Decimal)
            _totalCuentas = value
        End Set
    End Property
    Public Property Retenido() As Decimal
        Get
            Return _retenido
        End Get
        Set(ByVal value As Decimal)
            _retenido = value
        End Set
    End Property
    Public Property ValorPagado() As Decimal
        Get
            Return _valorPagado
        End Get
        Set(ByVal value As Decimal)
            _valorPagado = value
        End Set
    End Property
    Public Property CuentaDirecta() As Boolean
        Get
            Return _cuentaDirecta
        End Get
        Set(ByVal value As Boolean)
            _cuentaDirecta = value
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
    Public Sub New(proveedor As String, encargado As String, codigoObra As String, obra As String, vendedor As String)
        Try
            _proveedor = proveedor
            _encargado = encargado
            _codigoObra = codigoObra
            _obra = obra
            _vendedor = vendedor
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(idCuentaCobro As Integer, idDocumento As Integer, documento As String, consecutivo As Integer,
                   fecha As DateTime, totalCuentas As Decimal, retenido As Decimal, valorPagado As Decimal, cuentaDirecta As Boolean)
        Try
            _idCuentaCobro = idCuentaCobro
            _idDocumento = idDocumento
            _documento = documento
            _consecutivo = consecutivo
            _fecha = fecha
            _totalCuentas = totalCuentas
            _retenido = retenido
            _valorPagado = valorPagado
            _cuentaDirecta = cuentaDirecta
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
