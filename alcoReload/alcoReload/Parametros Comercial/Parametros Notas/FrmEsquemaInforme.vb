Imports ReglasNegocio
Imports Validaciones

Public Class FrmEsquemaInforme
#Region "Variables"
    Private curid As Integer = 0
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private mEsquemaNotas As ClsEsquemaInforme
    Private mTipoNota As ClsTiposNotas
    Private mOrigenNota As ClsOrigenNotas
    Private isDroping As Boolean
    Private btonTag As String
    Private objValidacion As ClsValidaciones
#End Region
#Region "Procedimientos"
    Private Sub cargarTiposNotas()
        Try
            mTipoNota = New ClsTiposNotas
            Dim listTiposNotas As List(Of tipoNota) = mTipoNota.TraerTodos()
            cmbTipoNota.DisplayMember = "Nombre"
            cmbTipoNota.ValueMember = "Id"
            cmbTipoNota.DataSource = listTiposNotas
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDatos()
        Try
            mEsquemaNotas = New ClsEsquemaInforme
            Dim listaEsquemas As List(Of esquemaInforme) = mEsquemaNotas.traerTodos()
            For Each esq As esquemaInforme In listaEsquemas
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(Id.Index).Value = esq.Id
                r.Cells(fechaCreacion.Index).Value = esq.FechaCreacion
                r.Cells(usuarioCreacion.Index).Value = esq.UsuarioCreacion
                r.Cells(idTipoNota.Index).Value = esq.idTipoNota
                r.Cells(tipoNota.Index).Value = esq.tipoNota
                r.Cells(descripcion.Index).Value = esq.descripcion
                r.Cells(pieDePagina.Index).Value = esq.pieDePagina
                r.Cells(fechaModi.Index).Value = esq.FechaModificacion
                r.Cells(usuarioModi.Index).Value = esq.UsuarioModificacion
                r.Cells(valorDefecto.Index).Value = esq.valorDefecto
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar(sender As Object, e As EventArgs)
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(Id.Index).Value)
            txtDescripcion.Text = r.Cells(descripcion.Index).Value
            txtPieDePagina.Text = r.Cells(pieDePagina.Index).Value
            cbValorDefecto.Checked = r.Cells(valorDefecto.Index).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validarDatos() As Boolean
        objValidacion = New ClsValidaciones
        If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider) Then
            Return False
        End If
        If Not objValidacion.TextBoxDigitado(txtPieDePagina, ErrorProvider) Then
            Return False
        End If
        Return True
    End Function
    Private Sub limpiarCampos()
        Try
            txtDescripcion.Text = String.Empty
            txtPieDePagina.Text = String.Empty
            cbValorDefecto.Checked = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmEsquemaNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarDatos()
            cargarTiposNotas()
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

    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            If validarDatos() Then
                mEsquemaNotas = New ClsEsquemaInforme
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mEsquemaNotas.Insertar(My.Settings.UsuarioActivo, cmbTipoNota.SelectedValue, txtDescripcion.Text,
                                       txtPieDePagina.Text, CInt(cbValorDefecto.Checked))
                Else
                    mEsquemaNotas.Modificar(curid, cmbTipoNota.SelectedValue, txtDescripcion.Text, txtPieDePagina.Text,
                                            My.Settings.UsuarioActivo, cbValorDefecto.Checked)
                End If
                MessageBox.Show("La información de guardó exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(Nothing, Nothing)
                dwItems.Rows.Clear()
                cargarDatos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            cmbTipoNota.SelectedValue = 1
            txtDescripcion.Text = String.Empty
            txtPieDePagina.Text = String.Empty
            cbValorDefecto.Checked = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub txtDescripcion_DragDrop(sender As Object, e As DragEventArgs) Handles txtDescripcion.DragDrop
        Try
            Dim posicion As Integer
            Dim primera As String
            Dim segunda As String
            Dim largoCadena As Integer

            posicion = txtDescripcion.SelectionStart
            primera = txtDescripcion.Text.Substring(0, posicion)
            largoCadena = txtDescripcion.Text.Length

            If posicion = txtDescripcion.Text.Length Then

                txtDescripcion.Text = primera & " " & btonTag
            Else
                segunda = Mid(txtDescripcion.Text, posicion + 1, largoCadena - posicion + 1)
                txtDescripcion.Text = primera & " " & btonTag & " " & segunda
            End If
            isDroping = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub txtDescripcion_DragEnter(sender As Object, e As DragEventArgs) Handles txtDescripcion.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.StringFormat) Then
                e.Effect = DragDropEffects.All
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Tsb_MouseDown(sender As Object, e As MouseEventArgs) Handles tsbTipoNota.MouseDown, tsbNumContrato.MouseDown,
            tsbObjetoNota.MouseDown, tsbValorContrato.MouseDown, tsbNumCuota.MouseDown, tsbTotalCuotas.MouseDown, tsbPorcentaje.MouseDown
        Try
            If e.Button = MouseButtons.Right Then
                Dim tbtn As ToolStripButton = DirectCast(sender, ToolStripButton)
                btonTag = Convert.ToString(tbtn.Tag)
                isDroping = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Tsb_MouseMove(sender As Object, e As MouseEventArgs) Handles tsbTipoNota.MouseMove, tsbNumContrato.MouseMove,
            tsbObjetoNota.MouseMove, tsbValorContrato.MouseMove, tsbNumCuota.MouseMove, tsbTotalCuotas.MouseMove, tsbPorcentaje.MouseMove
        Try
            If isDroping Then
                txtDescripcion.DoDragDrop(dwItems.ToString, DragDropEffects.Copy Or DragDropEffects.Move)
            End If
            isDroping = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                dwItems.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbTipoNota_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoNota.SelectedValueChanged
        Try
            If tform = ClsEnums.TiOperacion.MODIFICAR Then
                tform = ClsEnums.TiOperacion.INSERTAR
            End If
            limpiarCampos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class