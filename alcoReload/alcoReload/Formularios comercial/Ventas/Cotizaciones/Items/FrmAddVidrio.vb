Imports ReglasNegocio

Public Class FrmAddVidrio
#Region "Variables"
    Private _idCotiza As Integer
    Private _tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _curid As Integer
    Private _listArticulos As List(Of articuloTemporal)
    Private _listColores As List(Of acabadoTemporal)
    Private _listEspesores As List(Of espesorTemporal)
    Private _vidrio As articuloTemporal
    Private _color As acabadoTemporal
    Private _espesor As espesorTemporal
    Private _ancho As Decimal
    Private _alto As Decimal
    Private _cantidad As Integer
    Private _piezasxUnidad As Decimal
    Private _descuento As Decimal
    Private _versionCostoVidrio As Integer
    Private _dTableTrabajos As DataTable
    Private _esVidrioTemporal As Boolean = False
    Private _esColorTemporal As Boolean = False
    Private _esEspesorTemporal As Boolean = False
    Private loadCompleted As Boolean = False
    Private esLaminado As Boolean = False
    Private Sep As Char
    Private tformTrabajos As ClsEnums.TiOperacion
    Private _costointalauni As Decimal = 0
#End Region
#Region "Propiedades"
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property tform() As ClsEnums.TiOperacion
        Get
            Return _tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            _tform = value
        End Set
    End Property
    Public Property CurId() As Integer
        Get
            Return _curid
        End Get
        Set(ByVal value As Integer)
            _curid = value
        End Set
    End Property
    Public Property ListArticulos() As List(Of articuloTemporal)
        Get
            Return _listArticulos
        End Get
        Set(ByVal value As List(Of articuloTemporal))
            _listArticulos = value
        End Set
    End Property
    Public Property ListColores() As List(Of acabadoTemporal)
        Get
            Return _listColores
        End Get
        Set(ByVal value As List(Of acabadoTemporal))
            _listColores = value
        End Set
    End Property
    Public Property ListEspesores() As List(Of espesorTemporal)
        Get
            Return _listEspesores
        End Get
        Set(ByVal value As List(Of espesorTemporal))
            _listEspesores = value
        End Set
    End Property
    Public Property Vidrio() As articuloTemporal
        Get
            Return _vidrio
        End Get
        Set(ByVal value As articuloTemporal)
            _vidrio = value
        End Set
    End Property
    Public Property Color() As acabadoTemporal
        Get
            Return _color
        End Get
        Set(ByVal value As acabadoTemporal)
            _color = value
        End Set
    End Property
    Public Property Espesor() As espesorTemporal
        Get
            Return _espesor
        End Get
        Set(ByVal value As espesorTemporal)
            _espesor = value
        End Set
    End Property
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property ancho() As Decimal
        Get
            Return _ancho
        End Get
        Set(ByVal value As Decimal)
            _ancho = value
        End Set
    End Property
    Public Property alto() As Decimal
        Get
            Return _alto
        End Get
        Set(ByVal value As Decimal)
            _alto = value
        End Set
    End Property
    Public Property piezasxUnidad() As Decimal
        Get
            Return _piezasxUnidad
        End Get
        Set(ByVal value As Decimal)
            _piezasxUnidad = value
        End Set
    End Property
    Public Property Factor As Decimal
        Get
            Return nudfactor.Value
        End Get
        Set(ByVal value As Decimal)
            nudfactor.Value = value
        End Set
    End Property
    Public Property descuento() As Decimal
        Get
            Return _descuento
        End Get
        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property
    Public Property esVidrioTemporal() As Boolean
        Get
            Return _esVidrioTemporal
        End Get
        Set(ByVal value As Boolean)
            _esVidrioTemporal = value
        End Set
    End Property
    Public Property esColorTemporal() As Boolean
        Get
            Return _esColorTemporal
        End Get
        Set(ByVal value As Boolean)
            _esColorTemporal = value
        End Set
    End Property
    Public Property esEspesorTemporal() As Boolean
        Get
            Return _esEspesorTemporal
        End Get
        Set(ByVal value As Boolean)
            _esEspesorTemporal = value
        End Set
    End Property
    Public Property VersionCostoVidrio() As Integer
        Get
            Return _versionCostoVidrio
        End Get
        Set(ByVal value As Integer)
            _versionCostoVidrio = value
        End Set
    End Property
    Public Property DTableTrabajos() As DataTable
        Get
            Return _dTableTrabajos
        End Get
        Set(ByVal value As DataTable)
            _dTableTrabajos = value
        End Set
    End Property
    Public Property CostoInstalacionUnitario As Decimal
        Get
            Return _costointalauni
        End Get
        Set(value As Decimal)
            _costointalauni = value
        End Set
    End Property

#End Region
#Region "Procedimientos"
    Private Sub cargarVidrios()
        Try
            cmbVidrio.DisplayMember = "Referencia"
            cmbVidrio.ValueMember = "Id"
            cmbVidrio.DatosVisibles = {"Referencia", "Descripcion"}
            cmbVidrio.DataSource = _listArticulos
            cmbVidrio.SelectedValue = _vidrio.Id
            vidLaminado()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarAcabados()
        Try
            cmbColor.DisplayMember = "Prefijo"
            cmbColor.ValueMember = "Id"
            cmbColor.DatosVisibles = {"Prefijo", "Nombre"}
            cmbColor.DataSource = _listColores
            cmbColor.SelectedValue = _color.Id
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEspesores()
        Try
            Dim list As List(Of espesorTemporal) = _listEspesores
            If esLaminado Then
                list = _listEspesores.Where(Function(a) a.Descripcion.Contains("+")).ToList
            Else
                list = _listEspesores.Where(Function(a) Not a.Descripcion.Contains("+")).ToList
            End If
            cmbEspesor.DisplayMember = "Descripcion"
            cmbEspesor.ValueMember = "Id"
            cmbEspesor.DataSource = list
            cmbEspesor.SelectedValue = _espesor.Id
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTrabajos()
        Try
            Dim mTrabajo As New ClsTrabajosItems
            Dim listTrabajos As List(Of trabajoItems) = mTrabajo.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.VIDRIO)
            cmbTrabajo.DisplayMember = "Prefijo"
            cmbTrabajo.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbTrabajo.ValueMember = "Id"
            cmbTrabajo.DataSource = listTrabajos
            cmbTrabajo.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub vidLaminado()
        Try
            Dim vid As articuloTemporal = cmbVidrio.SelectedItem
            If vid.Descripcion.Contains("LAMINA") Then
                esLaminado = True
            Else
                esLaminado = False
            End If
            cargarEspesores()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If cmbVidrio.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbVidrio, "Debe seleccionar el vidrio")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbColor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbColor, "Debe seleccionar el color de vidrio")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbEspesor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbEspesor, "Debe seleccionar el espesor")
                Return False
            End If
            ErrorProvider.Clear()
            If nudCantidad.Value = 0 Then
                ErrorProvider.SetError(nudCantidad, "La cantidad debe ser mayor a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()
            If nudAncho.Value = 0 Then
                ErrorProvider.SetError(nudAncho, "El ancho debe ser mayor a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()
            If nudAlto.Value = 0 Then
                ErrorProvider.SetError(nudAlto, "El alto debe ser mayor a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()
            If nudPiezasxUnidad.Value = 0 Then
                ErrorProvider.SetError(nudPiezasxUnidad, "El número de piezas por unidad debe ser mayor a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()

            Dim mCostoVidrio As New ClsCostoVidrio
            Dim mCostoVidTemp As New ClsCostoVidrioTemporal
            Dim vid As articuloTemporal = cmbVidrio.SelectedItem
            Dim col As acabadoTemporal = cmbColor.SelectedItem
            Dim esp As espesorTemporal = cmbEspesor.SelectedItem
            If vid.Temporal = True Or col.Temporal = True Or esp.Temporal = True Then
                If mCostoVidTemp.TraerCostoEspecifico(_idCotiza, vid.Temporal, vid.IdDb, esp.Temporal, esp.IdDb,
                                                   col.Temporal, col.IdDb).Costo = 0 Then
                    MsgBox("El vidrio que está agregando no tiene ningún precio")
                    Return False
                End If
            Else
                If mCostoVidrio.TraerCosto(vid.IdDb, esp.IdDb, col.IdDb, _versionCostoVidrio) = 0 Then
                    MsgBox("El vidrio que está agregando no tiene ningún precio")
                    Return False
                End If
            End If

            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If r.Cells(col_cantidad.Index).Value Is Nothing Or Convert.ToString(r.Cells(col_cantidad.Index).Value) = String.Empty Then
                    conteo += 1
                End If
            Next

            If conteo > 0 Then
                ErrorProvider.SetError(dwItems, "Una o más celdas de cantidad se encuentran vacías")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub guardarTrabajos()
        Try
            If tformTrabajos = ClsEnums.TiOperacion.INSERTAR Then
                If _curid <> 0 Then
                    Dim mMovitoTrabajos As New ClsMovitoTrabajosCotiza
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = _curid
                        row("cantidad") = r.Cells(col_cantidad.Index).Value

                        mMovitoTrabajos.Insertar(My.Settings.UsuarioActivo, _curid, r.Cells(col_idTrabajo.Index).Value,
                                                 r.Cells(col_cantidad.Index).Value, ClsEnums.Estados.ACTIVO)
                    Next
                Else
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = Nothing
                        row("cantidad") = r.Cells(col_cantidad.Index).Value
                    Next
                End If
            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                If _dTableTrabajos Is Nothing Then
                    _dTableTrabajos = New DataTable
                    _dTableTrabajos.Columns.Add("idTrabajo")
                    _dTableTrabajos.Columns.Add("idHijo")
                    _dTableTrabajos.Columns.Add("cantidad")
                End If
                If _curid <> 0 Then
                    Dim mMovitoTrabajo As New ClsMovitoTrabajosCotiza
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = _curid
                        row("cantidad") = r.Cells(col_cantidad.Index).Value
                        If r.Cells(col_id.Index).Value Is Nothing Or Convert.ToString(r.Cells(col_id.Index).Value) = String.Empty Then
                            mMovitoTrabajo.Insertar(My.Settings.UsuarioActivo, _curid, r.Cells(col_idTrabajo.Index).Value,
                                                    r.Cells(col_cantidad.Index).Value, ClsEnums.Estados.ACTIVO)
                        Else
                            mMovitoTrabajo.Modificar(r.Cells(col_id.Index).Value, r.Cells(col_cantidad.Index).Value)
                        End If
                    Next
                Else
                    For Each r As DataGridViewRow In dwItems.Rows
                        Dim row As DataRow = _dTableTrabajos.Rows.Add
                        row("idTrabajo") = r.Cells(col_idTrabajo.Index).Value
                        row("idHijo") = Nothing
                        row("cantidad") = r.Cells(col_cantidad.Index).Value
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMovitoTrabajos()
        Try
            Dim mCosto As New ClsCostoTrabajoItem
            If tformTrabajos = ClsEnums.TiOperacion.INSERTAR Then
                _dTableTrabajos = New DataTable
                _dTableTrabajos.Columns.Add("idTrabajo")
                _dTableTrabajos.Columns.Add("idHijo")
                _dTableTrabajos.Columns.Add("cantidad")
            End If
            If tformTrabajos = ClsEnums.TiOperacion.MODIFICAR Then
                If _curid <> 0 Then
                    dwItems.Rows.Clear()
                    Dim mMovitoTrabajo As New ClsMovitoTrabajosCotiza
                    Dim list As List(Of movitoTrabajoCotiza) = mMovitoTrabajo.TraerxIdHijo(_curid)
                    For Each mov As movitoTrabajoCotiza In list
                        Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                        r.Cells(col_id.Index).Value = mov.Id
                        r.Cells(col_idTrabajo.Index).Value = mov.IdTrabajo
                        r.Cells(col_prefijo.Index).Value = mov.Prefijo
                        r.Cells(col_descripcion.Index).Value = mov.Descripcion
                        r.Cells(col_unMedida.Index).Value = mov.UnidadMedida
                        r.Cells(col_costo.Index).Value = mCosto.TraerEspecifico(1, mov.IdTrabajo).Costo
                        r.Cells(col_cantidad.Index).Value = mov.Cantidad
                    Next
                ElseIf _dTableTrabajos IsNot Nothing Then
                    dwItems.Rows.Clear()
                    Dim mTrabajo As New ClsTrabajosItems
                    For Each row As DataRow In _dTableTrabajos.Rows
                        Dim trabajo As trabajoItems = mTrabajo.TraerxId(row.Item("idTrabajo"))
                        Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                        r.Cells(col_id.Index).Value = String.Empty
                        r.Cells(col_idTrabajo.Index).Value = trabajo.Id
                        r.Cells(col_prefijo.Index).Value = trabajo.Prefijo
                        r.Cells(col_descripcion.Index).Value = trabajo.Descripcion
                        r.Cells(col_unMedida.Index).Value = trabajo.UnidadMedida
                        r.Cells(col_costo.Index).Value = mCosto.TraerEspecifico(1, trabajo.Id).Costo
                        r.Cells(col_cantidad.Index).Value = row.Item("cantidad")
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminarTrabajos()
        Try
            Dim r As DataGridViewRow = dwItems.CurrentRow()
            If r.Cells(col_id.Index).Value Is Nothing OrElse r.Cells(col_id.Index).Value Is String.Empty Then
                dwItems.Rows.Remove(r)
            Else
                Dim mMovitoTrabajos As New ClsMovitoTrabajosCotiza
                mMovitoTrabajos.ActualizarEstado(r.Cells(col_id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                dwItems.Rows.Remove(r)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

    Private Sub FrmAddVidrio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarVidrios()
            cargarAcabados()
            nudAncho.Value = _ancho
            nudAlto.Value = _alto
            If tform = ClsEnums.TiOperacion.MODIFICAR Then
                nudCantidad.Value = _cantidad
                nudPiezasxUnidad.Value = _piezasxUnidad
            End If
            cargarTrabajos()
            If _curid <> 0 Then
                Dim mMovitoTrabajos As New ClsMovitoTrabajosCotiza
                Dim list As List(Of movitoTrabajoCotiza) = mMovitoTrabajos.TraerxIdHijo(_curid)
                If list.Count = 0 Then
                    tformTrabajos = ClsEnums.TiOperacion.INSERTAR
                Else
                    tformTrabajos = ClsEnums.TiOperacion.MODIFICAR
                End If
            Else
                If _dTableTrabajos Is Nothing Then
                    tformTrabajos = ClsEnums.TiOperacion.INSERTAR
                Else
                    tformTrabajos = ClsEnums.TiOperacion.MODIFICAR
                End If
            End If
            cargarMovitoTrabajos()
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            dwItems.EndEdit()
            If _dTableTrabajos IsNot Nothing Then
                _dTableTrabajos.Rows.Clear()
            End If
            If validacion() Then
                _vidrio = cmbVidrio.SelectedItem
                _color = cmbColor.SelectedItem
                _espesor = cmbEspesor.SelectedItem
                _cantidad = nudCantidad.Value
                _ancho = nudAncho.Value
                _alto = nudAlto.Value
                _piezasxUnidad = nudPiezasxUnidad.Value

                _esVidrioTemporal = _vidrio.Temporal
                _esColorTemporal = _color.Temporal
                _esEspesorTemporal = _espesor.Temporal
                guardarTrabajos()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudCantidad.GotFocus,
            nudAncho.GotFocus, nudAlto.GotFocus, nudPiezasxUnidad.GotFocus
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Value = 0 Then
                nud.ResetText()
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudCantidad.Leave,
            nudAncho.Leave, nudAlto.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0"
                nud.Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nudPiezasxUnidad_Leave(sender As Object, e As EventArgs) Handles nudPiezasxUnidad.Leave
        Try
            If nudPiezasxUnidad.Controls.Item(1).Text = "" Then
                nudPiezasxUnidad.Controls.Item(1).Text = "0.00"
                nudPiezasxUnidad.Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbVidrio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVidrio.SelectedValueChanged
        Try
            If loadCompleted Then
                vidLaminado()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregarTrabajo_Click(sender As Object, e As EventArgs) Handles btnAgregarTrabajo.Click
        Try
            If cmbTrabajo.SelectedItem IsNot Nothing Then
                Dim trabajo As trabajoItems = cmbTrabajo.SelectedItem
                Dim mCosto As New ClsCostoTrabajoItem
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(col_idTrabajo.Index).Value = trabajo.Id
                r.Cells(col_prefijo.Index).Value = trabajo.Prefijo
                r.Cells(col_descripcion.Index).Value = trabajo.Descripcion
                r.Cells(col_unMedida.Index).Value = trabajo.UnidadMedida
                r.Cells(col_costo.Index).Value = mCosto.TraerEspecifico(1, trabajo.Id).Costo
                cmbTrabajo.SelectedItem = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is col_cantidad Then
                Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                RemoveHandler dText.KeyPress, AddressOf dText_KeyPress
                AddHandler dText.KeyPress, AddressOf dText_KeyPress
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is col_cantidad Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
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
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminarTrabajos)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class