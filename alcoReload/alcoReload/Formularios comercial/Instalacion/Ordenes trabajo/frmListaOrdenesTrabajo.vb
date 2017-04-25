Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class frmListaOrdenesTrabajo
#Region "Variables"
    Private fuenteInicial As DataTable = Nothing
    Private objEncabezado As New Informes.datosInformesTableAdapters.sp_tc097_selectOrdenTrabajoXMLTableAdapter
    Private objMovito As New Informes.datosInformesTableAdapters.sp_tc098_selectByIdOrdenTrabajoXMLTableAdapter
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub ObjetoyPara()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim mOrdenTrabajo As New ClsOrdenTrabajo
            Dim idContrato As Integer = mOrdenTrabajo.TraerIDContratoxConsecutivo(r.Cells(idDocumento.DataPropertyName).Value, r.Cells(consecutivo.DataPropertyName).Value)
            Dim mContrato As New clsContratos
            Dim cont As contrato = mContrato.TraerObjetoYPara(idContrato)
            Dim info As New ContextMenuStrip
            info.Items.Add("Contrato: " & cont.nContrato)
            info.Items.Add("Objeto: " & cont.Objeto)
            info.Items.Add("Para: " & cont.Para)
            info.Show(MousePosition)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verOrdenTrabajo()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New frmVistaOrdenTrabajo
            frm.IdOrdenTrabajo = r.Cells(idOT.DataPropertyName).Value
            frm.IdDocumento = r.Cells(idDocumento.DataPropertyName).Value
            frm.Documento = r.Cells(documento.DataPropertyName).Value
            frm.Consecutivo = r.Cells(consecutivo.DataPropertyName).Value
            frm.Obra = r.Cells(obra.DataPropertyName).Value
            frm.Vendedor = r.Cells(vendedor.DataPropertyName).Value
            frm.Proveedor = r.Cells(proveedor.DataPropertyName).Value
            frm.FechaCreacion = Convert.ToDateTime(r.Cells(fechaCreacion.DataPropertyName).Value).ToShortDateString()
            frm.Notas = r.Cells(notas.DataPropertyName).Value

            If frm.ShowDialog() = DialogResult.OK Then
                frmListaOrdenesTrabajo_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Anular()
        Try
            If MessageBox.Show("¿Está seguro de anular la orden de trabajo seleccionada?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                If CInt(r.Cells(idEstado.DataPropertyName).Value) = ClsEnums.Estados.ANULADO Then
                    MessageBox.Show("La orden de trabajo ya ha sido anulada", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If CInt(r.Cells(idTipoOrden.DataPropertyName).Value) = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO Then
                        Dim mOrdenTrabajo As New ClsOrdenTrabajo
                        If mOrdenTrabajo.cuentasCobroRealizadas(r.Cells(idOT.DataPropertyName).Value) > 0 Then
                            MessageBox.Show("No se puede anular una orden de trabajo que tiene cuentas de cobro asociadas", "",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
                            mOrdenTrabajo.ActualizarEstado(r.Cells(idOT.DataPropertyName).Value, ClsEnums.Estados.ANULADO)
                            mMovitoOrdenTrabajo.ActualizarEstadoByOrdenTrabajo(r.Cells(idOT.DataPropertyName).Value, ClsEnums.Estados.ANULADO)
                            frmListaOrdenesTrabajo_Load(Nothing, Nothing)
                        End If
                    Else
                        Dim mOrdenTrabajo As New ClsOrdenTrabajo
                        Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
                        mOrdenTrabajo.ActualizarEstado(r.Cells(idOT.DataPropertyName).Value, ClsEnums.Estados.ANULADO)
                        mMovitoOrdenTrabajo.ActualizarEstadoByOrdenTrabajo(r.Cells(idOT.DataPropertyName).Value, ClsEnums.Estados.ANULADO)
                        frmListaOrdenesTrabajo_Load(Nothing, Nothing)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verInforme()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)

            Dim ds As New DataSet
            ds.Tables.Add(objEncabezado.GetData(r.Cells(idOT.DataPropertyName).Value, r.Cells(idTipoOrden.DataPropertyName).Value))
            ds.Tables.Add(objMovito.GetData(r.Cells(idOT.DataPropertyName).Value))
            ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "otInstalacion.xml"))

            Dim frm As New frmInformeOrdenTrabajo
            frm.Ds = ds
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Private Sub frmListaOrdenesTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mOrdenTrabajo As New ClsOrdenTrabajo
            mOrdenTrabajo.TraerTodos(dwItems.TablaDatos)
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
                    menu.Items.Add("Mostrar objeto y para", Nothing, AddressOf ObjetoyPara)
                    menu.Items.Add("Ver orden de trabajo", Nothing, AddressOf verOrdenTrabajo)
                    If CInt(r.Cells(idEstado.DataPropertyName).Value) = ClsEnums.Estados.ACTIVO Then
                        menu.Items.Add("Traspasar cantidades", Nothing, AddressOf verInforme)
                        menu.Items.Add("Ver informe", Nothing, AddressOf verInforme)
                        menu.Items.Add("Imprimir orden", Nothing)
                        menu.Items.Add("Anular", Nothing, AddressOf Anular)
                    End If
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class