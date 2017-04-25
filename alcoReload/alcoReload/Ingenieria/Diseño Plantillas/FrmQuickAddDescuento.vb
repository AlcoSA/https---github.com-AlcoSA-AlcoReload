Imports ReglasNegocio
Imports Validaciones
Public Class FrmQuickAddDescuento
#Region "Variables"

    Private mdescuentos As ClsDescuentos
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private _idInsert As Integer
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos de usuario"
    Private Sub limpiar()
        Try
            Try
                curid = 0
                txtDescuento.Text = String.Empty
                txtdescripcion.Text = String.Empty
                cbEstado.Checked = False
                epdescuentos.Clear()
                tform = ClsEnums.TiOperacion.INSERTAR
            Catch ex As Exception
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            End Try
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.TextBoxDigitado(txtDescuento, epdescuentos) Then Return False
            If Not objValidacion.TextBoxDigitado(txtdescripcion, epdescuentos) Then Return False
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
#Region "Propiedades"
    Private Sub FrmQuickAddDescuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdescuentos = New ClsDescuentos
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try

            If Validacion() Then
                Dim mensaje As String = String.Empty
                If (mdescuentos.ValidarDatos(txtDescuento.Text, txtdescripcion.Text, mensaje)) Then
                    mdescuentos.Insertar(txtDescuento.Text, txtdescripcion.Text, My.Settings.UsuarioActivo, Int32.Parse(cbEstado.Tag))
                    MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                    limpiar()
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MsgBox(mensaje, MsgBoxStyle.Critical)
                End If
            End If




        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles cbEstado.CheckedChanged
        Try
            If cbEstado.Checked Then
                cbEstado.Tag = 1
                cbEstado.Text = "Activo"
            Else
                cbEstado.Tag = 2
                cbEstado.Text = "Inactivo"
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
End Class