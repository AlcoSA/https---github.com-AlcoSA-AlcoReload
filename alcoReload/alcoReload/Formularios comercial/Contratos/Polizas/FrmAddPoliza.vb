Imports ReglasNegocio

Public Class FrmAddPoliza
#Region "Variables"

    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _idContrato As Integer
    Private _numContrato As String
    Private _nit As String
    Private _cliente As String
    Private _codSuc As String
    Private _sucursal As String
#End Region
#Region "Propiedades"
    Public Property Operacion() As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property NumContrato() As String
        Get
            Return _numContrato
        End Get
        Set(ByVal value As String)
            _numContrato = value
        End Set
    End Property
    Public Property Nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodSuc() As String
        Get
            Return _codSuc
        End Get
        Set(ByVal value As String)
            _codSuc = value
        End Set
    End Property
    Public Property Sucursal() As String
        Get
            Return _sucursal
        End Get
        Set(ByVal value As String)
            _sucursal = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarConceptos()
        Try
            Dim mConcepto As New clsPolizas
            Dim listConceptos As List(Of poliza) = mConcepto.traerTodos()
            DirectCast(dwItems.Columns(concepto.Index), DataGridViewComboBoxColumn).DisplayMember = "descripcion"
            DirectCast(dwItems.Columns(concepto.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(concepto.Index), DataGridViewComboBoxColumn).DataSource = listConceptos.Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
            DirectCast(dwItems.Columns(concepto.Index), DataGridViewComboBoxColumn).Selected = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarAseguradora()
        Try
            Dim mAseguradora As New clsAseguradoras
            Dim listAseguradoras As List(Of aseguradora) = mAseguradora.traerTodos()
            DirectCast(dwItems.Columns(aseguradora.Index), DataGridViewComboBoxColumn).DisplayMember = "razonSocial"
            DirectCast(dwItems.Columns(aseguradora.Index), DataGridViewComboBoxColumn).ValueMember = "Id"
            DirectCast(dwItems.Columns(aseguradora.Index), DataGridViewComboBoxColumn).DataSource = listAseguradoras.Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInfoContrato()
        Try
            txtNumContrato.Text = _numContrato
            txtNit.Text = _nit
            txtCliente.Text = _cliente
            txtCodSuc.Text = _codSuc
            txtSuc.Text = _sucursal
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            dwItems.AllowUserToAddRows = False
            dwItems.Rows.Clear()

            Dim mMovitoPoliza As New clsMovitoPoliza
            Dim listMovitoPolizas As List(Of movitoPoliza) = mMovitoPoliza.TraerxIDContrato(_idContrato)
            For Each pol As movitoPoliza In listMovitoPolizas
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(id.Index).Value = pol.Id
                r.Cells(concepto.Index).Value = pol.IdTipoPoliza
                r.Cells(numPoliza.Index).Value = pol.Consecutivo
                r.Cells(anexo.Index).Value = pol.Anexo
                r.Cells(fechaInicio.Index).Value = pol.FechaInicio
                r.Cells(fechaVencimiento.Index).Value = pol.FechaVencimiento
                r.Cells(valorAsegurado.Index).Value = pol.ValorPoliza
                r.Cells(aseguradora.Index).Value = pol.IdAseguradora
                r.Cells(observaciones.Index).Value = pol.Observacion
                r.Cells(idEstado.Index).Value = pol.IdEstado
                r.Cells(estado.Index).Value = pol.Estado
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If Convert.ToInt32(r.Cells(idEstado.Index).Value) = ClsEnums.Estados.VENCIDO Then
                MessageBox.Show("La póliza se ha cumplido, no se puede eliminar")
                Return
            End If

            If MessageBox.Show("¿Está seguro de eliminar la fila seleccionada?", "",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    If dwItems.Rows.Count > 1 Then

                        If dwItems.CurrentRow.Index <> (dwItems.Rows.Count - 1) Then
                            dwItems.Rows.Remove(dwItems.SelectedRows(0))
                        End If
                    End If
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    Dim mMovitoPoliza As New clsMovitoPoliza
                    If dwItems.Rows.Count > 1 Then
                        mMovitoPoliza.ActualizarEstado(r.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                        dwItems.Rows.Remove(dwItems.SelectedRows(0))
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Validaciones"
    Private Function Validaciones(operacion As ClsEnums.TiOperacion) As Boolean
        Try
            If operacion = ClsEnums.TiOperacion.INSERTAR Then
                If Not informacionIngresada() Then
                    Return False
                End If
                If ExistePoliza() Then
                    ErrorProvider.SetError(Panel, "Una o más polizas ya existen en base de datos")
                    Return False
                End If
                If ConceptosRepetidos() Then
                    ErrorProvider.SetError(Panel, "Uno o más conceptos están repetidos")
                    Return False
                End If
                Return True
            ElseIf operacion = ClsEnums.TiOperacion.MODIFICAR Then
                If Not informacionIngresada() Then
                    Return False
                End If
                Return True
            End If
            Return False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function informacionIngresada() As Boolean
        Try
            Dim indexUltimaFila As Integer = dwItems.Rows.GetLastRow(DataGridViewElementStates.Visible)
            Dim filasIncompletas As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If r.Index <> indexUltimaFila Then
                    If r.Cells(concepto.Index).Value Is Nothing Or r.Cells(numPoliza.Index).Value Is Nothing Or
                    r.Cells(anexo.Index).Value Is Nothing Or r.Cells(valorAsegurado.Index).Value Is Nothing Or
                    r.Cells(aseguradora.Index).Value Is Nothing Or Convert.ToString(r.Cells(valorAsegurado.Index).Value) = String.Empty Or
                    Convert.ToString(r.Cells(numPoliza.Index).Value) = String.Empty Or Convert.ToString(r.Cells(anexo.Index).Value) = String.Empty Then
                        filasIncompletas += 1
                    End If
                End If
            Next
            If filasIncompletas > 0 Then
                ErrorProvider.SetError(Panel, "Una o más filas tienen campos vacíos")
                Return False
            Else
                ErrorProvider.Clear()
                Return True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function ExistePoliza() As Boolean
        Try
            Dim mMovitoPoliza As New clsMovitoPoliza
            Dim conteo As Integer = 0

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                For Each r As DataGridViewRow In dwItems.Rows
                    If r.Cells(concepto.Index).Value IsNot Nothing And r.Cells(numPoliza.Index).Value IsNot Nothing And
                        r.Cells(anexo.Index).Value IsNot Nothing And r.Cells(valorAsegurado.Index).Value IsNot Nothing And
                        r.Cells(aseguradora.Index).Value IsNot Nothing Then

                        If mMovitoPoliza.ExistePoliza(_idContrato, Convert.ToInt32(r.Cells(concepto.Index).Value), Convert.ToInt32(r.Cells(aseguradora.Index).Value),
                                                 Convert.ToString(r.Cells(numPoliza.Index).Value), Convert.ToString(r.Cells(anexo.Index).Value)) Then
                            conteo += 1
                        End If
                    End If
                Next

            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                For Each row1 As DataGridViewRow In dwItems.Rows
                    For Each row2 As DataGridViewRow In dwItems.Rows
                        If row1.Index <> row2.Index Then
                            If Convert.ToInt32(row1.Cells(concepto.Index).Value) = Convert.ToInt32(row2.Cells(concepto.Index).Value) And
                                Convert.ToString(row1.Cells(numPoliza.Index).Value) = Convert.ToString(row2.Cells(numPoliza.Index).Value) And
                                Convert.ToString(row1.Cells(anexo.Index).Value) = Convert.ToString(row2.Cells(anexo.Index).Value) And
                                Convert.ToInt32(row1.Cells(aseguradora.Index).Value) = Convert.ToInt32(row2.Cells(aseguradora.Index).Value) Then
                                conteo += 1
                            End If
                        End If
                    Next
                Next
            End If


            If conteo > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function ConceptosRepetidos() As Boolean
        Try
            Dim conteo As Integer = 0
            For Each row1 As DataGridViewRow In dwItems.Rows
                For Each row2 As DataGridViewRow In dwItems.Rows
                    If row1.Index <> row2.Index Then
                        If Convert.ToInt32(row1.Cells(concepto.Index).Value) = Convert.ToInt32(row2.Cells(concepto.Index).Value) Then
                            conteo += 1
                        End If
                    End If
                Next
            Next
            If conteo > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Function ValidarPolizaExistente(idConcepto As Integer) As Boolean
        Try
            Dim mMovitoPoliza As New clsMovitoPoliza
            Dim poliza As movitoPoliza = mMovitoPoliza.PolizaVigente(_idContrato, idConcepto)
            If poliza IsNot Nothing Then
                If MessageBox.Show("El contrato actual cuenta con una poliza de " & poliza.TipoPoliza & " vigente. De continuar con el " &
                                   "guardado, la poliza repetida pasará a estado VENCIDO reemplazada por la que está insertando " &
                                   "¿Desea continuar?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    mMovitoPoliza.ActualizarEstado(poliza.Id, ClsEnums.Estados.VENCIDO)
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
#End Region

    Private Sub FrmAddPoliza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarConceptos()
        cargarAseguradora()
        cargarInfoContrato()
        dwItems.Columns(estado.Index).Visible = False
        If tform = ClsEnums.TiOperacion.MODIFICAR Then
            Modificar()
            dwItems.Columns(estado.Index).Visible = True

            dwItems.Columns(concepto.Index).ReadOnly = True
            dwItems.Columns(numPoliza.Index).ReadOnly = True
            dwItems.Columns(anexo.Index).ReadOnly = True
            dwItems.Columns(aseguradora.Index).ReadOnly = True
            dwItems.Columns(numPoliza.Index).DefaultCellStyle.BackColor = Color.Gainsboro
            dwItems.Columns(anexo.Index).DefaultCellStyle.BackColor = Color.Gainsboro
            dwItems.Columns(estado.Index).DefaultCellStyle.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub btnGuardado_Click(sender As Object, e As EventArgs) Handles btnGuardado.Click
        Try
            dwItems.EndEdit()
            ErrorProvider.Clear()
            Dim mMovitoPoliza As New clsMovitoPoliza
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If Validaciones(tform) Then
                    For Each r As DataGridViewRow In dwItems.Rows
                        If r.Cells(concepto.Index).Value IsNot Nothing And r.Cells(numPoliza.Index).Value IsNot Nothing And
                                    r.Cells(anexo.Index).Value IsNot Nothing And r.Cells(valorAsegurado.Index).Value IsNot Nothing And
                                    r.Cells(aseguradora.Index).Value IsNot Nothing Then
                            If ValidarPolizaExistente(r.Cells(concepto.Index).Value) Then
                                mMovitoPoliza.Insertar(My.Settings.UsuarioActivo, _idContrato, r.Cells(concepto.Index).Value,
                                                       r.Cells(aseguradora.Index).Value, r.Cells(numPoliza.Index).Value, r.Cells(anexo.Index).Value,
                                                       r.Cells(valorAsegurado.Index).Value, r.Cells(fechaInicio.Index).Value,
                                                       r.Cells(fechaVencimiento.Index).Value,
                                                       If(r.Cells(observaciones.Index).Value Is Nothing, String.Empty, r.Cells(observaciones.Index).Value),
                                                       ClsEnums.Estados.VIGENTE)
                            Else
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    Exit Sub
                End If
            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                If Validaciones(tform) Then
                    For Each r As DataGridViewRow In dwItems.Rows
                        If r.Cells(concepto.Index).Value IsNot Nothing And r.Cells(numPoliza.Index).Value IsNot Nothing And
                                    r.Cells(anexo.Index).Value IsNot Nothing And r.Cells(valorAsegurado.Index).Value IsNot Nothing And
                                    r.Cells(aseguradora.Index).Value IsNot Nothing Then
                            mMovitoPoliza.Modificar(r.Cells(id.Index).Value, r.Cells(concepto.Index).Value, r.Cells(aseguradora.Index).Value,
                                                    r.Cells(numPoliza.Index).Value, r.Cells(anexo.Index).Value, r.Cells(valorAsegurado.Index).Value,
                                                    r.Cells(fechaInicio.Index).Value, r.Cells(fechaVencimiento.Index).Value,
                                                    r.Cells(observaciones.Index).Value, My.Settings.UsuarioActivo)
                        End If
                    Next
                Else
                    Exit Sub
                End If
            End If
            MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub


    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
            If e.ColumnIndex = numPoliza.Index Then
                If r.Cells(numPoliza.Index).Value IsNot Nothing Then
                    r.Cells(numPoliza.Index).Value = r.Cells(numPoliza.Index).Value.ToString().ToUpper()
                End If
            End If
            If e.ColumnIndex = anexo.Index Then
                If r.Cells(anexo.Index).Value IsNot Nothing Then
                    r.Cells(anexo.Index).Value = r.Cells(anexo.Index).Value.ToString().ToUpper()
                End If
            End If
            If e.ColumnIndex = observaciones.Index Then
                If r.Cells(observaciones.Index).Value IsNot Nothing Then
                    r.Cells(observaciones.Index).Value = r.Cells(observaciones.Index).Value.ToString().ToUpper()
                End If
            End If

            If e.ColumnIndex = valorAsegurado.Index Then
                If r.Cells(valorAsegurado.Index).Value IsNot Nothing Then
                    If IsNumeric(r.Cells(valorAsegurado.Index).Value) Then
                        Dim valor As Decimal = r.Cells(valorAsegurado.Index).Value
                        r.Cells(valorAsegurado.Index).Value = String.Empty
                        r.Cells(valorAsegurado.Index).Value = valor
                    Else
                        r.Cells(valorAsegurado.Index).Value = Nothing
                    End If
                End If
            End If

            If e.ColumnIndex = fechaInicio.Index Then
                If Convert.ToDateTime(r.Cells(fechaInicio.Index).Value) < DateTime.Now.ToShortDateString Then
                    r.Cells(fechaInicio.Index).Value = DateTime.Now
                End If
            End If

            If e.ColumnIndex = fechaVencimiento.Index Then
                If Convert.ToDateTime(r.Cells(fechaVencimiento.Index).Value) < DateTime.Now.ToShortDateString Then
                    r.Cells(fechaInicio.Index).Value = DateTime.Now
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItems.CellBeginEdit
        Try
            ErrorProvider.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.Button = MouseButtons.Right Then
                Dim col As DataGridViewColumn = dwItems.Columns(e.ColumnIndex)
                dwItems.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Eliminar", Nothing, AddressOf Eliminar)
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class