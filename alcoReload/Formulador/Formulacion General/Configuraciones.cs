using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formulador.Formulacion_General
{
    public static class Configuraciones
    {
        public static void Modificar_Consola(bool console)
        {
            Properties.Settings.Default.Consola = console;
            Properties.Settings.Default.Save();
        }
    }
}
