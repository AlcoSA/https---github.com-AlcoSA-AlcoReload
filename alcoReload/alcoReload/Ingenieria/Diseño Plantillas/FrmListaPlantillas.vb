Imports ReglasNegocio
Public Class FrmListaPlantillas

#Region "Variables"
    Private mplantillamodelos As ClsPlantillasModelos
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Procedimientos"
    Private Sub EditarPlantilla()
        Try
            Dim r As DataGridViewRow = dwitems.SelectedRows(0)
            Dim utilserv As New ClsUtilidadesServidor
            Dim us As String = ClsInterbloqueos.ElementoBloqueado(Convert.ToInt32(r.Cells(Id.Index).Value), ClsEnums.ModulosAplicacion.MODULO_PLANTILLAS)
            If String.IsNullOrEmpty(us) Or My.Settings.UsuarioActivo.Equals(us) Or My.Settings.Es_Desarrollador Then

                If Not My.Settings.Es_Desarrollador And String.IsNullOrEmpty(us) Then
                    ClsInterbloqueos.Bloquear(Convert.ToInt32(r.Cells(Id.Index).Value),
                                              ClsEnums.ModulosAplicacion.MODULO_PLANTILLAS,
                                              My.Settings.UsuarioActivo)
                End If
                Dim plantilla As New FrmPlantillaModelo()
                plantilla.OperacionActual = ClsEnums.TiOperacion.MODIFICAR
                plantilla.IdActual = Convert.ToInt32(r.Cells(Id.Index).Value)
                plantilla.MdiParent = Me.MdiParent
                plantilla.WindowState = FormWindowState.Maximized
                plantilla.Text = r.Cells(Nombre_Modelo.Index).Value
                plantilla.Show()
            Else
                MsgBox("Esta plantilla esta siendo utilizada por el usuario: " &
                       utilserv.TraerNombreDirectorio(us), MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ProbarPlantilla()
        Try
            Dim r As DataGridViewRow = dwitems.SelectedRows(0)
            Dim pruebaplantillas As New FrmTesteadorPlantillas
            pruebaplantillas.IdPlantilla = Convert.ToInt32(r.Cells(Id.Index).Value)
            pruebaplantillas.MdiParent = Me.MdiParent
            pruebaplantillas.WindowState = FormWindowState.Maximized
            pruebaplantillas.Show()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub DuplicarPlantilla()
        Try
            Dim r As DataGridViewRow = dwitems.SelectedRows(0)
            Dim plantilla As New FrmPlantillaModelo()
            plantilla.IdActual = Convert.ToInt32(r.Cells(Id.Index).Value)
            plantilla.OperacionActual = ClsEnums.TiOperacion.INSERTAR
            plantilla.DuplicarPlantilla = True
            plantilla.MdiParent = Me.MdiParent
            plantilla.WindowState = FormWindowState.Maximized
            plantilla.Show()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub impresion(sender As Object, e As EventArgs)
        Try
            dwitems.Imprimir()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub vistaPrevia(sender As Object, e As EventArgs)
        Try
            dwitems.Imprimir(True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            Dim btnsImprimir As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimprimir
            Dim btnimpresionrapida As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnsvistaprevia As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnvistaprevia
            AddHandler btnsImprimir.Click, AddressOf impresion
            AddHandler btnimpresionrapida.Click, AddressOf impresion
            AddHandler btnsvistaprevia.Click, AddressOf vistaPrevia
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = True
            Dim btnsImprimir As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimprimir
            Dim btnimpresionrapida As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnsvistaprevia As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnvistaprevia
            RemoveHandler btnsImprimir.Click, AddressOf impresion
            RemoveHandler btnimpresionrapida.Click, AddressOf impresion
            RemoveHandler btnsvistaprevia.Click, AddressOf vistaPrevia
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmListaPlantillas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mplantillamodelos = New ClsPlantillasModelos()
            Dim listaplantillas As List(Of PlantillaModelo) = mplantillamodelos.TraerTodos(dwitems.TablaDatos)
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwitems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwitems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                dwitems.Rows(e.RowIndex).Selected = True
                menu.Items.Add("Editar Plantilla", Nothing, AddressOf EditarPlantilla)
                menu.Items.Add("Probar Plantilla", Nothing, AddressOf ProbarPlantilla)
                menu.Items.Add("Duplicar Plantilla", Nothing, AddressOf DuplicarPlantilla)
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwitems_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwitems.CellMouseDoubleClick
        Try
            If e.RowIndex >= 0 Then
                dwitems.Rows(e.RowIndex).Selected = True
                EditarPlantilla()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class