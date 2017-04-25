Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class FrmListaContratos

#Region "Variables"
    Private mContrato As clsContratos
    Private idCotizaDuplicada As Integer
    Private _listOfSelectedRows As List(Of DataGridViewRow)
    Private _listPara As List(Of String)
    Private _selectedId As Integer
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
#End Region

#Region "Procedimientos"
    Private Sub cargarContratos()
        Try
            mContrato = New clsContratos
            Dim dt As New DataTable
            mContrato.TraerTodos(dt)

            Dim filteredTable As DataTable = (From n In dt.AsEnumerable()
                                              Where n.Field(Of Int32)("idEstado") = ClsEnums.Estados.CONTRATADO OrElse
                                                  n.Field(Of Int32)("idEstado") = ClsEnums.Estados.ANULADO
                                              Select n).CopyToDataTable()
            dwItem.TablaDatos = filteredTable
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub TomarMedidas()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim tomamedidas As New FrmTomaMedidas
            tomamedidas.IdContrato = Convert.ToInt32(r.Cells(id.Index).Value)
            tomamedidas.MdiParent = Me.MdiParent
            tomamedidas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validarNoRepetidos() As Boolean
        dwItem.EndEdit()
        validarNoRepetidos = False
        Try
            If _listOfSelectedRows.GroupBy(Function(a) a.Cells(Obra.Index).Value, Function(b) b.Cells(Cliente.Index).Value).Count > 1 Then Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Function Modificar() As String
        Try
            Dim frmContract As New frmContratos
            With frmContract
                .curId = _selectedId
                .operacionActual = ClsEnums.TiOperacion.MODIFICAR
                .WindowState = FormWindowState.Maximized
            End With
            frmContract.Show()
            Return String.Empty
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub NuevoOtrosi()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim fotro As New FrmOtroSi
            fotro.IdContrato = Convert.ToInt32(r.Cells(id.Index).Value)
            fotro.nudvalor.Enabled = False
            If fotro.ShowDialog() = DialogResult.OK Then
                mContrato.TraerTodos(dwItem.TablaDatos)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarEnContratacion()
        Try
            mContrato = New clsContratos
            Dim listContrato As List(Of contrato) = mContrato.TraerTodos().Where(Function(a) a.IdEstado = ClsEnums.Estados.EN_CONTRATACION).ToList()
            Dim dTable As New DataTable
            dTable.Columns.Add("col_id")
            dTable.Columns.Add("col_idEstado")
            dTable.Columns.Add("col_estado")
            dTable.Columns.Add("col_documento")
            dTable.Columns.Add("col_cliente")
            dTable.Columns.Add("col_nombreObra")
            dTable.Columns.Add("col_valorContrato")
            For Each cont As contrato In listContrato
                Dim row As DataRow = dTable.Rows.Add()
                row.Item("col_id") = cont.Id
                row.Item("col_idEstado") = cont.IdEstado
                row.Item("col_estado") = cont.Estado
                row.Item("col_documento") = cont.nit
                row.Item("col_cliente") = cont.Cliente
                row.Item("col_nombreObra") = cont.obra
                row.Item("col_valorContrato") = cont.valorContrato
            Next
            dwContratacion.TablaDatos = dTable
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub contratar()
        Try
            If MessageBox.Show("¿Está seguro de pasar los registros seleccionados a CONTRATADO?", "",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                mContrato = New clsContratos
                Dim mDuracion As New ClsDuracionDuplicacion
                For Each r As DataGridViewRow In dwContratacion.Rows
                    If CBool(r.Cells(col_seleccion.Index).EditedFormattedValue) = True Then
                        Dim cont As contrato = mContrato.traerById(r.Cells(col_id.Index).Value)
                        mDuracion.InsertarFinDuplicacion(cont.Id, cont.fechaInicial, My.Settings.UsuarioActivo)
                        mContrato.ModificarEstadoContrato(r.Cells(col_id.Index).Value, ClsEnums.Estados.CONTRATADO, My.Settings.UsuarioActivo)
                    End If
                Next
                cargarEnContratacion()
                cargarContratos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#Region "Procedimientos Controles"
    Private Sub FrmListaContratos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            cargarContratos()
            cargarEnContratacion()
            dwItem.AutoGenerateColumns = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CambiarEstado()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim fcambioes As New FrmCambioEstadoContratado
            fcambioes.IdContrato = r.Cells(id.Index).Value
            If fcambioes.ShowDialog() = DialogResult.OK Then
                mContrato.TraerTodos(dwItem.TablaDatos)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwitem_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                dwItem.Rows(e.RowIndex).Selected = True
                _selectedId = dwItem.Rows(e.RowIndex).Cells(id.Index).Value
                menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                menu.Items.Add("Tomar Medidas", Nothing, AddressOf TomarMedidas)
                menu.Items.Add("Otro Si", Nothing, AddressOf NuevoOtrosi)
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwContratacion_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwContratacion.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                dwContratacion.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                If CBool(dwContratacion.Rows(e.RowIndex).Cells(col_seleccion.Index).EditedFormattedValue) = True Then
                    menu.Items.Add("Contratar", Nothing, AddressOf contratar)
                End If
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

End Class