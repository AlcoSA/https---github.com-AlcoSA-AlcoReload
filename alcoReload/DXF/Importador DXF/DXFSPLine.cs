using System;
using System.Drawing;
using System.Collections.Generic;

namespace DXF.Importador_DXF
{
    public class DXFSPLine : DXFVisibleEntity
    {
        #region Variables
        private float x, y;
        private List<DXFVertex> controlpoints, fitpoints;
        
        private List<float> knotvalues;
        private float degree;
        private int numberofknots, numberofcontrolpoints, numberoffitpoints;
        private int weight = 1;
        private float knottolerance, controlpointtolerance, fittolerance = 0.0000001F;        
        private Spline_flag splineflag = Spline_flag.default_;
        #endregion
        #region Constructor
        public DXFSPLine()
        {
            controlpoints = new List<DXFVertex>();
            fitpoints = new List<DXFVertex>();
            knotvalues = new List<float>();
        }
        #endregion
        #region Propiedades
        public Spline_flag SplineFlag
        {
            get { return splineflag; }
            set { splineflag = value; }
        }
        public List<DXFVertex> VertexCoordinates
        {
            get { return controlpoints; }
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
                    break;
                case 30:
                    controlpoints.Add(new DXFVertex(x, y,
                        Convert.ToSingle(Converter.FValue, Converter.N)));
                    break;
                case 11:
                    x = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 21:
                    y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 31:
                    fitpoints.Add(new DXFVertex(x, y,
                        Convert.ToSingle(Converter.FValue, Converter.N)));
                    break;
                case 40:
                    knotvalues.Add(Convert.ToSingle(Converter.FValue, Converter.N));
                    break;
                case 41:
                    weight = Convert.ToInt32(Converter.FValue);
                    break;
                case 42:
                    knottolerance = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 43:
                    controlpointtolerance = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 44:
                    fittolerance = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 70:
                    splineflag = (Spline_flag)Convert.ToInt32(Converter.FValue);
                    break;
                case 71:
                    degree = Convert.ToInt32(Converter.FValue);
                    break;
                case 72:
                    numberofknots = Convert.ToInt32(Converter.FValue);
                    break;
                case 73:
                    numberofcontrolpoints = Convert.ToInt32(Converter.FValue);
                    break;
                case 74:
                    numberoffitpoints = Convert.ToInt32(Converter.FValue);
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
            for (int i = 0; i < controlpoints.Count; i++)
            {
                DXFVertex cpunto = Converter.GetPoint(controlpoints[i]);
                listapf.Add(new PointF(cpunto.X, cpunto.Y));
            }
            Converter.GetPoint(new DXFVertex(x, y, 0));
            Color RealColor = DXFConst.EntColor(this, Converter.FParams.Insert);
            Pen p = new Pen(new SolidBrush(RealColor), 1);
            switch (splineflag)
            {
                case Spline_flag.default_:
                    break;
                case Spline_flag.ClosedSpline:
                    G.DrawClosedCurve(p, listapf.ToArray(), controlpointtolerance, System.Drawing.Drawing2D.FillMode.Alternate);
                    break;
                case Spline_flag.Linear:
                    G.DrawCurve(p, listapf.ToArray(), controlpointtolerance);
                    break;
                case Spline_flag.PeriodicSpline:
                    break;
                case Spline_flag.Planar:
                    G.DrawCurve(p, listapf.ToArray());
                    break;
                case Spline_flag.RationalSpline:
                    break;
            }
        }
        #endregion
    }
}
