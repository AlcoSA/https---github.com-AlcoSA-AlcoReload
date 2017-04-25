Imports ReglasNegocio
Imports ReglasNegocio.movitoHijos
Imports Validaciones

Public Class FrmAddNuevoEspesor
#Region "Variables"
    Private _idCotiza As Integer
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curId As Integer
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
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mEspTemp As New ClsEspesorTemporal
            Dim list As List(Of espesorTemporal) = mEspTemp.TraerxIdCotiza(_idCotiza)
            list.ForEach(Sub(esp)
                             Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                             r.Cells(id.Index).Value = esp.Id
                             r.Cells(fechaCreacion.Index).Value = esp.FechaCreacion
                             r.Cells(usuarioCreacion.Index).Value = esp.UsuarioCreacion
                             r.Cells(prefijo.Index).Value = esp.Prefijo
                             r.Cells(descripcion.Index).Value = esp.Descripcion
                             r.Cells(usuarioModi.Index).Value = esp.UsuarioModificacion
                             r.Cells(fechaModi.Index).Value = esp.FechaModificacion
                             r.Cells(idEstado.Index).Value = esp.IdEstado
                             r.Cells(estado.Index).Value = esp.Estado
                         End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiar()
        Try
            tform = ClsEnums.TiOperacion.INSERTAR
            curId = 0
            txtPrefijo.Text = String.Empty
            txtDescripcion.Text = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            tform = ClsEnums.TiOperacion.MODIFICAR
            curId = r.Cells(id.Index).Value
            txtPrefijo.Text = r.Cells(prefijo.Index).Value
            txtDescripcion.Text = r.Cells(descripcion.Index).Value

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            If MessageBox.Show("¿Está seguro de eliminar el registro?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim r As DataGridViewRow = dwItems.SelectedRows(0)
                Dim mMovitoHijo As New ClsMovitoHijos
                If mMovitoHijo.TemporalesCotizados(_idCotiza, "ESPE", r.Cells(prefijo.Index).Value) > 0 Then
                    MsgBox("El artículo ya existe en una cotización, no se puede eliminar")
                    Return
                End If
                Dim mCostoVidrio As New ClsCostoVidrioTemporal
                Dim list As List(Of costoVidrioTemporal) = mCostoVidrio.TraerxEspesor(_idCotiza, True, r.Cells(id.Index).Value)
                For Each ct As costoVidrioTemporal In list
                    mCostoVidrio.ActualizarEstado(ct.Id, ClsEnums.Estados.ARCHIVADO)
                Next
                Dim mEspesorTemp As New ClsEspesorTemporal
                mEspesorTemp.ActualizarEstado(r.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                cargarInformacion()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            Dim mValidacion As New ClsValidaciones
            If Not mValidacion.TextBoxDigitado(txtPrefijo, ErrorProvider) Then
                Return False
            End If
            If Not mValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider) Then
                Return False
            End If
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim mEspTemp As New ClsEspesorTemporal
                Dim esp As espesorTemporal = mEspTemp.TraerConExistentesByPrefijo(_idCotiza, txtPrefijo.Text)
                If esp.Id <> 0 Then
                    ErrorProvider.SetError(txtPrefijo, "Ya existe un espesor temporal con este prefijo")
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
#End Region

    Private Sub FrmAddNuevoEspesor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If validacion() Then
                Dim mEspTemp As New ClsEspesorTemporal
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mEspTemp.Insertar(My.Settings.UsuarioActivo, txtPrefijo.Text, txtDescripcion.Text, _idCotiza, ClsEnums.Estados.ACTIVO)
                ElseIf ClsEnums.TiOperacion.MODIFICAR Then
                    mEspTemp.Modificar(curId, txtPrefijo.Text, txtDescripcion.Text, My.Settings.UsuarioActivo)
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
                cargarInformacion()
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
                    menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class