Imports Datos
Public Class ClsVariablesPlantillaOrdenProd
#Region "Variables"
    Private varia As New dsAlcoOrdenesProduccionTableAdapters.top005_valoresVariablesPlantillaOPTableAdapter
#End Region
    Public Function Insertar(idhijoOP As Integer, idvariable As Integer,
                           minimo As String, minimo_valor As String, maximo As String, maximo_valor As String,
                           valor As String, usuario As String) As Integer
        Try
            Return Convert.ToInt32(varia.sp_top005_insert(idhijoOP, idvariable, usuario, minimo, minimo_valor,
                                                         maximo, maximo_valor, valor))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub EliminarxIdItemOp(idhijoOP As Integer)
        Try
            varia.sp_top005_deletebyIdOP(idhijoOP)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerxIdItemOp(idhijoOp As Integer) As List(Of VariableItemCotiza)
        TraerxIdItemOp = New List(Of VariableItemCotiza)
        Try
            Dim ta As New dsAlcoOrdenesProduccionTableAdapters.sp_top005_selectByIdHijoOPTableAdapter
            Dim txall As dsAlcoOrdenesProduccion.sp_top005_selectByIdHijoOPDataTable = ta.GetData(idhijoOp)
            txall.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top005_selectByIdHijoOPRow).ToList.ForEach(
                Sub(vc)
                    TraerxIdItemOp.Add(New VariableItemCotiza(vc.fop005_rowid, vc.fop005_rowidHijoOp,
                                                                vc.fop005_rowidVariable, vc.fi006_nombreVariable,
                                                                vc.fop005_minimo, vc.fop005_minimoValor, vc.fop005_maximo,
                                                                vc.fop005_maximoValor, vc.fop005_valor,
                                                                DirectCast(vc.fi006_rowIdtipoDeDato, ClsEnums.TiposDato),
                                                                vc.fi006_valordesdebd, vc.fi006_edicionproduccion,
                                                                vc.fop005_usuarioCreacion, vc.fop005_fechaCreacion,
                                                                vc.fop005_usuarioModificacion, vc.fop005_fechaModificacion))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
