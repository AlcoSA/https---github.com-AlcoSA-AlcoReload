Imports Datos
Namespace Contratos
    Public Class clsContratos
#Region "Variables"
        Private _dsContrato As New dsAlcoContratosTableAdapters.tc039_contratosTableAdapter
        Private _objContrato As New Contratos.contrato
#End Region
#Region "Procedimientos"
        Public Function t039_insert(nit As String, cliente As String, codObra As String, obra As String, nContrato As String, fechaInicial As DateTime, fechaFin As DateTime,
                                        tipoImpuesto As Integer, valor_impuesto As Decimal, valorContrato As Decimal, valorIva As Decimal, porcentaje_Retenido As Decimal, notas As String, usuarioCreacion As String,
                                        UsuarioModificacion As String, idEstado As Integer, nitYo As String, clienteYo As String, administracion As Decimal, improvistos As Decimal,
                                        utilidad As Decimal) As Integer
            Try
                t039_insert = Convert.ToInt32(_dsContrato.sp_tc039_insert(nit, cliente, codObra, obra, nContrato, fechaInicial,
                                                                          fechaFin, tipoImpuesto, valor_impuesto, valorContrato, valorIva, porcentaje_Retenido, notas, usuarioCreacion,
                                                                          UsuarioModificacion, idEstado, nitYo, clienteYo, administracion, improvistos, utilidad))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Sub t039_update(nit As String, cliente As String, codObra As String, obra As String, nContrato As String, fechaInicial As DateTime, fechaFin As DateTime,
                                            tipoImpuesto As Integer, valor_impuesto As Decimal, valorContrato As Decimal, valorIva As Decimal, porcentaje_retenido As Decimal, notas As String, usuarioCreacion As String,
                                            UsuarioModificacion As String, FechaModificacion As DateTime, IdEstado As Integer, Id As Integer, nitYo As String, ClienteYo As String,
                                            administracion As Decimal, improvistos As Decimal, utilidad As Decimal)
            Try
                _dsContrato.sp_tc039_update(nit, cliente, codObra, obra, nContrato, fechaInicial, fechaFin,
                                            tipoImpuesto, valor_impuesto, valorContrato, valorIva, porcentaje_retenido, notas, usuarioCreacion,
                                           UsuarioModificacion, FechaModificacion, IdEstado, Id, nitYo, ClienteYo, administracion, improvistos, utilidad)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub tc016_updateEstados(cadenaCotizaciones As String, idEstado As Integer)
            Try
                _dsContrato.sp_tc016_updateEstado(cadenaCotizaciones, idEstado)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        Public Sub ModificarEstadoContrato(idcontrato As Integer, idestado As Integer, usuario As String)
            Try
                _dsContrato.sp_tc039_updateEstado(idcontrato, idestado, usuario)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Function TraerTodos(Optional ByRef tabla As DataTable = Nothing) As List(Of contrato)
            TraerTodos = New List(Of contrato)
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc039_selectAllTableAdapter
            Dim td As dsAlcoContratos.sp_tc039_selectAllDataTable = ta.GetData()
            Try
                If td.Rows.Count > 0 Then
                    For Each _fila As dsAlcoContratos.sp_tc039_selectAllRow In td.Rows
                        TraerTodos.Add(New contrato(_fila.Id, _fila.Nit, _fila.CodigoObra, _fila.Cliente, _fila.Obra, _fila.nContrato,
                                                        _fila.FechaInicio, _fila.FechaTerminacion, _fila.TipoImpuesto, _fila.valorimpuesto, _fila.ValorContrato, _fila.ValorIva,
                                                        _fila.porcentaje_retenido, _fila.Notas, _fila.UsuarioCreacion, _fila.UsuarioModi, _fila.NitYo, _fila.ClienteYO, _fila.Administracion,
                                                        _fila.Improvistos, _fila.Utilidad, _fila.IdEstado, _fila.DescEstado))
                    Next
                    tabla = td.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function TraerParaOrdenesPedido(idestado As Integer, Optional ByRef tabla As DataTable = Nothing) As List(Of contrato)
            TraerParaOrdenesPedido = New List(Of contrato)
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc039_selectparaOrdenPedidoTableAdapter
            Dim td As dsAlcoContratos.sp_tc039_selectparaOrdenPedidoDataTable = ta.GetData(idestado)
            Try
                If td.Rows.Count > 0 Then
                    For Each _fila As dsAlcoContratos.sp_tc039_selectparaOrdenPedidoRow In td.Rows
                        TraerParaOrdenesPedido.Add(New contrato(_fila.Id, _fila.Nit, _fila.CodigoObra, _fila.Cliente, _fila.Obra, _fila.nContrato,
                                                        _fila.FechaInicio, _fila.FechaTerminacion, _fila.TipoImpuesto, _fila.valorimpuesto, _fila.ValorContrato, _fila.ValorIva,
                                                        _fila.porcentaje_retenido, _fila.Notas, _fila.UsuarioCreacion, _fila.UsuarioModi, _fila.NitYo, _fila.ClienteYO, _fila.Administracion,
                                                        _fila.Improvistos, _fila.Utilidad, _fila.IdEstado, String.Empty))
                    Next
                    tabla = td.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function traerByIdEstado(idEstado As Integer) As List(Of contrato)
            Try
                traerByIdEstado = New List(Of contrato)
                traerByIdEstado.AddRange(TraerTodos().Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function traerById(id As Integer) As contrato
            traerById = New contrato
            Try
                Dim ta As New dsAlcoContratosTableAdapters.sp_tc039_selectByIdTableAdapter
                Dim td As dsAlcoContratos.sp_tc039_selectByIdDataTable = ta.GetData(id)
                If td.Rows.Count > 0 Then
                    Dim rc As dsAlcoContratos.sp_tc039_selectByIdRow = DirectCast(td.Rows(0), dsAlcoContratos.sp_tc039_selectByIdRow)
                    traerById = New contrato(rc.Id, rc.Nit, rc.CodigoObra, rc.Cliente, rc.Obra, rc.nContrato,
                                                        rc.FechaInicio, rc.FechaTerminacion, rc.TipoImpuesto, rc.valorimpuesto, rc.ValorContrato, rc.ValorIva,
                                                        rc.porcentaje_retenido, rc.Notas, rc.UsuarioCreacion, rc.UsuarioModi, rc.NitYo, rc.ClienteYO, rc.Administracion,
                                                        rc.Improvistos, rc.Utilidad, rc.IdEstado, rc.DescEstado)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function traerByNitAndIdObra(nit As String, codObra As String) As List(Of contrato)
            Try
                Return TraerTodos().Where(Function(a) a.nit = nit And a.codObra = codObra And a.IdEstado = ClsEnums.Estados.ACTIVO).ToList()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function t039_selectNextId() As String
            t039_selectNextId = "--"
            Try
                Dim l = TraerTodos()
                If Not l.Count <= 0 Then
                    t039_selectNextId = TraerTodos.Max(Function(a) a.Id).ToString
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function traerByIdTabla(id As Integer) As DataTable
            Try
                Return _dsContrato.GetData().Where(Function(c) c.fc039_rowid = id).CopyToDataTable()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function TraerByNumeroContrato(numeroContrato As String) As List(Of contrato)
            Try
                TraerByNumeroContrato = New List(Of contrato)
                Dim taAll As New dsAlcoContratosTableAdapters.sp_tc039_selectyByNumeroContratoTableAdapter
                Dim txAll As dsAlcoContratos.sp_tc039_selectyByNumeroContratoDataTable = taAll.GetData(numeroContrato)
                For Each con As dsAlcoContratos.sp_tc039_selectyByNumeroContratoRow In txAll
                    TraerByNumeroContrato.Add(New contrato(con.Id, con.Nit, con.CodigoObra, con.Cliente, con.Obra, con.nContrato,
                                                          con.FechaInicio, con.FechaTerminacion, con.TipoImpuesto, con.valorimpuesto, con.ValorContrato,
                                                          con.ValorIva, con.porcentaje_retenido, con.Notas, con.UsuarioCreacion, con.UsuarioModi, con.NitYo,
                                                          con.ClienteYO, con.Administracion, con.Improvistos, con.Utilidad,
                                                          con.IdEstado, con.DescEstado))
                Next
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function TraerClientes(desdeContratos As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of contrato)
            Try
                TraerClientes = New List(Of contrato)
                Dim taAll As New dsAlcoContratosTableAdapters.sp_tc039_selectClientesTableAdapter
                Dim txAll As dsAlcoContratos.sp_tc039_selectClientesDataTable = taAll.GetData(desdeContratos)
                For Each con As dsAlcoContratos.sp_tc039_selectClientesRow In txAll
                    TraerClientes.Add(New contrato(Convert.ToString(con.Item("nit")), Convert.ToString(con.Item("cliente")),
                                                   Convert.ToString(con.Item("nombreEstablecimiento"))))
                Next
                If txAll.Rows.Count > 0 Then
                    dt = txAll.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function TraerObras(desdeContratos As Boolean, nit As String, Optional ByRef dt As DataTable = Nothing) As List(Of contrato)
            Try
                TraerObras = New List(Of contrato)
                Dim taAll As New dsAlcoContratosTableAdapters.sp_tc039_selectObrasTableAdapter
                Dim txAll As dsAlcoContratos.sp_tc039_selectObrasDataTable = taAll.GetData(desdeContratos, nit)
                For Each con As dsAlcoContratos.sp_tc039_selectObrasRow In txAll
                    TraerObras.Add(New contrato(con.codigoObra, con.obra))
                Next
                If txAll.Rows.Count > 0 Then
                    dt = txAll.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function VerificarMovimientos(idcontrato As Integer) As Boolean
            Try
                Return Convert.ToBoolean(_dsContrato.sp_tc039_verificarMovimientos(idcontrato))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function RegionObraContrato(nit As String, cod_obra As String) As String
            Try
                Return Convert.ToString(_dsContrato.sp_tc039_regionObra(nit, cod_obra))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerObjetoYPara(idContrato As Integer) As contrato
            Try
                Dim taAll As New dsAlcoContratosTableAdapters.sp_tc039_selectObjetoyParaTableAdapter
                Dim txAll As dsAlcoContratos.sp_tc039_selectObjetoyParaDataTable = taAll.GetData(idContrato)
                Dim objPara As dsAlcoContratos.sp_tc039_selectObjetoyParaRow = DirectCast(txAll.Rows(0), dsAlcoContratos.sp_tc039_selectObjetoyParaRow)
                TraerObjetoYPara = New contrato(objPara.id, objPara.nContrato, objPara.objeto, objPara.para)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
    End Class
    Public Class contrato : Inherits ClsBaseParametros
#Region "vars"
        Private _nit As String
        Private _codObra As String
        Private _cliente As String
        Private _nombreEstablecimiento As String
        Private _nContrato As String
        Private _obra As String
        Private _fechaInicial As DateTime
        Private _fechaFin As DateTime
        Private _tipoImpuesto As Integer
        Private _valor_impuesto As Decimal = 0
        Private _valorContrato As Decimal
        Private _valorIva As Decimal
        Private _porcentaje_retenido As Decimal
        Private _notas As String
        Private _nitYo As String
        Private _clienteYo As String
        Private _administradcion As Decimal
        Private _improvistos As Decimal
        Private _utilidad As Decimal
        Private _objeto As String
        Private _para As String
#End Region
#Region "Propiedaes"
        Public Property nit As String
            Get
                Return _nit
            End Get
            Set(ByVal value As String)
                _nit = value
            End Set
        End Property
        Public Property codObra As String
            Get
                Return _codObra
            End Get
            Set(ByVal value As String)
                _codObra = value
            End Set
        End Property
        Public Property Cliente As String
            Get
                Return _cliente
            End Get
            Set(ByVal value As String)
                _cliente = value
            End Set
        End Property
        Public Property NombreEstablecimiento As String
            Get
                Return _nombreEstablecimiento
            End Get
            Set(ByVal value As String)
                _nombreEstablecimiento = value
            End Set
        End Property
        Public Property obra As String
            Get
                Return _obra
            End Get
            Set(ByVal value As String)
                _obra = value
            End Set
        End Property
        Public Property nContrato As String
            Get
                Return _nContrato
            End Get
            Set(ByVal value As String)
                _nContrato = value
            End Set
        End Property
        Public Property fechaInicial As DateTime
            Get
                Return _fechaInicial
            End Get
            Set(ByVal value As DateTime)
                _fechaInicial = value
            End Set
        End Property
        Public Property fechaFin As DateTime
            Get
                Return _fechaFin
            End Get
            Set(ByVal value As DateTime)
                _fechaFin = value
            End Set
        End Property
        Public Property tipoImpuesto As Integer
            Get
                Return _tipoImpuesto
            End Get
            Set(ByVal value As Integer)
                _tipoImpuesto = value
            End Set
        End Property
        Public Property valorContrato As Decimal
            Get
                Return _valorContrato
            End Get
            Set(ByVal value As Decimal)
                _valorContrato = value
            End Set
        End Property
        Public Property valorIva As Decimal
            Get
                Return _valorIva
            End Get
            Set(ByVal value As Decimal)
                _valorIva = value
            End Set
        End Property
        Public Property Porcentaje_Retenido As Decimal
            Get
                Return _porcentaje_retenido
            End Get
            Set(value As Decimal)
                _porcentaje_retenido = value
            End Set
        End Property
        Public Property notas As String
            Get
                Return _notas
            End Get
            Set(ByVal value As String)
                _notas = value
            End Set
        End Property
        Public Property NitYo As String
            Get
                Return _nitYo
            End Get
            Set(ByVal value As String)
                _nitYo = value
            End Set
        End Property
        Public Property ClienteYo As String
            Get
                Return _clienteYo
            End Get
            Set(ByVal value As String)
                _clienteYo = value
            End Set
        End Property
        Public Property Administracion As Decimal
            Get
                Return _administradcion
            End Get
            Set(ByVal value As Decimal)
                _administradcion = value
            End Set
        End Property
        Public Property Improvistos As Decimal
            Get
                Return _improvistos
            End Get
            Set(ByVal value As Decimal)
                _improvistos = value
            End Set
        End Property
        Public Property Utilidad As Decimal
            Get
                Return _utilidad
            End Get
            Set(ByVal value As Decimal)
                _utilidad = value
            End Set
        End Property
        Public Property Objeto As String
            Get
                Return _objeto
            End Get
            Set(ByVal value As String)
                _objeto = value
            End Set
        End Property
        Public Property Para As String
            Get
                Return _para
            End Get
            Set(ByVal value As String)
                _para = value
            End Set
        End Property
        Public Property Valor_Impuesto As Decimal
            Get
                Return _valor_impuesto
            End Get
            Set(value As Decimal)
                _valor_impuesto = value
            End Set
        End Property
#End Region
#Region "Constructor"
        Public Sub New()

        End Sub
        Public Sub New(id As Integer, nit As String, CodObra As String, Cliente As String, obra As String,
                       nContrato As String, fechaInicial As DateTime, FechaFin As DateTime, tipoImpuesto As Integer,
                       valor_impuesto As Decimal, valorContratado As Decimal, valorIva As Decimal, porcentaje_retenido As Decimal, notas As String, usuarioCreacion As String,
                       usuarioModi As String, nitYO As String, clienteYO As String, administracion As Decimal, improvistos As Decimal,
                       utilidad As Decimal, idEstado As Integer, estado As String)
            Try
                Me.Id = id
                _nit = RTrim(nit)
                _cliente = RTrim(Cliente)
                _codObra = RTrim(CodObra)
                _obra = Trim(obra)
                _nContrato = RTrim(nContrato)
                _fechaInicial = fechaInicial
                _fechaFin = FechaFin
                _tipoImpuesto = tipoImpuesto
                _valor_impuesto = valor_impuesto
                _valorContrato = valorContratado
                _valorIva = valorIva
                _porcentaje_retenido = porcentaje_retenido
                _notas = RTrim(notas)
                _nitYo = RTrim(nitYO)
                _clienteYo = RTrim(clienteYO)
                usuarioCreacion = RTrim(usuarioCreacion)
                UsuarioModificacion = RTrim(usuarioModi)
                _administradcion = administracion
                _improvistos = improvistos
                _utilidad = utilidad
                Me.IdEstado = idEstado
                Me.Estado = estado
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub New(nit As String, cliente As String, nombreEstablecimiento As String)
            Try
                _nit = nit
                _cliente = cliente
                _nombreEstablecimiento = nombreEstablecimiento
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub New(codigoObra As String, obra As String, Optional ByRef nd As Integer = 0)
            Try
                _codObra = codigoObra
                _obra = obra
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub New(id As Integer, nContrato As String, objeto As String, para As String)
            Try
                Me.Id = id
                _nContrato = nContrato
                _objeto = objeto
                _para = para
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace
