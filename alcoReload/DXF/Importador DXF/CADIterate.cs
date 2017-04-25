
namespace DXF.Importador_DXF
{
    public class CADIterate
    {
        #region Variables
        private DXFVertex scale;
        private DXFMatrix matrix;
        private DXFInsert insert;
        #endregion
        #region Constructor
        public CADIterate()
        {
            scale = new DXFVertex();
            //matrix = new DXFMatrix();
            //insert = new DXFInsert();
        }
        #endregion
        #region Propiedades
        public DXFVertex Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public DXFMatrix Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public DXFInsert Insert
        {
            get { return insert; }
            set { insert = value; }
        }
        #endregion
    }
}
