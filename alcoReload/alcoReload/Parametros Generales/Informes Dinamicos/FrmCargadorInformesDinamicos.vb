Imports ReglasNegocio
Public Class FrmCargadorInformesDinamicos
#Region "vars"
    Private _idmodulo As ClsEnums.ModulosAplicacion = ClsEnums.ModulosAplicacion.NA
#End Region
#Region "props"
    Public Property Modulo As ClsEnums.ModulosAplicacion
        Get
            Return _idmodulo
        End Get
        Set(value As ClsEnums.ModulosAplicacion)
            _idmodulo = value
        End Set
    End Property
#End Region
    Private Sub btninformesconsulta_CheckedChanged(sender As Object, e As EventArgs) Handles btnusuario_s.CheckedChanged
        Try
            If imimagenes.Images.Count > 0 Then
                If btnusuario_s.Checked Then
                    btnusuario_s.Image = imimagenes.Images.Item(0)
                    btnusuario_s.ToolTipText = "Informes Usuario"
                Else
                    btnusuario_s.Image = imimagenes.Images.Item(1)
                    btnusuario_s.ToolTipText = "Todos los Informes"
                End If
                CargarInformesPersonalizados()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CargarInformes()
        Try
            Dim minf As New ClsInformesDinamicos
            Dim listinf As List(Of InformeDinamico) = minf.TraerxModulo(_idmodulo)
            listinf.Insert(0, New InformeDinamico())
            Dim bsource As New BindingSource()
            bsource.DataSource = listinf
            cmbinformes.ComboBox.DisplayMember = "NombreInforme"
            cmbinformes.ComboBox.ValueMember = "Id"
            cmbinformes.ComboBox.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarInformesPersonalizados()
        Try
            dwItems.LimpiarGrupos()
            Dim infd As New ClsInformesDinamicosPersonalizados
            Dim listinf As List(Of InformeDinamicoPersonalizado) = Nothing
            If btnusuario_s.Checked Then
                listinf = infd.TraerxIdInformeyUsuario(Convert.ToInt32(cmbinformes.ComboBox.SelectedValue),
                                                       My.Settings.UsuarioActivo)
            Else
                listinf = infd.TraerxIdInforme(Convert.ToInt32(cmbinformes.ComboBox.SelectedValue))
            End If
            Dim inf As New InformeDinamicoPersonalizado
            inf.NombreInforme = "<Predeterminado>"
            listinf.Insert(0, inf)
            Dim bsource As New BindingSource()
            bsource.DataSource = listinf
            cmbinformespersonalizados.ComboBox.DisplayMember = "NombreInforme"
            cmbinformespersonalizados.ComboBox.ValueMember = "Id"
            cmbinformespersonalizados.ComboBox.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub FrmCargadorInformesDinamicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarInformes()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbinformes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbinformes.SelectedIndexChanged
        Try
            CargarInformesPersonalizados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnconsultar_click(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Convert.ToInt32(cmbinformes.ComboBox.SelectedValue) > 0 Then
                Dim inf_din As New ClsInformesDinamicos
                Dim diccionario As New Dictionary(Of String, Object)
                For Each c As Control In flpfiltros.Controls
                    If TypeOf c Is TextBox Then
                        diccionario.Add(c.Name, c.Text)
                    ElseIf TypeOf c Is NumericUpDown Then
                        diccionario.Add(c.Name, DirectCast(c, NumericUpDown).Value)
                    ElseIf TypeOf c Is CheckBox Then
                        diccionario.Add(c.Name, DirectCast(c, CheckBox).Checked)
                    ElseIf TypeOf c Is DateTimePicker Then
                        diccionario.Add(c.Name, DirectCast(c, DateTimePicker).Value)
                    End If
                Next
                dwItems.TablaDatos = inf_din.EjecutarProcedimientoInforme(DirectCast(cmbinformes.SelectedItem, InformeDinamico).NombreSP, diccionario)
            Else
                dwItems.TablaDatos = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbinformespersonalizados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbinformespersonalizados.SelectedIndexChanged
        Try
            fddFiltros.LimpiarFiltros()
            dwItems.Reiniciar_Grid()
            flpfiltros.Controls.Clear()
            Dim cb As ToolStripComboBox = DirectCast(sender, ToolStripComboBox)
            Dim btn As New Button
            btn.Text = "Consultar"
            AddHandler btn.Click, AddressOf btnconsultar_click
            If Convert.ToInt32(cb.ComboBox.SelectedValue) = 0 Then
                lbnombreinforme.Text = cmbinformes.Text
                Dim parinforme As New ClsParametrosInformesDinamicos
                Dim listp As List(Of ParametroInforme) = parinforme.TraerxIdInformeyEstado(Convert.ToInt32(cmbinformes.ComboBox.SelectedValue), ClsEnums.Estados.ACTIVO)
                For Each p In listp
                    Dim lb As New Label
                    lb.Text = p.Nombre
                    flpfiltros.Controls.Add(lb)
                    Dim d As New Dictionary(Of Integer, Integer)
                    d.Add(p.Id, 0)
                    Select Case p.TipoDato
                        Case ClsEnums.TiposDato.BOOLEANO
                            Dim ch As New CheckBox
                            ch.Name = p.NombreBD
                            ch.Tag = d
                            flpfiltros.Controls.Add(ch)
                        Case ClsEnums.TiposDato.FECHA
                            Dim dtp As New DateTimePicker
                            dtp.Name = p.NombreBD
                            dtp.Tag = d
                            flpfiltros.Controls.Add(dtp)
                        Case ClsEnums.TiposDato.NUMERICO
                            Dim nud As New NumericUpDown
                            nud.Name = p.NombreBD
                            nud.Tag = d
                            nud.Minimum = -999999999999
                            nud.Maximum = 999999999999
                            nud.Name = p.NombreBD
                            flpfiltros.Controls.Add(nud)
                        Case ClsEnums.TiposDato.TEXTO
                            Dim txt As New TextBox
                            txt.Name = p.NombreBD
                            txt.Tag = d
                            flpfiltros.Controls.Add(txt)
                    End Select
                Next
                flpfiltros.Controls.Add(btn)
            Else
                lbnombreinforme.Text = cb.Text
                Dim parinforme As New ClsValoresParametrosInforme
                Dim listp As List(Of ValorParametroInforme) = parinforme.TraerxIdInformeBase(Convert.ToInt32(cmbinformes.ComboBox.SelectedValue))
                For Each p In listp
                    Dim lb As New Label
                    lb.Text = p.Nombre
                    flpfiltros.Controls.Add(lb)
                    Dim d As New Dictionary(Of Integer, Integer)
                    d.Add(p.IdParametro, p.Id)
                    Select Case p.TipoDato
                        Case ClsEnums.TiposDato.BOOLEANO
                            Dim ch As New CheckBox
                            ch.Name = p.NombreBD
                            ch.Tag = d
                            ch.Checked = Convert.ToBoolean(Convert.ToInt32(p.Valor))
                            flpfiltros.Controls.Add(ch)
                        Case ClsEnums.TiposDato.FECHA
                            Dim dtp As New DateTimePicker
                            dtp.Name = p.NombreBD
                            dtp.Tag = d
                            dtp.Value = Convert.ToDateTime(p.Valor)
                            flpfiltros.Controls.Add(dtp)
                        Case ClsEnums.TiposDato.NUMERICO
                            Dim nud As New NumericUpDown
                            nud.Name = p.NombreBD
                            nud.Tag = d
                            nud.Minimum = -999999999999
                            nud.Maximum = 999999999999
                            nud.Value = Convert.ToDecimal(p.Valor)
                            flpfiltros.Controls.Add(nud)
                        Case ClsEnums.TiposDato.TEXTO
                            Dim txt As New TextBox
                            txt.Name = p.NombreBD
                            txt.Tag = d
                            txt.Text = p.Valor
                            flpfiltros.Controls.Add(txt)
                    End Select
                Next
                Dim mf As New ClsFiltrosInformePersonalizado
                Dim lfiltros As List(Of FiltroInformePersonalizado) = mf.TraerxIdInforme(Convert.ToInt32(cb.ComboBox.SelectedValue))
                For Each f As FiltroInformePersonalizado In lfiltros
                    If f.IdTipoValor = ClsEnums.TiposDato.FECHA Then
                        fddFiltros.AgregarFiltro(f.NombreColumna, f.Valor.Split("|")(0), f.Valor.Split("|")(1), f.IdTipoValor, f.IdTipoCoincidencia)
                    Else
                        fddFiltros.AgregarFiltro(f.NombreColumna, f.Valor, String.Empty, f.IdTipoValor, f.IdTipoCoincidencia)
                    End If
                Next
                Dim mg As New ClsGruposInformesPersonalizados
                Dim lgrupos As List(Of GrupoInformePersonalizado) = mg.TraerxIdInforme(Convert.ToInt32(cb.ComboBox.SelectedValue))
                For Each g As GrupoInformePersonalizado In lgrupos
                    dwItems.AgregarGrupo(g.NombreColumna)
                Next
                flpfiltros.Controls.Add(btn)
                btnconsultar_click(btn, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            cmbinformes.ComboBox.SelectedValue = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub guardar_nuevo_informe()
        Try
            Dim fpetd As New frmPeticionCadenaTexto
            If fpetd.ShowDialog() = DialogResult.OK Then
                If String.IsNullOrEmpty(fpetd.Dato) Then
                    MsgBox("Debe ingresar un nombre para el informe de lo contrario no podra guardarlo. Verifique la información", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            Dim inf As New ClsInformesDinamicosPersonalizados
            Dim idinf = inf.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(cmbinformes.ComboBox.SelectedValue),
                         dwItems.Total, fpetd.Dato, ClsEnums.Estados.ACTIVO)
            Dim parvar As New ClsValoresParametrosInforme
            For Each c As Control In flpfiltros.Controls
                If TypeOf c IsNot Label Then
                    Dim d As KeyValuePair(Of Integer, Integer) = DirectCast(c.Tag, Dictionary(Of Integer, Integer)).First()
                    If TypeOf c Is TextBox Then
                        parvar.Insertar(d.Key, idinf, c.Text)
                    ElseIf TypeOf c Is DateTimePicker Then
                        parvar.Insertar(d.Key, idinf, Convert.ToString(DirectCast(c, DateTimePicker).Value))
                    ElseIf TypeOf c Is NumericUpDown Then
                        parvar.Insertar(d.Key, idinf, Convert.ToString(DirectCast(c, NumericUpDown).Value))
                    ElseIf TypeOf c Is CheckBox Then
                        parvar.Insertar(d.Key, idinf, Convert.ToString(Convert.ToInt32(DirectCast(c, CheckBox).Checked)))
                    End If
                End If
            Next
            guardar_personalizaciones(idinf)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub guardar_personalizaciones(idinformepersonalizado As Integer)
        Try
            Dim filtro As New ClsFiltrosInformePersonalizado
            filtro.EliminarxIdInforme(idinformepersonalizado)
            For Each f In dwItems.Filtros
                filtro.Insertar(My.Settings.UsuarioActivo, idinformepersonalizado, f.TipoValor,
                                f.TipoCoincidencia, f.Nombre_Columna, f.Valor)
            Next
            Dim grupos As New ClsGruposInformesPersonalizados
            grupos.EliminarxIdInforme(idinformepersonalizado)
            For Each g In dwItems.Grupos
                grupos.Insertar(My.Settings.UsuarioActivo, idinformepersonalizado, g.Nombre_Columna)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs)
        Try
            If Convert.ToInt32(cmbinformespersonalizados.ComboBox.SelectedValue) > 0 Then
                Dim infp As InformeDinamicoPersonalizado = DirectCast(cmbinformespersonalizados.SelectedItem, InformeDinamicoPersonalizado)
                If Not infp.UsuarioCreacion.Equals(My.Settings.UsuarioActivo) Then
                    If MsgBox("Este informe ha sido creado por otro usuario, no puede modificarlo. ¿Desea guardar una copia?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        guardar_nuevo_informe()
                    Else
                        Exit Sub
                    End If
                Else
                    Dim fpetd As New frmPeticionCadenaTexto
                    fpetd.Dato = cmbinformespersonalizados.Text
                    If fpetd.ShowDialog() = DialogResult.OK Then
                        If String.IsNullOrEmpty(fpetd.Dato) Then
                            MsgBox("Debe ingresar un nombre para el informe de lo contrario no podra guardarlo. Verifique la información", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    End If
                    Dim inf As New ClsInformesDinamicosPersonalizados
                    Dim idinf As Integer = Convert.ToInt32(cmbinformespersonalizados.ComboBox.SelectedValue)
                    inf.Modificar(Convert.ToInt32(cmbinformespersonalizados.ComboBox.SelectedValue),
                                              My.Settings.UsuarioActivo, Convert.ToInt32(cmbinformes.ComboBox.SelectedValue),
                                            dwItems.Total, fpetd.Dato, ClsEnums.Estados.ACTIVO)
                    Dim parvar As New ClsValoresParametrosInforme
                    For Each c As Control In flpfiltros.Controls
                        If TypeOf c IsNot Label Then
                            'NOTA IMPORTANTE: EL KEY ES EL ID DEL PARAMETRO BASE, EL VALUE ES EL ID DEL PARAMETRO PERSONALIZADO
                            Dim d As KeyValuePair(Of Integer, Integer) = DirectCast(c.Tag, Dictionary(Of Integer, Integer)).First()
                            If TypeOf c Is TextBox Then
                                If d.Value = 0 Then
                                    parvar.Insertar(d.Key, idinf, c.Text)
                                Else
                                    parvar.Modificar(d.Value, d.Key,
                                                     idinf,
                                                     c.Text)
                                End If
                            ElseIf TypeOf c Is DateTimePicker Then
                                If d.Value = 0 Then
                                    parvar.Insertar(d.Key, idinf, Convert.ToString(DirectCast(c, DateTimePicker).Value))
                                Else
                                    parvar.Modificar(d.Value, d.Key,
                                                     idinf,
                                                     Convert.ToString(DirectCast(c, DateTimePicker).Value))
                                End If
                            ElseIf TypeOf c Is NumericUpDown Then
                                If d.Value = 0 Then
                                    parvar.Insertar(d.Key, idinf, Convert.ToString(DirectCast(c, NumericUpDown).Value))
                                Else
                                    parvar.Modificar(d.Value, d.Key,
                                                     idinf,
                                                     Convert.ToString(DirectCast(c, NumericUpDown).Value))
                                End If
                            ElseIf TypeOf c Is CheckBox Then
                                If d.Value = 0 Then
                                    parvar.Insertar(d.Key, idinf, Convert.ToString(Convert.ToInt32(DirectCast(c, CheckBox).Checked)))
                                Else
                                    parvar.Modificar(d.Value, d.Key,
                                                     idinf,
                                                     Convert.ToString(Convert.ToInt32(DirectCast(c, CheckBox).Checked)))
                                End If
                            End If
                        End If
                    Next
                    guardar_personalizaciones(idinf)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs)
        Try
            dwItems.ExportaraExcel()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs)
        Try
            dwItems.Imprimir()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnVistaprevia_Click(sender As Object, e As EventArgs)
        Try
            dwItems.Imprimir(True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmCargadorInformesDinamicos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportarword.Enabled = False
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf BtnGuardar_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf BtnGuardar_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Click, AddressOf BtnLimpiar_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnexportarExcel.Click, AddressOf btnExcel_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnExportarPdf.Click, AddressOf btnPdf_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnimprimir.Click, AddressOf btnImprimir_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnimprimir.Click, AddressOf btnImprimir_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnvistaprevia.Click, AddressOf btnVistaprevia_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmCargadorInformesDinamicos_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnexportarword.Enabled = True
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf BtnGuardar_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf BtnGuardar_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Click, AddressOf BtnLimpiar_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnexportarExcel.Click, AddressOf btnExcel_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnExportarPdf.Click, AddressOf btnPdf_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnimprimir.Click, AddressOf btnImprimir_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnimprimir.Click, AddressOf btnImprimir_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnvistaprevia.Click, AddressOf btnVistaprevia_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class