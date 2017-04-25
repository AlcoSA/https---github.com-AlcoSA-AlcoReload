Imports ReglasNegocio

Public Class FrmCostoTrabajosItems
#Region "Variables"
    Private Sep As Char
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion(ver As Integer)
        Try
            dwItems.Rows.Clear()
            Dim mCostoTrabajo As New ClsCostoTrabajoItem
            Dim maxVersion As Integer = mCostoTrabajo.TraerMaxVersion()
            Dim list As List(Of costoTrabajoItem) = mCostoTrabajo.TraerxVersion(ver)
            list.ForEach(Sub(cos)
                             Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                             r.Cells(id.Index).Value = cos.Id
                             r.Cells(fechaCreacion.Index).Value = cos.FechaCreacion
                             r.Cells(usuarioCreacion.Index).Value = cos.UsuarioCreacion
                             r.Cells(idTrabajo.Index).Value = cos.IdTrabajo
                             r.Cells(descripcion.Index).Value = cos.Descripcion
                             r.Cells(idFamiliaMaterial.Index).Value = cos.IdFamiliaMaterial
                             r.Cells(familiaMaterial.Index).Value = cos.FamiliaMaterial
                             r.Cells(version.Index).Value = cos.Version
                             r.Cells(nuevaVersion.Index).Value = maxVersion + 1
                             r.Cells(costo.Index).Value = cos.Costo
                             r.Cells(nuevoCosto.Index).Value = cos.Costo
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVersiones()
        Try
            Dim mCostoTrabajo As New ClsCostoTrabajoItem
            Dim maxVersion As Integer = mCostoTrabajo.TraerMaxVersion()
            Dim list As New List(Of Integer)
            For i = 1 To maxVersion
                list.Add(i)
            Next
            cmbVersion.DataSource = list
            cmbVersion.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub controlesRecalculo()
        Try
            If gbRecalculo.Enabled = False Then
                gbRecalculo.Enabled = True
            Else
                gbRecalculo.Enabled = False
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub controlesVersionBase()
        Try
            If gbVersionCosto.Enabled = False Then
                gbVersionCosto.Enabled = True
            Else
                gbVersionCosto.Enabled = False
            End If
            cmbVersion.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmCostoTrabajosItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mCostoTrabajo As New ClsCostoTrabajoItem
            Dim maxVersion As Integer = mCostoTrabajo.TraerMaxVersion()
            cargarInformacion(maxVersion)
            cargarVersiones()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    If gbVersionCosto.Enabled = False Then
                        menu.Items.Add("Cambiar versión de costo base", Nothing, AddressOf controlesVersionBase)
                    Else
                        menu.Items.Add("Reestablecer versión de costo base", Nothing, AddressOf controlesVersionBase)
                    End If

                    If gbRecalculo.Enabled = False Then
                        menu.Items.Add("Recalcular con porcentaje", Nothing, AddressOf controlesRecalculo)
                    Else
                        menu.Items.Add("Finalizar recalculado", Nothing, AddressOf controlesRecalculo)
                    End If
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCambiarVersion_Click(sender As Object, e As EventArgs) Handles btnCambiarVersion.Click
        Try
            cargarInformacion(cmbVersion.SelectedValue)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim porcent As Decimal = nudPorcent.Value / 100
            For Each r As DataGridViewRow In dwItems.Rows
                Dim valor As Decimal = Convert.ToDecimal(r.Cells(costo.Index).Value)
                r.Cells(nuevoCosto.Index).Value = (valor * porcent) + valor
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        Try
            If MessageBox.Show("Se van a recalcular los costos de trabajos items. ¿Desea continuar", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                Dim mCostoTrabajo As New ClsCostoTrabajoItem
                For Each r As DataGridViewRow In dwItems.Rows
                    mCostoTrabajo.Insertar(My.Settings.UsuarioActivo, r.Cells(idTrabajo.Index).Value, r.Cells(nuevoCosto.Index).Value,
                                           r.Cells(nuevaVersion.Index).Value)
                Next
            End If
            MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FrmCostoTrabajosItems_Load(Nothing, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is nuevoCosto Then
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

            If dwItems.Columns(columnIndex) Is nuevoCosto Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class