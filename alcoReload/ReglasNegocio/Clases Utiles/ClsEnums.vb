Public Class ClsEnums
    Public Enum TipoCarga
        ORIGINAL = 0
        COTIZA = 1
        ORDENPEDIDO = 2
        ORDENPRODUCCION = 3
    End Enum
    Public Enum TiOperacion
        INSERTAR = 0
        MODIFICAR = 1
        SOLO_LECTURA = 3
    End Enum
    Public Enum Estados
        ACTIVO = 1
        INACTIVO = 2
        ARCHIVADO = 3
        ANULADO = 4
        CONTRATADO = 5
        PAGADO = 6
        IMPRESO = 7
        SIN_IMPRIMIR = 8
        PENDIENTE_CONTRATAR = 9
        EN_ELABORACION = 10
        VENCIDO = 11
        VIGENTE = 12
        GENERADO = 13
        PARA_LIQUIDAR = 14
        LIQUIDADO = 15
        SIN_CONT_PLANEADA = 16
        SIN_CONTRATO = 17
        SIN_PLANEAR = 18
        CON_PLANEACION = 19
        TERMINADO = 20
        PARCIAL = 21
        APROBADO = 22
        RECHAZADO = 23
        ENVIADO = 24
        SOLUCIONADO_PARCIAL = 25
        SOLUCIONADO = 26
        EN_CONTRATACION = 27
        RECHAZADO_CLIENTE = 28
        RECHAZADO_PRODUCCION = 29
    End Enum

    Public Enum ControlesEnlaceConector
        NA = 0
        TEXTO = 1
        FECHA = 2
        NUMERICO = 3
        LISTA = 4
        COLUMNA_TABLA = 5
        LISTA_CHEQUEO = 6
        CHECK = 7
        COMBOBOX = 8
    End Enum
    Public Enum ModulosAplicacion
        NA = 0
        MODULO_PLANTILLAS = 1
        MODULO_COTIZACIONES = 2
        MODULO_GENERACION_ORDEN_PED = 3
    End Enum
    Public Enum FamiliasMateriales
        DISEÑOS = 1
        ACCESORIOS = 2
        PERFILERIA = 3
        OTROS = 4
        VIDRIO = 5
        TRABAJOS_VIDRIO = 6
        TRABAJO_PERFILES = 7
        TEMPORAL = 8
    End Enum
    Public Enum TiposDato
        NUMERICO = 2
        TEXTO = 3
        BOOLEANO = 4
        FECHA = 5
    End Enum
    Public Enum tipoDescuento
        DSCGOLBAL = 1
        DSCINDIVIDUAL = 2
    End Enum
    Public Enum TipoCalculoCuotas
        SUMINISTRO = 1
        SUMINISTROINSTALACION = 2
        SUMINISTROIVA = 3
        SUMINISTROMASINSTALACIONMASIVA = 4
    End Enum
    Public Enum ObjetosContratos
        SUMINISTRO = 1
        CONSTRUCCION = 2
        INSTALACION = 3
        MANO_OBRA = 4
    End Enum
    Public Enum OrigenNota
        PORANTICIPO = 1
        DIRECTA = 2
    End Enum
    Public Enum tipoImpuestos
        IVAPLENO = 1
        IVAUTILIDAD = 2
    End Enum
    Public Enum niveles
        SINNIVEL = 1
        NIVEL1 = 2
        NIVEL2 = 3
        NIVEL3 = 4
        NIVEL4 = 5
        NIVEL5 = 6
        NIVEL6 = 7
    End Enum

    Public Enum Tipos_Cambio
        CANTIDAD = 1
        ANCHO = 2
        ALTO = 3
        ACABADO = 4
        TIPO_VIDRIO = 5
        ESPESOR = 6
        COLOR_VIDRIO = 7
    End Enum

    Public Enum Tipos_nota
        ANTICIPO = 1
        RETENIDO = 2
        OTROS = 3
    End Enum

    Public Enum Tipos_obra
        VENTANERIA = 1
        FACHADA = 2
        DOMO = 3
        PASAMANOS = 4
        CABINAS = 5
        CONS_FACHADA = 6
        CONS_DOMO = 7
    End Enum
    Public Enum Tipo_seguridad
        GRUPO = 1
        USUARIO = 2
    End Enum

    Public Enum Tipo_Escritura
        PUBLICO = 1
        PRIVADO = 2
    End Enum

    Public Enum TipoFormato
        CONTRATO = 1
        OTROSI = 2
    End Enum

    Public Enum TipoOrdenTrabajo
        DESDE_CONTRATO = 1
        ADICIONALES = 2
    End Enum

    Public Enum TipoCuentaCobro
        DIRECTAS = 1
        DESDE_OT = 2
    End Enum
End Class
