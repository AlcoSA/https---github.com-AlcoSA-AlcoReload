Imports ReglasNegocio
Public Class FrmCreacionVariables

#Region "Variables"
    Private variables As ClsCreacionVariablesEsquemas
    Private tablasvariables As ClsTablasdeVariables
    Private tbVariables As DataTable = Nothing
    Private listaVariables As List(Of variableEsquema)
    Private curid As Integer = 0
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private lista As New List(Of String)
#End Region

#Region "Procedimientos"

    Private Sub dw_CellMouseDown(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                dw.DoDragDrop(dw.Item(0, e.RowIndex).Value, DragDropEffects.Copy Or DragDropEffects.Move)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function DefiniriGrid(gname As String) As DataGridView
        Try
            '
            'descripcion
            '
            Dim descripcion As New DataGridViewTextBoxColumn
            descripcion.HeaderText = "Descripción"
            descripcion.Name = "descripcion"
            descripcion.ReadOnly = True
            '
            'nomCol
            '
            Dim nomCol As New DataGridViewTextBoxColumn
            nomCol.HeaderText = "Nombre"
            nomCol.Name = "nomCol"
            nomCol.ReadOnly = True
            nomCol.Visible = True
            '
            'isnumeric
            '
            Dim isnumeric As New DataGridViewCheckBoxColumn
            isnumeric.HeaderText = "Numérica"
            isnumeric.Name = "isnumeric"
            isnumeric.ReadOnly = True
            '
            'dw
            '
            Dim dw As New DataGridView
            dw.AllowUserToAddRows = False
            dw.AllowUserToDeleteRows = False
            dw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dw.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
            dw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dw.Location = New System.Drawing.Point(3, 3)
            dw.Name = gname
            dw.ReadOnly = True
            dw.RowHeadersVisible = False
            dw.Size = New System.Drawing.Size(240, 150)
            dw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {descripcion, nomCol, isnumeric})
            dw.TabIndex = 0
            dw.Dock = DockStyle.Fill
            AddHandler dw.CellMouseDown, AddressOf dw_CellMouseDown
            Return dw
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function definirContenedor(textEncabe As String) As Control
        definirContenedor = New Panel()
        Try
            Dim tsencabe As New ToolStrip
            tsencabe.Items.Add(textEncabe)
            tsencabe.SendToBack()
            tsencabe.GripStyle = ToolStripGripStyle.Hidden
            tsencabe.Font = New Font(tsencabe.Font.Name, 12, FontStyle.Bold)
            definirContenedor.Height = 250
            definirContenedor.Width = 200
            definirContenedor.Controls.Add(tsencabe)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub cargarTablas()
        Try
            flpTablas.Controls.Clear()
            Dim ds As DataSet = tablasvariables.ConjuntoTablas
            For Each tb As DataTable In ds.Tables
                Dim dw As DataGridView = DefiniriGrid(tb.Rows(0).Item("TABLE_NAME"))
                For Each rw As DataRow In tb.Rows
                    Dim r As DataGridViewRow = dw.Rows(dw.Rows.Add())
                    r.Cells(0).Value = rw.Item("COLUMN_COMMENT")
                    r.Cells(1).Value = rw.Item("COLUMN_NAME")
                    r.Cells(2).Value = Convert.ToBoolean(rw.Item("ISNUMERIC"))
                    lista.Add(r.Cells(0).Value)
                    If Not txtvariable.Configuraciones.PalabrasClave.ContainsKey(Convert.ToString(r.Cells(0).Value)) Then
                        txtvariable.Configuraciones.PalabrasClave.Add(Convert.ToString(r.Cells(0).Value),
                                                                  Color.Red)
                    End If
                Next
                Dim c As Control = definirContenedor(dw.Name)
                c.Controls.Add(dw)
                dw.BringToFront()
                flpTablas.Controls.Add(c)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarDatos(tb As DataTable)
        Try
            dwitems.AutoGenerateColumns = False
            If tb.Rows.Count = 0 Then Exit Sub
            tb.Columns.Cast(Of DataColumn).AsParallel.ForAll(Sub(columna)
                                                                 If dwitems.Columns.Contains(columna.ColumnName) Then
                                                                     dwitems.Columns(columna.ColumnName).DataPropertyName = columna.ColumnName
                                                                 End If
                                                             End Sub)
            dwitems.DataSource = tb
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que Carga los campos que se van a combinar con el texto
    ''' </summary>
    ''' <remarks></remarks>
    Sub cargarCampos()
        Try
            Dim crev As New ClsCreacionVariablesEsquemas
            listaVariables = crev.selectByEstado(ClsEnums.Estados.ACTIVO, tbVariables)
            cargarDatos(tbVariables)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub cargarVariables()
        Try
            dwitems.Rows.Clear()
            Dim varEsq As List(Of variableEsquema) = variables.TraerTodos()
            For Each ve As variableEsquema In varEsq
                Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                r.Cells(id.Index).Value = ve.Id
                r.Cells(nombre.Index).Value = ve.nombreVariable
                r.Cells(valor.Index).Value = ve.valorVariable
                r.Cells(valors.Index).Value = ve.valorSistema
                r.Cells(estado.Index).Value = Not Convert.ToBoolean(ve.IdEstado - 1)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Validar = True
        Try
            If String.IsNullOrEmpty(txtnombre.Text) Then
                MsgBox("Debe ingresar el nombre de la variable. Verifique la información", MsgBoxStyle.Critical)
                Return False
            End If
            If String.IsNullOrEmpty(txtvariable.Text) Then
                MsgBox("Debe ingresar el valor de la variable. Verifique la información", MsgBoxStyle.Critical)
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwitems.SelectedRows(0)
            tform = ClsEnums.TiOperacion.MODIFICAR
            curid = Convert.ToInt32(r.Cells(id.Index).Value)
            txtnombre.Text = Convert.ToString(r.Cells(nombre.Index).Value)
            txtvariable.Text = Convert.ToString(r.Cells(valor.Index).Value)
            cbestado.Checked = Convert.ToBoolean(r.Cells(estado.Index).Value)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub Limpiar()
        Try
            tform = ClsEnums.TiOperacion.INSERTAR
            curid = 0
            txtnombre.Text = String.Empty
            txtvariable.Text = String.Empty
            cbestado.Checked = False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Function FormulaSistema() As String
        Try
            FormulaSistema = txtvariable.Text
            For Each c As Control In flpTablas.Controls
                If TypeOf c Is Panel Then
                    For Each c1 As Control In c.Controls
                        If TypeOf c1 Is DataGridView Then
                            Dim dw As DataGridView = DirectCast(c1, DataGridView)
                            For Each r As DataGridViewRow In dw.Rows
                                FormulaSistema = Replace(FormulaSistema, r.Cells(0).Value, r.Cells(1).Value)
                            Next
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Private Sub cargarClavesFuncion()
        Try
            Dim ej As New Formulador.Ejecutor
            For Each f In ej.FuncionesMatematicas.Keys
                If Not txtvariable.Configuraciones.PalabrasClave.ContainsKey(f) Then
                    txtvariable.Configuraciones.PalabrasClave.Add(f, Color.Green)
                    lista.Add(f)
                End If
            Next
            For Each f In ej.VariablesNumericas.Keys
                If Not txtvariable.Configuraciones.PalabrasClave.ContainsKey(f) Then
                    txtvariable.Configuraciones.PalabrasClave.Add(f, Color.Green)
                    lista.Add(f)
                End If
            Next
            For Each f In ej.FuncionesCadena.Keys
                If Not txtvariable.Configuraciones.PalabrasClave.ContainsKey(f) Then
                    txtvariable.Configuraciones.PalabrasClave.Add(f, Color.Blue)
                    lista.Add(f)
                End If
            Next
            For Each f In ej.VariablesCadena.Keys
                If Not txtvariable.Configuraciones.PalabrasClave.ContainsKey(f) Then
                    txtvariable.Configuraciones.PalabrasClave.Add(f, Color.Blue)
                    lista.Add(f)
                End If
            Next
            txtvariable.CompilarPalabrasClave()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
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
            btnsParcial.Enabled = False
            RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validar() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    variables.Ingresar(txtnombre.Text, txtvariable.Text, FormulaSistema(), Convert.ToInt32(Not cbestado.Checked) + 1, My.Settings.UsuarioActivo)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    variables.Modificar(curid, txtnombre.Text, txtvariable.Text, FormulaSistema(), Convert.ToInt32(Not cbestado.Checked) + 1, My.Settings.UsuarioActivo)
                End If
                Limpiar()
                cargarVariables()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            Limpiar()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmCreacionVariables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            variables = New ClsCreacionVariablesEsquemas
            tablasvariables = New ClsTablasdeVariables
            cargarTablas()
            cargarClavesFuncion()
            cargarVariables()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_CellMouseUp(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dwitems.CellMouseUp
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If e.RowIndex >= 0 Then
                    Dim menu As New ContextMenuStrip
                    dwitems.Rows(e.RowIndex).Selected = True
                    menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                    menu.Show(Control.MousePosition)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtvariable_KeyUp(sender As Object, e As KeyEventArgs) Handles txtvariable.KeyUp
        Try
            If (e.Control And e.KeyCode = Keys.Space) Then
            Else
                Dim anteclas As New Multiusos.OperacionesTeclado
                Dim ttecla = anteclas.DefinirTipoTecla(e)
                Dim vtecla As Char = anteclas.ObtenerValorTecla(e)
                If ttecla = Multiusos.OperacionesTeclado.TipoTecla.Letras Or ttecla = Multiusos.OperacionesTeclado.TipoTecla.Puntuacion Or (e.KeyCode = Keys.OemMinus And e.Shift) Then
                    If lista.Count > 0 Then
                        Dim ayudante As New Formulador.Formularios_Ayuda.FrmAyudanteFormulacion
                        ayudante.IndexultimoItem = txtvariable.SelectionStart - 1
                        ayudante.LenghtUltimoItem = 1
                        ayudante.EliminarUltimo = (ttecla = Multiusos.OperacionesTeclado.TipoTecla.Letras)
                        ayudante.ListaAyuda = lista
                        ayudante.ControlAyudado = txtvariable
                        Dim pt As Point = txtvariable.PointToScreen(txtvariable.GetPositionFromCharIndex(txtvariable.SelectionStart))
                        pt.Y += Convert.ToInt32(txtvariable.CreateGraphics().MeasureString("a", txtvariable.Font).Height)
                        ayudante.Location = pt
                        ayudante.Show()
                    End If
                End If

            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class