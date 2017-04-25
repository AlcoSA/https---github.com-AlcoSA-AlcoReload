using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Norma_NSR.NSR10
{
    public class Parametros_Tabla_Final_10
    {
        #region Variables
        private decimal altura_instalacion = 0;
        private decimal presion_diseño_b23=0;
        private decimal presion_diseño_b24=0;
        private decimal w=0;
        private decimal wu=0;
        private decimal wu_centesima=0;
        private decimal mu = 0;
        private decimal deflexion_servicio = 0;        
        private bool resistencia = false;
        private bool deflexion = false;
        #endregion

        #region Constructor
        public Parametros_Tabla_Final_10() { }
        #endregion

        #region Propiedades
        public decimal Altura_Instalacion
        {
            get { return altura_instalacion; }
            set { altura_instalacion = value; }
        }
        public decimal Presion_Diseño_B23
        {
            get { return presion_diseño_b23; }
            set { presion_diseño_b23 = value; }
        }
        public decimal Presion_Diseño_B24
        {
            get { return presion_diseño_b24; }
            set { presion_diseño_b24 = value; }
        }
        public decimal W
        {
            get { return w; }
            set { w = value; }
        }
        public decimal Wu
        {
            get { return wu; }
            set { wu = value; }
        }
        public decimal Centesima_de_Wu
        {
            get { return wu_centesima; }
            set { wu_centesima = value; }
        }
        public decimal Mu
        {
            get { return mu; }
            set { mu = value; }
        }
        public decimal Deflexion_Servicio
        {
            get { return deflexion_servicio; }
            set { deflexion_servicio = value; }
        }
        public bool Resistencia
        {
            get { return resistencia; }
            set { resistencia = value; }
        }
        public bool Deflexion
        {
            get { return deflexion; }
            set { deflexion = value; }
        }
        #endregion
    }
}
