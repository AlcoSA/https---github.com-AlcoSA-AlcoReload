using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.Estructurador
{
    public class Region_Content_Changed_EventArgs
    {
        decimal ancho, alto;

        public Region_Content_Changed_EventArgs(decimal ancho, decimal alto)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public decimal Ancho
        {
            get { return ancho; }
        }

        public decimal Alto
        { get { return alto; } }
    }
}
