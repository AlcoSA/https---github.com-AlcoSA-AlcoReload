Imports Datos
Namespace movitoComplementos

    Public Class ClsMovitoComplementos
#Region "Variables"
        Private taMovitoComplementos As New dsAlcoComercialTableAdapters.tc022_movitoComplementosHijosCotizaTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"

        Public Sub Ingresar(usuario As String, idHIjosPrincipal As Integer, idHijoComplemento As Integer)
            Try
                taMovitoComplementos.sp_tc022_insert(usuario, idHijoComplemento, idHijoComplemento)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        Public Sub modificar(idHijoPrincipal As Integer, idHijoComplemento As Integer, usuarioModi As String, rowid As Integer)
            Try
                taMovitoComplementos.sp_tc022_update(idHijoPrincipal, idHijoComplemento, usuarioModi, rowid)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Private Sub eliminar(id As Integer)
            Try
                taMovitoComplementos.sp_tc022_delete(id)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        ''' <summary>
        ''' Selecciona toda la informacion de las relaciones que existen entre los items hijos
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerAll() As cotizacion
            Try
                TraerAll = New cotizacion
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc022_selectAllTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc022_selectAllDataTable = taAll.GetData()
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc022_selectAllRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc022_selectAllRow)
                        TraerAll = New cotizacion(ti.Id_Complemento, ti.Fecha_Creacion, ti.Usuario_Creacion, ti.Id_Hijo_Principal, ti.Id_Hijo_Complemento, ti.Usuario_Modi, ti.Fecha_Modi)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
#Region "Funciones"

#End Region
    End Class
    Public Class cotizacion
        Inherits ClsBaseParametros
#Region "Variables"
        Private _idHijoPrincipal As Integer = 0
        Private _idHijoComplemento As Integer = 0
#End Region

#Region "Propiedades"
        Public Property idHijoPrincipal() As Integer
            Get
                Return _idHijoPrincipal
            End Get
            Set(ByVal value As Integer)
                _idHijoPrincipal = value
            End Set
        End Property
        Public Property idHijoComplemento() As Integer
            Get
                Return _idHijoComplemento
            End Get
            Set(ByVal value As Integer)
                _idHijoComplemento = value
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
        Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idHijoPrincipal As Integer,
                       idHijoComplemento As Integer, usuarioModi As String, fechaModi As DateTime)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _idHijoPrincipal = idHijoPrincipal
                _idHijoComplemento = idHijoComplemento
                Me.UsuarioModificacion = Trim(usuarioModi)
                Me.FechaModificacion = fechaModi
                'Me.IdEstado = IdEstado
                'Me.Estado = Estado
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

