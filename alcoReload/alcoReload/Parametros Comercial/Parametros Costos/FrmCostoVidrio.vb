Imports ReglasNegocio

Public Class FrmCostoVidrio
#Region "Variables"
    Private versionActual As Integer
    Private loadCompleted As Boolean = False
#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Private Sub cargarVersionActual()
        Try
            Dim mCostoVidrio As New ClsCostoVidrio
            versionActual = mCostoVidrio.TraerMaxVersion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVidrios()
        Try
            Dim mArticulo As New ClsArticulos
            Dim listArticulos As List(Of Articulo) = mArticulo.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.VIDRIO, ClsEnums.Estados.ACTIVO).Where(Function(a) a.Id <> 838).ToList
            cmbVidrio.DisplayMember = "Referencia"
            cmbVidrio.DatosVisibles = {"Referencia", "Descripcion"}
            cmbVidrio.ValueMember = "Id"
            cmbVidrio.DataSource = listArticulos
            cmbVidrio.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarColores()
        Try
            Dim mAcabado As New ClsAcabados
            Dim listAcabados As List(Of Acabado) = mAcabado.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.VIDRIO).Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO And a.Id <> 32).ToList
            cmbColor.DisplayMember = "Prefijo"
            cmbColor.DatosVisibles = {"Prefijo", "Nombre"}
            cmbColor.ValueMember = "Id"
            cmbColor.DataSource = listAcabados
            cmbColor.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEspesores()
        Try
            Dim mEspesor As New ClsEspesores
            Dim listEspesor As List(Of Espesor) = mEspesor.TraerxEstado(ClsEnums.Estados.ACTIVO).Where(Function(a) a.Id <> 1).ToList
            cmbEspesor.DisplayMember = "Prefijo"
            cmbEspesor.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbEspesor.ValueMember = "Id"
            cmbEspesor.DataSource = listEspesor
            cmbEspesor.SelectedItem = Nothing
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
    Private Function validarAgregar() As Boolean
        Try
            If cmbVidrio.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbVidrio, "Debe seleccionar el vidrio")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbColor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbColor, "Debe seleccionar el color")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbEspesor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbEspesor, "Debe seleccionar el espesor")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function existeCombinacion(idVidrio As Integer, idColor As Integer, idEspesor As Integer) As Boolean
        Try
            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If Convert.ToInt32(r.Cells(col_idVidrio.Index).Value) = idVidrio And
                    Convert.ToInt32(r.Cells(col_idColor.Index).Value) = idColor And
                    Convert.ToInt32(r.Cells(col_idEspesor.Index).Value) = idEspesor Then
                    conteo += 1
                End If
            Next
            If conteo > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmCostoVidrio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarVersionActual()
            cargarVidrios()
            cargarColores()
            cargarEspesores()

            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbVidrio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVidrio.SelectedValueChanged
        Try
            If loadCompleted Then
                Dim mEspesor As New ClsEspesores
                Dim listEspesores As New List(Of Espesor)
                Dim vidrio As Articulo = cmbVidrio.SelectedItem
                If vidrio.Descripcion.Contains("LAMINADO") Then
                    listEspesores = mEspesor.TraerxEstado(ClsEnums.Estados.ACTIVO).Where(Function(a) a.Descripcion.Contains("+")).ToList
                Else
                    listEspesores = mEspesor.TraerxEstado(ClsEnums.Estados.ACTIVO).Where(Function(a) Not a.Descripcion.Contains("+") And
                                                                                             a.Id <> 1).ToList
                End If
                cmbEspesor.DataSource = listEspesores
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If validarAgregar() Then
                If existeCombinacion(cmbVidrio.SelectedValue, cmbColor.SelectedValue, cmbEspesor.SelectedValue) Then
                    Dim Vid As Articulo = cmbVidrio.SelectedItem
                    Dim Col As Acabado = cmbColor.SelectedItem
                    Dim Esp As Espesor = cmbEspesor.SelectedItem
                    MessageBox.Show("Ya existe la combinación " & Vid.Descripcion & " " & Col.Nombre & " " & Esp.Descripcion, "")
                    Return
                End If

                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                Dim vidrio As Articulo = cmbVidrio.SelectedItem
                Dim color As Acabado = cmbColor.SelectedItem
                Dim espesor As Espesor = cmbEspesor.SelectedItem

                r.Cells(col_idVidrio.Index).Value = vidrio.Id
                r.Cells(col_vidrio.Index).Value = vidrio.Descripcion
                r.Cells(col_idColor.Index).Value = color.Id
                r.Cells(col_color.Index).Value = color.Nombre
                r.Cells(col_idEspesor.Index).Value = espesor.Id
                r.Cells(col_espesor.Index).Value = espesor.Descripcion
                r.Cells(col_versionActual.Index).Value = versionActual
                r.Cells(col_nuevaVersion.Index).Value = versionActual + 1
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    dwItems.Rows(e.RowIndex).Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    menu.Show(Control.MousePosition)
                End If
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCargarCostos_Click(sender As Object, e As EventArgs) Handles btnCargarCostos.Click
        Try
            Dim frm As New FrmBuscarCostoVidrio
            If frm.ShowDialog() = DialogResult.OK Then
                For Each costo As costoVidrio In frm.ListAgregados
                    If Not existeCombinacion(costo.idArticulo, costo.idAcabado, costo.idEspesor) Then
                        Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                        r.Cells(col_idVidrio.Index).Value = costo.idArticulo
                        r.Cells(col_vidrio.Index).Value = costo.articulo
                        r.Cells(col_idColor.Index).Value = costo.idAcabado
                        r.Cells(col_color.Index).Value = costo.acabado
                        r.Cells(col_idEspesor.Index).Value = costo.idEspesor
                        r.Cells(col_espesor.Index).Value = costo.espesor
                        r.Cells(col_versionActual.Index).Value = costo.versionActual
                        r.Cells(col_nuevaVersion.Index).Value = versionActual + 1
                        r.Cells(col_costo.Index).Value = costo.costo
                    Else
                        MessageBox.Show("Ya existe la combinación " & costo.articulo & " " & costo.acabado & " " & costo.espesor, "")
                    End If
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        Try
            Dim mCostoVidrio As New ClsCostoVidrio
            For Each r As DataGridViewRow In dwItems.Rows
                mCostoVidrio.Insertar(My.Settings.UsuarioActivo, r.Cells(col_idVidrio.Index).Value,
                                      r.Cells(col_idEspesor.Index).Value, r.Cells(col_idColor.Index).Value,
                                      versionActual + 1, r.Cells(col_costo.Index).Value)
            Next
            MessageBox.Show("La información se ha guardado exitosamente", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.ColumnIndex = col_costo.Index Then
                    If Not IsNumeric(r.Cells(col_costo.Index).Value) Then
                        r.Cells(col_costo.Index).Value = String.Empty
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub


    Private Sub dwItems_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dwItems.RowsAdded
        Try
            btnRecalcular.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dwItems.RowsRemoved
        Try
            If dwItems.Rows.Count = 0 Then
                btnRecalcular.Enabled = False
            Else
                btnRecalcular.Enabled = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class