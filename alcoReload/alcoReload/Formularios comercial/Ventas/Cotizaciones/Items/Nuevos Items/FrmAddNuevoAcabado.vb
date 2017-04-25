Imports ReglasNegocio
Imports ReglasNegocio.movitoHijos
Imports Validaciones

Public Class FrmAddNuevoAcabado
#Region "Variables"
    Private curId As Integer
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _idCotiza As Integer
    Private _familiaMaterial As ClsEnums.FamiliasMateriales
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
#End Region
#Region "Procedimientos"
    Private Sub configurarForm()
        Try
            If _familiaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA Then
                Me.Text = "Acabado temporal"
            ElseIf _familiaMaterial = ClsEnums.FamiliasMateriales.VIDRIO Then
                Me.Text = "Color temporal"
                lblCosto.Visible = False
                nudCosto.Visible = False
                nudCosto.Value = 0
                dwItems.Columns(costo.Index).Visible = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mAcabadoTemp As New ClsAcabadoTemporal
            Dim list As List(Of acabadoTemporal) = mAcabadoTemp.TraerxIdCotiza(_idCotiza).Where(Function(a) a.IdFamiliaMaterial = _familiaMaterial).ToList
            For Each acab As acabadoTemporal In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(id.Index).Value = acab.Id
                r.Cells(fechaCreacion.Index).Value = acab.FechaCreacion
                r.Cells(usuarioCreacion.Index).Value = acab.UsuarioCreacion
                r.Cells(prefijo.Index).Value = acab.Prefijo
                r.Cells(nombre.Index).Value = acab.Nombre
                r.Cells(costo.Index).Value = acab.Costo
                r.Cells(usuarioModi.Index).Value = acab.UsuarioModificacion
                r.Cells(fechaModi.Index).Value = acab.FechaModificacion
                r.Cells(idEstado.Index).Value = acab.IdEstado
                r.Cells(estado.Index).Value = acab.Estado
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            txtPrefijo.Text = r.Cells(prefijo.Index).Value
            txtNombre.Text = r.Cells(nombre.Index).Value
            nudCosto.Value = r.Cells(costo.Index).Value
            curId = r.Cells(id.Index).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
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
            If Not mValidacion.TextBoxDigitado(txtNombre, ErrorProvider) Then
                Return False
            End If
            If _familiaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA Then
                If Not mValidacion.NumeroMayorACero(nudCosto, ErrorProvider) Then
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub Limpiar()
        curId = Nothing
        tform = ClsEnums.TiOperacion.INSERTAR
        txtPrefijo.Text = String.Empty
        txtNombre.Text = String.Empty
        nudCosto.Value = 0
    End Sub
    Private Sub Eliminar()
        Try
            If MessageBox.Show("¿Está seguro de eliminar el registro?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                Dim mMovitoHijo As New ClsMovitoHijos
                If _familiaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA Then
                    If mMovitoHijo.TemporalesCotizados(_idCotiza, "ACAB", r.Cells(prefijo.Index).Value) > 0 Then
                        MsgBox("El artículo ya existe en una cotización, no se puede eliminar")
                        Return
                    End If
                    Dim mCostoPerf As New ClsCostoPerfilTemporal
                    Dim list As List(Of costoPerfilTemporal) = mCostoPerf.TraerxAcabado(_idCotiza, True, r.Cells(id.Index).Value)
                    For Each ct As costoPerfilTemporal In list
                        mCostoPerf.ActualizarEstado(ct.Id, ClsEnums.Estados.ARCHIVADO)
                    Next
                ElseIf _familiaMaterial = ClsEnums.FamiliasMateriales.VIDRIO Then
                    If mMovitoHijo.TemporalesCotizados(_idCotiza, "COLO", r.Cells(prefijo.Index).Value) > 0 Then
                        MsgBox("El artículo ya existe en una cotización, no se puede eliminar")
                        Return
                    End If
                    Dim mCostoVidrio As New ClsCostoVidrioTemporal
                    Dim list As List(Of costoVidrioTemporal) = mCostoVidrio.TraerxColor(_idCotiza, True, r.Cells(id.Index).Value)
                    For Each ct As costoVidrioTemporal In list
                        mCostoVidrio.ActualizarEstado(ct.Id, ClsEnums.Estados.ARCHIVADO)
                    Next
                End If

                Dim mAcabTemp As New ClsAcabadoTemporal
                mAcabTemp.ActualizarEstado(r.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)

                cargarInformacion()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmAcabadosTemporales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            configurarForm()
            cargarInformacion()
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
                    menu.Items.Add("Eliminar", Nothing, AddressOf Eliminar)
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
                Dim mAcabadoTemp As New ClsAcabadoTemporal
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mAcabadoTemp.Insertar(My.Settings.UsuarioActivo, txtPrefijo.Text, txtNombre.Text, _familiaMaterial,
                                          _idCotiza, nudCosto.Value, ClsEnums.Estados.ACTIVO)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mAcabadoTemp.Modificar(curId, txtNombre.Text, txtPrefijo.Text, nudCosto.Value, My.Settings.UsuarioActivo)
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar()
                cargarInformacion()
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
End Class