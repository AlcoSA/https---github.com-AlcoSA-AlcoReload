using System;
using System.Collections.Generic;

namespace Formulador
{
    public delegate void valor_cambiado(object sender, ParametroEventargs e);
    public delegate void formula_cambiada(object sender, ParametroEventargs e);
    public class Parametro
    {
        #region Delegados
        public event valor_cambiado valor_cambiado;        
        protected virtual void OnValor_Cambiado(ParametroEventargs e)
        {
            valor_cambiado?.Invoke(this, e);
        }
        public event formula_cambiada formula_cambiada;
        protected virtual void OnFormula_Cambiada(ParametroEventargs e)
        {
            formula_cambiada?.Invoke(this, e);
        }
        #endregion

        #region Variables
        private int id = 0;
        private int indice = -1;
        private string nombre = string.Empty;
        private string formula = string.Empty;
        private string valor = string.Empty;
        private TiposValores tipovalor = TiposValores.Numerico;
        private List<string> posiblesvalores;
        private RestriccionCollection restricciones;
        #endregion
        #region Constructor
        public Parametro() { restricciones = new RestriccionCollection();
        posiblesvalores = new List<string>();}
        public Parametro(int indice,string nombre, string formula, string valor, TiposValores tipovalor)
        {
            this.indice = indice;
            this.nombre = nombre;
            this.formula = formula;
            this.valor = valor;
            this.tipovalor = tipovalor;
            posiblesvalores = new List<string>();
            restricciones = new RestriccionCollection();
        }
        public Parametro(string nombre, string formula, string valor, TiposValores tipovalor)
        {
            this.nombre = nombre;
            this.formula = formula;
            this.valor = valor;
            this.tipovalor = tipovalor;
            posiblesvalores = new List<string>();
            restricciones = new RestriccionCollection();
        }
        public Parametro(string nombre, string formula, string valor, TiposValores tipovalor, List<string> posiblesvalores)
        {
            this.nombre = nombre;
            this.formula = formula;
            this.valor = valor;
            this.tipovalor = tipovalor;
            this.posiblesvalores = posiblesvalores;
            restricciones = new RestriccionCollection();
        }
        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get
            { return nombre; }
            set
            { nombre = value;                
            }
        }
        public string Formula
        {
            get
            { return formula; }
            set
            { formula = value;
                OnFormula_Cambiada(new ParametroEventargs(this));
            }
        }
        public string Valor
        {
            get
            {
                if (tipovalor == TiposValores.Numerico)
                {
                    if (string.IsNullOrEmpty(valor)) { return "0"; }
                    else
                    {
                        if (restricciones.Count > 0)
                        {
                            decimal val = 0;
                            if (Decimal.TryParse(valor, out val))
                            {
                                if (decimal.Parse(restricciones[0].Valor) > val)
                                {
                                    return restricciones[0].Valor;
                                }
                                else
                                { return valor; }
                            }
                            else
                            {
                                return valor;
                            }
                            
                        }
                    }
                }
                else if(tipovalor == TiposValores.Letras)
                {
                    if (string.IsNullOrEmpty(valor)) { return "''"; }
                    else { return valor; }
                }
                else if(tipovalor == TiposValores.Booleano)
                {
                    if (string.IsNullOrEmpty(valor)) { return "0"; }
                    else { return valor; }
                }
                else
                {
                    if (string.IsNullOrEmpty(valor)) { return "''"; }
                    else { return valor; }
                }
                return valor;
            }
            set
            { valor = value;
                OnValor_Cambiado(new ParametroEventargs(this));
            }
        }
        public TiposValores TipoValor
        {
            get
            { return tipovalor; }
            set
            {
                tipovalor = value;
            }
        }
        public RestriccionCollection Restricciones
        {
            get
            {
                return restricciones;
            }
        }
        public List<string> PosiblesValores
        {
            get { return posiblesvalores; }
            set { posiblesvalores = value; }
        }
        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }


        #endregion
    }
}
