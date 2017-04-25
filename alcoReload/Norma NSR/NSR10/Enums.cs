namespace Norma_NSR.NSR10
{
    public class Retornos
    {
        public  string[] grupo_uso = new string[] {"I", "II", "III", "IV"};
        public  string[] categoria_expo = new string[] { "B", "C", "D"};
        public  string[] tipo_cubierta = new string[] { "DOS AGUAS", "UNA PENDIENTE" };
        public  string[] tipo_edificacion = new string[] { "EDIFICIO CERRADO", "EDIFICIO ABIERTO" };
        public  string[] componente = new string[] { "VENTANA", "ANCLAJE" };
        public  string[] presiones_diseno = new string[] { "ZONA 4 (+)", "ZONA 4 (-)", "ZONA 5 (+)", "ZONA 5 (-)" };
    }

    public enum GRUPO_USO
    {
        I=1,
        II=2,
        III=3,
        IV=4
    }

    public enum CATEGORIA_EXPOSICION
    {
        B = 1,
        C = 2,
        D = 3
    }

    public enum TIPO_CUBIERTA
    {        
        DOS_AGUAS = 1,
        UNA_PENDIENTE = 2,
    }

    public enum TIPO_EDIFICACION
    {
        EDIFICIO_CERRADO = 1,
        EDIFICIO_ABIERTO = 2
    }

    public enum COMPONENTE
    {
        VENTANA = 1,
        ANCLAJE = 2                    
    }

    public enum PRESIONES_DISEGNO
    {
        ZONA_4_POSITIVO =1,
        ZONA_4_NEGATIVO = 2,
        ZONA_5_POSITIVO = 3,
        ZONA_5_NEGATIVO = 4
    }

}
