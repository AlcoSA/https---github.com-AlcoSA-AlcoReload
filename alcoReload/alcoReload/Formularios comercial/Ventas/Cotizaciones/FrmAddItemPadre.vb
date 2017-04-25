Imports ReglasNegocio
Imports Formulador
Imports ReglasNegocio.Factores
Imports ReglasNegocio.cotizaciones
Imports ReglasNegocio.movitoPadres
Imports ReglasNegocio.movitoHijos
Imports DatagridTreeView
Imports System.Math
Imports ControlesPersonalizados.Estructurador

Public Class FrmAddItemPadre

#Region "Variables"

    Private mAcabados As ClsAcabados
    Private mArticulos As ClsArticulos
    Private mArticuloTemporal As ClsArticuloTemporal
    Private mEspesores As ClsEspesores
    Private mCotiza
    Private mFactor As ClsFactores
    Private listFactores As List(Of factores)
    Private calculo As ClsCalculos
    Private _tasa As Decimal = 0
    Public tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _frmCotiza As FrmCotizaciones
    Private nodotrabajo As DataGridViewTreeNode
    Private total As DataGridViewRow
    Private _factorGlobal As factores
    Private _acabadoGlobal As Acabado
    Private _descuentoGlobal As Decimal
    Private _manoObra As Decimal
    Private _tieneInstalacion As Boolean
    Private _idCotiza As Integer = 0
    Private _tieneTemporales As Boolean
    Private mt2Padre As Decimal = 0
    Private _indAIU As Boolean = False
    Private mMovitoHijo As ClsMovitoHijos
    Private mMovitoPadre As ClsMovitoPadres
    Private mCotizacion As ClsCostizaciones
    Private _versionCostoAcabado As Integer
    Private _versionCostoNivel As Integer
    Private _versionCostoKiloAluminio As Integer
    Private _versionCostoVidrio As Integer
    Private _versionCostoAccesorio As Integer
    Private _versionCostoOtros As Integer
    Private _calcular_norma As Boolean = False
    Private _cumple_norma As Boolean = False
    Private _numero_cuerpos_norma_ As Integer = 1
#Region "Re-calculo según valores"
    Private valor_tipo_vidrio_original As Integer = 0
    Private valor_espesor_original As Integer = 0
    Private valor_acabado_original As Integer = 0
    Private valor_color_original As Integer = 0
    Private valor_ancho_original As Decimal = 0
    Private valor_alto_original As Decimal = 0
    Private valor_cantidad_original As Decimal = 0
    Private _IdTasaImpuestoGlobal As Integer
    Private _tasaImpuestoGlobal As Decimal
    Private _listArticulos As List(Of articuloTemporal)
    Private _listColores As List(Of acabadoTemporal)
    Private _listEspesores As List(Of espesorTemporal)
    Private _listAcabados As List(Of acabadoTemporal)
#End Region

#End Region

#Region "Propiedades"
    Private _curid As Integer = 0
    Public Property CurId() As Integer
        Get
            Return _curid
        End Get
        Set(ByVal value As Integer)
            _curid = value
        End Set
    End Property
    Public Property tipoFormulario() As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Property NodoItem() As DataGridViewTreeNode
        Get
            Return nodotrabajo
        End Get
        Set(ByVal value As DataGridViewTreeNode)
            nodotrabajo = value
        End Set
    End Property
    Public Property totales() As DataGridViewRow
        Get
            Return total
        End Get
        Set(ByVal value As DataGridViewRow)
            total = value
        End Set
    End Property
    Public Property FactorGlobal As factores
        Get
            Return _factorGlobal
        End Get
        Set(ByVal value As factores)
            _factorGlobal = value
        End Set
    End Property
    Public Property AcabadoGlobal As Acabado
        Get
            Return _acabadoGlobal
        End Get
        Set(ByVal value As Acabado)
            _acabadoGlobal = value
        End Set
    End Property
    Public Property DescuentoGlobal As Decimal
        Get
            Return _descuentoGlobal
        End Get
        Set(ByVal value As Decimal)
            _descuentoGlobal = value
        End Set
    End Property
    Public Property manoObra As Decimal
        Get
            Return _manoObra
        End Get
        Set(ByVal value As Decimal)
            _manoObra = value
        End Set
    End Property
    Public Property tieneInstalacion As Boolean
        Get
            Return _tieneInstalacion
        End Get
        Set(ByVal value As Boolean)
            _tieneInstalacion = value
        End Set
    End Property
    Public Property idTasaImpuestoGlobal As Integer
        Get
            Return _IdTasaImpuestoGlobal
        End Get
        Set(ByVal value As Integer)
            _IdTasaImpuestoGlobal = value
        End Set
    End Property
    Public Property tasaImpuestoGlobal As Decimal
        Get
            Return _tasaImpuestoGlobal
        End Get
        Set(ByVal value As Decimal)
            _tasaImpuestoGlobal = value
        End Set
    End Property
    Public Property idCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property TieneTemporales() As Boolean
        Get
            Return _tieneTemporales
        End Get
        Set(ByVal value As Boolean)
            _tieneTemporales = value
        End Set
    End Property
    Public Property ListArticulos() As List(Of articuloTemporal)
        Get
            Return _listArticulos
        End Get
        Set(ByVal value As List(Of articuloTemporal))
            _listArticulos = value
        End Set
    End Property
    Public Property ListColores() As List(Of acabadoTemporal)
        Get
            Return _listColores
        End Get
        Set(ByVal value As List(Of acabadoTemporal))
            _listColores = value
        End Set
    End Property
    Public Property ListEspesores() As List(Of espesorTemporal)
        Get
            Return _listEspesores
        End Get
        Set(ByVal value As List(Of espesorTemporal))
            _listEspesores = value
        End Set
    End Property
    Public Property ListAcabados() As List(Of acabadoTemporal)
        Get
            Return _listAcabados
        End Get
        Set(ByVal value As List(Of acabadoTemporal))
            _listAcabados = value
        End Set
    End Property
    Public Property indAIU As Boolean
        Get
            Return _indAIU
        End Get
        Set(value As Boolean)
            _indAIU = value
        End Set
    End Property
    Private _indCobroMetrosReales As Boolean
    Public Property indCobroMetrosReales() As Boolean
        Get
            Return _indCobroMetrosReales
        End Get
        Set(ByVal value As Boolean)
            _indCobroMetrosReales = value
        End Set
    End Property
    Private _tasaAdministracion As Decimal
    Public Property tasaAdministracion() As Decimal
        Get
            Return _tasaAdministracion
        End Get
        Set(ByVal value As Decimal)
            _tasaAdministracion = value
        End Set
    End Property
    Private _tasaimprovistos As Decimal
    Public Property tasaImprovistos() As Decimal
        Get
            Return _tasaimprovistos
        End Get
        Set(ByVal value As Decimal)
            _tasaimprovistos = value
        End Set
    End Property
    Private _tasaUtilidad As Decimal
    Public Property tasaUtilidad() As Decimal
        Get
            Return _tasaUtilidad
        End Get
        Set(ByVal value As Decimal)
            _tasaUtilidad = value
        End Set
    End Property
    Public Property VersionCostoAcabado() As Integer
        Get
            Return _versionCostoAcabado
        End Get
        Set(ByVal value As Integer)
            _versionCostoAcabado = value
        End Set
    End Property
    Public Property VersionCostoNivel() As Integer
        Get
            Return _versionCostoNivel
        End Get
        Set(ByVal value As Integer)
            _versionCostoNivel = value
        End Set
    End Property
    Public Property VersionCostoKAlum() As Integer
        Get
            Return _versionCostoKiloAluminio
        End Get
        Set(ByVal value As Integer)
            _versionCostoKiloAluminio = value
        End Set
    End Property
    Public Property VersionCostoVidrio() As Integer
        Get
            Return _versionCostoVidrio
        End Get
        Set(ByVal value As Integer)
            _versionCostoVidrio = value
        End Set
    End Property
    Public Property VersionCostoAccesorio() As Integer
        Get
            Return _versionCostoAccesorio
        End Get
        Set(ByVal value As Integer)
            _versionCostoAccesorio = value
        End Set
    End Property
    Public Property VersionCostoOtros() As Integer
        Get
            Return _versionCostoOtros
        End Get
        Set(ByVal value As Integer)
            _versionCostoOtros = value
        End Set
    End Property
#End Region

#Region "Procedimientos Usuarios"
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
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
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
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarAcabados()
        Try
            mAcabados = New ClsAcabados
            Dim listAcab As List(Of Acabado) = mAcabados.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.PERFILERIA)
            cmbAcabado.DisplayMember = "Prefijo"
            cmbAcabado.ValueMember = "Id"
            cmbAcabado.DatosVisibles = {"Prefijo", "Nombre"}
            cmbAcabado.DataSource = listAcab
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVidrios()
        Try
            mArticulos = New ClsArticulos
            Dim listArt As List(Of Articulo) = mArticulos.TraerxFamiliaMaterial(5)
            cmbVidrio.DisplayMember = "Referencia"
            cmbVidrio.ValueMember = "Id"
            cmbVidrio.DatosVisibles = {"Referencia", "Descripcion"}
            cmbVidrio.DataSource = listArt
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEspesor()
        Try
            mEspesores = New ClsEspesores
            Dim listEsp As List(Of Espesor) = mEspesores.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbEspesores.DisplayMember = "Prefijo"
            cmbEspesores.ValueMember = "Id"
            cmbEspesores.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbEspesores.DataSource = listEsp
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarColores()
        Try
            mAcabados = New ClsAcabados
            Dim listCol As List(Of Acabado) = mAcabados.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.VIDRIO)
            cmbcolorvidrio.DisplayMember = "Prefijo"
            cmbcolorvidrio.ValueMember = "Id"
            cmbcolorvidrio.DatosVisibles = {"Prefijo", "Nombre"}
            cmbcolorvidrio.DataSource = listCol
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarUnidades()
        Try
            mArticulos = New ClsArticulos
            Dim tbunis As DataTable = mArticulos.traerUnidades()
            tbunis = tbunis.AsEnumerable().Where(Function(x) {"MTS2", "MTL", "UND"}.Contains(Trim(x.ItemArray(0)))).AsDataView().ToTable()
            cmbuminstala.DisplayMember = tbunis.Columns(0).ColumnName
            cmbuminstala.ValueMember = tbunis.Columns(0).ColumnName
            cmbuminstala.DatosVisibles = {tbunis.Columns(0).ColumnName, tbunis.Columns(1).ColumnName}
            cmbuminstala.DataSource = tbunis
            cmbuminstala.SelectedIndex = 1
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarAnalizador(ByRef r As DataGridViewRow)
        Try
            Dim cp As New CargasPlantilla
            Dim analizador As AnalizadorLexico
            If r.Cells(especial.Index).Value Is Nothing Then
                analizador = New AnalizadorLexico
                cp.CargarPlantilla(Convert.ToInt32(r.Cells(id.Index).Value), analizador, ClsEnums.TipoCarga.COTIZA)
            Else
                analizador = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
            End If
            cp.ValorarAnalizador(analizador, _idCotiza, _versionCostoAcabado, _versionCostoNivel,
                                 _versionCostoKiloAluminio, _versionCostoVidrio, _versionCostoAccesorio,
                                 _versionCostoOtros)
            If CInt(r.Cells(id.Index).Value) > 0 Then
                cp.isFromCotiza = True
            End If
            r.Cells(especial.Index).Value = analizador
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim sw As Integer = Convert.ToInt32(r.Cells(tipoItem.Index).Value)
            Select Case sw
                Case = ClsEnums.FamiliasMateriales.DISEÑOS
                    If r.Cells(especial.Index).Value Is Nothing Then
                        cargarAnalizador(r)
                    End If
                    Dim fcargaplantilla As New FrmCargaPlantillas
                    fcargaplantilla.Id_Cotiza = _idCotiza
                    fcargaplantilla.IdPlantilla = Convert.ToInt32(r.Cells(idArticulo.Index).Value)
                    fcargaplantilla.Analizador = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                    fcargaplantilla.Factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                    fcargaplantilla.descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                    fcargaplantilla.CurId = r.Cells(id.Index).Value
                    fcargaplantilla.versionCostoKiloAluminio = _versionCostoKiloAluminio
                    fcargaplantilla.versionCostoVidrio = _versionCostoVidrio
                    fcargaplantilla.versionCostoAccesorio = _versionCostoAccesorio
                    fcargaplantilla.versionCostoAcabado = _versionCostoAcabado
                    fcargaplantilla.versionCostoNivel = _versionCostoNivel
                    fcargaplantilla.versionCostoOtrosArticulos = _versionCostoOtros
                    For Each v As Parametro In fcargaplantilla.Analizador.ListaVariables
                        fcargaplantilla.DiccionarioVariables.Add(v.Nombre, v.Valor)
                    Next
                    If fcargaplantilla.ShowDialog() = DialogResult.OK Then

                        Dim analiza As AnalizadorLexico = fcargaplantilla.Analizador
                        Dim pmodelo As New PlantillaModelo(fcargaplantilla.itPlantillas.selected_item.Item("Id"), fcargaplantilla.itPlantillas.selected_item.Item("Usuario_Creacion"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Fecha_Creacion"), fcargaplantilla.itPlantillas.selected_item.Item("Id_TipoModelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_Tipo_Modelo"), fcargaplantilla.itPlantillas.selected_item.Item("Tipo_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Id_ClasificacionModelo"), fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_Clasificacion_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Clasificacion_Modelo"), fcargaplantilla.itPlantillas.selected_item.Item("IdFamiliaModelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_Familia_Modelo"), fcargaplantilla.itPlantillas.selected_item.Item("Familia_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Id_Configuracion"), fcargaplantilla.itPlantillas.selected_item.Item("Configuracion"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Id_CaracteristicasAd"), fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_caracteristica_ad"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Caracteristica_Adicional"), fcargaplantilla.itPlantillas.selected_item.Item("Nombre_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Descripcion"), fcargaplantilla.itPlantillas.selected_item.Item("Usuario_Modifiacion"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Fecha_Modificacion"), fcargaplantilla.itPlantillas.selected_item.Item("Id_Estado"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Estado"), 0, False,
                                              Convert.ToBoolean(fcargaplantilla.itPlantillas.selected_item.Item("Calcular_Nsr")))
                        r.Cells(calcular_nsr.Index).Value = pmodelo.Calcular_NSR
                        calculo = New ClsCalculos
                        calculo.tasaImpuesto = _tasaImpuestoGlobal
                        calculo.indAIU = _indAIU
                        Dim idAcabado As Integer = DirectCast(acabadoPerf.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("ACABADO").Valor).IdDb
                        Dim idVidrio As Integer = 838
                        Dim vidtemp As Boolean = False
                        Dim idColorVidrio As Integer = 32
                        Dim colortemp As Boolean = False
                        Dim idEspesor As Integer = 1
                        Dim espesortemp As Boolean = False
                        If analiza.ListaVariables.Contains("TIPO_VIDRIO") Then
                            idVidrio = DirectCast(vidrio.DataSource, List(Of articuloTemporal)).First(Function(x) x.Referencia = analiza.ListaVariables.Item("TIPO_VIDRIO").Valor).IdDb
                            vidtemp = DirectCast(vidrio.DataSource, List(Of articuloTemporal)).First(Function(x) x.Referencia = analiza.ListaVariables.Item("TIPO_VIDRIO").Valor).Temporal
                        End If
                        If analiza.ListaVariables.Contains("COLOR_VIDRIO") Then
                            idColorVidrio = DirectCast(colorVidrio.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("COLOR_VIDRIO").Valor).IdDb
                            colortemp = DirectCast(colorVidrio.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("COLOR_VIDRIO").Valor).Temporal
                        End If
                        If analiza.ListaVariables.Contains("ESPESOR") Then
                            idEspesor = DirectCast(espesor.DataSource, List(Of espesorTemporal)).First(Function(x) Convert.ToString(x.Prefijo) = Convert.ToString(analiza.ListaVariables.Item("ESPESOR").Valor)).IdDb
                            espesortemp = DirectCast(espesor.DataSource, List(Of espesorTemporal)).First(Function(x) Convert.ToString(x.Prefijo) = Convert.ToString(analiza.ListaVariables.Item("ESPESOR").Valor)).Temporal
                        End If

                        Dim costoVidrio, costoPerfiles, costoAccesorios,
                            costoOtros, vlrDespVidrio, vlrDespPerfiles,
                            vlrDespAccesorio, vlrDespOtros, costounitario,
                        costo_instalacion As Decimal
                        costoVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        costoPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        costoAccesorios = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        costoOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                        vlrDespVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        vlrDespPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        vlrDespAccesorio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        vlrDespOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                        costounitario = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Unitario))
                        costo_instalacion = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Instalacion_Total))

                        calculo.Calcular_Disenio(costounitario, Convert.ToInt32(analiza.ListaVariables.Item("CANTIDAD").Valor),
                                        Convert.ToDecimal(analiza.ListaVariables.Item("PIEZAS_X_UND").Valor),
                                        Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor),
                                        Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor),
                                                 nudDescuento.Value, fcargaplantilla.Factor, nudPrecioInstalacion.Value,
                                                 costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costo_instalacion)

                        llenarFila(r, pmodelo.Id, 0, pmodelo.NombreModelo, pmodelo.Descripcion, analiza.ListaVariables.Item("CANTIDAD").Valor,
                                   analiza.ListaVariables.Item("PIEZAS_X_UND").Valor, Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor),
                                   Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor), calculo.MetrosCuadrados, idAcabado, idVidrio, idColorVidrio,
                                   idEspesor, "UND", nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario,
                                   calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.Costo_Instalacion, calculo.PrecioInstalacion, costoVidrio,
                                   costoPerfiles, costoAccesorios, costoOtros, fcargaplantilla.Factor, ClsEnums.FamiliasMateriales.DISEÑOS,
                                   Convert.ToInt32(r.Cells(id.Index).Value), _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, False, colortemp, espesortemp, analiza,
                                   True, vlrDespVidrio, vlrDespPerfiles, vlrDespAccesorio, vlrDespOtros)
                    Else
                        r.Cells(especial.Index).Value = fcargaplantilla.Analizador
                    End If
                Case = ClsEnums.FamiliasMateriales.ACCESORIOS
                    Dim frm As New FrmAddAccesorio
                    Dim mArtTemp As New ClsArticuloTemporal
                    frm.IdCotiza = _idCotiza
                    frm.curId = r.Cells(id.Index).Value
                    frm.Accesorio = mArtTemp.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.ACCESORIOS,
                                                                             r.Cells(referencia.Index).Value)
                    frm.Acabado = _listAcabados.FirstOrDefault(Function(a) a.Id = CInt(r.Cells(acabadoPerf.Index).Value))
                    frm.Cantidad = Convert.ToDecimal(r.Cells(cantidad.Index).Value)
                    frm.PiezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                    frm.Factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                    frm.Descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                    frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
                    frm.VersionCostoAccesorio = _versionCostoAccesorio
                    frm.DTableTrabajos = r.Cells(especial.Index).Value
                    frm.curId = r.Cells(id.Index).Value
                    If frm.ShowDialog = DialogResult.OK Then
                        calculo = New ClsCalculos
                        calculo.tasaImpuesto = _tasaImpuestoGlobal
                        calculo.indAIU = _indAIU
                        If frm.Accesorio.Temporal = True Or frm.Acabado.Temporal = True Then
                            calculo.Temporales(frm.Accesorio, frm.Cantidad, frm.PiezasxUnidad, 0, 0, Nothing, Nothing, Nothing, Nothing, nudDescuento.Value,
                                               FactorGlobal.tasa, nudPrecioInstalacion.Value, frm.Accesorio.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                            llenarFila(r, If(frm.Accesorio.Temporal = True, 0, frm.Accesorio.Id), If(frm.Accesorio.Temporal = True, frm.Accesorio.Id, 0),
                                       frm.Accesorio.Referencia, frm.Accesorio.Descripcion, frm.Cantidad, frm.PiezasxUnidad, 0, 0, 0,
                                       frm.Acabado.IdDb, 838, 32, 1, frm.Accesorio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                                       calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                                       calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, calculo.CostoTotal, 0, frm.Factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.curId,
                                       _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, calculo.vlrdespOtros, 0)
                        Else
                            calculo.Calcular_Accesorios(frm.Accesorio.Id, frm.Cantidad, frm.PiezasxUnidad, _versionCostoAccesorio,
                                                        frm.Accesorio.PorcentajeDesperdicio, frm.Factor, nudDescuento.Value,
                                                        frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                            llenarFila(r, frm.Accesorio.Id, 0, frm.Accesorio.Referencia, frm.Accesorio.Descripcion, frm.Cantidad, frm.PiezasxUnidad, 0, 0, 0,
                                       frm.Acabado.IdDb, 838, 32, 1, frm.Accesorio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                                       calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                       frm.CostoInstalacionUnitario, 0, 0, calculo.CostoTotal, 0, frm.Factor, ClsEnums.FamiliasMateriales.ACCESORIOS, frm.curId, _IdTasaImpuestoGlobal,
                                       _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, calculo.vlrdespAccesorios, 0)
                        End If
                    End If

                Case = ClsEnums.FamiliasMateriales.PERFILERIA
                    Dim frm As New FrmAddPerfil
                    frm.IdCotiza = _idCotiza
                    frm.Perfil = _listArticulos.FirstOrDefault(Function(a) a.IdDb = CInt(r.Cells(idArticulo.Index).Value) And a.Temporal = False)
                    frm.Acabado = _listAcabados.FirstOrDefault(Function(a) a.Id = CInt(r.Cells(acabadoPerf.Index).Value))
                    frm.ancho = Convert.ToDecimal(r.Cells(ancho.Index).Value)
                    frm.cantidad = Convert.ToDecimal(r.Cells(cantidad.Index).Value)
                    frm.piezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                    frm.factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                    frm.descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                    frm.CurId = r.Cells(id.Index).Value
                    frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
                    frm.VersionCostoAcabado = _versionCostoAcabado
                    frm.VersionCostoNivel = _versionCostoNivel
                    frm.VersionCostoKAluminio = _versionCostoKiloAluminio
                    frm.DTableTrabajos = r.Cells(especial.Index).Value
                    If frm.ShowDialog() = DialogResult.OK Then
                        calculo = New ClsCalculos
                        calculo.tasaImpuesto = _tasaImpuestoGlobal
                        calculo.indAIU = _indAIU
                        If frm.Perfil.Temporal = True Or frm.Acabado.Temporal = True Then
                            calculo.Temporales(frm.Perfil, frm.cantidad, frm.piezasxUnidad, frm.ancho, 0, frm.Acabado, Nothing, Nothing, Nothing,
                                               nudDescuento.Value, frm.factor, nudPrecioInstalacion.Value, frm.Perfil.PorcentajeDesperdicio,
                                               _idCotiza, frm.DTableTrabajos)
                            llenarFila(r, If(frm.Perfil.Temporal = True, 0, frm.Perfil.Id), If(frm.Perfil.Temporal = True, frm.Perfil.Id, 0),
                                       frm.Perfil.Referencia, frm.Perfil.Descripcion, frm.cantidad, frm.piezasxUnidad, frm.ancho,
                                       0, 0, frm.Acabado.Id, 838, 32, 1, frm.Perfil.UnidadMedida,
                                       nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal,
                                       calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, calculo.CostoTotal, 0, 0, frm.factor,
                                       ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal,
                                       False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                        Else
                            calculo.Calcular_Perfiles(frm.Perfil.Id, frm.Acabado.Id, _versionCostoAcabado, _versionCostoNivel,
                                            _versionCostoKiloAluminio, frm.ancho, frm.cantidad, frm.piezasxUnidad,
                                                      frm.Perfil.PorcentajeDesperdicio, frm.factor, nudDescuento.Value, nudPrecioInstalacion.Value,
                                                      frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                            llenarFila(r, frm.Perfil.Id, 0, frm.Perfil.Referencia, frm.Perfil.Descripcion, frm.cantidad,
                                       frm.piezasxUnidad, frm.ancho, 0, 0, frm.Acabado.Id,
                                       838, 32, 1, frm.Perfil.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                                       calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                       frm.CostoInstalacionUnitario, 0, calculo.CostoPerfiles, 0, 0, frm.factor, ClsEnums.FamiliasMateriales.PERFILERIA, frm.CurId,
                                       _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False,
                                       0, calculo.vlrdespPerfiles, 0, 0)
                        End If
                    End If

                Case = ClsEnums.FamiliasMateriales.VIDRIO
                    Dim frm As New FrmAddVidrio
                    frm.IdCotiza = _idCotiza
                    frm.tform = ClsEnums.TiOperacion.MODIFICAR
                    frm.Vidrio = _listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(vidrio.Index).Value))
                    frm.Color = _listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(colorVidrio.Index).Value))
                    frm.Espesor = _listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(espesor.Index).Value))
                    frm.cantidad = Convert.ToInt32(r.Cells(cantidad.Index).Value)
                    frm.ancho = Convert.ToDecimal(r.Cells(ancho.Index).Value)
                    frm.alto = Convert.ToDecimal(r.Cells(alto.Index).Value)
                    frm.piezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                    frm.Factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                    frm.descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                    frm.CurId = r.Cells(id.Index).Value
                    frm.VersionCostoVidrio = _versionCostoVidrio
                    frm.ListArticulos = _listArticulos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO And a.IdDb <> 838).ToList
                    frm.ListColores = _listColores
                    frm.ListEspesores = _listEspesores.Where(Function(a) a.Id <> 1).ToList
                    frm.DTableTrabajos = r.Cells(especial.Index).Value
                    If frm.ShowDialog() = DialogResult.OK Then
                        calculo = New ClsCalculos
                        calculo.tasaImpuesto = _tasaImpuestoGlobal
                        calculo.indAIU = _indAIU
                        If frm.esVidrioTemporal = False And frm.esColorTemporal = False And frm.esEspesorTemporal = False Then
                            calculo.Calcular_Vidrios(frm.Vidrio.IdDb, frm.Espesor.IdDb, frm.Color.IdDb, _versionCostoVidrio, frm.ancho,
                                                     frm.alto, frm.cantidad, frm.piezasxUnidad, frm.Vidrio.PorcentajeDesperdicio,
                                                     frm.Factor, nudDescuento.Value, nudPrecioInstalacion.Value, frm.CostoInstalacionUnitario,
                                                     frm.DTableTrabajos)
                            llenarFila(r, frm.Vidrio.IdDb, 0, frm.Vidrio.Referencia, frm.Vidrio.Descripcion, frm.cantidad,
                                               frm.piezasxUnidad, frm.ancho, frm.alto, calculo.MetrosCuadrados, 32, frm.Vidrio.IdDb, frm.Color.IdDb,
                                               frm.Espesor.IdDb, frm.Vidrio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                                               calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                               frm.CostoInstalacionUnitario, calculo.CostoVidrio, 0, 0, 0, frm.Factor, ClsEnums.FamiliasMateriales.VIDRIO, frm.CurId, _IdTasaImpuestoGlobal,
                                               _tasaImpuestoGlobal, False, frm.esColorTemporal, frm.esEspesorTemporal, frm.DTableTrabajos, False, calculo.vlrdespVidrio, 0, 0, 0)
                        Else
                            calculo.Temporales(frm.Vidrio, frm.cantidad, frm.piezasxUnidad, frm.ancho, frm.alto, Nothing, frm.Vidrio, frm.Color,
                                                       frm.Espesor, nudDescuento.Value, frm.Factor, nudPrecioInstalacion.Value,
                                                       frm.Vidrio.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                            llenarFila(r, If(frm.Vidrio.Temporal = True, 0, frm.Vidrio.IdDb), If(frm.Vidrio.Temporal = True, frm.Vidrio.IdDb, 0),
                                               frm.Vidrio.Referencia, frm.Vidrio.Descripcion, frm.cantidad, frm.piezasxUnidad, frm.ancho, frm.alto,
                                               calculo.MetrosCuadrados, 32, frm.Vidrio.IdDb, frm.Color.IdDb, frm.Espesor.IdDb, frm.Vidrio.UnidadMedida,
                                               nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal,
                                               calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                               frm.CostoInstalacionUnitario, calculo.CostoVidrio, 0, 0, 0,
                                               frm.Factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal,
                                               False, frm.esColorTemporal, frm.esEspesorTemporal, frm.DTableTrabajos, False, calculo.vlrdespVidrio, 0, 0, 0)
                        End If
                    End If

                Case = ClsEnums.FamiliasMateriales.OTROS
                    Dim frm As New FrmAddOtros
                    Dim mArtTemp As New ClsArticuloTemporal
                    frm.IdCotiza = _idCotiza
                    frm.Articulo = mArtTemp.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.OTROS, r.Cells(referencia.Index).Value)
                    frm.Acabado = _listAcabados.FirstOrDefault(Function(a) a.Id = CInt(r.Cells(acabadoPerf.Index).Value))
                    frm.cantidad = Convert.ToInt32(r.Cells(cantidad.Index).Value)
                    frm.piezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                    frm.factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                    frm.descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                    frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
                    frm.VersionCostoOtros = _versionCostoOtros
                    frm.CurId = r.Cells(id.Index).Value
                    frm.DTableTrabajos = r.Cells(especial.Index).Value
                    If frm.ShowDialog() = DialogResult.OK Then
                        calculo = New ClsCalculos
                        calculo.tasaImpuesto = _tasaImpuestoGlobal
                        calculo.indAIU = _indAIU
                        If frm.Articulo.Temporal = True Or frm.Acabado.Temporal = True Then
                            calculo.Temporales(frm.Articulo, frm.cantidad, frm.piezasxUnidad, 0, 0, Nothing, Nothing, Nothing, Nothing, nudDescuento.Value,
                                               frm.factor, nudPrecioInstalacion.Value, frm.Articulo.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                            llenarFila(r, If(frm.Articulo.Temporal = True, 0, frm.Articulo.Id), If(frm.Articulo.Temporal = True, frm.Articulo.Id, 0),
                                       frm.Articulo.Referencia, frm.Articulo.Descripcion, frm.cantidad, frm.piezasxUnidad, 0, 0, 0,
                                       frm.Acabado.Id, 838, 32, 1, frm.Articulo.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                                       calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                                       calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, 0, calculo.CostoTotal, frm.factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId,
                                       _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                        Else
                            calculo.Calcular_Otros(frm.Articulo.Id, frm.cantidad, frm.piezasxUnidad, _versionCostoOtros,
                                                   frm.Articulo.PorcentajeDesperdicio, frm.factor, nudDescuento.Value,
                                                   frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                            llenarFila(r, frm.Articulo.Id, 0, frm.Articulo.Referencia, frm.Articulo.Descripcion, frm.cantidad, frm.piezasxUnidad,
                                       0, 0, 0, frm.Acabado.Id, 838, 32, 1, frm.Articulo.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                                       calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                                       calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, 0, calculo.CostoOtros, frm.factor, ClsEnums.FamiliasMateriales.OTROS, frm.CurId,
                                       _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, False, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                        End If
                    End If

                Case = ClsEnums.FamiliasMateriales.TEMPORAL
                    Dim familia As Integer
                    Dim art As articuloTemporal = New articuloTemporal
                    If CInt(r.Cells(idArticulo.Index).Value) = 0 And CInt(r.Cells(idArticuloTemp.Index).Value) <> 0 Then
                        mArticuloTemporal = New ClsArticuloTemporal
                        familia = mArticuloTemporal.TraerxReferencia(r.Cells(referencia.Index).Value).IdFamiliaMaterial
                        art = mArticuloTemporal.TraerxReferencia(r.Cells(referencia.Index).Value)
                    ElseIf CInt(r.Cells(idArticulo.Index).Value) <> 0 And CInt(r.Cells(idArticuloTemp.Index).Value) = 0 Then
                        mArticulos = New ClsArticulos
                        familia = mArticulos.TraerxReferencia(r.Cells(referencia.Index).Value).IdFamiliaMaterial
                        art = _listArticulos.FirstOrDefault(Function(a) a.IdFamiliaMaterial = familia And
                                                                a.IdDb = mArticulos.TraerxReferencia(r.Cells(referencia.Index).Value).Id And
                                                                a.Temporal = False)
                    End If
                    Select Case familia
                        Case = ClsEnums.FamiliasMateriales.ACCESORIOS
                            Dim frm As New FrmAddAccesorio
                            frm.IdCotiza = _idCotiza
                            frm.Accesorio = art
                            frm.Acabado = _listAcabados.FirstOrDefault(Function(a) a.Id = CInt(r.Cells(acabadoPerf.Index).Value))
                            frm.Cantidad = Convert.ToInt32(r.Cells(cantidad.Index).Value)
                            frm.PiezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                            frm.Factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                            frm.Descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                            frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
                            frm.VersionCostoAccesorio = _versionCostoAccesorio
                            frm.DTableTrabajos = r.Cells(especial.Index).Value
                            frm.curId = r.Cells(id.Index).Value
                            If frm.ShowDialog() = DialogResult.OK Then
                                calculo = New ClsCalculos
                                calculo.tasaImpuesto = _tasaImpuestoGlobal
                                calculo.indAIU = _indAIU
                                If frm.Accesorio.Temporal = True Or frm.Acabado.Temporal = True Then
                                    calculo.Temporales(frm.Accesorio, frm.Cantidad, frm.PiezasxUnidad, 0, 0, Nothing, Nothing, Nothing, Nothing, nudDescuento.Value,
                                                       frm.Factor, nudPrecioInstalacion.Value, frm.Accesorio.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                                    llenarFila(r, If(frm.Accesorio.Temporal = True, 0, frm.Accesorio.Id), If(frm.Accesorio.Temporal = True, frm.Accesorio.Id, 0),
                                               frm.Accesorio.Referencia, frm.Accesorio.Descripcion, frm.Cantidad, frm.PiezasxUnidad, 0, 0, 0,
                                               frm.Acabado.IdDb, 838, 32, 1, frm.Accesorio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                                               calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                                               calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, calculo.CostoTotal, 0, frm.Factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.curId,
                                               _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                                Else
                                    calculo.Calcular_Accesorios(frm.Accesorio.Id, frm.Cantidad, frm.PiezasxUnidad, _versionCostoAccesorio,
                                                                frm.Accesorio.PorcentajeDesperdicio, frm.Factor, nudDescuento.Value, frm.CostoInstalacionUnitario,
                                                                frm.DTableTrabajos)
                                    llenarFila(r, frm.Accesorio.Id, 0, frm.Accesorio.Referencia, frm.Accesorio.Descripcion, frm.Cantidad, frm.PiezasxUnidad, 0, 0, 0,
                                               frm.Acabado.IdDb, 838, 32, 1, frm.Accesorio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                                               calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                               frm.CostoInstalacionUnitario, 0, 0, calculo.CostoTotal, 0, frm.Factor, ClsEnums.FamiliasMateriales.ACCESORIOS, frm.curId, _IdTasaImpuestoGlobal,
                                               _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, calculo.vlrdespAccesorios, 0)
                                End If
                            End If
                        Case = ClsEnums.FamiliasMateriales.PERFILERIA
                            Dim frm As New FrmAddPerfil
                            frm.IdCotiza = _idCotiza
                            frm.Perfil = art
                            frm.Acabado = _listAcabados.FirstOrDefault(Function(a) a.Id = CInt(r.Cells(acabadoPerf.Index).Value))
                            frm.ancho = Convert.ToDecimal(r.Cells(ancho.Index).Value)
                            frm.cantidad = Convert.ToInt32(r.Cells(cantidad.Index).Value)
                            frm.piezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                            frm.factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                            frm.descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                            frm.CurId = r.Cells(id.Index).Value
                            frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
                            frm.VersionCostoAcabado = _versionCostoAcabado
                            frm.VersionCostoNivel = _versionCostoNivel
                            frm.VersionCostoKAluminio = _versionCostoKiloAluminio
                            frm.DTableTrabajos = r.Cells(especial.Index).Value
                            If frm.ShowDialog() = DialogResult.OK Then
                                calculo = New ClsCalculos
                                calculo.tasaImpuesto = _tasaImpuestoGlobal
                                calculo.indAIU = _indAIU
                                If frm.Perfil.Temporal = True Or frm.Acabado.Temporal = True Then
                                    calculo.Temporales(frm.Perfil, frm.cantidad, frm.piezasxUnidad, frm.ancho, 0, frm.Acabado, Nothing, Nothing, Nothing,
                                                       nudDescuento.Value, frm.factor, nudPrecioInstalacion.Value, frm.Perfil.PorcentajeDesperdicio,
                                                       _idCotiza, frm.DTableTrabajos)
                                    llenarFila(r, If(frm.Perfil.Temporal = True, 0, frm.Perfil.Id), If(frm.Perfil.Temporal = True, frm.Perfil.Id, 0),
                                               frm.Perfil.Referencia, frm.Perfil.Descripcion, frm.cantidad, frm.piezasxUnidad, frm.ancho,
                                               0, 0, frm.Acabado.Id, 838, 32, 1, frm.Perfil.UnidadMedida,
                                               nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal,
                                               calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                               frm.CostoInstalacionUnitario, 0, calculo.CostoTotal, 0, 0, frm.factor,
                                               ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal,
                                               False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                                Else
                                    calculo.Calcular_Perfiles(frm.Perfil.Id, frm.Acabado.Id, _versionCostoAcabado, _versionCostoNivel,
                                                              _versionCostoKiloAluminio, frm.ancho, frm.cantidad, frm.piezasxUnidad,
                                                              frm.Perfil.PorcentajeDesperdicio, frm.factor, nudDescuento.Value, nudPrecioInstalacion.Value,
                                                              frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                                    llenarFila(r, frm.Perfil.Id, 0, frm.Perfil.Referencia, frm.Perfil.Descripcion, frm.cantidad,
                                               frm.piezasxUnidad, frm.ancho, 0, 0, frm.Acabado.Id,
                                               838, 32, 1, frm.Perfil.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                                               calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                               frm.CostoInstalacionUnitario, 0, calculo.CostoPerfiles, 0, 0, frm.factor, ClsEnums.FamiliasMateriales.PERFILERIA, frm.CurId,
                                               _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False,
                                               0, calculo.vlrdespPerfiles, 0, 0)
                                End If
                            End If
                        Case = ClsEnums.FamiliasMateriales.VIDRIO
                            Dim frm As New FrmAddVidrio
                            frm.IdCotiza = _idCotiza
                            frm.tform = ClsEnums.TiOperacion.MODIFICAR
                            frm.Vidrio = _listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(vidrio.Index).Value))
                            frm.Color = _listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(colorVidrio.Index).Value))
                            frm.Espesor = _listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(espesor.Index).Value))
                            frm.cantidad = Convert.ToInt32(r.Cells(cantidad.Index).Value)
                            frm.ancho = Convert.ToDecimal(r.Cells(ancho.Index).Value)
                            frm.alto = Convert.ToDecimal(r.Cells(alto.Index).Value)
                            frm.piezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                            frm.Factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                            frm.descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                            frm.CurId = r.Cells(id.Index).Value
                            frm.VersionCostoVidrio = _versionCostoVidrio
                            frm.ListArticulos = _listArticulos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO And
                                                                         a.IdDb <> 838).ToList
                            frm.ListColores = _listColores
                            frm.ListEspesores = _listEspesores.Where(Function(a) a.IdDb <> 1).ToList
                            frm.DTableTrabajos = r.Cells(especial.Index).Value
                            If frm.ShowDialog() = DialogResult.OK Then
                                calculo = New ClsCalculos
                                calculo.tasaImpuesto = _tasaImpuestoGlobal
                                calculo.indAIU = _indAIU
                                If frm.esVidrioTemporal = False And frm.esColorTemporal = False And frm.esEspesorTemporal = False Then
                                    calculo.Calcular_Vidrios(frm.Vidrio.IdDb, frm.Espesor.IdDb, frm.Color.IdDb, _versionCostoVidrio,
                                                             frm.ancho, frm.alto, frm.cantidad, frm.piezasxUnidad,
                                                             frm.Vidrio.PorcentajeDesperdicio, frm.Factor, frm.descuento, nudPrecioInstalacion.Value,
                                                             frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                                    llenarFila(r, frm.Vidrio.IdDb, 0, frm.Vidrio.Referencia, frm.Vidrio.Descripcion, frm.cantidad,
                                               frm.piezasxUnidad, frm.ancho, frm.alto, calculo.MetrosCuadrados, 32, frm.Vidrio.IdDb, frm.Color.IdDb,
                                               frm.Espesor.IdDb, frm.Vidrio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                                               calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                               frm.CostoInstalacionUnitario, calculo.CostoVidrio, 0, 0, 0, frm.Factor, ClsEnums.FamiliasMateriales.VIDRIO, frm.CurId, _IdTasaImpuestoGlobal,
                                               _tasaImpuestoGlobal, False, frm.esColorTemporal, frm.esEspesorTemporal, frm.DTableTrabajos, False, calculo.vlrdespVidrio, 0, 0, 0)
                                Else
                                    calculo.Temporales(frm.Vidrio, frm.cantidad, frm.piezasxUnidad, frm.ancho, frm.alto, Nothing, frm.Vidrio, frm.Color,
                                                       frm.Espesor, nudDescuento.Value, frm.Factor, nudPrecioInstalacion.Value,
                                                       frm.Vidrio.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                                    llenarFila(r, If(frm.Vidrio.Temporal = True, 0, frm.Vidrio.IdDb), If(frm.Vidrio.Temporal = True, frm.Vidrio.IdDb, 0),
                                               frm.Vidrio.Referencia, frm.Vidrio.Descripcion, frm.cantidad, frm.piezasxUnidad, frm.ancho, frm.alto,
                                               calculo.MetrosCuadrados, 32, frm.Vidrio.IdDb, frm.Color.IdDb, frm.Espesor.IdDb, frm.Vidrio.UnidadMedida,
                                               nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal,
                                               calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                                               frm.CostoInstalacionUnitario, calculo.CostoVidrio, 0, 0, 0,
                                               frm.Factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal,
                                               False, frm.esColorTemporal, frm.esEspesorTemporal, frm.DTableTrabajos, False, calculo.vlrdespVidrio, 0, 0, 0)
                                End If
                            End If
                        Case = ClsEnums.FamiliasMateriales.OTROS
                            Dim frm As New FrmAddOtros
                            frm.IdCotiza = _idCotiza
                            frm.Articulo = art
                            frm.Acabado = _listAcabados.FirstOrDefault(Function(a) a.Id = CInt(r.Cells(acabadoPerf.Index).Value))
                            frm.cantidad = Convert.ToDecimal(r.Cells(cantidad.Index).Value)
                            frm.piezasxUnidad = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                            frm.factor = Convert.ToDecimal(r.Cells(factor.Index).Value)
                            frm.descuento = Convert.ToDecimal(r.Cells(descuento.Index).Value)
                            frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
                            frm.VersionCostoOtros = _versionCostoOtros
                            frm.CurId = r.Cells(id.Index).Value
                            frm.DTableTrabajos = r.Cells(especial.Index).Value
                            If frm.ShowDialog() = DialogResult.OK Then
                                calculo = New ClsCalculos
                                calculo.tasaImpuesto = _tasaImpuestoGlobal
                                calculo.indAIU = _indAIU
                                If frm.Articulo.Temporal = True Or frm.Acabado.Temporal = True Then
                                    calculo.Temporales(frm.Articulo, frm.cantidad, frm.piezasxUnidad, 0, 0, Nothing, Nothing, Nothing, Nothing, nudDescuento.Value,
                                                       frm.factor, nudPrecioInstalacion.Value, frm.Articulo.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                                    llenarFila(r, If(frm.Articulo.Temporal = True, 0, frm.Articulo.Id), If(frm.Articulo.Temporal = True, frm.Articulo.Id, 0),
                                               frm.Articulo.Referencia, frm.Articulo.Descripcion, frm.cantidad, frm.piezasxUnidad, 0, 0, 0,
                                               frm.Acabado.Id, 838, 32, 1, frm.Articulo.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                                               calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                                               calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, 0, calculo.CostoTotal, frm.factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId,
                                               _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                                Else
                                    calculo.Calcular_Otros(frm.Articulo.Id, frm.cantidad, frm.piezasxUnidad, _versionCostoOtros,
                                                           frm.Articulo.PorcentajeDesperdicio, frm.factor, nudDescuento.Value,
                                                           frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                                    llenarFila(r, frm.Articulo.Id, 0, frm.Articulo.Referencia, frm.Articulo.Descripcion, frm.cantidad, frm.piezasxUnidad,
                                               0, 0, 0, frm.Acabado.Id, 838, 32, 1, frm.Articulo.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                                               calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                                               calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, 0, calculo.CostoOtros, frm.factor, ClsEnums.FamiliasMateriales.OTROS,
                                               frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, False, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                                End If
                            End If
                    End Select
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Duplicar()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim nr As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
            dwItem.Columns.Cast(Of DataGridViewColumn).ToList.ForEach(Sub(col)
                                                                          If col.Index = id.Index Then
                                                                              nr.Cells(col.Index).Value = 0
                                                                          Else
                                                                              nr.Cells(col.Index).Value = r.Cells(col.Index).Value
                                                                          End If
                                                                      End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)

            ' If Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
            If String.IsNullOrEmpty(Convert.ToString(r.Cells(id.Index).Value)) Then
                QuitarEstructurasxIndex(r.Index, egmodelo.EstructuraPrincipal)
            Else
                mMovitoHijo = New ClsMovitoHijos
                mMovitoHijo.cambioEstado(r.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                QuitarEstructurasxId(Convert.ToInt32(r.Cells(id.Index).Value), egmodelo.EstructuraPrincipal)
            End If
            'End If
            dwItem.Rows.Remove(r)
            egmodelo.Refresh()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub MostrarMateriales()
        Try
            Dim frm As New FrmListaMateriales
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            If r.Cells(especial.Index).Value Is Nothing Then
                cargarAnalizador(r)
            End If
            frm.IdCotiza = _idCotiza
            frm.versionCostoAcabado = _versionCostoAcabado
            frm.versionCostoAccesorio = _versionCostoAccesorio
            frm.versionCostoKiloAluminio = _versionCostoKiloAluminio
            frm.versionCostoNivel = _versionCostoNivel
            frm.versionCostoOtrosArticulos = _versionCostoOtros
            frm.versionCostoVidrio = _versionCostoVidrio
            frm.Tipo_Formulario = tform
            frm.lista = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico).ListaMateriales
            frm.Text += " " & Convert.ToString(r.Cells(referencia.Index).Value)
            If frm.ShowDialog() = DialogResult.OK Then
                r.Cells(actualizar_plantilla.Index).Value = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub llenarFila(r As DataGridViewRow, idArticulo As Integer, idArticuloTemp As Integer, referencia As String, descripcion As String, cantidad As Integer,
                           piezasxUnidad As Decimal, ancho As Decimal, alto As Decimal, mtCuadrados As Decimal, idAcabadoPerf As Integer, idVidrio As Integer,
                           idColorVidrio As Integer, idEspesor As Integer, unidadMedida As String, descuento As Decimal, valorDescuento As Decimal, costoUnitario As Decimal,
                           precioVentaUnitario As Decimal, costoTotal As Decimal, precioTotal As Decimal, valorInstalacion As Decimal, precioInstalacion As Decimal,
                           costo_instalacion As Decimal, costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorios As Decimal, costoOtros As Decimal, factor As Decimal, tipoItem As Integer,
                           idFila As Integer, idtasaImpuesto As Integer, tasaImpuesto As Decimal, acabadoTemp As Boolean, colorTemp As Boolean,
                           espesorTemp As Boolean, Optional especial As Object = Nothing, Optional actualizar As Boolean = False, Optional vlrDespVidrio As Decimal = 0,
                           Optional vlrDespPerfiles As Decimal = 0, Optional vlrDespAccesorios As Decimal = 0, Optional vlrDespOtro As Decimal = 0)
        Try
            r.Cells(Me.id.Index).Value = idFila
            r.Cells(Me.idArticulo.Index).Value = idArticulo
            r.Cells(Me.idArticuloTemp.Index).Value = idArticuloTemp
            r.Cells(Me.referencia.Index).Value = referencia
            r.Cells(Me.descripcion.Index).Value = descripcion
            r.Cells(Me.cantidad.Index).Value = cantidad
            r.Cells(Me.piezasXUnidad.Index).Value = piezasxUnidad
            r.Cells(Me.ancho.Index).Value = ancho
            r.Cells(Me.alto.Index).Value = alto
            r.Cells(Me.mtCuadrados.Index).Value = mtCuadrados
            Dim acab As acabadoTemporal = _listAcabados.FirstOrDefault(Function(a) a.IdDb = idAcabadoPerf And a.Temporal = acabadoTemp)
            If acab IsNot Nothing Then
                If DirectCast(acabadoPerf.DataSource, List(Of acabadoTemporal)).FirstOrDefault(Function(n) n.Id = acab.Id) IsNot Nothing Then
                    r.Cells(Me.acabadoPerf.Index).Value = acab.Id
                Else
                    r.Cells(Me.acabadoPerf.Index).Value = idAcabadoPerf
                End If
            Else
                r.Cells(Me.acabadoPerf.Index).Value = idAcabadoPerf
            End If

            Dim tempVid As Boolean = False
            If idVidrio <> 838 Then
                If idArticulo = 0 And idArticuloTemp <> 0 Then
                    tempVid = True
                ElseIf idArticulo <> 0 And idArticuloTemp = 0 Then
                    tempVid = False
                End If
            End If

            Dim vidv As articuloTemporal = _listArticulos.FirstOrDefault(Function(a) a.IdDb = idVidrio And a.Temporal = tempVid)
            If vidv IsNot Nothing Then
                If DirectCast(vidrio.DataSource, List(Of articuloTemporal)).FirstOrDefault(Function(n) n.Id = vidv.Id) IsNot Nothing Then
                    r.Cells(Me.vidrio.Index).Value = vidv.Id
                Else
                    r.Cells(Me.vidrio.Index).Value = idVidrio
                End If
            Else
                r.Cells(Me.vidrio.Index).Value = idVidrio
            End If

            Dim colv As acabadoTemporal = _listColores.FirstOrDefault(Function(a) a.IdDb = idColorVidrio And a.Temporal = colorTemp)
            If colv IsNot Nothing Then
                If DirectCast(colorVidrio.DataSource, List(Of acabadoTemporal)).FirstOrDefault(Function(n) n.Id = colv.Id) IsNot Nothing Then
                    r.Cells(Me.colorVidrio.Index).Value = colv.Id
                Else
                    r.Cells(Me.colorVidrio.Index).Value = idColorVidrio
                End If
            Else
                r.Cells(Me.colorVidrio.Index).Value = idColorVidrio
            End If

            Dim espev As espesorTemporal = _listEspesores.FirstOrDefault(Function(a) a.IdDb = idEspesor And a.Temporal = espesorTemp)
            If espev IsNot Nothing Then
                If DirectCast(espesor.DataSource, List(Of espesorTemporal)).FirstOrDefault(Function(n) n.Id = espev.Id) IsNot Nothing Then
                    r.Cells(Me.espesor.Index).Value = espev.Id
                Else
                    r.Cells(Me.espesor.Index).Value = idEspesor
                End If
            Else
                r.Cells(Me.espesor.Index).Value = idEspesor
            End If

            r.Cells(Me.unidadMedida.Index).Value = unidadMedida
            r.Cells(Me.descuento.Index).Value = descuento
            r.Cells(Me.valorDescuento.Index).Value = valorDescuento
            r.Cells(Me.precioUnitario.Index).Value = Round(precioVentaUnitario)
            r.Cells(Me.precioTotal.Index).Value = Round(precioTotal)
            r.Cells(Me.precioMtInstalacion.Index).Value = valorInstalacion
            r.Cells(Me.precioInstalacion.Index).Value = Round(precioInstalacion)
            r.Cells(Me.costoinstalacion.Index).Value = Round(costo_instalacion)
            r.Cells(Me.costoUnitario.Index).Value = Round(costoUnitario)
            r.Cells(Me.costoTotal.Index).Value = Round(costoTotal)
            r.Cells(Me.costoVidrio.Index).Value = Round(costoVidrio)
            r.Cells(Me.costoPerfiles.Index).Value = Round(costoPerfiles)
            r.Cells(Me.costoAccesorio.Index).Value = Round(costoAccesorios)
            r.Cells(Me.costoOtros.Index).Value = costoOtros
            r.Cells(Me.factor.Index).Value = factor
            r.Cells(Me.tipoItem.Index).Value = tipoItem
            r.Cells(Me.idTasaImpuesto.Index).Value = idtasaImpuesto
            r.Cells(Me.tasaImpuesto.Index).Value = tasaImpuesto
            r.Cells(Me.acabTemporal.Index).Value = acabadoTemp
            r.Cells(Me.colorTemporal.Index).Value = colorTemp
            r.Cells(Me.espesorTemporal.Index).Value = espesorTemp
            r.Cells(Me.actualizar_plantilla.Index).Value = actualizar
            r.Cells(Me.vlrDesperdicioVidrio.Index).Value = vlrDespVidrio
            r.Cells(Me.vlrDesperdicioPerfiles.Index).Value = vlrDespPerfiles
            r.Cells(Me.vlrDespedicioAccesorios.Index).Value = vlrDespAccesorios
            r.Cells(Me.vlrDespOtros.Index).Value = vlrDespOtro
            If especial IsNot Nothing Then
                r.Cells(Me.especial.Index).Value = especial
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub EnModificacion()
        Try
            Dim c As FrmCotizaciones = DirectCast(nodotrabajo.DataGridView.FindForm(), FrmCotizaciones)
            txtUbicacion.Text = Convert.ToString(nodotrabajo.Cells(c.Ubicacion.Index).Value)
            txtdescripcion.Text = Convert.ToString(nodotrabajo.Cells(c.Descripcion.Index).Value)
            nudancho.Value = Convert.ToDecimal(nodotrabajo.Cells(c.ancho.Index).Value)
            nudalto.Value = Convert.ToDecimal(nodotrabajo.Cells(c.Alto.Index).Value)
            nudcantidad.Value = Convert.ToDecimal(nodotrabajo.Cells(c.Cantidad.Index).Value)
            nudDescuento.Value = Convert.ToDecimal(nodotrabajo.Cells(c.descuento.Index).Value)
            nuddescuentoinstalacion.Value = Convert.ToDecimal(nodotrabajo.Cells(c.descuentoinstala.Index).Value)
            cmbAcabado.SelectedValue = Convert.ToInt32(nodotrabajo.Cells(c.acabadoPerf.Index).Value)
            cmbuminstala.SelectedValue = nodotrabajo.Cells(c.unmedinstala.Index).Value
            nudtasa.Value = Convert.ToDecimal(nodotrabajo.Cells(c.tasaImpuesto.Index).Value)
            'cmbAcabado.SelectedValue = _listAcabados.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(nodotrabajo.Cells(c.acabadoPerf.Index).Value)).IdDb
            cmbVidrio.SelectedValue = _listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(nodotrabajo.Cells(c.vidrio.Index).Value)).IdDb
            cmbcolorvidrio.SelectedValue = _listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(nodotrabajo.Cells(c.colorVidrio.Index).Value)).IdDb
            cmbEspesores.SelectedValue = _listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(nodotrabajo.Cells(c.espesor.Index).Value)).IdDb
            _calcular_norma = Convert.ToBoolean(nodotrabajo.Cells(c.calcularnorma.Index).Value)
            _cumple_norma = Convert.ToBoolean(nodotrabajo.Cells(c.cumplenorma.Index).Value)
            _numero_cuerpos_norma_ = Convert.ToInt32(nodotrabajo.Cells(c.numero_cuerpos_norma.Index).Value)
            nodotrabajo.Nodes.ToList.ForEach(Sub(itemHijo)
                                                 Dim r As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
                                                 r.Cells(id.Index).Value = itemHijo.Cells(c.id.Index).Value
                                                 r.Cells(idArticulo.Index).Value = itemHijo.Cells(c.idArticulo.Index).Value
                                                 r.Cells(idArticuloTemp.Index).Value = itemHijo.Cells(c.idArticuloTemp.Index).Value
                                                 r.Cells(referencia.Index).Value = itemHijo.Cells(c.Ubicacion.Index).Value
                                                 r.Cells(descripcion.Index).Value = itemHijo.Cells(c.Descripcion.Index).Value
                                                 r.Cells(cantidad.Index).Value = itemHijo.Cells(c.Cantidad.Index).Value
                                                 r.Cells(piezasXUnidad.Index).Value = itemHijo.Cells(c.piezasxUnidad.Index).Value
                                                 r.Cells(ancho.Index).Value = itemHijo.Cells(c.ancho.Index).Value
                                                 r.Cells(alto.Index).Value = itemHijo.Cells(c.Alto.Index).Value
                                                 r.Cells(mtCuadrados.Index).Value = itemHijo.Cells(c.mtCuadrados.Index).Value
                                                 r.Cells(acabadoPerf.Index).Value = itemHijo.Cells(c.acabadoPerf.Index).Value
                                                 r.Cells(vidrio.Index).Value = itemHijo.Cells(c.vidrio.Index).Value
                                                 r.Cells(colorVidrio.Index).Value = itemHijo.Cells(c.colorVidrio.Index).Value
                                                 r.Cells(espesor.Index).Value = itemHijo.Cells(c.espesor.Index).Value
                                                 r.Cells(unidadMedida.Index).Value = itemHijo.Cells(c.unidadMedida.Index).Value
                                                 r.Cells(descuento.Index).Value = itemHijo.Cells(c.descuento.Index).Value
                                                 r.Cells(valorDescuento.Index).Value = itemHijo.Cells(c.valorDescuento.Index).Value
                                                 r.Cells(factor.Index).Value = itemHijo.Cells(c.factor.Index).Value
                                                 r.Cells(costoUnitario.Index).Value = itemHijo.Cells(c.costoUnitario.Index).Value
                                                 r.Cells(precioUnitario.Index).Value = itemHijo.Cells(c.precioUnitario.Index).Value
                                                 r.Cells(costoTotal.Index).Value = itemHijo.Cells(c.costoTotal.Index).Value
                                                 r.Cells(precioTotal.Index).Value = itemHijo.Cells(c.precioTotal.Index).Value
                                                 r.Cells(costoVidrio.Index).Value = itemHijo.Cells(c.costoVidrio.Index).Value
                                                 r.Cells(costoPerfiles.Index).Value = itemHijo.Cells(c.costoPerfiles.Index).Value
                                                 r.Cells(costoAccesorio.Index).Value = itemHijo.Cells(c.costoAccesorios.Index).Value
                                                 r.Cells(costoOtros.Index).Value = itemHijo.Cells(c.costoOtros.Index).Value
                                                 r.Cells(precioMtInstalacion.Index).Value = itemHijo.Cells(c.precioMtInstalacion.Index).Value
                                                 r.Cells(precioInstalacion.Index).Value = itemHijo.Cells(c.precioInstalacion.Index).Value
                                                 r.Cells(costoinstalacion.Index).Value = itemHijo.Cells(c.costoinstalacion.Index).Value
                                                 r.Cells(tipoItem.Index).Value = itemHijo.Cells(c.tipoItem.Index).Value
                                                 r.Cells(actualizar_plantilla.Index).Value = itemHijo.Cells(c.actualizar_plantilla.Index).Value
                                                 r.Cells(vlrDesperdicioVidrio.Index).Value = itemHijo.Cells(c.vlrDesperdicioVidrio.Index).Value
                                                 r.Cells(vlrDesperdicioPerfiles.Index).Value = itemHijo.Cells(c.vlrDesperdicioPerfiles.Index).Value
                                                 r.Cells(vlrDespedicioAccesorios.Index).Value = itemHijo.Cells(c.vlrDesperdicioAccesorios.Index).Value
                                                 r.Cells(vlrDespOtros.Index).Value = itemHijo.Cells(c.vlrDesperdicioOtros.Index).Value
                                                 r.Cells(calcular_nsr.Index).Value = Convert.ToBoolean(itemHijo.Cells(c.calcularnorma.Index).Value)
                                                 r.Cells(cumplenorma.Index).Value = Convert.ToBoolean(itemHijo.Cells(c.cumplenorma.Index).Value)
                                                 r.Cells(numero_cuerpos_norma.Index).Value = Convert.ToInt32(itemHijo.Cells(c.numero_cuerpos_norma.Index).Value)
                                                 If DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                                                     If itemHijo.Cells(c.especial.Index).Value Is Nothing Then
                                                         cargarAnalizador(r)
                                                         itemHijo.Cells(c.especial.Index).Value = r.Cells(especial.Index).Value
                                                     Else
                                                         r.Cells(especial.Index).Value = itemHijo.Cells(c.especial.Index).Value
                                                     End If
                                                     r.Cells(idTasaImpuesto.Index).Value = itemHijo.Cells(c.idTasaImpuesto.Index).Value
                                                     r.Cells(tasaImpuesto.Index).Value = itemHijo.Cells(c.tasaImpuesto.Index).Value
                                                 ElseIf DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.TEMPORAL Then
                                                     r.Cells(especial.Index).Value = itemHijo.Cells(c.especial.Index).Value
                                                 Else
                                                     r.Cells(especial.Index).Value = Nothing
                                                 End If
                                                 r.Cells(colorTemporal.Index).Value = itemHijo.Cells(c.colorTemporal.Index).Value
                                                 r.Cells(espesorTemporal.Index).Value = itemHijo.Cells(c.espesorTemporal.Index).Value
                                                 r.Cells(acabTemporal.Index).Value = itemHijo.Cells(c.acabTemporal.Index).Value
                                             End Sub)
            If nodotrabajo.Cells(c.especial.Index).Value Is Nothing Then
                Dim cd As New CargaDibujos
                Dim ldatos As List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)) = nodotrabajo.Nodes.Select(Function(h) New Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)(h.Cells(c.id.Index).Value, h.Cells(c.especial.Index).Value, h.Index, h.Cells(c.ancho.Index).Value, h.Cells(c.Alto.Index).Value)).ToList()
                nodotrabajo.Cells(c.especial.Index).Value = cd.CrearDibujos(nodotrabajo.Cells(c.id.Index).Value,
                                                                            ldatos, False, ClsEnums.TipoCarga.COTIZA)
            End If
            egmodelo.EstructuraPrincipal = DirectCast(nodotrabajo.Cells(c.especial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras).Duplicate(True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDesplegables()
        Try
            DirectCast(dwItem.Columns(vidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Referencia"
            DirectCast(dwItem.Columns(vidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItem.Columns(vidrio.Index), DataGridViewComboBoxColumn).DataSource = _listArticulos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO).ToList

            DirectCast(dwItem.Columns(acabadoPerf.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItem.Columns(acabadoPerf.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItem.Columns(acabadoPerf.Index), DataGridViewComboBoxColumn).DataSource = _listAcabados

            DirectCast(dwItem.Columns(colorVidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItem.Columns(colorVidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItem.Columns(colorVidrio.Index), DataGridViewComboBoxColumn).DataSource = _listColores

            DirectCast(dwItem.Columns(espesor.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItem.Columns(espesor.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItem.Columns(espesor.Index), DataGridViewComboBoxColumn).DataSource = _listEspesores
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ocultarCostos()
        Try
            dwItem.Columns(descuento.Index).Visible = False
            dwItem.Columns(valorDescuento.Index).Visible = False
            dwItem.Columns(factor.Index).Visible = False
            dwItem.Columns(precioMtInstalacion.Index).Visible = False
            dwItem.Columns(precioInstalacion.Index).Visible = False
            dwItem.Columns(costoUnitario.Index).Visible = False
            dwItem.Columns(costoTotal.Index).Visible = False
            dwItem.Columns(costoVidrio.Index).Visible = False
            dwItem.Columns(costoPerfiles.Index).Visible = False
            dwItem.Columns(costoAccesorio.Index).Visible = False
            dwItem.Columns(costoOtros.Index).Visible = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mostrarCostos()
        Try
            dwItem.Columns(descuento.Index).Visible = True
            dwItem.Columns(valorDescuento.Index).Visible = True
            dwItem.Columns(factor.Index).Visible = True
            dwItem.Columns(precioMtInstalacion.Index).Visible = True
            dwItem.Columns(precioInstalacion.Index).Visible = True
            dwItem.Columns(costoUnitario.Index).Visible = True
            dwItem.Columns(costoTotal.Index).Visible = True
            dwItem.Columns(costoVidrio.Index).Visible = True
            dwItem.Columns(costoPerfiles.Index).Visible = True
            dwItem.Columns(costoAccesorio.Index).Visible = True
            dwItem.Columns(costoOtros.Index).Visible = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub RecalcularFila(r As DataGridViewRow)
        Try
            Dim porDespVidrio, porDespPerfiles, porDespAccesorio, porDespOtros As Decimal
            calculo = New ClsCalculos
            calculo.tasaImpuesto = _tasaImpuestoGlobal
            calculo.indAIU = _indAIU
            If Convert.ToInt32(r.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.TEMPORAL Then
                Dim artTemp As articuloTemporal = _listArticulos.FirstOrDefault(Function(a)
                                                                                    Return a.Referencia = Convert.ToString(r.Cells(referencia.Index).Value)
                                                                                End Function)
                Dim temp As Boolean = False
                If CInt(r.Cells(idArticulo.Index).Value) = 0 And CInt(r.Cells(idArticuloTemp.Index).Value) <> 0 Then
                    temp = True
                ElseIf CInt(r.Cells(idArticulo.Index).Value) <> 0 And CInt(r.Cells(idArticuloTemp.Index).Value) = 0 Then
                    temp = False
                End If
                Dim vidTemp As articuloTemporal = _listArticulos.FirstOrDefault(Function(a)
                                                                                    Return a.Id = CInt(r.Cells(vidrio.Index).Value) And a.Temporal = temp
                                                                                End Function)
                Dim colTemp As acabadoTemporal = _listColores.FirstOrDefault(Function(a)
                                                                                 Return a.Id = CInt(r.Cells(colorVidrio.Index).Value) And a.Temporal = CBool(r.Cells(colorTemporal.Index).Value)
                                                                             End Function)
                Dim acabTemp As acabadoTemporal = _listAcabados.FirstOrDefault(Function(a)
                                                                                   Return a.Id = CInt(r.Cells(acabadoPerf.Index).Value) And a.Temporal = CBool(r.Cells(acabTemporal.Index).Value)
                                                                               End Function)
                Dim espTemp As espesorTemporal = _listEspesores.FirstOrDefault(Function(a)
                                                                                   Return a.Id = CInt(r.Cells(espesor.Index).Value) And a.Temporal = CBool(r.Cells(espesorTemporal.Index).Value)
                                                                               End Function)
                calculo.Temporales(artTemp, r.Cells(cantidad.Index).Value, r.Cells(piezasXUnidad.Index).Value, r.Cells(ancho.Index).Value,
                                   r.Cells(alto.Index).Value, acabTemp, vidTemp, colTemp, espTemp, r.Cells(descuento.Index).Value,
                                   r.Cells(factor.Index).Value, r.Cells(precioMtInstalacion.Index).Value, artTemp.PorcentajeDesperdicio, _idCotiza)
            Else
                porDespVidrio = 0
                porDespPerfiles = 0
                porDespAccesorio = 0
                porDespOtros = 0
                If CInt(r.Cells(id.Index).Value) = 0 Then
                    Select Case DirectCast(CInt(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                        Case ClsEnums.FamiliasMateriales.VIDRIO
                            porDespVidrio = mArticulos.TraerxId(r.Cells(idArticulo.Index).Value).porcDesperdicio
                        Case ClsEnums.FamiliasMateriales.PERFILERIA
                            porDespPerfiles = mArticulos.TraerxId(r.Cells(idArticulo.Index).Value).porcDesperdicio
                        Case ClsEnums.FamiliasMateriales.ACCESORIOS
                            porDespAccesorio = mArticulos.TraerxId(r.Cells(idArticulo.Index).Value).porcDesperdicio
                        Case ClsEnums.FamiliasMateriales.OTROS
                            porDespOtros = mArticulos.TraerxId(r.Cells(idArticulo.Index).Value).porcDesperdicio
                    End Select
                Else
                    Select Case DirectCast(CInt(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                        Case ClsEnums.FamiliasMateriales.VIDRIO
                            porDespVidrio = (CDec(r.Cells(vlrDesperdicioVidrio.Index).Value) / (CDec(r.Cells(costoTotal.Index).Value) - CDec(CDec(r.Cells(vlrDesperdicioVidrio.Index).Value))) * 100)
                        Case ClsEnums.FamiliasMateriales.PERFILERIA
                            porDespPerfiles = (CDec(r.Cells(vlrDesperdicioPerfiles.Index).Value) / (CDec(r.Cells(costoTotal.Index).Value) - CDec(CDec(r.Cells(vlrDesperdicioPerfiles.Index).Value))) * 100)
                        Case ClsEnums.FamiliasMateriales.ACCESORIOS
                            porDespAccesorio = (CDec(r.Cells(vlrDespedicioAccesorios.Index).Value) / (CDec(r.Cells(costoTotal.Index).Value) - CDec(CDec(r.Cells(vlrDespedicioAccesorios.Index).Value))) * 100)
                        Case ClsEnums.FamiliasMateriales.OTROS
                            porDespOtros = (CDec(r.Cells(vlrDespOtros.Index).Value) / (CDec(r.Cells(costoTotal.Index).Value) - CDec(CDec(r.Cells(vlrDespOtros.Index).Value))) * 100)
                    End Select
                End If
                Select Case DirectCast(CInt(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                    Case ClsEnums.FamiliasMateriales.DISEÑOS
                        Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)

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
                                        nudDescuento.Value, r.Cells(factor.Index).Value, nudPrecioInstalacion.Value,
                                        costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costo_instalacion)
                    Case ClsEnums.FamiliasMateriales.VIDRIO
                        calculo.Calcular_Vidrios(_listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(vidrio.Index).Value)).IdDb,
                                                 _listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(espesor.Index).Value)).IdDb,
                                                 _listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(colorVidrio.Index).Value)).IdDb,
                                                 _versionCostoVidrio, r.Cells(ancho.Index).Value, r.Cells(alto.Index).Value,
                                                 r.Cells(cantidad.Index).Value, r.Cells(piezasXUnidad.Index).Value, porDespVidrio,
                                                 r.Cells(factor.Index).Value, r.Cells(descuento.Index).Value,
                                                 r.Cells(precioMtInstalacion.Index).Value, r.Cells(costoinstalacion.Index).Value,
                                                 r.Cells(especial.Index).Value)
                    Case ClsEnums.FamiliasMateriales.PERFILERIA
                        calculo.Calcular_Perfiles(r.Cells(idArticulo.Index).Value, r.Cells(acabadoPerf.Index).Value,
                                                  _versionCostoAcabado, _versionCostoNivel, _versionCostoKiloAluminio,
                                                  r.Cells(ancho.Index).Value, r.Cells(cantidad.Index).Value,
                                                  r.Cells(piezasXUnidad.Index).Value, porDespPerfiles, r.Cells(factor.Index).Value,
                                                  r.Cells(descuento.Index).Value, r.Cells(precioMtInstalacion.Index).Value,
                                                  r.Cells(costoinstalacion.Index).Value, r.Cells(especial.Index).Value)

                    Case ClsEnums.FamiliasMateriales.ACCESORIOS
                        calculo.Calcular_Accesorios(r.Cells(idArticulo.Index).Value, r.Cells(cantidad.Index).Value,
                                                    r.Cells(piezasXUnidad.Index).Value, _versionCostoAccesorio,
                                                    porDespAccesorio, r.Cells(factor.Index).Value, r.Cells(descuento.Index).Value,
                                                    r.Cells(costoinstalacion.Index).Value, r.Cells(especial.Index).Value)

                    Case ClsEnums.FamiliasMateriales.OTROS
                        calculo.Calcular_Otros(r.Cells(idArticulo.Index).Value, r.Cells(cantidad.Index).Value,
                                                    r.Cells(piezasXUnidad.Index).Value, _versionCostoOtros,
                                                    porDespOtros, r.Cells(factor.Index).Value, r.Cells(descuento.Index).Value,
                                                    r.Cells(costoinstalacion.Index).Value, r.Cells(especial.Index).Value)
                End Select
            End If
            Dim idv As Integer = _listArticulos.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(vidrio.Index).Value)).IdDb
            Dim idcolorv As Integer = _listColores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(colorVidrio.Index).Value)).IdDb
            Dim idesp As Integer = _listEspesores.FirstOrDefault(Function(a) a.Id = Convert.ToInt32(r.Cells(espesor.Index).Value)).IdDb
            llenarFila(r, r.Cells(idArticulo.Index).Value, r.Cells(idArticuloTemp.Index).Value, r.Cells(referencia.Index).Value,
                       r.Cells(descripcion.Index).Value, r.Cells(cantidad.Index).Value, r.Cells(piezasXUnidad.Index).Value,
                       r.Cells(ancho.Index).Value, r.Cells(alto.Index).Value, calculo.MetrosCuadrados, r.Cells(acabadoPerf.Index).Value,
                       idv, idcolorv, idesp,
                       r.Cells(unidadMedida.Index).Value, r.Cells(descuento.Index).Value, calculo.ValorDescuento, calculo.CostoUnitario,
                       calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, r.Cells(precioMtInstalacion.Index).Value,
                       calculo.PrecioInstalacion, calculo.Costo_Instalacion, calculo.CostoVidrio, calculo.CostoPerfiles, calculo.CostoAccesorio, calculo.CostoOtros,
                       r.Cells(factor.Index).Value, r.Cells(tipoItem.Index).Value, r.Cells(id.Index).Value, r.Cells(idTasaImpuesto.Index).Value,
                       r.Cells(tasaImpuesto.Index).Value, r.Cells(acabTemporal.Index).Value, r.Cells(colorTemporal.Index).Value,
                       r.Cells(espesorTemporal.Index).Value, r.Cells(especial.Index).Value, r.Cells(actualizar_plantilla.Index).Value,
                       calculo.vlrdespVidrio, calculo.vlrdespPerfiles, calculo.vlrdespAccesorios, calculo.vlrdespOtros)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub RecalcularElementos(valor As String, valorsecundario As String, cambio As ClsEnums.Tipos_Cambio)
        Try
            Select Case cambio
#Region "Cantidad"
                Case ClsEnums.Tipos_Cambio.CANTIDAD
                    For Each r As DataGridViewRow In dwItem.Rows

                    Next
#End Region
#Region "Ancho"
                Case ClsEnums.Tipos_Cambio.ANCHO
                    dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                            Select Case DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                                Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                    If Convert.ToDecimal(r.Cells(ancho.Index).Value) > Convert.ToDecimal(valor) Then
                                                                                        r.Cells(ancho.Index).Value = Convert.ToDecimal(valor)
                                                                                        RecalcularFila(r)
                                                                                    End If
                                                                                Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                                                    If Convert.ToDecimal(r.Cells(ancho.Index).Value) > Convert.ToDecimal(valor) Then
                                                                                        r.Cells(ancho.Index).Value = Convert.ToDecimal(valor)
                                                                                        If r.Cells(especial.Index).Value Is Nothing Then
                                                                                            cargarAnalizador(r)
                                                                                        End If
                                                                                        Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                        If an.ListaVariables.Contains("ANCHO") Then
                                                                                            an.ListaVariables.Item("ANCHO").Valor = valor
                                                                                            cargarAnalizador(r)
                                                                                        End If
                                                                                        r.Cells(costoVidrio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoAccesorio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoUnitario.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoinstalacion.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Instalacion_Unidad)
                                                                                        r.Cells(vlrDesperdicioVidrio.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Vidrios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDesperdicioPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Perfiles Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespedicioAccesorios.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Accesorios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        RecalcularFila(r)
                                                                                    End If
                                                                            End Select
                                                                        End Sub)
#End Region
#Region "Alto"
                Case ClsEnums.Tipos_Cambio.ALTO
                    dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                            Select Case DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                                Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                    If Convert.ToDecimal(r.Cells(alto.Index).Value) > Convert.ToDecimal(valor) Then
                                                                                        r.Cells(alto.Index).Value = Convert.ToDecimal(valor)
                                                                                        RecalcularFila(r)
                                                                                    End If
                                                                                Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                                                    If Convert.ToDecimal(r.Cells(alto.Index).Value) > Convert.ToDecimal(valor) Then
                                                                                        r.Cells(alto.Index).Value = Convert.ToDecimal(valor)
                                                                                        If r.Cells(especial.Index).Value Is Nothing Then
                                                                                            cargarAnalizador(r)
                                                                                        End If
                                                                                        Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                        If an.ListaVariables.Contains("ALTO") Then
                                                                                            an.ListaVariables.Item("ALTO").Valor = valor
                                                                                            cargarAnalizador(r)
                                                                                        End If
                                                                                        r.Cells(costoVidrio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoAccesorio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoUnitario.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoinstalacion.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Instalacion_Unidad)
                                                                                        r.Cells(vlrDesperdicioVidrio.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Vidrios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDesperdicioPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Perfiles Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespedicioAccesorios.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Accesorios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        RecalcularFila(r)
                                                                                    End If
                                                                            End Select
                                                                        End Sub)
#End Region
#Region "Acabado"
                Case ClsEnums.Tipos_Cambio.ACABADO
                    dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                            Select Case DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                                Case ClsEnums.FamiliasMateriales.PERFILERIA
                                                                                    r.Cells(acabadoPerf.Index).Value = Convert.ToInt32(valor)
                                                                                    RecalcularFila(r)
                                                                                Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                                                    r.Cells(acabadoPerf.Index).Value = Convert.ToInt32(valor)
                                                                                    If r.Cells(especial.Index).Value Is Nothing Then
                                                                                        cargarAnalizador(r)
                                                                                    End If
                                                                                    Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                    If an.ListaVariables.Contains("ACABADO") Then
                                                                                        an.ListaVariables.Item("ACABADO").Valor = valorsecundario
                                                                                        cargarAnalizador(r)
                                                                                    End If
                                                                                    r.Cells(costoVidrio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                    r.Cells(costoPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                    r.Cells(costoAccesorio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                    r.Cells(costoOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                    r.Cells(costoUnitario.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                    r.Cells(costoinstalacion.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Instalacion_Unidad)
                                                                                    r.Cells(vlrDesperdicioVidrio.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Vidrios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                    r.Cells(vlrDesperdicioPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Perfiles Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                    r.Cells(vlrDespedicioAccesorios.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Accesorios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                    RecalcularFila(r)
                                                                            End Select
                                                                        End Sub)
#End Region
#Region "Tipo Vidrio"
                Case ClsEnums.Tipos_Cambio.TIPO_VIDRIO
                    dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                            Select Case DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                                Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                    r.Cells(vidrio.Index).Value = Convert.ToInt32(valor)
                                                                                    RecalcularFila(r)
                                                                                Case ClsEnums.FamiliasMateriales.DISEÑOS

                                                                                    If r.Cells(especial.Index).Value Is Nothing Then
                                                                                        cargarAnalizador(r)
                                                                                    End If
                                                                                    Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                    If an.ListaVariables.Contains("TIPO_VIDRIO") Then
                                                                                        r.Cells(vidrio.Index).Value = Convert.ToInt32(valor)
                                                                                        an.ListaVariables.Item("TIPO_VIDRIO").Valor = valorsecundario
                                                                                        cargarAnalizador(r)
                                                                                        r.Cells(costoVidrio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoAccesorio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoUnitario.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoinstalacion.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Instalacion_Unidad)
                                                                                        r.Cells(vlrDesperdicioVidrio.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Vidrios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDesperdicioPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Perfiles Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespedicioAccesorios.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Accesorios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        RecalcularFila(r)
                                                                                    End If

                                                                            End Select
                                                                        End Sub)
#End Region
#Region "Espesor"
                Case ClsEnums.Tipos_Cambio.ESPESOR
                    dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                            Select Case DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                                Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                    r.Cells(espesor.Index).Value = Convert.ToInt32(valor)
                                                                                    RecalcularFila(r)
                                                                                Case ClsEnums.FamiliasMateriales.DISEÑOS

                                                                                    If r.Cells(especial.Index).Value Is Nothing Then
                                                                                        cargarAnalizador(r)
                                                                                    End If
                                                                                    Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                    If an.ListaVariables.Contains("ESPESOR") Then
                                                                                        r.Cells(espesor.Index).Value = Convert.ToInt32(valor)
                                                                                        an.ListaVariables.Item("ESPESOR").Valor = valorsecundario
                                                                                        cargarAnalizador(r)
                                                                                        r.Cells(costoVidrio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoAccesorio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoUnitario.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoinstalacion.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Instalacion_Unidad)
                                                                                        r.Cells(vlrDesperdicioVidrio.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Vidrios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDesperdicioPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Perfiles Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespedicioAccesorios.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Accesorios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        RecalcularFila(r)
                                                                                    End If
                                                                            End Select
                                                                        End Sub)
#End Region
#Region "Color Vidrio"
                Case ClsEnums.Tipos_Cambio.COLOR_VIDRIO
                    dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                            Select Case DirectCast(Convert.ToInt32(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                                Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                    r.Cells(colorVidrio.Index).Value = Convert.ToInt32(valor)
                                                                                    RecalcularFila(r)
                                                                                Case ClsEnums.FamiliasMateriales.DISEÑOS

                                                                                    If r.Cells(especial.Index).Value Is Nothing Then
                                                                                        cargarAnalizador(r)
                                                                                    End If
                                                                                    Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                                                                                    If an.ListaVariables.Contains("COLOR_VIDRIO") Then
                                                                                        r.Cells(colorVidrio.Index).Value = Convert.ToInt32(valor)
                                                                                        an.ListaVariables.Item("COLOR_VIDRIO").Valor = valorsecundario
                                                                                        cargarAnalizador(r)
                                                                                        r.Cells(costoVidrio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoAccesorio.Index).Value = an.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoUnitario.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Unitario)
                                                                                        r.Cells(costoinstalacion.Index).Value = an.ListaMateriales.Where(Function(a) a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Instalacion_Unidad)
                                                                                        r.Cells(vlrDesperdicioVidrio.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Vidrios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDesperdicioPerfiles.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Perfiles Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespedicioAccesorios.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Accesorios Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        r.Cells(vlrDespOtros.Index).Value = an.ListaMateriales.Where(Function(a) (a.TipoObjeto = TiposElementos.Otros Or a.TipoObjeto = TiposElementos.Trabajos_Vidrio) And a.Utilizar And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.VlrDesperdicio)
                                                                                        RecalcularFila(r)
                                                                                    End If
                                                                            End Select
                                                                        End Sub)
#End Region
            End Select
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

#Region "Procedimientos Controles"
    Private Sub FrmAddItemPadre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarAcabados()
            cmbAcabado.SelectedValue = AcabadoGlobal.Id
            cargarVidrios()
            cargarEspesor()
            cargarColores()
            cargarUnidades()
            cargarDesplegables()
            nudDescuento.Value = DescuentoGlobal
            If tieneInstalacion = False Then
                _manoObra = 0
            End If
            nudtasa.Value = _tasaImpuestoGlobal
            If Not tform = ClsEnums.TiOperacion.INSERTAR Then
                EnModificacion()
                If tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                    txtUbicacion.Enabled = False
                    txtdescripcion.Enabled = False
                    nudancho.Enabled = False
                    nudalto.Enabled = False
                    nudcantidad.Enabled = False
                    nudDescuento.Enabled = False
                    nudPrecioInstalacion.Enabled = False
                    cmbAcabado.Enabled = False
                    cmbcolorvidrio.Enabled = False
                    cmbEspesores.Enabled = False
                    cmbVidrio.Enabled = False
                    tselementos.Enabled = False
                    dwItem.ReadOnly = True
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Add_Plantilla_Click(sender As Object, e As EventArgs) Handles btnplantilla.Click
        Try
            Dim fcargaplantilla As New FrmCargaPlantillas
            fcargaplantilla.DiccionarioVariables.Add("ACABADO", cmbAcabado.Text)
            fcargaplantilla.DiccionarioVariables.Add("TIPO_VIDRIO", cmbVidrio.Text)
            fcargaplantilla.DiccionarioVariables.Add("ANCHO", nudancho.Value)
            fcargaplantilla.DiccionarioVariables.Add("ALTO", nudalto.Value)
            fcargaplantilla.DiccionarioVariables.Add("CANTIDAD", nudcantidad.Value)
            fcargaplantilla.DiccionarioVariables.Add("COLOR_VIDRIO", cmbcolorvidrio.Text)
            fcargaplantilla.DiccionarioVariables.Add("ESPESOR", cmbEspesores.Text)
            fcargaplantilla.Factor = FactorGlobal.tasa
            fcargaplantilla.Id_Cotiza = _idCotiza
            fcargaplantilla.versionCostoKiloAluminio = _versionCostoKiloAluminio
            fcargaplantilla.versionCostoVidrio = _versionCostoVidrio
            fcargaplantilla.versionCostoAccesorio = _versionCostoAccesorio
            fcargaplantilla.versionCostoAcabado = _versionCostoAcabado
            fcargaplantilla.versionCostoNivel = _versionCostoNivel
            fcargaplantilla.versionCostoOtrosArticulos = _versionCostoOtros
            If fcargaplantilla.ShowDialog() = DialogResult.OK Then
                Dim analiza As AnalizadorLexico = fcargaplantilla.Analizador
                Dim r As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
                r.Cells(numero_cuerpos_norma.Index).Value = 1
                Dim pmodelo As PlantillaModelo
                pmodelo = New PlantillaModelo(fcargaplantilla.itPlantillas.selected_item.Item("Id"), fcargaplantilla.itPlantillas.selected_item.Item("Usuario_Creacion"),
                fcargaplantilla.itPlantillas.selected_item.Item("Fecha_Creacion"), fcargaplantilla.itPlantillas.selected_item.Item("Id_TipoModelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_Tipo_Modelo"), fcargaplantilla.itPlantillas.selected_item.Item("Tipo_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Id_ClasificacionModelo"), fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_Clasificacion_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Clasificacion_Modelo"), fcargaplantilla.itPlantillas.selected_item.Item("IdFamiliaModelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_Familia_Modelo"), fcargaplantilla.itPlantillas.selected_item.Item("Familia_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Id_Configuracion"), fcargaplantilla.itPlantillas.selected_item.Item("Configuracion"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Id_CaracteristicasAd"), fcargaplantilla.itPlantillas.selected_item.Item("Prefijo_caracteristica_ad"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Caracteristica_Adicional"), fcargaplantilla.itPlantillas.selected_item.Item("Nombre_Modelo"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Descripcion"), fcargaplantilla.itPlantillas.selected_item.Item("Usuario_Modifiacion"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Fecha_Modificacion"), fcargaplantilla.itPlantillas.selected_item.Item("Id_Estado"),
                                              fcargaplantilla.itPlantillas.selected_item.Item("Estado"), 0, False,
                                              Convert.ToBoolean(fcargaplantilla.itPlantillas.selected_item.Item("Calcular_Nsr")))
                r.Cells(calcular_nsr.Index).Value = pmodelo.Calcular_NSR
                calculo = New ClsCalculos
                calculo.tasaImpuesto = _tasaImpuestoGlobal
                calculo.indAIU = _indAIU
                Dim idAcabado As Integer = DirectCast(acabadoPerf.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("ACABADO").Valor).IdDb
                Dim idVidrio As Integer = 838
                Dim vidtemp As Boolean = False
                Dim idColorVidrio As Integer = 32
                Dim colortemp As Boolean = False
                Dim idEspesor As Integer = 1
                Dim espesortemp As Boolean = False
                If analiza.ListaVariables.Contains("TIPO_VIDRIO") Then
                    idVidrio = DirectCast(vidrio.DataSource, List(Of articuloTemporal)).First(Function(x) x.Referencia = analiza.ListaVariables.Item("TIPO_VIDRIO").Valor).IdDb
                    vidtemp = DirectCast(vidrio.DataSource, List(Of articuloTemporal)).First(Function(x) x.Referencia = analiza.ListaVariables.Item("TIPO_VIDRIO").Valor).Temporal
                End If
                If analiza.ListaVariables.Contains("COLOR_VIDRIO") Then
                    idColorVidrio = DirectCast(colorVidrio.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("COLOR_VIDRIO").Valor).IdDb
                    colortemp = DirectCast(colorVidrio.DataSource, List(Of acabadoTemporal)).First(Function(x) x.Prefijo = analiza.ListaVariables.Item("COLOR_VIDRIO").Valor).Temporal
                End If
                If analiza.ListaVariables.Contains("ESPESOR") Then
                    idEspesor = DirectCast(espesor.DataSource, List(Of espesorTemporal)).First(Function(x) Convert.ToString(x.Prefijo) = Convert.ToString(analiza.ListaVariables.Item("ESPESOR").Valor)).IdDb
                    espesortemp = DirectCast(espesor.DataSource, List(Of espesorTemporal)).First(Function(x) Convert.ToString(x.Prefijo) = Convert.ToString(analiza.ListaVariables.Item("ESPESOR").Valor)).Temporal
                End If
                Dim costoVidrio, costoPerfiles, costoAccesorios,
                            costoOtros, vlrDespVidrio, vlrDespPerfiles,
                            vlrDespAccesorio, vlrDespOtros, costounitario,
                        costo_instalacion As Decimal
                costoVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                costoPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                costoAccesorios = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                costoOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.Costo_Total)
                vlrDespVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                vlrDespPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                vlrDespAccesorio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                vlrDespOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                costounitario = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Unitario))
                costo_instalacion = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Instalacion_Total))

                calculo.Calcular_Disenio(costounitario, Convert.ToInt32(analiza.ListaVariables.Item("CANTIDAD").Valor), Convert.ToDecimal(analiza.ListaVariables.Item("PIEZAS_X_UND").Valor),
                                Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor),
                                Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor), nudDescuento.Value,
                                         fcargaplantilla.Factor, nudPrecioInstalacion.Value, costoVidrio,
                                         costoPerfiles, costoAccesorios, costoOtros, costo_instalacion)

                llenarFila(r, pmodelo.Id, 0, pmodelo.NombreModelo, pmodelo.Descripcion, analiza.ListaVariables.Item("CANTIDAD").Valor,
                           analiza.ListaVariables.Item("PIEZAS_X_UND").Valor, Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor),
                           Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor), calculo.MetrosCuadrados, idAcabado, idVidrio, idColorVidrio,
                           idEspesor, "UND", nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal,
                           calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion, costo_instalacion, costoVidrio, costoPerfiles,
                           costoAccesorios, costoOtros, fcargaplantilla.Factor, ClsEnums.FamiliasMateriales.DISEÑOS, 0, _IdTasaImpuestoGlobal,
                           _tasaImpuestoGlobal, False, colortemp, espesortemp, analiza, False, vlrDespVidrio, vlrDespPerfiles,
                           vlrDespAccesorio, vlrDespOtros)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Add_Accesorios_Click(sender As Object, e As EventArgs) Handles tsbAddAccesorio.Click
        Try
            Dim frm As New FrmAddAccesorio
            frm.IdCotiza = _idCotiza
            frm.VersionCostoAccesorio = _versionCostoAccesorio
            frm.Factor = _factorGlobal.tasa
            If frm.ShowDialog() = DialogResult.OK Then
                calculo = New ClsCalculos
                calculo.tasaImpuesto = _tasaImpuestoGlobal
                calculo.indAIU = _indAIU
                Dim r As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
                r.Cells(numero_cuerpos_norma.Index).Value = 0
                If frm.Accesorio.Temporal = True Or frm.Acabado.Temporal = True Then
                    calculo.Temporales(frm.Accesorio, frm.Cantidad, frm.PiezasxUnidad, 0, 0, Nothing, Nothing, Nothing, Nothing, nudDescuento.Value,
                                       frm.Factor, nudPrecioInstalacion.Value, frm.Accesorio.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                    llenarFila(r, If(frm.Accesorio.Temporal = True, 0, frm.Accesorio.Id), If(frm.Accesorio.Temporal = True, frm.Accesorio.Id, 0),
                               frm.Accesorio.Referencia, frm.Accesorio.Descripcion, frm.Cantidad, frm.PiezasxUnidad, 0, 0, 0,
                               frm.Acabado.IdDb, 838, 32, 1, frm.Accesorio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                               calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                               calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, calculo.CostoTotal, 0, frm.Factor, ClsEnums.FamiliasMateriales.TEMPORAL, 0,
                               _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                Else
                    calculo.Calcular_Accesorios(frm.Accesorio.Id, frm.Cantidad, frm.PiezasxUnidad,
                                                _versionCostoAccesorio, frm.Accesorio.PorcentajeDesperdicio,
                                                frm.Factor, nudDescuento.Value, frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                    llenarFila(r, frm.Accesorio.Id, 0, frm.Accesorio.Referencia, frm.Accesorio.Descripcion, frm.Cantidad, frm.PiezasxUnidad, 0, 0, 0,
                               frm.Acabado.IdDb, 838, 32, 1, frm.Accesorio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                               calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                               frm.CostoInstalacionUnitario, 0, 0, calculo.CostoTotal, 0, frm.Factor, ClsEnums.FamiliasMateriales.ACCESORIOS, 0, _IdTasaImpuestoGlobal,
                               _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, calculo.vlrdespAccesorios, 0)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Add_Perfil_Click(sender As Object, e As EventArgs) Handles tsbAddPerfil.Click
        Try
            Dim frm As New FrmAddPerfil
            frm.IdCotiza = _idCotiza
            frm.Acabado = _listAcabados.FirstOrDefault(Function(a) a.IdDb = CInt(cmbAcabado.SelectedValue) And a.Temporal = False)
            frm.VersionCostoAcabado = _versionCostoAcabado
            frm.VersionCostoNivel = _versionCostoNivel
            frm.VersionCostoKAluminio = _versionCostoKiloAluminio
            frm.factor = _factorGlobal.tasa
            If frm.ShowDialog() = DialogResult.OK Then
                calculo = New ClsCalculos
                calculo.tasaImpuesto = _tasaImpuestoGlobal
                calculo.indAIU = _indAIU
                Dim r As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
                r.Cells(numero_cuerpos_norma.Index).Value = 0
                frm.CurId = r.Cells(id.Index).Value
                If frm.Perfil.Temporal = True Or frm.Acabado.Temporal = True Then
                    calculo.Temporales(frm.Perfil, frm.cantidad, frm.piezasxUnidad, frm.ancho, 0, frm.Acabado, Nothing, Nothing, Nothing,
                                       nudDescuento.Value, frm.factor, nudPrecioInstalacion.Value, frm.Perfil.PorcentajeDesperdicio,
                                       _idCotiza, frm.DTableTrabajos)
                    llenarFila(r, If(frm.Perfil.Temporal = True, 0, frm.Perfil.Id), If(frm.Perfil.Temporal = True, frm.Perfil.Id, 0),
                               frm.Perfil.Referencia, frm.Perfil.Descripcion, frm.cantidad, frm.piezasxUnidad, frm.ancho,
                               0, 0, frm.Acabado.Id, 838, 32, 1, frm.Perfil.UnidadMedida,
                               nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal,
                               calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion, frm.CostoInstalacionUnitario,
                               0, calculo.CostoTotal, 0, 0, frm.factor,
                               ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal,
                               False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                Else
                    calculo.Calcular_Perfiles(frm.Perfil.Id, frm.Acabado.Id, _versionCostoAcabado, _versionCostoNivel,
                                              _versionCostoKiloAluminio, frm.ancho, frm.cantidad, frm.piezasxUnidad,
                                              frm.Perfil.PorcentajeDesperdicio, frm.factor, nudDescuento.Value,
                                              nudPrecioInstalacion.Value, frm.CostoInstalacionUnitario, frm.DTableTrabajos)

                    llenarFila(r, frm.Perfil.Id, 0, frm.Perfil.Referencia, frm.Perfil.Descripcion, frm.cantidad,
                               frm.piezasxUnidad, frm.ancho, 0, 0, frm.Acabado.Id,
                               838, 32, 1, frm.Perfil.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                               calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                               frm.CostoInstalacionUnitario, 0, calculo.CostoPerfiles, 0, 0, frm.factor, ClsEnums.FamiliasMateriales.PERFILERIA, frm.CurId,
                               _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False,
                               0, calculo.vlrdespPerfiles, 0, 0)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Add_Vidrio_Click(sender As Object, e As EventArgs) Handles tsbAddVidrio.Click
        Try
            Dim frm As New FrmAddVidrio
            frm.IdCotiza = _idCotiza
            frm.Vidrio = _listArticulos.FirstOrDefault(Function(a) a.IdDb = Convert.ToInt32(cmbVidrio.SelectedValue))
            frm.Color = _listColores.FirstOrDefault(Function(a) a.IdDb = Convert.ToInt32(cmbcolorvidrio.SelectedValue))
            frm.Espesor = _listEspesores.FirstOrDefault(Function(a) a.IdDb = Convert.ToInt32(cmbEspesores.SelectedValue))
            frm.alto = nudalto.Value
            frm.ancho = nudancho.Value
            frm.VersionCostoVidrio = _versionCostoVidrio
            frm.Factor = _factorGlobal.tasa
            frm.ListArticulos = _listArticulos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO And
                                                                         a.IdDb <> 838).ToList
            frm.ListColores = _listColores
            frm.ListEspesores = _listEspesores.Where(Function(a) a.Id <> 1).ToList
            If frm.ShowDialog() = DialogResult.OK Then
                calculo = New ClsCalculos
                calculo.tasaImpuesto = _tasaImpuestoGlobal
                calculo.indAIU = _indAIU
                Dim r As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
                r.Cells(numero_cuerpos_norma.Index).Value = 0
                frm.CurId = r.Cells(id.Index).Value
                If frm.esVidrioTemporal = False And frm.esColorTemporal = False And
                    frm.esEspesorTemporal = False Then
                    calculo.Calcular_Vidrios(frm.Vidrio.IdDb, frm.Espesor.IdDb, frm.Color.IdDb, _versionCostoVidrio,
                                             frm.ancho, frm.alto, frm.cantidad, frm.piezasxUnidad,
                                             frm.Vidrio.PorcentajeDesperdicio, frm.Factor, nudDescuento.Value, nudPrecioInstalacion.Value,
                                             frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                    llenarFila(r, frm.Vidrio.IdDb, 0, frm.Vidrio.Referencia, frm.Vidrio.Descripcion, frm.cantidad,
                               frm.piezasxUnidad, frm.ancho, frm.alto, calculo.MetrosCuadrados, 32, frm.Vidrio.IdDb, frm.Color.IdDb,
                               frm.Espesor.IdDb, frm.Vidrio.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario,
                               calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion,
                               frm.CostoInstalacionUnitario, calculo.CostoVidrio, 0, 0, 0, frm.Factor, ClsEnums.FamiliasMateriales.VIDRIO, frm.CurId, _IdTasaImpuestoGlobal,
                               _tasaImpuestoGlobal, False, frm.esColorTemporal, frm.esEspesorTemporal, frm.DTableTrabajos, False, calculo.vlrdespVidrio, 0, 0, 0)
                Else
                    calculo.Temporales(frm.Vidrio, frm.cantidad, frm.piezasxUnidad, frm.ancho, frm.alto, Nothing, frm.Vidrio, frm.Color,
                                       frm.Espesor, nudDescuento.Value, frm.Factor, nudPrecioInstalacion.Value,
                                       frm.Vidrio.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                    llenarFila(r, If(frm.Vidrio.Temporal = True, 0, frm.Vidrio.IdDb), If(frm.Vidrio.Temporal = True, frm.Vidrio.IdDb, 0),
                               frm.Vidrio.Referencia, frm.Vidrio.Descripcion, frm.cantidad, frm.piezasxUnidad, frm.ancho, frm.alto,
                               calculo.MetrosCuadrados, 32, frm.Vidrio.IdDb, frm.Color.IdDb, frm.Espesor.IdDb, frm.Vidrio.UnidadMedida,
                               nudDescuento.Value, calculo.ValorDescuento, calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal,
                               calculo.PrecioTotal, nudPrecioInstalacion.Value, calculo.PrecioInstalacion, frm.CostoInstalacionUnitario,
                               calculo.CostoVidrio, 0, 0, 0, frm.Factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal,
                               False, frm.esColorTemporal, frm.esEspesorTemporal, frm.DTableTrabajos, False, calculo.vlrdespVidrio, 0, 0, 0)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Add_Otros_Click(sender As Object, e As EventArgs) Handles tsbAddOtros.Click
        Try
            Dim frm As New FrmAddOtros
            frm.IdCotiza = _idCotiza
            frm.VersionCostoOtros = _versionCostoOtros
            frm.factor = _factorGlobal.tasa
            If frm.ShowDialog() = DialogResult.OK Then
                calculo = New ClsCalculos
                calculo.tasaImpuesto = _tasaImpuestoGlobal
                calculo.indAIU = _indAIU
                Dim r As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
                r.Cells(numero_cuerpos_norma.Index).Value = 0
                If frm.Articulo.Temporal = True Or frm.Acabado.Temporal = True Then
                    calculo.Temporales(frm.Articulo, frm.cantidad, frm.piezasxUnidad, 0, 0, Nothing, Nothing, Nothing, Nothing, nudDescuento.Value,
                                       frm.factor, nudPrecioInstalacion.Value, frm.Articulo.PorcentajeDesperdicio, _idCotiza, frm.DTableTrabajos)
                    llenarFila(r, If(frm.Articulo.Temporal = True, 0, frm.Articulo.Id), If(frm.Articulo.Temporal = True, frm.Articulo.Id, 0),
                               frm.Articulo.Referencia, frm.Articulo.Descripcion, frm.cantidad, frm.piezasxUnidad, 0, 0, 0,
                               frm.Acabado.Id, 838, 32, 1, frm.Articulo.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                               calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                               calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, 0, calculo.CostoTotal, frm.factor, ClsEnums.FamiliasMateriales.TEMPORAL, frm.CurId,
                               _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, frm.Acabado.Temporal, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                Else
                    calculo.Calcular_Otros(frm.Articulo.Id, frm.cantidad, frm.piezasxUnidad, _versionCostoOtros,
                                           frm.Articulo.PorcentajeDesperdicio, frm.factor, nudDescuento.Value,
                                           frm.CostoInstalacionUnitario, frm.DTableTrabajos)
                    llenarFila(r, frm.Articulo.Id, 0, frm.Articulo.Referencia, frm.Articulo.Descripcion, frm.cantidad, frm.piezasxUnidad,
                               0, 0, 0, frm.Acabado.Id, 838, 32, 1, frm.Articulo.UnidadMedida, nudDescuento.Value, calculo.ValorDescuento,
                               calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                               calculo.PrecioInstalacion, frm.CostoInstalacionUnitario, 0, 0, 0, calculo.CostoOtros, frm.factor, ClsEnums.FamiliasMateriales.OTROS,
                               frm.CurId, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, False, False, False, frm.DTableTrabajos, False, 0, 0, 0, calculo.vlrdespOtros)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub valorarIndividual(dr As DataGridViewRow, dataToChange As String, newValue As String)
        Try
            Dim analiza As AnalizadorLexico = DirectCast(dr.Cells(especial.Index).Value, AnalizadorLexico)
            If Convert.ToInt32(dr.Cells(tipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS And analiza IsNot Nothing Then
                If analiza.ListaVariables.Contains(dataToChange) Then
                    analiza.ListaVariables.Item(dataToChange).Valor = newValue
                    analiza.ListaVariables.Item(dataToChange).Formula = String.Empty
                    cargarAnalizador(dr)
                    calculo = New ClsCalculos
                    calculo.tasaImpuesto = _tasaImpuestoGlobal
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
                    Dim costoVidrio, costoPerfiles, costoAccesorios, costoOtros,
                        vlrDespVidrio, vlrDespPerfiles, vlrDespAccesorio,
                        vlrDespOtros, costo_instala, costo_unitario As Decimal
                    costoVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    costoPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    costoAccesorios = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    costoOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) = True).Sum(Function(b) b.Costo_Total)
                    vlrDespVidrio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Vidrios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                    vlrDespPerfiles = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Perfiles And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                    vlrDespAccesorio = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Accesorios And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                    vlrDespOtros = analiza.ListaMateriales.Where(Function(a) a.TipoObjeto = TiposElementos.Otros And CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) b.VlrDesperdicio)
                    costo_instala = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Instalacion_Total))
                    costo_unitario = analiza.ListaMateriales.Where(Function(a) CBool(a.Parametros("VISIBILIDAD").Valor) And a.Utilizar).Sum(Function(b) Convert.ToDecimal(b.Costo_Unitario))

                    calculo.Calcular_Disenio(costo_unitario, Convert.ToDecimal(analiza.ListaVariables.Item("CANTIDAD").Valor),
                                             Convert.ToDecimal(dr.Cells(piezasXUnidad.Index).Value),
                                             Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor), Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor),
                                             nudDescuento.Value, Convert.ToDecimal(dr.Cells(factor.Index).Value),
                                             nudPrecioInstalacion.Value, costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costo_instala)
                    llenarFila(dr, dr.Cells(idArticulo.Index).Value, dr.Cells(idArticuloTemp.Index).Value, dr.Cells(referencia.Index).Value, dr.Cells(descripcion.Index).Value,
                               analiza.ListaVariables.Item("CANTIDAD").Valor, CDec(dr.Cells(piezasXUnidad.Index).Value),
                               Convert.ToDecimal(analiza.ListaVariables.Item("ANCHO").Valor), Convert.ToDecimal(analiza.ListaVariables.Item("ALTO").Valor),
                               calculo.MetrosCuadrados, idAcabado, idVidrio, idColorVidrio, idEspesor, "UN", nudDescuento.Value, calculo.ValorDescuento,
                               calculo.CostoUnitario, calculo.PrecioUnitario, calculo.CostoTotal, calculo.PrecioTotal, nudPrecioInstalacion.Value,
                               calculo.PrecioInstalacion, costo_instala, costoVidrio, costoPerfiles, costoAccesorios, costoOtros, FactorGlobal.tasa, ClsEnums.FamiliasMateriales.DISEÑOS,
                               dr.Cells(id.Index).Value, _IdTasaImpuestoGlobal, _tasaImpuestoGlobal, False, False, False, analiza,
                               Convert.ToBoolean(dr.Cells(actualizar_plantilla.Index).Value), vlrDespVidrio, vlrDespPerfiles, vlrDespAccesorio, vlrDespOtros)

                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnguardarcerrar_Click(sender As Object, e As EventArgs) Handles btnguardarcerrar.Click
        Try
            If tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                Me.DialogResult = DialogResult.None
                Me.Close()
            Else
                If dwItem.Rows.Count = 0 Then
                    MessageBox.Show("No se puede agregar un item sin hijos", "")
                    Exit Sub
                Else
                    Dim c As FrmCotizaciones = DirectCast(nodotrabajo.DataGridView.FindForm(), FrmCotizaciones)
                    nodotrabajo.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
                    nodotrabajo.Cells(c.id.Index).Value = _curid
                    nodotrabajo.Cells(c.idArticulo.Index).Value = 0
                    nodotrabajo.Cells(c.Ubicacion.Index).Value = txtUbicacion.Text
                    nodotrabajo.Cells(c.Descripcion.Index).Value = txtdescripcion.Text
                    nodotrabajo.Cells(c.ancho.Index).Value = nudancho.Value
                    nodotrabajo.Cells(c.Alto.Index).Value = nudalto.Value
                    nodotrabajo.Cells(c.Cantidad.Index).Value = nudcantidad.Value
                    nodotrabajo.Cells(c.piezasxUnidad.Index).Value = "--"
                    nodotrabajo.Cells(c.acabadoPerf.Index).Value = cmbAcabado.SelectedValue
                    nodotrabajo.Cells(c.vidrio.Index).Value = _listArticulos.FirstOrDefault(Function(a) a.IdDb = Convert.ToInt32(cmbVidrio.SelectedValue)).Id
                    nodotrabajo.Cells(c.colorVidrio.Index).Value = _listColores.FirstOrDefault(Function(a) a.IdDb = Convert.ToInt32(cmbcolorvidrio.SelectedValue)).Id
                    nodotrabajo.Cells(c.espesor.Index).Value = _listEspesores.FirstOrDefault(Function(a) a.IdDb = Convert.ToInt32(cmbEspesores.SelectedValue)).Id
                    nodotrabajo.Cells(c.factor.Index).Value = FactorGlobal.tasa
                    nodotrabajo.Cells(c.descuento.Index).Value = nudDescuento.Value
                    nodotrabajo.Cells(c.valorDescuento.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(valorDescuento.Index).Value)), 0)
                    nodotrabajo.Cells(c.costoUnitario.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(costoUnitario.Index).Value) * CDec(a.Cells(piezasXUnidad.Index).Value)), 0)
                    nodotrabajo.Cells(c.precioUnitario.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(precioUnitario.Index).Value)), 0)
                    nodotrabajo.Cells(c.costoTotal.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(costoTotal.Index).Value)), 0)

                    nodotrabajo.Cells(c.precioTotal.Index).Value = Math.Round(CDec(nodotrabajo.Cells(c.precioUnitario.Index).Value) * CDec(nodotrabajo.Cells(c.Cantidad.Index).Value), 0)

                    nodotrabajo.Cells(c.costoVidrio.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(costoVidrio.Index).Value)), 0)
                    nodotrabajo.Cells(c.costoPerfiles.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(costoPerfiles.Index).Value)), 0)
                    nodotrabajo.Cells(c.costoAccesorios.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(costoAccesorio.Index).Value)), 0)
                    nodotrabajo.Cells(c.costoOtros.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(costoOtros.Index).Value)), 0)
                    nodotrabajo.Cells(c.vlrDesperdicioVidrio.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(vlrDesperdicioVidrio.Index).Value)), 0)
                    nodotrabajo.Cells(c.vlrDesperdicioPerfiles.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(vlrDesperdicioPerfiles.Index).Value)), 0)
                    nodotrabajo.Cells(c.vlrDesperdicioAccesorios.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(vlrDespedicioAccesorios.Index).Value)), 0)
                    nodotrabajo.Cells(c.vlrDesperdicioOtros.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) CDec(a.Cells(vlrDespOtros.Index).Value)), 0)
                    nodotrabajo.Cells(c.calcularnorma.Index).Value = _calcular_norma
                    nodotrabajo.Cells(c.cumplenorma.Index).Value = _cumple_norma
                    nodotrabajo.Cells(c.numero_cuerpos_norma.Index).Value = _numero_cuerpos_norma_
                    Dim vparcial As Decimal = 0
                    Select Case Trim(Convert.ToString(cmbuminstala.SelectedValue))
                        Case "UND"
                            vparcial = 1
                        Case "MTS2"
                            vparcial = (nudancho.Value / 1000) * (nudalto.Value / 1000)
                        Case "MTL"
                            vparcial = (nudancho.Value / 1000)
                    End Select

                    nodotrabajo.Cells(c.mtCuadrados.Index).Value = vparcial * Math.Round(CDec(nudcantidad.Value), 3)

                    nodotrabajo.Cells(c.Mtinstalacion.Index).Value = If(vparcial < 1, 1, vparcial) * CDec(nudcantidad.Value)




                    nodotrabajo.Cells(c.precioInstalacion.Index).Value = Math.Round(If(_indCobroMetrosReales,
                    If(_indAIU, CDec(nodotrabajo.Cells(c.mtCuadrados.Index).Value) * (nudPrecioInstalacion.Value) + ((nudPrecioInstalacion.Value) * (_tasaUtilidad / 100) * (tasaImpuestoGlobal / 100)), CDec(nodotrabajo.Cells(c.mtCuadrados.Index).Value) * nudPrecioInstalacion.Value),
                    If(_indAIU, CDec(nodotrabajo.Cells(c.Mtinstalacion.Index).Value) * (nudPrecioInstalacion.Value) + ((nudPrecioInstalacion.Value) * (_tasaUtilidad / 100) * (tasaImpuestoGlobal / 100)), CDec(nodotrabajo.Cells(c.Mtinstalacion.Index).Value) * nudPrecioInstalacion.Value)), 0)


                    nodotrabajo.Cells(c.precioMtInstalacion.Index).Value = nudPrecioInstalacion.Value
                    nodotrabajo.Cells(c.costoinstalacion.Index).Value = Math.Round(dwItem.Rows.Cast(Of DataGridViewRow).Sum(Function(a) Convert.ToDecimal((a.Cells(costoinstalacion.Index).Value))), 0)
                    nodotrabajo.Cells(c.tipoItem.Index).Value = "--"
                    nodotrabajo.Cells(c.tasaImpuesto.Index).Value = nudtasa.Value
                    nodotrabajo.Cells(c.unmedinstala.Index).Value = cmbuminstala.SelectedValue
                    nodotrabajo.Cells(c.descuentoinstala.Index).Value = nuddescuentoinstalacion.Value
                    nodotrabajo.Cells(c.tipoItem.Index).Value = "--"
                    nodotrabajo.Cells(c.especial.Index).Value = egmodelo.EstructuraPrincipal
                    If String.IsNullOrEmpty(Convert.ToString(nodotrabajo.Cells(c.idpropiedad.Index).Value)) Then
                        nodotrabajo.Cells(c.idpropiedad.Index).Value = 1
                    End If
                    nodotrabajo.Cells(c.indGuardado.Index).Value = False
                    nodotrabajo.Nodes.Clear()
                    dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                            Dim ndh As New DataGridViewTreeNode
                                                                            nodotrabajo.Nodes.Add(ndh)
                                                                            ndh.Cells(c.id.Index).Value = Convert.ToInt32(r.Cells(id.Index).Value)
                                                                            ndh.Cells(c.idArticulo.Index).Value = Convert.ToInt32(r.Cells(idArticulo.Index).Value)
                                                                            ndh.Cells(c.idArticuloTemp.Index).Value = Convert.ToInt32(r.Cells(idArticuloTemp.Index).Value)
                                                                            ndh.Cells(c.Ubicacion.Index).Value = Convert.ToString(r.Cells(referencia.Index).Value)
                                                                            ndh.Cells(c.Descripcion.Index).Value = Convert.ToString(r.Cells(descripcion.Index).Value)
                                                                            ndh.Cells(c.ancho.Index).Value = Convert.ToString(r.Cells(ancho.Index).Value)
                                                                            ndh.Cells(c.Alto.Index).Value = Convert.ToString(r.Cells(alto.Index).Value)
                                                                            ndh.Cells(c.mtCuadrados.Index).Value = r.Cells(mtCuadrados.Index).Value
                                                                            Select Case DirectCast(CInt(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales)
                                                                                Case ClsEnums.FamiliasMateriales.DISEÑOS, ClsEnums.FamiliasMateriales.VIDRIO
                                                                                    Dim valorparcial As Decimal = (CDec(r.Cells(ancho.Index).Value) * CDec(r.Cells(alto.Index).Value)) / 1000000
                                                                                    ndh.Cells(c.Mtinstalacion.Index).Value = If(valorparcial < 1, 1, valorparcial) * CDec(r.Cells(piezasXUnidad.Index).Value) * CDec(r.Cells(cantidad.Index).Value)
                                                                                Case Else
                                                                                    ndh.Cells(c.Mtinstalacion.Index).Value = 0
                                                                            End Select
                                                                            ndh.Cells(c.Cantidad.Index).Value = Convert.ToString(r.Cells(cantidad.Index).Value)
                                                                            ndh.Cells(c.piezasxUnidad.Index).Value = Convert.ToDecimal(r.Cells(piezasXUnidad.Index).Value)
                                                                            ndh.Cells(c.acabadoPerf.Index).Value = r.Cells(acabadoPerf.Index).Value
                                                                            ndh.Cells(c.vidrio.Index).Value = r.Cells(vidrio.Index).Value
                                                                            ndh.Cells(c.colorVidrio.Index).Value = r.Cells(colorVidrio.Index).Value
                                                                            ndh.Cells(c.espesor.Index).Value = r.Cells(espesor.Index).Value
                                                                            ndh.Cells(c.factor.Index).Value = r.Cells(factor.Index).Value
                                                                            ndh.Cells(c.descuento.Index).Value = r.Cells(descuento.Index).Value
                                                                            ndh.Cells(c.valorDescuento.Index).Value = r.Cells(valorDescuento.Index).Value
                                                                            ndh.Cells(c.costoUnitario.Index).Value = Round(Convert.ToDecimal(r.Cells(costoUnitario.Index).Value))
                                                                            ndh.Cells(c.precioUnitario.Index).Value = Round(Convert.ToDecimal(r.Cells(precioUnitario.Index).Value))
                                                                            ndh.Cells(c.costoTotal.Index).Value = Round(Convert.ToDecimal(r.Cells(costoTotal.Index).Value))
                                                                            ndh.Cells(c.precioTotal.Index).Value = Round(Convert.ToDecimal(r.Cells(precioTotal.Index).Value))
                                                                            ndh.Cells(c.costoVidrio.Index).Value = Convert.ToDecimal(r.Cells(costoVidrio.Index).Value)
                                                                            ndh.Cells(c.costoPerfiles.Index).Value = Convert.ToDecimal(r.Cells(costoPerfiles.Index).Value)
                                                                            ndh.Cells(c.costoAccesorios.Index).Value = Convert.ToDecimal(r.Cells(costoAccesorio.Index).Value)
                                                                            ndh.Cells(c.costoOtros.Index).Value = Convert.ToDecimal(r.Cells(costoOtros.Index).Value)
                                                                            ndh.Cells(c.precioMtInstalacion.Index).Value = 0 ' Convert.ToDecimal(r.Cells(precioMtInstalacion.Index).Value)
                                                                            ndh.Cells(c.precioInstalacion.Index).Value = 0 'Convert.ToDecimal(r.Cells(precioInstalacion.Index).Value)
                                                                            ndh.Cells(c.costoinstalacion.Index).Value = Convert.ToDecimal(r.Cells(costoinstalacion.Index).Value)
                                                                            ndh.Cells(c.unidadMedida.Index).Value = Convert.ToString(r.Cells(unidadMedida.Index).Value)
                                                                            ndh.Cells(c.tipoItem.Index).Value = Convert.ToString(r.Cells(tipoItem.Index).Value)
                                                                            ndh.Cells(c.especial.Index).Value = r.Cells(especial.Index).Value
                                                                            ndh.Cells(c.idTasaImpuesto.Index).Value = r.Cells(idTasaImpuesto.Index).Value
                                                                            ndh.Cells(c.tasaImpuesto.Index).Value = r.Cells(tasaImpuesto.Index).Value
                                                                            If Not Convert.ToBoolean(ndh.Cells(c.actualizar_plantilla.Index).Value) Then
                                                                                ndh.Cells(c.actualizar_plantilla.Index).Value = r.Cells(actualizar_plantilla.Index).Value
                                                                            End If
                                                                            If Not Convert.ToBoolean(nodotrabajo.Cells(c.calcularnorma.Index).Value) And Convert.ToInt32(ndh.Cells(c.tipoItem.Index).Value) = 1 Then
                                                                                ndh.Cells(c.calcularnorma.Index).Value = r.Cells(calcular_nsr.Index).Value
                                                                            End If

                                                                            ndh.Cells(c.tasaImpuesto.Index).Value = 0
                                                                            ndh.Cells(c.unmedinstala.Index).Value = "--"
                                                                            ndh.Cells(c.descuentoinstala.Index).Value = 0

                                                                            ndh.Cells(c.acabTemporal.Index).Value = r.Cells(acabTemporal.Index).Value
                                                                            ndh.Cells(c.colorTemporal.Index).Value = r.Cells(colorTemporal.Index).Value
                                                                            ndh.Cells(c.espesorTemporal.Index).Value = r.Cells(espesorTemporal.Index).Value
                                                                            ndh.Cells(c.vlrDesperdicioVidrio.Index).Value = r.Cells(vlrDesperdicioVidrio.Index).Value
                                                                            ndh.Cells(c.vlrDesperdicioPerfiles.Index).Value = r.Cells(vlrDesperdicioPerfiles.Index).Value
                                                                            ndh.Cells(c.vlrDesperdicioAccesorios.Index).Value = r.Cells(vlrDespedicioAccesorios.Index).Value
                                                                            ndh.Cells(c.vlrDesperdicioOtros.Index).Value = r.Cells(vlrDespOtros.Index).Value

                                                                            ndh.Cells(c.calcularnorma.Index).Value = r.Cells(calcular_nsr.Index).Value
                                                                            ndh.Cells(c.cumplenorma.Index).Value = r.Cells(cumplenorma.Index).Value
                                                                            ndh.Cells(c.numero_cuerpos_norma.Index).Value = r.Cells(numero_cuerpos_norma.Index).Value

                                                                        End Sub)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudDescuento_ValueChanged(sender As Object, e As EventArgs) Handles nudDescuento.ValueChanged
        Try
            If dwItem.Rows.Count > 0 Then
                dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                        r.Cells(descuento.Index).Value = nudDescuento.Value
                                                                        RecalcularFila(r)
                                                                    End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudPrecioInstalacion_ValueChanged(sender As Object, e As EventArgs) Handles nudPrecioInstalacion.ValueChanged
        Try
            If dwItem.Rows.Count > 0 Then
                dwItem.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                        r.Cells(precioMtInstalacion.Index).Value = nudPrecioInstalacion.Value
                                                                        RecalcularFila(r)
                                                                    End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudancho.GotFocus, nudalto.GotFocus,
            nudcantidad.GotFocus, nudDescuento.GotFocus, nudPrecioInstalacion.GotFocus
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Value = 0 Then
                nud.ResetText()
            End If
            valor_cantidad_original = nudcantidad.Value
            valor_ancho_original = nudancho.Value
            valor_alto_original = nudalto.Value
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudancho.Leave, nudalto.Leave,
            nudcantidad.Leave, nudDescuento.Leave, nudPrecioInstalacion.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If dwItem.RowCount > 0 Then
                If nud Is nudcantidad Then
                    If nudcantidad.Value <> valor_cantidad_original Then
                        If MsgBox("El cambio en la cantidad puede generar un re-calculo en los elementos agregados. ¿ Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            valor_cantidad_original = nudcantidad.Value
                            RecalcularElementos(valor_cantidad_original, String.Empty, ClsEnums.Tipos_Cambio.CANTIDAD)
                        Else
                            nudcantidad.Value = valor_cantidad_original
                        End If
                    End If
                ElseIf nud Is nudancho Then
                    If nudancho.Value <> valor_ancho_original Then
                        If MsgBox("El cambio en el ancho puede generar un re-calculo en los elementos agregados y la perdida de los dibujos. ¿ Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            valor_ancho_original = nudancho.Value
                            RecalcularElementos(valor_ancho_original, String.Empty, ClsEnums.Tipos_Cambio.ANCHO)
                            egmodelo.EstructuraPrincipal.Estructuras.Clear()
                            egmodelo.EstructuraPrincipal.Estructura = String.Empty
                            egmodelo.EstructuraPrincipal.Arquitecto = Nothing
                            egmodelo.EstructuraPrincipal.Ancho_Real = valor_ancho_original
                        Else
                            nudancho.Value = valor_ancho_original
                        End If
                    End If
                ElseIf nud Is nudalto Then
                    If nudalto.Value <> valor_alto_original Then
                        If MsgBox("El cambio en el alto puede generar un re-calculo en los elementos agregados y la perdida de los dibujos. ¿ Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            valor_alto_original = nudalto.Value
                            RecalcularElementos(valor_alto_original, String.Empty, ClsEnums.Tipos_Cambio.ALTO)
                            egmodelo.EstructuraPrincipal.Estructuras.Clear()
                            egmodelo.EstructuraPrincipal.Estructura = String.Empty
                            egmodelo.EstructuraPrincipal.Arquitecto = Nothing
                            egmodelo.EstructuraPrincipal.Alto_Real = valor_alto_original
                        Else
                            nudalto.Value = valor_alto_original
                        End If
                    End If
                End If
            Else

                If nud Is nudancho Then
                    If nudancho.Value <> valor_ancho_original Then
                        If egmodelo.EstructuraPrincipal.Estructuras.Count > 0 Then
                            If MsgBox("El cambio en el ancho puede generar la perdida de los dibujos. ¿ Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                valor_ancho_original = nudancho.Value
                                egmodelo.EstructuraPrincipal.Estructuras.Clear()
                                egmodelo.EstructuraPrincipal.Estructura = String.Empty
                                egmodelo.EstructuraPrincipal.Arquitecto = Nothing
                                egmodelo.EstructuraPrincipal.Ancho_Real = valor_ancho_original
                                egmodelo.Refresh()
                            Else
                                nudancho.Value = valor_ancho_original
                            End If
                        Else
                            valor_alto_original = nudancho.Value
                            egmodelo.EstructuraPrincipal.Ancho_Real = valor_alto_original
                            egmodelo.Refresh()
                        End If
                    End If
                ElseIf nud Is nudalto Then
                    If nudalto.Value <> valor_alto_original Then
                        If egmodelo.EstructuraPrincipal.Estructuras.Count > 0 Then
                            If MsgBox("El cambio en el alto puede generar la perdida de los dibujos. ¿ Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                valor_alto_original = nudalto.Value
                                egmodelo.EstructuraPrincipal.Estructuras.Clear()
                                egmodelo.EstructuraPrincipal.Estructura = String.Empty
                                egmodelo.EstructuraPrincipal.Arquitecto = Nothing
                                egmodelo.EstructuraPrincipal.Alto_Real = valor_alto_original
                                egmodelo.Refresh()
                            Else
                                nudalto.Value = valor_alto_original
                            End If
                        Else
                            valor_alto_original = nudalto.Value
                            egmodelo.EstructuraPrincipal.Alto_Real = valor_alto_original
                            egmodelo.Refresh()
                        End If
                    End If
                End If
            End If
            If nud.DecimalPlaces = 0 Then
                If nud.Controls.Item(1).Text = "" Then
                    nud.Controls.Item(1).Text = "0"
                    nud.Value = 0
                End If
            ElseIf nud.DecimalPlaces = 2 Then
                If nud.Controls.Item(1).Text = "" Then
                    nud.Controls.Item(1).Text = "0.00"
                    nud.Value = 0.00
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudMedidasAndCantidad_ValueChanged(sender As Object, e As EventArgs) Handles nudancho.ValueChanged,
        nudalto.ValueChanged, nudcantidad.ValueChanged
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If (nud Is nudalto Or nud Is nudancho) Then
                If _cumple_norma Then
                    MsgBox("Debe recalcular la norma NSR despues del cambio", MsgBoxStyle.Information)
                End If
                _cumple_norma = False
            End If
            calculo = New ClsCalculos
            calculo.tasaImpuesto = _tasaImpuestoGlobal
            calculo.indAIU = _indAIU
            mt2Padre = calculo.mtCuadradosPadre(nudancho.Value, nudalto.Value, nudcantidad.Value)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbVidrio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVidrio.SelectedValueChanged
        Try
            If CInt(cmbVidrio.SelectedValue) = 838 Then
                cmbcolorvidrio.SelectedValue = 32
                cmbEspesores.SelectedValue = 1
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItem.CellEndEdit
        Try
            Dim r As DataGridViewRow = dwItem.Rows(e.RowIndex)
            If DirectCast(CInt(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                dwItem.Item(actualizar_plantilla.Index, e.RowIndex).Value = True
                Select Case e.ColumnIndex
                    Case cantidad.Index
                        valorarIndividual(r, "CANTIDAD", r.Cells(cantidad.Index).Value)
                    Case piezasXUnidad.Index
                        valorarIndividual(r, "PIEZAS_X_UND", r.Cells(piezasXUnidad.Index).Value)
                    Case ancho.Index
                        r.Cells(cumplenorma.Index).Value = False
                        If CDec(r.Cells(ancho.Index).Value) > nudancho.Value Then
                            MsgBox("EL ancho no puede ser mayor al ancho del ítem general", MsgBoxStyle.Critical)
                            r.Cells(ancho.Index).Value = nudancho.Value
                        End If
                        valorarIndividual(r, "ANCHO", r.Cells(ancho.Index).Value)
                    Case alto.Index
                        r.Cells(cumplenorma.Index).Value = False
                        If CDec(r.Cells(alto.Index).Value) > nudalto.Value Then
                            MsgBox("EL alto no puede ser mayor al alto del ítem general", MsgBoxStyle.Critical)
                            r.Cells(alto.Index).Value = nudalto.Value
                        End If
                        valorarIndividual(r, "ALTO", r.Cells(alto.Index).Value)
                    Case vidrio.Index
                        valorarIndividual(r, "TIPO_VIDRIO", r.Cells(vidrio.Index).FormattedValue)
                    Case acabadoPerf.Index
                        valorarIndividual(r, "ACABADO", r.Cells(acabadoPerf.Index).FormattedValue)
                    Case colorVidrio.Index
                        valorarIndividual(r, "COLOR_VIDRIO", r.Cells(colorVidrio.Index).FormattedValue)
                    Case espesor.Index
                        valorarIndividual(r, "ESPESOR", r.Cells(espesor.Index).FormattedValue)
                    Case Else
                End Select
            Else
                RecalcularFila(r)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncolpanel_Click(sender As Object, e As EventArgs) Handles btncolpanel.Click
        Try
            scgenpadre.Panel2Collapsed = Not scgenpadre.Panel2Collapsed
            btncolpanel.Text = If(scgenpadre.Panel2Collapsed, "Mostrar Dibujo", "Ocultar Dibujo")
            egmodelo.EstructuraPrincipal.Ancho_Real = nudancho.Value
            egmodelo.EstructuraPrincipal.Alto_Real = nudalto.Value
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseDown
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Left Then
                    If Convert.ToInt32(dwItem.Item(tipoItem.Index, e.RowIndex).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                        If e.ColumnIndex = referencia.Index Or e.ColumnIndex = descripcion.Index Then
                            Dim an As AnalizadorLexico = DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico)
                            If an IsNot Nothing Then
                                Dim listdib As List(Of DibujoModelo)
                                If String.IsNullOrEmpty(Convert.ToString(dwItem.Item(id.Index, e.RowIndex).Value)) Or
                                    Convert.ToString(dwItem.Item(id.Index, e.RowIndex).Value).Equals("0") Or
                                    Convert.ToBoolean(dwItem.Item(actualizar_plantilla.Index, e.RowIndex).Value) Then
                                    Dim dib As New ClsDibujosModelo
                                    listdib = dib.TraerxIdPlantilla(Convert.ToInt32(dwItem.Item(idArticulo.Index, e.RowIndex).Value))
                                Else
                                    Dim dib As New ClsDibujosPlantillaCotiza
                                    listdib = dib.TraerporIdHijoCotiza(Convert.ToInt32(dwItem.Item(id.Index, e.RowIndex).Value))
                                    If listdib.Count <= 0 Then
                                        Dim db As New ClsDibujosModelo
                                        listdib = db.TraerxIdPlantilla(Convert.ToInt32(dwItem.Item(idArticulo.Index, e.RowIndex).Value))
                                    End If
                                End If
                                Dim mdib As DibujoModelo = New DibujoModelo
                                For i = 0 To listdib.Count - 1
                                    If listdib(i).Predeterminado.StartsWith("=") Then
                                        If Convert.ToBoolean(Convert.ToInt32(an.EjecutarExpresion(listdib(i).Predeterminado.Remove(0, 1)))) Then
                                            mdib = listdib(i)
                                            Exit For
                                        End If
                                    Else
                                        If Convert.ToBoolean(Convert.ToInt32(listdib(i).Predeterminado)) Then
                                            mdib = listdib(i)
                                            Exit For
                                        End If
                                    End If
                                Next
                                Dim vn As New DXF.Dibujante_DXF.Ventana(an, New SizeF(700, 700))
                                vn.LeerDxfPersonalizado(mdib.DXF, False)
                                If String.IsNullOrEmpty(Convert.ToString(dwItem.Item(id.Index, e.RowIndex).Value)) Then
                                    dwItem.DoDragDrop({ClsEnums.FamiliasMateriales.DISEÑOS, vn, e.RowIndex, 0,
                                                      dwItem.Item(ancho.Index, e.RowIndex).Value,
                                                      dwItem.Item(alto.Index, e.RowIndex).Value, nudancho.Value, nudalto.Value},
                                                      DragDropEffects.All)
                                Else
                                    dwItem.DoDragDrop({ClsEnums.FamiliasMateriales.DISEÑOS, vn, e.RowIndex,
                                                      Convert.ToInt32(dwItem.Item(id.Index, e.RowIndex).Value),
                                                      dwItem.Item(ancho.Index, e.RowIndex).Value,
                                                      dwItem.Item(alto.Index, e.RowIndex).Value, nudancho.Value, nudalto.Value},
                                                      DragDropEffects.All)
                                End If
                            End If
                        End If
                    ElseIf Convert.ToInt32(dwItem.Item(tipoItem.Index, e.RowIndex).Value) = ClsEnums.FamiliasMateriales.PERFILERIA Then

                        Dim cart As New ClsArticulos
                        Dim art As Articulo = cart.TraerxId(dwItem.Item(idArticulo.Index, e.RowIndex).Value)
                        If String.IsNullOrEmpty(Convert.ToString(dwItem.Item(id.Index, e.RowIndex).Value)) Then
                            dwItem.DoDragDrop({ClsEnums.FamiliasMateriales.PERFILERIA, art.Referencia,
                                              e.RowIndex, 0, Convert.ToString(dwItem.Item(acabadoPerf.Index, e.RowIndex).FormattedValue),
                                              dwItem.Item(ancho.Index, e.RowIndex).Value, art.AltoDecuento},
                                              DragDropEffects.All)
                        Else
                            dwItem.DoDragDrop({ClsEnums.FamiliasMateriales.PERFILERIA, art.Referencia,
                                              e.RowIndex, Convert.ToInt32(dwItem.Item(id.Index, e.RowIndex).Value),
                                              Convert.ToString(dwItem.Item(acabadoPerf.Index, e.RowIndex).FormattedValue),
                                                        dwItem.Item(ancho.Index, e.RowIndex).Value, art.AltoDecuento},
                                              DragDropEffects.All)
                        End If
                    End If
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    dwItem.Rows(e.RowIndex).Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                    menu.Items.Add("Duplicar", Nothing, AddressOf Duplicar)
                    menu.Items.Add("Eliminar", Nothing, AddressOf Eliminar)
                    If dwItem.Columns(costoVidrio.Index).Visible = False Or
                            dwItem.Columns(costoPerfiles.Index).Visible = False Or
                            dwItem.Columns(costoAccesorio.Index).Visible = False Or
                            dwItem.Columns(costoUnitario.Index).Visible = False Or
                            dwItem.Columns(costoTotal.Index).Visible = False Or
                            dwItem.Columns(costoOtros.Index).Visible = False Then
                        menu.Items.Add("Mostrar más", Nothing, AddressOf mostrarCostos)
                    Else
                        menu.Items.Add("Mostrar menos", Nothing, AddressOf ocultarCostos)
                    End If
                    If Convert.ToInt32(dwItem.Item(tipoItem.Index, e.RowIndex).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                        menu.Items.Add("Lista de materiales", Nothing, AddressOf MostrarMateriales)
                    End If
                    menu.Show(Control.MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudhorizontal_ValueChanged(sender As Object, e As EventArgs) Handles nudhorizontal.ValueChanged
        Try
            If nudhorizontal.Value > 1 Then
                egmodelo.DividirRegion(Convert.ToInt32(nudhorizontal.Value), True)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudvertical_ValueChanged(sender As Object, e As EventArgs) Handles nudvertical.ValueChanged
        Try
            If nudvertical.Value > 1 Then
                egmodelo.DividirRegion(Convert.ToInt32(nudvertical.Value), False)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nudvertical_Leave(sender As Object, e As EventArgs) Handles nudvertical.Leave, nudhorizontal.Leave
        Try
            DirectCast(sender, NumericUpDown).Value = DirectCast(sender, NumericUpDown).Minimum
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
        DirectCast(sender, NumericUpDown).Value = DirectCast(sender, NumericUpDown).Minimum
    End Sub
    Private Sub dwItem_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItem.CellBeginEdit
        Try
            Select Case DirectCast(Convert.ToInt32(dwItem.Item(tipoItem.Index, e.RowIndex).Value), ClsEnums.FamiliasMateriales)
                Case ClsEnums.FamiliasMateriales.DISEÑOS
#Region "Validación Diseños"
                    If dwItem.Item(especial.Index, e.RowIndex).Value Is Nothing Then
                        cargarAnalizador(DirectCast(dwItem.Rows(e.RowIndex), DataGridViewRow))
                    End If
                    Select Case e.ColumnIndex
                        Case acabadoPerf.Index
                            If Not DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico).ListaVariables.Contains("ACABADO") Then
                                e.Cancel = True
                            End If
                        Case ancho.Index
                            Dim reg As RegionEstructuras = Nothing
                            egmodelo.ObtenerxIndex(e.RowIndex, egmodelo.EstructuraPrincipal, reg)
                            If reg IsNot Nothing Then
                                If MsgBox("Esta accion eliminara el dibujo del dibujo general. ¿Esta seguro que quiere continuar?") = MsgBoxResult.No Then
                                    e.Cancel = True
                                Else
                                    reg.Id_Hijo_Owner = -1
                                    reg.Index_Hijo_Owner = -1
                                    reg.Estructura = String.Empty
                                    reg.Arquitecto = Nothing
                                    reg.Referencia_Perfil = String.Empty
                                    reg.TipoEstructura = Tipo_Estructura.BASICO
                                End If
                            End If
                            If Not DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico).ListaVariables.Contains("ANCHO") Then
                                e.Cancel = True
                            End If
                        Case alto.Index
                            Dim reg As RegionEstructuras = Nothing
                            egmodelo.ObtenerxIndex(e.RowIndex, egmodelo.EstructuraPrincipal, reg)
                            If reg IsNot Nothing Then
                                If MsgBox("Esta accion eliminara el dibujo del dibujo general. ¿Esta seguro que quiere continuar?") = MsgBoxResult.No Then
                                    e.Cancel = True
                                Else
                                    reg.Id_Hijo_Owner = -1
                                    reg.Index_Hijo_Owner = -1
                                    reg.Estructura = String.Empty
                                    reg.Arquitecto = Nothing
                                    reg.Referencia_Perfil = String.Empty
                                    reg.TipoEstructura = Tipo_Estructura.BASICO
                                End If
                            End If
                            If Not DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico).ListaVariables.Contains("ALTO") Then
                                e.Cancel = True
                            End If
                        Case cantidad.Index
                            If Not DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico).ListaVariables.Contains("CANTIDAD") Then
                                e.Cancel = True
                            End If
                        Case colorVidrio.Index
                            If Not DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico).ListaVariables.Contains("COLOR_VIDRIO") Then
                                e.Cancel = True
                            End If
                        Case espesor.Index
                            If Not DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico).ListaVariables.Contains("ESPESOR") Then
                                e.Cancel = True
                            End If
                        Case vidrio.Index
                            If Not DirectCast(dwItem.Item(especial.Index, e.RowIndex).Value, AnalizadorLexico).ListaVariables.Contains("VIDRIO") Then
                                e.Cancel = True
                            End If
                    End Select
#End Region
                Case ClsEnums.FamiliasMateriales.ACCESORIOS, ClsEnums.FamiliasMateriales.OTROS
#Region "Accesorios, Perfiles y Otros"
                    If e.ColumnIndex = vidrio.Index Or e.ColumnIndex = colorVidrio.Index Or
                         e.ColumnIndex = espesor.Index Or e.ColumnIndex = alto.Index Then
                        e.Cancel = True
                    End If

#End Region
                Case ClsEnums.FamiliasMateriales.PERFILERIA
                    If e.ColumnIndex = vidrio.Index Or e.ColumnIndex = colorVidrio.Index Or
                         e.ColumnIndex = espesor.Index Or e.ColumnIndex = alto.Index Then
                        e.Cancel = True
                    End If
                    If e.ColumnIndex = ancho.Index Then
                        Dim reg As RegionEstructuras = Nothing
                        egmodelo.ObtenerxIndex(e.RowIndex, egmodelo.EstructuraPrincipal, reg)
                        If reg IsNot Nothing Then
                            If MsgBox("Esta accion eliminara el dibujo del dibujo general. ¿Esta seguro que quiere continuar?") = MsgBoxResult.No Then
                                e.Cancel = True
                            Else
                                reg.Id_Hijo_Owner = -1
                                reg.Index_Hijo_Owner = -1
                                reg.Estructura = String.Empty
                                reg.Arquitecto = Nothing
                                reg.Referencia_Perfil = String.Empty
                                reg.TipoEstructura = Tipo_Estructura.BASICO
                            End If
                        End If
                    End If
                Case ClsEnums.FamiliasMateriales.VIDRIO
#Region "Vidrios"
                    If e.ColumnIndex = acabadoPerf.Index Then
                        e.Cancel = True
                    End If
#End Region
                Case ClsEnums.FamiliasMateriales.TEMPORAL
#Region "Temporales"
                    If e.ColumnIndex = acabadoPerf.Index Or e.ColumnIndex = vidrio.Index Or
                        e.ColumnIndex = espesor.Index Or e.ColumnIndex = colorVidrio.Index Then
                        e.Cancel = True
                    End If
#End Region
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmb_Enter(sender As Object, e As EventArgs) Handles cmbAcabado.Enter, cmbcolorvidrio.Enter, cmbEspesores.Enter, cmbVidrio.Enter
        Try
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            If cmb Is cmbAcabado Then
                valor_acabado_original = cmb.SelectedValue
            ElseIf cmb Is cmbcolorvidrio Then
                valor_color_original = cmb.SelectedValue
            ElseIf cmb Is cmbVidrio Then
                valor_tipo_vidrio_original = cmb.SelectedValue
            ElseIf cmb Is cmbEspesores Then
                valor_espesor_original = cmb.SelectedValue
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbAcabado.SelectionChangeCommitted, cmbVidrio.SelectionChangeCommitted, cmbEspesores.SelectionChangeCommitted, cmbcolorvidrio.SelectionChangeCommitted
        Try
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            If dwItem.RowCount > 0 Then
                If cmb Is cmbAcabado Then
                    If Convert.ToInt32(cmbAcabado.SelectedValue) <> valor_acabado_original Then
                        If MsgBox("El cambio en el acabado puede generar un re-calculo en los elementos agregados. ¿ Desea continuar?", MsgBoxStyle.YesNo) Then
                            valor_acabado_original = cmb.SelectedValue
                            RecalcularElementos(valor_acabado_original, cmb.Text, ClsEnums.Tipos_Cambio.ACABADO)
                        Else
                            cmb.SelectedValue = valor_acabado_original
                        End If
                    End If
                ElseIf cmb Is cmbcolorvidrio Then
                    If Convert.ToInt32(cmbcolorvidrio.SelectedValue) <> valor_color_original Then
                        If MsgBox("El cambio en el color del vidrio puede generar un re-calculo en los elementos agregados. ¿ Desea continuar?", MsgBoxStyle.YesNo) Then
                            valor_color_original = cmb.SelectedValue
                            RecalcularElementos(valor_color_original, cmb.Text, ClsEnums.Tipos_Cambio.COLOR_VIDRIO)
                        Else
                            cmb.SelectedValue = valor_color_original
                        End If
                    End If
                ElseIf cmb Is cmbVidrio Then
                    If Convert.ToInt32(cmbVidrio.SelectedValue) <> valor_tipo_vidrio_original Then
                        If MsgBox("El cambio en el tipo de vidrio puede generar un re-calculo en los elementos agregados. ¿ Desea continuar?", MsgBoxStyle.YesNo) Then
                            valor_tipo_vidrio_original = cmb.SelectedValue
                            RecalcularElementos(valor_tipo_vidrio_original, cmb.Text, ClsEnums.Tipos_Cambio.TIPO_VIDRIO)
                        Else
                            cmb.SelectedValue = valor_tipo_vidrio_original
                        End If
                    End If
                ElseIf cmb Is cmbEspesores Then
                    If Convert.ToInt32(cmbEspesores.SelectedValue) <> valor_espesor_original Then
                        If MsgBox("El cambio en el espesor puede generar un re-calculo en los elementos agregados. ¿ Desea continuar?", MsgBoxStyle.YesNo) Then
                            valor_espesor_original = cmb.SelectedValue
                            RecalcularElementos(valor_espesor_original, cmb.Text, ClsEnums.Tipos_Cambio.ESPESOR)
                        Else
                            cmb.SelectedValue = valor_espesor_original
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub egmodelo_Cambio_Medidas(sender As Object, e As Cambio_Medidas_Eventargs) Handles egmodelo.Cambio_Medidas
        Try
            Dim r As DataGridViewRow
            If e.Id_Item = 0 Then
                r = dwItem.Rows(e.Index)
            Else
                r = dwItem.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(id.Index).Value) = e.Id_Item)
            End If
            r.Cells(ancho.Index).Value = e.Ancho
            If DirectCast(CInt(r.Cells(tipoItem.Index).Value), ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                r.Cells(alto.Index).Value = e.Alto
            End If
            RecalcularFila(r)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#Region "Carga Dibujos Padres"


#End Region

End Class