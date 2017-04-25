Imports Datos
Public Class ClsVariablesPlantillaOped
#Region "Variables"
    Private varia As New dsAlcoProduccionTableAdapters.tp006_ValoresVariablesPlantillaOPTableAdapter
#End Region
    Public Function Insertar(idhijoOP As Integer, idvariable As Integer,
                           minimo As String, minimo_valor As String, maximo As String, maximo_valor As String,
                           valor As String, usuario As String) As Integer
        Try
            Return Convert.ToInt32(varia.sp_tp006_insert(idhijoOP, idvariable, usuario, minimo, minimo_valor,
                                                         maximo, maximo_valor, valor))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub EliminarxIdItemOp(idhijoOP As Integer)
        Try
            varia.sp_tp006_deleteByItemop(idhijoOP)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerxIdItemOp(idhijoOp As Integer, ByRef Optional tb As DataTable = Nothing) As List(Of VariableItemCotiza)
        TraerxIdItemOp = New List(Of VariableItemCotiza)
        Try
            Dim ta As New dsAlcoProduccionTableAdapters.sp_tp006_selectByIdItemOPTableAdapter
            Dim txall As dsAlcoProduccion.sp_tp006_selectByIdItemOPDataTable = ta.GetData(idhijoOp)
            txall.Rows.Cast(Of dsAlcoProduccion.sp_tp006_selectByIdItemOPRow).ToList.ForEach(
                Sub(vc)
                    TraerxIdItemOp.Add(New VariableItemCotiza(vc.fp006_rowid, vc.fp006_rowidhijoOp, vc.fp006_rowidvariable, vc.fi006_nombreVariable,
                                                                  vc.fp006_minimo, vc.fp006_minimovalor, vc.fp006_maximo, vc.fp006_maximovalor, vc.fp006_valor, DirectCast(vc.fi006_rowIdtipoDeDato, ClsEnums.TiposDato),
                                                                  vc.fi006_valordesdebd, vc.fi006_edicionproduccion, vc.fp006_usuariocreacion, vc.fp006_fechacreacion, vc.fp006_usuariomodificacion, vc.fp006_fechamodificacion))
                End Sub)
            tb = If(txall.Count > 0, txall.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
