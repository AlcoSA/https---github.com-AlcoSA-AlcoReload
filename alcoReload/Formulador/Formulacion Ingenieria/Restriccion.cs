
namespace Formulador
{
   public class Restriccion
    {
        #region Variables
        private string nombre = string.Empty;
        private string valor = string.Empty;
        private string formula = string.Empty;
        private TiposValores tipovalor = TiposValores.Numerico;
        #endregion
        #region Constructor
        public Restriccion() { }
        public Restriccion(string nombre, string valor, TiposValores tipovalor)
        {
            this.nombre = nombre;
            this.valor = valor;
            this.tipovalor = tipovalor;
        }
        public Restriccion(string nombre, string formula, string valor, TiposValores tipovalor)
        {
            this.nombre = nombre;
            this.formula = formula;
            this.valor = valor;
            this.tipovalor = tipovalor;
        }
        #endregion
        #region Propiedades
        public string Nombre
        {
            get
            { return nombre; }
            set
            { nombre = value; }
        }
        public string Formula
        {
            get
            { return formula; }
            set
            { formula = value; }
        }
        public string Valor
        {
            get
            {return valor; }
            set
            {valor = value; }
        }
        public TiposValores TipoValor
        {
            get
            { return tipovalor; }
            set{
                tipovalor = value;
            }
        }
        #endregion
    }
}
