using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.Estructurador
{
    public class ValorCotaCambiado_EventArgs
    {
        #region Variables
        Cota_Region_Estructural cota;
        private string valor_antiguo, valor_nuevo;
        #endregion

        #region Constructor
        public ValorCotaCambiado_EventArgs(Cota_Region_Estructural cota, string valor_antiguo, string valor_nuevo)
        {
            this.cota = cota;
            this.valor_antiguo = valor_antiguo;
            this.valor_nuevo = valor_nuevo;
        }
        #endregion

        #region Propiedades
        public Cota_Region_Estructural Cota
        {
            get { return cota; }            
        }
        public string Valor_Antiguo
        { get { return valor_antiguo; } }
        public string Valor_Nuevo
        { get { return valor_nuevo; } }
        #endregion
    }
}
