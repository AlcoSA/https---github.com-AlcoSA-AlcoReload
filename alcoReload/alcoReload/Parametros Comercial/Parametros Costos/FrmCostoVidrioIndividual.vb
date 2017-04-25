Imports ReglasNegocio

Public Class FrmCostoVidrioIndividual
#Region "Variables"
    Private loadCompleted As Boolean = False
#End Region
#Region "Procedimientos"
    Private Sub cargarVidrios()
        Try
            Dim mArticulo As New ClsArticulos
            Dim list As List(Of Articulo) = mArticulo.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.VIDRIO, ClsEnums.Estados.ACTIVO)
            cmbVidrio.DisplayMember = "Referencia"
            cmbVidrio.ValueMember = "Id"
            cmbVidrio.DatosVisibles = {"Referencia", "Descripcion"}
            cmbVidrio.DataSource = list
            cmbVidrio.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarColores()
        Try
            Dim mColor As New ClsAcabados
            Dim list As List(Of Acabado) = mColor.TraerxFamiliaMaterial(ClsEnums.FamiliasMateriales.VIDRIO).Where(Function(a)
                                                                                                                      Return a.IdEstado = ClsEnums.Estados.ACTIVO And
                                                                                                                      a.Id <> 32
                                                                                                                  End Function).ToList
            cmbColor.DisplayMember = "Prefijo"
            cmbColor.ValueMember = "Id"
            cmbColor.DatosVisibles = {"Prefijo", "Nombre"}
            cmbColor.DataSource = list
            cmbColor.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEspesores()
        Try
            cmbEspesor.DisplayMember = "Prefijo"
            cmbEspesor.ValueMember = "Id"
            cmbEspesor.DatosVisibles = {"Prefijo", "Descripcion"}
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVersiones()
        Try
            Dim mCostoVidrio As New ClsCostoVidrio
            Dim maxVersion As Integer = mCostoVidrio.TraerMaxVersion()
            Dim list As New List(Of Integer)
            For index = 1 To maxVersion
                list.Add(index)
            Next
            cmbVersion.DataSource = list
            cmbVersion.SelectedItem = Nothing
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
    Private Function validacionAgregar() As Boolean
        Try
            If cmbVidrio.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbVidrio, "Seleccione el vidrio")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbColor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbColor, "Seleccione el color")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbEspesor.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbEspesor, "Seleccione el espesor")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbVersion.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbVersion, "Seleccione la versión")
                Return False
            End If
            ErrorProvider.Clear()

            Dim conteoGrid As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CInt(r.Cells(col_idVidrio.Index).Value) = CInt(cmbVidrio.SelectedValue) And CInt(r.Cells(col_idColor.Index).Value) = CInt(cmbColor.SelectedValue) And
                    CInt(r.Cells(col_espesor.Index).Value) = CInt(cmbEspesor.SelectedValue) And CInt(r.Cells(col_version.Index).Value) = CInt(cmbVersion.SelectedValue) Then
                    conteoGrid += 1
                End If
            Next
            If conteoGrid > 0 Then
                MessageBox.Show("La combinación de items ya ha sido agregada")
                Return False
            End If

            Dim mCostoVidrio As New ClsCostoVidrio
            If mCostoVidrio.ExisteCosto(cmbVersion.SelectedValue, cmbVidrio.SelectedValue, cmbColor.SelectedValue, cmbEspesor.SelectedValue) Then
                MessageBox.Show("La combinación ya existe en base de datos")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmCostoVidrioIndividual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarVidrios()
            cargarColores()
            cargarEspesores()
            cargarVersiones()
            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbVidrio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVidrio.SelectedValueChanged
        Try
            If loadCompleted Then
                If cmbVidrio.SelectedItem IsNot Nothing Then
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
                    cmbEspesor.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If validacionAgregar() Then
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(col_idVidrio.Index).Value = cmbVidrio.SelectedValue
                r.Cells(col_vidrio.Index).Value = cmbVidrio.Text
                r.Cells(col_idColor.Index).Value = cmbColor.SelectedValue
                r.Cells(col_color.Index).Value = cmbColor.Text
                r.Cells(col_idEspesor.Index).Value = cmbEspesor.SelectedValue
                r.Cells(col_espesor.Index).Value = cmbEspesor.Text
                r.Cells(col_version.Index).Value = cmbVersion.SelectedValue
                r.Cells(col_costo.Index).Value = nudCosto.Value

                cmbVidrio.SelectedItem = Nothing
                cmbColor.SelectedItem = Nothing
                cmbEspesor.DataSource = Nothing
                cmbEspesor.SelectedItem = Nothing
                cmbVersion.SelectedItem = Nothing
                ErrorProvider.Clear()
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
            If dwItems.Rows.Count > 0 Then
                btnRecalcular.Enabled = True
                Return
            End If
            btnRecalcular.Enabled = False
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
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        Try
            If dwItems.Rows.Count > 0 Then
                Dim mCostoVidrio As New ClsCostoVidrio

                Dim conteoExistentes As Integer = 0
                For Each r As DataGridViewRow In dwItems.Rows
                    If mCostoVidrio.ExisteCosto(r.Cells(col_version.Index).Value, r.Cells(col_idVidrio.Index).Value,
                                                r.Cells(col_idColor.Index).Value, r.Cells(col_idEspesor.Index).Value) Then
                        conteoExistentes += 1
                    End If
                Next
                If conteoExistentes > 0 Then
                    MessageBox.Show("Una o más combinaciones ya existen en base de datos")
                    Return
                End If
                For Each r As DataGridViewRow In dwItems.Rows
                    mCostoVidrio.Insertar(My.Settings.UsuarioActivo, r.Cells(col_idVidrio.Index).Value, r.Cells(col_idEspesor.Index).Value,
                                          r.Cells(col_idColor.Index).Value, r.Cells(col_version.Index).Value, r.Cells(col_costo.Index).Value)
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dwItems.Rows.Clear()
                cmbVidrio.SelectedItem = Nothing
                cmbColor.SelectedItem = Nothing
                cmbEspesor.DataSource = Nothing
                cmbEspesor.SelectedItem = Nothing
                cmbVersion.SelectedItem = Nothing
                ErrorProvider.Clear()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class