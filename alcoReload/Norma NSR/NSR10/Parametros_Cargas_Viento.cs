namespace Norma_NSR.NSR10
{
    public class Parametros_Cargas_Viento
    {
        #region Variables
        private decimal z = 0;
        private decimal kz = 0;
        private decimal qz = 0;
        private decimal zona_4_pos = 0;
        private decimal zona_4_neg = 0;
        private decimal zona_5_pos = 0;
        private decimal zona_5_neg = 0;
        #endregion
        #region Constructor
        public Parametros_Cargas_Viento() { }
        #endregion
        #region Propiedades
        public decimal Z
        {
            get { return z; }
            set { z = value; }
        }
        public decimal Kz
        {
            get { return kz; }
            set { kz = value; }
        }
        public decimal qZ
        {
            get { return qz; }
            set { qz = value; }
        }
        public decimal Zona_4_Pos
        {
            get { return zona_4_pos; }
            set { zona_4_pos = value; }
        }
        public decimal Zona_4_Neg
        {
            get { return zona_4_neg; }
            set { zona_4_neg = value; }
        }
        public decimal Zona_5_Pos
        {
            get { return zona_5_pos; }
            set { zona_5_pos = value; }
        }
        public decimal Zona_5_Neg
        {
            get { return zona_5_neg; }
            set { zona_5_neg = value; }
        }
        #endregion
    }
}
