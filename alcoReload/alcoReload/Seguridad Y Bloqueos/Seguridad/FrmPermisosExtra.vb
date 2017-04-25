Imports ControlesPersonalizados.Filtro_DragDrop
Imports ReglasNegocio
Imports Validaciones
Public Class FrmPermisosExtra

#Region "Variables"
    Private mamodulos As ClsModulosPermisoExtra
    Private mpermisos As ClsPermisosExtra
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
            curid = Convert.ToInt32(r.Cells(Id.Index).Value)
            txtmodulo.Text = r.Cells(modulo.Index).Value.ToString()
            nudcodigo.Text = r.Cells(codigo.Index).Value.ToString()
            txtDescripcion.Text = r.Cells(Descripcion.Index).Value.ToString()
            cmbEstado.SelectedValue = r.Cells(Id_Estado.Index).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
            Dim lperm As List(Of PermisoExtra) = mpermisos.TraerxIdModulo(curid)
            For Each p As PermisoExtra In lperm
                Dim rp As DataGridViewRow = dwpermisos.Rows(dwpermisos.Rows.Add())
                rp.Cells(idpermiso.Index).Value = p.Id
                rp.Cells(permiso.Index).Value = p.Permiso
                rp.Cells(descripcionpermiso.Index).Value = p.Descripcion
                rp.Cells(codigopermiso.Index).Value = p.Codigo
            Next
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
            mamodulos = New ClsModulosPermisoExtra
            mpermisos = New ClsPermisosExtra
            cargarEstados()
            dwItems.TablaDatos = mamodulos.TraerTodosTabla()
            dwItems.AutoGenerateColumns = False
            nudcodigo.Value = nudcodigo.Minimum + dwItems.Rows.Count
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.TextBoxDigitado(txtmodulo, ErrorProvider1) Then Return False
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then Return False
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
                    curid = mamodulos.Insertar(My.Settings.UsuarioActivo, txtmodulo.Text, txtDescripcion.Text,
                                       nudcodigo.Value.ToString(), Convert.ToInt32(cmbEstado.SelectedValue))
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mamodulos.Modificar(My.Settings.UsuarioActivo, txtmodulo.Text, txtDescripcion.Text,
                                        nudcodigo.Value.ToString(), Convert.ToInt32(cmbEstado.SelectedValue), curid)
                End If
                For Each r As DataGridViewRow In dwpermisos.Rows
                    If String.IsNullOrEmpty(Convert.ToString(r.Cells(idpermiso.Index).Value)) Then
                        r.Cells(idpermiso.Index).Value = mpermisos.Insertar(curid, r.Cells(permiso.Index).Value, r.Cells(descripcionpermiso.Index).Value,
                                           r.Cells(codigopermiso.Index).Value, ClsEnums.Estados.ACTIVO, My.Settings.UsuarioActivo)
                    Else
                        mpermisos.Modificar(My.Settings.UsuarioActivo, curid, r.Cells(permiso.Index).Value,
                                            r.Cells(descripcionpermiso.Index).Value, r.Cells(codigopermiso.Index).Value,
                                            ClsEnums.Estados.ACTIVO, Convert.ToInt32(r.Cells(idpermiso.Index).Value))
                    End If
                Next
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                Frm_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
            If ex.Message.Contains("UNIQUE KEY 'IX_ti025_espesores_prefijo'") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(txtmodulo, "Ya existe un espesor con este prefijo. Verifique la información")
                Return
            End If
            If ex.Message.Contains("UNIQUE KEY 'IX_ti025_espesores_descripcion'") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(txtDescripcion, "Ya existe un espesor con esta descripción. Verifique la información")
                Return
            End If
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            txtmodulo.Text = String.Empty
            txtDescripcion.Text = String.Empty
            cmbEstado.SelectedValue = 1
            ErrorProvider1.Clear()
            dwpermisos.Rows.Clear()
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
    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Try
            Dim i As Integer = dwpermisos.Rows.Add()
            dwpermisos.Item(codigopermiso.Index, i).Value = nudcodigo.Value.ToString() & "." & i + 1
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class