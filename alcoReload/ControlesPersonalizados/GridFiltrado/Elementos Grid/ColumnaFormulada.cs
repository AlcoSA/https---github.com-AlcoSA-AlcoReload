using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public class ColumnaFormulada
    {
        #region vars
        private string nombre_columna = string.Empty;
        private string expresion = string.Empty;
        private int posicion = 0;
        #endregion
        #region ctor
        public ColumnaFormulada(string nombre_columna, string expresion, int posicion)
        {
            this.nombre_columna = nombre_columna;
            this.expresion = expresion;
            this.posicion = posicion;
        }
        #endregion
        #region props
        public string Nombre_Columna
        {
            get { return nombre_columna; }
            set { nombre_columna = value; }
        }
        public string Expresion
        {
            get { return expresion; }
            set { expresion = value; }
        }
        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        #endregion
    }
}
