Imports ReglasNegocio
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Reflection

Public Class FrmConectoresPlanos
#Region "Variables archivo excel"
    Private aplicacion As Excel.Application
    Private libro As Excel.Workbook
    Private hojas As New List(Of Excel.Worksheet)
    Private ruta As String
#End Region
#Region "Variables generales"
    Private _objConector As New ClsConector
    Private _objMovitoConector As New ClsMovitoConector
    Private _mensajeError As String
    Private _curid As Integer
    Private _selectedId As Integer
    Private _dwselected As New DataGridView
#End Region
#Region "Propieades"
    Private _tipoOperacion As ClsEnums.TiOperacion
    Public Property TipoOperacion() As ClsEnums.TiOperacion
        Get
            Return _tipoOperacion
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            _tipoOperacion = value
        End Set
    End Property

#End Region
#Region "Procedimientos de usuario"
    Public Sub cargarExcel()
        Try
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = “Seleccionar archivos”
                .Filter = “Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*”
                .Multiselect = False
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    bwCarga = New BackgroundWorker
                    bwCarga.WorkerSupportsCancellation = True
                    AddHandler bwCarga.DoWork, AddressOf bwCarga_DoWork
                    bwCarga.RunWorkerAsync("Cargado Hojas...")
                    ruta = .FileName
                    capturarLibro(.FileName)
                    CargarHojas()
                    If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
                End If
            End With

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try

    End Sub
    Public Sub ImportarExcel(dw As DataGridView)
        Try
            bwCarga = New BackgroundWorker
            bwCarga.WorkerSupportsCancellation = True
            AddHandler bwCarga.DoWork, AddressOf bwCarga_DoWork
            bwCarga.RunWorkerAsync("Cargado Información...")
            Dim _row As DataGridViewRow
            Dim sh As Excel.Worksheet = libro.ActiveSheet

            For i = 1 To sh.Rows.Count

                If sh.Cells(i, 1).Value IsNot Nothing Then

                    If InStr(sh.Cells(i, 1).Value.ToString(), "NOTAS GENERALES") > 0 Then
                        Exit For
                    End If
                    If Convert.ToBoolean(sh.Range("A" & i & ":" & "H" & i).MergeCells) = False Then

                        If sh.Cells(i, 1).Value.ToString() <> "NOMBRE" Then
                            _row = New DataGridViewRow
                            Dim _a As Integer = dw.Rows.Add()
                            Dim celda As New DataGridViewTextBoxCell
                            celda.MaxInputLength = CInt(sh.Cells(i, 7).Value)
                            If sh.Cells(i, 3).Value.ToString = "Numérico" Then
                                celda.Value = 0
                            Else
                                celda.Value = ""
                            End If
                            Dim a = sh.Cells(1, 2).Value
                            dw.Rows(_a).Cells(valorDefecto.Index) = celda
                            dw.Rows(_a).Cells(nombreCampo.Index).Value = sh.Cells(i, 1).Value
                            dw.Rows(_a).Cells(descripcion.Index).Value = sh.Cells(i, 2).Value
                            dw.Rows(_a).Cells(TipoDato.Index).Value = If(sh.Cells(i, 4).Value.ToString.Contains("AAAAMMDD"), "Fecha", sh.Cells(i, 3).Value)
                            dw.Rows(_a).Cells(Observaciones.Index).Value = sh.Cells(i, 4).Value
                            dw.Rows(_a).Cells(indObligatorio.Index).Value = If(sh.Cells(i, 5).Value.ToString.ToUpper = "SI", 1, 0)
                            dw.Rows(_a).Cells(posicionInicial.Index).Value = sh.Cells(i, 6).Value
                            dw.Rows(_a).Cells(posicionFinal.Index).Value = sh.Cells(i, 8).Value
                            dw.Rows(_a).Cells(longitud.Index).Value = sh.Cells(i, 7).Value
                            dw.Rows(_a).Cells(Decimales.Index).Value = 0
                            dw.Rows(_a).Cells(Formato.Index).Value = CrearFormato(dw.Rows(_a).Cells(TipoDato.Index).Value, sh.Cells(i, 7).Value)
                        End If
                    End If
                End If
            Next
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close() '            liberarRecursosExcel()
            bwCarga.CancelAsync()
            bwCarga.Dispose()
            bwCarga = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        Finally

        End Try
    End Sub
    Public Function CrearFormato(tipo As String, longitud As Integer, Optional decimales As Integer = 0) As String
        CrearFormato = String.Empty
        Try
            If tipo.Trim = "Numérico" Or tipo.Trim = "NUMERICO" Then
                Select Case decimales
                    Case Is = 0
                        CrearFormato = StrDup(longitud, "0")
                    Case Is > 0
                        CrearFormato = StrDup(longitud - decimales - 1, "0") & "." & StrDup(decimales, "0")
                End Select
            ElseIf tipo.Trim = "Fecha" Then
                CrearFormato = "yyyyMMdd"
            Else
                CrearFormato = StrDup(longitud, " ")
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Public Sub capturarLibro(ruta As String)
        Try
            aplicacion = New Excel.Application
            aplicacion.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable
            aplicacion.DisplayAlerts = True
            aplicacion.Visible = False
            libro = aplicacion.Workbooks.Open(ruta, , True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub liberarRecursosExcel()
        Try
            If libro IsNot Nothing Then
                libro.Close(False, ruta)
            End If
            If aplicacion IsNot Nothing Then
                aplicacion.Quit()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub CargarHojas()
        Try
            libro.Worksheets.Cast(Of Excel.Worksheet).ToList.ForEach(Sub(hoja)
                                                                         hojas.Add(hoja)
                                                                         listaHojas.Items.Add(hoja.Name)
                                                                     End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Function validadRequeridos() As Boolean
        validadRequeridos = False
        Try
            If String.IsNullOrEmpty(txtNombreConector.Text) Then
                _mensajeError = "El nombre del conector es obligatorio"
                Return True
            End If
            If dwconector.RowCount <= 0 Then
                _mensajeError = "El grid debe tener por lo menos un registro"
                Return True
            Else
                dwconector.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(R)
                                                                            If String.IsNullOrEmpty(R.Cells(Formato.Index).Value) Then
                                                                                _mensajeError = "Al Campo:" & R.Cells(nombreCampo.Index).Value.ToString & " le hace falta el formato"
                                                                                validadRequeridos = True
                                                                                Exit Sub
                                                                            End If
                                                                            If R.Cells(valorDefecto.Index).Value.ToString.Length > CInt(R.Cells(longitud.Index).Value) Then
                                                                                _mensajeError = "El valor por defecto del Campo:" & R.Cells(nombreCampo.Index).Value.ToString & " tiene más número de caracteres de los requeridos."
                                                                                validadRequeridos = True
                                                                                Exit Sub
                                                                            End If
                                                                            If Not IsNumeric(R.Cells(valorDefecto.Index).Value) And R.Cells(TipoDato.Index).Value.ToString = "Numérico" Then
                                                                                _mensajeError = "El valor por defecto del Campo:" & R.Cells(nombreCampo.Index).Value.ToString & "debe ser un valor numérico."
                                                                                validadRequeridos = True
                                                                                Exit Sub
                                                                            End If
                                                                            If R.Cells(TipoDato.Index).Value.ToString = "Numérico" Then
                                                                                If CDec(R.Cells(valorDefecto.Index).Value) < 0 Then
                                                                                    _mensajeError = "El valor por defecto del Campo:" & R.Cells(nombreCampo.Index).Value.ToString & "es un número negativo por favor verifique e intente nuevamente."
                                                                                    validadRequeridos = True
                                                                                    Exit Sub
                                                                                End If
                                                                            End If
                                                                        End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Public Sub limpiar()
        Try
            If _tipoOperacion = ClsEnums.TiOperacion.INSERTAR Then
                dwconector.Rows.Clear()
                txtNombreConector.Text = ""
            Else
                dwconectorconsulta.Rows.Clear()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonGuardar_Click(sender As Object, e As EventArgs)
        Try
            Select Case tbgeneral.SelectedIndex
                Case tpcombinar.TabIndex
                    Dim enl As New ClsEnlaceConectorControl
                    Dim enc_enl As New ClsEncabeEnlaceConector
                    If String.IsNullOrEmpty(txtnombreplano.Text) Then
                        MsgBox("Debe ingresar un nombre para la nueva configuración del conector", MsgBoxStyle.Critical)
                        Return
                    End If
                    If Convert.ToInt32(txtnombreplano.Tag) > 0 Then
                        enc_enl.Modificar(My.Settings.UsuarioActivo, txtnombreplano.Text,
                                     Convert.ToInt32(cmbconectores.SelectedValue), ClsEnums.Estados.ACTIVO,
                                          Convert.ToInt32(txtnombreplano.Tag))
                    Else
                        txtnombreplano.Tag = enc_enl.Insertar(My.Settings.UsuarioActivo, txtnombreplano.Text,
                                     Convert.ToInt32(cmbconectores.SelectedValue), ClsEnums.Estados.ACTIVO)
                    End If

                    For Each r As DataGridViewRow In dwitems.Rows
                        If Not String.IsNullOrEmpty(r.Cells(controlasociado.Index).Tag) Then
                            If Convert.ToInt32(r.Cells(idenlace.Index).Value) > 0 Then
                                enl.Modificar(Convert.ToInt32(r.Cells(idenlace.Index).Value), My.Settings.UsuarioActivo, Convert.ToInt32(txtnombreplano.Tag),
                                              Convert.ToInt32(r.Cells(idcon.Index).Value), Convert.ToInt32(r.Cells(tipocontrol.Index).Value),
                                              DirectCast(cmbformulario.SelectedItem, KeyValuePair(Of String, String)).Value, Convert.ToString(r.Cells(controlasociado.Index).Value),
                                              Convert.ToString(r.Cells(controlasociado.Index).Tag))
                            Else
                                r.Cells(idenlace.Index).Value = enl.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(txtnombreplano.Tag), Convert.ToInt32(r.Cells(idcon.Index).Value),
                                             Convert.ToInt32(r.Cells(tipocontrol.Index).Value), DirectCast(cmbformulario.SelectedItem, KeyValuePair(Of String, String)).Value,
                                             Convert.ToString(r.Cells(controlasociado.Index).Value),
                                              Convert.ToString(r.Cells(controlasociado.Index).Tag))
                            End If
                        End If
                    Next
                    MsgBox("Los elementos se han guardado correctamente.", MsgBoxStyle.Information)
                Case Else
                    If _tipoOperacion = ClsEnums.TiOperacion.INSERTAR Then
                        If Not validadRequeridos() Then
                            insert()
                            limpiar()
                        Else
                            MsgBox(_mensajeError, MsgBoxStyle.OkCancel, "Error campos requeridos")
                        End If
                    Else
                        dwconectorconsulta.EndEdit()
                        modificar()
                        limpiar()
                    End If
            End Select

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub insert()
        Try
            _curid = _objConector.insertar(txtNombreConector.Text, My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO)
            dwconector.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(A)
                                                                        _objMovitoConector.insertar(_curid, A.Cells(nombreCampo.Index).Value,
                                                                                                        A.Cells(descripcion.Index).Value,
                                                                                                        tipoDatos(A.Cells(TipoDato.Index).Value.ToString.Trim, A.Cells(Observaciones.Index).Value.ToString.Trim),
                                                                                                        A.Cells(Observaciones.Index).Value, CBool(A.Cells(indObligatorio.Index).Value),
                                                                                                        CInt(A.Cells(posicionInicial.Index).Value),
                                                                                                        CInt(A.Cells(posicionFinal.Index).Value),
                                                                                                        CInt(A.Cells(longitud.Index).Value),
                                                                                                        A.Cells(Formato.Index).Value,
                                                                                                        A.Cells(valorDefecto.Index).Value, CInt(A.Cells(Decimales.Index).Value),
                                                                                                    Convert.ToBoolean(A.Cells(autoincremento.Index).Value))
                                                                    End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub modificar()
        Try
            dwconectorconsulta.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(A)
                                                                                _objMovitoConector.update(CInt(A.Cells(id1.Index).Value),
                                                                                                     A.Cells(valorDefecto1.Index).Value,
                                                                                                     CInt(A.Cells(decimales1.Index).Value),
                                                                                                    Convert.ToBoolean(A.Cells(autoincrement.Index).Value))
                                                                            End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Function tipoDatos(Tipo As String, detalle As String) As ClsEnums.TiposDato
        Try
            Select Case Tipo
                Case Is = "Numérico"
                    Return ClsEnums.TiposDato.NUMERICO
                Case Is = "Alfanumérico"
                    If InStr(detalle, "AAAAMMDD") > 0 Then
                        Return ClsEnums.TiposDato.FECHA
                    Else
                        Return ClsEnums.TiposDato.TEXTO
                    End If
                Case Is = "Fecha"
                    Return ClsEnums.TiposDato.FECHA
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
#End Region
#Region "Procedimientos Controles"
    Private Sub btnabrirconector_Click(sender As Object, e As EventArgs) Handles btnabrirconector.Click
        Try
            cargarExcel()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmConectoresPlanos_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            liberarRecursosExcel()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub listaHojas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaHojas.SelectedIndexChanged
        Try
            dwconector.Rows.Clear()
            hojas.Where(Function(a) a.Name = listaHojas.SelectedItem.ToString).Cast(Of Excel.Worksheet).First().Activate()
            ImportarExcel(dwconector)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmConectoresPlanos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnimpresion.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnimprimir.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf btonGuardar_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf btonGuardar_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf btonGuardar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmConectoresPlanos_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnimpresion.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnimprimir.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnvistaprevia.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf btonGuardar_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf btonGuardar_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf btonGuardar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub Limpiar_Click(sender As Object, e As EventArgs)
        Try
            Select Case tbgeneral.SelectedIndex
                Case tpcombinar.TabIndex
                    cmbconectores.SelectedValue = 0
                Case Else
                    limpiar()
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tbgeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbgeneral.SelectedIndexChanged
        Try
            Select Case tbgeneral.SelectedIndex
                Case Is = tbConsulta.TabIndex
                    _tipoOperacion = ClsEnums.TiOperacion.MODIFICAR
                    dwConectores.Rows.Clear()
                    _objConector.SelectAll().ToList.ForEach(Sub(a)
                                                                Dim itm As New DataGridViewRow
                                                                itm = dwConectores.Rows(dwConectores.Rows.Add())
                                                                itm.Cells(idConector.Index).Value = a.Id
                                                                itm.Cells(Conector.Index).Value = a.descripcion
                                                            End Sub)
                Case Is = tbAdicion.TabIndex
                    _tipoOperacion = ClsEnums.TiOperacion.INSERTAR
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bwCarga_DoWork(sender As Object, e As DoWorkEventArgs)
        Try
            Dim carga As New FrmCargaProceso
            carga.Proceso = e.Argument
            carga.lbproceso.Font = New Font("Arial", 10.0F, FontStyle.Bold)
            Application.Run(carga)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwcon_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwconector.EditingControlShowing, dwconectorconsulta.EditingControlShowing
        Try
            _dwselected = DirectCast(sender, DataGridView)
            ' referencia a la celda  
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try

    End Sub
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If e.KeyChar = vbBack Then
                e.Handled = False
                Exit Sub
            End If
            Dim tx As TextBox = DirectCast(sender, TextBox)
            Select Case _dwselected.CurrentCell.OwningColumn.Name
                Case Is = "Decimales"
                    If Not IsNumeric(e.KeyChar.ToString) Then
                        e.Handled = True
                        Exit Sub
                    End If
                    If CInt(e.KeyChar.ToString) >
                        CInt(_dwselected.Rows(_dwselected.CurrentRow.Index).Cells(longitud.Index).Value) Then
                        e.Handled = True
                        Exit Sub
                    End If
                    If Not Regex.IsMatch(e.KeyChar, "^[0-9]$") And Not _dwselected.Rows(_dwselected.CurrentCell.RowIndex).Cells(TipoDato.Index).Value.ToString = "Numérico" Then
                        e.Handled = True
                    End If
                    If CInt(CInt(If(tx.Text = String.Empty, 0, tx.Text)) & e.KeyChar) > (CInt(_dwselected.Rows(_dwselected.CurrentRow.Index).Cells(longitud.Index).Value) - 2) Then
                        e.Handled = True
                    End If
                Case Is = "valorDefecto"
                    If _dwselected.Rows(_dwselected.CurrentCell.RowIndex).Cells(TipoDato.Index).Value.ToString = "Numérico" And
                    Not Regex.IsMatch(e.KeyChar, "^[0-9]$") Then
                        e.Handled = True
                    End If
                    If _dwselected.Rows(_dwselected.CurrentCell.RowIndex).Cells(TipoDato.Index).Value.ToString = "Fecha" And
                    Not Regex.IsMatch(e.KeyChar, "^[0-9]$") Then
                        e.Handled = True
                    End If
                Case Is = "decimales1"
                    If Not IsNumeric(e.KeyChar.ToString) Then
                        e.Handled = True
                        Exit Sub
                    End If
                    If CInt(e.KeyChar.ToString) >
                        CInt(_dwselected.Rows(_dwselected.CurrentRow.Index).Cells(longitud1.Index).Value) Then
                        e.Handled = True
                        Exit Sub
                    End If
                    If Not Regex.IsMatch(e.KeyChar, "^[0-9]$") And Not _dwselected.Rows(_dwselected.CurrentCell.RowIndex).Cells(TipoDato1.Index).Value.ToString = "Numérico" Then
                        e.Handled = True
                    End If
                    If CInt(CInt(If(tx.Text = String.Empty, 0, tx.Text)) & e.KeyChar) > (CInt(_dwselected.Rows(_dwselected.CurrentRow.Index).Cells(longitud1.Index).Value) - 2) Then
                        e.Handled = True
                    End If
                Case Is = "valorDefecto1"
                    If _dwselected.Rows(_dwselected.CurrentCell.RowIndex).Cells(TipoDato1.Index).Value.ToString = "Numérico" And
                    Not Regex.IsMatch(e.KeyChar, "^[0-9]$") Then
                        e.Handled = True
                    End If
                    If _dwselected.Rows(_dwselected.CurrentCell.RowIndex).Cells(TipoDato1.Index).Value.ToString = "Fecha" And
                    Not Regex.IsMatch(e.KeyChar, "^[0-9]$") Then
                        e.Handled = True
                    End If
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwcon_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwconector.CellEndEdit, dwconectorconsulta.CellEndEdit
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If dw.Columns(e.ColumnIndex) Is Decimales Then
                dwconector.Rows(e.RowIndex).Cells(Formato.Index).Value = CrearFormato(dwconector.Rows(dwconector.CurrentCell.RowIndex).Cells(TipoDato.Index).Value.ToString,
                                                                   dwconector.Rows(dwconector.CurrentCell.RowIndex).Cells(longitud.Index).Value.ToString,
                                                                   dwconector.Rows(dwconector.CurrentCell.RowIndex).Cells(Decimales.Index).Value.ToString)
            ElseIf dw.Columns(e.ColumnIndex) Is decimales1 Then
                dwconectorconsulta.Rows(e.RowIndex).Cells(formato1.Index).Value = CrearFormato(dwconectorconsulta.Rows(dwconectorconsulta.CurrentCell.RowIndex).Cells(TipoDato1.Index).Value.ToString,
                                                                   dwconectorconsulta.Rows(dwconectorconsulta.CurrentCell.RowIndex).Cells(longitud1.Index).Value.ToString,
                                                                   dwconectorconsulta.Rows(dwconectorconsulta.CurrentCell.RowIndex).Cells(decimales1.Index).Value.ToString)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwConectores_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwConectores.CellMouseDown
        Try
            If e.RowIndex >= 0 Then
                dwconectorconsulta.Rows.Clear()
                bwCarga = New BackgroundWorker
                bwCarga.WorkerSupportsCancellation = True
                AddHandler bwCarga.DoWork, AddressOf bwCarga_DoWork
                bwCarga.RunWorkerAsync("Cargado datos...")
                _curid = CInt(dwConectores.Rows(e.RowIndex).Cells(idConector.Index).Value)
                _objMovitoConector.SelectAllByIdConector(CInt(_curid)).ToList.ForEach(Sub(itm)
                                                                                          Dim rw As New DataGridViewRow
                                                                                          rw = dwconectorconsulta.Rows(dwconectorconsulta.Rows.Add())
                                                                                          rw.Cells(id1.Index).Value = itm.Id
                                                                                          rw.Cells(idConector1.Index).Value = itm.idConector
                                                                                          rw.Cells(nombreCampo1.Index).Value = itm.NombreCampo
                                                                                          rw.Cells(descripcion1.Index).Value = itm.Descripcion
                                                                                          rw.Cells(idtipoDato.Index).Value = itm.idTipoDato
                                                                                          rw.Cells(TipoDato1.Index).Value = itm.TipoDato
                                                                                          rw.Cells(observaciones1.Index).Value = itm.Observaciones
                                                                                          rw.Cells(indObligatorio1.Index).Value = itm.indObligatorio
                                                                                          rw.Cells(inicio1.Index).Value = itm.PosicionInicial
                                                                                          rw.Cells(fin1.Index).Value = itm.posicionFinal
                                                                                          rw.Cells(longitud1.Index).Value = itm.Longitud
                                                                                          rw.Cells(decimales1.Index).Value = If(itm.Decimales = 0, 0, itm.Decimales)
                                                                                          rw.Cells(formato1.Index).Value = itm.Formato
                                                                                          rw.Cells(valorDefecto1.Index).Value = itm.ValorDefecto
                                                                                          rw.Cells(autoincrement.Index).Value = itm.Autoincremento
                                                                                      End Sub)
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close() '            liberarRecursosExcel()
                bwCarga.CancelAsync()
                bwCarga.Dispose()
                bwCarga = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        Finally
        End Try
    End Sub
    Private Sub cargarComboConectores()
        Try
            Dim lcon As List(Of conector) = _objConector.SelectAll()
            lcon.Insert(0, New conector())
            cmbconectores.DisplayMember = "descripcion"
            cmbconectores.ValueMember = "Id"
            cmbconectores.DataSource = lcon
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarComboFormularios()
        Try
            Dim dic As New Dictionary(Of String, String)
            Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim types As Type() = myAssembly.GetTypes()
            For Each m In types
                If m.BaseType IsNot Nothing Then
                    If m.BaseType = GetType(Form) Then
                        'Dim ec = m.GetConstructor(Type.EmptyTypes)
                        'If ec IsNot Nothing Then
                        '    Dim f As Form = ec.Invoke(New Object() {})
                        '    If Not dic.ContainsKey(m.FullName) Then
                        '        dic.Add(m.FullName, f.Text)
                        '    End If
                        'End If
                        dic.Add(m.FullName, m.FullName)
                    End If
                End If
            Next
            cmbformulario.DisplayMember = "Value"
            cmbformulario.ValueMember = "Key"
            Dim bs As New BindingSource
            bs.DataSource = dic
            cmbformulario.DataSource = bs

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub FrmConectoresPlanos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarComboConectores()
            cargarComboFormularios()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbconectores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbconectores.SelectedIndexChanged
        Try
            txtnombreplano.Tag = 0
            txtnombreplano.Text = String.Empty
            dwitems.Rows.Clear()
            Dim enc As New ClsEncabeEnlaceConector
            Dim _idcon As Integer = 0
            If enc.TraerporIdConector(Convert.ToInt32(cmbconectores.SelectedValue)).Count > 0 Then
                Dim frmcondisp As New FrmConectoresDisponibles
                frmcondisp.IdConector = Convert.ToInt32(cmbconectores.SelectedValue)
                If frmcondisp.ShowDialog() = DialogResult.OK Then
                    _idcon = frmcondisp.IdPlano
                    Dim ec = enc.TraerporId(_idcon)
                    txtnombreplano.Tag = ec.Id
                    txtnombreplano.Text = ec.NombrePlano
                End If
            End If
            Dim enl As New ClsEnlaceConectorControl
            Dim lcon As List(Of EnlaceControlConector) = Nothing
            If _idcon > 0 Then
                lcon = enl.TraerporIdEncabe(Convert.ToInt32(cmbconectores.SelectedValue), _idcon)
            Else
                lcon = enl.TraerporIdConectorNuevoEnlazado(Convert.ToInt32(cmbconectores.SelectedValue))
            End If
            For Each mcon As EnlaceControlConector In lcon
                Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                r.Cells(idenlace.Index).Value = mcon.Id
                r.Cells(idcon.Index).Value = mcon.IdMovimientoConector
                r.Cells(campo.Index).Value = mcon.NombreCampo
                r.Cells(descripcioncampo.Index).Value = mcon.Descripcion
                r.Cells(controlasociado.Index).Value = mcon.NombreControl
                r.Cells(controlasociado.Index).Tag = mcon.RutaControl
                r.Cells(tipocontrol.Index).Tag = mcon.IdControl
                r.Cells(tipocontrol.Index).Value = mcon.IdControl
                r.Cells(valordefectocampo.Index).Value = mcon.ValorDefecto 'If(IsNothing(mcon.ValorDefecto), String.Empty, mcon.ValorDefecto)
                r.Cells(autoincrementocampo.Index).Value = mcon.Autoincremento
                r.Cells(obligatorio.Index).Value = mcon.indObligatorio
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbformulario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbformulario.SelectedIndexChanged
        Try
            For Each r As DataGridViewRow In dwitems.Rows
                r.Cells(idenlace.Index).Value = 0
                r.Cells(controlasociado.Index).Value = String.Empty
                r.Cells(controlasociado.Index).Value = String.Empty
                r.Cells(tipocontrol.Index).Value = 0
            Next
            Dim f As Form = [Assembly].GetEntryAssembly.CreateInstance(cmbformulario.SelectedValue)
            If f IsNot Nothing Then
                pformulario.Controls.Clear()
                f.FormBorderStyle = FormBorderStyle.None
                f.TopLevel = False
                f.AutoScroll = True
                pformulario.Controls.Add(f)
                f.Show()
                ObtenerControles(f)
                pformulario.Controls(0).Dock = DockStyle.Fill
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ObtenerControles(c As Control)
        Try
            For Each cn As Control In c.Controls
                If Not String.IsNullOrEmpty(cn.AccessibleName) Then
                    If cn.Controls.Count <= 0 Then
                        cn.Enabled = True
                        cn.Cursor = Cursors.Hand
                        AddHandler cn.MouseDown, AddressOf Control_Click
                    End If
                    If TypeOf cn Is NumericUpDown Then
                        cn.Cursor = Cursors.Hand
                        cn.Enabled = True
                        AddHandler cn.MouseDown, AddressOf Control_Click
                    ElseIf TypeOf cn Is DataGridView Or TypeOf cn Is DatagridTreeView.DataTreeGridView Then
                        cn.Enabled = True
                        cn.Cursor = Cursors.Hand
                        AddHandler DirectCast(cn, DataGridView).ColumnHeaderMouseClick, AddressOf Grid_Click
                    End If
                Else
                    If TypeOf cn IsNot Panel And TypeOf cn IsNot SplitContainer And
                    TypeOf cn IsNot TabControl And TypeOf cn IsNot TableLayoutPanel And
                    TypeOf cn IsNot FlowLayoutPanel And TypeOf cn IsNot GroupBox Then
                        cn.Enabled = False
                    End If
                End If
                ObtenerControles(cn)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub Control_Click(sender As Object, e As MouseEventArgs)
        Try
            Dim c As Control = DirectCast(sender, Control)
            If dwitems.SelectedRows.Count <= 0 Then
                MsgBox("Debe seleccionar al gun campo para su respectiva asignacion", MsgBoxStyle.Exclamation)
            Else
                Dim r As DataGridViewRow = dwitems.SelectedRows(0)
                If Convert.ToInt32(r.Cells(autoincrementocampo.Index).Value) Then
                    MsgBox("El campo " & Convert.ToString(r.Cells(campo.Index).Value) & " es autoincremental, no se puede tener un control asociado.", MsgBoxStyle.Exclamation)
                Else
                    Dim continuar As Boolean = True
                    If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valordefectocampo.Index).Value)) Then
                        If MsgBox("EL control " & Convert.ToString(r.Cells(campo.Index).Value) &
                                  " tiene un valor por defecto de: " &
                                  Convert.ToString(r.Cells(valordefectocampo.Index).Value) &
                                  ". ¿Esta seguro que desea cambiar ese valor?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Else
                            continuar = False
                        End If
                    End If
                    If continuar Then
                        r.Cells(controlasociado.Index).Value = c.AccessibleName
                        Dim b As New List(Of String)
                        b.Add(c.Name)
                        ObtenerRuta(c, b)
                        b.Reverse()
                        Dim ruta As String = String.Join(".", b.ToArray())
                        r.Cells(controlasociado.Index).Tag = ruta
                        If TypeOf c Is ComboBox Then
                            r.Cells(tipocontrol.Index).Value = Convert.ToInt32(ClsEnums.ControlesEnlaceConector.COMBOBOX)
                        ElseIf TypeOf c Is CheckedListBox Then
                            r.Cells(tipocontrol.Index).Value = Convert.ToInt32(ClsEnums.ControlesEnlaceConector.LISTA_CHEQUEO)
                        ElseIf TypeOf c Is CheckBox Then
                            r.Cells(tipocontrol.Index).Value = Convert.ToInt32(ClsEnums.ControlesEnlaceConector.CHECK)
                        ElseIf TypeOf c Is ListBox Then
                            r.Cells(tipocontrol.Index).Value = Convert.ToInt32(ClsEnums.ControlesEnlaceConector.LISTA)
                        ElseIf TypeOf c Is NumericUpDown Then
                            r.Cells(tipocontrol.Index).Value = Convert.ToInt32(ClsEnums.ControlesEnlaceConector.NUMERICO)
                        ElseIf TypeOf c Is DateTimePicker Then
                            r.Cells(tipocontrol.Index).Value = Convert.ToInt32(ClsEnums.ControlesEnlaceConector.FECHA)
                        Else
                            r.Cells(tipocontrol.Index).Value = Convert.ToInt32(ClsEnums.ControlesEnlaceConector.TEXTO)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Grid_Click(sender As Object, e As DataGridViewCellMouseEventArgs)
        Try
            Dim grid As DataGridView = DirectCast(sender, DataGridView)
            If dwitems.SelectedRows.Count <= 0 Then
                MsgBox("Debe seleccionar algun campo para su respectiva asignacion", MsgBoxStyle.Exclamation)
            Else
                Dim r As DataGridViewRow = dwitems.SelectedRows(0)
                r.Cells(controlasociado.Index).Value = grid.Columns(e.ColumnIndex).HeaderText
                Dim b As New List(Of String)
                b.Add(grid.Name & "|" & grid.Columns(e.ColumnIndex).Name)
                ObtenerRuta(grid, b)
                b.Reverse()
                Dim ruta As String = String.Join(".", b.ToArray())
                r.Cells(controlasociado.Index).Tag = ruta
                r.Cells(tipocontrol.Index).Value = ClsEnums.ControlesEnlaceConector.COLUMNA_TABLA
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ObtenerRuta(c As Control, ByRef br As List(Of String))
        Try
            If c.Parent IsNot c.FindForm() Then
                If String.IsNullOrEmpty(c.Parent.Name) Then
                    br.Add(c.Parent.Parent.Controls.IndexOf(c.Parent))
                Else
                    br.Add(c.Parent.Name)
                    ObtenerRuta(c.Parent, br)
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub LimpiarEnlace()
        Try
            Dim r As DataGridViewRow = dwitems.SelectedRows(0)
            If Convert.ToInt32(r.Cells(idenlace.Index).Value) > 0 Then
                Dim enl As New ClsEnlaceConectorControl
                enl.EliminarporId(Convert.ToInt32(r.Cells(idenlace.Index).Value))
            End If
            r.Cells(controlasociado.Index).Value = String.Empty
            r.Cells(controlasociado.Index).Tag = String.Empty
            r.Cells(tipocontrol.Index).Value = 0
            MsgBox("El campo se ha desenlazado correctamente", MsgBoxStyle.Information)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwitems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwitems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                If e.Button = MouseButtons.Right Then
                    Dim menu As New ContextMenuStrip
                    dwitems.Rows(e.RowIndex).Selected = True
                    menu.Items.Add("Limpiar Enlace", Nothing, AddressOf LimpiarEnlace)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
End Class