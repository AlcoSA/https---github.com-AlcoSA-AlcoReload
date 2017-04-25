Imports ReglasNegocio

Public Class frmListaPrecios
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private loadCompleted As Boolean = False
    Private curid As Integer = 0
    Private Sep As Char
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Propiedades"
    Public Property Operacion() As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarProveedores()
        Try
            Dim mProveedor As New ClsProveedores
            Dim listProveedores As List(Of proveedores) = mProveedor.TraerTodos().Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
            cmbProveedores.DisplayMember = "nombreProveedor"
            cmbProveedores.DatosVisibles = {"nombreProveedor", "nombreEstablecimiento"}
            cmbProveedores.ValueMember = "Id"
            cmbProveedores.DataSource = listProveedores
            cmbProveedores.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarConceptos()
        Try
            dwConceptos.Rows.Clear()
            Dim mConcepto As New ClsConceptos
            Dim listConceptos As List(Of concepto) = mConcepto.TraerDisponiblesxProveedor(cmbProveedores.SelectedValue)
            For Each conc As concepto In listConceptos
                Dim r As DataGridViewRow = dwConceptos.Rows(dwConceptos.Rows.Add())
                r.Cells(conc_id.Index).Value = conc.Id
                r.Cells(conc_concepto.Index).Value = conc.Concepto
                r.Cells(conc_descripcion.Index).Value = conc.Descripcion
                r.Cells(conc_unidadMedida.Index).Value = conc.UnidadMedida
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarPrecios(Optional ByRef idProv As Integer = 0)
        Try
            Dim mPrecioInstalacion As New ClsPreciosInstalacion
            Dim lista As New List(Of precioInstalacion)
            If idProv <> 0 Then
                lista = mPrecioInstalacion.TraerxIdProveedor(idProv)
            Else
                lista = mPrecioInstalacion.TraerTodos()

            End If
            dwPrecios.Rows.Clear()
            For Each pre As precioInstalacion In lista
                Dim r As DataGridViewRow = dwPrecios.Rows(dwPrecios.Rows.Add())
                r.Cells(id.Index).Value = pre.Id
                r.Cells(fechaCreacion.Index).Value = pre.FechaCreacion
                r.Cells(usuarioCreacion.Index).Value = pre.UsuarioCreacion
                r.Cells(idProveedor.Index).Value = pre.IdProveedor
                r.Cells(proveedor.Index).Value = pre.Proveedor
                r.Cells(idConcepto.Index).Value = pre.IdConcepto
                r.Cells(concepto.Index).Value = pre.Concepto
                r.Cells(unidadMedida.Index).Value = pre.UnidadMedida
                r.Cells(precio.Index).Value = pre.Precio
                r.Cells(porcRetenido.Index).Value = pre.PorcRetenido
                r.Cells(usuarioModi.Index).Value = pre.UsuarioModificacion
                r.Cells(fechaModi.Index).Value = pre.FechaModificacion
                r.Cells(idEstado.Index).Value = pre.IdEstado
                r.Cells(estado.Index).Value = pre.Estado
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validacion() As Boolean
        Try
            Dim conteo As Integer = 0
            Dim vacios As Integer = 0
            Dim noNumericos As Integer = 0
            For Each r As DataGridViewRow In dwConceptos.Rows
                If Convert.ToBoolean(r.Cells(conc_seleccion.Index).EditedFormattedValue) = True Then
                    conteo += 1
                    If r.Cells(conc_precio.Index).Value Is Nothing Or r.Cells(conc_precio.Index).Value Is String.Empty Then
                        vacios += 1
                    End If
                    If r.Cells(conc_porcRetenido.Index).Value Is Nothing Or r.Cells(conc_porcRetenido.Index).Value Is String.Empty Then
                        vacios += 1
                    End If
                    If Not IsNumeric(r.Cells(conc_precio.Index).Value) Then
                        noNumericos += 1
                    End If
                    If Not IsNumeric(r.Cells(conc_porcRetenido.Index).Value) Then
                        noNumericos += 1
                    End If
                End If
            Next
            If conteo = 0 Then
                ErrorProvider.SetError(dwConceptos, "No se ha seleccionado ningún concepto")
                Return False
            End If
            ErrorProvider.Clear()

            If vacios > 0 Then
                ErrorProvider.SetError(dwConceptos, "Uno o más conceptos seleccionados tienen campos vacíos")
                Return False
            End If
            ErrorProvider.Clear()

            If noNumericos > 0 Then
                ErrorProvider.SetError(dwConceptos, "Uno o más campos contienen datos no numéricos")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwPrecios.SelectedRows(0)
            Dim frm As New frmModificarPrecio
            frm.Id = r.Cells(id.Index).Value
            frm.Proveedor = r.Cells(proveedor.Index).Value
            frm.Concepto = r.Cells(concepto.Index).Value
            frm.Precio = r.Cells(precio.Index).Value
            frm.PorcentajeRetenido = r.Cells(porcRetenido.Index).Value
            frm.IdEstado = r.Cells(idEstado.Index).Value
            If frm.ShowDialog() = DialogResult.OK Then
                cargarConceptos()
                cargarPrecios(cmbProveedores.SelectedValue)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmListaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarProveedores()
            cargarPrecios()
            dwConceptos.Rows.Clear()
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwConceptos.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwConceptos.CurrentCell.ColumnIndex

            If dwConceptos.Columns(columnIndex) Is conc_precio Then
                Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                RemoveHandler dText.KeyPress, AddressOf dText_KeyPress
                AddHandler dText.KeyPress, AddressOf dText_KeyPress
            End If

            If dwConceptos.Columns(columnIndex) Is conc_porcRetenido Then
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
            Dim columnIndex As Integer = dwConceptos.CurrentCell.ColumnIndex

            If dwConceptos.Columns(columnIndex) Is conc_precio Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
            End If

            If dwConceptos.Columns(columnIndex) Is conc_porcRetenido Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
            End If
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
            dwConceptos.EndEdit()

            If Validacion() Then
                Dim mPrecioInstalacion As New ClsPreciosInstalacion
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    For Each r As DataGridViewRow In dwConceptos.Rows
                        If Convert.ToBoolean(r.Cells(conc_seleccion.Index).EditedFormattedValue) = True Then
                            mPrecioInstalacion.Insertar(My.Settings.UsuarioActivo, cmbProveedores.SelectedValue, r.Cells(conc_id.Index).Value,
                                                        r.Cells(conc_precio.Index).Value, r.Cells(conc_porcRetenido.Index).Value, ClsEnums.Estados.ACTIVO)
                        End If
                    Next
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmListaPrecios_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            cmbProveedores.SelectedItem = Nothing
            dwConceptos.Rows.Clear()
            cargarPrecios()
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbProveedores_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProveedores.SelectedValueChanged
        Try
            If loadCompleted Then
                cargarConceptos()
                cargarPrecios(cmbProveedores.SelectedValue)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwPrecios_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwPrecios.CellMouseClick, dwPrecios.CellMouseDoubleClick
        Try
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                dwPrecios.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class