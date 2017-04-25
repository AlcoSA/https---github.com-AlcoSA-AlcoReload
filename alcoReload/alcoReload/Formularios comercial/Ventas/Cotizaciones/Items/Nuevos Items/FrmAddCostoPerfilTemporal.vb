Imports ReglasNegocio
Imports ReglasNegocio.CostoAcabado
Imports ReglasNegocio.CostoKiloAluminio
Imports ReglasNegocio.CostoNivel
Imports ReglasNegocio.movitoHijos

Public Class FrmAddCostoPerfilTemporal
#Region "Variables"
    Private _idCotiza As Integer
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curId As Integer = 0
    Private perf As articuloTemporal
    Private acab As acabadoTemporal

    Private _versionCostoAcabado As Integer
    Private _versionCostoNivel As Integer
    Private _versionCostoAluminio As Integer

    Private Sep As Char
#End Region
#Region "Propiedades"
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property VersionCostoAcabado() As Integer
        Get
            Return _versionCostoAcabado
        End Get
        Set(ByVal value As Integer)
            _versionCostoAcabado = value
        End Set
    End Property
    Public Property VersionCostoNivel() As Integer
        Get
            Return _versionCostoNivel
        End Get
        Set(ByVal value As Integer)
            _versionCostoNivel = value
        End Set
    End Property
    Public Property VersionCostoAluminio() As Integer
        Get
            Return _versionCostoAluminio
        End Get
        Set(ByVal value As Integer)
            _versionCostoAluminio = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarPerfiles()
        Try
            Dim mArticuloTemporal As New ClsArticuloTemporal
            Dim listArtTemp As List(Of articuloTemporal) = mArticuloTemporal.TraerConExistentes(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.TablaFuente)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarAcabados()
        Try
            Dim mAcabTemp As New ClsAcabadoTemporal
            Dim listAcab As List(Of acabadoTemporal) = mAcabTemp.TraerconExistentes(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA)
            cmbAcabado.DatosVisibles = {"Prefijo", "Nombre"}
            cmbAcabado.DisplayMember = "Prefijo"
            cmbAcabado.ValueMember = "Id"
            cmbAcabado.DataSource = listAcab
            cmbAcabado.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mCostoPerf As New ClsCostoPerfilTemporal
            Dim list As List(Of costoPerfilTemporal) = mCostoPerf.TraerxIdCotiza(_idCotiza)
            list.ForEach(Sub(ct)
                             Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                             r.Cells(item_idCosto.Index).Value = ct.Id
                             r.Cells(item_perfilTemporal.Index).Value = ct.PerfilTemporal
                             r.Cells(item_idPerfil.Index).Value = ct.IdPerfil
                             r.Cells(item_perfil.Index).Value = ct.Perfil
                             r.Cells(item_acabadoTemporal.Index).Value = ct.AcabadoTemporal
                             r.Cells(item_idAcabado.Index).Value = ct.IdAcabado
                             r.Cells(item_acabado.Index).Value = ct.Acabado
                             r.Cells(item_idCostoAcabado.Index).Value = ct.IdCostoAcabado
                             r.Cells(item_idCostoNivel.Index).Value = ct.IdCostoNivel
                             r.Cells(item_idCostoAluminio.Index).Value = ct.IdCostoAluminio
                             r.Cells(item_costo.Index).Value = ct.Costo
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionAgregar() As Boolean
        Try
            If perf.Id = 0 Then
                MsgBox("Hay items sin seleccionar")
                Return False
            End If
            If CInt(cmbAcabado.SelectedValue) = 0 Then
                MsgBox("Hay items sin seleccionar")
                Return False
            End If
            '----------------------------------------
            Dim conteoTemporales As Integer = 0
            If perf.Temporal = True Then
                conteoTemporales += 1
            End If
            If acab.Temporal = True Then
                conteoTemporales += 1
            End If
            If conteoTemporales = 0 Then
                MsgBox("Ninguno de los items seleccionados es temporal")
                Return False
            End If
            '---------------------------------------
            Dim mCostoPerfil As New ClsCostoPerfilTemporal
            Dim costo As costoPerfilTemporal = mCostoPerfil.TraerCostoEspecifico(_idCotiza, perf.Temporal, perf.Id, acab.Temporal, acab.IdDb)
            If costo.Id <> 0 Then
                MsgBox("La combinación de items ya tiene un precio registrado")
                Return False
            End If
            '---------------------------------------
            Dim conteofilas As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CBool(r.Cells(item_perfilTemporal.Index).Value) = perf.Temporal And CInt(r.Cells(item_idPerfil.Index).Value) = perf.Id And
                    CBool(r.Cells(item_acabadoTemporal.Index).Value) = acab.Temporal And CInt(r.Cells(item_idAcabado.Index).Value) = acab.Id Then
                    conteofilas += 1
                End If
            Next
            If conteofilas > 0 Then
                MsgBox("Ya agregó esta combinación de items")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub eliminar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If MessageBox.Show("¿Está seguro de eliminar el registro?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                If r.Cells(item_idCosto.Index).Value Is Nothing Then
                    dwItems.Rows.Remove(r)
                Else
                    Dim mCostoPerf As New ClsCostoPerfilTemporal
                    mCostoPerf.ActualizarEstado(r.Cells(item_idCosto.Index).Value, ClsEnums.Estados.ARCHIVADO)
                End If
                cargarInformacion()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiar()
        Try
            tform = ClsEnums.TiOperacion.INSERTAR
            curId = 0
            itPerfil.Seleted_rowid = Nothing
            itPerfil.Text = String.Empty
            cmbAcabado.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmAddCostoPerfilTemporal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarPerfiles()
            cargarAcabados()
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itPerfil_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itPerfil.selected_value_changed
        Try
            Dim mArtTemp As New ClsArticuloTemporal
            perf = mArtTemp.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.Text)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbAcabado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAcabado.SelectedValueChanged
        Try
            acab = cmbAcabado.SelectedItem
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If validacionAgregar() Then
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(item_perfilTemporal.Index).Value = perf.Temporal
                r.Cells(item_idPerfil.Index).Value = perf.Id
                r.Cells(item_perfil.Index).Value = perf.Referencia
                r.Cells(item_acabadoTemporal.Index).Value = acab.Temporal
                r.Cells(item_idAcabado.Index).Value = acab.Id
                r.Cells(item_acabado.Index).Value = acab.Prefijo
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is item_costo Then
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

            If dwItems.Columns(columnIndex) Is item_costo Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            dwItems.EndEdit()
            Dim mCostoPerf As New ClsCostoPerfilTemporal

            Dim mArticulo As New ClsArticuloTemporal
            Dim mAcabado As New ClsAcabadoTemporal

            Dim mCostoNivel As New ClsCostoNivel
            Dim mCostoKAluminio As New ClsCostoKiloAluminio
            Dim mCostoAcabado As New ClsCostoAcabado

            For Each r As DataGridViewRow In dwItems.Rows
                Dim art As articuloTemporal = mArticulo.TraerConExistentesPorReferencia(_idCotiza,
                                                                                            ClsEnums.FamiliasMateriales.PERFILERIA,
                                                                                            r.Cells(item_perfil.Index).Value)
                Dim aca As acabadoTemporal = mAcabado.TraerConExistentesByPrefijo(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA,
                                                                                      r.Cells(item_acabado.Index).Value)

                Dim cniv As CostoNivel = mCostoNivel.TraerTodos(_versionCostoNivel).FirstOrDefault(Function(a) a.idNivel = CInt(art.IdNivel))
                Dim ckla As CostoKAluminio = mCostoKAluminio.TraerTodos(_versionCostoAluminio).FirstOrDefault()
                If r.Cells(item_idCosto.Index).Value Is Nothing Then
                    Dim costo As Decimal
                    If aca.Temporal = False Then
                        Dim cacb As costoAcabado = mCostoAcabado.TraerTodos(_versionCostoAcabado).FirstOrDefault(Function(a) a.idAcabado = aca.Id)
                        costo = ((ckla.Costo * art.Peso) + (cacb.Costo * art.Perimetro)) + cniv.valorCosto
                        mCostoPerf.Insertar(My.Settings.UsuarioActivo, _idCotiza, art.Temporal, art.Id, aca.Temporal, aca.Id,
                                                cacb.Id, cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                    Else
                        costo = ((ckla.Costo * art.Peso) + (aca.Costo * art.Perimetro)) + cniv.valorCosto
                        mCostoPerf.Insertar(My.Settings.UsuarioActivo, _idCotiza, art.Temporal, art.Id, aca.Temporal, aca.Id,
                                                aca.Id, cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                    End If
                Else
                    Dim costo As Decimal
                    If aca.Temporal = False Then
                        Dim cacb As costoAcabado = mCostoAcabado.TraerTodos(_versionCostoAcabado).FirstOrDefault(Function(a) a.idAcabado = aca.Id)
                        costo = ((ckla.Costo * art.Peso) + (cacb.Costo * art.Perimetro)) + cniv.valorCosto
                        mCostoPerf.Modificar(r.Cells(item_idCosto.Index).Value, cacb.Id, cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                    Else
                        costo = ((ckla.Costo * art.Peso) + (aca.Costo * art.Perimetro)) + cniv.valorCosto
                        mCostoPerf.Modificar(r.Cells(item_idCosto.Index).Value, aca.Id, cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                    End If
                End If
            Next
            MessageBox.Show("La información de ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            limpiar()
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    dwItems.Rows(e.RowIndex).Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregarAcabado_Click(sender As Object, e As EventArgs) Handles btnAgregarAcabado.Click
        Try
            Dim frm As New FrmAddNuevoAcabado
            frm.IdCotiza = _idCotiza
            frm.FamiliaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class