using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
namespace DXF.Dibujante_DXF
{
    public class Ele:ComponenteVentana
    {
        #region Constructor
        public Ele(PointF puntoinicial, string nombre) : base(puntoinicial, nombre)
        {            
        }
        public Ele(PointF puntoinicial, PointF puntofinal, string nombre, string visibilidad) : base(puntoinicial, puntofinal, nombre, visibilidad)
        {            
        }
        public Ele(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool circular, string nombre) : base(punto1, punto2, punto3, punto4, circular, nombre)
        {            
        }
        public Ele(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool circular, string nombre, string visibilidad) : base(punto1, punto2, punto3, punto4, circular, nombre, visibilidad)
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
            if (r.Width > 5 && r.Height > 5)
            {
                #region Relleno
                GraphicsPath path;
                if (material != null)
                {                    
                    using (path = new GraphicsPath())
                    {
                        path.AddArc(r.X, r.Y - 10, r.Width, 20, 0, 180);
                        path.AddLine(r.X, r.Y, r.X, r.Y + r.Height);
                        path.AddLine(r.X + r.Width, r.Y, r.X + r.Width, r.Y + r.Height);
                        path.AddArc(r.X, r.Y + r.Height - 10, r.Width, 20, 0, 180);                        
                        switch (material.TipoObjeto)
                        {
                            case Formulador.TiposElementos.Vidrios:
                                Color cV = owner.dics.ObtenerColorVidrio(material.Parametros["COLOR"].Valor);
                                LinearGradientBrush bg = new LinearGradientBrush(RegionExterna, cV, Color.White, LinearGradientMode.ForwardDiagonal);
                                g.FillPath(bg, path);
                                break;
                            case Formulador.TiposElementos.Perfiles:
                                //Color cP = owner.dics.ObtenerColorPerfil(material.Parametros["ACABADO"].Valor);
                                //g.FillPath(new SolidBrush(cP), path);
                                break;
                        }
                    }
                }
                else
                {
                    using (path = new GraphicsPath())
                    {
                        path.AddArc(r.X, r.Y - 10, r.Width, 20, 0, 180);
                        path.AddLine(r.X, r.Y, r.X, r.Y + r.Height);
                        path.AddLine(r.X + r.Width, r.Y, r.X + r.Width, r.Y + r.Height);
                        path.AddArc(r.X, r.Y + r.Height - 10, r.Width, 20, 0, 180);
                        g.FillPath(new SolidBrush(color_fondo), path);
                    }
                }
                #endregion
                g.DrawArc(lapiz, r.X + 1, r.Y - 10, r.Width - 2, 20, 0, 180);
                g.DrawLine(lapiz, r.X + r.Width, r.Y, r.X + r.Width, r.Y + r.Height);
                g.DrawArc(lapiz, r.X, r.Y + r.Height - 10, r.Width, 20, 0, 180);
                g.DrawLine(lapiz, r.X, r.Y, r.X, r.Y + r.Height);
            }
            g.ResetTransform();
        }
        #endregion
    }
}
