Imports ReglasNegocio

Public Class frmModificarPrecio
#Region "Variables"
    Private _id As Integer
    Private _proveedor As String
    Private _concepto As String
    Private _precio As Decimal
    Private _porcentajeRetenido As Decimal
    Private _idEstado As Integer
#End Region
#Region "Propiedades"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
    Public Property PorcentajeRetenido() As Decimal
        Get
            Return _porcentajeRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcentajeRetenido = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarEstados()
        Try
            Dim mEstados As New ClsEstados
            Dim list As List(Of Estado) = mEstados.TraerTodos().Where(Function(a) a.Id = ClsEnums.Estados.ACTIVO Or
                                                                          a.Id = ClsEnums.Estados.INACTIVO).ToList
            cmbEstados.DisplayMember = "Descripcion"
            cmbEstados.ValueMember = "Id"
            cmbEstados.DataSource = list
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacion()
        Try
            txtProveedor.Text = _proveedor
            txtConcepto.Text = _concepto
            nudPrecio.Value = _precio
            nudPorcRetenido.Value = _porcentajeRetenido
            cmbEstados.SelectedValue = _idEstado
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmModificarPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarEstados()
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If MessageBox.Show("Se va a modificar el registro. ¿Está seguro de continuar con la operación?",
                               "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim mPrecioInstalacion As New ClsPreciosInstalacion
                mPrecioInstalacion.Modificar(_id, nudPrecio.Value, nudPorcRetenido.Value, cmbEstados.SelectedValue, My.Settings.UsuarioActivo)
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class