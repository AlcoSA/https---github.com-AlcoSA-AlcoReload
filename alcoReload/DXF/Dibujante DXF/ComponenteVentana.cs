using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System;
using System.Text;

namespace DXF.Dibujante_DXF
{
    #region descripción de la distribución general de los 4 puntos
    
    //P1 __________________________ P4
    //   |                        |
    //   |                        |
    //   |                        |
    //   |                        |
    //   |                        |
    //   |                        |
    //   |                        |
    // P2-------------------------- P3
    
    #endregion
    public class ComponenteVentana
    {
        #region Variables
        private string nombre;
        protected PointF punto1;
        protected PointF punto2;
        protected PointF punto3;
        protected PointF punto4;
        protected Ventana owner;        
        private RectangleF regionexterna;
        private bool formacircular = false;
        private string visibilidadcliente = "1";
        protected Color color = Color.Black;
        protected float grosorlinea = 1;        
        protected Pen lapiz = new Pen(Color.Black, 1);
        protected Formulador.Objeto material = null;
        protected string formula_material = "'NINGUNO(0)'";
        protected bool punteado = false;
        protected float rotacion = 0;
        protected Color color_fondo = Color.Transparent;
        #endregion
        #region Propiedades
        public PointF[] Puntos
        {
            get {
                return new PointF[] { punto1, punto2, punto3, punto4 };
            }
        }
        public virtual RectangleF RegionExterna
        {
            get {
                List<float> x = new List<float>() { punto1.X, punto2.X, punto3.X, punto4.X };
                List<float> y = new List<float>() { punto1.Y, punto2.Y, punto3.Y, punto4.Y };
                PointF inicio = new PointF(x.Min(), y.Min());
                SizeF fin = new SizeF(x.Max() - inicio.X, y.Max() - inicio.Y);
                if (owner != null)
                {
                    regionexterna = new RectangleF((inicio.X * owner.zoom_factor) + owner.traslacion_factor[0], (inicio.Y * owner.zoom_factor) + owner.traslacion_factor[1],
                    fin.Width * owner.zoom_factor, fin.Height * owner.zoom_factor);
                }
                else
                { regionexterna = new RectangleF(inicio, fin); }
                return regionexterna;
            }
            set {
                regionexterna = value;
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public PointF Punto1
        {
            get { return punto1; }
            set { punto1 = value;
            }
        }
        public PointF Punto2
        {
            get { return punto2; }
            set
            {
                punto2 = value;
            }
        }
        public PointF Punto3
        {
            get { return punto3; }
            set
            {
                punto3 = value;              
            }
        }
        public PointF Punto4
        {
            get { return punto4; }
            set { punto4 = value;
            }
        }
        public Ventana Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public bool FormaCircular
        {
            get
            { return formacircular; }
            set
            {
                formacircular = value;
            }
        }
        public string VisibilidadCliente
        {
            get { return visibilidadcliente; }
            set { visibilidadcliente = value; }
        }
        public bool Punteado
        {
            get { return punteado; }
            set { punteado = value;
                if (punteado)
                { lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; }
                else
                { lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; }
            }
        }
        public Color Color
        {
            get { return color; }
            set { color = value;
                lapiz.Color = value;
            }
        }
        public Color Color_Fondo
        {
            get { return color_fondo; }
            set
            {color_fondo = value;}
        }
        public float GrosorLinea
        {
            get { return grosorlinea; }
            set { grosorlinea = value;
                lapiz.Width = value;
            }
        }
        public Formulador.Objeto Material
        {
            get { return material; }
            set { material = value;
            }
        }
        public string Formula_Material
        {
            get { return formula_material; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    formula_material = "'NINGUNO(0)'";
                }
                else
                {
                    formula_material = value;
                    string[] mat;
                    if (value.StartsWith("="))
                    {
                        mat = owner.Analizador.EjecutarExpresion(value.Remove(0, 1)).Split(new char[] { '(', ')' });
                    }
                    else
                    {
                        mat = owner.Analizador.EjecutarExpresion(value).Split(new char[] { '(', ')' });
                    }
                    if (mat.Length < 3)
                    {
                        formula_material = "'NINGUNO(0)'";
                        throw new Exception("Hay Errores en la formula. Verifique la información");
                    }
                    else
                    {
                        material = owner.Analizador.ListaMateriales[mat[0], Convert.ToInt32(mat[1])];
                    }
                }                
            }
        }
        public float Rotacion
        {
            get { return rotacion; }
            set { rotacion = value; }
        }
        #endregion
        #region Constructor
        public ComponenteVentana(PointF puntoinicial, string nombre)
        {            
            this.nombre = nombre;
            punto1 = puntoinicial;
            punto2 = puntoinicial;
            punto3 = puntoinicial;
            punto4 = puntoinicial;           
        }
        public ComponenteVentana(PointF puntoinicial, PointF puntofinal, string nombre, string visibilidad)
        {
            this.nombre = nombre;
            this.punto1 = puntoinicial;
            this.punto2 = new PointF(puntoinicial.X, puntofinal.Y);
            this.punto3 = puntofinal;
            this.punto4 = new PointF(puntofinal.X, puntoinicial.Y);
            this.visibilidadcliente = visibilidad;
        }
        public ComponenteVentana(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool formacircular ,string nombre)
        {
            this.nombre = nombre;
            this.punto1 = punto1;
            this.punto2 = punto2;            
            this.punto3 = punto3;
            this.punto4 = punto4;
            this.formacircular = formacircular;
        }
        public ComponenteVentana(PointF punto1, PointF punto2, PointF punto3, PointF punto4, bool formacircular, string nombre, string visibilidad)
        {
            this.nombre = nombre;
            this.punto1 = punto1;
            this.punto2 = punto2;
            this.punto3 = punto3;
            this.punto4 = punto4;
            this.formacircular = formacircular;
            this.visibilidadcliente = visibilidad;
        }
        #endregion
        #region Sobrescribe
        public virtual void Dibujar(Graphics g, bool posrelativa = true) { }
        public virtual string ObtenerPiezaDXF(float desplazamiento=0)
        {
            StringBuilder mdxf = new StringBuilder();
            mdxf.Append("nombre").AppendLine();
            mdxf.Append(nombre).AppendLine();
            mdxf.Append("x1").AppendLine();
            mdxf.Append(((punto1.X+desplazamiento) / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y1").AppendLine();
            mdxf.Append(((punto1.Y+desplazamiento) / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("x2").AppendLine();
            mdxf.Append(((punto2.X+desplazamiento) / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y2").AppendLine();
            mdxf.Append(((punto2.Y+desplazamiento) / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("x3").AppendLine();
            mdxf.Append(((punto3.X+desplazamiento) / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y3").AppendLine();
            mdxf.Append(((punto3.Y+desplazamiento) / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("x4").AppendLine();
            mdxf.Append(((punto4.X+desplazamiento) / Owner.tamanio_lienzo.Width).ToString()).AppendLine();
            mdxf.Append("y4").AppendLine();
            mdxf.Append(((punto4.Y+desplazamiento) / Owner.tamanio_lienzo.Height).ToString()).AppendLine();
            mdxf.Append("circular").AppendLine();
            mdxf.Append(Convert.ToInt32(formacircular).ToString()).AppendLine();
            mdxf.Append("visible_cliente").AppendLine();
            mdxf.Append(visibilidadcliente).AppendLine();
            mdxf.Append("grosor_linea").AppendLine();
            mdxf.Append(grosorlinea.ToString()).AppendLine();
            mdxf.Append("color").AppendLine();
            mdxf.Append(color.Name).AppendLine();
            mdxf.Append("punteado").AppendLine();
            mdxf.Append(punteado?"1":"0").AppendLine();
            mdxf.Append("material").AppendLine();
            mdxf.Append(formula_material).AppendLine();
            mdxf.Append("rotacion").AppendLine();
            mdxf.Append(rotacion.ToString()).AppendLine();
            mdxf.Append("color_fondo").AppendLine();
            mdxf.Append(color_fondo.Name).AppendLine();
            mdxf.Append("fin");
            return mdxf.ToString();
        }
        public virtual void ReflejarHorizontal()
        {
            PointF p1 = punto1;
            PointF p2 = punto2;
            PointF p3 = punto3;
            PointF p4 = punto4;
            punto1 = new PointF(p4.X, p1.Y);
            punto2 = new PointF(p3.X, p2.Y);
            punto3 = new PointF(p2.X, p3.Y);
            punto4 = new PointF(p1.X, p4.Y);
        }
        public virtual void ReflejarVertical()
        {
            PointF p1 = punto1;
            PointF p2 = punto2;
            PointF p3 = punto3;
            PointF p4 = punto4;
            punto1 = new PointF(p1.X, p2.Y);
            punto2 = new PointF(p2.X, p1.Y);
            punto3 = new PointF(p3.X, p4.Y);
            punto4 = new PointF(p4.X, p3.Y);
        }
        #endregion
        #region Procedimientos
        public void RecalcularPuntos()
        {
            try
            {
                this.punto2 = new PointF(punto1.X, punto3.Y);
                this.punto4 = new PointF(punto3.X, punto1.Y);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
        }
        protected PointF[] MarcoBasico(bool posrelativa = false)
        {
            PointF[] ap = new PointF[] { punto1, punto2, punto3, punto4 };
            if (posrelativa)
            {
                return new PointF[] { new PointF(ap[0].X - owner.difrelativa_x,
                    ap[0].Y - owner.difrelativa_y), new PointF(ap[1].X - owner.difrelativa_x,
                    ap[1].Y - owner.difrelativa_y), new PointF(ap[2].X - owner.difrelativa_x,
                    ap[2].Y - owner.difrelativa_y), new PointF(ap[3].X - owner.difrelativa_x,
                    ap[3].Y - owner.difrelativa_y) };
            }
            else
            {
                return new PointF[] {new PointF(ap[0].X, ap[0].Y), new PointF(ap[1].X, ap[1].Y),
                new PointF(ap[2].X, ap[2].Y), new PointF(ap[3].X, ap[3].Y)};
            }
        }
        #endregion
    }
}
