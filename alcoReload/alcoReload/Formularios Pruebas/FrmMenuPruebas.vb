Public Class FrmMenuPruebas
    Private Sub btnedatagrid_Click(sender As Object, e As EventArgs) Handles btnedatagrid.Click
        Try
            Dim pdatagrid As New FrmPruebasNuevoDatagrid
            pdatagrid.MdiParent = Me
            pdatagrid.WindowState = FormWindowState.Maximized
            pdatagrid.Show()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub ParseadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParseadorToolStripMenuItem.Click
        Try
            Dim pparseador As New FrmPruebasEjecutor
            pparseador.MdiParent = Me
            pparseador.WindowState = FormWindowState.Maximized
            pparseador.Show()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub ColumnasDatagridviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnasDatagridviewToolStripMenuItem.Click
        Try
            Dim pcolumnas As New FrmPruebasColumnasGrid
            pcolumnas.MdiParent = Me
            pcolumnas.WindowState = FormWindowState.Maximized
            pcolumnas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub RTFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RTFToolStripMenuItem.Click
        Try
            Dim frtf As New FrmRTF
            frtf.MdiParent = Me
            frtf.WindowState = FormWindowState.Maximized
            frtf.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class