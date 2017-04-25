Imports ReglasNegocio

Public Class FrmAddProgramacion
#Region "Variables"
    Private tform As ClsEnums.TiOperacion
    Private _idContrato As Integer
    Private _idPendiente As Integer
    Private _vendedorContrato As String
    Private _nit As String
    Private _codSucursal As String
    Private _constructora As String
    Private _obra As String
    Private _numContrato As String
    Private _region As String
    Private _fechaInicio As DateTime
    Private _fechaFin As DateTime
    Private _metros As Decimal
    Private _valorContrato As String
    Private _totalUnidades As String
    Private _totalPuntos As String

    Private loadCompleted As Boolean = False
    Private calendarioVisible As Boolean = False
    Private Sep As Char
#End Region
#Region "Propiedades"
    Public Property Operacion() As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property IdPendiente() As Integer
        Get
            Return _idPendiente
        End Get
        Set(ByVal value As Integer)
            _idPendiente = value
        End Set
    End Property
    Public Property VendedorContrato() As String
        Get
            Return _vendedorContrato
        End Get
        Set(ByVal value As String)
            _vendedorContrato = value
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
    Public Property CodigoSucursal() As String
        Get
            Return _codSucursal
        End Get
        Set(ByVal value As String)
            _codSucursal = value
        End Set
    End Property
    Public Property Constructora() As String
        Get
            Return _constructora
        End Get
        Set(ByVal value As String)
            _constructora = value
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
    Public Property NumeroContrato() As String
        Get
            Return _numContrato
        End Get
        Set(ByVal value As String)
            _numContrato = value
        End Set
    End Property
    Public Property RegionUno() As String
        Get
            Return _region
        End Get
        Set(ByVal value As String)
            _region = value
        End Set
    End Property
    Public Property FechaInicio() As DateTime
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As DateTime)
            _fechaInicio = value
        End Set
    End Property
    Public Property FechaFin() As DateTime
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As DateTime)
            _fechaFin = value
        End Set
    End Property
    Public Property Metros() As Decimal
        Get
            Return _metros
        End Get
        Set(ByVal value As Decimal)
            _metros = value
        End Set
    End Property
    Public Property ValorContrato() As String
        Get
            Return _valorContrato
        End Get
        Set(ByVal value As String)
            _valorContrato = value
        End Set
    End Property
    Public Property TotalPuntos() As String
        Get
            Return _totalPuntos
        End Get
        Set(ByVal value As String)
            _totalPuntos = value
        End Set
    End Property
    Public Property TotalUnidades() As String
        Get
            Return _totalUnidades
        End Get
        Set(ByVal value As String)
            _totalUnidades = value
        End Set
    End Property
    Private _listItems As DataTable
    Public Property ListItems() As DataTable
        Get
            Return _listItems
        End Get
        Set(ByVal value As DataTable)
            _listItems = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarConceptos()
        Try
            Dim mTipoObra As New ClsTiposObras
            Dim listTiposObras As List(Of tipoObra) = mTipoObra.TraerxEstado(ClsEnums.Estados.ACTIVO)
            DirectCast(dwItems.Columns(concepto.Index), DataGridViewComboBoxColumn).DisplayMember = "Descripcion"
            DirectCast(dwItems.Columns(concepto.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(concepto.Index), DataGridViewComboBoxColumn).DataSource = listTiposObras
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacion()
        Try
            lblVendedor.Text = _vendedorContrato
            txtNit.Text = _nit
            txtCodigoSucursal.Text = _codSucursal
            txtConstructora.Text = _constructora
            txtObra.Text = _obra
            txtNumeroContrato.Text = _numContrato
            txtRegion.Text = _region
            txtFechaInicio.Text = _fechaInicio.ToShortDateString
            txtFechaFin.Text = If(_fechaFin = Nothing, String.Empty, _fechaFin.ToShortDateString)
            txtMetros.Text = _metros
            txtValorContrato.Text = _valorContrato
            txtMetros.Text = _metros
            txtTotalUnidades.Text = _totalUnidades
            txtTotalPuntos.Text = _totalPuntos

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim und As Integer = 0
                Dim mts As Decimal = 0
                Dim pts As Integer = 0
                For Each obj As DataRow In _listItems.Rows
                    Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                    r.Cells(item_id.Index).Value = obj("idItem")
                    r.Cells(item_ubicacion.Index).Value = obj("ubicacion")
                    r.Cells(item_descripcion.Index).Value = obj("descripcion")
                    r.Cells(item_totalPuntos.Index).Value = obj("puntosTotales")
                    r.Cells(item_puntosSinPlanear.Index).Value = obj("puntos")
                    pts += Convert.ToInt32(obj("puntos"))
                    mts += Convert.ToDecimal(obj("metros"))
                    und += Convert.ToInt32(obj("unidades"))
                    DirectCast(r.Cells(concepto.Index), DataGridViewComboBoxCell).Value = Convert.ToInt32(obj("idConcepto"))
                Next

                txtUnidadesSelec.Text = und
                txtMetrosSelec.Text = Decimal.Round(mts, 2)
                txtPuntosSelec.Text = pts
            Else
                Dim mPlaneacion As New clsPlaneacion
                Dim list As New List(Of planeacion)
                If _idContrato <> 0 Then
                    list = mPlaneacion.TraerxIdContrato(_idContrato)
                Else
                    list = mPlaneacion.TraerxIdPendiente(_idPendiente)
                End If
                For Each obj As planeacion In list
                    Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                    r.Cells(id.Index).Value = obj.Id
                    r.Cells(item_id.Index).Value = obj.IdPadre
                    r.Cells(item_ubicacion.Index).Value = obj.Ubicacion
                    r.Cells(item_descripcion.Index).Value = obj.Descripcion
                    r.Cells(item_totalPuntos.Index).Value = obj.TotalPuntos
                    r.Cells(item_puntosSinPlanear.Index).Value = obj.PuntosSinPlanear
                    r.Cells(puntos.Index).Value = obj.Puntos
                    r.Cells(fechaSemana.Index).Value = obj.Semana
                    r.Cells(numeroSemana.Index).Value = obj.NumSemana
                    r.Cells(mes.Index).Value = obj.Mes
                    r.Cells(anio.Index).Value = obj.Anio
                    r.Cells(concepto.Index).Value = obj.IdConcepto
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarPlaneaciones(idContrato As Integer, idPendiente As Integer)
        Try
            'Dim mPlaneacion As New clsPlaneacion
            'Dim listPlaneacion As New List(Of planeacion)
            'If idContrato <> 0 Then
            '    listPlaneacion = mPlaneacion.TraerxIdContrato(idContrato)
            'Else
            '    listPlaneacion = mPlaneacion.TraerxIdPendiente(idPendiente)
            'End If
            'For Each plan As planeacion In listPlaneacion
            '    Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
            '    r.Cells(idProgramacion.Index).Value = plan.Id
            '    r.Cells(puntos.Index).Value = plan.Puntos
            '    r.Cells(fechaSemana.Index).Value = plan.Semana
            '    r.Cells(numeroSemana.Index).Value = plan.NumSemana
            '    r.Cells(mes.Index).Value = plan.Mes
            '    r.Cells(anio.Index).Value = plan.Anio
            '    r.Cells(concepto.Index).Value = plan.IdConcepto
            'Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminarFila()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If MessageBox.Show("Está seguro de eliminar la información", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim mPlaneacion As New clsPlaneacion
                mPlaneacion.ActualizarEstado(r.Cells(id.Index).Value, My.Settings.UsuarioActivo, ClsEnums.Estados.ARCHIVADO)
                dwItems.Rows.RemoveAt(r.Index)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validarInformacion() As Boolean
        Try
            Dim vacios As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If r.Cells(puntos.Index).Value Is Nothing Or r.Cells(puntos.Index).Value Is String.Empty Then
                    vacios += 1
                End If
                If r.Cells(fechaSemana.Index).Value Is Nothing Or r.Cells(fechaSemana.Index).Value Is String.Empty Then
                    vacios += 1
                End If
                If r.Cells(concepto.Index).Value Is Nothing Then
                    vacios += 1
                End If
            Next
            If vacios > 0 Then
                ErrorProvider.SetError(Panel, "Una o más filas contienen campos sin información")
                Return False
            End If
            ErrorProvider.Clear()

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim ptsSuperioresAItem As Integer = 0
                For Each r As DataGridViewRow In dwItems.Rows
                    If CInt(r.Cells(puntos.Index).Value) > CInt(r.Cells(item_puntosSinPlanear.Index).Value) Then
                        ptsSuperioresAItem += 1
                    End If
                Next
                If ptsSuperioresAItem > 0 Then
                    ErrorProvider.SetError(Panel, "Uno o más puntos programados superan los puntos disponibles del item")
                    Return False
                End If
                ErrorProvider.Clear()

                If CInt(lblPtsProgramados.Text) > CInt(txtPuntosSelec.Text) Then
                    ErrorProvider.SetError(Panel, "La totalidad de puntos programados supera los puntos de los items seleccionados (" &
                                                   txtPuntosSelec.Text & ")")
                    Return False
                End If
                ErrorProvider.Clear()
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub actualizarPtsProgramados()
        Try
            Dim ptsProgramados As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                ptsProgramados += Convert.ToInt32(r.Cells(puntos.Index).Value)
            Next
            lblPtsProgramados.Text = ptsProgramados
            If CInt(lblPtsProgramados.Text) > CInt(txtPuntosSelec.Text) Then
                lblPtsProgramados.ForeColor = Color.Red
            Else
                lblPtsProgramados.ForeColor = Color.Black
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmAddProgramacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarConceptos()
            cargarInformacion()
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                actualizarPtsProgramados()
            End If
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = fecha.Index Then
                    If calendarioVisible = False Then
                        Dim frm As New FrmCalendarioSemanas
                        frm.Anio = DateTime.Now.Year
                        Dim rec As Rectangle
                        rec = dwItems.GetCellDisplayRectangle(dwItems.CurrentCell.ColumnIndex, dwItems.CurrentCell.RowIndex, False)
                        frm.Location = New Point(rec.Location.X + dwItems.Location.X + Panel.Location.X + Me.Location.X + 8,
                                                 rec.Location.Y + dwItems.Location.Y + Panel.Location.Y + Me.Location.Y + r.Cells(fecha.Index).Size.Height + 30)
                        calendarioVisible = True
                        If frm.ShowDialog() = DialogResult.OK Then
                            r.Cells(fechaSemana.Index).Value = frm.Descripcion
                            r.Cells(numeroSemana.Index).Value = frm.Semana
                            r.Cells(mes.Index).Value = frm.FechaFin.Month
                            r.Cells(anio.Index).Value = frm.FechaFin.Year
                        End If
                        calendarioVisible = False
                    Else

                    End If
                Else
                    If e.Button = MouseButtons.Right Then
                        If tform = ClsEnums.TiOperacion.MODIFICAR Then
                            Dim menu As New ContextMenuStrip
                            dwItems.Rows(e.RowIndex).Selected = True
                            menu.Items.Add("Eliminar registro", Nothing, AddressOf eliminarFila)
                            menu.Show(MousePosition)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is puntos Then
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

            If dwItems.Columns(columnIndex) Is puntos Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            If loadCompleted Then
                Dim row As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.ColumnIndex = puntos.Index Then
                    If tform = ClsEnums.TiOperacion.INSERTAR Then
                        Dim ptsProgramados As Integer = 0
                        For Each r As DataGridViewRow In dwItems.Rows
                            ptsProgramados += Convert.ToInt32(r.Cells(puntos.Index).Value)
                        Next
                        actualizarPtsProgramados()

                        If ptsProgramados > Convert.ToInt32(txtPuntosSelec.Text) Then
                            ErrorProvider.SetError(Panel, "La totalidad de puntos programados supera los puntos de los items seleccionados (" &
                                                   txtPuntosSelec.Text & ")")
                            Exit Sub
                        Else
                            ErrorProvider.Clear()
                        End If

                        If CInt(row.Cells(puntos.Index).Value) > CInt(row.Cells(item_puntosSinPlanear.Index).Value) Then
                            ErrorProvider.SetError(Panel, "Uno o más puntos programados superan los puntos disponibles del item")
                            Exit Sub
                        Else
                            ErrorProvider.Clear()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            dwItems.EndEdit()
            If validarInformacion() Then
                ErrorProvider.Clear()
                For Each r As DataGridViewRow In dwItems.Rows
                    Dim mPlaneacion As New clsPlaneacion
                    If tform = ClsEnums.TiOperacion.INSERTAR Then
                        mPlaneacion.Insertar(My.Settings.UsuarioActivo, _idContrato, _idPendiente, r.Cells(item_id.Index).Value,
                                             lblVendedor.Text, r.Cells(puntos.Index).Value, r.Cells(fechaSemana.Index).Value,
                                             r.Cells(numeroSemana.Index).Value, r.Cells(mes.Index).Value, r.Cells(anio.Index).Value,
                                             r.Cells(concepto.Index).Value, ClsEnums.Estados.ACTIVO)
                    ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                        If r.Cells(id.Index).Value IsNot Nothing Or r.Cells(id.Index).Value IsNot String.Empty Then
                            mPlaneacion.Modificar(r.Cells(id.Index).Value, _idContrato, _idPendiente, r.Cells(puntos.Index).Value,
                                                  r.Cells(fechaSemana.Index).Value, r.Cells(numeroSemana.Index).Value, r.Cells(mes.Index).Value,
                                                  r.Cells(anio.Index).Value, r.Cells(concepto.Index).Value, My.Settings.UsuarioActivo)
                        End If
                    End If
                Next
                Dim mEstadoPlaneacion As New clsEstadosPlaneacion
                If _idContrato <> 0 Then
                    If mEstadoPlaneacion.ExistePlaneacion(_idContrato, _idPendiente) Then
                        mEstadoPlaneacion.actualizarxIdContrato(_idContrato, 0, ClsEnums.Estados.CON_PLANEACION)
                    Else
                        mEstadoPlaneacion.Insertar(_idContrato, _idPendiente, ClsEnums.Estados.CON_PLANEACION)
                    End If
                Else
                    If mEstadoPlaneacion.ExistePlaneacion(_idContrato, _idPendiente) Then
                        mEstadoPlaneacion.actualizarxIdPendiente(_idPendiente, 0, ClsEnums.Estados.SIN_CONT_PLANEADA)
                    Else
                        mEstadoPlaneacion.Insertar(_idContrato, _idPendiente, ClsEnums.Estados.SIN_CONT_PLANEADA)
                    End If
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class