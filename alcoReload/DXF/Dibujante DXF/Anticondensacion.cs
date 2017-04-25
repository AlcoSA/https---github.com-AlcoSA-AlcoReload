using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace DXF.Dibujante_DXF
{
    public class Anticondensacion : ComponenteVentana
    {
        #region Variables
        private string valor = string.Empty;
        private string formula = string.Empty;
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
        #endregion        
        #region Constructor
        public Anticondensacion(PointF puntoinicial, string nombre, string formula, string valor) : base(puntoinicial, nombre)
        {
            this.formula = formula;
            this.valor = valor;
        }
        public Anticondensacion(PointF puntoinicial, PointF puntofinal, string nombre, string visibilidad, string formula, string valor) : base(puntoinicial, puntofinal, nombre, visibilidad)
        {
            this.formula = formula;
            this.valor = valor;
        }
        public Anticondensacion(PointF punto1, PointF punto2, PointF punto3, PointF punto4, string nombre, string formula, string valor) : base(punto1, punto2, punto3, punto4, false, nombre)
        {
            this.formula = formula;
            this.valor = valor;
        }
        public Anticondensacion(PointF punto1, PointF punto2, PointF punto3, PointF punto4, string nombre, string visibilidad, string formula, string valor) : base(punto1, punto2, punto3, punto4, false, nombre, visibilidad)
        {
            this.formula = formula;
            this.valor = valor;
        }
        #endregion
        #region Procedimientos
        public override void Dibujar(Graphics g, bool posrelativa = false)
        {            
            #region Anti-condensaciones            
            Bitmap bmp = new Bitmap(RegionExterna.Width > 10 ? System.Convert.ToInt32(RegionExterna.Width) : 10,
                RegionExterna.Height > 10 ? System.Convert.ToInt32(RegionExterna.Height) : 10);
            Graphics ng = Graphics.FromImage(bmp);
            valor = owner.Analizador.EjecutarExpresion(formula);
            float divs = System.Convert.ToSingle(valor)+1;// + 1.0F;
            ng.Clear(Color.White);
            float tamanio = bmp.Height / divs;            
            for (int i = 1; i < divs; i++)
            {
                ng.DrawLine(lapiz, 0, tamanio * i,
                        bmp.Width, tamanio * i);                
            }            
            TextureBrush npincel = new TextureBrush(bmp);
            npincel.WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
            PointF[] pt = MarcoBasico(posrelativa);
            npincel.TranslateTransform(pt.Min(p => p.X), pt.Min(p => p.Y), System.Drawing.Drawing2D.MatrixOrder.Append);            
            #endregion
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
                            //Color cP = owner.dics.ObtenerColorVidrio(material.Parametros["ACABADO"].Valor);
                            //g.FillEllipse(new SolidBrush(cP), r);
                            break;
                    }
                }
                else
                {
                    g.FillEllipse(new SolidBrush(color_fondo), r);
                }
                g.DrawEllipse(lapiz, r);                         
                g.FillEllipse(npincel, r);
            }
            else
            {                
                PointF[] externos = MarcoBasico(posrelativa).Select(p => new PointF((p.X * owner.zoom_factor) + owner.traslacion_factor[0], (p.Y * owner.zoom_factor) + owner.traslacion_factor[1])).ToArray();
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
                else
                { g.FillPolygon(new SolidBrush(color_fondo), externos); }
                g.FillPolygon(npincel, externos);
                g.DrawPolygon(lapiz, externos);
                
            }
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
            mdxf.Append(System.Convert.ToInt32(FormaCircular).ToString()).AppendLine();
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
            mdxf.Append("material").AppendLine();
            mdxf.Append(formula_material).AppendLine();
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
