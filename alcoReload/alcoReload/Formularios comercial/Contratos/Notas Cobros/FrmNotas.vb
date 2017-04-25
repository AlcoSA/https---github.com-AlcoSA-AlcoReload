Imports ReglasNegocio
Imports ReglasNegocio.Contratos
Imports Informes
Imports Validaciones

Public Class FrmNotas
#Region "Variables"
    Private _tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _origenNota As ClsEnums.OrigenNota = ClsEnums.OrigenNota.DIRECTA
    Private mObra As clsObrasUnoee
    Private mContrato As clsContratos
    Private mNota As ClsNotasCobro
    Private objEsquemaInforme As esquemaInforme
    Private listObjetos As New List(Of objetoContrato)
    Private listpara As New List(Of tipoObra)
    Private loadCompleted As Boolean = False
    Private _listOfSelectedRows As List(Of DataGridViewRow)
    Private _dsInformes As New datosInformesTableAdapters.sp_tc053_selectByIdXMLTableAdapter
    Private dtpFecha As New DateTimePicker

    Private _nit As String
    Private _cliente As String
    Private _codigoObra As String
    Private _obra As String
    Private _idTipoNota As Integer
    Private _contrato As String
    Private _valorContrato As Decimal
    Private _vendedor As String
    Private _totalCuotas As Integer
    Private _listCuotas As List(Of cuota)
    Private _listObjetosContrato As List(Of relacionObjetosContratos)
    Private _listParaContrato As List(Of relacionParaContrato)

    Private detalleGenerado As Boolean = False
#End Region
#Region "Propiedades"
    Public Property Operacion() As ClsEnums.TiOperacion
        Get
            Return _tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            _tform = value
        End Set
    End Property
    Public Property origenNota() As ClsEnums.OrigenNota
        Get
            Return _origenNota
        End Get
        Set(ByVal value As ClsEnums.OrigenNota)
            _origenNota = value
        End Set
    End Property
    Public Property listaFilasSeleccionadas() As List(Of DataGridViewRow)
        Get
            Return _listOfSelectedRows
        End Get
        Set(ByVal value As List(Of DataGridViewRow))
            _listOfSelectedRows = value
        End Set
    End Property
    Public Property Nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodigoObra() As String
        Get
            Return _codigoObra
        End Get
        Set(ByVal value As String)
            _codigoObra = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property IdTipoNota() As Integer
        Get
            Return _idTipoNota
        End Get
        Set(ByVal value As Integer)
            _idTipoNota = value
        End Set
    End Property
    Public Property Contrato() As String
        Get
            Return _contrato
        End Get
        Set(ByVal value As String)
            _contrato = value
        End Set
    End Property
    Public Property ValorContrato() As Decimal
        Get
            Return _valorContrato
        End Get
        Set(ByVal value As Decimal)
            _valorContrato = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property TotalCuotas() As Integer
        Get
            Return _totalCuotas
        End Get
        Set(ByVal value As Integer)
            _totalCuotas = value
        End Set
    End Property
    Public Property ListCuotasSeleccionadas() As List(Of cuota)
        Get
            Return _listCuotas
        End Get
        Set(ByVal value As List(Of cuota))
            _listCuotas = value
        End Set
    End Property
    Public Property ListObjetosContrato() As List(Of relacionObjetosContratos)
        Get
            Return _listObjetosContrato
        End Get
        Set(ByVal value As List(Of relacionObjetosContratos))
            _listObjetosContrato = value
        End Set
    End Property
    Public Property ListParaContrato() As List(Of relacionParaContrato)
        Get
            Return _listParaContrato
        End Get
        Set(ByVal value As List(Of relacionParaContrato))
            _listParaContrato = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Procedimiento que crea el control de la fecha inicial en el plan de anticipos.
    ''' </summary>
    Private Sub CargarControlesAdicionalesToolStrip()
        Try
            Dim host As New ToolStripControlHost(dtpFecha)
            dtpFecha.Format = DateTimePickerFormat.Short
            tsherramientas.Items.Insert(9, host)
            AddHandler dtpFecha.ValueChanged, AddressOf dtpFecha_valueChanged
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Carga de información"
    Private Sub cargarTipoNota()
        Try
            Dim mTipoNota As New ClsTiposNotas()
            Dim listTiposNotas As List(Of tipoNota) = mTipoNota.TraerTodos()
            cmbTipoNota.DisplayMember = "Descripcion"
            cmbTipoNota.ValueMember = "Id"
            cmbTipoNota.DataSource = listTiposNotas.Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarContratos()
        Try
            mContrato = New clsContratos
            Dim listContratos As List(Of contrato) = mContrato.traerByNitAndIdObra(ctrlNit.Text, ctrCodSucursal.Text)
            cmbContrato.DisplayMember = "nContrato"
            cmbContrato.ValueMember = "Id"
            cmbContrato.DataSource = listContratos
            cmbContrato.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarClientes()
        Try
            mContrato = New clsContratos
            If _origenNota = ClsEnums.OrigenNota.PORANTICIPO Then
                mContrato.TraerClientes(1, ctrlNit.TablaFuente)
            Else
                mContrato.TraerClientes(0, ctrlNit.TablaFuente)
            End If
            ctrCliente.TablaFuente = ctrlNit.TablaFuente
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarSucursales()
        Try
            mContrato = New clsContratos
            If Not ctrCliente.Seleted_rowid Is Nothing Or Not ctrlNit.Seleted_rowid Is Nothing Then
                If _origenNota = ClsEnums.OrigenNota.PORANTICIPO Then
                    mContrato.TraerObras(True, ctrlNit.Text, ctrCodSucursal.TablaFuente)
                Else
                    mContrato.TraerObras(False, ctrlNit.Text, ctrCodSucursal.TablaFuente)
                End If
                ctrObra.TablaFuente = ctrCodSucursal.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarObjetosYPara()
        Try
            Dim mObjetoContrato As New clsObjetosContratos
            Dim dt As New DataTable
            listObjetos = mObjetoContrato.traerTodos(dt)
            Cargar(dt, dwItemsObjetos)

            Dim mTipoObra As New ClsTiposObras
            listpara = mTipoObra.TraerTodos(dt)
            Cargar(dt, dwItemsPara)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Cargar(tb As DataTable, dw As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros, Optional grid As Integer = 0)
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
    Private Sub cargarInformacionObra()
        Try
            If loadCompleted Then
                mObra = New clsObrasUnoee
                Dim objObra As obrasUnoee = mObra.traerObraByNitClienteAndSuc(ctrlNit.Text, ctrCodSucursal.Text)
                txtVendedor.Text = objObra.idVendedor
                cargarContratos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub CargarDesdeAnticipo()
        Try
            ctrlNit.Text = _nit
            ctrlNit.Seleted_rowid = _nit
            ctrCliente.Text = _cliente
            ctrCliente.Seleted_rowid = _nit
            cargarSucursales()
            ctrCodSucursal.Text = _codigoObra
            ctrCodSucursal.Seleted_rowid = _codigoObra
            ctrObra.Text = _obra
            ctrObra.Seleted_rowid = _codigoObra
            cmbTipoNota.SelectedValue = _idTipoNota
            cargarContratos()
            cmbContrato.Text = _contrato
            txtValorNota.Text = _listCuotas.Sum(Function(a) a.valorCuota)
            txtValorNota_Leave(Nothing, Nothing)
            txtValorContrato.Text = _valorContrato
            txtValorContrato_Leave(Nothing, Nothing)
            mObra = New clsObrasUnoee
            Dim objObra As obrasUnoee = mObra.traerObraByNitClienteAndSuc(ctrlNit.Text, ctrCodSucursal.Text)
            txtVendedor.Text = objObra.idVendedor
            txtPorcAnticipo.Text = _listCuotas.Sum(Function(a) a.porcentajeCuota)

            lblCuota.Text = numeroCuota()
            lblDe.Text = _totalCuotas

            For Each obj As relacionObjetosContratos In _listObjetosContrato
                For Each r As DataGridViewRow In dwItemsObjetos.Rows
                    If Convert.ToInt32(r.Cells(id1.Index).Value) = obj.idObjeto Then
                        r.Cells(selected1.Index).Value = True
                    End If
                Next
            Next

            For Each para As relacionParaContrato In _listParaContrato
                For Each r As DataGridViewRow In dwItemsPara.Rows
                    If Convert.ToInt32(r.Cells(id2.Index).Value) = para.idTipoObra Then
                        r.Cells(selected2.Index).Value = True
                    End If
                    If para.idTipoObra = ClsEnums.Tipos_obra.CONS_FACHADA Or para.idTipoObra = ClsEnums.Tipos_obra.CONS_DOMO Then
                        cbIvaSobreUtilidad.Checked = True
                    End If
                Next
            Next

            deshabilitarCampos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function numeroCuota() As String
        numeroCuota = String.Empty
        Try
            Dim msj As String = String.Empty
            Dim cuotas As Integer = _listCuotas.Count
            If cuotas > 0 Then
                Dim conteo As Integer = 0
                For Each cta As cuota In _listCuotas
                    msj += cta.NumeroCuota.ToString()
                    conteo += 1
                    If conteo < cuotas Then
                        msj += ", "
                    End If
                Next
                numeroCuota = msj
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Sub deshabilitarCampos()
        Try
            ctrlNit.Enabled = False
            ctrCliente.Enabled = False
            ctrCodSucursal.Enabled = False
            ctrObra.Enabled = False
            cmbTipoNota.Enabled = False
            'cmbContrato.Enabled = False
            lblpesos1.Enabled = False
            txtValorNota.Enabled = False
            lblpesos2.Enabled = False
            txtValorContrato.Enabled = False
            txtVendedor.Enabled = False
            txtPorcAnticipo.Enabled = False
            dwItemsObjetos.ReadOnly = True
            dwItemsPara.ReadOnly = True
            cbIvaSobreUtilidad.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Imprimir(id As Integer)
        Try
            Dim ds As New DataSet
            Dim dt As DataTable
            dt = _dsInformes.GetData(id).CopyToDataTable
            dt.TableName = "NotaCobro"
            ds.Tables.Add(dt)
            ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "NotaCobro.xml"))
            Dim b As New Informes.NotadeCobroXml
            b.SetDataSource(ds)

            b.PrintToPrinter(4, False, 0, 1)

            'ds.Tables(0).Rows(0).Item("ncopia") = 2
            'b.SetDataSource(ds)
            'b.PrintToPrinter(1, False, 0, 1)

            ActualizarImpresiones(id, 5)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ActualizarImpresiones(idNota As Integer, impresionesNuevas As Integer)
        Try
            Dim mNotaCobro As New ClsNotasCobro
            Dim impresionesActuales As Integer = mNotaCobro.TraerNumeroImpresiones(idNota)
            mNotaCobro.ActualizarNumImpresiones(idNota, impresionesActuales + impresionesNuevas)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Sub seleccionarTiposObra()
        Try
            For Each itm As DataGridViewRow In _listOfSelectedRows
                For Each fila As DataGridViewRow In dwItemsPara.Rows
                    If fila.Cells(id2.Index).Value.ToString.Trim = itm.Cells("idtipoCotiza").Value.ToString.Trim Then
                        fila.Cells(selected2.Index).Value = True
                        seleccionObjetosObra(fila)
                    End If
                Next
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Sub seleccionObjetosObra(rw As DataGridViewRow)
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
    Public Function calculoIVAS(valor As String, tipo As Integer) As Decimal
        Try
            calculoIVAS = 0
            Select Case tipo
                Case Is = 1
                    calculoIVAS = valor * 1.16
                Case Is = 2
                    calculoIVAS = (((valor / 1.06) * 0.06) * 0.16) + valor
            End Select
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Function ObjetosNota() As String
        ObjetosNota = String.Empty
        Try
            Dim msj As String = String.Empty
            'Creación del string con los objetos seleccionados
            Dim listObjetos As New Dictionary(Of Integer, String)
            For Each row As DataGridViewRow In dwItemsObjetos.Rows
                If Convert.ToBoolean(row.Cells(selected1.Index).Value) = True Then
                    listObjetos.Add(row.Cells(id1.Index).Value,
                                    RTrim(Convert.ToString(row.Cells(descripcion1.Index).Value)))
                End If
            Next
            msj += preposicion(listObjetos.First.Value)
            msj += generarObjetosNota(listObjetos)

            'Continuación del string con las obras
            Dim listObras As New Dictionary(Of Integer, String)
            For Each row As DataGridViewRow In dwItemsPara.Rows
                If Convert.ToBoolean(row.Cells(selected2.Index).Value) = True Then
                    listObras.Add(row.Cells(id2.Index).Value,
                                  RTrim(Convert.ToString(row.Cells(descripcion2.Index).Value)))
                End If
            Next
            msj += generarObjetosNota(listObras, True)
            ObjetosNota = msj
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Function preposicion(palabra As String) As String
        preposicion = String.Empty
        Try
            Dim primera As String
            Dim ultima, dosUltimas As String
            primera = If(String.IsNullOrEmpty(Replace(Split(palabra, " ")(0), ",", "")), palabra, Replace(Split(palabra, " ")(0), ",", ""))
            ultima = Mid(primera, Len(primera), Len(primera)).ToString.ToUpper
            dosUltimas = Mid(primera, Len(primera) - 1, Len(primera)).ToString.ToUpper
            Select Case palabra
                Case Is = "mano"
                    preposicion = "la "
                Case Else
                    Select Case ultima
                        Case Is = "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
                            preposicion = "la "
                        Case Is = "O"
                            preposicion = "el "
                        Case Is = "A"
                            preposicion = "la "
                        Case Else
                            Select Case dosUltimas
                                Case Is = "IZ", "ÓN", "ON"
                                    preposicion = "la "
                                Case Is = "AS", "ES", "IS", "US"
                                    preposicion = "las "
                                Case Is = "OS"
                                    preposicion = "los "
                            End Select
                    End Select
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Function generarObjetosNota(dic As Dictionary(Of Integer, String),
                                        Optional ByVal obra As Boolean = False) As String
        generarObjetosNota = String.Empty
        Try
            Dim msj = String.Empty
            Dim numObjetos As Integer = dic.Count
            Dim conteo As Integer = 0
            For Each obj In dic
                conteo += 1
                If numObjetos >= 3 Then
                    If conteo <= numObjetos - 2 Then
                        msj += obj.Value & ", "
                    ElseIf conteo = numObjetos - 1 Then
                        msj += obj.Value
                    Else
                        msj += devolverYoE(obj)
                        If obra = False Then
                            msj += " de "
                        End If
                    End If

                ElseIf numObjetos = 2 Then
                    If conteo = numObjetos - 1 Then
                        msj += obj.Value
                    Else
                        msj += devolverYoE(obj)
                        If obra = False Then
                            msj += " de "
                        End If
                    End If
                Else
                    msj += obj.Value
                    If obra = False Then
                        msj += " de "
                    End If
                End If
            Next
            Return msj
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Function devolverYoE(obj As KeyValuePair(Of Integer, String)) As String
        Try
            Dim c As Char = obj.Value(0)
            If c = "I" Then
                Return " e " & obj.Value
            Else
                Return " y " & obj.Value
            End If
            Return String.Empty
        Catch ex As Exception
            Return String.Empty
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Function validarCombinacion() As Boolean
        Try
            Dim countObjetos As Integer = 0
            For Each r As DataGridViewRow In dwItemsObjetos.Rows
                If Convert.ToBoolean(r.Cells(selected1.Index).Value) = True Then
                    countObjetos += 1
                End If
            Next
            If countObjetos = 0 Then
                ErrorProvider.SetError(grObjeto, "Debe seleccionar al menos un objeto de contrato")
                Return False
            End If
            ErrorProvider.Clear()

            Dim countPara As Integer = 0
            For Each r As DataGridViewRow In dwItemsPara.Rows
                If Convert.ToBoolean(r.Cells(selected2.Index).Value) = True Then
                    countPara += 1
                End If
            Next
            If countPara = 0 Then
                ErrorProvider.SetError(grPara, "Debe seleccionar al menos un item")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub Limpiar()
        Try
            ctrlNit.Text = String.Empty
            ctrlNit.Seleted_rowid = Nothing
            ctrCliente.Text = String.Empty
            ctrCliente.Seleted_rowid = Nothing
            ctrCodSucursal.Text = String.Empty
            ctrCodSucursal.Seleted_rowid = Nothing
            ctrObra.Text = String.Empty
            ctrObra.Seleted_rowid = Nothing
            cmbContrato.DataSource = Nothing
            cmbContrato.Text = String.Empty
            txtValorNota.Text = String.Empty
            txtValorContrato.Text = String.Empty
            txtVendedor.Text = String.Empty
            txtPorcAnticipo.Text = String.Empty
            lblCuota.Text = "---"
            lblDe.Text = "---"
            cargarObjetosYPara()


            _tform = ClsEnums.TiOperacion.INSERTAR
            _origenNota = ClsEnums.OrigenNota.DIRECTA
            listObjetos = New List(Of objetoContrato)
            listpara = New List(Of tipoObra)
            loadCompleted = False
            _listOfSelectedRows = New List(Of DataGridViewRow)
            _dsInformes = New datosInformesTableAdapters.sp_tc053_selectByIdXMLTableAdapter

            _nit = String.Empty
            _cliente = String.Empty
            _codigoObra = String.Empty
            _obra = String.Empty
            _idTipoNota = 0
            _contrato = String.Empty
            _valorContrato = 0
            _vendedor = String.Empty
            _totalCuotas = 0
            _listCuotas = New List(Of cuota)
            _listObjetosContrato = New List(Of relacionObjetosContratos)
            _listParaContrato = New List(Of relacionParaContrato)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionFinal() As Boolean
        Try
            If ctrlNit.Text = String.Empty Then
                ErrorProvider.SetError(ctrlNit, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If ctrCliente.Text = String.Empty Then
                ErrorProvider.SetError(ctrCliente, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If ctrCodSucursal.Text = String.Empty Then
                ErrorProvider.SetError(ctrCodSucursal, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If ctrObra.Text = String.Empty Then
                ErrorProvider.SetError(ctrObra, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbTipoNota.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbTipoNota, "Debe seleccionar un dato. Verifique la información")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbContrato.Text = String.Empty Then
                ErrorProvider.SetError(cmbContrato, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If txtValorNota.Text = String.Empty Then
                ErrorProvider.SetError(txtValorNota, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If txtValorContrato.Text = String.Empty Then
                ErrorProvider.SetError(txtValorContrato, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If txtVendedor.Text = String.Empty Then
                ErrorProvider.SetError(txtVendedor, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If txtPorcAnticipo.Text = String.Empty Then
                ErrorProvider.SetError(txtPorcAnticipo, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If Not validarCombinacion() Then
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region


#Region "Configuración Intellisens"
#Region "Comportamiento Nit"
    Private Sub ctrlNit_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles ctrlNit.selected_value_changed
        Try
            ctrCliente.Text = e.ValorSecundario
            ctrCliente.Value2 = e.ValorPrimario
            cargarSucursales()
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
            ctrlNit.Text = e.ValorSecundario
            ctrlNit.Value2 = e.ValorPrimario
            cargarSucursales()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ctrlCliente_KeyUp(sender As Object, e As EventArgs) Handles ctrCliente.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                ctrlNit.Text = ""
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Comportamiento Código Obra"
    Private Sub ctrCodSucursal_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles ctrCodSucursal.selected_value_changed
        Try
            ctrObra.Text = e.ValorSecundario
            ctrObra.Value2 = e.ValorPrimario
            cargarInformacionObra()
            txtValorContrato.Text = String.Empty
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
            If Not String.IsNullOrEmpty(e.ValorSecundario) Then
                ctrCodSucursal.Text = e.ValorSecundario
                ctrCodSucursal.Value2 = e.ValorPrimario
                cargarInformacionObra()
                txtValorContrato.Text = String.Empty
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
#Region "Procedimiento Controles"
    Private Sub FrmNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarControlesAdicionalesToolStrip()
            cargarTipoNota()
            cargarClientes()
            cargarObjetosYPara()

            mNota = New ClsNotasCobro
            lblConsecutivo.Text = Convert.ToInt32(mNota.TraerMaxId()) + 1
            If _origenNota = ClsEnums.OrigenNota.PORANTICIPO Then
                CargarDesdeAnticipo()
                'btnCombinar_Click(Nothing, Nothing)
            End If

            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtSoloNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorNota.KeyPress,
        txtValorContrato.KeyPress, txtPorcAnticipo.KeyPress
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
    Private Sub cmbTipoNota_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoNota.SelectedValueChanged
        Try
            Dim mEsquemaInforme As New ClsEsquemaInforme
            objEsquemaInforme = mEsquemaInforme.traerValorDefectoByTipoNota(cmbTipoNota.SelectedValue)
            txtDetalleNota.Text = objEsquemaInforme.descripcion
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCombinar_Click(sender As Object, e As EventArgs) Handles btnCombinar.Click
        Try
            If validarCombinacion() Then
                For Each cnt As Control In Me.Controls
                    If Not TypeOf (cnt) Is CheckBox Then
                        If InStr(cnt.Tag, "{", CompareMethod.Text) > 0 Then
                            If cnt.Name = "txtValorContrato" Then
                                txtDetalleNota.Text = Replace(txtDetalleNota.Text, cnt.Tag, (FormatCurrency(((If(cnt.Text = "---" OrElse cnt.Text = "", 0, calculoIVAS(FormatNumber(cnt.Text), If(cbIvaSobreUtilidad.Checked, 2, 1))))), 0)))
                            Else
                                txtDetalleNota.Text = Replace(txtDetalleNota.Text, cnt.Tag, cnt.Text)
                            End If
                        End If
                    End If
                Next
                txtDetalleNota.Text = Replace(txtDetalleNota.Text, "{objeto_nota}", ObjetosNota())
                detalleGenerado = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnDescombinar_Click(sender As Object, e As EventArgs) Handles btnDescombinar.Click
        Try
            cmbTipoNota_SelectedValueChanged(Nothing, Nothing)
            detalleGenerado = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnGuardado_Click(sender As Object, e As EventArgs) Handles btnGuardado.Click
        Try
            If detalleGenerado = False Then
                btnCombinar_Click(Nothing, Nothing)
            End If
            If validacionFinal() Then
                mNota = New ClsNotasCobro
                Dim mVendedor As New ClsVendedoresSiesa
                Dim objVendedor As vendedor = mVendedor.TraerxIdSiesa(txtVendedor.Text)
                Dim notaInsertada As Integer
                If _tform = ClsEnums.TiOperacion.INSERTAR Then
                    notaInsertada = mNota.Insertar(My.Settings.UsuarioActivo, _origenNota, dtpFecha.Value, ctrlNit.Text, ctrCliente.Text, ctrCodSucursal.Text,
                    ctrObra.Text, cmbTipoNota.SelectedValue, cmbContrato.Text, Convert.ToDecimal(txtValorNota.Text),
                                                       Convert.ToDecimal(txtValorContrato.Text), txtVendedor.Text, Convert.ToDecimal(txtPorcAnticipo.Text),
                                                       lblCuota.Text, lblDe.Text, Convert.ToBoolean(cbIvaSobreUtilidad.Checked), txtObservaciones.Text,
                                                       ClsEnums.Estados.IMPRESO, 0, My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO)

                    Dim mEsquemaNota As New ClsEsquemaNota
                    mEsquemaNota.Insertar(My.Settings.UsuarioActivo, notaInsertada, txtDetalleNota.Text, objEsquemaInforme.pieDePagina)

                    Dim mObjetoNota As New ClsObjetosNota
                    For Each r As DataGridViewRow In dwItemsObjetos.Rows
                        If Convert.ToBoolean(r.Cells(selected1.Index).Value) = True Then
                            mObjetoNota.Insertar(My.Settings.UsuarioActivo, notaInsertada, r.Cells(id1.Index).Value)
                        End If
                    Next

                    Dim mParaNota As New ClsParaNota
                    For Each r As DataGridViewRow In dwItemsPara.Rows
                        If Convert.ToBoolean(r.Cells(selected2.Index).Value) = True Then
                            mParaNota.Insertar(My.Settings.UsuarioActivo, notaInsertada, r.Cells(id2.Index).Value)
                        End If
                    Next

                    If _origenNota = ClsEnums.OrigenNota.PORANTICIPO Then

                        Dim mAnticiporNota As New clsAnticiposPorNota
                        Dim mMovitoAnticipo As New clsMovitoPlanAnticipos
                        For Each cta As cuota In _listCuotas
                            mAnticiporNota.InsertAnticipoxCuota(notaInsertada, cta.Id)
                            mMovitoAnticipo.ActualizarEstado(cta.Id, ClsEnums.Estados.GENERADO)
                        Next
                    End If
                ElseIf _tform = ClsEnums.TiOperacion.MODIFICAR Then

                End If
                'Imprimir(notaInsertada)
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                Limpiar()
                'FrmNotas_Load(Nothing, Nothing)
                Me.DialogResult = DialogResult.OK
            Else
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtValorNota_Leave(sender As Object, e As EventArgs) Handles txtValorNota.Leave
        Try
            If txtValorNota.Text = String.Empty Then
                txtValorNota.Text = 0
            Else
                txtValorNota.Text = FormatNumber(txtValorNota.Text)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtValorContrato_Leave(sender As Object, e As EventArgs) Handles txtValorContrato.Leave
        Try
            If txtValorContrato.Text = String.Empty Then
                txtValorContrato.Text = 0
            Else
                txtValorContrato.Text = FormatNumber(txtValorContrato.Text)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbContrato_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbContrato.SelectedValueChanged
        Try
            If cmbContrato.Text <> String.Empty Then
                mContrato = New clsContratos
                Dim listContrato As List(Of contrato) = mContrato.TraerByNumeroContrato(cmbContrato.Text)
                Dim objContrato As contrato = listContrato.FirstOrDefault()
                txtValorContrato.Text = FormatNumber(objContrato.valorContrato)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbContrato_Leave(sender As Object, e As EventArgs) Handles cmbContrato.Leave
        Try
            cmbContrato.Text = cmbContrato.Text.ToUpper
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbContrato_TextChanged(sender As Object, e As EventArgs) Handles cmbContrato.TextChanged
        Try
            If loadCompleted And cmbContrato.DataSource IsNot Nothing Then
                Dim listContratos As List(Of contrato) = cmbContrato.DataSource
                For Each ct As contrato In listContratos
                    If cmbContrato.Text <> ct.nContrato Then
                        cmbContrato.SelectedValue = 0
                        txtValorContrato.Text = String.Empty
                    End If
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Public Sub dtpFecha_valueChanged()
        Try
            If dtpFecha.Value < DateTime.Now Then
                'ErrorProvider.SetError(dtpFecha, "No puede generar notas de cobro para notas pasadas")
                dtpFecha.Value = DateTime.Now
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub controlesObra_TextChanged(sender As Object, e As EventArgs) Handles ctrCodSucursal.TextChanged, ctrObra.TextChanged
        Try
            If loadCompleted Then
                lblNitYo.Text = mNota.traerYoByNitCodObra(ctrlNit.Text, ctrCodSucursal.Text, "Nit")
                lblNombreYo.Text = mNota.traerYoByNitCodObra(ctrlNit.Text, ctrCodSucursal.Text, "Nombre")
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

End Class