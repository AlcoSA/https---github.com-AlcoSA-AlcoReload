Imports ReglasNegocio
Public Class FrmListaCorte
#Region "vars"
    Private _idordenprod As Integer = 0
#End Region
#Region "props"
    Public Property IdOrdenProduccion As Integer
        Get
            Return _idordenprod
        End Get
        Set(value As Integer)
            _idordenprod = value
        End Set
    End Property
#End Region
#Region "procs"
    Private Sub cargar_lista()
        Try
            Dim m_orden_prod As New ClsEncabeOrdenProd
            Dim m_meds As New ClsMedidasPerfileria
            Dim tb As DataTable = m_orden_prod.TraerListadeCorte(_idordenprod)
            Dim meds = m_meds.TraerxEstado(ClsEnums.Estados.ACTIVO)
            dwitems.DataSource = tb
            Dim l_agrup = (From r In dwitems.Rows.Cast(Of DataGridViewRow)
                           Group r By referencia = Convert.ToString(r.Cells(referencia.Index).Value),
                               acabado = Convert.ToString(r.Cells(acabado.Index).Value) Into Group).Select(Function(f) f.Group.First()).ToList()
            l_agrup.ForEach(Sub(f)

                                Dim r As DataGridViewRow = dwagrupados.Rows(dwagrupados.Rows.Add())
                                r.Cells(gid.Index).Value = f.Cells(idarticulo.Index).Value
                                r.Cells(greferencia.Index).Value = f.Cells(referencia.Index).Value
                                r.Cells(gacabado.Index).Value = f.Cells(acabado.Index).Value
                                Dim cb As DataGridViewComboBoxCell = DirectCast(r.Cells(lotesperfileria.Index), DataGridViewComboBoxCell)
                                cb.ValueMember = "id"
                                cb.DisplayMember = "medida"
                                cb.DataSource = meds.Where(Function(m) m.IdPerfil = Convert.ToInt32(r.Cells(gid.Index).Value)).ToList() 'tbmeds.Rows.Cast(Of DataRow).Where(Function(x) Convert.ToInt32(x.Item("id")) = Convert.ToInt32(r.Cells(id.Index).Value)).CopyToDataTable()
                            End Sub
                )

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargar_lista_guardada(tb As DataTable)
        Try
            Dim m_orden_prod As New ClsEncabeOrdenProd
            Dim m_meds As New ClsMedidasPerfileria
            Dim meds = m_meds.TraerxEstado(ClsEnums.Estados.ACTIVO)
            dwitems.DataSource = tb
            Dim l_agrup = (From r In dwitems.Rows.Cast(Of DataGridViewRow)
                           Group r By referencia = Convert.ToString(r.Cells(referencia.Index).Value),
                               acabado = Convert.ToString(r.Cells(acabado.Index).Value) Into Group).Select(Function(f) f.Group.First()).ToList()
            l_agrup.ForEach(Sub(f)

                                Dim r As DataGridViewRow = dwagrupados.Rows(dwagrupados.Rows.Add())
                                r.Cells(gid.Index).Value = f.Cells(idarticulo.Index).Value
                                r.Cells(greferencia.Index).Value = f.Cells(referencia.Index).Value
                                r.Cells(gacabado.Index).Value = f.Cells(acabado.Index).Value
                                Dim cb As DataGridViewComboBoxCell = DirectCast(r.Cells(lotesperfileria.Index), DataGridViewComboBoxCell)
                                cb.ValueMember = "id"
                                cb.DisplayMember = "medida"
                                cb.DataSource = meds.Where(Function(m) m.IdPerfil = Convert.ToInt32(r.Cells(gid.Index).Value)).ToList() 'tbmeds.Rows.Cast(Of DataRow).Where(Function(x) Convert.ToInt32(x.Item("id")) = Convert.ToInt32(r.Cells(id.Index).Value)).CopyToDataTable()
                                r.Cells(lote.Index).Value = Convert.ToInt32(f.Cells(idlote.Index).Value)



                            End Sub
                )
            Dim estimado_perf = (From r In dwitems.Rows.Cast(Of DataGridViewRow)
                                 Group r By referencia = Convert.ToString(r.Cells(referencia.Index).Value),
                               acabado = Convert.ToString(r.Cells(acabado.Index).Value) Into g = Group, cantidad_total = Sum(CDec(r.Cells(cantidadnecesaria.Index).Value)), desperdicio_total = Sum(CDec(r.Cells(desperdicioperfil.Index).Value))
                                 Select idart = g.First().Cells(idarticulo.Index).Value, referencia, acabado, lote_p = g.First().Cells(lotesugerido.Index).Value, cantidad_total, desperdicio_total).ToList()
            estimado_perf.ForEach(Sub(est)
                                      Dim e As DataGridViewRow = dwestimado.Rows(dwestimado.Rows.Add())
                                      e.Cells(eid.Index).Value = est.idart
                                      e.Cells(ereferencia.Index).Value = est.referencia
                                      e.Cells(eacabado.Index).Value = est.acabado
                                      e.Cells(lote.Index).Value = est.lote_p
                                      e.Cells(perfilesnecesarios.Index).Value = est.cantidad_total
                                      Dim div As Integer = dwitems.Rows.Cast(Of DataGridViewRow).Where(Function(x) Convert.ToInt32(x.Cells(idarticulo.Index).Value) = Convert.ToInt32(est.idart) And Convert.ToInt32(x.Cells(cantidadnecesaria.Index).Value) > 0).Count()
                                      e.Cells(desperdicio.Index).Value = est.desperdicio_total / div
                                  End Sub)


        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
    Private Sub FrmListaCorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dwitems.AutoGenerateColumns = False
            Dim est_perf As New ClsEstimadosPerfileria
            Dim tb As DataTable = est_perf.TraerporIdOP_Tabla(_idordenprod)
            If tb.Rows.Count > 0 Then
                If MsgBox("Ya existe una lista que se ha guardado previamente. ¿Desea cargar la lista guardadda?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cargar_lista_guardada(tb)
                Else
                    cargar_lista()
                End If
            Else
                cargar_lista()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnoptimizar_Click(sender As Object, e As EventArgs) Handles btnoptimizar.Click
        Try
            Dim est_perf As New ClsEstimadosPerfileria
            dwestimado.Rows.Clear()
            Dim lista_cortes As New List(Of ClsEstimadosPerfileria.CortePerfileria)
            dwagrupados.Rows.Cast(Of DataGridViewRow).ToList().ForEach(Sub(x)
                                                                           Dim rows = dwitems.Rows.Cast(Of DataGridViewRow).Where(Function(r) Convert.ToString(r.Cells(referencia.Index).Value) = Convert.ToString(x.Cells(greferencia.Index).Value) And Convert.ToString(r.Cells(acabado.Index).Value) = Convert.ToString(x.Cells(gacabado.Index).Value)).ToList()
                                                                           Dim l_perf As New List(Of ClsEstimadosPerfileria.Perfil)
                                                                           Dim lotes As List(Of LotePerfileria) = DirectCast(x.Cells(lotesperfileria.Index), DataGridViewComboBoxCell).Items.Cast(Of LotePerfileria).ToList()
                                                                           rows.ForEach(Sub(r)
                                                                                            Dim perf As New ClsEstimadosPerfileria.Perfil
                                                                                            perf.id = Convert.ToInt32(r.Cells(id.Index).Value)
                                                                                            perf.referencia = Convert.ToString(r.Cells(referencia.Index).Value)
                                                                                            perf.acabado = Convert.ToString(r.Cells(acabado.Index).Value)
                                                                                            perf.medida = Convert.ToDecimal(r.Cells(dimension.Index).Value)
                                                                                            perf.cantidad = Convert.ToDecimal(r.Cells(cantidad.Index).Value)
                                                                                            l_perf.Add(perf)
                                                                                        End Sub)
                                                                           Dim lista_corte_general As New List(Of ClsEstimadosPerfileria.CortePerfileria)
                                                                           lista_cortes.AddRange(est_perf.CalculoEstimado(l_perf, lotes, lista_corte_general))

                                                                           For Each c In lista_corte_general
                                                                               Dim f As DataGridViewRow = dwitems.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(z) Convert.ToString(z.Cells(referencia.Index).Value).Equals(c.perfil.referencia) And
                                                                                                                                        Convert.ToString(z.Cells(acabado.Index).Value).Equals(c.perfil.acabado) And
                                                                                                                                        Convert.ToDecimal(z.Cells(dimension.Index).Value).Equals(c.perfil.medida))
                                                                               f.Cells(idlote.Index).Value = c.lote.Id
                                                                               f.Cells(lotesugerido.Index).Value = c.lote.Medida
                                                                               f.Cells(cantidadnecesaria.Index).Value = c.perfilesnecesarios
                                                                               f.Cells(desperdicioperfil.Index).Value = c.porcentaje_desperdicio
                                                                           Next

                                                                       End Sub)
            lista_cortes.ForEach(Sub(x)
                                     Dim r As DataGridViewRow = dwestimado.Rows(dwestimado.Rows.Add())
                                     r.Cells(eid.Index).Value = x.perfil.id
                                     r.Cells(ereferencia.Index).Value = x.perfil.referencia
                                     r.Cells(eacabado.Index).Value = x.perfil.acabado
                                     r.Cells(perfilesnecesarios.Index).Value = x.perfilesnecesarios
                                     r.Cells(lote.Index).Value = x.lote.Medida
                                     r.Cells(desperdicio.Index).Value = x.porcentaje_desperdicio
                                     Dim rg As DataGridViewRow = dwagrupados.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(z) Convert.ToString(z.Cells(greferencia.Index).Value) = x.perfil.referencia And Convert.ToString(z.Cells(gacabado.Index).Value) = x.perfil.acabado)
                                     rg.Cells(lotesperfileria.Index).Value = x.lote.Id
                                 End Sub
                )

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Dim est_perf As New ClsEstimadosPerfileria
            est_perf.EliminarporIdOrdenPro(_idordenprod)
            dwitems.Rows.Cast(Of DataGridViewRow).ToList().ForEach(Sub(r)
                                                                       If String.IsNullOrEmpty(r.Cells(id.Index).Value) Then
                                                                           r.Cells(id.Index).Value = est_perf.Insertar(My.Settings.UsuarioActivo,
                                                                                         _idordenprod,
                                                                                         Convert.ToInt32(r.Cells(idarticulo.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(idacabado.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(cantidad.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(dimension.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(cantidadnecesaria.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(idlote.Index).Value),
                                                                                         Convert.ToDecimal(r.Cells(desperdicioperfil.Index).Value))
                                                                       Else
                                                                           est_perf.Modificar(My.Settings.UsuarioActivo,
                                                                                         _idordenprod,
                                                                                         Convert.ToInt32(r.Cells(idarticulo.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(idacabado.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(cantidad.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(dimension.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(cantidadnecesaria.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(idlote.Index).Value),
                                                                                         Convert.ToDecimal(r.Cells(desperdicioperfil.Index).Value),
                                                                                         Convert.ToInt32(r.Cells(id.Index).Value))
                                                                       End If

                                                                   End Sub)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class