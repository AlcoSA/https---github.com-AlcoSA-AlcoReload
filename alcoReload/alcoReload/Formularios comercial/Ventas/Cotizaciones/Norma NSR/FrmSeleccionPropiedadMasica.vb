Imports ReglasNegocio
Public Class FrmSeleccionPropiedadMasica

#Region "Variables"
    Private prop_masica As PropiedadMasica
    Private lista_base As List(Of PropiedadMasica)
    Private mprop_masica As ClsPropiedadesMasicas
#End Region

#Region "Propiedades"
    Public Property Propiedad_Masica As PropiedadMasica
        Get
            Return prop_masica
        End Get
        Set(value As PropiedadMasica)
            prop_masica = value
        End Set
    End Property
#End Region

#Region "Procedimientos"
    Private Sub CargarDatos(lista As List(Of PropiedadMasica))
        Try
            dwitems.Rows.Clear()
            For Each pm As PropiedadMasica In lista
                Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                r.Cells(id.Index).Value = pm.Id
                r.Cells(nombre.Index).Value = pm.Nombre
                r.Cells(descripcion.Index).Value = pm.Descripcion
                r.Cells(inercia.Index).Value = pm.Inercia
                r.Cells(modulo_seccion.Index).Value = pm.ModuloSeccion
            Next
            If dwitems.Rows.Count > 0 Then
                dwitems.Rows(0).Selected = True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

    Private Sub FrmSeleccionPropiedadMasica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            prop_masica = New PropiedadMasica
            mprop_masica = New ClsPropiedadesMasicas
            lista_base = New List(Of PropiedadMasica)
            lista_base = mprop_masica.TraerporEstado(ClsEnums.Estados.ACTIVO)
            CargarDatos(lista_base)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            prop_masica = lista_base.Find(Function(p) p.Id = Convert.ToInt32(dwitems.SelectedRows(0).Cells(id.Index).Value))
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub txtbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        Try
            CargarDatos(lista_base.Where(Function(m) m.Nombre.Contains(txtbusqueda.Text) Or m.Descripcion.Contains(txtbusqueda.Text)).ToList())
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwitems.CellMouseDoubleClick
        Try
            dwitems.Rows(e.RowIndex).Selected = True
            btnAceptar_Click(btnAceptar, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class