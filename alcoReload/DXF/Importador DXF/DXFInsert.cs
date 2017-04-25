
using System;
using System.Drawing;

namespace DXF.Importador_DXF
{
    public class DXFInsert : DXFVisibleEntity
    {
        #region Variables
        private DXFMatrix matrix;
        public DXFInsert owner;
        public DXFBlock FBlock;
        private DXFVertex scale, insertionpoint;
        private Color color;
        private float rotationangle = 0;
        private int columncount = 1;
        private int rowcount = 1;
        private int columnspacing = 0;
        private int rowspacing = 0;
        private double sin;
        private double cos;
        #endregion
        #region Constructor
        public DXFInsert()
        {
            matrix = new DXFMatrix();
            insertionpoint = new DXFVertex();
            scale = new DXFVertex(1, 1, 1);
            Matrix.IdentityMat();
        }
        #endregion
        #region Propiedades
        public DXFMatrix Matrix
        {
            get {return matrix;}
            set {matrix = value;}
        }
        public DXFVertex InsertionPoint
        {
            get { return insertionpoint; }
            set { insertionpoint = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public DXFVertex Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public DXFInsert Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public float RotationAngle
        {
            get { return rotationangle; }
            set { rotationangle = value;
                sin = Math.Sin(DXFConst.Radian(rotationangle));
                cos = Math.Cos(DXFConst.Radian(rotationangle));
            }
        }
        public int ColumnCount
        {
            get { return columncount; }
            set { columncount = value; }
        }
        public int RowCount
        {
            get { return rowcount; }
            set { rowcount = value; }
        }
        public int ColumnSpacing
        {
            get { return columnspacing; }
            set { columnspacing = value; }
        }
        public int RowSpacing
        {
            get { return rowspacing; }
            set { rowspacing = value; }
        }
        #endregion
        #region Procedimientos
        public override void Invoke(CADEntityProc Proc, CADIterate Params)
        {
            if (Params.Matrix == null) Params.Matrix = new DXFMatrix();
            if (FBlock == null) return;
            CADIterate Iter;
            Iter = Params;
            Params.Matrix = matrix;
            Params.Scale = scale;
            Params.Insert = this;
            Converter.FParams = Params;
            FBlock.Iterate(Proc, Params);
            Converter.FParams = Iter;
            Params = Iter;
            owner = Params.Insert;
        }
        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 2:
                    FBlock = Converter.FindBlock(Converter.FValue);
                    break;
                case 10:
                    insertionpoint.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 20:
                    insertionpoint.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 30:
                    insertionpoint.Z = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 41:
                    scale.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 42:
                    scale.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 43:
                    scale.Z = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 44:
                    columnspacing = Convert.ToInt32(Converter.FValue);
                    break;
                case 45:
                    rowspacing = Convert.ToInt32(Converter.FValue);
                    break;
                case 50:
                    rotationangle = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 70:
                    columncount = Convert.ToInt32(Converter.FValue);
                    break;
                case 71:
                    rowcount = Convert.ToInt32(Converter.FValue);
                    break;               
                default:
                    base.ReadProperty();
                    break;
            }
        }
        public override void Loaded()
        {
            matrix = new DXFMatrix();
            matrix = DXFMatrix.MatXMat(matrix, DXFMatrix.StdMat(new DXFVertex(1, 1, 1), insertionpoint));
        }
        #endregion
    }
}
