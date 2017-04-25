Imports DatagridTreeView
Imports ReglasNegocio

Public Class frmCuentaCobroContrato
#Region "Variables"
    Private _idOrdenTrabajo As Integer
    Private _idContrato As Integer
    Private _obra As String
    Private _idProveedor As Integer
    Private _proveedor As String
    Private mostrandoPaneles As Boolean = False
    Private loadCompleted As Boolean = False
    Private Sep As Char
#End Region
#Region "Propiedades"
    Public Property IdOrdenTrabajo() As Integer
        Get
            Return _idOrdenTrabajo
        End Get
        Set(ByVal value As Integer)
            _idOrdenTrabajo = value
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
    Public Property obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
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
#End Region
#Region "Procedimientos"
    Private Sub cargarDocumentos()
        Try
            Dim mDocuento As New ClsDocumentosOT
            Dim list As List(Of documentoOT) = mDocuento.TraerTodos().Where(Function(a) a.Prefijo = "CCM" Or a.Prefijo = "CCB").ToList
            cmbDocumentos.DisplayMember = "Prefijo"
            cmbDocumentos.ValueMember = "Id"
            cmbDocumentos.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbDocumentos.DataSource = list
            cmbDocumentos.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarItemsOP()
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
    Private Sub cargarEncargados(idProveedor As Integer)
        Try
            Dim mEncargado As New ClsEncargados
            Dim list As List(Of encargado) = mEncargado.TraerxIdProveedor(idProveedor)
            cmbEncargado.DisplayMember = "NombreEncargado"
            cmbEncargado.ValueMember = "Id"
            cmbEncargado.DataSource = list
            cmbEncargado.SelectedItem = Nothing
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
    Private Sub cargarOrdenesTrabajo()
        Try
            Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
            Dim listConceptos As List(Of conceptosOT) = mMovitoOrdenTrabajo.TraerConceptos(_idContrato, _idProveedor)
            For Each con As conceptosOT In listConceptos
                Dim ndpd As DataGridViewTreeNode = dwOrdenesTrabajo.Nodes.Add()
                ndpd.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                ndpd.Cells(ot_id.Index).Value = 0
                ndpd.Cells(ot_idConcepto.Index).Value = con.IdConcepto
                ndpd.Cells(ot_concepto.Index).Value = con.Concepto
                ndpd.Cells(ot_undMedida.Index).Value = con.UnidadMedida
                ndpd.Cells(ot_precioUnitario.Index).Value = con.PrecioUnitario
                ndpd.Cells(ot_idTipoObra.Index).Value = con.IdTipoObra
                ndpd.Cells(ot_tipoObra.Index).Value = con.TipoObra
                Dim listItemsOT As List(Of movitoOrdenTrabajo) = mMovitoOrdenTrabajo.TraerxIdConcepto(_idContrato, _idProveedor, con.IdConcepto)
                Dim cantTotal As Decimal = 0
                Dim cantDisponible As Decimal = 0
                For Each item As movitoOrdenTrabajo In listItemsOT
                    Dim nd As DataGridViewRow = ndpd.Nodes.Add()
                    nd.Cells(ot_id.Index).Value = item.Id
                    nd.Cells(ot_idConcepto.Index).Value = item.IdConcepto
                    nd.Cells(ot_concepto.Index).Value = item.Concepto
                    nd.Cells(ot_descripcion.Index).Value = item.Descripcion
                    nd.Cells(ot_cantTotal.Index).Value = item.CantidadTotal
                    nd.Cells(ot_cantDisponible.Index).Value = item.CantidadDisponible
                    nd.Cells(ot_cantCuenta.Index).Value = 0
                    nd.Cells(ot_undMedida.Index).Value = item.UnidadMedida
                    nd.Cells(ot_precioUnitario.Index).Value = item.Precio
                    nd.Cells(ot_subtotal.Index).Value = 0
                    nd.Cells(ot_porcRetenido.Index).Value = item.PorcentajeRetenido
                    nd.Cells(ot_idTipoObra.Index).Value = item.IdTipoObra
                    nd.Cells(ot_tipoObra.Index).Value = item.TipoObra
                    nd.Cells(ot_facturable.Index).Value = item.Facturable
                    nd.Cells(ot_notas.Index).Value = item.Notas
                    cantTotal += item.CantidadTotal
                    cantDisponible += item.CantidadDisponible
                Next
                ndpd.Cells(ot_cantTotal.Index).Value = cantTotal
                ndpd.Cells(ot_cantDisponible.Index).Value = cantDisponible
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If cmbDocumentos.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbDocumentos, "Debe seleccionar el documento")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbEncargado.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbEncargado, "Debe seleccionar el encargado")
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

            Dim conteoDigitados As Integer = 0
            Dim conteoSuperiores As Integer = 0
            For Each ndpd As DataGridViewTreeNode In dwOrdenesTrabajo.Nodes
                For Each nod As DataGridViewTreeNode In ndpd.Nodes
                    If CDec(nod.Cells(ot_cantCuenta.Index).Value) > 0 Then
                        conteoDigitados += 1
                    End If
                    If CDec(nod.Cells(ot_cantCuenta.Index).Value) > CDec(nod.Cells(ot_cantDisponible.Index).Value) Then
                        conteoSuperiores += 1
                    End If
                Next
            Next

            If conteoSuperiores > 0 Then
                ErrorProvider.SetError(lblErrorListaOt, "Uno o más cantidades son mayores a sus disponibles")
                Return False
            End If
            ErrorProvider.Clear()

            If conteoDigitados = 0 Then
                ErrorProvider.SetError(lblErrorListaOt, "No se ha indicado la cantidad de cuenta de cobro en ningún item")
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
#Region "Funcionamiento paneles"
    Private Sub MostrarPaneles()
        Try
            mostrandoPaneles = True
            If PanelOrdenTrabajo.Tag Is "A" Or PanelOrdenTrabajo.Tag Is "V" Then
                spMovimiento.Visible = True
                spMovimiento.Panel1Collapsed = False
                If PanelItemsOP.Tag Is "A" Or PanelItemsOP.Tag Is "V" Then
                    spMovimiento.Panel2Collapsed = False
                Else
                    spMovimiento.Panel2Collapsed = True
                End If
            Else
                If PanelItemsOP.Tag Is "A" Or PanelItemsOP.Tag Is "V" Then
                    spMovimiento.Visible = True
                    spMovimiento.Panel1Collapsed = True
                    spMovimiento.Panel2Collapsed = False
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
            If PanelItemsOP.Tag Is "D" Then
                PanelItemsOP.Tag = "V"
                MostrarPaneles()
                PanelItemsOP.Focus()
            Else
                PanelItemsOP.Tag = "D"
                MostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAnclajeItemsOP_Click(sender As Object, e As EventArgs) Handles btnAnclajeItemsOP.Click
        Try
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
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub spMovimiento_Panel2_Leave(sender As Object, e As EventArgs) Handles spMovimiento.Panel2.Leave
        Try
            If PanelItemsOP.Tag IsNot "A" Then
                PanelItemsOP.Tag = "D"
                If mostrandoPaneles = False Then
                    MostrarPaneles()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwOrdenesTrabajo.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwOrdenesTrabajo.CurrentCell.ColumnIndex

            If dwOrdenesTrabajo.Columns(columnIndex) Is ot_cantCuenta Then
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
            Dim columnIndex As Integer = dwOrdenesTrabajo.CurrentCell.ColumnIndex

            If dwOrdenesTrabajo.Columns(columnIndex) Is ot_cantCuenta Then
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
    Private Sub frmCuentaCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtObra.Text = _obra
            txtProveedor.Text = _proveedor
            cargarEncargados(_idProveedor)
            cargarDocumentos()
            cargarOrdenesTrabajo()
            cargarItemsOP()
            cargarTotales()
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            dwOrdenesTrabajo.EndEdit()
            If validacion() Then
                Dim mCuentaCobro As New ClsCuentaCobro
                Dim idCCobro As Integer = mCuentaCobro.Insertar(My.Settings.UsuarioActivo, _idContrato, _idProveedor, cmbEncargado.SelectedValue,
                                                                cmbDocumentos.SelectedValue, CInt(lblConsecutivo.Text), ClsEnums.TipoCuentaCobro.DESDE_OT,
                                                                "--", "--", "--", "--", "--", "--", String.Empty, txtObservaciones.Text, ClsEnums.Estados.ACTIVO,
                                                                ClsEnums.Estados.SIN_IMPRIMIR)
                Dim mMovitoCuentaCobro As New ClsMovitoCuentaCobro
                Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
                For Each ndpd As DataGridViewTreeNode In dwOrdenesTrabajo.Nodes
                    For Each nod As DataGridViewTreeNode In ndpd.Nodes
                        If CInt(nod.Cells(ot_cantCuenta.Index).Value) <> 0 Then
                            mMovitoCuentaCobro.Insertar(My.Settings.UsuarioActivo, idCCobro, nod.Cells(ot_id.Index).Value,
                                                        nod.Cells(ot_precioUnitario.Index).Value, nod.Cells(ot_cantCuenta.Index).Value,
                                                        nod.Cells(ot_porcRetenido.Index).Value, nod.Cells(ot_undMedida.Index).Value,
                                                        nod.Cells(ot_facturable.Index).Value, 0, "--", 0, 0, ClsEnums.Estados.ACTIVO)
                            mMovitoOrdenTrabajo.ActualizarEstadoById(nod.Cells(ot_id.Index).Value, ClsEnums.Estados.GENERADO)
                        End If
                    Next
                Next
                Dim mDocumento As New ClsDocumentosOT
                mDocumento.ActualizarConsecutivo(lblConsecutivo.Text, cmbDocumentos.SelectedValue)
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbEncargado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEncargado.SelectedValueChanged
        Try
            If loadCompleted Then
                Dim mCuentaCobro As New ClsCuentaCobro
                lblCuentasRealizadas.Text = mCuentaCobro.TraerNumeroCuentasRealizadas(_idContrato, _idProveedor, cmbEncargado.SelectedValue)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbDocumentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDocumentos.SelectedValueChanged
        Try
            If loadCompleted Then
                Dim docto As documentoOT = cmbDocumentos.SelectedItem
                lblConsecutivo.Text = String.Empty
                lblConsecutivo.Text = docto.ConsecutivoProximo
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwOrdenesTrabajo_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dwOrdenesTrabajo.CellEnter
        Try
            If e.RowIndex >= 0 Then
                Dim nodo As DataGridViewTreeNode = DirectCast(dwOrdenesTrabajo.Rows(e.RowIndex), DataGridViewTreeNode)
                If nodo.Level <> 1 Then
                    If e.ColumnIndex = ot_cantCuenta.Index Then
                        nodo.Cells(ot_cantCuenta.Index).ReadOnly = False
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwOrdenesTrabajo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwOrdenesTrabajo.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim nodo As DataGridViewTreeNode = DirectCast(dwOrdenesTrabajo.Rows(e.RowIndex), DataGridViewTreeNode)
                If nodo.Level <> 1 Then
                    If e.ColumnIndex = ot_cantCuenta.Index Then
                        If CInt(nodo.Cells(ot_cantCuenta.Index).Value) > CDec(nodo.Cells(ot_cantDisponible.Index).Value) Then
                            nodo.Cells(ot_cantCuenta.Index).Value = 0
                        Else
                            nodo.Cells(ot_subtotal.Index).Value = CDec(nodo.Cells(ot_cantCuenta.Index).Value) * CDec(nodo.Cells(ot_precioUnitario.Index).Value)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class