Imports ReglasNegocio
Imports ReglasNegocio.CostoAcabado
Imports ReglasNegocio.CostoKiloAluminio
Imports ReglasNegocio.CostoNivel
Imports Validaciones

Public Class FrmCostoAluminio
#Region "Variables"
    Private mCostoNivel As ClsCostoNivel
    Private mCostoKiloAluminio As ClsCostoKiloAluminio
    Private mCostoAcabado As ClsCostoAcabado

    Private mNivel As ClsNivelesFamilias
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private Sep As Char

    Private maxVersionCNiveles As Integer
    Private maxVersionCKiloAluminio As Integer
    Private maxVersionCAcabado As Integer
#End Region

#Region "Procedimientos"
    Private Sub cargarVersionesNiveles()
        Try
            Dim listVersiones As New List(Of Integer)
            For ver = 0 To maxVersionCNiveles
                listVersiones.Add(ver)
            Next
            cmbVersCostoNiveles.DataSource = listVersiones
            cmbVersCostoNiveles.SelectedItem = maxVersionCNiveles
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarVersionesKiloAluminio()
        Try
            Dim listVersiones As New List(Of Integer)
            For ver = 0 To maxVersionCKiloAluminio
                listVersiones.Add(ver)
            Next
            cmbVersCostoKiloAlum.DataSource = listVersiones
            cmbVersCostoKiloAlum.SelectedItem = maxVersionCKiloAluminio
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarVersionesAcabado()
        Try
            Dim listVersiones As New List(Of Integer)
            For ver = 0 To maxVersionCAcabado
                listVersiones.Add(ver)
            Next
            cmbVersCostoAcabados.DataSource = listVersiones
            cmbVersCostoAcabados.SelectedItem = maxVersionCAcabado
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarCostosNiveles(versionBase As Integer)
        Try
            mCostoNivel = New ClsCostoNivel
            Dim listCostoNiveles As List(Of CostoNivel) = mCostoNivel.TraerTodos(versionBase)
            dwCostoNivel.Rows.Clear()
            For Each vv As CostoNivel In listCostoNiveles
                Dim r As DataGridViewRow = dwCostoNivel.Rows(dwCostoNivel.Rows.Add())
                r.Cells(idCostoNivel.Index).Value = vv.Id
                r.Cells(fechacNivel.Index).Value = vv.FechaCreacion
                r.Cells(usuariocNivel.Index).Value = vv.UsuarioCreacion
                r.Cells(idNivel.Index).Value = vv.idNivel
                r.Cells(nivel.Index).Value = vv.Nivel
                r.Cells(versionActNivel.Index).Value = vv.VersionCosto
                r.Cells(proxVersionNivel.Index).Value = vv.NuevaVersion
                r.Cells(costoActNivel.Index).Value = vv.valorCosto
                r.Cells(nuevoCostoNivel.Index).Value = vv.NuevoCosto
                r.Cells(motivoCreacion.Index).Value = vv.motivo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarCostosKiloAluminio(versionBase As Integer)
        Try
            mCostoKiloAluminio = New CostoKiloAluminio.ClsCostoKiloAluminio
            Dim listCostoKiloAluminio As List(Of CostoKiloAluminio.CostoKAluminio) = mCostoKiloAluminio.TraerTodos(versionBase)

            dwCostoKiloAluminio.Rows.Clear()
            For Each vv As CostoKiloAluminio.CostoKAluminio In listCostoKiloAluminio
                Dim r As DataGridViewRow = dwCostoKiloAluminio.Rows(dwCostoKiloAluminio.Rows.Add())
                r.Cells(idCostoKiloAluminio.Index).Value = vv.Id
                r.Cells(fechacKiloAluminio.Index).Value = vv.FechaCreacion
                r.Cells(usuariocKiloAluminio.Index).Value = vv.UsuarioCreacion
                r.Cells(idKiloAluminio.Index).Value = vv.idKiloAluminio
                r.Cells(descripcion.Index).Value = vv.descripcion
                r.Cells(versionActKiloAluminio.Index).Value = vv.version
                r.Cells(proxVersionKiloAluminio.Index).Value = vv.NuevaVersion
                r.Cells(costoActKiloAluminio.Index).Value = vv.Costo
                r.Cells(nuevoCostoKiloAluminio.Index).Value = vv.NuevoCosto
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarCostosAcabados(versionBase As Integer)
        Try
            mCostoAcabado = New ClsCostoAcabado
            Dim listCostoAcabado As List(Of costoAcabado) = mCostoAcabado.TraerTodos(versionBase)

            dwCostoAcabado.Rows.Clear()
            For Each vv As costoAcabado In listCostoAcabado
                Dim r As DataGridViewRow = dwCostoAcabado.Rows(dwCostoAcabado.Rows.Add())
                r.Cells(idCostoAcabado.Index).Value = vv.Id
                r.Cells(fechacAcabado.Index).Value = vv.FechaCreacion
                r.Cells(usuariocAcabado.Index).Value = vv.UsuarioCreacion
                r.Cells(idAcabado.Index).Value = vv.idAcabado
                r.Cells(acabado.Index).Value = vv.acabado
                r.Cells(versionActAcabado.Index).Value = vv.version
                r.Cells(proxVersionAcabado.Index).Value = vv.NuevaVersion
                r.Cells(costoActAcabado.Index).Value = vv.Costo
                r.Cells(nuevoCostoAcabado.Index).Value = vv.NuevoCosto
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#Region "Elementos Carga Grafica"
    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Application.Run(New FrmCargaProceso)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

    Private Sub FrmCostoAluminio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mCostoNivel = New ClsCostoNivel
            maxVersionCNiveles = mCostoNivel.TraerMaxVersion()

            mCostoKiloAluminio = New ClsCostoKiloAluminio
            maxVersionCKiloAluminio = mCostoKiloAluminio.TraerUltimaVersion()

            mCostoAcabado = New ClsCostoAcabado
            maxVersionCAcabado = mCostoAcabado.TraerUltimaVersion()

            cargarCostosNiveles(maxVersionCNiveles)
            cargarCostosKiloAluminio(maxVersionCKiloAluminio)
            cargarCostosAcabados(maxVersionCAcabado)

            cargarVersionesNiveles()
            cargarVersionesKiloAluminio()
            cargarVersionesAcabado()

            cbRecalcularAcabado.Checked = True
            cbRecalcularAluminio.Checked = True
            cbRecalcularNivel.Checked = True
            Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub CalcularPerfileria()
        Try
            Dim ccostoalu As New CostoArticulo.ClsCostoAluminio
            ccostoalu.Ingresar()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        Try
            mCostoNivel = New ClsCostoNivel
            mCostoKiloAluminio = New CostoKiloAluminio.ClsCostoKiloAluminio
            Dim cbSeleccionados As Integer = 0

            If Convert.ToInt32(cbRecalcularAcabado.Checked) + Convert.ToInt32(cbRecalcularAluminio.Checked) + Convert.ToInt32(cbRecalcularNivel.Checked) <= 0 Then
                MessageBox.Show("No ha seleccionado ningún costo para re-calcular", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If
            If MessageBox.Show("Se van a re-calcular todos los costos de los niveles. ¿Desea continuar?", "", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                bwcargas.RunWorkerAsync()
                If cbRecalcularNivel.Checked Then
                    If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "Re-calculando Aluminio"
                    For Each row As DataGridViewRow In dwCostoNivel.Rows
                        mCostoNivel.Ingresar(Convert.ToInt32(row.Cells(idNivel.Index).Value), Convert.ToInt32(row.Cells(proxVersionNivel.Index).Value),
                                         Convert.ToDecimal(row.Cells(nuevoCostoNivel.Index).Value), row.Cells(motivoCreacion.Index).Value.ToString(),
                                         My.Settings.UsuarioActivo)
                    Next
                End If
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "Re-calculando Aluminio"
                If cbRecalcularAluminio.Checked Then
                    For Each row As DataGridViewRow In dwCostoKiloAluminio.Rows
                        mCostoKiloAluminio.Ingresar(Convert.ToInt32(row.Cells(idKiloAluminio.Index).Value), My.Settings.UsuarioActivo,
                                        Convert.ToDecimal(row.Cells(nuevoCostoKiloAluminio.Index).Value), Convert.ToInt32(row.Cells(proxVersionKiloAluminio.Index).Value))
                    Next
                End If
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "Re-acabados Aluminio"
                If cbRecalcularAcabado.Checked Then
                    For Each row As DataGridViewRow In dwCostoAcabado.Rows
                        mCostoAcabado.Ingresar(Convert.ToInt32(row.Cells(idAcabado.Index).Value), Convert.ToInt32(row.Cells(proxVersionAcabado.Index).Value),
                                               Convert.ToDecimal(row.Cells(nuevoCostoAcabado.Index).Value), My.Settings.UsuarioActivo)
                    Next
                End If
                CalcularPerfileria()
                cargarCostosNiveles(3)
                cargarCostosKiloAluminio(3)
                cargarCostosAcabados(3)
                Application.OpenForms().Item("FrmCargaProceso").Close()
            End If
            cbRecalcularNivel.Checked = False
            cbRecalcularAluminio.Checked = False
            cbRecalcularAcabado.Checked = False
        Catch ex As Exception
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then Application.OpenForms().Item("FrmCargaProceso").Close()
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#Region "Solo números y solo letras en datagrid"
    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwCostoNivel.EditingControlShowing,
            dwCostoKiloAluminio.EditingControlShowing, dwCostoAcabado.EditingControlShowing
        Try
            Dim columnIndexNivel As Integer = dwCostoNivel.CurrentCell.ColumnIndex
            Dim columnIndexCostoAluminio As Integer = dwCostoKiloAluminio.CurrentCell.ColumnIndex
            Dim columnIndexCostoAcabado As Integer = dwCostoAcabado.CurrentCell.ColumnIndex

            If dwCostoNivel.Columns(columnIndexNivel) Is motivoCreacion Or dwCostoNivel.Columns(columnIndexNivel) Is nuevoCostoNivel Then
                Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                RemoveHandler dText.KeyPress, AddressOf dText_KeyPress
                AddHandler dText.KeyPress, AddressOf dText_KeyPress
            End If

            If dwCostoKiloAluminio.Columns(columnIndexCostoAluminio) Is nuevoCostoKiloAluminio Then
                Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                RemoveHandler dText.KeyPress, AddressOf dText_KeyPress
                AddHandler dText.KeyPress, AddressOf dText_KeyPress
            End If

            If dwCostoAcabado.Columns(columnIndexCostoAcabado) Is nuevoCostoAcabado Then
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
            Dim columnIndexNivel As Integer = dwCostoNivel.CurrentCell.ColumnIndex
            Dim columnIndexKiloAluminio As Integer = dwCostoKiloAluminio.CurrentCell.ColumnIndex
            Dim columnIndexAcabado As Integer = dwCostoAcabado.CurrentCell.ColumnIndex

            If dwCostoNivel.Columns(columnIndexNivel) Is motivoCreacion Then
                e.KeyChar = Char.ToUpper(e.KeyChar)
            End If

            If dwCostoNivel.Columns(columnIndexNivel) Is nuevoCostoNivel Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return

            ElseIf dwCostoKiloAluminio.Columns(columnIndexKiloAluminio) Is nuevoCostoKiloAluminio Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return

            ElseIf dwCostoAcabado.Columns(columnIndexAcabado) Is nuevoCostoAcabado Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

    Private Sub dw_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwCostoNivel.CellMouseClick,
            dwCostoKiloAluminio.CellMouseClick, dwCostoAcabado.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                If gbRecalcular.Enabled = False Then
                    menu.Items.Add("Recalcular con porcentaje", Nothing, AddressOf recalcular)
                Else
                    menu.Items.Add("Finalizar recalculado", Nothing, AddressOf finalizar)
                End If

                If gbVersionBase.Enabled = False Then
                    menu.Items.Add("Cambiar versión de costo base", Nothing, AddressOf ActivarVersionBase)
                Else
                    menu.Items.Add("Reestablacer versión de costo base", Nothing, AddressOf DesactivarVersionBase)
                End If
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#Region "Activar o inactivar recalculado"
    Private Sub recalcular()
        Try
            gbRecalcular.Enabled = True
            If cbRecalcularNivel.Checked = True Then
                lblCNiveles.Enabled = True
                nudPorcentCN.Enabled = True
            Else
                lblCNiveles.Enabled = False
                nudPorcentCN.Enabled = False
            End If

            If cbRecalcularAcabado.Checked = True Then
                lblCAcabados.Enabled = True
                nudPorcentCA.Enabled = True
            Else
                lblCAcabados.Enabled = False
                nudPorcentCA.Enabled = False
            End If

            If cbRecalcularAluminio.Checked = True Then
                lblCKAlumn.Enabled = True
                nudPorcentCK.Enabled = True
            Else
                lblCKAlumn.Enabled = False
                nudPorcentCK.Enabled = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub finalizar()
        Try
            nudPorcentCN.Value = 0
            nudPorcentCA.Value = 0
            nudPorcentCK.Value = 0
            gbRecalcular.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub ActivarVersionBase()
        Try
            gbVersionBase.Enabled = True
            cmbVersCostoNiveles.SelectedItem = maxVersionCNiveles
            cmbVersCostoKiloAlum.SelectedItem = maxVersionCKiloAluminio
            cmbVersCostoAcabados.SelectedItem = maxVersionCAcabado

            If cbRecalcularNivel.Checked Then
                lblCNiveles2.Enabled = True
                cmbVersCostoNiveles.Enabled = True
            Else
                lblCNiveles2.Enabled = False
                cmbVersCostoNiveles.Enabled = False
            End If

            If cbRecalcularAluminio.Checked Then
                lblCKAlumn2.Enabled = True
                cmbVersCostoKiloAlum.Enabled = True
            Else
                lblCKAlumn2.Enabled = False
                cmbVersCostoKiloAlum.Enabled = False
            End If

            If cbRecalcularAcabado.Checked Then
                lblCAcabados2.Enabled = True
                cmbVersCostoAcabados.Enabled = True
            Else
                lblCAcabados2.Enabled = False
                cmbVersCostoAcabados.Enabled = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub DesactivarVersionBase()
        Try
            cmbVersCostoNiveles.SelectedItem = maxVersionCNiveles
            cmbVersCostoKiloAlum.SelectedItem = maxVersionCKiloAluminio
            cmbVersCostoAcabados.SelectedItem = maxVersionCAcabado
            gbVersionBase.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cbRecalcularNivel_CheckedChanged(sender As Object, e As EventArgs) Handles cbRecalcularNivel.CheckedChanged
        Try
            If gbRecalcular.Enabled = True Then
                If cbRecalcularNivel.Checked Then
                    lblCNiveles.Enabled = True
                    nudPorcentCN.Enabled = True
                Else
                    lblCNiveles.Enabled = False
                    nudPorcentCN.Enabled = False
                End If
            End If

            If gbVersionBase.Enabled Then
                If cbRecalcularNivel.Checked Then
                    lblCNiveles2.Enabled = True
                    cmbVersCostoNiveles.Enabled = True
                Else
                    lblCNiveles2.Enabled = False
                    cmbVersCostoNiveles.Enabled = False
                End If
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cbRecalcularAcabado_CheckedChanged(sender As Object, e As EventArgs) Handles cbRecalcularAcabado.CheckedChanged
        Try
            If gbRecalcular.Enabled = True Then
                If cbRecalcularAcabado.Checked Then
                    lblCAcabados.Enabled = True
                    nudPorcentCA.Enabled = True
                Else
                    lblCAcabados.Enabled = False
                    nudPorcentCA.Enabled = False
                End If
            End If

            If gbVersionBase.Enabled Then
                If cbRecalcularAcabado.Checked Then
                    lblCAcabados2.Enabled = True
                    cmbVersCostoAcabados.Enabled = True
                Else
                    lblCAcabados2.Enabled = False
                    cmbVersCostoAcabados.Enabled = False
                End If
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cbRecalcularAluminio_CheckedChanged(sender As Object, e As EventArgs) Handles cbRecalcularAluminio.CheckedChanged
        Try
            If gbRecalcular.Enabled = True Then
                If cbRecalcularAluminio.Checked Then
                    lblCKAlumn.Enabled = True
                    nudPorcentCK.Enabled = True
                Else
                    lblCKAlumn.Enabled = False
                    nudPorcentCK.Enabled = False
                End If
            End If

            If gbVersionBase.Enabled Then
                If cbRecalcularAluminio.Checked Then
                    lblCKAlumn2.Enabled = True
                    cmbVersCostoKiloAlum.Enabled = True
                Else
                    lblCKAlumn2.Enabled = False
                    cmbVersCostoKiloAlum.Enabled = False
                End If
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If nudPorcentCN.Enabled Then
                For Each r As DataGridViewRow In dwCostoNivel.Rows
                    Dim valor As Decimal = Convert.ToDecimal(r.Cells(costoActNivel.Index).Value)
                    Dim porcent As Decimal = nudPorcentCN.Value / 100
                    r.Cells(nuevoCostoNivel.Index).Value = (valor * porcent) + valor
                Next
            End If

            If nudPorcentCA.Enabled Then
                For Each r As DataGridViewRow In dwCostoAcabado.Rows
                    Dim valor As Decimal = Convert.ToDecimal(r.Cells(costoActAcabado.Index).Value)
                    Dim porcent As Decimal = nudPorcentCA.Value / 100
                    r.Cells(nuevoCostoAcabado.Index).Value = (valor * porcent) + valor
                Next
            End If

            If nudPorcentCK.Enabled Then
                For Each r As DataGridViewRow In dwCostoKiloAluminio.Rows
                    Dim valor As Decimal = Convert.ToDecimal(r.Cells(costoActKiloAluminio.Index).Value)
                    Dim porcent As Decimal = nudPorcentCK.Value / 100
                    r.Cells(nuevoCostoKiloAluminio.Index).Value = (valor * porcent) + valor
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCambiarVersionBase_Click(sender As Object, e As EventArgs) Handles btnCambiarVersionBase.Click
        Try
            If cmbVersCostoNiveles.Enabled Then
                cargarCostosNiveles(cmbVersCostoNiveles.SelectedValue)
            End If

            If cmbVersCostoKiloAlum.Enabled Then
                cargarCostosKiloAluminio(cmbVersCostoKiloAlum.SelectedValue)
            End If

            If cmbVersCostoAcabados.Enabled Then
                cargarCostosAcabados(cmbVersCostoAcabados.SelectedValue)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudPorcentCN.GotFocus,
            nudPorcentCA.GotFocus, nudPorcentCK.GotFocus
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Value = 0 Then
                nud.ResetText()
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudPorcentCN.Leave,
            nudPorcentCA.Leave, nudPorcentCK.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0.00"
                nud.Value = 0.00
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class