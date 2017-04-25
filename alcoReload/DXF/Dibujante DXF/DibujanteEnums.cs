namespace DXF.Dibujante_DXF
{
    public enum TipoFigura
    {
        NINGUNA = 0,
        MARCO = 1,
        FIJO = 2,
        NAVE = 3,
        DIVISOR =4,
        REJILLA = 5,
        ANTICONDENSACION = 6,
        ANGEO = 7,
        COTA=8,
        ELE = 9,
        ARCO = 10,
        TEXTO = 11,
        FLECHA = 12,
        LINEA = 13,
        TRASLADAR = 14,        
        NA = 15
    }

    public enum TipoContacto
    {
        NINGUNO = 0,
        HORIZONTAL = 1,
        VERTICAL = 2,
        INTERCEPTO = 3
    }

    public enum Click_Redimension
    {
        NINGUNA = 0,
        IZQUIERDA = 1,
        ARRIBA = 2,
        DERECHA = 3,
        ABAJO = 4,
        PUNTO1 = 5,
        PUNTO2 = 6,
        PUNTO3 = 7,
        PUNTO4 = 8,
        CENTRAL = 9,
        ROTADOR = 10
    }

    public enum Tipo_Traslacion
    {
        ARRIBA_IZQUIERDA =0,
        ARRIBA_DERECHA = 1,
        ABAJO_DERECHA = 2,
        ABAJO_IZQUIERDA = 3
    }

    public enum Tipo_Redimension
    {
        X = 0,
        Y = 1,
        ANCHO = 2,
        ALTO = 3
    }


}
