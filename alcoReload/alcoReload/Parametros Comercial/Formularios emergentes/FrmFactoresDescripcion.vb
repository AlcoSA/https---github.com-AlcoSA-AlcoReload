Imports ReglasNegocio.Factores
Imports Validaciones

Public Class FrmFactoresDescripcion
#Region "Variables"
    Private IDC As Integer
    Private mFactores As ClsFactores
    Private objValidacion As ClsValidaciones
#End Region

#Region "Propiedades"
    Public Property TasaUtilidad As Decimal
        Get
            Return txtTasa.Text
        End Get
        Set(value As Decimal)
            txtTasa.Text = value
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
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then
                Return
            End If
            mFactores = New ClsFactores
            mFactores.Ingresar(My.Settings.UsuarioActivo, TasaUtilidad, 1, IDC, txtDescripcion.Text, 0)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class