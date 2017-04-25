Imports ReglasNegocio.ManoObraInstalacion
Imports Validaciones

Public Class FrmManoObraDescripcion
#Region "Variables"
    Private IDC As Integer
    Private mManoObraInst As ClsManoObraInstalacion
    Private mInstalacion As ClsManoObraInstalacion
    Private objValidacion As ClsValidaciones
#End Region
#Region "Propiedades"
    Public Property Valor As Decimal
        Get
            Return txtValor.Text
        End Get
        Set(value As Decimal)
            txtValor.Text = value
        End Set
    End Property

    Public Property NombreCiudad As String
        Get
            Return txtCiudad.Text
        End Get
        Set(value As String)
            txtCiudad.Text = value
        End Set
    End Property

    Public Property idCiudad As Integer
        Get
            Return IDC
        End Get
        Set(value As Integer)
            IDC = value
        End Set
    End Property
#End Region
    Private Sub FrmManoObraDescripcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mInstalacion = New ClsManoObraInstalacion
            Dim td As DataTable = mInstalacion.traerUnidades()
            cmbUnidadMedida.ValueMember = "Unidad"
            cmbUnidadMedida.DisplayMember = "Unidad"
            cmbUnidadMedida.DataSource = td
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then
                Return
            End If
            mInstalacion = New ClsManoObraInstalacion
            mInstalacion.Ingresar(My.Settings.UsuarioActivo, cmbUnidadMedida.SelectedValue, Valor, 1,
                                  txtDescripcion.Text, IDC, 0)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class