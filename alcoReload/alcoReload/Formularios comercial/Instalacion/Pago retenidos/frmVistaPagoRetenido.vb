Imports ReglasNegocio

Public Class frmVistaPagoRetenido
#Region "Variables"
    Private _idPagoRetenido As Integer
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _proveedor As String
    Private _encargado As String
    Private _idEstado As Integer
#End Region
#Region "Propiedades"
    Public Property IdPagoRetenido() As Integer
        Get
            Return _idPagoRetenido
        End Get
        Set(ByVal value As Integer)
            _idPagoRetenido = value
        End Set
    End Property
    Public Property IdDocumento() As Integer
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As Integer)
            _idDocumento = value
        End Set
    End Property
    Public Property Documento() As String
        Get
            Return _documento
        End Get
        Set(ByVal value As String)
            _documento = value
        End Set
    End Property
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
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
    Public Property Encargado() As String
        Get
            Return _encargado
        End Get
        Set(ByVal value As String)
            _encargado = value
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
    Private Sub cargarMovimientos()
        Try
            Dim mMovitoPagoRet As New ClsMovitoPagoRetenido
            Dim list As List(Of movitoPagoRet) = mMovitoPagoRet.TraerxIdPagoRetenido(_idPagoRetenido)
            For Each mov As movitoPagoRet In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(col_id.Index).Value = mov.Id
                r.Cells(col_fechaCreacion.Index).Value = mov.FechaCreacion
                r.Cells(col_obra.Index).Value = mov.Obra
                r.Cells(col_valorPagado.Index).Value = mov.ValorPagado
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmVistaPagoRetenido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblDocumento.Text = _documento
            lblConsecutivo.Text = _consecutivo
            txtProveedor.Text = _proveedor
            txtEncargado.Text = _encargado
            cargarMovimientos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAnularPago_Click(sender As Object, e As EventArgs) Handles btnAnularPago.Click
        Try
            If _idEstado = ClsEnums.Estados.ANULADO Then
                MessageBox.Show("El pago de retenidos ya ha sido anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MessageBox.Show("¿Está seguro de anular el pago de retenidos?", "", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Information) = DialogResult.Yes Then
                    Dim mPagoRetenido As New ClsPagoRetenidos
                    mPagoRetenido.ActualizarEstado(False, _idPagoRetenido, ClsEnums.Estados.ANULADO, My.Settings.UsuarioActivo)
                    Dim mMovitoPagoRet As New ClsMovitoPagoRetenido
                    mMovitoPagoRet.ActualizarEstado(_idPagoRetenido, ClsEnums.Estados.ANULADO, My.Settings.UsuarioActivo)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class