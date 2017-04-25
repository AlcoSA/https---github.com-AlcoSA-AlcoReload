using System;
using System.Drawing;

namespace DXF.Importador_DXF
{
        public class DXFArc : DXFVisibleEntity
    {
        #region Variables
        private float startAngle;
        private float endAngle;
        private float radius;
        private DXFVertex centerpoint;
        #endregion
        #region Constructor
        public DXFArc(){ centerpoint = new DXFVertex(); }
        #endregion
        #region Propiedades
        public float StartAngle
        {
            get { return startAngle; }
            set { startAngle = value;}
        }
        public float EndAngle
        {
            get { return endAngle; }
            set { endAngle = value; }
        }
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
                    radius =  Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 50:
                    startAngle = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 51:
                    endAngle = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                default:
                    base.ReadProperty();
                    break;
            }
        }
        public override void Loaded()
        {
            base.Loaded();
            centerpoint = new DXFVertex(0, 0, 0);
        }

        public override void Draw(Graphics G)
        {
            if (FVisible)
            {
                DXFVertex P1;
                float rd1 = radius;
                P1 = Converter.GetPoint(centerpoint);
                rd1 = rd1 * Converter.FScale;
                P1.X = P1.X - rd1;
                P1.Y = P1.Y - rd1;
                Color RealColor = DXFConst.EntColor(this, Converter.FParams.Insert);
                float sA = -startAngle, eA = -endAngle;
                if (endAngle < startAngle) sA = Conversion_Angle(sA);
                eA -= sA;
                G.DrawArc(new Pen(RealColor, 1), Math.Abs( P1.X), P1.Y, rd1 * 2, rd1 * 2, sA, eA);
            }
            
        }
        private float Conversion_Angle(float Val)
        {
            while (Val < 0) Val = Val + 360;
            return Val;
        }
        #endregion
    }    
}
