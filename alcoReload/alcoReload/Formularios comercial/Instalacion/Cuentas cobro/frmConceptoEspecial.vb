Imports ReglasNegocio

Public Class frmConceptoEspecial
#Region "Variables"
    Private _idConceptoLinea As Integer
    Private _descripcion As String
    Private _unidadMedida As String
    Private _cantidad As Integer
    Private _valorUnitario As Decimal
    Private _porcRetenido As Decimal
    Private operacionDescripcion As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
#End Region
#Region "Propiedades"
    Public Property IdConceptoLinea() As Integer
        Get
            Return _idConceptoLinea
        End Get
        Set(ByVal value As Integer)
            _idConceptoLinea = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property ValorUnitario() As Decimal
        Get
            Return _valorUnitario
        End Get
        Set(ByVal value As Decimal)
            _valorUnitario = value
        End Set
    End Property
    Public Property PorcentajeRetenido() As Decimal
        Get
            Return _porcRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcRetenido = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarUnidadesMedida()
        Try
            Dim mArticulos As New ClsArticulos
            Dim td As DataTable = mArticulos.traerUnidades()
            cmbUnidadMedida.ValueMember = "Unidad"
            cmbUnidadMedida.DisplayMember = "Unidad"
            cmbUnidadMedida.DataSource = td
            cmbUnidadMedida.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDescripciones()
        Try
            Dim mConceptosEspeciales As New ClsConceptosEspeciales
            mConceptosEspeciales.TraerTodos(_idConceptoLinea, itDescripcion.TablaFuente)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If itDescripcion.Text = String.Empty Then
                ErrorProvider.SetError(itDescripcion, "Debe ingresar la descripción")
                Return False
            End If
            ErrorProvider.Clear()

            If operacionDescripcion = ClsEnums.TiOperacion.INSERTAR Then
                Dim mConceptoEspecial As New ClsConceptosEspeciales
                If mConceptoEspecial.ExisteDesripcion(_idConceptoLinea, itDescripcion.Text) Then
                    ErrorProvider.SetError(itDescripcion, "Ya existe un concepto con esta descripción")
                    Return False
                End If
                ErrorProvider.Clear()
            End If

            If cmbUnidadMedida.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbUnidadMedida, "Debe indicar la unidad de medida")
                Return False
            End If
            ErrorProvider.Clear()

            If nudCantidad.Value = 0 Then
                ErrorProvider.SetError(nudCantidad, "La cantidad debe ser mayor a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()

            If nudValorUnitario.Value = 0 Then
                ErrorProvider.SetError(nudValorUnitario, "El valor unitario debe ser mayor a cero (0)")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub frmConceptoEspecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarUnidadesMedida()
            cargarDescripciones()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If validacion() Then
                Dim mConceptoEspecial As New ClsConceptosEspeciales
                If operacionDescripcion = ClsEnums.TiOperacion.INSERTAR Then
                    mConceptoEspecial.Insertar(My.Settings.UsuarioActivo, _idConceptoLinea, itDescripcion.Text, ClsEnums.Estados.ACTIVO)
                End If
                _descripcion = itDescripcion.Text
                _unidadMedida = cmbUnidadMedida.SelectedValue
                _cantidad = nudCantidad.Value
                _valorUnitario = nudValorUnitario.Value
                _porcRetenido = nudPorcRetenido.Value
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
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

    Private Sub itDescripcion_User_Edit(sender As Object, e As EventArgs) Handles itDescripcion.User_Edit
        Try
            itDescripcion.Seleted_rowid = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itDescripcion_Leave(sender As Object, e As EventArgs) Handles itDescripcion.Leave
        Try
            If itDescripcion.Seleted_rowid Is Nothing Then
                operacionDescripcion = ClsEnums.TiOperacion.INSERTAR
            Else
                operacionDescripcion = ClsEnums.TiOperacion.SOLO_LECTURA
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudCantidad.GotFocus,
            nudValorUnitario.GotFocus, nudPorcRetenido.GotFocus
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Value = 0 Then
                nud.ResetText()
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudCantidad.Leave,
            nudValorUnitario.Leave, nudPorcRetenido.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0"
                nud.Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class