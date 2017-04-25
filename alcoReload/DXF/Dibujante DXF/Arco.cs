using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace DXF.Dibujante_DXF
{
    public class Arco : ComponenteVentana
    {
        #region Constructor
        public Arco(PointF puntoinicial, string nombre) : base(puntoinicial, nombre)
        {
        }
        public Arco(PointF puntoinicial, PointF puntofinal, string nombre, string visibilidad) : base(puntoinicial, puntofinal, nombre, visibilidad)
        {
        }
        public Arco(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool circular, string nombre) : base(punto1, punto2, punto3, punto4, circular, nombre)
        {
        }
        public Arco(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool circular, string nombre, string visibilidad) : base(punto1, punto2, punto3, punto4, circular, nombre, visibilidad)
        {
        }
        #endregion
        #region Propiedades

        public override RectangleF RegionExterna
        {
            get
            {
                List<float> x = new List<float>() { punto1.X, punto3.X};
                List<float> y = new List<float>() { punto1.Y, punto3.Y};
                PointF inicio = new PointF(x.Min(), y.Min());
                SizeF fin = new SizeF(x.Max() - inicio.X, y.Max() - inicio.Y);
                if (owner != null)
                {
                    return new RectangleF((inicio.X * owner.zoom_factor) + owner.traslacion_factor[0], (inicio.Y * owner.zoom_factor) + owner.traslacion_factor[1],
                    fin.Width * owner.zoom_factor, fin.Height * owner.zoom_factor);
                }
                else
                { return  new RectangleF(inicio, fin); }                
            }
            set
            {                
            }
        }

        #endregion
        #region Procedimientos
        public override void Dibujar(Graphics g, bool posrelativa = false)
        {
            #region Rectángulo de trabajo
            RectangleF r;
            List<float> x = new List<float>() { punto1.X, punto3.X};
            List<float> y = new List<float>() { punto1.Y, punto3.Y};
            PointF inicio = new PointF(x.Min(), y.Min());
            SizeF fin = new SizeF(x.Max() - inicio.X, y.Max() - inicio.Y);
            if (owner != null)
            {
                r = new RectangleF((inicio.X * owner.zoom_factor) + owner.traslacion_factor[0], (inicio.Y * owner.zoom_factor) + owner.traslacion_factor[1],
                fin.Width * owner.zoom_factor, fin.Height * owner.zoom_factor);
            }
            else
            { r = new RectangleF(inicio, fin); }            
            if (posrelativa)
            {
                r.X -= owner.difrelativa_x; r.Width -= owner.difrelativa_x;
                r.Y -= owner.difrelativa_y; r.Height -= owner.difrelativa_y;                
            }
            #endregion

            g.TranslateTransform(r.X + (r.Width / 2), r.Y + (r.Height / 2));
            g.RotateTransform(rotacion);
            g.TranslateTransform(-(r.X + (r.Width / 2)), -(r.Y + (r.Height / 2)));
            if (!(r.Width <= 10 || r.Height <= 10))
            {
                float angInical = Punto3.Y > Punto1.Y ? 0 : -180;
                float angIntInical = Punto3.Y > Punto1.Y ? -2.5F : -177.5F;

                #region Relleno
                if (material != null)
                {
                    GraphicsPath path = new GraphicsPath();
                    using (path = new GraphicsPath())
                    {
                        path.AddArc(r.X, r.Y, r.Width, r.Height * 2, angInical, 180);
                        path.AddLine(r.X, r.Y + r.Height, r.X + r.Width, r.Y + r.Height);                        
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
                    GraphicsPath path = new GraphicsPath();
                    using (path = new GraphicsPath())
                    {
                        path.AddArc(r.X, r.Y, r.Width, r.Height * 2, angInical, 180);
                        path.AddLine(r.X, r.Y + r.Height, r.X + r.Width, r.Y + r.Height);
                        g.FillPath(new SolidBrush(color_fondo), path);
                    }
                    
                }
                #endregion

                #region Externo
                g.DrawArc(lapiz, r.X, r.Y,
                    r.Width, r.Height*2,
                    angInical, 180);
                g.DrawLine(lapiz, r.X, r.Y + r.Height,
                            r.X + r.Width, r.Y + r.Height);
                #endregion
            }
            g.ResetTransform();
        }
        #endregion
    }
}
