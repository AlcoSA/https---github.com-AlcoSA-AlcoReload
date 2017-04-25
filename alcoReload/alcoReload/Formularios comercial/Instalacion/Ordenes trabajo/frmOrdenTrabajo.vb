Imports ReglasNegocio

Public Class frmOrdenTrabajo
#Region "Variables"
    Private _tipoOrdenTrabajo As ClsEnums.TipoOrdenTrabajo
    Private _idContrato As Integer
    Private _nombreObra As String
    Private loadCompleted As Boolean = False
    Private mostrandoPaneles As Boolean = False
    Private Sep As Char
#End Region
#Region "Propiedades"
    Public Property TipoOrdenTrabajo() As ClsEnums.TipoOrdenTrabajo
        Get
            Return _tipoOrdenTrabajo
        End Get
        Set(ByVal value As ClsEnums.TipoOrdenTrabajo)
            _tipoOrdenTrabajo = value
        End Set
    End Property
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property NombreObra() As String
        Get
            Return _nombreObra
        End Get
        Set(ByVal value As String)
            _nombreObra = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarDocumentos()
        Try
            Dim mDocumentoOT As New ClsDocumentosOT
            Dim list As List(Of documentoOT) = mDocumentoOT.TraerTodos().Where(Function(a)
                                                                                   Return a.IdEstado = ClsEnums.Estados.ACTIVO And
                                                                                   a.Prefijo.Contains("OT")
                                                                               End Function).ToList
            cmbDocumentos.DisplayMember = "Prefijo"
            cmbDocumentos.ValueMember = "Id"
            cmbDocumentos.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbDocumentos.DataSource = list
            cmbDocumentos.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarProveedores()
        Try
            Dim mProveedores As New ClsProveedores
            Dim list As List(Of proveedores) = mProveedores.TraerTodos().Where(Function(a)
                                                                                   Return a.IdEstado = ClsEnums.Estados.ACTIVO
                                                                               End Function).ToList
            cmbProveedor.DisplayMember = "NombreEstablecimiento"
            cmbProveedor.ValueMember = "Id"
            cmbProveedor.DatosVisibles = {"NombreProveedor", "NombreEstablecimiento"}
            cmbProveedor.DataSource = list
            cmbProveedor.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarConceptos()
        Try
            Dim mConceptos As New ClsConceptos
            Dim list As New List(Of concepto)
            If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                list = mConceptos.TraerDisponiblesxProveedor(cmbProveedor.SelectedValue).Where(Function(a) a.ConceptoContrato = True).ToList
            ElseIf _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.ADICIONALES Then
                list = mConceptos.TraerDisponiblesxProveedor(cmbProveedor.SelectedValue).Where(Function(a) a.ConceptoAdicional = True).ToList
            End If
            DirectCast(ot_concepto, DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(ot_concepto, DataGridViewComboBoxColumn).DisplayMember = "Concepto"
            DirectCast(ot_concepto, DataGridViewComboBoxColumn).DataSource = list
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarUnidadesMedida()
        Try
            Dim mArticulos As New ClsArticulos
            Dim td As DataTable = mArticulos.traerUnidades()
            DirectCast(ot_unidadMedida, DataGridViewComboBoxColumn).ValueMember = "Unidad"
            DirectCast(ot_unidadMedida, DataGridViewComboBoxColumn).DisplayMember = "Unidad"
            DirectCast(ot_unidadMedida, DataGridViewComboBoxColumn).DataSource = td
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarItemsOT()
        Try
            Dim mOrdenP As New ClsOrdenDePedido
            Dim list As List(Of OrdenPedidoInstalacion) = mOrdenP.TraerParaInstalacion(_idContrato)
            For Each op As OrdenPedidoInstalacion In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(item_idOP.Index).Value = op.IdOrdenPedido
                r.Cells(item_fechaInicio.Index).Value = op.FechaInicio
                r.Cells(item_fechaFin.Index).Value = op.FechaEntrega
                r.Cells(item_mt2.Index).Value = op.Metros
                r.Cells(item_instalado.Index).Value = op.Instalado
                r.Cells(item_disponible.Index).Value = op.Disponible
                r.Cells(item_tipo.Index).Value = op.Tipo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarTotales()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("tipo")
            dt.Columns.Add("mts")
            dt.Columns.Add("inst")
            dt.Columns.Add("disp")
            For Each r As DataGridViewRow In dwItems.Rows
                If dt.Rows.Count > 0 Then
                    If Not existeTipo(dt, r.Cells(item_tipo.Index).Value) Then
                        Dim row As DataRow = dt.Rows.Add()
                        row("tipo") = r.Cells(item_tipo.Index).Value
                        row("mts") = r.Cells(item_mt2.Index).Value
                        row("inst") = r.Cells(item_instalado.Index).Value
                        row("disp") = r.Cells(item_disponible.Index).Value
                    Else
                        Dim mts As Integer = 0
                        Dim inst As Integer = 0
                        Dim disp As Integer = 0
                        Dim row As DataRow = Nothing
                        For Each dtrow As DataRow In dt.Rows
                            If dtrow("tipo").ToString() = r.Cells(item_tipo.Index).Value.ToString() Then
                                mts += CDec(dtrow("mts"))
                                inst += CDec(dtrow("inst"))
                                disp += CDec(dtrow("disp"))
                                row = dtrow
                            End If
                        Next
                        row("mts") = mts + CDec(r.Cells(item_mt2.Index).Value)
                        row("inst") = inst + CDec(r.Cells(item_instalado.Index).Value)
                        row("disp") = disp + CDec(r.Cells(item_disponible.Index).Value)
                    End If
                Else
                    Dim row As DataRow = dt.Rows.Add()
                    row("tipo") = r.Cells(item_tipo.Index).Value
                    row("mts") = r.Cells(item_mt2.Index).Value
                    row("inst") = r.Cells(item_instalado.Index).Value
                    row("disp") = r.Cells(item_disponible.Index).Value
                End If
            Next
            generarFilasYColumnas(dt)
            Dim rw As DataGridViewRow = dwTotales.Rows(dwTotales.Rows.Add())
            For Each row As DataRow In dt.Rows
                rw.Cells("tot_metros" & row("tipo").ToString().ToLower()).Value = CDec(row("mts"))
                rw.Cells("tot_inst" & row("tipo").ToString().ToLower()).Value = CDec(row("inst"))
                rw.Cells("tot_disp" & row("tipo").ToString().ToLower()).Value = CDec(row("disp"))
            Next
            rw.Selected = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function existeTipo(dt As DataTable, tipo As String) As Boolean
        Try
            Dim conteo As Integer = 0
            For Each r As DataRow In dt.Rows
                If r("tipo").ToString() = tipo Then
                    conteo += 1
                End If
            Next
            If conteo > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub generarFilasYColumnas(dt As DataTable)
        Try
            dwTotales.Columns.Clear()
            dwTotales.Rows.Clear()
            For Each row As DataRow In dt.Rows
                Dim colMetros As New DataGridViewTextBoxColumn
                colMetros.Name = "tot_metros" & row("tipo").ToString().ToLower
                colMetros.HeaderText = "Metros " & row("tipo").ToString().ToLower()
                colMetros.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dwTotales.Columns.Add(colMetros)

                Dim colInstalado As New DataGridViewTextBoxColumn
                colInstalado.Name = "tot_inst" & row("tipo").ToString().ToLower()
                colInstalado.HeaderText = "Instalado " & row("tipo").ToString().ToLower()
                colInstalado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dwTotales.Columns.Add(colInstalado)

                Dim colDisponible As New DataGridViewTextBoxColumn
                colDisponible.Name = "tot_disp" & row("tipo").ToString().ToLower()
                colDisponible.HeaderText = "Disponible " & row("tipo").ToString().ToLower()
                colDisponible.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dwTotales.Columns.Add(colDisponible)
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub calcularSubtotal(r As DataGridViewRow)
        Try
            r.Cells(ot_subtotal.Index).Value = CDec(r.Cells(ot_cantidadOrden.Index).Value) * CDec(r.Cells(ot_precioUnitario.Index).Value)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminarFilaDwOrdenPedido()
        Try
            If MessageBox.Show("¿Está seguro de eliminar el registro?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwOrdenPedido.SelectedRows(0)
                dwOrdenPedido.Rows.Remove(r)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cambiarPrecio()
        Try
            Dim r As DataGridViewRow = dwOrdenPedido.SelectedRows(0)
            Dim frm As New FrmCambioPrecio
            frm.Precio = r.Cells(ot_precioUnitario.Index).Value
            frm.PorcRetenido = r.Cells(ot_porcRecaudo.Index).Value
            frm.MotivoCambio = r.Cells(ot_motivoCambio.Index).Value
            If frm.ShowDialog() = DialogResult.OK Then
                If frm.Precio <> CDec(r.Cells(ot_precioUnitario.Index).Value) Or
                    frm.PorcRetenido <> CDec(r.Cells(ot_porcRecaudo.Index).Value) Then
                    r.Cells(ot_precioOriginal.Index).Value = r.Cells(ot_precioUnitario.Index).Value
                    r.Cells(ot_porcRetOriginal.Index).Value = r.Cells(ot_porcRecaudo.Index).Value
                    r.Cells(ot_motivoCambio.Index).Value = frm.MotivoCambio
                    r.Cells(ot_precioUnitario.Index).Value = frm.Precio
                    r.Cells(ot_porcRecaudo.Index).Value = frm.PorcRetenido
                    r.Cells(ot_actualizarPrecio.Index).Value = True
                End If
            End If
            calcularSubtotal(r)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionEncabezado() As Boolean
        Try
            If cmbDocumentos.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbDocumentos, "Debe seleccionar un documento para continuar")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbProveedor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbProveedor, "Debe seleccionar un proveedor para continuar")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function validacionMovimiento() As Boolean
        Try
            If dwOrdenPedido.Rows.Count = 0 Then
                ErrorProvider.SetError(lblErrorOT, "Ninguna orden de trabajo ha sido agregada")
                Return False
            End If
            ErrorProvider.Clear()

            Dim conteoConceptos As Integer = 0
            Dim conteoCantidad As Integer = 0
            Dim conteoPrecioCliente As Integer = 0
            For Each r As DataGridViewRow In dwOrdenPedido.Rows
                If r.Cells(ot_concepto.Index).Value Is Nothing Then
                    conteoConceptos += 1
                End If

                If r.Cells(ot_cantidadOrden.Index).Value Is Nothing Or CDec(r.Cells(ot_cantidadOrden.Index).Value) = 0 Then
                    conteoCantidad += 1
                End If

                If r.Cells(ot_precioCliente.Index).Value Is Nothing Or CDec(r.Cells(ot_precioCliente.Index).Value) = 0 Then
                    conteoPrecioCliente += 1
                End If
            Next

            If conteoConceptos > 0 Then
                ErrorProvider.SetError(lblErrorOT, "No se ha seleccionado el concepto en una o más filas")
                Return False
            End If
            ErrorProvider.Clear()

            If conteoCantidad > 0 Then
                ErrorProvider.SetError(lblErrorOT, "La cantidad debe ser mayor a cero (0). Verifique la información")
                Return False
            End If
            ErrorProvider.Clear()

            If conteoPrecioCliente > 0 Then
                ErrorProvider.SetError(lblErrorOT, "El precio del cliente debe ser mayor a cero (0). Verifique la información")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub frmOrdenTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblObra.Text = _nombreObra
            cargarDocumentos()
            cargarProveedores()
            cargarConceptos()
            cargarUnidadesMedida()
            cargarItemsOT()
            cargarTotales()
            If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.ADICIONALES Then
                spMovimiento.Panel2Collapsed = True
            End If
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Funcionamiento paneles"
    Private Sub MostrarPaneles()
        Try
            mostrandoPaneles = True
            If PanelOrdenTrabajo.Tag Is "A" Or PanelOrdenTrabajo.Tag Is "V" Then
                spMovimiento.Visible = True
                spMovimiento.Panel1Collapsed = False
                If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                    If PanelItemsOP.Tag Is "A" Or PanelItemsOP.Tag Is "V" Then
                        spMovimiento.Panel2Collapsed = False
                    Else
                        spMovimiento.Panel2Collapsed = True
                    End If
                Else
                    spMovimiento.Panel2Collapsed = True
                End If
            Else
                If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                    If PanelItemsOP.Tag Is "A" Or PanelItemsOP.Tag Is "V" Then
                        spMovimiento.Visible = True
                        spMovimiento.Panel1Collapsed = True
                        spMovimiento.Panel2Collapsed = False
                    Else
                        spMovimiento.Panel2Collapsed = True
                        spMovimiento.Panel1Collapsed = True
                        spMovimiento.Visible = False
                    End If
                Else
                    spMovimiento.Panel2Collapsed = True
                    spMovimiento.Panel1Collapsed = True
                    spMovimiento.Visible = False
                End If
            End If
            mostrandoPaneles = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnOrdenTrabajo_Click(sender As Object, e As EventArgs) Handles btnOrdenTrabajo.Click
        Try
            If PanelOrdenTrabajo.Tag Is "D" Then
                PanelOrdenTrabajo.Tag = "V"
                MostrarPaneles()
                PanelOrdenTrabajo.Focus()
            Else
                PanelOrdenTrabajo.Tag = "D"
                MostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAnclajeOrdenTrabajo_Click(sender As Object, e As EventArgs) Handles btnAnclajeOrdenTrabajo.Click
        Try
            If PanelOrdenTrabajo.Tag Is "A" Then
                btnAnclajeOrdenTrabajo.BackgroundImage = ImageListAnclaje.Images(1)
                PanelOrdenTrabajo.Tag = "D"
                btnOrdenTrabajo.Visible = True
                MostrarPaneles()
            Else
                btnAnclajeOrdenTrabajo.BackgroundImage = ImageListAnclaje.Images(0)
                PanelOrdenTrabajo.Tag = "A"
                btnOrdenTrabajo.Visible = False
                MostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub spMovimiento_Panel1_Leave(sender As Object, e As EventArgs) Handles spMovimiento.Panel1.Leave
        Try
            If PanelOrdenTrabajo.Tag IsNot "A" Then
                PanelOrdenTrabajo.Tag = "D"
                If mostrandoPaneles = False Then
                    MostrarPaneles()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnItemsOP_Click(sender As Object, e As EventArgs) Handles btnItemsOP.Click
        Try
            If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                If PanelItemsOP.Tag Is "D" Then
                    PanelItemsOP.Tag = "V"
                    MostrarPaneles()
                    PanelItemsOP.Focus()
                Else
                    PanelItemsOP.Tag = "D"
                    MostrarPaneles()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAnclajeItemsOP_Click(sender As Object, e As EventArgs) Handles btnAnclajeItemsOP.Click
        Try
            If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                If PanelItemsOP.Tag Is "A" Then
                    btnAnclajeItemsOP.BackgroundImage = ImageListAnclaje.Images(1)
                    PanelItemsOP.Tag = "D"
                    btnItemsOP.Visible = True
                    MostrarPaneles()
                Else
                    btnAnclajeItemsOP.BackgroundImage = ImageListAnclaje.Images(0)
                    PanelItemsOP.Tag = "A"
                    btnItemsOP.Visible = False
                    MostrarPaneles()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub spMovimiento_Panel2_Leave(sender As Object, e As EventArgs) Handles spMovimiento.Panel2.Leave
        Try
            If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                If PanelItemsOP.Tag IsNot "A" Then
                    PanelItemsOP.Tag = "D"
                    If mostrandoPaneles = False Then
                        MostrarPaneles()
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            dwOrdenPedido.EndEdit()
            If validacionEncabezado() Then
                If validacionMovimiento() Then
                    Dim mDocumentosOT As New ClsDocumentosOT
                    Dim mOrdenTrabajo As New ClsOrdenTrabajo
                    Dim mMovitoOt As New ClsMovitoOrdenTrabajo
                    Dim mCambioPrecio As New ClsCambioPrecio

                    Dim consecutivo As Integer = mDocumentosOT.TraerxId(cmbDocumentos.SelectedValue).ConsecutivoProximo

                    Dim idOrdenTrabajo As Integer = mOrdenTrabajo.Insertar(My.Settings.UsuarioActivo, _idContrato, cmbProveedor.SelectedValue,
                                           _tipoOrdenTrabajo, cmbDocumentos.SelectedValue, consecutivo, txtNotas.Text, ClsEnums.Estados.SIN_IMPRIMIR,
                                           ClsEnums.Estados.ACTIVO)

                    mDocumentosOT.ActualizarConsecutivo(consecutivo, cmbDocumentos.SelectedValue)

                    For Each r As DataGridViewRow In dwOrdenPedido.Rows
                        Dim idMovitoOT As Integer = mMovitoOt.Insertar(My.Settings.UsuarioActivo, r.Cells(ot_concepto.Index).Value,
                                                                       r.Cells(ot_descripcion.Index).Value, r.Cells(ot_precioUnitario.Index).Value,
                                                                       r.Cells(ot_cantidadOrden.Index).Value, 0, r.Cells(ot_porcRecaudo.Index).Value,
                                                                       r.Cells(ot_unidadMedida.Index).Value, r.Cells(ot_notas.Index).Value, "",
                                                                       r.Cells(ot_facturable.Index).Value, ClsEnums.Estados.ACTIVO, idOrdenTrabajo)

                        If CBool(r.Cells(ot_actualizarPrecio.Index).Value) = True Then
                            mCambioPrecio.Insertar(My.Settings.UsuarioActivo, idMovitoOT, r.Cells(ot_precioOriginal.Index).Value,
                                                   r.Cells(ot_precioUnitario.Index).Value, r.Cells(ot_porcRetOriginal.Index).Value,
                                                   r.Cells(ot_porcRecaudo.Index).Value, r.Cells(ot_motivoCambio.Index).Value)
                        End If
                    Next
                    MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbDocumentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDocumentos.SelectedValueChanged
        Try
            If loadCompleted = True Then
                Dim docto As documentoOT = cmbDocumentos.SelectedItem
                lblConsecutivo.Text = String.Empty
                lblConsecutivo.Text = docto.ConsecutivoProximo
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Eventos dwOrdenPedido"
    Private Sub btnAgregarFila_Click_1(sender As Object, e As EventArgs) Handles btnAgregarFila.Click
        Try
            If validacionEncabezado() Then
                Dim r As DataGridViewRow = dwOrdenPedido.Rows(dwOrdenPedido.Rows.Add())
                'If _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                r.Cells(ot_facturable.Index).Value = True
                '    dwOrdenPedido.Columns(ot_facturable.Index).ReadOnly = True
                '    dwOrdenPedido.Columns(ot_facturable.Index).DefaultCellStyle.BackColor = Color.Gainsboro
                'ElseIf _tipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.ADICIONALES Then
                '    r.Cells(ot_facturable.Index).Value = False
                '    dwOrdenPedido.Columns(ot_facturable.Index).ReadOnly = False
                '    dwOrdenPedido.Columns(ot_facturable.Index).DefaultCellStyle.BackColor = Color.White
                'End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwOrdenPedido.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwOrdenPedido.CurrentCell.ColumnIndex

            If dwOrdenPedido.Columns(columnIndex) Is ot_cantidadOrden Or dwOrdenPedido.Columns(columnIndex) Is ot_precioCliente Then
                Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                RemoveHandler dText.KeyPress, AddressOf dText_KeyPress
                AddHandler dText.KeyPress, AddressOf dText_KeyPress
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            Dim columnIndex As Integer = dwOrdenPedido.CurrentCell.ColumnIndex

            If dwOrdenPedido.Columns(columnIndex) Is ot_cantidadOrden Or dwOrdenPedido.Columns(columnIndex) Is ot_precioCliente Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then e.Handled = True
                If Char.IsPunctuation(e.KeyChar) Then
                    If e.KeyChar <> "."c Then e.Handled = True
                End If
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwOrdenPedido_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwOrdenPedido.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwOrdenPedido.Rows(e.RowIndex)
                If e.ColumnIndex = ot_concepto.Index Then
                    If r.Cells(ot_concepto.Index).Value IsNot Nothing Then
                        Dim mConcepto As New ClsConceptos
                        Dim mPrecioInstalacion As New ClsPreciosInstalacion
                        Dim conc As concepto = mConcepto.TraerxId(DirectCast(r.Cells(ot_concepto.Index), DataGridViewComboBoxCell).Value)
                        If Not mPrecioInstalacion.ExistePrecio(cmbProveedor.SelectedValue, conc.Id) Then
                            MsgBox("El concepto seleccionado no tiene precio con el proveedor actual")
                            r.Cells(ot_concepto.Index).Value = Nothing
                            Return
                        End If
                        r.Cells(ot_descripcion.Index).Value = conc.Descripcion
                        r.Cells(ot_unidadMedida.Index).Value = conc.UnidadMedida
                        Dim prec As precioInstalacion = mPrecioInstalacion.TraerEspecifico(cmbProveedor.SelectedValue, conc.Id)
                        r.Cells(ot_precioUnitario.Index).Value = prec.Precio
                        r.Cells(ot_porcRecaudo.Index).Value = prec.PorcRetenido
                        r.Cells(ot_idTipoObra.Index).Value = conc.IdTipoObra
                        r.Cells(ot_tipoObra.Index).Value = conc.TipoObra
                        calcularSubtotal(r)
                        r.Cells(ot_actualizarPrecio.Index).Value = False
                        r.Cells(ot_precioOriginal.Index).Value = Nothing
                        r.Cells(ot_porcRetOriginal.Index).Value = Nothing
                        r.Cells(ot_motivoCambio.Index).Value = Nothing
                    End If
                ElseIf e.ColumnIndex = ot_cantidadOrden.Index Then
                    If r.Cells(ot_cantidadOrden.Index).Value Is String.Empty Then
                        r.Cells(ot_cantidadOrden.Index).Value = 0
                    End If
                    calcularSubtotal(r)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwOrdenPedido_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwOrdenPedido.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwOrdenPedido.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminarFilaDwOrdenPedido)
                    menu.Items.Add("Cambiar precio", Nothing, AddressOf cambiarPrecio)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

End Class