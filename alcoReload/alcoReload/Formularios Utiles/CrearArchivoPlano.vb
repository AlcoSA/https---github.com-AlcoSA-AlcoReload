Imports System.Text
Imports ReglasNegocio
Public Class CrearArchivoPlano

    Public Function CrearPlano(f As Form, idconector As Integer, idencabeinforme As Integer,
                               ByRef dic_consecutivos As Dictionary(Of String, Integer)) As StringBuilder
        Dim sb As New StringBuilder
        Try
            Dim enl As New ClsEnlaceConectorControl
            Dim lenl As List(Of EnlaceControlConector) = enl.TraerporIdEncabe(idconector, idencabeinforme)
            For Each e As EnlaceControlConector In lenl
                Dim v_linea As String = String.Empty
                Select Case DirectCast(e.IdControl, ClsEnums.ControlesEnlaceConector)
                    Case ClsEnums.ControlesEnlaceConector.NA
                        If e.indObligatorio Then
                            If String.IsNullOrEmpty(e.ValorDefecto) And Not e.Autoincremento Then
                                Throw New Exception("El valor del campo: " & e.NombreCampo & ", es obligatorio. No se puede generar el plano")
                            ElseIf e.Autoincremento Then
                                If dic_consecutivos.ContainsKey(e.NombreCampo) Then
                                    v_linea = AplicarFormato(dic_consecutivos.Item(e.NombreCampo), e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                                    dic_consecutivos.Item(e.NombreCampo) = dic_consecutivos.Item(e.NombreCampo) + 1
                                Else
                                    If String.IsNullOrEmpty(e.ValorDefecto) Then
                                        dic_consecutivos.Add(e.NombreCampo, 1)
                                    Else
                                        dic_consecutivos.Add(e.NombreCampo, Convert.ToInt32(e.ValorDefecto))
                                    End If
                                    v_linea = AplicarFormato(dic_consecutivos.Item(e.NombreCampo), e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                                    dic_consecutivos.Item(e.NombreCampo) = dic_consecutivos.Item(e.NombreCampo) + 1

                                End If
                            Else
                                v_linea = AplicarFormato(Convert.ToString(e.ValorDefecto), e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                            End If
                        Else
                            v_linea = AplicarFormato(e.ValorDefecto, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        End If
                    Case ClsEnums.ControlesEnlaceConector.CHECK
                        Dim c As Control = ObtenerControl(f, e.RutaControl)
                        Dim valor As String = Convert.ToString(Convert.ToInt32(DirectCast(c, CheckBox).Checked))
                        v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                    Case ClsEnums.ControlesEnlaceConector.COMBOBOX
                        Dim c As Control = ObtenerControl(f, e.RutaControl)
                        Dim valor As String = String.Empty
                        If DirectCast(c, ComboBox).DataSource IsNot Nothing Then
                            valor = Convert.ToString(DirectCast(c, ComboBox).SelectedValue)
                        Else
                            valor = Convert.ToString(DirectCast(c, ComboBox).SelectedItem)
                        End If
                        v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                    Case ClsEnums.ControlesEnlaceConector.FECHA
                        Dim c As Control = ObtenerControl(f, e.RutaControl)
                        Dim valor As String = Convert.ToString(Convert.ToDateTime(DirectCast(c, DateTimePicker).Value).ToShortDateString)
                        v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                    Case ClsEnums.ControlesEnlaceConector.LISTA
                        Dim c As Control = ObtenerControl(f, e.RutaControl)
                        Dim valor As String = String.Empty
                        valor = String.Join(" ", DirectCast(c, ListBox).Items.Cast(Of String).ToArray())
                        v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                    Case ClsEnums.ControlesEnlaceConector.LISTA_CHEQUEO
                        Dim c As Control = ObtenerControl(f, e.RutaControl)
                        Dim valor As String = String.Empty
                        valor = String.Join(" ", DirectCast(c, CheckedListBox).CheckedItems.Cast(Of String).ToArray())
                        v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                    Case ClsEnums.ControlesEnlaceConector.NUMERICO
                        Dim c As Control = ObtenerControl(f, e.RutaControl)
                        Dim valor As String = Convert.ToString(Convert.ToDecimal(DirectCast(c, NumericUpDown).Value))
                        v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                    Case ClsEnums.ControlesEnlaceConector.TEXTO
                        Dim c As Control = ObtenerControl(f, e.RutaControl)
                        Dim valor As String = Convert.ToString(c.Text)
                        v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                End Select
                sb.Append(v_linea)
            Next
            Return sb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Private Function ObtenerControl(f As Form, rutacontrol As String) As Control
        Dim c As Control = f
        Try
            Dim lc As String() = rutacontrol.Split(".")
            For Each s In lc
                If IsNumeric(s) Then
                    c = c.Controls(Convert.ToInt32(s))
                Else
                    c = c.Controls(s)
                End If
            Next
            Return c
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Private Function AplicarFormato(valor As String, longitud As Integer,
                                    formato As String, decimales As Integer,
                                    tipodato As ClsEnums.TiposDato) As String
        Try
            If tipodato = ClsEnums.TiposDato.NUMERICO Or tipodato = ClsEnums.TiposDato.BOOLEANO Then
                If decimales > 0 Then
                    valor = (Convert.ToDecimal(valor).ToString("N" & decimales)) 'Convert.ToString()
                End If
                valor = valor.PadLeft(longitud, "0")
            ElseIf tipodato = ClsEnums.TiposDato.FECHA Then
                valor = Convert.ToDateTime(valor).ToString(formato)
                valor = valor.PadRight(longitud)
            Else
                If Not String.IsNullOrEmpty(formato) Then
                    valor = String.Format(formato, valor)
                End If
                valor = valor.PadRight(longitud)
            End If
            Return valor
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function CrearPlanoGRID(f As Form, idconector As Integer, idencabeinforme As Integer, dw As DataGridView,
                                   ByRef dic_consecutivos As Dictionary(Of String, Integer)) As StringBuilder
        Dim sb As New StringBuilder
        Try
            For Each r As DataGridViewRow In dw.Rows
                Dim enl As New ClsEnlaceConectorControl
                Dim lenl As List(Of EnlaceControlConector) = enl.TraerporIdEncabe(idconector, idencabeinforme)
                For Each e As EnlaceControlConector In lenl
                    Dim v_linea As String = String.Empty
                    Select Case DirectCast(e.IdControl, ClsEnums.ControlesEnlaceConector)
                        Case ClsEnums.ControlesEnlaceConector.NA
                            If e.indObligatorio Then
                                If String.IsNullOrEmpty(e.ValorDefecto) And Not e.Autoincremento Then
                                    Throw New Exception("El valor del campo: " & e.NombreCampo & ", es obligatorio. No se puede generar el plano")
                                ElseIf e.Autoincremento Then
                                    If dic_consecutivos.ContainsKey(e.NombreCampo) Then
                                        dic_consecutivos.Item(e.NombreCampo) = dic_consecutivos.Item(e.NombreCampo) + 1
                                        v_linea = AplicarFormato(dic_consecutivos.Item(e.NombreCampo), e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                                    Else
                                        If String.IsNullOrEmpty(e.ValorDefecto) Then
                                            dic_consecutivos.Add(e.NombreCampo, 1)
                                        Else
                                            dic_consecutivos.Add(e.NombreCampo, Convert.ToInt32(e.ValorDefecto))
                                        End If
                                        dic_consecutivos.Item(e.NombreCampo) = dic_consecutivos.Item(e.NombreCampo) + 1
                                        AplicarFormato(dic_consecutivos.Item(e.NombreCampo), e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                                    End If
                                Else
                                    v_linea = AplicarFormato(e.ValorDefecto, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                                End If
                            Else
                                v_linea = AplicarFormato(e.ValorDefecto, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                            End If
                        Case ClsEnums.ControlesEnlaceConector.CHECK
                            Dim c As Control = ObtenerControl(f, e.RutaControl)
                            Dim valor As String = Convert.ToString(Convert.ToInt32(DirectCast(c, CheckBox).Checked))
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        Case ClsEnums.ControlesEnlaceConector.COMBOBOX
                            Dim c As Control = ObtenerControl(f, e.RutaControl)
                            Dim valor As String = String.Empty
                            If DirectCast(c, ComboBox).DataSource IsNot Nothing Then
                                valor = Convert.ToString(DirectCast(c, ComboBox).SelectedValue)
                            Else
                                valor = Convert.ToString(DirectCast(c, ComboBox).SelectedItem)
                            End If
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        Case ClsEnums.ControlesEnlaceConector.FECHA
                            Dim c As Control = ObtenerControl(f, e.RutaControl)
                            Dim valor As String = Convert.ToString(Convert.ToDateTime(DirectCast(c, DateTimePicker).Value))
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        Case ClsEnums.ControlesEnlaceConector.LISTA
                            Dim c As Control = ObtenerControl(f, e.RutaControl)
                            Dim valor As String = String.Empty
                            valor = String.Join(" ", DirectCast(c, ListBox).Items.Cast(Of String).ToArray())
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        Case ClsEnums.ControlesEnlaceConector.LISTA_CHEQUEO
                            Dim c As Control = ObtenerControl(f, e.RutaControl)
                            Dim valor As String = String.Empty
                            valor = String.Join(" ", DirectCast(c, CheckedListBox).CheckedItems.Cast(Of String).ToArray())
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        Case ClsEnums.ControlesEnlaceConector.NUMERICO
                            Dim c As Control = ObtenerControl(f, e.RutaControl)
                            Dim valor As String = Convert.ToString(Convert.ToDecimal(DirectCast(c, NumericUpDown).Value))
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        Case ClsEnums.ControlesEnlaceConector.TEXTO
                            Dim c As Control = ObtenerControl(f, e.RutaControl)
                            Dim valor As String = Convert.ToString(Convert.ToString(DirectCast(c, TextBox).Text))
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                        Case ClsEnums.ControlesEnlaceConector.COLUMNA_TABLA
                            Dim valor As String = Convert.ToString(r.Cells(e.RutaControl.Split("|")(1)).Value)
                            v_linea = AplicarFormato(valor, e.Longitud, e.Formato, e.Decimales, e.idTipoDato)
                    End Select
                    sb.Append(v_linea)
                Next
                sb.AppendLine()
            Next
            Return sb
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
