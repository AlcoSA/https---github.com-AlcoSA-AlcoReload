Imports System.ComponentModel
Imports DatagridTreeView
Imports Formulador
Imports Informes
Imports Multiusos
Imports Norma_NSR
Imports ReglasNegocio
Imports ReglasNegocio.CategExposicion
Imports ReglasNegocio.Ciudades
Imports ReglasNegocio.Componente
Imports ReglasNegocio.CostoAcabado
Imports ReglasNegocio.CostoKiloAluminio
Imports ReglasNegocio.CostoNivel
Imports ReglasNegocio.cotizaciones
Imports ReglasNegocio.Factores
Imports ReglasNegocio.FormasPago
Imports ReglasNegocio.grupoUso
Imports ReglasNegocio.ManoObraInstalacion
Imports ReglasNegocio.movitoHijos
Imports ReglasNegocio.movitoPadres
Imports ReglasNegocio.TasaImpuesto
Imports ReglasNegocio.TiempoEntrega
Imports ReglasNegocio.tipoCubuerta
Imports ReglasNegocio.tipoEdificacion
Imports Validaciones
Public Class FrmCotizaciones
#Region "Variables"
#Region "Globales"
    Public curid As Integer = 0
    Public versionCostoKiloAluminio As Integer
    Public versionCostoVidrio As Integer
    Public versionCostoAccesorio As Integer
    Public versionCostoAcabado As Integer
    Public versionCostoNivel As Integer
    Public versionCostoOtrosArticulos As Integer
    Private isLoad As Boolean
    Private guardado As Boolean
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private idHistoriaModi As Integer = 0
    Private movimientoModificable As Boolean
    Private haveEmpty As Boolean
    Private tImpuesto As tasaImpuesto
    Private analizador As AnalizadorLexico
    Private seleccionAnterior As Integer
    Private puedeCambiar As Boolean = False
    Private objCostoVidrio As ClsCostoVidrio
    Private objCostoAccesorio As ClsCostoAccesorio
    Private objCostoAcabado As ClsCostoAcabado
    Private objCostoNivel As ClsCostoNivel
    Private objCostoOtrosArticulos As ClsCostoOtrosArticulos
    Private objValidacion As ClsValidaciones
    Private objCostoKiloAluminio As ClsCostoKiloAluminio
    Private objFactor As ClsFactores
    Private objInstalacion As ClsManoObraInstalacion
    Private mCotizacion As ClsCostizaciones
    Private mMovitoPadre As ClsMovitoPadres
    Private mMovitoHijo As ClsMovitoHijos
    Private mDigitoVerificacion As DigitoVerificacion
    Private mLimpiezaCampos As LimpiarCampos
    Private mAcabados As ClsAcabados
    Private mArticulos As ClsArticulos
    Private mEspesor As ClsEspesores
    Private mformaPago As ClsFormasPago
    Private mEstados As ClsEstados
    Private mTasaImpuesto As ClsTasaImpuesto
    Private mTiempoEntrega As ClsTiempoEntrega
    Private mTipoDocumento As ClsTiposIdentificacion
    Private mCiudad As ClsCiudades
    Private mTipoEdificacion As ClsTipoEdificacion
    Private mCategExposicion As ClsCategExposicion
    Private mGrupoUso As ClsGrupoUso
    Private mTipoCubierta As ClsTipoCubierta
    Private mEstado As ClsEstados
    Private mVendedor As ClsVendedoresSiesa
    Private mTipoObra As ClsTiposObras
    Private mVigencia As ClsVigencias
    Private listAcabadoGlobal As List(Of Acabado)
    Private listFormasPago As List(Of formaPago)
    Private listTiempoEntrega As List(Of tiempoEntrega)
    Private listTImpuesto As List(Of tasaImpuesto)
    Private listTipoDoc As List(Of TiposIdentificacion)
    Private listCiudades As List(Of Ciudad)
    Private listEdificacion As List(Of tipoEdificacion)
    Private listCategExp As List(Of categExposicion)
    Private listGruposUso As List(Of grupoUso)
    Private listTipoCubierta As List(Of tipoCubuertas)
    Private listPresionesModelo As List(Of presionModelos)
    Private listEstados As List(Of Estado)
    Private listVendedores As List(Of vendedor)
    Private listTipoObra As List(Of tipoObra)
    Private listVigencia As List(Of Vigencia)
    Private listByNombreCliente As List(Of cotizacion)
    Private listByDocumentoCliente As List(Of cotizacion)
    Private listByNombreCotiza As List(Of cotizacion)
    Private listByNombreObra As List(Of cotizacion)
    Private listaCosto As New List(Of costo)
    Private _tieneTemporales As Boolean = False
    Private _defaultDespVidrio As Integer
    Private _defaultPerfiles As Integer
    Private _defaultAccesorio As Integer
    Private _defaultDespOtros As Integer
#End Region
#Region "Backup Plantillas"
    Private mvarhijocotiza As ClsVariablesPlantillaCotiza
    Private mmaterialhijocotiza As ClsMaterialesPlantillaCotiza
    Private mdibujohijocotiza As ClsDibujosPlantillaCotiza
    Private mobservacioneshijocotiza As ClsObservacionesPlantillaCotiza
    Private mdescuentosgeneraleshijocotiza As ClsDescuentosGeneralesPlantillaCotiza
    Private mdescuentosmaterialplantillacotiza As ClsDescuentosMaterialPlantillaCotiza

#End Region
#Region "Listas de temporales"
    Private listColores As List(Of acabadoTemporal)
    Private listAcabados As List(Of acabadoTemporal)
    Private listArticulos As List(Of articuloTemporal)
    Private listEspesores As List(Of espesorTemporal)
#End Region
#Region "Cambio General Re-calculo"
    Dim originalacabadoseleccionado As Integer = 0
#End Region
#Region "especiales"
    Private _duplicado As Boolean = False
#End Region
#End Region
#Region "Propiedades"
    Public Property Duplicado As Boolean
        Get
            Return _duplicado
        End Get
        Set(value As Boolean)
            _duplicado = value
        End Set
    End Property
    Public Property IdActual As Integer
        Get
            Return curid
        End Get
        Set(value As Integer)
            curid = value
        End Set
    End Property
    Public Property OperacionActual As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Ciudad As Integer
    Public Property TieneTemporales() As Boolean
        Get
            Return _tieneTemporales
        End Get
        Set(ByVal value As Boolean)
            _tieneTemporales = value
        End Set
    End Property
    Private _indAIU As Boolean
    Public Property indAIU() As Boolean
        Get
            Return _indAIU
        End Get
        Set(ByVal value As Boolean)
            _indAIU = value
        End Set
    End Property
#End Region
#Region "Permisos especiasles"
    Sub aplicarPermisos()
        Try
            If Not My.Settings.Permisos.Contains("102.1") Then
                tbVistaInterna.Parent = Nothing
            ElseIf tbVistaInterna.Parent Is Nothing Then
                tbVistaInterna.Parent = tbCotizaciones
            End If
            If Not My.Settings.Permisos.Contains("102.2") Then
                tbVistaAsesor.Parent = Nothing
            ElseIf tbVistaAsesor.Parent Is Nothing Then
                tbVistaAsesor.Parent = tbCotizaciones
            End If
            If Not My.Settings.Permisos.Contains("102.3") Then
                tbpCostos.Parent = Nothing
            ElseIf tbpCostos.Parent Is Nothing Then
                tbpCostos.Parent = tbCotizaciones
            End If
            If Not My.Settings.Permisos.Contains("102.4") Then
                tbpCondiciones.Parent = Nothing
            ElseIf tbpCondiciones.Parent Is Nothing Then
                tbpCondiciones.Parent = tbCotizaciones
            End If
            If Not My.Settings.Permisos.Contains("102.5") Then
                btncondicion.Enabled = False
            End If
            If Not My.Settings.Permisos.Contains("102.6") Then
                btonRestablecerOriginales.Enabled = False
            End If
            If Not My.Settings.Permisos.Contains("102.7") Then
                btnvisibilidadcolumnas.Enabled = False
            End If
            If Not My.Settings.Permisos.Contains("102.8") Then
                btnseleccionarvarios.Enabled = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Procedimientos para calculo de costos en los materiales"
    Private Sub cargarCostosegunTipo(ndh As DataGridViewTreeNode)
        Try
            Dim t As ClsEnums.FamiliasMateriales = DirectCast(ndh.Cells(tipoItem.Index).Value, ClsEnums.FamiliasMateriales)
            Dim calculo As New ClsCalculos
            calculo.tasaImpuesto = DirectCast(cmbTasaImpuesto.SelectedItem, ReglasNegocio.TasaImpuesto.tasaImpuesto).tasa
            calculo.indAIU = gbxParametrosAIU.Enabled
            Select Case t
                Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
                    calculo.Calcular_Accesorios(ndh.Cells(idArticulo.Index).Value, ndh.Cells(Cantidad.Index).Value,
                                                ndh.Cells(piezasxUnidad.Index).Value, 0,
                                                0, ndh.Cells(factor.Index).Value, ndh.Cells(descuento.Index).Value,
                                                ndh.Cells(costoinstalacion.Index).Value, ndh.Cells(especial.Index).Value)
                    'calculo.General(Convert.ToInt32(ndh.Cells(idArticulo.Index).Value), ClsEnums.FamiliasMateriales.ACCESORIOS,
                    '                Convert.ToDecimal(ndh.Cells(Cantidad.Index).Value), Convert.ToDecimal(ndh.Cells(piezasxUnidad.Index).Value),
                    '                0, 0, 0, 0, 0, 0, Convert.ToDecimal(ndh.Cells(descuento.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(factor.Index).Value), Convert.ToDecimal(ndh.Cells(precioMtInstalacion.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(costoinstalacion.Index).Value))

                Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
                    calculo.Calcular_Perfiles(ndh.Cells(idArticulo.Index).Value, ndh.Cells(acabadoPerf.Index).Value,
                          0, 0, 0,
                          ndh.Cells(ancho.Index).Value, ndh.Cells(Cantidad.Index).Value,
                          ndh.Cells(piezasxUnidad.Index).Value, 0, ndh.Cells(factor.Index).Value,
                          ndh.Cells(descuento.Index).Value, ndh.Cells(precioMtInstalacion.Index).Value,
                          ndh.Cells(costoinstalacion.Index).Value, ndh.Cells(especial.Index).Value)
                    'calculo.General(Convert.ToInt32(ndh.Cells(idArticulo.Index).Value), ClsEnums.FamiliasMateriales.PERFILERIA, Convert.ToDecimal(ndh.Cells(Cantidad.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(piezasxUnidad.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(ancho.Index).Value), 0, Convert.ToInt32(ndh.Cells(acabadoPerf.Index).Value), 0, 0, 0, Convert.ToDecimal(ndh.Cells(descuento.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(factor.Index).Value), Convert.ToDecimal(ndh.Cells(precioMtInstalacion.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(costoinstalacion.Index).Value))

                Case Is = ClsEnums.FamiliasMateriales.VIDRIO
                    calculo.Calcular_Vidrios(ndh.Cells(vidrio.Index).Value,
                         ndh.Cells(espesor.Index).Value,
                         ndh.Cells(colorVidrio.Index).Value,
                         0, ndh.Cells(ancho.Index).Value, ndh.Cells(Alto.Index).Value,
                         ndh.Cells(Cantidad.Index).Value, ndh.Cells(piezasxUnidad.Index).Value, 0,
                         ndh.Cells(factor.Index).Value, ndh.Cells(descuento.Index).Value,
                         ndh.Cells(precioMtInstalacion.Index).Value, ndh.Cells(costoinstalacion.Index).Value,
                         ndh.Cells(especial.Index).Value)
                    'calculo.General(Convert.ToInt32(ndh.Cells(idArticulo.Index).Value), ClsEnums.FamiliasMateriales.VIDRIO, Convert.ToDecimal(ndh.Cells(Cantidad.Index).Value), Convert.ToDecimal(ndh.Cells(piezasxUnidad.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(ancho.Index).Value), Convert.ToDecimal(ndh.Cells(Alto.Index).Value), 32, Convert.ToInt32(ndh.Cells(vidrio.Index).Value), Convert.ToInt32(ndh.Cells(colorVidrio.Index).Value),
                    '                Convert.ToInt32(ndh.Cells(espesor.Index).Value), Convert.ToDecimal(ndh.Cells(descuento.Index).Value), Convert.ToDecimal(ndh.Cells(factor.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(precioMtInstalacion.Index).Value),
                    '                Convert.ToDecimal(ndh.Cells(costoinstalacion.Index).Value))

                Case Is = ClsEnums.FamiliasMateriales.DISEÑOS
                    Dim analiza As AnalizadorLexico = DirectCast(ndh.Cells(especial.Index).Value, AnalizadorLexico)
                    Dim alto As Decimal = Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor)
                    Dim ancho As Decimal = Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor)
                    Dim idAcabado As Integer = DirectCast(acabadoPerf.DataSource, List(Of Acabado)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("ACABADO").Valor).Id
                    Dim idVidrio As Integer = DirectCast(vidrio.DataSource, List(Of Articulo)).First(Function(x) x.Referencia = analiza.ListaVariables.Item("TIPO_VIDRIO").Valor).Id
                    Dim idColorVidrio As Integer = DirectCast(colorVidrio.DataSource, List(Of Acabado)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("COLOR_VIDRIO").Valor).Id
                    Dim idEspesor As Integer = DirectCast(espesor.DataSource, List(Of Espesor)).First(Function(x) Convert.ToString(x.Prefijo) = Convert.ToString(analiza.ListaVariables.Item("ESPESOR").Valor)).Id
                    Dim costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costo_unitario, costo_instalacion As Decimal
                    costoVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    costoPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    costoAccesorios = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    costoOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    costo_unitario = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                    costo_instalacion = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Instalacion_Total))
                    calculo.Calcular_Disenio(costo_unitario,
                         Convert.ToInt32(analiza.ListaVariables.Item("CANTIDAD").Valor), ndh.Cells(piezasxUnidad.Index).Value,
                         ancho, alto, ndh.Cells(descuento.Index).Value,
                         ndh.Cells(factor.Index).Value, ndh.Cells(precioMtInstalacion.Index).Value,
                         costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costo_instalacion)

                Case Is = ClsEnums.FamiliasMateriales.OTROS
                    calculo.Calcular_Otros(ndh.Cells(idArticulo.Index).Value, ndh.Cells(Cantidad.Index).Value,
                            ndh.Cells(piezasxUnidad.Index).Value, 0,
                            0, ndh.Cells(factor.Index).Value, ndh.Cells(descuento.Index).Value,
                            ndh.Cells(costoinstalacion.Index).Value, ndh.Cells(especial.Index).Value)
            End Select
            ndh.Cells(valorDescuento.Index).Value = calculo.ValorDescuento
            ndh.Cells(costoUnitario.Index).Value = calculo.CostoUnitario
            ndh.Cells(precioUnitario.Index).Value = calculo.PrecioUnitario
            ndh.Cells(costoTotal.Index).Value = calculo.CostoTotal
            ndh.Cells(precioTotal.Index).Value = calculo.PrecioTotal
            ndh.Cells(costoAccesorios.Index).Value = calculo.CostoAccesorio
            ndh.Cells(costoPerfiles.Index).Value = calculo.CostoPerfiles
            ndh.Cells(costoVidrio.Index).Value = calculo.CostoVidrio
            ndh.Cells(costoOtros.Index).Value = calculo.CostoOtros
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
#Region "Procedimientos"
    Public Sub CargarRegistroDuplicacion()
        Try
            Dim regtdup As New ClsRegistroDuplicacion
            Dim base_dup As RegistroDuplicacion = regtdup.TraerporIdDuplicado(curid)
            lbidfuente.Tag = base_dup.IdCotizaBase
            lbidfuente.Text = Convert.ToString(base_dup.IdCotizaBase) & "-" & base_dup.Nombre_Cotiza
            Dim l_dups As List(Of RegistroDuplicacion) = regtdup.TraerporIdBase(curid)
            Dim dic As New Dictionary(Of Integer, String)
            l_dups.All(Function(x)
                           dic.Add(x.IdCotizaDuplicada, Convert.ToString(x.IdCotizaDuplicada) & "-" & x.Nombre_Cotiza)
                           Return False
                       End Function)



            Dim bsource As New BindingSource()
            bsource.DataSource = dic
            lbduplicados.DisplayMember = "Value"
            lbduplicados.ValueMember = "Key"
            lbduplicados.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub GuardarDibujos(est As ControlesPersonalizados.Estructurador.RegionEstructuras, iditem As Integer, idcontenedor As Integer, nivel As Integer)
        Try
            Dim gdib As New ClsDibujosItemsCotiza
            Dim idcont As Integer = 0
            Dim mdxf As String = "Pared"
            Select Case est.TipoEstructura
                Case ControlesPersonalizados.Estructurador.Tipo_Estructura.BASICO
                    If Not String.IsNullOrEmpty(Convert.ToString(est.Estructura)) Then
                        mdxf = est.Estructura
                    End If
                Case ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ARRIBA
                    mdxf = "Ele_Arriba"
                Case ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_IZQUIERDA
                    mdxf = "Ele_Izquierda"
                Case ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ABAJO
                    mdxf = "Ele_Abajo"
                Case ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_DERECHA
                    mdxf = "Ele_Derecha"
                Case ControlesPersonalizados.Estructurador.Tipo_Estructura.PERFIL
                    mdxf = "Perfil&" & est.Referencia_Perfil & "&" & est.Acabado_Perfil
            End Select
            If est.Index_Hijo_Owner = -1 And est.Id_Hijo_Owner <= 0 Then
                idcont = gdib.Ingresar(iditem, 0, My.Settings.UsuarioActivo, mdxf,
                          est.X, est.Y, est.Ancho, est.Alto, est.OrientacionEstructura, nivel, idcontenedor)
            Else
                If est.Id_Hijo_Owner > 0 Then
                    idcont = gdib.Ingresar(iditem, est.Id_Hijo_Owner, My.Settings.UsuarioActivo, mdxf,
                          est.X, est.Y, est.Ancho, est.Alto, est.OrientacionEstructura, nivel, idcontenedor)
                Else
                    Dim idh As Integer = Convert.ToInt32(dwItems.Nodes.First(Function(n) Convert.ToInt32(n.Cells(id.Index).Value) = iditem).Nodes(est.Index_Hijo_Owner).Cells(id.Index).Value)
                    idcont = gdib.Ingresar(iditem, idh, My.Settings.UsuarioActivo, mdxf,
                          est.X, est.Y, est.Ancho, est.Alto, est.OrientacionEstructura, nivel, idcontenedor)
                End If
            End If
            For i = 0 To est.Estructuras.Count - 1
                GuardarDibujos(est.Estructuras(i), iditem, idcont, nivel + 1)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub guardar_costos_adicionales()
        Try
#Region "costos adicionales"
            Dim c_ad_cot As New ClsExtraCostosCotiza
            dwcostosextra.Rows.Cast(Of DataGridViewRow).ToList().ForEach(Sub(x)
                                                                             If Convert.ToInt32(x.Cells(idadicionalcotiza.Index).Value) > 0 Then
                                                                                 If Convert.ToInt32(x.Cells(duracion.Index).Value) > 0 Then
                                                                                     c_ad_cot.Modificar(Convert.ToInt32(x.Cells(idadicional.Index).Value), curid,
                                                                                                        Convert.ToDecimal(x.Cells(costoadicional.Index).Value),
                                                                                                        Convert.ToInt32(x.Cells(duracion.Index).Value), My.Settings.UsuarioActivo,
                                                                                                        Convert.ToInt32(x.Cells(idadicionalcotiza.Index).Value))
                                                                                 Else
                                                                                     c_ad_cot.EliminarporId(Convert.ToInt32(x.Cells(idadicionalcotiza.Index).Value))
                                                                                 End If
                                                                             Else
                                                                                 If Convert.ToInt32(x.Cells(duracion.Index).Value) > 0 Then
                                                                                     c_ad_cot.Insertar(Convert.ToInt32(x.Cells(idadicional.Index).Value), curid,
                                                                                                        Convert.ToDecimal(x.Cells(costoadicional.Index).Value),
                                                                                                        Convert.ToInt32(x.Cells(duracion.Index).Value), My.Settings.UsuarioActivo)
                                                                                 End If
                                                                             End If
                                                                         End Sub
                )
#End Region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que inserta la información por primera vez en la base de datos,
    ''' y cambia la variable de enumeriación a modificado.
    ''' </summary>
    Private Sub insertar()
        Try
#Region "Encabezado y generales"
            curid = mCotizacion.Ingresar(My.Settings.UsuarioActivo, txtNombreCotizacion.Text, dtpFecha.Value, cmbTipoObra.SelectedValue, cmbVendedor.SelectedValue,
                                         cmbAcabado.SelectedValue, Ciudad, cmbFactor.SelectedValue, nudDescuentoSum.Value, cmbFormaPago.SelectedValue, cmbTiempoEntrega.SelectedValue,
                                         Convert.ToInt32(cbInstalacion.Tag), cmbInstalacion.SelectedValue, cmbTasaImpuesto.SelectedValue, cmbVigencia.SelectedValue,
                                         nudPorcAdministracion.Value, nudPorcImprovistos.Value, nudPorcUtilidad.Value, cmbTipoDocumento.SelectedValue,
                                         txtDocumento.Text, txtDigitoVerificacion.Text, txtCliente.Text, txtTelefonoCliente.Text,
                                         txtDireccionCliente.Text, txtCorreoCliente.Text, txtContactoCliente.Text, txtNombreObra.Text, txtContactoObra.Text,
                                         txtTelefonoObra.Text, txtCorreoObra.Text, cmbTipoEdificacion.SelectedValue, cmbCategExposicion.SelectedValue,
                                         cmbComponente.SelectedValue, cmbGruposUso.SelectedValue, cmbTipoCubierta.SelectedValue, cmbpresionModelo.SelectedValue, nudAltoEdificio.Value,
                                         nudAnchoEdificio.Value, nudAlturaCaballete.Value, nudAlturaAlero.Value, nudAltoEntreLosas.Value, versionCostoVidrio,
                                         versionCostoAcabado, versionCostoNivel, versionCostoKiloAluminio, versionCostoAccesorio, versionCostoOtrosArticulos, 1, 1,
                                         cmbEstado.SelectedValue, nudDescuentoInst.Value, cbCobroMetros.Checked, If(lblTipoImpuesto.Text = "IVA pleno", False, True))
            ClsInterbloqueos.Bloquear(curid, ClsEnums.ModulosAplicacion.MODULO_COTIZACIONES, My.Settings.UsuarioActivo)

#End Region

#Region "Condiciones"
            Dim _objcondicion As New ClsCondicionCotiza
            dwCondiciones.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(fila)
                                                                           _objcondicion.insert(My.Settings.UsuarioActivo, curid, fila.Cells(Condicion.Index).Value, If(CBool(fila.Cells(Estado.Index).Value),
                                                                                                ClsEnums.Estados.ACTIVO, ClsEnums.Estados.ARCHIVADO), fila.Cells(Grupo.Index).Value)
                                                                       End Sub)
#End Region
            guardar_costos_adicionales()
            Dim cd As New CargaDibujos
            dwItems.Nodes.ToList.ForEach(Sub(dgvTv)
                                             mMovitoPadre = New ClsMovitoPadres
                                             dgvTv.Cells(id.Index).Value = mMovitoPadre.Ingresar(My.Settings.UsuarioActivo, curid, Convert.ToString(dgvTv.Cells(Ubicacion.Index).Value), Convert.ToString(dgvTv.Cells(Descripcion.Index).Value),
                                                                                                Convert.ToDecimal(dgvTv.Cells(ancho.Index).Value), Convert.ToDecimal(dgvTv.Cells(Alto.Index).Value), Convert.ToInt32(dgvTv.Cells(Cantidad.Index).Value),
                                                                                                Convert.ToInt32(dgvTv.Cells(acabadoPerf.Index).Value),
                                                                                                listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(vidrio.Index).Value)).IdDb,
                                                                                                listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(colorVidrio.Index).Value)).IdDb,
                                                                                                listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(espesor.Index).Value)).IdDb,
                                                                                                Convert.ToInt32(dgvTv.Cells(factor.Index).Value), Convert.ToInt32(dgvTv.Cells(descuento.Index).Value), versionCostoVidrio, versionCostoAccesorio,
                                                                                                versionCostoNivel, versionCostoAcabado, versionCostoKiloAluminio, versionCostoOtrosArticulos, Convert.ToBoolean(dgvTv.Cells(calcularnorma.Index).Value),
                                                                                                Convert.ToBoolean(dgvTv.Cells(cumplenorma.Index).Value), Convert.ToInt32(dgvTv.Cells(numero_cuerpos_norma.Index).Value),
                                                                                                Convert.ToInt32(dgvTv.Cells(idpropiedad.Index).Value), ClsEnums.Estados.ACTIVO, Convert.ToInt32(dgvTv.Cells(precioMtInstalacion.Index).Value),
                                                                                                Convert.ToDecimal(dgvTv.Cells(precioInstalacion.Index).Value), Convert.ToDecimal(dgvTv.Cells(tasaImpuesto.Index).Value),
                                                                                                Convert.ToDecimal(dgvTv.Cells(costoVidrio.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoPerfiles.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoAccesorios.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoOtros.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoUnitario.Index).Value),
                                                                                                Convert.ToDecimal(dgvTv.Cells(costoTotal.Index).Value), Convert.ToDecimal(dgvTv.Cells(precioUnitario.Index).Value), Convert.ToDecimal(dgvTv.Cells(precioTotal.Index).Value), Convert.ToDecimal(dgvTv.Cells(valorDescuento.Index).Value),
                                                                                                Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioVidrio.Index).Value), Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioPerfiles.Index).Value),
                                                                                                Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioAccesorios.Index).Value), Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioOtros.Index).Value), cd.crearBitMap(dgvTv.Cells(especial.Index).Value),
                                                                                                Convert.ToString(dgvTv.Cells(unmedinstala.Index).Value), Convert.ToString(dgvTv.Cells(descuentoinstala.Index).Value))
                                             dgvTv.Nodes.ToList.ForEach(Sub(r)
                                                                            mMovitoHijo = New ClsMovitoHijos
                                                                            r.Cells(id.Index).Value = mMovitoHijo.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(dgvTv.Cells(id.Index).Value),
                                                                   If(Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS, 0, Convert.ToInt32(r.Cells(idArticulo.Index).Value)),
                                                                   If(Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS, Convert.ToInt32(r.Cells(idArticulo.Index).Value), 0),
                                                                   If(Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.TEMPORAL, Convert.ToInt32(r.Cells(idArticuloTemp.Index).Value), 0), Convert.ToInt32(r.Cells(Cantidad.Index).Value),
                                                                   Convert.ToDecimal(r.Cells(piezasxUnidad.Index).Value), Convert.ToDecimal(r.Cells(ancho.Index).Value), Convert.ToDecimal(r.Cells(Alto.Index).Value),
                                                                   listAcabados.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(acabadoPerf.Index).Value)).IdDb,
                                                                   listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(vidrio.Index).Value)).IdDb,
                                                                   listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(colorVidrio.Index).Value)).IdDb,
                                                                   listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(espesor.Index).Value)).IdDb,
                                                                   versionCostoVidrio, versionCostoNivel, versionCostoAcabado,
                                                                   versionCostoKiloAluminio, versionCostoAccesorio, versionCostoOtrosArticulos, Convert.ToDecimal(r.Cells(descuento.Index).Value), Convert.ToDecimal(r.Cells(factor.Index).Value), Convert.ToInt32(r.Cells(tipoItem.Index).Value),
                                                                   Convert.ToDecimal(r.Cells(precioMtInstalacion.Index).Value), Convert.ToDecimal(r.Cells(precioInstalacion.Index).Value), Convert.ToBoolean(dgvTv.Cells(calcularnorma.Index).Value),
                                                                   Convert.ToBoolean(dgvTv.Cells(cumplenorma.Index).Value), Convert.ToInt32(r.Cells(numero_cuerpos_norma.Index).Value), ClsEnums.Estados.ACTIVO, CDec(r.Cells(costoVidrio.Index).Value), CDec(r.Cells(costoPerfiles.Index).Value), CDec(r.Cells(costoAccesorios.Index).Value), CDec(r.Cells(costoOtros.Index).Value),
                                                                   r.Cells(Ubicacion.Index).Value, r.Cells(Descripcion.Index).Value, Convert.ToBoolean(r.Cells(colorTemporal.Index).Value), Convert.ToBoolean(r.Cells(espesorTemporal.Index).Value), CBool(r.Cells(acabTemporal.Index).Value),
                                                                   CDec(r.Cells(costoUnitario.Index).Value), CDec(r.Cells(costoTotal.Index).Value), CDec(r.Cells(precioUnitario.Index).Value), CDec(r.Cells(precioTotal.Index).Value), CDec(r.Cells(valorDescuento.Index).Value),
                                                                   Convert.ToDecimal(r.Cells(vlrDesperdicioVidrio.Index).Value),
                                                                   Convert.ToDecimal(r.Cells(vlrDesperdicioPerfiles.Index).Value), Convert.ToDecimal(r.Cells(vlrDesperdicioAccesorios.Index).Value), Convert.ToDecimal(r.Cells(vlrDesperdicioOtros.Index).Value),
                                                                   Convert.ToDecimal(r.Cells(costoinstalacion.Index).Value))
#Region "Inserción elementos modelos"
                                                                            If Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                                                                                GuardarElementosPlantilla(DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico),
                                                                                                           Convert.ToInt32(r.Cells(id.Index).Value),
                                                                                                          Convert.ToInt32(r.Cells(idArticulo.Index).Value))
                                                                            End If
#End Region
                                                                        End Sub)
                                             'GUARDADO DIBUJO
                                             If dgvTv.Cells(especial.Index).Value IsNot Nothing Then
                                                 Dim est As ControlesPersonalizados.Estructurador.RegionEstructuras = DirectCast(dgvTv.Cells(especial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras)
                                                 Dim gdib As New ClsDibujosItemsCotiza
                                                 '  gdib.BorrarxIdItemCotiza(Convert.ToInt32(dgvTv.Cells(id.Index).Value))
                                                 GuardarDibujos(est, Convert.ToInt32(dgvTv.Cells(id.Index).Value),
                                   0, 0)
                                             End If
                                             'FIN GUARDADO DIBUJO
                                         End Sub)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub GuardarElementosPlantilla(an As AnalizadorLexico, id_hijos_cotiza As Integer, id_plantilla As Integer)
        Try
            mvarhijocotiza.EliminarxIdItemCotiza(id_hijos_cotiza)
            mdescuentosgeneraleshijocotiza.BorrarporIdHijoCotiza(id_hijos_cotiza)
            mdescuentosmaterialplantillacotiza.BorrarporIdHijoCotiza(id_hijos_cotiza)
            mmaterialhijocotiza.BorrarporIdHijoCotiza(id_hijos_cotiza)
            mdibujohijocotiza.BorrarporIdHijoCotiza(id_hijos_cotiza)
            mobservacioneshijocotiza.BorrarporIdHijoCotiza(id_hijos_cotiza)
#Region "Variables"
            Dim lvar As ParametrosCollection = an.ListaVariables
            lvar.ToList.ForEach(Sub(var As Parametro)
                                    If var.Id > 0 Then
                                        Dim minimo_f As String = String.Empty
                                        Dim minimo_v As String = String.Empty

                                        If var.Restricciones.Contains("MINIMO") Then
                                            minimo_v = var.Restricciones.Item("MINIMO").Valor
                                            minimo_f = var.Restricciones.Item("MINIMO").Formula
                                        End If
                                        Dim maximo_f As String = String.Empty
                                        Dim maximo_v As String = String.Empty
                                        If var.Restricciones.Contains("MAXIMO") Then
                                            maximo_v = var.Restricciones.Item("MAXIMO").Valor
                                            maximo_f = var.Restricciones.Item("MAXIMO").Formula
                                        End If
                                        mvarhijocotiza.Insertar(id_hijos_cotiza, var.Id,
                                                                minimo_f, minimo_v, maximo_f, maximo_v, var.Valor,
                                                                My.Settings.UsuarioActivo)
                                    End If
                                End Sub)
#End Region
#Region "Materiales"
            Dim materiales As ObjetosCollection = an.ListaMateriales
            an.ListaMateriales.ToList().ForEach(Sub(m)
                                                    Dim id_mat As Integer = 0
                                                    Select Case m.TipoObjeto
                                                        Case Is = TiposElementos.Vidrios
                                                            id_mat = mmaterialhijocotiza.Insertar(id_hijos_cotiza,
                                                         m.Id, My.Settings.UsuarioActivo, TiposElementos.Vidrios,
                                                         Convert.ToInt32(m.Parametros.Item("IDORIENTACIONPOSICION").Valor),
                                                        m.Parametros.Item("ESPESOR").Formula, m.Parametros.Item("ESPESOR").Valor,
                                                        If(m.Parametros.Item("ARTICULO").Formula.StartsWith("="), m.Parametros.Item("ARTICULO").Formula, m.Parametros.Item("ARTICULO").Valor),
                                                        m.Parametros.Item("REFERENCIA").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDUBICACIONMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDMATERIALPARA").Valor),
                                                        m.Parametros.Item("COLOR").Formula, m.Parametros.Item("COLOR").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOMATERIAL").Valor), Convert.ToInt32(m.Parametros.Item("IDTIPOCORTES").Valor),
                                                        m.Parametros.Item("CANTIDAD").Formula, CDec(m.Parametros.Item("CANTIDAD").Valor),
                                                        m.Parametros.Item("PXUNIDAD").Formula, CDec(m.Parametros.Item("PXUNIDAD").Valor),
                                                        m.Parametros.Item("ANCHO").Formula, CDec(m.Parametros.Item("ANCHO").Valor),
                                                        m.Parametros.Item("ALTO").Formula, CDec(m.Parametros.Item("ALTO").Valor),
                                                        m.Parametros.Item("PESO").Formula, CDec(If(String.IsNullOrEmpty(m.Parametros.Item("PESO").Valor.Replace("'", "")), 0, m.Parametros.Item("PESO").Valor)),
                                                        m.Parametros.Item("DESCUENTO").Formula, CDec(m.Parametros.Item("DESCUENTO").Valor),
                                                        m.Parametros.Item("DETALLE").Formula, m.Parametros.Item("DETALLE").Valor, 1,
                                                        m.Parametros.Item("VISIBILIDAD").Formula, CInt(m.Parametros.Item("VISIBILIDAD").Valor), m.Utilizar, CDec(m.Desperdicio), CDec(m.Costo_Instalacion_Unidad), CInt(m.Indice))
                                                        Case TiposElementos.Perfiles, TiposElementos.Accesorios, TiposElementos.Otros
                                                            id_mat = mmaterialhijocotiza.Insertar(id_hijos_cotiza,
                                                         m.Id, My.Settings.UsuarioActivo, m.TipoObjeto,
                                                         Convert.ToInt32(m.Parametros.Item("IDORIENTACIONPOSICION").Valor), "", 1,
                                                        If(m.Parametros.Item("ARTICULO").Formula.StartsWith("="), m.Parametros.Item("ARTICULO").Formula, m.Parametros.Item("ARTICULO").Valor),
                                                        m.Parametros.Item("REFERENCIA").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDUBICACIONMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDMATERIALPARA").Valor),
                                                        m.Parametros.Item("ACABADO").Formula, m.Parametros.Item("ACABADO").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOCORTES").Valor),
                                                        m.Parametros.Item("CANTIDAD").Formula, CDec(If(m.Parametros.Item("CANTIDAD").Valor = "", 0, m.Parametros.Item("CANTIDAD").Valor)),
                                                        m.Parametros.Item("PXUNIDAD").Formula, CDec(If(m.Parametros.Item("PXUNIDAD").Valor.Replace("'", "") = "", 0, m.Parametros.Item("PXUNIDAD").Valor)),
                                                        m.Parametros.Item("DIMENSION").Formula, CDec(If(m.Parametros.Item("DIMENSION").Valor = "", 0, m.Parametros.Item("DIMENSION").Valor)), "", 0,
                                                        m.Parametros.Item("PESO").Formula, CDec(If(String.IsNullOrEmpty(m.Parametros.Item("PESO").Valor.Replace("'", "")), 0, m.Parametros.Item("PESO").Valor)),
                                                        m.Parametros.Item("DESCUENTO").Formula, CDec(If(m.Parametros.Item("DESCUENTO").Valor = "", 0, m.Parametros.Item("DESCUENTO").Valor)),
                                                        m.Parametros.Item("DETALLE").Formula, m.Parametros.Item("DETALLE").Valor, 1,
                                                        m.Parametros.Item("VISIBILIDAD").Formula, m.Parametros.Item("VISIBILIDAD").Valor,
                                                        m.Utilizar, CDec(m.Desperdicio), CDec(m.Costo_Instalacion_Unidad), CInt(m.Indice))
                                                    End Select
                                                    m.Descuentos.ToList().ForEach(Sub(d)
                                                                                      mdescuentosmaterialplantillacotiza.Insertar(id_mat, d.IdDescuento, d.Formula,
                                                                                                                                  CDec(d.Valor), My.Settings.UsuarioActivo)
                                                                                  End Sub
                                                                                  )
                                                End Sub
                )
#End Region
            mdibujohijocotiza.Insertar(id_hijos_cotiza,
                                         id_plantilla,
                                         My.Settings.UsuarioActivo)
            mobservacioneshijocotiza.Insertar(id_hijos_cotiza,
                                             id_plantilla,
                                             My.Settings.UsuarioActivo)
            an.ListaDescuentos.ToList().ForEach(Sub(a)
                                                    mdescuentosgeneraleshijocotiza.Insertar(id_hijos_cotiza,
                                         a.IdDescuento, a.Formula, a.Valor, My.Settings.UsuarioActivo)
                                                End Sub)

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que modifica la información de la cotización 
    ''' </summary>
    Private Sub modificarCotiza()
        Try
#Region "Encabezado"
            mCotizacion.Modificar(curid, My.Settings.UsuarioActivo, txtNombreCotizacion.Text, dtpFecha.Value, cmbTipoObra.SelectedValue, cmbVendedor.SelectedValue, cmbAcabado.SelectedValue,
                                  Ciudad, cmbFactor.SelectedValue, nudDescuentoSum.Value, cmbFormaPago.SelectedValue, cmbTiempoEntrega.SelectedValue, Convert.ToInt32(cbInstalacion.Tag),
                                  cmbInstalacion.SelectedValue, cmbTasaImpuesto.SelectedValue, cmbVigencia.SelectedValue, nudPorcAdministracion.Value, nudPorcImprovistos.Value, nudPorcUtilidad.Value,
                                  cmbTipoDocumento.SelectedValue, txtDocumento.Text, txtDigitoVerificacion.Text, txtCliente.Text, txtTelefonoCliente.Text,
                                  txtDireccionCliente.Text, txtCorreoCliente.Text, txtContactoCliente.Text, txtNombreObra.Text, txtContactoObra.Text, txtTelefonoObra.Text, txtCorreoObra.Text,
                                  cmbTipoEdificacion.SelectedValue, cmbCategExposicion.SelectedValue, cmbComponente.SelectedValue, cmbGruposUso.SelectedValue, cmbTipoCubierta.SelectedValue,
                                  cmbpresionModelo.SelectedValue, nudAltoEdificio.Value, nudAnchoEdificio.Value, nudAlturaCaballete.Value, nudAlturaAlero.Value, nudAltoEntreLosas.Value, versionCostoVidrio, versionCostoAcabado,
                                  versionCostoNivel, versionCostoKiloAluminio, versionCostoAccesorio, versionCostoOtrosArticulos, 1, cmbEstado.SelectedValue, nudDescuentoInst.Value, cbCobroMetros.Checked, If(lblTipoImpuesto.Text = "IVA pleno", False, True))
#End Region
#Region "Condiciones Cotización"
            Dim objCondiciones As New ClsCondicionCotiza
            'dwCondiciones.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(fila)
            '                                                               objCondiciones.insert(My.Settings.UsuarioActivo, curid, fila.Cells(Condicion.Index).Value, If(CBool(fila.Cells(Estado.Index).Value),
            '                                                                                    ClsEnums.Estados.ACTIVO, ClsEnums.Estados.ARCHIVADO), fila.Cells(Grupo.Index).Value)
            '                                                           End Sub)
            dwCondiciones.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(fila)
                                                                           dwCondiciones.EndEdit()
                                                                           objCondiciones.update(fila.Cells(idCondicion.Index).Value, My.Settings.UsuarioActivo, curid, fila.Cells(Condicion.Index).Value,
                                                                                                 If(Convert.ToBoolean(fila.Cells(Estado.Index).Value) = CBool(ClsEnums.Estados.ACTIVO), ClsEnums.Estados.ACTIVO, ClsEnums.Estados.INACTIVO),
                                                                                                 fila.Cells(Grupo.Index).Value)
                                                                       End Sub)

#End Region
            guardar_costos_adicionales()
#Region "Movimientos"
            Dim cd As New CargaDibujos
            dwItems.Nodes.ToList.ForEach(Sub(dgvTv)
#Region "Movito Padres"
                                             If Not CBool(dgvTv.Cells(indGuardado.Index).Value) Then
                                                 If dgvTv.Cells(especial.Index).Value Is Nothing Then
                                                     Dim ldatos As List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)) =
                                                     dgvTv.Nodes.Select(Function(h) New Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)(h.Cells(id.Index).Value, h.Cells(especial.Index).Value, h.Index, h.Cells(ancho.Index).Value, h.Cells(Alto.Index).Value)).ToList()
                                                     dgvTv.Cells(especial.Index).Value = cd.CrearDibujos(dgvTv.Cells(id.Index).Value,
                                                                     ldatos,
                                                                     False, ClsEnums.TipoCarga.COTIZA)
                                                 End If
                                                 mMovitoPadre = New ClsMovitoPadres
                                                 If Convert.ToString(dgvTv.Cells(id.Index).Value) = 0 Then
                                                     dgvTv.Cells(id.Index).Value = mMovitoPadre.Ingresar(My.Settings.UsuarioActivo, curid, Convert.ToString(dgvTv.Cells(Ubicacion.Index).Value), Convert.ToString(dgvTv.Cells(Descripcion.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(ancho.Index).Value), Convert.ToDecimal(dgvTv.Cells(Alto.Index).Value), Convert.ToInt32(dgvTv.Cells(Cantidad.Index).Value),
                                                                                    Convert.ToInt32(dgvTv.Cells(acabadoPerf.Index).Value),
                                                                                    listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(vidrio.Index).Value)).IdDb,
                                                                                    listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(colorVidrio.Index).Value)).IdDb,
                                                                                    listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(espesor.Index).Value)).IdDb,
                                                                                    Convert.ToInt32(dgvTv.Cells(factor.Index).Value), Convert.ToInt32(dgvTv.Cells(descuento.Index).Value), versionCostoVidrio, versionCostoAccesorio,
                                                                                    versionCostoNivel, versionCostoAcabado, versionCostoKiloAluminio, versionCostoOtrosArticulos, Convert.ToBoolean(dgvTv.Cells(calcularnorma.Index).Value),
                                                                                    Convert.ToBoolean(dgvTv.Cells(cumplenorma.Index).Value), Convert.ToInt32(dgvTv.Cells(numero_cuerpos_norma.Index).Value), Convert.ToInt32(dgvTv.Cells(idpropiedad.Index).Value), ClsEnums.Estados.ACTIVO, CDec(dgvTv.Cells(precioMtInstalacion.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(precioInstalacion.Index).Value), Convert.ToDecimal(dgvTv.Cells(tasaImpuesto.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(costoVidrio.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoPerfiles.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoAccesorios.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoOtros.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoUnitario.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(costoTotal.Index).Value), Convert.ToDecimal(dgvTv.Cells(precioUnitario.Index).Value), Convert.ToDecimal(dgvTv.Cells(precioTotal.Index).Value), Convert.ToDecimal(dgvTv.Cells(valorDescuento.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioVidrio.Index).Value), Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioPerfiles.Index).Value), Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioAccesorios.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioOtros.Index).Value), cd.crearBitMap(dgvTv.Cells(especial.Index).Value),
                                                                                    Convert.ToString(dgvTv.Cells(unmedinstala.Index).Value), Convert.ToString(dgvTv.Cells(descuentoinstala.Index).Value))
                                                 Else
                                                     mMovitoPadre.Modificar(Convert.ToInt32(dgvTv.Cells(id.Index).Value), Convert.ToString(dgvTv.Cells(Ubicacion.Index).Value), Convert.ToString(dgvTv.Cells(Descripcion.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(ancho.Index).Value), Convert.ToDecimal(dgvTv.Cells(Alto.Index).Value), Convert.ToInt32(dgvTv.Cells(Cantidad.Index).Value),
                                                                                    Convert.ToInt32(dgvTv.Cells(acabadoPerf.Index).Value),
                                                                                    listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(vidrio.Index).Value)).IdDb,
                                                                                    listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(colorVidrio.Index).Value)).IdDb,
                                                                                    listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(dgvTv.Cells(espesor.Index).Value)).IdDb,
                                                                                    Convert.ToDecimal(dgvTv.Cells(factor.Index).Value), Convert.ToDecimal(dgvTv.Cells(descuento.Index).Value),
                                                                                    versionCostoVidrio, versionCostoAccesorio, versionCostoNivel, versionCostoAcabado, versionCostoKiloAluminio, versionCostoOtrosArticulos,
                                                                                    Convert.ToBoolean(dgvTv.Cells(calcularnorma.Index).Value), Convert.ToBoolean(dgvTv.Cells(cumplenorma.Index).Value), Convert.ToInt32(dgvTv.Cells(numero_cuerpos_norma.Index).Value),
                                                                                    Convert.ToInt32(dgvTv.Cells(idpropiedad.Index).Value),
                                                                                    My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO, CDec(dgvTv.Cells(precioMtInstalacion.Index).Value), Convert.ToDecimal(dgvTv.Cells(precioInstalacion.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(tasaImpuesto.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(costoVidrio.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoPerfiles.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoAccesorios.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoOtros.Index).Value), Convert.ToDecimal(dgvTv.Cells(costoUnitario.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(costoTotal.Index).Value), Convert.ToDecimal(dgvTv.Cells(precioUnitario.Index).Value), Convert.ToDecimal(dgvTv.Cells(precioTotal.Index).Value), Convert.ToDecimal(dgvTv.Cells(valorDescuento.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioVidrio.Index).Value), Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioPerfiles.Index).Value),
                                                                                    Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioAccesorios.Index).Value), Convert.ToDecimal(dgvTv.Cells(vlrDesperdicioOtros.Index).Value), cd.crearBitMap(dgvTv.Cells(especial.Index).Value),
                                                                                    Convert.ToString(dgvTv.Cells(unmedinstala.Index).Value), Convert.ToString(dgvTv.Cells(descuentoinstala.Index).Value))
                                                     dgvTv.Cells(indGuardado.Index).Value = True
                                                 End If
#Region "Movimiento HIjos"
                                                 dgvTv.Nodes.ToList.ForEach(Sub(r)
                                                                                mMovitoHijo = New ClsMovitoHijos
                                                                                Dim modplantillas As Boolean = False
                                                                                If Convert.ToString(r.Cells(id.Index).Value) = 0 Then
                                                                                    modplantillas = True
                                                                                    r.Cells(id.Index).Value = mMovitoHijo.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(dgvTv.Cells(id.Index).Value),
                                                    If(Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS, 0, Convert.ToInt32(r.Cells(idArticulo.Index).Value)),
                                                    If(Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS, Convert.ToInt32(r.Cells(idArticulo.Index).Value), 0),
                                                    If(Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.TEMPORAL, Convert.ToInt32(r.Cells(idArticuloTemp.Index).Value), 0),
                                                    Convert.ToInt32(r.Cells(Cantidad.Index).Value),
                                                    Convert.ToDecimal(r.Cells(piezasxUnidad.Index).Value), Convert.ToDecimal(r.Cells(ancho.Index).Value), Convert.ToDecimal(r.Cells(Alto.Index).Value),
                                                    listAcabados.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(acabadoPerf.Index).Value)).IdDb,
                                                    listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(vidrio.Index).Value)).IdDb,
                                                    listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(colorVidrio.Index).Value)).IdDb,
                                                    listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(espesor.Index).Value)).IdDb,
                                                    versionCostoVidrio, versionCostoNivel, versionCostoAcabado,
                                                    versionCostoKiloAluminio, versionCostoAccesorio, versionCostoOtrosArticulos, Convert.ToDecimal(r.Cells(descuento.Index).Value), Convert.ToDecimal(r.Cells(factor.Index).Value), Convert.ToInt32(r.Cells(tipoItem.Index).Value),
                                                    Convert.ToDecimal(r.Cells(precioMtInstalacion.Index).Value), Convert.ToDecimal(r.Cells(precioInstalacion.Index).Value), Convert.ToBoolean(dgvTv.Cells(calcularnorma.Index).Value),
                                                    Convert.ToBoolean(dgvTv.Cells(cumplenorma.Index).Value), Convert.ToInt32(r.Cells(numero_cuerpos_norma.Index).Value), ClsEnums.Estados.ACTIVO, CDec(r.Cells(costoVidrio.Index).Value), CDec(r.Cells(costoPerfiles.Index).Value), CDec(r.Cells(costoAccesorios.Index).Value), CDec(r.Cells(costoOtros.Index).Value),
                                                    r.Cells(Ubicacion.Index).Value, r.Cells(Descripcion.Index).Value, Convert.ToBoolean(r.Cells(colorTemporal.Index).Value), Convert.ToBoolean(r.Cells(espesorTemporal.Index).Value), CBool(r.Cells(acabTemporal.Index).Value),
                                                    CDec(r.Cells(costoUnitario.Index).Value), CDec(r.Cells(costoTotal.Index).Value),
                                                    CDec(r.Cells(precioUnitario.Index).Value), CDec(r.Cells(precioTotal.Index).Value),
                                                    CDec(r.Cells(valorDescuento.Index).Value),
                                                    Convert.ToDecimal(r.Cells(vlrDesperdicioVidrio.Index).Value),
                                                    Convert.ToDecimal(r.Cells(vlrDesperdicioPerfiles.Index).Value), Convert.ToDecimal(r.Cells(vlrDesperdicioAccesorios.Index).Value),
                                                    Convert.ToDecimal(r.Cells(vlrDesperdicioOtros.Index).Value), Convert.ToDecimal(r.Cells(costoinstalacion.Index).Value))
                                                                                Else
                                                                                    mMovitoHijo.Modificar(Convert.ToInt32(r.Cells(id.Index).Value), Convert.ToInt32(r.Cells(Cantidad.Index).Value), Convert.ToDecimal(r.Cells(piezasxUnidad.Index).Value), Convert.ToDecimal(r.Cells(ancho.Index).Value),
                                                  Convert.ToDecimal(r.Cells(Alto.Index).Value),
                                                  listAcabados.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(acabadoPerf.Index).Value)).IdDb,
                                                  listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(vidrio.Index).Value)).IdDb,
                                                  listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(colorVidrio.Index).Value)).IdDb,
                                                  listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(espesor.Index).Value)).IdDb,
                                                  versionCostoVidrio, versionCostoNivel, versionCostoAcabado, versionCostoKiloAluminio, versionCostoAccesorio, versionCostoOtrosArticulos,
                                                  Convert.ToDecimal(r.Cells(descuento.Index).Value), Convert.ToDecimal(r.Cells(factor.Index).Value), Convert.ToDecimal(r.Cells(precioMtInstalacion.Index).Value), Convert.ToDecimal(r.Cells(precioInstalacion.Index).Value),
                                                  Convert.ToBoolean(r.Cells(calcularnorma.Index).Value), Convert.ToBoolean(r.Cells(cumplenorma.Index).Value), Convert.ToInt32(r.Cells(numero_cuerpos_norma.Index).Value), My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO, CDec(r.Cells(costoVidrio.Index).Value),
                                                  CDec(r.Cells(costoPerfiles.Index).Value), CDec(r.Cells(costoAccesorios.Index).Value), CDec(r.Cells(costoOtros.Index).Value),
                                                  Convert.ToBoolean(r.Cells(colorTemporal.Index).Value), Convert.ToBoolean(r.Cells(espesorTemporal.Index).Value), CBool(r.Cells(acabTemporal.Index).Value),
                                                  CDec(r.Cells(costoUnitario.Index).Value), CDec(r.Cells(costoTotal.Index).Value),
                                                  CDec(r.Cells(precioUnitario.Index).Value), CDec(r.Cells(precioTotal.Index).Value),
                                                  CDec(r.Cells(valorDescuento.Index).Value),
                                                  Convert.ToDecimal(r.Cells(vlrDesperdicioVidrio.Index).Value), Convert.ToDecimal(r.Cells(vlrDesperdicioPerfiles.Index).Value),
                                                  Convert.ToDecimal(r.Cells(vlrDesperdicioAccesorios.Index).Value), Convert.ToDecimal(r.Cells(vlrDesperdicioOtros.Index).Value),
                                                  Convert.ToDecimal(r.Cells(costoinstalacion.Index).Value))
                                                                                End If
#Region "Modificación para elementos de modelos"
                                                                                If modplantillas Or Convert.ToBoolean(r.Cells(actualizar_plantilla.Index).Value) Then
                                                                                    If Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
#Region "Guardado Elementos Plantilla"
                                                                                        GuardarElementosPlantilla(DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico),
                                                                                                                  Convert.ToInt32(r.Cells(id.Index).Value),
                                                                                                                  Convert.ToInt32(r.Cells(idArticulo.Index).Value))
#End Region
                                                                                    End If
                                                                                End If
#End Region
                                                                            End Sub)
#End Region
                                                 If dgvTv.Cells(especial.Index).Value IsNot Nothing Then
                                                     Dim est As ControlesPersonalizados.Estructurador.RegionEstructuras = DirectCast(dgvTv.Cells(especial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras)
                                                     Dim gdib As New ClsDibujosItemsCotiza
                                                     gdib.BorrarxIdItemCotiza(Convert.ToInt32(dgvTv.Cells(id.Index).Value))
                                                     GuardarDibujos(est, Convert.ToInt32(dgvTv.Cells(id.Index).Value),
                                                                    0, 0)
                                                 End If

                                             End If
#End Region
                                         End Sub)

#End Region


        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        Finally
            bwcargas_RunWorkerCompleted(Nothing, Nothing)
        End Try
    End Sub
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If ValidacionFinal() Then
                bwcargas.RunWorkerAsync("Guardar...")
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    insertar()
                    Me.Text = "Cot. (" & curid & ") " & txtNombreObra.Text
                    renumerarNoGuardadas()
                    DirectCast(Me.Parent.FindForm(), frmInicial).GlobalCotizaForms += 1
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    If curid = 0 Then
                        insertar()
                    Else
                        modificarCotiza()
                        'bwcargas.ReportProgress(100)
                    End If
                End If
                '  If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
                guardado = True
            Else
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        Finally
            bwcargas_RunWorkerCompleted(Nothing, Nothing)
        End Try


    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            ClsInterbloqueos.Desbloquear(curid, ClsEnums.ModulosAplicacion.MODULO_COTIZACIONES)
            mLimpiezaCampos = New LimpiarCampos
            mLimpiezaCampos.Limpiar(Me)
            lblTipoImpuesto.Text = ""
            FrmCotizaciones_Load(Nothing, Nothing)
            ErrorProvider.Clear()
            ErrorProvider1.Clear()
            txtNombreCotizacion.Focus()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbAcabado_SelectedValueChanged_1(sender As Object, e As EventArgs) Handles cmbAcabado.SelectedValueChanged
        Try
            Versiones(False)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub VerificacionTipoImpuestoObra(idtipoobra As Integer)
        Try
            cargarComponente()
            cargarCondicionesBase(If(Me.OperacionActual = ClsEnums.TiOperacion.INSERTAR, False, True))
            mTipoObra = New ClsTiposObras
            Dim obra As tipoObra = mTipoObra.TraerxId(idtipoobra)
            If obra.tipoImpuesto = 1 Then
                _indAIU = False
                lblTipoImpuesto.Text = "IVA pleno"
                nudPorcAdministracion.Value = 0
                nudPorcImprovistos.Value = 0
                nudPorcUtilidad.Value = 0
                gbxParametrosAIU.Enabled = False

            Else
                _indAIU = True
                lblTipoImpuesto.Text = "IVA sobre la utilidad"
                gbxParametrosAIU.Enabled = True
                cargarParametrosAIU()
            End If
            ActualizarTotales_AIU()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Solo_lectura()
        Try
            tbpInfoGeneral.Controls.Cast(Of Control).ToList.ForEach(Sub(c)
                                                                        If Not TypeOf c Is TabControl Then
                                                                            c.Enabled = False
                                                                        End If
                                                                    End Sub)
            tpgeneral.Enabled = False
            tpconfigura.Enabled = False
            tsherramientas.Enabled = False
            tscondiciones.Enabled = False
            dwItems.ReadOnly = True
            dwCondiciones.ReadOnly = True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub QuitarEstructurasxIndex(index As Integer, est As ControlesPersonalizados.Estructurador.RegionEstructuras)
        Try
            If est.Index_Hijo_Owner = index Then
                est.Arquitecto = Nothing
                est.Estructura = String.Empty
                est.Id_Hijo_Owner = 0
                est.Index_Hijo_Owner = -1
            End If
            For i As Integer = 0 To est.Estructuras.Count - 1
                QuitarEstructurasxId(index, est.Estructuras(i))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub QuitarEstructurasxId(id As Integer, est As ControlesPersonalizados.Estructurador.RegionEstructuras)
        Try
            If est.Id_Hijo_Owner = id Then
                est.Arquitecto = Nothing
                est.Estructura = String.Empty
                est.Id_Hijo_Owner = 0
                est.Index_Hijo_Owner = -1
            End If
            For i As Integer = 0 To est.Estructuras.Count - 1
                QuitarEstructurasxId(id, est.Estructuras(i))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub Modificar()
        Try
#Region "Carga Encabezado"
            Dim Cotiza As New cotizacion
            Cotiza = mCotizacion.TraerxId(curid)
            idHistoriaModi = Cotiza.idHistorialUsuMod
            txtNombreCotizacion.Text = Cotiza.nombreCotizacion
            Me.Text &= " " & Cotiza.nomObra
            dtpFecha.Value = Cotiza.fechaCotizacion
            puedeCambiar = True
            cmbTipoObra.SelectedValue = Cotiza.idTipoCotiza
            cmbVendedor.SelectedValue = Cotiza.idVendedor
            cmbAcabado.SelectedValue = Cotiza.idAcabado
            Ciudad = Cotiza.idCiudad
            txtCiudad.Text = Cotiza.Ciudad
            cmbFactor.SelectedValue = Cotiza.idFactor
            nudDescuentoSum.Value = Cotiza.descuentoGlobal
            cmbVigencia.SelectedValue = Cotiza.idVigencia
            cmbFormaPago.SelectedValue = Cotiza.idFormaPago
            cmbEstado.SelectedValue = Cotiza.IdEstado
            cmbTiempoEntrega.SelectedValue = Cotiza.idTiempoEntrega
            cmbInstalacion.SelectedValue = Cotiza.idManoObraInstalacion
            cbInstalacion.Checked = Not Convert.ToBoolean(Cotiza.conInstalacion - 1)
            cmbTasaImpuesto.SelectedValue = Cotiza.idTasaImpuesto
            txtNombreObra.Text = Cotiza.nomObra
            txtContactoObra.Text = Cotiza.nomContacObra
            txtTelefonoObra.Text = Cotiza.telObra
            txtCorreoObra.Text = Cotiza.mailObra
            txtCliente.Text = Cotiza.cliente
            cmbTipoDocumento.SelectedValue = Cotiza.idIdentificacion
            txtDocumento.Text = Cotiza.numIdentificacion
            txtDigitoVerificacion.Text = Cotiza.digitoVerificacion
            txtTelefonoCliente.Text = Cotiza.telCliente
            txtDireccionCliente.Text = Cotiza.dirCliente
            txtCorreoCliente.Text = Cotiza.mailCliente
            txtContactoCliente.Text = Cotiza.nomContacCliente
            cmbTipoEdificacion.SelectedValue = Cotiza.idTipoEdificacion
            cmbCategExposicion.SelectedValue = Cotiza.idCateExposicion
            cmbComponente.SelectedValue = Cotiza.idComponente
            cmbGruposUso.SelectedValue = Cotiza.idGrupoUso
            cmbTipoCubierta.SelectedValue = Cotiza.idTipoCubierta
            nudAltoEdificio.Value = Cotiza.altoEdificio
            nudAnchoEdificio.Value = Cotiza.anchoEdificio
            nudAlturaCaballete.Value = Cotiza.alturaCaballete
            nudAlturaAlero.Value = Cotiza.alturaAlero
            nudAltoEntreLosas.Value = Cotiza.alturaEntreLosas
            nudPorcAdministracion.Value = Cotiza.porcAdministracion
            nudPorcImprovistos.Value = Cotiza.porcImprovistos
            nudPorcUtilidad.Value = Cotiza.porcUtilidad
            versionCostoKiloAluminio = Cotiza.versionCostoKiloAluminio
            versionCostoVidrio = Cotiza.versionCostoAcabado
            nudDescuentoInst.Value = Cotiza.descuentoInstalacion
            cbCobroMetros.Checked = Not Convert.ToBoolean(Cotiza.CobraMtReales - 1)

#End Region
#Region "Carga Movimiento"
            mMovitoPadre = New ClsMovitoPadres
            Dim listPadre As List(Of movitoPadre) = mMovitoPadre.TraerxIdCotiza(curid)
            listPadre.ForEach(Sub(item)
#Region "Cargar Padres"
                                  Dim ndp As DataGridViewTreeNode = dwItems.Nodes.Add()
                                  ndp.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                                  ndp.Cells(id.Index).Value = item.Id
                                  ndp.Cells(Ubicacion.Index).Value = RTrim(item.Ubicacion)
                                  ndp.Cells(idArticulo.Index).Value = 0
                                  ndp.Cells(Descripcion.Index).Value = RTrim(item.Descripcion)
                                  ndp.Cells(ancho.Index).Value = Math.Round(item.Ancho, 0)
                                  ndp.Cells(Alto.Index).Value = Math.Round(item.Alto, 0)
                                  ndp.Cells(mtCuadrados.Index).Value = item.mtCuadrados 'If(((Math.Round(item.ancho) * Math.Round(item.alto, 0)) / 1000000) < 1, item.cantidad, ((Math.Round(item.ancho) * Math.Round(item.alto, 0)) / 1000000) * item.cantidad)
                                  ndp.Cells(Cantidad.Index).Value = item.Cantidad
                                  ndp.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = item.IdAcabadoPerfil).Id
                                  ndp.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = item.IdVidrio).Id
                                  ndp.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = item.IdColorVidrio).Id
                                  ndp.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = item.idEspesor).Id
                                  ndp.Cells(factor.Index).Value = item.factor
                                  ndp.Cells(piezasxUnidad.Index).Value = 1
                                  ndp.Cells(descuento.Index).Value = item.Descuento
                                  ndp.Cells(precioMtInstalacion.Index).Value = item.tarifaMtInstalacion
                                  ndp.Cells(precioInstalacion.Index).Value = item.precioInstalacion '(((CDec(ndp.Cells(mtCuadrados.Index).Value)) * item.cantidad) * Convert.ToDecimal(cmbInstalacion.Text))
                                  ndp.Cells(unidadMedida.Index).Value = "-"
                                  ndp.Cells(tipoItem.Index).Value = "-"
                                  ndp.Cells(idpropiedad.Index).Value = item.idPropiedadMasica
                                  ndp.Cells(calcularnorma.Index).Value = item.calculo_NSR
                                  ndp.Cells(cumplenorma.Index).Value = item.cumpleNorma
                                  ndp.Cells(numero_cuerpos_norma.Index).Value = item.Numero_Cuerpos_Norma
                                  ndp.Cells(unmedinstala.Index).Value = Trim(item.UnidadMedidaInstalacion)
                                  ndp.Cells(descuentoinstala.Index).Value = item.Descuento_Instalacion
                                  ndp.Cells(tasaImpuesto.Index).Value = item.tasaImpuesto
                                  Dim valparcial As Decimal = (item.Ancho * item.Alto) / 1000000
                                  ndp.Cells(mtCuadrados.Index).Value = valparcial * item.Cantidad
                                  ndp.Cells(Mtinstalacion.Index).Value = If(valparcial < 1, 1, valparcial) * item.Cantidad
#Region "Carga Hijos"
                                  mMovitoHijo = New ClsMovitoHijos
                                  Dim listHijos As List(Of movitoHijo) = mMovitoHijo.TraerxIdPadre(item.Id)
                                  listHijos.ForEach(Sub(ith)
                                                        Dim ndh As DataGridViewTreeNode = ndp.Nodes.Add
                                                        ndh.Cells(id.Index).Value = ith.Id
                                                        ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                                                        ndh.Cells(idArticuloTemp.Index).Value = ith.IdArticuloTemporal
                                                        ndh.Cells(Ubicacion.Index).Value = RTrim(ith.referencia)
                                                        ndh.Cells(Descripcion.Index).Value = RTrim(ith.descripcion)
                                                        ndh.Cells(ancho.Index).Value = Math.Round(ith.ancho)
                                                        ndh.Cells(Alto.Index).Value = Math.Round(ith.alto)
                                                        Dim vparcial As Decimal = (ith.ancho * ith.alto) / 1000000
                                                        Select Case DirectCast(ith.tipoItem, ClsEnums.FamiliasMateriales)
                                                            Case ClsEnums.FamiliasMateriales.DISEÑOS, ClsEnums.FamiliasMateriales.VIDRIO
                                                                ndh.Cells(mtCuadrados.Index).Value = vparcial * ith.cantidad * ith.piezasxUnidad
                                                                ndh.Cells(Mtinstalacion.Index).Value = If(vparcial < 1, 1, vparcial) * ith.cantidad * ith.piezasxUnidad
                                                            Case Else
                                                                ndh.Cells(mtCuadrados.Index).Value = 0
                                                        End Select
                                                        ndh.Cells(Cantidad.Index).Value = ith.cantidad
                                                        If ith.tipoItem = ClsEnums.FamiliasMateriales.TEMPORAL Then
                                                            'PENDIENTE: PROBAR QUE SUCEDERÁ SI TENEMOS DOS ARTÍCULOS CON LA MISMA REFERENCIA EN DISTINTAS FAMILIAS DE MATERIAL
                                                            Dim art As articuloTemporal = listArticulos.FirstOrDefault(Function(a) a.Referencia = ith.referencia)
                                                            If art IsNot Nothing Then
                                                                If art.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO Then
                                                                    ndh.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = ith.idAcabadoPerfil And a.Temporal = ith.AcabadoTemporal).Id
                                                                    ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio And a.Temporal = art.Temporal).Id
                                                                    ndh.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = ith.idColorVidrio And a.Temporal = ith.ColorTemporal).Id
                                                                    ndh.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = ith.idEspesor And a.Temporal = ith.EspesorTemporal).Id
                                                                Else
                                                                    ndh.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = ith.idAcabadoPerfil And a.Temporal = ith.AcabadoTemporal).Id
                                                                    'ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio And a.Temporal = ith.VidrioTemporal).Id
                                                                    ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio).Id
                                                                    ndh.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = ith.idColorVidrio And a.Temporal = ith.ColorTemporal).Id
                                                                    ndh.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = ith.idEspesor And a.Temporal = ith.EspesorTemporal).Id
                                                                End If
                                                            End If
                                                        Else
                                                            ndh.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = ith.idAcabadoPerfil).Id
                                                            ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio).Id
                                                            ndh.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = ith.idColorVidrio).Id
                                                            ndh.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = ith.idEspesor).Id
                                                        End If
                                                        ndh.Cells(factor.Index).Value = ith.factor
                                                        ndh.Cells(descuento.Index).Value = ith.descuento
                                                        ndh.Cells(valorDescuento.Index).Value = ith.valorDescuento
                                                        ndh.Cells(precioUnitario.Index).Value = ith.precioUnitario
                                                        ndh.Cells(precioTotal.Index).Value = ith.precioTotal
                                                        ndh.Cells(piezasxUnidad.Index).Value = ith.piezasxUnidad
                                                        ndh.Cells(costoVidrio.Index).Value = ith.costoVidrio
                                                        ndh.Cells(costoPerfiles.Index).Value = ith.costoPerfiles
                                                        ndh.Cells(costoAccesorios.Index).Value = ith.costoAccesorios
                                                        ndh.Cells(costoOtros.Index).Value = ith.costoOtros
                                                        ndh.Cells(costoUnitario.Index).Value = ith.costoUnitario
                                                        ndh.Cells(costoTotal.Index).Value = ith.costoTotal
                                                        ndh.Cells(precioMtInstalacion.Index).Value = ith.tarifaMtInstalacion
                                                        ndh.Cells(precioInstalacion.Index).Value = ith.precioInstalacion
                                                        ndh.Cells(unidadMedida.Index).Value = RTrim(ith.unidadMedida)
                                                        ndh.Cells(valorDescuento.Index).Value = ith.valorDescuento
                                                        ndh.Cells(tipoItem.Index).Value = ith.tipoItem
                                                        If ith.tipoItem = ClsEnums.FamiliasMateriales.DISEÑOS Then
                                                            ndh.Cells(idArticulo.Index).Value = ith.idPlantilla
                                                        Else
                                                            ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                                                        End If
                                                        ndh.Cells(calcularnorma.Index).Value = ith.calculo_NSR
                                                        ndh.Cells(cumplenorma.Index).Value = ith.cumpleNorma
                                                        ndh.Cells(numero_cuerpos_norma.Index).Value = ith.Numero_Cuerpos_Norma
                                                        ndh.Cells(acabTemporal.Index).Value = ith.AcabadoTemporal
                                                        ndh.Cells(colorTemporal.Index).Value = ith.ColorTemporal
                                                        ndh.Cells(espesorTemporal.Index).Value = ith.EspesorTemporal
                                                        ndh.Cells(vlrDesperdicioVidrio.Index).Value = ith.vlrDespVidrio
                                                        ndh.Cells(vlrDesperdicioPerfiles.Index).Value = ith.vlrDespPerfiles
                                                        ndh.Cells(vlrDesperdicioAccesorios.Index).Value = ith.vlrDespAccesorios
                                                        ndh.Cells(vlrDesperdicioOtros.Index).Value = ith.vlrDespOtros
                                                        If _duplicado Then
                                                            ActualizarValoresNodo(ndh)
                                                        End If
                                                    End Sub)
#End Region
                                  ndp.Cells(valorDescuento.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(valorDescuento.Index).Value))
                                  ndp.Cells(precioUnitario.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioUnitario.Index).Value))
                                  ndp.Cells(precioTotal.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioTotal.Index).Value))
                                  ndp.Cells(costoAccesorios.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoAccesorios.Index).Value))
                                  ndp.Cells(costoPerfiles.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoPerfiles.Index).Value))
                                  ndp.Cells(costoVidrio.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoVidrio.Index).Value))
                                  ndp.Cells(costoOtros.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoOtros.Index).Value))
                                  ndp.Cells(costoTotal.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoTotal.Index).Value))
                                  ndp.Cells(costoUnitario.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoUnitario.Index).Value))
                                  ndp.Cells(precioInstalacion.Index).Value = ndp.Cells(precioInstalacion.Index).Value ' If(cbInstalacion.Checked, If(indAIU, (CDec(cmbInstalacion.Text) + (CDec(cmbInstalacion.Text) * (DirectCast(cmbTasaImpuesto.SelectedItem, tasaImpuesto).tasa / 100)) * CDec(ndp.Cells(Mtinstalacion.Index).Value)), CDec(cmbInstalacion.Text) * CDec(ndp.Cells(Mtinstalacion.Index).Value)), 0) 'ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioInstalacion.Index).Value))
                                  ndp.Cells(vlrDesperdicioVidrio.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioVidrio.Index).Value))
                                  ndp.Cells(vlrDesperdicioPerfiles.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioPerfiles.Index).Value))
                                  ndp.Cells(vlrDesperdicioAccesorios.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioAccesorios.Index).Value))
                                  ndp.Cells(vlrDesperdicioOtros.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioOtros.Index).Value))
                                  ndp.Cells(indGuardado.Index).Value = Not _duplicado
                              End Sub)
#End Region
#Region "Carga Condiciones"
            dwCondiciones.Rows.Clear()
            Dim objCondiciones As New ClsCondicionCotiza
            Dim listaCondicineas As New List(Of CondicionCotiza)
            listaCondicineas.AddRange(objCondiciones.selectByIdCotiza(curid).Where(Function(a) CInt(a.IdEstado) = ClsEnums.Estados.ACTIVO).ToList)
            listaCondicineas.ForEach(Sub(fila)
                                         Dim row As New DataGridViewRow
                                         row = dwCondiciones.Rows(dwCondiciones.Rows.Add())
                                         row.Cells(idCondicion.Index).Value = fila.Id
                                         row.Cells(Condicion.Index).Value = fila.txtCondicion
                                         row.Cells(Estado.Index).Value = If(fila.IdEstado = ClsEnums.Estados.ACTIVO, True, False)
                                         row.Cells(Grupo.Index).Value = fila.Grupo
                                     End Sub)
#End Region


            actualizarTotalesGrid()
#Region "Carga costos"
            bwCostos.RunWorkerAsync()

#End Region
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
            If _duplicado Then
                modificarCotiza()
                _duplicado = False
            End If
#End Region
        Catch ex As Exception
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarAnalizador(ByRef r As DataGridViewRow)
        Try
            Dim cp As New CargasPlantilla
            Dim analizador As AnalizadorLexico = New AnalizadorLexico
            If r.Cells(especial.Index).Value Is Nothing Then
                cp.CargarPlantilla(Convert.ToInt32(r.Cells(id.Index).Value), analizador, ClsEnums.TipoCarga.COTIZA)
            Else
                analizador = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
            End If
            cp.ValorarAnalizador(analizador, curid, versionCostoAcabado, versionCostoNivel,
                                 versionCostoKiloAluminio, versionCostoVidrio, versionCostoAccesorio,
                                 versionCostoOtrosArticulos)
            r.Cells(especial.Index).Value = analizador
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function ValidacionFinal() As Boolean
        Try
            objValidacion = New ClsValidaciones

            If Not objValidacion.TextBoxDigitado(txtNombreCotizacion, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbAcabado, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbFactor, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbFormaPago, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbEstado, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbTiempoEntrega, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbInstalacion, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbTasaImpuesto, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtCliente, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbTipoDocumento, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtDocumento, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtTelefonoCliente, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtDireccionCliente, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtCorreoCliente, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtContactoCliente, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtNombreObra, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtContactoObra, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtTelefonoObra, ErrorProvider) Then Return False
            If Not objValidacion.TextBoxDigitado(txtCorreoObra, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbTipoEdificacion, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbCategExposicion, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbGruposUso, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbComponente, ErrorProvider) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbTipoCubierta, ErrorProvider) Then Return False
            If Not objValidacion.GridSeleccionado(dwCondiciones, ErrorProvider) Then Return False
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub Versiones(mostrarMensaje As Boolean)
        Try
            If OperacionActual = ClsEnums.TiOperacion.INSERTAR Then
                versionCostoVidrio = 0
                versionCostoNivel = 0
                versionCostoAcabado = 0
                versionCostoKiloAluminio = 0
                versionCostoAccesorio = 0
                versionCostoOtrosArticulos = 0
                cargarVersiones()

            ElseIf OperacionActual = ClsEnums.TiOperacion.MODIFICAR Then
                mCotizacion = New ClsCostizaciones
                Dim c As cotizacion = mCotizacion.TraerxId(curid)
                versionCostoVidrio = c.versionCostoVidrio
                versionCostoNivel = c.versionCostoNivel
                versionCostoAcabado = c.versionCostoAcabado
                versionCostoKiloAluminio = c.versionCostoKiloAluminio
                versionCostoAccesorio = c.versionCostoAccesorio
                versionCostoOtrosArticulos = c.versionCostoOtrosArticulos
            End If
            lblVersion.Text = versionCostoKiloAluminio.ToString + "." + versionCostoVidrio.ToString
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVersiones()
        Try
            objCostoKiloAluminio = New ClsCostoKiloAluminio
            versionCostoKiloAluminio = objCostoKiloAluminio.TraerUltimaVersion()
            objCostoVidrio = New ClsCostoVidrio
            versionCostoVidrio = objCostoVidrio.TraerMaxVersion()
            objCostoAccesorio = New ClsCostoAccesorio
            versionCostoAccesorio = objCostoAccesorio.TraerMaxVersion()
            objCostoAcabado = New ClsCostoAcabado
            versionCostoAcabado = objCostoAcabado.TraerUltimaVersion()
            objCostoNivel = New ClsCostoNivel
            versionCostoNivel = objCostoNivel.TraerMaxVersion()
            objCostoOtrosArticulos = New ClsCostoOtrosArticulos
            versionCostoOtrosArticulos = objCostoOtrosArticulos.TraerMaxVersion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub recalcularValoreInstalacion()
        Try
            If dwItems.Rows.Count = 0 Then
                Return
            Else
                If cbInstalacion.Checked Then
                    dwItems.Nodes.ToList.ForEach(Sub(padre)
                                                     Dim pInstalacion As Decimal = 0
                                                     padre.Cells(precioMtInstalacion.Index).Value = Convert.ToDecimal(cmbInstalacion.Text)
                                                     padre.Cells(indGuardado.Index).Value = False
                                                     padre.Nodes.ToList.ForEach(Sub(nod)
                                                                                    nod.Cells(precioMtInstalacion.Index).Value = Convert.ToDecimal(cmbInstalacion.Text)
                                                                                    ActualizarValoresNodo(nodo:=nod, calcular_totales:=True)
                                                                                    pInstalacion += Convert.ToDecimal(nod.Cells(precioInstalacion.Index).Value)
                                                                                End Sub)
                                                     padre.Cells(precioInstalacion.Index).Value = pInstalacion
                                                 End Sub)
                Else
                    dwItems.Nodes.ToList.ForEach(Sub(padre)
                                                     ' Dim pInstalacion As Decimal = 0
                                                     padre.Cells(precioMtInstalacion.Index).Value = 0
                                                     padre.Cells(precioInstalacion.Index).Value = 0
                                                     padre.Cells(indGuardado.Index).Value = False
                                                     padre.Nodes.ToList.ForEach(Sub(nod)
                                                                                    nod.Cells(precioMtInstalacion.Index).Value = 0
                                                                                    nod.Cells(precioInstalacion.Index).Value = 0
                                                                                    'ActualizarValoresNodo(nod, True)
                                                                                    'pInstalacion += Convert.ToDecimal(nod.Cells(precioInstalacion.Index).Value)
                                                                                End Sub)
                                                     'padre.Cells(precioInstalacion.Index).Value = pInstalacion
                                                 End Sub)
                End If
            End If
            Dim acum As Integer = 0
            actualizarTotalesGrid()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub actualizarTotalesGrid()
        Try
            If dwItems.Rows.Count <> 0 Then
                ' calculo total metrosCuadrados
                If cbInstalacion.Checked = True Then
                    If cbCobroMetros.Checked = True Then
                        dwTotales.Rows(0).Cells(totalMt.Index).Value = dwItems.Nodes.Sum(Function(a) CDec(a.Cells(mtCuadrados.Index).Value))
                    Else
                        dwTotales.Rows(0).Cells(totalMt.Index).Value = dwItems.Nodes.Sum(Function(a) CDec(a.Cells(Mtinstalacion.Index).Value))
                    End If
                    Dim mTasa As New tasaImpuesto
                    mTasa = cmbTasaImpuesto.SelectedItem
                    dwTotales.Rows(0).Cells(valorMt.Index).Value = dwItems.Nodes.Sum(Function(a) CDec(a.Cells(precioMtInstalacion.Index).Value)) / dwItems.Nodes.Count 'IIf(_indAIU, Convert.ToDecimal(cmbInstalacion.Text) + (Convert.ToDecimal(cmbInstalacion.Text) * (CDec(mTasa.tasa) / 100)), Convert.ToDecimal(cmbInstalacion.Text))
                Else
                    dwTotales.Rows(0).Cells(valorMt.Index).Value = 0
                End If
                ' calculo total suministro
                dwTotales.Rows(0).Cells(suma.Index).Value = dwItems.Nodes.Sum(Function(a) CDec(a.Cells(precioTotal.Index).Value))
                'calculo total descuento
                dwTotales.Rows(0).Cells(totalDescuento.Index).Value = dwItems.Nodes.Sum(Function(a) CDec(a.Cells(valorDescuento.Index).Value))
                'calculo subtotal suministro
                dwTotales.Rows(0).Cells(subtotalSuministro.Index).Value = Convert.ToDecimal(dwTotales.Rows(0).Cells(suma.Index).Value) - Convert.ToDecimal(dwTotales.Rows(0).Cells(totalDescuento.Index).Value)
                'Calculo Instalación
                dwTotales.Rows(0).Cells(Instalacion.Index).Value = dwItems.Nodes.Sum(Function(a) CDec(a.Cells(precioInstalacion.Index).Value))
                'Calculo Descuento Instalación
                dwTotales.Rows(0).Cells(DescuentoIntalacion.Index).Value = dwItems.Nodes.Sum(Function(a) CDec(a.Cells(precioInstalacion.Index).Value) * (CDec(a.Cells(descuentoinstala.Index).Value) / 100))
                'Calculo Subtotal Instalación
                dwTotales.Rows(0).Cells(subtotalInstalacion.Index).Value = Convert.ToDecimal(dwTotales.Rows(0).Cells(Instalacion.Index).Value) - Convert.ToDecimal(dwTotales.Rows(0).Cells(DescuentoIntalacion.Index).Value)
                'Calculo Subtotal cotización Antes de I.V.A.
                'El siguiente procedimiento calcula el I.V.A para los casos que se presentan de I.V.A.
                dwTotales.Rows(0).Cells(subtotal.Index).Value = Convert.ToDecimal(dwTotales.Rows(0).Cells(subtotalSuministro.Index).Value) +
                    Convert.ToDecimal(dwTotales.Rows(0).Cells(subtotalInstalacion.Index).Value) + Convert.ToDecimal(Replace(dwTotales.Rows(0).Cells(AIU.Index).Value, "$", ""))
                ActualizarTotales_AIU()

                'Calculo del total de la cotización con I.V.A
                dwTotales.Rows(0).Cells(totalCotiza.Index).Value = Math.Round(Convert.ToDecimal(dwTotales.Rows(0).Cells(subtotal.Index).Value) +
                                                                              Convert.ToDecimal(dwTotales.Rows(0).Cells(iva.Index).Value), 0)
            Else
                dwTotales.Rows(0).Cells(totalMt.Index).Value = 0
                dwTotales.Rows(0).Cells(valorMt.Index).Value = 0
                dwTotales.Rows(0).Cells(suma.Index).Value = 0
                dwTotales.Rows(0).Cells(totalDescuento.Index).Value = 0
                dwTotales.Rows(0).Cells(subtotalSuministro.Index).Value = 0
                dwTotales.Rows(0).Cells(subtotalInstalacion.Index).Value = 0
                dwTotales.Rows(0).Cells(subtotal.Index).Value = 0
                dwTotales.Rows(0).Cells(iva.Index).Value = 0
                dwTotales.Rows(0).Cells(totalCotiza.Index).Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ActualizarTotales_AIU()
        Try
            If _indAIU Then
                Dim subSuministro, subInstalacion As Integer
                subSuministro = Convert.ToDecimal(If(String.IsNullOrEmpty(dwTotales.Rows(0).Cells(subtotalSuministro.Index).Value), 0, dwTotales.Rows(0).Cells(subtotalSuministro.Index).Value))
                subInstalacion = Convert.ToDecimal(If(String.IsNullOrEmpty(dwTotales.Rows(0).Cells(subtotalInstalacion.Index).Value), 0, dwTotales.Rows(0).Cells(subtotalInstalacion.Index).Value))
                lbtotAdministracion.Text = FormatCurrency((subSuministro + subInstalacion) * (nudPorcAdministracion.Value / 100))
                lbTotImprovisto.Text = FormatCurrency((subSuministro + subInstalacion) * (nudPorcImprovistos.Value / 100))
                lbTotUtilidad.Text = FormatCurrency((subSuministro + subInstalacion) * (nudPorcUtilidad.Value / 100))
                ''Calculo Columna TOTALAIU
                dwTotales.Rows(0).Cells(AIU.Index).Value = FormatCurrency(CDec(Replace(lbtotAdministracion.Text, "$", "")) + CDec(Replace(lbTotImprovisto.Text, "$", "")) + CDec(Replace(lbTotUtilidad.Text, "$", "")))
                Dim mTasa As New tasaImpuesto
                mTasa = cmbTasaImpuesto.SelectedItem
                dwTotales.Rows(0).Cells(iva.Index).Value = Math.Truncate((mTasa.tasa / 100) * Convert.ToDecimal(Replace(lbTotUtilidad.Text, "$", "")))
            Else
                lbAdministracion.Text = "Administración 0%:"
                lbImprovisto.Text = "  Improvisto 0%: "
                lbUtilidad.Text = "Utilidad 0%: "
                lbtotAdministracion.Text = "$0"
                lbTotImprovisto.Text = "$0"
                lbTotUtilidad.Text = "$0"
                dwTotales.Rows(0).Cells(AIU.Index).Value = 0
                dwTotales.Rows(0).Cells(iva.Index).Value = Math.Round((Convert.ToDecimal(IIf(String.IsNullOrEmpty(dwTotales.Rows(0).Cells(subtotal.Index).Value), 0, dwTotales.Rows(0).Cells(subtotal.Index).Value)) * (tImpuesto.tasa / 100)), 0)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mostrarCostos()
        Try
            dwItems.Columns(costoUnitario.Index).Visible = True
            dwItems.Columns(costoTotal.Index).Visible = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ocultarCostos()
        Try
            dwItems.Columns(costoUnitario.Index).Visible = False
            dwItems.Columns(costoTotal.Index).Visible = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Manual_NSR()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            Dim fpnc As New FrmPeticionNumeroCuerposNorma
            fpnc.Numero_Cuerpos = Convert.ToInt32(n.Cells(numero_cuerpos_norma.Index).Value)
            If fpnc.ShowDialog() = DialogResult.OK Then
                n.Cells(numero_cuerpos_norma.Index).Value = fpnc.Numero_Cuerpos
                n.Cells(cumplenorma.Index).Value = CumplimientoNorma(n)
                n.Cells(calcularnorma.Index).Value = True
                n.Cells(indGuardado.Index).Value = False
                n.Nodes.ToList.ForEach(Sub(nh)
                                           nh.Cells(calcularnorma.Index).Value = False
                                           nh.Cells(cumplenorma.Index).Value = False
                                       End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Automatico_NSR()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            Dim fpnc As New FrmPeticionNumeroCuerposNorma
            fpnc.Numero_Cuerpos = Convert.ToInt32(n.Cells(numero_cuerpos_norma.Index).Value)
            If fpnc.ShowDialog() = DialogResult.OK Then
                n.Cells(calcularnorma.Index).Value = False
                n.Cells(cumplenorma.Index).Value = False
                n.Cells(indGuardado.Index).Value = False
                Dim plant As New ClsPlantillasModelos
                n.Nodes.ToList.ForEach(Sub(nh)
                                           If Convert.ToInt32(nh.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                                               nh.Cells(calcularnorma.Index).Value = plant.TraerxId(Convert.ToInt32(nh.Cells(idArticulo.Index).Value)).Calcular_NSR
                                               nh.Cells(cumplenorma.Index).Value = False
                                               nh.Cells(indGuardado.Index).Value = False
                                               nh.Cells(numero_cuerpos_norma.Index).Value = fpnc.Numero_Cuerpos
                                               If Convert.ToBoolean(nh.Cells(calcularnorma.Index).Value) Then
                                                   nh.Cells(cumplenorma.Index).Value = CumplimientoNorma(nh)
                                               End If
                                           End If
                                       End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Recalcular_Norma_NSR()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            Dim fpnc As New FrmPeticionNumeroCuerposNorma
            fpnc.Numero_Cuerpos = Convert.ToInt32(n.Cells(numero_cuerpos_norma.Index).Value)
            If fpnc.ShowDialog() = DialogResult.OK Then
                If n.Level > 1 Then
                    n.Parent.Cells(indGuardado.Index).Value = False
                Else
                    n.Cells(indGuardado.Index).Value = False
                End If
                n.Cells(numero_cuerpos_norma.Index).Value = fpnc.Numero_Cuerpos
                    n.Cells(cumplenorma.Index).Value = CumplimientoNorma(n, recalculo:=True, alertas:=True)
                End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Imprimir_Norma_NSR()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            n.Cells(cumplenorma.Index).Value = CumplimientoNorma(n, recalculo:=False, impresion:=True, alertas:=True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub duplicarNodo()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            If n.Cells(especial.Index).Value Is Nothing Then
                n.Nodes.ToList.ForEach(Sub(ndp)
                                           cargarAnalizador(ndp)
                                       End Sub)
            End If
            If IsNothing(n.Cells(especial.Index).Value) Then
                Dim cd As New CargaDibujos
                Dim ldatos As List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)) = n.Nodes.Select(Function(h) New Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)(h.Cells(id.Index).Value, h.Cells(especial.Index).Value, h.Index, h.Cells(ancho.Index).Value, h.Cells(Alto.Index).Value)).ToList()
                n.Cells(especial.Index).Value = cd.CrearDibujos(n.Cells(id.Index).Value,
                                                                ldatos,
                                                                False, ClsEnums.TipoCarga.COTIZA).Duplicate(True)
            End If
            Dim nnod As DataGridViewTreeNode = dwItems.Nodes.Add()
            nnod.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
            dwItems.Columns.Cast(Of DataGridViewColumn).ToList.ForEach(Sub(col)
                                                                           If col.Name = "id" Then
                                                                               nnod.Cells(col.Index).Value = 0
                                                                           Else
                                                                               nnod.Cells(col.Index).Value = n.Cells(col.Index).Value
                                                                           End If
                                                                       End Sub)
            n.Nodes.ToList.ForEach(Sub(item)
                                       Dim newItem As DataGridViewTreeNode = nnod.Nodes.Add()
                                       dwItems.Columns.Cast(Of DataGridViewColumn).ToList.ForEach(Sub(col)

                                                                                                      If col.Name = "id" Then
                                                                                                          newItem.Cells(col.Index).Value = 0
                                                                                                      Else
                                                                                                          newItem.Cells(col.Index).Value = item.Cells(col.Index).Value
                                                                                                      End If
                                                                                                  End Sub)
                                   End Sub)
            nnod.Cells(especial.Index).Value = DirectCast(nnod.Cells(especial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras).Duplicate(False)
            nnod.Expand()
            nnod.Selected = True
            actualizar_todos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            Dim nod As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            Dim padre As DataGridViewTreeNode = nod.Parent
            If tform = ClsEnums.TiOperacion.MODIFICAR Then
                If MessageBox.Show("¿Está seguro de eliminar el registro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    If nod.Level = 1 Then
                        mMovitoPadre = New ClsMovitoPadres
                        mMovitoPadre.CambioEstado(nod.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                        dwItems.Nodes.Remove(nod)
                    Else
                        mMovitoHijo = New ClsMovitoHijos
                        mMovitoHijo.cambioEstado(nod.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)

                        If padre.Cells(especial.Index).Value IsNot Nothing Then
                            If Convert.ToInt32(nod.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                                If String.IsNullOrEmpty(Convert.ToString(nod.Cells(id.Index).Value)) Then
                                    QuitarEstructurasxIndex(nod.Index, DirectCast(padre.Cells(especial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras))
                                Else
                                    QuitarEstructurasxId(Convert.ToInt32(nod.Cells(id.Index).Value), DirectCast(padre.Cells(especial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras))
                                End If
                            End If
                        End If
                        padre.Nodes.Remove(nod)
                        padre.Cells(costoUnitario.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(costoUnitario.Index).Value)
                        padre.Cells(precioUnitario.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(precioUnitario.Index).Value)
                        padre.Cells(costoTotal.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(costoTotal.Index).Value)
                        padre.Cells(precioTotal.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(precioTotal.Index).Value)
                        padre.Cells(costoVidrio.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(costoVidrio.Index).Value)
                        padre.Cells(costoPerfiles.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(costoPerfiles.Index).Value)
                        padre.Cells(costoAccesorios.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(costoAccesorios.Index).Value)
                        padre.Cells(costoOtros.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(costoOtros.Index).Value)
                        padre.Cells(precioInstalacion.Index).Value = padre.Nodes.Sum(Function(a) a.Cells(precioInstalacion.Index).Value)
                    End If
                    actualizar_todos()
                Else
                    Return
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub modificarNodo()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            Dim frm As New FrmAddItemPadre
            frm.ListArticulos = listArticulos
            frm.ListColores = listColores
            frm.ListEspesores = listEspesores
            frm.ListAcabados = listAcabados
            frm.tform = If(tform = ClsEnums.TiOperacion.SOLO_LECTURA, ClsEnums.TiOperacion.SOLO_LECTURA, ClsEnums.TiOperacion.MODIFICAR)
            frm.NodoItem = n
            frm.FactorGlobal = cmbFactor.SelectedItem
            frm.nudPrecioInstalacion.Value = CDec(If(cbInstalacion.Checked = False, 0, CDec(n.Cells(precioMtInstalacion.Index).Value)))
            frm.AcabadoGlobal = cmbAcabado.SelectedItem
            frm.CurId = n.Cells(id.Index).Value
            frm.idCotiza = curid
            frm.TieneTemporales = _tieneTemporales
            frm.tasaImpuestoGlobal = DirectCast(cmbTasaImpuesto.SelectedItem, ReglasNegocio.TasaImpuesto.tasaImpuesto).tasa
            frm.indCobroMetrosReales = cbCobroMetros.CheckState
            frm.tieneInstalacion = cbInstalacion.CheckState
            frm.VersionCostoAcabado = versionCostoAcabado
            frm.VersionCostoNivel = versionCostoNivel
            frm.VersionCostoKAlum = versionCostoKiloAluminio
            frm.VersionCostoVidrio = versionCostoVidrio
            frm.VersionCostoAccesorio = versionCostoAccesorio
            frm.VersionCostoOtros = versionCostoOtrosArticulos
            'If cbInstalacion.Checked Then
            '    frm.tieneInstalacion = True
            'Else
            '    frm.tieneInstalacion = False
            'End If
            If frm.ShowDialog() = DialogResult.OK Then
                actualizar_todos()
                If Not Convert.ToBoolean(n.Cells(calcularnorma.Index).Value) Then
                    For i As Integer = 0 To n.Nodes.Count - 1
                        If Convert.ToInt32(n.Nodes(i).Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                            CumplimientoNorma(n.Nodes(i), impresion:=False, alertas:=False)
                        End If
                    Next
                End If
                crearCostos()
                GuardadoTotal_Click(Nothing, Nothing)
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub MostrarMateriales()
        Try
            Dim frm As New FrmListaMateriales

            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If r.Cells(especial.Index).Value Is Nothing Then
                cargarAnalizador(r)
            End If
            frm.IdCotiza = curid
            frm.versionCostoAcabado = versionCostoAcabado
            frm.versionCostoAccesorio = versionCostoAccesorio
            frm.versionCostoKiloAluminio = versionCostoKiloAluminio
            frm.versionCostoNivel = versionCostoNivel
            frm.versionCostoOtrosArticulos = versionCostoOtrosArticulos
            frm.versionCostoVidrio = versionCostoVidrio
            frm.Tipo_Formulario = If(tform = ClsEnums.TiOperacion.SOLO_LECTURA, ClsEnums.TiOperacion.SOLO_LECTURA,
                ClsEnums.TiOperacion.MODIFICAR)
            frm.lista = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico).ListaMateriales
            frm.Text += " " & Convert.ToString(r.Cells(Ubicacion.Index).Value)
            If frm.ShowDialog() = DialogResult.OK Then
                r.Cells(actualizar_plantilla.Index).Value = True
                CalcularPreciosPlantilla(r)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarListasTemporales()
        Try
            Dim mArtTemp As New ClsArticuloTemporal
            listArticulos = New List(Of articuloTemporal)
            listArticulos = mArtTemp.TraerConExistentes_II(curid)
            Dim mColTemp As New ClsAcabadoTemporal
            listColores = New List(Of acabadoTemporal)
            listColores = mColTemp.TraerconExistentes(curid, ClsEnums.FamiliasMateriales.VIDRIO)

            listAcabados = New List(Of acabadoTemporal)
            listAcabados = mColTemp.TraerconExistentes(curid, ClsEnums.FamiliasMateriales.PERFILERIA)

            Dim mEspTemp As New ClsEspesorTemporal
            listEspesores = New List(Of espesorTemporal)
            listEspesores = mEspTemp.TraerConExistentes(curid)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDesplegablesMovimiento()
        Try
            DirectCast(dwItems.Columns(vidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Referencia"
            DirectCast(dwItems.Columns(vidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(vidrio.Index), DataGridViewComboBoxColumn).DataSource = listArticulos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO).ToList

            DirectCast(dwItems.Columns(colorVidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItems.Columns(colorVidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(colorVidrio.Index), DataGridViewComboBoxColumn).DataSource = listColores

            DirectCast(dwItems.Columns(acabadoPerf.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItems.Columns(acabadoPerf.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(acabadoPerf.Index), DataGridViewComboBoxColumn).DataSource = listAcabados

            DirectCast(dwItems.Columns(espesor.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItems.Columns(espesor.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(espesor.Index), DataGridViewComboBoxColumn).DataSource = listEspesores
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarParametrosAIU()
        Try
            Dim mParametros As New ClsParametrosAIU
            Dim AIU As parametroIVA = mParametros.traerUltimo()
            lbAdministracion.Text = "Administración: " & AIU.porcentajeAdministracion.ToString & " % ="
            lbImprovisto.Text = "Improvisto: " & AIU.porcentajeImprovistos.ToString & " % ="
            lbUtilidad.Text = "Utilidad: " & AIU.porcentajeUtilidad.ToString & " % ="
            nudPorcAdministracion.Value = AIU.porcentajeAdministracion
            nudPorcImprovistos.Value = AIU.porcentajeImprovistos
            nudPorcUtilidad.Value = AIU.porcentajeUtilidad
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCondicionesBase(Optional cambioTipo As Boolean = False)
        Try
            Dim _objCondicionesBase As New ClsCondiciones
            Dim _objCondicionesCotiza As New ClsCondicionCotiza
            Dim listaConBase As New List(Of condicion)
            listaConBase.AddRange(_objCondicionesBase.selectByIdTipoObra(cmbTipoObra.SelectedValue).Where(Function(A) A.IdEstado = CInt(ClsEnums.Estados.ACTIVO)).ToList)
            If OperacionActual = ClsEnums.TiOperacion.INSERTAR Then
                puedeCambiar = True
                dwCondiciones.Rows.Clear()
                listaConBase.ForEach(Sub(fila)
                                         Dim row As New DataGridViewRow
                                         row = dwCondiciones.Rows(dwCondiciones.Rows.Add())
                                         row.Cells(idCondicion.Index).Value = 0
                                         row.Cells(Condicion.Index).Value = fila.Condicion
                                         row.Cells(Estado.Index).Value = If(fila.IdEstado = ClsEnums.Estados.ACTIVO, True, False)
                                         row.Cells(idGrupo.Index).Value = fila.idGrupo
                                         row.Cells(Grupo.Index).Value = fila.Grupo
                                     End Sub)
            ElseIf ClsEnums.TiOperacion.MODIFICAR Then
                If Not cambioTipo Then
                    If MsgBox("Tenga en cuenta que al realizar el cambio del tipo de obra, las condiciones actuales serán reemplazadas por las condiciones base del tipo de obra seleccionado.
                            ¿está seguro(a) de realizar el cambio?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        _objCondicionesCotiza.updateEstado(curid, ClsEnums.Estados.INACTIVO, My.Settings.UsuarioActivo)
                        listaConBase = New List(Of condicion)
                        listaConBase.AddRange(_objCondicionesBase.selectByIdTipoObra(cmbTipoObra.SelectedValue).Where(Function(A) A.IdEstado = CInt(ClsEnums.Estados.ACTIVO)).ToList)
                        dwCondiciones.Rows.Clear()
                        listaConBase.ForEach(Sub(fila)
                                                 Dim row As New DataGridViewRow
                                                 row = dwCondiciones.Rows(dwCondiciones.Rows.Add())
                                                 row.Cells(idCondicion.Index).Value = fila.Id
                                                 row.Cells(Condicion.Index).Value = fila.Condicion
                                                 row.Cells(Estado.Index).Value = If(fila.IdEstado = ClsEnums.Estados.ACTIVO, True, False)
                                                 row.Cells(Grupo.Index).Value = fila.Grupo
                                             End Sub)
                        puedeCambiar = True
                    Else
                        puedeCambiar = False
                        cmbTipoObra.SelectedValue = seleccionAnterior
                    End If
                Else
                    Dim listaContidiciones As New List(Of CondicionCotiza)
                    dwCondiciones.Rows.Clear()
                    listaContidiciones = _objCondicionesCotiza.selectByIdCotiza(curid).Where(Function(A) A.IdEstado = CInt(ClsEnums.Estados.ACTIVO)).ToList
                    listaContidiciones.ForEach(Sub(fila)
                                                   Dim row As New DataGridViewRow
                                                   row = dwCondiciones.Rows(dwCondiciones.Rows.Add())
                                                   row.Cells(idCondicion.Index).Value = fila.Id
                                                   row.Cells(Condicion.Index).Value = fila.txtCondicion
                                                   row.Cells(Estado.Index).Value = If(fila.IdEstado = ClsEnums.Estados.ACTIVO, True, False)
                                                   row.Cells(Grupo.Index).Value = fila.Grupo
                                               End Sub)
                End If
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub renumerarNoGuardadas()
        Try
            DirectCast(Me.Parent.FindForm(), frmInicial).GlobalCotizaForms = 0
            Dim maxIdCotiza As Integer = mCotizacion.TraerMaxIdCotiza()
            My.Application.OpenForms.Cast(Of Windows.Forms.Form).ToList.ForEach(Sub(frm)
                                                                                    If TypeOf (frm) Is FrmCotizaciones Then
                                                                                        If DirectCast(frm, FrmCotizaciones).OperacionActual = ClsEnums.TiOperacion.INSERTAR Then
                                                                                            DirectCast(Me.Parent.FindForm(), frmInicial).GlobalCotizaForms += 1
                                                                                            frm.Text = "Cot. (" & maxIdCotiza + DirectCast(Me.Parent.FindForm(), frmInicial).GlobalCotizaForms & ")"
                                                                                        End If
                                                                                    End If
                                                                                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CalcularPreciosPlantilla(r As DataGridViewRow)
        Try
            If r.Cells(especial.Index).Value Is Nothing Then
                cargarAnalizador(r)
            End If
            Dim cp As New CargasPlantilla
            cp.ValorarAnalizador(DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico),
                                        curid, versionCostoAcabado, versionCostoNivel,
                                        versionCostoKiloAluminio, versionCostoVidrio, versionCostoAccesorio,
                                        versionCostoOtrosArticulos)
            Dim analiza As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)

            Dim calculo As New ClsCalculos
            calculo.tasaImpuesto = DirectCast(cmbTasaImpuesto.SelectedItem, ReglasNegocio.TasaImpuesto.tasaImpuesto).tasa
            calculo.indAIU = _indAIU
            Dim idAcabado As Integer = 32
            Dim idVidrio As Integer = 838
            Dim idColorVidrio As Integer = 32
            Dim idEspesor As Integer = 1
            If analiza.ListaVariables.Contains("ACABADO") Then
                idAcabado = DirectCast(acabadoPerf.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("ACABADO").Valor).Id
            End If
            If analiza.ListaVariables.Contains("TIPO_VIDRIO") Then
                idVidrio = DirectCast(vidrio.DataSource, List(Of articuloTemporal)).First(Function(x) x.Referencia = analiza.ListaVariables.Item("TIPO_VIDRIO").Valor).Id
            End If
            If analiza.ListaVariables.Contains("COLOR_VIDRIO") Then
                idColorVidrio = DirectCast(colorVidrio.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("COLOR_VIDRIO").Valor).Id
            End If
            If analiza.ListaVariables.Contains("ESPESOR") Then
                idEspesor = DirectCast(espesor.DataSource, List(Of espesorTemporal)).First(Function(x) Convert.ToString(x.Prefijo) = Convert.ToString(analiza.ListaVariables.Item("ESPESOR").Valor)).Id
            End If

            Dim cVidrio, cPerfiles, cAccesorios, cOtros,
                vlrDespVidrio, vlrDespPerfiles, vlrDespAccesorio,
                vlrDespOtros, costo_instala, costo_unitario As Decimal
            cVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
            cPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
            cAccesorios = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
            cOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
            vlrDespVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
            vlrDespPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
            vlrDespAccesorio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
            vlrDespOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
            costo_instala = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Instalacion_Total))
            costo_unitario = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Unitario))
            calculo.Calcular_Disenio(costo_unitario, Convert.ToDecimal(analiza.ListaVariables.Item("CANTIDAD").Valor),
                         Convert.ToDecimal(r.Cells(piezasxUnidad.Index).Value),
                         Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor), Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor),
                         r.Cells(descuento.Index).Value, Convert.ToDecimal(r.Cells(factor.Index).Value),
                         r.Cells(precioInstalacion.Index).Value, cVidrio, cPerfiles, cAccesorios, cOtros, costo_instala)
            ''valor y precio son lo mismo
            r.Cells(Me.vlrDesperdicioVidrio.Index).Value = vlrDespVidrio
            r.Cells(Me.vlrDesperdicioPerfiles.Index).Value = vlrDespPerfiles
            r.Cells(Me.vlrDesperdicioAccesorios.Index).Value = vlrDespAccesorio
            r.Cells(Me.vlrDesperdicioOtros.Index).Value = vlrDespOtros
            r.Cells(Me.precioUnitario.Index).Value = calculo.PrecioUnitario
            r.Cells(Me.precioTotal.Index).Value = calculo.PrecioTotal
            r.Cells(Me.precioInstalacion.Index).Value = calculo.PrecioInstalacion
            r.Cells(Me.costoinstalacion.Index).Value = costo_instala
            r.Cells(Me.costoUnitario.Index).Value = costo_unitario
            r.Cells(Me.costoTotal.Index).Value = calculo.CostoTotal
            r.Cells(Me.costoVidrio.Index).Value = cVidrio
            r.Cells(Me.costoPerfiles.Index).Value = cPerfiles
            r.Cells(Me.costoAccesorios.Index).Value = cAccesorios
            r.Cells(Me.costoOtros.Index).Value = costoOtros
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub crearCostos()
        Dim _infproducto As String = String.Empty
        Try
            listaCosto.Clear()
            dwcostosVidrio.DataSource = Nothing
            dwcostosVidrio.AutoGenerateColumns = False
            dwcostosAccesorios.AutoGenerateColumns = False
            dwcostosPerfiles.AutoGenerateColumns = False
            dwcostosOtros.AutoGenerateColumns = False
            Dim listd As List(Of DataGridViewRow) = New List(Of DataGridViewRow)()
            dwItems.Nodes.Cast(Of DataGridViewTreeNode).ToList.ForEach(Sub(n)
                                                                           n.Nodes.ToList.ForEach(Sub(nh)
                                                                                                      _infproducto = Convert.ToString(nh.Cells(id.Index).Value)
                                                                                                      Dim artSuelto As New ClsArticulos
                                                                                                      Dim ac As New ClsAcabados
                                                                                                      Dim esp As New ClsEspesores
                                                                                                      Select Case Convert.ToInt32(nh.Cells(tipoItem.Index).Value)
                                                                                                          Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                                                                              If nh.Cells(especial.Index).Value Is Nothing Then
                                                                                                                  cargarAnalizador(nh)
                                                                                                              End If
                                                                                                              Dim analiza As AnalizadorLexico = DirectCast(nh.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                                              analiza.ListaMateriales.Where(Function(a) CBool(a.Utilizar) = True And CInt(a.Parametros("VISIBILIDAD").Valor) = 1).ToList.ForEach(Sub(m)
                                                                                                                                                                                                                                                     Dim artMaterial As New ClsArticulos
                                                                                                                                                                                                                                                     Select Case m.TipoObjeto
                                                                                                                                                                                                                                                         Case ClsEnums.FamiliasMateriales.PERFILERIA
                                                                                                                                                                                                                                                             Dim pesoM As Decimal = artMaterial.TraerxReferencia(m.Parametros("REFERENCIA").Valor).Peso * (CDec(m.Parametros("DIMENSION").Valor / 1000) * CDec(m.Parametros("CANTIDAD").Valor))
                                                                                                                                                                                                                                                             listaCosto.Add(New costo(m.Id, m.Parametros("REFERENCIA").Valor & "-" & m.Parametros("ACABADO").Valor,
                                                                                                                                                                                                                                                           m.TipoObjeto, CDec(m.Parametros("DIMENSION").Valor / 1000) * CDec(m.Parametros("CANTIDAD").Valor),
                                                                                                                                                                                                                                                           artMaterial.TraerxReferencia(m.Parametros("REFERENCIA").Valor).unidadMedida.ToString, pesoM, m.Costo_Unitario, m.Costo_Total))
                                                                                                                                                                                                                                                         Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                                                                                                                                                                                             Dim ej = New Ejecutor
                                                                                                                                                                                                                                                             Dim espesor_vidrio As Decimal = ej.Parse(Convert.ToString(m.Parametros("ESPESOR").Valor))
                                                                                                                                                                                                                                                             Dim pesoM As Decimal = CDec(((m.Parametros("ANCHO").Valor * m.Parametros("ALTO").Valor) / 1000000) * espesor_vidrio) * 2.2 * CDec(m.Parametros("CANTIDAD").Valor)
                                                                                                                                                                                                                                                             listaCosto.Add(New costo(m.Id, m.Parametros("REFERENCIA").Valor & "-" & String.Format("{0:00}", espesor_vidrio) & "-" & m.Parametros("COLOR").Valor,
                                                                                                                                                                                                                                                           m.TipoObjeto, CDec((m.Parametros("ANCHO").Valor * m.Parametros("ALTO").Valor) / 1000000) * CDec(m.Parametros("CANTIDAD").Valor),
                                                                                                                                                                                                                                                           artMaterial.TraerxReferencia(m.Parametros("REFERENCIA").Valor).unidadMedida.ToString, pesoM, m.Costo_Unitario, m.Costo_Total))
                                                                                                                                                                                                                                                         Case Else
                                                                                                                                                                                                                                                             listaCosto.Add(New costo(m.Id, m.Parametros("REFERENCIA").Valor, m.TipoObjeto, CDec(m.Parametros("CANTIDAD").Valor),
                                                                                                                                                                                                                                                          artMaterial.TraerxReferencia(m.Parametros("REFERENCIA").Valor).unidadMedida, 0, m.Costo_Unitario, m.Costo_Total))
                                                                                                                                                                                                                                                     End Select

                                                                                                                                                                                                                                                 End Sub)

                                                                                                          Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                                              Dim espe As espesorTemporal = DirectCast(DirectCast((nh.Cells(espesor.Index)), System.Windows.Forms.DataGridViewComboBoxCell).DataSource, List(Of espesorTemporal)).FirstOrDefault(Function(x) x.Id = Convert.ToInt32(nh.Cells(espesor.Index).Value))
                                                                                                              If espe Is Nothing Then
                                                                                                                  espe = New espesorTemporal
                                                                                                              End If
                                                                                                              Dim ej = New Ejecutor
                                                                                                              Dim espesor_vidrio As Decimal = ej.Parse(espe.Prefijo)
                                                                                                              Dim peso As Decimal = (((CDec(nh.Cells(ancho.Index).Value) * CDec(nh.Cells(Alto.Index).Value)) / 1000000) * espesor_vidrio) * 2.2 * CDec(nh.Cells(Cantidad.Index).Value) * CDec(nh.Cells(piezasxUnidad.Index).Value)
                                                                                                              listaCosto.Add(New costo(nh.Cells(id.Index).Value, (artSuelto.TraerxId(nh.Cells(idArticulo.Index).Value)).Referencia & "-" & String.Format("{0:00}", CInt(espe.Prefijo)) & "-" & ac.TraerxId(nh.Cells(colorVidrio.Index).Value).Prefijo,
                                                                                                         DirectCast(Convert.ToInt32(nh.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales), ((CDec(nh.Cells(ancho.Index).Value) * CDec(nh.Cells(Alto.Index).Value)) / 1000000) * CDec(nh.Cells(Cantidad.Index).Value) * CDec(nh.Cells(piezasxUnidad.Index).Value), artSuelto.TraerxId(nh.Cells(idArticulo.Index).Value).unidadMedida, peso,
                                                                                                         nh.Cells(costoUnitario.Index).Value, nh.Cells(costoTotal.Index).Value))
                                                                                                          Case ClsEnums.FamiliasMateriales.PERFILERIA
                                                                                                              Dim peso As Decimal = artSuelto.TraerxReferencia(nh.Cells(Ubicacion.Index).Value).Peso * ((CDec(nh.Cells(ancho.Index).Value) / 1000) * CDec(nh.Cells(Cantidad.Index).Value) * CDec(nh.Cells(piezasxUnidad.Index).Value))
                                                                                                              listaCosto.Add(New costo(nh.Cells(id.Index).Value, nh.Cells(Ubicacion.Index).Value.ToString & "-" & ac.TraerTodos.Where(Function(a) a.Id = CInt(nh.Cells(acabadoPerf.Index).Value)).First().Prefijo.ToString,
                                                                                                         DirectCast(Convert.ToInt32(nh.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales), (CDec(nh.Cells(ancho.Index).Value) / 1000) * CDec(nh.Cells(Cantidad.Index).Value) * CDec(nh.Cells(piezasxUnidad.Index).Value), artSuelto.TraerxId(nh.Cells(idArticulo.Index).Value).unidadMedida.ToString, peso,
                                                                                                         nh.Cells(costoUnitario.Index).Value, nh.Cells(costoTotal.Index).Value))
                                                                                                          Case ClsEnums.FamiliasMateriales.ACCESORIOS
                                                                                                              listaCosto.Add(New costo(nh.Cells(id.Index).Value, nh.Cells(Ubicacion.Index).Value, DirectCast(Convert.ToInt32(nh.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales),
                                                                                                         CDec(nh.Cells(Cantidad.Index).Value) * CDec(nh.Cells(piezasxUnidad.Index).Value), artSuelto.TraerxId(nh.Cells(idArticulo.Index).Value).unidadMedida.ToString, 0, nh.Cells(costoUnitario.Index).Value, nh.Cells(costoTotal.Index).Value))
                                                                                                          Case ClsEnums.FamiliasMateriales.OTROS
                                                                                                              listaCosto.Add(New costo(nh.Cells(id.Index).Value, nh.Cells(Ubicacion.Index).Value, DirectCast(Convert.ToInt32(nh.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales),
                                                                                                         CDec(nh.Cells(Cantidad.Index).Value) * CDec(nh.Cells(piezasxUnidad.Index).Value), artSuelto.TraerxId(nh.Cells(idArticulo.Index).Value).unidadMedida.ToString, 0, nh.Cells(costoUnitario.Index).Value, nh.Cells(costoTotal.Index).Value))

                                                                                                      End Select
                                                                                                  End Sub)
                                                                       End Sub)


            Dim materiales = From mat In listaCosto
                             Order By mat.familiaMaterial, mat.referencia
                             Group By mat.referencia, mat.familiaMaterial Into g = Group, CostoTotal = Sum(mat.costoTotal), cantidad = Sum(mat.cantidad), peso = Sum(CDec(mat.peso))
                             Select g.First().referencia, und = If(g.First().familiaMaterial = ClsEnums.FamiliasMateriales.VIDRIO, "MTS2",
                                 If(g.First().familiaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA, "MTL", "UND")), g.First().familiaMaterial, CostoTotal, cantidad, peso



            dwcostosVidrio.DataSource = materiales.Where(Function(x) x.familiaMaterial = ClsEnums.FamiliasMateriales.VIDRIO).ToList()
            dwcostosAccesorios.DataSource = materiales.Where(Function(x) x.familiaMaterial = ClsEnums.FamiliasMateriales.ACCESORIOS).ToList()
            dwcostosPerfiles.DataSource = materiales.Where(Function(x) x.familiaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA).ToList()
            dwcostosOtros.DataSource = materiales.Where(Function(x) x.familiaMaterial = ClsEnums.FamiliasMateriales.OTROS).ToList()

            lbCostoVidrios.Text = FormatCurrency(dwcostosVidrio.Rows.Cast(Of DataGridViewRow).Sum(Function(a) a.Cells("costo").Value), 0)
            lbpesoVidrio.Text = FormatNumber(dwcostosVidrio.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells("peso").Value)), 2)
            lbmtsVidrio.Text = FormatNumber(dwcostosVidrio.Rows.Cast(Of DataGridViewRow).Sum(Function(a) a.Cells("cant").Value), 2)

            lbCostoAccesorios.Text = FormatCurrency(dwcostosAccesorios.Rows.Cast(Of DataGridViewRow).Sum(Function(a) a.Cells("CostoTotal1").Value), 0)

            lbCostoPerfiles.Text = FormatCurrency(dwcostosPerfiles.Rows.Cast(Of DataGridViewRow).Sum(Function(a) a.Cells("CostoTotal2").Value), 0)
            lbPesoPerfiles.Text = FormatNumber(dwcostosPerfiles.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells("peso2").Value)), 2)
            lbMetrosPerfiles.Text = FormatNumber(dwcostosPerfiles.Rows.Cast(Of DataGridViewRow).Sum(Function(a) a.Cells("cant2").Value), 2)

            lbCostoOtros.Text = FormatCurrency(dwcostosOtros.Rows.Cast(Of DataGridViewRow).Sum(Function(a) a.Cells("CostoTotal3").Value), 0)
        Catch ex As Exception
            MsgBox(_infproducto)
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
#Region "Validación Norma NSR"
    Public Function CumplimientoNorma(n As DataGridViewTreeNode, Optional recalculo As Boolean = False, Optional impresion As Boolean = True, Optional alertas As Boolean = True, Optional ocultar_calculos As Boolean = True) As Boolean
        Try
            If nudAltoEdificio.Value = 0 Then
                If alertas Then
                    Throw New Exception("El alto del edificio debe ser mayor a cero [0]")
                End If
                Return False
            End If
            If nudAnchoEdificio.Value = 0 Then
                If alertas Then
                    Throw New Exception("El ancho del edificio debe ser mayor a cero [0]")
                End If
                Return False
            End If
            If nudAlturaCaballete.Value = 0 Then
                If alertas Then
                    Throw New Exception("La altura del caballete debe ser mayor a cero [0]")
                End If
                Return False
            End If
            If nudAlturaAlero.Value = 0 Then
                If alertas Then
                    Throw New Exception("La altura del alero debe ser mayor a cero [0]")
                End If
                Return False
            End If
            If nudAltoEntreLosas.Value = 0 Then
                If alertas Then
                    Throw New Exception("El alto entre losas del edificio debe ser mayor a cero [0]")
                End If
                Return False
            End If
            Dim inercia As Decimal = 0
            Dim modulo_seccion As Decimal = 0
            Dim refperfil As String = String.Empty
            Dim mprm As New ClsPropiedadesMasicas
            If n.Level = 1 Then
                If Convert.ToInt32(n.Cells(idpropiedad.Index).Value) > 1 And Not recalculo Then
                    Dim mprop As PropiedadMasica = mprm.TraerporId(Convert.ToInt32(n.Cells(idpropiedad.Index).Value))
                    refperfil = mprop.Nombre
                    inercia = mprop.Inercia
                    modulo_seccion = mprop.ModuloSeccion
                Else
                    Dim frmselprop As New FrmSeleccionPropiedadMasica
                    If frmselprop.ShowDialog() = DialogResult.OK Then
                        inercia = frmselprop.Propiedad_Masica.Inercia
                        modulo_seccion = frmselprop.Propiedad_Masica.ModuloSeccion
                        refperfil = frmselprop.Propiedad_Masica.Nombre
                        n.Cells(idpropiedad.Index).Value = frmselprop.Propiedad_Masica.Id
                    Else
                        If alertas Then
                            Throw New Exception("No selecciono ninguna propiedad para realizar los cálculos de la norma")
                        End If
                        Return False
                    End If
                End If
            Else
                Dim mcpd As New ClsCombinacionPropiedadesDiseños
                Dim cpd As CombinacinPropiedadDiseño = mcpd.TraerporIdModelo(Convert.ToInt32(n.Cells(idArticulo.Index).Value))
                If cpd.IdPropiedadesMasica = 0 Then
                    If alertas Then
                        Throw New Exception("El diseño, no tiene propiedades másicas asignadas, comuníquese con el departamento de ingeniería")
                    End If
                    Return False
                End If
                Dim mprop As PropiedadMasica = mprm.TraerporId(cpd.IdPropiedadesMasica)
                refperfil = mprop.Nombre
                inercia = mprop.Inercia
                modulo_seccion = mprop.ModuloSeccion
            End If
            Dim velviento As New ClsVelocidadesViento
            Dim areaefectiva As Decimal = (Convert.ToDecimal(n.Cells(ancho.Index).Value) / Convert.ToDecimal(n.Cells(numero_cuerpos_norma.Index).Value) / 1000) * (Convert.ToDecimal(n.Cells(Alto.Index).Value) / 1000)
            Dim velvientB23 As Decimal = velviento.TraerxIdciudadyIdversion(Ciudad, 1).Valor
            Dim velvientB24 As Decimal = velviento.TraerxIdciudadyIdversion(Ciudad, 2).Valor
            If velvientB23 = 0 Or velvientB24 = 0 Then
                If alertas Then
                    Throw New Exception("La ciudad seleccionada en la cotización, no tiene asignada una velocidad del viento")
                End If
                Return False
            End If
            Dim b23 As New NSR10.Base_Reglas("B.2.3", Convert.ToString(n.Cells(Ubicacion.Index).Value), velvientB23, Convert.ToInt32(cmbGruposUso.SelectedValue),
                                             Convert.ToInt32(cmbCategExposicion.SelectedValue), nudAlturaCaballete.Value, nudAlturaAlero.Value,
                                             nudAnchoEdificio.Value, nudAltoEdificio.Value, Convert.ToInt32(cmbTipoCubierta.SelectedValue),
                                             Convert.ToInt32(cmbTipoEdificacion.SelectedValue), areaefectiva, nudAltoEntreLosas.Value)

            Dim b24 As New NSR10.Base_Reglas("B.2.4", Convert.ToString(n.Cells(Ubicacion.Index).Value), velvientB24, Convert.ToInt32(cmbGruposUso.SelectedValue),
                                             Convert.ToInt32(cmbCategExposicion.SelectedValue), nudAlturaCaballete.Value, nudAlturaAlero.Value,
                                             nudAnchoEdificio.Value, nudAltoEdificio.Value, Convert.ToInt32(cmbTipoCubierta.SelectedValue),
                                             Convert.ToInt32(cmbTipoEdificacion.SelectedValue), areaefectiva, nudAltoEntreLosas.Value)

            Dim calculos As New NSR10.Calculos_10(Convert.ToString(n.Cells(Ubicacion.Index).Value), refperfil, b23, b24, inercia, modulo_seccion, txtCiudad.Text,
                                                  Convert.ToDecimal(n.Cells(ancho.Index).Value) / Convert.ToDecimal(n.Cells(numero_cuerpos_norma.Index).Value), Convert.ToDecimal(n.Cells(Alto.Index).Value),
                                                  Convert.ToInt32(cmbCategExposicion.SelectedValue), Convert.ToInt32(cmbpresionModelo.SelectedValue), nudAltoEntreLosas.Value)

            calculos.Calculo_de_Parametros()
            Dim plist As List(Of NSR10.Parametros_Tabla_Final_10) = calculos.GenerarTabla()
            If plist.Where(Function(p) Not p.Resistencia Or Not p.Deflexion).Count > 0 Then
                If alertas Then
                    MsgBox("EL diseño " & Convert.ToString(n.Cells(Ubicacion.Index).Value) & " no cumple con la norma", MsgBoxStyle.Critical)
                End If
                Return False
            End If
            If impresion Then
                If MsgBox("¿Desea imprimir los documentos de calculo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim mCot As New datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter
                    Dim tencabe As DataTable = mCot.GetData(curid)
                    tencabe.Rows(0).Item("usuarioCreacion") = My.Settings.Nombre_Usuario_Activo
                    Dim dscalculos As DataSet = calculos.RetornoparaInforme()
                    dscalculos.Tables.Add(tencabe.Copy())
                    dscalculos.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "calculos_NSR10.xml"))
                    Dim infcalculosNSR As New Informes.calculo_NSR10
                    infcalculosNSR.SetDataSource(dscalculos)
                    infcalculosNSR.PrintToPrinter(1, False, 0, 0)
                End If
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
#Region "Información general"

#Region "Carga de Combobox"
    Private Sub cargarAcabados()
        Try
            mAcabados = New ClsAcabados
            listAcabadoGlobal = New List(Of Acabado)
            listAcabadoGlobal = mAcabados.TraerTodos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarFormaPago()
        Try
            mformaPago = New ClsFormasPago
            listFormasPago = New List(Of formaPago)
            listFormasPago = mformaPago.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTasaImpuesto()
        Try
            mTasaImpuesto = New ClsTasaImpuesto
            listTImpuesto = New List(Of tasaImpuesto)
            listTImpuesto = mTasaImpuesto.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTiempoEntrega()
        Try
            mTiempoEntrega = New ClsTiempoEntrega
            listTiempoEntrega = New List(Of tiempoEntrega)
            listTiempoEntrega = mTiempoEntrega.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try

    End Sub
    Private Sub cargarTipoDocumento()
        Try
            mTipoDocumento = New ClsTiposIdentificacion
            listTipoDoc = New List(Of TiposIdentificacion)
            listTipoDoc = mTipoDocumento.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTipoEdificacion()
        Try
            mTipoEdificacion = New ClsTipoEdificacion
            listEdificacion = New List(Of tipoEdificacion)
            listEdificacion = mTipoEdificacion.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCategExposicion()
        Try
            mCategExposicion = New ClsCategExposicion
            listCategExp = New List(Of categExposicion)
            listCategExp = mCategExposicion.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarGruposUso()
        Try
            mGrupoUso = New ClsGrupoUso
            listGruposUso = New List(Of grupoUso)
            listGruposUso = mGrupoUso.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTiposCubierta()
        Try
            mTipoCubierta = New ClsTipoCubierta
            listTipoCubierta = New List(Of tipoCubuertas)
            listTipoCubierta = mTipoCubierta.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarPresionesModelo()
        Try
            Dim mpresion As New ClsPresionModelo
            listPresionesModelo = New List(Of presionModelos)
            listPresionesModelo = mpresion.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEstado()
        Try
            mEstado = New ClsEstados
            listEstados = New List(Of Estado)
            listEstados = mEstado.TraerTodos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVendedor()
        Try
            mVendedor = New ClsVendedoresSiesa
            listVendedores = New List(Of vendedor)
            listVendedores = mVendedor.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTiposObra()
        Try
            mTipoObra = New ClsTiposObras
            listTipoObra = New List(Of tipoObra)
            listTipoObra = mTipoObra.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVigencias()
        Try
            mVigencia = New ClsVigencias
            listVigencia = New List(Of Vigencia)
            listVigencia = mVigencia.traerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarFactores()
        Try
            Dim mFactores As New ClsFactores
            Dim listFactores As List(Of factores) = mFactores.traerValorDefectoByCiudad(Ciudad)
            If Not mFactores.ExisteValorDefecto(Ciudad) Then
                listFactores = mFactores.TraerxEstadoAndCiudad(1, Ciudad)
            End If
            Dim bsource As New BindingSource()
            bsource.DataSource = listFactores
            cmbFactor.Text = String.Empty
            cmbFactor.DisplayMember = "tasa"
            cmbFactor.ValueMember = "Id"
            cmbFactor.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInstalacion()
        Try
            Dim mInstalacion As New ClsManoObraInstalacion
            Dim listInstalacion As List(Of manoObraInstalacion) = mInstalacion.TraerxValorDefectoAndCiudad(Ciudad)
            Dim bsource As New BindingSource
            bsource.DataSource = listInstalacion
            cmbInstalacion.Text = String.Empty
            cmbInstalacion.DisplayMember = "valorInstalacion"
            cmbInstalacion.ValueMember = "Id"
            cmbInstalacion.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarComponente()
        Try
            Dim mComponente = New ClsComponentes
            Dim listComponentes As List(Of componente) = mComponente.TraerxIdTipoCotizacion(cmbTipoObra.SelectedValue)
            Dim bsource = New BindingSource
            bsource.DataSource = listComponentes
            cmbComponente.DisplayMember = "descripcion"
            cmbComponente.ValueMember = "Id"
            cmbComponente.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region

#Region "Carga de TextBox"
    Private Sub cargarNombresCotizaciones()
        Try
            mCotizacion = New ClsCostizaciones
            listByNombreCotiza = New List(Of cotizacion)
            listByNombreCotiza = mCotizacion.TraerNombreCotizacion()
            txtNombreCotizacion.AutoCompleteCustomSource.AddRange(listByNombreCotiza.Select(Function(a) a.nombreCotizacion).ToArray())
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarClientes()
        Try
            mCotizacion = New ClsCostizaciones
            listByNombreCliente = New List(Of cotizacion)
            listByNombreCliente = mCotizacion.TraerNombreCliente()
            txtCliente.AutoCompleteCustomSource.AddRange(listByNombreCliente.Select(Function(a) a.cliente).ToArray())
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDocumentos(idTipoDocumento As Integer)
        Try
            listByDocumentoCliente = New List(Of cotizacion)
            listByDocumentoCliente = mCotizacion.TraerNumeroDocumento(1)
            txtDocumento.AutoCompleteCustomSource.AddRange(listByDocumentoCliente.Select(Function(a) a.numIdentificacion).ToArray())
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarNombreObra(nombreCliente As String)
        Try
            listByNombreObra = New List(Of cotizacion)
            listByNombreObra = mCotizacion.TraerNombreObra(nombreCliente)
            txtNombreObra.AutoCompleteCustomSource.AddRange(listByNombreObra.Select(Function(a) a.nomObra).ToArray())
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#Region "Validación durante ingreso de datos"
    Private Sub txtSoloLetras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactoObra.KeyPress, txtContactoCliente.KeyPress
        Try
            If Char.IsLetter(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsSeparator(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#Region "Autocompletado de campos"
    Private Sub txtNombreCotizacion_GotFocus(sender As Object, e As EventArgs) Handles txtNombreCotizacion.GotFocus
        Try
            If txtNombreCotizacion.AutoCompleteCustomSource.Count > 0 Then
                Exit Sub
            Else
                cargarNombresCotizaciones()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbTipoDocumento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoDocumento.SelectedValueChanged
        Try
            If cmbTipoDocumento.SelectedValue IsNot Nothing Then
                cargarDocumentos(cmbTipoDocumento.SelectedValue)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtDocumento_TextChanged(sender As Object, e As EventArgs) Handles txtDocumento.TextChanged
        Try
            mDigitoVerificacion = New DigitoVerificacion
            txtDigitoVerificacion.Text = mDigitoVerificacion.calculoDigitoVerificacion(txtDocumento)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtDocumento_Leave(sender As Object, e As EventArgs) Handles txtDocumento.Leave
        Try
            If txtDocumento.Text <> String.Empty Then
                mCotizacion = New ClsCostizaciones
                Dim datosCliente As List(Of cotizacion) = mCotizacion.TraerxNumeroDocumento(txtDocumento.Text)
                For Each dato As cotizacion In datosCliente
                    txtCliente.Text = dato.cliente
                    txtTelefonoCliente.Text = dato.telCliente.ToString
                    txtDireccionCliente.Text = dato.dirCliente
                    txtCorreoCliente.Text = dato.mailCliente
                    txtContactoCliente.Text = dato.nomContacCliente
                    cargarNombreObra(dato.cliente)
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtCliente_GotFocus(sender As Object, e As EventArgs) Handles txtCliente.GotFocus
        Try
            If txtCliente.AutoCompleteCustomSource.Count > 0 Then
                Exit Sub
            Else
                cargarClientes()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtCliente_Leave(sender As Object, e As EventArgs) Handles txtCliente.Leave
        Try
            If txtCliente.Text <> String.Empty Then
                mCotizacion = New ClsCostizaciones
                Dim datosCliente As List(Of cotizacion) = mCotizacion.TraerxNombreCliente(txtCliente.Text)
                For Each dato As cotizacion In datosCliente
                    cmbTipoDocumento.SelectedValue = dato.idIdentificacion
                    txtDocumento.Text = dato.numIdentificacion
                    txtTelefonoCliente.Text = dato.telCliente.ToString
                    txtDireccionCliente.Text = dato.dirCliente
                    txtCorreoCliente.Text = dato.mailCliente
                    txtContactoCliente.Text = dato.nomContacCliente
                    cargarNombreObra(dato.cliente)
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtNombreObra_Leave(sender As Object, e As EventArgs) Handles txtNombreObra.Leave
        Try
            If txtNombreObra.Text <> String.Empty Then
                mCotizacion = New ClsCostizaciones
                Dim datos As cotizacion = mCotizacion.TraerxNombreObra(txtNombreObra.Text)
                txtContactoObra.Text = datos.nomContacObra
                txtTelefonoObra.Text = datos.telObra
                txtCorreoObra.Text = datos.mailObra
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#Region "Combo box especiales"
    Private Sub txtCiudad_TextChanged(sender As Object, e As EventArgs) Handles txtCiudad.TextChanged
        Try
            cargarFactores()
            cargarInstalacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbFactor_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbFactor.KeyUp
        Try
            If Not IsNumeric(cmbFactor.Text) Then
                cmbFactor.Text = String.Empty
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbInstalacion_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbInstalacion.KeyUp
        Try
            If Not IsNumeric(cmbInstalacion.Text) Then
                cmbInstalacion.Text = String.Empty
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmb_Events(sender As Object, e As EventArgs) Handles cmbFactor.Click, cmbFactor.TextChanged,
            cmbInstalacion.Click, cmbInstalacion.TextChanged
        Try
            If txtCiudad.Text = String.Empty Then
                cmbFactor.Text = String.Empty
                cmbInstalacion.Text = String.Empty
                MessageBox.Show("Primero seleccione la ciudad en la cual se está realizando la cotización", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            If cmbInstalacion.Text Is String.Empty Then
                cbInstalacion.Checked = False
            Else
                If Convert.ToDecimal(cmbInstalacion.Text) > 0 Then
                    cbInstalacion.Checked = True
                Else
                    cbInstalacion.Checked = False
                End If
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbFactor_LostFocus(sender As Object, e As EventArgs) Handles cmbFactor.LostFocus
        Try
            If txtCiudad.Text <> String.Empty Then
                objFactor = New ClsFactores

                Dim valor As Decimal = 0
                If Decimal.TryParse(cmbFactor.Text, valor) Then
                    Dim ExisteValor As Integer = Convert.ToInt32(objFactor.ExisteFactor(valor, Ciudad))

                    If ExisteValor = 0 Then
                        If valor = 0 Then
                            ErrorProvider.SetError(cmbFactor, "Debe ingresar o seleccionar un factor. El factor está asociado a la ciudad")
                            Return
                        End If
                        ErrorProvider.Clear()
                        ErrorProvider1.Clear()

                        Dim formularioFactor As New FrmFactoresDescripcion
                        If MessageBox.Show("El factor en pantalla no existe. ¿Desea registrarlo?", "", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information) = DialogResult.Yes Then
                            formularioFactor.TasaUtilidad = Convert.ToDecimal(cmbFactor.Text)
                            formularioFactor.idCiudad = Convert.ToInt32(Ciudad)
                            formularioFactor.NombreCiudad = txtCiudad.Text

                            If formularioFactor.ShowDialog() = DialogResult.OK Then
                                cargarFactores()
                                cmbFactor.SelectedIndex = cmbFactor.Items.Count - 1
                                ExisteValor = 1
                            Else
                                cmbFactor.SelectedValue = 1
                            End If
                        End If
                    Else
                        Dim l_f As List(Of factores) = DirectCast(DirectCast(cmbFactor.DataSource, System.Windows.Forms.BindingSource).DataSource, List(Of factores))
                        Dim v = l_f.FirstOrDefault(Function(f) f.tasa = Convert.ToDecimal(cmbFactor.Text))
                        cmbFactor.SelectedItem = v
                    End If
                End If
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbInstalacion_LostFocus(sender As Object, e As EventArgs) Handles cmbInstalacion.LostFocus
        Try
            If txtCiudad.Text <> String.Empty Then
                objInstalacion = New ClsManoObraInstalacion

                Dim valor As Decimal = 0
                If Decimal.TryParse(cmbInstalacion.Text, valor) Then
                    Dim ExisteValor As Integer = Convert.ToInt32(objInstalacion.ExisteManoObra(valor, Ciudad))
                    If ExisteValor = 0 Then
                        If valor = 0 Then
                            ErrorProvider.SetError(cmbFactor, "Debe ingresar o seleccionar un valor. El costo de instalación está asociado a la ciudad")
                            Return
                        End If
                        ErrorProvider.Clear()
                        ErrorProvider1.Clear()
                        Dim formularioManoObra As New FrmManoObraDescripcion
                        If MessageBox.Show("El valor de mano de obra de instalación en pantalla no existe. ¿Desea registrarlo?", "", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information) = DialogResult.Yes Then
                            formularioManoObra.Valor = valor
                            formularioManoObra.idCiudad = Convert.ToInt32(Ciudad)
                            formularioManoObra.NombreCiudad = txtCiudad.Text

                            If formularioManoObra.ShowDialog() = DialogResult.OK Then
                                cargarInstalacion()
                                cmbInstalacion.SelectedIndex = cmbInstalacion.Items.Count - 1
                                ExisteValor = 1
                            Else
                                cmbInstalacion.SelectedValue = 1
                            End If
                        End If
                    End If
                End If
                'cbInstalacion.Checked = False
            Else
                'cbInstalacion.Checked = False
            End If

            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbInstalacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbInstalacion.SelectedValueChanged
        Try
            If isLoad Then
                recalcularValoreInstalacion()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub RefrescarComboBox(Cmb As ComboBox, index As Integer)
        Try
            Cmb.SelectedValue = 0
            Cmb.SelectedValue = index
            Cmb.DroppedDown = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#End Region
#Region "Elementos Carga Gráfica"
    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Dim carga As New FrmCargaProceso
            carga.Proceso = e.Argument
            Application.Run(carga)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Movimiento"
    Private Sub btonAddGrupo_Click(sender As Object, e As EventArgs) Handles btonAddGrupo.Click
        Try
            If cmbFactor.Text = String.Empty Then
                MessageBox.Show("Debe seleccionar un factor antes de agregar un nuevo grupo", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If
            Dim factor As Decimal = Convert.ToDecimal(cmbFactor.Text)
            If factor <= 0 Then
                MessageBox.Show("El factor debe ser mayor a cero (0) para agregar un nuevo grupo", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If
            Dim nodoPadre As New DataGridViewTreeNode
            dwItems.Nodes.Add(nodoPadre)
            movimientoModificable = False
            Dim frmItem As New FrmAddItemPadre
            frmItem.ListArticulos = listArticulos
            frmItem.ListColores = listColores
            frmItem.ListEspesores = listEspesores
            frmItem.ListAcabados = listAcabados
            frmItem.idTasaImpuestoGlobal = DirectCast(cmbTasaImpuesto.SelectedItem, ReglasNegocio.ClsBaseParametros).Id
            frmItem.tasaImpuestoGlobal = DirectCast(cmbTasaImpuesto.SelectedItem, ReglasNegocio.TasaImpuesto.tasaImpuesto).tasa
            frmItem.FactorGlobal = cmbFactor.SelectedItem
            frmItem.AcabadoGlobal = cmbAcabado.SelectedItem
            frmItem.DescuentoGlobal = nudDescuentoSum.Value
            frmItem.indAIU = _indAIU
            frmItem.tasaImpuestoGlobal = DirectCast(cmbTasaImpuesto.SelectedItem, ReglasNegocio.TasaImpuesto.tasaImpuesto).tasa
            frmItem.NodoItem = nodoPadre
            frmItem.tipoFormulario = ClsEnums.TiOperacion.INSERTAR
            frmItem.idCotiza = curid
            frmItem.TieneTemporales = _tieneTemporales
            frmItem.VersionCostoAcabado = versionCostoAcabado
            frmItem.VersionCostoNivel = versionCostoNivel
            frmItem.VersionCostoKAlum = versionCostoKiloAluminio
            frmItem.VersionCostoVidrio = versionCostoVidrio
            frmItem.VersionCostoAccesorio = versionCostoAccesorio
            frmItem.VersionCostoOtros = versionCostoOtrosArticulos
            frmItem.tieneInstalacion = cbInstalacion.Checked
            If cbInstalacion.Checked = False Then
                frmItem.nudPrecioInstalacion.Value = 0
                frmItem.nudPrecioInstalacion.Enabled = False
            Else
                If frmItem.indAIU Then
                    frmItem.nudPrecioInstalacion.Value = Convert.ToDecimal(cmbInstalacion.Text) + (Convert.ToDecimal(cmbInstalacion.Text) * (frmItem.tasaImpuestoGlobal / 100))
                Else
                    frmItem.nudPrecioInstalacion.Value = Convert.ToDecimal(cmbInstalacion.Text)
                End If
            End If
            If frmItem.ShowDialog() = DialogResult.OK Then
                actualizar_todos()
                movimientoModificable = True
                If Not Convert.ToBoolean(nodoPadre.Cells(calcularnorma.Index).Value) Then
                    For i As Integer = 0 To nodoPadre.Nodes.Count - 1
                        If Convert.ToInt32(nodoPadre.Nodes(i).Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                            nodoPadre.Nodes(i).Cells(cumplenorma.Index).Value = CumplimientoNorma(nodoPadre.Nodes(i), impresion:=False, alertas:=False)
                        End If
                    Next
                End If
                crearCostos()
                GuardadoTotal_Click(sender, e)
            Else
                dwItems.Nodes.Remove(nodoPadre)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Dim cms_menu As New ContextMenuStrip
    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                dwItems.Rows(e.RowIndex).Selected = True

                'cms_menu.Items.Clear()
                If DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode).Level = 1 Then
                    If Validar_Copiar_Elementos() Then
                        cms_menu.Items.Add("Copiar", Nothing, AddressOf Copiar_Elementos)
                    End If
                    If Not tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                        If Convert.ToBoolean(dwItems.Rows(e.RowIndex).Cells(calcularnorma.Index).Value) Then
                            cms_menu.Items.Add("Norma NSR Automático", Nothing, AddressOf Automatico_NSR)
                            cms_menu.Items.Add("Re-calcular Norma", Nothing, AddressOf Recalcular_Norma_NSR)
                            cms_menu.Items.Add("Imprimir Norma NSR", Nothing, AddressOf Imprimir_Norma_NSR)
                        Else
                            cms_menu.Items.Add("Norma NSR Manual", Nothing, AddressOf Manual_NSR)
                        End If
                        cms_menu.Items.Add("Duplicar", Nothing, AddressOf duplicarNodo)
                        cms_menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    End If
                    cms_menu.Items.Add("Modificar", Nothing, AddressOf modificarNodo)
                    If dwItems.Columns(costoUnitario.Index).Visible = False Or
                        dwItems.Columns(costoTotal.Index).Visible = False Then
                        cms_menu.Items.Add("Mostrar más", Nothing, AddressOf mostrarCostos)
                    Else
                        cms_menu.Items.Add("Mostrar menos", Nothing, AddressOf ocultarCostos)
                    End If
                Else
                    If Not tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                        cms_menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    End If
                    If Convert.ToInt32(DirectCast(dwItems.Rows(e.RowIndex), DataGridViewRow).Cells(tipoItem.Index).Value) =
                            ClsEnums.FamiliasMateriales.DISEÑOS Then
                        cms_menu.Items.Add("Lista de materiales", Nothing, AddressOf MostrarMateriales)
                        If Convert.ToBoolean(dwItems.Item(calcularnorma.Index, e.RowIndex).Value) And Not tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                            cms_menu.Items.Add("Re-calcular Norma", Nothing, AddressOf Recalcular_Norma_NSR)
                            cms_menu.Items.Add("Imprimir Norma NSR", Nothing, AddressOf Imprimir_Norma_NSR)
                        End If
                    End If
                End If
                If Not cms_menu.Visible Then
                    cms_menu.Show(Control.MousePosition)
                End If
            ElseIf e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Left Then
                If DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode).Level = 1 Then
                    Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                    r.Cells(Ubicacion.Index).ReadOnly = False
                    r.Cells(Descripcion.Index).ReadOnly = False
                    r.Cells(ancho.Index).ReadOnly = False
                    r.Cells(Alto.Index).ReadOnly = False
                    r.Cells(Cantidad.Index).ReadOnly = False
                Else
                    Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                    If Convert.ToInt32(r.Cells(tipoItem.Index).Value) = 1 Then
                        r.Cells(ancho.Index).ReadOnly = False
                        r.Cells(Alto.Index).ReadOnly = False
                        r.Cells(Cantidad.Index).ReadOnly = False
                    ElseIf Convert.ToInt32(r.Cells(tipoItem.Index).Value) = 2 Then

                    ElseIf Convert.ToInt32(r.Cells(tipoItem.Index).Value) = 3 Then
                        r.Cells(ancho.Index).ReadOnly = False
                        r.Cells(Alto.Index).ReadOnly = True
                        r.Cells(Cantidad.Index).ReadOnly = False
                    ElseIf Convert.ToInt32(r.Cells(tipoItem.Index).Value) = 4 Then

                    ElseIf Convert.ToInt32(r.Cells(tipoItem.Index).Value) = 5 Then
                        r.Cells(ancho.Index).ReadOnly = False
                        r.Cells(Alto.Index).ReadOnly = False
                        r.Cells(Cantidad.Index).ReadOnly = False
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_MouseClick(sender As Object, e As MouseEventArgs) Handles dwItems.MouseClick
        Try
            If e.Button = MouseButtons.Right Then
                cms_menu.Items.Clear()
                If Validar_Pegar_Elementos() Then
                    cms_menu.Items.Add("Pegar", Nothing, AddressOf Pegar_Elementos)
                End If
                cms_menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseDoubleClick
        Try
            If tform = ClsEnums.TiOperacion.SOLO_LECTURA Then Return
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Left Then
                If DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode).Level = 1 Then
                    modificarNodo()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDatos(tb As DataTable)
        Try
            If tb.Rows.Count = 0 Then Exit Sub
            tb.Columns.Cast(Of DataColumn).AsParallel.ForAll(Sub(columna)
                                                                 If dwItems.Columns.Contains(columna.ColumnName) Then
                                                                     dwItems.Columns(columna.ColumnName).DataPropertyName = columna.ColumnName
                                                                 End If
                                                             End Sub)
            dwItems.DataSource = tb
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tbCotizaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbCotizaciones.SelectedIndexChanged
        Try
            If OperacionActual = ClsEnums.TiOperacion.MODIFICAR Or OperacionActual = ClsEnums.TiOperacion.SOLO_LECTURA Then

                If tbCotizaciones.SelectedTab Is tbVistaInterna Then
#Region "Vista previa impresión Interna"
                    bwcargas.RunWorkerAsync("Cargando Informe...")
                    Dim ds As DataSet = Generar_Documento_Impresion(True)
                    ' CamposAdicionales(ds.Tables(0))
                    Dim mCothijos As New datosInformesTableAdapters.sp_tc018_selectByIdCotizaXMLTableAdapter
                    Dim tablahijos As DataTable = mCothijos.GetData(curid)
                    ' AcomodarVariables(tablahijos)
                    ds.Tables.Add(tablahijos)
                    ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "Cotizacion_Interna_Reload.xml"))
                    Dim b As New Informes.CotizacionInternaH
                    b.SetDataSource(ds)
                    visorInterna.ReportSource = b
                    If (Application.OpenForms("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
#End Region
                ElseIf tbCotizaciones.SelectedTab Is tbVistaPrevia Then
#Region "Vista previa impresión cliente"
                    bwcargas.RunWorkerAsync("Cargando Informe...")
                    Dim ds As DataSet = Generar_Documento_Impresion(True)
                    Dim b As New Informes.CotizacionClienteV
                    b.SetDataSource(ds)
                    visorCliente.ReportSource = b
                    visorCliente.Zoom(150)
                    If (Application.OpenForms("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
#End Region
                ElseIf tbCotizaciones.SelectedTab Is tbcargasdeviento Then
#Region "Cargas Viento"
                    cmbversioncargasviento_SelectedIndexChanged(cmbversioncargasviento, Nothing)
#End Region
                ElseIf tbCotizaciones.SelectedTab Is tbVistaAsesor Then
#Region "Vista previa Asesor"
                    bwcargas.RunWorkerAsync("Cargando Informe...")
                    Dim ds As DataSet = Generar_Documento_Impresion(True)
                    ' CamposAdicionales(ds.Tables(0))
                    Dim mCothijos As New datosInformesTableAdapters.sp_tc018_selectByIdCotizaXMLTableAdapter
                    Dim tablahijos As DataTable = mCothijos.GetData(curid)
                    ' AcomodarVariables(tablahijos)
                    ds.Tables.Add(tablahijos)
                    ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "Cotizacion_Interna_Reload.xml"))
                    Dim b As New Informes.CotizaInternaVendedores
                    b.SetDataSource(ds)
                    visorAsesor.ReportSource = b
                    If (Application.OpenForms("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
#End Region
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            If (Application.OpenForms("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        End Try
    End Sub
    Private Sub tsbDuplicadoItem_Click(sender As Object, e As EventArgs)
        Try
            If cmbFactor.Text = String.Empty Then
                MessageBox.Show("Debe seleccionar un factor antes de agregar un nuevo grupo", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If
            Dim factor As Decimal = Convert.ToDecimal(cmbFactor.Text)
            If factor <= 0 Then
                MessageBox.Show("El factor debe ser mayor a cero (0) para agregar un item", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If
            Dim frmDuplicaItem As New frmDuplicadoItem
            frmDuplicaItem.StartPosition = FormStartPosition.CenterScreen
            If frmDuplicaItem.ShowDialog() = DialogResult.OK Then
                Dim n As DataGridViewTreeNode = frmDuplicaItem.Nodo
                Dim nnod As DataGridViewTreeNode = dwItems.Nodes.Add()
                dwItems.Columns.Cast(Of DataGridViewColumn).ToList.ForEach(Sub(col)
                                                                               nnod.Cells(col.Index).Value = n.Cells(col.Index).Value
                                                                           End Sub)
                n.Nodes.ToList.ForEach(Sub(item)
                                           Dim newItem As DataGridViewTreeNode = nnod.Nodes.Add()
                                           dwItems.Columns.Cast(Of DataGridViewColumn).ToList.ForEach(Sub(col)
                                                                                                          nnod.Cells(col.Index).Value = n.Cells(col.Index).Value
                                                                                                      End Sub)
                                       End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellValueChanged
        Try
            If movimientoModificable Then
                Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
                If nodo.Level = 1 Then
                    If dwItems.CurrentCell.OwningColumn.Index = acabadoPerf.Index Then
                        If MessageBox.Show("¿Desea heredar el cambio a los items hijos?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            nodo.Nodes.ToList.ForEach(Sub(ndh)
                                                          If Convert.ToInt32(ndh.Cells(tipoItem.Index).Value) = 1 Or Convert.ToInt32(ndh.Cells(tipoItem.Index).Value) = 3 Then
                                                              ndh.Cells(acabadoPerf.Index).Value = nodo.Cells(acabadoPerf.Index).Value
                                                          Else
                                                              ndh.Cells(acabadoPerf.Index).Value = 32
                                                          End If
                                                      End Sub)
                        End If
                    ElseIf dwItems.CurrentCell.OwningColumn.Index = colorVidrio.Index Then
                        If MessageBox.Show("¿Desea heredar el cambio a los items hijos?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            nodo.Nodes.ToList.ForEach(Sub(ndh)
                                                          If Convert.ToInt32(ndh.Cells(tipoItem.Index).Value) = 1 Or Convert.ToInt32(ndh.Cells(tipoItem.Index).Value) = 5 Then
                                                              ndh.Cells(colorVidrio.Index).Value = nodo.Cells(colorVidrio.Index).Value
                                                          Else
                                                              ndh.Cells(colorVidrio.Index).Value = 32
                                                          End If
                                                      End Sub)
                        End If
                    ElseIf dwItems.CurrentCell.OwningColumn.Index = espesor.Index Then
                        If MessageBox.Show("¿Desea heredar el cambio a los items hijos?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            nodo.Nodes.ToList.ForEach(Sub(ndh)
                                                          If Convert.ToInt32(ndh.Cells(tipoItem.Index).Value) = 1 Or Convert.ToInt32(ndh.Cells(tipoItem.Index).Value) = 5 Then
                                                              ndh.Cells(espesor.Index).Value = nodo.Cells(espesor.Index).Value
                                                          Else
                                                              ndh.Cells(espesor.Index).Value = 1
                                                          End If
                                                      End Sub)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItems.CellBeginEdit
        Try
            Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
            If nodo.Level <> 1 Then
                If TypeOf dwItems.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
                    e.Cancel = True
                End If
                Select Case DirectCast(Convert.ToInt32(nodo.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                    Case ClsEnums.FamiliasMateriales.DISEÑOS
#Region "Validación Diseños"
                        If nodo.Cells(especial.Index).Value Is Nothing Then
                            cargarAnalizador(DirectCast(nodo, DataGridViewRow))
                        End If
                        Select Case e.ColumnIndex
                            Case acabadoPerf.Index
                                If Not DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ACABADO") Then
                                    e.Cancel = True
                                End If
                            Case ancho.Index
                                If Not DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ANCHO") Then
                                    e.Cancel = True
                                End If
                            Case Alto.Index
                                If Not DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ALTO") Then
                                    e.Cancel = True
                                End If
                            Case Cantidad.Index
                                If Not DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("CANTIDAD") Then
                                    e.Cancel = True
                                End If
                            Case colorVidrio.Index
                                If Not DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("COLOR_VIDRIO") Then
                                    e.Cancel = True
                                End If
                            Case espesor.Index
                                If Not DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ESPESOR") Then
                                    e.Cancel = True
                                End If
                            Case vidrio.Index
                                If Not DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("VIDRIO") Then
                                    e.Cancel = True
                                End If
                        End Select
#End Region
                    Case ClsEnums.FamiliasMateriales.ACCESORIOS, ClsEnums.FamiliasMateriales.PERFILERIA
#Region "Accesorios y Perfiles"
                        If e.ColumnIndex = vidrio.Index Or e.ColumnIndex = colorVidrio.Index Or
                             e.ColumnIndex = espesor.Index Or e.ColumnIndex = Alto.Index Then
                            e.Cancel = True
                        End If
#End Region
                    Case ClsEnums.FamiliasMateriales.OTROS
#Region "Otros"
                        If e.ColumnIndex = vidrio.Index Or e.ColumnIndex = colorVidrio.Index Or
                             e.ColumnIndex = espesor.Index Or e.ColumnIndex = Alto.Index Or e.ColumnIndex = acabadoPerf.Index Then
                            e.Cancel = True
                        End If
#End Region
                    Case ClsEnums.FamiliasMateriales.VIDRIO
#Region "Vidrios"
                        If e.ColumnIndex = acabadoPerf.Index Then
                            e.Cancel = True
                        End If
#End Region
#Region "Temporales"
                    Case ClsEnums.FamiliasMateriales.TEMPORAL
                        If e.ColumnIndex = acabadoPerf.Index Or e.ColumnIndex = vidrio.Index Or
                            e.ColumnIndex = colorVidrio.Index Or e.ColumnIndex = espesor.Index Then
                            e.Cancel = True
                        End If
#End Region
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
            If nodo.Level <> 1 Then
#Region "Plantillas"
                If DirectCast(Convert.ToInt32(nodo.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                    Select Case e.ColumnIndex
                        Case acabadoPerf.Index
                            If DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ACABADO") Then
                                DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Item("ACABADO").Valor = nodo.Cells(e.ColumnIndex).Value
                            End If
                        Case ancho.Index
                            If DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ANCHO") Then
                                DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Item("ANCHO").Valor = nodo.Cells(e.ColumnIndex).Value
                            End If
                        Case Alto.Index
                            If DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ALTO") Then
                                DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Item("ALTO").Valor = nodo.Cells(e.ColumnIndex).Value
                            End If
                        Case Cantidad.Index
                            If DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("CANTIDAD") Then
                                DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Item("CANTIDAD").Valor = nodo.Cells(e.ColumnIndex).Value
                            End If
                        Case colorVidrio.Index
                            If DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("COLOR_VIDRIO") Then
                                DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Item("COLOR_VIDRIO").Valor = nodo.Cells(e.ColumnIndex).Value
                            End If
                        Case espesor.Index
                            If DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("ESPESOR") Then
                                DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Item("ESPESOR").Valor = nodo.Cells(e.ColumnIndex).Value
                            End If
                        Case vidrio.Index
                            If DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Contains("VIDRIO") Then
                                DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ListaVariables.Item("VIDRIO").Valor = nodo.Cells(e.ColumnIndex).Value
                            End If
                    End Select
                    DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ValorarRestricciones()
                    DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ValorarElementosDescuentos()
                    DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico).ValorarElementosMaterial()
                    CalcularPreciosPlantilla(DirectCast(nodo, DataGridViewRow))
                End If
#End Region
                ActualizarValoresNodo(nodo:=nodo, calcular_totales:=True)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub actualizar_todos()
        Try
            dwItems.Nodes.Cast(Of DataGridViewTreeNode).ToList().ForEach(Sub(x)
                                                                             Dim i As Integer = 0
                                                                             x.Nodes.Cast(Of DataGridViewTreeNode).ToList().ForEach(Sub(n)
                                                                                                                                        i += 1
                                                                                                                                        If i = x.Nodes.Count Then
                                                                                                                                            ActualizarValoresNodo(nodo:=n)
                                                                                                                                        Else
                                                                                                                                            ActualizarValoresNodo(nodo:=n, calcular_padres:=False)
                                                                                                                                        End If
                                                                                                                                    End Sub)
                                                                         End Sub)
            actualizarTotalesGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub ActualizarValoresNodo(nodo As DataGridViewTreeNode, Optional calcular_padres As Boolean = True, Optional calcular_totales As Boolean = False)
        Try
            If nodo.Level > 1 Then
#Region "costos adicionales obra"
                Dim costo_adicional As Decimal = dwcostosextra.Rows.Cast(Of DataGridViewRow).Sum(Function(x) Convert.ToDecimal(x.Cells(costoadicional.Index).Value) * Convert.ToDecimal(x.Cells(duracion.Index).Value))
                Dim hijos As Integer = dwItems.Nodes.Cast(Of DataGridViewTreeNode).Sum(Function(n) n.Nodes.Count)
#End Region
                Dim calculo As New ClsCalculos
                calculo.tasaImpuesto = DirectCast(cmbTasaImpuesto.SelectedItem, ReglasNegocio.TasaImpuesto.tasaImpuesto).tasa
                calculo.indAIU = _indAIU
                Dim precInstalacion As Decimal = 0
                If Not _indAIU Then
                    precInstalacion = CDec(cmbInstalacion.Text)
                Else
                    precInstalacion = CDec(cmbInstalacion.Text) + (CDec(cmbInstalacion.Text) * (calculo.tasaImpuesto / 100))
                End If
                Select Case DirectCast(CInt(nodo.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                    Case ClsEnums.FamiliasMateriales.DISEÑOS
                        If nodo.Cells(especial.Index).Value Is Nothing Then
                            Dim c As New CargasPlantilla
                            If Convert.ToInt32(nodo.Cells(id.Index).Value) > 0 Then
                                Dim a As AnalizadorLexico = Nothing
                                c.CargarPlantilla(Convert.ToInt32(nodo.Cells(id.Index).Value), a, ClsEnums.TipoCarga.COTIZA)
                                nodo.Cells(especial.Index).Value = a
                            Else
                                c.CargarPlantillaOriginal(Convert.ToInt32(nodo.Cells(idArticulo.Index).Value), DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico))
                            End If
                            c.ValorarAnalizador(DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico),
                                                curid, versionCostoAcabado, versionCostoNivel, versionCostoKiloAluminio, versionCostoVidrio,
                                                versionCostoAccesorio, versionCostoOtrosArticulos)
                        End If
                        Dim an As AnalizadorLexico = DirectCast(nodo.Cells(especial.Index).Value, AnalizadorLexico)
                        Dim costoVidrio, costoPerfiles, costoAccesorios,
                            costoOtros, vlrDespVidrio, vlrDespPerfiles,
                            vlrDespAccesorio, vlrDespOtros, costounitario,
                        costo_instalacion As Decimal
                        costoVidrio = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        costoPerfiles = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        costoAccesorios = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        costoOtros = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        vlrDespVidrio = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        vlrDespPerfiles = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        vlrDespAccesorio = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        vlrDespOtros = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        costounitario = an.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Unitario))
                        costo_instalacion = an.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Instalacion_Total))
                        calculo.Calcular_Disenio(costounitario, Convert.ToInt32(an.ListaVariables.Item("CANTIDAD").Valor),
                                        Convert.ToDecimal(an.ListaVariables.Item("PIEZAS_X_UND").Valor),
                                        Convert.ToDecimal(an.ListaVariables.Item("ANCHO").Valor),
                                        Convert.ToDecimal(an.ListaVariables.Item("ALTO").Valor),
                                                 nodo.Cells(descuento.Index).Value, nodo.Cells(factor.Index).Value, nodo.Cells(precioMtInstalacion.Index).Value,
                                                 costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costo_instalacion)
                    Case ClsEnums.FamiliasMateriales.VIDRIO
                        calculo.Calcular_Vidrios(nodo.Cells(vidrio.Index).Value,
                                                 nodo.Cells(espesor.Index).Value,
                                                 nodo.Cells(colorVidrio.Index).Value,
                                                 0, nodo.Cells(ancho.Index).Value, nodo.Cells(Alto.Index).Value,
                                                 nodo.Cells(Cantidad.Index).Value, nodo.Cells(piezasxUnidad.Index).Value, 0,
                                                 nodo.Cells(factor.Index).Value, nodo.Cells(descuento.Index).Value,
                                                 nodo.Cells(precioMtInstalacion.Index).Value, nodo.Cells(costoinstalacion.Index).Value,
                                                 nodo.Cells(especial.Index).Value)
                    Case ClsEnums.FamiliasMateriales.PERFILERIA
                        calculo.Calcular_Perfiles(nodo.Cells(idArticulo.Index).Value, nodo.Cells(acabadoPerf.Index).Value,
                                                  0, 0, 0,
                                                  nodo.Cells(ancho.Index).Value, nodo.Cells(Cantidad.Index).Value,
                                                  nodo.Cells(piezasxUnidad.Index).Value, 0, nodo.Cells(factor.Index).Value,
                                                  nodo.Cells(descuento.Index).Value, nodo.Cells(precioMtInstalacion.Index).Value,
                                                  nodo.Cells(costoinstalacion.Index).Value, nodo.Cells(especial.Index).Value)

                    Case ClsEnums.FamiliasMateriales.ACCESORIOS
                        calculo.Calcular_Accesorios(nodo.Cells(idArticulo.Index).Value, nodo.Cells(Cantidad.Index).Value,
                                                    nodo.Cells(piezasxUnidad.Index).Value, 0,
                                                    0, nodo.Cells(factor.Index).Value, nodo.Cells(descuento.Index).Value,
                                                    nodo.Cells(costoinstalacion.Index).Value, nodo.Cells(especial.Index).Value)
                    Case ClsEnums.FamiliasMateriales.OTROS
                        calculo.Calcular_Otros(nodo.Cells(idArticulo.Index).Value, nodo.Cells(Cantidad.Index).Value,
                                                    nodo.Cells(piezasxUnidad.Index).Value, 0,
                                                    0, nodo.Cells(factor.Index).Value, nodo.Cells(descuento.Index).Value,
                                                    nodo.Cells(costoinstalacion.Index).Value, nodo.Cells(especial.Index).Value)
                End Select
                nodo.Cells(costoVidrio.Index).Value = calculo.CostoVidrio
                nodo.Cells(costoPerfiles.Index).Value = calculo.CostoPerfiles
                nodo.Cells(costoAccesorios.Index).Value = calculo.CostoAccesorio
                nodo.Cells(costoOtros.Index).Value = calculo.CostoOtros + (costo_adicional / hijos)
                nodo.Cells(costoTotal.Index).Value = calculo.CostoTotal
                nodo.Cells(costoUnitario.Index).Value = calculo.CostoUnitario
                nodo.Cells(precioUnitario.Index).Value = calculo.PrecioUnitario
                nodo.Cells(precioTotal.Index).Value = calculo.PrecioTotal
                nodo.Cells(precioInstalacion.Index).Value = calculo.PrecioInstalacion
                nodo.Cells(valorDescuento.Index).Value = calculo.ValorDescuento
                nodo.Cells(mtCuadrados.Index).Value = calculo.MetrosCuadrados
                If calcular_padres Then
                    nodo.Parent.Cells(costoVidrio.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(costoVidrio.Index).Value)
                    nodo.Parent.Cells(costoPerfiles.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(costoPerfiles.Index).Value)
                    nodo.Parent.Cells(costoAccesorios.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(costoAccesorios.Index).Value)
                    nodo.Parent.Cells(costoOtros.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(costoOtros.Index).Value)
                    nodo.Parent.Cells(costoUnitario.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(costoUnitario.Index).Value)
                    nodo.Parent.Cells(costoTotal.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(costoTotal.Index).Value)
                    nodo.Parent.Cells(precioUnitario.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(precioUnitario.Index).Value)
                    nodo.Parent.Cells(precioInstalacion.Index).Value = precInstalacion
                    nodo.Parent.Cells(precioTotal.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(precioTotal.Index).Value)
                    nodo.Parent.Cells(precioInstalacion.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(precioInstalacion.Index).Value)
                    nodo.Parent.Cells(valorDescuento.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(valorDescuento.Index).Value)
                    nodo.Parent.Cells(mtCuadrados.Index).Value = nodo.Parent.Nodes.Sum(Function(n) n.Cells(mtCuadrados.Index).Value)
                End If
                If calcular_totales Then
                    actualizarTotalesGrid()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnexpandir_Click(sender As Object, e As EventArgs) Handles btnexpandir.Click
        Try
            dwItems.Nodes.ToList.ForEach(Sub(nodo)
                                             nodo.Expand()
                                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontraer_Click(sender As Object, e As EventArgs) Handles btncontraer.Click
        Try
            dwItems.Nodes.ToList.ForEach(Sub(nodo)
                                             nodo.Collapse()
                                         End Sub)

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnvisibilidadcolumnas_Click(sender As Object, e As EventArgs) Handles btnvisibilidadcolumnas.Click
        Try
            Dim selector As New ControlesPersonalizados.GridFiltrado.FrmVisibilidadColumnas
            selector.Grid2 = dwItems
            selector.Location = MousePosition
            selector.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsbAddAccesorioTemporal_Click(sender As Object, e As EventArgs) Handles tsbAddAccesorioTemporal.Click
        Try
            If curid = 0 Then
                MessageBox.Show("Es necesario que guarde la cotización para agregar accesorios temporales", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim frm As New FrmAddNuevoItem
                frm.IdCotiza = curid
                frm.IdTasaImpuesto = cmbTasaImpuesto.SelectedValue
                frm.Perimetro = 0
                frm.FamiliaMaterial = ClsEnums.FamiliasMateriales.ACCESORIOS
                frm.Text += "accesorio temporal"
                frm.ShowDialog()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsbAddPerfilTemporal_Click(sender As Object, e As EventArgs) Handles tsbAddPerfilTemporal.Click
        Try
            If curid = 0 Then
                MessageBox.Show("Es necesario que guarde la cotización para agregar perfiles temporales", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim frm As New frmAddPerfilTemporal
                frm.IdCotiza = curid
                frm.VersionCostoAcabado = versionCostoAcabado
                frm.VersionCostoNivel = versionCostoNivel
                frm.VersionCostoAluminio = versionCostoKiloAluminio
                frm.IdTasaImpuesto = cmbTasaImpuesto.SelectedValue
                frm.ShowDialog()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsbAddVidrioTemporal_Click(sender As Object, e As EventArgs) Handles tsbAddVidrioTemporal.Click
        Try
            If curid = 0 Then
                MessageBox.Show("Es necesario que guarde la cotización para agregar vidrios temporales", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim frm As New FrmAddVidrioTemporal
                frm.IdCotizacion = curid
                frm.ShowDialog()
                'frm.IdTasaImpuesto = cmbTasaImpuesto.SelectedValue
                'frm.Perimetro = 0
                'frm.FamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO
                'frm.Text += "vidrio temporal"
                'frm.ShowDialog()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsbAddOtroTemporal_Click(sender As Object, e As EventArgs) Handles tsbAddOtroTemporal.Click
        Try
            If curid = 0 Then
                MessageBox.Show("Es necesario que guarde la cotización para agregar otros items temporales", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim frm As New FrmAddNuevoItem
                frm.IdCotiza = curid
                frm.IdTasaImpuesto = cmbTasaImpuesto.SelectedValue
                frm.Perimetro = 0
                frm.FamiliaMaterial = ClsEnums.FamiliasMateriales.OTROS
                frm.Text += "otro temporal"
                frm.ShowDialog()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsbListaTemporales_Click(sender As Object, e As EventArgs) Handles tsbListaTemporales.Click
        Try
            If curid = 0 Then
                MessageBox.Show("Es necesario que guarde la cotización para ver su lista de items temporales", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim frm As New FrmVerTemporales
            frm.IdCotiza = curid
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Impresión"
    Private Function Generar_Documento_Impresion(Optional imprimir_dibujos As Boolean = True) As DataSet
        Try
            Dim ds As New DataSet
            If curid > 0 Then
                Dim dibujoscotiza As New ClsDibujosItemsCotiza
                Dim mCot As New datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter
                Dim mCotPadres As New datosInformesTableAdapters.sp_tc017_selectByIdCotizaXMLTableAdapter
                Dim mCondiciones As New datosInformesTableAdapters.sp_tc072_selectbyIdContizaXMLTableAdapter
                Dim tbpadres As DataTable = mCotPadres.GetData(curid)
                Dim tbCondiciones As DataTable = mCondiciones.GetData(curid)
                Dim tbcotiza As DataTable = mCot.GetData(curid)
                ds.Tables.Add(tbcotiza)
                ds.Tables.Add(tbpadres)
                ds.Tables.Add(tbCondiciones)
                ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "Cotizacion_Reload.xml"))
            End If
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub Imprimir_Click(sender As Object, e As EventArgs)
        Try
            GuardadoTotal_Click(sender, e)
            Dim fconfimpresora As New FrmConfiguracionImpresionCotiza()
            If fconfimpresora.ShowDialog() = DialogResult.OK Then
                bwcargas.RunWorkerAsync("Imprimiendo")
                Dim ds As DataSet = Generar_Documento_Impresion(fconfimpresora.ImprimirImagenes)
                Dim b As New Informes.CotizacionClienteV
                b.SetDataSource(ds)
                b.PrintOptions.PrinterName = fconfimpresora.ConfiguracionImpresora.PrinterName
                b.PrintToPrinter(fconfimpresora.NumeroCopias, False,
                                 If(fconfimpresora.imprimirTodo, 0, fconfimpresora.desde), If(fconfimpresora.imprimirTodo, 0, fconfimpresora.hasta))
            End If
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub VistaPrevia_Click(sender As Object, e As EventArgs)
        Try
            Generar_Documento_Impresion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwCondiciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwCondiciones.CellEndEdit
        Try
            If String.IsNullOrEmpty(dwCondiciones.Rows(e.RowIndex).Cells(Condicion.Index).Value) Or
           String.IsNullOrEmpty(dwCondiciones.Rows(e.RowIndex).Cells(Condicion.Index).Value) Then
                haveEmpty = True
            Else
                haveEmpty = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CamposAdicionales(ByRef tbencabe As DataTable)
        Try
            Dim art As New ClsArticulos
            Dim puntostotales As Integer = 0
            Dim pesoperfileria As Decimal = 0
            Dim totalcostoperfileria As Decimal = 0
            dwItems.Nodes.ToList.ForEach(Sub(n)
                                             n.Nodes.ToList.ForEach(Sub(nh)
                                                                        Select Case DirectCast(Convert.ToInt32(nh.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                            Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                                                If nh.Cells(especial.Index).Value Is Nothing Then
                                                                                    cargarAnalizador(nh)
                                                                                End If
                                                                                Dim an As AnalizadorLexico = DirectCast(nh.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                If an.ListaVariables.Contains("PUNTOS") Then
                                                                                    puntostotales += Convert.ToDecimal(an.ListaVariables.Item("PUNTOS").Valor)
                                                                                End If
                                                                                pesoperfileria += (an.ListaMateriales.Where(Function(m) m.TipoObjeto = TiposElementos.Perfiles).Sum(Function(x) Convert.ToDecimal(x.Parametros("PESO").Valor)) *
                                                                                    Convert.ToDecimal(nh.Cells(Cantidad.Index).Value) * Convert.ToDecimal(nh.Cells(ancho.Index).Value))
                                                                                totalcostoperfileria += Convert.ToDecimal(nh.Cells(costoPerfiles.Index).Value)
                                                                            Case ClsEnums.FamiliasMateriales.PERFILERIA
                                                                                pesoperfileria += (Convert.ToDecimal(nh.Cells(Cantidad.Index).Value) * Convert.ToDecimal(nh.Cells(ancho.Index).Value) * art.TraerxId(nh.Cells(idArticulo.Index).Value).Peso)
                                                                                totalcostoperfileria += Convert.ToDecimal(nh.Cells(costoTotal.Index).Value)
                                                                        End Select
                                                                    End Sub)
                                         End Sub)
            tbencabe.Columns.Add("puntos", Type.GetType("System.Int32"))
            tbencabe.Columns.Add("total_kilo_aluminio", Type.GetType("System.Decimal"))
            tbencabe.Columns.Add("valor_kilo_promedio", Type.GetType("System.Decimal"))
            tbencabe.Rows(0).Item("puntos") = puntostotales
            tbencabe.Rows(0).Item("total_kilo_aluminio") = pesoperfileria
            tbencabe.Rows(0).Item("valor_kilo_promedio") = totalcostoperfileria / pesoperfileria
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub AcomodarVariables(ByRef tablahijos As DataTable)
        Try
            Dim varlist As New ClsVariables
            Dim variables = varlist.TraerTodos()
            tablahijos.Columns.Add("variables", Type.GetType("System.String"))
            tablahijos.Rows.Cast(Of DataRow).ToList.ForEach(Sub(rw)
                                                                If Convert.ToInt32(rw.Item("Id_Plantilla")) > 0 Then
                                                                    Dim nd As DataGridViewTreeNode = dwItems.Nodes.FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(id.Index).Value) = Convert.ToInt32(rw.Item("Id_Padre"))).Nodes.FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(id.Index).Value) = Convert.ToInt32(rw.Item("Id")))
                                                                    If nd IsNot Nothing Then
                                                                        If nd.Cells(especial.Index).Value Is Nothing Then
                                                                            cargarAnalizador(nd)
                                                                        End If
                                                                        Dim an As AnalizadorLexico = DirectCast(nd.Cells(especial.Index).Value, AnalizadorLexico)
                                                                        rw.Item("variables") = String.Join(vbCr, an.ListaVariables.Where(Function(c) variables.FirstOrDefault(Function(x) x.Nombre.Equals(c.Nombre)).Imprimir).Select(Function(x) x.Nombre & ": " & x.Valor).ToArray())
                                                                    End If
                                                                Else
                                                                    rw.Item("variables") = String.Empty
                                                                End If
                                                            End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
#Region "Procedimiento Controles"
    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            aplicarPermisos()
            ErrorProvider.Clear()
            ErrorProvider1.Clear()
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnimprimirr As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimprimir
            Dim btnimpresion As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnvistaprevia As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnvistaprevia
            btnsParcial.Enabled = False
            If tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                btnguardar.Enabled = False
                btnsTotal.Enabled = False
                btnsLimpiar.Enabled = False
                btnimprimirr.Enabled = False
                btnimpresion.Enabled = False
                btnvistaprevia.Enabled = False
            Else
                btnguardar.Enabled = True
                btnsTotal.Enabled = True
                btnsLimpiar.Enabled = True
                btnimprimirr.Enabled = True
                btnimpresion.Enabled = True
                btnvistaprevia.Enabled = True
                AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
                AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
                AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
                AddHandler btnimprimirr.Click, AddressOf Imprimir_Click
                AddHandler btnimpresion.Click, AddressOf Imprimir_Click
                AddHandler btnvistaprevia.Click, AddressOf VistaPrevia_Click
                btnimpresion.DropDownItems.Add(btn_imprimir_interno)
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnimprimirr As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimprimir
            Dim btnimpresion As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnvistaprevia As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnvistaprevia
            btnsParcial.Enabled = False
            If tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                btnguardar.Enabled = True
                btnsTotal.Enabled = True
                btnsLimpiar.Enabled = True
                btnimprimirr.Enabled = True
                btnimpresion.Enabled = True
                btnvistaprevia.Enabled = True
            Else
                RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
                RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
                RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
                RemoveHandler btnimprimirr.Click, AddressOf Imprimir_Click
                RemoveHandler btnimpresion.Click, AddressOf Imprimir_Click
                RemoveHandler btnvistaprevia.Click, AddressOf VistaPrevia_Click
                btnimpresion.DropDownItems.Remove(btn_imprimir_interno)
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargar_costos_adicionales_general()
        Try
            Dim cost_ext As New ClsCostosExtraObra
            Dim l_cost = cost_ext.TraerporIdEstado(ClsEnums.Estados.ACTIVO)
            l_cost.ForEach(Sub(c)
                               Dim r As DataGridViewRow = dwcostosextra.Rows(dwcostosextra.Rows.Add())
                               r.Cells(idadicionalcotiza.Index).Value = 0
                               r.Cells(idadicional.Index).Value = c.Id
                               r.Cells(adicional.Index).Value = c.Nombre
                               r.Cells(costoadicional.Index).Value = c.Valor
                               r.Cells(duracion.Index).Value = 0
                           End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargar_costos_adicionales_cotiza()
        Try
            Dim cost_ext As New ClsExtraCostosCotiza
            Dim l_cost = cost_ext.TraerporIdCotiza(curid)
            l_cost.ForEach(Sub(c)
                               Dim r As DataGridViewRow = dwcostosextra.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(idadicional.Index).Value) = c.IdOtro)
                               r.Cells(idadicionalcotiza.Index).Value = c.Id
                               r.Cells(idadicional.Index).Value = c.IdOtro
                               r.Cells(adicional.Index).Value = c.Nombre
                               r.Cells(costoadicional.Index).Value = c.Valor
                               r.Cells(duracion.Index).Value = c.Duracion
                           End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub FrmCotizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dwItems.ScrollBars = ScrollBars.Both
            CheckForIllegalCrossThreadCalls = False
            If tform = ClsEnums.TiOperacion.MODIFICAR Or tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                bwcargas.RunWorkerAsync()
                CargarRegistroDuplicacion()
            End If
            If tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                Solo_lectura()
            End If
            dwTotales.Rows.Add()
            mCotizacion = New ClsCostizaciones
#Region "Elementos Backup"
            mvarhijocotiza = New ClsVariablesPlantillaCotiza
            mmaterialhijocotiza = New ClsMaterialesPlantillaCotiza
            mdibujohijocotiza = New ClsDibujosPlantillaCotiza
            mobservacioneshijocotiza = New ClsObservacionesPlantillaCotiza
            mdescuentosgeneraleshijocotiza = New ClsDescuentosGeneralesPlantillaCotiza
            mdescuentosmaterialplantillacotiza = New ClsDescuentosMaterialPlantillaCotiza
#End Region
            txtNombreCotizacion.Focus()
            bgwHilo2.RunWorkerAsync()
            movimientoModificable = False
            Dim frmCiudad As New FrmSeleccionCiudades
            frmCiudad.ciudadDefecto()
            Ciudad = frmCiudad.idCiudad
            txtCiudad.Text = frmCiudad.nombreCiudad
            If mCotizacion.TieneTemporales(curid) = True Then
                _tieneTemporales = True
            End If
            mCotizacion = New ClsCostizaciones
            Dim maxIdCotiza As Integer = mCotizacion.TraerMaxIdCotiza()
            cargar_costos_adicionales_general()
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                DirectCast(Me.Parent.FindForm(), frmInicial).GlobalCotizaForms += 1
                Me.Text = "Cot.(" & maxIdCotiza + DirectCast(Me.Parent.FindForm(), frmInicial).GlobalCotizaForms & ")"
#Region "Asignar Desperdicios Predeterminados"


#End Region
            ElseIf (tform = ClsEnums.TiOperacion.MODIFICAR) Or tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                cargar_costos_adicionales_cotiza()
                Me.Text = "Cot. (" & curid & ")"
            End If
            cargarListasTemporales()
            cargarDesplegablesMovimiento()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bgwHilo2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwHilo2.DoWork
        Try
            cargarAcabados()
            cargarFormaPago()
            cargarTasaImpuesto()
            cargarTiempoEntrega()
            cargarTipoDocumento()
            cargarTipoEdificacion()
            cargarCategExposicion()
            cargarGruposUso()
            cargarTiposCubierta()
            cargarPresionesModelo()
            cargarEstado()
            cargarVendedor()
            cargarTiposObra()
            cargarVigencias()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bgwHilo2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwHilo2.RunWorkerCompleted
        Try
            'ACABADOS
            cmbAcabado.DisplayMember = "Prefijo"
            cmbAcabado.ValueMember = "Id"
            cmbAcabado.DatosVisibles = {"Prefijo", "Nombre"}
            cmbAcabado.DataSource = listAcabadoGlobal.Where(Function(a) a.Id = 32 Or a.idFamiliaMaterial = 3 And a.IdEstado = ClsEnums.Estados.ACTIVO).ToList

            'FORMAS DE PAGO
            cmbFormaPago.DisplayMember = "descripcion"
            cmbFormaPago.ValueMember = "Id"
            cmbFormaPago.DataSource = listFormasPago

            'TASAS DE IMPUESTO
            cmbTasaImpuesto.DisplayMember = "sigla"
            cmbTasaImpuesto.ValueMember = "Id"
            cmbTasaImpuesto.DataSource = listTImpuesto
            tImpuesto = cmbTasaImpuesto.SelectedItem

            'ESTADOS
            cmbEstado.DisplayMember = "descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = listEstados

            Dim dic As New Dictionary(Of Integer, String)()
            Dim datos As List(Of tiempoEntrega) = mTiempoEntrega.TraerxEstado(ClsEnums.Estados.ACTIVO)
            datos.ForEach(Sub(item)
                              dic.Add(Convert.ToInt32(item.Id), item.dias & " " & item.descripcion)
                          End Sub)
            cmbTiempoEntrega.DisplayMember = "value"
            cmbTiempoEntrega.ValueMember = "key"
            cmbTiempoEntrega.DataSource = dic.ToArray

            'TIPOS DE DOCUMENTO
            cmbTipoDocumento.DisplayMember = "prefijo"
            cmbTipoDocumento.ValueMember = "Id"
            cmbTipoDocumento.DatosVisibles = {"prefijo", "Descripcion"}
            cmbTipoDocumento.DataSource = listTipoDoc

            'ESTADOS
            cmbEstado.DisplayMember = "descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = listEstados

            'TIPOS DE EDIFICACIÓN
            cmbTipoEdificacion.DisplayMember = "descripcion"
            cmbTipoEdificacion.ValueMember = "Id"
            cmbTipoEdificacion.DataSource = listEdificacion

            'CATEGORÍAS DE EXPOSICIÓN
            cmbCategExposicion.DisplayMember = "descripcion"
            cmbCategExposicion.ValueMember = "Id"
            cmbCategExposicion.DataSource = listCategExp

            'GRUPOS DE USO
            cmbGruposUso.DisplayMember = "Descripcion"
            cmbGruposUso.ValueMember = "Id"
            cmbGruposUso.DataSource = listGruposUso

            'TIPOS DE CUBIERTA
            cmbTipoCubierta.DisplayMember = "descripcion"
            cmbTipoCubierta.ValueMember = "Id"
            cmbTipoCubierta.DataSource = listTipoCubierta

            'PRESIÓN MODELO
            cmbpresionModelo.DisplayMember = "descripcion"
            cmbpresionModelo.ValueMember = "Id"
            cmbpresionModelo.DataSource = listPresionesModelo

            'VENDEDORES
            cmbVendedor.DisplayMember = "idSiesa"
            cmbVendedor.ValueMember = "id"
            cmbVendedor.DatosVisibles = {"idSiesa", "Nombre"}
            cmbVendedor.DataSource = listVendedores

            'TIPOS DE OBRA/TIPO COTIZACIÓN
            cmbTipoObra.DisplayMember = "descripcion"
            cmbTipoObra.ValueMember = "Id"
            puedeCambiar = True
            cmbTipoObra.DataSource = listTipoObra

            'VIGENCIA DE CONTRATO
            cmbVigencia.DisplayMember = "descripcion"
            cmbVigencia.ValueMember = "Id"
            cmbVigencia.DataSource = listVigencia
            Versiones(True)
            If tform = ClsEnums.TiOperacion.MODIFICAR Or tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                Modificar()
            End If
            isLoad = True
            cmbVigencia_SelectedValueChanged(Nothing, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmCotizaciones_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If e.CloseReason = CloseReason.UserClosing Then
                If MsgBox("Si cierra el formulario no se guardarán los cambios. ¿ realmente desea salir ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmCotizaciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            ClsInterbloqueos.Desbloquear(curid, ClsEnums.ModulosAplicacion.MODULO_COTIZACIONES)
            mCotizacion = New ClsCostizaciones
            renumerarNoGuardadas()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncondicion_Click(sender As Object, e As EventArgs) Handles btncondicion.Click
        Try
            Dim frmAddCondiciones As New FrmAddCondicion
            With frmAddCondiciones
                .idCotizacion = curid
                .dwCondiciones = dwCondiciones
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub imprimirInterno_Click() Handles btn_imprimir_interno.Click
        Try
            'Dim fconfimpresora As New FrmConfiguracionImpresionCotiza()
            'If fconfimpresora.ShowDialog() = DialogResult.OK Then
            '    Dim ds As DataSet = Generar_Documento_Impresion(False)
            '    CamposAdicionales(ds.Tables(0))
            '    Dim mCothijos As New datosInformesTableAdapters.sp_tc018_selectByIdCotizaXMLTableAdapter
            '    Dim tablahijos As DataTable = mCothijos.GetData(curid)
            '    ' AcomodarVariables(tablahijos)
            '    ds.Tables.Add(tablahijos)
            '    ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "Cotizacion_Interna_Reload.xml"))

            '    Dim b As New Informes.CotizacionInternaH
            '    b.SetDataSource(ds)
            '    'b.SetParameterValue("imprimirInstalacion", CBool(fconfimpresora.ImprimirInstalacion))
            '    'b.SetParameterValue("tipoInstalacion", CBool(fconfimpresora.ImprimirMetrosInstalacion))
            '    b.PrintToPrinter(fconfimpresora.NumeroCopias, False, If(fconfimpresora.imprimirTodo, 0, fconfimpresora.desde), If(fconfimpresora.imprimirTodo, 0, fconfimpresora.hasta))
            '    '  ds.WriteXml(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "Cotizacion_Interna_Reload_datos.xml"))
            'End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbAcabado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbAcabado.SelectionChangeCommitted
        Try
            If Convert.ToInt32(cmbAcabado.SelectedValue) <> originalacabadoseleccionado Then
                If curid > 0 Then
                    Dim r = MsgBox("Este cambio generar re-calcular y re-costear los materiales. ¿ Desea generar un duplicado de la cotización con el nuevo acabado?", MsgBoxStyle.YesNoCancel)
                    Select Case r
                        Case MsgBoxResult.Yes
                            originalacabadoseleccionado = cmbAcabado.SelectedValue
                            mCotizacion = New ClsCostizaciones
                            Dim idCotizaNueva As Integer = mCotizacion.Duplicar(curid, My.Settings.UsuarioActivo, "Copia", originalacabadoseleccionado)
                            Dim cotiza As New FrmCotizaciones()
                            cotiza.IdActual = idCotizaNueva
                            cotiza.OperacionActual = ClsEnums.TiOperacion.MODIFICAR
                            cotiza.MdiParent = Me.MdiParent
                            cotiza.WindowState = FormWindowState.Maximized
                            cotiza.Text &= " (" & idCotizaNueva.ToString & ")"
                            cotiza.Duplicado = True
                            cotiza.Show()
                            Me.Close()
                        Case MsgBoxResult.No
                            originalacabadoseleccionado = cmbAcabado.SelectedValue
                            RecalcularPerfileriayDiseñoslosValores(originalacabadoseleccionado, cmbAcabado.Text)
                        Case MsgBoxResult.Cancel
                            cmbAcabado.SelectedValue = originalacabadoseleccionado
                    End Select
                Else
                    If MsgBox("Este cambio generar re-calcular y re-costear los materiales. ¿ Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        RecalcularPerfileriayDiseñoslosValores(originalacabadoseleccionado, cmbAcabado.Text)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbAcabado_Enter(sender As Object, e As EventArgs) Handles cmbAcabado.Enter
        Try
            originalacabadoseleccionado = cmbAcabado.SelectedValue
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbTipoObra_MouseDown(sender As Object, e As MouseEventArgs) Handles cmbTipoObra.MouseDown
        Try
            puedeCambiar = False
            seleccionAnterior = cmbTipoObra.SelectedValue
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub RecalcularPerfileriayDiseñoslosValores(idacabado As Integer, acabado As String)
        Try
            dwItems.Nodes.ToList.ForEach(Sub(n)
                                             n.Cells(indGuardado.Index).Value = False
                                             n.Nodes.ToList.ForEach(Sub(nh)

                                                                        Select Case DirectCast(Convert.ToInt32(nh.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                            Case ClsEnums.FamiliasMateriales.PERFILERIA
                                                                                nh.Cells(acabadoPerf.Index).Value = idacabado
                                                                            Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                                                If nh.Cells(especial.Index).Value Is Nothing Then
                                                                                    cargarAnalizador(nh)
                                                                                End If
                                                                                Dim an As AnalizadorLexico = DirectCast(nh.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                If an.ListaVariables.Contains("ACABADO") Then
                                                                                    an.ListaVariables.Item("ACABADO").Valor = acabado
                                                                                    cargarAnalizador(nh)
                                                                                End If
                                                                                nh.Cells(costoVidrio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                nh.Cells(costoPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                nh.Cells(costoAccesorios.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                nh.Cells(costoOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                        End Select
                                                                        ActualizarValoresNodo(nh)
                                                                    End Sub)
                                         End Sub)
            actualizarTotalesGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub RecalcularTodo(colindex As Integer, valor As Object, padres As Boolean)
        Try
            For Each n In dwItems.Nodes
                If padres Then
                    n.Cells(colindex).Value = valor
                    n.Cells(indGuardado.Index).Value = False
                End If
                For Each nh In n.Nodes
                    If colindex >= 0 Then
                        nh.Cells(colindex).Value = valor
                    End If
                    ActualizarValoresNodo(nh)
                Next
            Next
            'dwItems.Nodes.ToList.ForEach(Sub(n)
            '                                 If padres Then
            '                                     n.Cells(colindex).Value = valor
            '                                     n.Cells(indGuardado.Index).Value = False
            '                                 End If
            'n.Nodes.ToList.ForEach(Sub(nh)
            '                           If colindex >= 0 Then
            '                               nh.Cells(colindex).Value = valor
            '                           End If
            '                           ActualizarValoresNodo(nh, False)
            '                       End Sub)
            '                             End Sub)
            actualizarTotalesGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cmbFactor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbFactor.SelectionChangeCommitted
        Try
            RecalcularTodo(factor.Index, Convert.ToDecimal(cmbFactor.GetItemText(cmbFactor.SelectedItem)), True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudDescuentoSum_ValueChanged(sender As Object, e As EventArgs) Handles nudDescuentoSum.ValueChanged
        Try
            If dwItems.Rows.Count > 0 Then
                RecalcularTodo(descuento.Index, nudDescuentoSum.Value, True)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudDescuentoInst_ValueChanged(sender As Object, e As EventArgs) Handles nudDescuentoInst.ValueChanged
        Try
            If dwItems.Rows.Count > 0 Then
                RecalcularTodo(descuentoinstala.Index, nudDescuentoInst.Value, True)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtNombreCotizacion_TextChanged(sender As Object, e As EventArgs) Handles txtNombreCotizacion.TextChanged
        Try
            If txtNombreCotizacion.Text <> String.Empty Then
                mCotizacion = New ClsCostizaciones
                mCiudad = New ClsCiudades
                Dim cot As cotizacion = mCotizacion.TraerxNombreCotiza(txtNombreCotizacion.Text)
                If cot.Id > 0 Then
                    cmbTipoObra.SelectedValue = cot.idTipoCotiza
                    cmbVendedor.SelectedValue = cot.idVendedor
                    cmbAcabado.SelectedValue = cot.idAcabado
                    Ciudad = cot.idCiudad
                    Dim ciu As Ciudad = mCiudad.TraerxId(Ciudad)
                    txtCiudad.Text = ciu.nombreCiudad
                    cmbFactor.SelectedValue = cot.idFactor
                    cmbFormaPago.SelectedValue = cot.idFormaPago
                    cmbEstado.SelectedValue = cot.IdEstado
                    cmbTiempoEntrega.SelectedValue = cot.idTiempoEntrega
                    cmbInstalacion.SelectedValue = cot.idManoObraInstalacion
                    cbInstalacion.Checked = Not Convert.ToBoolean(cot.conInstalacion - 1)
                    cmbTasaImpuesto.SelectedValue = cot.idTasaImpuesto
                    cmbTipoDocumento.SelectedValue = cot.idIdentificacion
                    txtDocumento.Text = cot.numIdentificacion
                    txtDigitoVerificacion.Text = cot.digitoVerificacion
                    txtCliente.Text = cot.cliente
                    txtTelefonoCliente.Text = cot.telCliente
                    txtDireccionCliente.Text = cot.dirCliente
                    txtCorreoCliente.Text = cot.mailCliente
                    txtContactoCliente.Text = cot.nomContacCliente
                    txtNombreObra.Text = cot.nomObra
                    txtContactoObra.Text = cot.nomContacObra
                    txtTelefonoObra.Text = cot.telObra
                    txtCorreoObra.Text = cot.mailObra
                    cmbTipoEdificacion.SelectedValue = cot.idTipoEdificacion
                    cmbCategExposicion.SelectedValue = cot.idCateExposicion
                    cmbComponente.SelectedValue = cot.idComponente
                    cmbGruposUso.SelectedValue = cot.idGrupoUso
                    cmbTipoCubierta.SelectedValue = cot.idTipoCubierta
                    nudAltoEdificio.Value = cot.altoEdificio
                    nudAnchoEdificio.Value = cot.anchoEdificio
                    nudAlturaCaballete.Value = cot.alturaCaballete
                    nudAlturaAlero.Value = cot.alturaAlero
                    nudAltoEntreLosas.Value = cot.alturaEntreLosas
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbInstalacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbInstalacion.SelectionChangeCommitted
        Try
            If dwItems.Rows.Count > 0 Then
                RecalcularTodo(precioMtInstalacion.Index, cmbInstalacion.GetItemText(cmbInstalacion.SelectedValue), True)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbTasaImpuesto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTasaImpuesto.SelectionChangeCommitted
        Try
            If dwItems.Rows.Count > 0 Then
                RecalcularTodo(-1, Nothing, False)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbTipoObra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoObra.SelectedValueChanged
        Try
            If puedeCambiar Then
                VerificacionTipoImpuestoObra(Convert.ToInt32(cmbTipoObra.SelectedValue))
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbTipoObra_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipoObra.SelectionChangeCommitted
        Try
            VerificacionTipoImpuestoObra(cmbTipoObra.SelectedValue)
            RecalcularTodo(-1, Nothing, False)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbTasaImpuesto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTasaImpuesto.SelectedValueChanged
        Try
            tImpuesto = cmbTasaImpuesto.SelectedItem
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub lblVersion_MouseHover(sender As Object, e As EventArgs) Handles lblVersion.MouseHover
        Try
            ttVersiones.Show("Versión de los costos de aluminio y vidrio respectivamente", lblVersion)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnSelectCiudad_Click(sender As Object, e As EventArgs) Handles btnSelectCiudad.Click
        Try
            Dim frmSelectCiudad As New FrmSeleccionCiudades
            If frmSelectCiudad.ShowDialog = DialogResult.OK Then
                Ciudad = frmSelectCiudad.idCiudad
                txtCiudad.Text = frmSelectCiudad.nombreCiudad
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbInstalacion_CheckedChanged(sender As Object, e As EventArgs) Handles cbInstalacion.CheckedChanged
        Try
            If cbInstalacion.Checked Then
                cbInstalacion.Tag = 1
                cbInstalacion.Text = "Con instalación"
                For Each n As DataGridViewTreeNode In dwItems.Nodes
                    n.Cells(precioMtInstalacion.Index).Value = Math.Round(Convert.ToDecimal(cmbInstalacion.Text), 0)
                    n.Cells(precioInstalacion.Index).Value = CDec(n.Cells(precioMtInstalacion.Index).Value) * CDec(n.Cells(Mtinstalacion.Index).Value)
                    n.Cells(indGuardado.Index).Value = False
                    For Each nd As DataGridViewTreeNode In n.Nodes
                        n.Cells(precioMtInstalacion.Index).Value = Math.Round(Convert.ToDecimal(cmbInstalacion.Text), 0)
                        nd.Cells(precioInstalacion.Index).Value = CDec(nd.Cells(precioMtInstalacion.Index).Value) * CDec(n.Cells(Mtinstalacion.Index).Value)
                    Next
                Next
                recalcularValoreInstalacion()
            Else
                cbInstalacion.Tag = 2
                cbInstalacion.Text = "Sin instalación"
                For Each n As DataGridViewTreeNode In dwItems.Nodes
                    n.Cells(precioMtInstalacion.Index).Value = 0
                    n.Cells(precioInstalacion.Index).Value = 0
                    n.Cells(indGuardado.Index).Value = False
                    For Each nd As DataGridViewTreeNode In n.Nodes
                        nd.Cells(precioMtInstalacion.Index).Value = 0
                        nd.Cells(precioInstalacion.Index).Value = 0
                    Next
                Next
                recalcularValoreInstalacion()
            End If
            If curid <> 0 And dwItems.Nodes.Count > 0 Then
                modificarCotiza()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbCobroMetros_CheckedChanged(sender As Object, e As EventArgs) Handles cbCobroMetros.CheckedChanged
        Try
            If isLoad Then
                If cbCobroMetros.Checked Then
                    cbCobroMetros.Text = "Cobrar instalación metros reales"
                Else
                    cbCobroMetros.Text = "Cobrar instalación metros ajustados"
                End If
            End If
            If dwItems.Rows.Count > 0 Then
                RecalcularTodo(-1, Nothing, False)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbVigencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVigencia.SelectedValueChanged
        Try
            If isLoad = True Then
                Dim vigencia As Vigencia = cmbVigencia.SelectedItem
                Dim fecha As DateTime = dtpFecha.Value
                fecha = DateAdd(DateInterval.Day, Convert.ToDouble(vigencia.dias), fecha)
                lblVigencia.Text = fecha.ToShortDateString
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudAltoEdificio.GotFocus,
            nudAnchoEdificio.GotFocus, nudAlturaAlero.GotFocus, nudAlturaCaballete.GotFocus,
            nudPorcAdministracion.GotFocus, nudPorcImprovistos.GotFocus, nudPorcUtilidad.GotFocus,
            nudAltoEntreLosas.GotFocus, nudDescuentoSum.GotFocus
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Value = 0 Then
                nud.ResetText()
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudAltoEdificio.Leave,
            nudAnchoEdificio.Leave, nudAlturaAlero.Leave, nudAlturaCaballete.Leave,
            nudPorcAdministracion.Leave, nudPorcImprovistos.Leave, nudPorcUtilidad.Leave,
            nudAltoEntreLosas.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0.00"
                nud.Value = 0.00
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudDescuento_Leave(sender As Object, e As EventArgs) Handles nudDescuentoSum.Leave, nudDescuentoInst.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0"
                nud.Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudPorc_AIU_ValueChanged(sender As Object, e As EventArgs) Handles nudPorcAdministracion.ValueChanged,
           nudPorcImprovistos.ValueChanged, nudPorcUtilidad.ValueChanged
        Try
            If Not isLoad Then
                ActualizarTotales_AIU()
            Else
                actualizarTotalesGrid()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bwCostos_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwCostos.DoWork
        Try
            crearCostos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validar_Copiar_Elementos() As Boolean
        Try
            Return dwItems.SelectedRows().Cast(Of DataGridViewTreeNode).Count(Function(n) n.Level = 1) > 0
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Function Validar_Pegar_Elementos() As Boolean
        Try
            Return Clipboard.ContainsData("elementos_cotiza")
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub Copiar_Elementos()
        Try
            Dim ns As DataGridViewTreeNode() = dwItems.SelectedRows().Cast(Of DataGridViewTreeNode).Where(Function(n) n.Level = 1).ToArray()
            Dim sb As New System.Text.StringBuilder
            For Each n As DataGridViewTreeNode In ns
                sb.Append("{")
                sb.Append(n.Cells(id.Index).Value)
                sb.Append("}")
            Next
            Clipboard.SetData("elementos_cotiza", sb.ToString())
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Pegar_Elementos()
        Try
            Dim dibujoscotiza As New ClsDibujosItemsCotiza
            Dim str As String = Clipboard.GetData("elementos_cotiza")
            For i As Integer = 0 To str.Length - 1
                If str(i) = "{" Then
                    Dim id_c As Integer = str.Substring(i + 1, str.IndexOf("}", i) - 1)
                    i = str.IndexOf("}", i)
                    Dim dic_id_index As New List(Of Integer)
                    Dim item As movitoPadre = mMovitoPadre.TraerxId(id_c)
#Region "Cargar Padre"
                    Dim ndp As DataGridViewTreeNode = dwItems.Nodes.Add()
                    ndp.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                    ndp.Cells(Ubicacion.Index).Value = RTrim(item.Ubicacion)
                    ndp.Cells(idArticulo.Index).Value = 0
                    ndp.Cells(Descripcion.Index).Value = RTrim(item.Descripcion)
                    ndp.Cells(ancho.Index).Value = Math.Round(item.Ancho, 0)
                    ndp.Cells(Alto.Index).Value = Math.Round(item.Alto, 0)
                    ndp.Cells(mtCuadrados.Index).Value = item.mtCuadrados 'If(((Math.Round(item.ancho) * Math.Round(item.alto, 0)) / 1000000) < 1, item.cantidad, ((Math.Round(item.ancho) * Math.Round(item.alto, 0)) / 1000000) * item.cantidad)
                    ndp.Cells(Cantidad.Index).Value = item.Cantidad
                    ndp.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = item.IdAcabadoPerfil).Id
                    ndp.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = item.IdVidrio).Id
                    ndp.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = item.IdColorVidrio).Id
                    ndp.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = item.idEspesor).Id
                    ndp.Cells(factor.Index).Value = item.factor
                    ndp.Cells(piezasxUnidad.Index).Value = 1
                    ndp.Cells(descuento.Index).Value = item.Descuento
                    ndp.Cells(precioMtInstalacion.Index).Value = item.tarifaMtInstalacion
                    ndp.Cells(precioInstalacion.Index).Value = item.precioInstalacion '(((CDec(ndp.Cells(mtCuadrados.Index).Value)) * item.cantidad) * Convert.ToDecimal(cmbInstalacion.Text))
                    ndp.Cells(unidadMedida.Index).Value = "-"
                    ndp.Cells(tipoItem.Index).Value = "-"
                    ndp.Cells(idpropiedad.Index).Value = item.idPropiedadMasica
                    ndp.Cells(calcularnorma.Index).Value = item.calculo_NSR
                    ndp.Cells(cumplenorma.Index).Value = item.cumpleNorma
                    ndp.Cells(unmedinstala.Index).Value = item.UnidadMedidaInstalacion
                    ndp.Cells(descuentoinstala.Index).Value = item.Descuento_Instalacion
                    ndp.Cells(tasaImpuesto.Index).Value = item.tasaImpuesto
                    Dim valparcial As Decimal = (item.Ancho * item.Alto) / 1000000
                    ndp.Cells(mtCuadrados.Index).Value = valparcial * item.Cantidad
                    ndp.Cells(Mtinstalacion.Index).Value = If(valparcial < 1, 1, valparcial) * item.Cantidad
                    ndp.Cells(actualizar_plantilla.Index).Value = True
#Region "Carga Hijos"
                    mMovitoHijo = New ClsMovitoHijos
                    Dim listHijos As List(Of movitoHijo) = mMovitoHijo.TraerxIdPadre(item.Id)
                    listHijos.ForEach(Sub(ith)
                                          dic_id_index.Add(ith.Id)
                                          Dim ndh As DataGridViewTreeNode = ndp.Nodes.Add
                                          ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                                          ndh.Cells(idArticuloTemp.Index).Value = ith.IdArticuloTemporal
                                          ndh.Cells(Ubicacion.Index).Value = RTrim(ith.referencia)
                                          ndh.Cells(Descripcion.Index).Value = RTrim(ith.descripcion)
                                          ndh.Cells(ancho.Index).Value = Math.Round(ith.ancho)
                                          ndh.Cells(Alto.Index).Value = Math.Round(ith.alto)
                                          Dim vparcial As Decimal = (ith.ancho * ith.alto) / 1000000
                                          Select Case DirectCast(ith.tipoItem, ClsEnums.FamiliasMateriales)
                                              Case ClsEnums.FamiliasMateriales.DISEÑOS, ClsEnums.FamiliasMateriales.VIDRIO
                                                  ndh.Cells(mtCuadrados.Index).Value = vparcial * ith.cantidad * ith.piezasxUnidad
                                                  ndh.Cells(Mtinstalacion.Index).Value = If(vparcial < 1, 1, vparcial) * ith.cantidad * ith.piezasxUnidad
                                              Case Else
                                                  ndh.Cells(mtCuadrados.Index).Value = 0
                                          End Select
                                          ndh.Cells(Cantidad.Index).Value = ith.cantidad
                                          If ith.tipoItem = ClsEnums.FamiliasMateriales.TEMPORAL Then
                                              'PENDIENTE: PROBAR QUE SUCEDERÁ SI TENEMOS DOS ARTÍCULOS CON LA MISMA REFERENCIA EN DISTINTAS FAMILIAS DE MATERIAL
                                              Dim art As articuloTemporal = listArticulos.FirstOrDefault(Function(a) a.Referencia = ith.referencia)
                                              If art IsNot Nothing Then
                                                  If art.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO Then
                                                      ndh.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = ith.idAcabadoPerfil And a.Temporal = ith.AcabadoTemporal).Id
                                                      ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio And a.Temporal = art.Temporal).Id
                                                      ndh.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = ith.idColorVidrio And a.Temporal = ith.ColorTemporal).Id
                                                      ndh.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = ith.idEspesor And a.Temporal = ith.EspesorTemporal).Id
                                                  Else
                                                      ndh.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = ith.idAcabadoPerfil And a.Temporal = ith.AcabadoTemporal).Id
                                                      'ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio And a.Temporal = ith.VidrioTemporal).Id
                                                      ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio).Id
                                                      ndh.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = ith.idColorVidrio And a.Temporal = ith.ColorTemporal).Id
                                                      ndh.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = ith.idEspesor And a.Temporal = ith.EspesorTemporal).Id
                                                  End If
                                              End If
                                          Else
                                              ndh.Cells(acabadoPerf.Index).Value = listAcabados.FirstOrDefault(Function(a) a.IdDb = ith.idAcabadoPerfil).Id
                                              ndh.Cells(vidrio.Index).Value = listArticulos.FirstOrDefault(Function(a) a.IdDb = ith.idVidrio).Id
                                              ndh.Cells(colorVidrio.Index).Value = listColores.FirstOrDefault(Function(a) a.IdDb = ith.idColorVidrio).Id
                                              ndh.Cells(espesor.Index).Value = listEspesores.FirstOrDefault(Function(a) a.IdDb = ith.idEspesor).Id
                                          End If
                                          ndh.Cells(factor.Index).Value = ith.factor
                                          ndh.Cells(descuento.Index).Value = ith.descuento
                                          ndh.Cells(valorDescuento.Index).Value = ith.valorDescuento
                                          ndh.Cells(precioUnitario.Index).Value = ith.precioUnitario
                                          ndh.Cells(precioTotal.Index).Value = ith.precioTotal
                                          ndh.Cells(piezasxUnidad.Index).Value = ith.piezasxUnidad
                                          ndh.Cells(costoVidrio.Index).Value = ith.costoVidrio
                                          ndh.Cells(costoPerfiles.Index).Value = ith.costoPerfiles
                                          ndh.Cells(costoAccesorios.Index).Value = ith.costoAccesorios
                                          ndh.Cells(costoOtros.Index).Value = ith.costoOtros
                                          ndh.Cells(costoUnitario.Index).Value = ith.costoUnitario
                                          ndh.Cells(costoTotal.Index).Value = ith.costoTotal
                                          ndh.Cells(precioMtInstalacion.Index).Value = ith.tarifaMtInstalacion
                                          ndh.Cells(precioInstalacion.Index).Value = ith.precioInstalacion
                                          ndh.Cells(unidadMedida.Index).Value = RTrim(ith.unidadMedida)
                                          ndh.Cells(valorDescuento.Index).Value = ith.valorDescuento
                                          ndh.Cells(tipoItem.Index).Value = ith.tipoItem
                                          If ith.tipoItem = ClsEnums.FamiliasMateriales.DISEÑOS Then
                                              ndh.Cells(idArticulo.Index).Value = ith.idPlantilla
                                          Else
                                              ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                                          End If
                                          ndh.Cells(calcularnorma.Index).Value = ith.calculo_NSR
                                          ndh.Cells(cumplenorma.Index).Value = ith.cumpleNorma
                                          ndh.Cells(acabTemporal.Index).Value = ith.AcabadoTemporal
                                          ndh.Cells(colorTemporal.Index).Value = ith.ColorTemporal
                                          ndh.Cells(espesorTemporal.Index).Value = ith.EspesorTemporal
                                          ndh.Cells(vlrDesperdicioVidrio.Index).Value = ith.vlrDespVidrio
                                          ndh.Cells(vlrDesperdicioPerfiles.Index).Value = ith.vlrDespPerfiles
                                          ndh.Cells(vlrDesperdicioAccesorios.Index).Value = ith.vlrDespAccesorios
                                          ndh.Cells(vlrDesperdicioOtros.Index).Value = ith.vlrDespOtros
                                          ndh.Cells(actualizar_plantilla.Index).Value = True
                                      End Sub)
#End Region
                    ndp.Cells(valorDescuento.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(valorDescuento.Index).Value))
                    ndp.Cells(precioUnitario.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioUnitario.Index).Value))
                    ndp.Cells(precioTotal.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioTotal.Index).Value))
                    ndp.Cells(costoAccesorios.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoAccesorios.Index).Value))
                    ndp.Cells(costoPerfiles.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoPerfiles.Index).Value))
                    ndp.Cells(costoVidrio.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoVidrio.Index).Value))
                    ndp.Cells(costoOtros.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoOtros.Index).Value))
                    ndp.Cells(costoTotal.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoTotal.Index).Value))
                    ndp.Cells(costoUnitario.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoUnitario.Index).Value))
                    ndp.Cells(precioInstalacion.Index).Value = ndp.Cells(precioInstalacion.Index).Value ' If(cbInstalacion.Checked, If(indAIU, (CDec(cmbInstalacion.Text) + (CDec(cmbInstalacion.Text) * (DirectCast(cmbTasaImpuesto.SelectedItem, tasaImpuesto).tasa / 100)) * CDec(ndp.Cells(Mtinstalacion.Index).Value)), CDec(cmbInstalacion.Text) * CDec(ndp.Cells(Mtinstalacion.Index).Value)), 0) 'ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioInstalacion.Index).Value))
                    ndp.Cells(vlrDesperdicioVidrio.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioVidrio.Index).Value))
                    ndp.Cells(vlrDesperdicioPerfiles.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioPerfiles.Index).Value))
                    ndp.Cells(vlrDesperdicioAccesorios.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioAccesorios.Index).Value))
                    ndp.Cells(vlrDesperdicioOtros.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(vlrDesperdicioOtros.Index).Value))
                    ndp.Cells(indGuardado.Index).Value = True
#End Region

                    Dim ldatos As New List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal))
                    Dim ind As Integer = 0
                    dic_id_index.ForEach(Sub(d)
                                             Dim h = listHijos.FirstOrDefault(Function(x) x.Id = d)
                                             ldatos.Add(New Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)(d, Nothing, ind, h.ancho, h.alto))
                                             ind += 1
                                         End Sub)
                    Dim cd As New CargaDibujos
                    ndp.Cells(especial.Index).Value = cd.CrearDibujos(item.Id,
                                                                      ldatos,
                                                                      True,
                                                                      ClsEnums.TipoCarga.COTIZA)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_KeyDown(sender As Object, e As KeyEventArgs) Handles dwItems.KeyDown
        Try
            If e.Modifiers = Keys.Control Then
                Select Case e.KeyCode
                    Case Keys.C
                        If Validar_Copiar_Elementos() Then Copiar_Elementos()
                    Case Keys.V
                        If Validar_Pegar_Elementos() Then Pegar_Elementos()
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub lbidfuente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbidfuente.LinkClicked
        Try
            If Convert.ToInt32(lbidfuente.Tag) > 0 Then
                AbrirCotizacion(Convert.ToInt32(lbidfuente.Tag))
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub lbduplicados_DoubleClick(sender As Object, e As EventArgs) Handles lbduplicados.DoubleClick
        Try
            If lbduplicados.SelectedIndex >= 0 Then
                AbrirCotizacion(Convert.ToInt32(lbduplicados.SelectedValue))
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub AbrirCotizacion(idcot_ap As Integer)
        Try
            Dim cotiza As New FrmCotizaciones()
            cotiza.IdActual = idcot_ap
            If mCotizacion.TraerxId(idcot_ap).IdEstado <> ClsEnums.Estados.ACTIVO Then
                cotiza.OperacionActual = ClsEnums.TiOperacion.SOLO_LECTURA
            Else
                cotiza.OperacionActual = ClsEnums.TiOperacion.MODIFICAR
            End If
            cotiza.MdiParent = Me.MdiParent
            cotiza.WindowState = FormWindowState.Maximized
            cotiza.Text &= " (" & idcot_ap.ToString & ")"
            cotiza.Show()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub btonRestablecerOriginales_Click(sender As Object, e As EventArgs) Handles btonRestablecerOriginales.Click
        Try
            cargarCondicionesBase(False)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub bwcargas_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwcargas.RunWorkerCompleted
        Try
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub cmbversioncargasviento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbversioncargasviento.SelectedIndexChanged
        Try
            If cmbversioncargasviento.SelectedIndex < 0 Then
                cmbversioncargasviento.SelectedIndex = 0
            End If

            If nudAlturaCaballete.Value = 0 Then
                MsgBox("La altura del caballete debe ser mayor a cero [0]. No se realizara el informe", MsgBoxStyle.Critical)
                Return
            End If
            If nudAlturaAlero.Value = 0 Then
                MsgBox("La altura del alero debe ser mayor a cero [0]. No se realizara el informe", MsgBoxStyle.Critical)
                Return
            End If
            If nudAnchoEdificio.Value = 0 Then
                MsgBox("El ancho del edificio debe ser mayor a cero [0]. No se realizara el informe", MsgBoxStyle.Critical)
                Return
            End If
            If nudAltoEntreLosas.Value = 0 Then
                MsgBox("La altura entre losas debe ser mayor a cero [0]. No se realizara el informe", MsgBoxStyle.Critical)
                Return
            End If
            Dim velviento As New ClsVelocidadesViento
            Dim areaefectiva As Decimal = 1
            Dim velvientB23 As Decimal = velviento.TraerxIdciudadyIdversion(Ciudad, 1).Valor
            Dim velvientB24 As Decimal = velviento.TraerxIdciudadyIdversion(Ciudad, 2).Valor
            Dim ds As New DataSet
            If cmbversioncargasviento.SelectedIndex = 0 Then
                Dim b23 As New NSR10.Base_Reglas("B.2.3", String.Empty, velvientB23, Convert.ToInt32(cmbGruposUso.SelectedValue),
                                                         Convert.ToInt32(cmbCategExposicion.SelectedValue), nudAlturaCaballete.Value, nudAlturaAlero.Value,
                                                         nudAnchoEdificio.Value, nudAltoEdificio.Value, Convert.ToInt32(cmbTipoCubierta.SelectedValue),
                                                         Convert.ToInt32(cmbTipoEdificacion.SelectedValue), areaefectiva, nudAltoEntreLosas.Value)
                b23.Localizacion = txtCiudad.Text
                ds = b23.RetornoparaInforme()
            Else
                Dim b24 As New NSR10.Base_Reglas("B.2.4", String.Empty, velvientB24, Convert.ToInt32(cmbGruposUso.SelectedValue),
                                                         Convert.ToInt32(cmbCategExposicion.SelectedValue), nudAlturaCaballete.Value, nudAlturaAlero.Value,
                                                         nudAnchoEdificio.Value, nudAltoEdificio.Value, Convert.ToInt32(cmbTipoCubierta.SelectedValue),
                                                         Convert.ToInt32(cmbTipoEdificacion.SelectedValue), areaefectiva, nudAltoEntreLosas.Value)
                b24.Localizacion = txtCiudad.Text
                ds = b24.RetornoparaInforme()
            End If
            Dim mCot As New datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter
            Dim tencabe As DataTable = mCot.GetData(curid)
            tencabe.Rows(0).Item("usuarioCreacion") = My.Settings.Nombre_Usuario_Activo
            ds.Tables.Add(tencabe)
            Dim inf As New Informes.cargas_viento
            inf.SetDataSource(ds)
            inf.SetParameterValue("ocultar_calculos", True)
            crvcargasviento.ReportSource = inf
            crvcargasviento.Zoom(150)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnseleccionarvarios_CheckedChanged(sender As Object, e As EventArgs) Handles btnseleccionarvarios.CheckedChanged
        Try
            If btnseleccionarvarios.Checked Then
                Dim cccol As New DataGridViewCheckBoxColumn
                cccol.Name = "columnamultiseleccion"
                cccol.HeaderText = ""
                cccol.Frozen = True
                dwItems.Columns.Insert(1, cccol)
                btneliminar.Enabled = True
            Else
                dwItems.Columns.RemoveAt(1)
                btneliminar.Enabled = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Try
            If MsgBox("¿Esta seguro que desea eliminar los items seleccionados?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim nds = dwItems.Nodes.Where(Function(n) Convert.ToBoolean(n.Cells(1).Value)).ToArray()
                For Each nd As DataGridViewTreeNode In nds
                    mMovitoPadre = New ClsMovitoPadres
                    mMovitoPadre.CambioEstado(nd.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                    dwItems.Nodes.Remove(nd)
                Next
                actualizar_todos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwcostosextra_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwcostosextra.CellEndEdit
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                actualizar_todos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region
End Class