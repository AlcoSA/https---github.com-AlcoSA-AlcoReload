Public Class FrmCalendarioSemanas
#Region "Variables"
    Private _anio As Integer
    Private _semana As String
    Private _descripcion As String
    Private _fechaInicio As DateTime
    Private _fechaFin As DateTime
#End Region
#Region "Propiedades"
    Public Property Anio() As Integer
        Get
            Return _anio
        End Get
        Set(ByVal value As Integer)
            _anio = value
        End Set
    End Property
    Public Property Semana() As String
        Get
            Return _semana
        End Get
        Set(ByVal value As String)
            _semana = value
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
    Public Property FechaInicio() As DateTime
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As DateTime)
            _fechaInicio = value
        End Set
    End Property
    Public Property FechaFin() As DateTime
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As DateTime)
            _fechaFin = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub calcularSemanas(anio As Integer)
        Try
            Dim dtSemanas = New DataTable("Semanas")
            dtSemanas.Columns.Add("Codigo", System.Type.GetType("System.Int32"))
            dtSemanas.Columns.Add("Nombre", System.Type.GetType("System.String"))
            dtSemanas.Columns.Add("Inicio", System.Type.GetType("System.DateTime"))
            dtSemanas.Columns.Add("Fin", System.Type.GetType("System.DateTime"))
            Dim fechaRef As New Date(anio, 1, 1)
            While fechaRef.DayOfWeek <> DayOfWeek.Monday
                fechaRef = fechaRef.AddDays(1)
            End While
            For i As Integer = 0 To 51
                Dim r As DataRow = dtSemanas.NewRow
                r("Codigo") = i + 1
                r("Nombre") = fechaRef.AddDays(i * 7) & " al " & fechaRef.AddDays((i * 7) + 5)
                r("Inicio") = fechaRef.AddDays(i * 7)
                r("Fin") = fechaRef.AddDays((i * 7) + 5)
                dtSemanas.Rows.Add(r)
            Next

            For Each semana As DataRow In dtSemanas.Rows
                Dim cod As Integer = Convert.ToInt32(semana.Item("Codigo"))
                For Each ctrl As Control In PanelCalendario.Controls
                    If TypeOf (ctrl) Is Button Then
                        If ctrl.Name = "btn_semana" & cod Then
                            ctrl.Tag = semana.Item("Nombre")

                            Dim ToolTip As New ToolTip()
                            ToolTip.SetToolTip(ctrl, ctrl.Tag)

                            If Convert.ToDateTime(semana.Item("Fin")) < DateTime.Now.ToShortDateString Then
                                ctrl.Enabled = False
                            Else
                                ctrl.Enabled = True
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmCalendarioSemanas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtAnio.Text = _anio
            calcularSemanas(_anio)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btn_prevAnio_Click(sender As Object, e As EventArgs) Handles btn_prevAnio.Click
        Try
            Dim anioActual As Integer = Convert.ToInt32(txtAnio.Text)
            txtAnio.Text = Convert.ToString(anioActual - 1)
            calcularSemanas(Convert.ToInt32(txtAnio.Text))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btn_sgteAnio_Click(sender As Object, e As EventArgs) Handles btn_sgteAnio.Click
        Try
            Dim anioActual As Integer = Convert.ToInt32(txtAnio.Text)
            txtAnio.Text = Convert.ToString(anioActual + 1)
            calcularSemanas(Convert.ToInt32(txtAnio.Text))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btn_semana_Click(sender As Object, e As EventArgs) Handles btn_semana1.Click, btn_semana2.Click,
            btn_semana3.Click, btn_semana4.Click, btn_semana5.Click, btn_semana6.Click, btn_semana7.Click,
            btn_semana8.Click, btn_semana9.Click, btn_semana10.Click, btn_semana11.Click, btn_semana12.Click,
            btn_semana13.Click, btn_semana14.Click, btn_semana15.Click, btn_semana16.Click, btn_semana17.Click,
            btn_semana18.Click, btn_semana19.Click, btn_semana20.Click, btn_semana21.Click, btn_semana22.Click,
            btn_semana23.Click, btn_semana24.Click, btn_semana25.Click, btn_semana26.Click, btn_semana27.Click,
            btn_semana28.Click, btn_semana29.Click, btn_semana30.Click, btn_semana31.Click, btn_semana32.Click,
            btn_semana33.Click, btn_semana34.Click, btn_semana35.Click, btn_semana36.Click, btn_semana37.Click,
            btn_semana38.Click, btn_semana39.Click, btn_semana40.Click, btn_semana41.Click, btn_semana42.Click,
            btn_semana43.Click, btn_semana44.Click, btn_semana45.Click, btn_semana46.Click, btn_semana47.Click,
            btn_semana48.Click, btn_semana49.Click, btn_semana50.Click, btn_semana51.Click, btn_semana52.Click
        Dim btn As Button = DirectCast(sender, Button)
        _semana = btn.Text
        _descripcion = "Semana " & btn.Text & ", del " & Convert.ToString(btn.Tag)
        Dim arr As String() = Convert.ToString(btn.Tag).Split(" al ")
        _fechaInicio = Convert.ToDateTime(arr(0))
        _fechaFin = Convert.ToDateTime(arr(2))
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FrmCalendarioSemanas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmCalendarioSemanas_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Try
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class