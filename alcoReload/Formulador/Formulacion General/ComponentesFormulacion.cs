using System;
using System.Collections.Generic;

namespace Formulador
{
     public class ComponentesFormulacion
    {
        #region Variables
        private string nombre = string.Empty;
        private List<string> definiciones;
        private string ayuda = string.Empty;
        
        #endregion

        #region Constructor
        public ComponentesFormulacion()
        {
            nombre = string.Empty;
            definiciones = new List<string>();
            ayuda = string.Empty;
        }
        public ComponentesFormulacion(string nombre, List<string> definiciones, string ayuda )
        {
            this.nombre = nombre;
            this.definiciones = definiciones;
            this.ayuda = ayuda;       
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
        public List<string> Definiciones
        {
            get
            { return definiciones; }
            set
            { definiciones = value; }
        }
        public string Ayuda
        {
            get
            { return ayuda; }
            set
            { ayuda = value; }
        }

        #endregion

        #region Funciones
        public string AyudaCompleta()
        {
            try
            {
                string ayudacompleta = string.Empty;
                ayudacompleta += ayuda + "\n\n";
                for (int i = 0; i < definiciones.Count; i++)
                {
                    ayudacompleta += definiciones[i] + "\n\n";
                }
                return ayudacompleta;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

    }
}
