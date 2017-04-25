Imports ReglasNegocio
Imports Validaciones

Public Class FrmPropiedadesMasicas
#Region "Variables"
    Private mpropiedades As ClsPropiedadesMasicas
    Private mcombinacion As ClsCombinacionPropiedadesDiseños
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private fuenteInicial As DataTable = Nothing
#End Region

#Region "Procedimientos"
    Private Sub cargarCombinaciones()
        Try
            Dim listacomb As List(Of CombinacinPropiedadDiseño) = mcombinacion.TraerTodos()
            For Each c As CombinacinPropiedadDiseño In listacomb
                Dim r As DataGridViewRow = dwmodelos.Rows(dwmodelos.Rows.Add())
                r.Cells(idcombinacion.Index).Value = c.Id
                r.Cells(idpropiedad.Index).Value = c.IdPropiedadesMasica
                r.Cells(propiedad.Index).Value = c.NombrePropiedad
                r.Cells(idmodelo.Index).Value = c.IdModelo
                r.Cells(modelo.Index).Value = c.NombreModelo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
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
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            LimpiarCombinaciones()
            curid = Convert.ToInt32(r.Cells(Id.DataPropertyName).Value)
            txtnombre.Text = r.Cells(Nombre.DataPropertyName).Value
            txtdescripcion.Text = r.Cells(Descripcion.DataPropertyName).Value
            nudinercia.Value = r.Cells(Inercia.DataPropertyName).Value
            nudmoduloseccion.Value = r.Cells(Modulo_Seccion.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(Id_Estado.DataPropertyName).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
            Dim FilasUsadas = dwmodelos.Rows.Cast(Of DataGridViewRow).Where(Function(x) Convert.ToInt32(x.Cells(idpropiedad.Index).Value) = curid).ToList()
            For Each rx As DataGridViewRow In FilasUsadas
                rx.Cells(utilizar.Index).Value = True
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.TextBoxDigitado(txtnombre, eppropiedades) Then Return False
            If Not objValidacion.TextBoxDigitado(txtdescripcion, eppropiedades) Then Return False
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function

    Private Sub LimpiarCombinaciones()
        Try
            For i = 0 To dwmodelos.RowCount - 1
                dwmodelos.Item(utilizar.Index, i).Value = False
            Next
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
            mpropiedades = New ClsPropiedadesMasicas
            mcombinacion = New ClsCombinacionPropiedadesDiseños
            Dim objLista As List(Of PropiedadMasica) = mpropiedades.TraerTodos(dwItems.TablaDatos)
            cargarCombinaciones()
            cargarEstados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validacion() Then
                Dim mensaje As String = String.Empty

                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    curid = mpropiedades.Insertar(My.Settings.UsuarioActivo, txtnombre.Text,
                                          txtdescripcion.Text, nudinercia.Value, nudmoduloseccion.Value, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mpropiedades.Modificar(curid, My.Settings.UsuarioActivo, txtnombre.Text,
                                          txtdescripcion.Text, nudinercia.Value, nudmoduloseccion.Value, cmbEstado.SelectedValue)
                End If
                dwmodelos.EndEdit()
                For Each r As DataGridViewRow In dwmodelos.Rows
                    If Convert.ToBoolean(r.Cells(utilizar.Index).Value) Then
                        If Convert.ToInt32(r.Cells(idcombinacion.Index).Value) > 0 Then
                            mcombinacion.Modificar(Convert.ToInt32(r.Cells(idcombinacion.Index).Value),
                                                   My.Settings.UsuarioActivo, curid, Convert.ToInt32(r.Cells(idmodelo.Index).Value))
                        Else
                            r.Cells(idcombinacion.Index).Value = mcombinacion.Insertar(My.Settings.UsuarioActivo, curid,
                                                                                       Convert.ToInt32(r.Cells(idmodelo.Index).Value))
                        End If
                        r.Cells(idpropiedad.Index).Value = curid
                    End If

                Next

                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                Frm_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            txtnombre.Text = String.Empty
            txtdescripcion.Text = String.Empty
            nudinercia.Value = 0
            nudmoduloseccion.Value = 0
            cmbEstado.SelectedValue = 1
            eppropiedades.Clear()
            LimpiarCombinaciones()
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

    Private Sub dwmodelos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwmodelos.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                If dwmodelos.Columns(e.ColumnIndex) Is utilizar Then
                    If Not Convert.ToBoolean(dwmodelos.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        If Convert.ToInt32(dwmodelos.Item(idcombinacion.Index, e.RowIndex).Value) > 0 Then
                            If MsgBox("¿esta seguro que quiere des-asignar el modelo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                mcombinacion.BorrarporId(Convert.ToInt32(dwmodelos.Item(idcombinacion.Index, e.RowIndex).Value))
                                dwmodelos.Item(idcombinacion.Index, e.RowIndex).Value = 0
                            Else
                                dwmodelos.Item(e.ColumnIndex, e.RowIndex).Value = True
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class