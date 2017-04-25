﻿Imports ReglasNegocio
Imports Validaciones

Public Class FrmAcabados

#Region "Variables"
    Private macabado As ClsAcabados
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private fuenteInicial As DataTable = Nothing
#End Region

#Region "Procedimientos"
    Private Sub cargarEstados()
        Try
            Dim mEstado As New ClsEstados
            Dim listEstados As List(Of Estado) = mEstado.TraerTodos()
            Dim bsource As New BindingSource()
            bsource.DataSource = listEstados.Where(Function(a) a.Id < 3)
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            If Not My.Settings.Es_Desarrollador Then
                MsgBox("No tiene permisos para realizar esta acción", MsgBoxStyle.Information)
                Return
            End If
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(Id.DataPropertyName).Value)
            txtPrefijo.Text = r.Cells(Prefijo.DataPropertyName).Value.ToString()
            txtnombre.Text = r.Cells(Nombre.DataPropertyName).Value.ToString()
            cmbFamiliaMaterial.SelectedValue = r.Cells(Id_familia_material.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(Id_Estado.DataPropertyName).Value
            Dim mutiimagen As New ClsUtilidadesImagenes
            Pbimage.Image = mutiimagen.ArregloBytesaImagen(macabado.TraerxId(curid).Imagen)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarFamiliasMaterial()
        Try
            Dim mfamiliamaterial As New ClsFamiliaMaterial
            Dim listTiposD As List(Of FamiliaMaterial) = mfamiliamaterial.TraexEstado(1)
            Dim bsource As New BindingSource()
            bsource.DataSource = listTiposD
            listTiposD.Insert(0, New FamiliaMaterial)
            cmbFamiliaMaterial.DisplayMember = "FamiliaMaterial"
            cmbFamiliaMaterial.ValueMember = "Id"
            cmbFamiliaMaterial.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

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
    Private Sub Frm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            macabado = New ClsAcabados
            Dim objLista As List(Of Acabado) = macabado.TraerTodos(dwItems.TablaDatos)
            cargarFamiliasMaterial()
            cargarEstados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            macabado = New ClsAcabados
            If Not objValidacion.TextBoxDigitado(txtPrefijo, ErrorProvider1) Then Return False
            If Not objValidacion.TextBoxDigitado(txtnombre, ErrorProvider1) Then Return False
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If macabado.ExisteByPrefijoAndMaterial(txtPrefijo.Text, cmbFamiliaMaterial.SelectedValue) = True Then
                    ErrorProvider1.SetError(txtPrefijo, "Ya existe este prefijo en la familia de material seleccionada")
                    Return False
                End If
                ErrorProvider1.Clear()
                If macabado.ExisteByNombreAndMaterial(txtnombre.Text, cmbFamiliaMaterial.SelectedValue) = True Then
                    ErrorProvider1.SetError(txtnombre, "Ya existe este nombre en la familia de material seleccionada")
                    Return False
                End If
                ErrorProvider1.Clear()
            End If
            Return True
        Catch ex As Exception
            Return False
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validacion() Then
                Dim mutiimagen As New ClsUtilidadesImagenes
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    macabado.Ingresar(My.Settings.UsuarioActivo, txtnombre.Text, txtPrefijo.Text, mutiimagen.ImagenaArregloBytes(Pbimage.Image),
                                      cmbEstado.SelectedValue, cmbFamiliaMaterial.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    macabado.Modificar(curid, My.Settings.UsuarioActivo, txtnombre.Text, txtPrefijo.Text, mutiimagen.ImagenaArregloBytes(Pbimage.Image),
                                       cmbEstado.SelectedValue, cmbFamiliaMaterial.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                Frm_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
            If ex.Message.Contains("UNIQUE KEY 'IX_ti016_acabados_prefijo'") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(txtPrefijo, "Ya existe un acabado con este prefijo. Verifique la información")
                Return
            End If
            If ex.Message.Contains("UNIQUE KEY 'IX_ti016_acabados_nombre") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(txtnombre, "Ya existe un acabado con este nombre. Verifique la información")
                Return
            End If
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            txtPrefijo.Text = String.Empty
            txtnombre.Text = String.Empty
            cmbEstado.SelectedValue = 1
            cmbFamiliaMaterial.SelectedValue = 0
            ErrorProvider1.Clear()
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
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
    Private Sub btncargarimagen_Click(sender As System.Object, e As System.EventArgs) Handles btncargarimagen.Click
        Try
            Dim opfd As New OpenFileDialog
            opfd.Multiselect = False
            opfd.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            If opfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Pbimage.Image = Image.FromFile(opfd.FileName)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub lbcerrarImagen_Click(sender As System.Object, e As System.EventArgs) Handles lbcerrarImagen.Click
        Try
            Pbimage.Image = My.Resources.nodisponible
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class