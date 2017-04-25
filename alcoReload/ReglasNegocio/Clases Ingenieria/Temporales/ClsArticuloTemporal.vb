Imports Datos

Public Class ClsArticuloTemporal
#Region "Variables"
    Private taArticuloTemporal As New dsbAlcoIngenieriaTableAdapters.ti034_articulosTemporalTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo artículo temporal en la base de datos
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="idCotiza"></param>
    ''' <param name="referencia"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="peso"></param>
    ''' <param name="unidadMedida"></param>
    ''' <param name="perimetro"></param>
    ''' <param name="idNivel"></param>
    ''' <param name="idFamiliaMaterial"></param>
    ''' <param name="porcentDesperdicio"></param>
    ''' <param name="idTasaImpuesto"></param>
    ''' <param name="costo"></param>
    ''' <param name="idEstado"></param>
    Public Function Insertar(usuarioCreacion As String, idCotiza As Integer, referencia As String, descripcion As String,
                        peso As Decimal, unidadMedida As String, perimetro As Decimal, idNivel As Integer,
                        idFamiliaMaterial As Integer, porcentDesperdicio As Decimal, idTasaImpuesto As Integer,
                        costo As Decimal, idEstado As Integer) As Integer
        Try
            Return Convert.ToInt32(taArticuloTemporal.sp_ti034_insert(usuarioCreacion, idCotiza, referencia, descripcion,
                                                                  peso, unidadMedida, perimetro, idNivel, idFamiliaMaterial,
                                                                   porcentDesperdicio, idTasaImpuesto, costo, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, referencia As String, descripcion As String, peso As Decimal, unidadMedida As String,
                         perimetro As Decimal, idNivel As Integer, porcDesperdicio As Decimal, idTasaImpuesto As Integer,
                         costo As Decimal, usuario As String)
        Try
            taArticuloTemporal.sp_ti034_update(id, referencia, descripcion, peso, unidadMedida, perimetro, idNivel, porcDesperdicio,
                                           idTasaImpuesto, costo, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taArticuloTemporal.sp_ti034_updateEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Función booleana que devuelve verdadero si existe algún artículo temporal con la referencia indicada
    ''' </summary>
    ''' <param name="referencia"></param>
    ''' <returns></returns>
    Public Function ExisteArticulo(referencia As String) As Boolean
        Try
            If Convert.ToInt32(taArticuloTemporal.sp_ti034_selectExistReferencia(referencia)) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Función booleana que devuelve verdadero si existe un vidiro con la referencia indicada
    ''' </summary>
    ''' <param name="referencia"></param>
    ''' <returns></returns>
    Public Function ExisteVidrio(referencia As String) As Boolean
        Try
            If Convert.ToInt32(taArticuloTemporal.sp_ti034_selectExistVidrio(referencia)) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene sólo los artículos temporales correspondientes a la cotización indicada
    ''' </summary>
    ''' <param name="idcotiza"></param>
    ''' <returns></returns>
    Public Function TraerxIdCotiza(idcotiza As Integer) As List(Of articuloTemporal)
        Try
            TraerxIdCotiza = New List(Of articuloTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti034_selectByIdCotizaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti034_selectByIdCotizaDataTable = taAll.GetData(idcotiza)
            For Each art As dsbAlcoIngenieria.sp_ti034_selectByIdCotizaRow In txAll
                TraerxIdCotiza.Add(New articuloTemporal(art.id, art.usuarioCreacion, art.fechaCreacion, art.idCotiza, art.referencia, art.descripcion,
                                                        art.peso, art.unidadMedida, art.perimetro, art.idNivel, art.nivel, art.idFamiliaMaterial,
                                                        art.familiaMaterial, art.porcentDesperdicio, art.idTasaImpuesto, art.tasaImpuesto, art.costo,
                                                        art.fechaModi, art.usuarioModi, art.idEstado, art.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene el artículo correspondiente al idCotiza y idArtticulo indicados
    ''' </summary>
    ''' <param name="idCotiza"></param>
    ''' <param name="idArticulo"></param>
    ''' <returns></returns>
    Public Function TraerxId(idCotiza As Integer, idArticulo As Integer) As articuloTemporal
        Try
            TraerxId = New articuloTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti034_selectByIdTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti034_selectByIdDataTable = taAll.GetData(idCotiza, idArticulo)
            If txAll.Rows.Count > 0 Then
                Dim art As dsbAlcoIngenieria.sp_ti034_selectByIdRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti034_selectByIdRow)
                TraerxId = New articuloTemporal(art.id, True, art.usuarioCreacion, art.fechaCreacion, art.idCotiza, art.referencia, art.descripcion,
                                                art.peso, art.unidadMedida, art.perimetro, art.idNivel, art.nivel, art.idFamiliaMaterial,
                                                art.familiaMaterial, art.porcentDesperdicio, art.idTasaImpuesto, art.tasaImpuesto, art.costo,
                                                art.fechaModi, art.usuarioModi, art.idEstado, art.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene el artículo temporal correspondiente a la referencia indicada
    ''' </summary>
    ''' <param name="referencia"></param>
    ''' <returns></returns>
    Public Function TraerxReferencia(referencia As String) As articuloTemporal
        Try
            TraerxReferencia = New articuloTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti034_selectByReferenciaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti034_selectByReferenciaDataTable = taAll.GetData(referencia)
            If txAll.Rows.Count > 0 Then
                Dim art As dsbAlcoIngenieria.sp_ti034_selectByReferenciaRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti034_selectByReferenciaRow)
                TraerxReferencia = New articuloTemporal(art.id, True, art.usuarioCreacion, art.fechaCreacion, art.idCotiza, art.referencia, art.descripcion,
                                                        art.peso, art.unidadMedida, art.perimetro, art.idNivel, art.nivel, art.idFamiliaMaterial,
                                                        art.familiaMaterial, art.porcentajeDesperdicio, art.idTasaImpuesto, art.tasaImpuesto, art.costo,
                                                        art.fechaModi, art.usuarioModi, art.idEstado, art.estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerConExistentes(idCotiza As Integer, idFamiliaMaterial As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of articuloTemporal)
        Try
            TraerConExistentes = New List(Of articuloTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti034_selectWithExistentesTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti034_selectWithExistentesDataTable = taAll.GetData(idCotiza, idFamiliaMaterial)
            For Each art As dsbAlcoIngenieria.sp_ti034_selectWithExistentesRow In txAll
                TraerConExistentes.Add(New articuloTemporal(Convert.ToInt32(art.Item("Id")), Convert.ToBoolean(art.Item("Temporal")),
                                                            Convert.ToString(art.Item("Usuario_Creacion")), Convert.ToDateTime(art.Item("Fecha_Creacion")),
                                                            Convert.ToInt32(art.Item("Id_Cotiza")), Convert.ToString(art.Item("Referencia")),
                                                            Convert.ToString(art.Item("Descripcion")), Convert.ToDecimal(art.Item("Peso")),
                                                            Convert.ToString(art.Item("Unidad_medida")), Convert.ToDecimal(art.Item("Perimetro")),
                                                            Convert.ToInt32(art.Item("Id_Nivel")), Convert.ToString(art.Item("Nivel")),
                                                            Convert.ToInt32(art.Item("Id_Familia_Material")), Convert.ToString(art.Item("Familia_Material")),
                                                            Convert.ToDecimal(art.Item("porcentajeDesperdicio")), Convert.ToInt32(art.Item("Id_Tasa_Impuesto")),
                                                            Convert.ToString(art.Item("Tasa_Impuesto")), Convert.ToDecimal(art.Item("Costo")),
                                                            Convert.ToDateTime(art.Item("Fecha_Modificacion")), Convert.ToString(art.Item("Usuario_Modificacion")),
                                                            Convert.ToInt32(art.Item("Id_Estado")), Convert.ToString(art.Item("Estado"))))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerConExistentes_II(idCotiza As Integer) As List(Of articuloTemporal)
        Try
            TraerConExistentes_II = New List(Of articuloTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti034_selectWithExistentes_IITableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti034_selectWithExistentes_IIDataTable = taAll.GetData(idCotiza)
            For Each art As dsbAlcoIngenieria.sp_ti034_selectWithExistentes_IIRow In txAll
                TraerConExistentes_II.Add(New articuloTemporal(Convert.ToInt32(art.Item("Id")), Convert.ToInt32(art.Item("Id_DB")), Convert.ToDateTime(art.Item("Fecha_Creacion")),
                                                               Convert.ToString(art.Item("Usuario_Creacion")), Convert.ToString(art.Item("Referencia")),
                                                               Convert.ToString(art.Item("Descripcion")), Convert.ToInt32(art.Item("Id_Cotiza")), Convert.ToDecimal(art.Item("Peso")),
                                                               Convert.ToString(art.Item("Unidad_Medida")), Convert.ToDecimal(art.Item("Perimetro")), Convert.ToInt32(art.Item("Id_Nivel")),
                                                               Convert.ToString(art.Item("Nivel")), Convert.ToInt32(art.Item("Id_Familia_Material")), Convert.ToString(art.Item("Familia_Material")),
                                                               Convert.ToDecimal(art.Item("Porcent_Desperdicio")), Convert.ToInt32(art.Item("Id_Tasa_Impuesto")),
                                                               Convert.ToString(art.Item("Tasa_Impuesto")), Convert.ToDecimal(art.Item("Costo")), Convert.ToDateTime(art.Item("Fecha_Modi")),
                                                               Convert.ToString(art.Item("Usuario_Modi")), Convert.ToInt32(art.Item("Id_Estado")), Convert.ToString(art.Item("Estado")),
                                                               Convert.ToBoolean(art.Item("Temporal"))))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerConExistentesPorReferencia(idCotiza As Integer, idFamiliaMaterial As Integer, referencia As String) As articuloTemporal
        Try
            TraerConExistentesPorReferencia = New articuloTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti034_selectWithExistentesByReferenciaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti034_selectWithExistentesByReferenciaDataTable = taAll.GetData(idCotiza, idFamiliaMaterial, referencia)
            If txAll.Rows.Count > 0 Then
                Dim art As dsbAlcoIngenieria.sp_ti034_selectWithExistentesByReferenciaRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti034_selectWithExistentesByReferenciaRow)
                TraerConExistentesPorReferencia = New articuloTemporal(Convert.ToInt32(art.Item("Id")), Convert.ToBoolean(art.Item("Temporal")),
                                                                Convert.ToString(art.Item("Usuario_Creacion")), Convert.ToDateTime(art.Item("Fecha_Creacion")),
                                                                Convert.ToInt32(art.Item("Id_Cotiza")), Convert.ToString(art.Item("Referencia")),
                                                                Convert.ToString(art.Item("Descripcion")), Convert.ToDecimal(art.Item("Peso")),
                                                                Convert.ToString(art.Item("Unidad_medida")), Convert.ToDecimal(art.Item("Perimetro")),
                                                                Convert.ToInt32(art.Item("Id_Nivel")), Convert.ToString(art.Item("Nivel")),
                                                                Convert.ToInt32(art.Item("Id_Familia_Material")), Convert.ToString(art.Item("Familia_Material")),
                                                                Convert.ToDecimal(art.Item("porcentajeDesperdicio")), Convert.ToInt32(art.Item("Id_Tasa_Impuesto")),
                                                                Convert.ToString(art.Item("Tasa_Impuesto")), Convert.ToDecimal(art.Item("Costo")),
                                                                Convert.ToDateTime(art.Item("Fecha_Modificacion")), Convert.ToString(art.Item("Usuario_Modificacion")),
                                                                Convert.ToInt32(art.Item("Id_Estado")), Convert.ToString(art.Item("Estado")))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class articuloTemporal
    Inherits ClsBaseParametros
#Region "Variables"
    Private _Id_Db As Integer
    Private _referencia As String
    Private _descripcion As String
    Private _idCotiza As Integer
    Private _peso As Decimal
    Private _unidadMedida As String
    Private _perimetro As Decimal
    Private _idNivel As Integer
    Private _nivel As String
    Private _idFamiliaMaterial As Integer
    Private _familiaMaterial As String
    Private _porcentDesperdicio As Decimal
    Private _idTasaImpuesto As Integer
    Private _tasaImpuesto As String
    Private _costo As Decimal
    Private _temporal As Boolean
#End Region
#Region "Propiedades"
    Public Property IdDb() As Integer
        Get
            Return _Id_Db
        End Get
        Set(ByVal value As Integer)
            _Id_Db = value
        End Set
    End Property
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property Temporal() As Boolean
        Get
            Return _temporal
        End Get
        Set(ByVal value As Boolean)
            _temporal = value
        End Set
    End Property
    Public Property Referencia As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property Peso() As Decimal
        Get
            Return _peso
        End Get
        Set(ByVal value As Decimal)
            _peso = value
        End Set
    End Property
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property Perimetro() As Decimal
        Get
            Return _perimetro
        End Get
        Set(ByVal value As Decimal)
            _perimetro = value
        End Set
    End Property
    Public Property IdNivel() As Integer
        Get
            Return _idNivel
        End Get
        Set(ByVal value As Integer)
            _idNivel = value
        End Set
    End Property
    Public Property Nivel() As String
        Get
            Return _nivel
        End Get
        Set(ByVal value As String)
            _nivel = value
        End Set
    End Property
    Public Property IdFamiliaMaterial() As Integer
        Get
            Return _idFamiliaMaterial
        End Get
        Set(ByVal value As Integer)
            _idFamiliaMaterial = value
        End Set
    End Property
    Public Property FamiliaMaterial() As String
        Get
            Return _familiaMaterial
        End Get
        Set(ByVal value As String)
            _familiaMaterial = value
        End Set
    End Property
    Public Property PorcentajeDesperdicio() As Decimal
        Get
            Return _porcentDesperdicio
        End Get
        Set(ByVal value As Decimal)
            _porcentDesperdicio = value
        End Set
    End Property
    Public Property IdTasaImpuesto() As Integer
        Get
            Return _idTasaImpuesto
        End Get
        Set(ByVal value As Integer)
            _idTasaImpuesto = value
        End Set
    End Property
    Public Property TasaImpuesto() As String
        Get
            Return _tasaImpuesto
        End Get
        Set(ByVal value As String)
            _tasaImpuesto = value
        End Set
    End Property
    Public Property Costo() As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
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

    Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, idCotiza As Integer,
                   referencia As String, descripcion As String, peso As Decimal, unidadMedida As String, perimetro As Decimal,
                   idNivel As Integer, nivel As String, idFamiliaMaterial As Integer, familiaMaterial As String, porcentDesperdicio As Decimal,
                   idTasaImpuesto As Integer, tasaImpuesto As String, Costo As Decimal, fechaModi As DateTime, usuarioModi As String,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaCreacion
            _idCotiza = idCotiza
            _referencia = Trim(referencia)
            _descripcion = Trim(descripcion)
            _peso = peso
            _unidadMedida = unidadMedida
            _perimetro = perimetro
            _idNivel = idNivel
            _nivel = nivel
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = familiaMaterial
            _porcentDesperdicio = porcentDesperdicio
            _idTasaImpuesto = idTasaImpuesto
            _tasaImpuesto = tasaImpuesto
            _costo = Costo
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = usuarioModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub New(id As Integer, temporal As Boolean, usuarioCreacion As String, fechaCreacion As DateTime, idCotiza As Integer,
                   referencia As String, descripcion As String, peso As Decimal, unidadMedida As String, perimetro As Decimal,
                   idNivel As Integer, nivel As String, idFamiliaMaterial As Integer, familiaMaterial As String, porcentDesperdicio As Decimal,
                   idTasaImpuesto As Integer, tasaImpuesto As String, Costo As Decimal, fechaModi As DateTime, usuarioModi As String,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            Me.FechaCreacion = fechaCreacion
            _idCotiza = idCotiza
            _temporal = temporal
            _referencia = referencia.Trim
            _descripcion = descripcion.Trim
            _peso = peso
            _unidadMedida = unidadMedida.Trim
            _perimetro = perimetro
            _idNivel = idNivel
            _nivel = nivel
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = familiaMaterial.Trim
            _porcentDesperdicio = porcentDesperdicio
            _idTasaImpuesto = idTasaImpuesto
            _tasaImpuesto = tasaImpuesto.Trim
            _costo = Costo
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = usuarioModi.Trim
            Me.IdEstado = idEstado
            Me.Estado = estado.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub New(id As Integer, idDb As Integer, fechaCreacion As DateTime, usuarioCreacion As String, referencia As String,
                   descripcion As String, idCotiza As Integer, peso As Decimal, unidadMedida As String, perimetro As Decimal,
                   idNivel As Integer, nivel As String, idFamiliaMaterial As Integer, familiaMaterial As String,
                   porcentDesperdicio As Decimal, idTasaImpuesto As Integer, tasaImpuesto As String, costo As Decimal,
                   fechaModi As DateTime, usuarioModi As String, idEstado As Integer, estado As String, temporal As Boolean)
        Try
            Me.Id = id
            _Id_Db = idDb
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _referencia = Trim(referencia)
            _descripcion = Trim(descripcion)
            _idCotiza = idCotiza
            _peso = peso
            _unidadMedida = RTrim(unidadMedida)
            _perimetro = perimetro
            _idNivel = idNivel
            _nivel = nivel
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = familiaMaterial
            _porcentDesperdicio = porcentDesperdicio
            _idTasaImpuesto = idTasaImpuesto
            _tasaImpuesto = tasaImpuesto
            _costo = costo
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = usuarioModi
            Me.IdEstado = idEstado
            Me.Estado = estado
            _temporal = temporal
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
