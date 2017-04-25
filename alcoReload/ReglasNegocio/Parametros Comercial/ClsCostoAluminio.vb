Imports Datos
Namespace CostoArticulo
    Public Class ClsCostoAluminio
#Region "Variables"
        Private taCostoAlminio As New dsAlcoComercialTableAdapters.tc020_costoAluminioTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        Public Sub Ingresar()
            Try
                taCostoAlminio.sp_tc020_valorarAluminio()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub valorarPerfil(idPerfil As Integer)
            Try
                taCostoAlminio.sp_tc020_valorarPerfil(idPerfil)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Function TraerCostoxReferenciayAcabado(referencia As String, acabado As String) As Decimal
            TraerCostoxReferenciayAcabado = 0
            Try
                taCostoAlminio = New dsAlcoComercialTableAdapters.tc020_costoAluminioTableAdapter
                Return Convert.ToDecimal(taCostoAlminio.sp_tc020_selectCostoxReferenciayAcabado(referencia, acabado))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerCostoxReferenciayAcabado(referencia As String, acabado As String,
                                                      versionAcabado As Integer, versionNivel As Integer,
                                                      versionKiloAluminio As Integer) As Decimal
            TraerCostoxReferenciayAcabado = 0
            Try
                taCostoAlminio = New dsAlcoComercialTableAdapters.tc020_costoAluminioTableAdapter
                Return Convert.ToDecimal(taCostoAlminio.sp_tc020_selectByReferenciaEspecificos(referencia,
                                                                                               acabado,
                                                                                               versionAcabado,
                                                                                               versionNivel,
                                                                                               versionKiloAluminio))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerCostoEspecifico(idArticulo As Integer, idAcabado As Integer, versionAcabado As Integer,
                                             versionNivel As Integer, versionKiloAluminio As Integer) As Decimal
            Try
                taCostoAlminio = New dsAlcoComercialTableAdapters.tc020_costoAluminioTableAdapter
                Return Convert.ToDecimal(taCostoAlminio.sp_tc020_selectCostoEspecifico(idArticulo, idAcabado, versionAcabado,
                                                                                       versionNivel, versionKiloAluminio))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
    End Class
    Public Class costoAluminio
        Inherits ClsBaseParametros
#Region "Variables"
        Private _id_costo_Articulo As Integer
        Public Property idCostoArticulo() As Integer
            Get
                Return _id_costo_Articulo
            End Get
            Set(ByVal value As Integer)
                _id_costo_Articulo = value
            End Set
        End Property
        Private _idArticulo As Integer
        Public Property idArticulo() As Integer
            Get
                Return _idArticulo
            End Get
            Set(ByVal value As Integer)
                _idArticulo = value
            End Set
        End Property
        Private _referencia As String
        Public Property referencia() As String
            Get
                Return _referencia
            End Get
            Set(ByVal value As String)
                _referencia = value
            End Set
        End Property
        Private _peso As Decimal
        Public Property peso() As Decimal
            Get
                Return _peso
            End Get
            Set(ByVal value As Decimal)
                _peso = value
            End Set
        End Property
        Private _perimetro As Decimal
        Public Property perimetro() As Decimal
            Get
                Return _perimetro
            End Get
            Set(ByVal value As Decimal)
                _perimetro = value
            End Set
        End Property
        Private _id_Familia_Material As Integer
        Public Property idFamiliaMateria() As Integer
            Get
                Return _id_Familia_Material
            End Get
            Set(ByVal value As Integer)
                _id_Familia_Material = value
            End Set
        End Property
        Private _familiaMaterial As String
        Public Property familiaMaterial() As String
            Get
                Return _familiaMaterial
            End Get
            Set(ByVal value As String)
                _familiaMaterial = value
            End Set
        End Property
        Private _prefijoMaterial As String
        Public Property prefijoMaterial() As String
            Get
                Return _prefijoMaterial
            End Get
            Set(ByVal value As String)
                _prefijoMaterial = value
            End Set
        End Property
        Private _idAcabado As Integer
        Public Property idAcabado() As Integer
            Get
                Return _idAcabado
            End Get
            Set(ByVal value As Integer)
                _idAcabado = value
            End Set
        End Property
        Private _idCostoAcabado As Integer
        Public Property idCostoAcabado() As Integer
            Get
                Return _idCostoAcabado
            End Get
            Set(ByVal value As Integer)
                _idCostoAcabado = value
            End Set
        End Property
        Private _numVersionCosotoAcabado As String
        Public Property numVersionCostoAcabado() As String
            Get
                Return _numVersionCosotoAcabado
            End Get
            Set(ByVal value As String)
                _numVersionCosotoAcabado = value
            End Set
        End Property
        Private _valorCostoAcabado As Decimal
        Public Property valorCostoAcabado() As Decimal
            Get
                Return _valorCostoAcabado
            End Get
            Set(ByVal value As Decimal)
                _valorCostoAcabado = value
            End Set
        End Property
        Private _idCostoNivel As Integer
        Public Property idCostoNivel() As Integer
            Get
                Return _idCostoNivel
            End Get
            Set(ByVal value As Integer)
                _idCostoNivel = value
            End Set
        End Property
        Private _numVersionCostoNivel As String
        Public Property numVersionCostoNivel() As String
            Get
                Return _numVersionCostoNivel
            End Get
            Set(ByVal value As String)
                _numVersionCostoNivel = value
            End Set
        End Property
        Private _valorNivel As String
        Public Property valorNivel() As String
            Get
                Return _valorNivel
            End Get
            Set(ByVal value As String)
                _valorNivel = value
            End Set
        End Property
        Private _idCostoAluminio As Integer
        Public Property idCostoAluminio() As Integer
            Get
                Return _idCostoAluminio
            End Get
            Set(ByVal value As Integer)
                _idCostoAluminio = value
            End Set
        End Property
        Private _numVersionCostoAluminio As String
        Public Property numVersionCostoAluminio() As String
            Get
                Return _numVersionCostoAluminio
            End Get
            Set(ByVal value As String)
                _numVersionCostoAluminio = value
            End Set
        End Property
        Private _valorCostoAluminio As Decimal
        Public Property NewProperty() As Decimal
            Get
                Return _valorCostoAluminio
            End Get
            Set(ByVal value As Decimal)
                _valorCostoAluminio = value
            End Set
        End Property
        Private _costo As Decimal
        Public Property costo() As Decimal
            Get
                Return _costo
            End Get
            Set(ByVal value As Decimal)
                _costo = value
            End Set
        End Property

#End Region
#Region "Propiedades"

#End Region
#Region "Constructor"
        Public Sub New()
            Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub New(id_Costo_Articulo As Integer, Fecha_Creacion As DateTime, Usuario_Creacion As String, id_Articulo As Integer, Referencia As String,
                        Peso As Decimal, Perimetro As Decimal, id_Familia_Material As Integer, Familia_Material As String, Prefijo_Material As String,
                        id_Acabado As Integer, id_Espesor As Integer, idVersion_Filia As Integer, NumVersion_Filia As Integer, id_Costo_Acabado As Integer,
                       numVersion_Costo_Acabado As Integer, ValorCost_Acabado As Decimal, id_Costo_Nivel As Integer, NumVersion_Costo_Nivel As Integer,
                       Valor_Nivel As String, id_Costo_Aluminio As Integer, NumVersion_Costo_Alum As String, ValorCosto_Aluminio As Decimal, Costo As Decimal,
                       usuarioModi As String, fechaModi As DateTime, IdEstado As Integer, Estado As String)
            Try
                Me.Id = id_Costo_Articulo
                Me.UsuarioCreacion = Trim(UsuarioCreacion)
                Me.FechaCreacion = FechaCreacion
                _idArticulo = id_Articulo
                _referencia = Referencia
                _peso = Peso
                _perimetro = Perimetro
                _id_Familia_Material = idFamiliaMateria
                _familiaMaterial = familiaMaterial
                _prefijoMaterial = prefijoMaterial
                _numVersionCosotoAcabado = numVersionCostoAcabado
                _valorCostoAcabado = valorCostoAcabado
                _idCostoNivel = idCostoNivel
                _numVersionCostoNivel = numVersionCostoNivel
                _valorNivel = Valor_Nivel
                _idCostoAluminio = id_Costo_Aluminio
                _numVersionCostoAluminio = numVersionCostoAluminio
                _valorCostoAluminio = ValorCosto_Aluminio
                _costo = Costo
                Me.UsuarioModificacion = Trim(usuarioModi)
                Me.FechaModificacion = fechaModi
                Me.IdEstado = IdEstado
                Me.Estado = Estado
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

