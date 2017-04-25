Imports ReglasNegocio

Public Class frmCuentaCobroDirecta
#Region "Variables"
    Private loadCompleted As Boolean = False
    Private Sep As Char
#End Region
#Region "Procedimientos"
    Private Sub cargarDocumentos()
        Try
            Dim mDocumentos As New ClsDocumentosOT
            Dim list As List(Of documentoOT) = mDocumentos.TraerTodos().Where(Function(a) a.Prefijo.Contains("CCD")).ToList
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
    Private Sub cargarEncargados()
        Try
            Dim mEncargados As New ClsEncargados
            Dim list As List(Of encargado) = mEncargados.TraerxIdProveedor(cmbProveedor.SelectedValue)
            cmbEncargado.DisplayMember = "NombreEncargado"
            cmbEncargado.ValueMember = "Id"
            cmbEncargado.DatosVisibles = {"NombreEncargado"}
            cmbEncargado.DataSource = list
            cmbEncargado.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarClientes()
        Try
            Dim mClientes As New clsClientesUnoee
            mClientes.t200_selectAllClientesUnoee(itNit.TablaFuente)
            itCliente.TablaFuente = itNit.TablaFuente
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarConceptos()
        Try
            Dim mConceptos As New ClsConceptos
            Dim list As List(Of concepto) = mConceptos.TraerTodos()
            DirectCast(dwMovimiento.Columns(item_concepto.Index), DataGridViewComboBoxColumn).DisplayMember = "Concepto"
            DirectCast(dwMovimiento.Columns(item_concepto.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwMovimiento.Columns(item_concepto.Index), DataGridViewComboBoxColumn).DataSource = list
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarUnidadesMedida()
        Try
            Dim mArticulos As New ClsArticulos
            Dim td As DataTable = mArticulos.traerUnidades()
            DirectCast(item_undMedia, DataGridViewComboBoxColumn).ValueMember = "Unidad"
            DirectCast(item_undMedia, DataGridViewComboBoxColumn).DisplayMember = "Unidad"
            DirectCast(item_undMedia, DataGridViewComboBoxColumn).DataSource = td
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMotivos()
        Try
            Dim mMotivos As New ClsMotivos
            Dim list As List(Of motivo) = mMotivos.TraerTodos(76)
            DirectCast(dwMovimiento.Columns(item_motivo.Index), DataGridViewComboBoxColumn).DisplayMember = "Descripcion"
            DirectCast(dwMovimiento.Columns(item_motivo.Index), DataGridViewComboBoxColumn).ValueMember = "Codigo"
            DirectCast(dwMovimiento.Columns(item_motivo.Index), DataGridViewComboBoxColumn).DataSource = list
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub calcularSubtotal(r As DataGridViewRow)
        Try
            r.Cells(item_subtotal.Index).Value = CInt(r.Cells(item_cantidadOrden.Index).Value) * CDec(r.Cells(item_precioUnitario.Index).Value)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            If MessageBox.Show("¿Está seguro de eliminar el registro?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwMovimiento.SelectedRows(0)
                dwMovimiento.Rows.Remove(r)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVendedor()
        Try
            If loadCompleted Then
                Dim mObra As New clsObrasUnoee
                Dim obra As obrasUnoee = mObra.traerObraByNitClienteAndSuc(itNit.Text, itCodigoObra.Text)
                txtVendedor.Text = obra.idVendedor
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionEncabezado() As Boolean
        Try
            If cmbDocumentos.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbDocumentos, "Debe seleccionar el tipo de documento")
                Return False
            End If
            ErrorProvider.Clear()

            If lblConsecutivo.Text = String.Empty Then
                ErrorProvider.SetError(lblConsecutivo, "No hay ningún consecutivo")
                Return False
            End If
            ErrorProvider.Clear()

            If Not IsNumeric(lblConsecutivo.Text) Then
                ErrorProvider.SetError(lblConsecutivo, "Consecutivo inválido")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbProveedor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbProveedor, "Debe seleccionar el proveedor")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbEncargado.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbEncargado, "Debe seleccionar el encargado")
                Return False
            End If
            ErrorProvider.Clear()

            If itNit.Seleted_rowid Is Nothing Then
                ErrorProvider.SetError(itNit, "Debe indicar el nit")
                Return False
            End If
            ErrorProvider.Clear()

            If itCliente.Seleted_rowid Is Nothing Then
                ErrorProvider.SetError(itCliente, "Debe indicar el cliente")
                Return False
            End If
            ErrorProvider.Clear()

            If itCodigoObra.Seleted_rowid Is Nothing Then
                ErrorProvider.SetError(itCodigoObra, "Debe indicar el código de obra")
                Return False
            End If
            ErrorProvider.Clear()

            If itObra.Seleted_rowid Is Nothing Then
                ErrorProvider.SetError(itObra, "Debe indicar la obra")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function validacionFinal() As Boolean
        Try
            If Not validacionEncabezado() Then
                Return False
            End If
            Dim conteoConceptos As Integer = 0
            Dim conteoCantidad As Integer = 0
            Dim conteoMotivo As Integer = 0
            Dim conteoPCliente As Integer = 0
            For Each r As DataGridViewRow In dwMovimiento.Rows
                If r.Cells(item_concepto.Index).Value Is Nothing Then
                    conteoConceptos += 1
                End If
                If CDec(r.Cells(item_cantidadOrden.Index).Value) = 0 Then
                    conteoCantidad += 1
                End If
                If CDec(r.Cells(item_precioCliente.Index).Value) = 0 Then
                    conteoPCliente += 1
                End If
                If r.Cells(item_motivo.Index).Value Is Nothing Then
                    conteoMotivo += 1
                End If
            Next
            If conteoConceptos > 0 Then
                ErrorProvider.SetError(dwMovimiento, "Uno o más conceptos sin seleccionar")
                Return False
            End If
            ErrorProvider.Clear()
            If conteoCantidad > 0 Then
                ErrorProvider.SetError(dwMovimiento, "Uno o más campos de cantidad están en cero (0)")
                Return False
            End If
            ErrorProvider.Clear()
            If conteoPCliente > 0 Then
                ErrorProvider.SetError(dwMovimiento, "Uno o más precios de cliente está en cero (0)")
                Return False
            End If
            ErrorProvider.Clear()
            If conteoMotivo > 0 Then
                ErrorProvider.SetError(dwMovimiento, "Uno o más motivos sin seleccionar")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub cambiarPrecio()
        Try
            Dim r As DataGridViewRow = dwMovimiento.SelectedRows(0)
            Dim frm As New FrmCambioPrecio
            frm.Precio = r.Cells(item_precioUnitario.Index).Value
            frm.PorcRetenido = r.Cells(item_porcRetenido.Index).Value
            frm.MotivoCambio = r.Cells(item_motivoCambio.Index).Value
            If frm.ShowDialog() = DialogResult.OK Then
                If frm.Precio <> CDec(r.Cells(item_precioUnitario.Index).Value) Or
                    frm.PorcRetenido <> CDec(r.Cells(item_porcRetenido.Index).Value) Then
                    r.Cells(item_precioOriginal.Index).Value = r.Cells(item_precioUnitario.Index).Value
                    r.Cells(item_porcentOriginal.Index).Value = r.Cells(item_porcRetenido.Index).Value
                    r.Cells(item_motivoCambio.Index).Value = frm.MotivoCambio
                    r.Cells(item_precioUnitario.Index).Value = frm.Precio
                    r.Cells(item_porcRetenido.Index).Value = frm.PorcRetenido
                    r.Cells(item_actualizarPrecio.Index).Value = True
                End If
            End If
            calcularSubtotal(r)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmCuentaCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarDocumentos()
            cargarProveedores()
            cargarClientes()
            cargarConceptos()
            cargarUnidadesMedida()
            cargarMotivos()
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
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            dwMovimiento.EndEdit()
            If validacionFinal() Then
                Dim mCuentaCobro As New ClsCuentaCobro
                Dim mMovitoCuentaCobro As New ClsMovitoCuentaCobro
                Dim mDocumento As New ClsDocumentosOT
                Dim mCambioPrecio As New ClsCambioPrecio
                Dim idCuenta As Integer = mCuentaCobro.Insertar(My.Settings.UsuarioActivo, 0, cmbProveedor.SelectedValue,
                                                                 cmbEncargado.SelectedValue, cmbDocumentos.SelectedValue,
                                                                 CInt(lblConsecutivo.Text), ClsEnums.TipoCuentaCobro.DIRECTAS,
                                                                 itNit.Text, itCliente.Text, itCodigoObra.Text, itObra.Text,
                                                                 lblNitYO.Text, lblClienteYO.Text, txtVendedor.Text, txtObservaciones.Text,
                                                                 ClsEnums.Estados.ACTIVO, ClsEnums.Estados.SIN_IMPRIMIR)
                mDocumento.ActualizarConsecutivo(CInt(lblConsecutivo.Text), cmbDocumentos.SelectedValue)
                For Each r As DataGridViewRow In dwMovimiento.Rows
                    Dim idMovitoCCobro As Integer = mMovitoCuentaCobro.Insertar(My.Settings.UsuarioActivo, idCuenta, 0, r.Cells(item_precioUnitario.Index).Value,
                                                r.Cells(item_cantidadOrden.Index).Value, r.Cells(item_porcRetenido.Index).Value,
                                                r.Cells(item_undMedia.Index).Value, r.Cells(item_facturable.Index).Value,
                                                r.Cells(item_concepto.Index).Value, r.Cells(item_descripcion.Index).Value,
                                                r.Cells(item_precioCliente.Index).Value, r.Cells(item_motivo.Index).Value,
                                                ClsEnums.Estados.ACTIVO)

                    If CBool(r.Cells(item_actualizarPrecio.Index).Value) = True Then
                        mCambioPrecio.Insertar(My.Settings.UsuarioActivo, idMovitoCCobro, r.Cells(item_precioOriginal.Index).Value,
                                               r.Cells(item_precioUnitario.Index).Value, r.Cells(item_porcentOriginal.Index).Value,
                                               r.Cells(item_porcRetenido.Index).Value, r.Cells(item_motivoCambio.Index).Value)
                    End If
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            loadCompleted = False
            cmbDocumentos.SelectedItem = Nothing
            lblConsecutivo.Text = String.Empty
            cmbProveedor.SelectedItem = Nothing
            cmbEncargado.SelectedItem = Nothing
            txtVendedor.Text = String.Empty
            itNit.Text = String.Empty
            itNit.Seleted_rowid = Nothing
            itCliente.Text = String.Empty
            itCliente.Seleted_rowid = Nothing
            itCodigoObra.Text = String.Empty
            itCodigoObra.Seleted_rowid = Nothing
            itObra.Text = String.Empty
            itObra.Seleted_rowid = Nothing
            lblNitYO.Text = "--"
            lblClienteYO.Text = "--"
            dwMovimiento.Rows.Clear()
            txtObservaciones.Text = String.Empty
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Intellisens"
#Region "Nit"
    Private Sub itNit_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itNit.selected_value_changed
        Try
            ErrorProvider.Clear()
            itCliente.Text = e.ValorSecundario
            itCliente.Seleted_rowid = itNit.Seleted_rowid
            itCodigoObra.Text = String.Empty
            itObra.Text = String.Empty
            itCliente.Value2 = e.ValorPrimario
            Dim mObras As New clsObrasUnoee
            lblNitYO.Text = "--"
            lblClienteYO.Text = "--"
            txtVendedor.Text = String.Empty
            If Not String.IsNullOrEmpty(e.Id) Then
                mObras.traerObrasByID(e.Id, itCodigoObra.TablaFuente)
                itObra.TablaFuente = itCodigoObra.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itNit_User_Edit(sender As Object, e As EventArgs) Handles itNit.User_Edit
        Try
            itCliente.Text = String.Empty
            itCliente.Seleted_rowid = Nothing
            itCodigoObra.Text = String.Empty
            itCodigoObra.Seleted_rowid = Nothing
            itObra.Text = String.Empty
            itObra.Seleted_rowid = Nothing
            lblNitYO.Text = "--"
            lblClienteYO.Text = "--"
            txtVendedor.Text = String.Empty
            itNit.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Cliente"
    Private Sub itCliente_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itCliente.selected_value_changed
        Try
            ErrorProvider.Clear()
            itNit.Text = e.ValorSecundario
            itNit.Seleted_rowid = itCliente.Seleted_rowid
            itCodigoObra.Text = String.Empty
            itObra.Text = String.Empty
            itNit.Value2 = e.ValorPrimario
            Dim mObras As New clsObrasUnoee
            lblNitYO.Text = "--"
            lblClienteYO.Text = "--"
            txtVendedor.Text = String.Empty
            If Not String.IsNullOrEmpty(e.Id) Then
                mObras.traerObrasByID(e.Id, itCodigoObra.TablaFuente)
                itObra.TablaFuente = itCodigoObra.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCliente_User_Edit(sender As Object, e As EventArgs) Handles itCliente.User_Edit
        Try
            itNit.Text = String.Empty
            itNit.Seleted_rowid = Nothing
            itCodigoObra.Text = String.Empty
            itCodigoObra.Seleted_rowid = Nothing
            itObra.Text = String.Empty
            itObra.Seleted_rowid = Nothing
            lblNitYO.Text = "--"
            lblClienteYO.Text = "--"
            txtVendedor.Text = String.Empty
            itCliente.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Codigo obra"
    Private Sub itCodigoObra_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itCodigoObra.selected_value_changed
        Try
            ErrorProvider.Clear()
            itObra.Text = e.ValorSecundario
            itObra.Seleted_rowid = e.Id
            itObra.Value2 = e.ValorPrimario
            Dim mObras As New clsObrasUnoee
            lblNitYO.Text = mObras.traerYo(itNit.Text, e.ValorPrimario, "NIT")
            lblClienteYO.Text = mObras.traerYo(itNit.Text, e.ValorPrimario, "NOMBRE")
            cargarVendedor()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCodigoObra_User_Edit(sender As Object, e As EventArgs) Handles itCodigoObra.User_Edit
        Try
            itObra.Text = String.Empty
            itObra.Seleted_rowid = Nothing
            lblNitYO.Text = "--"
            lblClienteYO.Text = "--"
            txtVendedor.Text = String.Empty
            itCodigoObra.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Obra"
    Private Sub itObra_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itObra.selected_value_changed
        Try
            ErrorProvider.Clear()
            itCodigoObra.Text = e.ValorSecundario
            itCodigoObra.Seleted_rowid = e.Id
            itCodigoObra.Value2 = e.ValorPrimario
            Dim mObras As New clsObrasUnoee
            lblNitYO.Text = mObras.traerYo(itNit.Text, e.ValorSecundario, "NIT")
            lblClienteYO.Text = mObras.traerYo(itNit.Text, e.ValorSecundario, "NOMBRE")
            cargarVendedor()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itObra_User_Edit(sender As Object, e As EventArgs) Handles itObra.User_Edit
        Try
            itCodigoObra.Text = String.Empty
            itCodigoObra.Seleted_rowid = Nothing
            lblNitYO.Text = "--"
            lblClienteYO.Text = "--"
            txtVendedor.Text = String.Empty
            itObra.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
    Private Sub cmbProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedValueChanged
        Try
            If loadCompleted Then
                cargarEncargados()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbDocumentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDocumentos.SelectedValueChanged
        Try
            If loadCompleted Then
                Dim docto As documentoOT = cmbDocumentos.SelectedItem
                lblConsecutivo.Text = docto.ConsecutivoProximo
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAgregarFila_Click(sender As Object, e As EventArgs) Handles btnAgregarFila.Click
        Try
            If validacionEncabezado() Then
                Dim r As DataGridViewRow = dwMovimiento.Rows(dwMovimiento.Rows.Add())
                r.Cells(item_facturable.Index).Value = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwMovimiento_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwMovimiento.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwMovimiento.Rows(e.RowIndex)
                If e.ColumnIndex = item_concepto.Index Then
                    If r.Cells(item_concepto.Index).Value IsNot Nothing Then
                        Dim mConcepto As New ClsConceptos
                        Dim mPrecioInstalacion As New ClsPreciosInstalacion
                        r.Cells(item_precioOriginal.Index).Value = Nothing
                        r.Cells(item_porcentOriginal.Index).Value = Nothing
                        r.Cells(item_motivoCambio.Index).Value = Nothing
                        r.Cells(item_actualizarPrecio.Index).Value = False
                        Dim conc As concepto = mConcepto.TraerxId(r.Cells(item_concepto.Index).Value)
                        If Not conc.ConceptoEspecial Then
                            r.Cells(item_descripcion.Index).Value = conc.Descripcion
                            r.Cells(item_undMedia.Index).Value = conc.UnidadMedida
                            If mPrecioInstalacion.ExistePrecio(cmbProveedor.SelectedValue, conc.Id) Then
                                Dim prec As precioInstalacion = mPrecioInstalacion.TraerEspecifico(cmbProveedor.SelectedValue, conc.Id)
                                r.Cells(item_precioUnitario.Index).Value = prec.Precio
                                r.Cells(item_porcRetenido.Index).Value = prec.PorcRetenido
                            Else
                                MsgBox("El concepto seleccionado no tiene precio con el proveedor actual")
                                r.Cells(item_precioUnitario.Index).Value = 0
                                r.Cells(item_porcRetenido.Index).Value = 0
                            End If
                            calcularSubtotal(r)
                        Else
                            r.Cells(item_descripcion.Index).Value = Nothing
                            r.Cells(item_cantidadOrden.Index).Value = 0
                            r.Cells(item_undMedia.Index).Value = Nothing
                            r.Cells(item_precioUnitario.Index).Value = Nothing
                            r.Cells(item_precioCliente.Index).Value = Nothing
                            r.Cells(item_subtotal.Index).Value = Nothing
                            r.Cells(item_porcRetenido.Index).Value = Nothing
                            r.Cells(item_motivo.Index).Value = Nothing
                            Dim frm As New frmConceptoEspecial
                            frm.IdConceptoLinea = r.Cells(item_concepto.Index).Value
                            If frm.ShowDialog() = DialogResult.OK Then
                                r.Cells(item_descripcion.Index).Value = frm.Descripcion
                                r.Cells(item_cantidadOrden.Index).Value = frm.Cantidad
                                r.Cells(item_undMedia.Index).Value = frm.UnidadMedida
                                r.Cells(item_precioUnitario.Index).Value = frm.ValorUnitario
                                r.Cells(item_porcRetenido.Index).Value = frm.PorcentajeRetenido
                                calcularSubtotal(r)
                            Else
                                r.Cells(item_concepto.Index).Value = Nothing
                            End If
                        End If
                    End If
                ElseIf e.ColumnIndex = item_cantidadOrden.Index Then
                    calcularSubtotal(r)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwMovimiento_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwMovimiento.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwMovimiento.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    If r.Cells(item_concepto.Index).Value IsNot Nothing Then
                        Dim mConcepto As New ClsConceptos
                        Dim conc As concepto = mConcepto.TraerxId(r.Cells(item_concepto.Index).Value)
                        If conc.ConceptoEspecial Then
                            menu.Items.Add("Modificar información")
                        Else
                            menu.Items.Add("Cambiar precio", Nothing, AddressOf cambiarPrecio)
                        End If
                    End If
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwMovimiento.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwMovimiento.CurrentCell.ColumnIndex

            If dwMovimiento.Columns(columnIndex) Is item_cantidadOrden Or dwMovimiento.Columns(columnIndex) Is item_precioCliente Then
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
            Dim columnIndex As Integer = dwMovimiento.CurrentCell.ColumnIndex

            If dwMovimiento.Columns(columnIndex) Is item_cantidadOrden Or dwMovimiento.Columns(columnIndex) Is item_precioCliente Then
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
End Class