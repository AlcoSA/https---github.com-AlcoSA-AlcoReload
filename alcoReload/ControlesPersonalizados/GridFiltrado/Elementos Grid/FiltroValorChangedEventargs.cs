using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public class FiltroValorChangedEventargs
    {
        #region vars
        Filtro filtro;
        #endregion
        #region props
        public Filtro Filtro
        {
            get { return filtro; }            
        }
        #endregion
        #region ctor
        public FiltroValorChangedEventargs(Filtro filtro)
        {
            this.filtro = filtro;
        }
        #endregion

    }
}
