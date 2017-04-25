Imports System.Windows.Forms


Public Class ClsValidaciones
    ''' <summary>
    ''' Retorna verdadero si el campo textbox contiene información
    ''' </summary>
    ''' <param name="txtVacio"></param>
    ''' <param name="errorProvider"></param>
    ''' <returns></returns>
    Public Function TextBoxDigitado(txtVacio As TextBox, errorProvider As ErrorProvider) As Boolean
        If (txtVacio.Text = String.Empty) Then
            errorProvider.Clear()
            errorProvider.SetError(txtVacio, "El campo no debe estar vacío. Ingrese la información")
            Return False

        Else
            errorProvider.Clear()
            Return True
        End If
    End Function
    ''' <summary>
    ''' Retorna verdadero si el campo richtextbox contiene información
    ''' </summary>
    ''' <param name="txtVacio"></param>
    ''' <param name="errorProvider"></param>
    ''' <returns></returns>
    Public Function RichTextBoxDigitado(txtVacio As RichTextBox, errorProvider As ErrorProvider) As Boolean
        If (txtVacio.Text = String.Empty) Then
            errorProvider.Clear()
            errorProvider.SetError(txtVacio, "El campo no debe estar vacío. Ingrese la información")
            Return False

        Else
            errorProvider.Clear()
            Return True
        End If
    End Function
    ''' <summary>
    ''' Validará que los campos de texto contengan únicamente letras
    ''' </summary>
    ''' <param name="errorPrivider"></param>
    ''' <param name="obj"></param>
    Public Sub SoloLetras(errorPrivider As ErrorProvider, obj As Object)
        Try
            For Each letra As Char In obj.text
                If IsNumeric(letra) Then
                    errorPrivider.Clear()
                    errorPrivider.SetError(obj, "Sólo debe ingresar letras. Verifique la información")
                    Exit Sub
                Else
                    errorPrivider.Clear()
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento para validar que en el campo TextBox tenga un número entero, decimal o double
    ''' </summary>
    ''' <param name="numero"></param>
    ''' <param name="tipoNumero"></param>
    ''' <param name="errorProvider"></param>
    ''' <returns></returns>
    Public Function EsNumero(numero As Object, tipoNumero As String, errorProvider As ErrorProvider) As Boolean
        Try
            If tipoNumero = "entero" Then
                Try
                    Dim int As Integer = Convert.ToInt32(numero.Text)
                    Return True
                Catch ex As Exception
                    errorProvider.SetError(numero, "Debe ingresar un dato numérico. Verifique la información")
                    Return False
                End Try
            End If
            If tipoNumero = "decimal" Then
                Try
                    Dim dec As Decimal = Convert.ToDecimal(numero.Text)
                    Return True
                Catch ex As Exception
                    errorProvider.SetError(numero, "Debe ingresar un dato numérico. Verifique una información")
                    Return False
                End Try
            End If
            If tipoNumero = "double" Then
                Try
                    Dim dou As Double = Convert.ToDouble(numero.Text)
                    Return True
                Catch ex As Exception
                    errorProvider.SetError(numero, "Debe ingresar un dato numérico. Verifique la información")
                    Return False
                End Try
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Procedimiento útil para validar que un correo mínima mente cumpla con la estructura de una 
    ''' dirección de correo electrónico ya sea existente o no. 
    ''' </summary>
    ''' <param name="campo"></param>
    ''' <param name="errorProvider"></param>
    ''' <returns></returns>
    Function EmailCorrecto(campo As Object, errorProvider As ErrorProvider) As Boolean
        Try
            Dim email As String = campo.Text
            Dim emailRegex As New System.Text.RegularExpressions.Regex(
        "^(?<user>[^@]+)@(?<host>.+)$")
            Dim emailMatch As System.Text.RegularExpressions.Match =
           emailRegex.Match(email)
            If emailMatch.Success Then
                Return True
            End If
            errorProvider.SetError(campo, "Debe ingresar una dirección de correo electrónico válida.")
            Return False
        Catch ex As Exception
            Return False
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Validará que los campos numéricos no tengan valores inferiores a 1
    ''' </summary>
    ''' <param name="numero"></param>
    ''' <param name="errorProvider"></param>
    ''' <returns></returns>
    Public Function NumeroMayorACero(numero As Object, errorProvider As ErrorProvider) As Boolean
        Try
            If (numero.Value <= 0) Then
                errorProvider.Clear()
                errorProvider.SetError(numero, "El número debe ser mayor a cero. Verifique la información")
                Return False
            Else
                errorProvider.Clear()
                Return True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Validará que hayan elegido algún registro del combo box indicado
    ''' </summary>
    ''' <param name="control"></param>
    ''' <param name="errorProvider"></param>
    ''' <returns></returns>
    Public Function ComboBoxSeleccionado(control As Object, errorProvider As ErrorProvider) As Boolean
        Try
            If DirectCast(control, ComboBox).DataSource IsNot Nothing Then
                If (DirectCast(control, ComboBox).SelectedValue <= 0) Then
                    errorProvider.Clear()
                    errorProvider.SetError(control, "Debe seleccionar un dato. Verifique la información")
                    Return False
                Else
                    errorProvider.Clear()
                    Return True
                End If
            Else
                If (DirectCast(control, ComboBox).SelectedItem Is Nothing) Then
                    errorProvider.Clear()
                    errorProvider.SetError(control, "Debe seleccionar un dato. Verifique la información")
                    Return False
                Else
                    errorProvider.Clear()
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Validará que hayan elegido algún registro del combo box indicado
    ''' </summary>
    ''' <param name="control"></param>
    ''' <param name="errorProvider"></param>
    ''' <returns></returns>
    Public Function GridSeleccionado(control As Object, errorProvider As ErrorProvider) As Boolean
        Try
            If DirectCast(control, DataGridView).Rows.Count = 0 Then
                errorProvider.Clear()
                errorProvider.SetError(control, "El grid de las " & DirectCast(control, DataGridView).Tag)
                Return False
            Else
                errorProvider.Clear()
                Return True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
