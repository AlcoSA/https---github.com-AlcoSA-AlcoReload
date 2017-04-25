Imports ReglasNegocio
Imports ReglasNegocio.CostoArticulo

Public Class FrmAddPerfil
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _curId As Integer = 0
    Private _perfil As articuloTemporal
    Private _acabado As acabadoTemporal
    Private _cantidad As Integer
    Private _ancho As Decimal
    Private _piezasxUnidad As Decimal
    Private _descuento As Decimal
    Private _idCotiza As Integer
    Private _versionCostoAcabado As Integer
    Private _versionCostoNivel As Integer
    Private _versionCostoKAluminio As Integer
    Private _dTableTrabajos As DataTable
    Private Sep As Char
    Private tformTrabajos As ClsEnums.TiOperacion
    Private _costointalauni As Decimal = 0
#End Region
#Region "Propiedades"
    Public Property Operacion() As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Property CurId() As Integer
        Get
            Return _curId
        End Get
        Set(ByVal value As Integer)
            _curId = value
        End Set
    End Property
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property ancho() As Decimal
        Get
            Return _ancho
        End Get
        Set(ByVal value As Decimal)
            _ancho = value
        End Set
    End Property
    Public Property piezasxUnidad() As Decimal
        Get
            Return _piezasxUnidad
        End Get
        Set(ByVal value As Decimal)
            _piezasxUnidad = value
        End Set
    End Property
    Public Property factor() As Decimal
        Get
            Return nudfactor.Value
        End Get
        Set(ByVal value As Decimal)
            nudfactor.Value = value
        End Set
    End Property
    Public Property descuento() As Decimal
        Get
            Return _descuento
        End Get
        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property
    Public Property Perfil() As articuloTemporal
        Get
            Return _perfil
        End Get
        Set(ByVal value As articuloTemporal)
            _perfil = value
        End Set
    End Property
    Public Property Acabado() As acabadoTemporal
        Get
            Return _acabado
        End Get
        Set(ByVal value As acabadoTemporal)
            _acabado = value
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
    Public Property VersionCostoKAluminio() As Integer
        Get
            Return _versionCostoKAluminio
        End Get
        Set(ByVal value As Integer)
            _versionCostoKAluminio = value
        End Set
    End Property
    Public Property DTableTrabajos() As DataTable
        Get
            Return _dTableTrabajos
        End Get
        Set(ByVal value As DataTable)
            _dTableTrabajos = value
        End Set
    End Property
    Public Property CostoInstalacionUnitario As Decimal
        Get
            Return _costointalauni
        End Get
        Set(value As Decimal)
            _costointalauni = value
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
    Private Sub cargarAcabados()
        Try
            Dim mAcabTemp As New ClsAcabadoTemporal
            Dim list As List(Of acabadoTemporal) = mAcabTemp.TraerconExistentes(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA)
            cmbAcabado.DisplayMember = "Prefijo"
            cmbAcabado.DatosVisibles = {"Prefijo", "Nombre"}
            cmbAcabado.ValueMember = "Id"
            cmbAcabado.DataSource = list
            cmbAcabado.SelectedValue = _acabado.Id
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTrabajos()
        Try
            Dim mTrabajo As New ClsTrabajosItems
            Dim listTrabajos As List(Of trabajoItems) = mTrabajo.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.PERFILERIA)
            cmbTrabajo.DisplayMember = "Prefijo"
            cmbTrabajo.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbTrabajo.ValueMember = "Id"
            cmbTrabajo.DataSource = listTrabajos
            cmbTrabajo.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If itPerfil.Text = String.Empty Then
                ErrorProvider.SetError(itPerfil, "Debe indicar el perfil que va a agregar")
                Return False
            End If
            ErrorProvider.Clear()
            If itPerfil.Seleted_rowid Is Nothing Then
                ErrorProvider.SetError(itPerfil, "No se ha seleccionado ningún perfil")
                Return False
            End If
            ErrorProvider.Clear()
            If CInt(cmbAcabado.SelectedValue) = 0 Then
                ErrorProvider.SetError(cmbAcabado, "Debe seleccionar el acabado")
                Return False
            End If
            ErrorProvider.Clear()
            If nudAncho.Value = 0 Then
                ErrorProvider.SetError(nudAncho, "El ancho del perfil debe ser superior a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()
            If nudCantidad.Value = 0 Then
                ErrorProvider.SetError(nudCantidad, "La cantidad debe ser superior a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()
            If nudPiezasxUnidad.Value = 0 Then
                ErrorProvider.SetError(nudPiezasxUnidad, "El número de piezas por unidad debe ser superior a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()

            Dim mCostoPerfil As New ClsCostoAluminio
            Dim mCostoPerfTemp As New ClsCostoPerfilTemporal
            Dim mArtTemp As New ClsArticuloTemporal
            Dim perf As articuloTemporal = mArtTemp.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.Text)
            Dim acab As acabadoTemporal = cmbAcabado.SelectedItem
            If perf.Temporal = False Then
                If acab.Temporal = True Then
                    If mCostoPerfTemp.TraerCostoEspecifico(_idCotiza, perf.Temporal, perf.Id, acab.Temporal, acab.IdDb).Costo = 0 Then
                        MessageBox.Show("El perfil que está agregando no tiene ningún precio")
                        Return False
                    End If
                    Return True
                End If
                If mCostoPerfil.TraerCostoEspecifico(perf.Id, acab.IdDb, _versionCostoAcabado, _versionCostoNivel, _versionCostoKAluminio) = 0 Then
                    MessageBox.Show("El perfil que está agregando no tiene ningún precio")
                    Return False
                End If
            Else
                If mCostoPerfTemp.TraerCostoEspecifico(_idCotiza, perf.Temporal, perf.Id, acab.Temporal, acab.IdDb).Costo = 0 Then
                    MessageBox.Show("El perfil que está agregando no tiene ningún precio")
                    Return False
                End If
            End If

            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If r.Cells(col_cantidad.Index).Value Is Nothing Or Convert.ToString(r.Cells(col_cantidad.Index).Value) = String.Empty Then
                    conteo += 1
                End If
            Next

            If conteo > 0 Then
                ErrorProvider.SetError(dwItems, "Una o más celdas de cantidad se encuentran vacías")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub guardarTrabajos()
        Try
            If tformTrabajos = ClsEnums.TiOperacion.INSERTAR Then
                If _curId <> 0 Then
                    Dim mMovitoTrabajos As New ClsMovitoTrabajosCotiza
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = _curId
                        row("cantidad") = r.Cells(col_cantidad.Index).Value

                        mMovitoTrabajos.Insertar(My.Settings.UsuarioActivo, _curId, r.Cells(col_idTrabajo.Index).Value,
                                                 r.Cells(col_cantidad.Index).Value, ClsEnums.Estados.ACTIVO)
                    Next
                Else
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = Nothing
                        row("cantidad") = r.Cells(col_cantidad.Index).Value
                    Next
                End If
            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                If _dTableTrabajos Is Nothing Then
                    _dTableTrabajos = New DataTable
                    _dTableTrabajos.Columns.Add("idTrabajo")
                    _dTableTrabajos.Columns.Add("idHijo")
                    _dTableTrabajos.Columns.Add("cantidad")
                End If
                If _curId <> 0 Then
                    Dim mMovitoTrabajo As New ClsMovitoTrabajosCotiza
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = _curId
                        row("cantidad") = r.Cells(col_cantidad.Index).Value
                        If r.Cells(col_id.Index).Value Is Nothing Or Convert.ToString(r.Cells(col_id.Index).Value) = String.Empty Then
                            mMovitoTrabajo.Insertar(My.Settings.UsuarioActivo, _curId, r.Cells(col_idTrabajo.Index).Value,
                                                    r.Cells(col_cantidad.Index).Value, ClsEnums.Estados.ACTIVO)
                        Else
                            mMovitoTrabajo.Modificar(r.Cells(col_id.Index).Value, r.Cells(col_cantidad.Index).Value)
                        End If
                    Next
                Else
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = Nothing
                        row("cantidad") = r.Cells(col_cantidad.Index).Value
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMovitoTrabajos()
        Try
            Dim mCosto As New ClsCostoTrabajoItem
            If tformTrabajos = ClsEnums.TiOperacion.INSERTAR Then
                _dTableTrabajos = New DataTable
                _dTableTrabajos.Columns.Add("idTrabajo")
                _dTableTrabajos.Columns.Add("idHijo")
                _dTableTrabajos.Columns.Add("cantidad")
            End If
            If tformTrabajos = ClsEnums.TiOperacion.MODIFICAR Then
                If _curId <> 0 Then
                    dwItems.Rows.Clear()
                    Dim mMovitoTrabajo As New ClsMovitoTrabajosCotiza
                    Dim list As List(Of movitoTrabajoCotiza) = mMovitoTrabajo.TraerxIdHijo(_curId)
                    For Each mov As movitoTrabajoCotiza In list
                        Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                        r.Cells(col_id.Index).Value = mov.Id
                        r.Cells(col_idTrabajo.Index).Value = mov.IdTrabajo
                        r.Cells(col_prefijo.Index).Value = mov.Prefijo
                        r.Cells(col_descripcion.Index).Value = mov.Descripcion
                        r.Cells(col_unMedida.Index).Value = mov.UnidadMedida
                        r.Cells(col_costo.Index).Value = mCosto.TraerEspecifico(1, mov.IdTrabajo).Costo
                        r.Cells(col_cantidad.Index).Value = mov.Cantidad
                    Next
                ElseIf _dTableTrabajos IsNot Nothing Then
                    dwItems.Rows.Clear()
                    Dim mTrabajo As New ClsTrabajosItems
                    For Each row As DataRow In _dTableTrabajos.Rows
                        Dim trabajo As trabajoItems = mTrabajo.TraerxId(row.Item("idTrabajo"))
                        Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                        r.Cells(col_id.Index).Value = String.Empty
                        r.Cells(col_idTrabajo.Index).Value = trabajo.Id
                        r.Cells(col_prefijo.Index).Value = trabajo.Prefijo
                        r.Cells(col_descripcion.Index).Value = trabajo.Descripcion
                        r.Cells(col_unMedida.Index).Value = trabajo.UnidadMedida
                        r.Cells(col_costo.Index).Value = mCosto.TraerEspecifico(1, trabajo.Id).Costo
                        r.Cells(col_cantidad.Index).Value = row.Item("cantidad")
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminarTrabajos()
        Try
            Dim r As DataGridViewRow = dwItems.CurrentRow()
            If r.Cells(col_id.Index).Value Is Nothing OrElse r.Cells(col_id.Index).Value Is String.Empty Then
                dwItems.Rows.Remove(r)
            Else
                Dim mMovitoTrabajos As New ClsMovitoTrabajosCotiza
                mMovitoTrabajos.ActualizarEstado(r.Cells(col_id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                dwItems.Rows.Remove(r)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmAddPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarPerfiles()
            cargarAcabados()
            cargarTrabajos()
            If tform = ClsEnums.TiOperacion.MODIFICAR Then
                itPerfil.Text = _perfil.Referencia
                itPerfil.Seleted_rowid = _perfil.Id
                cmbAcabado.SelectedValue = _acabado.Id
                nudAncho.Value = _ancho
                nudCantidad.Value = _cantidad
                nudPiezasxUnidad.Value = _piezasxUnidad
            End If
            If _curId <> 0 Then
                Dim mMovitoTrabajos As New ClsMovitoTrabajosCotiza
                Dim list As List(Of movitoTrabajoCotiza) = mMovitoTrabajos.TraerxIdHijo(_curId)
                If list.Count = 0 Then
                    tformTrabajos = ClsEnums.TiOperacion.INSERTAR
                Else
                    tformTrabajos = ClsEnums.TiOperacion.MODIFICAR
                End If
            Else
                If _dTableTrabajos Is Nothing Then
                    tformTrabajos = ClsEnums.TiOperacion.INSERTAR
                Else
                    tformTrabajos = ClsEnums.TiOperacion.MODIFICAR
                End If
            End If
            cargarMovitoTrabajos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If validacion() Then
                Dim mArtTemp As New ClsArticuloTemporal
                _perfil = mArtTemp.TraerConExistentesPorReferencia(_idCotiza, ClsEnums.FamiliasMateriales.PERFILERIA, itPerfil.Text)
                _acabado = cmbAcabado.SelectedItem
                _ancho = nudAncho.Value
                _cantidad = nudCantidad.Value
                _piezasxUnidad = nudPiezasxUnidad.Value
                guardarTrabajos()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudAncho.GotFocus,
        nudCantidad.GotFocus, nudPiezasxUnidad.GotFocus
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

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudAncho.Leave, nudCantidad.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0"
                nud.Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nudPiezasxUnidad_Leave(sender As Object, e As EventArgs) Handles nudPiezasxUnidad.Leave
        Try
            If nudPiezasxUnidad.Controls.Item(1).Text = "" Then
                nudPiezasxUnidad.Controls.Item(1).Text = "0.00"
                nudPiezasxUnidad.Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregarTrabajo_Click(sender As Object, e As EventArgs) Handles btnAgregarTrabajo.Click
        Try
            If cmbTrabajo.SelectedItem IsNot Nothing Then
                Dim trabajo As trabajoItems = cmbTrabajo.SelectedItem
                Dim mCosto As New ClsCostoTrabajoItem
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(col_idTrabajo.Index).Value = trabajo.Id
                r.Cells(col_prefijo.Index).Value = trabajo.Prefijo
                r.Cells(col_descripcion.Index).Value = trabajo.Descripcion
                r.Cells(col_unMedida.Index).Value = trabajo.UnidadMedida
                r.Cells(col_costo.Index).Value = mCosto.TraerEspecifico(1, trabajo.Id).Costo
                cmbTrabajo.SelectedItem = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is col_cantidad Then
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

            If dwItems.Columns(columnIndex) Is col_cantidad Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
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
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminarTrabajos)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class