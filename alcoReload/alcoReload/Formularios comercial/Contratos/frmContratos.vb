Imports ReglasNegocio
Imports Validaciones
Imports ReglasNegocio.Contratos
Imports ReglasNegocio.movitoPadres
Imports DatagridTreeView
Imports Multiusos
Imports ReglasNegocio.movitoHijos
Imports System.ComponentModel
Public Class frmContratos

#Region "Variables"
    Private _objContrato As New clsContratos
    Private _objValidaciona As New ClsValidaciones
    Private _objCliente As New clsClientesUnoee
    Private _objMinuta As New clsMinutas
    Private _objObras As New clsObrasUnoee
    Private _objPolizas As New clsPolizas
    Private _objPolizaContrato As New clsPolizasContratos
    Private _objRelacionObjetosContrato As New clsRelacionObjetoContratos
    Private _objRelacionParaContratos As New clsRelacionParaContrato
    Private _objObjetosContratos As New clsObjetosContratos
    Private _objMovitoItems As New clsMovitoItemsContrato
    Private _objTipoObra As New ClsTiposObras
    Private _objHijoCotizas As New ClsMovitoPadres
    Private _objTipoAnticipo As New clsTipoAnticipo
    Private _objPlanAnticipo As New ClsPlanAnticipos
    Private _objMovitoAnticipos As New clsMovitoPlanAnticipos
    Private _objformatocontrato As New ClsFormatoContrato
    Private _isload As Boolean
    Private mLimpiezaCampos As LimpiarCampos
    Private listClientes As List(Of clienteUnoee)
    Private listObras As List(Of obrasUnoee)
    Private listPolizas As New List(Of poliza)
    Private listObjetos As New List(Of objetoContrato)
    Private listpara As New List(Of tipoObra)
    Private listTipoAnticipo As New List(Of TipoAnticipos)
    Private loadingForm As Boolean = False
    Private listArticulos As List(Of Articulo)
    Private mMovitoHijo As ClsMovitoHijos
    Private mvarhijocotiza As ClsVariablesPlantillaCotiza
    Private frmCargas As New ControlesPersonalizados.BarradeProgresoPersonalizada
    Private _isLoading As Boolean
    Private dtPadres As New List(Of movitoPadre)
    Private dibujoscotiza As New ClsDibujosItemsCotiza
    Private _listParas As List(Of DataGridViewRow)

    Private _curIdAnticipo As Integer = 0
#End Region

#Region "Propiedades"

    Private _operacionActual As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Public Property operacionActual() As ClsEnums.TiOperacion
        Get
            Return _operacionActual
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            _operacionActual = value
        End Set
    End Property
    Private _expresionConsulta As String
    Public Property expresionConsulta() As String
        Get
            Return _expresionConsulta
        End Get
        Set(ByVal value As String)
            _expresionConsulta = value
        End Set
    End Property
    Private _listOfSelectedRows As List(Of DataGridViewRow)
    Public Property listaFilasSeleccionadas() As List(Of DataGridViewRow)
        Get
            Return _listOfSelectedRows
        End Get
        Set(ByVal value As List(Of DataGridViewRow))
            _listOfSelectedRows = value
        End Set
    End Property
    Private _curId As Integer = 0
    Public Property curId() As Integer
        Get
            Return _curId
        End Get
        Set(ByVal value As Integer)
            _curId = value
        End Set
    End Property
    Private _idPendienteContratar As Integer
    Public Property IdPendienteContratar() As Integer
        Get
            Return _idPendienteContratar
        End Get
        Set(ByVal value As Integer)
            _idPendienteContratar = value
        End Set
    End Property

#End Region

#Region "Configuración Intellisens"
#Region "Comportamiento Nit"
    Private Sub ctrlNit_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles ctrlNit.selected_value_changed
        Try
            ErrorProvider1.Clear()
            ctrCliente.Text = e.ValorSecundario
            ctrCodSucursal.Text = String.Empty
            ctrObra.Text = String.Empty
            ctrCliente.Value2 = e.ValorPrimario
            _objObras = New clsObrasUnoee
            ClienteYo.Text = "--"
            NitYo.Text = "--"
            If Not String.IsNullOrEmpty(e.Id) Then
                _objObras.traerObrasByID(e.Id, ctrCodSucursal.TablaFuente)
                ctrObra.TablaFuente = ctrCodSucursal.TablaFuente
                Dim tunoee As New ClsTercerosUnoee
                txtdircontrante.Text = tunoee.TraerInfoTerceroxNit(e.ValorPrimario).Direccion
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
    Private Sub ctrCliente_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles ctrCliente.selected_value_changed
        Try
            ErrorProvider1.Clear()
            ctrlNit.Text = ctrCliente.Value2
            ctrlNit.Text = e.ValorSecundario
            ctrlNit.Value2 = e.ValorPrimario
            _objObras = New clsObrasUnoee
            If Not ctrCliente.Seleted_rowid Is Nothing Then
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
    Private Sub ctrCodSucursal_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles ctrCodSucursal.selected_value_changed
        Try
            ErrorProvider1.Clear()
            ctrObra.Text = e.ValorSecundario
            ctrObra.Seleted_rowid = e.Id
            ctrObra.Value2 = e.ValorPrimario
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
    Private Sub ctrObra_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles ctrObra.selected_value_changed
        Try
            ErrorProvider1.Clear()
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

    ''' <summary>
    ''' Almacena la información del contrato en la base de datos.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs) Handles btonGuardar.Click
        Try
            Dim _guardar As Boolean
            Dim msg As String = ""
            If _operacionActual = ClsEnums.TiOperacion.INSERTAR Then
                If verificarRequeridos(msg) Then
                    MsgBox(msg, MsgBoxStyle.Information, "Campos requeridos")
                    Exit Sub
                Else
                    If dwItemsAnticipos.RowCount = 0 Then
                        If MsgBox("No se ha generado un plan de anticipos, esta seguro que quiere guardar el contrato", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            _guardar = False
                        Else
                            _guardar = True
                        End If
                    Else
                        _guardar = True
                    End If
                    If _guardar Then
                        insertar()
                        _operacionActual = ClsEnums.TiOperacion.MODIFICAR
                        MsgBox("El proceso ha terminado con éxito", MsgBoxStyle.Information)
                        DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                End If
            ElseIf operacionActual = ClsEnums.TiOperacion.MODIFICAR Then
                modificar()
                MsgBox("El proceso ha terminado con éxito", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que guarda la información cuando el contrato es nuevo
    ''' </summary>
    Private Sub insertar()
        Try
#Region "Datos generales"
            _curId = _objContrato.t039_insert(ctrlNit.Text, ctrCliente.Text, ctrCodSucursal.Text, ctrObra.Text, txtNumContrato.Text, dtInicial.Text,
                                              dtFinal.Text, If(rbsobreutilidad.Checked, rbsobreutilidad.Tag, ClsEnums.tipoImpuestos.IVAPLENO),
                                              Convert.ToDecimal(lbiva.Text) / 100, txtValcontratado.Value, lbvaloriva.Text, nudretenido.Value, txtNotas.Text,
                                              My.Settings.UsuarioActivo, My.Settings.UsuarioActivo, ClsEnums.Estados.EN_CONTRATACION, NitYo.Text, ClienteYo.Text,
                                              nudPorcAdministracion.Value, nudPorcImprovistos.Value, nudPorcUtilidad.Value)
            lbCns.Text = _curId
            _objMinuta.tc049_insert(My.Settings.UsuarioActivo, _curId, cbescritura.SelectedValue, txtnumEscritura.Text, dtregistro.Value, txtnotaria.Text, txtciudadnotaria.Text,
                                            CInt(cbciudadcc.SelectedValue), txtrepresentante.Text, txtcedularepr.Text, txtformaPago.Text, My.Settings.UsuarioActivo, txtdircontrante.Text)
            Dim mEstadoPlaneacion As New clsEstadosPlaneacion
            If _listOfSelectedRows IsNot Nothing Then
                For Each itm As DataGridViewRow In _listOfSelectedRows
                    Dim idEstado As Integer = mEstadoPlaneacion.TraerEstadoxIdPendiente(itm.Cells("id").Value)
                    If idEstado = ClsEnums.Estados.SIN_CONTRATO Then
                        mEstadoPlaneacion.actualizarxIdPendiente(itm.Cells("id").Value, _curId, ClsEnums.Estados.SIN_PLANEAR)
                        mEstadoPlaneacion.actualizarxIdContrato(_curId, 0, ClsEnums.Estados.SIN_PLANEAR)
                    ElseIf idEstado = ClsEnums.Estados.SIN_CONT_PLANEADA Then
                        mEstadoPlaneacion.actualizarxIdPendiente(itm.Cells("id").Value, _curId, ClsEnums.Estados.CON_PLANEACION)
                        mEstadoPlaneacion.actualizarxIdContrato(_curId, 0, ClsEnums.Estados.CON_PLANEACION)
                    End If
                Next
            End If
#End Region
#Region "Movimientos"
#Region "Pólizas"
            For Each r As DataGridViewRow In dwItemsPoliza.Rows
                If r.Cells(selected0.Index).EditedFormattedValue Then
                    _objPolizaContrato.tc046_insert(My.Settings.UsuarioActivo, _curId, r.Cells(id0.Index).Value,
                                                    r.Cells(PorcentajeDefecto0.Index).Value, 2)
                End If
            Next
#End Region
#Region "Objetos"
            For Each r As DataGridViewRow In dwItemsObjetos.Rows
                If Convert.ToBoolean(r.Cells(selected1.Index).EditedFormattedValue) Then
                    _objRelacionObjetosContrato.tc043_insert(My.Settings.UsuarioActivo, _curId, r.Cells(id1.Index).Value)
                End If
            Next
#End Region
#Region "Para"
            For Each r As DataGridViewRow In dwItemsPara.Rows
                If Convert.ToBoolean(r.Cells(selected2.Index).EditedFormattedValue) Then
                    _objRelacionParaContratos.tc042_insert(My.Settings.UsuarioActivo, _curId, r.Cells(id2.Index).Value)
                End If
            Next
#End Region
#Region "Modificación estado cotizas"
            Dim cot As New cotizaciones.ClsCostizaciones
            cot.ModificarEstado(ClsEnums.Estados.EN_CONTRATACION, _expresionConsulta)
            Dim _objClienteUnoee As New clsClientesUnoee
            Dim _objUnoee As New clsObrasUnoee
            Dim _objUnoeeDetalleObra As New ClsClienteDetalle
            Dim clienteUnoee As clienteUnoee = _objClienteUnoee.t200_ClientesUnoeeByNit(RTrim(ctrlNit.Text)).First()
            Dim obraUnoee As obrasUnoee = _objUnoee.traerObraByNitClienteAndSuc(RTrim(ctrlNit.Text), RTrim(ctrCodSucursal.Text))
            Dim ClienteDetalle As clienteDetalleUnoee = _objUnoeeDetalleObra.TraerDetalleCliente(clienteUnoee.idCliente, ctrCodSucursal.Text)
            cot.ModificarInfoBasica(ctrlNit.Text, ctrCliente.Text, clienteUnoee.telefono, clienteUnoee.direccion,
                                    clienteUnoee.Correo, clienteUnoee.nombreContacto, ctrObra.Text, obraUnoee.nomContacto,
                                    obraUnoee.telefono, obraUnoee.correo, _expresionConsulta)
#End Region
#Region "items"
            For Each nodoP As DataGridViewTreeNode In dwItems.Nodes
                nodoP.Cells(id.Index).Value = _objMovitoItems.tc040_insert(_curId, 0,
                                             Convert.ToInt32(nodoP.Cells(iditemcotiza.Index).Value),
                                             My.Settings.UsuarioActivo)
            Next
#End Region
#Region "Plan Anticipos"
            If dwItemsAnticipos.RowCount > 0 Then
                _curIdAnticipo = _objPlanAnticipo.Insertar(My.Settings.UsuarioActivo, _curId, cbtipoanticipo.ComboBox.SelectedValue, nudcuotas.Value, nudanticipo.Value, cmbDias.Text, dtpfechaprimeracuota.Value)
                For Each cuota As DataGridViewRow In dwItemsAnticipos.Rows
                    _objMovitoAnticipos.Insertar(My.Settings.UsuarioActivo, _curIdAnticipo, cuota.Cells(_ColnCuota.Index).Value, cuota.Cells(_colPorcentaje.Index).Value,
                                                             cuota.Cells(_colValor.Index).Value, cuota.Cells(FechaCuota.Index).Value)

                Next
            End If
#End Region
#Region "Minuta Contrato"
            If Not String.IsNullOrEmpty(editorMinutas.Cuerpo_Control.Text) Then
                Dim cv As Boolean = editorMinutas.Combinado
                If cv Then editorMinutas.Descombinar()
                lbidformatocontrato.Text = _objformatocontrato.Insertar(Convert.ToInt32(lbnombredocumento.Tag), _curId,
                                             My.Settings.UsuarioActivo, editorMinutas.Cuerpo,
                                             editorMinutas.Encabezado, editorMinutas.PiedePagina,
                                             editorMinutas.AltoEncabezado, editorMinutas.AltoPiedePagina)
                If cv Then editorMinutas.Combinar()

            End If
#End Region
            Me.operacionActual = ClsEnums.TiOperacion.MODIFICAR
#End Region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que guarda en la base de datos la información modificada.
    ''' </summary>
    Private Sub modificar()
        Try
            _objContrato.t039_update(ctrlNit.Text, ctrCliente.Text, ctrCodSucursal.Text, ctrObra.Text, txtNumContrato.Text, dtInicial.Value, dtFinal.Value,
                                     If(rbsobreutilidad.Checked, rbsobreutilidad.Tag, ClsEnums.tipoImpuestos.IVAPLENO), Convert.ToDecimal(lbiva.Text) / 100,
                                     txtValcontratado.Value, lbvaloriva.Text, nudretenido.Value, txtNotas.Text, My.Settings.UsuarioActivo, My.Settings.UsuarioActivo, Now,
                                     Convert.ToInt32(cmbestados.ComboBox.SelectedValue), _curId, NitYo.Text, ClienteYo.Text, nudPorcAdministracion.Value,
                                     nudPorcImprovistos.Value, nudPorcUtilidad.Value)
            _objMinuta.tc049_update(Convert.ToInt32(gpMinuta.Tag), _curId, CInt(cbescritura.SelectedValue),
                                    txtnumEscritura.Text, dtregistro.Value, txtnotaria.Text, txtciudadnotaria.Text,
                                    CInt(cbciudadcc.SelectedValue), txtrepresentante.Text, txtcedularepr.Text,
                                    txtformaPago.Text, My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO,
                                    txtdircontrante.Text)
#Region "Pólizas"
            _objPolizaContrato.EliminarporIdContrato(_curId)
            For Each r As DataGridViewRow In dwItemsPoliza.Rows
                If r.Cells(selected0.Index).EditedFormattedValue Then
                    _objPolizaContrato.tc046_insert(My.Settings.UsuarioActivo, _curId, r.Cells(id0.Index).Value,
                                                    r.Cells(PorcentajeDefecto0.Index).Value, 2)
                End If
            Next
#End Region
#Region "Objetos"
            _objRelacionObjetosContrato.EliminarporIdContrato(_curId)
            For Each r As DataGridViewRow In dwItemsObjetos.Rows
                If Convert.ToBoolean(r.Cells(selected1.Index).EditedFormattedValue) Then
                    _objRelacionObjetosContrato.tc043_insert(My.Settings.UsuarioActivo, _curId, r.Cells(id1.Index).Value)
                End If
            Next
#End Region
#Region "Para"
            _objRelacionParaContratos.EliminarporIdContrato(_curId)
            For Each r As DataGridViewRow In dwItemsPara.Rows
                If Convert.ToBoolean(r.Cells(selected2.Index).EditedFormattedValue) Then
                    _objRelacionParaContratos.tc042_insert(My.Settings.UsuarioActivo, _curId, r.Cells(id2.Index).Value)
                End If
            Next
#End Region
#Region "items"
            For Each nodoP As DataGridViewTreeNode In dwItems.Nodes
                _objMovitoItems.tc040_update(CInt(nodoP.Cells(id.Index).Value), _curId, 0,
                                             Convert.ToInt32(nodoP.Cells(iditemcotiza.Index).Value), My.Settings.UsuarioActivo,
                                             ClsEnums.Estados.ACTIVO)
            Next
#End Region
#Region "Plan Anticipos"
            If dwItemsAnticipos.RowCount > 0 Then
                _objPlanAnticipo.Modificar(_curIdAnticipo, _curId, cbtipoanticipo.ComboBox.SelectedValue,
                                              nudcuotas.Value, nudanticipo.Value, cmbDias.Text, ClsEnums.Estados.ACTIVO,
                                              dtpfechaprimeracuota.Value)
                For Each c As DataGridViewRow In dwItemsAnticipos.Rows
                    If Not String.IsNullOrEmpty(Convert.ToString(c.Cells(idCuota.Index).Value)) Then
                        _objMovitoAnticipos.Modificar(CInt(c.Cells(idCuota.Index).Value), _curIdAnticipo, CInt(c.Cells(_ColnCuota.Index).Value), CDec(c.Cells(_colPorcentaje.Index).Value),
                                                             CDec(c.Cells(_colValor.Index).Value), ClsEnums.Estados.ACTIVO, CDate(c.Cells(FechaCuota.Index).Value))
                    Else
                        _objMovitoAnticipos.Insertar(My.Settings.UsuarioActivo, _curIdAnticipo, c.Cells(_ColnCuota.Index).Value, c.Cells(_colPorcentaje.Index).Value,
                                                             c.Cells(_colValor.Index).Value, c.Cells(FechaCuota.Index).Value)
                    End If
                Next
            End If
#End Region
#Region "Minuta Contrato"
            If Not String.IsNullOrEmpty(editorMinutas.Cuerpo_Control.Text) Then
                Dim cv As Boolean = editorMinutas.Combinado
                If cv Then editorMinutas.Descombinar()
                If Convert.ToInt32(lbidformatocontrato.Text) > 0 Then
                    _objformatocontrato.Modificar(Convert.ToInt32(lbidformatocontrato.Text), Convert.ToInt32(lbnombredocumento.Tag), _curId,
                                             My.Settings.UsuarioActivo, editorMinutas.Cuerpo,
                                             editorMinutas.Encabezado, editorMinutas.PiedePagina,
                                             editorMinutas.AltoEncabezado, editorMinutas.AltoPiedePagina)
                Else
                    lbidformatocontrato.Text = _objformatocontrato.Insertar(Convert.ToInt32(lbnombredocumento.Tag), _curId,
                                             My.Settings.UsuarioActivo, editorMinutas.Cuerpo,
                                             editorMinutas.Encabezado, editorMinutas.PiedePagina,
                                             editorMinutas.AltoEncabezado, editorMinutas.AltoPiedePagina)
                End If
                If cv Then editorMinutas.Combinar()
            End If
#End Region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que carga la información por defecto de las cuadriculas de objetos, para y pólizas
    ''' </summary>
    ''' <param name="tb"></param>
    ''' <param name="dw"></param>
    ''' <param name="grid"></param>
    Private Sub Cargar(tb As DataTable, dw As DataGridView, Optional grid As Integer = 0)
        Try
            dw.Rows.Clear()
            For Each rw As DataRow In tb.Rows
                Dim r As DataGridViewRow = dw.Rows(dw.Rows.Add())
                For Each c As DataGridViewColumn In dw.Columns
                    If Not TypeOf (c) Is DataGridViewCheckBoxColumn Then
                        r.Cells(c.Name).Value = rw.Item(Mid(c.Name, 1, Len(c.Name) - 1))
                    End If
                Next
            Next
        Catch ex As Exception
            Throw New Exception("Error al cargar uno de los grids filtrados", ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Carga la información de los tipos de registro que puede tener una sociedad
    ''' </summary>
    Private Sub CargarTRegistro()
        Try
            Dim listaEscrituras As New clsTipoEscritura
            cbescritura.ValueMember = "id"
            cbescritura.DisplayMember = "Descripcion"
            cbescritura.DataSource = listaEscrituras.traerTodos().ToList.Where(Function(a) a.IdEstado = 1).ToList
        Catch ex As Exception
            Throw New Exception("Error al cargar el tipo de registro", ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Cargar las cámaras de comercio
    ''' </summary>
    Private Sub CargarCC()
        Try
            Dim listaciudades As New clsCiudadesCamaraComercio
            Dim dt As New DataTable
            cbciudadcc.AutoCompleteCustomSource.AddRange(listaciudades.traerTodos(dt).Select(Function(a) a.descripcion).ToArray())
            cbciudadcc.DataSource = dt
            cbciudadcc.ValueMember = "id"
            cbciudadcc.DisplayMember = "Ciudad"
        Catch ex As Exception
            Throw New Exception("Error al cargar las ciudades de las cámaras de comercio", ex.InnerException)
        End Try
    End Sub
    Private Sub cargarItemsDesdeContrato()
        Try
            _objMovitoItems = New clsMovitoItemsContrato
            Dim dt As New DataTable
            _objMovitoItems.tc040_selectAllByIdContrato(curId, dt)
            cargarMovitoItems(dt, True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CargarEstados()
        Try
            Dim mestados As New ClsEstados
            Dim mcontrato As New Contratos.clsContratos
            Dim bsource As New BindingSource()
            If mcontrato.VerificarMovimientos(_curId) Then
                bsource.DataSource = mestados.TraerTodos().Where(Function(x) (New ClsEnums.Estados() {ClsEnums.Estados.ACTIVO, ClsEnums.Estados.PARA_LIQUIDAR, ClsEnums.Estados.LIQUIDADO}).Contains(x.Id)).ToList()
            Else
                bsource.DataSource = mestados.TraerTodos().Where(Function(x) (New ClsEnums.Estados() {ClsEnums.Estados.ACTIVO, ClsEnums.Estados.ANULADO, ClsEnums.Estados.PARA_LIQUIDAR, ClsEnums.Estados.LIQUIDADO}).Contains(x.Id)).ToList()
            End If
            cmbestados.ComboBox.DisplayMember = "Descripcion"
            cmbestados.ComboBox.ValueMember = "Id"
            cmbestados.ComboBox.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarMovitoItems(tb As DataTable, desdecontrato As Boolean)
        Try
            mMovitoHijo = New ClsMovitoHijos
            For Each item As DataRow In tb.Rows
#Region "Carga Padres"
                Dim ndp As DataGridViewTreeNode = dwItems.Nodes.Add()
                If desdecontrato Then
                    ndp.Cells(id.Index).Value = item.Item("id")
                    ndp.Cells(iditemcotiza.Index).Value = item.Item("id_cotiza")
                Else
                    ndp.Cells(iditemcotiza.Index).Value = item.Item("id")
                End If
                ndp.Cells(idCotizacion.Index).Value = item.Item("idCotizacion")
                ndp.Cells(Ubicacion.Index).Value = RTrim(item.Item("ubicacion"))
                ndp.Cells(Descripcion.Index).Value = RTrim(item.Item("descripcion"))
                ndp.Cells(ancho.Index).Value = Math.Round(CDec(item.Item("ancho")), 0)
                ndp.Cells(Alto.Index).Value = Math.Round(CDec(item.Item("alto")), 0)
                ndp.Cells(mtCuadrados.Index).Value = ((CDec(item.Item("ancho")) / 1000) * (CDec(item.Item("alto")) / 1000))
                ndp.Cells(Cantidad.Index).Value = Math.Round(CDec(item.Item("cantidad")), 0)
                ndp.Cells(acabadoPerf.Index).Value = item.Item("acabado")
                ndp.Cells(vidrio.Index).Value = item.Item("vidrio")
                ndp.Cells(colorVidrio.Index).Value = item.Item("colorVidrio")
                ndp.Cells(espesor.Index).Value = item.Item("espesor")
                ndp.Cells(factor.Index).Value = Math.Round(CDec(item.Item("factor")), 2)
                ndp.Cells(piezasxUnidad.Index).Value = 1
                ndp.Cells(descuento.Index).Value = Math.Round(CDec(item.Item("Descuento")), 0)
                ndp.Cells(precioMtInstalacion.Index).Value = Math.Round(CDec(item.Item("precioMtInstalacion")), 0)
                ndp.Cells(precioInstalacion.Index).Value = Math.Round(CDec(item.Item("precioInstalacion")), 0) '(((CDec(ndp.Cells(mtCuadrados.Index).Value)) * item.cantidad) * Convert.ToDecimal(cmbInstalacion.Text))
                ndp.Cells(unidadMedida.Index).Value = "-"
                ndp.Cells(tipoItem.Index).Value = "-"
                ndp.Cells(versioncosto.Index).Value = Convert.ToString(item.Item("verCostoKiloAluminio")) & "." & Convert.ToString(item.Item("verCostoVidrio"))
#End Region
#Region "Carga Hijos"

                Dim listHijos As List(Of movitoHijo) = mMovitoHijo.TraerxIdPadre(Convert.ToInt32(ndp.Cells(iditemcotiza.Index).Value))
                For Each ith As movitoHijo In listHijos
                    Dim ndh As DataGridViewTreeNode = ndp.Nodes.Add
                    ndh.Cells(id.Index).Value = ith.Id
                    ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                    ndh.Cells(Ubicacion.Index).Value = ndp.Cells(Ubicacion.Index).Value ' RTrim(ith.referencia)
                    ndh.Cells(Descripcion.Index).Value = RTrim(ith.referencia)
                    ndh.Cells(ancho.Index).Value = Math.Round(ith.ancho)
                    ndh.Cells(Alto.Index).Value = Math.Round(ith.alto)
                    ndh.Cells(mtCuadrados.Index).Value = ((Math.Round(ith.ancho) * Math.Round(ith.alto, 0)) / 10000000) * ith.piezasxUnidad * ith.cantidad '"Pendiente"
                    ndh.Cells(Cantidad.Index).Value = ith.cantidad
                    ndh.Cells(acabadoPerf.Index).Value = ith.acabadoPerfil
                    ndh.Cells(vidrio.Index).Value = ith.vidrio
                    ndh.Cells(colorVidrio.Index).Value = ith.colorVidrio
                    ndh.Cells(espesor.Index).Value = ith.espesor
                    ndh.Cells(factor.Index).Value = ith.factor
                    ndh.Cells(descuento.Index).Value = ith.descuento
                    ndh.Cells(valorDescuento.Index).Value = ith.valorDescuento
                    ndh.Cells(precioUnitario.Index).Value = ith.precioUnitario
                    ndh.Cells(precioTotal.Index).Value = ith.precioTotal
                    ndh.Cells(piezasxUnidad.Index).Value = ith.piezasxUnidad
                    ndh.Cells(costoVidrio.Index).Value = ith.costoVidrio
                    ndh.Cells(costoPerfiles.Index).Value = ith.costoPerfiles
                    ndh.Cells(costoAccesorios.Index).Value = ith.costoAccesorios
                    ndh.Cells(costoOtros.Index).Value = ith.costoOtros
                    ndh.Cells(costoUnitario.Index).Value = ith.costoUnitario
                    ndh.Cells(costoTotal.Index).Value = ith.costoTotal
                    ndh.Cells(precioMtInstalacion.Index).Value = ith.tarifaMtInstalacion
                    ndh.Cells(precioInstalacion.Index).Value = ith.precioInstalacion
                    ndh.Cells(unidadMedida.Index).Value = RTrim(ith.unidadMedida)
                    ndh.Cells(valorDescuento.Index).Value = ith.valorDescuento
                    ndh.Cells(tipoItem.Index).Value = ith.tipoItem
                    Select Case DirectCast(ith.tipoItem, ClsEnums.FamiliasMateriales)
                        Case ClsEnums.FamiliasMateriales.DISEÑOS
                            ndh.Cells(idArticulo.Index).Value = ith.idPlantilla
                            ndh.Cells(versioncosto.Index).Value = Convert.ToString(ith.verCostoKiloAluminio) & "." & Convert.ToString(ith.verCostoAcabado) & "." & Convert.ToString(ith.verCostoNiveles) &
                                "." & Convert.ToString(ith.verCostoVidrio) & "." & Convert.ToString(ith.verCostoAccesorios) & "." & Convert.ToString(ith.verCostoOtrosArticulos)
                        Case ClsEnums.FamiliasMateriales.ACCESORIOS
                            ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                            ndh.Cells(versioncosto.Index).Value = Convert.ToString(ith.verCostoAccesorios)
                        Case ClsEnums.FamiliasMateriales.OTROS
                            ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                            ndh.Cells(versioncosto.Index).Value = Convert.ToString(ith.verCostoOtrosArticulos)
                        Case ClsEnums.FamiliasMateriales.PERFILERIA
                            ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                            ndh.Cells(versioncosto.Index).Value = Convert.ToString(ith.verCostoKiloAluminio) & "." & Convert.ToString(ith.verCostoAcabado) & "." & Convert.ToString(ith.verCostoNiveles)
                        Case ClsEnums.FamiliasMateriales.VIDRIO
                            ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                            ndh.Cells(versioncosto.Index).Value = Convert.ToString(ith.verCostoVidrio)
                    End Select

                    ndp.Cells(valorDescuento.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(valorDescuento.Index).Value))
                    ndp.Cells(precioUnitario.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioUnitario.Index).Value))
                    ndp.Cells(precioTotal.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(precioTotal.Index).Value))
                    ndp.Cells(costoAccesorios.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoAccesorios.Index).Value))
                    ndp.Cells(costoPerfiles.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoPerfiles.Index).Value))
                    ndp.Cells(costoVidrio.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoVidrio.Index).Value))
                    ndp.Cells(costoOtros.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoOtros.Index).Value))
                    ndp.Cells(costoTotal.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoTotal.Index).Value))
                    ndp.Cells(costoUnitario.Index).Value = ndp.Nodes.Sum(Function(a) Convert.ToDecimal(a.Cells(costoUnitario.Index).Value))


                    'ndp.Cells(calcularnorma.Index).Value = ith.calculo_NSR
                    'ndp.Cells(cumplenorma.Index).Value = ith.cumpleNorma
                Next
#End Region
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Selecciona los tipos de obra según las cotizaciones seleccionadas por el usuario
    ''' </summary>
    Private Sub seleccionarTiposObra()
        Try
            If _listOfSelectedRows IsNot Nothing Then
                For Each itm As DataGridViewRow In _listOfSelectedRows
                    For Each fila As DataGridViewRow In dwItemsPara.Rows
                        If fila.Cells(id2.Index).Value.ToString.Trim = itm.Cells("idtipoCotiza").Value.ToString.Trim Then
                            fila.Cells(selected2.Index).Value = True
                            seleccionObjetosObra(fila)
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Selecciona los objetos del contrato según el tipo de obra seleccionada en el grid de tipos de obra.
    ''' </summary>
    ''' <param name="rw">recibe el row que se va a avaluar</param>
    Private Sub seleccionObjetosObra(rw As DataGridViewRow)
        Try
            For Each r As DataGridViewRow In dwItemsObjetos.Rows
                If CInt(r.Cells(id1.Index).Value) = CInt(rw.Cells(idParaSuministro2.Index).Value) Or
                    CInt(r.Cells(id1.Index).Value) = CInt(rw.Cells(idParaInstalacion2.Index).Value) Then
                    r.Cells(selected1.Index).Value = True
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Carga los totales sumando los valores de todos los items requeridos para las cotizaciones.
    ''' </summary>
    Private Sub cargarTotales()
        Try
            txtValSuministro.Text = TotalSuministro().ToString("c")
            txtValInstalacion.Text = TotalInstalacion().ToString("c")
            txtValcontratado.Value = TotalSuministro() + TotalInstalacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que crea el control con los tipos de anticipos que puedes existir con un datasource
    ''' </summary>
    Private Sub cargarTipoAnticipos()
        Try
            _objTipoAnticipo = New clsTipoAnticipo
            listTipoAnticipo = New List(Of TipoAnticipos)
            listTipoAnticipo = _objTipoAnticipo.selectAll()
            cbtipoanticipo.ComboBox.DisplayMember = "Nombre"
            cbtipoanticipo.ComboBox.ValueMember = "id"
            cbtipoanticipo.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            cbtipoanticipo.ComboBox.DropDownWidth = 250
            cbtipoanticipo.ComboBox.DataSource = listTipoAnticipo.Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Carga la información predeterminada de los desplegables y de los grids 
    ''' </summary>
    Public Sub CargarControlesFormulario()
        Try
            _objCliente = New clsClientesUnoee
            _objCliente.t200_selectAllClientesUnoee(ctrlNit.TablaFuente)
            lbCns.Text = _objContrato.t039_selectNextId()
            ctrCliente.TablaFuente = ctrlNit.TablaFuente
            Dim tb As DataTable = Nothing
            listPolizas = _objPolizas.traerTodos(tb)
            Cargar(tb, dwItemsPoliza)
            listObjetos = _objObjetosContratos.traerTodos(tb)
            Cargar(tb, dwItemsObjetos)
            listpara = _objTipoObra.TraerTodos(tb)
            Cargar(tb, dwItemsPara)
            CargarTRegistro()
            CargarCC()
            cargarTipoAnticipos()
            cargarFormatoscreados()
            cargarElementosMinuta()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Cargar la información necesaria para la creación de un nuevo contrato.
    ''' </summary>
    Public Sub CargarContratoNuevo()
        Try
            CargarControlesFormulario()
            seleccionarTiposObra()
            Dim tb As DataTable = Nothing
            _objHijoCotizas.traerByGroupCotiza(_expresionConsulta, tb)
            cargarMovitoItems(tb, False)
            cargarTotales()
            If validarImpuestos() Then
                MsgBox("Las cotizaciones seleccionadas tienen diferentes tipos de Impuestos" & vbLf & "o los porcentajes asignados al A.I.U no son diferentes en las cotizaciones, por favor verifique e intente nuevamente.", MsgBoxStyle.Information)
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Carga la información del contrato cuando se va ha modificar
    ''' </summary>
    Public Sub cargarContratoParaModificacion()
        Try
            lbCns.Text = _curId
            Dim contrato As New contrato
            contrato = _objContrato.traerById(_curId)
            ctrlNit.Text = contrato.nit
            ctrCliente.Text = contrato.Cliente
            ctrCodSucursal.Text = contrato.codObra
            ctrObra.Text = contrato.obra
            NitYo.Text = contrato.NitYo
            ClienteYo.Text = contrato.ClienteYo
            txtNumContrato.Text = contrato.nContrato
            txtValcontratado.Value = contrato.valorContrato
            lbvaloriva.Text = contrato.valorIva.ToString("c")
            txtNotas.Text = contrato.notas
            nudPorcAdministracion.Value = contrato.Administracion
            nudPorcImprovistos.Value = contrato.Improvistos
            nudPorcUtilidad.Value = contrato.Utilidad
            nudretenido.Value = contrato.Porcentaje_Retenido
            cmbestados.ComboBox.SelectedValue = contrato.IdEstado
            lbiva.Text = contrato.Valor_Impuesto * 100
            Dim rdb As New RadioButton()
            rdb.Tag = contrato.Valor_Impuesto
            rdb.Text = "IVA " & contrato.Valor_Impuesto * 100 & "%"
            flptasas.Controls.Add(rdb)
            If contrato.tipoImpuesto = ClsEnums.tipoImpuestos.IVAPLENO Then
                rdb.Checked = True
                rbsobreutilidad.Checked = False
                calculoIvaPleno(contrato.Valor_Impuesto)
            ElseIf contrato.tipoImpuesto = ClsEnums.tipoImpuestos.IVAUTILIDAD Then
                rbsobreutilidad.Checked = True
                rbsobreutilidad.Tag = CInt(ClsEnums.tipoImpuestos.IVAUTILIDAD)
                calculoIvaUtilidad()
            End If
#Region "Carga los datos adicionales de la pestaña general"
            Dim AdicionalesMinutas As minutas = _objMinuta.traerByIdContrato(_curId).First
            gpMinuta.Tag = AdicionalesMinutas.Id
            cbescritura.SelectedValue = AdicionalesMinutas.idTipoEscritura
            cbciudadcc.SelectedValue = AdicionalesMinutas.idCiudadCamaraComercio
            txtnumEscritura.Text = AdicionalesMinutas.numeroEscritura
            dtregistro.Value = AdicionalesMinutas.fechaRegistro
            txtnotaria.Text = AdicionalesMinutas.NumeroNotaria
            txtciudadnotaria.Text = AdicionalesMinutas.ciudadNotaria
            txtdircontrante.Text = AdicionalesMinutas.DireccionContratante
            txtrepresentante.Text = AdicionalesMinutas.representanteLegal
            txtcedularepr.Text = AdicionalesMinutas.cedulaRepresentante

#End Region
#Region "Carga la información de las pólizas del contrato"
            Dim listaPolizaContrato As List(Of polizasContratos) = _objPolizaContrato.traerByIdContrato(curId)
            For Each p As polizasContratos In listaPolizaContrato
                Dim r As DataGridViewRow = dwItemsPoliza.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(id0.Index).Value) = p.idTipoPoliza)
                If r IsNot Nothing Then
                    r.Cells(selected0.Index).Value = True
                    r.Cells(PorcentajeDefecto0.Index).Value = p.Porcentaje
                End If
            Next
#End Region
#Region "Cargar información objetos del contrato"
            Dim listaObjetos As List(Of relacionObjetosContratos) = _objRelacionObjetosContrato.traerxIdContrato(_curId)
            For Each fila As DataGridViewRow In dwItemsObjetos.Rows
                If listaObjetos.FindAll(Function(a) a.idObjeto = Convert.ToInt32(fila.Cells(id1.Index).Value)).Count > 0 Then
                    fila.Cells(selected1.Index).Value = True
                End If
            Next

#End Region
#Region "Carga la información de los Para del contrato"
            Dim listaPara As List(Of relacionParaContrato) = _objRelacionParaContratos.traerxIdContrato(_curId)
            For Each fila As DataGridViewRow In dwItemsPara.Rows
                If listaPara.FindAll(Function(a) a.idTipoObra = Convert.ToInt32(fila.Cells(id2.Index).Value)).Count > 0 Then
                    fila.Cells(selected1.Index).Value = True
                End If
            Next
#End Region
#Region "Carga la información de los items del contrato"
            cargarItemsDesdeContrato()
#End Region
#Region "Carga la información de los planes de anticipo"
            cargarTotales()
            Dim planEncabe As anticipoNotaCobro = _objPlanAnticipo.TraerxIdContrato(_curId)
            _curIdAnticipo = planEncabe.Id
            idPlan.Text = planEncabe.Id
            nudanticipo.Value = planEncabe.PorcentajeAnticipo
            nudcuotas.Value = planEncabe.NumeroCuota
            dtpfechaprimeracuota.Value = planEncabe.FechaPrimeraCuota
            cmbDias.Text = planEncabe.RangoDias
            cbtipoanticipo.ComboBox.SelectedValue = planEncabe.IdtipoAnticipo
            Dim coutas As List(Of cuota) = _objMovitoAnticipos.traerxIdAnticipo(planEncabe.Id)
            For Each cta As cuota In coutas
                Dim fila As New DataGridViewRow
                fila = dwItemsAnticipos.Rows(dwItemsAnticipos.Rows.Add())
                fila.Cells(id.Index).Value = cta.Id
                fila.Cells(_ColnCuota.Index).Value = cta.NumeroCuota
                fila.Cells(_colPorcentaje.Index).Value = cta.porcentajeCuota
                fila.Cells(_colValor.Index).Value = cta.valorCuota.ToString("c")
                fila.Cells(FechaCuota.Index).Value = cta.fechaCuota
            Next
#End Region
#Region "Carga de Formato si existe"
            Dim format As FormatoContrato = _objformatocontrato.TraerporIdContrato(_curId)
            If format.Id > 0 Then
                lbidformatocontrato.Text = format.Id
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
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarElementosMinuta()
        Try
            Dim cvar As New ClsCreacionVariablesEsquemas
            cvar.selectByEstado(ClsEnums.Estados.ACTIVO, editorMinutas.TablaVariables)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarFormatoscreados()
        Try
            ddbformatos.DropDownItems.Clear()
            Dim mformat As New ClsCreacionFormatosAlco
            Dim tb As List(Of Formato) = mformat.TraerporTipoFormato(ClsEnums.TipoFormato.CONTRATO)
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
    Private Sub TraerdesdeHistorico()
        Try
            Dim lmin As List(Of minutas) = _objMinuta.TraerporNit(ctrlNit.Text)
            For Each m As minutas In lmin
                cbescritura.SelectedValue = m.idTipoEscritura
                txtnumEscritura.Text = m.numeroEscritura
                dtregistro.Value = m.fechaRegistro
                txtnotaria.Text = m.NumeroNotaria
                txtciudadnotaria.Text = m.ciudadNotaria
                txtdircontrante.Text = m.DireccionContratante
                txtrepresentante.Text = m.representanteLegal
                txtcedularepr.Text = m.cedulaRepresentante
                txtformaPago.Text = m.formaPago
                cbciudadcc.SelectedValue = m.idCiudadCamaraComercio
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

#Region "Funciones"
    ''' <summary>
    ''' Verifica que los campos requeridos según las reglas de negocio si estén correctamente diligenciados
    ''' y devuelve el mensaje personalizado que será mostrado al usuario.
    ''' </summary>
    ''' <returns></returns>
    Private Function verificarRequeridos(ByRef msg As String) As Boolean
        dwItemsObjetos.EndEdit()
        dwItemsPara.EndEdit()
        dwItems.EndEdit()
        verificarRequeridos = False
        ErrorProvider1.Clear()
        Try
#Region "Validar Campos Generales"
            If String.IsNullOrEmpty(ctrlNit.Text) Then
                ErrorProvider1.SetError(ctrlNit, "El campo no puede estar vacío")
                msg = "Error en: " & ctrlNit.Tag.ToString
                verificarRequeridos = True
                Exit Function
            End If
            If String.IsNullOrEmpty(ctrCliente.Text) Then
                ErrorProvider1.SetError(ctrCliente, "El campo no puede estar vacío")
                msg = "Error en: " & ctrCliente.Tag.ToString
                verificarRequeridos = True
                Exit Function
            End If
            If String.IsNullOrEmpty(ctrCodSucursal.Text) Then
                ErrorProvider1.SetError(ctrCodSucursal, "El campo no puede estar vacío")
                msg = "Error en: " & ctrCodSucursal.Tag.ToString
                verificarRequeridos = True
                Exit Function
            End If
            If String.IsNullOrEmpty(ctrObra.Text) Then
                ErrorProvider1.SetError(ctrObra, "El campo no puede estar vacío")
                msg = "Error en: " & ctrObra.Tag.ToString
                verificarRequeridos = True
                Exit Function
            End If
            If txtValcontratado.Value = 0 Then
                ErrorProvider1.SetError(txtValcontratado, "El campo no puede estar vacío")
                msg = "Error en: " & txtValcontratado.Tag.ToString
                Exit Function
            End If
            If cbciudadcc.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cbciudadcc, "El campo no puede estar vacío")
                msg = "Error en: " & cbciudadcc.Tag.ToString
                Exit Function
            End If

#End Region
#Region "Validación Pólizas"
            'No se valida porque no es mandatario para todos los contratos 
            'pueden existir contratos que no requieran póliza, por ejemplo aquellos
            'que se hacen a nombre de Juan Francisco y Juan Manuel o a nombre de un empleado.
#End Region
#Region "Validación Objetos"
            For Each fila As DataGridViewRow In dwItemsObjetos.Rows
                If fila.Cells(selected1.Index).Value Then
                    verificarRequeridos = False
                    msg = ""
                    Exit For
                Else
                    verificarRequeridos = True
                    msg = "Debe seleccionar por lo menos una de las opciones del grid de objetos del contrato"
                End If
            Next
            If verificarRequeridos Then Exit Function
#End Region
#Region "Validación Para"
            For Each fila As DataGridViewRow In dwItemsPara.Rows
                If fila.Cells(selected2.Index).Value Then
                    verificarRequeridos = False
                    msg = ""
                    Exit For
                Else
                    verificarRequeridos = True
                    msg = "Debe seleccionar por lo menos una de las opciones del grid Para que es el contrato"
                End If
            Next
            If verificarRequeridos Then Exit Function
#End Region
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function

    ''' <summary>
    ''' Valida que las cotizaciones seleccionadas tengan el mismo tipo de impuestos.
    ''' </summary>
    ''' <returns></returns>
    Private Function validarImpuestos() As Boolean
        validarImpuestos = False
        Try
            Dim listaIvaPleno As New List(Of DataGridViewRow)
            Dim listaIvaUtilidad As New List(Of DataGridViewRow)

            For Each r As DataGridViewRow In dwItemsPara.Rows
                If r.Cells(selected2.Index).Value Then
                    If r.Cells(ivaPleno2.Index).Selected Then
                        listaIvaPleno.Add(r)
                    Else
                        listaIvaUtilidad.Add(r)
                    End If
                End If
            Next
            If listaIvaPleno.Count > 0 And listaIvaUtilidad.Count > 0 Then
                validarImpuestos = True
            Else
                If listaIvaPleno.Count > 0 Then
                    rbsobreutilidad.Checked = False
                    If flptasas.Controls.Count > 1 Then
                        DirectCast(flptasas.Controls.Item(1), RadioButton).Checked = True
                    End If
                    calculoIvaPleno(Convert.ToDecimal(lbiva.Text) / 100)
                Else

                    For Each fil1 As DataGridViewRow In _listOfSelectedRows
                        If fil1.Cells("AIU_Administracion").Value.ToString = _listOfSelectedRows(0).Cells("AIU_Administracion").Value.ToString And
                            fil1.Cells("AIU_Improvistos").Value.ToString = _listOfSelectedRows(0).Cells("AIU_Improvistos").Value.ToString And
                            fil1.Cells("AIU_Utilidad").Value.ToString = _listOfSelectedRows(0).Cells("AIU_Utilidad").Value.ToString Then
                            validarImpuestos = False
                        Else
                            validarImpuestos = True
                            Exit For
                        End If
                    Next
                    If Not validarImpuestos Then
                        cargarParametrosIvaUtilidad()
                        gbxParametrosAIU.Enabled = True
                        rbsobreutilidad.Enabled = True
                        rbsobreutilidad.Checked = True
                        calculoIvaUtilidad()
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    ''' <summary>
    ''' Valida los campos según su tipo
    ''' </summary>
    ''' <returns></returns>
    Public Function validaciones() As Boolean
        validaciones = False
        Try
            For Each control As Control In gbInfo.Controls
                If TypeOf (control) Is TextBox Then
                    If control.Name = "txtValcontratado" Then
                        validaciones = _objValidaciona.EsNumero(control, "entero", ErrorProvider1)
                    End If
                    validaciones = _objValidaciona.TextBoxDigitado(control, ErrorProvider1)
                    Return True
                End If
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Calcula y devuelve la sumatoria de los precios totales de los items padres de las cotizaciones seleccionadas
    ''' por el usuario.
    ''' </summary>
    ''' <returns></returns>
    Public Function TotalSuministro() As Decimal
        TotalSuministro = 0
        Try
            TotalSuministro = dwItems.Rows.Cast(Of DatagridTreeView.DataGridViewTreeNode).AsParallel.Where(Function(a) a.Level = 1).Sum(Function(b) b.Cells(precioTotal.Index).Value)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    ''' <summary>
    ''' Calcula y devuelve la sumatoria de la instalación por artículo
    ''' </summary>
    ''' <returns></returns>
    Public Function TotalInstalacion() As Decimal
        TotalInstalacion = 0
        Try
            TotalInstalacion = dwItems.Rows.Cast(Of DatagridTreeView.DataGridViewTreeNode).AsParallel.Where(Function(a) a.Level = 1).Sum(Function(b) b.Cells(precioInstalacion.Index).Value)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Public Sub cargarParametrosIvaUtilidad()
        Try
            nudPorcAdministracion.Value = _listOfSelectedRows(0).Cells("AIU_Administracion").Value
            nudPorcImprovistos.Value = _listOfSelectedRows(0).Cells("AIU_Improvistos").Value
            nudPorcUtilidad.Value = _listOfSelectedRows(0).Cells("AIU_Utilidad").Value
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub calculoIvaPleno(valor_iva As Decimal)
        Try
            lbvaloriva.Text = (txtValcontratado.Value * valor_iva).ToString("c")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub calculoIvaUtilidad()
        Try

            lbAdministracion.Text = (txtValcontratado.Value * (nudPorcAdministracion.Value / 100)).ToString("c")
            lbImprovisto.Text = (txtValcontratado.Value * (nudPorcImprovistos.Value / 100)).ToString("c") '((((txtValcontratado.Value / (1 + (nudPorcImprovistos.Value / 100))) * (nudPorcImprovistos.Value / 100))).ToString("c"))
            lbUtilidad.Text = (txtValcontratado.Value * (nudPorcUtilidad.Value / 100)).ToString("c")
            lbvaloriva.Text = (lbUtilidad.Text * 0.16).ToString("c") '(((txtValcontratado.Value * (nudPorcUtilidad.Value / 100))) * (nudPorcUtilidad.Value / 100)) * 0.16).ToString("c")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub CalculoCuota()
        Try
            Dim Valorcuota As Decimal = 0
            Dim porcentajeEquivalente As Decimal = 0
            Dim val_suministro As Decimal = Convert.ToDecimal(txtValSuministro.Text.Replace("$", "").Replace(".", ""))
            Dim IVA As Decimal = Convert.ToDecimal(lbiva.Text) / 100
            Select Case CInt(cbtipoanticipo.ComboBox.SelectedValue)
                Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTRO
                    Valorcuota = (val_suministro * ((nudanticipo.Value / 100))) / nudcuotas.Value
                    porcentajeEquivalente = Valorcuota / val_suministro
                Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROINSTALACION
                    Valorcuota = ((txtValcontratado.Value) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                    porcentajeEquivalente = Valorcuota / txtValcontratado.Value
                Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROIVA
                    If rbsobreutilidad.Checked Then
                        Dim ivaU As Integer = ((val_suministro / (1 + (nudPorcUtilidad.Value / 100))) * (nudPorcUtilidad.Value / 100)) * IVA
                        Valorcuota = ((val_suministro + ivaU) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                        porcentajeEquivalente = Valorcuota / (val_suministro + ivaU)
                    Else
                        Valorcuota = ((val_suministro * (1 + IVA)) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                        porcentajeEquivalente = Valorcuota / val_suministro
                    End If
                Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROMASINSTALACIONMASIVA
                    If rbsobreutilidad.Checked Then
                        Dim ivaU As Integer = ((Convert.ToInt32(txtValcontratado.Value) / (1 + (nudPorcUtilidad.Value / 100))) * (nudPorcUtilidad.Value / 100)) * IVA
                        Valorcuota = ((Convert.ToInt32(txtValcontratado.Value) + ivaU) * ((nudanticipo.Value / 100))) / nudcuotas.Value
                        porcentajeEquivalente = Valorcuota / (Convert.ToInt32(txtValcontratado.Value) + ivaU)
                    Else
                        Valorcuota = ((Convert.ToInt32(txtValcontratado.Value) * (1 + IVA)) * (1 + (nudanticipo.Value / 100))) / nudcuotas.Value
                        porcentajeEquivalente = Valorcuota / (Convert.ToInt32(txtValcontratado.Value) * (1 + IVA))
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
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub rb_iva_click(sender As Object, e As EventArgs)
        Try
            If Not loadingForm Then Exit Sub
            Dim rdb As RadioButton = DirectCast(sender, RadioButton)
            If rdb.Checked Then
                calculoIvaPleno(Convert.ToDecimal(rdb.Tag))
                lbiva.Text = Convert.ToString(Convert.ToDecimal(rdb.Tag) * 100)
            Else
                calculoIvaUtilidad()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region

#Region "Procedimientos Controles"
    Private Sub frmContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lbiva.Text = My.Settings.IVA_Actual
            dtpfechaprimeracuota.Value = Now
            CargarControlesFormulario()
            CargarEstados()
            If Me.operacionActual = ClsEnums.TiOperacion.INSERTAR Then
                cmbestados.ComboBox.SelectedValue = ClsEnums.Estados.ACTIVO
                cmbestados.Enabled = False
                Dim tb As DataTable = Nothing
                Dim rw As DataRow = ctrlNit.TablaFuente.Rows.Cast(Of DataRow).FirstOrDefault(Function(x) x.Item(ctrlNit.ColToReturn).ToString().Trim() = _listOfSelectedRows(0).Cells("numIdentificacion").Value.ToString().Trim())
                If rw IsNot Nothing Then
                    ctrlNit.Text = rw.Item(ctrlNit.ColToReturn)
                    ctrlNit.selected_item = rw
                    TraerdesdeHistorico()
                End If
                _objHijoCotizas.traerByGroupCotiza(_expresionConsulta, tb)
                Dim tasas = tb.AsEnumerable().GroupBy(Function(x) x.Item("tasaImpuesto")).Select(Function(y) Convert.ToDecimal(y.First().Item("tasaImpuesto"))).ToList()
                For Each v In tasas
                    Dim rb As New RadioButton
                    rb.Tag = v / 100D
                    rb.Text = "IVA " & Convert.ToString(v) & "%"
                    lbiva.Text = v
                    AddHandler rb.CheckedChanged, AddressOf rb_iva_click
                    flptasas.Controls.Add(rb)
                Next
                seleccionarTiposObra()
                If tb Is Nothing Then
                    MsgBox("Las cotizaciones seleccionadas no tienen items disponibles")
                Else
                    cargarMovitoItems(tb, False)
                End If
                cargarTotales()
                If validarImpuestos() Then
                    MsgBox("Las cotizaciones seleccionadas tienen diferentes tipos de Impuestos" & vbLf & "o los porcentajes asignados al A.I.U no son diferentes en las cotizaciones, por favor verifique e intente nuevamente.", MsgBoxStyle.Information)
                    Me.DialogResult = DialogResult.Cancel
                    Me.Close()
                End If
                txtNumContrato.Text = "ALCO-" & lbCns.Text.PadLeft(4, "0")
            ElseIf Me.operacionActual = ClsEnums.TiOperacion.MODIFICAR Then
                dtInicial.Enabled = False
                dtFinal.Enabled = False
                ctrlNit.Enabled = False
                ctrCliente.Enabled = False
                ctrCodSucursal.Enabled = False
                ctrObra.Enabled = False
                cargarContratoParaModificacion()
            End If
            loadingForm = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnexpandir_Click(sender As Object, e As EventArgs) Handles btnexpandir.Click
        Try
            If dwItems.RowCount > 0 Then
                For Each nodo In dwItems.Nodes
                    nodo.Expand()
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontraer_Click(sender As Object, e As EventArgs) Handles btncontraer.Click
        Try
            If dwItems.RowCount > 0 Then
                For Each nodo In dwItems.Nodes
                    nodo.Collapse()
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnmostrarcolumnas_Click(sender As Object, e As EventArgs) Handles btnmostrarcolumnas.Click
        Try
            Dim selector As New ControlesPersonalizados.GridFiltrado.FrmVisibilidadColumnas
            selector.Grid2 = dwItems
            selector.Location = MousePosition
            selector.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub BwCalculoPrecios_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwCalculoPrecios.RunWorkerCompleted
        Try
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCalculo_Click(sender As Object, e As EventArgs) Handles btonCalculo.Click
        Try
            For Each r As DataGridViewRow In dwItemsAnticipos.Rows
                If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(idCuota.Index).Value)) Then
                    Dim ncobra As New clsAnticiposPorNota
                    If ncobra.TraerxIdMovitoAnticipo(Convert.ToInt32(r.Cells(idCuota.Index).Value)).Count > 0 Then
                        MsgBox("El plan de anticipo ya tiene movimientos. No se puede ejecutar la acción", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Next
            dwItemsAnticipos.Rows.Clear()
            If nudcuotas.Value > 0 And nudanticipo.Value > 0 Then
                CalculoCuota()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItemsAnticipos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItemsAnticipos.CellEndEdit
        Try
            Dim IVA As Decimal = Convert.ToDecimal(lbiva.Text) / 100
            If dwItemsAnticipos.Columns(e.ColumnIndex) Is _colValor Then
                Dim cval As Decimal = 0
                For i As Integer = 0 To e.RowIndex
                    cval += Convert.ToDecimal(dwItemsAnticipos.Item(_colValor.Index, i).Value)
                Next
                Dim vtotal As Decimal = 0
                Select Case CInt(cbtipoanticipo.ComboBox.SelectedValue)
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTRO
                        vtotal = CDec(txtValSuministro.Text) * (nudanticipo.Value / 100)
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROINSTALACION
                        vtotal = txtValcontratado.Value * (nudanticipo.Value / 100)
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROIVA
                        If rbsobreutilidad.Checked Then
                            Dim ivaU As Integer = ((CDec(txtValSuministro.Text) / (1 + (nudPorcUtilidad.Value / 100))) * (nudPorcUtilidad.Value / 100)) * IVA
                            vtotal = (CDec(txtValSuministro.Text) + ivaU) * (nudanticipo.Value / 100)
                        Else
                            vtotal = CDec(txtValSuministro.Text) * (1 + IVA) * (nudanticipo.Value / 100)
                        End If
                    Case Is = ClsEnums.TipoCalculoCuotas.SUMINISTROMASINSTALACIONMASIVA
                        If rbsobreutilidad.Checked Then
                            Dim ivaU As Integer = ((CInt(txtValcontratado.Value) / (1 + (nudPorcUtilidad.Value / 100))) * (nudPorcUtilidad.Value / 100)) * IVA
                            vtotal = (txtValcontratado.Value + ivaU) * (nudanticipo.Value / 100)
                        Else
                            vtotal = txtValcontratado.Value * (1 + IVA) * (nudanticipo.Value / 100)
                        End If
                End Select
                dwItemsAnticipos.Item(_colValor.Index, e.RowIndex).Value = Convert.ToDecimal(dwItemsAnticipos.Item(_colValor.Index, e.RowIndex).Value)
                dwItemsAnticipos.Item(_colPorcentaje.Index, e.RowIndex).Value = (Convert.ToDecimal(dwItemsAnticipos.Item(_colValor.Index, e.RowIndex).Value) / vtotal) * nudanticipo.Value
                For i As Integer = e.RowIndex + 1 To dwItemsAnticipos.Rows.Count - 1
                    dwItemsAnticipos.Item(_colValor.Index, i).Value = (vtotal - cval) / (dwItemsAnticipos.Rows.Count - 1 - e.RowIndex)
                    dwItemsAnticipos.Item(_colPorcentaje.Index, i).Value = (Convert.ToDecimal(dwItemsAnticipos.Item(_colValor.Index, i).Value) / vtotal) * nudanticipo.Value
                Next
            End If
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
    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnimpresora.Click
        Try
            editorMinutas.Imprimir()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub PdfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
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
    Private Sub cbescritura_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbescritura.SelectedValueChanged
        Try
            If DirectCast(Convert.ToInt32(cbescritura.SelectedValue), ClsEnums.Tipo_Escritura) = ClsEnums.Tipo_Escritura.PRIVADO Then
                txtnumEscritura.Text = String.Empty
                txtnumEscritura.Enabled = False
                txtnotaria.Text = String.Empty
                txtnotaria.Enabled = False
                txtciudadnotaria.Text = String.Empty
                txtciudadnotaria.Enabled = False
            Else
                txtnumEscritura.Enabled = True
                txtnotaria.Enabled = True
                txtciudadnotaria.Enabled = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItemsAnticipos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItemsAnticipos.CellBeginEdit
        Try
            If e.RowIndex = dwItemsAnticipos.Rows.Count - 1 Then
                e.Cancel = True
            End If
            If Not String.IsNullOrEmpty(Convert.ToString(dwItemsAnticipos.Item(idCuota.Index, e.RowIndex).Value)) Then
                Dim ncobra As New clsAnticiposPorNota
                If ncobra.TraerxIdMovitoAnticipo(Convert.ToInt32(dwItemsAnticipos.Item(idCuota.Index, e.RowIndex).Value)).Count > 0 Then
                    e.Cancel = True
                End If
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub EliminarItem()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            If Not String.IsNullOrEmpty(Convert.ToString(n.Cells(id.Index).Value)) Then
                Dim fotrosi As New FrmOtroSi
                fotrosi.IdContrato = _curId
                fotrosi.Valor = -Convert.ToDecimal(n.Cells(precioTotal.Index).Value)
                fotrosi.FechaFinal = dtFinal.Value
                If fotrosi.ShowDialog() = DialogResult.OK Then
                    _objMovitoItems.EliminarItem(Convert.ToInt32(n.Cells(id.Index).Value))
                    dwItems.Nodes.Remove(n)
                End If
            Else
                dwItems.Nodes.Remove(n)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseDown
        Try
            If e.RowIndex >= 0 Then
                Dim n As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
                Select Case e.Button
                    Case MouseButtons.Right
                        If n.Level = 1 Then
                            n.Selected = True
                            Dim menu As New ContextMenuStrip
                            menu.Items.Add("Eliminar Ítem", Nothing, AddressOf EliminarItem)
                            menu.Show(MousePosition)
                        End If
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontratar_Click(sender As Object, e As EventArgs) Handles btncombinar.Click
        Try
            If _curId > 0 Then
                Dim ds As New DataSet()
                ds.Tables.Add(_objContrato.traerByIdTabla(_curId))
                ds.Tables.Add(_objMovitoItems.TraerValoresMinuta(_curId))
                ds.Tables.Add(_objMinuta.TraerValoresMinuta(_curId))
                ds.Tables.Add(_objPolizaContrato.TraerValoresMinuta(_curId))
                editorMinutas.TablasValoresVariables = ds
            Else
                MsgBox("Debe guardar el contrato antes de combinar los valores.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItemsPoliza_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItemsPoliza.CellEndEdit
        Try
            If e.RowIndex > -1 Then
                If Not Convert.ToBoolean(dwItemsPoliza.Item(selected0.Index, e.RowIndex).Value) Then
                    dwItemsPoliza.Item(PorcentajeDefecto0.Index, e.RowIndex).Value = 0.00
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItemsPoliza_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItemsPoliza.CellBeginEdit
        Try
            If e.RowIndex > -1 Then
                If e.ColumnIndex = PorcentajeDefecto0.Index Then
                    If Not Convert.ToBoolean(dwItemsPoliza.Item(selected0.Index, e.RowIndex).Value) Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btndescombinar_Click(sender As Object, e As EventArgs) Handles btndescombinar.Click
        Try
            If editorMinutas.Combinado Then
                editorMinutas.Descombinar()
            Else
                MsgBox("No se ha combinado el documento, por esta razón no se puede combinar.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btntablartf_Click(sender As Object, e As EventArgs) Handles btntablartf.Click
        Try
            Dim c As New ControlesPersonalizados.Editor_RTF.DocumentoRTF
            Dim movs = _objMovitoItems.TraerpaOrdenPedByIdContrato(_curId)
            Dim arr(dwItems.Nodes.Count + 5, 7) As Object
            arr(0, 0) = "REF"
            arr(0, 1) = "DISEÑO EXT" 'dwItems.Nodes(i).Cells(Descripcion.Index).Value
            arr(0, 2) = "VIDRIO"
            arr(0, 3) = "ANCHO"
            arr(0, 4) = "ALTO"
            arr(0, 5) = "CANTIDAD"
            arr(0, 6) = "VR. UNITARIO"
            arr(0, 7) = "VR. TOTAL"
            Dim totaln As Decimal = 0
            Dim descuento As Decimal = 10
            For i = 0 To dwItems.Nodes.Count - 1
                arr(i + 1, 0) = Trim(dwItems.Nodes(i).Cells(Ubicacion.Index).Value)
                arr(i + 1, 1) = ""
                arr(i + 1, 2) = Trim(dwItems.Nodes(i).Cells(vidrio.Index).Value)
                arr(i + 1, 3) = dwItems.Nodes(i).Cells(ancho.Index).Value
                arr(i + 1, 4) = dwItems.Nodes(i).Cells(Alto.Index).Value
                arr(i + 1, 5) = dwItems.Nodes(i).Cells(Cantidad.Index).Value
                arr(i + 1, 6) = Math.Round(Convert.ToDecimal(dwItems.Nodes(i).Cells(precioUnitario.Index).Value), 0).ToString("C")
                arr(i + 1, 7) = Math.Round(Convert.ToDecimal(dwItems.Nodes(i).Cells(precioTotal.Index).Value), 0).ToString("C")
                totaln += Convert.ToDecimal(dwItems.Nodes(i).Cells(precioUnitario.Index).Value)
            Next
            arr(dwItems.Nodes.Count + 1, 6) = "SUBTOTAL"
            arr(dwItems.Nodes.Count + 1, 7) = Math.Round(totaln, 0).ToString("C")
            Dim m_descuento As Decimal = totaln * (descuento / 100)
            arr(dwItems.Nodes.Count + 2, 6) = "DESCUENTO  " & descuento & "%"
            arr(dwItems.Nodes.Count + 2, 7) = Math.Round(m_descuento, 0).ToString("C")
            arr(dwItems.Nodes.Count + 3, 6) = "SUBTOTAL"
            arr(dwItems.Nodes.Count + 3, 7) = Math.Round(totaln - m_descuento, 0).ToString("C")
            Dim m_iva As Decimal = (totaln - m_descuento) * (Convert.ToDecimal(lbiva.Text) / 100)
            arr(dwItems.Nodes.Count + 4, 6) = "IVA"
            arr(dwItems.Nodes.Count + 4, 7) = Math.Round(m_iva, 0).ToString("C")
            arr(dwItems.Nodes.Count + 5, 6) = "TOTAL"
            arr(dwItems.Nodes.Count + 5, 7) = Math.Round(totaln - m_descuento + m_iva, 0).ToString("C")
            Clipboard.SetText(c.Tabla(arr, 700, True), TextDataFormat.Rtf)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

End Class