using System;
using System.Drawing;

namespace DXF.Importador_DXF
{
    public class DXFEllipse : DXFVisibleEntity
    {
        public float angle;
        public DXFVertex centerpoint, endpoint;
        public float ratio;

        public DXFEllipse()
        {
            centerpoint = new DXFVertex();
            endpoint = new DXFVertex();
        }

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
                case 11:
                    endpoint.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 21:
                    endpoint.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 31:
                    endpoint.Z = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 40:
                    ratio = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 62:
                    FColor = CADImage.IntToColor(Convert.ToInt32(Converter.FValue, Converter.N));
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
            DXFVertex P1;
            float rd1, rd2;
            rd1 = Math.Abs((centerpoint.X - endpoint.X) * ratio) * Converter.FScale;
            rd2 = Math.Abs((centerpoint.Y - endpoint.Y) * ratio)* Converter.FScale;
            //if (endpoint.X == 0)
            //{
            //    rd1 = Math.Abs((centerpoint.X - endpoint.X) * ratio);
            //    rd2 = (centerpoint.X - endpoint.X);
            //}
            //else
            //{
            //    rd1 = (centerpoint.X - endpoint.X);
            //    rd2 = Math.Abs(radius * ratio);
            //}
            P1 = Converter.GetPoint(centerpoint);
            P1.X = P1.X - rd1;
            P1.Y = P1.Y - rd2;
            Color RealColor = DXFConst.EntColor(this, Converter.FParams.Insert);
            if (RealColor == DXFConst.clNone) RealColor = Color.Black;

            if (FVisible)
            {
                G.DrawEllipse(new Pen(RealColor, 1), P1.X, P1.Y, rd1 * 2, rd2 * 2 );
                //if (eA == 0) 
                //else G.DrawArc(new Pen(RealColor, 1), P1.X, P1.Y, rd1 * 2, rd2 * 2, 0, 360);//sA, eA);
            }
        }
    }
}
