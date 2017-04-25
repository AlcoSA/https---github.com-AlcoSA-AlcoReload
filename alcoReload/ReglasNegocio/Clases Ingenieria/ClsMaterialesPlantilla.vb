Imports Datos
Public Class ClsMaterialesPlantilla
#Region "Variables"
    Private tamaterialPlantilla As New dsbAlcoIngenieriaTableAdapters.ti013_materialesplantillaTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar información de los materiales asignados a una plantilla
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idplantillamodelo"></param>
    ''' <param name="idfamiliamateria"></param>
    ''' <param name="idorientacionposicionmaterial"></param>
    ''' <param name="articulo"></param>
    ''' <param name="idubicacionmaterial"></param>
    ''' <param name="idmaterialpara"></param>
    ''' <param name="acabado"></param>
    ''' <param name="idtipoMaterial"></param>
    ''' <param name="idtipocortes"></param>
    ''' <param name="cantidad"></param>
    ''' <param name="ancho"></param>
    ''' <param name="alto"></param>
    ''' <param name="descuento"></param>
    ''' <param name="observaciones"></param>
    ''' <param name="estado"></param>
    ''' <param name="peso"></param>

    Public Function Ingresar(usuario As String, idplantillamodelo As Integer, idfamiliamateria As Integer, idorientacionposicionmaterial As Integer,
                        espesor As String, articulo As String, idubicacionmaterial As Integer, idmaterialpara As Integer, acabado As String, idtipoMaterial As Integer,
                        idtipocortes As Integer, cantidad As String, pxunidad As String, ancho As String, alto As String, peso As String, descuento As String,
                         observaciones As String, estado As Integer, visibilidad As String, indicador As Integer) As Integer
        Try
            Return Convert.ToInt32(tamaterialPlantilla.sp_ti013_insert(usuario, idplantillamodelo, idfamiliamateria, idorientacionposicionmaterial,
                                                idubicacionmaterial, idmaterialpara, idtipoMaterial, idtipocortes,
                                                espesor, articulo, acabado, cantidad, pxunidad, ancho, alto, peso, descuento, observaciones,
                                                visibilidad, indicador, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para actualizar los materiales asignados a una plantilla existentes 
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idplantillamodelo"></param>
    ''' <param name="idfamiliamateria"></param>
    ''' <param name="idorientacionposicionmaterial"></param>
    ''' <param name="articulo"></param>
    ''' <param name="idubicacionmaterial"></param>
    ''' <param name="idmaterialpara"></param>
    ''' <param name="acabado"></param>
    ''' <param name="idtipoMaterial"></param>
    ''' <param name="idtipocortes"></param>
    ''' <param name="cantidad"></param>
    ''' <param name="ancho"></param>
    ''' <param name="alto"></param>
    ''' <param name="peso"></param>
    ''' <param name="descuento"></param>
    ''' <param name="observaciones"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idplantillamodelo As Integer, idfamiliamateria As Integer, idorientacionposicionmaterial As Integer,
                        espesor As String, articulo As String, idubicacionmaterial As Integer, idmaterialpara As Integer, acabado As String, idtipoMaterial As Integer,
                        idtipocortes As Integer, cantidad As String, pxunidad As String, ancho As String, alto As String, peso As String, descuento As String,
                         observaciones As String, estado As Integer, visibilidad As String, indicador As Integer)
        Try
            tamaterialPlantilla.sp_ti013_updateById(idplantillamodelo, idfamiliamateria, idorientacionposicionmaterial,
                                                    idubicacionmaterial, idmaterialpara, idtipoMaterial, idtipocortes,
                                                    espesor, articulo, acabado, cantidad, pxunidad, ancho, alto, peso, descuento,
                                                    observaciones, usuario, estado, visibilidad, indicador, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxId(id As Integer)
        Try
            tamaterialPlantilla.sp_ti013_deleteById(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub ModificarFormulaporId(id As Integer, indicador As Integer, formula As String)
        Try
            tamaterialPlantilla.sp_ti013_updateFormulaById(id, formula, indicador)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function ModificarFormulaporIdPlantilla(idplantilla As Integer, idfamilia As Integer,
                                              indicadorcolumna As Integer, formulaoriginal As String,
                                              formulanueva As String) As Integer
        Try
            Return tamaterialPlantilla.sp_ti013_updateFormulaByIdPlantillayFormula(formulaoriginal, formulanueva,
                                                                            indicadorcolumna, idfamilia, idplantilla)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los materiales asignados a una plantilla 
    ''' que estén registrados en el sistema
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos() As List(Of MaterialPlantilla)
        TraerTodos = New List(Of MaterialPlantilla)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti013_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti013_selectAllDataTable = taAll.GetData()
            For Each mp As dsbAlcoIngenieria.sp_ti013_selectAllRow In txall.Rows
                TraerTodos.Add(New MaterialPlantilla(mp.Id, mp.Usuario_Creacion, mp.Fecha_Creacion, mp.Id_Plantilla, mp.Plantilla,
                                                    mp.Id_Familia, mp.Familia, mp.Id_Orientacion, mp.Orientacion, mp.Articulo,
                                                     mp.Articulo_Referencia, mp.Espesor, mp.Id_UbicaMaterial,
                                                    mp.Ubicacion_Material, mp.Id_MaterialPara, mp.Material_Para,
                                                     mp.Acabado, mp.Id_TipoMaterial, mp.Tipo_Material,
                                                    mp.Id_TiposCortes, mp.Tipo_Cortes, mp.imagen_tipo_corte,
                                                     mp.Cantidad, mp.Pxunidad, mp.Ancho, mp.Alto, mp.Peso, mp.Descuento,
                                                     mp.Observaciones, mp.costo_instalacion, mp.Usuario_Modificacion,
                                                    mp.Fecha_Modificacion, mp.Id_Estado, mp.Estado, mp.Visibilidad, mp.fi013_indicador))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Retorna un material según su columna de identificación
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As MaterialPlantilla
        TraerxId = New MaterialPlantilla()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti013_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti013_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim mp As dsbAlcoIngenieria.sp_ti013_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti013_selectByIdRow)
                TraerxId = New MaterialPlantilla(mp.Id, mp.Usuario_Creacion, mp.Fecha_Creacion, mp.Id_Plantilla, mp.Plantilla,
                                                mp.Id_Familia, mp.Familia, mp.Id_Orientacion, mp.Orientacion, mp.Articulo,
                                                mp.Articulo_Referencia, mp.Espesor, mp.Id_UbicaMaterial,
                                                mp.Ubicacion_Material, mp.Id_MaterialPara, mp.Material_Para, mp.Acabado,
                                                mp.Id_TipoMaterial, mp.Tipo_Material, mp.Id_TiposCortes, mp.Tipo_Cortes,
                                                mp.imagen_tipo_corte, mp.Cantidad, mp.Pxunidad,
                                                mp.Ancho, mp.Alto, mp.Peso, mp.Descuento, mp.Observaciones, mp.costo_instalacion,
                                                mp.Usuario_Modificacion, mp.Fecha_Modificacion, mp.Id_Estado, mp.Estado, mp.Visibilidad, mp.fi013_indicador)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Retorna todos los materiales pertenecientes a una plantilla
    ''' </summary>
    ''' <param name="idplantilla"></param>
    ''' <returns></returns>
    Public Function TraerxIdplantilla(idplantilla As Integer) As List(Of MaterialPlantilla)
        TraerxIdplantilla = New List(Of MaterialPlantilla)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti013_selectByPlantillaTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti013_selectByPlantillaDataTable = taAll.GetData(idplantilla)
            For Each mp As dsbAlcoIngenieria.sp_ti013_selectByPlantillaRow In txall.Rows
                TraerxIdplantilla.Add(New MaterialPlantilla(mp.Id, mp.Usuario_Creacion, mp.Fecha_Creacion, mp.Id_Plantilla, mp.Plantilla,
                                                            mp.Id_Familia, mp.Familia, mp.Id_Orientacion, mp.Orientacion, mp.Articulo,
                                                            mp.Articulo_Referencia, mp.Espesor, mp.Id_UbicaMaterial,
                                                            mp.Ubicacion_Material, mp.Id_MaterialPara, mp.Material_Para, mp.Acabado,
                                                            mp.Id_TipoMaterial, mp.Tipo_Material,
                                                            mp.Id_TiposCortes, mp.Tipo_Cortes, mp.imagen_tipo_corte, mp.Cantidad,
                                                            mp.Pxunidad, mp.Ancho, mp.Alto, mp.Peso, mp.Descuento, mp.Observaciones,
                                                            mp.costo_instalacion, mp.Usuario_Modificacion,
                                                            mp.Fecha_Modificacion, mp.Id_Estado, mp.Estado, mp.Visibilidad, mp.fi013_indicador))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Valida que los elementos de los materiales de una plantilla, esten correctos y completos
    ''' </summary>
    ''' <param name="listamateriales"></param>
    ''' <param name="mensaje"></param>
    ''' <returns></returns>
    Public Function validarMateriales(listamateriales As List(Of MaterialPlantilla), ByRef mensaje As String) As Boolean
        Try
            Dim nombrematerial As String = String.Empty
            If listamateriales.Count <= 0 Then
                mensaje &= vbCrLf & "No hay materiales en el diseño."
                Return False
            End If
            For Each material In listamateriales
                Select Case material.IdFamiliaMaterial
                    Case Is = ClsEnums.FamiliasMateriales.VIDRIO
                        nombrematerial = "vidrio"
                        If String.IsNullOrEmpty(material.Alto) Then
                            mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un alto, asignado o formulado."
                        End If
                        If String.IsNullOrEmpty(material.Espesor) Then
                            mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un espesor, asignado o formulado."
                        End If

                    Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
                        nombrematerial = "perfileria"
                        If String.IsNullOrEmpty(material.Descuento) Then
                            mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un descuento, asignado o formulado."
                        End If

                        If material.IdTipoCortes <= 0 Then
                            mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un tipo de corte asignado."
                        End If

                        If material.IdUbicacionMaterial <= 0 Then
                            mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene una ubicación asignada."
                        End If

                    Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
                        nombrematerial = "accesorios"
                End Select
                If String.IsNullOrEmpty(material.Articulo) Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene referencia."
                End If
                If String.IsNullOrEmpty(material.Acabado) Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un acabado asignado o formulado."
                End If
                If String.IsNullOrEmpty(material.Ancho) Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un ancho o dimensión, asignado o formulado."
                End If
                If String.IsNullOrEmpty(material.Cantidad) Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene una cantidad, asignada o formulada."
                End If
                If String.IsNullOrEmpty(material.Visibilidad) Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene visibilidad, asignada o formulada."
                End If
                If material.IdOrientacionyPosicion <= 0 Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene una orientación asignada."
                End If
                If material.IdTipoMaterial <= 0 Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un tipo de material asignado."
                End If
                If material.IdMaterialPara <= 0 Then
                    mensaje &= vbCrLf & "Un elemento de " & nombrematerial & " no tiene un destino de material asignado."
                End If
            Next
            Return String.IsNullOrEmpty(mensaje)
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class MaterialPlantilla
    Inherits ClsBaseParametros
#Region "Variables"
    Protected _cantidad As String = String.Empty
    Protected _piezasxunidad As String = String.Empty
    Protected _ancho As String = String.Empty
    Protected _alto As String = String.Empty
    Protected _descuento As String = String.Empty
    Protected _peso As String = String.Empty
    Protected _observaciones As String = String.Empty
    Protected _visibilidad As String = String.Empty
    Protected _idplantillamodelo As Integer = 0
    Protected _plantillamodelo As String = String.Empty
    Protected _idfamiliamaterial As Integer = 0
    Protected _familiamaterial As String = String.Empty
    Protected _idorientacionposicion As Integer = 0
    Protected _orientacionposicion As String = String.Empty
    Protected _articulo As String = String.Empty
    Protected _articulo_referencia As String = String.Empty
    Protected _idubicacionmaterial As Integer = 0
    Protected _ubicacionmaterial As String = String.Empty
    Protected _idmaterialpara As Integer = 0
    Protected _espesor As String = String.Empty
    Protected _materialpara As String = String.Empty
    Protected _acabado As String = String.Empty
    Protected _idtipomaterial As Integer = 0
    Protected _tipomaterial As String = String.Empty
    Protected _idtipocortes As Integer = 0
    Protected _tipocortes As String = String.Empty
    Protected _costo_instala As Decimal = 0
    Protected _imagentipocorte() As Byte = Nothing
    Protected _indicador As Integer = 0
#End Region
#Region "Propiedades"
    Public Property Cantidad As String
        Get
            Return _cantidad
        End Get
        Set(value As String)
            _cantidad = value
        End Set
    End Property
    Public Property PiezasxUnidad As String
        Get
            Return _piezasxunidad
        End Get
        Set(value As String)
            _piezasxunidad = value
        End Set
    End Property
    Public Property Ancho As String
        Get
            Return _ancho
        End Get
        Set(value As String)
            _ancho = value
        End Set
    End Property
    Public Property Alto As String
        Get
            Return _alto
        End Get
        Set(value As String)
            _alto = value
        End Set
    End Property
    Public Property Descuento As String
        Get
            Return _descuento
        End Get
        Set(value As String)
            _descuento = value
        End Set
    End Property
    Public Property Observaciones As String
        Get
            Return _observaciones
        End Get
        Set(value As String)
            _observaciones = value
        End Set
    End Property
    Public Property Visibilidad As String
        Get
            Return _visibilidad
        End Get
        Set(value As String)
            _visibilidad = value
        End Set
    End Property
    Public Property Espesor As String
        Get
            Return _espesor
        End Get
        Set(value As String)
            _espesor = value
        End Set
    End Property
    Public Property peso As String
        Get
            Return _peso
        End Get
        Set(value As String)
            _peso = value
        End Set
    End Property
    Public Property IdPlantilla As Integer
        Get
            Return _idplantillamodelo
        End Get
        Set(value As Integer)
            _idplantillamodelo = value
        End Set
    End Property
    Public Property PlantillaModelo As String
        Get
            Return _plantillamodelo
        End Get
        Set(value As String)
            _plantillamodelo = value
        End Set
    End Property
    Public Property IdFamiliaMaterial As Integer
        Get
            Return _idfamiliamaterial
        End Get
        Set(value As Integer)
            _idfamiliamaterial = value
        End Set
    End Property
    Public Property FamiliaMaterial As String
        Get
            Return _familiamaterial
        End Get
        Set(value As String)
            _familiamaterial = value
        End Set
    End Property
    Public Property IdOrientacionyPosicion As Integer
        Get
            Return _idorientacionposicion
        End Get
        Set(value As Integer)
            _idorientacionposicion = value
        End Set
    End Property
    Public Property OrientacionyPosicion As String
        Get
            Return _orientacionposicion
        End Get
        Set(value As String)
            _orientacionposicion = value
        End Set
    End Property
    Public Property Articulo As String
        Get
            Return _articulo
        End Get
        Set(value As String)
            _articulo = value
        End Set
    End Property
    Public Property ArticuloReferencia As String
        Get
            Return _articulo_referencia
        End Get
        Set(value As String)
            _articulo_referencia = value
        End Set
    End Property
    Public Property IdUbicacionMaterial As Integer
        Get
            Return _idubicacionmaterial
        End Get
        Set(value As Integer)
            _idubicacionmaterial = value
        End Set
    End Property
    Public Property UbicacionMaterial As String
        Get
            Return _ubicacionmaterial
        End Get
        Set(value As String)
            _ubicacionmaterial = value
        End Set
    End Property
    Public Property IdMaterialPara As Integer
        Get
            Return _idmaterialpara
        End Get
        Set(value As Integer)
            _idmaterialpara = value
        End Set
    End Property
    Public Property MaterialPara As String
        Get
            Return _materialpara
        End Get
        Set(value As String)
            _materialpara = value
        End Set
    End Property
    Public Property Acabado As String
        Get
            Return _acabado
        End Get
        Set(value As String)
            _acabado = value
        End Set
    End Property
    Public Property IdTipoMaterial As Integer
        Get
            Return _idtipomaterial
        End Get
        Set(value As Integer)
            _idtipomaterial = value
        End Set
    End Property
    Public Property TipoMaterial As String
        Get
            Return _tipomaterial
        End Get
        Set(value As String)
            _tipomaterial = value
        End Set
    End Property
    Public Property IdTipoCortes As Integer
        Get
            Return _idtipocortes
        End Get
        Set(value As Integer)
            _idtipocortes = value
        End Set
    End Property
    Public Property TipoCortes As String
        Get
            Return _tipocortes
        End Get
        Set(value As String)
            _tipocortes = value
        End Set
    End Property
    Public Property ImagenTipoCorte As Byte()
        Get
            Return _imagentipocorte
        End Get
        Set(value() As Byte)
            _imagentipocorte = value
        End Set
    End Property
    Public Property Costo_Instalacion As Decimal
        Get
            Return _costo_instala
        End Get
        Set(ByVal value As Decimal)
            _costo_instala = value
        End Set
    End Property
    Public Property Indicador As Integer
        Get
            Return _indicador
        End Get
        Set(value As Integer)
            _indicador = value
        End Set
    End Property

#End Region
#Region "Constructor"

    Public Sub New()
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, idplantillamodelo As Integer,
                   plantillamodelo As String, idfamiliamaterial As Integer, familiamaterial As String, idorientacionposicion As Integer,
                   orientacionposicion As String, articulo As String, articuloReferencia As String, espesor As String, idubicacionmaterial As Integer,
                   ubicacionmaterial As String, idmaterialpara As Integer, materialpara As String, acabado As String,
                   idtipomaterial As Integer, tipomaterial As String, idtipocortes As Integer, tipocortes As String, imagentipocorte As Byte(),
                   cantidad As String, pxunidad As String, ancho As String, alto As String, peso As String, descuento As String,
                   observaciones As String, costo_instalacion As Decimal, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String, visibilidad As String, indicador As Integer)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _cantidad = Trim(cantidad)
            _piezasxunidad = Trim(pxunidad)
            _ancho = Trim(ancho)
            _alto = Trim(alto)
            _descuento = Trim(descuento)
            _observaciones = Trim(observaciones)
            _visibilidad = Trim(visibilidad)
            _idplantillamodelo = idplantillamodelo
            _plantillamodelo = Trim(plantillamodelo)
            _idfamiliamaterial = idfamiliamaterial
            _familiamaterial = Trim(familiamaterial)
            _idorientacionposicion = idorientacionposicion
            _orientacionposicion = Trim(orientacionposicion)
            _articulo = Trim(articulo)
            _articulo_referencia = Trim(articuloReferencia)
            _espesor = Trim(espesor)
            _idubicacionmaterial = idubicacionmaterial
            _ubicacionmaterial = Trim(ubicacionmaterial)
            _idmaterialpara = idmaterialpara
            _materialpara = Trim(materialpara)
            _acabado = Trim(acabado)
            _idtipomaterial = idtipomaterial
            _tipomaterial = Trim(tipomaterial)
            _idtipocortes = idtipocortes
            _tipocortes = Trim(tipocortes)
            _imagentipocorte = imagentipocorte
            _peso = peso
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
            _indicador = indicador
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
#Region "Funciones"
    Public Function Formulacion(conIds As Boolean) As Dictionary(Of String, String)
        Formulacion = New Dictionary(Of String, String)()
        Try
            Formulacion.Add("REFERENCIA", If(_articulo.StartsWith("="), _articulo, _articulo_referencia))
            If _idfamiliamaterial = ClsEnums.FamiliasMateriales.VIDRIO Then
                Formulacion.Add("COLOR", _acabado)
                Formulacion.Add("ANCHO", _ancho)
                Formulacion.Add("ALTO", _alto)
                Formulacion.Add("ESPESOR", _espesor)
            Else
                Formulacion.Add("ACABADO", _acabado)
                Formulacion.Add("DIMENSION", _ancho)
            End If
            Formulacion.Add("PXUNIDAD", _piezasxunidad)
            Formulacion.Add("CANTIDAD", _cantidad)
            Formulacion.Add("DESCUENTO", _descuento)
            Formulacion.Add("DETALLE", _observaciones)
            Formulacion.Add("ORIENTACION", _orientacionposicion)
            Formulacion.Add("UBICACION", _ubicacionmaterial)
            Formulacion.Add("PARA", _materialpara)
            Formulacion.Add("TIPO", _tipomaterial)
            Formulacion.Add("PESO", _peso)
            If _idfamiliamaterial = ClsEnums.FamiliasMateriales.PERFILERIA Then
                Formulacion.Add("CORTES", _tipocortes)
            End If
            Formulacion.Add("VISIBILIDAD", _visibilidad)
            If conIds Then
                Formulacion.Add("ARTICULO", _articulo)
                Formulacion.Add("IDORIENTACIONPOSICION", Convert.ToString(_idorientacionposicion))
                Formulacion.Add("IDUBICACIONMATERIAL", Convert.ToString(_idubicacionmaterial))
                Formulacion.Add("IDMATERIALPARA", Convert.ToString(_idmaterialpara))
                Formulacion.Add("IDTIPOMATERIAL", Convert.ToString(_idtipomaterial))
                Formulacion.Add("IDTIPOCORTES", Convert.ToString(_idtipocortes))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Overridable Function Formulacion_Formula_Valor(conIds As Boolean) As Dictionary(Of String, String())
        Try
            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


#End Region
End Class

