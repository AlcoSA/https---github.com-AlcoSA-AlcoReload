Imports ReglasNegocio
Public Class FrmReemplazarPlantilla
#Region "vars"
    Private _idseleccionado As Integer = 0
    Private _desdebase As Boolean = True
    Private _nitobra As String = String.Empty
    Private _codobra As String = String.Empty
#End Region
#Region "props"
    Public Property Id_Seleccionado As Integer
        Get
            Return _idseleccionado
        End Get
        Set(value As Integer)
            _idseleccionado = value
        End Set
    End Property
    Public Property Desde_Plantillas_Originales
        Get
            Return _desdebase
        End Get
        Set(value)
            _desdebase = value
            estado.Visible = _desdebase
            Obra.Visible = Not _desdebase
        End Set
    End Property
    Public WriteOnly Property Nit As String
        Set(value As String)
            _nitobra = value
        End Set
    End Property
    Public WriteOnly Property Codigo_Obra As String
        Set(value As String)
            _codobra = value
        End Set
    End Property
#End Region
    Private Sub FrmReemplazarPlantilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If _desdebase Then
                Dim mplantillamodelos As New ClsPlantillasModelos
                dwitems.TablaDatos = mplantillamodelos.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Else
                Dim mplantillamodelos As New ClsPlantillaOrdenProd
                dwitems.TablaDatos = mplantillamodelos.TraerHistorialCreadoTabla(_nitobra, _codobra)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwitems.CellDoubleClick
        Try
            Dim r As DataGridViewRow = dwitems.Rows(e.RowIndex)
            _idseleccionado = Convert.ToInt32(r.Cells(id.Index).Value)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class