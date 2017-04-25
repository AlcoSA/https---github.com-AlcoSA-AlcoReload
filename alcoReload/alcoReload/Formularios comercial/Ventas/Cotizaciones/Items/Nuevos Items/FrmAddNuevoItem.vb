Imports ReglasNegocio
Imports ReglasNegocio.CostoAcabado
Imports ReglasNegocio.CostoKiloAluminio
Imports ReglasNegocio.CostoNivel
Imports ReglasNegocio.movitoHijos
Imports ReglasNegocio.TasaImpuesto
Imports Validaciones

Public Class FrmAddNuevoItem
#Region "Variables"
    Private _idCotiza As Integer
    Private _familiaMaterial As ClsEnums.FamiliasMateriales
    Private _versionCostokAluminio As Integer
    Private _versionCostoAcabado As Integer
    Private _versionCostoNivel As Integer
    Private _perimetro As Decimal
    Private _idTasaImpuesto As Integer

    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curId As Integer = 0
    Private loadCompleted As Boolean = False
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
    Public Property FamiliaMaterial() As ClsEnums.FamiliasMateriales
        Get
            Return _familiaMaterial
        End Get
        Set(ByVal value As ClsEnums.FamiliasMateriales)
            _familiaMaterial = value
        End Set
    End Property
    Public Property VersionCostoKAluminio() As Integer
        Get
            Return _versionCostokAluminio
        End Get
        Set(ByVal value As Integer)
            _versionCostokAluminio = value
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
    Public Property Perimetro() As Decimal
        Get
            Return _perimetro
        End Get
        Set(ByVal value As Decimal)
            _perimetro = value
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
#End Region
#Region "Procedimientos"
    Private Sub cargarUnidadMedida()
        Try
            Dim mArticulos As New ClsArticulos
            Dim td As DataTable = mArticulos.traerUnidades()
            cmbUnidadMedida.ValueMember = "Unidad"
            cmbUnidadMedida.DisplayMember = "Unidad"
            cmbUnidadMedida.DataSource = td
            cmbUnidadMedida.SelectedValue = ""
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTasaImpuesto()
        Try
            Dim mTasaImpuesto As New ClsTasaImpuesto
            Dim ListTasasImpuesto As List(Of tasaImpuesto) = mTasaImpuesto.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbTasaImpuesto.DisplayMember = "sigla"
            cmbTasaImpuesto.ValueMember = "Id"
            cmbTasaImpuesto.DataSource = ListTasasImpuesto
            cmbTasaImpuesto.SelectedValue = 0
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

            If _familiaMaterial <> ClsEnums.FamiliasMateriales.PERFILERIA Then
                cmbNivel.SelectedValue = CInt(ClsEnums.niveles.SINNIVEL)
            Else
                cmbNivel.SelectedValue = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mArticulosTemp As New ClsArticuloTemporal
            Dim list As List(Of articuloTemporal) = mArticulosTemp.TraerxIdCotiza(_idCotiza).Where(Function(a) a.IdFamiliaMaterial = _familiaMaterial).ToList
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
                             r.Cells(item_costo.Index).Value = art.Costo
                             r.Cells(item_usuarioModi.Index).Value = art.UsuarioModificacion
                             r.Cells(item_fechaModi.Index).Value = art.FechaModificacion
                             r.Cells(item_idEstado.Index).Value = art.IdEstado
                             r.Cells(item_estado.Index).Value = art.Estado
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub configurarForm()
        Try
            Select Case _familiaMaterial
                Case ClsEnums.FamiliasMateriales.ACCESORIOS
                    lblCosto.Visible = True
                    nudCosto.Visible = True
                Case ClsEnums.FamiliasMateriales.PERFILERIA
                    nudCosto.Value = 0
                    lblNivel.Visible = True
                    cmbNivel.Visible = True
                    btnAddAcabadosTemp.Visible = True
                    btnPrecioPerfil.Visible = True
                    lblPerimetro.Visible = True
                    lblmmPerimetro.Visible = True
                    nudPerimetro.Visible = True
                Case ClsEnums.FamiliasMateriales.VIDRIO
                    nudCosto.Value = 0
                    btnAddColoresTemp.Visible = True
                    btnAddEspesoresTemp.Visible = True
                    btnPrecioVidrio.Visible = True

                    cmbUnidadMedida.Location = nudPorcDesperdicio.Location
                    lblUnidadMedida.Location = lblDesperdicio.Location

                    nudPorcDesperdicio.Location = nudPeso.Location
                    lblDesperdicio.Location = lblPeso.Location
                    lblporcDesp.Location = lblgrPeso.Location

                    lblPeso.Visible = False
                    nudPeso.Visible = False
                    lblgrPeso.Visible = False
                Case ClsEnums.FamiliasMateriales.OTROS
                    lblCosto.Visible = True
                    nudCosto.Visible = True
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            tform = ClsEnums.TiOperacion.MODIFICAR
            txtReferencia.Text = r.Cells(item_referencia.Index).Value
            txtDescripcion.Text = r.Cells(item_descripcion.Index).Value
            nudCosto.Value = r.Cells(item_costo.Index).Value
            nudPeso.Value = r.Cells(item_peso.Index).Value
            nudPerimetro.Value = r.Cells(item_perimetro.Index).Value
            nudPorcDesperdicio.Value = r.Cells(item_porcentDesperdicio.Index).Value
            cmbUnidadMedida.SelectedValue = r.Cells(item_unidadMedida.Index).Value
            cmbTasaImpuesto.SelectedValue = r.Cells(item_idTasaImpuesto.Index).Value
            cmbNivel.SelectedValue = r.Cells(item_idNivel.Index).Value
            curId = r.Cells(item_id.Index).Value
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            If MessageBox.Show("¿Está seguro de eliminar el registro?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                Dim mMovitoHijo As New ClsMovitoHijos
                If mMovitoHijo.TemporalesCotizados(_idCotiza, "ITEM", r.Cells(item_referencia.Index).Value) > 0 Then
                    MsgBox("El artículo ya existe en una cotización, no se puede eliminar")
                    Return
                End If

                Dim mArtTemp As New ClsArticuloTemporal
                mArtTemp.ActualizarEstado(r.Cells(item_id.Index).Value, ClsEnums.Estados.ARCHIVADO)

                If _familiaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA Then
                    Dim mCostoPerf As New ClsCostoPerfilTemporal
                    Dim list As List(Of costoPerfilTemporal) = mCostoPerf.TraerxPerfil(_idCotiza, True, r.Cells(item_id.Index).Value)
                    For Each cto As costoPerfilTemporal In list
                        mCostoPerf.ActualizarEstado(cto.Id, ClsEnums.Estados.ARCHIVADO)
                    Next
                ElseIf _familiaMaterial = ClsEnums.FamiliasMateriales.VIDRIO Then
                    Dim mCostoVidrio As New ClsCostoVidrioTemporal
                    Dim list As List(Of costoVidrioTemporal) = mCostoVidrio.TraerxVidrio(_idCotiza, True, r.Cells(item_id.Index).Value)
                    For Each cto As costoVidrioTemporal In list
                        mCostoVidrio.ActualizarEstado(cto.Id, ClsEnums.Estados.ARCHIVADO)
                    Next
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
            txtReferencia.Text = String.Empty
            txtDescripcion.Text = String.Empty
            nudCosto.Value = 0
            nudPeso.Value = 0.00
            nudPerimetro.Value = 0.00
            nudPorcDesperdicio.Value = 0.00
            cmbUnidadMedida.SelectedValue = String.Empty
            cmbTasaImpuesto.SelectedValue = 0
            If _familiaMaterial <> ClsEnums.FamiliasMateriales.PERFILERIA Then
                cmbNivel.SelectedValue = CInt(ClsEnums.niveles.SINNIVEL)
            Else
                cmbNivel.SelectedValue = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub InsertCostoPerfileria(idPerfil As Integer)
        Try
            Dim mCostoNivel As New ClsCostoNivel
            Dim niv As CostoNivel = mCostoNivel.TraerTodos(_versionCostoNivel).FirstOrDefault(Function(a) a.idNivel = CInt(cmbNivel.SelectedValue))
            Dim mCostoKAluminio As New ClsCostoKiloAluminio
            Dim cka As CostoKAluminio = mCostoKAluminio.TraerTodos(_versionCostokAluminio).FirstOrDefault()

            Dim mAcabado As New ClsAcabadoTemporal
            Dim mCostoAcab As New ClsCostoAcabado

            Dim mCostoPerfTemp As New ClsCostoPerfilTemporal
            Dim listAcabados As List(Of acabadoTemporal) = mAcabado.TraerconExistentes(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA)
            For Each acab As acabadoTemporal In listAcabados
                If acab.Temporal = False Then
                    Dim cac As costoAcabado = mCostoAcab.TraerTodos(_versionCostoAcabado).FirstOrDefault(Function(a) a.idAcabado = acab.IdDb)
                    Dim costo As Decimal = ((cka.Costo * nudPeso.Value) + (cac.Costo * nudPerimetro.Value)) + niv.valorCosto
                    mCostoPerfTemp.Insertar(My.Settings.UsuarioActivo, _idCotiza, True, idPerfil, acab.Temporal, acab.IdDb, cac.Id,
                                            niv.Id, cka.Id, costo, ClsEnums.Estados.ACTIVO)
                Else
                    Dim costo As Decimal = ((cka.Costo * nudPeso.Value) + (acab.Costo * nudPerimetro.Value)) + niv.valorCosto
                    mCostoPerfTemp.Insertar(My.Settings.UsuarioActivo, _idCotiza, True, idPerfil, acab.Temporal, acab.IdDb, acab.IdDb,
                                            niv.Id, cka.Id, costo, ClsEnums.Estados.ACTIVO)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            Dim mValidacion As New ClsValidaciones
            If Not mValidacion.TextBoxDigitado(txtReferencia, ErrorProvider) Then
                Return False
            End If

            If Not mValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider) Then
                Return False
            End If

            If _familiaMaterial <> ClsEnums.FamiliasMateriales.PERFILERIA And
                _familiaMaterial <> ClsEnums.FamiliasMateriales.VIDRIO Then
                If Not mValidacion.NumeroMayorACero(nudCosto, ErrorProvider) Then
                    Return False
                End If
            End If

            If nudPerimetro.Visible = True Then
                If Not mValidacion.NumeroMayorACero(nudPerimetro, ErrorProvider) Then
                    Return False
                End If
            End If

            If cmbUnidadMedida.SelectedValue Is Nothing Then
                ErrorProvider.SetError(cmbUnidadMedida, "Debe indicar la unidad de medida")
                Return False
            End If
            ErrorProvider.Clear()

            If CInt(cmbTasaImpuesto.SelectedValue) = 0 Then
                ErrorProvider.SetError(cmbTasaImpuesto, "Debe indicar la tasa de impuesto")
                Return False
            End If
            ErrorProvider.Clear()

            If CInt(cmbNivel.SelectedValue) = 0 Then
                ErrorProvider.SetError(cmbNivel, "Debe indicar el nivel")
                Return False
            End If
            ErrorProvider.Clear()

            Dim mArtTemp As New ClsArticuloTemporal
            If mArtTemp.ExisteArticulo(txtReferencia.Text) Then
                'ErrorProvider.SetError(txtReferencia, "Ya existe un artículo )
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmAddNuevoItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            configurarForm()
            cargarUnidadMedida()
            cargarTasaImpuesto()
            cargarNivel()
            cargarInformacion()

            nudPerimetro.Value = _perimetro
            cmbTasaImpuesto.SelectedValue = _idTasaImpuesto

            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudPeso.GotFocus,
        nudPerimetro.GotFocus, nudPorcDesperdicio.GotFocus, nudCosto.GotFocus
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
        nudPerimetro.Leave, nudPorcDesperdicio.Leave, nudCosto.Leave
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

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Right Then
                    dwItems.Rows(e.RowIndex).Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Modificar", Nothing, AddressOf modificar)
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If validacion() Then
                Dim mArtTemp As New ClsArticuloTemporal
                Dim idItem As Integer
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    idItem = mArtTemp.Insertar(My.Settings.UsuarioActivo, _idCotiza, txtReferencia.Text, txtDescripcion.Text,
                                      nudPeso.Value, cmbUnidadMedida.SelectedValue, nudPerimetro.Value, cmbNivel.SelectedValue,
                                      _familiaMaterial, nudPorcDesperdicio.Value, cmbTasaImpuesto.SelectedValue,
                                      nudCosto.Value, ClsEnums.Estados.ACTIVO)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mArtTemp.Modificar(curId, txtReferencia.Text, txtDescripcion.Text, nudPeso.Value, cmbUnidadMedida.SelectedValue,
                                       nudPerimetro.Value, cmbNivel.SelectedValue, nudPorcDesperdicio.Value, cmbTasaImpuesto.SelectedValue,
                                       nudCosto.Value, My.Settings.UsuarioActivo)
                End If
                MessageBox.Show("La información de ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
                cargarInformacion()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnPrecioVidrio_Click(sender As Object, e As EventArgs) Handles btnPrecioVidrio.Click
        Try
            Dim frm As New FrmAddCostoVidrioTemporal
            frm.IdCotiza = _idCotiza
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAddColoresTemp_Click(sender As Object, e As EventArgs) Handles btnAddColoresTemp.Click
        Try
            Dim frm As New FrmAddNuevoAcabado
            frm.IdCotiza = _idCotiza
            frm.FamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAddEspesoresTemp_Click(sender As Object, e As EventArgs) Handles btnAddEspesoresTemp.Click
        Dim frm As New FrmAddNuevoEspesor
        frm.IdCotiza = _idCotiza
        frm.ShowDialog()
    End Sub

    Private Sub btnAddAcabadosTemp_Click(sender As Object, e As EventArgs) Handles btnAddAcabadosTemp.Click
        Try
            Dim frm As New FrmAddNuevoAcabado
            frm.IdCotiza = _idCotiza
            frm.FamiliaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnPrecioPerfil_Click(sender As Object, e As EventArgs) Handles btnPrecioPerfil.Click
        Try
            Dim frm As New FrmAddCostoPerfilTemporal
            frm.IdCotiza = _idCotiza
            frm.VersionCostoAcabado = _versionCostoAcabado
            frm.VersionCostoNivel = _versionCostoNivel
            frm.VersionCostoAluminio = _versionCostokAluminio
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class