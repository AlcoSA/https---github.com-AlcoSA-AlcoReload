Imports ReglasNegocio
Imports Validaciones

Public Class FrmVelocidadesViento

#Region "Variables"
    Private mvelocidades As ClsVelocidadesViento
    Private mciudades As Ciudades.ClsCiudades
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
            bsource.DataSource = listEstados.Where(Function(a) a.Id <> 3)
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(Id.DataPropertyName).Value)
            nudvalor.Value = Convert.ToDecimal(r.Cells(Valor.DataPropertyName).Value)
            cmbversion.SelectedValue = Convert.ToInt32(r.Cells(Id_Version_CV.DataPropertyName).Value)
            cmbEstado.SelectedValue = r.Cells(Id_Estado.DataPropertyName).Value
            Dim c As Ciudades.Ciudad = mciudades.TraerIdDptoAndIdPais(Convert.ToInt32(r.Cells(Id_Ciudad.DataPropertyName).Value))
            cmbPais.SelectedValue = c.idPais
            cmbDepartamento.SelectedValue = c.idDepartamento
            cmbCiudad.SelectedValue = Convert.ToInt32(r.Cells(Id_Ciudad.DataPropertyName).Value)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarVersiones()
        Try
            Dim mversiones As New ClsVersionesCargasViento
            Dim listTiposD As List(Of VersionCargasViento) = mversiones.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listTiposD
            listTiposD.Insert(0, New VersionCargasViento)
            cmbversion.DisplayMember = "Version"
            cmbversion.ValueMember = "Id"
            cmbversion.DataSource = bsource
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub CargarPaises()
        Try
            Dim mPais As New ClsPaises
            Dim listPaises As List(Of Pais) = mPais.TraerxValorDefecto()
            If Not mPais.ExisteValorDefecto Then
                listPaises.Insert(0, New Pais)
            End If
            cmbPais.DisplayMember = "descripcion"
            cmbPais.ValueMember = "Id"
            cmbPais.DataSource = listPaises
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub cargarDepartamento(idPais As Integer)
        Try
            Dim mDepto As New ClsDepartamentos
            Dim listDptos As List(Of Departamento) = mDepto.TraerxValorDefectoAndIdPais(idPais)
            If Not mDepto.ExisteValorDefecto Then listDptos.Insert(0, New Departamento)
            cmbDepartamento.DisplayMember = "descripcion"
            cmbDepartamento.ValueMember = "Id"
            cmbDepartamento.DataSource = listDptos
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarCiudades(idDpto As Integer)
        Try
            mciudades = New Ciudades.ClsCiudades
            Dim listCiudades As List(Of Ciudades.Ciudad) = mciudades.TraerxIdDepartamentoAndValorDefecto(idDpto)
            If Not mciudades.ExisteValorDefecto Then listCiudades.Insert(0, New Ciudades.Ciudad)
            cmbCiudad.DisplayMember = "nombreCiudad"
            cmbCiudad.ValueMember = "Id"
            cmbCiudad.DataSource = listCiudades
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
            mvelocidades = New ClsVelocidadesViento
            Dim objLista As List(Of VelocidadViento) = mvelocidades.TraerTodos(dwItems.TablaDatos)
            cargarVersiones()
            CargarPaises()
            cargarEstados()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If dwItems.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToInt32(r.Cells(Id_Version_CV.Index).Value) = Convert.ToInt32(cmbversion.SelectedValue) And Convert.ToInt32(r.Cells(Id_Ciudad.Index).Value) = Convert.ToInt32(cmbCiudad.SelectedValue)).Count() > 0 Then
                    eperrores.SetError(nudvalor, "Ya se ha asignado una velocidad la ciudad " & DirectCast(cmbCiudad.SelectedValue, Ciudades.Ciudad).nombreCiudad & ", con la versión " & DirectCast(cmbversion.SelectedValue, VersionCargasViento).Version)
                    Return False
                End If
                eperrores.Clear()
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
                    mvelocidades.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(cmbCiudad.SelectedValue), Convert.ToInt32(cmbversion.SelectedValue),
                                      nudvalor.Value, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mvelocidades.Modificar(curid, My.Settings.UsuarioActivo, Convert.ToInt32(cmbCiudad.SelectedValue), Convert.ToInt32(cmbversion.SelectedValue),
                                      nudvalor.Value, cmbEstado.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                Frm_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            cmbversion.SelectedValue = 0
            cmbPais.SelectedValue = 0
            cmbEstado.SelectedValue = 1
            nudvalor.Value = 0
            eperrores.Clear()
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

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        Try
            cargarDepartamento(Convert.ToInt32(DirectCast(sender, ComboBox).SelectedValue))
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        Try
            cargarCiudades(Convert.ToInt32(DirectCast(sender, ComboBox).SelectedValue))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class