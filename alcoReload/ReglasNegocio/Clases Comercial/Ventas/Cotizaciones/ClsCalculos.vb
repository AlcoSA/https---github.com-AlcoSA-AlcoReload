Imports ReglasNegocio.CostoArticulo

Public Class ClsCalculos

#Region "Variables"
    Private _costounitario As Decimal = 0
    Private _costototal As Decimal = 0
    Private _preciounitario As Decimal = 0
    Private _preciototal As Decimal = 0
    Private _precioinstalacion As Decimal = 0
    Private _costovidrio As Decimal = 0
    Private _costoperfiles As Decimal = 0
    Private _costoaccesorios As Decimal = 0
    Private _costootros As Decimal = 0
    Private cosTrabajos As Decimal = 0
    Private _costo_instalacion As Decimal = 0
    Private _valorDescuento As Decimal = 0
    Private _metroscuadrados As Decimal = 0
    Private _indAIU As Boolean = False
    Private _tasaImpuesto As Decimal = 0
    Private mCostoAccesorios As ClsCostoAccesorio
    Private mCostoVidrio As ClsCostoVidrio
    Private mCostoOtros As ClsCostoOtrosArticulos
    Private mCostoPerfil As ClsCostoAluminio
    Private mArticulo As ClsArticulos
#End Region

#Region "Propiedades"
    Public Property Costo_Instalacion As Decimal
        Get
            Return _costo_instalacion
        End Get
        Set(value As Decimal)
            _costo_instalacion = value
        End Set
    End Property
    Public Property CostoUnitario As Decimal
        Get
            Return _costounitario
        End Get
        Set(ByVal value As Decimal)
            _costounitario = value
        End Set
    End Property
    Public Property CostoTotal As Decimal
        Get
            Return _costototal
        End Get
        Set(ByVal value As Decimal)
            _costototal = value
        End Set
    End Property
    Public Property PrecioUnitario As Decimal
        Get
            Return _preciounitario
        End Get
        Set(ByVal value As Decimal)
            _preciounitario = value
        End Set
    End Property
    Public Property PrecioTotal As Decimal
        Get
            Return _preciototal
        End Get
        Set(ByVal value As Decimal)
            _preciototal = value
        End Set
    End Property
    Public Property PrecioInstalacion As Decimal
        Get
            Return _precioinstalacion
        End Get
        Set(ByVal value As Decimal)
            _precioinstalacion = value
        End Set
    End Property
    Public Property CostoVidrio As Decimal
        Get
            Return _costovidrio
        End Get
        Set(ByVal value As Decimal)
            _costovidrio = value
        End Set
    End Property
    Public Property CostoPerfiles As Decimal
        Get
            Return _costoperfiles
        End Get
        Set(ByVal value As Decimal)
            _costoperfiles = value
        End Set
    End Property
    Public Property CostoAccesorio As Decimal
        Get
            Return _costoaccesorios
        End Get
        Set(ByVal value As Decimal)
            _costoaccesorios = value
        End Set
    End Property
    Public Property CostoOtros As Decimal
        Get
            Return _costootros
        End Get
        Set(ByVal value As Decimal)
            _costootros = value
        End Set
    End Property
    Public Property CostoTrabajos As Decimal
        Get
            Return cosTrabajos
        End Get
        Set(ByVal value As Decimal)
            cosTrabajos = value
        End Set
    End Property
    Public Property ValorDescuento As Decimal
        Get
            Return _valorDescuento
        End Get
        Set(ByVal value As Decimal)
            _valorDescuento = value
        End Set
    End Property
    Public Property MetrosCuadrados As Decimal
        Get
            Return _metroscuadrados
        End Get
        Set(ByVal value As Decimal)
            _metroscuadrados = value
        End Set
    End Property
    Public Property indAIU As Boolean
        Get
            Return _indAIU
        End Get
        Set(ByVal value As Boolean)
            _indAIU = value
        End Set
    End Property
    Public Property tasaImpuesto As Decimal
        Get
            Return _tasaImpuesto
        End Get
        Set(ByVal value As Decimal)
            _tasaImpuesto = value
        End Set
    End Property

    Private _vlrdespVidrio As Decimal
    Public ReadOnly Property vlrdespVidrio As Decimal
        Get
            Return _vlrdespVidrio
        End Get
    End Property
    Private _vlrdespPerfiles As Decimal
    Public ReadOnly Property vlrdespPerfiles As Decimal
        Get
            Return _vlrdespPerfiles
        End Get
    End Property
    Private _vlrdespAccesorios As Decimal
    Public ReadOnly Property vlrdespAccesorios As Decimal
        Get
            Return _vlrdespAccesorios
        End Get
    End Property
    Private _vlrdespOtros As Decimal
    Public ReadOnly Property vlrdespOtros As Decimal
        Get
            Return _vlrdespOtros
        End Get

    End Property
#End Region

#Region "Metros cuadrados"
    Public Function mtCuadradosPadre(ancho As Decimal, alto As Decimal, cantidad As Integer) As Decimal
        Try
            Dim mtCuad As Decimal = ((ancho * alto) / 1000000)
            If mtCuad < 1 Then
                mtCuadradosPadre = cantidad * 1
            Else
                mtCuadradosPadre = mtCuad * cantidad
            End If
        Catch ex As ArgumentException
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

#Region "Costos"
    Private Sub Inicio()
        Try
            _costounitario = 0
            _costototal = 0
            _preciounitario = 0
            _preciototal = 0
            _precioinstalacion = 0
            _costovidrio = 0
            _costoperfiles = 0
            _costoaccesorios = 0
            _costootros = 0
            cosTrabajos = 0
            _valorDescuento = 0
            _metroscuadrados = 0
            _vlrdespVidrio = 0
            _vlrdespPerfiles = 0
            _vlrdespAccesorios = 0
            _vlrdespOtros = 0
            _valorDescuento = 0
            _costo_instalacion = 0
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Calcular_Trabajos(tabla_Trabajos As DataTable)
        Try
            cosTrabajos = 0
            If tabla_Trabajos IsNot Nothing Then
                Dim mCostoTrabajo As New ClsCostoTrabajoItem
                For Each row As DataRow In tabla_Trabajos.Rows
                    Dim cos As Decimal = mCostoTrabajo.TraerEspecifico(1, CInt(row("idTrabajo"))).Costo
                    cosTrabajos += cos * CInt(row("cantidad"))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Calcular_Disenio(costo_unitario As Decimal, cantidad As Decimal, pxund As Decimal, ancho As Decimal, alto As Decimal,
                       descuento As Decimal, factor As Decimal, precioMtInstalacion As Decimal,
                       costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorios As Decimal,
                        costoOtros As Decimal, costo_instalacion_unitario As Decimal)
        Try

            Inicio()
            ancho /= 1000
            alto /= 1000
            descuento /= 100
            _costovidrio = costoVidrio
            _costoperfiles = costoPerfiles
            _costoaccesorios = costoAccesorios
            _costootros = costoOtros
            _costounitario = costo_unitario
            _costototal = costo_unitario * cantidad
            _metroscuadrados = (ancho * alto)
            If _indAIU Then
                _preciounitario = Math.Round((_costounitario * (1 + (factor / 100))) + (_costounitario * (_tasaImpuesto / 100)), 0)
            Else
                _preciounitario = Math.Round((((factor / 100) * _costounitario) + _costounitario), 0)
            End If
            _preciototal = _preciounitario * cantidad
            _valorDescuento = _preciototal * descuento
            _precioinstalacion = (If(_metroscuadrados < 1, 1, _metroscuadrados) * cantidad * pxund) * precioMtInstalacion
            _metroscuadrados = (_metroscuadrados * cantidad) * pxund
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Calcular_Accesorios(idaccesorio As Integer, cantidad As Decimal, piezasxunidad As Decimal,
                                   versionCostoAccesorio As Integer, desperdicio_Accesorio As Decimal,
                                   factor As Decimal, descuento As Decimal, costo_unitario_instalacion As Decimal,
                                   tabla_trabajos As DataTable)
        Try
            Inicio()
            Calcular_Trabajos(tabla_trabajos)

            Dim fact_desperdicio As Decimal = 1 + (desperdicio_Accesorio / 100)
            fact_desperdicio = If(fact_desperdicio <= 0, 1, fact_desperdicio)
            descuento /= 100
            mCostoAccesorios = New ClsCostoAccesorio
            Dim CA As costoAccesorio = mCostoAccesorios.TraerxIdAccesorio(idaccesorio, versionCostoAccesorio)
            _costounitario = ((CA.costo * fact_desperdicio) + costo_unitario_instalacion + cosTrabajos) * piezasxunidad
            _vlrdespAccesorios = (CA.costo * ((desperdicio_Accesorio) / 100))
            _preciounitario = Math.Round((_costounitario + ((factor / 100) * _costounitario)), 0)
            _costototal = _costounitario * cantidad
            _costoaccesorios = _costototal
            _preciototal = _preciounitario * cantidad
            _valorDescuento = _preciototal * descuento
            _precioinstalacion = 0
            _metroscuadrados = 0
            _costo_instalacion = costo_unitario_instalacion * cantidad * piezasxunidad
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Calcular_Perfiles(idperfil As Integer, idacabado As Integer, version_costo_acabado As Integer,
                                 version_costo_nivel As Integer, version_costo_kilo_aluminio As Integer,
                                 dimension As Decimal, cantidad As Decimal, piezas_x_unidad As Decimal,
                                 desperdicio_perfiles As Decimal, factor As Decimal, descuento As Decimal,
                                 precio_metro_instalacion As Decimal, costo_unitario_instalacion As Decimal,
                                 tabla_trabajos As DataTable)
        Try
            Inicio()
            dimension /= 1000
            descuento /= 100
            Calcular_Trabajos(tabla_trabajos)
            mCostoPerfil = New ClsCostoAluminio
            Dim fact_desperdicio As Decimal = 1 + (desperdicio_perfiles / 100)
            fact_desperdicio = If(fact_desperdicio <= 0, 1, fact_desperdicio)
            Dim CP As Decimal = mCostoPerfil.TraerCostoEspecifico(idperfil, idacabado, version_costo_acabado,
                                                                  version_costo_nivel, version_costo_kilo_aluminio)
            _costounitario = ((CP * fact_desperdicio * dimension) + cosTrabajos + costo_unitario_instalacion) * piezas_x_unidad
            _vlrdespPerfiles = Convert.ToDecimal((dimension * ((desperdicio_perfiles / 100))) * CP) * cantidad * piezas_x_unidad
            If _indAIU Then
                _preciounitario = Math.Round(((_costounitario + ((factor / 100) * _costounitario)) + (_costounitario * (tasaImpuesto / 100))), 0)
            Else
                _preciounitario = Math.Round((_costounitario + ((factor / 100) * _costounitario)), 0)
            End If
            _costototal = _costounitario * cantidad
            _costoperfiles = _costototal
            _preciototal = _preciounitario * cantidad
            _valorDescuento = _preciototal * descuento
            _precioinstalacion = dimension * precio_metro_instalacion
            _metroscuadrados = 0
            _costo_instalacion = costo_unitario_instalacion * cantidad * piezas_x_unidad
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Calcular_Vidrios(idvidrio As Integer, idespesor As Integer, idcolorvidrio As Integer,
                                version_costo_vidrio As Integer, ancho As Decimal, alto As Decimal,
                                cantidad As Decimal, piezas_x_unidad As Decimal, desperdicio_vidrio As Decimal,
                                factor As Decimal, descuento As Decimal, precio_metro_instalacion As Decimal,
                                costo_unitario_instalacion As Decimal, tabla_trabajos As DataTable)
        Try
            Inicio()
            Dim factor_desperdicio As Decimal = 1 + (desperdicio_vidrio / 100)
            factor_desperdicio = If(factor_desperdicio <= 0, 1, factor_desperdicio)
            ancho /= 1000
            alto /= 1000
            descuento /= 100
            Calcular_Trabajos(tabla_trabajos)
            mCostoVidrio = New ClsCostoVidrio
            Dim CV As Decimal = mCostoVidrio.TraerCosto(idvidrio, idespesor, idcolorvidrio, version_costo_vidrio)
            _metroscuadrados = ancho * alto
            _costounitario = ((CV * factor_desperdicio) + cosTrabajos + costo_unitario_instalacion) * _metroscuadrados * piezas_x_unidad
            _vlrdespVidrio = CV * (_metroscuadrados * (factor_desperdicio - 1))
            If _indAIU Then
                _preciounitario = Math.Round((_costounitario + ((factor / 100) * _costounitario)) + ((_costounitario * (tasaImpuesto / 100))), 0)
            Else
                _preciounitario = Math.Round((_costounitario + ((factor / 100) * _costounitario)), 0)
            End If
            _costototal = _costounitario * cantidad
            _costovidrio = _costototal
            _preciototal = _preciounitario * cantidad
            _valorDescuento = _preciototal * descuento
            _precioinstalacion = (If(_metroscuadrados < 1, 1, _metroscuadrados) * cantidad) * precio_metro_instalacion
            _metroscuadrados = (_metroscuadrados * cantidad)
            _costo_instalacion = costo_unitario_instalacion * cantidad * piezas_x_unidad
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Calcular_Otros(idotro As Integer, cantidad As Decimal, piezasxunidad As Decimal,
                            version_costo_otros As Integer, desperdicio_otros As Decimal,
                            factor As Decimal, descuento As Decimal, costo_instalacion_unitario As Decimal,
                              tabla_trabajos As DataTable)
        Try
            Inicio()
            descuento /= 100
            Calcular_Trabajos(tabla_trabajos)
            Dim factor_desperdicio As Decimal = 1 + (desperdicio_otros / 100)
            factor_desperdicio = If(factor_desperdicio <= 0, 1, factor_desperdicio)
            mCostoOtros = New ClsCostoOtrosArticulos
            Dim CO As OtrosArticulos = mCostoOtros.TraerxIdArticulo(idotro, version_costo_otros)
            _costounitario = ((CO.costo * factor_desperdicio) + costo_instalacion_unitario + cosTrabajos) * piezasxunidad
            _vlrdespOtros = (CO.costo * ((desperdicio_otros) / 100))
            If _indAIU Then
                _preciounitario = Math.Round(_costounitario + ((factor / 100) * _costounitario) * ((1 + (desperdicio_otros / 100))) + (_costounitario * (tasaImpuesto / 100)), 0)
            Else
                _preciounitario = Math.Round(_costounitario + ((factor / 100) * _costounitario) * ((1 + (desperdicio_otros / 100))), 0)
            End If
            _costototal = _costounitario * cantidad
            _preciototal = _preciounitario * cantidad
            _valorDescuento = _preciototal * descuento
            _costootros = _costototal
            _precioinstalacion = 0
            _metroscuadrados = 0
            _costo_instalacion = costo_instalacion_unitario * cantidad * piezasxunidad
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Temporales(articulo As articuloTemporal, cantidad As Integer, pxunid As Decimal, ancho As Decimal, alto As Decimal,
                          acabado As acabadoTemporal, vidrio As articuloTemporal, color As acabadoTemporal, espesor As espesorTemporal,
                          descuento As Decimal, factor As Decimal, precioMtInstalacion As Decimal, Optional prcDesperdicio As Decimal = 0,
                          Optional idCotiza As Integer = 0, Optional dTableTrabajos As DataTable = Nothing)
        Try
            _costounitario = 0
            _costototal = 0
            _preciounitario = 0
            _preciototal = 0
            _precioinstalacion = 0
            _costovidrio = 0
            _costoperfiles = 0
            _costoaccesorios = 0
            _costootros = 0
            ValorDescuento = 0
            _metroscuadrados = 0
            ancho = (ancho / 1000)
            alto = (alto / 1000)
            descuento = (descuento / 100)
            prcDesperdicio = prcDesperdicio / 100

            If dTableTrabajos IsNot Nothing Then
                Dim mCostoTrabajo As New ClsCostoTrabajoItem
                For Each row As DataRow In dTableTrabajos.Rows
                    Dim cos As Decimal = mCostoTrabajo.TraerEspecifico(1, CInt(row("idTrabajo"))).Costo
                    cosTrabajos += cos * CInt(row("cantidad"))
                Next
            End If
            Select Case articulo.IdFamiliaMaterial
                Case ClsEnums.FamiliasMateriales.ACCESORIOS
                    _costounitario = articulo.Costo + cosTrabajos
                    _preciounitario = (_costounitario + ((factor / 100) * _costounitario)) * pxunid
                    _vlrdespOtros = (articulo.Costo * ((prcDesperdicio) / 100)) * pxunid
                    _costototal = (_costounitario * cantidad) * pxunid
                    _preciototal = _preciounitario * cantidad
                    ValorDescuento = _preciototal * descuento
                    _costoaccesorios = articulo.Costo * cantidad * pxunid
                    _precioinstalacion = 0
                    _metroscuadrados = 0
                Case ClsEnums.FamiliasMateriales.PERFILERIA
                    Dim mCostoPerfTemp As New ClsCostoPerfilTemporal
                    Dim costoPerf As costoPerfilTemporal = mCostoPerfTemp.TraerCostoEspecifico(idCotiza, articulo.Temporal,
                                                                                               articulo.Id, acabado.Temporal, acabado.IdDb)
                    Dim CP As Decimal = costoPerf.Costo
                    _costounitario = Convert.ToDecimal((ancho * prcDesperdicio + ancho) * CP) + cosTrabajos
                    _vlrdespOtros = Convert.ToDecimal((ancho * ((prcDesperdicio / 100))) * _costounitario) * cantidad * pxunid
                    _preciounitario = _costounitario + ((factor / 100) * _costounitario)
                    _costototal = Convert.ToDecimal(_costounitario * cantidad)
                    _preciototal = _preciounitario * cantidad
                    ValorDescuento = _preciototal * descuento
                    _costoperfiles = ancho * CP * cantidad * pxunid
                    _precioinstalacion = ancho * precioMtInstalacion
                    _metroscuadrados = 0
                Case ClsEnums.FamiliasMateriales.OTROS
                    _costounitario = articulo.Costo + cosTrabajos
                    _preciounitario = (_costounitario + ((factor / 100) * _costounitario)) * pxunid
                    _vlrdespOtros = (articulo.Costo * ((prcDesperdicio) / 100)) * pxunid
                    _costototal = _costounitario * cantidad * pxunid
                    _preciototal = _preciounitario * cantidad
                    ValorDescuento = _preciototal * descuento
                    _costootros = _costototal
                    _precioinstalacion = 0
                    _metroscuadrados = 0
                Case ClsEnums.FamiliasMateriales.VIDRIO
                    Dim mCostoVidTemp As New ClsCostoVidrioTemporal
                    Dim costoVid As costoVidrioTemporal = mCostoVidTemp.TraerCostoEspecifico(idCotiza, vidrio.Temporal, vidrio.IdDb,
                                                                                             espesor.Temporal, espesor.IdDb,
                                                                                             color.Temporal, color.IdDb)
                    Dim CV As Decimal = costoVid.Costo
                    _metroscuadrados = ancho * alto
                    _costounitario = CV * _metroscuadrados + cosTrabajos
                    _preciounitario = _costounitario + ((factor / 100) * _costounitario)
                    _costototal = _costounitario * cantidad * pxunid
                    _preciototal = _preciounitario * cantidad
                    ValorDescuento = _preciototal * descuento
                    _costovidrio = _costototal
                    _precioinstalacion = 0
                    If _metroscuadrados < 1 Then
                        _precioinstalacion = (cantidad) * precioMtInstalacion
                        _metroscuadrados = cantidad
                    Else
                        _precioinstalacion = (_metroscuadrados * cantidad) * precioMtInstalacion
                        _metroscuadrados = (_metroscuadrados * cantidad)
                    End If
            End Select
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
