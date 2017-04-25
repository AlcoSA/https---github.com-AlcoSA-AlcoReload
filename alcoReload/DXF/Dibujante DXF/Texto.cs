using System.Drawing;
using System.Linq;
using System;
using System.Text;

namespace DXF.Dibujante_DXF
{
    public class Texto : ComponenteVentana
    {
        #region Variables
        private string valor = string.Empty;
        private string formula = string.Empty;
        private Font font;
        #endregion
        #region Constructor
        public Texto(PointF puntoinicial, string nombre, string formula, string valor) : base(puntoinicial, nombre)
        {
            this.valor = valor;
            this.formula = formula;
            font = new Font("arial", 8);
        }
        public Texto(PointF puntoinicial, PointF puntofinal, string nombre, string valor, string formula, string visibilidad) : base(puntoinicial, puntofinal, nombre, visibilidad)
        {
            this.valor = valor;
            this.formula = formula;
            font = new Font("arial", 8);
        }
        #endregion
        #region Propiedades
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }
        public override RectangleF RegionExterna
        {
            get
            {
                float[] x = new float[] { (Punto1.X * owner.zoom_factor) + owner.traslacion_factor[0], (Punto3.X * owner.zoom_factor) + owner.traslacion_factor[0] };
                float[] y = new float[] { (Punto1.Y * owner.zoom_factor) + owner.traslacion_factor[1], (Punto3.Y * owner.zoom_factor) + owner.traslacion_factor[1] };
                RectangleF rect = new RectangleF();
                Font f = new Font(font.FontFamily.Name, font.Size * owner.zoom_factor, font.Style);
                Size offset = System.Windows.Forms.TextRenderer.MeasureText(valor, f);
                rect = new RectangleF(x.Min(), y.Min() - 10, offset.Width, offset.Height + 20);
                return rect;
            }
        }
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }
        #endregion
        #region Procedimientos
        public override void Dibujar(Graphics g, bool posrelativa = false)
        {            
            RectangleF r = RegionExterna;
            g.TranslateTransform(r.X + (r.Width / 2), r.Y + (r.Height / 2));
            g.RotateTransform(rotacion);
            g.TranslateTransform(-(r.X + (r.Width / 2)), -(r.Y + (r.Height / 2)));
            float[] xs;
            float[] ys;
            if (posrelativa)
            {
                 xs = new float[] { Punto1.X - Owner.difrelativa_x, Punto3.X - Owner.difrelativa_x};
                 ys = new float[] { Punto1.Y - Owner.difrelativa_y, Punto3.Y - Owner.difrelativa_y};      
            }
            else
            {
                xs = new float[] { Punto1.X, Punto3.X };
                ys = new float[] { Punto1.Y, Punto3.Y };
            }
            Font f = new Font(font.FontFamily.Name, font.Size * owner.zoom_factor, font.Style);
            if (!string.IsNullOrEmpty(formula))
            {
                valor = owner.Analizador.EjecutarExpresion(formula);
            }
            g.DrawString(valor, f, new SolidBrush(color), (xs.Min() * owner.zoom_factor) + owner.traslacion_factor[0],
                (ys.Min() * owner.zoom_factor) + owner.traslacion_factor[1]);
            g.ResetTransform();

        }
        public override string ObtenerPiezaDXF(float desplazamiento = 0)
        {
            StringBuilder mdxf = new StringBuilder();
            mdxf.Append("nombre").AppendLine();
            mdxf.Append(Nombre).AppendLine();
            mdxf.Append("x1").AppendLine();
            mdxf.Append((Punto1.X / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y1").AppendLine();
            mdxf.Append((Punto1.Y / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("x2").AppendLine();
            mdxf.Append((Punto2.X / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y2").AppendLine();
            mdxf.Append((Punto2.Y / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("x3").AppendLine();
            mdxf.Append((Punto3.X / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y3").AppendLine();
            mdxf.Append((Punto3.Y / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("x4").AppendLine();
            mdxf.Append((Punto4.X / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y4").AppendLine();
            mdxf.Append((Punto4.Y / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("circular").AppendLine();
            mdxf.Append(Convert.ToInt32(FormaCircular).ToString()).AppendLine();
            mdxf.Append("visible_cliente").AppendLine();
            mdxf.Append(VisibilidadCliente).AppendLine();
            mdxf.Append("valor").AppendLine();
            mdxf.Append(valor).AppendLine();
            mdxf.Append("formula").AppendLine();
            mdxf.Append(formula).AppendLine();
            mdxf.Append("color").AppendLine();
            mdxf.Append(this.Color.Name).AppendLine();
            mdxf.Append("punteado").AppendLine();
            mdxf.Append(punteado ? "1" : "0").AppendLine();
            mdxf.Append("nombre_fuente").AppendLine();
            mdxf.Append(this.font.Name).AppendLine();
            mdxf.Append("tamanio_fuente").AppendLine();
            mdxf.Append(Convert.ToString(this.font.Size/owner.tamanio_lienzo.Width)).AppendLine();
            mdxf.Append("fuente_negrilla").AppendLine();
            mdxf.Append(Convert.ToInt32(font.Bold)).AppendLine();
            mdxf.Append("rotacion").AppendLine();
            mdxf.Append(rotacion.ToString()).AppendLine();
            mdxf.Append("color_fondo").AppendLine();
            mdxf.Append(color_fondo.Name).AppendLine();
            mdxf.Append("fin");
            return mdxf.ToString();
        }
        #endregion
    }
}
