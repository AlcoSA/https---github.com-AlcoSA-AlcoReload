Imports ReglasNegocio
Public Class Frmagregarvariables
#Region "vars"
    Private _listavariables As List(Of Variables)
#End Region
#Region "props"
    Public ReadOnly Property Variables_Seleccionadas As List(Of Variables)
        Get
            Return _listavariables
        End Get
    End Property
#End Region
    Private Sub Frmagregarvariables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim variab As New ClsVariables
            dwItem.TablaDatos = variab.TraerxEstado_Tabla(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            DialogResult = DialogResult.Cancel
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            DialogResult = DialogResult.OK
            _listavariables = New List(Of Variables)
            dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(x) Convert.ToBoolean(x.Cells(selecccionar.Index).Value)).ToList().ForEach(Sub(r)
                                                                                                                                              _listavariables.Add(New Variables(r.Cells(id.Index).Value,
                                                                                                        "", Now, r.Cells(nombre_variable.Index).Value,
                                                                                                        "", r.Cells(Id_TipoDato.Index).Value, r.Cells(Tipo_Dato.Index).Value,
                                                                                                        r.Cells(Valor_Desde_BD.Index).Value, False, False, "", Now, ClsEnums.Estados.ACTIVO, "",
                                                                                                        -1, False))
                                                                                                                                          End Sub)
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class