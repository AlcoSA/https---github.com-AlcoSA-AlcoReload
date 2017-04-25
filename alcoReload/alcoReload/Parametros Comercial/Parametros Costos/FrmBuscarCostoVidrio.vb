Imports ReglasNegocio

Public Class FrmBuscarCostoVidrio
#Region "Variables"
    Private mCostoVidrio As ClsCostoVidrio
    Private fuenteInicial As DataTable
    Private _listAgregados As List(Of costoVidrio)
#End Region
#Region "Propiedades"
    Public Property ListAgregados() As List(Of costoVidrio)
        Get
            Return _listAgregados
        End Get
        Set(ByVal value As List(Of costoVidrio))
            _listAgregados = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub prepararDatos(versionBase As Integer)
        Try
            mCostoVidrio = New ClsCostoVidrio
            mCostoVidrio.TraerTodos(versionBase, dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarVersiones()
        Try
            mCostoVidrio = New ClsCostoVidrio
            Dim maxVersion As Integer = mCostoVidrio.TraerMaxVersion()

            Dim listVersiones As New List(Of Integer)
            For i = 1 To maxVersion
                listVersiones.Add(i)
            Next

            cmbVersion.DataSource = listVersiones
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try

    End Sub
#End Region
    Private Sub FrmBuscarCostoVidrio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mCostoVidrio = New ClsCostoVidrio
            Dim maxVersion As Integer = mCostoVidrio.TraerMaxVersion()
            cargarVersiones()
            prepararDatos(maxVersion)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCambiarVersionBase_Click(sender As Object, e As EventArgs) Handles btnCambiarVersionBase.Click
        Try
            prepararDatos(cmbVersion.SelectedValue)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim frm As New FrmCostoVidrio
            _listAgregados = New List(Of costoVidrio)
            For Each r As DataGridViewRow In dwItems.Rows
                If Convert.ToBoolean(r.Cells(seleccion.Index).Value) = True Then
                    Dim obj As New costoVidrio
                    obj.FechaCreacion = r.Cells(fechaCreacion.Index).Value
                    obj.UsuarioCreacion = r.Cells(usuarioCreacion.Index).Value
                    obj.idArticulo = r.Cells(idArticulo.Index).Value
                    obj.articulo = r.Cells(articulo.Index).Value
                    obj.idEspesor = r.Cells(idEspesor.Index).Value
                    obj.espesor = r.Cells(espesor.Index).Value
                    obj.idAcabado = r.Cells(idAcabado.Index).Value
                    obj.acabado = r.Cells(acabado.Index).Value
                    obj.versionActual = r.Cells(versionActual.Index).Value
                    obj.nuevaVersion = r.Cells(nuevaVersion.Index).Value
                    obj.costo = r.Cells(costo.Index).Value

                    _listAgregados.Add(obj)
                End If
            Next
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class