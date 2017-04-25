using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;

namespace DXF.Dibujante_DXF
{
    public class Angeo :ComponenteVentana
    {
        #region Constructor
        public Angeo(PointF puntoinicial, string nombre) : base(puntoinicial, nombre)
        {
        }
        public Angeo(PointF puntoinicial, PointF puntofinal,  string nombre, string visibilidad) : base(puntoinicial, puntofinal, nombre, visibilidad)
        {
        }
        public Angeo(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool circular, string nombre) : base(punto1, punto2, punto3, punto4, circular, nombre)
        {
        }
        public Angeo(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool circular, string nombre, string visibilidad) : base(punto1, punto2, punto3, punto4, circular, nombre, visibilidad)
        {
        }
        #endregion
        #region Procedimientos
        public override void Dibujar(Graphics g, bool posrelativa = false)
        {
            RectangleF r = RegionExterna;
            g.TranslateTransform(r.X + (r.Width / 2), r.Y + (r.Height / 2));
            g.RotateTransform(rotacion);
            g.TranslateTransform(-(r.X + (r.Width / 2)), -(r.Y + (r.Height / 2)));
            if (FormaCircular)
            {
                if (material != null)
                {
                    switch (material.TipoObjeto)
                    {
                        case Formulador.TiposElementos.Vidrios:
                            Color cV = owner.dics.ObtenerColorVidrio(material.Parametros["COLOR"].Valor);
                            LinearGradientBrush bg = new LinearGradientBrush(r, cV, Color.White, LinearGradientMode.ForwardDiagonal);
                            //g.FillEllipse(bg, r);
                            break;
                        case Formulador.TiposElementos.Perfiles:
                            Color cP = owner.dics.ObtenerColorVidrio(material.Parametros["ACABADO"].Valor);
                            //g.FillEllipse(new SolidBrush(cP), r);
                            break;
                    }
                }
                else
                { g.FillEllipse(new SolidBrush(color_fondo), r); }
                g.DrawEllipse(lapiz, r);                
                g.FillEllipse(new HatchBrush(System.Drawing.Drawing2D.HatchStyle.LargeGrid,
                                                    color, System.Drawing.Color.Transparent),
                                                    r);
            }
            else
            {
                PointF[] externos = MarcoBasico(posrelativa).Select(x => new PointF((x.X * owner.zoom_factor) + owner.traslacion_factor[0], (x.Y * owner.zoom_factor) + owner.traslacion_factor[1])).ToArray();
                if (material != null)
                {
                    switch (material.TipoObjeto)
                    {
                        case Formulador.TiposElementos.Vidrios:
                            Color cV = owner.dics.ObtenerColorVidrio(material.Parametros["COLOR"].Valor);
                            LinearGradientBrush bg = new LinearGradientBrush(RegionExterna, cV, Color.White, LinearGradientMode.ForwardDiagonal);
                            //g.FillPolygon(bg, externos);
                            break;
                        case Formulador.TiposElementos.Perfiles:
                            Color cP = owner.dics.ObtenerColorPerfil(material.Parametros["ACABADO"].Valor);
                            //g.FillPolygon(new SolidBrush(cP), externos);
                            break;
                    }
                }
                else { g.FillPolygon(new SolidBrush(color_fondo), externos); }
                g.DrawPolygon(lapiz, externos);                
                g.FillPolygon(new HatchBrush(System.Drawing.Drawing2D.HatchStyle.LargeGrid,
                                                    color, System.Drawing.Color.Transparent), externos);
            }
            g.ResetTransform();
        }
        #endregion
    }
}
