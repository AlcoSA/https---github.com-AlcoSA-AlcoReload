Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class FrmListaParaOrdenes


#Region "Variables"
    Private mContrato As clsContratos
    Private idCotizaDuplicada As Integer
    Private _listOfSelectedRows As List(Of DataGridViewRow)
    Private _listPara As List(Of String)
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
#End Region

#Region "Procedimientos"
    'Private Sub TomarMedidas()
    '    Try
    '        Dim r As DataGridViewRow = dwItem.SelectedRows(0)
    '        Dim tomamedidas As New FrmTomaMedidas
    '        tomamedidas.IdContrato = Convert.ToInt32(r.Cells(id.Index).Value)
    '        tomamedidas.MdiParent = Me.MdiParent
    '        tomamedidas.Show()
    '    Catch ex As Exception
    '        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
    '    End Try
    'End Sub
    Private Function validarNoRepetidos() As Boolean
        dwItem.EndEdit()
        validarNoRepetidos = False
        Try
            If _listOfSelectedRows.GroupBy(Function(a) a.Cells(Obra.Index).Value, Function(b) b.Cells(Cliente.Index).Value).Count > 1 Then Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Sub generarOp()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim utilserv As New ClsUtilidadesServidor
            Dim us As String = Trim(ClsInterbloqueos.ElementoBloqueado(Convert.ToInt32(r.Cells(id.Index).Value), ClsEnums.ModulosAplicacion.MODULO_GENERACION_ORDEN_PED))
            If String.IsNullOrEmpty(us) Or My.Settings.UsuarioActivo.Equals(us) Or My.Settings.Es_Desarrollador Then
                If Not My.Settings.Es_Desarrollador And String.IsNullOrEmpty(us) Then
                    ClsInterbloqueos.Bloquear(Convert.ToInt32(r.Cells(id.Index).Value),
                                              ClsEnums.ModulosAplicacion.MODULO_GENERACION_ORDEN_PED,
                                              My.Settings.UsuarioActivo)
                End If
                Dim frmGenerarOp As New frmGenerarOP
                With frmGenerarOp
                    .IdContrato = Convert.ToInt32(r.Cells(id.Index).Value)
                    .Tipo_Operacion = ClsEnums.TiOperacion.INSERTAR
                    .WindowState = FormWindowState.Maximized
                    .MdiParent = Me.MdiParent
                End With
                frmGenerarOp.Show()
            Else
                MsgBox("Este contrato esta siendo utilizado por el usuario: " &
                       utilserv.TraerNombreDirectorio(us), MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    'Private Sub NuevoOtrosi()
    '    Try
    '        Dim r As DataGridViewRow = dwItem.SelectedRows(0)
    '        Dim fotro As New FrmOtroSi
    '        fotro.IdContrato = Convert.ToInt32(r.Cells(id.Index).Value)
    '        fotro.nudvalor.Enabled = False
    '        If fotro.ShowDialog() = DialogResult.OK Then
    '            mContrato.t039_selectAll(dwItem.TablaDatos)
    '            fddFiltrado.TablaFuente = dwItem.TablaDatos
    '            cargarDatos(dwItem.TablaDatos)
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Sub
#End Region
    Private Sub FrmListaContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mContrato = New clsContratos
            mContrato.TraerParaOrdenesPedido(ClsEnums.Estados.CONTRATADO, dwItem.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    'Private Sub CambiarEstado()
    '    Try
    '        Dim r As DataGridViewRow = dwItem.SelectedRows(0)
    '        Dim fcambioes As New FrmCambioEstadoContratado
    '        fcambioes.IdContrato = r.Cells(id.Index).Value
    '        If fcambioes.ShowDialog() = DialogResult.OK Then
    '            mContrato.t039_selectAll(dwItem.TablaDatos)
    '            fddFiltrado.TablaFuente = dwItem.TablaDatos
    '            cargarDatos(dwItem.TablaDatos)
    '        End If
    '    Catch ex As Exception
    '        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
    '    End Try
    'End Sub
    Private Sub dwitem_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                dwItem.Rows(e.RowIndex).Selected = True
                menu.Items.Add("Generar OP", Nothing, AddressOf generarOp)
                'menu.Items.Add("Tomar Medidas", Nothing, AddressOf TomarMedidas)
                'menu.Items.Add("Otro Si", Nothing, AddressOf NuevoOtrosi)
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class