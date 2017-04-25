Imports Formulador
Imports ReglasNegocio
Public Class FrmModificacionVariables
#Region "Variables"
    Private _analizador As AnalizadorLexico
    Private _idplantilla As Integer = 0
#End Region

#Region "Propiedades"
    Public Property IdPlantilla As Integer
        Get
            Return _idplantilla
        End Get
        Set(value As Integer)
            _idplantilla = value
        End Set
    End Property

    Public Property Analizador As AnalizadorLexico
        Get
            Return _analizador
        End Get
        Set(value As AnalizadorLexico)
            _analizador = value
        End Set
    End Property

#End Region

#Region "Procedimientos"
    Private Sub cargarVariablesplantillaCotiza()
        Try
            dwitems.Rows.Clear()
            If _analizador Is Nothing Then Return
            Dim mvarplantilla As New ClsVariablesPlantillaCotiza
            Dim valvar As New ClsValoresVariables
            Dim listvariablesutilizadas As List(Of VariableItemCotiza) = mvarplantilla.TraerxIdItemCotiza(_idplantilla)
            listvariablesutilizadas.ToList.ForEach(Sub(var)
                                                       Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                                                       r.Cells(id.Index).Value = var.IdVariable
                                                       r.Cells(variable.Index).Value = var.NombreVariable
                                                       r.Cells(tipodato.Index).Value = var.TipoDato

                                                       r.Cells(valorminimo.Index).Tag = var.Minimo
                                                       r.Cells(valorminimo.Index).Value = var.ValorMinimo

                                                       If var.DesdeBaseDatos Then
                                                           r.Cells(valor.Index) = New DataGridViewComboBoxCell()
                                                           Dim lvvar As List(Of ValorVariable) = valvar.TraerxIdVariable(var.IdVariable)
                                                           DirectCast(r.Cells(valor.Index), DataGridViewComboBoxCell).Items.AddRange(lvvar.Select(Function(x) x.Valor).ToArray())
                                                           If lvvar.Where(Function(x) x.ValorporDefecto).Count() > 0 Then
                                                               r.Cells(valor.Index).Value = lvvar.First(Function(x) x.ValorporDefecto).Valor
                                                           End If
                                                           If Not String.IsNullOrEmpty(var.Valor) Then
                                                               Dim cmbcell As DataGridViewComboBoxCell = r.Cells(valor.Index)
                                                               If cmbcell.Items.Contains(var.Valor) Then
                                                                   r.Cells(valor.Index).Value = var.Valor
                                                               End If
                                                           End If
                                                       Else
                                                           If Not String.IsNullOrEmpty(var.Valor) Then
                                                               r.Cells(valor.Index).Value = var.Valor
                                                           Else
                                                               If String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)) Then
                                                                   Select Case var.TipoDato - 1
                                                                       Case Is = ClsEnums.TiposDato.NUMERICO
                                                                           r.Cells(valor.Index).Value = 0
                                                                       Case Is = ClsEnums.TiposDato.TEXTO
                                                                           r.Cells(valor.Index).Value = String.Empty
                                                                       Case Is = ClsEnums.TiposDato.BOOLEANO
                                                                           r.Cells(valor.Index).Value = 0
                                                                       Case Is = ClsEnums.TiposDato.FECHA
                                                                           r.Cells(valor.Index).Value = DateTime.MinValue.ToShortDateString()
                                                                   End Select
                                                               Else
                                                                   r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                                               End If
                                                           End If
                                                       End If
                                                       r.Cells(valormaximo.Index).Tag = var.Maximo
                                                       r.Cells(valormaximo.Index).Value = var.ValorMaximo


                                                       'If var.NombreVariable = "PUNTOS" And Not _puntosvisibles Then
                                                       '    r.Visible = False
                                                       'End If

                                                       RevisaryCrearVariableGeneral(r)
                                                   End Sub)
            Dim cp As New CargasPlantilla
            cp.cargaryCrearDescuentosGlobales(_idplantilla, _analizador, ClsEnums.TipoCarga.COTIZA)
            cp.CargaryCrearMaterial(_idplantilla, _analizador, ClsEnums.TipoCarga.COTIZA)
            ValorarCompleto()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub RevisaryCrearVariableGeneral(r As DataGridViewRow)
        Try
            Dim valorvaria As String = String.Empty
            Dim valminimo As String = String.Empty
            Dim valmaximo As String = String.Empty
            Dim cformula As String = String.Empty
            Dim tdato As Integer = Convert.ToInt32(r.Cells(tipodato.Index).Value)

            Select Case tdato
                Case Is = ClsEnums.TiposDato.NUMERICO
                    valminimo = If(String.IsNullOrEmpty(r.Cells(valorminimo.Index).Value), 0, r.Cells("valorminimo").Value)
                    valmaximo = If(String.IsNullOrEmpty(r.Cells(valormaximo.Index).Value), Int32.MaxValue, r.Cells("valormaximo").Value)
                Case Is = ClsEnums.TiposDato.TEXTO
                    valminimo = r.Cells(valorminimo.Index).Value.ToString()
                    valmaximo = r.Cells(valormaximo.Index).Value.ToString()
                Case Is = ClsEnums.TiposDato.BOOLEANO
                    valminimo = 0
                    valmaximo = 1
                Case Is = ClsEnums.TiposDato.FECHA
                    valminimo = If(String.IsNullOrEmpty(r.Cells(valorminimo.Index).Value), Date.MinValue.ToString(), r.Cells(valorminimo.Index).Value)
                    valmaximo = If(String.IsNullOrEmpty(r.Cells(valormaximo.Index).Value), Date.MaxValue.ToString(), r.Cells(valormaximo.Index).Value)
            End Select
            valorvaria = Convert.ToString(r.Cells(valor.Index).Value)

            If _analizador.ListaVariables.Contains(r.Cells(variable.Index).Value.ToString()) Then
                Dim param As Parametro = _analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                param.Restricciones.Clear()
                If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)) Then
                    If Convert.ToString(r.Cells(valorminimo.Index).Tag).StartsWith("=") Then
                        param.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(r.Cells(valorminimo.Index).Tag),
                                                                valminimo, tdato))
                    Else
                        param.Restricciones.Add(New Restriccion("MINIMO",
                                                                valminimo, tdato))
                    End If
                End If
                If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)) Then
                    If Convert.ToString(r.Cells(valormaximo.Index).Tag).StartsWith("=") Then
                        param.Restricciones.Add(New Restriccion("MAXIMO", Convert.ToString(r.Cells(valormaximo.Index).Tag),
                                                                    valmaximo, tdato))
                    Else
                        param.Restricciones.Add(New Restriccion("MAXIMO",
                                                                valmaximo, tdato))
                    End If
                End If
                param.TipoValor = tdato
                param.Valor = valorvaria
                param.Formula = valorvaria
            Else
                Dim param As New Parametro(r.Cells(variable.Index).Value.ToString(), valorvaria, valorvaria, tdato)
                param.Id = r.Cells(id.Index).Value
                If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)) Then
                    If Convert.ToString(r.Cells(valorminimo.Index).Tag).StartsWith("=") Then
                        param.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(r.Cells(valorminimo.Index).Tag),
                                                                valminimo, tdato))
                    Else
                        param.Restricciones.Add(New Restriccion("MINIMO",
                                                                valminimo, tdato))
                    End If
                End If

                If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)) Then
                    If Convert.ToString(r.Cells(valormaximo.Index).Tag).StartsWith("=") Then
                        param.Restricciones.Add(New Restriccion("MAXIMO", Convert.ToString(r.Cells(valormaximo.Index).Tag),
                                                                    valmaximo, tdato))
                    Else
                        param.Restricciones.Add(New Restriccion("MAXIMO",
                                                                valmaximo, tdato))
                    End If
                End If

                _analizador.ListaVariables.Add(param)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub ValorarCompleto()
        Try
            _analizador.ValorarRestricciones()
            Dim errores As String = String.Empty
            For Each r As DataGridViewRow In dwitems.Rows
                Dim v As Parametro = _analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                If v.Restricciones.Contains("MINIMO") Then
                    r.Cells(valorminimo.Index).Value = v.Restricciones.Item("MINIMO").Valor
                End If
                If v.Restricciones.Contains("MAXIMO") Then
                    r.Cells(valormaximo.Index).Value = v.Restricciones.Item("MAXIMO").Valor
                End If

                If v.TipoValor = TiposValores.Numerico Then
                    Dim vmin As Decimal = If(Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)), Convert.ToDecimal(r.Cells(valorminimo.Index).Value), 0)
                    Dim vmax As Decimal = If(Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)), Convert.ToDecimal(r.Cells(valormaximo.Index).Value), Decimal.MaxValue)
                    If (Convert.ToDecimal(r.Cells(valor.Index).Value) < vmin Or
                        Convert.ToDecimal(r.Cells(valor.Index).Value) > vmax) And vmax >= vmin Then
                        errores &= v.Nombre & ", "
                        r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                        RevisaryCrearVariableGeneral(r)
                    End If
                End If
            Next
            If Not String.IsNullOrEmpty(errores) Then
                ValorarCompleto()
            Else
                _analizador.ValorarElementosDescuentos()
                _analizador.ValorarElementosMaterial()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function validarVariables() As Boolean
        Try
            If dwitems.Rows.Count <= 0 Then
                MsgBox("El diseño actual no tiene elementos en su interior. Verifique la información", MsgBoxStyle.Critical)
                Return False
            End If
            For Each r As DataGridViewRow In dwitems.Rows
                If String.IsNullOrEmpty(Convert.ToString(r.Cells(valor.Index).Value)) Then
                    MsgBox("Todas las variables deben tener un valor. Verifique la información", MsgBoxStyle.Critical)
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmCargaVariables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _analizador = New AnalizadorLexico
            cargarVariablesplantillaCotiza()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwitems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwitems.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwitems.Rows(e.RowIndex)
                Select Case Convert.ToInt32(dwitems.Item(tipodato.Index, e.RowIndex).Value)
                    Case Is = ClsEnums.TiposDato.NUMERICO, ClsEnums.TiposDato.BOOLEANO
                        If Not IsNumeric(r.Cells(valor.Index).Value) Then
                            MsgBox("EL valor debe ser numérico. Verifique la información")
                            r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                            Return
                        Else
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)) Then
                                If Convert.ToDecimal(r.Cells(valor.Index).Value) < Convert.ToDecimal(r.Cells(valorminimo.Index).Value) Then
                                    MsgBox("El valor no debe ser menor que la restricción de valor mínimo. Verifique la información", MsgBoxStyle.Critical)
                                    r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                    Return
                                End If
                            End If
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)) Then
                                If Convert.ToDecimal(r.Cells(valor.Index).Value) > Convert.ToDecimal(r.Cells(valormaximo.Index).Value) Then
                                    MsgBox("El valor no debe ser mayor que la restricción de valor máximo. Verifique la información", MsgBoxStyle.Critical)
                                    r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                    Return
                                End If
                            End If
                        End If
                    Case Is = ClsEnums.TiposDato.TEXTO

                    Case Is = ClsEnums.TiposDato.FECHA

                End Select
                RevisaryCrearVariableGeneral(r)
                ValorarCompleto()
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            If validarVariables() Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class