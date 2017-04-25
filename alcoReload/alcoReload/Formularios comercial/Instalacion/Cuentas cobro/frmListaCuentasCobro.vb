Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class frmListaCuentasCobro
#Region "Variables"
    Private _tipoCuentaCobro As ClsEnums.TipoCuentaCobro
    Private _vistaParaDevolucion As Boolean = False
    Private fuenteInicial As DataTable = Nothing
    Private objEncabezado As New Informes.datosInformesTableAdapters.sp_tc100_selectCuentaCobroXMLTableAdapter
    Private objMovito As New Informes.datosInformesTableAdapters.sp_tc101_selectByCuentaCobroXMLTableAdapter
#End Region
#Region "Propiedades"
    Public Property TipoCuentaCobro() As ClsEnums.TipoCuentaCobro
        Get
            Return _tipoCuentaCobro
        End Get
        Set(ByVal value As ClsEnums.TipoCuentaCobro)
            _tipoCuentaCobro = value
        End Set
    End Property
    Public Property VistaParaDevolucion() As Boolean
        Get
            Return _vistaParaDevolucion
        End Get
        Set(ByVal value As Boolean)
            _vistaParaDevolucion = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub ObjetoyPara()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If _tipoCuentaCobro = ClsEnums.TipoCuentaCobro.DESDE_OT Then
                Dim mContrato As New clsContratos
                Dim cont As contrato = mContrato.TraerObjetoYPara(r.Cells(idContrato.DataPropertyName).Value)
                Dim info As New ContextMenuStrip
                info.Items.Add("Contrato: " & cont.nContrato)
                info.Items.Add("Objeto: " & cont.Objeto)
                info.Items.Add("Para: " & cont.Para)
                info.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verCuentaCobro()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If _tipoCuentaCobro = ClsEnums.TipoCuentaCobro.DESDE_OT Then
                Dim frm As New frmVistaCuentaCobro
                frm.IdCuentaCobro = r.Cells(id.DataPropertyName).Value
                frm.IdDocumento = r.Cells(idDocumento.DataPropertyName).Value
                frm.Documento = r.Cells(documento.DataPropertyName).Value
                frm.Consecutivo = r.Cells(consecutivo.DataPropertyName).Value
                frm.Obra = r.Cells(obra.DataPropertyName).Value
                frm.Vendedor = r.Cells(vendedor.DataPropertyName).Value
                frm.Proveedor = r.Cells(proveedor.DataPropertyName).Value
                frm.Encargado = r.Cells(encargado.DataPropertyName).Value
                frm.FechaCreacion = r.Cells(fechaCreacion.DataPropertyName).Value
                frm.IdEstado = r.Cells(idEstado.DataPropertyName).Value
                frm.Observaciones = r.Cells(observaciones.DataPropertyName).Value
                If frm.ShowDialog() = DialogResult.OK Then
                    frmListaCuentasCobro_Load(Nothing, Nothing)
                End If
            ElseIf _tipoCuentaCobro = ClsEnums.TipoCuentaCobro.DIRECTAS Then
                Dim frm As New frmVistaCuentaCobroDirecta
                frm.IdCuentaCobro = r.Cells(id.DataPropertyName).Value
                frm.IdDocumento = r.Cells(idDocumento.DataPropertyName).Value
                frm.Documento = r.Cells(documento.DataPropertyName).Value
                frm.Consecutivo = r.Cells(consecutivo.DataPropertyName).Value
                frm.Obra = r.Cells(obra.DataPropertyName).Value
                frm.Vendedor = r.Cells(vendedor.DataPropertyName).Value
                frm.Proveedor = r.Cells(proveedor.DataPropertyName).Value
                frm.Encargado = r.Cells(encargado.DataPropertyName).Value
                frm.FechaCreacion = r.Cells(fechaCreacion.DataPropertyName).Value
                frm.IdEstado = r.Cells(idEstado.DataPropertyName).Value
                frm.Observaciones = r.Cells(observaciones.DataPropertyName).Value
                If frm.ShowDialog() = DialogResult.OK Then
                    frmListaCuentasCobro_Load(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Anular()
        Try
            If MessageBox.Show("¿Está seguro de anular la cuenta de cobro seleccionada?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                Dim mCuentaCobro As New ClsCuentaCobro
                Dim mMovitoCuentaCobro As New ClsMovitoCuentaCobro
                If mCuentaCobro.TieneMovimientos(r.Cells(id.DataPropertyName).Value) Then
                    MessageBox.Show("La cuenta de cobro tiene movimientos activos, no se puede anular")
                    Return
                End If
                mCuentaCobro.ActualizarEstado(r.Cells(id.DataPropertyName).Value, ClsEnums.Estados.ANULADO, My.Settings.UsuarioActivo)
                mMovitoCuentaCobro.ActualizarEstado(r.Cells(id.DataPropertyName).Value, ClsEnums.Estados.ANULADO, My.Settings.UsuarioActivo)
                Dim list As List(Of movitoCuentaCobro) = mMovitoCuentaCobro.TraerxCuentaCobroOT(r.Cells(id.DataPropertyName).Value)
                For Each movito As movitoCuentaCobro In list
                    If Not mMovitoCuentaCobro.MovitosActivos(movito.IdMovitoOT) Then
                        Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
                        mMovitoOrdenTrabajo.ActualizarEstadoById(movito.IdMovitoOT, ClsEnums.Estados.ACTIVO)
                    End If
                Next
                frmListaCuentasCobro_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub realizarDevolucion()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New frmDevoluciones
            frm.IdCuentaCobro = r.Cells(id.DataPropertyName).Value
            frm.DocumentoCCobro = r.Cells(documento.DataPropertyName).Value
            frm.ConsecutivoCCobro = r.Cells(consecutivo.DataPropertyName).Value
            frm.Obra = r.Cells(obra.DataPropertyName).Value
            frm.Vendedor = r.Cells(vendedor.DataPropertyName).Value
            frm.FechaCreacion = r.Cells(fechaCreacion.DataPropertyName).Value
            frm.Proveedor = r.Cells(proveedor.DataPropertyName).Value
            frm.Encargado = r.Cells(encargado.DataPropertyName).Value
            frm.MdiParent = Me.MdiParent
            frm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verInforme()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)

            Dim ds As New DataSet
            ds.Tables.Add(objEncabezado.GetData(_tipoCuentaCobro, r.Cells(id.DataPropertyName).Value))
            ds.Tables.Add(objMovito.GetData(_tipoCuentaCobro, r.Cells(id.DataPropertyName).Value))
            ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "cCobro.xml"))

            Dim frm As New frmInformeCuentaCobro
            frm.Ds = ds
            frm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmListaCuentasCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mCuentaCobro As New ClsCuentaCobro
            If _vistaParaDevolucion = True Then
                mCuentaCobro.TraerTodas(dwItems.TablaDatos)
            Else
                If _tipoCuentaCobro = ClsEnums.TipoCuentaCobro.DESDE_OT Then
                    mCuentaCobro.TraerCuentasOT(dwItems.TablaDatos)
                ElseIf _tipoCuentaCobro = ClsEnums.TipoCuentaCobro.DIRECTAS Then
                    mCuentaCobro.TraerCuentasDirectas(dwItems.TablaDatos)
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
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    If _vistaParaDevolucion = True Then
                        menu.Items.Add("Realizar devolución", Nothing, AddressOf realizarDevolucion)
                    Else
                        If _tipoCuentaCobro = ClsEnums.TipoCuentaCobro.DESDE_OT Then
                            menu.Items.Add("Mostrar objeto y para", Nothing, AddressOf ObjetoyPara)
                        End If
                        menu.Items.Add("Ver cuenta de cobro", Nothing, AddressOf verCuentaCobro)
                        If CInt(r.Cells(idEstado.DataPropertyName).Value) = ClsEnums.Estados.ACTIVO Then
                            If _tipoCuentaCobro = ClsEnums.TipoCuentaCobro.DESDE_OT Then
                                menu.Items.Add("Realizar devolución", Nothing, AddressOf realizarDevolucion)
                            End If
                            menu.Items.Add("Ver informe", Nothing, AddressOf verInforme)
                            menu.Items.Add("Imprimir", Nothing)
                            menu.Items.Add("Anular", Nothing, AddressOf Anular)
                        End If
                    End If
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class