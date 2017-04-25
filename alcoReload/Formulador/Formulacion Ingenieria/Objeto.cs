
namespace Formulador
{
    public class Objeto
    {
        #region Variables
        private int id = 0;
        private TiposElementos tipo = TiposElementos.NA;
        private string nombre = string.Empty;
        private ParametrosCollection parametros;
        private Descuentos descuentos;
        private int indice = -1;
        private decimal costo_unitario = 0;
        private decimal costo_total = 0;
        private decimal costo_instalacion_unidad = 0;
        private decimal costo_instalacion_total = 0;
        private decimal peso=0;
        private bool utilizar = true;
        private decimal desperdicio = 0;
        private decimal vlrdesperdicio = 0;
        #endregion
        #region Constructor
        public Objeto() {
            parametros = new ParametrosCollection();
            descuentos = new Descuentos(this);
        }
        public Objeto(string nombre, int indice) {
            this.nombre = nombre;
            this.indice = indice;
            parametros = new ParametrosCollection();
            descuentos = new Descuentos(this);
            Descuento item = new Descuento(1,"DESCUENTO", 0, string.Empty);
            item.calculado = true;
            descuentos.Add(item);
        }
        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public TiposElementos TipoObjeto
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public decimal Costo_Unitario
        {
            get { return costo_unitario; }
            set { costo_unitario = value; }
        }
        public decimal Costo_Total
        {
            get { return costo_total; }
            set { costo_total = value; }
        }
        public decimal Costo_Instalacion_Unidad
        {
            get { return costo_instalacion_unidad; }
            set { costo_instalacion_unidad = value; }
        }
        public decimal Costo_Instalacion_Total
        {
            get { return costo_instalacion_total; }
            set { costo_instalacion_total = value; }
        }
        public decimal Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        public int Indice
        {
            get { return indice; }
            set
            { indice = value; }
        }
        public ParametrosCollection Parametros
        {
            get
            { return parametros; }
        }
        public Descuentos Descuentos
        {
            get
            { return descuentos; }
        }
        public bool Utilizar
        {
            get { return utilizar; }
            set { utilizar = value; }
        }
        public decimal Desperdicio
        {
            get { return desperdicio; }
            set { desperdicio = value; }
        }
        public decimal VlrDesperdicio
        {
            get { return vlrdesperdicio; }
            set { vlrdesperdicio = value; }
        }
        #endregion
    }
}
