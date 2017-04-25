Imports ReglasNegocio
Imports ReglasNegocio.Ciudades
Imports ReglasNegocio.Contratos

Public Class frmPedido
#Region "Variables"
    Private _pedidoFacturable As Boolean
    Private loadCompleted As Boolean = False
    Private updatingIntellisens As Boolean = False
    Private mObra As clsObrasUnoee
    Private mContrato As clsContratos
    Private Backorder As Dictionary(Of String, String)
    Private objObra As obrasUnoee

    Private listContrato As New List(Of contrato)
    Private idCiudad As Integer
    Private listBarrios As List(Of barrio)

    Private selectedColumn As DataGridViewColumn
#End Region
#Region "Propiedades"
    Public Property PedidoFacturable() As Boolean
        Get
            Return _pedidoFacturable
        End Get
        Set(ByVal value As Boolean)
            _pedidoFacturable = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarCentrosOperaciones()
        Try
            Dim mCentroOp As New ClsCentroOperaciones
            Dim listCentrosOp As List(Of centroOperacion) = mCentroOp.traerTodos()
            cmbCentroOperaciones.DisplayMember = "Id"
            cmbCentroOperaciones.ValueMember = "IdCia"
            cmbCentroOperaciones.DatosVisibles = {"Id", "Descripcion"}
            cmbCentroOperaciones.DataSource = listCentrosOp.Where(Function(a) a.IdCia = 1 And a.Id = "001").ToList
            cmbCentroOperaciones.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTipoDocumento()
        Try
            Dim mTipoDoc As New ClsTipoDctoPedido
            Dim listTiposDoc As List(Of tipoDcto) = mTipoDoc.traerTodos()
            cmbTipoDocto.DisplayMember = "Id"
            cmbTipoDocto.ValueMember = "Id"
            cmbTipoDocto.DatosVisibles = {"Id", "Descripcion"}
            If _pedidoFacturable = True Then
                cmbTipoDocto.DataSource = listTiposDoc.Where(Function(a) a.Id = "PED" Or a.Id = "PEV" Or
                                                             a.Id = "REP" Or a.Id = "RFB").ToList
            Else
                cmbTipoDocto.DataSource = listTiposDoc.Where(Function(a) a.Id = "PRP" Or a.Id = "RNB" Or a.Id = "RPN").ToList
            End If

            cmbTipoDocto.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEstado()
        Try
            Dim mEstado As New ClsEstados
            Dim estado As Estado = mEstado.TraerxId(ClsEnums.Estados.EN_ELABORACION)
            txtEstado.Text = estado.Descripcion
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarClientes()
        Try
            Dim mCliente As New clsClientesUnoee
            mCliente.t200_selectAllClientesUnoee(itNitFacturar.TablaFuente)
            itClienteFacturar.TablaFuente = itNitFacturar.TablaFuente

            mCliente.t200_selectAllClientesUnoee(itNitDesp.TablaFuente)
            itClienteDesp.TablaFuente = itNitDesp.TablaFuente
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMonedas()
        Try
            Dim mMoneda As New ClsMonedas
            Dim listMonedas As List(Of moneda) = mMoneda.traerTodos()
            cmbMoneda.DisplayMember = "Id"
            cmbMoneda.ValueMember = "Id"
            cmbMoneda.DataSource = listMonedas
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCentrosCostos()
        Try
            Dim mCentroCosto As New ClsCentroCostos
            Dim listCenCostos As List(Of centroCostos) = mCentroCosto.TraerTodos()
            cmbCentroCostos.DisplayMember = "Id"
            cmbCentroCostos.ValueMember = "Id"
            cmbCentroCostos.DatosVisibles = {"Id", "Descripcion"}
            cmbCentroCostos.DataSource = listCenCostos
            cmbCentroCostos.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarUnidadNegocio()
        Try
            Dim mUnidadNegocio As New ClsUnidadesNegocio
            Dim listUnidadesNegocio As List(Of unidadNegocio) = mUnidadNegocio.TraerTodos()
            cmbUnidadNegocio.DisplayMember = "Id"
            cmbUnidadNegocio.ValueMember = "Id"
            cmbUnidadNegocio.DatosVisibles = {"Id", "Descripcion"}
            cmbUnidadNegocio.DataSource = listUnidadesNegocio
            cmbUnidadNegocio.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarListasPrecios()
        Try
            Dim mListaPrecio As New ClsListaPrecios
            Dim listPrecios As List(Of lisPrecios) = mListaPrecio.traerTodos()
            cmbListaPrecios.DisplayMember = "Id"
            cmbListaPrecios.ValueMember = "Id"
            cmbListaPrecios.DatosVisibles = {"Id", "Descripcion"}
            cmbListaPrecios.DataSource = listPrecios

            cmbListaPrecios.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCondicionesPago()
        Try
            Dim mCondPago As New ClsCondicionesPago
            Dim listCondPago As List(Of condicionPago) = mCondPago.TraerTodos()
            cmbCondicionPago.DisplayMember = "Id"
            cmbCondicionPago.ValueMember = "Id"
            cmbCondicionPago.DatosVisibles = {"Id", "Descripcion"}
            cmbCondicionPago.DataSource = listCondPago
            cmbCondicionPago.Text = String.Empty
            cmbCondicionPago.SelectedValue = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub llenarBackorder()
        Try
            Backorder = New Dictionary(Of String, String)
            Backorder.Add("0", "Despachar Sólo lo disponible y lo demás pendiente")
            Backorder.Add("1", "Despachar Sólo lo disponible y lo demás cancela")
            Backorder.Add("2", "Despachar Sólo líneas completas y demás pendiente")
            Backorder.Add("3", "Despachar Líneas completas y lo demás cancela")
            Backorder.Add("4", "Despachar sólo pedido completo")
            Backorder.Add("5", "Por Línea")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarBackorder()
        Try
            llenarBackorder()
            cmbBackorder.DisplayMember = "Value"
            cmbBackorder.ValueMember = "Key"
            cmbBackorder.DatosVisibles = {"Value", "Key"}
            cmbBackorder.DataSource = Backorder.ToArray
            cmbBackorder.Text = String.Empty
            cmbBackorder.SelectedValue = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVendedores()
        Try
            Dim mVendedor As New ClsVendedoresSiesa
            Dim listVendedores As List(Of vendedor) = mVendedor.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbVendedores.DisplayMember = "Nombre"
            cmbVendedores.ValueMember = "idSiesa"
            cmbVendedores.DatosVisibles = {"idSiesa", "Nombre"}
            cmbVendedores.DataSource = listVendedores
            cmbVendedores.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarBarrios()
        Try
            Dim mBarrio As New ClsBarrios
            listBarrios = mBarrio.traerTodos(txtIdSiesaPais.Text, txtIdSiesaDepto.Text, txtIdSiesaCiudad.Text)

            cmbBarrios.DisplayMember = "NombreBarrio"
            cmbBarrios.ValueMember = "IdBarrio"
            cmbBarrios.DataSource = listBarrios
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarInformacionObra()
        Try
            mObra = New clsObrasUnoee
            mContrato = New clsContratos

            If itNitFacturar.Text = String.Empty Or itClienteFacturar.Text = String.Empty Or
                itCodSucursalFacturar.Text = String.Empty Or itObraFacturar.Text = String.Empty Then
                Return
            End If

            If itNitFacturar.Seleted_rowid <> Nothing Then
                If itCodSucursalFacturar.Seleted_rowid <> Nothing Then
                    objObra = mObra.traerObraByIdClienteAndIdObra(itNitFacturar.Seleted_rowid, itCodSucursalFacturar.Seleted_rowid)
                    listContrato = mContrato.traerByNitAndIdObra(itNitFacturar.Seleted_rowid, itCodSucursalFacturar.Seleted_rowid)
                Else
                    objObra = mObra.traerObraByIdClienteAndIdObra(itNitFacturar.Seleted_rowid, itObraFacturar.Seleted_rowid)
                    listContrato = mContrato.traerByNitAndIdObra(itNitFacturar.Seleted_rowid, itObraFacturar.Seleted_rowid)
                End If
            Else
                If itCodSucursalFacturar.Seleted_rowid <> Nothing Then
                    objObra = mObra.traerObraByIdClienteAndIdObra(itClienteFacturar.Seleted_rowid, itCodSucursalFacturar.Seleted_rowid)
                    listContrato = mContrato.traerByNitAndIdObra(itClienteFacturar.Seleted_rowid, itCodSucursalFacturar.Seleted_rowid)
                Else
                    objObra = mObra.traerObraByIdClienteAndIdObra(itClienteFacturar.Seleted_rowid, itObraFacturar.Seleted_rowid)
                    listContrato = mContrato.traerByNitAndIdObra(itClienteFacturar.Seleted_rowid, itObraFacturar.Seleted_rowid)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub IntellisensesDespachos()
        Try
            itNitDesp.Text = itNitFacturar.Text
            itNitDesp.Seleted_rowid = itNitFacturar.Seleted_rowid
            itNitDesp.Value2 = itNitFacturar.Value2

            itClienteDesp.Text = itClienteFacturar.Text
            itClienteDesp.Seleted_rowid = itClienteFacturar.Seleted_rowid
            itClienteDesp.Value2 = itClienteFacturar.Value2

            itCodSucursalDesp.Text = itCodSucursalFacturar.Text
            itCodSucursalDesp.Seleted_rowid = itCodSucursalFacturar.Seleted_rowid
            itCodSucursalDesp.Value2 = itCodSucursalFacturar.Value2

            itObraDesp.Text = itObraFacturar.Text
            itObraDesp.Seleted_rowid = itObraFacturar.Seleted_rowid
            itObraDesp.Value2 = itObraFacturar.Value2

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInfoGeneral()
        Try
            IntellisensesDespachos()
            Dim mClienteDetalle As New ClsClienteDetalle
            Dim objCliente As clienteDetalleUnoee
            If itNitFacturar.Seleted_rowid <> Nothing Then
                objCliente = mClienteDetalle.TraerDetalleCliente(itNitFacturar.Seleted_rowid, itCodSucursalFacturar.Text)
            ElseIf itClienteFacturar.Seleted_rowid <> String.Empty Then
                objCliente = mClienteDetalle.TraerDetalleCliente(itClienteFacturar.Seleted_rowid, itCodSucursalFacturar.Text)
            Else
                Return
            End If

            limpiarEncabezado()
            limpiarInfoGeneral()

            If objCliente.IdCliente = 0 Then
                Return
            End If

            txtTiposClientes.Text = objCliente.TipoCliente
            cmbBackorder.SelectedValue = Convert.ToString(objCliente.IdBackorder)
            cmbMoneda.SelectedValue = objCliente.IdMoneda
            cmbListaPrecios.SelectedValue = objCliente.IdListaPrecio
            cmbCondicionPago.SelectedValue = objCliente.IdCondicionPago
            cmbVendedores.SelectedValue = objCliente.IdVendedorSiesa
            txtIdContacto.Text = objCliente.IdContacto
            txtContacto.Text = objCliente.NombreContacto
            txtDireccion1.Text = objCliente.Direccion1
            txtDireccion2.Text = objCliente.Direccion2
            txtDireccion3.Text = objCliente.Direccion3
            txtTelefono.Text = objCliente.Telefono
            txtFax.Text = objCliente.Fax
            txtCorreo.Text = objCliente.Correo
            txtIdSiesaPais.Text = objCliente.IdPais
            txtIdSiesaDepto.Text = objCliente.IdDepartamento
            txtIdSiesaCiudad.Text = objCliente.IdCiudad
            txtCiudad.Text = objCliente.Ciudad
            cargarBarrios()
            cmbBarrios.SelectedValue = objCliente.IdBarrio
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub limpiarInfoFacturacion()
        Try
            itNitFacturar.Text = String.Empty
            itNitFacturar.Seleted_rowid = Nothing
            itClienteFacturar.Text = String.Empty
            itClienteFacturar.Seleted_rowid = Nothing
            itCodSucursalFacturar.Text = String.Empty
            itCodSucursalFacturar.Seleted_rowid = Nothing
            itObraFacturar.Text = String.Empty
            itObraFacturar.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiarInfoDespacho()
        Try
            itNitDesp.Text = String.Empty
            itNitDesp.Seleted_rowid = Nothing
            itClienteDesp.Text = String.Empty
            itClienteDesp.Seleted_rowid = Nothing
            itCodSucursalDesp.Text = String.Empty
            itCodSucursalDesp.Seleted_rowid = Nothing
            itObraDesp.Text = String.Empty
            itObraDesp.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiarEncabezado()
        Try
            dtpFechaEntrega.Value = DateTime.Now
            txtDiasEntrega.Text = String.Empty
            cmbCentroCostos.SelectedValue = "520100"
            cmbUnidadNegocio.SelectedValue = "01"
            txtOrdenCompra.Text = String.Empty
            cmbListaPrecios.SelectedValue = "C01"
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiarInfoGeneral()
        Try
            For Each ctrl As Control In gbGenerales.Controls
                If TypeOf (ctrl) Is ComboBox Then
                    DirectCast(ctrl, ComboBox).Text = String.Empty
                    DirectCast(ctrl, ComboBox).SelectedValue = String.Empty
                    If ctrl Is cmbVendedores Then
                        cmbVendedores.SelectedValue = "ALCO"
                    End If
                ElseIf TypeOf (ctrl) Is TextBox Then
                    DirectCast(ctrl, TextBox).Text = String.Empty
                End If
            Next

            For Each ctrl As Control In gbPuntoEnvio.Controls
                If TypeOf (ctrl) Is ComboBox Then
                    DirectCast(ctrl, ComboBox).Text = String.Empty
                    DirectCast(ctrl, ComboBox).SelectedValue = String.Empty
                ElseIf TypeOf (ctrl) Is TextBox Then
                    DirectCast(ctrl, TextBox).Text = String.Empty
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiarListaItems()
        Try
            dwVidrio.Rows.Clear()
            dwVidrioTemplado.Rows.Clear()
            dwAccesorios.Rows.Clear()
            dwPerfiles.Rows.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub habilitarCamposFacturacion(habilitar As Boolean)
        Try
            If habilitar Then
                btnBuscarClientesFact.Enabled = True
                itNitFacturar.Enabled = True
                itClienteFacturar.Enabled = True
                btnBuscarSucursalFact.Enabled = True
                itCodSucursalFacturar.Enabled = True
                itObraFacturar.Enabled = True
            Else
                btnBuscarClientesFact.Enabled = False
                itNitFacturar.Enabled = False
                itClienteFacturar.Enabled = False
                btnBuscarSucursalFact.Enabled = False
                itCodSucursalFacturar.Enabled = False
                itObraFacturar.Enabled = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub habliltarCamposDespachos(hablilitar As Boolean)
        Try
            If hablilitar Then
                btnBuscarClientesDesp.Enabled = True
                itNitDesp.Enabled = True
                itClienteDesp.Enabled = True
                btnBuscarSucursalDesp.Enabled = True
                itCodSucursalDesp.Enabled = True
                itObraDesp.Enabled = True
            Else
                btnBuscarClientesDesp.Enabled = False
                itNitDesp.Enabled = False
                itClienteDesp.Enabled = False
                btnBuscarSucursalDesp.Enabled = False
                itCodSucursalDesp.Enabled = False
                itObraDesp.Enabled = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Configuración Intellisenses"
#Region "FACTURACIÓN"
    Private Sub btnBuscarClientesFact_Click(sender As Object, e As EventArgs) Handles btnBuscarClientesFact.Click
        Try
            Dim frmBusqueda As New FrmBusqueda
            frmBusqueda.BuscoCliente = True
            If frmBusqueda.ShowDialog() = DialogResult.OK Then
                itNitFacturar.Text = frmBusqueda.NitSelected
                itNitFacturar.Seleted_rowid = frmBusqueda.Cliente.idCliente
                itClienteFacturar.Text = frmBusqueda.ClienteSelected
                itClienteFacturar.Seleted_rowid = frmBusqueda.Cliente.idCliente
                mObra = New clsObrasUnoee
                If Not itNitFacturar.Seleted_rowid Is Nothing Then
                    mObra.traerObrasByID(itNitFacturar.Seleted_rowid, itCodSucursalFacturar.TablaFuente)
                    itObraFacturar.TablaFuente = itCodSucursalFacturar.TablaFuente
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Comportamiento Nit"
    Private Sub itNitFacturar_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itNitFacturar.selected_value_changed
        Try
            itClienteFacturar.Text = e.ValorSecundario
            itClienteFacturar.Value2 = e.ValorPrimario
            itClienteFacturar.Seleted_rowid = e.Id
            mObra = New clsObrasUnoee
            If Not itNitFacturar.Seleted_rowid Is Nothing Then
                mObra.traerObrasByID(e.Id, itCodSucursalFacturar.TablaFuente)
                itObraFacturar.TablaFuente = itCodSucursalFacturar.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itNitFacturar_KeyUp(sender As Object, e As KeyEventArgs) Handles itNitFacturar.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itNitFacturar.Seleted_rowid = Nothing
                itClienteFacturar.Text = String.Empty
                itClienteFacturar.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itNitFacturar_TextChange(sender As Object, e As EventArgs) Handles itNitFacturar.TextChanged
        Try
            If itCodSucursalFacturar.Seleted_rowid IsNot Nothing Or itObraFacturar.Seleted_rowid IsNot Nothing Then
                itCodSucursalFacturar.Text = String.Empty
                itCodSucursalFacturar.Seleted_rowid = Nothing
                itObraFacturar.Text = String.Empty
                itObraFacturar.Seleted_rowid = Nothing
                limpiarInfoDespacho()
                limpiarEncabezado()
                limpiarInfoGeneral()
                limpiarListaItems()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Comportamiento Cliente"
    Private Sub itClienteFacturar_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itClienteFacturar.selected_value_changed
        Try
            itNitFacturar.Text = e.ValorSecundario
            itNitFacturar.Value2 = e.ValorPrimario
            itNitFacturar.Seleted_rowid = e.Id
            mObra = New clsObrasUnoee
            If Not String.IsNullOrEmpty(e.Id) Then
                mObra.traerObrasByID(e.Id, itCodSucursalFacturar.TablaFuente)
                itObraFacturar.TablaFuente = itCodSucursalFacturar.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itClienteFacturar_KeyUp(sender As Object, e As KeyEventArgs) Handles itClienteFacturar.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itClienteFacturar.Seleted_rowid = Nothing
                itNitFacturar.Text = String.Empty
                itNitFacturar.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itClienteFacturar_TextChanged(sender As Object, e As EventArgs) Handles itClienteFacturar.TextChanged
        Try
            If itCodSucursalFacturar.Seleted_rowid IsNot Nothing Or itObraFacturar.Seleted_rowid IsNot Nothing Then
                itCodSucursalFacturar.Text = String.Empty
                itCodSucursalFacturar.Seleted_rowid = Nothing
                itObraFacturar.Text = String.Empty
                itObraFacturar.Seleted_rowid = Nothing
                limpiarInfoDespacho()
                limpiarEncabezado()
                limpiarInfoGeneral()
                limpiarListaItems()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub btnBuscarSucursalFact_Click(sender As Object, e As EventArgs) Handles btnBuscarSucursalFact.Click
        Try
            If itNitFacturar.Seleted_rowid = Nothing Then
                MessageBox.Show("Indique el cliente antes de buscar la sucursal", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim frmBusqueda As New FrmBusqueda
            frmBusqueda.IdCliente = itNitFacturar.Seleted_rowid
            If frmBusqueda.ShowDialog() = DialogResult.OK Then
                itCodSucursalFacturar.Text = frmBusqueda.CodObraSelected
                itCodSucursalFacturar.Seleted_rowid = frmBusqueda.Obra.idObra
                itObraFacturar.Text = frmBusqueda.ObraSelected
                itObraFacturar.Seleted_rowid = frmBusqueda.Obra.idObra
                habliltarCamposDespachos(True)
                cargarInformacionObra()
                cargarInfoGeneral()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Comportamiento Código Obra"
    Private Sub itCodSucursalFacturar_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itCodSucursalFacturar.selected_value_changed
        Try
            itObraFacturar.Text = e.ValorSecundario
            itObraFacturar.Value2 = e.ValorPrimario
            habliltarCamposDespachos(True)
            cargarInformacionObra()
            cargarInfoGeneral()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCodSucursalFacturar_KeyUp(sender As Object, e As KeyEventArgs) Handles itCodSucursalFacturar.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itCodSucursalFacturar.Seleted_rowid = Nothing
                itObraFacturar.Text = String.Empty
                itObraFacturar.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Comportamiento Obra"
    Private Sub itObraFacturar_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itObraFacturar.selected_value_changed
        Try
            itCodSucursalFacturar.Text = e.ValorSecundario
            itCodSucursalFacturar.Value2 = e.ValorPrimario
            habliltarCamposDespachos(True)
            cargarInformacionObra()
            cargarInfoGeneral()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itObraFacturar_KeyUp(sender As Object, e As KeyEventArgs) Handles itObraFacturar.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itObraFacturar.Seleted_rowid = Nothing
                itCodSucursalFacturar.Text = String.Empty
                itCodSucursalFacturar.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#Region "DESPACHOS"
    Private Sub btnBuscarClientesDesp_Click(sender As Object, e As EventArgs) Handles btnBuscarClientesDesp.Click
        Try
            Dim frmBusqueda As New FrmBusqueda
            frmBusqueda.BuscoCliente = True
            If frmBusqueda.ShowDialog() = DialogResult.OK Then
                itNitDesp.Text = frmBusqueda.NitSelected
                itNitDesp.Seleted_rowid = frmBusqueda.Cliente.idCliente
                itClienteDesp.Text = frmBusqueda.ClienteSelected
                itClienteDesp.Seleted_rowid = frmBusqueda.Cliente.idCliente
                mObra = New clsObrasUnoee
                If Not itNitDesp.Seleted_rowid Is Nothing Then
                    mObra.traerObrasByID(itNitDesp.Seleted_rowid, itCodSucursalDesp.TablaFuente)
                    itObraDesp.TablaFuente = itCodSucursalDesp.TablaFuente
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Comportamiento Nit"
    Private Sub itNitDesp_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itNitDesp.selected_value_changed
        Try
            itClienteDesp.Text = e.ValorSecundario
            itClienteDesp.Value2 = e.ValorPrimario
            mObra = New clsObrasUnoee
            If Not itNitDesp.Seleted_rowid Is Nothing Then
                mObra.traerObrasByID(e.Id, itCodSucursalDesp.TablaFuente)
                itObraDesp.TablaFuente = itCodSucursalDesp.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itNitDesp_KeyUp(sender As Object, e As EventArgs) Handles itNitDesp.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itNitDesp.Seleted_rowid = Nothing
                itClienteDesp.Text = String.Empty
                itClienteDesp.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itNitDesp_TextChanged(sender As Object, e As EventArgs) Handles itNitDesp.TextChanged
        Try
            itCodSucursalDesp.Text = String.Empty
            itCodSucursalDesp.Seleted_rowid = Nothing
            itObraDesp.Text = String.Empty
            itObraDesp.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Comportamiento Cliente"
    Private Sub itClienteDesp_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itClienteDesp.selected_value_changed
        Try
            itNitDesp.Text = e.ValorSecundario
            itNitDesp.Value2 = e.ValorPrimario
            mObra = New clsObrasUnoee
            If Not String.IsNullOrEmpty(e.Id) Then
                mObra.traerObrasByID(e.Id, itCodSucursalDesp.TablaFuente)
                itObraDesp.TablaFuente = itCodSucursalDesp.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itClienteDesp_KeyUp(sender As Object, e As EventArgs) Handles itClienteDesp.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itClienteDesp.Seleted_rowid = Nothing
                itNitDesp.Text = String.Empty
                itNitDesp.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itClienteDesp_TextChanged(sender As Object, e As EventArgs) Handles itClienteDesp.TextChanged
        Try
            itCodSucursalDesp.Text = String.Empty
            itCodSucursalDesp.Seleted_rowid = Nothing
            itObraDesp.Text = String.Empty
            itObraDesp.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub btnBuscarSucursalDesp_Click(sender As Object, e As EventArgs) Handles btnBuscarSucursalDesp.Click
        Try
            If itNitDesp.Seleted_rowid = Nothing Then
                MessageBox.Show("Indique el cliente antes de buscar la sucursal", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim frmBusqueda As New FrmBusqueda
            frmBusqueda.IdCliente = itNitDesp.Seleted_rowid
            If frmBusqueda.ShowDialog() = DialogResult.OK Then
                itCodSucursalDesp.Text = frmBusqueda.CodObraSelected
                itCodSucursalDesp.Seleted_rowid = frmBusqueda.Obra.idObra
                itObraDesp.Text = frmBusqueda.ObraSelected
                itObraDesp.Seleted_rowid = frmBusqueda.Obra.idObra
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Comportamiento Código Obra"
    Private Sub itCodSucursalDesp_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itCodSucursalDesp.selected_value_changed
        Try
            itObraDesp.Text = e.ValorSecundario
            itObraDesp.Value2 = e.ValorPrimario
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCodSucursalDesp_KeyUp(sender As Object, e As EventArgs) Handles itCodSucursalDesp.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itCodSucursalDesp.Seleted_rowid = Nothing
                itObraDesp.Text = String.Empty
                itObraDesp.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Comportamiento Obra"
    Private Sub itObraDesp_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itObraDesp.selected_value_changed
        Try
            If Not String.IsNullOrEmpty(e.ValorSecundario) Then
                itCodSucursalDesp.Text = e.ValorSecundario
                itCodSucursalDesp.Value2 = e.ValorPrimario
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itObraDesp_KeyUp(sender As Object, e As EventArgs) Handles itObraDesp.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itObraDesp.Seleted_rowid = Nothing
                itCodSucursalDesp.Text = String.Empty
                itCodSucursalDesp.Seleted_rowid = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
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
            'AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
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
            'RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub frmPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarCentrosOperaciones()
            cargarTipoDocumento()
            cargarEstado()
            cargarClientes()
            cargarMonedas()
            cargarCentrosCostos()
            cargarUnidadNegocio()
            cargarListasPrecios()
            cargarCondicionesPago()
            cargarBackorder()
            cargarVendedores()
            cargarDesplegables()

            habilitarCamposFacturacion(False)
            habliltarCamposDespachos(False)
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbTipoDocto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoDocto.SelectedValueChanged
        Try
            If loadCompleted Then
                Dim mTipoDocto As New ClsTipoDctoPedido
                txtConsecutivo.Text = mTipoDocto.TraerConsecutivo(cmbTipoDocto.SelectedValue)
                If cmbTipoDocto.Text <> String.Empty Then
                    habilitarCamposFacturacion(True)
                    habliltarCamposDespachos(False)
                    limpiarInfoFacturacion()
                    limpiarInfoDespacho()
                    limpiarEncabezado()
                    limpiarInfoGeneral()
                    limpiarListaItems()
                Else
                    habilitarCamposFacturacion(False)
                    habliltarCamposDespachos(False)
                    limpiarInfoFacturacion()
                    limpiarInfoDespacho()
                    limpiarEncabezado()
                    limpiarInfoGeneral()
                    limpiarListaItems()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub txtDiasEntrega_TextChanged(sender As Object, e As EventArgs) Handles txtDiasEntrega.TextChanged
        Try
            If txtDiasEntrega.Text <> String.Empty Then

                dtpFechaEntrega.Value = DateTime.Now.AddDays(Val(txtDiasEntrega.Text))
            Else
                dtpFechaEntrega.Value = DateTime.Now
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub dtpFechaEntrega_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntrega.ValueChanged
        Try
            Dim diferencia As Integer = (dtpFechaEntrega.Value - DateTime.Now).TotalDays
            txtDiasEntrega.Text = diferencia
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub txtSoloNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasEntrega.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#Region "Tab general"
    Private Sub btnBuscarCiudad_Click(sender As Object, e As EventArgs) Handles btnBuscarCiudad.Click
        Try
            Dim frmCiudad As New FrmSeleccionCiudades
            If frmCiudad.ShowDialog() = DialogResult.OK Then
                txtPais.Text = frmCiudad.Pais.descripcion
                txtDepto.Text = frmCiudad.Departamento.descripcion
                txtCiudad.Text = frmCiudad.Ciudad.nombreCiudad
                idCiudad = frmCiudad.Ciudad.Id
                txtIdSiesaPais.Text = frmCiudad.Pais.idSiesa
                txtIdSiesaDepto.Text = frmCiudad.Departamento.idSiesa
                txtIdSiesaCiudad.Text = frmCiudad.Ciudad.idSiesa
                cargarBarrios()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbBarrios_Leave(sender As Object, e As EventArgs) Handles cmbBarrios.Leave
        Try
            Dim txt As String = cmbBarrios.Text
            cmbBarrios.Text = String.Empty
            cmbBarrios.Text = txt.ToUpper()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnBuscarVendedores_Click(sender As Object, e As EventArgs) Handles btnBuscarVendedores.Click
        Try
            Dim mVendedor As New ClsVendedoresSiesa
            Dim tabla As DataTable = Nothing
            Dim listVendedores As List(Of vendedor) = mVendedor.TraerxEstado(ClsEnums.Estados.ACTIVO, tabla)

            Dim busc As New FrmBuscador()
            busc.Tabla = tabla
            busc.ColumnasVisibles = New List(Of String) From {"IdSiesa", "Nombre"}
            busc.ColumnasResultados = New List(Of String) From {"IdSiesa"}
            busc.StartPosition = FormStartPosition.CenterScreen
            If busc.ShowDialog() = DialogResult.OK Then
                cmbVendedores.SelectedValue = busc.Resultados("IdSiesa")
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbCondicionPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCondicionPago.SelectedValueChanged
        Try
            If cmbCondicionPago.SelectedValue IsNot Nothing Then
                Dim mCondPago As New ClsCondicionesPago
                Dim objCondPago As condicionPago = mCondPago.TraerxId(cmbCondicionPago.SelectedValue)
                txtDiasCondPago.Text = 30
                txtDiasPago.Text = objCondPago.Descripcion
                Return
            End If
            txtDiasCondPago.Text = String.Empty
            txtDiasPago.Text = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Tab Adición Items"
#Region "Procedimientos"
    Private Sub cargarDesplegables()
        Try
            Dim mEspesor As New ClsEspesores
            Dim listEspesores As List(Of Espesor) = mEspesor.TraerxEstado(ClsEnums.Estados.ACTIVO)
            DirectCast(dwVidrioTemplado.Columns(vtemp_espesor.Index), DataGridViewComboBoxColumn).DisplayMember = "Prefijo"
            DirectCast(dwVidrioTemplado.Columns(vtemp_espesor.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwVidrioTemplado.Columns(vtemp_espesor.Index), DataGridViewComboBoxColumn).DataSource = listEspesores

            Dim ListXuO = New Dictionary(Of Integer, String)
            ListXuO.Add(1, "X")
            ListXuO.Add(2, "O")
            DirectCast(dwVidrioTemplado.Columns(vtemp_XuO.Index), DataGridViewComboBoxColumn).DisplayMember = "Value"
            DirectCast(dwVidrioTemplado.Columns(vtemp_XuO.Index), DataGridViewComboBoxColumn).ValueMember = "Key"
            DirectCast(dwVidrioTemplado.Columns(vtemp_XuO.Index), DataGridViewComboBoxColumn).DataSource = ListXuO.ToArray
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function CalcularMtCuadrados(ancho As Decimal, alto As Decimal, cantidad As Decimal) As Decimal
        Try
            If ancho = 0 And alto = 0 And cantidad = 0 Then
                Return 0
            End If
            Return ((ancho * alto) / 1000000) * cantidad
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub BuscarArticulo(r As DataGridViewRow, referenciaColumn As DataGridViewColumn, descripcionColumn As DataGridViewColumn,
                               unidadMedidaColumn As DataGridViewColumn, tabla As DataTable)
        Try
            Dim busc As New FrmBuscador()
            busc.Tabla = tabla
            busc.ColumnasVisibles = New List(Of String) From {"Referencia", "Descripcion"}
            busc.ColumnasResultados = New List(Of String) From {"Id", "Referencia", "Descripcion", "Unidad_Inventario"}
            If busc.ShowDialog() = DialogResult.OK Then
                r.Cells(referenciaColumn.Index).Value = busc.Resultados("Referencia")
                r.Cells(descripcionColumn.Index).Value = busc.Resultados("Descripcion")
                r.Cells(unidadMedidaColumn.Index).Value = busc.Resultados("Unidad_Inventario")
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub BuscarMotivo(r As DataGridViewRow, idMotivoColumn As DataGridViewColumn, descripcionMotivoColumn As DataGridViewColumn)
        Try
            Dim mMotivo As New ClsMotivos
            Dim tabla As DataTable = Nothing
            Dim listMotivos As List(Of motivo) = mMotivo.TraerTodos(76, tabla)
            Dim busc As New FrmBuscador()
            busc.Tabla = tabla
            busc.ColumnasVisibles = New List(Of String) From {"Código", "cod_desc", "Descripcion"}
            busc.ColumnasResultados = New List(Of String) From {"Código", "cod_desc"}
            If busc.ShowDialog() = DialogResult.OK Then
                r.Cells(idMotivoColumn.Index).Value = busc.Resultados("Código")
                r.Cells(descripcionMotivoColumn.Index).Value = busc.Resultados("cod_desc")
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub BuscarBodega(r As DataGridViewRow, idBodegaColumn As DataGridViewColumn, descripcionBodegaColumn As DataGridViewColumn)
        Try
            Dim mBodega As New ClsBodegas
            Dim tabla As DataTable = Nothing
            Dim listBodegas As List(Of bodega) = mBodega.TraerTodos(tabla)
            Dim busc As New FrmBuscador()
            busc.Tabla = tabla
            busc.ColumnasVisibles = New List(Of String) From {"prefijo", "descripcion_Corta", "descripcion"}
            busc.ColumnasResultados = New List(Of String) From {"id", "descripcion_Corta"}
            If busc.ShowDialog() = DialogResult.OK Then
                r.Cells(idBodegaColumn.Index).Value = busc.Resultados("id")
                r.Cells(descripcionBodegaColumn.Index).Value = busc.Resultados("descripcion_Corta")
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ActivarIntellisensBusqueda(tabPageLocation As Point, cellLocation As Point, dw As DataGridView,
                                           tablaFuente As DataTable, columnasVisible As String(),
                                           filtros As String(), filtro As String, columnaseleccionada As String)
        Try
            Dim f As New ControlesPersonalizados.Intellisens.FrmIntelisense
            f.Location = cellLocation
            f.BringToFront()
            f.Focus()
            f.Width = dw.CurrentCell.Size.Width
            f.ControlBase = dw.CurrentCell
            f.TablaFuente = tablaFuente
            f.ColumnasVisibles = columnasVisible
            f.ColumnaSeleccionada = columnaseleccionada
            f.Filtros = filtros
            f.Filtro = filtro
            f.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Tab vidrio"
    Private Sub dwVidrio_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwVidrio.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim r As DataGridViewRow = dwVidrio.Rows(e.RowIndex)
                Select Case e.ColumnIndex
                    Case Is = vid_busqVidrio.Index
                        Dim tabla As DataTable = Nothing
                        Dim mArticulo As New ClsArticulosUnoee
                        mArticulo.TraerVidrioCrudo(tabla)
                        BuscarArticulo(r, vid_referencia, vid_descripcion, vid_unMedida, tabla)
                    Case Is = vid_busqBodega.Index
                        BuscarBodega(r, vid_bodega, vid_descBodega)
                    Case Is = vid_busqMotivoPedido.Index
                        BuscarMotivo(r, vid_motivoPedido, vid_descMotivoPedido)
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwVidrio_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dwVidrio.CellValueChanged
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim r As DataGridViewRow = dwVidrio.Rows(e.RowIndex)
                Select Case e.ColumnIndex
                    Case Is = vid_cantidad.Index
                        r.Cells(vid_mt2.Index).Value = CalcularMtCuadrados(Convert.ToDecimal(r.Cells(vid_ancho.Index).Value),
                                                                             Convert.ToDecimal(r.Cells(vid_alto.Index).Value),
                                                                             Convert.ToDecimal(r.Cells(vid_cantidad.Index).Value))
                    Case Is = vid_ancho.Index
                        r.Cells(vid_mt2.Index).Value = CalcularMtCuadrados(Convert.ToDecimal(r.Cells(vid_ancho.Index).Value),
                                                                             Convert.ToDecimal(r.Cells(vid_alto.Index).Value),
                                                                             Convert.ToDecimal(r.Cells(vid_cantidad.Index).Value))
                    Case Is = vid_alto.Index
                        r.Cells(vid_mt2.Index).Value = CalcularMtCuadrados(Convert.ToDecimal(r.Cells(vid_ancho.Index).Value),
                                                                             Convert.ToDecimal(r.Cells(vid_alto.Index).Value),
                                                                             Convert.ToDecimal(r.Cells(vid_cantidad.Index).Value))
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwVidrio_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwVidrio.EditingControlShowing
        Try
            RemoveHandler e.Control.KeyUp, AddressOf IntellisensVidrio_KeyUp
            AddHandler e.Control.KeyUp, AddressOf IntellisensVidrio_KeyUp
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub IntellisensVidrio_KeyUp(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dwVidrio.EndEdit()
                Return
            End If

            Dim rec As Rectangle
            rec = dwVidrio.GetCellDisplayRectangle(dwVidrio.CurrentCell.ColumnIndex, dwVidrio.CurrentCell.RowIndex, False)
            Dim pt As Point = dwVidrio.PointToScreen(rec.Location)
            pt.Y += dwVidrio.CurrentRow.Height

            Select Case dwVidrio.CurrentCell.ColumnIndex
                Case vid_referencia.Index
                    Dim tabla As DataTable = Nothing
                    Dim mArticulo As New ClsArticulosUnoee
                    mArticulo.TraerVidrioCrudo(tabla)
                    ActivarIntellisensBusqueda(tabVidrio.Location, pt,
                                               dwVidrio, tabla, {"Referencia", "Descripcion"},
                                               {"Referencia", "Descripcion"},
                                               DirectCast(sender, TextBox).Text, "Referencia")
                Case vid_descMotivoPedido.Index
                    Dim tabla As DataTable = Nothing
                    Dim mMotivo As New ClsMotivos
                    mMotivo.TraerTodos(76, tabla)
                    ActivarIntellisensBusqueda(tabVidrio.Location, pt, dwVidrio, tabla,
                                               {"id", "descripcion"}, {"id", "descripcion"},
                                               DirectCast(sender, TextBox).Text, "descripcion")
                Case vid_descBodega.Index
                    Dim tabla As DataTable = Nothing
                    Dim mBodega As New ClsBodegas
                    mBodega.TraerTodos(tabla)
                    ActivarIntellisensBusqueda(tabVidrio.Location, pt, dwVidrio, tabla,
                                               {"prefijo", "descripcion"}, {"prefijo", "descripcion"},
                                               DirectCast(sender, TextBox).Text, "descripcion")
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwVidrio_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dwVidrio.CellLeave
        Try
            If loadCompleted Then
                Dim r As DataGridViewRow = dwVidrio.Rows(e.RowIndex)
                If r.Cells(e.ColumnIndex).Value IsNot Nothing Or Convert.ToString(r.Cells(e.ColumnIndex).Value) <> String.Empty Then
                    Select Case e.ColumnIndex
                        Case vid_referencia.Index
                            Dim mArticulo As New ClsArticulosUnoee
                            Dim art As ArticuloUnoee = mArticulo.TraerVidrioCrudoxRef(r.Cells(vid_referencia.Index).Value)
                            r.Cells(vid_descripcion.Index).Value = art.Descripcion
                            r.Cells(vid_unMedida.Index).Value = art.UnidadInventario
                        Case vid_descMotivoPedido.Index
                            Dim mMotivo As New ClsMotivos
                            Dim mot As motivo = mMotivo.TraerxDescripcion(76, r.Cells(vid_descMotivoPedido.Index).Value)
                            r.Cells(vid_motivoPedido.Index).Value = mot.Codigo
                        Case vid_descBodega.Index
                            Dim mBodega As New ClsBodegas
                            Dim bod As bodega = mBodega.TraerxDescripcion(r.Cells(vid_descBodega.Index).Value)
                            r.Cells(vid_bodega.Index).Value = bod.Id
                    End Select
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Tab vidrio templado"
    Private Sub dwVidrioTemplado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwVidrioTemplado.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim r As DataGridViewRow = dwVidrioTemplado.Rows(e.RowIndex)
                Select Case e.ColumnIndex
                    Case Is = vtemp_buscVidrioTemplado.Index
                        MessageBox.Show("Buscar vidrio templado")
                    Case Is = vtemp_buscMotivo.Index
                        MessageBox.Show("Buscar motivo vidrio templado")
                    Case Is = vtemp_buscBodega.Index
                        MessageBox.Show("Buscar bodega vidrio templado")
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwVidrioTemplado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwVidrioTemplado.EditingControlShowing
        Try
            RemoveHandler e.Control.KeyUp, AddressOf IntellisensVidrioTemplado_KeyUp
            AddHandler e.Control.KeyUp, AddressOf IntellisensVidrioTemplado_KeyUp
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub IntellisensVidrioTemplado_KeyUp(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dwVidrioTemplado.EndEdit()
                Return
            End If

            Dim rec As Rectangle
            rec = dwVidrioTemplado.GetCellDisplayRectangle(dwVidrioTemplado.CurrentCell.ColumnIndex, dwVidrioTemplado.CurrentCell.RowIndex, False)
            Dim pt As Point = dwVidrioTemplado.PointToScreen(rec.Location)
            pt.Y += dwVidrioTemplado.CurrentRow.Height

            Select Case dwVidrioTemplado.CurrentCell.ColumnIndex
                Case vtemp_referencia.Index
                Case vtemp_descMotivoPedido.Index
                Case vtemp_descBodega.Index
            End Select

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Tab accesorios"
    Private Sub dwAccesorios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwAccesorios.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim r As DataGridViewRow = dwAccesorios.Rows(e.RowIndex)
                Select Case e.ColumnIndex
                    Case Is = acc_buscAccesorios.Index
                        Dim mArticulo As New ClsArticulosUnoee
                        Dim tabla As DataTable = Nothing
                        mArticulo.TraerAccesorios(tabla)
                        BuscarArticulo(r, acc_referencia, acc_descripcion, acc_unMedida, tabla)
                    Case Is = acc_buscMotivo.Index
                        BuscarMotivo(r, acc_motivoCreacion, acc_descMotivoCreacion)
                    Case Is = acc_buscBodega.Index
                        BuscarBodega(r, acc_bodega, acc_descBodega)
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwAccesorios_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dwAccesorios.CellValueChanged
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim r As DataGridViewRow = dwAccesorios.Rows(e.RowIndex)
                If e.ColumnIndex = acc_unMedida.Index And r.Cells(acc_unMedida.Index).Value IsNot Nothing Then
                    If r.Cells(acc_unMedida.Index).Value.ToString() = "MTL" Then
                        r.Cells(acc_dimension.Index).ReadOnly = False
                        r.Cells(acc_dimension.Index).Value = Nothing
                    Else
                        r.Cells(acc_dimension.Index).ReadOnly = True
                        r.Cells(acc_dimension.Index).Value = 0
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwAccesorios_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwAccesorios.EditingControlShowing
        Try
            RemoveHandler e.Control.KeyUp, AddressOf IntellisensAccesorios_KeyUp
            AddHandler e.Control.KeyUp, AddressOf IntellisensAccesorios_KeyUp
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub IntellisensAccesorios_KeyUp(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dwAccesorios.EndEdit()
                Return
            End If

            Dim rec As Rectangle
            rec = dwAccesorios.GetCellDisplayRectangle(dwAccesorios.CurrentCell.ColumnIndex, dwAccesorios.CurrentCell.RowIndex, False)
            Dim pt As Point = dwAccesorios.PointToScreen(rec.Location)
            pt.Y += dwAccesorios.CurrentRow.Height

            Select Case dwAccesorios.CurrentCell.ColumnIndex
                Case acc_referencia.Index
                    Dim tabla As DataTable = Nothing
                    Dim mArticulo As New ClsArticulosUnoee
                    mArticulo.TraerAccesorios(tabla)
                    ActivarIntellisensBusqueda(tabAccesorios.Location, pt,
                                               dwAccesorios, tabla, {"Referencia", "Descripcion"},
                                               {"Referencia", "Descripcion"},
                                               DirectCast(sender, TextBox).Text, "Referencia")
                Case acc_descMotivoCreacion.Index
                    Dim tabla As DataTable = Nothing
                    Dim mMotivo As New ClsMotivos
                    mMotivo.TraerTodos(76, tabla)
                    ActivarIntellisensBusqueda(tabAccesorios.Location, pt, dwAccesorios, tabla,
                                               {"id", "descripcion"}, {"id", "descripcion"},
                                               DirectCast(sender, TextBox).Text, "descripcion")
                Case acc_descBodega.Index
                    Dim tabla As DataTable = Nothing
                    Dim mBodega As New ClsBodegas
                    mBodega.TraerTodos(tabla)
                    ActivarIntellisensBusqueda(tabAccesorios.Location, pt, dwAccesorios, tabla,
                                               {"prefijo", "descripcion"}, {"prefijo", "descripcion"},
                                               DirectCast(sender, TextBox).Text, "descripcion")
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwAccesorios_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dwAccesorios.CellLeave
        Try
            If loadCompleted Then
                Dim r As DataGridViewRow = dwAccesorios.Rows(e.RowIndex)
                If r.Cells(e.ColumnIndex).Value IsNot Nothing Or Convert.ToString(r.Cells(e.ColumnIndex).Value) <> String.Empty Then
                    Select Case e.ColumnIndex
                        Case acc_referencia.Index
                            Dim mArticulo As New ClsArticulosUnoee
                            Dim art As ArticuloUnoee = mArticulo.TraerAccesorioxRef(r.Cells(acc_referencia.Index).Value)
                            r.Cells(acc_descripcion.Index).Value = art.Descripcion
                            r.Cells(acc_unMedida.Index).Value = art.UnidadInventario
                        Case acc_descMotivoCreacion.Index
                            Dim mMotivo As New ClsMotivos
                            Dim mot As motivo = mMotivo.TraerxDescripcion(76, r.Cells(acc_descMotivoCreacion.Index).Value)
                            r.Cells(acc_motivoCreacion.Index).Value = mot.Codigo
                        Case acc_descBodega.Index
                            Dim mBodega As New ClsBodegas
                            Dim bod As bodega = mBodega.TraerxDescripcion(r.Cells(acc_descBodega.Index).Value)
                            r.Cells(acc_bodega.Index).Value = bod.Id
                    End Select
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Tab perfiles"
    Private Sub dwPerfiles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwPerfiles.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim r As DataGridViewRow = dwPerfiles.Rows(e.RowIndex)
                Select Case e.ColumnIndex
                    Case Is = perf_buscPerfiles.Index
                        Dim mArticulos As New ClsArticulosUnoee
                        Dim tabla As DataTable = Nothing
                        mArticulos.TraerPerfiles(tabla)
                        BuscarArticulo(r, perf_referencia, perf_descripcion, perf_unMedida, tabla)
                    Case Is = perf_buscMotivo.Index
                        BuscarMotivo(r, perf_motivoCreacion, perf_descMotivo)
                    Case Is = perf_buscBodega.Index
                        BuscarBodega(r, perf_bodega, perf_descBodega)
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwPerfiles_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwPerfiles.EditingControlShowing
        Try
            RemoveHandler e.Control.KeyUp, AddressOf IntellisensPerfiles_KeyUp
            AddHandler e.Control.KeyUp, AddressOf IntellisensPerfiles_KeyUp
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub IntellisensPerfiles_KeyUp(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dwPerfiles.EndEdit()
                Return
            End If

            Dim rec As Rectangle
            rec = dwPerfiles.GetCellDisplayRectangle(dwPerfiles.CurrentCell.ColumnIndex, dwPerfiles.CurrentCell.RowIndex, False)
            Dim pt As Point = dwPerfiles.PointToScreen(rec.Location)
            pt.Y += dwPerfiles.CurrentRow.Height

            Select Case dwPerfiles.CurrentCell.ColumnIndex
                Case perf_referencia.Index
                    Dim tabla As DataTable = Nothing
                    Dim mArticulo As New ClsArticulosUnoee
                    mArticulo.TraerPerfiles(tabla)
                    ActivarIntellisensBusqueda(tabPerfileria.Location, pt,
                                               dwPerfiles, tabla, {"Referencia", "Descripcion"},
                                               {"Referencia", "Descripcion"},
                                               DirectCast(sender, TextBox).Text, "Referencia")
                Case perf_descMotivo.Index
                    Dim tabla As DataTable = Nothing
                    Dim mMotivo As New ClsMotivos
                    mMotivo.TraerTodos(76, tabla)
                    ActivarIntellisensBusqueda(tabPerfileria.Location, pt, dwPerfiles, tabla,
                                               {"id", "descripcion"}, {"id", "descripcion"},
                                               DirectCast(sender, TextBox).Text, "descripcion")
                Case perf_descBodega.Index
                    Dim tabla As DataTable = Nothing
                    Dim mBodega As New ClsBodegas
                    mBodega.TraerTodos(tabla)
                    ActivarIntellisensBusqueda(tabPerfileria.Location, pt, dwPerfiles, tabla,
                                               {"prefijo", "descripcion"}, {"prefijo", "descripcion"},
                                               DirectCast(sender, TextBox).Text, "descripcion")
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwPerfiles_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dwPerfiles.CellLeave
        Try
            If loadCompleted Then
                Dim r As DataGridViewRow = dwPerfiles.Rows(e.RowIndex)
                If r.Cells(e.ColumnIndex).Value IsNot Nothing Or Convert.ToString(r.Cells(e.ColumnIndex).Value) <> String.Empty Then
                    Select Case e.ColumnIndex
                        Case perf_referencia.Index
                            Dim mArticulo As New ClsArticulosUnoee
                            Dim art As ArticuloUnoee = mArticulo.TraerPerfilxRef(r.Cells(perf_referencia.Index).Value)
                            r.Cells(perf_descripcion.Index).Value = art.Descripcion
                            r.Cells(perf_unMedida.Index).Value = art.UnidadInventario
                        Case perf_descMotivo.Index
                            Dim mMotivo As New ClsMotivos
                            Dim mot As motivo = mMotivo.TraerxDescripcion(76, r.Cells(perf_descMotivo.Index).Value)
                            r.Cells(perf_motivoCreacion.Index).Value = mot.Codigo
                        Case perf_descBodega.Index
                            Dim mBodega As New ClsBodegas
                            Dim bod As bodega = mBodega.TraerxDescripcion(r.Cells(perf_descBodega.Index).Value)
                            r.Cells(perf_bodega.Index).Value = bod.Id
                    End Select
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Vidrio laminado"
#End Region
#End Region
End Class