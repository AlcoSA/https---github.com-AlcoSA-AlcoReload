namespace Formulador
{
    public class Descuento
    {
        #region Variables
        internal int id = 0;
        internal int iddescuento = 0;
        internal string nombre;
        internal decimal valor;
        internal string formula;
        internal Descuentos owner;
        internal bool calculado =  false;
        #endregion

        #region Constructor
        public Descuento(int iddescuento, string nombre, decimal valor, string formula)
        {
            this.iddescuento = iddescuento;
            this.nombre = nombre;
            this.valor = valor;
            this.formula = formula;
        }
        public Descuento(int id,int iddescuento, string nombre, decimal valor, string formula)
        {
            this.id = id;
            this.iddescuento = iddescuento;
            this.nombre = nombre;
            this.valor = valor;
            this.formula = formula;
        }
        #endregion

        #region Propiedades
        public int Id
        {
            get
            { return id; }
            set { id = value; }
        }
        public int IdDescuento
        {
            get
            { return iddescuento; }
            set { iddescuento = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public decimal Valor
        {
            get {
                if (calculado && owner !=null)
                {
                    return owner.Calculado();
                }
                else
                { return valor; }
            }
                
            set { valor = value; }
        }
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }
        #endregion
    }
}
