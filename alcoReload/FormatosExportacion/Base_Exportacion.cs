using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatosExportacion
{
    public abstract class Base_Exportacion
    {
        internal string ruta = string.Empty;
        internal string usuariocreacion = string.Empty;

        public Base_Exportacion(string ruta, string usuario)
        {
            this.ruta = ruta;
            this.usuariocreacion = usuario;
        }
    }
}
