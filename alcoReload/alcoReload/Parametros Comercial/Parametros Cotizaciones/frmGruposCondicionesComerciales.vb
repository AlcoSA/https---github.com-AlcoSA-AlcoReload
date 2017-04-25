Imports ReglasNegocio
Imports ReglasNegocio.FormasPago
Imports Validaciones
Public Class frmGruposCondicionesComerciales
#Region "Variables"
    Private mGrupoCondiciones As ClsGruposCondiciones
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Propiedades"
    Private _TipoOperacion As String
    Public Property TipoOperacion() As String
        Get
            Return _TipoOperacion
        End Get
        Set(ByVal value As String)
            _TipoOperacion = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarDatos(tb As DataTable)
        Try
            If tb.Rows.Count = 0 Then Exit Sub
            tb.Columns.Cast(Of DataColumn).AsParallel.ForAll(Sub(columna)
                                                                 If dwItems.Columns.Contains(columna.ColumnName) Then
                                                                     dwItems.Columns(columna.ColumnName).DataPropertyName = columna.ColumnName
                                                                 End If
                                                             End Sub)
            dwItems.DataSource = tb
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEstados()
        Try
            Dim mEstado As New ClsEstados
            Dim listEstados As List(Of Estado) = mEstado.TraerTodos()
            Dim bsource As New BindingSource()
            bsource.DataSource = listEstados.Where(Function(a) a.Id < 3)
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(id.DataPropertyName).Value)
            txtDescripcion.Text = r.Cells(Descripcion.DataPropertyName).Value.ToString()
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validar()
        Try
            objValidacion = New ClsValidaciones
            mGrupoCondiciones = New ClsGruposCondiciones
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then Return False
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If mGrupoCondiciones.selectAll.ToList.Where(Function(A) A.descripcion = txtDescripcion.Text).Count > 0 Then
                    ErrorProvider1.SetError(txtDescripcion, "Ya existe este registro")
                    Return False
                End If
                ErrorProvider1.Clear()
            End If
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validar() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mGrupoCondiciones.insert(txtDescripcion.Text, My.Settings.UsuarioActivo, cmbEstado.SelectedValue)

                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mGrupoCondiciones.update(curid, txtDescripcion.Text, My.Settings.UsuarioActivo)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmGruposCondicionesComerciales_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            txtDescripcion.Text = String.Empty
            cmbEstado.SelectedValue = 1
            ErrorProvider1.Clear()
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Procecimientos Controles"
    Private Sub frmGruposCondicionesComerciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mGrupoCondiciones = New ClsGruposCondiciones
        Dim objLista As List(Of grupoCondiones) = mGrupoCondiciones.selectAll(dwItems.TablaDatos)
        If dwItems.TablaDatos IsNot Nothing Then
            fuenteInicial = dwItems.TablaDatos
            cargarDatos(fuenteInicial)
        End If
        cargarEstados()
    End Sub
    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region


End Class