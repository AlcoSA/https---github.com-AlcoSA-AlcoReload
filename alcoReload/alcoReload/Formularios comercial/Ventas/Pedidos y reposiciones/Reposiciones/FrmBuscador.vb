Public Class FrmBuscador
#Region "Variables"
    Private _tabla As DataTable
    Private fuenteInicial As DataTable = Nothing
    Private _columnasVisibles As List(Of String)
    Private _columnasResultados As List(Of String)
    Private _resultados As Dictionary(Of String, String)
#End Region
#Region "Propiedades"
    ''' <summary>
    ''' Tabla fuente en la que se hará la búsqueda
    ''' </summary>
    ''' <returns></returns>
    Public Property Tabla() As DataTable
        Get
            Return _tabla
        End Get
        Set(ByVal value As DataTable)
            _tabla = value
        End Set
    End Property
    ''' <summary>
    ''' Columnas con el nombre que viene en el store procedure que serán visibles en el formulario de búsqueda
    ''' </summary>
    ''' <returns></returns>
    Public Property ColumnasVisibles() As List(Of String)
        Get
            Return _columnasVisibles
        End Get
        Set(ByVal value As List(Of String))
            _columnasVisibles = value
        End Set
    End Property
    ''' <summary>
    ''' Columnas con los valores que se van a devolver
    ''' </summary>
    ''' <returns></returns>
    Public Property ColumnasResultados() As List(Of String)
        Get
            Return _columnasResultados
        End Get
        Set(ByVal value As List(Of String))
            _columnasResultados = value
        End Set
    End Property
    ''' <summary>
    ''' Diccionario de datos con los valores encontrados, la columna KEY contiene los nombres de columnas resultados indicadas
    ''' </summary>
    ''' <returns></returns>
    Public Property Resultados() As Dictionary(Of String, String)
        Get
            Return _resultados
        End Get
        Set(ByVal value As Dictionary(Of String, String))
            _resultados = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub mostrarColumnasVisibles()
        Try
            If _columnasVisibles IsNot Nothing Then
                For Each c As DataGridViewColumn In dwItems.Columns
                    c.Visible = False
                Next
                For Each column As String In _columnasVisibles
                    For Each col As DataGridViewColumn In dwItems.Columns
                        If column = col.Name Then
                            col.Visible = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmBuscador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dwItems.TablaDatos = _tabla
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                _resultados = New Dictionary(Of String, String)
                If _columnasResultados IsNot Nothing Then
                    Dim row As DataGridViewRow = dwItems.Rows(e.RowIndex)
                    For Each column As String In _columnasResultados
                        For Each col As DataGridViewColumn In dwItems.Columns
                            If column = col.Name Then
                                _resultados.Add(column, row.Cells(col.Index).Value.ToString())
                            End If
                        Next
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If _resultados Is Nothing Then
                MsgBox("No se ha seleccionado ningún registro")
                Return
            End If
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class