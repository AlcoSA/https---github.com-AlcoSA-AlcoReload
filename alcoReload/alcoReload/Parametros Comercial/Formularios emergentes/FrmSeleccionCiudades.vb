Imports ReglasNegocio
Imports ReglasNegocio.Ciudades

Public Class FrmSeleccionCiudades
#Region "Variables"
    Private mPais As ClsPaises
    Private mDepto As ClsDepartamentos
    Private mCiudad As ClsCiudades

    Private _idCiudad As Integer
    Private _nombreCiudad As String

    Private _ciudad As Ciudad
    Private _depto As Departamento
    Private _pais As Pais

    Private _isFromLoad As Boolean = False
#End Region
#Region "Propiedades"
    Public Property Ciudad() As Ciudad
        Get
            Return _ciudad
        End Get
        Set(ByVal value As Ciudad)
            _ciudad = value
        End Set
    End Property
    Public Property Departamento() As Departamento
        Get
            Return _depto
        End Get
        Set(ByVal value As Departamento)
            _depto = value
        End Set
    End Property
    Public Property Pais() As Pais
        Get
            Return _pais
        End Get
        Set(ByVal value As Pais)
            _pais = value
        End Set
    End Property

    Public Property idCiudad() As Integer
        Get
            Return _idCiudad
        End Get
        Set(ByVal value As Integer)
            _idCiudad = value
        End Set
    End Property
    Public Property nombreCiudad() As String
        Get
            Return _nombreCiudad
        End Get
        Set(ByVal value As String)
            _nombreCiudad = value
        End Set
    End Property

    Public Property IsFromLoad() As Boolean
        Get
            Return _isFromLoad
        End Get
        Set(ByVal value As Boolean)
            _isFromLoad = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarPais()
        Try
            mPais = New ClsPaises
            Dim listPaises As List(Of Pais) = mPais.TraerxValorDefecto()
            If Not mPais.ExisteValorDefecto Then
                listPaises.Insert(0, New Pais)
            End If
            cmbPais.DisplayMember = "descripcion"
            cmbPais.ValueMember = "Id"
            cmbPais.DataSource = listPaises
            cmbDepartamento.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDepartamento(idPais As Integer)
        Try
            mDepto = New ClsDepartamentos
            Dim listDptos As List(Of Departamento) = mDepto.TraerxValorDefectoAndIdPais(idPais)
            If Not mDepto.ExisteValorDefecto Then
                listDptos.Insert(0, New Departamento)
            End If
            cmbDepartamento.DisplayMember = "descripcion"
            cmbDepartamento.ValueMember = "Id"
            cmbDepartamento.DataSource = listDptos
            cmbCiudad.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCiudad(idDpto As Integer)
        Try
            mCiudad = New ClsCiudades
            Dim listCiudades As List(Of Ciudad) = mCiudad.TraerxIdDepartamentoAndValorDefecto(idDpto)
            If Not mCiudad.ExisteValorDefecto Then
                listCiudades.Insert(0, New Ciudad)
            End If
            cmbCiudad.DisplayMember = "nombreCiudad"
            cmbCiudad.ValueMember = "Id"
            cmbCiudad.DataSource = listCiudades
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub ciudadDefecto()
        Try
            cargarPais()
            cargarDepartamento(cmbPais.SelectedValue)
            cargarCiudad(cmbDepartamento.SelectedValue)
            _idCiudad = cmbCiudad.SelectedValue
            _nombreCiudad = cmbCiudad.Text
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmSeleccionCiudades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarPais()
            If cmbPais.Text <> String.Empty Then
                cmbDepartamento.Enabled = True
                If cmbDepartamento.Text <> String.Empty Then
                    cmbCiudad.Enabled = True
                End If
            End If

            If _isFromLoad Then
                cmbPais.SelectedItem = _pais

                cargarDepartamento(_pais.Id)
                mDepto = New ClsDepartamentos
                cmbDepartamento.SelectedItem = mDepto.TraerxIdPaisAndIdSiesa(_pais.Id, _depto.idSiesa)

                cargarCiudad(_depto.Id)
                mCiudad = New ClsCiudades
                cmbCiudad.SelectedItem = mCiudad.TraerxIdDeptoAndIdSiesa(_depto.Id, _ciudad.idSiesa)
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbPais_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedValueChanged
        Try
            cmbDepartamento.Enabled = True
            cargarDepartamento(cmbPais.SelectedValue)
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbDepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedValueChanged
        Try
            cmbCiudad.Enabled = True
            cargarCiudad(cmbDepartamento.SelectedValue)
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        _idCiudad = cmbCiudad.SelectedValue
        _nombreCiudad = cmbCiudad.Text
        _ciudad = cmbCiudad.SelectedItem
        _depto = cmbDepartamento.SelectedItem
        _pais = cmbPais.SelectedItem
        Me.DialogResult = DialogResult.OK
    End Sub
End Class