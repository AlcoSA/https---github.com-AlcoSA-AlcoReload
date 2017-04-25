Imports Datos

Public Class ClsCostoOtrosArticulos
#Region "Variables"
    Private taOtrosArticulos As New dsAlcoComercialTableAdapters.tc034_costoOtrosArticulosTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo costo de otros artículos
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="idArticulo"></param>
    ''' <param name="version"></param>
    ''' <param name="costo"></param>
    Public Sub Insertar(usuarioCreacion As String, idArticulo As Integer, idFamiliaMaterial As Integer,
                        version As Integer, costo As Decimal)
        Try
            taOtrosArticulos.sp_tc034_insert(usuarioCreacion, idArticulo, idFamiliaMaterial, version, costo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    ''' <summary>
    ''' Obtiene la máxima versión de los costos
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerMaxVersion() As Integer
        Try
            Return Convert.ToInt32(taOtrosArticulos.sp_tc034_selectMaxVersion())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Eliminar(idCosto As Integer)
        Try
            taOtrosArticulos.sp_tc034_deleteById(idCosto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de costos de la familia Otros
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(versionBase As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of OtrosArticulos)
        Try
            TraerTodos = New List(Of OtrosArticulos)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc034_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc034_selectAllDataTable = taAll.GetData(versionBase)
            For Each ti As dsAlcoComercial.sp_tc034_selectAllRow In txAll.Rows
                TraerTodos.Add(New OtrosArticulos(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.idArticulo,
                                                  ti.descripcion, ti.idFamiliaMaterial, ti.familiaMaterial,
                                                  ti.version, ti.nuevaVersion, ti.costo, ti.nuevoCosto))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro correspondiente al id de artículo indicado
    ''' </summary>
    ''' <param name="idArticulo"></param>
    ''' <returns></returns>
    Public Function TraerxIdArticulo(idArticulo As Integer, version As Integer) As OtrosArticulos
        Try
            TraerxIdArticulo = New OtrosArticulos
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc034_selectByIdArticuloTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc034_selectByIdArticuloDataTable = taAll.GetData(idArticulo, version)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc034_selectByIdArticuloRow In txAll.Rows
                    TraerxIdArticulo = New OtrosArticulos(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.idArticulo,
                                                          ti.descripcion, ti.idFamiliaMaterial, ti.familiaMaterial,
                                                          ti.version, ti.version + 1, ti.costo, ti.costo)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxReferencia(referencia As String, version As Integer) As Decimal
        Try
            Return Convert.ToDecimal(taOtrosArticulos.sp_tc034_selectByReferenciaVersion(referencia, version))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


    Public Function TraerxReferencia(referencia As String) As OtrosArticulos
        Try
            TraerxReferencia = New OtrosArticulos
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc034_selectByReferenciaTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc034_selectByReferenciaDataTable = taAll.GetData(referencia)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc034_selectByReferenciaRow In txAll.Rows
                    TraerxReferencia = New OtrosArticulos(ti.Id, ti.fechaCreacion, ti.usuarioCreacion, ti.idArticulo,
                                                          ti.descripcion, ti.idFamiliaMaterial, ti.familiaMaterial,
                                                          ti.version, ti.version + 1, ti.costo, ti.costo)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


#End Region
End Class
Public Class OtrosArticulos
    Inherits ClsBaseParametros

#Region "Variables"
    Private _idArticulo As Integer
    Private _descripcion As String
    Private _idFamiliaMaterial As Integer
    Private _familiaMaterial As String
    Private _version As Integer
    Private _nuevaVersion As Integer
    Private _costo As Decimal
    Private _nuevoCosto As Decimal
#End Region
#Region "Propiedades"
    Public Property idArticulo() As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = value
        End Set
    End Property
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property version() As Integer
        Get
            Return _version
        End Get
        Set(ByVal value As Integer)
            _version = value
        End Set
    End Property
    Public Property NuevaVersion() As Integer
        Get
            Return _nuevaVersion
        End Get
        Set(ByVal value As Integer)
            _nuevaVersion = value
        End Set
    End Property
    Public Property costo() As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
        End Set
    End Property
    Public Property NuevoCosto() As Decimal
        Get
            Return _nuevoCosto
        End Get
        Set(ByVal value As Decimal)
            _nuevoCosto = value
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
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String,
                   idArticulo As Integer, articulo As String, idFamiliaMaterial As Integer,
                   familiaMaterial As String, version As Integer, nuevaVersion As Integer,
                   costo As Decimal, nuevoCosto As Decimal)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _idArticulo = idArticulo
            _descripcion = Trim(articulo)
            _idFamiliaMaterial = idFamiliaMaterial
            _familiaMaterial = familiaMaterial
            _version = version
            _nuevaVersion = nuevaVersion
            _costo = costo
            _nuevoCosto = nuevoCosto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
