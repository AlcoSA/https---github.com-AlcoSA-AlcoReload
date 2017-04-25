Imports ReglasNegocio
Public Class FrmParametrosInformesDinamicos
#Region "Variables"
    Private _idinforme As Integer = 0
    Private mparam As ClsParametrosInformesDinamicos
#End Region
#Region "Propiedades"
    Public Property IdInforme As Integer
        Get
            Return _idinforme
        End Get
        Set(value As Integer)
            _idinforme = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarTiposDato()
        Try
            Dim tdat As New ClsTiposDatos
            Dim ldat As List(Of TipoDato) = tdat.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = ldat
            tipodato.DisplayMember = "Nombre"
            tipodato.ValueMember = "Id"
            tipodato.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarDatos()
        Try
            Dim lpars As List(Of ParametroInforme) = mparam.TraerxIdInforme(_idinforme)
            For Each p In lpars
                Dim r As DataGridViewRow = dwparametros.Rows(dwparametros.Rows.Add())
                r.Cells(id.Index).Value = p.Id
                r.Cells(nombre.Index).Value = p.Nombre
                r.Cells(nombrebd.Index).Value = p.NombreBD
                r.Cells(tipodato.Index).Value = p.TipoDato
                r.Cells(estado.Index).Value = Not Convert.ToBoolean(p.IdEstado - 1)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function Validar() As Boolean
        Try
            For Each r As DataGridViewRow In dwparametros.Rows
                For i = 1 To dwparametros.Columns.Count - 1
                    If String.IsNullOrEmpty(Convert.ToString(r.Cells(i).Value)) Then
                        Return False
                    End If
                Next
            Next
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
    Private Sub btnagregarparametro_Click(sender As Object, e As EventArgs) Handles btnagregarparametro.Click
        Try
            dwparametros.Rows.Add()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmParametrosInformesDinamicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mparam = New ClsParametrosInformesDinamicos
            cargarTiposDato()
            CargarDatos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwparametros_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dwparametros.UserDeletingRow
        Try
            If e.Row.Index >= 0 Then
                If Not String.IsNullOrEmpty(Convert.ToString(e.Row.Cells(id.Index).Value)) Then
                    If MsgBox("Este registro ya se ha guardado. ¿Esta seguro que desea eliminarlo?") Then
                        mparam.EliminarporId(Convert.ToInt32(e.Row.Cells(id.Index).Value))
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            If Validar() Then
                For Each r As DataGridViewRow In dwparametros.Rows
                    If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(id.Index).Value)) Then
                        mparam.Modificar(Convert.ToInt32(r.Cells(id.Index).Value), My.Settings.UsuarioActivo,
                                         _idinforme, Convert.ToInt32(r.Cells(tipodato.Index).Value),
                                         Convert.ToString(r.Cells(nombrebd.Index).Value),
                                         Convert.ToString(r.Cells(nombre.Index).Value),
                                         Convert.ToInt32(r.Cells(estado.Index).Value) + 1)
                    Else
                        mparam.Insertar(My.Settings.UsuarioActivo,
                                         _idinforme, Convert.ToInt32(r.Cells(tipodato.Index).Value),
                                         Convert.ToString(r.Cells(nombrebd.Index).Value),
                                         Convert.ToString(r.Cells(nombre.Index).Value),
                                         Convert.ToInt32(r.Cells(estado.Index).Value) + 1)
                    End If
                Next
            Else
                MsgBox("Hay campos que altan por llenar. Verifique la información e intente nuevamente", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class