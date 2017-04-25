Imports ReglasNegocio

Public Class FrmVariosCostos
#Region "Variables globales"
    Private mCostoAccesorio As ClsCostoAccesorio
    Private mCostoOtros As ClsCostoOtrosArticulos
    Private mCostoTrabajos As ClsCostoTrabajoItem

    Private Sep As Char
    Private currentDw As DataGridView
    Private currentTabPage As TabPage
    Private loadCompleted As Boolean
#End Region
#Region "Procedimientos globales"
    Private Sub recalculoPorcentaje(nud As NumericUpDown, dw As DataGridView)
        Try
            For Each r As DataGridViewRow In dw.Rows
                Dim valor As Decimal = CDec(r.Cells(dw.Columns(8).Index).Value)
                Dim porcent As Decimal = nud.Value / 100
                r.Cells(dw.Columns(9).Index).Value = (valor * porcent) + valor
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Rec_dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Otr_Rec_dwItems.CellMouseClick,
            Acc_Rec_dwItems.CellMouseClick, Tra_Rec_dwItems.CellMouseClick
        Try
            Dim container As TabPage = DirectCast(sender, DataGridView).Parent.Parent
            Dim gbVersionBase As New GroupBox
            Dim gbPorcentaje As New GroupBox
            For Each ctrl As Control In container.Controls
                If TypeOf (ctrl) Is GroupBox Then
                    If ctrl.Tag.ToString().Contains("_version") Then
                        gbVersionBase = ctrl
                    ElseIf ctrl.Tag.ToString().Contains("_porcent") Then
                        gbPorcentaje = ctrl
                    End If
                End If
            Next

            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                currentDw = DirectCast(sender, DataGridView)
                currentTabPage = container
                For Each r As DataGridViewRow In currentDw.Rows
                    r.Selected = False
                Next
                currentDw.Rows(e.RowIndex).Selected = True

                Dim menu As New ContextMenuStrip
                If gbPorcentaje.Enabled = False Then
                    menu.Items.Add("Recalcular con porcentaje", Nothing, AddressOf habilitarRecalculoPorcentaje)
                Else
                    menu.Items.Add("Finalizar recalculado", Nothing, AddressOf habilitarRecalculoPorcentaje)
                End If

                If gbVersionBase.Enabled = False Then
                    menu.Items.Add("Cambiar versión de costo base", Nothing, AddressOf habilitarCambioVersionBase)
                Else
                    menu.Items.Add("Reestablacer versión de costo base", Nothing, AddressOf habilitarCambioVersionBase)
                End If

                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub habilitarRecalculoPorcentaje()
        Try
            Dim gbPorc As New GroupBox
            For Each ctrl As Control In currentTabPage.Controls
                If TypeOf (ctrl) Is GroupBox And ctrl.Tag IsNot Nothing Then
                    If ctrl.Tag.ToString() = currentDw.Tag.ToString() & "_porcent" Then
                        gbPorc = ctrl
                        Exit For
                    End If
                End If
            Next
            If gbPorc.Enabled = True Then
                For Each ct As Control In gbPorc.Controls
                    If TypeOf (ct) Is NumericUpDown Then
                        DirectCast(ct, NumericUpDown).Value = 0
                    End If
                Next
                gbPorc.Enabled = False
            Else
                gbPorc.Enabled = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub habilitarCambioVersionBase()
        Try
            Dim gbVer As New GroupBox
            For Each ctrl As Control In currentTabPage.Controls
                If TypeOf (ctrl) Is GroupBox And ctrl.Tag IsNot Nothing Then
                    If ctrl.Tag.ToString() = currentDw.Tag.ToString() & "_version" Then
                        gbVer = ctrl
                        Exit For
                    End If
                End If
            Next
            If gbVer.Enabled = True Then
                For Each ct As Control In gbVer.Controls
                    If TypeOf (ct) Is ComboBox Then
                        DirectCast(ct, ComboBox).SelectedItem = Nothing
                    End If
                Next
                gbVer.Enabled = False
            Else
                gbVer.Enabled = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Acc_Rec_dwItems.EditingControlShowing,
        Otr_Rec_dwItems.EditingControlShowing, Tra_Rec_dwItems.EditingControlShowing
        Try
            currentDw = DirectCast(sender, DataGridView)
            Dim columnIndex As Integer = currentDw.CurrentCell.ColumnIndex
            If currentDw.Columns(columnIndex).Name.Contains("nuevoCosto") Then
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
            Dim columnIndex As Integer = currentDw.CurrentCell.ColumnIndex

            If currentDw.Columns(columnIndex).Name.Contains("nuevoCosto") Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then e.Handled = True
                If Char.IsPunctuation(e.KeyChar) Then
                    If e.KeyChar <> "."c Then
                        e.Handled = True
                    Else
                        If currentDw.CurrentRow.Cells(columnIndex).EditedFormattedValue.ToString().Contains(".") Then
                            e.Handled = True
                        Else
                            e.Handled = False
                        End If
                    End If
                End If
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub AgregarActualizacion(dwOrigen As DataGridView, dwDestino As DataGridView)
        Try
            Dim r1 As DataGridViewRow = dwOrigen.CurrentRow
            Dim r2 As DataGridViewRow = dwDestino.Rows(dwDestino.Rows.Add())
            For Each col As DataGridViewColumn In dwOrigen.Columns
                r2.Cells(col.Index).Value = r1.Cells(col.Index).Value
            Next
            dwOrigen.Rows.Remove(r1)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "ACCESORIOS"
    Private Sub cargarControlesAccesorios()
        Try
            mCostoAccesorio = New ClsCostoAccesorio
            Dim maxVersionAccesorios As Integer = mCostoAccesorio.TraerMaxVersion()
            cargarAccesoriosRecalculo(maxVersionAccesorios)

            cargarVersionesAccesorio()

            Dim mArticulo As New ClsArticulos
            mArticulo.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.ACCESORIOS, ClsEnums.Estados.ACTIVO, Acc_Ing_itAccesorio.TablaFuente)
            mArticulo.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.ACCESORIOS, ClsEnums.Estados.ACTIVO, Acc_Act_itAccesorio.TablaFuente)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVersionesAccesorio()
        Try
            mCostoAccesorio = New ClsCostoAccesorio
            Dim maxVersion As Integer = mCostoAccesorio.TraerMaxVersion()
            Dim listVersiones As New List(Of Integer)
            For ver = 1 To maxVersion
                listVersiones.Add(ver)
            Next
            Acc_Rec_cmbVersion.DataSource = listVersiones
            Acc_Rec_cmbVersion.SelectedItem = Nothing

            Acc_Ing_cmbVersion.DataSource = listVersiones
            Acc_Ing_cmbVersion.SelectedItem = Nothing

            listVersiones.Insert(0, 0)
            Acc_Act_cmbVersion.DataSource = listVersiones
            Acc_Act_cmbVersion.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Recalculo"
    Private Sub cargarAccesoriosRecalculo(version As Integer)
        Try
            mCostoAccesorio = New ClsCostoAccesorio
            mCostoAccesorio.TraerxVersion(version, Acc_Rec_dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Rec_btnCambiarVersionBase_Click(sender As Object, e As EventArgs) Handles Acc_Rec_btnCambiarVersionBase.Click
        Try
            cargarAccesoriosRecalculo(Acc_Rec_cmbVersion.SelectedItem)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Rec_btnAceptar_Click(sender As Object, e As EventArgs) Handles Acc_Rec_btnAceptar.Click
        Try
            recalculoPorcentaje(Acc_Rec_nudPorcent, Acc_Rec_dwItems)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Rec_btnRecalcular_Click(sender As Object, e As EventArgs) Handles Acc_Rec_btnRecalcular.Click
        Try
            If MessageBox.Show("Se van a recalcular los costos de accesorios. ¿Desea continuar?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                mCostoAccesorio = New ClsCostoAccesorio
                For Each r As DataGridViewRow In Acc_Rec_dwItems.Rows
                    mCostoAccesorio.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(r.Cells(idAccesorio.Index).Value),
                                            Convert.ToInt32(r.Cells(nuevaVersion.Index).Value), Convert.ToDecimal(r.Cells(nuevoCosto.Index).Value))
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim maxVersionAccesorios As Integer = mCostoAccesorio.TraerMaxVersion()
                cargarAccesoriosRecalculo(maxVersionAccesorios)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Inserción individual"
#Region "Procedimientos"
    Private Sub Acc_Ing_eliminar()
        Try
            Dim r As DataGridViewRow = Acc_Ing_dwItems.SelectedRows(0)
            Acc_Ing_dwItems.Rows.Remove(r)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionAgregarAccesoriosInsercion() As Boolean
        Try
            If Acc_Ing_itAccesorio.selected_item Is Nothing Then
                ErrorProvider.SetError(Acc_Ing_itAccesorio, "Seleccione el accesorio")
                Return False
            End If
            ErrorProvider.Clear()

            If Acc_Ing_cmbVersion.SelectedItem Is Nothing Then
                ErrorProvider.SetError(Acc_Ing_cmbVersion, "Seleccione la versión")
                Return False
            End If
            ErrorProvider.Clear()

            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In Acc_Ing_dwItems.Rows
                If CInt(r.Cells(Acc_Ing_col_idAccesorio.Index).Value) = CInt(Acc_Ing_itAccesorio.Seleted_rowid) And
                    CInt(r.Cells(Acc_Ing_col_version.Index).Value) = CInt(Acc_Ing_cmbVersion.SelectedItem) Then
                    conteo += 1
                End If
            Next
            If conteo > 0 Then
                MessageBox.Show("La combinación de items ya ha sido agregada")
                Return False
            End If

            mCostoAccesorio = New ClsCostoAccesorio
            If mCostoAccesorio.ExisteCosto(Acc_Ing_itAccesorio.Seleted_rowid, Acc_Ing_cmbVersion.SelectedItem) Then
                MessageBox.Show("La combinación ya existe en base de datos")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub Acc_Ing_dwItems_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Acc_Ing_dwItems.RowsAdded
        Try
            Acc_Ing_InsertarCostoAccesorios.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Ing_dwItems_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Acc_Ing_dwItems.RowsRemoved
        Try
            If Acc_Ing_dwItems.Rows.Count > 0 Then
                Acc_Ing_InsertarCostoAccesorios.Enabled = True
                Return
            End If
            Acc_Ing_InsertarCostoAccesorios.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Ing_btnAgregar_Click(sender As Object, e As EventArgs) Handles Acc_Ing_btnAgregar.Click
        Try
            If validacionAgregarAccesoriosInsercion() Then
                Dim r As DataGridViewRow = Acc_Ing_dwItems.Rows(Acc_Ing_dwItems.Rows.Add())
                r.Cells(Acc_Ing_col_idAccesorio.Index).Value = Acc_Ing_itAccesorio.Seleted_rowid
                r.Cells(Acc_Ing_col_referencia.Index).Value = Acc_Ing_itAccesorio.Text
                r.Cells(Acc_Ing_col_descripcion.Index).Value = Acc_Ing_itAccesorio.Value2
                r.Cells(Acc_Ing_col_version.Index).Value = Acc_Ing_cmbVersion.SelectedItem
                r.Cells(Acc_Ing_col_costo.Index).Value = Acc_Ing_nudCosto.Value

                Acc_Ing_itAccesorio.selected_item = Nothing
                Acc_Ing_itAccesorio.Text = String.Empty
                Acc_Ing_cmbVersion.SelectedItem = Nothing
                Acc_Ing_nudCosto.Value = 0
                ErrorProvider.Clear()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Ing_InsertarCostoAccesorios_Click(sender As Object, e As EventArgs) Handles Acc_Ing_InsertarCostoAccesorios.Click
        Try
            If Acc_Ing_dwItems.Rows.Count > 0 Then
                Dim mCostoAccesorio As New ClsCostoAccesorio

                Dim conteoExistentes As Integer = 0
                For Each r As DataGridViewRow In Acc_Ing_dwItems.Rows
                    If mCostoAccesorio.ExisteCosto(r.Cells(Acc_Ing_col_idAccesorio.Index).Value, r.Cells(Acc_Ing_col_version.Index).Value) Then
                        conteoExistentes += 1
                    End If
                Next
                If conteoExistentes > 0 Then
                    MessageBox.Show("Una o más combinaciones ya existen en base de datos")
                    Return
                End If
                For Each r As DataGridViewRow In Acc_Ing_dwItems.Rows
                    mCostoAccesorio.Insertar(My.Settings.UsuarioActivo, r.Cells(Acc_Ing_col_idAccesorio.Index).Value, r.Cells(Acc_Ing_col_version.Index).Value,
                                             r.Cells(Acc_Ing_col_costo.Index).Value)
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Acc_Ing_dwItems.Rows.Clear()
                Acc_Ing_itAccesorio.selected_item = Nothing
                Acc_Ing_itAccesorio.Text = String.Empty
                Acc_Ing_cmbVersion.SelectedItem = Nothing
                Acc_Ing_nudCosto.Value = 0
                ErrorProvider.Clear()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Ing_dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Acc_Ing_dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Acc_Ing_dwItems.Rows(e.RowIndex).Selected = True
                If e.Button = MouseButtons.Right Then
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Eliminar", Nothing, AddressOf Acc_Ing_eliminar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Actualización"
    Private Sub Acc_Act_btnBusqueda_Click(sender As Object, e As EventArgs) Handles Acc_Act_btnBusqueda.Click
        Try
            mCostoAccesorio = New ClsCostoAccesorio

            Dim listaOriginal As List(Of costoAccesorio) = mCostoAccesorio.TraerTodos()
            Dim lista As List(Of costoAccesorio) = listaOriginal

            If Acc_Act_itAccesorio.selected_item IsNot Nothing Then
                lista = listaOriginal
                lista = lista.Where(Function(a) a.idAccesorio = Acc_Act_itAccesorio.Seleted_rowid).ToList()
                If Acc_Act_cmbVersion.SelectedItem IsNot Nothing And CInt(Acc_Act_cmbVersion.SelectedValue) <> 0 Then
                    lista = lista.Where(Function(a) a.version = CInt(Acc_Act_cmbVersion.SelectedValue)).ToList()
                End If
            End If

            If Acc_Act_cmbVersion.SelectedItem IsNot Nothing And CInt(Acc_Act_cmbVersion.SelectedValue) <> 0 Then
                lista = listaOriginal
                lista = lista.Where(Function(a) a.version = CInt(Acc_Act_cmbVersion.SelectedValue)).ToList()
                If Acc_Act_itAccesorio.selected_item IsNot Nothing Then
                    lista = lista.Where(Function(a) a.idAccesorio = Acc_Act_itAccesorio.Seleted_rowid).ToList()
                End If
            End If

            Acc_Act_dwResultados.Rows.Clear()
            For Each cos As costoAccesorio In lista
                Dim conteo As Integer = 0
                For Each row As DataGridViewRow In Acc_Act_dwActualizar.Rows
                    If CInt(row.Cells(Acc_Act_Act_idAccesorio.Index).Value) = cos.idAccesorio And
                        CInt(row.Cells(Acc_Act_Act_version.Index).Value) = cos.version Then
                        conteo += 1
                    End If
                Next
                If conteo = 0 Then
                    Dim r As DataGridViewRow = Acc_Act_dwResultados.Rows(Acc_Act_dwResultados.Rows.Add())
                    r.Cells(Acc_Act_Busq_col_idAccesorio.Index).Value = cos.idAccesorio
                    r.Cells(Acc_Act_Busq_col_referencia.Index).Value = cos.referencia
                    r.Cells(Acc_Act_Busq_col_descripcion.Index).Value = cos.descripcion
                    r.Cells(Acc_Act_Busq_col_version.Index).Value = cos.version
                    r.Cells(Acc_Act_Busq_col_costo.Index).Value = cos.costo
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Act_Agregar_Click(sender As Object, e As EventArgs) Handles Acc_Act_Agregar.Click
        Try
            AgregarActualizacion(Acc_Act_dwResultados, Acc_Act_dwActualizar)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Act_Quitar_Click(sender As Object, e As EventArgs) Handles Acc_Act_Quitar.Click
        Try
            Acc_Act_dwActualizar.Rows.Remove(Acc_Act_dwActualizar.CurrentRow)
            Acc_Act_btnBusqueda_Click(Nothing, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Act_dwActualizar_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Acc_Act_dwActualizar.RowsAdded
        Try
            Acc_Act_btnActualizar.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Act_dwActualizar_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Acc_Act_dwActualizar.RowsRemoved
        Try

            If Acc_Act_dwActualizar.Rows.Count > 0 Then
                Acc_Act_btnActualizar.Enabled = True
                Return
            End If
            Acc_Act_btnActualizar.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Act_dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Acc_Act_dwActualizar.EditingControlShowing
        Try
            Dim columnIndex As Integer = Acc_Act_dwActualizar.CurrentCell.ColumnIndex

            If Acc_Act_dwActualizar.Columns(columnIndex) Is Acc_Act_Act_Costo Then
                Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                RemoveHandler dText.KeyPress, AddressOf Acc_Act_dText_KeyPress
                AddHandler dText.KeyPress, AddressOf Acc_Act_dText_KeyPress
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Act_dText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            Dim columnIndex As Integer = Acc_Act_dwActualizar.CurrentCell.ColumnIndex

            If Acc_Act_dwActualizar.Columns(columnIndex) Is Acc_Act_Act_Costo Then
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
    Private Sub Acc_Act_btnActualizar_Click(sender As Object, e As EventArgs) Handles Acc_Act_btnActualizar.Click
        Try
            If Acc_Act_dwActualizar.Rows.Count > 0 Then
                If MessageBox.Show("Se van a actualizar los costos de accesorios. ¿Desea continuar", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    mCostoAccesorio = New ClsCostoAccesorio
                    For Each r As DataGridViewRow In Acc_Act_dwActualizar.Rows
                        mCostoAccesorio.Modificar(r.Cells(Acc_Act_Act_Costo.Index).Value, r.Cells(Acc_Act_Act_idAccesorio.Index).Value,
                                                  r.Cells(Acc_Act_Act_version.Index).Value)
                    Next
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Acc_Act_dwActualizar.Rows.Clear()
                Acc_Act_dwResultados.Rows.Clear()
                Acc_Act_cmbVersion.SelectedItem = Nothing
                Acc_Act_itAccesorio.selected_item = Nothing
                Acc_Act_itAccesorio.Text = String.Empty
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Acc_Act_itAccesorio_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles Acc_Act_itAccesorio.selected_value_changed
        Try
            If Acc_Act_itAccesorio.selected_item IsNot Nothing Then
                Acc_Act_btnBusqueda_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#Region "OTROS"
    Private Sub cargarControlesOtros()
        Try
            mCostoOtros = New ClsCostoOtrosArticulos
            Dim maxVersionOtros As Integer = mCostoOtros.TraerMaxVersion()
            cargarOtrosRecalculo(maxVersionOtros)

            cargarVersionesOtros()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVersionesOtros()
        Try
            Dim mCostoOtroArticulo = New ClsCostoOtrosArticulos
            Dim maxVersion As Integer = mCostoOtroArticulo.TraerMaxVersion()
            Dim listVersiones As New List(Of Integer)
            For ver = 1 To maxVersion
                listVersiones.Add(ver)
            Next
            Otr_Rec_cmbVersion.DataSource = listVersiones
            Otr_Rec_cmbVersion.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Recalculo"
    Private Sub cargarOtrosRecalculo(version As Integer)
        Try
            mCostoOtros = New ClsCostoOtrosArticulos
            Dim list As List(Of OtrosArticulos) = mCostoOtros.TraerTodos(version)
            Otr_Rec_dwItems.Rows.Clear()
            For Each otr As OtrosArticulos In list
                Dim r As DataGridViewRow = Otr_Rec_dwItems.Rows(Otr_Rec_dwItems.Rows.Add())
                r.Cells(Otr_Rec_col_fechaCreacion.Index).Value = otr.FechaCreacion
                r.Cells(Otr_Rec_col_usuarioCreacion.Index).Value = otr.UsuarioCreacion
                r.Cells(Otr_Rec_col_IdArticulo.Index).Value = otr.idArticulo
                r.Cells(Otr_Rec_col_descripcion.Index).Value = otr.descripcion
                r.Cells(Otr_Rec_col_idFamiliaMaterial.Index).Value = otr.IdFamiliaMaterial
                r.Cells(Otr_Rec_col_FamiliaMaterial.Index).Value = otr.FamiliaMaterial
                r.Cells(Otr_Rec_col_version.Index).Value = otr.version
                r.Cells(Otr_Rec_col_nuevaVersion.Index).Value = otr.NuevaVersion
                r.Cells(Otr_Rec_col_costo.Index).Value = otr.costo
                r.Cells(Otr_Rec_col_nuevoCosto.Index).Value = otr.NuevoCosto
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Otr_Rec_btnCambiarVersionBase_Click(sender As Object, e As EventArgs) Handles Otr_Rec_btnCambiarVersionBase.Click
        Try
            If Otr_Rec_cmbVersion.SelectedItem IsNot Nothing Then
                cargarOtrosRecalculo(Otr_Rec_cmbVersion.SelectedItem)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Otr_Rec_btnAceptar_Click(sender As Object, e As EventArgs) Handles Otr_Rec_btnAceptar.Click
        Try
            recalculoPorcentaje(Otr_Rec_nudPorcent, Otr_Rec_dwItems)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Otr_Rec_btnRecalcular_Click(sender As Object, e As EventArgs) Handles Otr_Rec_btnRecalcular.Click
        Try
            mCostoOtros = New ClsCostoOtrosArticulos
            If MessageBox.Show("Se van a recalcular los costos de otros artículos. ¿Desea continuar?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                For Each r As DataGridViewRow In Otr_Rec_dwItems.Rows
                    mCostoOtros.Insertar(My.Settings.UsuarioActivo, r.Cells(Otr_Rec_col_IdArticulo.Index).Value, r.Cells(Otr_Rec_col_idFamiliaMaterial.Index).Value,
                                         r.Cells(Otr_Rec_col_nuevaVersion.Index).Value, r.Cells(Otr_Rec_col_nuevoCosto.Index).Value)
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim maxVersionOtros As Integer = mCostoOtros.TraerMaxVersion()
                cargarOtrosRecalculo(maxVersionOtros)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#Region "TRABAJOS"
    Private Sub cargarControlesTrabajos()
        Try
            mCostoTrabajos = New ClsCostoTrabajoItem
            Dim maxVersionTrabajos As Integer = mCostoTrabajos.TraerMaxVersion()
            cargarTrabajosRecalculo(maxVersionTrabajos)

            cargarVersionesTrabajos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVersionesTrabajos()
        Try
            mCostoTrabajos = New ClsCostoTrabajoItem
            Dim maxVersion As Integer = mCostoTrabajos.TraerMaxVersion()
            Dim listVersiones As New List(Of Integer)
            For ver = 1 To maxVersion
                listVersiones.Add(ver)
            Next
            Tra_Rec_cmbVersion.DataSource = listVersiones
            Tra_Rec_cmbVersion.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Recalculo"
    Private Sub cargarTrabajosRecalculo(version As Integer)
        Try
            mCostoTrabajos = New ClsCostoTrabajoItem
            Dim lista As List(Of costoTrabajoItem) = mCostoTrabajos.TraerxVersion(version)
            Tra_Rec_dwItems.Rows.Clear()
            For Each tra As costoTrabajoItem In lista
                Dim r As DataGridViewRow = Tra_Rec_dwItems.Rows(Tra_Rec_dwItems.Rows.Add())
                r.Cells(Tra_Rec_col_id.Index).Value = tra.Id
                r.Cells(Tra_Rec_col_fechaCreacion.Index).Value = tra.FechaCreacion
                r.Cells(Tra_Rec_col_usuarioCreacion.Index).Value = tra.UsuarioCreacion
                r.Cells(Tra_Rec_col_idTrabajo.Index).Value = tra.IdTrabajo
                r.Cells(Tra_Rec_col_descripcion.Index).Value = tra.Descripcion
                r.Cells(Tra_Rec_col_idFamiliaMaterial.Index).Value = tra.IdFamiliaMaterial
                r.Cells(Tra_Rec_col_familiaMaterial.Index).Value = tra.FamiliaMaterial
                r.Cells(Tra_Rec_col_version.Index).Value = tra.Version
                r.Cells(Tra_Rec_col_nuevaVersion.Index).Value = tra.Version + 1
                r.Cells(Tra_Rec_col_costo.Index).Value = tra.Costo
                r.Cells(Tra_Rec_col_nuevoCosto.Index).Value = tra.Costo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Tra_Rec_btnCambiarVersionBase_Click(sender As Object, e As EventArgs) Handles Tra_Rec_btnCambiarVersionBase.Click
        Try
            If Tra_Rec_cmbVersion.SelectedItem IsNot Nothing Then
                cargarTrabajosRecalculo(Tra_Rec_cmbVersion.SelectedItem)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Tra_Rec_btnAceptar_Click(sender As Object, e As EventArgs) Handles Tra_Rec_btnAceptar.Click
        Try
            recalculoPorcentaje(Tra_Rec_nudPorcent, Tra_Rec_dwItems)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Tra_Rec_btnRecalcular_Click(sender As Object, e As EventArgs) Handles Tra_Rec_btnRecalcular.Click
        Try
            If MessageBox.Show("Se van a recalcular los costos de trabajos items. ¿Desea continuar?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                mCostoTrabajos = New ClsCostoTrabajoItem
                For Each r As DataGridViewRow In Tra_Rec_dwItems.Rows
                    mCostoTrabajos.Insertar(My.Settings.UsuarioActivo, r.Cells(Tra_Rec_col_idTrabajo.Index).Value, r.Cells(Tra_Rec_col_nuevoCosto.Index).Value,
                                           r.Cells(Tra_Rec_col_nuevaVersion.Index).Value)
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim maxVersionOtros As Integer = mCostoTrabajos.TraerMaxVersion()
                cargarTrabajosRecalculo(maxVersionOtros)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
    Private Sub FrmVariosCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarControlesAccesorios()
            cargarControlesOtros()
            cargarControlesTrabajos()

            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class