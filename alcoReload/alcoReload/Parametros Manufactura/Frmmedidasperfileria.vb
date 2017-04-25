Imports ReglasNegocio
Imports Validaciones

Public Class Frmmedidasperfileria
#Region "vars"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private meds_perf As ClsMedidasPerfileria
#End Region
#Region "procs"
    Private Sub cargarestados()
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
    Private Sub cargarperfiles()
        Try
            Dim art As New ClsArticulos
            art.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.PERFILERIA, txtperfil.TablaFuente)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(id.Index).Value)
            nuddescuento.Value = Convert.ToDecimal(r.Cells(descuento.Index).Value)
            nudmedida.Value = Convert.ToDecimal(r.Cells(medida.Index).Value)
            cmbEstado.SelectedValue = Convert.ToInt32(r.Cells(id_estado.Index).Value)
            txtperfil.Seleted_rowid = Convert.ToInt32(r.Cells(idperfil.Index).Value)
            txtperfil.SelectedText = Convert.ToString(r.Cells(referencia.Index).Value)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validar() As Boolean
        Try
            ErrorProvider1.Clear()
            If String.IsNullOrEmpty(txtperfil.Text) Or String.IsNullOrEmpty(txtperfil.Seleted_rowid) Then
                ErrorProvider1.SetError(txtperfil, "Debe seleccionar un valor")
                Return False
            End If
            Dim objValidacion = New ClsValidaciones
            If Not objValidacion.NumeroMayorACero(nuddescuento, ErrorProvider1) Then Return False
            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

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
    Private Sub Frmmedidasperfileria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            meds_perf = New ClsMedidasPerfileria
            cargarestados()
            cargarperfiles()
            dwItems.TablaDatos = meds_perf.TraerTodosTabla()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            If validar() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    meds_perf.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(txtperfil.Seleted_rowid),
                                       nudmedida.Value, nuddescuento.Value, Convert.ToInt32(cmbEstado.SelectedValue))
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    meds_perf.Modificar(My.Settings.UsuarioActivo, Convert.ToInt32(txtperfil.Seleted_rowid),
                                       nudmedida.Value, nuddescuento.Value, Convert.ToInt32(cmbEstado.SelectedValue),
                                        curid)
                End If
                btnLimpiar_Click(Nothing, Nothing)
                dwItems.TablaDatos = meds_perf.TraerTodosTabla()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            nuddescuento.Value = 0
            nudmedida.Value = 0
            cmbEstado.SelectedValue = 1
            txtperfil.Seleted_rowid = 0
            txtperfil.SelectedText = String.Empty
            txtperfil.selected_item = Nothing
            txtperfil.Text = String.Empty
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Frmmedidasperfileria_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Enabled = False
            btnsTotal.Enabled = True
            btnguardar.Enabled = True
            btnsLimpiar.Enabled = True
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Frmmedidasperfileria_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Enabled = False
            btnsTotal.Enabled = False
            btnguardar.Enabled = False
            btnsLimpiar.Enabled = False
            RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class
