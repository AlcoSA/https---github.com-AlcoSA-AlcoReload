Imports ReglasNegocio

Public Class FrmAddVidrioTemporal
#Region "Variables"
    Private _idCotiza As Integer
    Private loadCompleted As Boolean = False
    Private Sep As Char
    Private vid As Articulo
    Private col As acabadoTemporal
    Private esp As espesorTemporal
#End Region
#Region "Propiedades"
    Public Property IdCotizacion() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarVidrio()
        Try
            cmbVidrio.DisplayMember = "Referencia"
            cmbVidrio.ValueMember = "Id"
            cmbVidrio.DatosVisibles = {"Referencia", "Descripcion"}
            Dim mArticulo As New ClsArticulos
            Dim list As List(Of Articulo) = mArticulo.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.VIDRIO).Where(Function(a)
                                                                                                                          Return a.IdEstado = ClsEnums.Estados.ACTIVO
                                                                                                                      End Function).ToList
            cmbVidrio.DataSource = List
            cmbVidrio.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarColores()
        Try
            cmbColor.DisplayMember = "Prefijo"
            cmbColor.ValueMember = "IdDb"
            cmbColor.DatosVisibles = {"Prefijo", "Nombre"}
            Dim mAcabTemp As New ClsAcabadoTemporal
            Dim listAcabTemp As List(Of acabadoTemporal) = mAcabTemp.TraerconExistentes(_idCotiza, ClsEnums.FamiliasMateriales.VIDRIO)
            cmbColor.DataSource = listAcabTemp
            cmbColor.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEspesores()
        Try
            If cmbVidrio.SelectedItem IsNot Nothing Then
                cmbEspesor.DisplayMember = "Prefijo"
                cmbEspesor.DatosVisibles = {"Prefijo", "Descripcion"}
                cmbEspesor.ValueMember = "Id"
                Dim mEspesores As New ClsEspesorTemporal
                Dim list As List(Of espesorTemporal)
                Dim vidrio As Articulo = cmbVidrio.SelectedItem
                If vidrio.Descripcion.Contains("LAMINADO") Then
                    list = mEspesores.TraerConExistentes(_idCotiza).Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO And
                                                                              a.Descripcion.Contains("+") And a.Id <> 1).ToList
                Else
                    list = mEspesores.TraerConExistentes(_idCotiza).Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO And
                                                                              Not a.Descripcion.Contains("+") And a.Id <> 1).ToList
                End If
                cmbEspesor.DataSource = list
                cmbEspesor.SelectedItem = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mCostoVidTemp As New ClsCostoVidrioTemporal
            Dim list As List(Of costoVidrioTemporal) = mCostoVidTemp.TraerxIdCotiza(_idCotiza)
            list.ForEach(Sub(ct)
                             Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                             r.Cells(idCosto.Index).Value = ct.Id
                             r.Cells(idVidrio.Index).Value = ct.IdVidrio
                             r.Cells(vidrio.Index).Value = ct.Vidrio
                             r.Cells(idColor.Index).Value = ct.IdColor
                             r.Cells(color.Index).Value = ct.Color
                             r.Cells(idEspesor.Index).Value = ct.IdEspesor
                             r.Cells(espesor.Index).Value = ct.Espesor
                             r.Cells(precioOriginal.Index).Value = ct.Costo
                             r.Cells(precio.Index).Value = ct.Costo
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionAgregar() As Boolean
        Try
            If cmbVidrio.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbVidrio, "Debe seleccionar el vidrio")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbColor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(btnAgregarColor, "Debe seleccionar el color")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbEspesor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(btnAgregarEspesor, "Debe seleccionar el espesor")
                Return False
            End If
            ErrorProvider.Clear()

            Dim conteofilas As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CInt(r.Cells(idVidrio.Index).Value) = vid.Id And CInt(r.Cells(idColor.Index).Value) = col.IdDb And
                    CInt(r.Cells(idEspesor.Index).Value) = esp.IdDb Then
                    conteofilas += 1
                End If
            Next
            If conteofilas > 0 Then
                MsgBox("Ya agregó esta combinación de items")
                Return False
            End If

            If col.Temporal = False And esp.Temporal = False Then
                MsgBox("La combinación de no tiene ningún item temporal")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub seleccionarItemsActualizar()
        Try
            dwItems.EndEdit()

            Dim r As DataGridViewRow = dwItems.CurrentRow
            If r.Cells(idCosto.Index).Value IsNot Nothing Then
                If Convert.ToDecimal(r.Cells(precioOriginal.Index).Value) <> Convert.ToDecimal(r.Cells(precio.Index).Value) Then
                    r.Cells(actualizar.Index).Value = True
                Else
                    r.Cells(actualizar.Index).Value = False
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionFinal() As Boolean
        Try
            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If r.Cells(precio.Index).Value Is Nothing Or Convert.ToString(r.Cells(precio.Index).Value) = String.Empty Then
                    conteo += 1
                End If
            Next
            If conteo > 0 Then
                MsgBox("Uno o más costos están vacíos")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmAddVidrioTemporal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarVidrio()
            cargarColores()
            cargarInformacion()
            nudCosto.Value = 0
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbVidrio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVidrio.SelectedValueChanged
        Try
            If loadCompleted Then
                cargarEspesores()
                vid = cmbVidrio.SelectedItem
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbColor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedValueChanged
        If loadCompleted Then
            col = cmbColor.SelectedItem
        End If
    End Sub

    Private Sub cmbEspesor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEspesor.SelectedValueChanged
        Try
            If loadCompleted Then
                esp = cmbEspesor.SelectedItem
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregarColor_Click(sender As Object, e As EventArgs) Handles btnAgregarColor.Click
        Try
            Dim frm As New FrmAddNuevoAcabado
            frm.IdCotiza = _idCotiza
            frm.FamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO
            frm.ShowDialog()
            cargarColores()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregarEspesor_Click(sender As Object, e As EventArgs) Handles btnAgregarEspesor.Click
        Try
            Dim frm As New FrmAddNuevoEspesor
            frm.IdCotiza = _idCotiza
            frm.ShowDialog()
            cargarEspesores()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If validacionAgregar() Then
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(idVidrio.Index).Value = vid.Id
                r.Cells(vidrio.Index).Value = vid.Referencia
                r.Cells(vidrioTemporal.Index).Value = False
                r.Cells(idColor.Index).Value = col.IdDb
                r.Cells(color.Index).Value = col.Prefijo
                r.Cells(colorTemporal.Index).Value = col.Temporal
                r.Cells(idEspesor.Index).Value = esp.IdDb
                r.Cells(espesor.Index).Value = esp.Prefijo
                r.Cells(espesorTemporal.Index).Value = esp.Temporal
                r.Cells(precio.Index).Value = nudCosto.Value
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            seleccionarItemsActualizar()
            If validacionFinal() Then
                Dim mCostoVidrioTemp As New ClsCostoVidrioTemporal
                For Each r As DataGridViewRow In dwItems.Rows
                    If r.Cells(idCosto.Index).Value Is Nothing Then
                        mCostoVidrioTemp.Insertar(My.Settings.UsuarioActivo, _idCotiza, r.Cells(vidrioTemporal.Index).Value, r.Cells(idVidrio.Index).Value,
                                                  r.Cells(espesorTemporal.Index).Value, r.Cells(idEspesor.Index).Value, r.Cells(colorTemporal.Index).Value,
                                                  r.Cells(idColor.Index).Value, r.Cells(precio.Index).Value, ClsEnums.Estados.ACTIVO)
                    End If
                    If Convert.ToBoolean(r.Cells(actualizar.Index).EditedFormattedValue) = True Then
                        mCostoVidrioTemp.Modificar(r.Cells(idCosto.Index).Value, r.Cells(precio.Index).Value)
                    End If
                Next
                MessageBox.Show("La información se ha guardado exitosamente")
                FrmAddVidrioTemporal_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            seleccionarItemsActualizar()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex
            If dwItems.Columns(columnIndex) Is dwItems.Columns(precio.Index) Then
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

            If dwItems.Columns(columnIndex) Is dwItems.Columns(precio.Index) Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then e.Handled = True
                If Char.IsPunctuation(e.KeyChar) Then
                    If e.KeyChar <> "."c Then
                        e.Handled = True
                    Else
                        If dwItems.CurrentRow.Cells(columnIndex).EditedFormattedValue.ToString().Contains(".") Then
                            e.Handled = True
                        Else
                            e.Handled = False
                        End If
                    End If
                End If
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class