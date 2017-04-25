Imports ReglasNegocio
Imports ReglasNegocio.movitoHijos
Imports DatagridTreeView
Imports ReglasNegocio.Contratos
Imports Formulador
Imports Norma_NSR
Public Class frmGenerarOP
#Region "Variables"
    Private _objClienteUnoee As clsClientesUnoee
    Private _objUnoee As clsObrasUnoee
    Private _objUnoeeDetalleObra As ClsClienteDetalle
    Private _objContrato As New clsContratos
    Private _objMovitoItems As clsMovitoItemsContrato
    Private _objMovitoHijo As ClsMovitoHijos
    Private carga_plantillas As CargasPlantilla
    Private _estadoHerramientas As Boolean = True
    Private mAcabados As New ClsAcabados
    Private mArticulos As New ClsArticulos
    Private mEspesores As New ClsEspesores
    Private lAcabados As New List(Of Acabado)
    Private lVidrios As New List(Of Articulo)
    Private lEspesores As New List(Of Espesor)
#Region "Variables Ordenes"
    Private encabezadoorden As ClsOrdenDePedido
    Private motivodevol As New ClsMovitoMotivoDevolucionOped
    Private itemsop As ClsItemsOped
    Private dibitemsop As ClsDibujosItemsOps
    Private itemshijos As ClsItemsHijoOped
#Region "Variables Plantilla"
    Private variables_plantilla As ClsVariablesPlantillaOped
    Private descuento_global As ClsDescuentosGeneralesPlantillaOped
    Private observaciones_plantilla As ClsObservacionesPlantillaOped
    Private dibujos_plantilla As ClsDibujosPlantillaOped
    Private materiales_plantilla As ClsMaterialesPlantillaOped
    Private descuento_material_plantilla As ClsDescuentosMaterialPlantillaOped
#End Region
#End Region

#Region "Especiales"
    Private valor_anterior_celda As Object = Nothing
#End Region
#End Region
#Region "Propiedades"
    Private _idcontrato As Integer
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(ByVal value As Integer)
            _idcontrato = value
        End Set
    End Property
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Public Property Tipo_Operacion As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Private curid As Integer = 0
    Public Property Id_Actual As Integer
        Get
            Return curid
        End Get
        Set(value As Integer)
            curid = value
        End Set
    End Property
    Private _ordenPedido As OrdenDePedido
    Public Property ordenPedido() As OrdenDePedido
        Get
            Return _ordenPedido
        End Get
        Set(ByVal value As OrdenDePedido)
            _ordenPedido = value
        End Set
    End Property
    Private _listOfPadres As List(Of ItemsOp)
    Public Property listOfPadres() As List(Of ItemsOp)
        Get
            Return _listOfPadres
        End Get
        Set(ByVal value As List(Of ItemsOp))
            _listOfPadres = value
        End Set
    End Property
    Private _listOfHijos As List(Of ItemHijoOp)
    Public Property listoOfHijos() As List(Of ItemHijoOp)
        Get
            Return _listOfHijos
        End Get
        Set(ByVal value As List(Of ItemHijoOp))
            _listOfHijos = value
        End Set
    End Property
#End Region
#Region "Carga Combos encabezado"
    Private Sub cargar_documentos()
        Try
            Dim unoee As New ClsGeneralesUnoee
            cmbdocumentos.DisplayMember = "Código"
            cmbdocumentos.ValueMember = "Código"
            Dim idusuario As Integer = My.Settings.Id_UsuarioUnoee
            If idusuario = 0 Then
                idusuario = 14
            End If
            cmbdocumentos.DataSource = unoee.Obtener_documentos(p_cia:=1, p_modulo:=5, p_clasedocto:=502,
                                                                p_genera_movto:=0, p_rowid_usuario:=idusuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarCentrosOperaciones()
        Try
            Dim mCentroOp As New ClsCentroOperaciones
            Dim listCentrosOp As List(Of centroOperacion) = mCentroOp.traerTodos()
            cmbCentroOperaciones.DisplayMember = "Id"
            cmbCentroOperaciones.ValueMember = "IdCia"
            cmbCentroOperaciones.DatosVisibles = {"Id", "Descripcion"}
            cmbCentroOperaciones.DataSource = listCentrosOp.Where(Function(a) a.IdCia = 1 And a.Id = "001").ToList

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCentrosCostos()
        Try
            Dim unoee As New ClsGeneralesUnoee
            Dim idusuario As Integer = My.Settings.Id_UsuarioUnoee
            cmbCentroCostos.DisplayMember = "Cuenta"
            cmbCentroCostos.ValueMember = "f284_rowid"
            cmbCentroCostos.DatosVisibles = {"Cuenta", "Descripcion"}
            If idusuario = 0 Then
                idusuario = 14
            End If
            cmbCentroCostos.DataSource = unoee.obtener_Ccostos(1, 1, DirectCast(cmbCentroOperaciones.SelectedItem, ReglasNegocio.centroOperacion).Id, "01", "CV", -1, idusuario, Nothing)

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarUnidadNegocio()
        Try
            Dim mUnidadNegocio As New ClsGeneralesUnoee
            Dim unoee As New ClsGeneralesUnoee
            Dim idusuario As Integer = My.Settings.Id_UsuarioUnoee
            cmbUnidadNegocio.DisplayMember = "Codigo"
            cmbUnidadNegocio.ValueMember = "idUn"
            cmbUnidadNegocio.DatosVisibles = {"Codigo", "Descripcion"}
            cmbUnidadNegocio.DataSource = unoee.obtener_uNegocio(1, idusuario)

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarListasPrecios()
        Try
            Dim mListaPrecio As New ClsListaPrecios
            Dim listPrecios As List(Of lisPrecios) = mListaPrecio.traerTodos()
            cmbListaPrecios.DisplayMember = "Id"
            cmbListaPrecios.ValueMember = "Id"
            cmbListaPrecios.DatosVisibles = {"Id", "Descripcion"}
            cmbListaPrecios.DataSource = listPrecios

            cmbListaPrecios.SelectedValue = "LP1"
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Carga Combobox Movimiento"
    Private Sub cargarDesplegablesMovimiento()
        Try
#Region "Cargar listas"
            lAcabados = mAcabados.TraerTodos().ToList
            lVidrios = mArticulos.TraerTodos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO).ToList
            lEspesores = mEspesores.TraerTodos.ToList
#End Region
#Region "Desplegables Items Contrato"
            DirectCast(dwItems.Columns(cVidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Referencia"
            DirectCast(dwItems.Columns(cVidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(cVidrio.Index), DataGridViewComboBoxColumn).DataSource = lVidrios

            DirectCast(dwItems.Columns(cColorVidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItems.Columns(cColorVidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(cColorVidrio.Index), DataGridViewComboBoxColumn).DataSource = lAcabados.Where(Function(a) (a.Id = 32 Or a.idFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO) And CInt(a.IdEstado) = ClsEnums.Estados.ACTIVO).ToList


            DirectCast(dwItems.Columns(cAcabadoPerfiles.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItems.Columns(cAcabadoPerfiles.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(cAcabadoPerfiles.Index), DataGridViewComboBoxColumn).DataSource = lAcabados.Where(Function(a) (a.Id = 32 Or a.idFamiliaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA) And CInt(a.IdEstado) = ClsEnums.Estados.ACTIVO).ToList

            DirectCast(dwItems.Columns(cEspesor.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItems.Columns(cEspesor.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(cEspesor.Index), DataGridViewComboBoxColumn).DataSource = lEspesores
#End Region
#Region "Desplegables Items Op"
            DirectCast(dwItemsOp.Columns(oTipoVidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Referencia"
            DirectCast(dwItemsOp.Columns(oTipoVidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItemsOp.Columns(oTipoVidrio.Index), DataGridViewComboBoxColumn).DataSource = lVidrios

            DirectCast(dwItemsOp.Columns(oColorVidrio.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItemsOp.Columns(oColorVidrio.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItemsOp.Columns(oColorVidrio.Index), DataGridViewComboBoxColumn).DataSource = lAcabados.Where(Function(a) (a.Id = 32 Or a.idFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO) And CInt(a.IdEstado) = ClsEnums.Estados.ACTIVO).ToList


            DirectCast(dwItemsOp.Columns(oAcabadoPerfiles.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItemsOp.Columns(oAcabadoPerfiles.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItemsOp.Columns(oAcabadoPerfiles.Index), DataGridViewComboBoxColumn).DataSource = lAcabados.Where(Function(a) (a.Id = 32 Or a.idFamiliaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA) And CInt(a.IdEstado) = ClsEnums.Estados.ACTIVO).ToList

            DirectCast(dwItemsOp.Columns(oEspesor.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwItemsOp.Columns(oEspesor.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItemsOp.Columns(oEspesor.Index), DataGridViewComboBoxColumn).DataSource = lEspesores
#End Region
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region
#Region "Procedimientos"

    Private Sub cargarEncabezado()
        Try
            _objClienteUnoee = New clsClientesUnoee
            _objUnoee = New clsObrasUnoee
            _objContrato = New clsContratos
            _objUnoeeDetalleObra = New ClsClienteDetalle
            Dim clienteUnoee As New clienteUnoee
            Dim obraUnoee As New obrasUnoee
            Dim contrato As New contrato
            Dim ClienteDetalle As New clienteDetalleUnoee
            Dim terc As New ClsTercerosUnoee
            contrato = _objContrato.traerById(_idcontrato)
            clienteUnoee = _objClienteUnoee.t200_ClientesUnoeeByNit(RTrim(contrato.nit)).First()
            obraUnoee = _objUnoee.traerObraByNitClienteAndSuc(RTrim(contrato.nit), RTrim(contrato.codObra))
            ClienteDetalle = _objUnoeeDetalleObra.TraerDetalleCliente(clienteUnoee.idCliente, contrato.codObra)
            lbObra.Text = contrato.obra
            lbNIt.Text = contrato.nit.Trim
            lbSucursal.Text = contrato.codObra.Trim
            lbcliente.Text = contrato.Cliente
            lbtelefono.Text = ClienteDetalle.Telefono
            lbDireccion.Text = ClienteDetalle.Direccion1
            lbVendedor.Text = obraUnoee.idVendedor
            lbnombrevendedor.Text = "-" & ClienteDetalle.VendedorSiesa
            lbCiudad.Text = ClienteDetalle.Ciudad

            lb_id_cond_pago.Text = terc.TraerInfoTerceroxNit(contrato.nit, contrato.codObra)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CargarMotivos()
        Try
            Dim cmov As New ClsMotivosDevolucionOp
            Dim lmovs As List(Of MotivoDevolucionOp) = cmov.TraerporEstado(ClsEnums.Estados.ACTIVO)
            clbmotivos.Items.AddRange(lmovs.Select(Function(x) x.Id.ToString() & "-" & x.Descripcion).ToArray())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarTerceros()
        Try
            Dim cterc As New ClsTercerosProduccion
            Dim listterc As List(Of TerceroProduccion) = cterc.TraerporEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listterc
            cbproducidopor.DisplayMember = "Descripcion"
            cbproducidopor.ValueMember = "Id"
            cbproducidopor.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarTiemposEntrega()
        Try
            Dim tentrega As New TiempoEntrega.ClsTiempoEntrega
            Dim tiempolis As List(Of TiempoEntrega.tiempoEntrega) = tentrega.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cbtiempoentrega.DisplayMember = "dias"
            cbtiempoentrega.ValueMember = "Id"
            cbtiempoentrega.DataSource = tiempolis.ToList
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarItemsDesdeContrato()
        Try
            _objMovitoItems = New clsMovitoItemsContrato
            cargarMovitoItems(_objMovitoItems.TraerpaOrdenPedByIdContrato(_idcontrato), True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMovitoItems(tb As List(Of ItemContratoOrdenPed), desdecontrato As Boolean)
        Try
            _objMovitoHijo = New ClsMovitoHijos
#Region "Carga Padres"
            tb.ForEach(Sub(item)
                           Dim mtinstala As Decimal = (item.ancho * item.alto) / 1000000
                           If mtinstala < 1 Then
                               mtinstala = 1
                           End If
                           mtinstala *= item.cantidad
                           Dim ndp As DataGridViewTreeNode = dwItems.Nodes.Add()
                           ndp.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
                           ndp.Cells(cId.Index).Value = item.Id
                           ndp.Cells(cIdItemCotiza.Index).Value = item.IdItemCotiza
                           ndp.Cells(cIdCotizacion.Index).Value = item.idCotiza
                           ndp.Cells(cUbicacion.Index).Value = RTrim(item.ubicacion)
                           ndp.Cells(cDescripcion.Index).Value = RTrim(item.descripcion)
                           ndp.Cells(cAncho.Index).Value = Math.Round(CDec(item.ancho), 0)
                           ndp.Cells(cAlto.Index).Value = Math.Round(CDec(item.alto), 0)
                           ndp.Cells(cMetros.Index).Value = ((CDec(item.ancho) * CDec(item.alto)) / 1000000)
                           ndp.Cells(cMetrosInstalacion.Index).Value = 0
                           ndp.Cells(cAcabadoPerfiles.Index).Value = item.idAcabadoPerfil
                           ndp.Cells(cVidrio.Index).Value = item.idVidrio
                           ndp.Cells(cColorVidrio.Index).Value = item.idColorVidrio
                           ndp.Cells(cEspesor.Index).Value = item.idEspesor
                           ndp.Cells(cPiezXUnidad.Index).Value = 1
                           ndp.Cells(cCantidad.Index).Value = item.cantidad
                           ndp.Cells(ccantidad_disp.Index).Value = item.Cantidad_Pendiente
                           ndp.Cells(cTipoitem.Index).Value = "--"
                           ndp.Cells(cpreciounitario.Index).Value = item.precioUnitario
                           ndp.Cells(cprecioinstalacion.Index).Value = item.tarifaMtInstalacion
                           ndp.Cells(cMetrosInstalacion.Index).Value = mtinstala
                           ndp.Cells(ccalculo_NSR.Index).Value = item.calculo_NSR
                           ndp.Cells(vercosto.Index).Value = Convert.ToString(item.versionCostoKiloAluminio) & "." & Convert.ToString(item.versionCostoVidrio)
#End Region
#Region "Carga Hijos"
                           Dim listHijos As List(Of movitoHijoOrdenPed) = _objMovitoHijo.TraerparaOrdenPedidoxIdPadreCotiza(Convert.ToInt32(ndp.Cells(cIdItemCotiza.Index).Value))
                           listHijos.ForEach(Sub(ith)
                                                 Dim mtinstalahijo As Decimal = (ith.ancho * ith.alto) / 1000000
                                                 If mtinstalahijo < 1 Then
                                                     mtinstalahijo = 1
                                                 End If
                                                 mtinstalahijo *= (ith.cantidad * ith.piezasxUnidad)
                                                 Dim ndh As DataGridViewTreeNode = ndp.Nodes.Add
                                                 ndh.Cells(cId.Index).Value = ith.Id
                                                 ndh.Cells(cIdArticulo.Index).Value = ith.idArticulo
                                                 ndh.Cells(cIdItemCotiza.Index).Value = ith.Id
                                                 ndh.Cells(cUbicacion.Index).Value = ndp.Cells(cUbicacion.Index).Value ' RTrim(ith.referencia)
                                                 ndh.Cells(cDescripcion.Index).Value = RTrim(ith.referencia)
                                                 ndh.Cells(cAncho.Index).Value = Math.Round(ith.ancho)
                                                 ndh.Cells(cAlto.Index).Value = Math.Round(ith.alto)
                                                 ndh.Cells(cMetros.Index).Value = ((Math.Round(ith.ancho) * Math.Round(ith.alto, 0)) / 10000000) * ith.piezasxUnidad * ith.cantidad '"Pendiente"
                                                 ndh.Cells(cCantidad.Index).Value = ith.cantidad
                                                 ndh.Cells(ccantidad_disp.Index).Value = ith.Cantidad_Disponible
                                                 ndh.Cells(cPiezXUnidad.Index).Value = ith.piezasxUnidad
                                                 ndh.Cells(cAcabadoPerfiles.Index).Value = ith.idAcabadoPerfil
                                                 ndh.Cells(cVidrio.Index).Value = ith.idVidrio
                                                 ndh.Cells(cColorVidrio.Index).Value = ith.idColorVidrio
                                                 ndh.Cells(cEspesor.Index).Value = ith.idEspesor
                                                 ndh.Cells(cTipoitem.Index).Value = ith.tipoItem
                                                 ndh.Cells(cpreciounitario.Index).Value = ith.precioUnitario
                                                 ndh.Cells(cprecioinstalacion.Index).Value = ith.tarifaMtInstalacion
                                                 ndh.Cells(vercosto.Index).Value = Convert.ToString(ith.verCostoKiloAluminio) & "." & Convert.ToString(ith.verCostoVidrio)
                                                 Select Case DirectCast(ith.tipoItem, ClsEnums.FamiliasMateriales)
                                                     Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                         ndh.Cells(cIdArticulo.Index).Value = ith.idPlantilla
                                                     Case Else
                                                         ndh.Cells(cIdArticulo.Index).Value = ith.idArticulo
                                                 End Select
                                                 ndh.Cells(cMetrosInstalacion.Index).Value = mtinstalahijo
                                                 If ith.tipoItem = ClsEnums.FamiliasMateriales.DISEÑOS Then
                                                     ndh.Cells(cIdArticulo.Index).Value = ith.idPlantilla
                                                 Else
                                                     ndh.Cells(cIdArticulo.Index).Value = ith.idArticulo
                                                 End If
                                                 ndh.Cells(ccalculo_NSR.Index).Value = ith.calculo_NSR
                                             End Sub)
                       End Sub)
#End Region
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVariables(n As DataGridViewTreeNode)
        Try
            dwVariables.Rows.Clear()
            Dim lvars As List(Of VariableItemCotiza) = New List(Of VariableItemCotiza)
            If Convert.ToInt32(n.Cells(oId.Index).Value) > 0 Then
                Dim mvarhijocotiza As New ClsVariablesPlantillaOped
                lvars = mvarhijocotiza.TraerxIdItemOp(Convert.ToInt32(n.Cells(oId.Index).Value))
            Else
                Dim mvarhijocotiza As New ClsVariablesPlantillaCotiza
                lvars = mvarhijocotiza.TraerxIdItemCotiza(Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value))
            End If
            Dim an As AnalizadorLexico = DirectCast(n.Cells(oEspecial.Index).Value, AnalizadorLexico)
            an.ListaVariables.ToList().ForEach(Sub(v)
                                                   Dim vr = lvars.FirstOrDefault(Function(x) x.IdVariable = v.Id)
                                                   Dim r As DataGridViewRow = dwVariables.Rows(dwVariables.Rows.Add())
                                                   r.Cells(id.Index).Value = v.Id
                                                   r.Cells(variable.Index).Value = v.Nombre
                                                   r.Cells(valorminimo.Index).Value = vr.ValorMinimo
                                                   r.Cells(valormaximo.Index).Value = vr.ValorMaximo
                                                   If v.PosiblesValores.Count > 0 Then
                                                       r.Cells(valor.Index) = New DataGridViewComboBoxCell()
                                                       DirectCast(r.Cells(valor.Index), DataGridViewComboBoxCell).Items.AddRange(v.PosiblesValores.ToArray())
                                                       If v.PosiblesValores.Contains(v.Valor) Then
                                                           r.Cells(valor.Index).Value = v.Valor
                                                       End If
                                                   Else
                                                       r.Cells(valor.Index).Value = v.Valor
                                                   End If
                                                   r.Cells(tipodato.Index).Value = v.TipoValor
                                                   r.Cells(permitiredicion.Index).Value = vr.EdicionProduccion
                                               End Sub)

            'Dim lvars As List(Of VariableItemCotiza) = New List(Of VariableItemCotiza)
            'If Convert.ToInt32(n.Cells(oId.Index).Value) > 0 Then
            '    Dim mvarhijocotiza As New ClsVariablesPlantillaOped
            '    lvars = mvarhijocotiza.TraerxIdItemOp(Convert.ToInt32(n.Cells(oId.Index).Value))
            'Else
            '    Dim mvarhijocotiza As New ClsVariablesPlantillaCotiza
            '    lvars = mvarhijocotiza.TraerxIdItemCotiza(Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value))
            'End If
            'Dim valvar As New ClsValoresVariables
            'lvars.ForEach(Sub(v)
            '                  Dim r As DataGridViewRow = dwVariables.Rows(dwVariables.Rows.Add())
            '                  r.Cells(id.Index).Value = v.IdVariable
            '                  r.Cells(variable.Index).Value = v.NombreVariable
            '                  r.Cells(valorminimo.Index).Value = v.ValorMinimo
            '                  r.Cells(valormaximo.Index).Value = v.ValorMaximo
            '                  If v.DesdeBaseDatos Then
            '                      Dim lvar() As String = valvar.TraerxIdVariable(v.IdVariable).Select(Function(x) x.Valor).ToArray()
            '                      r.Cells(valor.Index) = New DataGridViewComboBoxCell()
            '                      DirectCast(r.Cells(valor.Index), DataGridViewComboBoxCell).Items.AddRange(lvar)
            '                      If lvar.Contains(v.Valor) Then
            '                          r.Cells(valor.Index).Value = v.Valor
            '                      End If
            '                  Else
            '                      r.Cells(valor.Index).Value = v.Valor
            '                  End If
            '                  r.Cells(tipodato.Index).Value = v.TipoDato
            '                  r.Cells(permitiredicion.Index).Value = v.EdicionProduccion
            '              End Sub
            ')
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub addItemsParaProducir()
        Try
            dwItems.EndEdit()
            dwItems.Nodes.ToList.ForEach(Sub(nodo)
                                             If CBool(nodo.Cells(cSeleccion.Index).Value) = True Then
                                                 Dim nn As DataGridViewTreeNode = dwItemsOp.Nodes.Add()
                                                 nn.Expand()
                                                 nn.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
                                                 nn.Cells(AnchoRequerido.Index).Value = nodo.Cells(cAncho.Index).Value
                                                 nn.Cells(anchofabricacion.Index).Value = nodo.Cells(cAncho.Index).Value
                                                 nn.Cells(AltoRequerido.Index).Value = nodo.Cells(cAlto.Index).Value
                                                 nn.Cells(altofabricacion.Index).Value = nodo.Cells(cAlto.Index).Value
                                                 nn.Cells(PiezasXUnidadReq.Index).Value = nodo.Cells(cPiezXUnidad.Index).Value
                                                 nn.Cells(oId.Index).Value = 0
                                                 nn.Cells(oIdItemContrato.Index).Value = nodo.Cells(cId.Index).Value
                                                 nn.Cells(oIdCotiza.Index).Value = nodo.Cells(cIdCotizacion.Index).Value
                                                 nn.Cells(oIdItemCotiza.Index).Value = nodo.Cells(cIdItemCotiza.Index).Value
                                                 nn.Cells(oUbicacion.Index).Value = nodo.Cells(cUbicacion.Index).Value
                                                 nn.Cells(oDescripcion.Index).Value = nodo.Cells(cDescripcion.Index).Value
                                                 nn.Cells(oAncho.Index).Value = nodo.Cells(cAncho.Index).Value
                                                 nn.Cells(oAlto.Index).Value = nodo.Cells(cAlto.Index).Value
                                                 nn.Cells(oCantidad.Index).Value = nodo.Cells(cCantidad.Index).Value
                                                 nn.Cells(CantidadRequerida.Index).Value = nodo.Cells(ccantidad_disp.Index).Value
                                                 nn.Cells(oPiezasxUnidad.Index).Value = nodo.Cells(cPiezXUnidad.Index).Value
                                                 nn.Cells(oTipoVidrio.Index).Value = CInt(nodo.Cells(cVidrio.Index).Value)
                                                 nn.Cells(oEspesor.Index).Value = CInt(nodo.Cells(cEspesor.Index).Value)
                                                 nn.Cells(oColorVidrio.Index).Value = CInt(nodo.Cells(cColorVidrio.Index).Value)
                                                 nn.Cells(oAcabadoPerfiles.Index).Value = nodo.Cells(cAcabadoPerfiles.Index).Value
                                                 nn.Cells(oMetros.Index).Value = nodo.Cells(cMetros.Index).Value
                                                 nn.Cells(oMtInstalacion.Index).Value = nodo.Cells(cMetrosInstalacion.Index).Value
                                                 nn.Cells(opreciounitario.Index).Value = nodo.Cells(cpreciounitario.Index).Value
                                                 nn.Cells(oprecioinstalacion.Index).Value = nodo.Cells(cprecioinstalacion.Index).Value
                                                 nn.Cells(ocalculo_NSR.Index).Value = nodo.Cells(ccalculo_NSR.Index).Value
                                                 nn.Cells(opuntos.Index).Value = 0
                                                 nn.Cells(ubicacionEstructura.Index).Value = "--"
                                                 nn.Cells(versioncosto.Index).Value = nodo.Cells(vercosto.Index).Value
                                                 nodo.Nodes.ToList.ForEach(Sub(nh)
                                                                               Dim id_cotizacion As Integer = nn.Cells(oIdCotiza.Index).Value
                                                                               Dim nd As DataGridViewTreeNode = nn.Nodes.Add()
                                                                               nd.Cells(automatico.Index).Value = True
                                                                               nd.Cells(AnchoRequerido.Index).Value = nh.Cells(cAncho.Index).Value
                                                                               nd.Cells(anchofabricacion.Index).Value = nh.Cells(cAncho.Index).Value
                                                                               nd.Cells(AltoRequerido.Index).Value = nh.Cells(cAlto.Index).Value
                                                                               nd.Cells(altofabricacion.Index).Value = nh.Cells(cAlto.Index).Value
                                                                               nd.Cells(CantidadRequerida.Index).Value = nh.Cells(ccantidad_disp.Index).Value
                                                                               nd.Cells(PiezasXUnidadReq.Index).Value = nh.Cells(cPiezXUnidad.Index).Value
                                                                               nd.Cells(oId.Index).Value = 0
                                                                               nd.Cells(oIdItemContrato.Index).Value = nh.Cells(cId.Index).Value
                                                                               nd.Cells(oIdCotiza.Index).Value = nh.Cells(cIdCotizacion.Index).Value
                                                                               nd.Cells(oIdItemCotiza.Index).Value = nh.Cells(cIdItemCotiza.Index).Value
                                                                               nd.Cells(oIdArticulo.Index).Value = nh.Cells(cIdArticulo.Index).Value
                                                                               nd.Cells(oTipoItem.Index).Value = nh.Cells(cTipoitem.Index).Value
                                                                               nd.Cells(oUbicacion.Index).Value = nh.Cells(cUbicacion.Index).Value
                                                                               nd.Cells(oDescripcion.Index).Value = nh.Cells(cDescripcion.Index).Value
                                                                               nd.Cells(oAncho.Index).Value = nh.Cells(cAncho.Index).Value
                                                                               nd.Cells(oAlto.Index).Value = nh.Cells(cAlto.Index).Value
                                                                               nd.Cells(oCantidad.Index).Value = nh.Cells(cCantidad.Index).Value
                                                                               nd.Cells(ocantidad_disp.Index).Value = nh.Cells(ccantidad_disp.Index).Value
                                                                               nd.Cells(oPiezasxUnidad.Index).Value = nh.Cells(cPiezXUnidad.Index).Value
                                                                               nd.Cells(oTipoVidrio.Index).Value = nh.Cells(cVidrio.Index).Value
                                                                               nd.Cells(oEspesor.Index).Value = nh.Cells(cEspesor.Index).Value
                                                                               nd.Cells(oColorVidrio.Index).Value = nh.Cells(cColorVidrio.Index).Value
                                                                               nd.Cells(oAcabadoPerfiles.Index).Value = nh.Cells(cAcabadoPerfiles.Index).Value
                                                                               nd.Cells(oMetros.Index).Value = nh.Cells(cMetros.Index).Value
                                                                               nd.Cells(ubicacionEstructura.Index).Value = "--"
                                                                               nd.Cells(ubicacionEstructura.Index).ReadOnly = True
#Region "Carga Plantilla"
                                                                               Dim cot As New cotizaciones.ClsCostizaciones
                                                                               Dim coti As cotizaciones.cotizacion = cot.TraerxId(id_cotizacion)
                                                                               Dim an As AnalizadorLexico = Nothing
                                                                               carga_plantillas.CargarPlantilla(Convert.ToInt32(nh.Cells(cIdItemCotiza.Index).Value), an, ClsEnums.TipoCarga.COTIZA)
                                                                               carga_plantillas.ValorarAnalizador(an, id_cotizacion, coti.versionCostoAcabado,
                                                                                coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                                                                coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                                                               nd.Cells(oEspecial.Index).Value = an
#End Region
                                                                               nd.Cells(oMtInstalacion.Index).Value = 0
                                                                               nd.Cells(opreciounitario.Index).Value = nh.Cells(cpreciounitario.Index).Value
                                                                               nd.Cells(oprecioinstalacion.Index).Value = nh.Cells(cprecioinstalacion.Index).Value
                                                                               nd.Cells(opuntos.Index).Value = 0
                                                                               nd.Cells(ocalculo_NSR.Index).Value = CBool(nh.Cells(ccalculo_NSR.Index).Value)
                                                                               nd.Cells(versioncosto.Index).Value = nh.Cells(vercosto.Index).Value
                                                                               If nd.Cells(oEspecial.Index).Value IsNot Nothing Then
                                                                                   Dim a As AnalizadorLexico = DirectCast(nd.Cells(oEspecial.Index).Value, AnalizadorLexico)
                                                                                   If a.ListaVariables.Contains("CANTIDAD") Then
                                                                                       a.ListaVariables.Item("CANTIDAD").Valor = nd.Cells(CantidadRequerida.Index).Value
                                                                                       carga_plantillas.ValorarAnalizador(a, id_cotizacion, coti.versionCostoAcabado,
                                                                                       coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                                                                       coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                                                                   End If
                                                                                   If a.ListaVariables.Contains("PUNTOS") Then
                                                                                       nd.Cells(opuntos.Index).Value = Convert.ToDecimal(a.ListaVariables.Item("PUNTOS").Valor)
                                                                                   End If
                                                                               End If
                                                                           End Sub)
                                                 If nodo.Cells(cEspecial.Index).Value Is Nothing Then
#Region "Carga Dibujos"
                                                     Dim cd As New CargaDibujos
                                                     Dim ldatos As List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)) =
                                                     nodo.Nodes.Select(Function(h) New Tuple(Of Integer,
                                                     AnalizadorLexico,
                                                     Integer,
                                                     Decimal,
                                                     Decimal)(h.Cells(cIdItemCotiza.Index).Value,
                                                              h.Cells(cEspecial.Index).Value, h.Index,
                                                              h.Cells(cAncho.Index).Value,
                                                              h.Cells(cAlto.Index).Value)).ToList()
                                                     Dim rg As ControlesPersonalizados.Estructurador.RegionEstructuras =
                                                     cd.CrearDibujos(nodo.Cells(cIdItemCotiza.Index).Value,
                                                                     ldatos, False, ClsEnums.TipoCarga.COTIZA).Duplicate(True)
                                                     nodo.Cells(cEspecial.Index).Value = rg
                                                     If rg IsNot Nothing Then
                                                         nn.Cells(oEspecial.Index).Value = rg.Duplicate(False)
                                                     Else
                                                         nn.Cells(oEspecial.Index).Value = New ControlesPersonalizados.Estructurador.RegionEstructuras(0, 0, 1, 1)
                                                     End If
#End Region
                                                 Else
                                                     nn.Cells(oEspecial.Index).Value = DirectCast(nodo.Cells(cEspecial.Index).Value,
                                                     ControlesPersonalizados.Estructurador.RegionEstructuras).Duplicate(False)
                                                 End If
                                                 nodo.Cells(cSeleccion.Index).Value = False
                                             End If
                                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub EliminarItem()
        Try
            Dim r As DataGridViewRow = dwItemsOp.SelectedRows(0)
            If MsgBox("Esta seguro que desea eliminar el ítem?", vbYesNo) = MsgBoxResult.Yes Then
                If Convert.ToInt32(r.Cells(oId.Index).Value) > 0 Then
                    variables_plantilla.EliminarxIdItemOp(CInt(r.Cells(oId.Index).Value))
                    descuento_global.EliminarxIdItemOp(CInt(r.Cells(oId.Index).Value))
                    dibujos_plantilla.EliminarxIdItemOp(CInt(r.Cells(oId.Index).Value))
                    observaciones_plantilla.EliminarxIdItemOp(CInt(r.Cells(oId.Index).Value))
                    descuento_material_plantilla.EliminarxIdItemOp(CInt(r.Cells(oId.Index).Value))
                    materiales_plantilla.EliminarxIdItemOp(CInt(r.Cells(oId.Index).Value))
                End If
                dwItemsOp.Nodes.Remove(r)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub GuardarDibujos(est As ControlesPersonalizados.Estructurador.RegionEstructuras, iditem As Integer, idcontenedor As Integer, nivel As Integer)
        Try
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
                idcont = dibitemsop.Ingresar(iditem, 0, My.Settings.UsuarioActivo, mdxf,
                          est.X, est.Y, est.Ancho, est.Alto, est.OrientacionEstructura, nivel, idcontenedor)
            Else
                If est.Id_Hijo_Owner > 0 Then
                    idcont = dibitemsop.Ingresar(iditem, est.Id_Hijo_Owner, My.Settings.UsuarioActivo, mdxf,
                          est.X, est.Y, est.Ancho, est.Alto, est.OrientacionEstructura, nivel, idcontenedor)
                Else
                    Dim idh As Integer = Convert.ToInt32(dwItemsOp.Nodes.First(Function(n) Convert.ToInt32(n.Cells(oId.Index).Value) = iditem).Nodes(est.Index_Hijo_Owner).Cells(oId.Index).Value)
                    idcont = dibitemsop.Ingresar(iditem, idh, My.Settings.UsuarioActivo, mdxf,
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
    Public Function ObtenerImagen(r As DataGridViewRow)
        Try
            Dim est As ControlesPersonalizados.Estructurador.RegionEstructuras = DirectCast(r.Cells(oEspecial.Index).Value,
                ControlesPersonalizados.Estructurador.RegionEstructuras)
            If est.RegionControlContenedor.Width = 0 Or est.RegionControlContenedor.Height = 0 Then
                est.RegionControlContenedor = New RectangleF(0, 0, egmodelo.Width, egmodelo.Height)
            End If
            Dim bmp As New Bitmap(egmodelo.Width, egmodelo.Height)
            Dim g As Graphics = Graphics.FromImage(bmp)
            egmodelo.DibujarTodos(est, g)
            Return bmp
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub GuardarElementosPlantilla(an As AnalizadorLexico, id_hijo_op As Integer, id_item_cotiza As Integer)
        Try
            variables_plantilla.EliminarxIdItemOp(id_hijo_op)
            descuento_global.EliminarxIdItemOp(id_hijo_op)
            dibujos_plantilla.EliminarxIdItemOp(id_hijo_op)
            observaciones_plantilla.EliminarxIdItemOp(id_hijo_op)
            descuento_material_plantilla.EliminarxIdItemOp(id_hijo_op)
            materiales_plantilla.EliminarxIdItemOp(id_hijo_op)
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
                                        variables_plantilla.Insertar(id_hijo_op, var.Id,
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
                                                            id_mat = materiales_plantilla.Insertar(id_hijo_op,
                                                         m.Id, My.Settings.UsuarioActivo, TiposElementos.Vidrios,
                                                         Convert.ToInt32(m.Parametros.Item("IDORIENTACIONPOSICION").Valor),
                                                        m.Parametros.Item("ESPESOR").Formula, m.Parametros.Item("ESPESOR").Valor,
                                                        If(m.Parametros.Item("ARTICULO").Formula.StartsWith("="), m.Parametros.Item("ARTICULO").Formula, m.Parametros.Item("ARTICULO").Valor),
                                                        m.Parametros.Item("REFERENCIA").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDUBICACIONMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDMATERIALPARA").Valor),
                                                        m.Parametros.Item("COLOR").Formula, m.Parametros.Item("COLOR").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOMATERIAL").Valor), Convert.ToInt32(m.Parametros.Item("IDTIPOCORTES").Valor),
                                                        m.Parametros.Item("CANTIDAD").Formula, m.Parametros.Item("CANTIDAD").Valor,
                                                        m.Parametros.Item("PXUNIDAD").Formula, m.Parametros.Item("PXUNIDAD").Valor,
                                                        m.Parametros.Item("ANCHO").Formula, m.Parametros.Item("ANCHO").Valor,
                                                        m.Parametros.Item("ALTO").Formula, m.Parametros.Item("ALTO").Valor,
                                                        m.Parametros.Item("PESO").Formula, If(String.IsNullOrEmpty(m.Parametros.Item("PESO").Valor.Replace("'", "")), 0, m.Parametros.Item("PESO").Valor),
                                                        m.Parametros.Item("DESCUENTO").Formula, m.Parametros.Item("DESCUENTO").Valor,
                                                        m.Parametros.Item("DETALLE").Formula, m.Parametros.Item("DETALLE").Valor, 1,
                                                        m.Parametros.Item("VISIBILIDAD").Formula, CInt(m.Parametros.Item("VISIBILIDAD").Valor), m.Utilizar, m.Desperdicio, m.Costo_Instalacion_Unidad, m.Indice)
                                                        Case TiposElementos.Perfiles, TiposElementos.Accesorios, TiposElementos.Otros
                                                            id_mat = materiales_plantilla.Insertar(id_hijo_op,
                                                         m.Id, My.Settings.UsuarioActivo, m.TipoObjeto,
                                                         Convert.ToInt32(m.Parametros.Item("IDORIENTACIONPOSICION").Valor), "", 1,
                                                        If(m.Parametros.Item("ARTICULO").Formula.StartsWith("="), m.Parametros.Item("ARTICULO").Formula, m.Parametros.Item("ARTICULO").Valor),
                                                        m.Parametros.Item("REFERENCIA").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDUBICACIONMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDMATERIALPARA").Valor),
                                                        m.Parametros.Item("ACABADO").Formula, m.Parametros.Item("ACABADO").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOCORTES").Valor),
                                                        m.Parametros.Item("CANTIDAD").Formula, m.Parametros.Item("CANTIDAD").Valor,
                                                        m.Parametros.Item("PXUNIDAD").Formula, m.Parametros.Item("PXUNIDAD").Valor,
                                                        m.Parametros.Item("DIMENSION").Formula, m.Parametros.Item("DIMENSION").Valor, "", 0,
                                                        m.Parametros.Item("PESO").Formula, m.Parametros.Item("PESO").Valor,
                                                        m.Parametros.Item("DESCUENTO").Formula, m.Parametros.Item("DESCUENTO").Valor,
                                                        m.Parametros.Item("DETALLE").Formula, m.Parametros.Item("DETALLE").Valor, 1,
                                                        m.Parametros.Item("VISIBILIDAD").Formula, m.Parametros.Item("VISIBILIDAD").Valor,
                                                        m.Utilizar, m.Desperdicio, m.Costo_Instalacion_Unidad, m.Indice)
                                                    End Select
                                                    m.Descuentos.ToList().ForEach(Sub(d)
                                                                                      If d.Nombre <> "DESCUENTO" Then
                                                                                          descuento_material_plantilla.Insertar(id_mat, d.IdDescuento, d.Formula,
                                                                                                                                  d.Valor, My.Settings.UsuarioActivo)
                                                                                      End If
                                                                                  End Sub)
                                                End Sub
                )
#End Region
            dibujos_plantilla.Insertar(id_hijo_op, id_item_cotiza, My.Settings.UsuarioActivo)
            observaciones_plantilla.Insertar(id_hijo_op, id_item_cotiza, My.Settings.UsuarioActivo)
            an.ListaDescuentos.ToList().ForEach(Sub(a)
                                                    descuento_global.Insertar(id_hijo_op,
                                                    a.IdDescuento, a.Formula, a.Valor,
                                                    My.Settings.UsuarioActivo)
                                                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Guardar(total As Boolean)
        Try
            If dwItemsOp.Rows.Count = 0 Then
                MsgBox("El pedido debe tener por lo menos un item para que pueda ser generado", MsgBoxStyle.Information, "Información.")
                Exit Sub
            End If
            Dim motivos As Integer() = clbmotivos.CheckedItems.Cast(Of String).Select(Function(x) Convert.ToInt32(x.Split("-")(0))).ToArray()
            Dim contratos As New clsContratos
            Dim contrato As contrato = contratos.traerById(_idcontrato)
            Dim clienteUnoee As clienteUnoee = _objClienteUnoee.t200_ClientesUnoeeByNit(RTrim(contrato.nit)).First()
            Dim obraUnoee As obrasUnoee = _objUnoee.traerObraByNitClienteAndSuc(RTrim(contrato.nit), RTrim(contrato.codObra))
            Dim ClienteDetalle As clienteDetalleUnoee = _objUnoeeDetalleObra.TraerDetalleCliente(clienteUnoee.idCliente, contrato.codObra)
            Dim puntos_odp As Decimal = dwItemsOp.Nodes.Sum(Function(x) Convert.ToDecimal(x.Cells(opuntos.Index).Value))
            Dim metros_odp As Decimal = dwItemsOp.Nodes.Sum(Function(x) Convert.ToDecimal(x.Cells(oMetros.Index).Value))
            Dim dias_entrega_op As Integer = DirectCast(cbtiempoentrega.SelectedItem, TiempoEntrega.tiempoEntrega).dias 'frmgen.DiasEntrega
            Dim fecha_entrega_op As DateTime = dtptomamedidas.Value.AddDays(dias_entrega_op)
#Region "Semanas"
            If cbcalculodias.Checked Then 'CALCULO DE DIAS HABILES
                Dim dias_no_habiles As Integer = 0
                For i As Integer = 1 To dias_entrega_op
                    Select Case Weekday(fecha_entrega_op.AddDays(i), FirstDayOfWeek.Sunday)
                        Case 1, 7
                            dias_no_habiles += 1
                    End Select
                Next
                fecha_entrega_op = fecha_entrega_op.AddDays(dias_entrega_op + dias_no_habiles)
            Else
                fecha_entrega_op = fecha_entrega_op.AddDays(dias_entrega_op)
            End If
            Dim semana_entrega_prod As Integer = Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fecha_entrega_op,
                                                                                                                              Globalization.CalendarWeekRule.FirstDay, fecha_entrega_op.DayOfWeek)
#End Region
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                curid = encabezadoorden.Insertar(_idcontrato, Convert.ToString(cmbdocumentos.SelectedValue), contrato.nit, contrato.Cliente, clienteUnoee.telefono,
                                         clienteUnoee.direccion, clienteUnoee.Correo, clienteUnoee.nombreContacto, contrato.codObra,
                                         contrato.obra, obraUnoee.nomContacto, obraUnoee.telefono, obraUnoee.direccion, ClienteDetalle.Ciudad,
                                         obraUnoee.correo, dtprecibido.Value, Convert.ToInt32(cbtiempoentrega.SelectedValue), fecha_entrega_op, dtptomamedidas.Value,
                                        semana_entrega_prod, puntos_odp, obraUnoee.idVendedor, contratos.RegionObraContrato(contrato.nit, contrato.codObra), metros_odp,
                                        txtdestino.Text, Convert.ToInt32(cbproducidopor.SelectedValue), nuddevoluciones.Value,
                                         My.Settings.UsuarioActivo, If(total, ClsEnums.Estados.ACTIVO, ClsEnums.Estados.PARCIAL), cbcalculodias.Checked, True)
            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                encabezadoorden.Modificar(_idcontrato, Convert.ToString(cmbdocumentos.SelectedValue), contrato.nit, contrato.Cliente, clienteUnoee.telefono,
                                         clienteUnoee.direccion, clienteUnoee.Correo, clienteUnoee.nombreContacto, contrato.codObra,
                                         contrato.obra, obraUnoee.nomContacto, obraUnoee.telefono, obraUnoee.direccion, ClienteDetalle.Ciudad,
                                         obraUnoee.correo, dtprecibido.Value, Convert.ToInt32(cbtiempoentrega.SelectedValue), fecha_entrega_op, dtptomamedidas.Value,
                                        semana_entrega_prod, puntos_odp, obraUnoee.idVendedor, contratos.RegionObraContrato(contrato.nit, contrato.codObra), metros_odp,
                                        txtdestino.Text, Convert.ToInt32(cbproducidopor.SelectedValue), nuddevoluciones.Value,
                                         My.Settings.UsuarioActivo, If(total, ClsEnums.Estados.ACTIVO, ClsEnums.Estados.PARCIAL), curid, cbcalculodias.Checked, True)
            End If
            tform = ClsEnums.TiOperacion.MODIFICAR
#Region "Motivos"


            motivodevol.EliminarporIdOp(curid)
            For i As Integer = 0 To motivos.Length - 1
                motivodevol.Insertar(curid, motivos(i), My.Settings.UsuarioActivo)
            Next
#End Region
            Dim uimg As New ClsUtilidadesImagenes
            For Each nd As DatagridTreeView.DataGridViewTreeNode In dwItemsOp.Nodes
                Dim mrequeridos As Decimal = ((Convert.ToDecimal(nd.Cells(AnchoRequerido.Index).Value) * Convert.ToDecimal(nd.Cells(AltoRequerido.Index).Value)) / 10000000) *
                        Convert.ToDecimal(nd.Cells(CantidadRequerida.Index).Value)
                If Convert.ToInt32(nd.Cells(oId.Index).Value) = 0 Then
                    nd.Cells(oId.Index).Value = itemsop.Insertar(curid, Convert.ToInt32(nd.Cells(oIdItemContrato.Index).Value),
                                     Convert.ToString(nd.Cells(Observaciones.Index).Value), DirectCast(nd.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(AnchoRequerido.Index).Value), DirectCast(nd.Cells(anchofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(anchofabricacion.Index).Value),
                                     DirectCast(nd.Cells(AltoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(AltoRequerido.Index).Value), DirectCast(nd.Cells(altofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(altofabricacion.Index).Value), DirectCast(nd.Cells(CantidadRequerida.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(CantidadRequerida.Index).Value), DirectCast(nd.Cells(PiezasXUnidadReq.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(PiezasXUnidadReq.Index).Value), mrequeridos, Convert.ToInt32(nd.Cells(oTipoVidrio.Index).Value),
                                     Convert.ToInt32(nd.Cells(oColorVidrio.Index).Value), Convert.ToInt32(nd.Cells(oEspesor.Index).Value), Convert.ToInt32(nd.Cells(oAcabadoPerfiles.Index).Value),
                                     Convert.ToDecimal(nd.Cells(oAncho.Index).Value), Convert.ToDecimal(nd.Cells(oAlto.Index).Value), Convert.ToDecimal(nd.Cells(oCantidad.Index).Value),
                                     Convert.ToDecimal(nd.Cells(oPiezasxUnidad.Index).Value), Convert.ToDecimal(nd.Cells(oMetros.Index).Value), Convert.ToBoolean(nd.Cells(automatico.Index).Value),
                                     Convert.ToDecimal(nd.Cells(opuntos.Index).Value), Convert.ToDecimal(nd.Cells(opreciounitario.Index).Value), Convert.ToDecimal(nd.Cells(oprecioinstalacion.Index).Value),
                                     Convert.ToDecimal(nd.Cells(oMtInstalacion.Index).Value), My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO,
                                                                     uimg.ImagenaArregloBytes(ObtenerImagen(nd)), nd.Cells(ocalculo_NSR.Index).Value, nd.Cells(ubicacionEstructura.Index).Value)

                Else
                    itemsop.Modificar(curid, Convert.ToInt32(nd.Cells(oIdItemContrato.Index).Value),
                                     Convert.ToString(nd.Cells(Observaciones.Index).Value), DirectCast(nd.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(AnchoRequerido.Index).Value), DirectCast(nd.Cells(anchofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(anchofabricacion.Index).Value),
                                     DirectCast(nd.Cells(AltoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(AltoRequerido.Index).Value), DirectCast(nd.Cells(altofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(altofabricacion.Index).Value), DirectCast(nd.Cells(CantidadRequerida.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(CantidadRequerida.Index).Value), DirectCast(nd.Cells(PiezasXUnidadReq.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                                     Convert.ToDecimal(nd.Cells(PiezasXUnidadReq.Index).Value), mrequeridos, Convert.ToInt32(nd.Cells(oTipoVidrio.Index).Value),
                                     Convert.ToInt32(nd.Cells(oColorVidrio.Index).Value), Convert.ToInt32(nd.Cells(oEspesor.Index).Value), Convert.ToInt32(nd.Cells(oAcabadoPerfiles.Index).Value),
                                     Convert.ToDecimal(nd.Cells(oAncho.Index).Value), Convert.ToDecimal(nd.Cells(oAlto.Index).Value), Convert.ToDecimal(nd.Cells(oCantidad.Index).Value),
                                     Convert.ToDecimal(nd.Cells(oPiezasxUnidad.Index).Value), Convert.ToDecimal(nd.Cells(oMetros.Index).Value), Convert.ToBoolean(nd.Cells(automatico.Index).Value),
                                     Convert.ToDecimal(nd.Cells(opuntos.Index).Value), Convert.ToDecimal(nd.Cells(opreciounitario.Index).Value), Convert.ToDecimal(nd.Cells(oprecioinstalacion.Index).Value),
                                     Convert.ToDecimal(nd.Cells(oMtInstalacion.Index).Value), My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO,
                                        uimg.ImagenaArregloBytes(ObtenerImagen(nd)), nd.Cells(ocalculo_NSR.Index).Value, nd.Cells(ubicacionEstructura.Index).Value,
                                        Convert.ToInt32(nd.Cells(oId.Index).Value))
                End If
                For Each n As DatagridTreeView.DataGridViewTreeNode In nd.Nodes
                    Dim mhrequeridos As Decimal = ((Convert.ToDecimal(n.Cells(AnchoRequerido.Index).Value) * Convert.ToDecimal(n.Cells(AltoRequerido.Index).Value)) / 10000000) *
                        Convert.ToDecimal(n.Cells(CantidadRequerida.Index).Value)
                    If Convert.ToInt32(n.Cells(oId.Index).Value) = 0 Then
                        n.Cells(oId.Index).Value = itemshijos.Insertar(Convert.ToInt32(nd.Cells(oId.Index).Value), Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value),
                            DirectCast(n.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(AnchoRequerido.Index).Value),
                            DirectCast(n.Cells(anchofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(anchofabricacion.Index).Value),
                            DirectCast(n.Cells(AltoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(AltoRequerido.Index).Value),
                            DirectCast(n.Cells(altofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(altofabricacion.Index).Value),
                            DirectCast(n.Cells(CantidadRequerida.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                            Convert.ToDecimal(n.Cells(CantidadRequerida.Index).Value), DirectCast(n.Cells(PiezasXUnidadReq.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                            Convert.ToDecimal(n.Cells(PiezasXUnidadReq.Index).Value), mhrequeridos, Convert.ToInt32(n.Cells(oTipoVidrio.Index).Value),
                            Convert.ToInt32(n.Cells(oColorVidrio.Index).Value), Convert.ToInt32(n.Cells(oEspesor.Index).Value), Convert.ToInt32(n.Cells(oAcabadoPerfiles.Index).Value),
                            Convert.ToDecimal(n.Cells(oAncho.Index).Value), Convert.ToDecimal(n.Cells(oAlto.Index).Value), Convert.ToDecimal(n.Cells(oCantidad.Index).Value),
                            Convert.ToDecimal(n.Cells(oPiezasxUnidad.Index).Value), Convert.ToDecimal(n.Cells(oMetros.Index).Value), Convert.ToBoolean(n.Cells(automatico.Index).Value),
                            Convert.ToDecimal(n.Cells(opreciounitario.Index).Value), Convert.ToDecimal(n.Cells(oprecioinstalacion.Index).Value),
                            Convert.ToDecimal(n.Cells(oMtInstalacion.Index).Value), Convert.ToDecimal(n.Cells(opuntos.Index).Value),
                            Convert.ToString(n.Cells(Observaciones.Index).Value), My.Settings.UsuarioActivo, CInt(n.Cells(oIdArticulo.Index).Value),
                            CBool(n.Cells(ocalculo_NSR.Index).Value), CInt(n.Cells(oTipoItem.Index).Value), ClsEnums.Estados.ACTIVO, n.Cells(oUbicacion.Index).Value, n.Cells(oDescripcion.Index).Value)
                    Else
                        itemshijos.Modificar(Convert.ToInt32(nd.Cells(oId.Index).Value), Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value),
                            DirectCast(n.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(AnchoRequerido.Index).Value),
                            DirectCast(n.Cells(anchofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(anchofabricacion.Index).Value),
                            DirectCast(n.Cells(AltoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(AltoRequerido.Index).Value),
                            DirectCast(n.Cells(altofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(n.Cells(altofabricacion.Index).Value),
                            DirectCast(n.Cells(CantidadRequerida.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                            Convert.ToDecimal(n.Cells(CantidadRequerida.Index).Value), DirectCast(n.Cells(PiezasXUnidadReq.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula,
                            Convert.ToDecimal(n.Cells(PiezasXUnidadReq.Index).Value), mhrequeridos, Convert.ToInt32(n.Cells(oTipoVidrio.Index).Value),
                            Convert.ToInt32(n.Cells(oColorVidrio.Index).Value), Convert.ToInt32(n.Cells(oEspesor.Index).Value), Convert.ToInt32(n.Cells(oAcabadoPerfiles.Index).Value),
                            Convert.ToDecimal(n.Cells(oAncho.Index).Value), Convert.ToDecimal(n.Cells(oAlto.Index).Value), Convert.ToDecimal(n.Cells(oCantidad.Index).Value),
                            Convert.ToDecimal(n.Cells(oPiezasxUnidad.Index).Value), Convert.ToDecimal(n.Cells(oMetros.Index).Value), Convert.ToBoolean(n.Cells(automatico.Index).Value),
                            Convert.ToDecimal(n.Cells(opreciounitario.Index).Value), Convert.ToDecimal(n.Cells(oprecioinstalacion.Index).Value),
                            Convert.ToDecimal(n.Cells(oMtInstalacion.Index).Value), Convert.ToDecimal(n.Cells(opuntos.Index).Value),
                            Convert.ToString(n.Cells(Observaciones.Index).Value), My.Settings.UsuarioActivo, CInt(n.Cells(oIdArticulo.Index).Value), CBool(n.Cells(ocalculo_NSR.Index).Value),
                            CInt(n.Cells(oTipoItem.Index).Value), ClsEnums.Estados.ACTIVO, n.Cells(oUbicacion.Index).Value, n.Cells(oDescripcion.Index).Value,
                            Convert.ToInt32(n.Cells(oId.Index).Value))
                    End If
                    If Convert.ToInt32(n.Cells(oTipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                        GuardarElementosPlantilla(DirectCast(n.Cells(oEspecial.Index).Value, AnalizadorLexico),
                                              Convert.ToInt32(n.Cells(oId.Index).Value),
                                              Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value))
                    End If
                Next
                If nd.Cells(oEspecial.Index).Value IsNot Nothing Then
                    Dim est As ControlesPersonalizados.Estructurador.RegionEstructuras = DirectCast(nd.Cells(oEspecial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras)
                    dibitemsop.BorrarxIdItemOp(Convert.ToInt32(nd.Cells(oId.Index).Value))
                    GuardarDibujos(est, Convert.ToInt32(nd.Cells(oId.Index).Value), 0, 0)
                End If
            Next
            MsgBox("La orden de pedido se genero exitosamente", MsgBoxStyle.Information)
            If total Then
                Limpiar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#Region "En modificación"
    Sub enModificacion()
        Try
#Region "Carga encabezado guardado"
            dtprecibido.Value = _ordenPedido.fechaRecibo
            dtptomamedidas.Value = _ordenPedido.fechaTomaMedidas
            nuddevoluciones.Value = _ordenPedido.NroDevoluciones
            cbproducidopor.SelectedValue = _ordenPedido.idTerceroProduccion
            txtdestino.Text = _ordenPedido.UbicacionVentaneria
            cbtiempoentrega.SelectedValue = _ordenPedido.IdPlazoEntrega
            cbcalculodias.Checked = _ordenPedido.diasHabiles
#End Region
#Region "Cargar Movimiento Guardado"
#Region "Cargar padres"
            _listOfPadres.ForEach(Sub(nodo)
                                      Dim nn As DataGridViewTreeNode = dwItemsOp.Nodes.Add()
                                      nn.Expand()
                                      nn.Cells(automatico.Index).Value = nodo.indAutomatico
                                      nn.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
                                      nn.Cells(AnchoRequerido.Index).Value = nodo.anchoRequerido
                                      nn.Cells(AltoRequerido.Index).Value = nodo.AltoRequerido
                                      nn.Cells(anchofabricacion.Index).Value = nodo.AnchoFabricacion
                                      nn.Cells(altofabricacion.Index).Value = nodo.AltoFabricacion
                                      nn.Cells(CantidadRequerida.Index).Value = nodo.CantidadRequerida
                                      nn.Cells(PiezasXUnidadReq.Index).Value = nodo.PiezasxUnidadRequeridas
                                      nn.Cells(oId.Index).Value = nodo.Id
                                      nn.Cells(oIdItemContrato.Index).Value = nodo.IdItemContrato
                                      nn.Cells(oIdCotiza.Index).Value = nodo.IdCotiza
                                      nn.Cells(oIdItemCotiza.Index).Value = nodo.idItemCotiza
                                      nn.Cells(oUbicacion.Index).Value = nodo.ubicacion.Trim
                                      nn.Cells(oDescripcion.Index).Value = nodo.descripcion.Trim
                                      nn.Cells(oAncho.Index).Value = nodo.Ancho
                                      nn.Cells(oAlto.Index).Value = nodo.Alto
                                      nn.Cells(oCantidad.Index).Value = nodo.Cantidad
                                      nn.Cells(oPiezasxUnidad.Index).Value = 1
                                      nn.Cells(oTipoVidrio.Index).Value = CInt(nodo.IdVidrio)
                                      nn.Cells(oEspesor.Index).Value = CInt(nodo.IdEspesor)
                                      nn.Cells(oColorVidrio.Index).Value = CInt(nodo.idColorVidrio)
                                      nn.Cells(oAcabadoPerfiles.Index).Value = nodo.IdAcabadoPerfil
                                      nn.Cells(oMetros.Index).Value = nodo.mtCuadrados
                                      nn.Cells(oMtInstalacion.Index).Value = nodo.metrosIntalacion
                                      nn.Cells(opreciounitario.Index).Value = nodo.precioUnitario
                                      nn.Cells(oprecioinstalacion.Index).Value = nodo.precioinstalacion
                                      nn.Cells(ocalculo_NSR.Index).Value = nodo.indNSR
                                      nn.Cells(opuntos.Index).Value = nodo.Puntos
                                      nn.Cells(ubicacionEstructura.Index).Value = nodo.UbicacionEstructura
                                      nn.Cells(versioncosto.Index).Value = Convert.ToString(nodo.versionCostoKiloAluminio) & "." & Convert.ToString(nodo.versionCostoAcabado) ''& "." & Convert.ToString(nodo.versionCostoNiveles) &
                                      ''"." & Convert.ToString(nodo.versionCostoVidrio) & "." & Convert.ToString(nodo.versionCostoAccesorios) & "." & Convert.ToString(nodo.versionCostoOtrosArticulos)
                                      nn.Cells(refSiesa.Index).Value = nodo.refSiesa
#Region "Carga hijos"
                                      _listOfHijos.Where(Function(a) a.IdItemPadre = nodo.Id).ToList.ForEach(Sub(nh)
                                                                                                                 Dim nd As DataGridViewTreeNode = nn.Nodes.Add()
                                                                                                                 nd.Cells(automatico.Index).Value = nh.indAutomatico
                                                                                                                 nd.Cells(AnchoRequerido.Index).Value = nh.anchoRequerido
                                                                                                                 nd.Cells(AltoRequerido.Index).Value = nh.AltoRequerido
                                                                                                                 nd.Cells(anchofabricacion.Index).Value = nh.AnchoFabricacion
                                                                                                                 nd.Cells(altofabricacion.Index).Value = nh.AltoFabricacion
                                                                                                                 nd.Cells(CantidadRequerida.Index).Value = nh.CantidadRequerida
                                                                                                                 nd.Cells(PiezasXUnidadReq.Index).Value = nh.PiezasxUnidadRequeridas
                                                                                                                 nd.Cells(oId.Index).Value = nh.Id
                                                                                                                 nd.Cells(oIdItemContrato.Index).Value = nh.IdItemContrato
                                                                                                                 nd.Cells(oIdCotiza.Index).Value = nh.IdCotiza
                                                                                                                 nd.Cells(oIdItemCotiza.Index).Value = nh.idItemPadreCotiza
                                                                                                                 nd.Cells(oIdArticulo.Index).Value = nh.idArticulo
                                                                                                                 nd.Cells(oTipoItem.Index).Value = nh.tipoitem
                                                                                                                 nd.Cells(oUbicacion.Index).Value = nh.ubicacion.Trim
                                                                                                                 nd.Cells(oDescripcion.Index).Value = nh.descripcion.Trim
                                                                                                                 nd.Cells(oAncho.Index).Value = nh.Ancho
                                                                                                                 nd.Cells(oAlto.Index).Value = nh.Alto
                                                                                                                 nd.Cells(oCantidad.Index).Value = nh.Cantidad
                                                                                                                 nd.Cells(ocantidad_disp.Index).Value = nh.disponible
                                                                                                                 nd.Cells(oPiezasxUnidad.Index).Value = 1
                                                                                                                 nd.Cells(oTipoVidrio.Index).Value = nh.IdVidrio
                                                                                                                 nd.Cells(oEspesor.Index).Value = nh.IdEspesor
                                                                                                                 nd.Cells(oColorVidrio.Index).Value = nh.IdColorVidrio
                                                                                                                 nd.Cells(oAcabadoPerfiles.Index).Value = nh.IdAcabadoPerfil
                                                                                                                 nd.Cells(oMetros.Index).Value = nh.mtCuadrados
                                                                                                                 Dim an As AnalizadorLexico = New AnalizadorLexico
                                                                                                                 carga_plantillas.CargarPlantilla(nh.Id, an, ClsEnums.TipoCarga.ORDENPEDIDO)
                                                                                                                 Dim cot As New cotizaciones.ClsCostizaciones
                                                                                                                 Dim coti As cotizaciones.cotizacion = cot.TraerxId(nd.Cells(oIdCotiza.Index).Value)
                                                                                                                 carga_plantillas.ValorarAnalizador(an, Convert.ToInt32(nd.Cells(oIdCotiza.Index).Value), coti.versionCostoAcabado,
                                                                                                                 coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                                                                                                 coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                                                                                                 nd.Cells(oEspecial.Index).Value = an
                                                                                                                 nd.Cells(oMtInstalacion.Index).Value = nh.metrosIntalacion
                                                                                                                 nd.Cells(opreciounitario.Index).Value = nh.precioUnitario
                                                                                                                 nd.Cells(oprecioinstalacion.Index).Value = nh.precioinstalacion
                                                                                                                 nd.Cells(opuntos.Index).Value = nh.Puntos
                                                                                                                 nd.Cells(ocalculo_NSR.Index).Value = CBool(nh.indNSR)

                                                                                                                 Select Case DirectCast(nh.tipoitem, ClsEnums.FamiliasMateriales)
                                                                                                                     Case ClsEnums.FamiliasMateriales.DISEÑOS
                                                                                                                         nd.Cells(versioncosto.Index).Value = Convert.ToString(nh.versionCostoKiloAluminio) & "." & Convert.ToString(nh.versionCostoAcabado) ''& "." & Convert.ToString(nh.versionCostoNiveles) &
                                                                                                                        ''"." & Convert.ToString(nh.versionCostoVidrio) & "." & Convert.ToString(nh.versionCostoAccesorios) & "." & Convert.ToString(nh.versionCostoOtrosArticulos)
                                                                                                                     Case ClsEnums.FamiliasMateriales.ACCESORIOS
                                                                                                                         nd.Cells(versioncosto.Index).Value = Convert.ToString(nh.versionCostoAccesorios)
                                                                                                                     Case ClsEnums.FamiliasMateriales.OTROS
                                                                                                                         nd.Cells(versioncosto.Index).Value = Convert.ToString(nh.versionCostoOtrosArticulos)
                                                                                                                     Case ClsEnums.FamiliasMateriales.PERFILERIA
                                                                                                                         nd.Cells(versioncosto.Index).Value = Convert.ToString(nh.versionCostoKiloAluminio) & "." & Convert.ToString(nh.versionCostoAcabado) & "." & Convert.ToString(nh.versionCostoNiveles)
                                                                                                                     Case ClsEnums.FamiliasMateriales.VIDRIO
                                                                                                                         nd.Cells(versioncosto.Index).Value = Convert.ToString(nh.versionCostoVidrio)
                                                                                                                 End Select

                                                                                                                 If nd.Cells(oEspecial.Index).Value IsNot Nothing Then
                                                                                                                     Dim a As AnalizadorLexico = DirectCast(nd.Cells(oEspecial.Index).Value, AnalizadorLexico)
                                                                                                                     If a.ListaVariables.Contains("CANTIDAD") Then
                                                                                                                         a.ListaVariables.Item("CANTIDAD").Valor = nd.Cells(CantidadRequerida.Index).Value
                                                                                                                         Dim _cot As New cotizaciones.ClsCostizaciones
                                                                                                                         Dim _coti As cotizaciones.cotizacion = _cot.TraerxId(nd.Cells(oIdCotiza.Index).Value)
                                                                                                                         carga_plantillas.ValorarAnalizador(a, Convert.ToInt32(nd.Cells(oIdCotiza.Index).Value), coti.versionCostoAcabado,
                                                                                              _coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                                                                              _coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                                                                                                     End If
                                                                                                                     If a.ListaVariables.Contains("PUNTOS") Then
                                                                                                                         nd.Cells(opuntos.Index).Value = Convert.ToDecimal(a.ListaVariables.Item("PUNTOS").Valor)
                                                                                                                     End If
                                                                                                                 End If
                                                                                                             End Sub)
#End Region
                                      Dim cd As New CargaDibujos
                                      Dim ldatos As List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)) =
                                      nn.Nodes.Select(Function(h) New Tuple(Of Integer,
                                      AnalizadorLexico,
                                      Integer,
                                      Decimal,
                                      Decimal)(h.Cells(oId.Index).Value,
                                               h.Cells(oEspecial.Index).Value, h.Index,
                                               h.Cells(AnchoRequerido.Index).Value,
                                               h.Cells(AltoRequerido.Index).Value)).ToList()
                                      Dim rg As ControlesPersonalizados.Estructurador.RegionEstructuras =
                                      cd.CrearDibujos(nn.Cells(oId.Index).Value,
                                                      ldatos, False, ClsEnums.TipoCarga.ORDENPEDIDO)
                                      If rg IsNot Nothing Then
                                          nn.Cells(oEspecial.Index).Value = rg.Duplicate(True)
                                      Else
                                          nn.Cells(oEspecial.Index).Value = New ControlesPersonalizados.Estructurador.RegionEstructuras(0, 0, 1, 1)
                                      End If
                                  End Sub)
#End Region
#End Region
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#Region "Validación Norma NSR"
    Public Function CumplimientoNorma(n As DataGridViewTreeNode) As Boolean
        Try
            Dim inercia As Decimal = 0
            Dim modulo_seccion As Decimal = 0
            Dim refperfil As String = String.Empty
            Dim mprm As New ClsPropiedadesMasicas
            Dim cot As New cotizaciones.ClsCostizaciones
            Dim idcotizacol As Integer = If(n.Level = 1, Convert.ToInt32(n.Cells(oIdCotiza.Index).Value), Convert.ToInt32(n.Parent.Cells(oIdCotiza.Index).Value))
            Dim cotmov As cotizaciones.cotizacion = cot.TraerxId(idcotizacol)
            If cotmov.Id = 0 Then
                MsgBox("Hay problemas para ubicar la cotización. Por favor comuníquese con el departamento de sistemas", MsgBoxStyle.Exclamation)
            End If
            If Convert.ToDecimal(n.Cells(AnchoRequerido.Index).Value) <= 0 Then
                MsgBox("El alto requerido, tiene que ser un valor numérico mayor a cero [0]. Por favor verifique la información", MsgBoxStyle.Exclamation)
                n.Cells(AnchoRequerido.Index).Value = n.Cells(oAncho.Index).Value
                Return False
            End If
            If Convert.ToDecimal(n.Cells(AltoRequerido.Index).Value) <= 0 Then
                MsgBox("El alto requerido, tiene que ser un valor numérico mayor a cero [0]. Por favor verifique la información", MsgBoxStyle.Exclamation)
                n.Cells(AltoRequerido.Index).Value = n.Cells(oAlto.Index).Value
                Return False
            End If
            Dim ancho As Decimal = Convert.ToDecimal(n.Cells(AnchoRequerido.Index).Value)
            Dim alto As Decimal = Convert.ToDecimal(n.Cells(AltoRequerido.Index).Value)
            If n.Level = 1 Then
                Dim padc As New movitoPadres.ClsMovitoPadres
                Dim padc_mov As movitoPadres.movitoPadre = padc.TraerxId(Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value))
                Dim mprop As PropiedadMasica = mprm.TraerporId(padc_mov.idPropiedadMasica)
                ancho /= padc_mov.Numero_Cuerpos_Norma
                refperfil = mprop.Nombre
                inercia = mprop.Inercia
                modulo_seccion = mprop.ModuloSeccion
            Else
                Dim mcpd As New ClsCombinacionPropiedadesDiseños
                Dim mhijd As New movitoHijos.ClsMovitoHijos
                Dim hijo As movitoHijos.movitoHijo = mhijd.TraerxId(Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value))
                Dim cpd As CombinacinPropiedadDiseño = mcpd.TraerporIdModelo(Convert.ToInt32(n.Cells(oIdArticulo.Index).Value))
                If cpd.IdPropiedadesMasica = 0 Then Return False
                Dim mprop As PropiedadMasica = mprm.TraerporId(cpd.IdPropiedadesMasica)
                ancho /= hijo.Numero_Cuerpos_Norma
                refperfil = mprop.Nombre
                inercia = mprop.Inercia
                modulo_seccion = mprop.ModuloSeccion
            End If
            Dim velviento As New ClsVelocidadesViento
            Dim areaefectiva As Decimal = (ancho / 1000) * (alto / 1000)
            Dim velvientB23 As Decimal = velviento.TraerxIdciudadyIdversion(cotmov.idCiudad, 1).Valor
            Dim velvientB24 As Decimal = velviento.TraerxIdciudadyIdversion(cotmov.idCiudad, 2).Valor
            Dim b23 As New NSR10.Base_Reglas("B.2.3", Convert.ToString(n.Cells(oUbicacion.Index).Value), velvientB23, cotmov.idGrupoUso,
                                             cotmov.idCateExposicion, cotmov.alturaCaballete, cotmov.alturaAlero,
                                             cotmov.anchoEdificio, cotmov.altoEdificio, cotmov.idTipoCubierta,
                                             cotmov.idTipoEdificacion, areaefectiva, cotmov.alturaEntreLosas)

            Dim b24 As New NSR10.Base_Reglas("B.2.4", Convert.ToString(n.Cells(oUbicacion.Index).Value), velvientB24, cotmov.idGrupoUso,
                                             cotmov.idCateExposicion, cotmov.alturaCaballete, cotmov.alturaAlero,
                                             cotmov.anchoEdificio, cotmov.altoEdificio, cotmov.idTipoCubierta,
                                             cotmov.idTipoEdificacion, areaefectiva, cotmov.alturaEntreLosas)

            Dim calculos As New NSR10.Calculos_10(Convert.ToString(n.Cells(oUbicacion.Index).Value), refperfil, b23, b24, inercia, modulo_seccion, cotmov.Ciudad,
                                                  ancho, alto,
                                                  cotmov.idCateExposicion, cotmov.IdPresion, cotmov.alturaEntreLosas)
            calculos.Calculo_de_Parametros()
            Dim plist As List(Of NSR10.Parametros_Tabla_Final_10) = calculos.GenerarTabla()
            If plist.Where(Function(p) Not p.Resistencia Or Not p.Deflexion).Count > 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Function Validar() As Boolean
        Try
            If dwItemsOp.Rows.Count <= 0 Then

                MsgBox("Debe haber al menos un ítem en la orden de pedido", MsgBoxStyle.Critical)
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
#Region "Procedimientos controles"
    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        Try
            Guardar(False)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Guardar_Total_Click(sender As Object, e As EventArgs)
        Try
            Guardar(True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnimpresion.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnimprimir.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf Guardar_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf Guardar_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf Guardar_Total_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnimpresion.Click, AddressOf Imprimir_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnimprimir.Click, AddressOf Imprimir_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnimpresion.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnimprimir.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnvistaprevia.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf Guardar_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf Guardar_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf Guardar_Total_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnimpresion.Click, AddressOf Imprimir_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnimprimir.Click, AddressOf Imprimir_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Limpiar_Click(sender As Object, e As EventArgs)
        Try
            curid = 0
            dwItems.Rows.Clear()
            dwItemsOp.Rows.Clear()
            dwVariables.Rows.Clear()
            egmodelo.EstructuraPrincipal.Estructuras.Clear()
            egmodelo.Refresh()
            tform = ClsEnums.TiOperacion.INSERTAR
            cargarEncabezado()
            cargarItemsDesdeContrato()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub frmGenerarOP_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            dtprecibido.MaxDate = DateTime.Today
            dtptomamedidas.MaxDate = DateTime.Today

#Region "Inicialización Variables"
            carga_plantillas = New CargasPlantilla
            encabezadoorden = New ClsOrdenDePedido
            motivodevol = New ClsMovitoMotivoDevolucionOped
            itemsop = New ClsItemsOped
            dibitemsop = New ClsDibujosItemsOps
            itemshijos = New ClsItemsHijoOped
            variables_plantilla = New ClsVariablesPlantillaOped
            descuento_global = New ClsDescuentosGeneralesPlantillaOped
            observaciones_plantilla = New ClsObservacionesPlantillaOped
            dibujos_plantilla = New ClsDibujosPlantillaOped
            materiales_plantilla = New ClsMaterialesPlantillaOped
            descuento_material_plantilla = New ClsDescuentosMaterialPlantillaOped
#End Region
            If _idcontrato > 0 Then
                cargar_documentos()
                cargarListasPrecios()
                cargarCentrosOperaciones()
                cargarEncabezado()
                CargarTerceros()
                CargarMotivos()
                CargarTiemposEntrega()
                cargarCentrosCostos()
                cargarUnidadNegocio()
                cargarDesplegablesMovimiento()

                If Tipo_Operacion = ClsEnums.TiOperacion.INSERTAR Then
                    cargarEncabezado()
                Else
                    enModificacion()
                End If
                cargarItemsDesdeContrato()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub PinCajaHerramientas_Click(sender As Object, e As EventArgs) Handles PincajaHerramientas.Click
        Try
            Select Case _estadoHerramientas
                Case True
                    spdescriptivos.Visible = False
                    _estadoHerramientas = spdescriptivos.Visible
                    scmovimientos.SplitterDistance = Me.Width - 17
                    PincajaHerramientas.Image = lAnclajes.Images(1)
                Case False
                    spdescriptivos.Visible = True
                    _estadoHerramientas = spdescriptivos.Visible
                    PincajaHerramientas.Image = lAnclajes.Images(0)
                    scmovimientos.SplitterDistance = Me.Width - (Me.Width * 0.25)
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbcalculodias_CheckedChanged(sender As Object, e As EventArgs) Handles cbcalculodias.CheckedChanged
        Try
            If cbcalculodias.Checked Then
                cbcalculodias.Text = "Días Hábiles"
            Else
                cbcalculodias.Text = "Días Solares"
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Utilidades"
    Private Sub btnexpandir_Click(sender As Object, e As EventArgs) Handles btnexpandir.Click
        Try
            dwItems.Nodes.ToList.ForEach(Sub(item)
                                             item.Expand()
                                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontraer_Click(sender As Object, e As EventArgs) Handles btncontraer.Click
        Try
            dwItems.Nodes.ToList.ForEach(Sub(item)
                                             item.Collapse()
                                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnmostrarcolumnas_Click(sender As Object, e As EventArgs) Handles btnmostrarcolumnas.Click
        Try
            Dim selector As New ControlesPersonalizados.GridFiltrado.FrmVisibilidadColumnas
            selector.Grid2 = dwItems
            selector.Location = MousePosition
            selector.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnexpadir1_Click(sender As Object, e As EventArgs) Handles btnexpadir1.Click
        Try
            dwItemsOp.Nodes.ToList.ForEach(Sub(item)
                                               item.Expand()
                                           End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontraer1_Click(sender As Object, e As EventArgs) Handles btncontraer1.Click
        Try
            dwItemsOp.Nodes.ToList.ForEach(Sub(item)
                                               item.Collapse()
                                           End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnmostrarcolumnas1_Click(sender As Object, e As EventArgs) Handles btnmostrarcolumnas1.Click
        Try
            Dim selector As New ControlesPersonalizados.GridFiltrado.FrmVisibilidadColumnas
            selector.Grid2 = dwItemsOp
            selector.Location = MousePosition
            selector.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub btnpasaritems_Click(sender As Object, e As EventArgs) Handles btnpasaritems.Click
        Try
            addItemsParaProducir()
            chkTodos.Checked = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Try
            Select Case DirectCast(sender, CheckBox).Checked
                Case Is = True
                    dwItems.Nodes.Cast(Of DataGridViewTreeNode).Where(Function(a) a.Level = 1).ToList.ForEach(Sub(b)
                                                                                                                  b.Cells(cSeleccion.Index).Value = True
                                                                                                              End Sub)
                Case Is = False
                    dwItems.Nodes.Cast(Of DataGridViewTreeNode).Where(Function(a) a.Level = 1).ToList.ForEach(Sub(b)
                                                                                                                  b.Cells(cSeleccion.Index).Value = False
                                                                                                              End Sub)
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub PinItemsContratos_Click(sender As Object, e As EventArgs) Handles pinitemsContrato.Click
        Try
            Select Case scgrids.Panel1Collapsed
                Case Is = True
                    scgrids.Panel1Collapsed = False
                    pinitemsContrato.Image = lAnclajes.Images(0)
                Case Is = False
                    scgrids.Panel1Collapsed = True
                    pinitemsContrato.Image = lAnclajes.Images(1)
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_NodeExpanded(sender As Object, e As ExpandedEventArgs) Handles dwItems.NodeExpanded
        Try
            If DirectCast(e.Node, DataGridViewTreeNode).Level = 1 Then
                For Each n As DataGridViewTreeNode In e.Node.Nodes
                    Dim nC As New DataGridViewTextBoxCell
                    nC.ValueType = Type.GetType("System.String")
                    nC.Value = False
                    nC.Style.ForeColor = Color.White
                    nC.Style.SelectionForeColor = Color.RoyalBlue
                    n.Cells(cSeleccion.Index) = nC
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItemsOp_NodeExpanded(sender As Object, e As ExpandedEventArgs) Handles dwItemsOp.NodeExpanded
        Try
            If DirectCast(e.Node, DataGridViewTreeNode).Level = 1 Then
                For Each n As DataGridViewTreeNode In e.Node.Nodes
                    Dim nC As New DataGridViewTextBoxCell
                    nC.ValueType = Type.GetType("System.String")
                    nC.Value = False
                    nC.Style.ForeColor = Color.White
                    nC.Style.SelectionForeColor = Color.RoyalBlue
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseDown
        Try
            If e.RowIndex >= 0 Then
                Dim menu As New ContextMenuStrip
                If e.Button = MouseButtons.Right And dwItems.CurrentNode.Level = 1 Then
                    dwItems.Rows(e.RowIndex).Selected = True
                    menu.Items.Add("Adicionar", Nothing, AddressOf addItemsParaProducir)
                End If
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItemsOp_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItemsOp.CellMouseDown
        Try
            If e.RowIndex > -1 Then
                Dim n As DataGridViewTreeNode = DirectCast(dwItemsOp.Rows(e.RowIndex), DataGridViewTreeNode)
                If e.Button = MouseButtons.Right Then
                    dwItemsOp.Rows(e.RowIndex).Selected = True
                    Dim menu As New ContextMenuStrip
                    If n.Level = 1 Then
                        menu.Items.Add("Eliminar", Nothing, AddressOf EliminarItem)
                    End If
                    menu.Show(Control.MousePosition)
                ElseIf e.Button = MouseButtons.Left Then

                    dwVariables.Rows.Clear()
                    If n.Level = 1 Then
                        If n.Cells(oEspecial.Index).Value Is Nothing Then
                            MsgBox("El item no tiene un dibujo", MsgBoxStyle.Exclamation)
                        Else
                            egmodelo.EstructuraPrincipal = DirectCast(n.Cells(oEspecial.Index).Value, ControlesPersonalizados.Estructurador.RegionEstructuras)
                        End If

                    ElseIf n.Level > 1 Then
                        If CInt(n.Cells(oTipoItem.Index).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                            cargarVariables(n)
                            If n.Cells(e.ColumnIndex).ReadOnly Then
                                Dim an As AnalizadorLexico = DirectCast(n.Cells(oEspecial.Index).Value, AnalizadorLexico)
                                Dim dib As New ClsDibujosPlantillaCotiza
                                Dim listdib As List(Of DibujoModelo) = dib.TraerporIdHijoCotiza(Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value))
                                If listdib.Count <= 0 Then
                                    Dim db As New ClsDibujosModelo
                                    listdib = db.TraerxIdPlantilla(Convert.ToInt32(n.Cells(oIdArticulo.Index).Value))
                                End If
                                Dim mdib As DibujoModelo = listdib.FirstOrDefault(Function(x) Convert.ToBoolean(Convert.ToInt32(If(x.Predeterminado.StartsWith("="),
                                                                                                                                an.EjecutarExpresion(x.Predeterminado.Remove(0, 1)),
                                                                                                                                x.Predeterminado))))
                                If mdib IsNot Nothing Then
                                    Dim vn As New DXF.Dibujante_DXF.Ventana(an, New SizeF(300, 350))
                                    vn.LeerDxfPersonalizado(mdib.DXF, False)
                                    dwItemsOp.DoDragDrop({vn, e.RowIndex, Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value)}, DragDropEffects.All)
                                Else
                                    MsgBox("Hay problemas para obtener la imagen del diseño. Comuníquese con el departamento de sistemas", MsgBoxStyle.Exclamation)
                                End If
                            End If
                        ElseIf Convert.ToInt32(n.Cells(oTipoItem.Index).Value) = ClsEnums.FamiliasMateriales.PERFILERIA Then
                            If n.Cells(e.ColumnIndex).ReadOnly Then
                                Dim art As New ClsArticulos
                                Dim ref As String = art.TraerxId(Convert.ToInt32(n.Cells(oIdArticulo.Index).Value)).Referencia
                                dwItemsOp.DoDragDrop({ref, e.RowIndex, Convert.ToInt32(n.Cells(oIdItemCotiza.Index).Value),
                                                  Convert.ToString(n.Cells(oAcabadoPerfiles.Index).FormattedValue)},
                                                  DragDropEffects.All)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItemsOp_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItemsOp.CellBeginEdit
        Try
            If e.RowIndex > -1 Then
                Dim n As DataGridViewTreeNode = dwItemsOp.Rows(e.RowIndex)
                If n.Level > 1 Then
                    Select Case Convert.ToInt32(n.Cells(oTipoItem.Index).Value)
                        Case 1, 5
                        Case 2
                            If e.ColumnIndex <> CantidadRequerida.Index Then
                                e.Cancel = True
                            End If
                        Case 3
                            If e.ColumnIndex = AltoRequerido.Index Then
                                e.Cancel = True
                            End If
                    End Select
                Else
                    If e.ColumnIndex = PiezasXUnidadReq.Index Then
                        e.Cancel = True
                    End If
                    valor_anterior_celda = n.Cells(e.ColumnIndex).Value
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub dwItemsOp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItemsOp.CellEndEdit
        Try
            If e.RowIndex > -1 Then
                Dim n As DataGridViewTreeNode = dwItemsOp.Rows(e.RowIndex)
                Select Case e.ColumnIndex
                    Case AnchoRequerido.Index, anchofabricacion.Index
                        If Not IsNumeric(n.Cells(e.ColumnIndex).Value) Then
                            MsgBox("El ancho requerido debe ser un valor numérico. Verifique la información", MsgBoxStyle.Exclamation)
                            n.Cells(e.ColumnIndex).Value = n.Cells(oAncho.Index).Value
                            Return
                        Else
                            If CDec(n.Cells(e.ColumnIndex).Value) <= 0 Then
                                MsgBox("El ancho requerido debe ser un valor mayor a cero [0]. Verifique la información", MsgBoxStyle.Exclamation)
                                n.Cells(e.ColumnIndex).Value = n.Cells(oAncho.Index).Value
                                Return
                            End If
                        End If
                    Case AltoRequerido.Index, altofabricacion.Index
                        If Not IsNumeric(n.Cells(e.ColumnIndex).Value) Then
                            MsgBox("El alto requerido debe ser un valor numérico. Verifique la información", MsgBoxStyle.Exclamation)
                            n.Cells(e.ColumnIndex).Value = n.Cells(oAlto.Index).Value
                            Return
                        Else
                            If CDec(n.Cells(e.ColumnIndex).Value) <= 0 Then
                                MsgBox("El alto requerido debe ser un valor mayor a cero [0]. Verifique la información", MsgBoxStyle.Exclamation)
                                n.Cells(e.ColumnIndex).Value = n.Cells(oAlto.Index).Value
                                Return
                            End If
                        End If
                    Case CantidadRequerida.Index
                        If Not IsNumeric(n.Cells(e.ColumnIndex).Value) Then
                            MsgBox("La cantidad requerida debe ser un valor numérico. Verifique la información")
                            n.Cells(e.ColumnIndex).Value = n.Cells(ocantidad_disp.Index).Value
                            Return
                        End If
                End Select
                If n.Level = 1 Then
                    Dim area_original As Decimal = (CDec(n.Cells(oAncho.Index).Value) * CDec(n.Cells(oAlto.Index).Value)) / 1000000
                    Dim areanueva As Decimal = (CDec(n.Cells(AnchoRequerido.Index).Value) * CDec(n.Cells(AltoRequerido.Index).Value)) / 1000000
                    Dim varianza As Decimal = (areanueva - area_original) / area_original
                    Dim cambio_cancelado As Boolean = False
                    If varianza < -0.1 Then
                        MsgBox("La reducción esta por debajo del 10% permitido. Verifique la información", MsgBoxStyle.Critical)
                        cambio_cancelado = True
                    End If
                    If varianza > 0.05 Then
                        MsgBox("El aumento esta por encima del 5% permitido. Verifique la información", MsgBoxStyle.Critical)
                        cambio_cancelado = True
                    End If
                    If Convert.ToBoolean(n.Cells(ocalculo_NSR.Index).Value) Then
                        If Not CumplimientoNorma(n) Then
                            MsgBox("El cambio en el/la " & dwItemsOp.Columns(e.ColumnIndex).HeaderText & ". No cumple con la norma NSR", MsgBoxStyle.Exclamation)
                            cambio_cancelado = True
                        End If
                    End If
                    If cambio_cancelado Then
                        If e.ColumnIndex = AnchoRequerido.Index Then
                            DirectCast(n.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                            n.Cells(AnchoRequerido.Index).Value = n.Cells(oAncho.Index).Value
                        ElseIf e.ColumnIndex = AltoRequerido.Index Then
                            DirectCast(n.Cells(AltoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                            n.Cells(AltoRequerido.Index).Value = n.Cells(oAlto.Index).Value
                        End If
                        Return
                    End If
                End If
                If e.ColumnIndex = CantidadRequerida.Index Then
                    If CDec(n.Cells(CantidadRequerida.Index).Value) > CDec(n.Cells(oCantidad.Index).Value) Then
                        MsgBox("La cantidad requerida no puede ser mayor a la cantidad disponible. Verifique la información", MsgBoxStyle.Critical)
                        DirectCast(n.Cells(CantidadRequerida.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                        n.Cells(CantidadRequerida.Index).Value = n.Cells(ocantidad_disp.Index).Value
                        Return
                    End If
                End If

                If e.ColumnIndex = anchofabricacion.Index Or e.ColumnIndex = AnchoRequerido.Index Or
    e.ColumnIndex = CantidadRequerida.Index Or e.ColumnIndex = AltoRequerido.Index Or
    e.ColumnIndex = altofabricacion.Index Then
                    Dim v As Decimal = Convert.ToDecimal(valor_anterior_celda) - Convert.ToDecimal(n.Cells(e.ColumnIndex).Value)
                    For Each h As DataGridViewTreeNode In n.Nodes
                        If DirectCast(h.Cells(oTipoItem.Index).Value, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Or
                                (DirectCast(h.Cells(oTipoItem.Index).Value, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.PERFILERIA And e.ColumnIndex <> AltoRequerido.Index And e.ColumnIndex <> altofabricacion.Index) Then
                            h.Cells(e.ColumnIndex).Value = Convert.ToDecimal(h.Cells(e.ColumnIndex).Value) - v
                        End If
                    Next
                End If

#Region "Cambio en variables"
                If n.Level > 1 Then
                    Select Case e.ColumnIndex
                        Case AnchoRequerido.Index
                            If CDec(n.Cells(AnchoRequerido.Index).Value) > CDec(n.Parent.Cells(AnchoRequerido.Index).Value) Then
                                MsgBox("El ancho del componente, no puede ser mayor al ancho del ítem general. Verifique la información", MsgBoxStyle.Critical)
                                DirectCast(n.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                                n.Cells(AnchoRequerido.Index).Value = n.Cells(oAncho.Index).Value
                            Else
                                If Convert.ToBoolean(n.Cells(ocalculo_NSR.Index).Value) Then
                                    If Not CumplimientoNorma(n) Then
                                        MsgBox("El cambio en el/la " & dwItemsOp.Columns(e.ColumnIndex).HeaderText & ". No cumple con la norma NSR", MsgBoxStyle.Exclamation)
                                        DirectCast(n.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                                        n.Cells(AnchoRequerido.Index).Value = n.Cells(oAncho.Index).Value
                                    End If
                                End If
                            End If
                        Case AltoRequerido.Index
                            If CDec(n.Cells(AltoRequerido.Index).Value) > CDec(n.Parent.Cells(AltoRequerido.Index).Value) Then
                                MsgBox("El alto del componente, no puede ser mayor al alto del ítem general. Verifique la información", MsgBoxStyle.Critical)
                                DirectCast(n.Cells(AltoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                                n.Cells(AltoRequerido.Index).Value = n.Cells(oAlto.Index).Value
                            Else
                                If Convert.ToBoolean(n.Cells(ocalculo_NSR.Index).Value) Then
                                    If Not CumplimientoNorma(n) Then
                                        MsgBox("El cambio en el/la " & dwItemsOp.Columns(e.ColumnIndex).HeaderText & ". No cumple con la norma NSR", MsgBoxStyle.Exclamation)
                                        DirectCast(n.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                                        n.Cells(AnchoRequerido.Index).Value = n.Cells(oAncho.Index).Value
                                    End If
                                End If
                            End If
                    End Select
                    If Convert.ToInt32(n.Cells(oTipoItem.Index).Value) = 1 Then
                        Dim a As AnalizadorLexico = DirectCast(n.Cells(oEspecial.Index).Value, AnalizadorLexico)
                        Dim min As Decimal = 0
                        Dim max As Decimal = Integer.MaxValue
                        Select Case e.ColumnIndex
                            Case AnchoRequerido.Index
                                If a.ListaVariables.Contains("ANCHO") Then
                                    If Convert.ToString(n.Cells(e.ColumnIndex).Value) <> "ERROR" Then
                                        If a.ListaVariables.Item("ANCHO").Restricciones.Contains("MINIMO") Then
                                            min = CDec(a.ListaVariables.Item("ANCHO").Restricciones.Item("MINIMO").Valor)
                                        End If
                                        If a.ListaVariables.Item("ANCHO").Restricciones.Contains("MAXIMO") Then
                                            max = CDec(a.ListaVariables.Item("ANCHO").Restricciones.Item("MAXIMO").Valor)
                                        End If
                                        If CDec(n.Cells(e.ColumnIndex).Value) >= min And CDec(n.Cells(e.ColumnIndex).Value) <= max Then
                                            a.ListaVariables.Item("ANCHO").Valor = n.Cells(e.ColumnIndex).Value
                                            Dim cot As New cotizaciones.ClsCostizaciones
                                            Dim coti As cotizaciones.cotizacion = cot.TraerxId(n.Cells(oIdCotiza.Index).Value)
                                            carga_plantillas.ValorarAnalizador(a, coti.Id, coti.versionCostoAcabado,
                                            coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                            coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                            dwItemsOp_CellMouseDown(dwItemsOp, New DataGridViewCellMouseEventArgs(e.ColumnIndex, e.RowIndex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
                                        Else
                                            MsgBox("El ancho de diseño debe estar entre [" & min.ToString() & "-" & max.ToString() & "]")
                                            n.Cells(e.ColumnIndex).Value = n.Cells(oAncho.Index).Value
                                        End If
                                    End If
                                End If
                            Case AltoRequerido.Index
                                If a.ListaVariables.Contains("ALTO") Then
                                    If Convert.ToString(n.Cells(e.ColumnIndex).Value) <> "ERROR" Then
                                        If a.ListaVariables.Item("ALTO").Restricciones.Contains("MINIMO") Then
                                            min = CDec(a.ListaVariables.Item("ALTO").Restricciones.Item("MINIMO").Valor)
                                        End If
                                        If a.ListaVariables.Item("ALTO").Restricciones.Contains("MAXIMO") Then
                                            max = CDec(a.ListaVariables.Item("ALTO").Restricciones.Item("MAXIMO").Valor)
                                        End If
                                        If CDec(n.Cells(e.ColumnIndex).Value) >= min And CDec(n.Cells(e.ColumnIndex).Value) <= max Then
                                            a.ListaVariables.Item("ALTO").Valor = n.Cells(e.ColumnIndex).Value
                                            Dim cot As New cotizaciones.ClsCostizaciones
                                            Dim coti As cotizaciones.cotizacion = cot.TraerxId(n.Cells(oIdCotiza.Index).Value)
                                            carga_plantillas.ValorarAnalizador(a, coti.Id, coti.versionCostoAcabado,
                                            coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                            coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                            dwItemsOp_CellMouseDown(dwItemsOp, New DataGridViewCellMouseEventArgs(e.ColumnIndex, e.RowIndex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
                                        Else
                                            MsgBox("El ancho de diseño debe estar entre [" & min.ToString() & "-" & max.ToString() & "]")
                                            n.Cells(e.ColumnIndex).Value = n.Cells(oAlto.Index).Value
                                        End If
                                    End If
                                End If
                            Case CantidadRequerida.Index
                                If a.ListaVariables.Contains("CANTIDAD") Then
                                    If Convert.ToString(n.Cells(e.ColumnIndex).Value) <> "ERROR" Then

                                        If a.ListaVariables.Item("CANTIDAD").Restricciones.Contains("MINIMO") Then
                                            min = CDec(a.ListaVariables.Item("CANTIDAD").Restricciones.Item("MINIMO").Valor)
                                        End If
                                        If a.ListaVariables.Item("CANTIDAD").Restricciones.Contains("MAXIMO") Then
                                            max = CDec(a.ListaVariables.Item("CANTIDAD").Restricciones.Item("MAXIMO").Valor)
                                        End If
                                        If CDec(n.Cells(e.ColumnIndex).Value) >= min And CDec(n.Cells(e.ColumnIndex).Value) <= max Then
                                            a.ListaVariables.Item("CANTIDAD").Valor = n.Cells(e.ColumnIndex).Value
                                            Dim cot As New cotizaciones.ClsCostizaciones
                                            Dim coti As cotizaciones.cotizacion = cot.TraerxId(n.Cells(oIdCotiza.Index).Value)
                                            carga_plantillas.ValorarAnalizador(a, coti.Id, coti.versionCostoAcabado,
                                            coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                            coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                            dwItemsOp_CellMouseDown(dwItemsOp, New DataGridViewCellMouseEventArgs(e.ColumnIndex, e.RowIndex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
                                        Else
                                            MsgBox("La cantidad de diseño debe estar entre [" & min.ToString() & "-" & max.ToString() & "]")
                                            n.Cells(e.ColumnIndex).Value = n.Cells(ocantidad_disp.Index).Value
                                        End If
                                    End If
                                End If
                            Case PiezasXUnidadReq.Index
                                If a.ListaVariables.Contains("PIEZAS_X_UND") Then
                                    If Convert.ToString(n.Cells(e.ColumnIndex).Value) <> "ERROR" Then
                                        a.ListaVariables.Item("PIEZAS_X_UND").Valor = n.Cells(e.ColumnIndex).Value
                                        Dim cot As New cotizaciones.ClsCostizaciones
                                        Dim coti As cotizaciones.cotizacion = cot.TraerxId(n.Cells(oIdCotiza.Index).Value)
                                        carga_plantillas.ValorarAnalizador(a, coti.Id, coti.versionCostoAcabado,
                                            coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                            coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                        dwItemsOp_CellMouseDown(dwItemsOp, New DataGridViewCellMouseEventArgs(e.ColumnIndex, e.RowIndex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
                                    End If
                                End If
                        End Select
                    End If
                End If
#End Region
                Dim mtinstala As Decimal = (CDec(n.Cells(AnchoRequerido.Index).Value) * CDec(n.Cells(AltoRequerido.Index).Value)) / 1000000
                If mtinstala < 1 Then
                    mtinstala = 1
                End If
                n.Cells(oMtInstalacion.Index).Value = mtinstala * CDec(n.Cells(CantidadRequerida.Index).Value) * CDec(n.Cells(PiezasXUnidadReq.Index).Value)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwVariables_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwVariables.CellEndEdit
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                Dim r As DataGridViewRow = dwItemsOp.SelectedRows(0)
                Dim a As AnalizadorLexico = DirectCast(r.Cells(oEspecial.Index).Value, AnalizadorLexico)
                Dim nombre_variable As String = Convert.ToString(dwVariables.Item(variable.Index, e.RowIndex).Value)
                Select Case nombre_variable
                    Case "ANCHO"
                        r.Cells(AnchoRequerido.Index).Value = dwVariables.Item(e.ColumnIndex, e.RowIndex).Value
                        DirectCast(r.Cells(AnchoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                    Case "ALTO"
                        r.Cells(AltoRequerido.Index).Value = dwVariables.Item(e.ColumnIndex, e.RowIndex).Value
                        DirectCast(r.Cells(AltoRequerido.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                    Case "CANTIDAD"
                        r.Cells(CantidadRequerida.Index).Value = dwVariables.Item(e.ColumnIndex, e.RowIndex).Value
                        DirectCast(r.Cells(CantidadRequerida.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                    Case "PIEZAS_X_UND"
                        r.Cells(PiezasXUnidadReq.Index).Value = dwVariables.Item(e.ColumnIndex, e.RowIndex).Value
                        DirectCast(r.Cells(PiezasXUnidadReq.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula = String.Empty
                End Select
                If a.ListaVariables.Contains(nombre_variable) Then
                    a.ListaVariables.Item(nombre_variable).Valor = dwVariables.Item(e.ColumnIndex, e.RowIndex).Value
                    Dim cot As New cotizaciones.ClsCostizaciones
                    Dim coti As cotizaciones.cotizacion = cot.TraerxId(r.Cells(oIdCotiza.Index).Value)
                    carga_plantillas.ValorarAnalizador(a, coti.Id, coti.versionCostoAcabado,
                                            coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                            coti.versionCostoVidrio, coti.versionCostoAccesorio,
                                                       coti.versionCostoOtrosArticulos)

                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub frmGenerarOP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            ClsInterbloqueos.Desbloquear(_idcontrato, ClsEnums.ModulosAplicacion.MODULO_GENERACION_ORDEN_PED)
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
                Dim menc As New Informes.datosInformesTableAdapters.sp_tp002_selectByIdXMLTableAdapter
                Dim mpadres As New Informes.datosInformesTableAdapters.sp_tp003_SelectPadresByIdOpXMLTableAdapter
                Dim mhijos As New Informes.datosInformesTableAdapters.sp_tp004_selectHijosByIdOpXMLTableAdapter
                Dim tb_ordenped As DataTable = menc.GetData(curid)
                Dim tbpadres As DataTable = mpadres.GetData(curid)
                Dim tbhijos As DataTable = mhijos.GetData(curid)
                ds.Tables.Add(tb_ordenped)
                ds.Tables.Add(tbpadres)
                ds.Tables.Add(tbhijos)
                ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "Orden_Ped_Reload.xml"))
            End If
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub Imprimir_Click(sender As Object, e As EventArgs)
        Try
            'Guardar(True)
            Dim fconfimpresora As New FrmConfiguracionImpresionCotiza()
            If fconfimpresora.ShowDialog() = DialogResult.OK Then
                'bwcargas.RunWorkerAsync("Imprimiendo")
                Dim ds As DataSet = Generar_Documento_Impresion(fconfimpresora.ImprimirImagenes)
            End If
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwVariables_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwVariables.CellBeginEdit
        Try
            e.Cancel = Not Convert.ToBoolean(dwVariables.Item(permitiredicion.Index, e.RowIndex).Value)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim ar As New CrearArchivoPlano
            Dim dic As New Dictionary(Of String, Integer)
            Dim sb = ar.CrearPlano(Me, 1, 2, dic)

            'Dim fs As IO.FileStream = IO.File.Create("")

            ' Add text to the file.
            'Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")

            Using outputFile As New IO.StreamWriter(IO.Path.Combine(ClsRutas.rutaTemporales, "plano.txt"))
                outputFile.WriteLine(sb.ToString())
            End Using
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dtptomamedidas_TextChanged(sender As Object, e As EventArgs) Handles dtptomamedidas.TextChanged
        Try
            lbFechaEntrega.Text = DateAdd(DateInterval.Day, CDbl(cbtiempoentrega.Text), DirectCast(sender, DateTimePicker).Value).ToString("dd/MM/yyyy")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
End Class