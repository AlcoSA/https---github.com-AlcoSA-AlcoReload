Imports ReglasNegocio

Public Class FrmPlaneacion
#Region "Variables"
    Private mPlaneacion As clsPlaneacion
    Private mostrandoSpliters As Boolean = False

    Private contratoSelected As Boolean = False
    Private loadCompleted As Boolean = False
    Private fuenteContratos As DataGridView
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub cargarVendedores()
        Try
            Dim mVendedor As New ClsVendedoresSiesa
            Dim listVendedores As List(Of vendedor) = mVendedor.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbVendedor.ValueMember = "idSiesa"
            cmbVendedor.DatosVisibles = {"idSiesa", "Nombre"}
            cmbVendedor.DataSource = listVendedores
            cmbVendedor.SelectedValue = ""
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarContratos(idVendedor As String)
        Try
            dwContratos.Rows.Clear()
            Dim mContratoPlaneacion As New clsContratosPlaneacion
            Dim listContratos As New List(Of contratoPlaneacion)
            listContratos = mContratoPlaneacion.TraerContratos(idVendedor)

            listContratos.ForEach(Sub(contrato)
                                      Dim r As DataGridViewRow = dwContratos.Rows(dwContratos.Rows.Add())
                                      r.Cells(cont_idContrato.Index).Value = contrato.IdContrato
                                      r.Cells(cont_idPendiente.Index).Value = contrato.IdPendiente
                                      r.Cells(cont_idEstado.Index).Value = contrato.IdEstadoPlaneacion
                                      Select Case contrato.IdEstadoPlaneacion
                                          Case ClsEnums.Estados.SIN_CONT_PLANEADA
                                              DirectCast(r.Cells(cont_estado.Index), DataGridViewImageCell).Value = ImageListEstados.Images(0)
                                          Case ClsEnums.Estados.SIN_CONTRATO
                                              DirectCast(r.Cells(cont_estado.Index), DataGridViewImageCell).Value = ImageListEstados.Images(1)
                                          Case ClsEnums.Estados.SIN_PLANEAR
                                              DirectCast(r.Cells(cont_estado.Index), DataGridViewImageCell).Value = ImageListEstados.Images(2)
                                          Case ClsEnums.Estados.CON_PLANEACION
                                              DirectCast(r.Cells(cont_estado.Index), DataGridViewImageCell).Value = ImageListEstados.Images(3)
                                          Case ClsEnums.Estados.TERMINADO
                                              DirectCast(r.Cells(cont_estado.Index), DataGridViewImageCell).Value = ImageListEstados.Images(4)
                                      End Select
                                      r.Cells(cont_cliente.Index).Value = contrato.Cliente
                                      r.Cells(cont_codSucursal.Index).Value = contrato.CodSucursal
                                      r.Cells(cont_sucursal.Index).Value = contrato.Sucursal
                                      r.Cells(cont_contrato.Index).Value = contrato.NumContrato
                                      r.Cells(cont_fechaInicio.Index).Value = contrato.FechaInicial.ToShortDateString
                                      If contrato.FechaFin.Year <> 1 Then
                                          r.Cells(cont_fechaFin.Index).Value = contrato.FechaFin.ToShortDateString
                                      Else
                                          r.Cells(cont_fechaFin.Index).Value = String.Empty
                                      End If
                                      r.Cells(cont_puntosTotales.Index).Value = contrato.PuntosTotales
                                      r.Cells(cont_puntosProgramados.Index).Value = contrato.PuntosProgramados
                                      r.Cells(cont_unidadesTotales.Index).Value = contrato.UnidadesTotales
                                      r.Cells(cont_region.Index).Value = contrato.Region
                                      r.Cells(cont_valorContrato.Index).Value = contrato.ValorContrato
                                      r.Cells(cont_metros.Index).Value = contrato.Metros
                                  End Sub)
            dwContratos.ClearSelection()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarItems(id As Integer, desdeContratos As Boolean)
        Try
            dwItems.Rows.Clear()
            Dim mCotizaPlaneacion As New clsCotizacionPlaneacion
            Dim listCotizas As New List(Of cotizaPlaneacion)
            listCotizas = Nothing
            If desdeContratos = True Then
                listCotizas = mCotizaPlaneacion.TraerItemsContratados(id)
            Else
                listCotizas = mCotizaPlaneacion.TraerItemsPendientes(id)
            End If
            listCotizas.ForEach(Sub(item)
                                    Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                                    r.Cells(item_id.Index).Value = item.Id
                                    r.Cells(item_ubicacion.Index).Value = item.Ubicacion
                                    r.Cells(item_descripcion.Index).Value = item.Descripcion
                                    r.Cells(item_idCotiza.Index).Value = item.IdCotiza
                                    r.Cells(item_cotiza.Index).Value = item.Cotiza
                                    r.Cells(item_idVendedor.Index).Value = item.IdVendedor
                                    r.Cells(item_vendedor.Index).Value = item.Vendedor
                                    r.Cells(item_idAcabado.Index).Value = item.IdAcabado
                                    r.Cells(item_acabado.Index).Value = item.Acabado
                                    r.Cells(item_metros.Index).Value = item.Metros
                                    r.Cells(item_puntosTotales.Index).Value = item.Puntos
                                    r.Cells(item_puntosSinPlanear.Index).Value = item.Puntos - item.PuntosPlaneados
                                    r.Cells(item_unidades.Index).Value = item.Unidades
                                    r.Cells(item_precioInstalacion.Index).Value = item.PrecioInstalacion
                                    r.Cells(item_idEstado.Index).Value = item.IdEstado
                                    r.Cells(item_estado.Index).Value = item.Estado
                                    If CInt(r.Cells(item_puntosSinPlanear.Index).Value) = 0 Then
                                        r.Visible = False
                                    End If
                                End Sub)
            dwItems.ClearSelection()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarPlaneaciones(idContrato As Integer, idPendiente As Integer)
        Try
            dwPlaneacion.Rows.Clear()
            mPlaneacion = New clsPlaneacion
            Dim lista As New List(Of planeacion)
            If idContrato <> 0 Then
                lista = mPlaneacion.TraerxIdContrato(idContrato)
            Else
                lista = mPlaneacion.TraerxIdPendiente(idPendiente)
            End If
            lista.ForEach(Sub(plan)
                              Dim r As DataGridViewRow = dwPlaneacion.Rows(dwPlaneacion.Rows.Add())
                              r.Cells(plan_id.Index).Value = plan.Id
                              r.Cells(plan_idContrato.Index).Value = plan.IdContrato
                              r.Cells(plan_idPendiente.Index).Value = plan.IdPendiente
                              r.Cells(plan_padre.Index).Value = plan.Ubicacion + " // " + plan.Descripcion
                              r.Cells(plan_vendedor.Index).Value = plan.IdVendedor
                              r.Cells(plan_cantidadPuntos.Index).Value = plan.Puntos
                              r.Cells(plan_semana.Index).Value = plan.Semana
                              r.Cells(plan_numSemana.Index).Value = plan.NumSemana
                              r.Cells(plan_mes.Index).Value = plan.Mes
                              r.Cells(plan_anio.Index).Value = plan.Anio
                              r.Cells(plan_usuarioRegistro.Index).Value = plan.UsuarioCreacion
                              r.Cells(plan_fechaCreacion.Index).Value = plan.FechaCreacion
                              r.Cells(plan_fechaModi.Index).Value = plan.FechaModificacion
                              r.Cells(plan_idConcepto.Index).Value = plan.IdConcepto
                              r.Cells(plan_concepto.Index).Value = plan.Concepto
                          End Sub)

            dwPlaneacion.ClearSelection()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub terminarPlaneacion()
        Try
            Dim r As DataGridViewRow = dwContratos.SelectedRows(0)
            If MessageBox.Show("¿Está seguro de terminar la planeación seleccionada?", "",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim mEstadoPlaneacion As New clsEstadosPlaneacion
                If Convert.ToInt32(r.Cells(cont_idContrato.Index).Value) <> 0 Then
                    mEstadoPlaneacion.actualizarxIdContrato(r.Cells(cont_idContrato.Index).Value, r.Cells(cont_idPendiente.Index).Value,
                                                            ClsEnums.Estados.TERMINADO)
                Else
                    mEstadoPlaneacion.actualizarxIdPendiente(r.Cells(cont_idPendiente.Index).Value, r.Cells(cont_idContrato.Index).Value,
                                                             ClsEnums.Estados.TERMINADO)
                End If
                cargarContratos(cmbVendedor.SelectedValue)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub restaurarPlaneacion()
        Try
            Dim r As DataGridViewRow = dwContratos.SelectedRows(0)
            Dim mPlaneacion As New clsPlaneacion
            Dim mEstadoPlaneacion As New clsEstadosPlaneacion
            If Convert.ToInt32(r.Cells(cont_idContrato.Index).Value) <> 0 Then
                Dim list As List(Of planeacion) = mPlaneacion.TraerxIdContrato(r.Cells(cont_idContrato.Index).Value)
                If list.Count > 0 Then
                    mEstadoPlaneacion.actualizarxIdContrato(r.Cells(cont_idContrato.Index).Value, r.Cells(cont_idPendiente.Index).Value,
                                                            ClsEnums.Estados.CON_PLANEACION)
                Else
                    mEstadoPlaneacion.actualizarxIdContrato(r.Cells(cont_idContrato.Index).Value, r.Cells(cont_idPendiente.Index).Value,
                                                            ClsEnums.Estados.SIN_PLANEAR)
                End If
            Else
                Dim list As List(Of planeacion) = mPlaneacion.TraerxIdPendiente(r.Cells(cont_idPendiente.Index).Value)
                If list.Count > 0 Then
                    mEstadoPlaneacion.actualizarxIdPendiente(r.Cells(cont_idPendiente.Index).Value, r.Cells(cont_idContrato.Index).Value,
                                                             ClsEnums.Estados.SIN_CONT_PLANEADA)
                Else
                    mEstadoPlaneacion.actualizarxIdPendiente(r.Cells(cont_idPendiente.Index).Value, r.Cells(cont_idContrato.Index).Value,
                                                             ClsEnums.Estados.SIN_CONTRATO)
                End If
            End If
            cargarContratos(cmbVendedor.SelectedValue)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub abrirPlaneacion()
        Try
            Dim frm As New FrmAddProgramacion
            frm.Operacion = ClsEnums.TiOperacion.INSERTAR
            Dim cont As DataGridViewRow = dwContratos.SelectedRows(0)
            Dim dt As DataTable = New DataTable
            dt.Columns.Add("idItem")
            dt.Columns.Add("ubicacion")
            dt.Columns.Add("descripcion")
            dt.Columns.Add("puntosTotales")
            dt.Columns.Add("puntos")
            dt.Columns.Add("metros")
            dt.Columns.Add("unidades")
            dt.Columns.Add("idConcepto")
            mPlaneacion = New clsPlaneacion
            dwItems.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                     If Convert.ToBoolean(r.Cells(item_seleccionVarios.Index).EditedFormattedValue) = True Then
                                                                         dt.Rows.Add((Convert.ToInt32(r.Cells(item_id.Index).Value)),
                                                                                 r.Cells(item_ubicacion.Index).Value,
                                                                                 r.Cells(item_descripcion.Index).Value,
                                                                                 r.Cells(item_puntosTotales.Index).Value,
                                                                                 r.Cells(item_puntosSinPlanear.Index).Value,
                                                                                 r.Cells(item_metros.Index).Value,
                                                                                 r.Cells(item_unidades.Index).Value,
                                                                                     If(CInt(cont.Cells(cont_idContrato.Index).Value) <> 0,
                                                                                     mPlaneacion.traerConceptoxIDPadreAndIDContrato(cont.Cells(cont_idContrato.Index).Value, r.Cells(item_id.Index).Value),
                                                                                     mPlaneacion.traerConceptoxIDPendiente(cont.Cells(cont_idPendiente.Index).Value)))
                                                                     End If
                                                                 End Sub)
            frm.ListItems = dt
            Dim nit, codSucursal As String
            If Convert.ToString(cont.Cells(cont_codSucursal.Index).Value) <> String.Empty And
                cont.Cells(cont_codSucursal.Index).Value IsNot Nothing Then
                Dim docto As String = cont.Cells(cont_codSucursal.Index).Value
                Dim arr As String() = docto.Split("-")
                nit = arr(0)
                codSucursal = arr(1)
            Else
                nit = String.Empty
                codSucursal = String.Empty
            End If
            frm.Metros = cont.Cells(cont_metros.Index).Value
            frm.IdContrato = cont.Cells(cont_idContrato.Index).Value
            frm.IdPendiente = cont.Cells(cont_idPendiente.Index).Value
            frm.VendedorContrato = cmbVendedor.SelectedValue
            frm.Nit = nit
            frm.CodigoSucursal = codSucursal
            frm.Constructora = cont.Cells(cont_cliente.Index).Value
            frm.Obra = cont.Cells(cont_sucursal.Index).Value
            frm.NumeroContrato = cont.Cells(cont_contrato.Index).Value
            frm.RegionUno = cont.Cells(cont_region.Index).Value
            frm.FechaInicio = Convert.ToDateTime(cont.Cells(cont_fechaInicio.Index).Value).ToShortDateString
            If Convert.ToString(cont.Cells(cont_fechaFin.Index).Value) <> String.Empty Then
                frm.FechaFin = Convert.ToDateTime(cont.Cells(cont_fechaFin.Index).Value).ToShortDateString()
            Else
                frm.FechaFin = Nothing
            End If
            frm.ValorContrato = String.Format("{0:C}", Convert.ToDecimal(cont.Cells(cont_valorContrato.Index).Value))
            frm.TotalPuntos = cont.Cells(cont_puntosTotales.Index).Value
            frm.TotalUnidades = cont.Cells(cont_puntosTotales.Index).Value

            If frm.ShowDialog() = DialogResult.OK Then
                cmbVendedor.SelectedValue = ""
                cmbVendedor.SelectedValue = frm.VendedorContrato
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmPlaneacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarVendedores()
            fuenteContratos = dwContratos
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbVendedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVendedor.SelectedValueChanged
        Try
            If loadCompleted Then
                dwContratos.Rows.Clear()
                contratoSelected = False
                dwItems.Rows.Clear()
                dwPlaneacion.Rows.Clear()
                cargarContratos(cmbVendedor.SelectedValue)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Funcionamiento Paneles"
    Private Sub mostrarPaneles()
        Try
            mostrandoSpliters = True
            If PanelPlaneacion.Tag Is "A" Or PanelPlaneacion.Tag Is "V" Then
                'Visibles: Planeación
                splitC1.Visible = True
                splitC1.Panel1Collapsed = True
                splitC1.Panel2Collapsed = False
                If PanelContratos.Tag Is "A" Or PanelContratos.Tag Is "V" Then
                    'Visibles: Planeación - Contratos
                    splitC1.Panel1Collapsed = False
                    splitC2.Visible = True
                    splitC2.Panel1Collapsed = False
                    splitC2.Panel2Collapsed = True
                    If PanelItems.Tag Is "A" Or PanelItems.Tag Is "V" Then
                        'Visibles: Planeación - Contratos - Items
                        splitC2.Panel2Collapsed = False
                    Else
                        'Visibles: Planeación - Contratos
                        splitC2.Panel2Collapsed = True
                    End If
                Else
                    'Visibles: Planeación
                    If PanelItems.Tag Is "A" Or PanelItems.Tag Is "V" Then
                        'Visibles: Planeación . Items
                        splitC1.Panel1Collapsed = False
                        splitC2.Visible = True
                        splitC2.Panel1Collapsed = True
                        splitC2.Panel2Collapsed = False
                    Else
                        'Visibles: Planeación
                        splitC2.Panel2Collapsed = True
                        splitC2.Panel1Collapsed = True
                        splitC2.Visible = False
                        splitC1.Panel1Collapsed = True
                    End If
                End If
            Else
                'Visibles: Ninguno
                If PanelContratos.Tag Is "A" Or PanelContratos.Tag Is "V" Then
                    'Visibles: Contratos
                    splitC1.Visible = True
                    splitC1.Panel2Collapsed = True
                    splitC1.Panel1Collapsed = False
                    splitC2.Visible = True
                    splitC2.Panel1Collapsed = False
                    If PanelItems.Tag Is "A" Or PanelItems.Tag Is "V" Then
                        'Visibles:Contratos - items
                        splitC2.Panel2Collapsed = False
                    Else
                        'Visibles: Contratos
                        splitC2.Panel2Collapsed = True
                    End If
                Else
                    'Visibles: Ninguno
                    If PanelItems.Tag Is "A" Or PanelItems.Tag Is "V" Then
                        'Visibles: Items
                        splitC1.Visible = True
                        splitC1.Panel2Collapsed = True
                        splitC1.Panel1Collapsed = False
                        splitC2.Visible = True
                        splitC2.Panel1Collapsed = True
                        splitC2.Panel2Collapsed = False
                    Else
                        splitC2.Panel2Collapsed = True
                        splitC2.Panel1Collapsed = True
                        splitC2.Visible = False
                        splitC1.Panel1Collapsed = True
                        splitC1.Panel2Collapsed = True
                        splitC1.Visible = False
                    End If
                End If
            End If
            mostrandoSpliters = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Panel contratos"
    Private Sub tsbContratos_Click(sender As Object, e As EventArgs) Handles tsbContratos.Click
        Try
            If PanelContratos.Tag Is "D" Then
                PanelContratos.Tag = "V"
                mostrarPaneles()
                PanelContratos.Focus()
            Else
                PanelContratos.Tag = "D"
                mostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAnclajeContratos_Click(sender As Object, e As EventArgs) Handles btnAnclajeContratos.Click
        Try
            If PanelContratos.Tag Is "A" Then
                btnAnclajeContratos.BackgroundImage = ImageListAnclaje.Images(1)
                PanelContratos.Tag = "D"
                tsbContratos.Visible = True
                mostrarPaneles()
            Else
                btnAnclajeContratos.BackgroundImage = ImageListAnclaje.Images(0)
                PanelContratos.Tag = "A"
                tsbContratos.Visible = False
                mostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub splitC2_Panel1_Leave(sender As Object, e As EventArgs) Handles splitC2.Panel1.Leave
        Try
            If PanelContratos.Tag IsNot "A" Then
                PanelContratos.Tag = "D"
                If mostrandoSpliters = False Then
                    mostrarPaneles()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Panel Cotizaciones"
    Private Sub tsbCotizaciones_Click(sender As Object, e As EventArgs) Handles tsbCotizaciones.Click
        Try
            If PanelItems.Tag Is "D" Then
                PanelItems.Tag = "V"
                mostrarPaneles()
                PanelItems.Focus()
            Else
                PanelItems.Tag = "D"
                mostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAnclajeCotizaciones_Click(sender As Object, e As EventArgs) Handles btnAnclajeCotizaciones.Click
        Try
            If PanelItems.Tag Is "A" Then
                btnAnclajeCotizaciones.BackgroundImage = ImageListAnclaje.Images(1)
                PanelItems.Tag = "D"
                tsbCotizaciones.Visible = True
                mostrarPaneles()
            Else
                btnAnclajeCotizaciones.BackgroundImage = ImageListAnclaje.Images(0)
                PanelItems.Tag = "A"
                tsbCotizaciones.Visible = False
                mostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub splitC2_Panel2_Leave(sender As Object, e As EventArgs) Handles splitC2.Panel2.Leave
        Try
            If PanelItems.Tag IsNot "A" Then
                PanelItems.Tag = "D"
                If mostrandoSpliters = False Then
                    mostrarPaneles()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Panel Planeación"
    Private Sub tsbPlaneacion_Click(sender As Object, e As EventArgs) Handles tsbPlaneacion.Click
        Try
            If PanelPlaneacion.Tag Is "D" Then
                PanelPlaneacion.Tag = "V"
                mostrarPaneles()
                PanelPlaneacion.Focus()
            Else
                PanelPlaneacion.Tag = "D"
                mostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAnclarPlaneacion_Click(sender As Object, e As EventArgs) Handles btnAnclajePlaneacion.Click
        Try
            If PanelPlaneacion.Tag Is "A" Then
                btnAnclajePlaneacion.BackgroundImage = ImageListAnclaje.Images(1)
                PanelPlaneacion.Tag = "D"
                tsbPlaneacion.Visible = True
                mostrarPaneles()
            Else
                btnAnclajePlaneacion.BackgroundImage = ImageListAnclaje.Images(0)
                PanelPlaneacion.Tag = "A"
                tsbPlaneacion.Visible = False
                mostrarPaneles()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub splitC1_Panel2_Leave(sender As Object, e As EventArgs) Handles splitC1.Panel2.Leave
        Try
            If PanelPlaneacion.Tag IsNot "A" Then
                PanelPlaneacion.Tag = "D"
                If mostrandoSpliters = False Then
                    mostrarPaneles()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#Region "Filtros estados"
    Private Sub btnSinContratoPlaneada_Click(sender As Object, e As EventArgs) Handles btnSinContratoPlaneada.Click
        Try
            btnDeshacerFiltro.Visible = True
            tsSeparador.Visible = True
            For Each r As DataGridViewRow In dwContratos.Rows
                r.Visible = True
                If Convert.ToInt32(r.Cells(cont_idEstado.Index).Value) <> ClsEnums.Estados.SIN_CONT_PLANEADA Then
                    r.Visible = False
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnSinContrato_Click(sender As Object, e As EventArgs) Handles btnSinContrato.Click
        Try
            btnDeshacerFiltro.Visible = True
            tsSeparador.Visible = True
            For Each r As DataGridViewRow In dwContratos.Rows
                r.Visible = True
                If Convert.ToInt32(r.Cells(cont_idEstado.Index).Value) <> ClsEnums.Estados.SIN_CONTRATO Then
                    r.Visible = False
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnSinPlanear_Click(sender As Object, e As EventArgs) Handles btnSinPlanear.Click
        Try
            btnDeshacerFiltro.Visible = True
            tsSeparador.Visible = True
            For Each r As DataGridViewRow In dwContratos.Rows
                r.Visible = True
                If Convert.ToInt32(r.Cells(cont_idEstado.Index).Value) <> ClsEnums.Estados.SIN_PLANEAR Then
                    r.Visible = False
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnConPlaneacion_Click(sender As Object, e As EventArgs) Handles btnConPlaneacion.Click
        Try
            btnDeshacerFiltro.Visible = True
            tsSeparador.Visible = True
            For Each r As DataGridViewRow In dwContratos.Rows
                r.Visible = True
                If Convert.ToInt32(r.Cells(cont_idEstado.Index).Value) <> ClsEnums.Estados.CON_PLANEACION Then
                    r.Visible = False
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnTerminado_Click(sender As Object, e As EventArgs) Handles btnTerminado.Click
        Try
            btnDeshacerFiltro.Visible = True
            tsSeparador.Visible = True
            For Each r As DataGridViewRow In dwContratos.Rows
                r.Visible = True
                If Convert.ToInt32(r.Cells(cont_idEstado.Index).Value) <> ClsEnums.Estados.TERMINADO Then
                    r.Visible = False
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnDeshacerFiltro_Click(sender As Object, e As EventArgs) Handles btnDeshacerFiltro.Click
        Try
            For Each r As DataGridViewRow In dwContratos.Rows
                r.Visible = True
            Next
            btnDeshacerFiltro.Visible = False
            tsSeparador.Visible = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub dwContratos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwContratos.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                contratoSelected = True
                Dim r As DataGridViewRow = dwContratos.Rows(e.RowIndex)
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    dwContratos.Rows(e.RowIndex).Selected = True
                    Dim menu As New ContextMenuStrip
                    If Convert.ToInt32(r.Cells(cont_idEstado.Index).Value) = ClsEnums.Estados.TERMINADO Then
                        menu.Items.Add("Restaurar planeación", Nothing, AddressOf restaurarPlaneacion)
                    Else
                        menu.Items.Add("Terminar planeación", ImageListEstados.Images(4), AddressOf terminarPlaneacion)
                    End If
                    menu.Show(Control.MousePosition)
                ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
                    If Convert.ToInt32(r.Cells(cont_idContrato.Index).Value) <> 0 Then
                        cargarItems(r.Cells(cont_idContrato.Index).Value, True)
                        cargarPlaneaciones(r.Cells(cont_idContrato.Index).Value, r.Cells(cont_idPendiente.Index).Value)
                    ElseIf Convert.ToInt32(r.Cells(cont_idPendiente.Index).Value) <> 0 And Convert.ToInt32(r.Cells(cont_idContrato.Index).Value) = 0 Then
                        cargarItems(r.Cells(cont_idPendiente.Index).Value, False)
                        cargarPlaneaciones(r.Cells(cont_idContrato.Index).Value, r.Cells(cont_idPendiente.Index).Value)
                    End If
                End If
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
                    dwItems.Rows(e.RowIndex).Selected = True
                    If Convert.ToBoolean(r.Cells(item_seleccionVarios.Index).EditedFormattedValue) = True Then
                        Dim menu As New ContextMenuStrip
                        menu.Items.Add("Programar seleccionados", Nothing, AddressOf abrirPlaneacion)
                        menu.Show(Control.MousePosition)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnEditarTodas_Click(sender As Object, e As EventArgs) Handles btnEditarTodas.Click
        Try
            If contratoSelected Then
                Dim frm As New FrmAddProgramacion
                frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
                Dim cont As DataGridViewRow = dwContratos.SelectedRows(0)
                Dim nit, codSucursal As String
                If Convert.ToString(cont.Cells(cont_codSucursal.Index).Value) <> String.Empty And
                    cont.Cells(cont_codSucursal.Index).Value IsNot Nothing Then
                    Dim docto As String = cont.Cells(cont_codSucursal.Index).Value
                    Dim arr As String() = docto.Split("-")
                    nit = arr(0)
                    codSucursal = arr(1)
                Else
                    nit = String.Empty
                    codSucursal = String.Empty
                End If
                frm.IdContrato = cont.Cells(cont_idContrato.Index).Value
                frm.IdPendiente = cont.Cells(cont_idPendiente.Index).Value
                frm.VendedorContrato = cmbVendedor.SelectedValue
                frm.Nit = nit
                frm.CodigoSucursal = codSucursal
                frm.Constructora = cont.Cells(cont_cliente.Index).Value
                frm.Obra = cont.Cells(cont_sucursal.Index).Value
                frm.NumeroContrato = cont.Cells(cont_contrato.Index).Value
                frm.RegionUno = cont.Cells(cont_region.Index).Value
                frm.FechaInicio = Convert.ToDateTime(cont.Cells(cont_fechaInicio.Index).Value).ToShortDateString
                If Convert.ToString(cont.Cells(cont_fechaFin.Index).Value) <> String.Empty Then
                    frm.FechaFin = Convert.ToDateTime(cont.Cells(cont_fechaFin.Index).Value).ToShortDateString()
                Else
                    frm.FechaFin = Nothing
                End If
                frm.Metros = cont.Cells(cont_metros.Index).Value
                frm.ValorContrato = String.Format("{0:C}", Convert.ToDecimal(cont.Cells(cont_valorContrato.Index).Value))
                frm.TotalPuntos = cont.Cells(cont_puntosTotales.Index).Value
                frm.TotalUnidades = cont.Cells(cont_puntosTotales.Index).Value

                If frm.ShowDialog() = DialogResult.OK Then
                    'cmbVendedor.SelectedValue = ""
                    'cmbVendedor.SelectedValue = frm.VendedorContrato
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnProgramar_Click(sender As Object, e As EventArgs) Handles btnProgramar.Click
        Try
            Dim count As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If Convert.ToBoolean(r.Cells(item_seleccionVarios.Index).EditedFormattedValue) = True Then
                    count += 1
                End If
            Next
            If count = 0 Then
                MsgBox("No se ha seleccionado ningún item para programar")
                Return
            End If
            abrirPlaneacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cbSeleccionTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbSeleccionTodos.CheckedChanged
        Try
            If cbSeleccionTodos.Checked Then
                For Each r As DataGridViewRow In dwItems.Rows
                    r.Cells(item_seleccionVarios.Index).Value = True
                Next
            Else
                For Each r As DataGridViewRow In dwItems.Rows
                    r.Cells(item_seleccionVarios.Index).Value = False
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class