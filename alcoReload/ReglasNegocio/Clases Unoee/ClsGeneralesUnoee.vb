Imports Datos
Public Class ClsGeneralesUnoee
#Region "vars"

#End Region
    Public Function Obtener_documentos(p_cia As Short, Optional p_clasedocto As Short = -1,
                                       Optional p_modulo As Short = 0, Optional p_requieretipo As Short = 1,
                                       Optional p_genera_movto As Short = 1, Optional p_id_grupo_clase_docto As Short = 0, Optional p_seg_x_maestro As Short = -1,
                                       Optional p_rowid_usuario As Short = 0, Optional p_prefijo_formato As String = Nothing,
                                       Optional p_ind_aplica_filtro_consultas As Short = -1) As DataTable
        Try
            Dim tax As New dsBUnoeeTableAdapters.sp_tipo_docto_leer_todosTableAdapter
            Return tax.GetData(p_cia, p_clasedocto, p_modulo, p_requieretipo, p_genera_movto,
                        p_id_grupo_clase_docto, p_seg_x_maestro, p_rowid_usuario, p_prefijo_formato,
                        p_ind_aplica_filtro_consultas).Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function obtener_Ccostos(p_cia As Short, p_estado As Short, p_idco As String, p_idun As String, p_idgrupo As String,
                                     p_seguridad_x_maestro As Short, p_rowid_usuario As Integer, p_id_mayor_ccosto As String) As DataTable
        Try
            Dim tax As New dsBUnoeeTableAdapters.sp_ccosto_aux_leer_todosTableAdapter
            Return tax.GetData(p_cia, p_estado, p_idco, p_idun, p_idgrupo,
                                    Nothing, p_seguridad_x_maestro, p_rowid_usuario, p_id_mayor_ccosto).Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function obtener_uNegocio(cia As Short, p_rowid_usuario As Integer, Optional p_por_estado As Short = 1, Optional p_ind_estado As Short = 1) As DataTable
        Try
            Dim tax As New dsBUnoeeTableAdapters.sp_un_leer_todosTableAdapter
            Return tax.GetData(cia, p_por_estado, p_ind_estado, p_rowid_usuario).Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function Traer_Id_Usuario(usuariont As String) As Integer
        Try
            Dim tax As New dsBUnoeeTableAdapters.alco_selectIdusuario_byNombreTableAdapter
            Return Convert.ToInt32(tax.Fill(usuariont))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
