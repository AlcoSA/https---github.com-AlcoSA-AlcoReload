Imports ReglasNegocio

Public Class FrmCambioSeccion
#Region "Variables"
    Private _idEncabezado As Integer
    Private _consecutivo As Integer
    Private _idSeccionOriginal As Integer
    Private _seccionOriginal As String
    Private _responsableOriginal As String
    Private _idSeccionCambio As Integer
    Private _seccionCambio As String
    Private _responsableCambio As String

    Private loadCompleted As Boolean = False
#End Region
#Region "Propiedades"
    Public Property IdEncabezado() As Integer
        Get
            Return _idEncabezado
        End Get
        Set(ByVal value As Integer)
            _idEncabezado = value
        End Set
    End Property
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
        End Set
    End Property
    Public Property IdSeccionOriginal() As Integer
        Get
            Return _idSeccionOriginal
        End Get
        Set(ByVal value As Integer)
            _idSeccionOriginal = value
        End Set
    End Property
    Public Property SeccionOriginal() As String
        Get
            Return _seccionOriginal
        End Get
        Set(ByVal value As String)
            _seccionOriginal = value
        End Set
    End Property
    Public Property ResponsableOriginal() As String
        Get
            Return _responsableOriginal
        End Get
        Set(ByVal value As String)
            _responsableOriginal = value
        End Set
    End Property
    Public Property IdSeccionCambio() As Integer
        Get
            Return _idSeccionCambio
        End Get
        Set(ByVal value As Integer)
            _idSeccionCambio = value
        End Set
    End Property
    Public Property SeccionCambio() As String
        Get
            Return _seccionCambio
        End Get
        Set(ByVal value As String)
            _seccionCambio = value
        End Set
    End Property
    Public Property ResponsableCambio() As String
        Get
            Return _responsableCambio
        End Get
        Set(ByVal value As String)
            _responsableCambio = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarSecciones()
        Try
            Dim mSecciones As New ClsSecciones
            Dim listSecciones As List(Of seccion) = mSecciones.TraerTodos()
            cmbSeccion.ValueMember = "Id"
            cmbSeccion.DisplayMember = "Prefijo"
            cmbSeccion.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbSeccion.DataSource = listSecciones
            cmbSeccion.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmCambioSeccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarSecciones()
            txtConsecutivo.Text = _consecutivo
            txtSeccionOriginal.Text = _seccionOriginal
            txtResponsableOriginal.Text = _responsableOriginal

            loadCompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If cmbSeccion.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbSeccion, "Seleccione la sección por la que realizará el cambio")
                Return
            End If
            ErrorProvider.Clear()

            If txtMotivoCambio.Text = String.Empty Then
                ErrorProvider.SetError(txtMotivoCambio, "Debe ingresar el motivo del cambio de sección")
                Return
            End If
            ErrorProvider.Clear()

            If MessageBox.Show("¿Está seguro de cambiar la sección encargada del problema de producción?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim mEncabezado As New ClsEncabezadoProblemasP

                Dim sec As seccion = cmbSeccion.SelectedItem
                _idSeccionCambio = sec.Id
                _seccionCambio = sec.Prefijo
                _responsableCambio = sec.Encargado

                mEncabezado.ActualizarSeccionResponsable(_idEncabezado, sec.Id)
                mEncabezado.InsertarCambioSeccion(My.Settings.UsuarioActivo, _idEncabezado, _idSeccionOriginal, _idSeccionCambio, txtMotivoCambio.Text)
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

    Private Sub cmbSeccion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSeccion.SelectedValueChanged
        Try
            If loadCompleted Then
                ErrorProvider.Clear()
                If cmbSeccion.SelectedItem IsNot Nothing Then
                    Dim sec As seccion = cmbSeccion.SelectedItem
                    txtResponsableCambio.Text = sec.Encargado
                    _idSeccionCambio = sec.Id
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub txtMotivoCambio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMotivoCambio.KeyDown
        Try
            ErrorProvider.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class