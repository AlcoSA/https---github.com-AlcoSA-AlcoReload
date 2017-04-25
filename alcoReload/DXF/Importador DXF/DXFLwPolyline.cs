using System;
using System.Drawing;
using System.Collections.Generic;
namespace DXF.Importador_DXF
{
    public class DXFLwPolyline : DXFVisibleEntity
    {
        #region Variables
        private float x, y;
        private List<DXFVertex> vertecoordinates = new List<DXFVertex>();
        private float numberofvertices;
        private Polyline_flag polylineflag = Polyline_flag.default_;
        #endregion
        #region Constructor
        public DXFLwPolyline() { }
        #endregion
        #region Propiedades
        public float NumberofVertices
        {
            get { return numberofvertices; }
            set { numberofvertices = value; }
        }
        public Polyline_flag PolylineFlag 
        {
            get { return polylineflag; }
            set { polylineflag = value; }
        }
        public List<DXFVertex> VertexCoordinates
        {
            get { return vertecoordinates; }
        }
        #endregion
        #region Procedimientos
        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 10:
                    x = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 20:
                    y = Convert.ToSingle(Converter.FValue, Converter.N);
                    vertecoordinates.Add(new DXFVertex(x, y, 0));
                    break;
                case 70:
                    polylineflag = (Polyline_flag)Convert.ToInt32(Converter.FValue);
                    break;
                case 90:
                    numberofvertices = Convert.ToSingle(Converter.FValue, Converter.N);
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
            List<PointF> listapf = new List<PointF>();
            for (int i = 0; i < vertecoordinates.Count; i++)
            {
                DXFVertex cpunto = Converter.GetPoint(vertecoordinates[i]);
                listapf.Add(new PointF(cpunto.X, cpunto.Y));
            }
            Converter.GetPoint(new DXFVertex(x, y, 0));
            Color RealColor = DXFConst.EntColor(this, Converter.FParams.Insert);
            Pen p = new Pen(new SolidBrush(RealColor), 1);
            switch (polylineflag)
            {
                case Polyline_flag.default_:
                    {
                        G.DrawLines(p, listapf.ToArray());
                        break;
                    }
                case Polyline_flag.closed:
                    {
                        G.DrawPolygon(p, listapf.ToArray());
                        break;
                    }
                case Polyline_flag.Plinegen:
                    {
                        p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        G.DrawLines(p, listapf.ToArray());
                        break;
                    }
            }
        }
        #endregion
    }
}
