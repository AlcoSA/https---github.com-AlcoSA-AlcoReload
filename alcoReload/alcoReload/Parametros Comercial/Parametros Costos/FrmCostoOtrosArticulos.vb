Imports ReglasNegocio

Public Class FrmCostoOtrosArticulos
#Region "Variables"
    Private mCostoOtroArticulo As ClsCostoOtrosArticulos
    Private fuenteInicial As DataTable = Nothing
    Private Sep As Char
#End Region
#Region "Procedimientos"
    Private Sub prepararDatos(versionBase As Integer)
        Try
            mCostoOtroArticulo = New ClsCostoOtrosArticulos
            Dim objLista As List(Of OtrosArticulos) = mCostoOtroArticulo.TraerTodos(versionBase, dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVersiones()
        Try
            mCostoOtroArticulo = New ClsCostoOtrosArticulos
            Dim maxVersion As Integer = mCostoOtroArticulo.TraerMaxVersion()
            Dim listVersiones As New List(Of Integer)
            For ver = 1 To maxVersion
                listVersiones.Add(ver)
            Next
            cmbVersion.DataSource = listVersiones
            cmbVersion.SelectedItem = maxVersion
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub recalcular()
        Try
            gbRecalcular.Enabled = True
            nudPorcent.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub finalizar()
        Try
            nudPorcent.Value = 0
            gbRecalcular.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ActivarVersionBase()
        Try
            mCostoOtroArticulo = New ClsCostoOtrosArticulos
            Dim version As Integer = mCostoOtroArticulo.TraerMaxVersion()
            cmbVersion.SelectedItem = version
            gbxVersionCostoBase.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub DesactivarVersionBase()
        Try
            mCostoOtroArticulo = New ClsCostoOtrosArticulos
            Dim maxVersion As Integer = mCostoOtroArticulo.TraerMaxVersion()
            prepararDatos(maxVersion)
            gbxVersionCostoBase.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Elementos Carga Gráfica"
    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Application.Run(New FrmCargaProceso)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmCostoOtrosArticulos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            mCostoOtroArticulo = New ClsCostoOtrosArticulos
            Dim maxVersion As Integer = mCostoOtroArticulo.TraerMaxVersion()
            prepararDatos(maxVersion)
            Application.OpenForms().Item("FrmCargaProceso").Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmCostoOtrosArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarVersiones()

            bwcargas.RunWorkerAsync()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        Try
            If MessageBox.Show("Se van a recalcular los costos de otros artículos. ¿Desea continuar", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                mCostoOtroArticulo = New ClsCostoOtrosArticulos
                For Each r As DataGridViewRow In dwItems.Rows
                    mCostoOtroArticulo.Insertar(My.Settings.UsuarioActivo, r.Cells(idArticulo.Index).Value,
                                                r.Cells(idFamiliaMaterial.Index).Value, r.Cells(nuevaVersion.Index).Value,
                                                r.Cells(nuevoCosto.Index).Value)
                Next
            End If
            MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FrmCostoOtrosArticulos_Shown(Nothing, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            e.Handled = False
        End If
    End Sub

    Private Sub dw_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                If gbRecalcular.Enabled = False Then
                    menu.Items.Add("Recalcular con porcentaje", Nothing, AddressOf recalcular)
                Else
                    menu.Items.Add("Finalizar recalculado", Nothing, AddressOf finalizar)
                End If

                If gbxVersionCostoBase.Enabled = False Then
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

    Private Sub btnCambiarVersionBase_Click(sender As Object, e As EventArgs) Handles btnCambiarVersionBase.Click
        Try
            prepararDatos(cmbVersion.SelectedValue)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            For Each r As DataGridViewRow In dwItems.Rows
                Dim valor As Decimal = Convert.ToDecimal(r.Cells("costo").Value)
                Dim porcent As Decimal = nudPorcent.Value / 100
                r.Cells("nuevoCosto").Value = (valor * porcent) + valor
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudPorcent.GotFocus
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

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudPorcent.Leave
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