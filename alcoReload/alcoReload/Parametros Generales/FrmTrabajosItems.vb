Imports ReglasNegocio
Imports Validaciones

Public Class FrmTrabajosItems
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curId As Integer = 0
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub cargarEstados()
        Try
            Dim mEstado As New ClsEstados
            Dim list As List(Of Estado) = mEstado.TraerTodos().Where(Function(a)
                                                                         Return a.Id = ClsEnums.Estados.ACTIVO Or a.Id = ClsEnums.Estados.INACTIVO
                                                                     End Function).ToList
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = list
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarFamiliasMaterial()
        Try
            Dim mFamilia As New ClsFamiliaMaterial
            Dim list As List(Of FamiliaMaterial) = mFamilia.TraexEstado(ClsEnums.Estados.ACTIVO).Where(Function(a)
                                                                                                           Return a.Id = ClsEnums.FamiliasMateriales.ACCESORIOS Or
                                                                                                           a.Id = ClsEnums.FamiliasMateriales.DISEÑOS Or
                                                                                                           a.Id = ClsEnums.FamiliasMateriales.OTROS Or
                                                                                                           a.Id = ClsEnums.FamiliasMateriales.PERFILERIA Or
                                                                                                           a.Id = ClsEnums.FamiliasMateriales.VIDRIO
                                                                                                       End Function).ToList
            cmbFamiliaMaterial.DisplayMember = "FamiliaMaterial"
            cmbFamiliaMaterial.ValueMember = "Id"
            cmbFamiliaMaterial.DataSource = list
            cmbFamiliaMaterial.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarUnidadMedida()
        Try
            Dim mArticulos As New ClsArticulos
            Dim td As DataTable = mArticulos.traerUnidades()
            cmbUnidadMedida.ValueMember = "Unidad"
            cmbUnidadMedida.DisplayMember = "Unidad"
            cmbUnidadMedida.DataSource = td
            cmbUnidadMedida.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            tform = ClsEnums.TiOperacion.MODIFICAR
            curId = r.Cells(id.DataPropertyName).Value
            txtPrefijo.Text = r.Cells(prefijo.DataPropertyName).Value
            txtDescripcion.Text = r.Cells(descripcion.DataPropertyName).Value
            cmbUnidadMedida.SelectedValue = r.Cells(unidadMedida.DataPropertyName).Value
            cmbFamiliaMaterial.SelectedValue = r.Cells(idFamiliaMaterial.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            nudCosto.Value = 0.00
            nudCosto.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Limpiar()
        Try
            tform = ClsEnums.TiOperacion.INSERTAR
            curId = 0
            txtPrefijo.Text = String.Empty
            txtDescripcion.Text = String.Empty
            cmbUnidadMedida.SelectedItem = Nothing
            cmbFamiliaMaterial.SelectedValue = 0
            cmbEstado.SelectedValue = CInt(ClsEnums.Estados.ACTIVO)
            nudCosto.Value = 0.00
            nudCosto.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            If MessageBox.Show("¿Está seguro de eliminar el registro?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                Dim mTrabajo As New ClsTrabajosItems
                mTrabajo.ActualizarEstado(r.Cells(id.DataPropertyName).Value, ClsEnums.Estados.ARCHIVADO)
                Limpiar()
                FrmTrabajosItems_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            Dim mValidacion As New ClsValidaciones
            If Not mValidacion.TextBoxDigitado(txtPrefijo, ErrorProvider) Then
                Return False
            End If

            If Not mValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider) Then
                Return False
            End If

            If CInt(cmbFamiliaMaterial.SelectedValue) = 0 Then
                ErrorProvider.SetError(cmbFamiliaMaterial, "Debe indicar la familia material")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbUnidadMedida.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbUnidadMedida, "Debe indicar la unidad de medida")
                Return False
            End If
            ErrorProvider.Clear()

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim mTrabajo As New ClsTrabajosItems
                If mTrabajo.ExisteRegistro(txtPrefijo.Text, cmbFamiliaMaterial.SelectedValue) Then
                    ErrorProvider.SetError(txtPrefijo, "El registro ya existe")
                    Return False
                End If
                ErrorProvider.Clear()

                If nudCosto.Value = 0 Then
                    ErrorProvider.SetError(nudCosto, "Ingrese el costo del trabajo")
                    Return False
                End If
                ErrorProvider.Clear()
            End If
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmTrabajosItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mTrabajo As New ClsTrabajosItems
            Dim list As List(Of trabajoItems) = mTrabajo.TraerTodos(dwItems.TablaDatos)
            cargarFamiliasMaterial()
            cargarEstados()
            cargarUnidadMedida()
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
            If validacion() Then
                Dim mTrabajo As New ClsTrabajosItems
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    Dim idTrabajo As Integer = mTrabajo.Insertar(My.Settings.UsuarioActivo, txtPrefijo.Text, txtDescripcion.Text,
                                                                 cmbUnidadMedida.SelectedValue, cmbFamiliaMaterial.SelectedValue, cmbEstado.SelectedValue)

                    Dim mCostoTrabajo As New ClsCostoTrabajoItem
                    Dim maxVersion As Integer = mCostoTrabajo.TraerMaxVersion()
                    If maxVersion = 0 Then
                        mCostoTrabajo.Insertar(My.Settings.UsuarioActivo, idTrabajo, nudCosto.Value, 1)
                    Else
                        For i = 1 To maxVersion
                            mCostoTrabajo.Insertar(My.Settings.UsuarioActivo, idTrabajo, nudCosto.Value, i)
                        Next
                    End If

                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mTrabajo.Modificar(curId, txtPrefijo.Text, txtDescripcion.Text, cmbUnidadMedida.SelectedValue,
                                       cmbFamiliaMaterial.SelectedValue, My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar()
                FrmTrabajosItems_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            Limpiar()
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
                    menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                    menu.Items.Add("Eliminar", Nothing, AddressOf Eliminar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudCosto.GotFocus
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
    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudCosto.Leave
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