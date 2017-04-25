Imports Datos
Public Class ClsEstimadosPerfileria
#Region "vars"
    Private taestimados As New dsAlcoOrdenesProduccionTableAdapters.top012_estimadoperfileriaTableAdapter
#End Region
    Public Function Insertar(usuario As String, rowidop As Integer, rowidarticulo As Integer,
                            rowidacabado As Integer, cantidadperfil As Decimal, dimension As Decimal, cantidadnecesaria As Decimal,
                            idlote As Integer, desperdicio As Decimal) As Integer
        Try
            Return Convert.ToInt32(taestimados.sp_top012_insert(usuario, rowidop, rowidarticulo, rowidacabado, cantidadperfil,
                                         dimension, cantidadnecesaria, idlote, desperdicio))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(usuario As String, rowidop As Integer, rowidarticulo As Integer,
                            rowidacabado As Integer, cantidadperfil As Decimal, dimension As Decimal, cantidadnecesaria As Decimal,
                            idlote As Integer, desperdicio As Decimal, id As Integer)
        Try
            taestimados.sp_top012_update(usuario, rowidop, rowidarticulo, rowidacabado, cantidadperfil,
                                         dimension, cantidadnecesaria, idlote, desperdicio, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarporIdOrdenPro(idop As Integer)
        Try
            taestimados.sp_top012_deleteByIdop(idop)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerporIdOP_Tabla(idop As Integer) As DataTable
        Try
            Dim taestim As New dsAlcoOrdenesProduccionTableAdapters.sp_top012_selectByIdOpTableAdapter
            Return taestim.GetData(idop).Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#Region "Calculo Estimado"
    Public Function CalculoEstimado(perfiles As List(Of Perfil), lotes As List(Of LotePerfileria),
                                    ByRef listageneral As List(Of CortePerfileria), Optional disco As Integer = 4) As CortePerfileria()
        Try
            Dim l_cestimado As New List(Of CortePerfileria)
            Dim residuos As New List(Of Residuos)
            Dim indice As Integer = 0
            perfiles.ForEach(Sub(p)
                                 Dim perfiles_usados As Integer = 0
                                 Dim lot = lotes.Where(Function(lo) lo.Medida - lo.Descuento >= p.medida + disco).ToList()
                                 Dim lote = lot.Item(lot.Select(Function(x) (x.Medida - x.Descuento) Mod (p.medida + disco)).ToList().IndexOf(lot.Min(Function(l) (l.Medida - l.Descuento) Mod (p.medida + disco))))
                                 While (p.cantidad > 0)
                                     Dim usa As Integer = 0
                                     For i As Integer = 0 To residuos.Count - 1
                                         If residuos(i).valor > p.medida Then
                                             usa = Convert.ToInt32(Int(residuos(i).valor / p.medida))
                                             If p.cantidad >= usa Then
                                                 p.cantidad -= usa
                                             Else
                                                 usa = Convert.ToInt32(p.cantidad)
                                                 p.cantidad = 0
                                             End If
                                             residuos(i).valor -= p.medida * usa
                                         End If
                                     Next
                                     If p.cantidad > 0 Then
                                         usa = Convert.ToInt32(Int((lote.Medida - lote.Descuento) / p.medida))
                                         If p.cantidad >= usa Then
                                             p.cantidad -= usa
                                         Else
                                             usa = Convert.ToInt32(p.cantidad)
                                             p.cantidad = 0
                                         End If
                                         perfiles_usados += 1
                                         residuos.Add(New ClsEstimadosPerfileria.Residuos(indice, Int((lote.Medida - lote.Descuento) - (p.medida * usa))))
                                         residuos = residuos.Where(Function(r) r.valor > 0).ToList()
                                     End If
                                 End While
                                 Dim corte As New CortePerfileria
                                 corte.indice = indice
                                 corte.lote = lote
                                 corte.perfilesnecesarios = perfiles_usados
                                 corte.porcentaje_desperdicio = 0 ' If(perfiles_usados > 0, (residuos.Where(Function(y) y.indice = indice).Sum(Function(x) x.valor) / (perfiles_usados * (lote.Medida - lote.Descuento))) * 100, 0)
                                 corte.perfil = p
                                 l_cestimado.Add(corte)
                                 indice += 1
                             End Sub
                )
            For i As Integer = 0 To l_cestimado.Count - 1
                Dim divisor As Decimal = l_cestimado(i).perfilesnecesarios * (l_cestimado(i).lote.Medida)
                l_cestimado(i).porcentaje_desperdicio = residuos.Where(Function(x) x.indice = l_cestimado(i).indice).Sum(Function(y) y.valor / divisor) * 100
            Next
            listageneral = l_cestimado
            Dim l_agrup = (From c In l_cestimado
                           Group c By referencia = c.perfil.referencia, acabado = c.perfil.acabado, lote = c.lote.Medida Into Group
                           Select Group.First()).ToList()
            Dim m_l_agrupada As New List(Of CortePerfileria)
            For Each g In l_agrup
                Dim nec As Integer = l_cestimado.Where(Function(l) l.perfil.referencia = g.perfil.referencia And l.perfil.acabado = g.perfil.acabado And l.lote.Medida = g.lote.Medida).Select(Function(c) c.perfilesnecesarios).Sum()
                Dim corte As New CortePerfileria
                corte.perfilesnecesarios = nec
                corte.porcentaje_desperdicio = If(nec > 0, (residuos.Sum(Function(x) x.valor) / (nec * (g.lote.Medida))) * 100, 0)
                corte.perfil = g.perfil
                corte.lote = g.lote
                m_l_agrupada.Add(corte)
            Next
            Return m_l_agrupada.ToArray()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Class Residuos
        Public indice As Integer
        Public valor As Decimal
        Public Sub New(indice As Integer, valor As Decimal)
            Me.indice = indice
            Me.valor = valor
        End Sub
    End Class
    Structure Perfil
        Public id As Integer
        Public referencia As String
        Public acabado As String
        Public medida As Decimal
        Public cantidad As Decimal
    End Structure
    Class CortePerfileria
        Public indice As Integer
        Public residuos As Decimal
        Public perfilesnecesarios As Integer
        Public porcentaje_desperdicio As Decimal
        Public perfil As Perfil
        Public lote As LotePerfileria
    End Class
#End Region
End Class
