using System;
using System.Drawing;

namespace DXF.Importador_DXF
{
    public class DXFCircle : DXFVisibleEntity
    {
        #region Variables       
        private float radius;
        private DXFVertex centerpoint;
        #endregion
        #region Constructor
        public DXFCircle() { centerpoint = new DXFVertex(); }
        #endregion
        #region Propiedades
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public DXFVertex CenterPoint
        {
            get { return centerpoint; }
            set { centerpoint = value; }
        }
        #endregion
        #region Procedimientos
        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 10:
                    centerpoint.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 20:
                    centerpoint.Y = Convert.ToSingle(Converter.FValue, Converter.N);                    
                    break;
                case 30:
                    centerpoint.Z = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 40:
                    radius = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                default:
                    base.ReadProperty();
                    break;
            }
        }
        public override void Loaded()
        {
            base.Loaded();
        }
        public override void Draw(Graphics G)
        {
            if (FVisible)
            {
                DXFVertex P1;
                P1 = Converter.GetPoint(centerpoint);
                Color RealColor = DXFConst.EntColor(this, Converter.FParams.Insert);
                G.DrawEllipse(new Pen(RealColor, 1), P1.X -(radius * Converter.FScale),
                    P1.Y- (radius * Converter.FScale), (radius * Converter.FScale) * 2,
                    (radius * Converter.FScale) * 2);            }

        }
        #endregion
    }
}
