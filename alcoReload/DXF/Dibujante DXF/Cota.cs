using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System;
using System.Text;
using System.Drawing.Drawing2D;

namespace DXF.Dibujante_DXF
{
    class Cota : ComponenteVentana
    {
        #region Variables        
        private string valor = string.Empty;
        private string formula = string.Empty;
        private Font font;
        #endregion
        #region Constructor
        public Cota(PointF puntoinicial, string nombre, string formula, string valor) : base(puntoinicial, nombre)
        {
            this.valor = valor;
            this.formula = formula;
            VisibilidadCliente = "0";
            font = new Font("arial", 8);
            Comienzo_Final_Lapiz();
            Color = Color.Red;
        }
        public Cota(PointF puntoinicial, PointF puntofinal, string nombre, string valor, string formula, string visibilidad) : base(puntoinicial, puntofinal, nombre, visibilidad)
        {
            this.valor = valor;
            this.formula = formula;
            font = new Font("arial", 8);
            Comienzo_Final_Lapiz();
            Color = Color.Red;
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
                float[] x = new float[] { Punto1.X, Punto3.X };
                List<float> y = new List<float>() { Punto1.Y, Punto3.Y };
                RectangleF rect = new RectangleF();
                rect = new RectangleF(((x.Min() - 5) * Owner.zoom_factor) + Owner.traslacion_factor[0], ((y.Min() - 5) * Owner.zoom_factor) + Owner.traslacion_factor[0],
                    (x.Max() - x.Min() + 10) * Owner.zoom_factor, (y.Max() - y.Min() + 10) * Owner.zoom_factor);
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
        private void Comienzo_Final_Lapiz()
        {
            GraphicsPath start_path = new GraphicsPath();
            start_path.AddLine(new System.Drawing.Point(-5, 0), new System.Drawing.Point(5, 0));
            CustomLineCap c_cap = new CustomLineCap(null, start_path);
            lapiz.EndCap = System.Drawing.Drawing2D.LineCap.Custom;
            lapiz.StartCap = System.Drawing.Drawing2D.LineCap.Custom;
            lapiz.CustomStartCap = c_cap;
            lapiz.CustomEndCap = c_cap;
        }
        public override void Dibujar(Graphics g, bool posrelativa = false)
        {            
            PointF pi = new PointF(((Punto1.X - (posrelativa?Owner.difrelativa_x:0))*owner.zoom_factor) + owner.traslacion_factor[0] ,
                ((Punto1.Y - (posrelativa?Owner.difrelativa_y:0))*owner.zoom_factor)+owner.traslacion_factor[1]);
            PointF pf = new PointF(((Punto3.X - (posrelativa ? Owner.difrelativa_x : 0)) * owner.zoom_factor) + owner.traslacion_factor[0],
                ((Punto3.Y - (posrelativa ? Owner.difrelativa_y : 0)) * owner.zoom_factor) + owner.traslacion_factor[1]);
            g.DrawLine(lapiz, pi, pf);
            if(!string.IsNullOrEmpty(formula))
                valor = owner.Analizador.EjecutarExpresion(formula);
            if (!string.IsNullOrEmpty(valor))
            {
                float[] xs = new float[] {pi.X,pf.X};
                float[] ys = new float[] {pi.Y,pf.Y};
                float nangle = (float)((Math.Atan2(pf.Y - pi.Y, pf.X - pi.X) * 180) / Math.PI);
                float resx = xs.Min() + ((xs.Max() - xs.Min()) / 2);
                float resY = ys.Min() + ((ys.Max() - ys.Min()) / 2);
                g.TranslateTransform(resx, resY);
                g.RotateTransform(nangle);
                g.DrawString(valor, font, new SolidBrush(color), 0,0);
                g.ResetTransform();
            }         
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
            mdxf.Append("grosor_linea").AppendLine();
            mdxf.Append(this.GrosorLinea.ToString()).AppendLine();
            mdxf.Append("color").AppendLine();
            mdxf.Append(this.Color.Name).AppendLine();
            mdxf.Append("punteado").AppendLine();
            mdxf.Append(punteado ? "1" : "0").AppendLine();
            mdxf.Append("nombre_fuente").AppendLine();
            mdxf.Append(this.font.Name).AppendLine();
            mdxf.Append("tamanio_fuente").AppendLine();
            mdxf.Append(Convert.ToString(this.font.Size / owner.tamanio_lienzo.Width)).AppendLine();            
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
