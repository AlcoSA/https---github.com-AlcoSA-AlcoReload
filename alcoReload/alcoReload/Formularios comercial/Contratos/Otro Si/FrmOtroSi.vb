Imports ReglasNegocio
Public Class FrmOtroSi
#Region "Variables"
    Private _idcontrato As Integer = 0
    Private _idotrosi As Integer = 0
    Private cotrosi As ClsOtroSi
    Private mformatootrosi As ClsFormatoOtrosi
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
#End Region
#Region "Propiedades"
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
        End Set
    End Property
    Public Property IdOtroSi As Integer
        Get
            Return _idotrosi
        End Get
        Set(value As Integer)
            _idotrosi = value
        End Set
    End Property
    Public Property TipoOperacion As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return nudvalor.Value
        End Get
        Set(value As Decimal)
            nudvalor.Value = value
        End Set
    End Property
    Public Property FechaInicial As DateTime
        Get
            Return dtpfechainicial.Value
        End Get
        Set(value As DateTime)
            dtpfechainicial.Value = value
        End Set
    End Property
    Public Property FechaFinal As DateTime
        Get
            Return dtpfechafinal.Value
        End Get
        Set(value As DateTime)
            dtpfechafinal.Value = value
        End Set
    End Property
#End Region
#Region "Configuración Intellisens"
#Region "Comportamiento Nit"
    Private Sub ctrlNit_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs)
        Try
            ctrCliente.Text = e.ValorSecundario
            ctrCodSucursal.Text = String.Empty
            ctrObra.Text = String.Empty
            ctrCliente.Value2 = e.ValorPrimario
            ClienteYo.Text = "--"
            NitYo.Text = "--"
            If Not String.IsNullOrEmpty(e.Id) Then
                Dim _objObras As New clsObrasUnoee
                _objObras.traerObrasByID(e.Id, ctrCodSucursal.TablaFuente)
                ctrObra.TablaFuente = ctrCodSucursal.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ctrlNit_KeyUp(sender As Object, e As EventArgs) Handles ctrlNit.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                ctrCliente.Text = ""
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Comportamiento Cliente"
    Private Sub ctrCliente_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs)
        Try
            ctrlNit.Text = ctrCliente.Value2
            ctrlNit.Text = e.ValorSecundario
            ctrlNit.Value2 = e.ValorPrimario

            If Not ctrCliente.Seleted_rowid Is Nothing Then
                Dim _objObras As New clsObrasUnoee
                _objObras.traerObrasByID(e.Id, ctrCodSucursal.TablaFuente)
                ctrObra.TablaFuente = ctrCodSucursal.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ctrlCliente_KeyUp(sender As Object, e As EventArgs) Handles ctrCliente.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                ctrlNit.Text = String.Empty
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Comportamiento Código Obra"
    Private Sub ctrCodSucursal_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs)
        Try
            ctrObra.Text = e.ValorSecundario
            ctrObra.Seleted_rowid = e.Id
            ctrObra.Value2 = e.ValorPrimario
            Dim _objObras As New clsObrasUnoee
            NitYo.Text = _objObras.traerYo(ctrlNit.Text, e.ValorPrimario, "NIT")
            ClienteYo.Text = _objObras.traerYo(ctrlNit.Text, e.ValorPrimario, "NOMBRE")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ctrlCodSucursal_KeyUp(sender As Object, e As EventArgs) Handles ctrCodSucursal.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                ctrObra.Text = ""
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region
#Region "Comportamiento Obra"
    Private Sub ctrObra_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs)
        Try
            If Not String.IsNullOrEmpty(e.ValorSecundario) Then
                ctrCodSucursal.Text = e.ValorSecundario
                ctrCodSucursal.Value2 = e.ValorPrimario
                ctrCodSucursal.selected_item = ctrCodSucursal.TablaFuente.Rows.Cast(Of DataRow).FirstOrDefault(Function(x) Convert.ToString(x.Item(ctrCodSucursal.ColToReturn)) = e.ValorSecundario)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ctrlObra_KeyUp(sender As Object, e As EventArgs) Handles ctrObra.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                ctrCodSucursal.Text = ""
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#Region "Procedimientos"
    Private Sub cargarIntellisense()
        Try
            Dim _objCliente As New clsClientesUnoee
            _objCliente.t200_selectAllClientesUnoee(ctrlNit.TablaFuente)
            ctrCliente.TablaFuente = ctrlNit.TablaFuente
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargaInicial()
        Try
            Dim l_otrosi = cotrosi.TraerporIdContrato(_idcontrato)
            Dim _otrosi As OtroSi = l_otrosi.LastOrDefault()

            lbotrosi.Text = Convert.ToString(_idcontrato) & "-" & Convert.ToString(l_otrosi.Count) + 1

            If _otrosi IsNot Nothing Then
                FechaFinal = _otrosi.FechaFinal
                ctrCliente.Text = _otrosi.Cliente
                ctrlNit.Text = _otrosi.Nit
                ctrObra.Text = _otrosi.Obra
                ctrCodSucursal.Text = _otrosi.CodObra
                NitYo.Text = _otrosi.NitYO
                ClienteYo.Text = _otrosi.ClienteYO
            Else
                Dim mcont As New Contratos.clsContratos
                Dim contra As Contratos.contrato = mcont.traerById(_idcontrato)
                If contra IsNot Nothing Then
                    FechaFinal = contra.fechaFin
                    ctrCliente.Text = contra.Cliente
                    ctrlNit.Text = contra.nit
                    ctrObra.Text = contra.obra
                    ctrCodSucursal.Text = contra.codObra
                    NitYo.Text = contra.NitYo
                    ClienteYo.Text = contra.ClienteYo
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarElementosMinuta()
        Try
            Dim cvar As New ClsCreacionVariablesEsquemas
            cvar.selectAllVariables(editorMinutas.TablaVariables)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarFormatoscreados()
        Try
            ddbformatos.DropDownItems.Clear()
            Dim mformat As New ClsCreacionFormatosAlco
            Dim tb As List(Of Formato) = mformat.TraerporTipoFormato(ClsEnums.TipoFormato.OTROSI)
            For Each rw As Formato In tb
                Dim t As New ToolStripButton(rw.nombreArchivo)
                t.Width = 300
                t.Tag = rw.Id
                ddbformatos.DropDownItems.Add(t)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarOtroSi()
        Try
            Dim otro As OtroSi = cotrosi.TraerxId(_idotrosi)
            If otro IsNot Nothing Then
                lbotrosi.Text = Convert.ToString(_idcontrato) & "-" & Convert.ToString(otro.Indice)
                ctrlNit.Text = otro.Nit
                ctrCliente.Text = otro.Cliente
                ctrCodSucursal.Text = otro.CodObra
                ctrObra.Text = otro.Obra
                _idcontrato = otro.IdContrato
                txtnumero.Text = otro.NumeroContrato
                nudvalor.Text = otro.Valor
                dtpfechainicial.Value = otro.FechaInicial
                dtpfechafinal.Value = otro.FechaFinal
                rtbnotas.Text = otro.Notas
            End If

#Region "Carga de Formato si existe"
            Dim format As FormatoOtrosi = mformatootrosi.TraerporIdOtrosi(_idotrosi)
            If format.Id > 0 Then
                editorMinutas.Tag = format.Id
                lbnombredocumento.Text = format.nombreArchivo
                lbnombredocumento.Tag = format.IdFormato
                editorMinutas.Encabezado = format.encabezado
                editorMinutas.Cuerpo = format.cuerpo
                editorMinutas.PiedePagina = format.piepagina
                editorMinutas.AltoEncabezado = format.AltoEncabezado
                editorMinutas.AltoPiedePagina = format.AltoPiePagina
            End If
#End Region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarPolizas()
        Try
            Dim polz As New clsPolizas
            Dim lpoliza As List(Of poliza) = polz.traerTodos() '(dwItemsPoliza.TablaDatos)
            dwItemsPoliza.Rows.Clear()
            dwItemsPoliza.AutoGenerateColumns = False
            Dim pol_contrat As New clsPolizasContratos
            Dim listaPolizaContrato As List(Of polizasContratos) = pol_contrat.traerByIdContrato(_idcontrato)
            For Each p As poliza In lpoliza
                Dim r As DataGridViewRow = dwItemsPoliza.Rows(dwItemsPoliza.Rows.Add())
                r.Cells(id.Index).Value = p.Id
                r.Cells(FechaCreacion.Index).Value = p.FechaCreacion
                r.Cells(UsuarioCreacion.Index).Value = p.UsuarioCreacion
                r.Cells(Descripcion.Index).Value = p.descripcion
                r.Cells(PorcentajeDefecto.Index).Value = p.porcentajeDefecto
                r.Cells(UsuarioModif.Index).Value = p.UsuarioModificacion
                r.Cells(FechaModi.Index).Value = p.FechaModificacion
                r.Cells(idEstado.Index).Value = p.IdEstado
                Dim mp = listaPolizaContrato.FirstOrDefault(Function(x) x.idTipoPoliza = p.Id)
                If mp IsNot Nothing Then
                    r.Cells(selpol.Index).Value = True
                    r.Cells(PorcentajeDefecto.Index).Value = mp.Porcentaje
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarPlanAnticipo()
        Try
            Dim pantic As New ClsPlanAnticipos
            Dim planEncabe As anticipoNotaCobro = pantic.TraerxIdContrato(_idcontrato)
            idPlan.Text = planEncabe.Id
            nudanticipo.Value = planEncabe.PorcentajeAnticipo
            nudcuotas.Value = planEncabe.NumeroCuota
            dtpfechaprimeracuota.Text = planEncabe.FechaPrimeraCuota
            cmbDias.Text = planEncabe.RangoDias
            cbtipoanticipo.ComboBox.SelectedValue = planEncabe.IdtipoAnticipo

            Dim mvc As New clsMovitoItemsContrato
            Dim l_mvc = mvc.tc040_selectAllByIdContrato(_idcontrato)
            txtValSuministro.Text = l_mvc.Sum(Function(x) x.precioTotal).ToString("C0")
            txtValInstalacion.Text = l_mvc.Sum(Function(x) x.precioInstalacion).ToString("C0")

            Dim mov_plan_ant As New clsMovitoPlanAnticipos
            Dim coutas As List(Of cuota) = mov_plan_ant.traerxIdAnticipo(planEncabe.Id)
            For Each cta As cuota In coutas
                Dim fila As New DataGridViewRow
                fila = dwItemsAnticipos.Rows(dwItemsAnticipos.Rows.Add())
                fila.Cells(idCuota.Index).Value = cta.Id
                fila.Cells(_ColnCuota.Index).Value = cta.NumeroCuota
                fila.Cells(_colPorcentaje.Index).Value = cta.porcentajeCuota
                fila.Cells(_colValor.Index).Value = cta.valorCuota.ToString("c")
                fila.Cells(FechaCuota.Index).Value = cta.fechaCuota
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarTipoAnticipos()
        Try
            Dim tanticipo As New clsTipoAnticipo
            Dim listTipoAnticipo As List(Of TipoAnticipos) = tanticipo.selectAll()
            cbtipoanticipo.ComboBox.DisplayMember = "Nombre"
            cbtipoanticipo.ComboBox.ValueMember = "id"
            cbtipoanticipo.ComboBox.DataSource = listTipoAnticipo.Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CargarObjetos()
        Try
            Dim objcontr As New clsObjetosContratos
            Dim relobj As New clsRelacionObjetoContratos
            Dim listObjetos As List(Of objetoContrato) = objcontr.traerTodos()
            Dim listaObjetos As List(Of relacionObjetosContratos) = relobj.traerxIdContrato(_idcontrato)
            For Each o As objetoContrato In listObjetos
                Dim r As DataGridViewRow = dwItemsObjetos.Rows(dwItemsObjetos.Rows.Add())
                r.Cells(id1.Index).Value = o.Id
                r.Cells(FechaCreacion1.Index).Value = o.FechaCreacion
                r.Cells(usuarioCreacion1.Index).Value = o.UsuarioCreacion
                r.Cells(descripcion1.Index).Value = o.descripcion
                r.Cells(UsuarioModif1.Index).Value = o.UsuarioModificacion
                r.Cells(FechaModi.Index).Value = o.FechaModificacion
                r.Cells(idEstado1.Index).Value = o.IdEstado
                If listaObjetos.FirstOrDefault(Function(x) x.idObjeto = o.Id) IsNot Nothing Then
                    r.Cells(selected1.Index).Value = True
                End If
                'For Each fila As DataGridViewRow In dwItemsObjetos.Rows
                '    If listaObjetos.FindAll(Function(a) a.idObjeto = Convert.ToInt32(fila.Cells(id1.Index).Value)).Count > 0 Then
                '        fila.Cells(selected1.Index).Value = True
                '    End If
                'Next
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub CalculoCuota()
        Try
            Dim Valorcuota As Decimal = 0
            Dim porcentajeEquivalente As Decimal = 0
            Dim c As New Contratos.clsContratos
            Dim cont = c.traerById(_idcontrato)
            Dim val_suministro As Decimal = Convert.ToDecimal(txtValSuministro.Text.Replace("$", "").Replace(".", ""))
            Dim IVA As Decimal = cont.Valor_Impuesto
            Dim valcontrato As Decimal = cont.valorContrato + nudvalor.Value - dwItemsAnticipos.Rows.Cast(Of DataGridViewRow).Sum(Function(x) Convert.ToDecimal(x.Cells(_colValor.Index).Value))
            If valcontrato > 0 Then
                Select Case CInt(cbtipoanticipo.ComboBox.SelectedValue)
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTRO
                        Valorcuota = (val_suministro * ((nudanticipo.Value / 100))) / nudcuotas.Value
                        porcentajeEquivalente = Valorcuota / val_suministro
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROINSTALACION
                        Valorcuota = ((valcontrato) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                        porcentajeEquivalente = Valorcuota / cont.valorContrato
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROIVA
                        If cont.tipoImpuesto = ClsEnums.tipoImpuestos.IVAUTILIDAD Then
                            Dim ivaU As Integer = ((val_suministro / (1 + (cont.Utilidad / 100))) * (cont.Utilidad / 100)) * IVA
                            Valorcuota = ((val_suministro + ivaU) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                            porcentajeEquivalente = Valorcuota / (val_suministro + ivaU)
                        Else
                            Valorcuota = ((val_suministro * (1 + IVA)) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                            porcentajeEquivalente = Valorcuota / val_suministro
                        End If
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROMASINSTALACIONMASIVA
                        If cont.tipoImpuesto = ClsEnums.tipoImpuestos.IVAUTILIDAD Then
                            Dim ivaU As Integer = ((Convert.ToInt32(valcontrato) / (1 + (cont.valorContrato / 100))) * (cont.Utilidad / 100)) * IVA
                            Valorcuota = ((Convert.ToInt32(valcontrato) + ivaU) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                            porcentajeEquivalente = Valorcuota / (Convert.ToInt32(cont.valorContrato) + ivaU)
                        Else
                            Valorcuota = ((Convert.ToInt32(valcontrato) * (1 + IVA)) * (1 + (nudanticipo.Value / 100))) / nudcuotas.Value
                            porcentajeEquivalente = Valorcuota / (Convert.ToInt32(valcontrato) * (1 + IVA))
                        End If
                End Select
                Dim lastDate As Date = dtpfechaprimeracuota.Value
                For i = 1 To nudcuotas.Value
                    Dim fila As New DataGridViewRow
                    fila = dwItemsAnticipos.Rows(dwItemsAnticipos.Rows.Add())
                    fila.Cells(idCuota.Index).Value = 0
                    fila.Cells(_ColnCuota.Index).Value = i
                    fila.Cells(_colPorcentaje.Index).Value = porcentajeEquivalente * 100
                    fila.Cells(FechaCuota.Index).Value = lastDate
                    lastDate = If(Date.DaysInMonth(Year((lastDate)), Month(lastDate)) = 29 Or Date.DaysInMonth(Year((lastDate)), Month(lastDate)) = 31, lastDate.AddDays(CDbl(cmbDias.Text) + 1), lastDate.AddDays(CDbl(cmbDias.Text) + 1))
                    fila.Cells(_colValor.Index).Value = Valorcuota.ToString("c")
                Next
            Else
                MsgBox("No se pueden hacer modificaciones sobre este plan de anticipos.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
    Private Sub FrmOtroSi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cotrosi = New ClsOtroSi
            mformatootrosi = New ClsFormatoOtrosi
            cargarIntellisense()
            CargarPolizas()
            CargarObjetos()
            cargarTipoAnticipos()
            CargarPlanAnticipo()
            cargarElementosMinuta()
            cargarFormatoscreados()
            CargaInicial()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Select Case tform
                Case ClsEnums.TiOperacion.INSERTAR
                    _idotrosi = cotrosi.Insertar(My.Settings.UsuarioActivo, _idcontrato, txtnumero.Text,
                                     dtpfechainicial.Value, dtpfechafinal.Value, ctrlNit.Text, ctrCliente.Text,
                                                 ctrCodSucursal.Text, ctrObra.Text, NitYo.Text, ClienteYo.Text, nudvalor.Value,
                                     rtbnotas.Text, txtrepresentante.Text, txtcedularepr.Text, txtformaPago.Text, ClsEnums.Estados.ACTIVO)
                    If Not String.IsNullOrEmpty(editorMinutas.Cuerpo_Control.Text) Then
                        Dim cv As Boolean = editorMinutas.Combinado
                        If cv Then editorMinutas.Descombinar()
                        editorMinutas.Tag = mformatootrosi.Insertar(Convert.ToInt32(lbnombredocumento.Tag), _idotrosi,
                                                     My.Settings.UsuarioActivo, editorMinutas.Cuerpo,
                                                     editorMinutas.Encabezado, editorMinutas.PiedePagina,
                                                     editorMinutas.AltoEncabezado, editorMinutas.AltoPiedePagina)
                        If cv Then editorMinutas.Combinar()
                    End If
                Case ClsEnums.TiOperacion.MODIFICAR
                    cotrosi.Modificacion(_idotrosi, My.Settings.UsuarioActivo, _idcontrato,
                                         txtnumero.Text, dtpfechainicial.Value, dtpfechafinal.Value, ctrlNit.Text, ctrCliente.Text,
                                                 ctrCodSucursal.Text, ctrObra.Text, NitYo.Text, ClienteYo.Text,
                                         nudvalor.Value, rtbnotas.Text, txtrepresentante.Text, txtcedularepr.Text, txtformaPago.Text, ClsEnums.Estados.ACTIVO)
                    If Not String.IsNullOrEmpty(editorMinutas.Cuerpo_Control.Text) Then
                        Dim cv As Boolean = editorMinutas.Combinado
                        If cv Then editorMinutas.Descombinar()
                        If Convert.ToInt32(editorMinutas.Tag) > 0 Then
                            mformatootrosi.Modificar(Convert.ToInt32(editorMinutas.Tag), Convert.ToInt32(lbnombredocumento.Tag), _idotrosi,
                                                     My.Settings.UsuarioActivo, editorMinutas.Cuerpo,
                                                     editorMinutas.Encabezado, editorMinutas.PiedePagina,
                                                     editorMinutas.AltoEncabezado, editorMinutas.AltoPiedePagina)
                        Else
                            editorMinutas.Tag = mformatootrosi.Insertar(Convert.ToInt32(lbnombredocumento.Tag), _idotrosi,
                                                     My.Settings.UsuarioActivo, editorMinutas.Cuerpo,
                                                     editorMinutas.Encabezado, editorMinutas.PiedePagina,
                                                     editorMinutas.AltoEncabezado, editorMinutas.AltoPiedePagina)
                        End If
                        If cv Then editorMinutas.Combinar()
                    End If
            End Select
#Region "Pólizas"
            Dim pol_cont As New clsPolizasContratos
            pol_cont.EliminarporIdContrato(_idcontrato)
            For Each r As DataGridViewRow In dwItemsPoliza.Rows
                If r.Cells(selpol.Index).EditedFormattedValue Then
                    pol_cont.tc046_insert(My.Settings.UsuarioActivo, _idcontrato, r.Cells(id.Index).Value,
                                                    r.Cells(PorcentajeDefecto.Index).Value, 2)
                End If
            Next
#End Region
#Region "Objetos"
            Dim rel_con_obj As New clsRelacionObjetoContratos
            rel_con_obj.EliminarporIdContrato(_idcontrato)
            For Each r As DataGridViewRow In dwItemsObjetos.Rows
                If Convert.ToBoolean(r.Cells(selected1.Index).EditedFormattedValue) Then
                    rel_con_obj.tc043_insert(My.Settings.UsuarioActivo, _idcontrato, r.Cells(id1.Index).Value)
                End If
            Next
#End Region
#Region "Plan Anticipos"
            If dwItemsAnticipos.RowCount > 0 Then
                Dim p_anticipo As New ClsPlanAnticipos
                Dim mov_p_anticipo As New clsMovitoPlanAnticipos
                p_anticipo.Modificar(Convert.ToInt32(idPlan.Text), _idcontrato, cbtipoanticipo.ComboBox.SelectedValue,
                                              nudcuotas.Value, nudanticipo.Value, cmbDias.Text, ClsEnums.Estados.ACTIVO,
                                              dtpfechaprimeracuota.Value)
                For Each c As DataGridViewRow In dwItemsAnticipos.Rows
                    If Not String.IsNullOrEmpty(Convert.ToString(c.Cells(idCuota.Index).Value)) Then
                        mov_p_anticipo.Modificar(CInt(c.Cells(idCuota.Index).Value), Convert.ToInt32(idPlan.Text), CInt(c.Cells(_ColnCuota.Index).Value), CDec(c.Cells(_colPorcentaje.Index).Value),
                                                             CDec(c.Cells(_colValor.Index).Value), ClsEnums.Estados.ACTIVO, CDate(c.Cells(FechaCuota.Index).Value))
                    Else
                        mov_p_anticipo.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(idPlan.Text), c.Cells(_ColnCuota.Index).Value, c.Cells(_colPorcentaje.Index).Value,
                                                             c.Cells(_colValor.Index).Value, c.Cells(FechaCuota.Index).Value)
                    End If
                Next
            End If
#End Region


            DialogResult = DialogResult.OK
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ddbformatos_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ddbformatos.DropDownItemClicked
        Try
            lbnombredocumento.Text = e.ClickedItem.Text
            lbnombredocumento.Tag = Convert.ToInt32(e.ClickedItem.Tag)
            Dim mformat As New ClsCreacionFormatosAlco
            Dim fc As Formato = mformat.TraerXId(Convert.ToInt32(e.ClickedItem.Tag))
            editorMinutas.Encabezado = fc.encabezado
            editorMinutas.Cuerpo = fc.cuerpo
            editorMinutas.PiedePagina = fc.piepagina
            editorMinutas.AltoEncabezado = fc.AltoEncabezado
            editorMinutas.AltoPiedePagina = fc.AltoPiePagina
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub VistaPreviaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnvistaprevia.Click
        Try
            editorMinutas.VistaPrevia()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnimprimir.Click
        Try
            editorMinutas.Imprimir()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub PdfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnpdf.Click
        Try
            Dim svg As New SaveFileDialog
            svg.FileName = lbnombredocumento.Text & ".pdf"
            svg.Filter = "Adobe PDF (PDF (*.pdf)|*.pdf | Todos los Archivos (*.*) |*.*"
            If svg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                editorMinutas.GuardarArchivo(svg.FileName, ControlesPersonalizados.Editor_RTF.EditorRTF.TipoGuardado.ARCHIVO_PDF)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub WordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnword.Click
        Try
            Dim svg As New SaveFileDialog
            svg.FileName = "alcosys.rtf"
            svg.Filter = "Archivo de Word (Word (*.rtf)|*.rtf | Todos los Archivos (*.*) |*.*"
            If svg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                editorMinutas.GuardarArchivo(svg.FileName, ControlesPersonalizados.Editor_RTF.EditorRTF.TipoGuardado.ARCHIVO_WORD)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tbgeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbgeneral.SelectedIndexChanged
        Try
            tsseparador.Visible = tbgeneral.SelectedTab Is tpminuta
            ddbformatos.Visible = tbgeneral.SelectedTab Is tpminuta
            lbindnombre.Visible = tbgeneral.SelectedTab Is tpminuta
            lbnombredocumento.Visible = tbgeneral.SelectedTab Is tpminuta
            tssep2.Visible = tbgeneral.SelectedTab Is tpminuta
            sbimprimir.Visible = tbgeneral.SelectedTab Is tpminuta
            sbexportar.Visible = tbgeneral.SelectedTab Is tpminuta
            btncombinar.Visible = tbgeneral.SelectedTab Is tpminuta
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        Try
            _idotrosi = 0
            editorMinutas.Tag = 0
            editorMinutas.Encabezado = String.Empty
            editorMinutas.Cuerpo = String.Empty
            editorMinutas.PiedePagina = String.Empty
            ctrlNit.Text = String.Empty
            ctrCliente.Text = String.Empty
            ctrCodSucursal.Text = String.Empty
            ctrObra.Text = String.Empty
            txtnumero.Text = String.Empty
            nudvalor.Text = 0
            dtpfechainicial.Value = Today
            dtpfechafinal.Value = Today
            rtbnotas.Text = String.Empty
            CargaInicial()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btonCalculo_Click(sender As Object, e As EventArgs) Handles btonCalculo.Click
        Try
            Dim rs As New List(Of DataGridViewRow)
            For Each r As DataGridViewRow In dwItemsAnticipos.Rows
                If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(idCuota.Index).Value)) Then
                    Dim ncobra As New clsAnticiposPorNota
                    If ncobra.TraerxIdMovitoAnticipo(Convert.ToInt32(r.Cells(idCuota.Index).Value)).Count = 0 Then
                        rs.Add(r)
                    End If
                End If
            Next
            For Each r In rs
                dwItemsAnticipos.Rows.Remove(r)
            Next

            If nudcuotas.Value > 0 And nudanticipo.Value > 0 Then
                CalculoCuota()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class