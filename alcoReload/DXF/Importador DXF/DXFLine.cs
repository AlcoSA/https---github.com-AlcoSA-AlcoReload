using System;
using System.Drawing;

namespace DXF.Importador_DXF
{
    public class DXFLine : DXFVisibleEntity
    {
        #region Variables
        public DXFVertex startpoint, endpoint;
        #endregion
        #region Constructor
        public DXFLine()
        {
            startpoint = new DXFVertex();
            endpoint = new DXFVertex();
        }
        #endregion
        #region Propiedades
        public DXFVertex StartPoint
        {
            get { return startpoint; }
            set { startpoint = value; }
        }
        public DXFVertex EndPoint
        {
            get { return endpoint; }
            set { endpoint = value; }
        }
        #endregion
        #region Procedimientos
        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 10:
                    startpoint.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 20:
                    startpoint.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 11:
                    endpoint.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 21:
                    endpoint.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                default:
                    base.ReadProperty();
                    break;
            }
        }

        public override void Draw(System.Drawing.Graphics G)
        {
            DXFVertex P1, P2;
            Color RealColor = DXFConst.EntColor(this, Converter.FParams.Insert);
            P1 = Converter.GetPoint(startpoint);
            P2 = Converter.GetPoint(endpoint);
            if (FVisible)
                G.DrawLine(new Pen(RealColor, 1), P1.X, P1.Y, P2.X, P2.Y);
        }
        #endregion
    }
}
