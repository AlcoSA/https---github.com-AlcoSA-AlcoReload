Imports ReglasNegocio
Imports Validaciones

Public Class FrmValoresParametrosTecnicosArticulo
#Region "Variables"
    Private mvaltec As ClsValoresParametrosTecnicosArticulo
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private fuenteInicial As DataTable = Nothing
#End Region

#Region "Procedimientos"
    Private Sub Modificar()
        Try
            If Not My.Settings.Es_Desarrollador Then
                MsgBox("No tiene permisos para realizar esta acción", MsgBoxStyle.Information)
                Return
            End If
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(Id.Index).Value)
            cmbarticulo.SelectedValue = r.Cells(Id_Articulo.Index).Value
            cmbparametro.SelectedValue = r.Cells(Id_Parametro.Index).Value
            nudvalor.Value = Convert.ToDecimal(r.Cells(Valor.Index).Value)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarParametros()
        Try
            Dim mparam As New ClsParametrosTecnicosArticulo
            Dim listparam As List(Of ParametrosTecnicosArticulo) = mparam.TraerxIdEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listparam
            listparam.Insert(0, New ParametrosTecnicosArticulo)
            cmbparametro.DisplayMember = "Nombre"
            cmbparametro.ValueMember = "Id"
            cmbparametro.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarArticulos()
        Try
            Dim marticulos As New ClsArticulos
            Dim listarticulos As List(Of Articulo) = marticulos.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.PERFILERIA, ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listarticulos
            listarticulos.Insert(0, New Articulo)
            cmbarticulo.DisplayMember = "Referencia"
            cmbarticulo.ValueMember = "Id"
            cmbarticulo.DataSource = bsource
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
            mvaltec = New ClsValoresParametrosTecnicosArticulo
            Dim objLista As List(Of ValorParametroTecnicoArticulo) = mvaltec.TraerTodos(dwItems.TablaDatos)
            cargarArticulos()
            cargarParametros()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.ComboBoxSeleccionado(cmbarticulo, eperrores) Or Not objValidacion.ComboBoxSeleccionado(cmbparametro, eperrores) Then
                Return False
            End If
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If dwItems.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToInt32(r.Cells(Id_Articulo.Index).Value) = Convert.ToInt32(cmbarticulo.SelectedValue) And Convert.ToInt32(r.Cells(Id_Articulo.Index).Value) = Convert.ToInt32(cmbparametro.SelectedValue)).Count() > 0 Then
                    eperrores.SetError(nudvalor, "Ya existe un valor asignado al parámetro: " & cmbparametro.Text & " en el articulo: " & cmbarticulo.Text)
                    Return False
                End If
            End If
            eperrores.Clear()
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
                    mvaltec.Ingresar(My.Settings.UsuarioActivo, Convert.ToInt32(cmbparametro.SelectedValue), Convert.ToInt32(cmbarticulo.SelectedValue),
                                      nudvalor.Value)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mvaltec.Modifcar(curid, My.Settings.UsuarioActivo, Convert.ToInt32(cmbparametro.SelectedValue), Convert.ToInt32(cmbarticulo.SelectedValue),
                                      nudvalor.Value)
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
            cmbparametro.SelectedValue = 0
            cmbarticulo.SelectedValue = 0
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
End Class