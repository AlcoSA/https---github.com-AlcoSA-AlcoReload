namespace DXF.Importador_DXF
{
    public class DXFVertex
    {
        #region Variables
        private float x;
        private float y;
        private float z;
        #endregion
        #region Propiedades
        public float X
        {
            get { return x; }
            set { x= value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        public float Z
        {
            get { return z; }
            set { z = value; }
        }
        #endregion
        #region Constructor
        public DXFVertex()
        {
        }
        public DXFVertex(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion
    }
}
