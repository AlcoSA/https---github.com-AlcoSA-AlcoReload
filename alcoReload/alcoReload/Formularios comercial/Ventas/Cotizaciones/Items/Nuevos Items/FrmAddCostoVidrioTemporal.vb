Imports ReglasNegocio

Public Class FrmAddCostoVidrioTemporal
#Region "Variables"
    Private _idCotiza As Integer
    Private vid As articuloTemporal
    Private col As acabadoTemporal
    Private esp As espesorTemporal

    Private Sep As Char
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
#End Region
#Region "Procedimientos"
    Private Sub cargarVidrios()
        Try
            cmbVidrio.DisplayMember = "Referencia"
            cmbVidrio.ValueMember = "Id"
            cmbVidrio.DatosVisibles = {"Referencia", "Descripcion"}
            Dim mArtTemp As New ClsArticuloTemporal
            Dim listArtTemp As List(Of articuloTemporal) = mArtTemp.TraerConExistentes(_idCotiza, ClsEnums.FamiliasMateriales.VIDRIO)
            cmbVidrio.DataSource = listArtTemp
            cmbVidrio.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarColores()
        Try
            cmbColor.DisplayMember = "Prefijo"
            cmbColor.ValueMember = "Id"
            cmbColor.DatosVisibles = {"Prefijo", "Nombre"}
            Dim mAcabTemp As New ClsAcabadoTemporal
            Dim listAcabTemp As List(Of acabadoTemporal) = mAcabTemp.TraerconExistentes(_idCotiza, ClsEnums.FamiliasMateriales.VIDRIO)
            cmbColor.DataSource = listAcabTemp
            cmbColor.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEspesores()
        Try
            cmbEspesor.DisplayMember = "Prefijo"
            cmbEspesor.ValueMember = "Id"
            cmbEspesor.DatosVisibles = {"Prefijo", "Descripcion"}
            Dim mEspTemp As New ClsEspesorTemporal
            Dim listEspTemp As List(Of espesorTemporal) = mEspTemp.TraerConExistentes(_idCotiza)
            cmbEspesor.DataSource = listEspTemp
            cmbEspesor.SelectedValue = 0
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
                             r.Cells(vidrioTemporal.Index).Value = ct.VidrioTemporal
                             r.Cells(idVidrio.Index).Value = ct.IdVidrio
                             r.Cells(vidrio.Index).Value = ct.Vidrio
                             r.Cells(colorTemporal.Index).Value = ct.ColorTemporal
                             r.Cells(idColor.Index).Value = ct.IdColor
                             r.Cells(color.Index).Value = ct.Color
                             r.Cells(espesorTemporal.Index).Value = ct.EspesorTemporal
                             r.Cells(idEspesor.Index).Value = ct.IdEspesor
                             r.Cells(espesor.Index).Value = ct.Espesor
                             r.Cells(precioOriginal.Index).Value = ct.Costo
                             r.Cells(precio.Index).Value = ct.Costo
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            dwItems.Rows.Remove(r)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub seleccionarItemsActualizar()
        Try
            dwItems.EndEdit()
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
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
    Private Function validacionAgregar()
        Try
            If CInt(cmbVidrio.SelectedValue) = 0 Or CInt(cmbColor.SelectedValue) = 0 Or CInt(cmbEspesor.SelectedValue) = 0 Then
                MsgBox("Hay items sin seleccionar")
                Return False
            End If

            '-----------------------------------
            Dim conteoTemporales As Integer = 0
            If vid.Temporal = True Then
                conteoTemporales += 1
            End If
            If col.Temporal = True Then
                conteoTemporales += 1
            End If
            If esp.Temporal = True Then
                conteoTemporales += 1
            End If

            If conteoTemporales = 0 Then
                MsgBox("Ninguno de los items seleccionados es temporal")
                Return False
            End If

            '---------------------------------
            Dim mCostoVidrio As New ClsCostoVidrioTemporal
            Dim costo As costoVidrioTemporal = mCostoVidrio.TraerCostoEspecifico(_idCotiza, vid.Temporal, vid.Id, esp.Temporal, esp.IdDb,
                                     col.Temporal, col.IdDb)
            If costo.Id <> 0 Then
                MsgBox("La combinación de items ya tiene un precio registrado")
                Return False
            End If

            '--------------------------------
            Dim conteofilas As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CBool(r.Cells(vidrioTemporal.Index).Value) = vid.Temporal And CInt(r.Cells(idVidrio.Index).Value) = vid.Id And
                    CBool(r.Cells(colorTemporal.Index).Value) = col.Temporal And CInt(r.Cells(idColor.Index).Value) = col.IdDb And
                    CBool(r.Cells(espesorTemporal.Index).Value) = esp.Temporal And CInt(r.Cells(idEspesor.Index).Value) = esp.IdDb Then
                    conteofilas += 1
                End If
            Next
            If conteofilas > 0 Then
                MsgBox("Ya agregó esta combinación de items")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
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
    Private Sub FrmAddCostoVidrioTemporal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarVidrios()
            cargarColores()
            cargarEspesores()
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If validacionAgregar() Then
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(vidrioTemporal.Index).Value = vid.Temporal
                r.Cells(idVidrio.Index).Value = vid.Id
                r.Cells(vidrio.Index).Value = vid.Referencia
                r.Cells(colorTemporal.Index).Value = col.Temporal
                r.Cells(idColor.Index).Value = col.IdDb
                r.Cells(color.Index).Value = col.Prefijo
                r.Cells(espesorTemporal.Index).Value = esp.Temporal
                r.Cells(idEspesor.Index).Value = esp.IdDb
                r.Cells(espesor.Index).Value = esp.Prefijo
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbVidrio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVidrio.SelectedValueChanged
        Try
            vid = cmbVidrio.SelectedItem
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbColor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedValueChanged
        Try
            col = cmbColor.SelectedItem
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbEspesor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEspesor.SelectedValueChanged
        Try
            esp = cmbEspesor.SelectedItem
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is precio Then
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

            If dwItems.Columns(columnIndex) Is precio Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
                Return
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
                        mCostoVidrioTemp.Insertar(My.Settings.UsuarioActivo, _idCotiza, r.Cells(vidrioTemporal.Index).Value,
                                                  r.Cells(idVidrio.Index).Value, r.Cells(espesorTemporal.Index).Value,
                                                  r.Cells(idEspesor.Index).Value, r.Cells(colorTemporal.Index).Value,
                                                  r.Cells(idColor.Index).Value, r.Cells(precio.Index).Value, ClsEnums.Estados.ACTIVO)
                    End If
                    If Convert.ToBoolean(r.Cells(actualizar.Index).EditedFormattedValue) = True Then
                        mCostoVidrioTemp.Modificar(r.Cells(idCosto.Index).Value, r.Cells(precio.Index).Value)
                    End If
                Next
                MessageBox.Show("La información se ha guardado exitosamente")
                FrmAddCostoVidrioTemporal_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If r.Cells(idCosto.Index).Value Is Nothing Then
                    If e.Button = MouseButtons.Right Then
                        dwItems.Rows(e.RowIndex).Selected = True
                        Dim menu As New ContextMenuStrip
                        menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                        menu.Show(MousePosition)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class