Imports ReglasNegocio
Public Class FrmCambioEstadoContratado
#Region "Variables"
    Private _idcontrato As Integer
    Private mcontrato As Contratos.clsContratos
#End Region
#Region "Propiedades"
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub CargarEstados()
        Try
            Dim mestados As New ClsEstados
            Dim bsource As New BindingSource()
            If mcontrato.VerificarMovimientos(IdContrato) Then
                bsource.DataSource = mestados.TraerTodos().Where(Function(x) (New ClsEnums.Estados() {ClsEnums.Estados.ACTIVO, ClsEnums.Estados.PARA_LIQUIDAR, ClsEnums.Estados.LIQUIDADO}).Contains(x.Id)).ToList()
            Else
                bsource.DataSource = mestados.TraerTodos().Where(Function(x) (New ClsEnums.Estados() {ClsEnums.Estados.ACTIVO, ClsEnums.Estados.ANULADO, ClsEnums.Estados.PARA_LIQUIDAR, ClsEnums.Estados.LIQUIDADO}).Contains(x.Id)).ToList()
            End If
            cmbestados.DisplayMember = "Descripcion"
            cmbestados.ValueMember = "Id"
            cmbestados.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
    Private Sub FrmCambioEstadoContratado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mcontrato = New Contratos.clsContratos
            CargarEstados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            mcontrato.ModificarEstadoContrato(_idcontrato, Convert.ToInt32(cmbestados.SelectedValue),
                                              My.Settings.UsuarioActivo)
            DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class