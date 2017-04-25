using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Formulador;
using System.Linq;
namespace DXF.Dibujante_DXF
{
   public class Ventana
    {
        #region Variables
        private float grosorperfileria = 5;
        private List<ComponenteVentana> listaComponentes;
        private AnalizadorLexico analizador;
        internal float difrelativa_x = 0;
        internal float difrelativa_y = 0;
        internal SizeF tamanio_lienzo;
        internal float zoom_factor = 1;
        internal float[] traslacion_factor = new float[]{ 0F,0F};
        internal Diccionarios dics;     
        #endregion
        #region Propiedades
        public float GrosorPerfileria
        {
            get { return grosorperfileria; }
            set { grosorperfileria= value; }
        }
        public List<ComponenteVentana> ListaComponentes
        {
            get
            { return listaComponentes; }            
        }
        public AnalizadorLexico Analizador
        {
            get { return analizador; }
            set { analizador = value;
                if (analizador != null)
                {
                    if (analizador.ListaVariables.Contains("NRO_FIJOS_V"))
                    {
                        analizador.ListaVariables["NRO_FIJOS_V"].formula_cambiada += Ventana_formula_cambiada;
                    }
                    if (analizador.ListaVariables.Contains("NRO_FIJOS_H"))
                    {
                        analizador.ListaVariables["NRO_FIJOS_H"].formula_cambiada += Ventana_formula_cambiada;
                    }
                }
            }
        }        
        public float Factor_Zoom
        {
            get { return zoom_factor; }
            set { zoom_factor = value;                
            }
        }
        public float[] Factor_Traslacion
        {
            get { return traslacion_factor; }
            set { traslacion_factor = value; }
        }
        #endregion
        #region Constructor
        public Ventana(AnalizadorLexico analizador, SizeF tamanio_lienzo)
        {
            dics = new Diccionarios();
            listaComponentes = new List<ComponenteVentana>();
            this.tamanio_lienzo = tamanio_lienzo;
            this.analizador = analizador;
            if (analizador != null)
            {
                if (analizador.ListaVariables.Contains("NRO_FIJOS_V"))
                {
                    analizador.ListaVariables["NRO_FIJOS_V"].formula_cambiada += Ventana_formula_cambiada;
                }
                if (analizador.ListaVariables.Contains("NRO_FIJOS_H"))
                {
                    analizador.ListaVariables["NRO_FIJOS_H"].formula_cambiada += Ventana_formula_cambiada;
                }
            }
        }

        private void Ventana_formula_cambiada(object sender, ParametroEventargs e)
        {
            try
            {
                if (e.Parametro.Nombre == "NRO_FIJOS_V")
                {
                    
                }
                else if (e.Parametro.Nombre == "NRO_FIJOS_H")
                {

                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        #endregion
        #region Procedimientos
        public void CambiarTamañoLienzo(SizeF tamaño, bool visibilidad_en_carga)
        {
            string vdxf = obtenerDXFPersonalizado();
            tamanio_lienzo = tamaño;
            listaComponentes.Clear();
            LeerDxfPersonalizado(vdxf, visibilidad_en_carga);
        }
        public void AgregarComponente(ComponenteVentana componente)
        {
            if (!listaComponentes.Contains(componente))
            {
                componente.Owner = this;
                listaComponentes.Add(componente);
                PointF pt = RegionVentana().Location;
                difrelativa_x = pt.X - 2;
                difrelativa_y = pt.Y - 2;
            }            
        }
        public ComponenteVentana contienePunto(float x, float y, bool profundo)
        {
            try
            {
                if (profundo)
                {                    
                    return listaComponentes.LastOrDefault(r => r.RegionExterna.Contains(x, y));
                }
                else
                {
                    return listaComponentes.FirstOrDefault(r => r.RegionExterna.Contains(x, y));
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }            
        }
        public TipoContacto InterseccionColision(PointF punto, ComponenteVentana noevaluar)
        {
            List<TipoContacto> mlist = new List<TipoContacto>();
            for (int i = 0; i < ListaComponentes.Count; i++)
            {
                if (listaComponentes[i] != noevaluar)
                {
                    RectangleF recte = ListaComponentes[i].RegionExterna;
                    List<PointF> lpuntos = new List<PointF>();
                    lpuntos.Add(new PointF(recte.X, recte.Y));
                    lpuntos.Add(new PointF(recte.X, recte.Y + recte.Height));
                    lpuntos.Add(new PointF(recte.X  + recte.Width, recte.Y + recte.Height));
                    lpuntos.Add(new PointF(recte.X + recte.Width, recte.Y));

                    if (lpuntos.Contains(punto))
                    {
                        return TipoContacto.INTERCEPTO;
                    }
                    else if (recte.X == punto.X || recte.X + recte.Width == punto.X)
                    {
                        return TipoContacto.HORIZONTAL;
                    }
                    else if (recte.Y == punto.Y || recte.Y + recte.Height == punto.Y)
                    {
                        return TipoContacto.VERTICAL;
                    }
                }
            }
            return TipoContacto.NINGUNO;
        }
        public string obtenerDXFPersonalizado(float desplazamiento =0)
        {
            try
            {
                StringBuilder mdxf = new StringBuilder();
                foreach (ComponenteVentana cv in listaComponentes)
                {
                    mdxf.Append(cv.ObtenerPiezaDXF(desplazamiento)).AppendLine();
                }
                return mdxf.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void LeerDxfPersonalizado(string dxf, bool ignorarvisibilidad = true)
        {
            try
            {            
                if(string.IsNullOrEmpty(dxf))
                {
                    throw new Exception("No hay dibujos asignados para este elemento.");
                }
                else
                {
                    string[] ldxf = dxf.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    string nombre = string.Empty;
                    string valor = string.Empty;
                    string formula = string.Empty;
                    bool circular = false;
                    string visible_cliente = "1";
                    float grosor_linea = 1;
                    Color color = Color.Black;
                    Color color_fondo = Color.Transparent;
                    string nombre_fuente = "arial";
                    float tamanio_fuente = 8F;
                    bool fuente_negrilla = false;
                    bool punteado = false;
                    float rotacion = 0;
                    string material = "'NINGUNO(0)'";
                    PointF pt1 = new PointF();
                    PointF pt2 = new PointF();
                    PointF pt3 = new PointF();
                    PointF pt4 = new PointF();
                    for (int i = 0; i <= ldxf.Length - 1; i++)
                    {
                        switch (ldxf[i])
                        {
                            case "nombre":
                                {
                                    nombre = ldxf[i + 1]; i++;
                                    break;
                                }
                            case "x1":
                                {
                                    pt1.X = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Width; i++;
                                    break;
                                }
                            case "y1":
                                {
                                    pt1.Y = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Height; i++;
                                    break;
                                }
                            case "x2":
                                {
                                    pt2.X = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Width; i++;
                                    break;
                                }
                            case "y2":
                                {
                                    pt2.Y = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Height; i++;
                                    break;
                                }
                            case "x3":
                                {
                                    pt3.X = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Width; i++;
                                    break;
                                }
                            case "y3":
                                {
                                    pt3.Y = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Height; i++;
                                    break;
                                }
                            case "x4":
                                {
                                    pt4.X = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Width; i++;
                                    break;
                                }
                            case "y4":
                                {
                                    pt4.Y = float.Parse(ldxf[i + 1]) * tamanio_lienzo.Height; i++;
                                    break;
                                }
                            case "circular":
                                {
                                    circular = Convert.ToBoolean(Convert.ToInt32(ldxf[i + 1])); i++;
                                    break;
                                }
                            case "valor":
                                {
                                    valor = ldxf[i + 1]; i++;
                                    break;
                                }
                            case "formula":
                                {
                                    formula = ldxf[i + 1]; i++;
                                    break;
                                }
                            case "visible_cliente":
                                {                                    
                                    visible_cliente = ldxf[i + 1]; i++;
                                    break;
                                }
                            case "grosor_linea":
                                {
                                    grosor_linea = Convert.ToSingle(ldxf[i + 1]); i++;
                                    break;
                                }
                            case "color":
                                {
                                    color = Color.FromName(ldxf[i + 1]); i++;
                                    break;
                                }
                            case "punteado":
                                {
                                    punteado = Convert.ToBoolean(Convert.ToInt32(ldxf[i + 1])); i++;
                                    break;
                                }
                            case "nombre_fuente":
                                {
                                    nombre_fuente = ldxf[i + 1]; i++;
                                    break;
                                }
                            case "tamanio_fuente":
                                {                                    
                                    tamanio_fuente = Convert.ToSingle(Math.Round(Convert.ToSingle(ldxf[i + 1]) * tamanio_lienzo.Width, 1)); i++;                                    
                                    break;
                                }
                            case "fuente_negrilla":
                                {
                                    fuente_negrilla = Convert.ToBoolean(Convert.ToInt32(ldxf[i + 1])); i++;
                                    break;
                                }
                            case "material":
                                {
                                    material = ldxf[i + 1]; i++;
                                    break;
                                }
                            case "rotacion":
                                {
                                    rotacion = Convert.ToSingle(ldxf[i + 1]); i++;
                                    break;
                                }
                            case "color_fondo":
                                {
                                    color_fondo = Color.FromName(ldxf[i + 1]); i++;
                                    break;
                                }

                            case "fin":
                                {
                                    switch (nombre)
                                    {
                                        #region Marco
                                        case "Marco":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if (vis)
                                                {
                                                    Marco m = new Marco(pt1, pt2, pt3, pt4, circular, nombre, visible_cliente);
                                                    m.GrosorLinea = grosor_linea;
                                                    m.Color = color;
                                                    m.Punteado = punteado;
                                                    m.Color_Fondo = color_fondo;
                                                    m.Rotacion = rotacion;
                                                    AgregarComponente(m);
                                                    m.Formula_Material = material;
                                                }
                                                break;
                                            }
                                        #endregion
                                        #region Rejilla
                                        case "Rejilla":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if (vis)
                                                {
                                                    Rejilla rej = new Rejilla(pt1, pt2, pt3, pt4, circular, nombre, visible_cliente);
                                                    rej.GrosorLinea = grosor_linea;
                                                    rej.Color = color;
                                                    rej.Punteado = punteado;
                                                    rej.Color_Fondo = color_fondo;
                                                    rej.Rotacion = rotacion;
                                                    AgregarComponente(rej);
                                                    rej.Formula_Material = material;
                                                }
                                                break;
                                            }
                                        #endregion                                        
                                        #region Angeo
                                        case "Angeo":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if (vis)
                                                {
                                                    Angeo ang = new Angeo(pt1, pt2, pt3, pt4, circular, nombre, visible_cliente);
                                                    ang.GrosorLinea = grosor_linea;
                                                    ang.Color = color;
                                                    ang.Punteado = punteado;
                                                    ang.Color_Fondo = color_fondo;
                                                    ang.Rotacion = rotacion;
                                                    AgregarComponente(ang);
                                                    ang.Formula_Material = material;
                                                }
                                                break;
                                            }
                                        #endregion
                                        #region Cotas
                                        case "Cota":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }                                                
                                                if(vis)
                                                {
                                                    if (string.IsNullOrEmpty(formula))
                                                    {
                                                        Cota cot = new Cota(pt1, pt3, nombre, valor, formula, visible_cliente);
                                                        cot.GrosorLinea = grosor_linea;
                                                        cot.Color = color;

                                                        cot.Rotacion = rotacion;
                                                        AgregarComponente(cot);
                                                    }
                                                    else
                                                    {
                                                        if (analizador == null)
                                                        {
                                                            throw new Exception("No hay un analizador sintáctico seleccionado.");
                                                        }
                                                        else
                                                        {
                                                            Cota cot = new Cota(pt1, pt3, nombre, analizador.EjecutarExpresion(formula), formula, visible_cliente);
                                                            cot.GrosorLinea = grosor_linea;
                                                            cot.Color = color;
                                                            cot.Font = new Font(nombre_fuente, tamanio_fuente, fuente_negrilla ? FontStyle.Bold : FontStyle.Regular);
                                                            cot.Punteado = punteado;
                                                            cot.Color_Fondo = color_fondo;                                                                                                                        
                                                            cot.Rotacion = rotacion;
                                                            AgregarComponente(cot);
                                                        }
                                                    }
                                                }                                                    
                                                
                                                break;
                                            }
                                        #endregion
                                        #region Ele
                                        case "Ele":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if (vis)
                                                {
                                                    Ele el = new Ele(pt1, pt2, pt3, pt4, circular, nombre, visible_cliente);
                                                    el.GrosorLinea = grosor_linea;
                                                    el.Color = color;
                                                    el.Punteado = punteado;
                                                    el.Color_Fondo = color_fondo;
                                                    el.Rotacion = rotacion;
                                                    AgregarComponente(el);
                                                    el.Formula_Material = material;
                                                }
                                                break;
                                            }
                                        #endregion
                                        #region Arco
                                        case "Arco":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if (vis)
                                                {
                                                    Arco arc = new Arco(pt1, pt2, pt3, pt4, circular, nombre, visible_cliente);
                                                    arc.GrosorLinea = grosor_linea;
                                                    arc.Color = color;
                                                    arc.Punteado = punteado;
                                                    arc.Color_Fondo = color_fondo;
                                                    arc.Rotacion = rotacion;
                                                    AgregarComponente(arc);
                                                    arc.Formula_Material = material;
                                                }
                                                break;
                                            }
                                        #endregion
                                        #region Texto
                                        case "Texto":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if(vis)
                                                {
                                                    if (string.IsNullOrEmpty(formula))
                                                    {
                                                        Texto text = new Texto(pt1, pt3, nombre, valor, formula, visible_cliente);
                                                        text.Color = color;
                                                        text.GrosorLinea = grosor_linea;
                                                        text.Color = color;
                                                        text.Font = new Font(nombre_fuente, tamanio_fuente, fuente_negrilla ? FontStyle.Bold : FontStyle.Regular);
                                                        text.Punteado = punteado;
                                                        text.Color_Fondo = color_fondo;
                                                        text.Rotacion = rotacion;
                                                        AgregarComponente(text);
                                                    }
                                                    else
                                                    {
                                                        if (analizador == null)
                                                        {
                                                            throw new Exception("No hay un analizador sintáctico seleccionado.");
                                                        }
                                                        else
                                                        {
                                                            Texto text = new Texto(pt1, pt3, nombre, analizador.EjecutarExpresion(formula), formula, visible_cliente);
                                                            text.Color = color;
                                                            text.GrosorLinea = grosor_linea;
                                                            text.Color = color;
                                                            text.Font = new Font(nombre_fuente, tamanio_fuente, fuente_negrilla ? FontStyle.Bold : FontStyle.Regular);
                                                            text.Punteado = punteado;
                                                            text.Color_Fondo = color_fondo;
                                                            text.Rotacion = rotacion;
                                                            AgregarComponente(text);
                                                        }
                                                    }
                                                                                                        
                                                }
                                                break;
                                            }
                                        #endregion
                                        #region Flecha
                                        case "Flecha":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if(vis)
                                                {
                                                    Flecha fle = new Flecha(pt1, pt3, nombre, visible_cliente);
                                                    fle.GrosorLinea = grosor_linea;
                                                    fle.Color = color;
                                                    fle.Punteado = punteado;
                                                    fle.Color_Fondo = color_fondo;
                                                    fle.Rotacion = rotacion;
                                                    AgregarComponente(fle);
                                                }                                               
                                                break;

                                            }
                                        #endregion
                                        #region Linea
                                        case "Linea":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if (vis)
                                                {
                                                    Linea lin = new Linea(pt1, pt3, nombre, visible_cliente);
                                                    lin.GrosorLinea = grosor_linea;
                                                    lin.Color = color;
                                                    lin.Punteado = punteado;
                                                    lin.Color_Fondo = color_fondo;
                                                    lin.Rotacion = rotacion;
                                                    AgregarComponente(lin);
                                                }                                                
                                                break;
                                            }
                                        #endregion
                                        #region Anticondensacion
                                        case "Anticondensacion":
                                            {
                                                bool vis = true;
                                                if (!ignorarvisibilidad)
                                                {
                                                    if (visible_cliente.StartsWith("="))
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(analizador.EjecutarExpresion(visible_cliente.Remove(0, 1))));
                                                    }
                                                    else
                                                    {
                                                        vis = Convert.ToBoolean(Convert.ToInt32(visible_cliente));
                                                    }
                                                }
                                                if (vis)
                                                {

                                                    if (string.IsNullOrEmpty(formula))
                                                    {

                                                        Anticondensacion m = new Anticondensacion(pt1, pt2, pt3, pt4, nombre, visible_cliente, formula, valor);
                                                        m.GrosorLinea = grosor_linea;
                                                        m.Color = color;
                                                        m.Punteado = punteado;
                                                        m.Color_Fondo = color_fondo;
                                                        m.Rotacion = rotacion;
                                                        AgregarComponente(m);
                                                        m.Formula_Material = material;
                                                    }
                                                    else
                                                    {
                                                        if (analizador == null)
                                                        {
                                                            throw new Exception("No hay un analizador sintáctico seleccionado.");
                                                        }
                                                        else
                                                        {                                                            
                                                            Anticondensacion m = new Anticondensacion(pt1, pt2, pt3, pt4, nombre, visible_cliente, formula, analizador.EjecutarExpresion(formula));
                                                            m.GrosorLinea = grosor_linea;
                                                            m.Color = color;
                                                            m.Punteado = punteado;
                                                            m.Color_Fondo = color_fondo;
                                                            m.Rotacion = rotacion;
                                                            AgregarComponente(m);
                                                            m.Formula_Material = material;
                                                        }
                                                    }                                                    
                                                }
                                                break;
                                            }
                                            #endregion
                                    }
                                    break;
                                }
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public RectangleF RegionVentana()
        {
            try
            {
                RectangleF r;
                List<float> px= new List<float>();
                List<float> py = new List<float>();
                for (int i = 0; i < ListaComponentes.Count; i++)
                {
                    px.Add(listaComponentes[i].Punto1.X);
                    px.Add(listaComponentes[i].Punto2.X);
                    px.Add(listaComponentes[i].Punto3.X);
                    px.Add(listaComponentes[i].Punto4.X);
                    py.Add(listaComponentes[i].Punto1.Y);
                    py.Add(listaComponentes[i].Punto2.Y);
                    py.Add(listaComponentes[i].Punto3.Y);
                    py.Add(listaComponentes[i].Punto4.Y);
                }
                r = new RectangleF(px.Min(), py.Min(), px.Max() - px.Min(),
                    py.Max() - py.Min());
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public Bitmap ObtenerImagen()
        {
            RectangleF rc = RegionVentana();            
            difrelativa_x = rc.X;
            difrelativa_y = rc.Y;

            Bitmap bp = new Bitmap(Convert.ToInt32(tamanio_lienzo.Width),
            Convert.ToInt32(tamanio_lienzo.Height));
            Graphics G = Graphics.FromImage(bp);
            for (int i = 0; i < ListaComponentes.Count; i++)
            {
                listaComponentes[i].Dibujar(G, true);
            }         
            
            int ancho = bp.Width;
            int alto = bp.Height;
            for (int i = bp.Width-1; i > 0; i--)
            {
                if (bp.GetPixel(i, 0).Name != "0")
                { ancho = i; break; }
            }
            for (int i = bp.Height - 1; i > 0; i--)
            {
                if (bp.GetPixel(0, i).Name != "0")
                { alto = i; break; }
            }
            return bp.Clone(new Rectangle(0, 0, ancho, alto),
                            System.Drawing.Imaging.PixelFormat.DontCare);
        }
        public bool ContieneAnticondensaciones()
        {
            return listaComponentes.Where(c => c.GetType() == typeof(Anticondensacion)).Count() > 0;
        }
        public void Marcar_Puntos_Componentes(Graphics g)
        {
            try
            {
                for (int i = 0; i < listaComponentes.Count; i++)
                {
                    RectangleF r1 = new RectangleF((listaComponentes[i].Punto1.X * zoom_factor) + traslacion_factor[0] - 5,
                        (listaComponentes[i].Punto1.Y*zoom_factor) + traslacion_factor[1] - 5, 10, 10);
                    RectangleF r2 = new RectangleF((listaComponentes[i].Punto2.X * zoom_factor) + traslacion_factor[0] - 5,
                        (listaComponentes[i].Punto2.Y * zoom_factor) + traslacion_factor[1] - 5, 10, 10);
                    RectangleF r3 = new RectangleF((listaComponentes[i].Punto3.X * zoom_factor) + traslacion_factor[0] - 5,
                        (listaComponentes[i].Punto3.Y * zoom_factor) + traslacion_factor[1] - 5, 10, 10);
                    RectangleF r4 = new RectangleF((listaComponentes[i].Punto4.X * zoom_factor) + traslacion_factor[0] - 5,
                        (listaComponentes[i].Punto4.Y * zoom_factor) + traslacion_factor[1] - 5, 10, 10);
                    g.FillRectangle(Brushes.Gold, r1);
                    g.DrawRectangle(Pens.Gray, r1.X, r1.Y, r1.Width, r1.Height);
                    g.FillRectangle(Brushes.Gold, r2);
                    g.DrawRectangle(Pens.Gray, r2.X, r2.Y, r2.Width, r2.Height);
                    g.FillRectangle(Brushes.Gold, r3);
                    g.DrawRectangle(Pens.Gray, r3.X, r3.Y, r3.Width, r3.Height);
                    g.FillRectangle(Brushes.Gold, r4);
                    g.DrawRectangle(Pens.Gray, r4.X, r4.Y, r4.Width, r4.Height);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex.InnerException);
            }
        }
        public void Obtener_Punto_y_Componente(PointF punto_busqueda ,out PointF punto, out ComponenteVentana componente)
        {
            punto = PointF.Empty;
            componente = null;
            #region Búsqueda
            for (int i = 0; i < listaComponentes.Count; i++)
            {
                RectangleF r1 = new RectangleF((listaComponentes[i].Punto1.X * zoom_factor) + traslacion_factor[0] - 5,
                        (listaComponentes[i].Punto1.Y * zoom_factor) + traslacion_factor[1] - 5, 10, 10);
                RectangleF r2 = new RectangleF((listaComponentes[i].Punto2.X * zoom_factor) + traslacion_factor[0] - 5,
                    (listaComponentes[i].Punto2.Y * zoom_factor) + traslacion_factor[1] - 5, 10, 10);
                RectangleF r3 = new RectangleF((listaComponentes[i].Punto3.X * zoom_factor) + traslacion_factor[0] - 5,
                    (listaComponentes[i].Punto3.Y * zoom_factor) + traslacion_factor[1] - 5, 10, 10);
                RectangleF r4 = new RectangleF((listaComponentes[i].Punto4.X * zoom_factor) + traslacion_factor[0] - 5,
                    (listaComponentes[i].Punto4.Y * zoom_factor) + traslacion_factor[1] - 5, 10, 10);

                if (r1.Contains(punto_busqueda))
                {
                    punto = listaComponentes[i].Punto1;
                    componente = listaComponentes[i];
                }
                if (r2.Contains(punto_busqueda))
                {
                    punto = listaComponentes[i].Punto2;
                    componente = listaComponentes[i];
                }
                if (r3.Contains(punto_busqueda))
                {
                    punto = listaComponentes[i].Punto3;
                    componente = listaComponentes[i];
                }
                if (r4.Contains(punto_busqueda))
                {
                    punto = listaComponentes[i].Punto4;
                    componente = listaComponentes[i];
                }

            }
            #endregion
        }
        public void Marcar_Centrales_Componentes(Graphics g)
        {
            try
            {                
                for (int i = 0; i < listaComponentes.Count; i++)
                {
                    RectangleF r = listaComponentes[i].RegionExterna;                    
                    RectangleF r1 = new RectangleF(r.X + (r.Width / 2) - 5, r.Y  - 5, 10, 10);
                    RectangleF r2 = new RectangleF(r.X + r.Width - 5, r.Y + (r.Height/2) - 5, 10, 10);
                    RectangleF r3 = new RectangleF(r.X + (r.Width / 2) - 5, r.Y + r.Height - 5, 10, 10);
                    RectangleF r4 = new RectangleF(r.X - 5, r.Y + (r.Height / 2) - 5, 10, 10);
                    g.FillRectangle(Brushes.Gold, r1);
                    g.DrawRectangle(Pens.Gray, r1.X, r1.Y, r1.Width, r1.Height);
                    g.FillRectangle(Brushes.Gold, r2);
                    g.DrawRectangle(Pens.Gray, r2.X, r2.Y, r2.Width, r2.Height);
                    g.FillRectangle(Brushes.Gold, r3);
                    g.DrawRectangle(Pens.Gray, r3.X, r3.Y, r3.Width, r3.Height);
                    g.FillRectangle(Brushes.Gold, r4);
                    g.DrawRectangle(Pens.Gray, r4.X, r4.Y, r4.Width, r4.Height);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void Obtener_Componente_Centrales(PointF punto_busqueda, out PointF punto_resultado, out ComponenteVentana componente, out Tipo_Redimension tipo_redimension)
        {
            componente = null;
            tipo_redimension = Tipo_Redimension.ANCHO;
            punto_resultado = PointF.Empty;
            #region Búsqueda
            for (int i = 0; i < listaComponentes.Count; i++)
            {
                RectangleF r = listaComponentes[i].RegionExterna;
                RectangleF r1 = new RectangleF(r.X + (r.Width / 2) - 5, r.Y - 5, 10, 10);
                RectangleF r2 = new RectangleF(r.X + r.Width - 5, r.Y + (r.Height / 2) - 5, 10, 10);
                RectangleF r3 = new RectangleF(r.X + (r.Width / 2) - 5, r.Y + r.Height - 5, 10, 10);
                RectangleF r4 = new RectangleF(r.X - 5, r.Y + (r.Height / 2) - 5, 10, 10);

                if (r1.Contains(punto_busqueda))
                {
                    componente = listaComponentes[i];
                    tipo_redimension = Tipo_Redimension.Y;
                    PointF[] puntos = new PointF[] {listaComponentes[i].Punto1, listaComponentes[i].Punto2, listaComponentes[i].Punto3, listaComponentes[i].Punto4 };                    
                    punto_resultado = new PointF(0, puntos.Min(p => p.Y));
                }
                if (r2.Contains(punto_busqueda))
                {
                    componente = listaComponentes[i];
                    tipo_redimension = Tipo_Redimension.ANCHO;
                    PointF[] puntos = new PointF[] { listaComponentes[i].Punto1, listaComponentes[i].Punto2, listaComponentes[i].Punto3, listaComponentes[i].Punto4 };                    
                    punto_resultado = new PointF(puntos.Max(p=>p.X), 0);                    
                }
                if (r3.Contains(punto_busqueda))
                {
                    componente = listaComponentes[i];
                    tipo_redimension = Tipo_Redimension.ALTO;
                    PointF[] puntos = new PointF[] { listaComponentes[i].Punto1, listaComponentes[i].Punto2, listaComponentes[i].Punto3, listaComponentes[i].Punto4 };
                    punto_resultado = new PointF(0, puntos.Max(p => p.Y));
                }
                if (r4.Contains(punto_busqueda))
                {
                    componente = listaComponentes[i];
                    tipo_redimension = Tipo_Redimension.X;
                    PointF[] puntos = new PointF[] { listaComponentes[i].Punto1, listaComponentes[i].Punto2, listaComponentes[i].Punto3, listaComponentes[i].Punto4 };
                    punto_resultado = new PointF(puntos.Min(p => p.X), 0);
                }

            }
            #endregion
        }

        #endregion
    }
}
