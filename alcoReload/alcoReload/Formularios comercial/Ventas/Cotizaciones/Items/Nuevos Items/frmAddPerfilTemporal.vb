Imports ReglasNegocio
Imports ReglasNegocio.CostoAcabado
Imports ReglasNegocio.CostoKiloAluminio
Imports ReglasNegocio.CostoNivel

Public Class frmAddPerfilTemporal
#Region "Variables"
    Private _idCotiza As Integer
    Private _idTasaImpuesto As Integer
    Private _versionCostoAcabado As Integer
    Private _versionCostoNivel As Integer
    Private _versionCostoAluminio As Integer
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private loadCompleted As Boolean = False
    Private perfilExistente As Boolean = False
    Private curId As Integer = 0
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
    Public Property IdTasaImpuesto() As Integer
        Get
            Return _idTasaImpuesto
        End Get
        Set(ByVal value As Integer)
            _idTasaImpuesto = value
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
            Dim mArticuloTemp As New ClsArticuloTemporal
            Dim list As List(Of articuloTemporal) = mArticuloTemp.TraerConExistentes(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.TablaFuente)
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
    Private Sub cargarNivel()
        Try
            Dim mNivel As New ClsNivelesFamilias
            Dim listNiveles As List(Of NivelFamilia) = mNivel.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbNivel.DisplayMember = "Descripcion"
            cmbNivel.ValueMember = "Id"
            cmbNivel.DataSource = listNiveles
            cmbNivel.SelectedItem = Nothing
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
            cmbAcabado.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mArticulosTemp As New ClsArticuloTemporal
            Dim list As List(Of articuloTemporal) = mArticulosTemp.TraerxIdCotiza(_idCotiza).Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA).ToList
            list.ForEach(Sub(art)
                             Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                             r.Cells(item_id.Index).Value = art.Id
                             r.Cells(item_fechaCreacion.Index).Value = art.FechaCreacion
                             r.Cells(item_usuarioCreacion.Index).Value = art.UsuarioCreacion
                             r.Cells(item_idCotiza.Index).Value = art.IdCotiza
                             r.Cells(item_referencia.Index).Value = art.Referencia
                             r.Cells(item_descripcion.Index).Value = art.Descripcion
                             r.Cells(item_peso.Index).Value = art.Peso
                             r.Cells(item_unidadMedida.Index).Value = art.UnidadMedida
                             r.Cells(item_perimetro.Index).Value = art.Perimetro
                             r.Cells(item_idNivel.Index).Value = art.IdNivel
                             r.Cells(item_nivel.Index).Value = art.Nivel
                             r.Cells(item_idFamiliaMaterial.Index).Value = art.IdFamiliaMaterial
                             r.Cells(item_familiaMaterial.Index).Value = art.FamiliaMaterial
                             r.Cells(item_porcentDesperdicio.Index).Value = art.PorcentajeDesperdicio
                             r.Cells(item_idTasaImpuesto.Index).Value = art.IdTasaImpuesto
                             r.Cells(item_tasaImpuesto.Index).Value = art.TasaImpuesto
                             r.Cells(item_usuarioModi.Index).Value = art.UsuarioModificacion
                             r.Cells(item_fechaModi.Index).Value = art.FechaModificacion
                             r.Cells(item_idEstado.Index).Value = art.IdEstado
                             r.Cells(item_estado.Index).Value = art.Estado
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarPrecios()
        Try
            dwPrecios.Rows.Clear()
            Dim mCostoPerf As New ClsCostoPerfilTemporal
            Dim list As List(Of costoPerfilTemporal) = mCostoPerf.TraerxIdCotiza(_idCotiza)
            list.ForEach(Sub(ct)
                             Dim r As DataGridViewRow = dwPrecios.Rows(dwPrecios.Rows.Add())
                             r.Cells(prec_idCosto.Index).Value = ct.Id
                             r.Cells(prec_perfilTemporal.Index).Value = ct.PerfilTemporal
                             r.Cells(prec_idPerfil.Index).Value = ct.IdPerfil
                             r.Cells(prec_perfil.Index).Value = ct.Perfil
                             r.Cells(prec_acabadoTemporal.Index).Value = ct.AcabadoTemporal
                             r.Cells(prec_idAcabado.Index).Value = ct.IdAcabado
                             r.Cells(prec_acabado.Index).Value = ct.Acabado
                             r.Cells(prec_idCostoAcabado.Index).Value = ct.IdCostoAcabado
                             r.Cells(prec_idCostoNivel.Index).Value = ct.IdCostoNivel
                             r.Cells(prec_idCostoAluminio.Index).Value = ct.IdCostoAluminio
                             r.Cells(prec_precio.Index).Value = ct.Costo
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If itPerfil.Text = String.Empty Then
                ErrorProvider.SetError(itPerfil, "Debe ingresar la referencia")
                Return False
            End If
            ErrorProvider.Clear()

            If txtDescripcion.Text = String.Empty Then
                ErrorProvider.SetError(txtDescripcion, "Debe ingresar la descripción")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbUnidadMedida.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbUnidadMedida, "Debe indicar la unidad de medida")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbNivel.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbNivel, "Debe indicar el nivel")
                Return False
            End If
            ErrorProvider.Clear()

            If tform <> ClsEnums.TiOperacion.MODIFICAR Then
                If cmbAcabado.SelectedItem Is Nothing Then
                    ErrorProvider.SetError(btnAgregarAcabado, "Debe indicar el acabado con el cual cotizará el perfil")
                    Return False
                End If
                ErrorProvider.Clear()

                Dim mArticuloTemp As New ClsArticuloTemporal
                Dim perfil As articuloTemporal = mArticuloTemp.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.Text)

                Dim mAcabadoTemp As New ClsAcabadoTemporal
                Dim acabado As acabadoTemporal = mAcabadoTemp.TraerConExistentesByPrefijo(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, cmbAcabado.Text)

                If perfil.Id <> 0 Then
                    If perfil.Temporal = False Then
                        If acabado.Temporal = False Then
                            ErrorProvider.SetError(itPerfil, "El perfil y el acabado no son temporales")
                            ErrorProvider.SetError(btnAgregarAcabado, "El perfil y el acabado no son temporales")
                            Return False
                        End If
                        ErrorProvider.Clear()
                    End If

                    Dim mCostoPerfilTemp As New ClsCostoPerfilTemporal
                    Dim costo As costoPerfilTemporal = mCostoPerfilTemp.TraerCostoEspecifico(_idCotiza, perfil.Temporal, perfil.IdDb, acabado.Temporal, acabado.IdDb)
                    If costo.Id <> 0 Then
                        MsgBox("El perfil con el acabado indicado ya tiene un precio registrado")
                        Return False
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub editarPerfil()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim mPerfil As New ClsArticuloTemporal
            Dim perfil As articuloTemporal = mPerfil.TraerxId(_idCotiza, r.Cells(item_id.Index).Value)
            curId = perfil.Id
            tform = ClsEnums.TiOperacion.MODIFICAR
            itPerfil.Text = perfil.Referencia
            txtDescripcion.Text = perfil.Descripcion
            nudPeso.Value = perfil.Peso
            nudPorcDesperdicio.Value = perfil.PorcentajeDesperdicio
            cmbUnidadMedida.SelectedValue = perfil.UnidadMedida
            cmbNivel.SelectedValue = perfil.IdNivel
            nudPerimetro.Value = perfil.Perimetro
            cmbAcabado.Enabled = False
            btnAgregarAcabado.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub editarPrecio()
        Try
            Dim r As DataGridViewRow = dwPrecios.SelectedRows(0)
            Dim mCosto As New ClsCostoPerfilTemporal
            Dim costo As costoPerfilTemporal = mCosto.TraerCostoEspecifico(_idCotiza, r.Cells(prec_perfilTemporal.Index).Value, r.Cells(prec_idPerfil.Index).Value,
                                                                           r.Cells(prec_acabadoTemporal.Index).Value, r.Cells(prec_idAcabado.Index).Value)

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmAddPerfilTemporal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarPerfiles()
            cargarUnidadMedida()
            cargarNivel()
            cargarAcabados()
            cargarInformacion()
            cargarPrecios()
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itPerfil_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itPerfil.selected_value_changed
        Try
            If loadCompleted Then
                Dim mArtTemp As New ClsArticuloTemporal
                Dim perfil As articuloTemporal = mArtTemp.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.Text)
                txtDescripcion.Text = perfil.Descripcion
                txtDescripcion.Enabled = False
                nudPeso.Value = perfil.Peso
                nudPeso.Enabled = False
                nudPorcDesperdicio.Value = perfil.PorcentajeDesperdicio
                nudPorcDesperdicio.Enabled = False
                cmbUnidadMedida.SelectedValue = perfil.UnidadMedida
                cmbUnidadMedida.Enabled = False
                cmbNivel.SelectedValue = perfil.IdNivel
                cmbNivel.Enabled = False
                nudPerimetro.Value = perfil.Perimetro
                nudPerimetro.Enabled = False
                perfilExistente = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itPerfil_User_Edit(sender As Object, e As EventArgs) Handles itPerfil.User_Edit
        Try
            itPerfil.Seleted_rowid = Nothing
            txtDescripcion.Text = String.Empty
            txtDescripcion.Enabled = True
            nudPeso.Value = 0
            nudPeso.Enabled = True
            nudPorcDesperdicio.Value = 0
            nudPorcDesperdicio.Enabled = True
            cmbUnidadMedida.SelectedItem = Nothing
            cmbUnidadMedida.Enabled = True
            cmbNivel.SelectedItem = Nothing
            cmbNivel.Enabled = True
            nudPerimetro.Value = 0
            nudPerimetro.Enabled = True
            perfilExistente = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudPeso.GotFocus,
        nudPorcDesperdicio.GotFocus, nudPerimetro.GotFocus
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
    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudPeso.Leave,
        nudPorcDesperdicio.Leave, nudPerimetro.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.DecimalPlaces = 0 Then
                If nud.Controls.Item(1).Text = "" Then
                    nud.Controls.Item(1).Text = "0"
                    nud.Value = 0
                End If
            ElseIf nud.DecimalPlaces = 2 Then
                If nud.Controls.Item(1).Text = "" Then
                    nud.Controls.Item(1).Text = "0.00"
                    nud.Value = 0.00
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
            cargarAcabados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If validacion() Then
                Dim mArticuloTemporal As New ClsArticuloTemporal
                Dim mAcabadoTemporal As New ClsAcabadoTemporal
                Dim mCostoPerfilTemp As New ClsCostoPerfilTemporal

                Dim mCostoNivel As New ClsCostoNivel
                Dim mCostoKAluminio As New ClsCostoKiloAluminio
                Dim mCostoAcabado As New ClsCostoAcabado

                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    If Not perfilExistente Then
                        mArticuloTemporal.Insertar(My.Settings.UsuarioActivo, _idCotiza, itPerfil.Text, txtDescripcion.Text, nudPeso.Value,
                                                   cmbUnidadMedida.SelectedValue, nudPerimetro.Value, cmbNivel.SelectedValue,
                                                   ClsEnums.FamiliasMateriales.PERFILERIA, nudPorcDesperdicio.Value, _idTasaImpuesto, 0, ClsEnums.Estados.ACTIVO)
                    End If

                    Dim perfil As articuloTemporal = mArticuloTemporal.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.Text)
                    Dim acabado As acabadoTemporal = cmbAcabado.SelectedItem
                    Dim cniv As CostoNivel = mCostoNivel.TraerTodos(_versionCostoNivel).FirstOrDefault(Function(a) a.idNivel = CInt(cmbNivel.SelectedValue))
                    Dim ckla As CostoKAluminio = mCostoKAluminio.TraerTodos(_versionCostoAluminio).FirstOrDefault()
                    Dim costo As Decimal

                    If acabado.Temporal = False Then
                        Dim cacb As costoAcabado = mCostoAcabado.TraerTodos(_versionCostoAcabado).FirstOrDefault(Function(a) a.idAcabado = acabado.IdDb)
                        costo = ((ckla.Costo * nudPeso.Value) + (cacb.Costo * nudPerimetro.Value)) + cniv.valorCosto
                        mCostoPerfilTemp.Insertar(My.Settings.UsuarioActivo, _idCotiza, perfil.Temporal, perfil.Id, acabado.Temporal, acabado.IdDb, cacb.Id,
                                                  cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                    Else
                        costo = ((ckla.Costo * nudPeso.Value) + (acabado.Costo * nudPerimetro.Value)) + cniv.valorCosto
                        mCostoPerfilTemp.Insertar(My.Settings.UsuarioActivo, _idCotiza, perfil.Temporal, perfil.Id, acabado.Temporal, acabado.IdDb, acabado.IdDb,
                                                  cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                    End If
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mArticuloTemporal.Modificar(curId, itPerfil.Text, txtDescripcion.Text, nudPeso.Value, cmbUnidadMedida.SelectedValue, nudPerimetro.Value,
                                                cmbNivel.SelectedValue, nudPorcDesperdicio.Value, _idTasaImpuesto, 0, My.Settings.UsuarioActivo)

                    Dim perfil As articuloTemporal = mArticuloTemporal.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.Text)
                    Dim cniv As CostoNivel = mCostoNivel.TraerTodos(_versionCostoNivel).FirstOrDefault(Function(a) a.idNivel = CInt(cmbNivel.SelectedValue))
                    Dim ckla As CostoKAluminio = mCostoKAluminio.TraerTodos(_versionCostoAluminio).FirstOrDefault()
                    Dim costo As Decimal
                    For Each r As DataGridViewRow In dwPrecios.Rows
                        Dim acabado As acabadoTemporal = mAcabadoTemporal.TraerConExistentesByPrefijo(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, r.Cells(prec_acabado.Index).Value)
                        If acabado.Temporal = False Then
                            Dim cacb As costoAcabado = mCostoAcabado.TraerTodos(_versionCostoAcabado).FirstOrDefault(Function(a) a.idAcabado = acabado.Id)
                            costo = ((ckla.Costo * perfil.Peso) + (cacb.Costo * perfil.Perimetro)) + cniv.valorCosto
                            For Each row As DataGridViewRow In dwPrecios.Rows
                                If CInt(row.Cells(prec_idPerfil.Index).Value) = perfil.Id And CBool(row.Cells(prec_perfilTemporal.Index).Value) = perfil.Temporal And
                                    CInt(row.Cells(prec_idAcabado.Index).Value) = acabado.Id And CInt(row.Cells(prec_acabadoTemporal.Index).Value) = acabado.Temporal Then
                                    mCostoPerfilTemp.Modificar(CInt(row.Cells(prec_idCosto.Index).Value), cacb.Id, cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                                End If
                            Next

                        Else
                            costo = ((ckla.Costo * perfil.Peso) + (acabado.Costo * perfil.Perimetro)) + cniv.valorCosto
                            For Each row As DataGridViewRow In dwPrecios.Rows
                                If CInt(row.Cells(prec_idPerfil.Index).Value) = perfil.Id And CBool(row.Cells(prec_perfilTemporal.Index).Value) = perfil.Temporal And
                                    CInt(row.Cells(prec_idAcabado.Index).Value) = acabado.Id And CInt(row.Cells(prec_acabadoTemporal.Index).Value) = acabado.Temporal Then
                                    mCostoPerfilTemp.Modificar(CInt(row.Cells(prec_idCosto.Index).Value), acabado.Id, cniv.Id, ckla.Id, costo, ClsEnums.Estados.ACTIVO)
                                End If
                            Next
                        End If
                    Next
                End If

                MessageBox.Show("La información se ha guardado exitosamente")
                btnLimpiar_Click(Nothing, Nothing)
                frmAddPerfilTemporal_Load(Nothing, Nothing)
            End If
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
                    menu.Items.Add("Modificar", Nothing, AddressOf editarPerfil)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            curId = 0
            tform = ClsEnums.TiOperacion.INSERTAR
            loadCompleted = False
            perfilExistente = False
            itPerfil.Text = String.Empty
            itPerfil.Seleted_rowid = Nothing
            txtDescripcion.Text = String.Empty
            nudPeso.Value = 0.00
            nudPorcDesperdicio.Value = 0.00
            cmbUnidadMedida.SelectedItem = Nothing
            cmbNivel.SelectedItem = Nothing
            nudPerimetro.Value = 0.00
            cmbAcabado.SelectedItem = Nothing
            cmbAcabado.Enabled = True
            btnAgregarAcabado.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class