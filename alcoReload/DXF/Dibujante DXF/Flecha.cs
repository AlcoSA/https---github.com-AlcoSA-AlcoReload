using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;

namespace DXF.Dibujante_DXF
{
    class Flecha : ComponenteVentana
    {
        #region Variables
        private string valor = string.Empty;
        private string formula = string.Empty;
        #endregion
        #region Constructor
        public Flecha(PointF puntoinicial, string nombre) : base(puntoinicial, nombre)
        {
            FinalLapiz();
        }
        public Flecha(PointF puntoinicial, PointF puntofinal, string nombre, string visibilidad) : base(puntoinicial, puntofinal, nombre, visibilidad)
        {
            FinalLapiz();
        }
        #endregion
        #region Propiedades      
        public override RectangleF RegionExterna
        {
            get
            {
                float[] x = new float[] { Punto1.X, Punto3.X };
                List<float> y = new List<float>() { Punto1.Y, Punto3.Y };
                RectangleF rect = new RectangleF();
                rect = new RectangleF(((x.Min() - 5) * Owner.zoom_factor) + Owner.traslacion_factor[0], ((y.Min() - 5) * Owner.zoom_factor) + Owner.traslacion_factor[0],
                    (x.Max() - x.Min() + 10) * Owner.zoom_factor, (y.Max() - y.Min() + 10) * Owner.zoom_factor);
                return rect;
            }
        }
        #endregion
        #region Procedimientos
        private void FinalLapiz()
        {
            GraphicsPath start_path = new GraphicsPath();
            start_path.AddPolygon(new System.Drawing.PointF[] { new System.Drawing.PointF(-2.5F, 0), new System.Drawing.PointF(2.5F, 0), new System.Drawing.PointF(0, 3) });
            CustomLineCap c_cap = new CustomLineCap(null, start_path);
            lapiz.EndCap = System.Drawing.Drawing2D.LineCap.Custom;
            lapiz.CustomEndCap = c_cap;
        }
        public override void Dibujar(Graphics g, bool posrelativa = false)
        {
            if (posrelativa)
            {

                g.DrawLine(lapiz, ((Punto1.X - Owner.difrelativa_x) * owner.zoom_factor) + owner.traslacion_factor[0],
                    ((Punto1.Y - Owner.difrelativa_y) * owner.zoom_factor) + owner.traslacion_factor[1],
                    ((Punto3.X - Owner.difrelativa_x) * owner.zoom_factor) + owner.traslacion_factor[0],
                    ((Punto3.Y - Owner.difrelativa_y) * owner.zoom_factor) + owner.traslacion_factor[1]);
            }
            else
            {
                g.DrawLine(lapiz, (Punto1.X * owner.zoom_factor) + owner.traslacion_factor[0],
                                    (Punto1.Y * owner.zoom_factor) + owner.traslacion_factor[1],
                                    (Punto3.X * owner.zoom_factor) + owner.traslacion_factor[0],
                                    (Punto3.Y * owner.zoom_factor) + owner.traslacion_factor[1]);
            }
        }
        #endregion
    }
}
