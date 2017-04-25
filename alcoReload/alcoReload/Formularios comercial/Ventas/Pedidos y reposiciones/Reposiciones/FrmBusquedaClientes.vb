Imports ReglasNegocio

Public Class FrmBusqueda
#Region "Variables"
    Private fuenteInicial As DataTable = Nothing
    Private _buscoCliente As Boolean = False
    Private _cliente As clienteUnoee
    Private _obra As obrasUnoee
    Private _nitSelected As String
    Private _clienteSelected As String
    Private _codObraSelected As String
    Private _obraSelected As String

    Private _idCliente As Integer
#End Region
#Region "Propiedades"
    Public Property BuscoCliente() As Boolean
        Get
            Return _buscoCliente
        End Get
        Set(ByVal value As Boolean)
            _buscoCliente = value
        End Set
    End Property
    Public Property Cliente() As clienteUnoee
        Get
            Return _cliente
        End Get
        Set(ByVal value As clienteUnoee)
            _cliente = value
        End Set
    End Property
    Public Property Obra() As obrasUnoee
        Get
            Return _obra
        End Get
        Set(ByVal value As obrasUnoee)
            _obra = value
        End Set
    End Property
    Public Property NitSelected() As String
        Get
            Return _nitSelected
        End Get
        Set(ByVal value As String)
            _nitSelected = value
        End Set
    End Property
    Public Property ClienteSelected() As String
        Get
            Return _clienteSelected
        End Get
        Set(ByVal value As String)
            _clienteSelected = value
        End Set
    End Property
    Public Property CodObraSelected() As String
        Get
            Return _codObraSelected
        End Get
        Set(ByVal value As String)
            _codObraSelected = value
        End Set
    End Property
    Public Property ObraSelected() As String
        Get
            Return _obraSelected
        End Get
        Set(ByVal value As String)
            _obraSelected = value
        End Set
    End Property
    Public Property IdCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub columnasVisibles()
        Try
            If _buscoCliente = True Then
                For Each c As DataGridViewColumn In dwItems.Columns
                    If c.Name Is "nit" Then
                        c.HeaderText = "Nit"
                        c.Visible = True
                    ElseIf c.Name Is "nombreCliente" Then
                        c.HeaderText = "Nombre cliente"
                        c.Visible = True
                    Else
                        c.Visible = False
                    End If
                Next
            Else
                For Each c As DataGridViewColumn In dwItems.Columns
                    If c.Name Is "idObra" Then
                        c.HeaderText = "Código obra"
                        c.Visible = True
                    ElseIf c.Name Is "nombreObra" Then
                        c.HeaderText = "Nombre obra"
                        c.Visible = True
                    Else
                        c.Visible = False
                    End If
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarClientes()
        Try
            Dim mCliente As New clsClientesUnoee
            Dim listClientes As List(Of clienteUnoee) = mCliente.t200_selectAllClientesUnoee(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarObras()
        Try
            Dim mObra As New clsObrasUnoee
            Dim listObras As List(Of obrasUnoee) = mObra.traerObrasByID(_idCliente, dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmBusqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If _buscoCliente = True Then
                cargarClientes()
            Else
                cargarObras()
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
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If _buscoCliente Then
                If _nitSelected Is Nothing Or _clienteSelected Is Nothing Or _cliente Is Nothing Then
                    MessageBox.Show("Debe seleccionar un registro")
                    Return
                End If
                Me.DialogResult = DialogResult.OK
            Else
                If _codObraSelected Is Nothing Or _obraSelected Is Nothing Or _obra Is Nothing Then
                    MessageBox.Show("Debe seleccionar un registro")
                    Return
                End If
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
            If _buscoCliente Then
                Dim mCliente As New clsClientesUnoee
                _nitSelected = Convert.ToString(r.Cells("nit").Value)
                _clienteSelected = Convert.ToString(r.Cells("nombreCliente").Value)
                _cliente = mCliente.ClienteUnoeeByNit(_nitSelected)
            Else
                Dim mObra As New clsObrasUnoee
                _codObraSelected = Convert.ToString(r.Cells("idObra").Value)
                _obraSelected = Convert.ToString(r.Cells("nombreObra").Value)
                _obra = mObra.traerObraByIdClienteAndIdObra(_idCliente, CInt(r.Cells("idObra").Value))
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class