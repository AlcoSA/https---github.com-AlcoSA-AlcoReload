Imports ControlesPersonalizados.Filtro_DragDrop
Imports ReglasNegocio
Imports Validaciones
Public Class FrmUsuarios

#Region "Variables"
    Private musuarios As ClsUsuarios
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
            cbestado.DisplayMember = "Descripcion"
            cbestado.ValueMember = "Id"
            cbestado.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarDepartamentos()
        Try
            Dim mdepartamento As New ClsDepartamentosAlco
            Dim listdep As List(Of DepartamentoAlco) = mdepartamento.TraerporEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listdep
            cbdepartamento.DisplayMember = "Departamento"
            cbdepartamento.ValueMember = "Id"
            cbdepartamento.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarGrupos()
        Try
            Dim mgrupo As New ClsGruposSeguridad
            Dim listgrupo As List(Of GrupoSeguridad) = mgrupo.TraerporEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listgrupo
            cbgrupo.DisplayMember = "Grupo"
            cbgrupo.ValueMember = "Id"
            cbgrupo.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarUsuarioNt()
        Try
            Dim userv As New ClsUtilidadesServidor
            cbusuario.Items.AddRange(userv.llenarListaUsuariosNt())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub cargarUnoee()
        Try
            cbunoee.ValueMember = "f552_rowid"
            cbunoee.DisplayMember = "f552_nombre"
            cbunoee.DataSource = musuarios.TraerUsuariosUnoee()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
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
            cbusuario.SelectedItem = Convert.ToString(r.Cells(usuario.DataPropertyName).Value).Trim()
            cbunoee.SelectedValue = Convert.ToInt32(r.Cells(idunoee.DataPropertyName).Value)
            cbdepartamento.SelectedValue = Convert.ToInt32(r.Cells(iddepartamento.DataPropertyName).Value)
            cbgrupo.SelectedValue = Convert.ToInt32(r.Cells(Id_grupo.DataPropertyName).Value)
            cbestado.SelectedValue = Convert.ToInt32(r.Cells(Id_Estado.DataPropertyName).Value)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarInicial()
        Try
            musuarios.TraerTodos(dwItems.TablaDatos)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
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
            musuarios = New ClsUsuarios
            dwItems.AutoGenerateColumns = False
            cargarInicial()
            cargarEstados()
            cargarUsuarioNt()
            cargarDepartamentos()
            cargarUnoee()
            cargarGrupos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.ComboBoxSeleccionado(cbusuario, ErrorProvider1) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cbunoee, ErrorProvider1) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cbdepartamento, ErrorProvider1) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cbestado, ErrorProvider1) Then Return False
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validacion() Then
                Dim mutiimagen As New ClsUtilidadesImagenes
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    musuarios.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(cbdepartamento.SelectedValue),
                                       Convert.ToInt32(cbgrupo.SelectedValue),
                                       Convert.ToInt32(cbunoee.SelectedValue), Convert.ToString(cbusuario.SelectedItem),
                                       Convert.ToInt32(cbestado.SelectedValue))
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    musuarios.Modificar(My.Settings.UsuarioActivo, Convert.ToInt32(cbdepartamento.SelectedValue),
                                        Convert.ToInt32(cbgrupo.SelectedValue),
                                       Convert.ToInt32(cbunoee.SelectedValue), Convert.ToString(cbusuario.SelectedItem),
                                       Convert.ToInt32(cbestado.SelectedValue), curid)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                cargarInicial()
            Else
                MessageBox.Show("Hay campos obligatorios que están vacíos. Verifique la información")
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            cbestado.SelectedIndex = 0
            cbusuario.SelectedIndex = 0
            cbunoee.SelectedIndex = 0
            cbdepartamento.SelectedIndex = 0
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
End Class