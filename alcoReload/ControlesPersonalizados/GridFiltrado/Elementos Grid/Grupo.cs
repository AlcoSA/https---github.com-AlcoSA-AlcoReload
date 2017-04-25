using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public class Grupo
    {
        #region var
        string nombre_columna;
        #endregion

        #region props
        public string Nombre_Columna
        {
            get { return nombre_columna; }
            set { nombre_columna = value; }
        }
        #endregion

        #region ctor
        public Grupo(string nombre_columna)
        {
            this.nombre_columna = nombre_columna;
        }
        #endregion

    }
}
