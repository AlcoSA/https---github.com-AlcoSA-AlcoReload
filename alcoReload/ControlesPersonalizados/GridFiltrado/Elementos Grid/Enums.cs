namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public enum TipoFiltro
    {
        FILTRO_DRAGDROP = 0,
        FILTRO_EXCEL = 1
    }
    public enum TipoCoincidencia
    {
        IGUALQUE = 1,
        COMO = 2,
        MAYORQUE = 3,
        MENORQUE=4,
        MAYOROIGUALQUE = 5,
        MENORIGUALQUE = 6
    }
    public enum TipoValor
    {
        NUMERICO = 2,
        TEXTO = 3,        
        BOOLEANO = 4,
        FECHA = 5,
        MULTIPLES_VALORES_TEXTO = 6,
        MULTIPLES_VALORES_NUMERICOS = 7,
        MULTIPLES_VALORES_FECHA = 8
    }
    public enum TOTAL
    {
        NINGUNA = 1,
        PRIMERAFILA = 2,
        ULTIMAFILA = 3
    }
}
