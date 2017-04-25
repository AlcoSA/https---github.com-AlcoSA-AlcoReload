Imports ReglasNegocio
Imports ReglasNegocio.CostoArticulo
Imports ReglasNegocio.TasaImpuesto
Imports Validaciones

Public Class FrmArticulos

#Region "Variables"
    Private mArticulos As ClsArticulos
    Private mImgArticulos As ClsImagenesArticulos
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private isLoad As Boolean = False
    Private fuenteInicial As DataTable = Nothing
    Private tieneMovimiento As Boolean = False
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
    Private Sub cargarFamiliasMaterial()
        Try
            Dim mfamiliamaterial As New ClsFamiliaMaterial
            Dim listTiposD As List(Of FamiliaMaterial) = mfamiliamaterial.TraexEstado(ClsEnums.Estados.ACTIVO)
            cmbFamiliaMaterial.DisplayMember = "FamiliaMaterial"
            cmbFamiliaMaterial.ValueMember = "Id"
            cmbFamiliaMaterial.DataSource = listTiposD.Where(Function(a) a.Id <> 1 And a.Id <> 8).ToList
            cmbFamiliaMaterial.SelectedItem = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarNiveles()
        Try
            Dim mnivelfamilia As New ClsNivelesFamilias
            Dim listniveles As List(Of NivelFamilia) = mnivelfamilia.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbNivel.DisplayMember = "Descripcion"
            cmbNivel.ValueMember = "Id"
            cmbNivel.DataSource = listniveles
            cmbNivel.SelectedItem = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarUnidadMedida()
        Try
            Dim td As DataTable = mArticulos.traerUnidades()
            cmbUnidadMedida.ValueMember = "Unidad"
            cmbUnidadMedida.DisplayMember = "Unidad"
            cmbUnidadMedida.DataSource = td
            cmbUnidadMedida.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTasasImpuesto()
        Try
            Dim mTasaImpuesto As New ClsTasaImpuesto
            Dim ListTasasImpuesto As List(Of tasaImpuesto) = mTasaImpuesto.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbTasaImpuesto.DisplayMember = "sigla"
            cmbTasaImpuesto.ValueMember = "Id"
            cmbTasaImpuesto.DataSource = ListTasasImpuesto
            cmbTasaImpuesto.SelectedItem = Nothing
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
            curid = r.Cells(Id.Index).Value
            cmbFamiliaMaterial.SelectedValue = Convert.ToInt32(r.Cells(Id_Familia_Material.Index).Value)
            cmbEstado.SelectedValue = r.Cells(Id_Estado.Index).Value
            cmbUnidadMedida.SelectedValue = r.Cells(Unidad_medida.Index).Value
            cmbNivel.SelectedValue = Convert.ToInt32(r.Cells(Id_Nivel.Index).Value)
            cmbTasaImpuesto.SelectedValue = Convert.ToInt32(r.Cells(Id_Tasa_Impuesto.Index).Value)
            txtReferencia.Text = r.Cells(Referencia.Index).Value.ToString()
            txtdescripcion.Text = r.Cells(Descripcion.Index).Value
            nudpeso.Value = r.Cells(Peso.Index).Value
            nudperimetro.Value = r.Cells(Perimetro.Index).Value
            nudPorcDesperdicio.Value = r.Cells(porcentajeDesperdicio.Index).Value
            nudcostoinstalacion.Value = r.Cells(costo_instalacion.Index).Value
            nudAltoDescunto.Value = r.Cells(Alto_para_descuentos.Index).Value
            Dim listdxfs As List(Of ImagenArticulo) = mImgArticulos.TraerxIdArticulo(curid)
            For i = 0 To listdxfs.Count - 1
                DimensionarControlImagen(listdxfs(i).Id, listdxfs(i).Descripcion,
                                         listdxfs(i).DXF, False)
            Next
            tform = ClsEnums.TiOperacion.MODIFICAR
            nudcosto.Enabled = False
            nudcosto.Value = buscarCosto(curid, cmbFamiliaMaterial.SelectedValue)
            ExisteMovimiento()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub DimensionarControlImagen(idimagen As Integer, descripcion As String, dxf As String, esruta As Boolean)
        Try
            Dim visor As New ControlesPersonalizados.VisorDXFBasico()
            visor.Id = idimagen
            visor.Descripcion = descripcion
            flpImagenes.Controls.Add(visor)
            If Not String.IsNullOrEmpty(dxf) Then
                If esruta Then
                    visor.CargarDXFdesdeRuta(dxf)
                Else
                    visor.CargarDXFdesdedxf(dxf)
                End If
            End If
            AddHandler visor.cargar_Click, AddressOf btnCargarImagen_Click
            AddHandler visor.cancelar_Click, AddressOf btnEliminarImagen_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function ExisteReferencia() As Boolean
        Try
            mArticulos = New ClsArticulos
            If mArticulos.ExisteArticulo(cmbFamiliaMaterial.SelectedValue, txtReferencia.Text) Then
                ErrorProvider.SetError(txtReferencia, "Ya existe un artículo con esta referencia en " & cmbFamiliaMaterial.Text)
                Return True
            End If
            ErrorProvider.Clear()
            Return False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function ValidacionFinal() As Boolean
        Try

            Dim objValidacion As New ClsValidaciones
            If Not objValidacion.TextBoxDigitado(txtReferencia, ErrorProvider) Then
                Return False
            End If

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If ExisteReferencia() Then
                    Return False
                End If

                If nudcosto.Visible = True Then
                    If Not objValidacion.NumeroMayorACero(nudcosto, ErrorProvider) Then
                        Return False
                    End If
                End If
            End If

            If Not objValidacion.TextBoxDigitado(txtdescripcion, ErrorProvider) Then
                Return False
            End If

            If cmbFamiliaMaterial.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbFamiliaMaterial, "Debe seleccionar la familia material")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbNivel.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbNivel, "Debe seleccionar el nivel")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbUnidadMedida.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbUnidadMedida, "Debe seleccionar la unidad de medida")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbTasaImpuesto.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbTasaImpuesto, "Debe seleccionar la tasa de impuesto")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub ExisteMovimiento()
        Try
            If curid <> 0 Then
                mArticulos = New ClsArticulos
                Dim listMovimiento As List(Of Articulo) = mArticulos.ExisteMovimiento(curid)
                If listMovimiento.Count > 0 Then
                    tieneMovimiento = True
                Else
                    tieneMovimiento = False
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionMovimiento() As Boolean
        Try
            If tieneMovimiento Then
                Dim listMovimiento As List(Of Articulo) = mArticulos.ExisteMovimiento(curid)
                Dim familia As Integer = listMovimiento.Item(0).IdFamiliaMaterial
                If Convert.ToInt32(cmbFamiliaMaterial.SelectedValue) = familia Then
                    Return True
                Else
                    Dim conteo As Integer = 0
                    For Each art As Articulo In listMovimiento
                        If art.Costo > 0 Then
                            conteo += 1
                        End If
                    Next
                    If conteo > 0 Then
                        ErrorProvider.SetError(cmbFamiliaMaterial, "No puede cambiar la familia material de un artículo que ya tiene costos")
                        Return False
                    Else
                        updateMovimiento(listMovimiento)
                        Return True
                    End If
                End If
            Else
                insertMovimiento()
                Return True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub insertMovimiento()
        Try
            Dim costo As Decimal = 0
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If nudcosto.Enabled = True Then
                    costo = nudcosto.Value
                Else
                    costo = 0
                End If
            Else
                costo = 0
            End If
            Select Case Convert.ToInt32(cmbFamiliaMaterial.SelectedValue)
                Case ClsEnums.FamiliasMateriales.ACCESORIOS
                    Dim mCostoAccesorio As New ClsCostoAccesorio
                    Dim version As Integer = mCostoAccesorio.TraerMaxVersion()
                    For vrs = 1 To version
                        mCostoAccesorio.Insertar(My.Settings.UsuarioActivo, curid, vrs, costo)
                    Next

                Case ClsEnums.FamiliasMateriales.OTROS, ClsEnums.FamiliasMateriales.TRABAJOS_VIDRIO
                    Dim mCostoOtros As New ClsCostoOtrosArticulos
                    Dim version As Integer = mCostoOtros.TraerMaxVersion()
                    For vrs = 0 To version
                        mCostoOtros.Insertar(My.Settings.UsuarioActivo, curid, cmbFamiliaMaterial.SelectedValue, vrs, costo)
                    Next
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub updateMovimiento(listMovimiento As List(Of Articulo))
        Try
            Dim familia As Integer = listMovimiento.Item(0).IdFamiliaMaterial
            Select Case familia
                Case ClsEnums.FamiliasMateriales.ACCESORIOS
                    Dim mCostoAccesorio As New ClsCostoAccesorio
                    For Each item As Articulo In listMovimiento
                        mCostoAccesorio.Eliminar(item.IdCosto)
                    Next
                Case ClsEnums.FamiliasMateriales.OTROS
                    Dim mCostoOtro As New ClsCostoOtrosArticulos
                    For Each item As Articulo In listMovimiento
                        mCostoOtro.Eliminar(item.IdCosto)
                    Next
            End Select
            insertMovimiento()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function buscarCosto(idArticulo As Integer, idFamiliaMaterial As Integer) As Decimal
        Try
            Select Case idFamiliaMaterial
                Case ClsEnums.FamiliasMateriales.ACCESORIOS
                    Dim mCosto As New ClsCostoAccesorio
                    Dim objCosto As costoAccesorio = mCosto.TraerxIdAccesorio(idArticulo, mCosto.TraerMaxVersion())
                    Return objCosto.costo
                Case ClsEnums.FamiliasMateriales.OTROS
                    Dim mCosto As New ClsCostoOtrosArticulos
                    Dim objCosto As OtrosArticulos = mCosto.TraerxIdArticulo(idArticulo, mCosto.TraerMaxVersion())
                    Return objCosto.costo
                Case ClsEnums.FamiliasMateriales.TRABAJOS_VIDRIO
                    Dim mCosto As New ClsCostoOtrosArticulos
                    Dim objCosto As OtrosArticulos = mCosto.TraerxIdArticulo(idArticulo, mCosto.TraerMaxVersion())
                    Return objCosto.costo
                Case Else
                    Return 0
            End Select
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
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
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
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
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mArticulos = New ClsArticulos
            Dim objLista As List(Of Articulo) = mArticulos.TraerTodos(dwItems.TablaDatos)
            mImgArticulos = New ClsImagenesArticulos
            cargarFamiliasMaterial()
            cargarNiveles()
            cargarUnidadMedida()
            cargarEstados()
            cargarTasasImpuesto()

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                nudcosto.Enabled = True
            Else
                nudcosto.Enabled = False
                nudcosto.Value = 0
            End If
            isLoad = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            Dim listdxf As New List(Of String)
            For i = 0 To flpImagenes.Controls.Count - 1
                listdxf.Add(DirectCast(flpImagenes.Controls(i),
                                    ControlesPersonalizados.VisorDXFBasico).Descripcion)
            Next
            Dim mensaje As String = String.Empty
            If ValidacionFinal() Then
                Dim mutiimagen As New ClsUtilidadesImagenes
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    curid = mArticulos.Ingresar(My.Settings.UsuarioActivo, cmbFamiliaMaterial.SelectedValue, txtReferencia.Text,
                                                txtdescripcion.Text, nudpeso.Value, nudperimetro.Value, cmbUnidadMedida.Text,
                                                cmbNivel.SelectedValue, cmbTasaImpuesto.SelectedValue, nudPorcDesperdicio.Value,
                                                nudcostoinstalacion.Value, cmbEstado.SelectedValue, nudAltoDescunto.Value)
                    insertMovimiento()
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    If validacionMovimiento() Then
                        mArticulos.Modificar(curid, My.Settings.UsuarioActivo, cmbFamiliaMaterial.SelectedValue, txtReferencia.Text,
                                         txtdescripcion.Text, nudpeso.Value, nudperimetro.Value, cmbUnidadMedida.Text,
                                         cmbNivel.SelectedValue, cmbTasaImpuesto.SelectedValue, nudPorcDesperdicio.Value,
                                            nudcostoinstalacion.Value, nudAltoDescunto.Value, cmbEstado.SelectedValue)
                    Else
                        Exit Sub
                    End If
                End If
                If Convert.ToInt32(cmbFamiliaMaterial.SelectedValue) = ClsEnums.FamiliasMateriales.PERFILERIA Then
                    Dim mCostoPerfil As New ClsCostoAluminio
                    mCostoPerfil.valorarPerfil(curid)
                End If
                If flpImagenes.Controls.Count > 0 Then
                    For i = 0 To flpImagenes.Controls.Count - 1
                        Dim dxfvisorb As ControlesPersonalizados.VisorDXFBasico = DirectCast(flpImagenes.Controls(i),
                                    ControlesPersonalizados.VisorDXFBasico)
                        If dxfvisorb.Id <= 0 Then
                            mImgArticulos.Insertar(My.Settings.UsuarioActivo, curid, dxfvisorb.DXF,
                                                   dxfvisorb.Descripcion, 1)
                        Else
                            mImgArticulos.Modificar(dxfvisorb.Id, My.Settings.UsuarioActivo, curid, dxfvisorb.DXF,
                       dxfvisorb.Descripcion, 1)
                        End If
                    Next
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                Frm_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            curid = 0
            txtReferencia.Text = String.Empty
            txtdescripcion.Text = String.Empty
            nudpeso.Value = 0
            nudperimetro.Value = 0
            nudPorcDesperdicio.Value = 0
            nudcosto.Value = 0
            nudAltoDescunto.Value = 0
            nudcostoinstalacion.Value = 0
            cmbFamiliaMaterial.SelectedItem = Nothing
            cmbNivel.SelectedItem = Nothing
            cmbUnidadMedida.SelectedItem = Nothing
            cmbTasaImpuesto.SelectedItem = Nothing
            flpImagenes.Controls.Clear()
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
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
    Private Sub btnagregarimagen_Click(sender As Object, e As EventArgs) Handles btnagregarimagen.Click
        Try
            DimensionarControlImagen(0, String.Empty, String.Empty, False)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCargarImagen_Click(sender As Object, e As EventArgs)
        Try
            Dim opfd As New OpenFileDialog
            opfd.Filter = "DXF (*.dxf)|*.dxf"
            If opfd.ShowDialog() = DialogResult.OK Then
                Dim mcontrol As ControlesPersonalizados.VisorDXFBasico =
                    DirectCast(sender, ControlesPersonalizados.VisorDXFBasico)
                mcontrol.CargarDXFdesdeRuta(opfd.FileName)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnEliminarImagen_Click(sender As Object, e As EventArgs)
        Try
            If MsgBox("¿Esta seguro de que quiere borrar la imagen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim mcontrol As ControlesPersonalizados.VisorDXFBasico =
                    DirectCast(sender, ControlesPersonalizados.VisorDXFBasico)
                If mcontrol.Id > 0 Then

                End If
                flpImagenes.Controls.Remove(mcontrol)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudpeso.GotFocus,
        nudperimetro.GotFocus, nudPorcDesperdicio.GotFocus, nudcosto.GotFocus, nudcostoinstalacion.GotFocus
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
    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudpeso.Leave,
        nudperimetro.Leave, nudPorcDesperdicio.Leave, nudcosto.Leave, nudcostoinstalacion.GotFocus
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
    Private Sub cmbFamiliaMaterial_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFamiliaMaterial.SelectedValueChanged
        Try
            If isLoad Then
                If tform = ClsEnums.TiOperacion.MODIFICAR Then
                    ExisteMovimiento()
                Else
                    ExisteReferencia()
                End If
            End If

            If Convert.ToInt32(cmbFamiliaMaterial.SelectedValue) = ClsEnums.FamiliasMateriales.ACCESORIOS Or
                Convert.ToInt32(cmbFamiliaMaterial.SelectedValue) = ClsEnums.FamiliasMateriales.OTROS Or
                Convert.ToInt32(cmbFamiliaMaterial.SelectedValue) = ClsEnums.FamiliasMateriales.TRABAJOS_VIDRIO Then
                lblCosto.Visible = True
                nudcosto.Visible = True
            Else
                lblCosto.Visible = False
                nudcosto.Visible = False
            End If
            nudcosto.Value = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtReferencia_Leave(sender As Object, e As EventArgs) Handles txtReferencia.Leave
        Try
            ExisteReferencia()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class
