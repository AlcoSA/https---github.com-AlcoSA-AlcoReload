Imports Datos
Public Class ClsOtroSi
#Region "Variables"
    Private taotrosi As New dsAlcoContratosTableAdapters.tc047_otrosiContratosTableAdapter
#End Region

#Region "Procedimientos"
    Public Function Insertar(usuario As String, idcontrato As Integer, numero As String, fechainicial As Date,
                              fechafinal As Date, nit As String, cliente As String, codobra As String, obra As String,
                            nityo As String, clienteyo As String, valor As Decimal, notas As String,
                             representante As String, cedula_representante As String, forma_pago As String, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(taotrosi.sp_tc047_insert(usuario, idcontrato, numero, fechainicial,
                                                            fechafinal, nit, cliente, codobra, obra, nityo, clienteyo, valor,
                                                            notas, representante, cedula_representante, forma_pago, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificacion(id As Integer, usuario As String, idcontrato As Integer, numero As String, fechainicial As Date,
                              fechafinal As Date, nit As String, cliente As String, codobra As String, obra As String,
                            nityo As String, clienteyo As String, valor As Decimal, notas As String,
                            representante As String, cedula_representante As String, forma_pago As String, estado As Integer)
        Try
            taotrosi.sp_tc047_update(id, usuario, idcontrato, numero, fechainicial, fechafinal,
                                     nit, cliente, codobra, obra, nityo, clienteyo,
                                     valor, notas, representante, cedula_representante, forma_pago, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of OtroSi)
        TraerTodos = New List(Of OtroSi)
        Try
            Dim tot As dsAlcoContratos.tc047_otrosiContratosDataTable = taotrosi.GetData()
            For Each ot As dsAlcoContratos.tc047_otrosiContratosRow In tot.Rows
                TraerTodos.Add(New OtroSi(ot.fc047_rowid, ot.fc047_usuarioCreacion, ot.fc047_fechaCreacion,
                                          ot.fc047_rowidContrato, ot.fc047_indiceotrosi, ot.fc047_numero, ot.fc047_fechaInicial, ot.fc047_fechaFinal,
                                          ot.fc047_nit, ot.fc047_cliente, ot.fc047_codObra, ot.fc047_obra, ot.fc047_nitYO,
                                          ot.fc047_clienteYO, ot.fc047_valorOtroSi, ot.fc047_Notas, ot.fc047_representante,
                                          ot.fc047_cedularepresentante, ot.fc047_formadepago, ot.fc047_usuarioModi,
                                          ot.fc047_fechaModi, ot.fc047_rowidEstado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerporIdContrato(idcontrato As Integer) As List(Of OtroSi)
        TraerporIdContrato = New List(Of OtroSi)
        Try
            Dim tot As dsAlcoContratos.tc047_otrosiContratosDataTable = taotrosi.TraerporIdContrato(idcontrato)
            For Each ot As dsAlcoContratos.tc047_otrosiContratosRow In tot.Rows
                TraerporIdContrato.Add(New OtroSi(ot.fc047_rowid, ot.fc047_usuarioCreacion, ot.fc047_fechaCreacion,
                                          ot.fc047_rowidContrato, ot.fc047_indiceotrosi, ot.fc047_numero, ot.fc047_fechaInicial, ot.fc047_fechaFinal,
                                          ot.fc047_nit, ot.fc047_cliente, ot.fc047_codObra, ot.fc047_obra, ot.fc047_nitYO,
                                          ot.fc047_clienteYO, ot.fc047_valorOtroSi, ot.fc047_Notas, ot.fc047_representante,
                                          ot.fc047_cedularepresentante, ot.fc047_formadepago, ot.fc047_usuarioModi,
                                          ot.fc047_fechaModi, ot.fc047_rowidEstado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(id As Integer) As OtroSi
        TraerxId = New OtroSi
        Try

            Dim tot As dsAlcoContratos.tc047_otrosiContratosDataTable = taotrosi.TraerporId(id)
            If tot.Rows.Count > 0 Then
                Dim ot As dsAlcoContratos.tc047_otrosiContratosRow = DirectCast(tot.Rows(0), dsAlcoContratos.tc047_otrosiContratosRow)
                TraerxId = New OtroSi(ot.fc047_rowid, ot.fc047_usuarioCreacion, ot.fc047_fechaCreacion,
                                          ot.fc047_rowidContrato, ot.fc047_indiceotrosi, ot.fc047_numero, ot.fc047_fechaInicial, ot.fc047_fechaFinal,
                                          ot.fc047_nit, ot.fc047_cliente, ot.fc047_codObra, ot.fc047_obra, ot.fc047_nitYO,
                                          ot.fc047_clienteYO, ot.fc047_valorOtroSi, ot.fc047_Notas, ot.fc047_representante,
                                          ot.fc047_cedularepresentante, ot.fc047_formadepago, ot.fc047_usuarioModi,
                                          ot.fc047_fechaModi, ot.fc047_rowidEstado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class OtroSi
    Inherits ClsBaseParametros

#Region "vars"
    Private _idcontrato As Integer = 0
    Private _indice As Integer = 0
    Private _numero As String = String.Empty
    Private _fechainicial As Date
    Private _fechafinal As Date
    Private _nit As String = String.Empty
    Private _cliente As String = String.Empty
    Private _codobra As String = String.Empty
    Private _obra As String = String.Empty
    Private _nityo As String = String.Empty
    Private _clienteyo As String = String.Empty
    Private _valor As Decimal = 0
    Private _notas As String = String.Empty
    Private _representante As String = String.Empty
    Private _cedula_representante As String = String.Empty
    Private _forma_pago As String = String.Empty
#End Region

#Region "props"
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
        End Set
    End Property
    Public Property Indice As Integer
        Get
            Return _indice
        End Get
        Set(value As Integer)
            _indice = value
        End Set
    End Property
    Public Property NumeroContrato As String
        Get
            Return _numero
        End Get
        Set(value As String)
            _numero = value
        End Set
    End Property
    Public Property FechaInicial As Date
        Get
            Return _fechainicial
        End Get
        Set(value As Date)
            _fechainicial = value
        End Set
    End Property
    Public Property FechaFinal As Date
        Get
            Return _fechafinal
        End Get
        Set(value As Date)
            _fechafinal = value
        End Set
    End Property
    Public Property Nit As String
        Get
            Return _nit
        End Get
        Set(value As String)
            _nit = value
        End Set
    End Property
    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodObra As String
        Get
            Return _codobra
        End Get
        Set(value As String)
            _codobra = value
        End Set
    End Property
    Public Property Obra As String
        Get
            Return _obra
        End Get
        Set(value As String)
            _obra = value
        End Set
    End Property
    Public Property NitYO As String
        Get
            Return _nityo
        End Get
        Set(value As String)
            _nityo = value
        End Set
    End Property
    Public Property ClienteYO As String
        Get
            Return _clienteyo
        End Get
        Set(value As String)
            _clienteyo = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return _valor
        End Get
        Set(value As Decimal)
            _valor = value
        End Set
    End Property
    Public Property Notas As String
        Get
            Return _notas
        End Get
        Set(value As String)
            _notas = value
        End Set
    End Property
    Public Property Representante As String
        Get
            Return _representante
        End Get
        Set(value As String)
            _representante = value
        End Set
    End Property
    Private Property Cedula_Representante As String
        Get
            Return _cedula_representante
        End Get
        Set(value As String)
            _cedula_representante = value
        End Set
    End Property

#End Region

#Region "Constructor"
    Public Sub New()

    End Sub

    Public Sub New(id As Integer, usuariocrea As String, fechacrea As Date, idcontrato As Integer, indice As Integer, numero As String, fechainicial As Date, fechafinal As Date,
                   nit As String, cliente As String, codobra As String, obra As String, nityo As String,
                   clienteyo As String, valor As Decimal, notas As String, representante As String, cedula_repsentante As String,
                   forma_pago As String, usuariomodifica As String,
                   fechamodifica As Date, idestado As Integer)
        Me.Id = id
        Me.UsuarioCreacion = Trim(usuariocrea)
        Me.FechaCreacion = fechacrea
        _idcontrato = idcontrato
        _indice = indice
        _numero = Trim(numero)
        _fechainicial = fechainicial
        _fechafinal = fechafinal
        _nit = Trim(nit)
        _cliente = Trim(cliente)
        _codobra = Trim(codobra)
        _obra = Trim(obra)
        _nityo = Trim(nityo)
        _clienteyo = Trim(clienteyo)
        _valor = valor
        _notas = Trim(notas)
        _representante = representante
        _cedula_representante = cedula_repsentante
        _forma_pago = forma_pago
        Me.UsuarioModificacion = Trim(usuariomodifica)
        Me.FechaModificacion = fechamodifica
        Me.IdEstado = idestado
    End Sub
#End Region

End Class
