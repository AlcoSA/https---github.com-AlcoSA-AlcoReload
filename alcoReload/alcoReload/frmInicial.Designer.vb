<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInicial
    Inherits System.Windows.Forms.RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicial))
        Me.rbprincipal = New System.Windows.Forms.Ribbon()
        Me.prmGenerales = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.mnEstados = New System.Windows.Forms.RibbonMenuItem()
        Me.mnAcabados = New System.Windows.Forms.RibbonMenuItem()
        Me.mnArticulos = New System.Windows.Forms.RibbonMenuItem()
        Me.mnserviciosItems = New System.Windows.Forms.RibbonButton()
        Me.mnVariables = New System.Windows.Forms.RibbonMenuItem()
        Me.mnValoresVariables = New System.Windows.Forms.RibbonMenuItem()
        Me.mmEspesoresVidrio = New System.Windows.Forms.RibbonMenuItem()
        Me.nmparametrostecnicos = New System.Windows.Forms.RibbonMenuItem()
        Me.nmvaloresparametros = New System.Windows.Forms.RibbonMenuItem()
        Me.mmmodulosaplicacion = New System.Windows.Forms.RibbonButton()
        Me.mnControlescon = New System.Windows.Forms.RibbonButton()
        Me.mmConectoresPlanosSiesa = New System.Windows.Forms.RibbonButton()
        Me.mninformesdinamicos = New System.Windows.Forms.RibbonButton()
        Me.prmManufactura = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.mnOrientacionPosicion = New System.Windows.Forms.RibbonMenuItem()
        Me.mnUbicacionMaterial = New System.Windows.Forms.RibbonMenuItem()
        Me.mnMaterialPara = New System.Windows.Forms.RibbonMenuItem()
        Me.mnFamiliasModelo = New System.Windows.Forms.RibbonMenuItem()
        Me.mnFamiliasMateriales = New System.Windows.Forms.RibbonMenuItem()
        Me.mnTiposModelos = New System.Windows.Forms.RibbonMenuItem()
        Me.mnClasificacionModelos = New System.Windows.Forms.RibbonMenuItem()
        Me.mnTiposDatos = New System.Windows.Forms.RibbonMenuItem()
        Me.mnTiposCortes = New System.Windows.Forms.RibbonMenuItem()
        Me.mnTiposMaterial = New System.Windows.Forms.RibbonMenuItem()
        Me.mnCaracteristicasAdicionales = New System.Windows.Forms.RibbonMenuItem()
        Me.mnConfiguraciones = New System.Windows.Forms.RibbonMenuItem()
        Me.mnDescuentos = New System.Windows.Forms.RibbonMenuItem()
        Me.mnversionCargaVientos = New System.Windows.Forms.RibbonMenuItem()
        Me.mnVelocidadesViento = New System.Windows.Forms.RibbonMenuItem()
        Me.mnpropiedadesmodelos = New System.Windows.Forms.RibbonMenuItem()
        Me.mnmedsperfileria = New System.Windows.Forms.RibbonButton()
        Me.prmComercial = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.mnParamCostos = New System.Windows.Forms.RibbonMenuItem()
        Me.btonCostoKiloAluminio = New System.Windows.Forms.RibbonButton()
        Me.btonNiveles = New System.Windows.Forms.RibbonButton()
        Me.btonCostoAluminio = New System.Windows.Forms.RibbonButton()
        Me.btonCostoVidrio = New System.Windows.Forms.RibbonButton()
        Me.btonCostoVidrioIndividual = New System.Windows.Forms.RibbonButton()
        Me.btonCostoArticulos = New System.Windows.Forms.RibbonButton()
        Me.btonCostoTrabajos = New System.Windows.Forms.RibbonButton()
        Me.btonVariosCostos = New System.Windows.Forms.RibbonButton()
        Me.btoncostosadicionalesobra = New System.Windows.Forms.RibbonButton()
        Me.mnParamNSR10 = New System.Windows.Forms.RibbonMenuItem()
        Me.btonTipoEdificacion = New System.Windows.Forms.RibbonButton()
        Me.btonGrupoUso = New System.Windows.Forms.RibbonButton()
        Me.btonCategExposicion = New System.Windows.Forms.RibbonButton()
        Me.btonTipoCubierta = New System.Windows.Forms.RibbonButton()
        Me.btonPresionModelo = New System.Windows.Forms.RibbonButton()
        Me.btonComponentes = New System.Windows.Forms.RibbonButton()
        Me.mnParamContratos = New System.Windows.Forms.RibbonMenuItem()
        Me.btonObjetos = New System.Windows.Forms.RibbonButton()
        Me.btonPara = New System.Windows.Forms.RibbonButton()
        Me.btonAseguradoras = New System.Windows.Forms.RibbonButton()
        Me.btonTipoPolizas = New System.Windows.Forms.RibbonButton()
        Me.btonTiposEscrituras = New System.Windows.Forms.RibbonButton()
        Me.btonCamarasComercio = New System.Windows.Forms.RibbonButton()
        Me.btonTipoAnticipo = New System.Windows.Forms.RibbonButton()
        Me.btontipoformato = New System.Windows.Forms.RibbonButton()
        Me.btonVariablesMinutas = New System.Windows.Forms.RibbonButton()
        Me.btonFormatosMinutas = New System.Windows.Forms.RibbonButton()
        Me.mnParametrosNotas = New System.Windows.Forms.RibbonMenuItem()
        Me.btonTiposNotas = New System.Windows.Forms.RibbonButton()
        Me.btonEsquemaNotas = New System.Windows.Forms.RibbonButton()
        Me.btonOrigenesNotas = New System.Windows.Forms.RibbonButton()
        Me.mnParametrosCotizaciones = New System.Windows.Forms.RibbonMenuItem()
        Me.btonDirectores = New System.Windows.Forms.RibbonButton()
        Me.btonVendedores = New System.Windows.Forms.RibbonButton()
        Me.btonFactores = New System.Windows.Forms.RibbonButton()
        Me.btonFormasPago = New System.Windows.Forms.RibbonButton()
        Me.btonImpuestos = New System.Windows.Forms.RibbonButton()
        Me.btonInstalacion = New System.Windows.Forms.RibbonButton()
        Me.btonParametrosAIU = New System.Windows.Forms.RibbonButton()
        Me.btonTiempoEntrega = New System.Windows.Forms.RibbonButton()
        Me.btonTiposIdentificacion = New System.Windows.Forms.RibbonButton()
        Me.btonTipoObra = New System.Windows.Forms.RibbonButton()
        Me.btonVigencias = New System.Windows.Forms.RibbonButton()
        Me.btonCondiciones = New System.Windows.Forms.RibbonButton()
        Me.btonGruposCondiciones = New System.Windows.Forms.RibbonButton()
        Me.btonDuracionDuplicacion = New System.Windows.Forms.RibbonButton()
        Me.mnParametrosInstalacion = New System.Windows.Forms.RibbonMenuItem()
        Me.btnProveedores = New System.Windows.Forms.RibbonButton()
        Me.btnEncargados = New System.Windows.Forms.RibbonButton()
        Me.btnConceptos = New System.Windows.Forms.RibbonButton()
        Me.btnListaPrecios = New System.Windows.Forms.RibbonButton()
        Me.btnTiposCuentas = New System.Windows.Forms.RibbonButton()
        Me.btnTiposOrdenesTrabajo = New System.Windows.Forms.RibbonButton()
        Me.btnDocumentos = New System.Windows.Forms.RibbonButton()
        Me.prmProduccion = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.rbtgenerales = New System.Windows.Forms.RibbonMenuItem()
        Me.btnTercerosProduccion = New System.Windows.Forms.RibbonButton()
        Me.btnMotivosDevolucionOP = New System.Windows.Forms.RibbonButton()
        Me.rbtcalidad = New System.Windows.Forms.RibbonMenuItem()
        Me.btnSecciones = New System.Windows.Forms.RibbonButton()
        Me.btnMotivosxSeccion = New System.Windows.Forms.RibbonButton()
        Me.btnCausas = New System.Windows.Forms.RibbonButton()
        Me.btnMotivosxCausa = New System.Windows.Forms.RibbonButton()
        Me.btnDestinatarios = New System.Windows.Forms.RibbonButton()
        Me.prmseguridad = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.btndepartamentos = New System.Windows.Forms.RibbonButton()
        Me.btnusuarios = New System.Windows.Forms.RibbonButton()
        Me.btngrupos = New System.Windows.Forms.RibbonButton()
        Me.btnpermisos = New System.Windows.Forms.RibbonButton()
        Me.btnpermisosextra = New System.Windows.Forms.RibbonButton()
        Me.btonCerrar = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.btnmodulos = New System.Windows.Forms.RibbonButton()
        Me.btnfinanciero = New System.Windows.Forms.RibbonButton()
        Me.btncomercial = New System.Windows.Forms.RibbonButton()
        Me.btnmanufactura = New System.Windows.Forms.RibbonButton()
        Me.btnplaneacion = New System.Windows.Forms.RibbonButton()
        Me.btnLimpiar = New System.Windows.Forms.RibbonButton()
        Me.btnrecargar = New System.Windows.Forms.RibbonButton()
        Me.btnGuardar = New System.Windows.Forms.RibbonButton()
        Me.btnguardarParcial = New System.Windows.Forms.RibbonButton()
        Me.btnGuardarTotal = New System.Windows.Forms.RibbonButton()
        Me.btnimpresion = New System.Windows.Forms.RibbonButton()
        Me.btnimprimir = New System.Windows.Forms.RibbonButton()
        Me.btnvistaprevia = New System.Windows.Forms.RibbonButton()
        Me.btnexportar = New System.Windows.Forms.RibbonButton()
        Me.btnexportarExcel = New System.Windows.Forms.RibbonButton()
        Me.btnExportarPdf = New System.Windows.Forms.RibbonButton()
        Me.btnexportarword = New System.Windows.Forms.RibbonButton()
        Me.rbconsola = New System.Windows.Forms.RibbonButton()
        Me.btonpermisos = New System.Windows.Forms.RibbonButton()
        Me.tbventas = New System.Windows.Forms.RibbonTab()
        Me.rpcotizaciones = New System.Windows.Forms.RibbonPanel()
        Me.btnGeneraCotizaciones = New System.Windows.Forms.RibbonButton()
        Me.btnVerCotizaciones = New System.Windows.Forms.RibbonButton()
        Me.rppedidos = New System.Windows.Forms.RibbonPanel()
        Me.btngenerarordenpedido = New System.Windows.Forms.RibbonButton()
        Me.btnlistaordenespedido = New System.Windows.Forms.RibbonButton()
        Me.rpReposiciones = New System.Windows.Forms.RibbonPanel()
        Me.btnRepFacturables = New System.Windows.Forms.RibbonButton()
        Me.btnRepNoFacturables = New System.Windows.Forms.RibbonButton()
        Me.btnBuscarxVendedor = New System.Windows.Forms.RibbonButton()
        Me.rpProblemasProduccionVentas = New System.Windows.Forms.RibbonPanel()
        Me.btnregistrodeproblemas = New System.Windows.Forms.RibbonButton()
        Me.btnlistaproblemas = New System.Windows.Forms.RibbonButton()
        Me.tbcontratos = New System.Windows.Forms.RibbonTab()
        Me.pnelContratos = New System.Windows.Forms.RibbonPanel()
        Me.btonlapendientecontrato = New System.Windows.Forms.RibbonButton()
        Me.btonListaContratos = New System.Windows.Forms.RibbonButton()
        Me.rpNotasCobro = New System.Windows.Forms.RibbonPanel()
        Me.btonNotasDirectas = New System.Windows.Forms.RibbonButton()
        Me.btonNotasDesdeAnticipos = New System.Windows.Forms.RibbonButton()
        Me.btonListaNotasCobro = New System.Windows.Forms.RibbonButton()
        Me.rpPolizas = New System.Windows.Forms.RibbonPanel()
        Me.btnIngresoyModi = New System.Windows.Forms.RibbonButton()
        Me.rpPlaneacion = New System.Windows.Forms.RibbonPanel()
        Me.btnFechasProduccion = New System.Windows.Forms.RibbonButton()
        Me.tbinstalacion = New System.Windows.Forms.RibbonTab()
        Me.rpOrdenTrabajo = New System.Windows.Forms.RibbonPanel()
        Me.btnNuevaOrden = New System.Windows.Forms.RibbonButton()
        Me.btnListaOrdenesTrabajo = New System.Windows.Forms.RibbonButton()
        Me.rpCuentasCobro = New System.Windows.Forms.RibbonPanel()
        Me.btnCuentaxContrato = New System.Windows.Forms.RibbonButton()
        Me.btnListaCuentasxOT = New System.Windows.Forms.RibbonButton()
        Me.rpCuentasCobroDirectas = New System.Windows.Forms.RibbonPanel()
        Me.btnCuentaDiracta = New System.Windows.Forms.RibbonButton()
        Me.btnListaCuentasDirectas = New System.Windows.Forms.RibbonButton()
        Me.rpPagoRetenidos = New System.Windows.Forms.RibbonPanel()
        Me.btnPagoRetenidos = New System.Windows.Forms.RibbonButton()
        Me.btnRetenidosPagados = New System.Windows.Forms.RibbonButton()
        Me.btnDetallePago = New System.Windows.Forms.RibbonButton()
        Me.rpDevolucionesInst = New System.Windows.Forms.RibbonPanel()
        Me.btnNuevaDevolucion = New System.Windows.Forms.RibbonButton()
        Me.btnListaDevoluciones = New System.Windows.Forms.RibbonButton()
        Me.rpConsultasReportes = New System.Windows.Forms.RibbonPanel()
        Me.btnCuentasPorFecha = New System.Windows.Forms.RibbonButton()
        Me.btnOrdenesVsCuentas = New System.Windows.Forms.RibbonButton()
        Me.tbfacturacion = New System.Windows.Forms.RibbonTab()
        Me.tbcostos = New System.Windows.Forms.RibbonTab()
        Me.tblogistica = New System.Windows.Forms.RibbonTab()
        Me.rpaprobacionEntregas = New System.Windows.Forms.RibbonPanel()
        Me.rpremisiones = New System.Windows.Forms.RibbonPanel()
        Me.rpdevoluciones = New System.Windows.Forms.RibbonPanel()
        Me.rpanulacionLogistica = New System.Windows.Forms.RibbonPanel()
        Me.tbconsultasreportesComercial = New System.Windows.Forms.RibbonTab()
        Me.tbingenieria = New System.Windows.Forms.RibbonTab()
        Me.rpplantillas = New System.Windows.Forms.RibbonPanel()
        Me.btnagregarPlantilla = New System.Windows.Forms.RibbonButton()
        Me.btnlistaplantillas = New System.Windows.Forms.RibbonButton()
        Me.rpmodificacionesmasivas = New System.Windows.Forms.RibbonPanel()
        Me.btnmodificarmasivo = New System.Windows.Forms.RibbonButton()
        Me.tbdeptecnico = New System.Windows.Forms.RibbonTab()
        Me.rpparaplanos = New System.Windows.Forms.RibbonPanel()
        Me.btnopaprobadas = New System.Windows.Forms.RibbonButton()
        Me.rprevajplanos = New System.Windows.Forms.RibbonPanel()
        Me.rpimpplanos = New System.Windows.Forms.RibbonPanel()
        Me.rpadicionplanos = New System.Windows.Forms.RibbonPanel()
        Me.rpeliminacionplanos = New System.Windows.Forms.RibbonPanel()
        Me.rpoptimizacionop = New System.Windows.Forms.RibbonPanel()
        Me.rpimpresionetiquetas = New System.Windows.Forms.RibbonPanel()
        Me.tbproduccion = New System.Windows.Forms.RibbonTab()
        Me.rpdesdepedido = New System.Windows.Forms.RibbonPanel()
        Me.btnimprimirop = New System.Windows.Forms.RibbonButton()
        Me.btnanularop = New System.Windows.Forms.RibbonButton()
        Me.rpentregasproduccion = New System.Windows.Forms.RibbonPanel()
        Me.btnentregasproduccion = New System.Windows.Forms.RibbonButton()
        Me.btndevolucionesproduccion = New System.Windows.Forms.RibbonButton()
        Me.rpparaproduccion = New System.Windows.Forms.RibbonPanel()
        Me.btnparaproduccion = New System.Windows.Forms.RibbonButton()
        Me.btnenproduccion = New System.Windows.Forms.RibbonButton()
        Me.rpproblemasproduccion = New System.Windows.Forms.RibbonPanel()
        Me.btnabrirproblema = New System.Windows.Forms.RibbonButton()
        Me.tbperfileria = New System.Windows.Forms.RibbonTab()
        Me.rplistascorteperf = New System.Windows.Forms.RibbonPanel()
        Me.tbconsultasreportesManufactura = New System.Windows.Forms.RibbonTab()
        Me.pninfdinamicosman = New System.Windows.Forms.RibbonPanel()
        Me.btninfdinamicosman = New System.Windows.Forms.RibbonButton()
        Me.mditabbar = New MdiTabPagesBar.MdiToolStripTabBar()
        Me.rbCotizacion = New System.Windows.Forms.RibbonButton()
        Me.btncomision = New System.Windows.Forms.RibbonButton()
        Me.btnrecaudo = New System.Windows.Forms.RibbonButton()
        Me.SuspendLayout()
        '
        'rbprincipal
        '
        Me.rbprincipal.BackColor = System.Drawing.SystemColors.Control
        Me.rbprincipal.BorderMode = System.Windows.Forms.RibbonWindowMode.NonClientAreaCustomDrawn
        Me.rbprincipal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbprincipal.Location = New System.Drawing.Point(0, 0)
        Me.rbprincipal.Minimized = False
        Me.rbprincipal.Name = "rbprincipal"
        '
        '
        '
        Me.rbprincipal.OrbDropDown.BorderRoundness = 8
        Me.rbprincipal.OrbDropDown.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.rbprincipal.OrbDropDown.Location = New System.Drawing.Point(0, 0)
        Me.rbprincipal.OrbDropDown.MenuItems.Add(Me.prmGenerales)
        Me.rbprincipal.OrbDropDown.MenuItems.Add(Me.prmManufactura)
        Me.rbprincipal.OrbDropDown.MenuItems.Add(Me.prmComercial)
        Me.rbprincipal.OrbDropDown.MenuItems.Add(Me.prmProduccion)
        Me.rbprincipal.OrbDropDown.MenuItems.Add(Me.prmseguridad)
        Me.rbprincipal.OrbDropDown.MenuItems.Add(Me.btonCerrar)
        Me.rbprincipal.OrbDropDown.Name = "orbmenu"
        Me.rbprincipal.OrbDropDown.Size = New System.Drawing.Size(500, 336)
        Me.rbprincipal.OrbDropDown.TabIndex = 0
        Me.rbprincipal.OrbDropDown.Tag = "1"
        Me.rbprincipal.OrbImage = CType(resources.GetObject("rbprincipal.OrbImage"), System.Drawing.Image)
        Me.rbprincipal.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013
        Me.rbprincipal.OrbText = ""
        '
        '
        '
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.btnmodulos)
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.btnLimpiar)
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.btnrecargar)
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.btnGuardar)
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.btnimpresion)
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.btnexportar)
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.rbconsola)
        Me.rbprincipal.QuickAcessToolbar.Items.Add(Me.btonpermisos)
        Me.rbprincipal.QuickAcessToolbar.Tag = "0"
        Me.rbprincipal.QuickAcessToolbar.Text = "Barra accesos rapidos"
        Me.rbprincipal.RibbonTabFont = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.rbprincipal.Size = New System.Drawing.Size(1079, 148)
        Me.rbprincipal.TabIndex = 9
        Me.rbprincipal.Tabs.Add(Me.tbventas)
        Me.rbprincipal.Tabs.Add(Me.tbcontratos)
        Me.rbprincipal.Tabs.Add(Me.tbinstalacion)
        Me.rbprincipal.Tabs.Add(Me.tbfacturacion)
        Me.rbprincipal.Tabs.Add(Me.tbcostos)
        Me.rbprincipal.Tabs.Add(Me.tblogistica)
        Me.rbprincipal.Tabs.Add(Me.tbconsultasreportesComercial)
        Me.rbprincipal.Tabs.Add(Me.tbingenieria)
        Me.rbprincipal.Tabs.Add(Me.tbdeptecnico)
        Me.rbprincipal.Tabs.Add(Me.tbproduccion)
        Me.rbprincipal.Tabs.Add(Me.tbperfileria)
        Me.rbprincipal.Tabs.Add(Me.tbconsultasreportesManufactura)
        Me.rbprincipal.TabsMargin = New System.Windows.Forms.Padding(12, 26, 20, 0)
        Me.rbprincipal.ThemeColor = System.Windows.Forms.RibbonTheme.Blue
        '
        'prmGenerales
        '
        Me.prmGenerales.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.prmGenerales.DropDownItems.Add(Me.mnEstados)
        Me.prmGenerales.DropDownItems.Add(Me.mnAcabados)
        Me.prmGenerales.DropDownItems.Add(Me.mnArticulos)
        Me.prmGenerales.DropDownItems.Add(Me.mnserviciosItems)
        Me.prmGenerales.DropDownItems.Add(Me.mnVariables)
        Me.prmGenerales.DropDownItems.Add(Me.mnValoresVariables)
        Me.prmGenerales.DropDownItems.Add(Me.mmEspesoresVidrio)
        Me.prmGenerales.DropDownItems.Add(Me.nmparametrostecnicos)
        Me.prmGenerales.DropDownItems.Add(Me.nmvaloresparametros)
        Me.prmGenerales.DropDownItems.Add(Me.mmmodulosaplicacion)
        Me.prmGenerales.DropDownItems.Add(Me.mnControlescon)
        Me.prmGenerales.DropDownItems.Add(Me.mmConectoresPlanosSiesa)
        Me.prmGenerales.DropDownItems.Add(Me.mninformesdinamicos)
        Me.prmGenerales.FlashIntervall = 100000
        Me.prmGenerales.Image = CType(resources.GetObject("prmGenerales.Image"), System.Drawing.Image)
        Me.prmGenerales.SmallImage = CType(resources.GetObject("prmGenerales.SmallImage"), System.Drawing.Image)
        Me.prmGenerales.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.prmGenerales.Tag = "1.1"
        Me.prmGenerales.Text = "Parámetros Generales"
        '
        'mnEstados
        '
        Me.mnEstados.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnEstados.Image = CType(resources.GetObject("mnEstados.Image"), System.Drawing.Image)
        Me.mnEstados.SmallImage = CType(resources.GetObject("mnEstados.SmallImage"), System.Drawing.Image)
        Me.mnEstados.Tag = "1.1.1"
        Me.mnEstados.Text = "Estados"
        Me.mnEstados.ToolTip = ""
        '
        'mnAcabados
        '
        Me.mnAcabados.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnAcabados.Image = CType(resources.GetObject("mnAcabados.Image"), System.Drawing.Image)
        Me.mnAcabados.SmallImage = CType(resources.GetObject("mnAcabados.SmallImage"), System.Drawing.Image)
        Me.mnAcabados.Tag = "1.1.2"
        Me.mnAcabados.Text = "Acabados"
        '
        'mnArticulos
        '
        Me.mnArticulos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnArticulos.Image = CType(resources.GetObject("mnArticulos.Image"), System.Drawing.Image)
        Me.mnArticulos.SmallImage = CType(resources.GetObject("mnArticulos.SmallImage"), System.Drawing.Image)
        Me.mnArticulos.Tag = "1.1.3"
        Me.mnArticulos.Text = "Articulos"
        '
        'mnserviciosItems
        '
        Me.mnserviciosItems.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnserviciosItems.Image = CType(resources.GetObject("mnserviciosItems.Image"), System.Drawing.Image)
        Me.mnserviciosItems.SmallImage = CType(resources.GetObject("mnserviciosItems.SmallImage"), System.Drawing.Image)
        Me.mnserviciosItems.Tag = "1.1.4"
        Me.mnserviciosItems.Text = "Servicios items"
        '
        'mnVariables
        '
        Me.mnVariables.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnVariables.Image = CType(resources.GetObject("mnVariables.Image"), System.Drawing.Image)
        Me.mnVariables.SmallImage = CType(resources.GetObject("mnVariables.SmallImage"), System.Drawing.Image)
        Me.mnVariables.Tag = "1.1.5"
        Me.mnVariables.Text = "Variables"
        '
        'mnValoresVariables
        '
        Me.mnValoresVariables.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnValoresVariables.Image = CType(resources.GetObject("mnValoresVariables.Image"), System.Drawing.Image)
        Me.mnValoresVariables.SmallImage = CType(resources.GetObject("mnValoresVariables.SmallImage"), System.Drawing.Image)
        Me.mnValoresVariables.Tag = "1.1.6"
        Me.mnValoresVariables.Text = "Valores Variables"
        '
        'mmEspesoresVidrio
        '
        Me.mmEspesoresVidrio.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mmEspesoresVidrio.Image = CType(resources.GetObject("mmEspesoresVidrio.Image"), System.Drawing.Image)
        Me.mmEspesoresVidrio.SmallImage = CType(resources.GetObject("mmEspesoresVidrio.SmallImage"), System.Drawing.Image)
        Me.mmEspesoresVidrio.Tag = "1.1.7"
        Me.mmEspesoresVidrio.Text = "Espesores Vidrios"
        '
        'nmparametrostecnicos
        '
        Me.nmparametrostecnicos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.nmparametrostecnicos.Image = CType(resources.GetObject("nmparametrostecnicos.Image"), System.Drawing.Image)
        Me.nmparametrostecnicos.SmallImage = CType(resources.GetObject("nmparametrostecnicos.SmallImage"), System.Drawing.Image)
        Me.nmparametrostecnicos.Tag = "1.1.8"
        Me.nmparametrostecnicos.Text = "Parametros Tecnicos Articulo"
        '
        'nmvaloresparametros
        '
        Me.nmvaloresparametros.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.nmvaloresparametros.Image = CType(resources.GetObject("nmvaloresparametros.Image"), System.Drawing.Image)
        Me.nmvaloresparametros.SmallImage = CType(resources.GetObject("nmvaloresparametros.SmallImage"), System.Drawing.Image)
        Me.nmvaloresparametros.Tag = "1.1.9"
        Me.nmvaloresparametros.Text = "Valores Parametros Tecnicos"
        '
        'mmmodulosaplicacion
        '
        Me.mmmodulosaplicacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mmmodulosaplicacion.Image = CType(resources.GetObject("mmmodulosaplicacion.Image"), System.Drawing.Image)
        Me.mmmodulosaplicacion.SmallImage = CType(resources.GetObject("mmmodulosaplicacion.SmallImage"), System.Drawing.Image)
        Me.mmmodulosaplicacion.Tag = "1.1.10"
        Me.mmmodulosaplicacion.Text = "Modulos Aplicacion"
        '
        'mnControlescon
        '
        Me.mnControlescon.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnControlescon.Image = CType(resources.GetObject("mnControlescon.Image"), System.Drawing.Image)
        Me.mnControlescon.SmallImage = CType(resources.GetObject("mnControlescon.SmallImage"), System.Drawing.Image)
        Me.mnControlescon.Tag = "1.1.11"
        Me.mnControlescon.Text = "Controles Conectores"
        '
        'mmConectoresPlanosSiesa
        '
        Me.mmConectoresPlanosSiesa.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mmConectoresPlanosSiesa.Image = CType(resources.GetObject("mmConectoresPlanosSiesa.Image"), System.Drawing.Image)
        Me.mmConectoresPlanosSiesa.SmallImage = CType(resources.GetObject("mmConectoresPlanosSiesa.SmallImage"), System.Drawing.Image)
        Me.mmConectoresPlanosSiesa.Tag = "1.1.12"
        Me.mmConectoresPlanosSiesa.Text = "Conectores Siesa"
        '
        'mninformesdinamicos
        '
        Me.mninformesdinamicos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mninformesdinamicos.Image = CType(resources.GetObject("mninformesdinamicos.Image"), System.Drawing.Image)
        Me.mninformesdinamicos.SmallImage = CType(resources.GetObject("mninformesdinamicos.SmallImage"), System.Drawing.Image)
        Me.mninformesdinamicos.Tag = "1.1.13"
        Me.mninformesdinamicos.Text = "Informes Dinamicos"
        '
        'prmManufactura
        '
        Me.prmManufactura.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.prmManufactura.DropDownItems.Add(Me.mnOrientacionPosicion)
        Me.prmManufactura.DropDownItems.Add(Me.mnUbicacionMaterial)
        Me.prmManufactura.DropDownItems.Add(Me.mnMaterialPara)
        Me.prmManufactura.DropDownItems.Add(Me.mnFamiliasModelo)
        Me.prmManufactura.DropDownItems.Add(Me.mnFamiliasMateriales)
        Me.prmManufactura.DropDownItems.Add(Me.mnTiposModelos)
        Me.prmManufactura.DropDownItems.Add(Me.mnClasificacionModelos)
        Me.prmManufactura.DropDownItems.Add(Me.mnTiposDatos)
        Me.prmManufactura.DropDownItems.Add(Me.mnTiposCortes)
        Me.prmManufactura.DropDownItems.Add(Me.mnTiposMaterial)
        Me.prmManufactura.DropDownItems.Add(Me.mnCaracteristicasAdicionales)
        Me.prmManufactura.DropDownItems.Add(Me.mnConfiguraciones)
        Me.prmManufactura.DropDownItems.Add(Me.mnDescuentos)
        Me.prmManufactura.DropDownItems.Add(Me.mnversionCargaVientos)
        Me.prmManufactura.DropDownItems.Add(Me.mnVelocidadesViento)
        Me.prmManufactura.DropDownItems.Add(Me.mnpropiedadesmodelos)
        Me.prmManufactura.DropDownItems.Add(Me.mnmedsperfileria)
        Me.prmManufactura.Image = CType(resources.GetObject("prmManufactura.Image"), System.Drawing.Image)
        Me.prmManufactura.SmallImage = CType(resources.GetObject("prmManufactura.SmallImage"), System.Drawing.Image)
        Me.prmManufactura.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.prmManufactura.Tag = "1.2"
        Me.prmManufactura.Text = "Parámetros Manufactura"
        '
        'mnOrientacionPosicion
        '
        Me.mnOrientacionPosicion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnOrientacionPosicion.Image = CType(resources.GetObject("mnOrientacionPosicion.Image"), System.Drawing.Image)
        Me.mnOrientacionPosicion.SmallImage = CType(resources.GetObject("mnOrientacionPosicion.SmallImage"), System.Drawing.Image)
        Me.mnOrientacionPosicion.Tag = "1.2.1"
        Me.mnOrientacionPosicion.Text = "Orientación y Posiciones"
        '
        'mnUbicacionMaterial
        '
        Me.mnUbicacionMaterial.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnUbicacionMaterial.Image = CType(resources.GetObject("mnUbicacionMaterial.Image"), System.Drawing.Image)
        Me.mnUbicacionMaterial.SmallImage = CType(resources.GetObject("mnUbicacionMaterial.SmallImage"), System.Drawing.Image)
        Me.mnUbicacionMaterial.Tag = "1.2.2"
        Me.mnUbicacionMaterial.Text = "Ubicación Material"
        '
        'mnMaterialPara
        '
        Me.mnMaterialPara.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnMaterialPara.Image = CType(resources.GetObject("mnMaterialPara.Image"), System.Drawing.Image)
        Me.mnMaterialPara.SmallImage = CType(resources.GetObject("mnMaterialPara.SmallImage"), System.Drawing.Image)
        Me.mnMaterialPara.Tag = "1.2.3"
        Me.mnMaterialPara.Text = "Material Para"
        '
        'mnFamiliasModelo
        '
        Me.mnFamiliasModelo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnFamiliasModelo.Image = CType(resources.GetObject("mnFamiliasModelo.Image"), System.Drawing.Image)
        Me.mnFamiliasModelo.SmallImage = CType(resources.GetObject("mnFamiliasModelo.SmallImage"), System.Drawing.Image)
        Me.mnFamiliasModelo.Tag = "1.2.4"
        Me.mnFamiliasModelo.Text = "Familias Modelos"
        '
        'mnFamiliasMateriales
        '
        Me.mnFamiliasMateriales.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnFamiliasMateriales.Image = CType(resources.GetObject("mnFamiliasMateriales.Image"), System.Drawing.Image)
        Me.mnFamiliasMateriales.SmallImage = CType(resources.GetObject("mnFamiliasMateriales.SmallImage"), System.Drawing.Image)
        Me.mnFamiliasMateriales.Tag = "1.2.5"
        Me.mnFamiliasMateriales.Text = "Familias Materiales"
        '
        'mnTiposModelos
        '
        Me.mnTiposModelos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnTiposModelos.Image = CType(resources.GetObject("mnTiposModelos.Image"), System.Drawing.Image)
        Me.mnTiposModelos.SmallImage = CType(resources.GetObject("mnTiposModelos.SmallImage"), System.Drawing.Image)
        Me.mnTiposModelos.Tag = "1.2.6"
        Me.mnTiposModelos.Text = "Tipo Modelos"
        '
        'mnClasificacionModelos
        '
        Me.mnClasificacionModelos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnClasificacionModelos.Image = CType(resources.GetObject("mnClasificacionModelos.Image"), System.Drawing.Image)
        Me.mnClasificacionModelos.SmallImage = CType(resources.GetObject("mnClasificacionModelos.SmallImage"), System.Drawing.Image)
        Me.mnClasificacionModelos.Tag = "1.2.7"
        Me.mnClasificacionModelos.Text = "Clasificación Modelos"
        '
        'mnTiposDatos
        '
        Me.mnTiposDatos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnTiposDatos.Image = CType(resources.GetObject("mnTiposDatos.Image"), System.Drawing.Image)
        Me.mnTiposDatos.SmallImage = CType(resources.GetObject("mnTiposDatos.SmallImage"), System.Drawing.Image)
        Me.mnTiposDatos.Tag = "1.2.8"
        Me.mnTiposDatos.Text = "Tipos Datos"
        '
        'mnTiposCortes
        '
        Me.mnTiposCortes.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnTiposCortes.Image = CType(resources.GetObject("mnTiposCortes.Image"), System.Drawing.Image)
        Me.mnTiposCortes.SmallImage = CType(resources.GetObject("mnTiposCortes.SmallImage"), System.Drawing.Image)
        Me.mnTiposCortes.Tag = "1.2.9"
        Me.mnTiposCortes.Text = "Tipos Cortes"
        '
        'mnTiposMaterial
        '
        Me.mnTiposMaterial.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnTiposMaterial.Image = CType(resources.GetObject("mnTiposMaterial.Image"), System.Drawing.Image)
        Me.mnTiposMaterial.SmallImage = CType(resources.GetObject("mnTiposMaterial.SmallImage"), System.Drawing.Image)
        Me.mnTiposMaterial.Tag = "1.2.10"
        Me.mnTiposMaterial.Text = "Tipos Material"
        '
        'mnCaracteristicasAdicionales
        '
        Me.mnCaracteristicasAdicionales.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnCaracteristicasAdicionales.Image = CType(resources.GetObject("mnCaracteristicasAdicionales.Image"), System.Drawing.Image)
        Me.mnCaracteristicasAdicionales.SmallImage = CType(resources.GetObject("mnCaracteristicasAdicionales.SmallImage"), System.Drawing.Image)
        Me.mnCaracteristicasAdicionales.Tag = "1.2.11"
        Me.mnCaracteristicasAdicionales.Text = "Características Adicionales"
        '
        'mnConfiguraciones
        '
        Me.mnConfiguraciones.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnConfiguraciones.Image = CType(resources.GetObject("mnConfiguraciones.Image"), System.Drawing.Image)
        Me.mnConfiguraciones.SmallImage = CType(resources.GetObject("mnConfiguraciones.SmallImage"), System.Drawing.Image)
        Me.mnConfiguraciones.Tag = "1.2.12"
        Me.mnConfiguraciones.Text = "Configuraciones"
        '
        'mnDescuentos
        '
        Me.mnDescuentos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnDescuentos.Image = CType(resources.GetObject("mnDescuentos.Image"), System.Drawing.Image)
        Me.mnDescuentos.SmallImage = CType(resources.GetObject("mnDescuentos.SmallImage"), System.Drawing.Image)
        Me.mnDescuentos.Tag = "1.2.13"
        Me.mnDescuentos.Text = "Descuentos"
        '
        'mnversionCargaVientos
        '
        Me.mnversionCargaVientos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnversionCargaVientos.Image = CType(resources.GetObject("mnversionCargaVientos.Image"), System.Drawing.Image)
        Me.mnversionCargaVientos.SmallImage = CType(resources.GetObject("mnversionCargaVientos.SmallImage"), System.Drawing.Image)
        Me.mnversionCargaVientos.Tag = "1.2.14"
        Me.mnversionCargaVientos.Text = "Versiones Carga Viento"
        '
        'mnVelocidadesViento
        '
        Me.mnVelocidadesViento.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnVelocidadesViento.Image = CType(resources.GetObject("mnVelocidadesViento.Image"), System.Drawing.Image)
        Me.mnVelocidadesViento.SmallImage = CType(resources.GetObject("mnVelocidadesViento.SmallImage"), System.Drawing.Image)
        Me.mnVelocidadesViento.Tag = "1.2.15"
        Me.mnVelocidadesViento.Text = "Velocidad Viento"
        '
        'mnpropiedadesmodelos
        '
        Me.mnpropiedadesmodelos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnpropiedadesmodelos.Image = CType(resources.GetObject("mnpropiedadesmodelos.Image"), System.Drawing.Image)
        Me.mnpropiedadesmodelos.SmallImage = CType(resources.GetObject("mnpropiedadesmodelos.SmallImage"), System.Drawing.Image)
        Me.mnpropiedadesmodelos.Tag = "1.2.16"
        Me.mnpropiedadesmodelos.Text = "Propiedades Modelos"
        '
        'mnmedsperfileria
        '
        Me.mnmedsperfileria.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnmedsperfileria.Image = CType(resources.GetObject("mnmedsperfileria.Image"), System.Drawing.Image)
        Me.mnmedsperfileria.SmallImage = CType(resources.GetObject("mnmedsperfileria.SmallImage"), System.Drawing.Image)
        Me.mnmedsperfileria.Tag = "1.2.17"
        Me.mnmedsperfileria.Text = "Lotes Perfileria"
        '
        'prmComercial
        '
        Me.prmComercial.DrawIconsBar = False
        Me.prmComercial.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.prmComercial.DropDownItems.Add(Me.mnParamCostos)
        Me.prmComercial.DropDownItems.Add(Me.mnParamNSR10)
        Me.prmComercial.DropDownItems.Add(Me.mnParamContratos)
        Me.prmComercial.DropDownItems.Add(Me.mnParametrosNotas)
        Me.prmComercial.DropDownItems.Add(Me.mnParametrosCotizaciones)
        Me.prmComercial.DropDownItems.Add(Me.mnParametrosInstalacion)
        Me.prmComercial.FlashEnabled = True
        Me.prmComercial.FlashIntervall = 500
        Me.prmComercial.Image = CType(resources.GetObject("prmComercial.Image"), System.Drawing.Image)
        Me.prmComercial.SmallImage = CType(resources.GetObject("prmComercial.SmallImage"), System.Drawing.Image)
        Me.prmComercial.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.prmComercial.Tag = "1.3"
        Me.prmComercial.Text = "Parámetros Comercial"
        '
        'mnParamCostos
        '
        Me.mnParamCostos.DrawIconsBar = False
        Me.mnParamCostos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnParamCostos.DropDownItems.Add(Me.btonCostoKiloAluminio)
        Me.mnParamCostos.DropDownItems.Add(Me.btonNiveles)
        Me.mnParamCostos.DropDownItems.Add(Me.btonCostoAluminio)
        Me.mnParamCostos.DropDownItems.Add(Me.btonCostoVidrio)
        Me.mnParamCostos.DropDownItems.Add(Me.btonCostoVidrioIndividual)
        Me.mnParamCostos.DropDownItems.Add(Me.btonCostoArticulos)
        Me.mnParamCostos.DropDownItems.Add(Me.btonCostoTrabajos)
        Me.mnParamCostos.DropDownItems.Add(Me.btonVariosCostos)
        Me.mnParamCostos.DropDownItems.Add(Me.btoncostosadicionalesobra)
        Me.mnParamCostos.FlashEnabled = True
        Me.mnParamCostos.FlashIntervall = 500
        Me.mnParamCostos.Image = CType(resources.GetObject("mnParamCostos.Image"), System.Drawing.Image)
        Me.mnParamCostos.ShowFlashImage = True
        Me.mnParamCostos.SmallImage = CType(resources.GetObject("mnParamCostos.SmallImage"), System.Drawing.Image)
        Me.mnParamCostos.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.mnParamCostos.Tag = "1.3.1"
        Me.mnParamCostos.Text = "Parámetros Costos"
        '
        'btonCostoKiloAluminio
        '
        Me.btonCostoKiloAluminio.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCostoKiloAluminio.Image = CType(resources.GetObject("btonCostoKiloAluminio.Image"), System.Drawing.Image)
        Me.btonCostoKiloAluminio.SmallImage = CType(resources.GetObject("btonCostoKiloAluminio.SmallImage"), System.Drawing.Image)
        Me.btonCostoKiloAluminio.Tag = "1.3.1.1"
        Me.btonCostoKiloAluminio.Text = "Tipos Aluminio"
        '
        'btonNiveles
        '
        Me.btonNiveles.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonNiveles.Image = CType(resources.GetObject("btonNiveles.Image"), System.Drawing.Image)
        Me.btonNiveles.SmallImage = CType(resources.GetObject("btonNiveles.SmallImage"), System.Drawing.Image)
        Me.btonNiveles.Tag = "1.3.1.2"
        Me.btonNiveles.Text = "Niveles"
        '
        'btonCostoAluminio
        '
        Me.btonCostoAluminio.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCostoAluminio.Image = CType(resources.GetObject("btonCostoAluminio.Image"), System.Drawing.Image)
        Me.btonCostoAluminio.SmallImage = CType(resources.GetObject("btonCostoAluminio.SmallImage"), System.Drawing.Image)
        Me.btonCostoAluminio.Tag = "1.3.1.3"
        Me.btonCostoAluminio.Text = "Calculo Costo Alumio"
        '
        'btonCostoVidrio
        '
        Me.btonCostoVidrio.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCostoVidrio.Image = CType(resources.GetObject("btonCostoVidrio.Image"), System.Drawing.Image)
        Me.btonCostoVidrio.SmallImage = CType(resources.GetObject("btonCostoVidrio.SmallImage"), System.Drawing.Image)
        Me.btonCostoVidrio.Tag = "1.3.1.4"
        Me.btonCostoVidrio.Text = "Costo Vidrio"
        '
        'btonCostoVidrioIndividual
        '
        Me.btonCostoVidrioIndividual.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCostoVidrioIndividual.Image = CType(resources.GetObject("btonCostoVidrioIndividual.Image"), System.Drawing.Image)
        Me.btonCostoVidrioIndividual.SmallImage = CType(resources.GetObject("btonCostoVidrioIndividual.SmallImage"), System.Drawing.Image)
        Me.btonCostoVidrioIndividual.Tag = "1.3.1.5"
        Me.btonCostoVidrioIndividual.Text = "Costo vidrio individual"
        '
        'btonCostoArticulos
        '
        Me.btonCostoArticulos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCostoArticulos.Image = CType(resources.GetObject("btonCostoArticulos.Image"), System.Drawing.Image)
        Me.btonCostoArticulos.SmallImage = CType(resources.GetObject("btonCostoArticulos.SmallImage"), System.Drawing.Image)
        Me.btonCostoArticulos.Tag = "1.3.1.8"
        Me.btonCostoArticulos.Text = "Costo Otros Articulos"
        '
        'btonCostoTrabajos
        '
        Me.btonCostoTrabajos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCostoTrabajos.Image = CType(resources.GetObject("btonCostoTrabajos.Image"), System.Drawing.Image)
        Me.btonCostoTrabajos.SmallImage = CType(resources.GetObject("btonCostoTrabajos.SmallImage"), System.Drawing.Image)
        Me.btonCostoTrabajos.Tag = "1.3.1.9"
        Me.btonCostoTrabajos.Text = "Costo trabajos items"
        '
        'btonVariosCostos
        '
        Me.btonVariosCostos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonVariosCostos.Image = CType(resources.GetObject("btonVariosCostos.Image"), System.Drawing.Image)
        Me.btonVariosCostos.SmallImage = CType(resources.GetObject("btonVariosCostos.SmallImage"), System.Drawing.Image)
        Me.btonVariosCostos.Tag = "1.3.1.10"
        Me.btonVariosCostos.Text = "Costo accesorios/otros/trabajos"
        '
        'btoncostosadicionalesobra
        '
        Me.btoncostosadicionalesobra.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btoncostosadicionalesobra.Image = CType(resources.GetObject("btoncostosadicionalesobra.Image"), System.Drawing.Image)
        Me.btoncostosadicionalesobra.SmallImage = CType(resources.GetObject("btoncostosadicionalesobra.SmallImage"), System.Drawing.Image)
        Me.btoncostosadicionalesobra.Tag = "1.3.1.11"
        Me.btoncostosadicionalesobra.Text = "Costos Adicionales Obra"
        '
        'mnParamNSR10
        '
        Me.mnParamNSR10.DrawIconsBar = False
        Me.mnParamNSR10.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnParamNSR10.DropDownItems.Add(Me.btonTipoEdificacion)
        Me.mnParamNSR10.DropDownItems.Add(Me.btonGrupoUso)
        Me.mnParamNSR10.DropDownItems.Add(Me.btonCategExposicion)
        Me.mnParamNSR10.DropDownItems.Add(Me.btonTipoCubierta)
        Me.mnParamNSR10.DropDownItems.Add(Me.btonPresionModelo)
        Me.mnParamNSR10.DropDownItems.Add(Me.btonComponentes)
        Me.mnParamNSR10.FlashEnabled = True
        Me.mnParamNSR10.FlashIntervall = 500
        Me.mnParamNSR10.Image = CType(resources.GetObject("mnParamNSR10.Image"), System.Drawing.Image)
        Me.mnParamNSR10.ShowFlashImage = True
        Me.mnParamNSR10.SmallImage = CType(resources.GetObject("mnParamNSR10.SmallImage"), System.Drawing.Image)
        Me.mnParamNSR10.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.mnParamNSR10.Tag = "1.3.2"
        Me.mnParamNSR10.Text = "Parámetros NSR10"
        '
        'btonTipoEdificacion
        '
        Me.btonTipoEdificacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTipoEdificacion.Image = CType(resources.GetObject("btonTipoEdificacion.Image"), System.Drawing.Image)
        Me.btonTipoEdificacion.SmallImage = CType(resources.GetObject("btonTipoEdificacion.SmallImage"), System.Drawing.Image)
        Me.btonTipoEdificacion.Tag = "1.3.2.1"
        Me.btonTipoEdificacion.Text = "Tipo Edificacion"
        '
        'btonGrupoUso
        '
        Me.btonGrupoUso.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonGrupoUso.Image = CType(resources.GetObject("btonGrupoUso.Image"), System.Drawing.Image)
        Me.btonGrupoUso.SmallImage = CType(resources.GetObject("btonGrupoUso.SmallImage"), System.Drawing.Image)
        Me.btonGrupoUso.Tag = "1.3.2.2"
        Me.btonGrupoUso.Text = "Grupo de Uso"
        '
        'btonCategExposicion
        '
        Me.btonCategExposicion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCategExposicion.Image = CType(resources.GetObject("btonCategExposicion.Image"), System.Drawing.Image)
        Me.btonCategExposicion.SmallImage = CType(resources.GetObject("btonCategExposicion.SmallImage"), System.Drawing.Image)
        Me.btonCategExposicion.Tag = "1.3.2.3"
        Me.btonCategExposicion.Text = "Categorias de Exposición"
        '
        'btonTipoCubierta
        '
        Me.btonTipoCubierta.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTipoCubierta.Image = CType(resources.GetObject("btonTipoCubierta.Image"), System.Drawing.Image)
        Me.btonTipoCubierta.SmallImage = CType(resources.GetObject("btonTipoCubierta.SmallImage"), System.Drawing.Image)
        Me.btonTipoCubierta.Tag = "1.3.2.4"
        Me.btonTipoCubierta.Text = "Tipos de Cubiertas"
        '
        'btonPresionModelo
        '
        Me.btonPresionModelo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonPresionModelo.Image = CType(resources.GetObject("btonPresionModelo.Image"), System.Drawing.Image)
        Me.btonPresionModelo.SmallImage = CType(resources.GetObject("btonPresionModelo.SmallImage"), System.Drawing.Image)
        Me.btonPresionModelo.Tag = "1.3.2.5"
        Me.btonPresionModelo.Text = "Pesión Modelos"
        '
        'btonComponentes
        '
        Me.btonComponentes.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonComponentes.Image = CType(resources.GetObject("btonComponentes.Image"), System.Drawing.Image)
        Me.btonComponentes.SmallImage = CType(resources.GetObject("btonComponentes.SmallImage"), System.Drawing.Image)
        Me.btonComponentes.Tag = "1.3.2.6"
        Me.btonComponentes.Text = "Componentes"
        '
        'mnParamContratos
        '
        Me.mnParamContratos.DrawIconsBar = False
        Me.mnParamContratos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnParamContratos.DropDownItems.Add(Me.btonObjetos)
        Me.mnParamContratos.DropDownItems.Add(Me.btonPara)
        Me.mnParamContratos.DropDownItems.Add(Me.btonAseguradoras)
        Me.mnParamContratos.DropDownItems.Add(Me.btonTipoPolizas)
        Me.mnParamContratos.DropDownItems.Add(Me.btonTiposEscrituras)
        Me.mnParamContratos.DropDownItems.Add(Me.btonCamarasComercio)
        Me.mnParamContratos.DropDownItems.Add(Me.btonTipoAnticipo)
        Me.mnParamContratos.DropDownItems.Add(Me.btontipoformato)
        Me.mnParamContratos.DropDownItems.Add(Me.btonVariablesMinutas)
        Me.mnParamContratos.DropDownItems.Add(Me.btonFormatosMinutas)
        Me.mnParamContratos.FlashEnabled = True
        Me.mnParamContratos.FlashIntervall = 500
        Me.mnParamContratos.Image = CType(resources.GetObject("mnParamContratos.Image"), System.Drawing.Image)
        Me.mnParamContratos.ShowFlashImage = True
        Me.mnParamContratos.SmallImage = CType(resources.GetObject("mnParamContratos.SmallImage"), System.Drawing.Image)
        Me.mnParamContratos.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.mnParamContratos.Tag = "1.3.3"
        Me.mnParamContratos.Text = "Parámetros Contratos"
        '
        'btonObjetos
        '
        Me.btonObjetos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonObjetos.Image = CType(resources.GetObject("btonObjetos.Image"), System.Drawing.Image)
        Me.btonObjetos.SmallImage = CType(resources.GetObject("btonObjetos.SmallImage"), System.Drawing.Image)
        Me.btonObjetos.Tag = "1.2.3.1"
        Me.btonObjetos.Text = "Objetos"
        '
        'btonPara
        '
        Me.btonPara.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonPara.Image = CType(resources.GetObject("btonPara.Image"), System.Drawing.Image)
        Me.btonPara.SmallImage = CType(resources.GetObject("btonPara.SmallImage"), System.Drawing.Image)
        Me.btonPara.Tag = "1.2.3.2"
        Me.btonPara.Text = "Para"
        '
        'btonAseguradoras
        '
        Me.btonAseguradoras.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonAseguradoras.Image = CType(resources.GetObject("btonAseguradoras.Image"), System.Drawing.Image)
        Me.btonAseguradoras.SmallImage = CType(resources.GetObject("btonAseguradoras.SmallImage"), System.Drawing.Image)
        Me.btonAseguradoras.Tag = "1.2.3.3"
        Me.btonAseguradoras.Text = "Aseguradoras"
        '
        'btonTipoPolizas
        '
        Me.btonTipoPolizas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTipoPolizas.Image = CType(resources.GetObject("btonTipoPolizas.Image"), System.Drawing.Image)
        Me.btonTipoPolizas.SmallImage = CType(resources.GetObject("btonTipoPolizas.SmallImage"), System.Drawing.Image)
        Me.btonTipoPolizas.Tag = "1.2.3.4"
        Me.btonTipoPolizas.Text = "Tipo Poliza"
        '
        'btonTiposEscrituras
        '
        Me.btonTiposEscrituras.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTiposEscrituras.Image = CType(resources.GetObject("btonTiposEscrituras.Image"), System.Drawing.Image)
        Me.btonTiposEscrituras.SmallImage = CType(resources.GetObject("btonTiposEscrituras.SmallImage"), System.Drawing.Image)
        Me.btonTiposEscrituras.Tag = "1.2.3.5"
        Me.btonTiposEscrituras.Text = "Tipo Escritura"
        '
        'btonCamarasComercio
        '
        Me.btonCamarasComercio.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCamarasComercio.Image = CType(resources.GetObject("btonCamarasComercio.Image"), System.Drawing.Image)
        Me.btonCamarasComercio.SmallImage = CType(resources.GetObject("btonCamarasComercio.SmallImage"), System.Drawing.Image)
        Me.btonCamarasComercio.Tag = "1.2.3.6"
        Me.btonCamarasComercio.Text = "Camaras de Comercio"
        '
        'btonTipoAnticipo
        '
        Me.btonTipoAnticipo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTipoAnticipo.Image = CType(resources.GetObject("btonTipoAnticipo.Image"), System.Drawing.Image)
        Me.btonTipoAnticipo.SmallImage = CType(resources.GetObject("btonTipoAnticipo.SmallImage"), System.Drawing.Image)
        Me.btonTipoAnticipo.Tag = "1.2.3.7"
        Me.btonTipoAnticipo.Text = "Tipo Anticipo"
        '
        'btontipoformato
        '
        Me.btontipoformato.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btontipoformato.Image = CType(resources.GetObject("btontipoformato.Image"), System.Drawing.Image)
        Me.btontipoformato.SmallImage = CType(resources.GetObject("btontipoformato.SmallImage"), System.Drawing.Image)
        Me.btontipoformato.Text = "Tipos Formatos"
        '
        'btonVariablesMinutas
        '
        Me.btonVariablesMinutas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonVariablesMinutas.Image = CType(resources.GetObject("btonVariablesMinutas.Image"), System.Drawing.Image)
        Me.btonVariablesMinutas.SmallImage = CType(resources.GetObject("btonVariablesMinutas.SmallImage"), System.Drawing.Image)
        Me.btonVariablesMinutas.Tag = "1.2.3.8"
        Me.btonVariablesMinutas.Text = "Variables Minutas"
        '
        'btonFormatosMinutas
        '
        Me.btonFormatosMinutas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonFormatosMinutas.Image = CType(resources.GetObject("btonFormatosMinutas.Image"), System.Drawing.Image)
        Me.btonFormatosMinutas.SmallImage = CType(resources.GetObject("btonFormatosMinutas.SmallImage"), System.Drawing.Image)
        Me.btonFormatosMinutas.Tag = "1.2.3.9"
        Me.btonFormatosMinutas.Text = "Formatos Minutas"
        '
        'mnParametrosNotas
        '
        Me.mnParametrosNotas.DrawIconsBar = False
        Me.mnParametrosNotas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnParametrosNotas.DropDownItems.Add(Me.btonTiposNotas)
        Me.mnParametrosNotas.DropDownItems.Add(Me.btonEsquemaNotas)
        Me.mnParametrosNotas.DropDownItems.Add(Me.btonOrigenesNotas)
        Me.mnParametrosNotas.FlashEnabled = True
        Me.mnParametrosNotas.FlashIntervall = 500
        Me.mnParametrosNotas.Image = CType(resources.GetObject("mnParametrosNotas.Image"), System.Drawing.Image)
        Me.mnParametrosNotas.SmallImage = CType(resources.GetObject("mnParametrosNotas.SmallImage"), System.Drawing.Image)
        Me.mnParametrosNotas.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.mnParametrosNotas.Tag = "1.3.4"
        Me.mnParametrosNotas.Text = "Parámetros Notas"
        '
        'btonTiposNotas
        '
        Me.btonTiposNotas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTiposNotas.Image = CType(resources.GetObject("btonTiposNotas.Image"), System.Drawing.Image)
        Me.btonTiposNotas.SmallImage = CType(resources.GetObject("btonTiposNotas.SmallImage"), System.Drawing.Image)
        Me.btonTiposNotas.Tag = "1.2.4.1"
        Me.btonTiposNotas.Text = "Tipos de notas"
        '
        'btonEsquemaNotas
        '
        Me.btonEsquemaNotas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonEsquemaNotas.Image = CType(resources.GetObject("btonEsquemaNotas.Image"), System.Drawing.Image)
        Me.btonEsquemaNotas.SmallImage = CType(resources.GetObject("btonEsquemaNotas.SmallImage"), System.Drawing.Image)
        Me.btonEsquemaNotas.Tag = "1.2.4.2"
        Me.btonEsquemaNotas.Text = "Esquema notas"
        '
        'btonOrigenesNotas
        '
        Me.btonOrigenesNotas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonOrigenesNotas.Image = CType(resources.GetObject("btonOrigenesNotas.Image"), System.Drawing.Image)
        Me.btonOrigenesNotas.SmallImage = CType(resources.GetObject("btonOrigenesNotas.SmallImage"), System.Drawing.Image)
        Me.btonOrigenesNotas.Tag = "1.2.4.3"
        Me.btonOrigenesNotas.Text = "Orígenes notas"
        '
        'mnParametrosCotizaciones
        '
        Me.mnParametrosCotizaciones.DrawIconsBar = False
        Me.mnParametrosCotizaciones.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonDirectores)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonVendedores)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonFactores)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonFormasPago)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonImpuestos)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonInstalacion)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonParametrosAIU)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonTiempoEntrega)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonTiposIdentificacion)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonTipoObra)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonVigencias)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonCondiciones)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonGruposCondiciones)
        Me.mnParametrosCotizaciones.DropDownItems.Add(Me.btonDuracionDuplicacion)
        Me.mnParametrosCotizaciones.FlashEnabled = True
        Me.mnParametrosCotizaciones.FlashIntervall = 500
        Me.mnParametrosCotizaciones.Image = CType(resources.GetObject("mnParametrosCotizaciones.Image"), System.Drawing.Image)
        Me.mnParametrosCotizaciones.SmallImage = CType(resources.GetObject("mnParametrosCotizaciones.SmallImage"), System.Drawing.Image)
        Me.mnParametrosCotizaciones.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.mnParametrosCotizaciones.Tag = "1.3.5"
        Me.mnParametrosCotizaciones.Text = "Parámetros Cotizaciones"
        '
        'btonDirectores
        '
        Me.btonDirectores.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonDirectores.Image = CType(resources.GetObject("btonDirectores.Image"), System.Drawing.Image)
        Me.btonDirectores.SmallImage = CType(resources.GetObject("btonDirectores.SmallImage"), System.Drawing.Image)
        Me.btonDirectores.Tag = "1.2.5.1"
        Me.btonDirectores.Text = "Directores"
        Me.btonDirectores.ToolTip = "Agrega directores de ventas"
        '
        'btonVendedores
        '
        Me.btonVendedores.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonVendedores.Image = CType(resources.GetObject("btonVendedores.Image"), System.Drawing.Image)
        Me.btonVendedores.SmallImage = CType(resources.GetObject("btonVendedores.SmallImage"), System.Drawing.Image)
        Me.btonVendedores.Tag = "1.2.5.2"
        Me.btonVendedores.Text = "Vendedores"
        Me.btonVendedores.ToolTip = "Agrega asesores comerciales para disponibilidad en la plantilla de cotizaciones."
        '
        'btonFactores
        '
        Me.btonFactores.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonFactores.Image = CType(resources.GetObject("btonFactores.Image"), System.Drawing.Image)
        Me.btonFactores.SmallImage = CType(resources.GetObject("btonFactores.SmallImage"), System.Drawing.Image)
        Me.btonFactores.Tag = "1.2.5.3"
        Me.btonFactores.Text = "Factores"
        Me.btonFactores.ToolTip = "Adiciona factores de utilidad a la plantilla de cotizaciones."
        '
        'btonFormasPago
        '
        Me.btonFormasPago.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonFormasPago.Image = CType(resources.GetObject("btonFormasPago.Image"), System.Drawing.Image)
        Me.btonFormasPago.SmallImage = CType(resources.GetObject("btonFormasPago.SmallImage"), System.Drawing.Image)
        Me.btonFormasPago.Tag = "1.2.5.4"
        Me.btonFormasPago.Text = "Formas de Pago"
        Me.btonFormasPago.ToolTip = "Adiciona, modifica e inactiva condiciones de pago que estaran disponibles en la p" &
    "lantilla de cotizaciones."
        '
        'btonImpuestos
        '
        Me.btonImpuestos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonImpuestos.Image = CType(resources.GetObject("btonImpuestos.Image"), System.Drawing.Image)
        Me.btonImpuestos.SmallImage = CType(resources.GetObject("btonImpuestos.SmallImage"), System.Drawing.Image)
        Me.btonImpuestos.Tag = "1.2.5.5"
        Me.btonImpuestos.Text = "Impuestos"
        Me.btonImpuestos.ToolTip = "Adiciona tasa de impuesto a los desplegables de las plantillas de cotización."
        '
        'btonInstalacion
        '
        Me.btonInstalacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonInstalacion.Image = CType(resources.GetObject("btonInstalacion.Image"), System.Drawing.Image)
        Me.btonInstalacion.SmallImage = CType(resources.GetObject("btonInstalacion.SmallImage"), System.Drawing.Image)
        Me.btonInstalacion.Tag = "1.2.5.6"
        Me.btonInstalacion.Text = "Instalación"
        Me.btonInstalacion.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right
        Me.btonInstalacion.ToolTip = "Adiciona, modifica e inactiva valores para el cobro de la instalación en la plant" &
    "illa de cotización."
        '
        'btonParametrosAIU
        '
        Me.btonParametrosAIU.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonParametrosAIU.Image = CType(resources.GetObject("btonParametrosAIU.Image"), System.Drawing.Image)
        Me.btonParametrosAIU.SmallImage = CType(resources.GetObject("btonParametrosAIU.SmallImage"), System.Drawing.Image)
        Me.btonParametrosAIU.Tag = "1.2.5.7"
        Me.btonParametrosAIU.Text = "A.I.U"
        Me.btonParametrosAIU.ToolTip = "Defina los parámetros que seran utilizados para las cotizaciones a las que se les" &
    " deba aplicar el A.I.U."
        '
        'btonTiempoEntrega
        '
        Me.btonTiempoEntrega.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTiempoEntrega.Image = CType(resources.GetObject("btonTiempoEntrega.Image"), System.Drawing.Image)
        Me.btonTiempoEntrega.SmallImage = CType(resources.GetObject("btonTiempoEntrega.SmallImage"), System.Drawing.Image)
        Me.btonTiempoEntrega.Tag = "1.2.5.8"
        Me.btonTiempoEntrega.Text = "Tiempos de Entrega"
        Me.btonTiempoEntrega.ToolTip = "Adiciona, Modifica e inactiva los tiempos de entrega que aparecerán en los desple" &
    "gables de la plantilla de cotizaciones."
        '
        'btonTiposIdentificacion
        '
        Me.btonTiposIdentificacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTiposIdentificacion.Image = CType(resources.GetObject("btonTiposIdentificacion.Image"), System.Drawing.Image)
        Me.btonTiposIdentificacion.SmallImage = CType(resources.GetObject("btonTiposIdentificacion.SmallImage"), System.Drawing.Image)
        Me.btonTiposIdentificacion.Tag = "1.2.5.9"
        Me.btonTiposIdentificacion.Text = "Tipos de Identificación"
        Me.btonTiposIdentificacion.ToolTip = "Adición, modifición e inactivación de los tipos de identificación que aparecerán " &
    "en los desplegables de la plantilla de cotización."
        '
        'btonTipoObra
        '
        Me.btonTipoObra.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonTipoObra.Image = CType(resources.GetObject("btonTipoObra.Image"), System.Drawing.Image)
        Me.btonTipoObra.SmallImage = CType(resources.GetObject("btonTipoObra.SmallImage"), System.Drawing.Image)
        Me.btonTipoObra.Tag = "1.2.5.10"
        Me.btonTipoObra.Text = "Tipos de Obra"
        Me.btonTipoObra.ToolTip = "Adiciona, Modifica e inativa los tipos de obra que podrán aparecer en los despleg" &
    "ables de plantilla de cotización."
        '
        'btonVigencias
        '
        Me.btonVigencias.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonVigencias.Image = CType(resources.GetObject("btonVigencias.Image"), System.Drawing.Image)
        Me.btonVigencias.SmallImage = CType(resources.GetObject("btonVigencias.SmallImage"), System.Drawing.Image)
        Me.btonVigencias.Tag = "1.2.5.11"
        Me.btonVigencias.Text = "Vigencias Cotizaciones"
        Me.btonVigencias.ToolTip = "Adiciona, modifica e inactiva las  vigencias que aparecerán disponibles en la pla" &
    "ntilla de cotizaciones."
        '
        'btonCondiciones
        '
        Me.btonCondiciones.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCondiciones.Image = CType(resources.GetObject("btonCondiciones.Image"), System.Drawing.Image)
        Me.btonCondiciones.SmallImage = CType(resources.GetObject("btonCondiciones.SmallImage"), System.Drawing.Image)
        Me.btonCondiciones.Tag = "1.2.5.12"
        Me.btonCondiciones.Text = "Condiciones"
        Me.btonCondiciones.ToolTip = "Agrega condiones nuevas asociadas a un grupo de condiciones"
        '
        'btonGruposCondiciones
        '
        Me.btonGruposCondiciones.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonGruposCondiciones.Image = CType(resources.GetObject("btonGruposCondiciones.Image"), System.Drawing.Image)
        Me.btonGruposCondiciones.SmallImage = CType(resources.GetObject("btonGruposCondiciones.SmallImage"), System.Drawing.Image)
        Me.btonGruposCondiciones.Tag = "1.2.5.13"
        Me.btonGruposCondiciones.Text = "Grupos de condiciones"
        Me.btonGruposCondiciones.ToolTip = "Adiciona grupo nuevo a condiciones comerciales"
        '
        'btonDuracionDuplicacion
        '
        Me.btonDuracionDuplicacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonDuracionDuplicacion.Image = CType(resources.GetObject("btonDuracionDuplicacion.Image"), System.Drawing.Image)
        Me.btonDuracionDuplicacion.SmallImage = CType(resources.GetObject("btonDuracionDuplicacion.SmallImage"), System.Drawing.Image)
        Me.btonDuracionDuplicacion.Tag = "1.2.5.14"
        Me.btonDuracionDuplicacion.Text = "Duración para duplicación"
        Me.btonDuracionDuplicacion.ToolTip = "Tiempo máximo para duplicar las cotizaciones realizadas"
        '
        'mnParametrosInstalacion
        '
        Me.mnParametrosInstalacion.DrawIconsBar = False
        Me.mnParametrosInstalacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.mnParametrosInstalacion.DropDownItems.Add(Me.btnProveedores)
        Me.mnParametrosInstalacion.DropDownItems.Add(Me.btnEncargados)
        Me.mnParametrosInstalacion.DropDownItems.Add(Me.btnConceptos)
        Me.mnParametrosInstalacion.DropDownItems.Add(Me.btnListaPrecios)
        Me.mnParametrosInstalacion.DropDownItems.Add(Me.btnTiposCuentas)
        Me.mnParametrosInstalacion.DropDownItems.Add(Me.btnTiposOrdenesTrabajo)
        Me.mnParametrosInstalacion.DropDownItems.Add(Me.btnDocumentos)
        Me.mnParametrosInstalacion.FlashEnabled = True
        Me.mnParametrosInstalacion.FlashIntervall = 500
        Me.mnParametrosInstalacion.Image = CType(resources.GetObject("mnParametrosInstalacion.Image"), System.Drawing.Image)
        Me.mnParametrosInstalacion.ShowFlashImage = True
        Me.mnParametrosInstalacion.SmallImage = CType(resources.GetObject("mnParametrosInstalacion.SmallImage"), System.Drawing.Image)
        Me.mnParametrosInstalacion.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.mnParametrosInstalacion.Tag = "1.3.6"
        Me.mnParametrosInstalacion.Text = "Parámetros instalacion"
        '
        'btnProveedores
        '
        Me.btnProveedores.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnProveedores.Image = CType(resources.GetObject("btnProveedores.Image"), System.Drawing.Image)
        Me.btnProveedores.SmallImage = CType(resources.GetObject("btnProveedores.SmallImage"), System.Drawing.Image)
        Me.btnProveedores.Tag = "1.3.6.1"
        Me.btnProveedores.Text = "Proveedores"
        '
        'btnEncargados
        '
        Me.btnEncargados.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnEncargados.Image = CType(resources.GetObject("btnEncargados.Image"), System.Drawing.Image)
        Me.btnEncargados.SmallImage = CType(resources.GetObject("btnEncargados.SmallImage"), System.Drawing.Image)
        Me.btnEncargados.Tag = "1.3.6.2"
        Me.btnEncargados.Text = "Encargados"
        '
        'btnConceptos
        '
        Me.btnConceptos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnConceptos.Image = CType(resources.GetObject("btnConceptos.Image"), System.Drawing.Image)
        Me.btnConceptos.SmallImage = CType(resources.GetObject("btnConceptos.SmallImage"), System.Drawing.Image)
        Me.btnConceptos.Tag = "1.3.6.3"
        Me.btnConceptos.Text = "Conceptos"
        '
        'btnListaPrecios
        '
        Me.btnListaPrecios.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnListaPrecios.Image = CType(resources.GetObject("btnListaPrecios.Image"), System.Drawing.Image)
        Me.btnListaPrecios.SmallImage = CType(resources.GetObject("btnListaPrecios.SmallImage"), System.Drawing.Image)
        Me.btnListaPrecios.Tag = "1.3.6.4"
        Me.btnListaPrecios.Text = "Lista de precios"
        '
        'btnTiposCuentas
        '
        Me.btnTiposCuentas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnTiposCuentas.Image = CType(resources.GetObject("btnTiposCuentas.Image"), System.Drawing.Image)
        Me.btnTiposCuentas.SmallImage = CType(resources.GetObject("btnTiposCuentas.SmallImage"), System.Drawing.Image)
        Me.btnTiposCuentas.Tag = "1.3.6.5"
        Me.btnTiposCuentas.Text = "Tipos de cuentas"
        '
        'btnTiposOrdenesTrabajo
        '
        Me.btnTiposOrdenesTrabajo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnTiposOrdenesTrabajo.Image = CType(resources.GetObject("btnTiposOrdenesTrabajo.Image"), System.Drawing.Image)
        Me.btnTiposOrdenesTrabajo.SmallImage = CType(resources.GetObject("btnTiposOrdenesTrabajo.SmallImage"), System.Drawing.Image)
        Me.btnTiposOrdenesTrabajo.Tag = "1.3.6.6"
        Me.btnTiposOrdenesTrabajo.Text = "Tipos ordenes de trabajo"
        '
        'btnDocumentos
        '
        Me.btnDocumentos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnDocumentos.Image = CType(resources.GetObject("btnDocumentos.Image"), System.Drawing.Image)
        Me.btnDocumentos.SmallImage = CType(resources.GetObject("btnDocumentos.SmallImage"), System.Drawing.Image)
        Me.btnDocumentos.Tag = "1.3.6.7"
        Me.btnDocumentos.Text = "Documentos"
        '
        'prmProduccion
        '
        Me.prmProduccion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.prmProduccion.DropDownItems.Add(Me.rbtgenerales)
        Me.prmProduccion.DropDownItems.Add(Me.rbtcalidad)
        Me.prmProduccion.Image = CType(resources.GetObject("prmProduccion.Image"), System.Drawing.Image)
        Me.prmProduccion.SmallImage = CType(resources.GetObject("prmProduccion.SmallImage"), System.Drawing.Image)
        Me.prmProduccion.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.prmProduccion.Tag = "1.4"
        Me.prmProduccion.Text = "Parámetros Producción"
        '
        'rbtgenerales
        '
        Me.rbtgenerales.DrawIconsBar = False
        Me.rbtgenerales.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbtgenerales.DropDownItems.Add(Me.btnTercerosProduccion)
        Me.rbtgenerales.DropDownItems.Add(Me.btnMotivosDevolucionOP)
        Me.rbtgenerales.Image = CType(resources.GetObject("rbtgenerales.Image"), System.Drawing.Image)
        Me.rbtgenerales.SmallImage = CType(resources.GetObject("rbtgenerales.SmallImage"), System.Drawing.Image)
        Me.rbtgenerales.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbtgenerales.Tag = "1.4.1"
        Me.rbtgenerales.Text = "Generales"
        '
        'btnTercerosProduccion
        '
        Me.btnTercerosProduccion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnTercerosProduccion.Image = CType(resources.GetObject("btnTercerosProduccion.Image"), System.Drawing.Image)
        Me.btnTercerosProduccion.SmallImage = CType(resources.GetObject("btnTercerosProduccion.SmallImage"), System.Drawing.Image)
        Me.btnTercerosProduccion.Text = "Terceros producción"
        '
        'btnMotivosDevolucionOP
        '
        Me.btnMotivosDevolucionOP.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnMotivosDevolucionOP.Image = CType(resources.GetObject("btnMotivosDevolucionOP.Image"), System.Drawing.Image)
        Me.btnMotivosDevolucionOP.SmallImage = CType(resources.GetObject("btnMotivosDevolucionOP.SmallImage"), System.Drawing.Image)
        Me.btnMotivosDevolucionOP.Text = "Motivos devolución OP"
        '
        'rbtcalidad
        '
        Me.rbtcalidad.DrawIconsBar = False
        Me.rbtcalidad.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbtcalidad.DropDownItems.Add(Me.btnSecciones)
        Me.rbtcalidad.DropDownItems.Add(Me.btnMotivosxSeccion)
        Me.rbtcalidad.DropDownItems.Add(Me.btnCausas)
        Me.rbtcalidad.DropDownItems.Add(Me.btnMotivosxCausa)
        Me.rbtcalidad.DropDownItems.Add(Me.btnDestinatarios)
        Me.rbtcalidad.Image = CType(resources.GetObject("rbtcalidad.Image"), System.Drawing.Image)
        Me.rbtcalidad.SmallImage = CType(resources.GetObject("rbtcalidad.SmallImage"), System.Drawing.Image)
        Me.rbtcalidad.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbtcalidad.Tag = "1.4.2"
        Me.rbtcalidad.Text = "Calidad"
        '
        'btnSecciones
        '
        Me.btnSecciones.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnSecciones.Image = CType(resources.GetObject("btnSecciones.Image"), System.Drawing.Image)
        Me.btnSecciones.SmallImage = CType(resources.GetObject("btnSecciones.SmallImage"), System.Drawing.Image)
        Me.btnSecciones.Text = "Secciones"
        '
        'btnMotivosxSeccion
        '
        Me.btnMotivosxSeccion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnMotivosxSeccion.Image = CType(resources.GetObject("btnMotivosxSeccion.Image"), System.Drawing.Image)
        Me.btnMotivosxSeccion.SmallImage = CType(resources.GetObject("btnMotivosxSeccion.SmallImage"), System.Drawing.Image)
        Me.btnMotivosxSeccion.Text = "Motivos por secciones"
        '
        'btnCausas
        '
        Me.btnCausas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnCausas.Image = CType(resources.GetObject("btnCausas.Image"), System.Drawing.Image)
        Me.btnCausas.SmallImage = CType(resources.GetObject("btnCausas.SmallImage"), System.Drawing.Image)
        Me.btnCausas.Text = "Causas"
        '
        'btnMotivosxCausa
        '
        Me.btnMotivosxCausa.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnMotivosxCausa.Image = CType(resources.GetObject("btnMotivosxCausa.Image"), System.Drawing.Image)
        Me.btnMotivosxCausa.SmallImage = CType(resources.GetObject("btnMotivosxCausa.SmallImage"), System.Drawing.Image)
        Me.btnMotivosxCausa.Text = "Motivos por causas"
        '
        'btnDestinatarios
        '
        Me.btnDestinatarios.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnDestinatarios.Image = CType(resources.GetObject("btnDestinatarios.Image"), System.Drawing.Image)
        Me.btnDestinatarios.SmallImage = CType(resources.GetObject("btnDestinatarios.SmallImage"), System.Drawing.Image)
        Me.btnDestinatarios.Text = "Destinatarios"
        '
        'prmseguridad
        '
        Me.prmseguridad.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.prmseguridad.DropDownItems.Add(Me.btndepartamentos)
        Me.prmseguridad.DropDownItems.Add(Me.btnusuarios)
        Me.prmseguridad.DropDownItems.Add(Me.btngrupos)
        Me.prmseguridad.DropDownItems.Add(Me.btnpermisos)
        Me.prmseguridad.DropDownItems.Add(Me.btnpermisosextra)
        Me.prmseguridad.Image = CType(resources.GetObject("prmseguridad.Image"), System.Drawing.Image)
        Me.prmseguridad.SmallImage = CType(resources.GetObject("prmseguridad.SmallImage"), System.Drawing.Image)
        Me.prmseguridad.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.prmseguridad.Tag = "1.5"
        Me.prmseguridad.Text = "Parámetros Seguridad"
        '
        'btndepartamentos
        '
        Me.btndepartamentos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btndepartamentos.Image = CType(resources.GetObject("btndepartamentos.Image"), System.Drawing.Image)
        Me.btndepartamentos.SmallImage = CType(resources.GetObject("btndepartamentos.SmallImage"), System.Drawing.Image)
        Me.btndepartamentos.Tag = "1.5.1"
        Me.btndepartamentos.Text = "Departamentos"
        '
        'btnusuarios
        '
        Me.btnusuarios.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnusuarios.Image = CType(resources.GetObject("btnusuarios.Image"), System.Drawing.Image)
        Me.btnusuarios.SmallImage = CType(resources.GetObject("btnusuarios.SmallImage"), System.Drawing.Image)
        Me.btnusuarios.Tag = "1.5.2"
        Me.btnusuarios.Text = "Usuarios"
        '
        'btngrupos
        '
        Me.btngrupos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btngrupos.Image = CType(resources.GetObject("btngrupos.Image"), System.Drawing.Image)
        Me.btngrupos.SmallImage = CType(resources.GetObject("btngrupos.SmallImage"), System.Drawing.Image)
        Me.btngrupos.Tag = "1.5.3"
        Me.btngrupos.Text = "Grupos"
        '
        'btnpermisos
        '
        Me.btnpermisos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnpermisos.Image = CType(resources.GetObject("btnpermisos.Image"), System.Drawing.Image)
        Me.btnpermisos.SmallImage = CType(resources.GetObject("btnpermisos.SmallImage"), System.Drawing.Image)
        Me.btnpermisos.Tag = "1.5.4"
        Me.btnpermisos.Text = "Permisos"
        '
        'btnpermisosextra
        '
        Me.btnpermisosextra.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnpermisosextra.Image = CType(resources.GetObject("btnpermisosextra.Image"), System.Drawing.Image)
        Me.btnpermisosextra.SmallImage = CType(resources.GetObject("btnpermisosextra.SmallImage"), System.Drawing.Image)
        Me.btnpermisosextra.Tag = "1.5.5"
        Me.btnpermisosextra.Text = "Permisos Extra"
        '
        'btonCerrar
        '
        Me.btonCerrar.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btonCerrar.Image = CType(resources.GetObject("btonCerrar.Image"), System.Drawing.Image)
        Me.btonCerrar.SmallImage = CType(resources.GetObject("btonCerrar.SmallImage"), System.Drawing.Image)
        Me.btonCerrar.Text = "Cerrar"
        '
        'btnmodulos
        '
        Me.btnmodulos.DropDownItems.Add(Me.btnfinanciero)
        Me.btnmodulos.DropDownItems.Add(Me.btncomercial)
        Me.btnmodulos.DropDownItems.Add(Me.btnmanufactura)
        Me.btnmodulos.DropDownItems.Add(Me.btnplaneacion)
        Me.btnmodulos.Image = CType(resources.GetObject("btnmodulos.Image"), System.Drawing.Image)
        Me.btnmodulos.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.btnmodulos.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium
        Me.btnmodulos.SmallImage = CType(resources.GetObject("btnmodulos.SmallImage"), System.Drawing.Image)
        Me.btnmodulos.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.btnmodulos.Tag = "0.1"
        Me.btnmodulos.Text = "Módulos"
        '
        'btnfinanciero
        '
        Me.btnfinanciero.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnfinanciero.Image = CType(resources.GetObject("btnfinanciero.Image"), System.Drawing.Image)
        Me.btnfinanciero.SmallImage = CType(resources.GetObject("btnfinanciero.SmallImage"), System.Drawing.Image)
        Me.btnfinanciero.Tag = "0.1.1"
        Me.btnfinanciero.Text = "Financiero"
        '
        'btncomercial
        '
        Me.btncomercial.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btncomercial.Image = CType(resources.GetObject("btncomercial.Image"), System.Drawing.Image)
        Me.btncomercial.SmallImage = CType(resources.GetObject("btncomercial.SmallImage"), System.Drawing.Image)
        Me.btncomercial.Tag = "0.1.2"
        Me.btncomercial.Text = "Comercial"
        '
        'btnmanufactura
        '
        Me.btnmanufactura.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnmanufactura.Image = CType(resources.GetObject("btnmanufactura.Image"), System.Drawing.Image)
        Me.btnmanufactura.SmallImage = CType(resources.GetObject("btnmanufactura.SmallImage"), System.Drawing.Image)
        Me.btnmanufactura.Tag = "0.1.3"
        Me.btnmanufactura.Text = "Manufactura"
        '
        'btnplaneacion
        '
        Me.btnplaneacion.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnplaneacion.Image = CType(resources.GetObject("btnplaneacion.Image"), System.Drawing.Image)
        Me.btnplaneacion.SmallImage = CType(resources.GetObject("btnplaneacion.SmallImage"), System.Drawing.Image)
        Me.btnplaneacion.Tag = "0.1.4"
        Me.btnplaneacion.Text = "Planeación"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.btnLimpiar.SmallImage = CType(resources.GetObject("btnLimpiar.SmallImage"), System.Drawing.Image)
        Me.btnLimpiar.Tag = "0.2"
        Me.btnLimpiar.Text = "Limpiar"
        '
        'btnrecargar
        '
        Me.btnrecargar.Image = CType(resources.GetObject("btnrecargar.Image"), System.Drawing.Image)
        Me.btnrecargar.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.btnrecargar.SmallImage = CType(resources.GetObject("btnrecargar.SmallImage"), System.Drawing.Image)
        Me.btnrecargar.Tag = "0.3"
        Me.btnrecargar.Text = "Referescar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DropDownItems.Add(Me.btnguardarParcial)
        Me.btnGuardar.DropDownItems.Add(Me.btnGuardarTotal)
        Me.btnGuardar.DropDownResizable = True
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.btnGuardar.SmallImage = CType(resources.GetObject("btnGuardar.SmallImage"), System.Drawing.Image)
        Me.btnGuardar.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown
        Me.btnGuardar.Tag = "0.4"
        Me.btnGuardar.Text = "Guardar"
        '
        'btnguardarParcial
        '
        Me.btnguardarParcial.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnguardarParcial.Image = CType(resources.GetObject("btnguardarParcial.Image"), System.Drawing.Image)
        Me.btnguardarParcial.SmallImage = CType(resources.GetObject("btnguardarParcial.SmallImage"), System.Drawing.Image)
        Me.btnguardarParcial.Tag = "0.4.1"
        Me.btnguardarParcial.Text = "Guardar Parcial"
        '
        'btnGuardarTotal
        '
        Me.btnGuardarTotal.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnGuardarTotal.Image = CType(resources.GetObject("btnGuardarTotal.Image"), System.Drawing.Image)
        Me.btnGuardarTotal.SmallImage = CType(resources.GetObject("btnGuardarTotal.SmallImage"), System.Drawing.Image)
        Me.btnGuardarTotal.Tag = "0.4.2"
        Me.btnGuardarTotal.Text = "Guardar Total"
        '
        'btnimpresion
        '
        Me.btnimpresion.DropDownItems.Add(Me.btnimprimir)
        Me.btnimpresion.DropDownItems.Add(Me.btnvistaprevia)
        Me.btnimpresion.Image = CType(resources.GetObject("btnimpresion.Image"), System.Drawing.Image)
        Me.btnimpresion.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.btnimpresion.SmallImage = CType(resources.GetObject("btnimpresion.SmallImage"), System.Drawing.Image)
        Me.btnimpresion.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown
        Me.btnimpresion.Tag = "0.5"
        Me.btnimpresion.Text = "Impresión"
        '
        'btnimprimir
        '
        Me.btnimprimir.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnimprimir.Image = CType(resources.GetObject("btnimprimir.Image"), System.Drawing.Image)
        Me.btnimprimir.SmallImage = CType(resources.GetObject("btnimprimir.SmallImage"), System.Drawing.Image)
        Me.btnimprimir.Tag = "0.5.1"
        Me.btnimprimir.Text = "Imprimir"
        '
        'btnvistaprevia
        '
        Me.btnvistaprevia.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnvistaprevia.Image = CType(resources.GetObject("btnvistaprevia.Image"), System.Drawing.Image)
        Me.btnvistaprevia.SmallImage = CType(resources.GetObject("btnvistaprevia.SmallImage"), System.Drawing.Image)
        Me.btnvistaprevia.Tag = "0.5.2"
        Me.btnvistaprevia.Text = "Vista Previa"
        '
        'btnexportar
        '
        Me.btnexportar.DropDownItems.Add(Me.btnexportarExcel)
        Me.btnexportar.DropDownItems.Add(Me.btnExportarPdf)
        Me.btnexportar.DropDownItems.Add(Me.btnexportarword)
        Me.btnexportar.Image = CType(resources.GetObject("btnexportar.Image"), System.Drawing.Image)
        Me.btnexportar.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.btnexportar.SmallImage = CType(resources.GetObject("btnexportar.SmallImage"), System.Drawing.Image)
        Me.btnexportar.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown
        Me.btnexportar.Tag = "0.6"
        Me.btnexportar.Text = "Exportar"
        '
        'btnexportarExcel
        '
        Me.btnexportarExcel.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnexportarExcel.Image = CType(resources.GetObject("btnexportarExcel.Image"), System.Drawing.Image)
        Me.btnexportarExcel.SmallImage = CType(resources.GetObject("btnexportarExcel.SmallImage"), System.Drawing.Image)
        Me.btnexportarExcel.Tag = "0.6.1"
        Me.btnexportarExcel.Text = "Excel"
        '
        'btnExportarPdf
        '
        Me.btnExportarPdf.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnExportarPdf.Image = CType(resources.GetObject("btnExportarPdf.Image"), System.Drawing.Image)
        Me.btnExportarPdf.SmallImage = CType(resources.GetObject("btnExportarPdf.SmallImage"), System.Drawing.Image)
        Me.btnExportarPdf.Tag = "0.6.2"
        Me.btnExportarPdf.Text = "PDF"
        '
        'btnexportarword
        '
        Me.btnexportarword.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.btnexportarword.Image = CType(resources.GetObject("btnexportarword.Image"), System.Drawing.Image)
        Me.btnexportarword.SmallImage = CType(resources.GetObject("btnexportarword.SmallImage"), System.Drawing.Image)
        Me.btnexportarword.Tag = "0.6.3"
        Me.btnexportarword.Text = "Word"
        '
        'rbconsola
        '
        Me.rbconsola.CheckOnClick = True
        Me.rbconsola.Image = CType(resources.GetObject("rbconsola.Image"), System.Drawing.Image)
        Me.rbconsola.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.rbconsola.SmallImage = CType(resources.GetObject("rbconsola.SmallImage"), System.Drawing.Image)
        '
        'btonpermisos
        '
        Me.btonpermisos.Image = CType(resources.GetObject("btonpermisos.Image"), System.Drawing.Image)
        Me.btonpermisos.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.btonpermisos.SmallImage = CType(resources.GetObject("btonpermisos.SmallImage"), System.Drawing.Image)
        Me.btonpermisos.Text = "RibbonButton1"
        '
        'tbventas
        '
        Me.tbventas.Panels.Add(Me.rpcotizaciones)
        Me.tbventas.Panels.Add(Me.rppedidos)
        Me.tbventas.Panels.Add(Me.rpReposiciones)
        Me.tbventas.Panels.Add(Me.rpProblemasProduccionVentas)
        Me.tbventas.Tag = "2"
        Me.tbventas.Text = "Ventas"
        '
        'rpcotizaciones
        '
        Me.rpcotizaciones.Items.Add(Me.btnGeneraCotizaciones)
        Me.rpcotizaciones.Items.Add(Me.btnVerCotizaciones)
        Me.rpcotizaciones.Tag = "2.1"
        Me.rpcotizaciones.Text = "Presupuestos"
        '
        'btnGeneraCotizaciones
        '
        Me.btnGeneraCotizaciones.Image = CType(resources.GetObject("btnGeneraCotizaciones.Image"), System.Drawing.Image)
        Me.btnGeneraCotizaciones.SmallImage = CType(resources.GetObject("btnGeneraCotizaciones.SmallImage"), System.Drawing.Image)
        Me.btnGeneraCotizaciones.Tag = "2.1.1"
        Me.btnGeneraCotizaciones.Text = "Nuevo"
        Me.btnGeneraCotizaciones.ToolTip = "Crea una nueva cotización en la ultima versión de costos disponible"
        '
        'btnVerCotizaciones
        '
        Me.btnVerCotizaciones.Image = CType(resources.GetObject("btnVerCotizaciones.Image"), System.Drawing.Image)
        Me.btnVerCotizaciones.SmallImage = CType(resources.GetObject("btnVerCotizaciones.SmallImage"), System.Drawing.Image)
        Me.btnVerCotizaciones.Tag = "2.1.2"
        Me.btnVerCotizaciones.Text = "Listar"
        Me.btnVerCotizaciones.ToolTip = "Trae un listado las cotizaciones disponibles para modificaciones, duplicados etc." &
    ""
        '
        'rppedidos
        '
        Me.rppedidos.Items.Add(Me.btngenerarordenpedido)
        Me.rppedidos.Items.Add(Me.btnlistaordenespedido)
        Me.rppedidos.Tag = "2.2"
        Me.rppedidos.Text = "Pedidos de Producción"
        '
        'btngenerarordenpedido
        '
        Me.btngenerarordenpedido.Image = CType(resources.GetObject("btngenerarordenpedido.Image"), System.Drawing.Image)
        Me.btngenerarordenpedido.SmallImage = CType(resources.GetObject("btngenerarordenpedido.SmallImage"), System.Drawing.Image)
        Me.btngenerarordenpedido.Tag = "2.2.1"
        Me.btngenerarordenpedido.Text = "Generar Orden"
        Me.btngenerarordenpedido.ToolTip = "Genera las ordenes de pedido que posteriormente a su aprobación por el cliente, s" &
    "erán producidas."
        Me.btngenerarordenpedido.ToolTipTitle = "Descripción."
        '
        'btnlistaordenespedido
        '
        Me.btnlistaordenespedido.Image = CType(resources.GetObject("btnlistaordenespedido.Image"), System.Drawing.Image)
        Me.btnlistaordenespedido.SmallImage = CType(resources.GetObject("btnlistaordenespedido.SmallImage"), System.Drawing.Image)
        Me.btnlistaordenespedido.Tag = "2.2.2"
        Me.btnlistaordenespedido.Text = "Lista"
        '
        'rpReposiciones
        '
        Me.rpReposiciones.Items.Add(Me.btnRepFacturables)
        Me.rpReposiciones.Items.Add(Me.btnRepNoFacturables)
        Me.rpReposiciones.Items.Add(Me.btnBuscarxVendedor)
        Me.rpReposiciones.Tag = "2.3"
        Me.rpReposiciones.Text = "Reposiciones"
        '
        'btnRepFacturables
        '
        Me.btnRepFacturables.Image = CType(resources.GetObject("btnRepFacturables.Image"), System.Drawing.Image)
        Me.btnRepFacturables.SmallImage = CType(resources.GetObject("btnRepFacturables.SmallImage"), System.Drawing.Image)
        Me.btnRepFacturables.Tag = "2.3.1"
        Me.btnRepFacturables.Text = "Facturables"
        Me.btnRepFacturables.ToolTip = "Permite crear una nueva reposición facturable"
        '
        'btnRepNoFacturables
        '
        Me.btnRepNoFacturables.Image = CType(resources.GetObject("btnRepNoFacturables.Image"), System.Drawing.Image)
        Me.btnRepNoFacturables.SmallImage = CType(resources.GetObject("btnRepNoFacturables.SmallImage"), System.Drawing.Image)
        Me.btnRepNoFacturables.Tag = "2.3.2"
        Me.btnRepNoFacturables.Text = "No facturables"
        Me.btnRepNoFacturables.ToolTip = "Permite crear una nueva reposición no facturable."
        '
        'btnBuscarxVendedor
        '
        Me.btnBuscarxVendedor.Image = CType(resources.GetObject("btnBuscarxVendedor.Image"), System.Drawing.Image)
        Me.btnBuscarxVendedor.SmallImage = CType(resources.GetObject("btnBuscarxVendedor.SmallImage"), System.Drawing.Image)
        Me.btnBuscarxVendedor.Tag = "2.3.3"
        Me.btnBuscarxVendedor.Text = "Buscar por vendedor"
        '
        'rpProblemasProduccionVentas
        '
        Me.rpProblemasProduccionVentas.Items.Add(Me.btnregistrodeproblemas)
        Me.rpProblemasProduccionVentas.Items.Add(Me.btnlistaproblemas)
        Me.rpProblemasProduccionVentas.Tag = "2.4"
        Me.rpProblemasProduccionVentas.Text = "Problemas de producción"
        '
        'btnregistrodeproblemas
        '
        Me.btnregistrodeproblemas.Image = CType(resources.GetObject("btnregistrodeproblemas.Image"), System.Drawing.Image)
        Me.btnregistrodeproblemas.SmallImage = CType(resources.GetObject("btnregistrodeproblemas.SmallImage"), System.Drawing.Image)
        Me.btnregistrodeproblemas.Tag = "2.4.1"
        Me.btnregistrodeproblemas.Text = "Registro problemas"
        '
        'btnlistaproblemas
        '
        Me.btnlistaproblemas.Image = CType(resources.GetObject("btnlistaproblemas.Image"), System.Drawing.Image)
        Me.btnlistaproblemas.SmallImage = CType(resources.GetObject("btnlistaproblemas.SmallImage"), System.Drawing.Image)
        Me.btnlistaproblemas.Tag = "2.4.2"
        Me.btnlistaproblemas.Text = "Lista problemas"
        '
        'tbcontratos
        '
        Me.tbcontratos.Panels.Add(Me.pnelContratos)
        Me.tbcontratos.Panels.Add(Me.rpNotasCobro)
        Me.tbcontratos.Panels.Add(Me.rpPolizas)
        Me.tbcontratos.Panels.Add(Me.rpPlaneacion)
        Me.tbcontratos.Tag = "3"
        Me.tbcontratos.Text = "Contratos"
        '
        'pnelContratos
        '
        Me.pnelContratos.Items.Add(Me.btonlapendientecontrato)
        Me.pnelContratos.Items.Add(Me.btonListaContratos)
        Me.pnelContratos.Tag = "3.1"
        Me.pnelContratos.Text = "Contratación"
        '
        'btonlapendientecontrato
        '
        Me.btonlapendientecontrato.Image = CType(resources.GetObject("btonlapendientecontrato.Image"), System.Drawing.Image)
        Me.btonlapendientecontrato.SmallImage = CType(resources.GetObject("btonlapendientecontrato.SmallImage"), System.Drawing.Image)
        Me.btonlapendientecontrato.Tag = "3.1.1"
        Me.btonlapendientecontrato.Text = "Pendientes contrato"
        Me.btonlapendientecontrato.ToolTip = "Lista de cotizaciones que estan negociadas pero que aún no tienen contrato."
        '
        'btonListaContratos
        '
        Me.btonListaContratos.Image = CType(resources.GetObject("btonListaContratos.Image"), System.Drawing.Image)
        Me.btonListaContratos.SmallImage = CType(resources.GetObject("btonListaContratos.SmallImage"), System.Drawing.Image)
        Me.btonListaContratos.Tag = "3.1.2"
        Me.btonListaContratos.Text = "Lista Contratos"
        Me.btonListaContratos.ToolTip = "Lista de todos los contratos que maneja la compañia."
        '
        'rpNotasCobro
        '
        Me.rpNotasCobro.Items.Add(Me.btonNotasDirectas)
        Me.rpNotasCobro.Items.Add(Me.btonNotasDesdeAnticipos)
        Me.rpNotasCobro.Items.Add(Me.btonListaNotasCobro)
        Me.rpNotasCobro.Tag = "3.2"
        Me.rpNotasCobro.Text = "Notas de cobro"
        '
        'btonNotasDirectas
        '
        Me.btonNotasDirectas.Image = CType(resources.GetObject("btonNotasDirectas.Image"), System.Drawing.Image)
        Me.btonNotasDirectas.SmallImage = CType(resources.GetObject("btonNotasDirectas.SmallImage"), System.Drawing.Image)
        Me.btonNotasDirectas.Tag = "3.2.1"
        Me.btonNotasDirectas.Text = "Notas directas"
        Me.btonNotasDirectas.ToolTip = "Esta opción le permite al usuario generar otro tipo de notas que no fueron contra" &
    "tadas con el cliente, por ejemplo las notas de cobro por retenidos."
        '
        'btonNotasDesdeAnticipos
        '
        Me.btonNotasDesdeAnticipos.Image = CType(resources.GetObject("btonNotasDesdeAnticipos.Image"), System.Drawing.Image)
        Me.btonNotasDesdeAnticipos.SmallImage = CType(resources.GetObject("btonNotasDesdeAnticipos.SmallImage"), System.Drawing.Image)
        Me.btonNotasDesdeAnticipos.Tag = "3.2.2"
        Me.btonNotasDesdeAnticipos.Text = "Desde anticipos"
        Me.btonNotasDesdeAnticipos.ToolTip = "Por medio de esta opción se generan las notas de cobro para los clientes que tien" &
    "e en sus contrato unos planes de pago o planes de anticipos."
        '
        'btonListaNotasCobro
        '
        Me.btonListaNotasCobro.Image = CType(resources.GetObject("btonListaNotasCobro.Image"), System.Drawing.Image)
        Me.btonListaNotasCobro.SmallImage = CType(resources.GetObject("btonListaNotasCobro.SmallImage"), System.Drawing.Image)
        Me.btonListaNotasCobro.Tag = "3.2.3"
        Me.btonListaNotasCobro.Text = "Lista"
        Me.btonListaNotasCobro.ToolTip = "Muestra el listado completo de las notas de crobro que se han realizado, sean dir" &
    "ectas o desde planes de anticipo"
        '
        'rpPolizas
        '
        Me.rpPolizas.Items.Add(Me.btnIngresoyModi)
        Me.rpPolizas.Tag = "3.3"
        Me.rpPolizas.Text = "Polizas"
        '
        'btnIngresoyModi
        '
        Me.btnIngresoyModi.Image = CType(resources.GetObject("btnIngresoyModi.Image"), System.Drawing.Image)
        Me.btnIngresoyModi.SmallImage = CType(resources.GetObject("btnIngresoyModi.SmallImage"), System.Drawing.Image)
        Me.btnIngresoyModi.Tag = "3.3.1"
        Me.btnIngresoyModi.Text = "Ingreso y modificcación"
        Me.btnIngresoyModi.ToolTip = "Opción que permite al usuario la adición y modificación de la pólizas a los contr" &
    "atos de la compañía. "
        '
        'rpPlaneacion
        '
        Me.rpPlaneacion.Items.Add(Me.btnFechasProduccion)
        Me.rpPlaneacion.Tag = "3.4"
        Me.rpPlaneacion.Text = "Planeación"
        '
        'btnFechasProduccion
        '
        Me.btnFechasProduccion.Image = CType(resources.GetObject("btnFechasProduccion.Image"), System.Drawing.Image)
        Me.btnFechasProduccion.SmallImage = CType(resources.GetObject("btnFechasProduccion.SmallImage"), System.Drawing.Image)
        Me.btnFechasProduccion.Tag = "3.4.1"
        Me.btnFechasProduccion.Text = "Fechas producción"
        Me.btnFechasProduccion.ToolTip = "Permite realizar la pleaneación de puntos por contrato."
        '
        'tbinstalacion
        '
        Me.tbinstalacion.Panels.Add(Me.rpOrdenTrabajo)
        Me.tbinstalacion.Panels.Add(Me.rpCuentasCobro)
        Me.tbinstalacion.Panels.Add(Me.rpCuentasCobroDirectas)
        Me.tbinstalacion.Panels.Add(Me.rpPagoRetenidos)
        Me.tbinstalacion.Panels.Add(Me.rpDevolucionesInst)
        Me.tbinstalacion.Panels.Add(Me.rpConsultasReportes)
        Me.tbinstalacion.Tag = "4"
        Me.tbinstalacion.Text = "Instalaciones"
        '
        'rpOrdenTrabajo
        '
        Me.rpOrdenTrabajo.Items.Add(Me.btnNuevaOrden)
        Me.rpOrdenTrabajo.Items.Add(Me.btnListaOrdenesTrabajo)
        Me.rpOrdenTrabajo.Tag = "4.1"
        Me.rpOrdenTrabajo.Text = "Ordenes de trabajo"
        '
        'btnNuevaOrden
        '
        Me.btnNuevaOrden.Image = CType(resources.GetObject("btnNuevaOrden.Image"), System.Drawing.Image)
        Me.btnNuevaOrden.SmallImage = CType(resources.GetObject("btnNuevaOrden.SmallImage"), System.Drawing.Image)
        Me.btnNuevaOrden.Tag = "4.1.1"
        Me.btnNuevaOrden.Text = "Nueva orden"
        Me.btnNuevaOrden.ToolTip = "Permite al usuario generar ordenes de trabajo a partir de las obras contratadas"
        '
        'btnListaOrdenesTrabajo
        '
        Me.btnListaOrdenesTrabajo.Image = CType(resources.GetObject("btnListaOrdenesTrabajo.Image"), System.Drawing.Image)
        Me.btnListaOrdenesTrabajo.SmallImage = CType(resources.GetObject("btnListaOrdenesTrabajo.SmallImage"), System.Drawing.Image)
        Me.btnListaOrdenesTrabajo.Tag = "4.1.2"
        Me.btnListaOrdenesTrabajo.Text = "Lista ordenes"
        Me.btnListaOrdenesTrabajo.ToolTip = "Trae el listado de las ordenes de trabajo realizadas"
        '
        'rpCuentasCobro
        '
        Me.rpCuentasCobro.Items.Add(Me.btnCuentaxContrato)
        Me.rpCuentasCobro.Items.Add(Me.btnListaCuentasxOT)
        Me.rpCuentasCobro.Tag = "4.2"
        Me.rpCuentasCobro.Text = "Cuentas desde orden de trabajo"
        '
        'btnCuentaxContrato
        '
        Me.btnCuentaxContrato.Image = CType(resources.GetObject("btnCuentaxContrato.Image"), System.Drawing.Image)
        Me.btnCuentaxContrato.SmallImage = CType(resources.GetObject("btnCuentaxContrato.SmallImage"), System.Drawing.Image)
        Me.btnCuentaxContrato.Tag = "4.2.1"
        Me.btnCuentaxContrato.Text = "Realizar cuenta"
        Me.btnCuentaxContrato.ToolTip = "Generar cuentas de cobro a partir de las ordenes de trabajo generadas"
        '
        'btnListaCuentasxOT
        '
        Me.btnListaCuentasxOT.Image = CType(resources.GetObject("btnListaCuentasxOT.Image"), System.Drawing.Image)
        Me.btnListaCuentasxOT.SmallImage = CType(resources.GetObject("btnListaCuentasxOT.SmallImage"), System.Drawing.Image)
        Me.btnListaCuentasxOT.Tag = "4.2.2"
        Me.btnListaCuentasxOT.Text = "Lista cuentas"
        Me.btnListaCuentasxOT.ToolTip = "Trae el listado de las cuentas de cobro por orden de trabajo generadas"
        '
        'rpCuentasCobroDirectas
        '
        Me.rpCuentasCobroDirectas.Items.Add(Me.btnCuentaDiracta)
        Me.rpCuentasCobroDirectas.Items.Add(Me.btnListaCuentasDirectas)
        Me.rpCuentasCobroDirectas.Tag = "4.3"
        Me.rpCuentasCobroDirectas.Text = "Cuentas de cobro directas"
        '
        'btnCuentaDiracta
        '
        Me.btnCuentaDiracta.Image = CType(resources.GetObject("btnCuentaDiracta.Image"), System.Drawing.Image)
        Me.btnCuentaDiracta.SmallImage = CType(resources.GetObject("btnCuentaDiracta.SmallImage"), System.Drawing.Image)
        Me.btnCuentaDiracta.Tag = "4.3.1"
        Me.btnCuentaDiracta.Text = "Realizar cuenta"
        Me.btnCuentaDiracta.ToolTip = "Permite al usuario generar cuentas de cobro directas"
        '
        'btnListaCuentasDirectas
        '
        Me.btnListaCuentasDirectas.Image = CType(resources.GetObject("btnListaCuentasDirectas.Image"), System.Drawing.Image)
        Me.btnListaCuentasDirectas.SmallImage = CType(resources.GetObject("btnListaCuentasDirectas.SmallImage"), System.Drawing.Image)
        Me.btnListaCuentasDirectas.Tag = "4.3.2"
        Me.btnListaCuentasDirectas.Text = "Lista cuentas"
        Me.btnListaCuentasDirectas.ToolTip = "Obtiene el listado de las cuentas de cobro directas realizadas"
        '
        'rpPagoRetenidos
        '
        Me.rpPagoRetenidos.Items.Add(Me.btnPagoRetenidos)
        Me.rpPagoRetenidos.Items.Add(Me.btnRetenidosPagados)
        Me.rpPagoRetenidos.Items.Add(Me.btnDetallePago)
        Me.rpPagoRetenidos.Tag = "4.4"
        Me.rpPagoRetenidos.Text = "Pago retenidos"
        '
        'btnPagoRetenidos
        '
        Me.btnPagoRetenidos.Image = CType(resources.GetObject("btnPagoRetenidos.Image"), System.Drawing.Image)
        Me.btnPagoRetenidos.SmallImage = CType(resources.GetObject("btnPagoRetenidos.SmallImage"), System.Drawing.Image)
        Me.btnPagoRetenidos.Tag = "4.4.1"
        Me.btnPagoRetenidos.Text = "Pago retenidos"
        Me.btnPagoRetenidos.ToolTip = "Permite al usuario realizar el pago de retenidos  según el proveedor y encargado " &
    "indicados."
        '
        'btnRetenidosPagados
        '
        Me.btnRetenidosPagados.Image = CType(resources.GetObject("btnRetenidosPagados.Image"), System.Drawing.Image)
        Me.btnRetenidosPagados.SmallImage = CType(resources.GetObject("btnRetenidosPagados.SmallImage"), System.Drawing.Image)
        Me.btnRetenidosPagados.Tag = "4.4.2"
        Me.btnRetenidosPagados.Text = "Retenidos pagados"
        Me.btnRetenidosPagados.ToolTip = "Obtiene el listado de retenidos pagados y sus opciones de impresión, informes y a" &
    "nulación."
        '
        'btnDetallePago
        '
        Me.btnDetallePago.Image = CType(resources.GetObject("btnDetallePago.Image"), System.Drawing.Image)
        Me.btnDetallePago.SmallImage = CType(resources.GetObject("btnDetallePago.SmallImage"), System.Drawing.Image)
        Me.btnDetallePago.Tag = "4.4.3"
        Me.btnDetallePago.Text = "Detalles pago"
        Me.btnDetallePago.ToolTip = "Obtiene la lista detallada de los retenidos pagados."
        '
        'rpDevolucionesInst
        '
        Me.rpDevolucionesInst.Items.Add(Me.btnNuevaDevolucion)
        Me.rpDevolucionesInst.Items.Add(Me.btnListaDevoluciones)
        Me.rpDevolucionesInst.Tag = "4.5"
        Me.rpDevolucionesInst.Text = "Devoluciones"
        '
        'btnNuevaDevolucion
        '
        Me.btnNuevaDevolucion.Image = CType(resources.GetObject("btnNuevaDevolucion.Image"), System.Drawing.Image)
        Me.btnNuevaDevolucion.SmallImage = CType(resources.GetObject("btnNuevaDevolucion.SmallImage"), System.Drawing.Image)
        Me.btnNuevaDevolucion.Tag = "4.5.1"
        Me.btnNuevaDevolucion.Text = "Nueva devolución"
        Me.btnNuevaDevolucion.ToolTip = "Trae la lista de cuentas de cobro activas y permite realizar devolución sobre las" &
    " mismas."
        '
        'btnListaDevoluciones
        '
        Me.btnListaDevoluciones.Image = CType(resources.GetObject("btnListaDevoluciones.Image"), System.Drawing.Image)
        Me.btnListaDevoluciones.SmallImage = CType(resources.GetObject("btnListaDevoluciones.SmallImage"), System.Drawing.Image)
        Me.btnListaDevoluciones.Tag = "4.5.2"
        Me.btnListaDevoluciones.Text = "Lista devoluciones"
        Me.btnListaDevoluciones.ToolTip = "Obtiene el listado de devoluciones realizadas."
        '
        'rpConsultasReportes
        '
        Me.rpConsultasReportes.Items.Add(Me.btnCuentasPorFecha)
        Me.rpConsultasReportes.Items.Add(Me.btnOrdenesVsCuentas)
        Me.rpConsultasReportes.Tag = "4.6"
        Me.rpConsultasReportes.Text = "Consultas y reportes"
        '
        'btnCuentasPorFecha
        '
        Me.btnCuentasPorFecha.Image = CType(resources.GetObject("btnCuentasPorFecha.Image"), System.Drawing.Image)
        Me.btnCuentasPorFecha.MinimumSize = New System.Drawing.Size(100, 0)
        Me.btnCuentasPorFecha.SmallImage = CType(resources.GetObject("btnCuentasPorFecha.SmallImage"), System.Drawing.Image)
        Me.btnCuentasPorFecha.Tag = "4.6.1"
        Me.btnCuentasPorFecha.Text = "Cuentas por fecha"
        '
        'btnOrdenesVsCuentas
        '
        Me.btnOrdenesVsCuentas.Image = CType(resources.GetObject("btnOrdenesVsCuentas.Image"), System.Drawing.Image)
        Me.btnOrdenesVsCuentas.MinimumSize = New System.Drawing.Size(100, 0)
        Me.btnOrdenesVsCuentas.SmallImage = CType(resources.GetObject("btnOrdenesVsCuentas.SmallImage"), System.Drawing.Image)
        Me.btnOrdenesVsCuentas.Tag = "4.6.2"
        Me.btnOrdenesVsCuentas.Text = "Ordenes vs cuentas"
        '
        'tbfacturacion
        '
        Me.tbfacturacion.Tag = "5"
        Me.tbfacturacion.Text = "Facturación"
        '
        'tbcostos
        '
        Me.tbcostos.Tag = "6"
        Me.tbcostos.Text = "Costos"
        '
        'tblogistica
        '
        Me.tblogistica.Panels.Add(Me.rpaprobacionEntregas)
        Me.tblogistica.Panels.Add(Me.rpremisiones)
        Me.tblogistica.Panels.Add(Me.rpdevoluciones)
        Me.tblogistica.Panels.Add(Me.rpanulacionLogistica)
        Me.tblogistica.Tag = "7"
        Me.tblogistica.Text = "Logística"
        '
        'rpaprobacionEntregas
        '
        Me.rpaprobacionEntregas.Tag = "7.1"
        Me.rpaprobacionEntregas.Text = "Aprobación Entregas"
        '
        'rpremisiones
        '
        Me.rpremisiones.Tag = "7.2"
        Me.rpremisiones.Text = "Remisiones"
        '
        'rpdevoluciones
        '
        Me.rpdevoluciones.Tag = "7.3"
        Me.rpdevoluciones.Text = "Devoluciones"
        '
        'rpanulacionLogistica
        '
        Me.rpanulacionLogistica.Tag = "7.4"
        Me.rpanulacionLogistica.Text = "Anulaciones"
        '
        'tbconsultasreportesComercial
        '
        Me.tbconsultasreportesComercial.Tag = "8"
        Me.tbconsultasreportesComercial.Text = "Consultas y Reportes Comercial"
        '
        'tbingenieria
        '
        Me.tbingenieria.Panels.Add(Me.rpplantillas)
        Me.tbingenieria.Panels.Add(Me.rpmodificacionesmasivas)
        Me.tbingenieria.Tag = "9"
        Me.tbingenieria.Text = "Ingeniería"
        '
        'rpplantillas
        '
        Me.rpplantillas.Items.Add(Me.btnagregarPlantilla)
        Me.rpplantillas.Items.Add(Me.btnlistaplantillas)
        Me.rpplantillas.Tag = "9.1"
        Me.rpplantillas.Text = "Plantillas"
        '
        'btnagregarPlantilla
        '
        Me.btnagregarPlantilla.Image = CType(resources.GetObject("btnagregarPlantilla.Image"), System.Drawing.Image)
        Me.btnagregarPlantilla.SmallImage = CType(resources.GetObject("btnagregarPlantilla.SmallImage"), System.Drawing.Image)
        Me.btnagregarPlantilla.Tag = "9.1.1"
        Me.btnagregarPlantilla.Text = "Nuevo"
        Me.btnagregarPlantilla.ToolTip = "Crea una nueva plantilla de diseños que podran ser cotizados posteriormente"
        '
        'btnlistaplantillas
        '
        Me.btnlistaplantillas.Image = CType(resources.GetObject("btnlistaplantillas.Image"), System.Drawing.Image)
        Me.btnlistaplantillas.SmallImage = CType(resources.GetObject("btnlistaplantillas.SmallImage"), System.Drawing.Image)
        Me.btnlistaplantillas.Tag = "9.1.2"
        Me.btnlistaplantillas.Text = "Lista"
        Me.btnlistaplantillas.ToolTip = "Trae un listado de todas las plantillas disponibles para modificaciones y duplica" &
    "dos."
        '
        'rpmodificacionesmasivas
        '
        Me.rpmodificacionesmasivas.Items.Add(Me.btnmodificarmasivo)
        Me.rpmodificacionesmasivas.Tag = "9.2"
        Me.rpmodificacionesmasivas.Text = "Modificaciones Masivas"
        '
        'btnmodificarmasivo
        '
        Me.btnmodificarmasivo.Image = CType(resources.GetObject("btnmodificarmasivo.Image"), System.Drawing.Image)
        Me.btnmodificarmasivo.SmallImage = CType(resources.GetObject("btnmodificarmasivo.SmallImage"), System.Drawing.Image)
        Me.btnmodificarmasivo.Tag = "9.2.1"
        Me.btnmodificarmasivo.Text = "Modificar Plantilla"
        '
        'tbdeptecnico
        '
        Me.tbdeptecnico.Panels.Add(Me.rpparaplanos)
        Me.tbdeptecnico.Panels.Add(Me.rprevajplanos)
        Me.tbdeptecnico.Panels.Add(Me.rpimpplanos)
        Me.tbdeptecnico.Panels.Add(Me.rpadicionplanos)
        Me.tbdeptecnico.Panels.Add(Me.rpeliminacionplanos)
        Me.tbdeptecnico.Panels.Add(Me.rpoptimizacionop)
        Me.tbdeptecnico.Panels.Add(Me.rpimpresionetiquetas)
        Me.tbdeptecnico.Tag = "10"
        Me.tbdeptecnico.Text = "Depto. Técnico"
        '
        'rpparaplanos
        '
        Me.rpparaplanos.Items.Add(Me.btnopaprobadas)
        Me.rpparaplanos.Tag = "10.1"
        Me.rpparaplanos.Text = "Para planos"
        '
        'btnopaprobadas
        '
        Me.btnopaprobadas.Image = CType(resources.GetObject("btnopaprobadas.Image"), System.Drawing.Image)
        Me.btnopaprobadas.SmallImage = CType(resources.GetObject("btnopaprobadas.SmallImage"), System.Drawing.Image)
        Me.btnopaprobadas.Tag = "10.1.1"
        Me.btnopaprobadas.Text = "Op aprobadas"
        '
        'rprevajplanos
        '
        Me.rprevajplanos.Tag = "10.2"
        Me.rprevajplanos.Text = "Revisión Planos"
        '
        'rpimpplanos
        '
        Me.rpimpplanos.Tag = "10.3"
        Me.rpimpplanos.Text = "Impresión Planos"
        '
        'rpadicionplanos
        '
        Me.rpadicionplanos.Tag = "10.4"
        Me.rpadicionplanos.Text = "Adición Planos"
        '
        'rpeliminacionplanos
        '
        Me.rpeliminacionplanos.Tag = "10.5"
        Me.rpeliminacionplanos.Text = "Eliminación Planos"
        '
        'rpoptimizacionop
        '
        Me.rpoptimizacionop.Tag = "10.6"
        Me.rpoptimizacionop.Text = "Optimización"
        '
        'rpimpresionetiquetas
        '
        Me.rpimpresionetiquetas.Tag = "10.7"
        Me.rpimpresionetiquetas.Text = "Impresión Etiquetas"
        '
        'tbproduccion
        '
        Me.tbproduccion.Panels.Add(Me.rpdesdepedido)
        Me.tbproduccion.Panels.Add(Me.rpentregasproduccion)
        Me.tbproduccion.Panels.Add(Me.rpparaproduccion)
        Me.tbproduccion.Panels.Add(Me.rpproblemasproduccion)
        Me.tbproduccion.Tag = "11"
        Me.tbproduccion.Text = "Producción"
        '
        'rpdesdepedido
        '
        Me.rpdesdepedido.Items.Add(Me.btnimprimirop)
        Me.rpdesdepedido.Items.Add(Me.btnanularop)
        Me.rpdesdepedido.Tag = "11.1"
        Me.rpdesdepedido.Text = "Ordenes Producción"
        '
        'btnimprimirop
        '
        Me.btnimprimirop.Image = CType(resources.GetObject("btnimprimirop.Image"), System.Drawing.Image)
        Me.btnimprimirop.SmallImage = CType(resources.GetObject("btnimprimirop.SmallImage"), System.Drawing.Image)
        Me.btnimprimirop.Tag = "11.1.2"
        Me.btnimprimirop.Text = "Aprobar Op"
        '
        'btnanularop
        '
        Me.btnanularop.Image = CType(resources.GetObject("btnanularop.Image"), System.Drawing.Image)
        Me.btnanularop.SmallImage = CType(resources.GetObject("btnanularop.SmallImage"), System.Drawing.Image)
        Me.btnanularop.Tag = "11.1.3"
        Me.btnanularop.Text = "Anular Ordenes"
        '
        'rpentregasproduccion
        '
        Me.rpentregasproduccion.Items.Add(Me.btnentregasproduccion)
        Me.rpentregasproduccion.Items.Add(Me.btndevolucionesproduccion)
        Me.rpentregasproduccion.Tag = "11.2"
        Me.rpentregasproduccion.Text = "Entregas Producción"
        '
        'btnentregasproduccion
        '
        Me.btnentregasproduccion.Image = CType(resources.GetObject("btnentregasproduccion.Image"), System.Drawing.Image)
        Me.btnentregasproduccion.SmallImage = CType(resources.GetObject("btnentregasproduccion.SmallImage"), System.Drawing.Image)
        Me.btnentregasproduccion.Tag = "11.2.1"
        Me.btnentregasproduccion.Text = "Entrega"
        '
        'btndevolucionesproduccion
        '
        Me.btndevolucionesproduccion.Image = CType(resources.GetObject("btndevolucionesproduccion.Image"), System.Drawing.Image)
        Me.btndevolucionesproduccion.SmallImage = CType(resources.GetObject("btndevolucionesproduccion.SmallImage"), System.Drawing.Image)
        Me.btndevolucionesproduccion.Tag = "11.2.2"
        Me.btndevolucionesproduccion.Text = "Devolucion"
        '
        'rpparaproduccion
        '
        Me.rpparaproduccion.Items.Add(Me.btnparaproduccion)
        Me.rpparaproduccion.Items.Add(Me.btnenproduccion)
        Me.rpparaproduccion.Tag = "11.3"
        Me.rpparaproduccion.Text = "Para producción"
        '
        'btnparaproduccion
        '
        Me.btnparaproduccion.Image = CType(resources.GetObject("btnparaproduccion.Image"), System.Drawing.Image)
        Me.btnparaproduccion.SmallImage = CType(resources.GetObject("btnparaproduccion.SmallImage"), System.Drawing.Image)
        Me.btnparaproduccion.Tag = "11.3.1"
        Me.btnparaproduccion.Text = "Para produccion"
        '
        'btnenproduccion
        '
        Me.btnenproduccion.Image = CType(resources.GetObject("btnenproduccion.Image"), System.Drawing.Image)
        Me.btnenproduccion.SmallImage = CType(resources.GetObject("btnenproduccion.SmallImage"), System.Drawing.Image)
        Me.btnenproduccion.Tag = "11.3.2"
        Me.btnenproduccion.Text = "En producción"
        '
        'rpproblemasproduccion
        '
        Me.rpproblemasproduccion.Items.Add(Me.btnabrirproblema)
        Me.rpproblemasproduccion.Tag = "11.4"
        Me.rpproblemasproduccion.Text = "Problemas de producción"
        '
        'btnabrirproblema
        '
        Me.btnabrirproblema.Image = CType(resources.GetObject("btnabrirproblema.Image"), System.Drawing.Image)
        Me.btnabrirproblema.SmallImage = CType(resources.GetObject("btnabrirproblema.SmallImage"), System.Drawing.Image)
        Me.btnabrirproblema.Tag = "11.4.1"
        Me.btnabrirproblema.Text = "Abrir problema"
        '
        'tbperfileria
        '
        Me.tbperfileria.Panels.Add(Me.rplistascorteperf)
        Me.tbperfileria.Tag = "12"
        Me.tbperfileria.Text = "Perfilería"
        '
        'rplistascorteperf
        '
        Me.rplistascorteperf.Tag = "12.1"
        Me.rplistascorteperf.Text = "Listas de Corte"
        '
        'tbconsultasreportesManufactura
        '
        Me.tbconsultasreportesManufactura.Panels.Add(Me.pninfdinamicosman)
        Me.tbconsultasreportesManufactura.Text = "Consultas y Reportes Producción"
        '
        'pninfdinamicosman
        '
        Me.pninfdinamicosman.Items.Add(Me.btninfdinamicosman)
        Me.pninfdinamicosman.Text = "Informes Dinámicos"
        '
        'btninfdinamicosman
        '
        Me.btninfdinamicosman.Image = CType(resources.GetObject("btninfdinamicosman.Image"), System.Drawing.Image)
        Me.btninfdinamicosman.SmallImage = CType(resources.GetObject("btninfdinamicosman.SmallImage"), System.Drawing.Image)
        Me.btninfdinamicosman.Text = "Informes"
        '
        'mditabbar
        '
        Me.mditabbar.BackColor = System.Drawing.SystemColors.Window
        Me.mditabbar.CanOverflow = False
        Me.mditabbar.CerrarVisible = True
        Me.mditabbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.mditabbar.Location = New System.Drawing.Point(0, 148)
        Me.mditabbar.MaximizarVisible = False
        Me.mditabbar.MDIForm = Me
        Me.mditabbar.MinimizarVisible = False
        Me.mditabbar.Name = "mditabbar"
        Me.mditabbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.mditabbar.SelectedItem = Nothing
        Me.mditabbar.Size = New System.Drawing.Size(1079, 25)
        Me.mditabbar.TabIndex = 11
        Me.mditabbar.Text = "MdiToolStripTabBar1"
        '
        'rbCotizacion
        '
        Me.rbCotizacion.Image = CType(resources.GetObject("rbCotizacion.Image"), System.Drawing.Image)
        Me.rbCotizacion.SmallImage = CType(resources.GetObject("rbCotizacion.SmallImage"), System.Drawing.Image)
        '
        'btncomision
        '
        Me.btncomision.Image = CType(resources.GetObject("btncomision.Image"), System.Drawing.Image)
        Me.btncomision.SmallImage = CType(resources.GetObject("btncomision.SmallImage"), System.Drawing.Image)
        Me.btncomision.Text = "Comisión"
        '
        'btnrecaudo
        '
        Me.btnrecaudo.Image = CType(resources.GetObject("btnrecaudo.Image"), System.Drawing.Image)
        Me.btnrecaudo.SmallImage = CType(resources.GetObject("btnrecaudo.SmallImage"), System.Drawing.Image)
        Me.btnrecaudo.Text = "Recaudo"
        '
        'frmInicial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 494)
        Me.Controls.Add(Me.mditabbar)
        Me.Controls.Add(Me.rbprincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "frmInicial"
        Me.Tag = "2"
        Me.Text = "ALCO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbprincipal As System.Windows.Forms.Ribbon
    Friend WithEvents mditabbar As MdiTabPagesBar.MdiToolStripTabBar
    Friend WithEvents btnimpresion As System.Windows.Forms.RibbonButton
    Friend WithEvents btnexportar As System.Windows.Forms.RibbonButton
    Friend WithEvents prmManufactura As System.Windows.Forms.RibbonOrbMenuItem
    Friend WithEvents prmComercial As System.Windows.Forms.RibbonOrbMenuItem
    Friend WithEvents prmProduccion As System.Windows.Forms.RibbonOrbMenuItem
    Friend WithEvents prmGenerales As System.Windows.Forms.RibbonOrbMenuItem
    Friend WithEvents mnEstados As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnAcabados As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.RibbonButton
    Friend WithEvents btonCerrar As System.Windows.Forms.RibbonOrbMenuItem
    Friend WithEvents mnFamiliasModelo As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnFamiliasMateriales As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnTiposModelos As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnClasificacionModelos As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnVariables As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnOrientacionPosicion As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnUbicacionMaterial As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnMaterialPara As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.RibbonButton
    Friend WithEvents btnguardarParcial As System.Windows.Forms.RibbonButton
    Friend WithEvents btnGuardarTotal As System.Windows.Forms.RibbonButton
    Friend WithEvents mnTiposDatos As RibbonMenuItem
    Friend WithEvents btnmodulos As RibbonButton
    Friend WithEvents btnfinanciero As RibbonButton
    Friend WithEvents btncomercial As RibbonButton
    Friend WithEvents btnmanufactura As RibbonButton
    Friend WithEvents btnplaneacion As RibbonButton
    Friend WithEvents tbventas As RibbonTab
    Friend WithEvents tbcontratos As RibbonTab
    Friend WithEvents tbinstalacion As RibbonTab
    Friend WithEvents tbfacturacion As RibbonTab
    Friend WithEvents tbcostos As RibbonTab
    Friend WithEvents tbconsultasreportesComercial As RibbonTab
    Friend WithEvents tbingenieria As RibbonTab
    Friend WithEvents rpplantillas As RibbonPanel
    Friend WithEvents tbproduccion As RibbonTab
    Friend WithEvents tbdeptecnico As RibbonTab
    Friend WithEvents tblogistica As RibbonTab
    Friend WithEvents rpdesdepedido As RibbonPanel
    Friend WithEvents rprevajplanos As RibbonPanel
    Friend WithEvents rpimpplanos As RibbonPanel
    Friend WithEvents rpadicionplanos As RibbonPanel
    Friend WithEvents rpeliminacionplanos As RibbonPanel
    Friend WithEvents rpoptimizacionop As RibbonPanel
    Friend WithEvents rpimpresionetiquetas As RibbonPanel
    Friend WithEvents rpremisiones As RibbonPanel
    Friend WithEvents rpdevoluciones As RibbonPanel
    Friend WithEvents rpanulacionLogistica As RibbonPanel
    Friend WithEvents tbperfileria As RibbonTab
    Friend WithEvents rplistascorteperf As RibbonPanel
    Friend WithEvents tbconsultasreportesManufactura As RibbonTab
    Friend WithEvents rpentregasproduccion As RibbonPanel
    Friend WithEvents btnentregasproduccion As RibbonButton
    Friend WithEvents btndevolucionesproduccion As RibbonButton
    Friend WithEvents btnimprimirop As RibbonButton
    Friend WithEvents btnanularop As RibbonButton
    Friend WithEvents rpcotizaciones As RibbonPanel
    Friend WithEvents rbCotizacion As RibbonButton
    Friend WithEvents btncomision As RibbonButton
    Friend WithEvents btnrecaudo As RibbonButton
    Friend WithEvents rpaprobacionEntregas As RibbonPanel
    Friend WithEvents btnimprimir As RibbonButton
    Friend WithEvents btnvistaprevia As RibbonButton
    Friend WithEvents btnexportarExcel As RibbonButton
    Friend WithEvents btnExportarPdf As RibbonButton
    Friend WithEvents mnTiposCortes As RibbonMenuItem
    Friend WithEvents mnTiposMaterial As RibbonMenuItem
    Friend WithEvents mnCaracteristicasAdicionales As RibbonMenuItem
    Friend WithEvents mnConfiguraciones As RibbonMenuItem
    Friend WithEvents mnArticulos As RibbonMenuItem
    Friend WithEvents mnValoresVariables As RibbonMenuItem
    Friend WithEvents btnagregarPlantilla As RibbonButton
    Friend WithEvents mmEspesoresVidrio As System.Windows.Forms.RibbonMenuItem
    Friend WithEvents mnCostoAluminio As RibbonMenuItem
    Friend WithEvents btnlistaplantillas As RibbonButton
    Friend WithEvents btnGeneraCotizaciones As RibbonButton
    Friend WithEvents btnVerCotizaciones As RibbonButton
    Friend WithEvents btnrecargar As RibbonButton
    Friend WithEvents mnDescuentos As RibbonMenuItem
    Friend WithEvents mnversionCargaVientos As RibbonMenuItem
    Friend WithEvents mnVelocidadesViento As RibbonMenuItem
    Friend WithEvents nmparametrostecnicos As RibbonMenuItem
    Friend WithEvents nmvaloresparametros As RibbonMenuItem
    Friend WithEvents pnelContratos As RibbonPanel
    Friend WithEvents mnParamContratos As RibbonMenuItem
    Friend WithEvents btonObjetos As RibbonButton
    Friend WithEvents btonPara As RibbonButton
    Friend WithEvents btonAseguradoras As RibbonButton
    Friend WithEvents btonTipoPolizas As RibbonButton
    Friend WithEvents btonTiposEscrituras As RibbonButton
    Friend WithEvents mnParamNSR10 As RibbonMenuItem
    Friend WithEvents btonTipoEdificacion As RibbonButton
    Friend WithEvents btonGrupoUso As RibbonButton
    Friend WithEvents btonCategExposicion As RibbonButton
    Friend WithEvents btonTipoCubierta As RibbonButton
    Friend WithEvents btonPresionModelo As RibbonButton
    Friend WithEvents btonComponentes As RibbonButton
    Friend WithEvents mnParamCostos As RibbonMenuItem
    Friend WithEvents btonCostoKiloAluminio As RibbonButton
    Friend WithEvents btonNiveles As RibbonButton
    Friend WithEvents btonCostoAluminio As RibbonButton
    Friend WithEvents btonCostoVidrio As RibbonButton
    Friend WithEvents btonCostoArticulos As RibbonButton
    Friend WithEvents btonCamarasComercio As RibbonButton
    Friend WithEvents mnpropiedadesmodelos As RibbonMenuItem
    Friend WithEvents rpNotasCobro As RibbonPanel
    Friend WithEvents btonNotasDirectas As RibbonButton
    Friend WithEvents btonNotasDesdeAnticipos As RibbonButton
    Friend WithEvents mnParametrosNotas As RibbonMenuItem
    Friend WithEvents btonTiposNotas As RibbonButton
    Friend WithEvents btonTipoAnticipo As RibbonButton
    Friend WithEvents btonEsquemaNotas As RibbonButton
    Friend WithEvents btonOrigenesNotas As RibbonButton
    Friend WithEvents btonListaNotasCobro As RibbonButton
    Friend WithEvents rpReposiciones As RibbonPanel
    Friend WithEvents btnRepFacturables As RibbonButton
    Friend WithEvents btonVariablesMinutas As RibbonButton
    Friend WithEvents btonFormatosMinutas As RibbonButton
    Friend WithEvents btonListaContratos As RibbonButton
    Friend WithEvents btnexportarword As RibbonButton
    Friend WithEvents mnParametrosCotizaciones As RibbonMenuItem
    Friend WithEvents btonDirectores As RibbonButton
    Friend WithEvents btonVendedores As RibbonButton
    Friend WithEvents btonFactores As RibbonButton
    Friend WithEvents btonFormasPago As RibbonButton
    Friend WithEvents btonImpuestos As RibbonButton
    Friend WithEvents btonInstalacion As RibbonButton
    Friend WithEvents btonParametrosAIU As RibbonButton
    Friend WithEvents btonTiempoEntrega As RibbonButton
    Friend WithEvents btonTiposIdentificacion As RibbonButton
    Friend WithEvents btonTipoObra As RibbonButton
    Friend WithEvents btonVigencias As RibbonButton
    Friend WithEvents btonCondiciones As RibbonButton
    Friend WithEvents mmmodulosaplicacion As RibbonButton
    Friend WithEvents prmseguridad As RibbonOrbMenuItem
    Friend WithEvents btndepartamentos As RibbonButton
    Friend WithEvents btnusuarios As RibbonButton
    Friend WithEvents btngrupos As RibbonButton
    Friend WithEvents btnpermisos As RibbonButton
    Friend WithEvents rpmodificacionesmasivas As RibbonPanel
    Friend WithEvents btnmodificarmasivo As RibbonButton
    Friend WithEvents btnRepNoFacturables As RibbonButton
    Friend WithEvents btnBuscarxVendedor As RibbonButton
    Friend WithEvents rpPolizas As RibbonPanel
    Friend WithEvents btnIngresoyModi As RibbonButton
    Friend WithEvents btonlapendientecontrato As RibbonButton
    Friend WithEvents btontipoformato As RibbonButton
    Friend WithEvents btnpermisosextra As RibbonButton
    Friend WithEvents rpPlaneacion As RibbonPanel
    Friend WithEvents btnFechasProduccion As RibbonButton
    Friend WithEvents rppedidos As RibbonPanel
    Friend WithEvents btngenerarordenpedido As RibbonButton
    Friend WithEvents btnlistaordenespedido As RibbonButton
    Friend WithEvents rbconsola As RibbonButton
    Friend WithEvents btonCostoTrabajos As RibbonButton
    Friend WithEvents rbtcalidad As RibbonMenuItem
    Friend WithEvents btnSecciones As RibbonButton
    Friend WithEvents rbtgenerales As RibbonMenuItem
    Friend WithEvents btnTercerosProduccion As RibbonButton
    Friend WithEvents btnMotivosDevolucionOP As RibbonButton
    Friend WithEvents btnMotivosxSeccion As RibbonButton
    Friend WithEvents btnCausas As RibbonButton
    Friend WithEvents btnMotivosxCausa As RibbonButton
    Friend WithEvents btnDestinatarios As RibbonButton
    Friend WithEvents mnParametrosInstalacion As RibbonMenuItem
    Friend WithEvents btnProveedores As RibbonButton
    Friend WithEvents btnEncargados As RibbonButton
    Friend WithEvents btnConceptos As RibbonButton
    Friend WithEvents btnListaPrecios As RibbonButton
    Friend WithEvents btnTiposCuentas As RibbonButton
    Friend WithEvents btnTiposOrdenesTrabajo As RibbonButton
    Friend WithEvents btnDocumentos As RibbonButton
    Friend WithEvents rpOrdenTrabajo As RibbonPanel
    Friend WithEvents btnNuevaOrden As RibbonButton
    Friend WithEvents btnListaOrdenesTrabajo As RibbonButton
    Friend WithEvents mmConectoresPlanosSiesa As RibbonButton
    Friend WithEvents rpCuentasCobro As RibbonPanel
    Friend WithEvents rpPagoRetenidos As RibbonPanel
    Friend WithEvents rpConsultasReportes As RibbonPanel
    Friend WithEvents rpCuentasCobroDirectas As RibbonPanel
    Friend WithEvents rpDevolucionesInst As RibbonPanel
    Friend WithEvents btnCuentaxContrato As RibbonButton
    Friend WithEvents btnListaCuentasxOT As RibbonButton
    Friend WithEvents btnPagoRetenidos As RibbonButton
    Friend WithEvents btnCuentaDiracta As RibbonButton
    Friend WithEvents btnListaCuentasDirectas As RibbonButton
    Friend WithEvents btnNuevaDevolucion As RibbonButton
    Friend WithEvents btnListaDevoluciones As RibbonButton
    Friend WithEvents btnRetenidosPagados As RibbonButton
    Friend WithEvents mnControlescon As RibbonButton
    Friend WithEvents btnDetallePago As RibbonButton
    Friend WithEvents btonGruposCondiciones As RibbonButton
    Friend WithEvents btnCuentasPorFecha As RibbonButton
    Friend WithEvents btnOrdenesVsCuentas As RibbonButton
    Friend WithEvents mninformesdinamicos As RibbonButton
    Friend WithEvents btonCostoVidrioIndividual As RibbonButton
    Friend WithEvents rpparaplanos As RibbonPanel
    Friend WithEvents rpparaproduccion As RibbonPanel
    Friend WithEvents btnparaproduccion As RibbonButton
    Friend WithEvents btnenproduccion As RibbonButton
    Friend WithEvents btnopaprobadas As RibbonButton
    Friend WithEvents rpProblemasProduccionVentas As RibbonPanel
    Friend WithEvents btnregistrodeproblemas As RibbonButton
    Friend WithEvents btnlistaproblemas As RibbonButton
    Friend WithEvents rpproblemasproduccion As RibbonPanel
    Friend WithEvents btnabrirproblema As RibbonButton
    Friend WithEvents btonVariosCostos As RibbonButton
    Friend WithEvents pninfdinamicosman As RibbonPanel
    Friend WithEvents btninfdinamicosman As RibbonButton
    Friend WithEvents mnserviciosItems As RibbonButton
    Friend WithEvents mnmedsperfileria As RibbonButton
    Friend WithEvents btonpermisos As RibbonButton
    Friend WithEvents btoncostosadicionalesobra As RibbonButton
    Friend WithEvents btonDuracionDuplicacion As RibbonButton
End Class
