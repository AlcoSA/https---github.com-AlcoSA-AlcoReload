Imports Datos

Public Class ClsMovitoCuentaCobro
#Region "Variables"
    Private taMovitoCuentaCobro As New dsAlcoComercial2TableAdapters.tc101_movitoCuentaCobroTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(usuario As String, idCuentaCobro As Integer, idMovitoOT As Integer,
                        precio As Decimal, cantidad As Decimal, porcRetenido As Decimal,
                        unidadMedida As String, facturable As Boolean, idConceptoEspecial As Integer,
                        descripcionEspecial As String, precioCliente As Decimal, idMotivo As String,
                        idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taMovitoCuentaCobro.sp_tc101_insert(usuario, idCuentaCobro, idMovitoOT, precio, cantidad,
                                                porcRetenido, unidadMedida, facturable, idConceptoEspecial,
                                                descripcionEspecial, precioCliente, idMotivo, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstado(idCuentaCobro As Integer, idEstado As Integer, usuario As String)
        Try
            taMovitoCuentaCobro.sp_tc101_updateEstado(idEstado, idCuentaCobro, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxCuentaCobroOT(idCuentaCobro As Integer) As List(Of movitoCuentaCobro)
        Try
            TraerxCuentaCobroOT = New List(Of movitoCuentaCobro)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc101_selectByCuentaCobroOTTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc101_selectByCuentaCobroOTDataTable = taAll.GetData(idCuentaCobro)
            For Each mov As dsAlcoComercial2.sp_tc101_selectByCuentaCobroOTRow In txAll
                TraerxCuentaCobroOT.Add(New movitoCuentaCobro(mov.id, mov.fechaCreacion, mov.usuarioCreacion, mov.idCuentaCobro,
                                                              mov.idMovitoOT, mov.idConcepto, mov.concepto, mov.descripcion, mov.unidadMedida,
                                                              mov.porcentajeRetenido, mov.cantidad, mov.precio, mov.facturable,
                                                              mov.idConceptoEspecial, mov.conceptoEspecial, mov.descripcionEspecial,
                                                              mov.precioCliente, mov.idMotivo, mov.motivo, mov.usuarioModi, mov.fechaModi,
                                                              mov.idEstado, mov.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxCuentaCobroDirecta(idCuentaCobro As Integer) As List(Of movitoCuentaCobro)
        Try
            TraerxCuentaCobroDirecta = New List(Of movitoCuentaCobro)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc101_selectByCuentaCobroDirectaTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc101_selectByCuentaCobroDirectaDataTable = taAll.GetData(idCuentaCobro)
            For Each mov As dsAlcoComercial2.sp_tc101_selectByCuentaCobroDirectaRow In txAll
                TraerxCuentaCobroDirecta.Add(New movitoCuentaCobro(mov.id, mov.fechaCreacion, mov.usuarioCreacion, mov.idCuentaCobro,
                                                                   mov.idMovitoOT, mov.idConcepto, mov.concepto, mov.descripcion, mov.unidadMedida,
                                                                   mov.porcentajeRetenido, mov.cantidad, mov.precio, mov.facturable,
                                                                   mov.idConceptoEspecial, mov.conceptoEspecial, mov.descripcionEspecial,
                                                                   mov.precioCliente, mov.idMotivo, mov.motivo, mov.usuarioModi, mov.fechaModi,
                                                                   mov.idEstado, mov.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function MovitosActivos(idMovitoOt As Integer) As Boolean
        Try
            Dim conteo As Integer = CInt(taMovitoCuentaCobro.sp_tc101_selectMovitosActivos(idMovitoOt))
            If conteo > 0 Then
                MovitosActivos = True
            Else
                MovitosActivos = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerMovimientosParaDevolucion(idCuentaCobro As Integer) As List(Of CuentaCobroDevolucion)
        Try
            TraerMovimientosParaDevolucion = New List(Of cuentaCobroDevolucion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc101_selectForDevolucionTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc101_selectForDevolucionDataTable = taAll.GetData(idCuentaCobro)
            For Each mov As dsAlcoComercial2.sp_tc101_selectForDevolucionRow In txAll
                TraerMovimientosParaDevolucion.Add(New cuentaCobroDevolucion(mov.id, mov.idConcepto, mov.concepto, mov.unidadMedida, mov.cantidad,
                                                                             mov.valor, mov.total, mov.cantDisponible, mov.valorDisponible))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxFechas(fechaInicial As DateTime, fechaFin As DateTime, Optional ByRef dt As DataTable = Nothing) As List(Of detalleMovitoCuentaCobro)
        Try
            TraerxFechas = New List(Of detalleMovitoCuentaCobro)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc101_selectByFechasTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc101_selectByFechasDataTable = taAll.GetData(fechaInicial, fechaFin)
            For Each mov As dsAlcoComercial2.sp_tc101_selectByFechasRow In txAll
                TraerxFechas.Add(New detalleMovitoCuentaCobro(mov.ciudad, mov.fechaCreacion, mov.idDocumento, mov.documento, mov.consecutivo,
                                                              mov.idProveedor, mov.proveedor, mov.idEncargado, mov.encargado, mov.codigoObra,
                                                              mov.obra, mov.concepto, mov.descripcionConcepto, mov.unidadMedida, mov.cantidad,
                                                              mov.precio, mov.porcRetenido, mov.subtotal, mov.retenido, mov.total))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            Else
                dt = Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerOrdenesVsCuentas(obra As String) As List(Of ordenesVsCuentas)
        Try
            TraerOrdenesVsCuentas = New List(Of ordenesVsCuentas)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc101_selectOrdenesVsCuentasTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc101_selectOrdenesVsCuentasDataTable = taAll.GetData(obra)
            For Each ovc As dsAlcoComercial2.sp_tc101_selectOrdenesVsCuentasRow In txAll
                TraerOrdenesVsCuentas.Add(New ordenesVsCuentas(Convert.ToInt32(ovc.Item("idMovitoCuentaCobro")), Convert.ToString(ovc.Item("concepto")),
                                                               Convert.ToString(ovc.Item("descripcion")), Convert.ToString(ovc.Item("proveedor")),
                                                               Convert.ToDecimal(ovc.Item("precio")), Convert.ToDecimal(ovc.Item("cantidad")),
                                                               Convert.ToDecimal(ovc.Item("precioTotal")), Convert.ToDecimal(ovc.Item("pagado")),
                                                               Convert.ToDecimal(ovc.Item("disponible")), Convert.ToDecimal(ovc.Item("precioCliente")),
                                                               Convert.ToDecimal(ovc.Item("precioTotalCliente")), Convert.ToDecimal(ovc.Item("utilidad")),
                                                               Convert.ToString(ovc.Item("motivo")), CBool(ovc.Item("facturable")), CBool(ovc.Item("contrato")),
                                                               CBool(ovc.Item("adicional")), CBool(ovc.Item("directa"))))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoCuentaCobro
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idCuentaCobro As Integer
    Private _idMovitoOT As Integer
    Private _idConcepto As Integer
    Private _concepto As String
    Private _descripcion As String
    Private _unidadMedida As String
    Private _porcRetenido As Decimal
    Private _cantidad As Decimal
    Private _precio As Decimal
    Private _facturable As Boolean
    Private _idConceptoEspecial As Integer
    Private _conceptoEspecial As String
    Private _descripcionEspecial As String
    Private _precioCliente As Decimal
    Private _idMotivo As String
    Private _motivo As String
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
    Public Property IdMovitoOT() As Integer
        Get
            Return _idMovitoOT
        End Get
        Set(ByVal value As Integer)
            _idMovitoOT = value
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
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property PorcRetenido() As Decimal
        Get
            Return _porcRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcRetenido = value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
    Public Property Facturable() As Boolean
        Get
            Return _facturable
        End Get
        Set(ByVal value As Boolean)
            _facturable = value
        End Set
    End Property
    Public Property IdConceptoEspecial() As Integer
        Get
            Return _idConceptoEspecial
        End Get
        Set(ByVal value As Integer)
            _idConceptoEspecial = value
        End Set
    End Property
    Public Property ConceptoEspecial() As String
        Get
            Return _conceptoEspecial
        End Get
        Set(ByVal value As String)
            _conceptoEspecial = value
        End Set
    End Property
    Public Property DescripcionEspecial() As String
        Get
            Return _descripcionEspecial
        End Get
        Set(ByVal value As String)
            _descripcionEspecial = value
        End Set
    End Property
    Public Property PrecioCliente() As Decimal
        Get
            Return _precioCliente
        End Get
        Set(ByVal value As Decimal)
            _precioCliente = value
        End Set
    End Property
    Public Property IdMotivo() As String
        Get
            Return _idMotivo
        End Get
        Set(ByVal value As String)
            _idMotivo = value
        End Set
    End Property
    Public Property Motivo() As String
        Get
            Return _motivo
        End Get
        Set(ByVal value As String)
            _motivo = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCuentaCobro As Integer,
                   idMovitoOT As Integer, idConcepto As Integer, concepto As String, descripcion As String,
                   unidadMedida As String, porcRetenido As Decimal, cantidad As Decimal, precio As Decimal,
                   facturable As Boolean, idConceptoEspecial As Integer, conceptoEspecial As String,
                   descripcionEspecial As String, precioCliente As Decimal, codigoMotivo As String, motivo As String,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idCuentaCobro = idCuentaCobro
            _idMovitoOT = idMovitoOT
            _idConcepto = idConcepto
            _concepto = concepto
            _descripcion = descripcion
            _unidadMedida = unidadMedida
            _porcRetenido = porcRetenido
            _cantidad = cantidad
            _precio = precio
            _facturable = facturable
            _idConceptoEspecial = idConceptoEspecial
            _conceptoEspecial = conceptoEspecial
            _descripcionEspecial = descripcionEspecial
            _precioCliente = precioCliente
            _idMotivo = codigoMotivo
            _motivo = motivo
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class detalleMovitoCuentaCobro
#Region "Variables"
    Private _ciudad As String
    Private _fechaCreacion As DateTime
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _idProveedor As Integer
    Private _proveedor As String
    Private _idEncargado As Integer
    Private _encargado As String
    Private _codigoObra As String
    Private _obra As String
    Private _concepto As String
    Private _descripcion As String
    Private _unidadMedida As String
    Private _cantidad As Decimal
    Private _precio As Decimal
    Private _porcRetenido As Decimal
    Private _subtotal As Decimal
    Private _retenido As Decimal
    Private _total As Decimal
#End Region
#Region "Propiedades"
    Public Property Ciudad() As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
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
    Public Property Concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
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
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
    Public Property PorcRetenido() As Decimal
        Get
            Return _porcRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcRetenido = value
        End Set
    End Property
    Public Property Subtotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Decimal)
            _subtotal = value
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
    Public Property Total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
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
    Public Sub New(ciudad As String, fechaCreacion As DateTime, idDocumento As Integer, documento As String, consecutivo As Integer,
                   idProveedor As Integer, proveedor As String, idEncargado As Integer, encargado As String, codigoObra As String,
                   obra As String, concepto As String, descripcion As String, unidadMedida As String, cantidad As Decimal,
                   precio As Decimal, porcRetenido As Decimal, subtotal As Decimal, retenido As Decimal, total As Decimal)
        Try
            _ciudad = ciudad
            _fechaCreacion = fechaCreacion
            _idDocumento = idDocumento
            _documento = documento
            _consecutivo = consecutivo
            _idProveedor = idProveedor
            _proveedor = proveedor
            _idEncargado = idEncargado
            _encargado = encargado
            _codigoObra = codigoObra
            _obra = obra
            _concepto = concepto
            _descripcion = descripcion
            _unidadMedida = unidadMedida
            _cantidad = cantidad
            _precio = precio
            _porcRetenido = porcRetenido
            _subtotal = subtotal
            _retenido = retenido
            _total = total
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class cuentaCobroDevolucion
#Region "Variables"
    Private _idMovitoCuentaCobro As Integer
    Private _idConcepto As Integer
    Private _concepto As String
    Private _unidadMedida As String
    Private _cantidad As Decimal
    Private _valor As Decimal
    Private _total As Decimal
    Private _cantidadDisponible As Decimal
    Private _valorDisponible As Decimal
#End Region
#Region "Propiedades"
    Public Property IdMovitoCCobro() As Integer
        Get
            Return _idMovitoCuentaCobro
        End Get
        Set(ByVal value As Integer)
            _idMovitoCuentaCobro = value
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
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Public Property Valor() As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            _valor = value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property
    Public Property CantidadDisponible() As Decimal
        Get
            Return _cantidadDisponible
        End Get
        Set(ByVal value As Decimal)
            _cantidadDisponible = value
        End Set
    End Property
    Public Property ValorDisponible() As Decimal
        Get
            Return _valorDisponible
        End Get
        Set(ByVal value As Decimal)
            _valorDisponible = value
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
    Public Sub New(idMovitoCCobro As Integer, idConcepto As Integer, concepto As String, unidadMedida As String, cantidad As Decimal,
                   valor As Decimal, total As Decimal, cantidadDisponible As Decimal, valorDisponible As Decimal)
        Try
            _idMovitoCuentaCobro = idMovitoCCobro
            _idConcepto = idConcepto
            _concepto = concepto
            _unidadMedida = unidadMedida
            _cantidad = cantidad
            _valor = valor
            _total = total
            _cantidadDisponible = cantidadDisponible
            _valorDisponible = valorDisponible
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class ordenesVsCuentas
#Region "Variables"
    Private _idMovitoCuentaCobro As Integer
    Private _concepto As String
    Private _descripcion As String
    Private _proveedor As String
    Private _precioUnit As Decimal
    Private _cantidad As Decimal
    Private _precioTotal As Decimal
    Private _pagado As Decimal
    Private _disponible As Decimal
    Private _precioCliente As Decimal
    Private _precioTotalCliente As Decimal
    Private _utilidad As Decimal
    Private _motivo As String
    Private _facturable As Boolean
    Private _contrato As Boolean
    Private _adicional As Boolean
    Private _directa As Boolean
#End Region
#Region "Propiedades"
    Public Property IdMovitoCCobro() As Integer
        Get
            Return _idMovitoCuentaCobro
        End Get
        Set(ByVal value As Integer)
            _idMovitoCuentaCobro = value
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
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
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
    Public Property PrecioUnitario() As Decimal
        Get
            Return _precioUnit
        End Get
        Set(ByVal value As Decimal)
            _precioUnit = value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    Public Property PrecioTotal() As Decimal
        Get
            Return _precioTotal
        End Get
        Set(ByVal value As Decimal)
            _precioTotal = value
        End Set
    End Property
    Public Property Pagado() As Decimal
        Get
            Return _pagado
        End Get
        Set(ByVal value As Decimal)
            _pagado = value
        End Set
    End Property
    Public Property Disponible() As Decimal
        Get
            Return _disponible
        End Get
        Set(ByVal value As Decimal)
            _disponible = value
        End Set
    End Property
    Public Property PrecioCliente() As Decimal
        Get
            Return _precioCliente
        End Get
        Set(ByVal value As Decimal)
            _precioCliente = value
        End Set
    End Property
    Public Property PrecioTotalCliente() As Decimal
        Get
            Return _precioTotalCliente
        End Get
        Set(ByVal value As Decimal)
            _precioTotalCliente = value
        End Set
    End Property
    Public Property Utilidad() As Decimal
        Get
            Return _utilidad
        End Get
        Set(ByVal value As Decimal)
            _utilidad = value
        End Set
    End Property
    Public Property Motivo() As String
        Get
            Return _motivo
        End Get
        Set(ByVal value As String)
            _motivo = value
        End Set
    End Property
    Public Property Facturable() As Boolean
        Get
            Return _facturable
        End Get
        Set(ByVal value As Boolean)
            _facturable = value
        End Set
    End Property
    Public Property Contrato() As Boolean
        Get
            Return _contrato
        End Get
        Set(ByVal value As Boolean)
            _contrato = value
        End Set
    End Property
    Public Property Adicional() As Boolean
        Get
            Return _adicional
        End Get
        Set(ByVal value As Boolean)
            _adicional = value
        End Set
    End Property
    Public Property Directa() As Boolean
        Get
            Return _directa
        End Get
        Set(ByVal value As Boolean)
            _directa = value
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
    Public Sub New(idMovitoCCobro As Integer, concepto As String, descripcion As String, proveedor As String, precioUnit As Decimal,
                   cantidad As Decimal, precioTotal As Decimal, pagado As Decimal, disponible As Decimal, precioCliente As Decimal,
                   precioTotalCliente As Decimal, utilidad As Decimal, motivo As String, facturable As Boolean, contrato As Boolean,
                   adicional As Boolean, directa As Boolean)
        Try
            _idMovitoCuentaCobro = idMovitoCCobro
            _concepto = concepto
            _descripcion = descripcion
            _proveedor = proveedor
            _precioUnit = precioUnit
            _cantidad = cantidad
            _precioTotal = precioTotal
            _pagado = pagado
            _disponible = disponible
            _precioCliente = precioCliente
            _precioTotalCliente = precioTotalCliente
            _utilidad = utilidad
            _motivo = motivo
            _facturable = facturable
            _contrato = contrato
            _adicional = adicional
            _directa = directa
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
