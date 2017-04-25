Imports ReglasNegocio
Imports Formulador
Public Class FrmCargaPlantillas
#Region "Variables"
    Private _curid As Integer
    Private _analizador As AnalizadorLexico
    Private _precio As Decimal = 0.0
    Private _costo As Decimal = 0.0
    Private _puntosvisibles As Boolean = False
    Private dic As New Dictionary(Of String, String)
    Private _idplantilla As Integer = 0
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _descuento As Decimal
    Private _despVidrio As Decimal
    Private _despPerfiles As Decimal
    Private _despAccesorios As Decimal
    Private _despOtros As Decimal
    Private cp As New CargasPlantilla
    Private _onload As Boolean = False
    Private _id_cotiza As Integer = 0
    Private _versionCostoKiloAluminio As Integer = 0
    Private _versionCostoVidrio As Integer = 0
    Private _versionCostoAccesorio As Integer = 0
    Private _versionCostoAcabado As Integer = 0
    Private _versionCostoNivel As Integer = 0
    Private _versionCostoOtrosArticulos As Integer = 0

#End Region
#Region "Propiedades"
    Public Property Id_Cotiza As Integer
        Get
            Return _id_cotiza
        End Get
        Set(value As Integer)
            _id_cotiza = value
        End Set
    End Property
    Public Property VersionCostoKiloAluminio As Integer
        Get
            Return _versionCostoKiloAluminio
        End Get
        Set(value As Integer)
            _versionCostoKiloAluminio = value
        End Set
    End Property
    Public Property VersionCostoVidrio As Integer
        Get
            Return _versionCostoVidrio
        End Get
        Set(value As Integer)
            _versionCostoVidrio = value
        End Set
    End Property
    Public Property VersionCostoAccesorio As Integer
        Get
            Return _versionCostoAccesorio
        End Get
        Set(value As Integer)
            _versionCostoAccesorio = value
        End Set
    End Property
    Public Property VersionCostoAcabado As Integer
        Get
            Return _versionCostoAcabado
        End Get
        Set(value As Integer)
            _versionCostoAcabado = value
        End Set
    End Property
    Public Property VersionCostoNivel As Integer
        Get
            Return _versionCostoNivel
        End Get
        Set(value As Integer)
            _versionCostoNivel = value
        End Set
    End Property
    Public Property VersionCostoOtrosArticulos As Integer
        Get
            Return _versionCostoOtrosArticulos
        End Get
        Set(value As Integer)
            _versionCostoOtrosArticulos = value
        End Set
    End Property
    Public Property CurId As Integer
        Get
            Return _curid
        End Get
        Set(ByVal value As Integer)
            _curid = value
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
    Private _analizadoOriginal As AnalizadorLexico
    Public ReadOnly Property analizadoOriginal() As AnalizadorLexico
        Get
            Return _analizadoOriginal
        End Get
    End Property
    Public ReadOnly Property Precio As Decimal
        Get
            Return _precio
        End Get
    End Property
    Public ReadOnly Property Costo As Decimal
        Get
            Return _costo
        End Get
    End Property
    Public ReadOnly Property DiccionarioVariables As Dictionary(Of String, String)
        Get
            Return dic
        End Get
    End Property
    Public Property IdPlantilla As Integer
        Get
            Return _idplantilla
        End Get
        Set(value As Integer)
            _idplantilla = value
        End Set
    End Property
    Public Property Factor As Decimal
        Get
            Return nudfactor.Value
        End Get
        Set(ByVal value As Decimal)
            nudfactor.Value = value
        End Set
    End Property
    Public Property descuento() As Decimal
        Get
            Return _descuento
        End Get
        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property

#End Region
#Region "Procedimientos"
    Private Sub cargarPlantillas()
        Try
            Dim pmodelo As New ClsPlantillasModelos
            If itFamilia.Text <> String.Empty Then
                pmodelo.TraerxIdFamilia(Convert.ToInt32(itFamilia.Seleted_rowid), itPlantillas.TablaFuente)
            Else
                pmodelo.TraerxEstado(ClsEnums.Estados.ACTIVO, itPlantillas.TablaFuente)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarVariablesplantilla()
        Try
            dwitems.Rows.Clear()
            If _analizador Is Nothing Then Return
            cp.CargarPlantillaOriginal(Convert.ToInt32(itPlantillas.Seleted_rowid), _analizador, dic)
            cp.ValorarAnalizador(_analizador, _id_cotiza, VersionCostoAcabado, VersionCostoNivel,
                                 VersionCostoKiloAluminio, VersionCostoVidrio, VersionCostoAccesorio,
                                 VersionCostoOtrosArticulos)
            _analizador.ListaVariables.ToList.ForEach(
                Sub(v)
                    Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                    r.Cells(id.Index).Value = v.Id
                    r.Cells(variable.Index).Value = v.Nombre
                    r.Cells(tipodato.Index).Value = v.TipoValor
                    If v.Restricciones.Contains("MINIMO") Then
                        r.Cells(valorminimo.Index).Value = v.Restricciones.Item("MINIMO").Valor
                        r.Cells(valorminimo.Index).Tag = v.Restricciones.Item("MINIMO").Formula
                    Else
                        r.Cells(valorminimo.Index).Value = String.Empty
                    End If
                    If v.Restricciones.Contains("MAXIMO") Then
                        r.Cells(valormaximo.Index).Value = v.Restricciones.Item("MAXIMO").Valor
                        r.Cells(valormaximo.Index).Tag = v.Restricciones.Item("MAXIMO").Formula
                    Else
                        r.Cells(valormaximo.Index).Value = String.Empty
                    End If
                    If v.PosiblesValores.Count > 0 Then
                        Dim valvar As New ClsValoresVariables
                        Dim lvars As List(Of ValorVariable) = valvar.TraerxIdVariable(v.Id)
                        Dim lvar() As String = lvars.Select(Function(x) x.Valor).ToArray()
                        r.Cells(valor.Index) = New DataGridViewComboBoxCell()
                        DirectCast(r.Cells(valor.Index), DataGridViewComboBoxCell).Items.AddRange(lvar)
                        If v.PosiblesValores.Contains(v.Valor) Then
                            r.Cells(valor.Index).Value = v.Valor
                        Else
                            r.Cells(valor.Index).Value = lvars.FirstOrDefault(Function(x) x.ValorporDefecto).Valor
                        End If
                    Else
                        r.Cells(valor.Index).Value = v.Valor
                    End If
                End Sub
                )
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
                    valminimo = Convert.ToString(r.Cells(valorminimo.Index).Value)
                    valmaximo = Convert.ToString(r.Cells(valormaximo.Index).Value)
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
            Dim ej As New Ejecutor
            Dim errores As String = String.Empty
            dwitems.Rows.Cast(Of DataGridViewRow).ToList.ForEach(Sub(r)
                                                                     Dim v As Parametro = _analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                                                                     If v.Restricciones.Contains("MINIMO") Then
                                                                         r.Cells(valorminimo.Index).Value = v.Restricciones.Item("MINIMO").Valor
                                                                     End If
                                                                     If v.Restricciones.Contains("MAXIMO") Then
                                                                         r.Cells(valormaximo.Index).Value = v.Restricciones.Item("MAXIMO").Valor
                                                                     End If

                                                                     If v.TipoValor = TiposValores.Numerico Then
                                                                         Dim _vmin = ej.ObtenerTokens(Convert.ToString(r.Cells(valorminimo.Index).Value))
                                                                         Dim valmin As String = ej.Parse(_vmin)
                                                                         Dim _vmax = ej.ObtenerTokens(Convert.ToString(r.Cells(valormaximo.Index).Value))
                                                                         Dim valmax As String = ej.Parse(_vmax)
                                                                         Dim vmin As Decimal = If(Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)), valmin, 0)
                                                                         Dim vmax As Decimal = If(Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)), valmax, Decimal.MaxValue)
                                                                         Dim _val = ej.ObtenerTokens(Convert.ToString(r.Cells(valor.Index).Value))
                                                                         Dim val As String = ej.Parse(_val)
                                                                         If (Convert.ToDecimal(val) < vmin Or
                                                                             Convert.ToDecimal(val) > vmax) And vmax >= vmin Then
                                                                             errores &= v.Nombre & ", "
                                                                             r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                                                             RevisaryCrearVariableGeneral(r)
                                                                         End If
                                                                     End If
                                                                 End Sub)
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
#Region "Procedimientos Controles"
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            If _analizadoOriginal IsNot Nothing Then
                _analizador = _analizadoOriginal
                If _curid > 0 Then
                    cp.ValorarAnalizador(_analizador, _id_cotiza, VersionCostoAcabado, VersionCostoNivel,
                                         VersionCostoKiloAluminio, VersionCostoVidrio, VersionCostoAccesorio,
                                         VersionCostoOtrosArticulos)
                End If
            End If
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub CargaModificable()
        Try
            dwitems.Rows.Clear()
            Dim valvar As New ClsValoresVariables
            _analizador.ListaVariables.ToList().ForEach(Sub(var)
                                                            Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                                                            r.Cells(id.Index).Value = var.Id
                                                            r.Cells(variable.Index).Value = var.Nombre
                                                            Dim lvvar As List(Of ValorVariable) = valvar.TraerxIdVariable(var.Id)
                                                            If lvvar.Count > 0 Then
                                                                r.Cells(valor.Index) = New DataGridViewComboBoxCell()
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
                                                                r.Cells(valor.Index).Value = var.Valor
                                                            End If
                                                            If var.Restricciones.Contains("MINIMO") Then
                                                                r.Cells(valorminimo.Index).Value = var.Restricciones.Item("MINIMO").Valor
                                                            End If
                                                            If var.Restricciones.Contains("MAXIMO") Then
                                                                r.Cells(valormaximo.Index).Value = var.Restricciones.Item("MAXIMO").Valor
                                                            End If
                                                            r.Cells(tipodato.Index).Value = var.TipoValor
                                                        End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub FrmCargaVariables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _onload = True
            Dim fmodelo As New ClsFamiliaModelo()
            fmodelo.TraerxEstado(ClsEnums.Estados.ACTIVO, itFamilia.TablaFuente)
            cargarPlantillas()
            If _idplantilla > 0 Then
                Dim v As New ClsPlantillasModelos
                Dim plantilla As PlantillaModelo = v.TraerxId(_idplantilla, itFamilia.TablaFuente)
                Dim expresion As String
                expresion = itPlantillas.Id_Column_Name & "='" & _idplantilla & "'"
                itFamilia.Text = plantilla.FamiliaModelo
                itFamilia.Seleted_rowid = plantilla.IdFamiliaModelo
                itPlantillas.Seleted_rowid = plantilla.Id
                itPlantillas.Text = plantilla.NombreModelo
                itPlantillas.selected_item = itPlantillas.TablaFuente.Select(expresion)(0)
                If _analizador Is Nothing Then
                    _analizador = New AnalizadorLexico
                Else
                    CargaModificable()
                End If
            End If
            _onload = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmCargaPlantillas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If _curid > 0 Or _analizador IsNot Nothing Then
                If MsgBox("¿Desea actualizar el diseño?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    _analizador = New AnalizadorLexico
                    cargarVariablesplantilla()
                End If
            Else
                cargarVariablesplantilla()
            End If
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

                        Dim ej As New Ejecutor()
                        Dim v = ej.ObtenerTokens(Convert.ToString(r.Cells(valor.Index).Value))
                        Dim val As String = ej.Parse(v)

                        If Not IsNumeric(val) Then
                            MsgBox("EL valor debe ser numérico. Verifique la información")
                            r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                            Return
                        Else
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)) Then
                                Dim vmin = ej.ObtenerTokens(Convert.ToString(r.Cells(valorminimo.Index).Value))
                                Dim valmin As String = ej.Parse(vmin)
                                If Convert.ToDecimal(val) < Convert.ToDecimal(valmin) Then
                                    MsgBox("El valor no debe ser menor que la restricción de valor mínimo. Verifique la información", MsgBoxStyle.Critical)
                                    r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                    Return
                                End If
                            End If
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)) Then
                                Dim vmax = ej.ObtenerTokens(Convert.ToString(r.Cells(valormaximo.Index).Value))
                                Dim valmax As String = ej.Parse(vmax)
                                If Convert.ToDecimal(val) > Convert.ToDecimal(valmax) Then
                                    MsgBox("El valor no debe ser mayor que la restricción de valor máximo. Verifique la información", MsgBoxStyle.Critical)
                                    r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                    Return
                                End If
                            End If
                        End If
                    Case Is = ClsEnums.TiposDato.TEXTO

                        If Not (String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).EditedFormattedValue)) And String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).EditedFormattedValue))) Then
                            Dim vmax As String = Convert.ToString(r.Cells(valormaximo.Index).Value)
                            Dim vmin As String = Convert.ToString(r.Cells(valorminimo.Index).Value)
                            If (Convert.ToString(r.Cells(valor.Index).Value) <> vmax And Convert.ToString(r.Cells(valor.Index).Value) <> vmin) Then
                                MsgBox("El valor no debe ser diferente al máximo perminitdo, ni al mínimo permitido. Verifique la información", MsgBoxStyle.Critical)
                                r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                Return
                            End If
                        End If
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
                For Each r As DataGridViewRow In dwitems.Rows
                    _analizador.ListaVariables.Item(Convert.ToString(r.Cells(variable.Index).Value)).Valor = r.Cells(valor.Index).Value
                Next
                Dim cp As New CargasPlantilla
                cp.ValorarAnalizador(_analizador, _id_cotiza, VersionCostoAcabado, VersionCostoNivel,
                                     VersionCostoKiloAluminio, VersionCostoVidrio, VersionCostoAccesorio,
                                     VersionCostoOtrosArticulos)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itFamilia_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itFamilia.selected_value_changed
        Try
            cargarPlantillas()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itPlantillas_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itPlantillas.selected_value_changed
        Try
            If Not _onload And Not String.IsNullOrEmpty(itPlantillas.Seleted_rowid) Then
                _analizador = New AnalizadorLexico
                itFamilia.Text = e.ValorSecundario
                cargarVariablesplantilla()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwitems.EditingControlShowing
        Try
            If e.Control.GetType().BaseType.Name = "TextBox" Then
                Dim validar As TextBox = CType(e.Control, TextBox)
                validar.CharacterCasing = CharacterCasing.Upper
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region
End Class