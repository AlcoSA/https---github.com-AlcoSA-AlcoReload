Imports ReglasNegocio
Imports Validaciones
Public Class FrmAddCondicion
#Region "Variables"
    Private _objCondiciones As New ClsCondicionCotiza
    Private _objGrupo As New ClsGruposCondiciones
    Private _valida As New ClsValidaciones
#End Region
#Region "Propiedades"
    Private _idCotizacion As Integer
    Public Property idCotizacion() As Integer
        Get
            Return _idCotizacion
        End Get
        Set(ByVal value As Integer)
            _idCotizacion = value
        End Set
    End Property
    Private _dwCondiciones As DataGridView
    Public Property dwCondiciones() As DataGridView
        Get
            Return _dwCondiciones
        End Get
        Set(ByVal value As DataGridView)
            _dwCondiciones = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Sub cargarGrupos()
        Try
            Dim listgrupos As List(Of grupoCondiones) = _objGrupo.selectAll()
            cmbGrupo.ValueMember = "id"
            cmbGrupo.DisplayMember = "Descripcion"
            cmbGrupo.DataSource = listgrupos.ToList()
            cmbGrupo.SelectedValue = 5
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
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
#End Region
#Region "Procedimientos formulario"
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If dwItems.Rows.Count = 0 Then
                MsgBox("No se ha agregado ninguna condición")
                Return
            Else
                For Each r As DataGridViewRow In dwItems.Rows
                    Dim newId As Integer = _objCondiciones.insert(My.Settings.UsuarioActivo, idCotizacion, r.Cells(col_Descripción.Index).Value,
                                                                  ClsEnums.Estados.ACTIVO, r.Cells(col_grupo.Index).Value)
                    Dim row As New DataGridViewRow
                    row = _dwCondiciones.Rows(dwCondiciones.Rows.Add)
                    row.Cells("idCondicion").Value = newId
                    row.Cells("Estado").Value = True
                    row.Cells("condicion").Value = r.Cells(col_Descripción.Index).Value
                    row.Cells("idGrupo").Value = r.Cells(col_idGrupo.Index).Value
                    row.Cells("Grupo").Value = r.Cells(col_grupo.Index).Value
                Next
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtCondicion_TextChanged(sender As Object, e As EventArgs) Handles txtCondicion.TextChanged
        Try
            ErrorProvider1.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmAddCondicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarGrupos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If txtCondicion.Text = String.Empty Then
                ErrorProvider1.SetError(txtCondicion, "Ingrese la condición")
                Return
            End If
            ErrorProvider1.Clear()

            Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
            r.Cells(col_idGrupo.Index).Value = cmbGrupo.SelectedValue
            r.Cells(col_grupo.Index).Value = cmbGrupo.Text
            r.Cells(col_Descripción.Index).Value = txtCondicion.Text

            cmbGrupo.SelectedValue = 5
            txtCondicion.Text = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                dwItems.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
#End Region
End Class