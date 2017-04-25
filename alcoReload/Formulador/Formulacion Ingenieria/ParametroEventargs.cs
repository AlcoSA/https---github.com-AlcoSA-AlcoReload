using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formulador
{
    public class ParametroEventargs
    {
        Parametro p;

        public ParametroEventargs(Parametro parametro)
        {
            p = parametro;
        }

        public Parametro Parametro
        {
            get { return p; }
        }
    }
}
