Imports Datos

Public Class ClsMovitoReposicion
#Region "Variables"
    Private taMovitoRep As dsAlcoComercial2TableAdapters.tc076_movito_reposicionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(idEncabezado As Integer, ind_grid As Integer, referencia As String, descripcion As String, unidadMedida As String,
                        cantidad As Integer, ancho As Decimal, alto As Decimal, bpbAncho As Integer, bpbAlto As Integer, precioUnitario As Decimal,
                        xoCabina As String, tipoCabina As String, idMotivo As String, idBodega As String, cantidadBoquetes As Integer,
                        cantidadPerforaciones As Integer, cantidadBoquetesEspeciales As Integer, ubicacion As String, plantilla As String,
                        causa As String, seccion As String, responsable As String)
        Try
            taMovitoRep.sp_tc076_insert(idEncabezado, ind_grid, referencia, descripcion, unidadMedida, cantidad, ancho, alto, bpbAncho,
                                        bpbAlto, precioUnitario, xoCabina, tipoCabina, idMotivo, idBodega, cantidadBoquetes,
                                        cantidadPerforaciones, cantidadBoquetesEspeciales, ubicacion, plantilla, causa, seccion, responsable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(idReposicion As Integer) As List(Of movitoReposicion)
        Try
            TraerTodos = New List(Of movitoReposicion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc076_selectByIdReposicionTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc076_selectByIdReposicionDataTable = taAll.GetData(idReposicion)
            For Each mov As dsAlcoComercial2.sp_tc076_selectByIdReposicionRow In txAll.Rows
                TraerTodos.Add(New movitoReposicion(mov.id, mov.idEncabezado, mov.ind_grid, mov.referencia, mov.descripcion, mov.unidadMedida,
                                                    mov.cantidad, mov.ancho, mov.alto, mov.bpbAncho, mov.bpbAlto, mov.precioUnitario,
                                                    mov.xoCabina, mov.tipoCabina, mov.idMotivo, mov.idBodega, mov.cantidadBoquetes,
                                                    mov.cantidadPerforaciones, mov.cantidadBoquetesEspeciales, mov.ubicacion, mov.plantilla,
                                                    mov.causa, mov.seccion, mov.responsable))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoReposicion
#Region "Variables"
    Private _id As Integer
    Private _idEncabezado As Integer
    Private _ind_grid As Integer
    Private _referencia As String
    Private _descripcion As String
    Private _unidadMedida As String
    Private _cantidad As Integer
    Private _ancho As Decimal
    Private _alto As Decimal
    Private _bpbAncho As Integer
    Private _bpbAlto As Integer
    Private _precioUnitario As Decimal
    Private _xoCabina As String
    Private _tipoCabina As String
    Private _idMotivo As String
    Private _idBodega As String
    Private _cantidadBoquetes As Integer
    Private _cantidadPerforaciones As Integer
    Private _cantidadBoquetesEspeciales As Integer
    Private _ubicacion As String
    Private _plantilla As String
    Private _causa As String
    Private _seccion As String
    Private _responsable As String
#End Region
#Region "Propiedades"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property IdEncabezado() As Integer
        Get
            Return _idEncabezado
        End Get
        Set(ByVal value As Integer)
            _idEncabezado = value
        End Set
    End Property
    Public Property Ind_grid() As Integer
        Get
            Return _ind_grid
        End Get
        Set(ByVal value As Integer)
            _ind_grid = value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
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
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property Ancho() As Decimal
        Get
            Return _ancho
        End Get
        Set(ByVal value As Decimal)
            _ancho = value
        End Set
    End Property
    Public Property Alto() As Decimal
        Get
            Return _alto
        End Get
        Set(ByVal value As Decimal)
            _alto = value
        End Set
    End Property
    Public Property BpbAncho() As Integer
        Get
            Return _bpbAncho
        End Get
        Set(ByVal value As Integer)
            _bpbAncho = value
        End Set
    End Property
    Public Property BpbAlto() As Integer
        Get
            Return _bpbAlto
        End Get
        Set(ByVal value As Integer)
            _bpbAlto = value
        End Set
    End Property
    Public Property PrecioUnitario() As Decimal
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As Decimal)
            _precioUnitario = value
        End Set
    End Property
    Public Property XOCabina() As String
        Get
            Return _xoCabina
        End Get
        Set(ByVal value As String)
            _xoCabina = value
        End Set
    End Property
    Public Property TipoCabina() As String
        Get
            Return _tipoCabina
        End Get
        Set(ByVal value As String)
            _tipoCabina = value
        End Set
    End Property
    Public Property IdMotivo() As String
        Get
            Return _idMotivo
        End Get
        Set(ByVal value As String)
            _idMotivo = value
        End Set
    End Property
    Public Property IdBodega() As String
        Get
            Return _idBodega
        End Get
        Set(ByVal value As String)
            _idBodega = value
        End Set
    End Property
    Public Property CantidadBoquetes() As Integer
        Get
            Return _cantidadBoquetes
        End Get
        Set(ByVal value As Integer)
            _cantidadBoquetes = value
        End Set
    End Property
    Public Property CantidadPerforaciones() As Integer
        Get
            Return _cantidadPerforaciones
        End Get
        Set(ByVal value As Integer)
            _cantidadPerforaciones = value
        End Set
    End Property
    Public Property CantidadBoquetesEspeciales() As Integer
        Get
            Return _cantidadBoquetesEspeciales
        End Get
        Set(ByVal value As Integer)
            _cantidadBoquetesEspeciales = value
        End Set
    End Property
    Public Property Ubicacion() As String
        Get
            Return _ubicacion
        End Get
        Set(ByVal value As String)
            _ubicacion = value
        End Set
    End Property
    Public Property Plantilla() As String
        Get
            Return _plantilla
        End Get
        Set(ByVal value As String)
            _plantilla = value
        End Set
    End Property
    Public Property Causa() As String
        Get
            Return _causa
        End Get
        Set(ByVal value As String)
            _causa = value
        End Set
    End Property
    Public Property Seccion() As String
        Get
            Return _seccion
        End Get
        Set(ByVal value As String)
            _seccion = value
        End Set
    End Property
    Public Property Responsable() As String
        Get
            Return _responsable
        End Get
        Set(ByVal value As String)
            _responsable = value
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
    Public Sub New(id As Integer, idEncabezado As Integer, ind_grid As Integer, referencia As String, descripcion As String,
                   unidadMedida As String, cantidad As Integer, ancho As Decimal, alto As Decimal, bpbAncho As Integer,
                   bpbAlto As Integer, precioUnitario As Decimal, xoCabina As String, tipoCabina As String, idMotivo As String,
                   idBodega As String, cantidadBoquetes As Integer, cantidadPerforaciones As Integer, cantidadBoquetesEspeciales As Integer,
                   ubicacion As String, plantilla As String, causa As String, seccion As String, responsable As String)
        Try
            _id = id
            _idEncabezado = idEncabezado
            _ind_grid = ind_grid
            _referencia = Trim(referencia)
            _descripcion = Trim(descripcion)
            _unidadMedida = Trim(unidadMedida)
            _cantidad = cantidad
            _ancho = ancho
            _alto = alto
            _bpbAncho = bpbAncho
            _bpbAlto = bpbAlto
            _precioUnitario = precioUnitario
            _xoCabina = Trim(xoCabina)
            _tipoCabina = Trim(tipoCabina)
            _idMotivo = Trim(idMotivo)
            _idBodega = Trim(idBodega)
            _cantidadBoquetes = cantidadBoquetes
            _cantidadPerforaciones = cantidadPerforaciones
            _cantidadBoquetesEspeciales = cantidadBoquetesEspeciales
            _ubicacion = Trim(ubicacion)
            _plantilla = Trim(plantilla)
            _causa = Trim(causa)
            _seccion = Trim(seccion)
            _responsable = Trim(responsable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class