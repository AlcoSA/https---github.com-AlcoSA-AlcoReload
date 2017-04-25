Imports ReglasNegocio
Imports ReglasNegocio.Contratos
Public Class frmEsquemasContratos

#Region "Variables"

    Private mformat As ClsCreacionFormatosAlco
    Private mcontratos As clsContratos
    Private curId As Integer = 0
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR

#End Region
#Region "Propiedades"
    Public Property FormatoActual As Integer
        Get
            Return curId
        End Get
        Set(value As Integer)
            curId = value
        End Set
    End Property

#End Region

#Region "Procedimientos de usuario"

#Region "Generales"
    ''' <summary>
    ''' Procedimiento que Carga los campos que se van a combinar con el texto
    ''' </summary>
    ''' <remarks></remarks>
    Sub cargarCampos()
        Try
            Dim crev As New ClsCreacionVariablesEsquemas
            crev.selectByEstado(ClsEnums.Estados.ACTIVO, editordocumentos.TablaVariables)
            editordocumentos.Descombinar()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub cargarFormatoscreados()
        Try
            btnminutas.DropDownItems.Clear()
            Dim mformat As New ClsCreacionFormatosAlco
            Dim tb As List(Of Formato) = mformat.traerTodos()
            For Each rw As Formato In tb
                Dim t As New ToolStripButton(rw.nombreArchivo)
                t.Tag = rw.Id
                t.Width = 200
                btnminutas.DropDownItems.Add(t)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub cargarTiposFormatos()
        Try
            Dim mformato As New ClsTiposFormato
            Dim lformatos As List(Of TipoFormato) = mformato.TraerporEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = lformatos
            cbtipoformato.ComboBox.DisplayMember = "Tipo"
            cbtipoformato.ComboBox.ValueMember = "Id"
            cbtipoformato.ComboBox.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

#End Region

#Region "Procedimientos de Controles"
    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnPrevia As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnvistaprevia
            Dim btnImpresion As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnImprimir As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimprimir
            Dim btnpdf As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnExportarPdf
            Dim btnword As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnexportarword
            btnsParcial.Enabled = False
            AddHandler btnguardar.Click, AddressOf Guardar_Click
            AddHandler btnsTotal.Click, AddressOf Guardar_Click
            AddHandler btnsLimpiar.Click, AddressOf Limpiar_Click
            AddHandler btnPrevia.Click, AddressOf btnvistaprev_Click
            AddHandler btnImpresion.Click, AddressOf btnvistaprev_Click
            AddHandler btnImprimir.Click, AddressOf btnimprimir_Click
            AddHandler btnpdf.Click, AddressOf btnpdf_Click
            AddHandler btnword.Click, AddressOf Word_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnPrevia As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnvistaprevia
            Dim btnImpresion As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnImprimir As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimprimir
            Dim btnpdf As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnExportarPdf
            Dim btnword As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnexportarword
            btnsParcial.Enabled = False
            RemoveHandler btnguardar.Click, AddressOf Guardar_Click
            RemoveHandler btnsTotal.Click, AddressOf Guardar_Click
            RemoveHandler btnsLimpiar.Click, AddressOf Limpiar_Click
            RemoveHandler btnPrevia.Click, AddressOf btnvistaprev_Click
            RemoveHandler btnImpresion.Click, AddressOf btnvistaprev_Click
            RemoveHandler btnImprimir.Click, AddressOf btnimprimir_Click
            RemoveHandler btnpdf.Click, AddressOf btnpdf_Click
            RemoveHandler btnword.Click, AddressOf Word_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub frmEsquemasContratos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            mformat = New ClsCreacionFormatosAlco
            mcontratos = New clsContratos
            cargarTiposFormatos()
            cargarCampos()
            cargarFormatoscreados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Limpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            txtnombredocumento.Enabled = True
            curId = 0
            tform = ClsEnums.TiOperacion.INSERTAR

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Guardar_Click(sender As System.Object, e As System.EventArgs)
        Try
            If String.IsNullOrEmpty(txtnombredocumento.Text) Then
                MsgBox("Debe ingresar el un nombre para el formato.", MsgBoxStyle.Critical)
                txtnombredocumento.Focus()
                Return
            End If
            If String.IsNullOrEmpty(editordocumentos.Cuerpo) Then
                MsgBox("No hay ningún formato para guardar. Verifique la información", MsgBoxStyle.Critical)
                Return
            End If
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                curId = mformat.insertar(Convert.ToInt32(cbtipoformato.ComboBox.SelectedValue), txtnombredocumento.Text, editordocumentos.Cuerpo, editordocumentos.Encabezado, editordocumentos.PiedePagina, editordocumentos.AltoEncabezado, editordocumentos.AltoPiedePagina, My.Settings.UsuarioActivo)
            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                mformat.update(curId, Convert.ToInt32(cbtipoformato.ComboBox.SelectedValue), txtnombredocumento.Text, editordocumentos.Cuerpo, editordocumentos.Encabezado, editordocumentos.PiedePagina, editordocumentos.AltoEncabezado, editordocumentos.AltoPiedePagina, My.Settings.UsuarioActivo)
            End If
            txtnombredocumento.Enabled = False
            tform = ClsEnums.TiOperacion.MODIFICAR
            MsgBox("El formato se ha guardado correctamente", MsgBoxStyle.Information)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnvistaprev_Click(sender As System.Object, e As System.EventArgs)
        Try
            editordocumentos.VistaPrevia()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnimprimir_Click(sender As System.Object, e As System.EventArgs)
        Try
            editordocumentos.Imprimir()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region

    Private Sub btnpdf_Click(sender As System.Object, e As System.EventArgs)
        Try
            Dim svg As New SaveFileDialog
            svg.FileName = "documento_alco.pdf"
            svg.Filter = "Adobe PDF (PDF (*.pdf)|*.pdf | Todos los Archivos (*.*) |*.*"
            If svg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                editordocumentos.GuardarArchivo(svg.FileName, ControlesPersonalizados.Editor_RTF.EditorRTF.TipoGuardado.ARCHIVO_PDF)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Word_Click(sender As Object, e As EventArgs)
        Try
            Dim svg As New SaveFileDialog
            svg.FileName = "documento_alco.rtf"
            svg.Filter = "Archivo de Word (Word (*.rtf)|*.rtf | Todos los Archivos (*.*) |*.*"
            If svg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                editordocumentos.GuardarArchivo(svg.FileName, ControlesPersonalizados.Editor_RTF.EditorRTF.TipoGuardado.ARCHIVO_WORD)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnminutas_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles btnminutas.DropDownItemClicked
        Try
            txtnombredocumento.Text = e.ClickedItem.Text
            curId = Convert.ToInt32(e.ClickedItem.Tag)
            Dim fm As Formato = mformat.TraerXId(curId)
            editordocumentos.Encabezado = fm.encabezado
            editordocumentos.Cuerpo = fm.cuerpo
            editordocumentos.PiedePagina = fm.piepagina
            editordocumentos.AltoEncabezado = fm.AltoEncabezado
            editordocumentos.AltoPiedePagina = fm.AltoPiePagina
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class

