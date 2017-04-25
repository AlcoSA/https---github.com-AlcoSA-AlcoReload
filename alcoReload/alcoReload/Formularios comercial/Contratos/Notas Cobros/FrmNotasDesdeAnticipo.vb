Imports DatagridTreeView
Imports ReglasNegocio

Public Class FrmNotasDesdeAnticipo
#Region "Variables"
    Private mPlanAnticipo As ClsPlanAnticipos
    Private mMovitoAnticipo As clsMovitoPlanAnticipos
    Private dtpFechaInicio As New DateTimePicker
    Private dtpFechaFin As New DateTimePicker

    Private selectedList As List(Of cuota)
    Private gridFiltrado As Boolean = False
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            mPlanAnticipo = New ClsPlanAnticipos
            Dim listPlanesAnt As List(Of anticipoNotaCobro) = mPlanAnticipo.TraerPlanesAnticipo().Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
            For Each plan As anticipoNotaCobro In listPlanesAnt
                Dim ndp As DataGridViewTreeNode = dwItems.Nodes.Add()
                ndp.Cells(idPlan.Index).Value = plan.IdPlanAnticipo
                ndp.Cells(fechaCreacion.Index).Value = plan.FechaCreacion
                ndp.Cells(usuarioCreacion.Index).Value = plan.UsuarioCreacion
                ndp.Cells(idContrato.Index).Value = plan.IdContrato
                ndp.Cells(nit.Index).Value = plan.Nit
                ndp.Cells(constructora.Index).Value = plan.Constructora
                ndp.Cells(codSucursal.Index).Value = plan.CodigoSucursal
                ndp.Cells(obra.Index).Value = plan.Obra
                ndp.Cells(numContrato.Index).Value = plan.NumeroContrato
                ndp.Cells(idTipoAnticipo.Index).Value = plan.IdtipoAnticipo
                ndp.Cells(tipoAnticipo.Index).Value = plan.TipoAnticipo
                ndp.Cells(porcentAnticipo.Index).Value = plan.PorcentajeAnticipo
                ndp.Cells(cuotas.Index).Value = plan.NumeroCuota
                ndp.Cells(rangoDias.Index).Value = plan.RangoDias
                ndp.Cells(valorContratado.Index).Value = plan.ValorContratado

                mMovitoAnticipo = New clsMovitoPlanAnticipos
                Dim mAnticipoxNota As New clsAnticiposPorNota

                Dim listMovitoAnt As List(Of cuota) = mMovitoAnticipo.traerxIdAnticipo(plan.IdPlanAnticipo).Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
                For Each cuotaAnt As cuota In listMovitoAnt
                    Dim hijo As DataGridViewTreeNode = ndp.Nodes.Add
                    hijo.Cells(porcentAnticipo.Index).Value = cuotaAnt.porcentajeCuota
                    hijo.Cells(cuotas.Index).Value = cuotaAnt.NumeroCuota
                    hijo.Cells(rangoDias.Index).Value = Convert.ToDateTime(cuotaAnt.fechaCuota).ToShortDateString
                    hijo.Cells(valorContratado.Index).Value = cuotaAnt.valorCuota
                Next
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub generarNota()
        Try
            If gridFiltrado Then
                For Each plan As DataGridViewTreeNode In dwItems.Nodes
                    Dim conteoHijosChequeados As Integer = 0
                    For Each cuotaPlan As DataGridViewTreeNode In plan.Nodes
                        If cuotaPlan.Visible = True And Convert.ToBoolean(cuotaPlan.Cells(seleccion.Index).EditedFormattedValue) = True Then
                            conteoHijosChequeados += 1
                        End If
                    Next
                    If conteoHijosChequeados > 0 Then
                        cargarNota(plan)
                    End If
                Next
            Else
                Dim row As DataGridViewTreeNode = dwItems.SelectedRows(0)
                Dim padre As DataGridViewTreeNode = row.Parent
                cargarNota(padre)
            End If
            dwItems.Rows.Clear()
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarNota(padre As DataGridViewTreeNode)
        Try
            Dim frm As New FrmNotas
            frm.origenNota = ClsEnums.OrigenNota.PORANTICIPO
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.Text += " desde anticipo"
            frm.Operacion = ClsEnums.TiOperacion.INSERTAR

            frm.ListCuotasSeleccionadas = generarListaCuotasSeleccionadas(padre)
            frm.Nit = padre.Cells(nit.Index).Value
            frm.Cliente = padre.Cells(constructora.Index).Value
            frm.CodigoObra = padre.Cells(codSucursal.Index).Value
            frm.Obra = padre.Cells(obra.Index).Value
            frm.IdTipoNota = ClsEnums.Tipos_nota.ANTICIPO
            frm.Contrato = padre.Cells(numContrato.Index).Value
            frm.ValorContrato = padre.Cells(valorContratado.Index).Value
            frm.TotalCuotas = padre.Cells(cuotas.Index).Value

            Dim mRelacionObjetos As New clsRelacionObjetoContratos
            Dim listRelacionObjetos As List(Of relacionObjetosContratos) = mRelacionObjetos.traerxIdContrato(padre.Cells(idContrato.Index).Value)
            frm.ListObjetosContrato = listRelacionObjetos

            Dim mRelacionPara As New clsRelacionParaContrato
            Dim listRelacionPara As List(Of relacionParaContrato) = mRelacionPara.traerxIdContrato(padre.Cells(idContrato.Index).Value)
            frm.ListParaContrato = listRelacionPara

            If frm.ShowDialog() = DialogResult.OK Then
                'dwItems.Rows.Clear()
                Dim conteo As Integer = mMovitoAnticipo.TraerNumeroPendientes(padre.Cells(idPlan.Index).Value)
                If conteo = 0 Then
                    Dim mPlanAnticipo As New ClsPlanAnticipos
                    mPlanAnticipo.ActualizarEstado(padre.Cells(idPlan.Index).Value, ClsEnums.Estados.GENERADO)
                End If
                'If gridFiltrado = False Then
                '    cargarInformacion()
                'Else

                'End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function generarListaCuotasSeleccionadas(plan As DataGridViewTreeNode) As List(Of cuota)
        generarListaCuotasSeleccionadas = New List(Of cuota)
        Try
            mMovitoAnticipo = New clsMovitoPlanAnticipos
            Dim listMovitoAnticipo As List(Of cuota) = mMovitoAnticipo.traerxIdAnticipo(plan.Cells(idPlan.Index).Value)
            Dim seleccionados As New List(Of cuota)
            If gridFiltrado Then
                For Each cuotaPlan As DataGridViewTreeNode In plan.Nodes
                    If Convert.ToBoolean(cuotaPlan.Cells(seleccion.Index).EditedFormattedValue) = True Then
                        seleccionados.Add(listMovitoAnticipo.FirstOrDefault(Function(a) a.NumeroCuota = Convert.ToInt32(cuotaPlan.Cells(cuotas.Index).Value)))
                    End If
                Next
            Else
                For Each cuotaPlan As DataGridViewTreeNode In plan.Nodes
                    If cuotaPlan.Selected = True Then
                        seleccionados.Add(listMovitoAnticipo.FirstOrDefault(Function(a) a.NumeroCuota = Convert.ToInt32(cuotaPlan.Cells(cuotas.Index).Value)))
                    End If
                Next
            End If
            Return seleccionados
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function

    Private Sub cambiarValorNota()
        Try
            MessageBox.Show("Cambiar valor nota")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub CargarControlesAdicionalesToolStrip()
        Try
            Dim hostFechaInicio As New ToolStripControlHost(dtpFechaInicio)
            dtpFechaInicio.Format = DateTimePickerFormat.Short
            tsherramientas.Items.Insert(4, hostFechaInicio)

            Dim hostFechaFin As New ToolStripControlHost(dtpFechaFin)
            dtpFechaFin.Format = DateTimePickerFormat.Short
            tsherramientas.Items.Insert(8, hostFechaFin)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub OcultarNodosPorFiltro()
        Try
            For Each plan As DataGridViewTreeNode In dwItems.Nodes
                plan.Expand()
                Dim conteoCuotasVisibles As Integer = plan.Nodes.Count
                For Each cuotaPlan As DataGridViewTreeNode In plan.Nodes
                    Dim fecha As DateTime = Convert.ToDateTime(cuotaPlan.Cells(rangoDias.Index).Value).ToShortDateString
                    If fecha < dtpFechaInicio.Value.ToShortDateString Or fecha > dtpFechaFin.Value.ToShortDateString Then
                        cuotaPlan.Visible = False
                        cuotaPlan.Cells(seleccion.Index).Value = False
                        conteoCuotasVisibles -= 1
                    End If
                Next
                If conteoCuotasVisibles = 0 Then
                    plan.Visible = False
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmNotasDesdeAnticipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarControlesAdicionalesToolStrip()
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseDown
        Try
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim col As DataGridViewColumn = dwItems.Columns(e.ColumnIndex)
                If col.Index <> seleccion.Index Then
                    If DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode).Level = 2 Then
                        dwItems.Rows(e.RowIndex).Selected = True
                        Dim menu As New ContextMenuStrip
                        If gridFiltrado = False Then
                            menu.Items.Add("Generar nota", Nothing, AddressOf generarNota)
                            menu.Items.Add("Cambiar valor nota", Nothing, AddressOf cambiarValorNota)
                        Else
                            Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                            If Convert.ToBoolean(r.Cells(seleccion.Index).EditedFormattedValue) = True Then
                                menu.Items.Add("Generar notas seleccionadas", Nothing, AddressOf generarNota)
                            End If
                        End If
                        menu.Show(Control.MousePosition)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseUp
        Try
            If dwItems.Columns(seleccion.Index).Visible = True Then
                Dim col As DataGridViewColumn = dwItems.Columns(e.ColumnIndex)
                If col.Index = seleccion.Index Then
                    If DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode).Level = 1 Then
                        Dim plan As DataGridViewTreeNode = dwItems.Rows(e.RowIndex)
                        If Convert.ToBoolean(plan.Cells(seleccion.Index).EditedFormattedValue) = True Then
                            For Each cuotaPlan As DataGridViewTreeNode In plan.Nodes
                                If cuotaPlan.Visible = True Then
                                    cuotaPlan.Cells(seleccion.Index).Value = True
                                End If
                            Next
                        Else
                            For Each cuotaPlan As DataGridViewTreeNode In plan.Nodes
                                cuotaPlan.Cells(seleccion.Index).Value = False
                            Next
                        End If
                    Else
                        Dim cuotaPlan As DataGridViewTreeNode = dwItems.Rows(e.RowIndex)
                        Dim plan As DataGridViewTreeNode = cuotaPlan.Parent
                        For Each cuotaPlan2 As DataGridViewTreeNode In plan.Nodes
                            If Convert.ToBoolean(cuotaPlan2.Cells(seleccion.Index).EditedFormattedValue) = False Then
                                plan.Cells(seleccion.Index).Value = False
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            For Each plan As DataGridViewTreeNode In dwItems.Nodes
                plan.Visible = True
                For Each cuotaPlan As DataGridViewTreeNode In plan.Nodes
                    cuotaPlan.Visible = True
                Next
            Next

            OcultarNodosPorFiltro()
            dwItems.Columns(seleccion.Index).Visible = True
            dwItems.MultiSelect = False
            gridFiltrado = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnReiniciarFiltros_Click(sender As Object, e As EventArgs) Handles btnReiniciarFiltros.Click
        Try
            If dwItems.Columns(seleccion.Index).Visible = True Then
                dtpFechaInicio.Value = DateTime.Now
                dtpFechaFin.Value = DateTime.Now
                dwItems.Columns(seleccion.Index).Visible = False
                dwItems.MultiSelect = True
                dwItems.Nodes.Clear()
                cargarInformacion()
                gridFiltrado = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmNotasDesdeAnticipo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            dwItems.Rows.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class