Imports Datos
Namespace Ciudades
    Public Class ClsCiudades
#Region "Procedimientos"
        ''' <summary>
        ''' Obtiene el id de departamento y país cuando se necesite cargar una ciudad conociendo su Id
        ''' </summary>
        ''' <param name="idCiudad"></param>
        ''' <returns></returns>
        Public Function TraerIdDptoAndIdPais(idCiudad As Integer) As Ciudad
            Try
                TraerIdDptoAndIdPais = New Ciudad
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc002_selectIdDptoAndIdPaisTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc002_selectIdDptoAndIdPaisDataTable = taAll.GetData(idCiudad)
                If txAll.Rows.Count > 0 Then
                    Dim ti As dsAlcoComercial.sp_tc002_selectIdDptoAndIdPaisRow = DirectCast(txAll.Rows(0), dsAlcoComercial.sp_tc002_selectIdDptoAndIdPaisRow)
                    TraerIdDptoAndIdPais = New Ciudad(ti.idDpto, ti.idPais)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerxIdDepartamento(idDepartamento As Integer) As List(Of Ciudad)
            Try
                TraerxIdDepartamento = New List(Of Ciudad)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc002_selectByDepartamentoTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc002_selectByDepartamentoDataTable = taAll.GetData(idDepartamento)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc002_selectByDepartamentoRow In txAll.Rows
                        TraerxIdDepartamento.Add(New Ciudad(ti.id, ti.usuarioCreacion, ti.fechaCreacion, ti.idDepartamento,
                                                            ti.idSiesa, ti.nombreCiudad, ti.velocidadViento, ti.usuarioModi,
                                                            ti.fechaModi, ti.valorDefecto))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function ExisteValorDefecto() As Boolean
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc002_selectExistValorDefectoTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc002_selectExistValorDefectoDataTable = taAll.GetData()
                If txAll.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerxIdDepartamentoAndValorDefecto(idDepartamento As Integer) As List(Of Ciudad)
            Try
                TraerxIdDepartamentoAndValorDefecto = New List(Of Ciudad)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc002_selectByDepAndValorDefectoTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc002_selectByDepAndValorDefectoDataTable = taAll.GetData(idDepartamento)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc002_selectByDepAndValorDefectoRow In txAll.Rows
                        TraerxIdDepartamentoAndValorDefecto.Add(New Ciudad(ti.id, ti.usuarioCreacion, ti.fechaCreacion, ti.idDepartamento, ti.idSiesa,
                                                                           ti.nombreCiudad, ti.velocidadViento, ti.usuarioModi, ti.fechaModi, ti.valorDefecto))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerxId(idCiudad As Integer) As Ciudad
            Try
                TraerxId = New Ciudad
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc002_selectByIdTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc002_selectByIdDataTable = taAll.GetData(idCiudad)
                If txAll.Rows.Count > 0 Then
                    Dim ti As dsAlcoComercial.sp_tc002_selectByIdRow = DirectCast(txAll.Rows(0), dsAlcoComercial.sp_tc002_selectByIdRow)
                    TraerxId = New Ciudad(ti.Id, ti.usuarioCreacion, ti.fechaCreacion, ti.idDpto, ti.idSiesa, ti.nombreCiudad, ti.velocidadViento,
                                          ti.usuarioModi, ti.fechaModi, ti.valorDefecto)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerTodos() As List(Of Ciudad)
            Try
                TraerTodos = New List(Of Ciudad)
                Dim taAll As New dsAlcoComercialTableAdapters.tc002_ciudadesTableAdapter
                Dim txAll As dsAlcoComercial.tc002_ciudadesDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.tc002_ciudadesRow In txAll.Rows
                    TraerTodos.Add(New Ciudad(ti.fc002_rowid, ti.fc002_usuarioCreacion, ti.fc002_fechaCreacion, ti.fc002_rowidDepartamento, ti.fc002_rowidSiesa,
                                                                       ti.fc002_NombreCiudad, ti.fc002_velocidadViento, ti.fc002_usuarioModi, ti.fc002_fechaModi, ti.fc002_valorPorDefecto))
                Next
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerxIdDeptoAndIdSiesa(idDepto As Integer, idCiudad As String) As Ciudad
            Try
                TraerxIdDeptoAndIdSiesa = New Ciudad
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc002_selectByDeptoAndIdSiesaTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc002_selectByDeptoAndIdSiesaDataTable = taAll.GetData(idDepto, idCiudad)
                If txAll.Rows.Count > 0 Then
                    Dim ti As dsAlcoComercial.sp_tc002_selectByDeptoAndIdSiesaRow = DirectCast(txAll.Rows(0), dsAlcoComercial.sp_tc002_selectByDeptoAndIdSiesaRow)
                    TraerxIdDeptoAndIdSiesa = New Ciudad(ti.id, ti.usuarioCreacion, ti.fechaCreacion, ti.idDepartamento, ti.idSiesa,
                                                         ti.nombreCiudad, ti.velocidadViento, ti.usuarioModi, ti.fechaModi, ti.valorDefecto)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
    End Class
    Public Class Ciudad
        Inherits ClsBaseParametros
#Region "Variables"
        Private _idDepartamento As Integer
        Private _idPais As Integer
        Private _idSiesa As String
        Private _nombre As String = String.Empty
        Private _velocidad As Decimal
        Private _valorxDefecto As Integer
#End Region
#Region "Propiedades"
        Public Property nombreCiudad() As String
            Get
                Return _nombre
            End Get
            Set(ByVal value As String)
                _nombre = value
            End Set
        End Property
        Public Property velocidadViento() As Decimal
            Get
                Return _velocidad
            End Get
            Set(ByVal value As Decimal)
                _velocidad = value
            End Set
        End Property
        Public Property valorPorDefecto() As Integer
            Get
                Return _valorxDefecto
            End Get
            Set(ByVal value As Integer)
                _valorxDefecto = value
            End Set
        End Property

        Public Property idDepartamento() As Integer
            Get
                Return _idDepartamento
            End Get
            Set(ByVal value As Integer)
                _idDepartamento = value
            End Set
        End Property

        Public Property idSiesa() As String
            Get
                Return _idSiesa
            End Get
            Set(ByVal value As String)
                _idSiesa = value
            End Set
        End Property

        Public Property idPais() As Integer
            Get
                Return _idPais
            End Get
            Set(ByVal value As Integer)
                _idPais = value
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
        Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, idDepartamento As Integer,
                       idSiesa As String, nombreCiudad As String, velocidadViento As Decimal, usuarioModificacion As String,
                       fechaModificacion As DateTime, valorxDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _idDepartamento = idDepartamento
                _idSiesa = idSiesa
                _nombre = Trim(nombreCiudad)
                _velocidad = velocidadViento
                _valorxDefecto = valorxDefecto
                Me.UsuarioModificacion = Trim(usuarioModificacion)
                Me.FechaModificacion = fechaModificacion
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub New(idDpto As Integer, idPais As Integer)
            Try
                _idDepartamento = idDpto
                _idPais = idPais
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

