Imports DatagridTreeView
Imports ReglasNegocio

Public Class frmPagoRetenidos
#Region "Variables"
    Private loadCompleted As Boolean = False
    Private Sep As Char
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub cargarDocumentos()
        Try
            Dim mDocumento As New ClsDocumentosOT
            Dim list As List(Of documentoOT) = mDocumento.TraerTodos().Where(Function(a) a.Prefijo.Contains("RI")).ToList
            cmbDocumentos.DisplayMember = "Prefijo"
            cmbDocumentos.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbDocumentos.ValueMember = "Id"
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
    Private Sub cargarGrid()
        Try
            dwItems.Nodes.Clear()
            Dim mCuentaCobro As New ClsCuentaCobro
            Dim listObras As List(Of obrasCuentaCobro) = mCuentaCobro.TraerObras(cmbProveedor.SelectedValue, cmbEncargado.SelectedValue)
            For Each obra As obrasCuentaCobro In listObras
                Dim ndpd As DataGridViewTreeNode = dwItems.Nodes.Add()
                ndpd.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                ndpd.Cells(col_proveedor.Index).Value = obra.Proveedor
                ndpd.Cells(col_encargado.Index).Value = obra.Encargado
                ndpd.Cells(col_codigoObra.Index).Value = obra.CodigoObra
                ndpd.Cells(col_obraFecha.Index).Value = obra.Obra
                ndpd.Cells(col_vendedor.Index).Value = obra.Vendedor
                Dim TextArray() As String = Split(obra.CodigoObra, "-")
                Dim listCCobro As List(Of obrasCuentaCobro) = mCuentaCobro.TraerxObra(cmbProveedor.SelectedValue,
                                                                                      cmbEncargado.SelectedValue, TextArray(0), TextArray(1))
                Dim totalCuentas As Decimal = 0
                Dim totalRetenido As Decimal = 0
                Dim totalPagado As Decimal = 0
                Dim totalPendiente As Decimal = 0
                Dim conteo As Integer = 0
                For Each Ccobro As obrasCuentaCobro In listCCobro
                    Dim nd As DataGridViewTreeNode = ndpd.Nodes.Add()
                    nd.Cells(col_id.Index).Value = Ccobro.IdCuentaCobro
                    nd.Cells(col_idDocumento.Index).Value = Ccobro.IdDocumento
                    nd.Cells(col_documento.Index).Value = Ccobro.Documento
                    nd.Cells(col_consecutivo.Index).Value = Ccobro.Consecutivo
                    nd.Cells(col_obraFecha.Index).Value = Ccobro.Fecha.ToShortDateString()
                    nd.Cells(col_totalCuentas.Index).Value = Ccobro.TotalCuentas
                    totalCuentas += Ccobro.TotalCuentas
                    nd.Cells(col_retenido.Index).Value = Ccobro.Retenido
                    totalRetenido += Ccobro.Retenido
                    nd.Cells(col_valorPagado.Index).Value = Ccobro.ValorPagado
                    totalPagado += Ccobro.ValorPagado
                    nd.Cells(col_valorPendiente.Index).Value = Ccobro.Retenido - Ccobro.ValorPagado
                    totalPendiente += CDec(nd.Cells(col_valorPendiente.Index).Value)
                    nd.Cells(col_valorPagar.Index).Value = 0
                    nd.Cells(col_directa.Index).Value = Ccobro.CuentaDirecta
                    conteo += 1
                Next
                ndpd.Cells(col_totalCuentas.Index).Value = totalCuentas
                ndpd.Cells(col_retenido.Index).Value = totalRetenido
                ndpd.Cells(col_valorPagado.Index).Value = totalPagado
                ndpd.Cells(col_valorPendiente.Index).Value = totalPendiente
                ndpd.Cells(col_valorPagar.Index).Value = "--"
                If conteo = 0 Then
                    dwItems.Nodes.Remove(ndpd)
                End If
            Next
            cargarTotales()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTotales()
        Try
            Dim totalPagar As Decimal = 0
            Dim totalPagado As Decimal = 0
            For Each ndpd As DataGridViewTreeNode In dwItems.Nodes
                totalPagado += CDec(ndpd.Cells(col_valorPagado.Index).Value)
                For Each nd As DataGridViewTreeNode In ndpd.Nodes
                    If CBool(nd.Cells(col_insertar.Index).Value) = True Then
                        totalPagar += CDec(nd.Cells(col_valorPagar.Index).Value)
                    End If
                Next
            Next
            lblValorPagar.Text = totalPagar.ToString("N2")
            lblTotalPagado.Text = totalPagado.ToString("N2")
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

            If lblConsecutivo.Text = String.Empty Then
                ErrorProvider.SetError(lblConsecutivo, "No hay nigún consecutivo")
                Return False
            End If
            ErrorProvider.Clear()

            If Not IsNumeric(lblConsecutivo.Text) Then
                ErrorProvider.SetError(lblConsecutivo, "El consecutivo no es válido")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbProveedor.Items Is Nothing Then
                ErrorProvider.SetError(cmbProveedor, "Debe seleccionar un proveedor")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbEncargado.Items Is Nothing Then
                ErrorProvider.SetError(cmbEncargado, "Debe seleccionar un encargado")
                Return False
            End If
            ErrorProvider.Clear()

            Dim conteo As Integer = 0
            For Each ndpd As DataGridViewTreeNode In dwItems.Nodes
                For Each nod As DataGridViewTreeNode In ndpd.Nodes
                    If CBool(nod.Cells(col_insertar.Index).Value) = True Then
                        conteo += 1
                    End If
                Next
            Next
            If conteo = 0 Then
                MessageBox.Show("No ha ingresado ningún valor a pagar")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub frmPagoRetenidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            loadCompleted = False
            lblConsecutivo.Text = String.Empty
            cargarDocumentos()
            cargarProveedores()
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
    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
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
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            btnBuscar.Focus()
            dwItems.EndEdit()
            If validacion() Then
                'MsgBox("Guardando")
                Dim mPagoRetenidos As New ClsPagoRetenidos
                Dim idPagoRetenido As Integer = mPagoRetenidos.Insertar(My.Settings.UsuarioActivo, cmbDocumentos.SelectedValue, CInt(lblConsecutivo.Text),
                                                                        cmbProveedor.SelectedValue, cmbEncargado.SelectedValue, ClsEnums.Estados.ACTIVO,
                                                                        ClsEnums.Estados.SIN_IMPRIMIR)
                Dim mDocumento As New ClsDocumentosOT
                mDocumento.ActualizarConsecutivo(lblConsecutivo.Text, cmbDocumentos.SelectedValue)
                Dim mMovitoPagoRetenidos As New ClsMovitoPagoRetenido
                For Each ndpd As DataGridViewTreeNode In dwItems.Nodes
                    For Each nod As DataGridViewTreeNode In ndpd.Nodes
                        If CBool(nod.Cells(col_insertar.Index).Value) = True Then
                            mMovitoPagoRetenidos.Insertar(My.Settings.UsuarioActivo, idPagoRetenido, nod.Cells(col_id.Index).Value, nod.Cells(col_valorPagar.Index).Value, ClsEnums.Estados.ACTIVO)
                        End If
                    Next
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dwItems.Nodes.Clear()
                frmPagoRetenidos_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            cmbDocumentos.SelectedItem = Nothing
            lblConsecutivo.Text = String.Empty
            cmbProveedor.SelectedItem = Nothing
            cmbEncargado.SelectedItem = Nothing
            dwItems.Nodes.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbDocumentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDocumentos.SelectedValueChanged
        Try
            If loadCompleted And cmbDocumentos.SelectedItem IsNot Nothing Then
                Dim docto As documentoOT = cmbDocumentos.SelectedItem
                lblConsecutivo.Text = docto.ConsecutivoProximo
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedValueChanged
        Try
            If loadCompleted And cmbProveedor.SelectedItem IsNot Nothing Then
                dwItems.Nodes.Clear()
                cargarEncargados()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbEncargado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEncargado.SelectedValueChanged
        Try
            If loadCompleted And cmbEncargado.SelectedItem IsNot Nothing Then
                dwItems.Nodes.Clear()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            cargarGrid()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEnter
        Try
            If e.RowIndex >= 0 Then
                Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
                If nodo.Level <> 1 Then
                    If e.ColumnIndex = col_valorPagar.Index Then
                        nodo.Cells(col_valorPagar.Index).ReadOnly = False
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is col_valorPagar Then
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
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is col_valorPagar Then
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

    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
                If nodo.Level <> 1 Then
                    If e.ColumnIndex = col_valorPagar.Index Then
                        If nodo.Cells(col_valorPagar.Index).Value Is Nothing Then
                            nodo.Cells(col_valorPagar.Index).Value = 0
                            Return
                        End If
                        If nodo.Cells(col_valorPagar.Index).Value.ToString() = String.Empty Then
                            nodo.Cells(col_valorPagar.Index).Value = 0
                            Return
                        End If

                        If CDec(nodo.Cells(col_valorPagar.Index).Value) > CDec(nodo.Cells(col_valorPendiente.Index).Value) Then
                            nodo.Cells(col_valorPagar.Index).Value = 0
                        End If
                        If CDec(nodo.Cells(col_valorPagar.Index).Value) > 0 Then
                            nodo.Cells(col_insertar.Index).Value = True
                        Else
                            nodo.Cells(col_insertar.Index).Value = False
                        End If
                        cargarTotales()
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class