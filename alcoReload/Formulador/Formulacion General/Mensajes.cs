using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formulador
{
    public class Mensajes
    {
        #region Variables
        private string mensaje = string.Empty;
        private int indicadorinicio = -1;
        private int largocadena = -1;
        #endregion
        #region Constructor
        public Mensajes() { }
        public Mensajes(string mensaje,int indicadorinicio, int largocadena)
        {
            this.mensaje = mensaje;
            this.indicadorinicio = indicadorinicio;
            this.largocadena = largocadena;
        }
        public Mensajes(string mensaje)
        {
            this.mensaje = mensaje;            
        }
        #endregion
        #region Propiedades
        public string Mensaje
        {
            get
            { return mensaje; }
            set
            { mensaje = value; }
        }
        public int IndicadorInicio
        {
            get
            { return indicadorinicio; }
            set
            {
                indicadorinicio = value;
            }
        }
        public int LargoCadena
        {
            get
            { return largocadena; }
            set
            { largocadena = value; }
        }
        #endregion
    }
}
