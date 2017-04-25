using System;
using System.Drawing;
using System.Windows.Forms;
using DXF.Dibujante_DXF;
using DXF.Dibujante_DXF.Especiales;
using Formulador;
using System.Collections.Generic;
using System.Linq;

namespace DXF
{
    public partial class DibujanteDXF : UserControl
    {
        #region Variables
        private AnalizadorLexico analizador;
        private string last_dxf = string.Empty;
        private TipoFigura tipofigura = TipoFigura.NINGUNA;
        private int cantidadpresion = 0;
        private ComponenteVentana componenteactual;
        private Ventana ventana;
        private MargenRedimension margenelementoActual;
        private Click_Redimension redimension_seleccionada;
        private Tipo_Traslacion tipo_traslacion = Tipo_Traslacion.ARRIBA_IZQUIERDA;
        private Tipo_Redimension tipo_redimension = Tipo_Redimension.ANCHO;
        private Point puntobase = new Point(0, 0);
        private bool mousepressed = false;
        private bool sololectura = false;
        private bool ignorarfactorvisibilidad= true;
        private List<ComponenteVentana> seleccionados;
        Stack<string> undoList = new Stack<string>();
        private RectangleF rec_seleccion;
        #endregion
        #region Constructor
        public DibujanteDXF()
        {
            InitializeComponent();
            seleccionados = new List<ComponenteVentana>();            
        }
        #endregion
        #region Propiedades
        public AnalizadorLexico Analizador
        {
            get { return analizador; }
            set{ analizador = value;
                if (ventana == null)
                { ventana = new Ventana(analizador, pbdxf.Size); }
                else
                { ventana.Analizador = analizador; }               
            }
        }
        public Ventana Ventana
        {
            get { return ventana; }
            set { ventana = value; }
        }
        public bool SoloLectura
        {
            get { return sololectura; }
            set { sololectura = value;
                tsherramientasdxf.Visible = !sololectura;
                tbzoom.Visible = !sololectura;
            }
        }
        public bool IgnorarFactorVisibilidad
        {
            get { return ignorarfactorvisibilidad; }
            set { ignorarfactorvisibilidad = value; }
        }
        #endregion
        #region Procedimientos
        public  string ObtenerDxf()
        {
            return ventana.obtenerDXFPersonalizado();
        }
        public void LeerDxf(string dxf)
        {
            ventana.LeerDxfPersonalizado(dxf, ignorarfactorvisibilidad);            
        }
         public void DefinirMenuStrip()
        {
            try
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                if (ventana != null)
                {
                    if (ventana.ListaComponentes.Count > 0)
                    {
                        menu.Items.Add("Copiar", null, Copiar_Click);
                    }
                }
                if (Clipboard.ContainsText())
                {
                    string ndxf = Convert.ToString(Clipboard.GetData("Text"));
                    if ((ndxf.Contains("x1") || ndxf.Contains("y1") || ndxf.Contains("x3") || ndxf.Contains("y3")))
                    {
                        menu.Items.Add("Pegar", null, Pegar_Click);
                    }
                }
                if (ventana.ListaComponentes.Count > 0)
                {
                    menu.Items.Add("Reflejar Horizontal", null, girarHorizontalmenteToolStripMenuItem_Click);
                    menu.Items.Add("Reflejar Vertical", null, girarVerticalmenteToolStripMenuItem_Click);
                }
                
                if (componenteactual != null)
                {
                    if (seleccionados.Count > 1)
                    {
                        menu.Items.Add("Igualar Anchos", null, Igualar_Anchos_Click);
                        menu.Items.Add("Igualar Altos", null, Igualar_Altos_Click);
                        menu.Items.Add("Alinear Arriba", null, Alinear_Arriba_Click);
                        menu.Items.Add("Alinear Izquierda", null, Alinear_Izquierda_Click);
                        menu.Items.Add("Alinear Abajo", null, Alinear_Abajo_Click);
                        menu.Items.Add("Alinear Derecha", null, Alinear_Derecha_Click);                        
                    }
                    if (componenteactual.GetType() != typeof(Texto) && componenteactual.GetType() != typeof(Linea) &&
                        componenteactual.GetType() != typeof(Cota) && componenteactual.GetType() != typeof(Flecha) && seleccionados.Count == 1)
                    {
                        menu.Items.Add("Definir Material", null, SeleccionMaterial_Click);
                    }                        
                    menu.Items.Add("Eliminar", null, tsmeliminar_Click);
                    menu.Items.Add("Visibilidad", null, tsmvisibilidad_Click);                    
                    menu.Items.Add("Color", null, tsmcolor_Click);
                    if (seleccionados.Where(c => c.GetType() == typeof(Cota) || c.GetType() == typeof(Linea) || c.GetType() == typeof(Flecha)).Count() == 0)
                    {
                        menu.Items.Add("Rotación", null, Rotacion_Click);
                        menu.Items.Add("Color Fondo", null, tsmcolorFondo_Click);
                    }                    
                    if (componenteactual.Punteado)
                    { menu.Items.Add("Linea Solida", null, Solido_Click); }
                    else
                    { menu.Items.Add("Linea Punteada", null, Punteado_Click); }

                    if (!(seleccionados.Count(c => c.GetType() != typeof(Cota) && c.GetType() != typeof(Texto)) > 0))
                    {
                        menu.Items.Add("Modificar Valor", null, tsmeditarValor_Click);
                        menu.Items.Add("Fuente", null, tsmfuente_Click);
                    }
                    if (seleccionados.Where(x => x.GetType() == typeof(Texto)).Count() == 0)
                    {
                        menu.Items.Add("Grosor Lineas", null, tsmgrosor_Click);
                    }                                        
                    if (componenteactual.GetType() != typeof(Texto) && componenteactual.GetType() != typeof(Linea) &&
                        componenteactual.GetType() != typeof(Cota) && componenteactual.GetType() != typeof(Flecha) &&
                        componenteactual.GetType() != typeof(Ele) && componenteactual.GetType() != typeof(Arco))
                    {
                        if (componenteactual.FormaCircular)
                        {
                            menu.Items.Add("Forma Predeterminada", null, tsmpredeterminada_Click);
                        }
                        else
                        {
                            menu.Items.Add("Forma Circular", null, tsmcircular_Click);
                        }
                    }
                }
                menu.Show(MousePosition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void DefinirActualSegunTipo(float x, float y)
        {
            try
            {
                switch (tipofigura)
                {
                    case TipoFigura.NINGUNA:
                        break;
                    case TipoFigura.MARCO:
                        componenteactual = new Marco(new PointF(x, y), "Marco");
                        break;
                    case TipoFigura.REJILLA:
                        componenteactual = new Rejilla(new PointF(x, y), "Rejilla");
                        break;
                    case TipoFigura.ANGEO:
                        componenteactual = new Angeo(new PointF(x, y), "Angeo");
                        break;
                    case TipoFigura.ELE:
                        componenteactual = new Ele(new PointF(x, y), "Ele");
                        break;
                    case TipoFigura.ARCO:
                        componenteactual = new Arco(new PointF(x, y), "Arco");
                        break;
                    case TipoFigura.LINEA:
                        componenteactual = new Linea(new PointF(x, y), "Linea");
                        break;
                    case TipoFigura.ANTICONDENSACION:
                        componenteactual = new Anticondensacion(new PointF(x, y), "Anticondensacion", "NRO_ANTICON", analizador.EjecutarExpresion("NRO_ANTICON"));
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void ControlZ()
        {
            #region Control Z
            string s = ventana.obtenerDXFPersonalizado();
            if (undoList.Count <= 0)
            {
                undoList.Push(s);
            }
            else
            {
                if (!s.Equals(undoList.Peek()))
                {
                    undoList.Push(s);
                }
            }
            #endregion
        }
        private void Aplicar_ControlZ()
        {
            ventana.ListaComponentes.Clear();
            margenelementoActual = null;
            tipofigura = TipoFigura.NINGUNA;
            tipo_traslacion = Tipo_Traslacion.ARRIBA_IZQUIERDA;
            if (undoList.Count > 0)
            {
                if (undoList.Count > 1)
                { undoList.Pop();}                
                string s = undoList.Pop();
                if (!string.IsNullOrEmpty(s))
                {
                    ventana.LeerDxfPersonalizado(s, ignorarfactorvisibilidad);
                }
            }
            pbdxf.Refresh();
        }
        #endregion
        #region Selección Figura
        private void btndevolveraccion_Click(object sender, EventArgs e)
        {
            try
            {
                Aplicar_ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnmarco_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.MARCO;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnrejilla_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.REJILLA;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnacotar_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.COTA;
            }
            catch (Exception ex)
            {

                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnangeo_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.ANGEO;
            }
            catch (Exception ex)
            {

                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnninguno_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.NINGUNA;
            }
            catch (Exception ex)
            {

                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }        
        private void btnele_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.ELE;
            }
            catch (Exception ex)
            {

                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnarco_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.ARCO;
            }
            catch (Exception ex)
            {

                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btntexto_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.TEXTO;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnflecha_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.FLECHA;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnlinea_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = Cursors.Cross;
                tipofigura = TipoFigura.LINEA;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btntrasladar_Click(object sender, EventArgs e)
        {
            try
            {
                pbdxf.Cursor = new Cursor(Properties.Resources.Mano_abierta24.GetHicon());
                tipofigura = TipoFigura.TRASLADAR;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnanticondensacion_Click(object sender, EventArgs e)
        {
            try
            {
                if(analizador.ListaVariables.Contains("NRO_ANTICON"))
                {
                    pbdxf.Cursor = Cursors.Cross;
                    tipofigura = TipoFigura.ANTICONDENSACION;
                }
                else
                {
                    MessageBox.Show("La variable [NRO_ANTICON], debe estar seleccionada");
                }
                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        #endregion        
        #region Opciones Context_Menu_Strip
        private void tsmeliminar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < seleccionados.Count; i++)
                {
                    ventana.ListaComponentes.Remove(seleccionados[i]);
                }
                seleccionados.Clear();
                componenteactual = null;
                margenelementoActual = null;
                redimension_seleccionada = Click_Redimension.NINGUNA;
                pbdxf.Refresh();
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmcircular_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < seleccionados.Count; i++)
                {
                    seleccionados[i].FormaCircular = true;
                }
                pbdxf.Refresh();
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmpredeterminada_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < seleccionados.Count; i++)
                {
                    seleccionados[i].FormaCircular = false;
                }
                pbdxf.Refresh();
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmeditarValor_Click(object sender, EventArgs e)
        {
            try
            {
                Formulador.Formularios_Ayuda.FrmFormuladorMin fcotas = new Formulador.Formularios_Ayuda.FrmFormuladorMin();
                fcotas.Formula = componenteactual.GetType() == typeof(Cota) ? ((Cota)componenteactual).Formula : ((Texto)componenteactual).Formula;
                fcotas.Analizador = this.analizador;
                if (fcotas.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        if (seleccionados[i].GetType() == typeof(Cota))
                        {
                            ((Cota)seleccionados[i]).Formula = fcotas.Formula;
                            ((Cota)seleccionados[i]).Valor = fcotas.Valor;
                        }
                        else if (componenteactual.GetType() == typeof(Texto))
                        {
                            ((Texto)seleccionados[i]).Formula = fcotas.Formula;
                            ((Texto)seleccionados[i]).Valor = fcotas.Valor;
                        }
                    }                                        
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventana != null)
                {
                    if (seleccionados.Count > 0)
                    {
                        System.Text.StringBuilder s = new System.Text.StringBuilder();
                        for (int i = 0; i < seleccionados.Count; i++)
                        {
                            s.AppendLine(seleccionados[i].ObtenerPiezaDXF(10));
                        }
                        Clipboard.SetText(s.ToString());
                    }
                    else
                    {
                        if (ventana.ListaComponentes.Count > 0)
                        {
                            Clipboard.SetText(ventana.obtenerDXFPersonalizado(), TextDataFormat.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Pegar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    string ndxf = Convert.ToString(Clipboard.GetData("Text"));
                    if (ndxf.Contains("x1") || ndxf.Contains("y1") || ndxf.Contains("x3") || ndxf.Contains("y3"))
                    {
                        ventana.LeerDxfPersonalizado(Convert.ToString(Clipboard.GetData("Text")));
                    }                    
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmvisibilidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventana != null)
                {
                    if (componenteactual != null)
                    {

                        Formulador.Formularios_Ayuda.FrmFormuladorMin fform = new Formulador.Formularios_Ayuda.FrmFormuladorMin();
                        if (componenteactual.VisibilidadCliente.StartsWith("="))
                        { fform.Formula = componenteactual.VisibilidadCliente.Remove(0, 1); }
                        else
                        { fform.Formula = componenteactual.VisibilidadCliente; }
                        fform.Analizador = this.analizador;
                        if (fform.ShowDialog() == DialogResult.OK)
                        {
                            decimal v = 0;
                            bool wform = decimal.TryParse(fform.Formula, out v);
                            if (!wform)
                            { componenteactual.VisibilidadCliente = "=" + fform.Formula; }
                            else
                            { componenteactual.VisibilidadCliente = "=" + fform.Valor; }                            
                        }
                    }
                    ControlZ();
                }
                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmcolor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colord = new ColorDialog();
                colord.Color = componenteactual.Color;
                if (colord.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        seleccionados[i].Color = colord.Color;
                    }
                }
                ControlZ();
                pbdxf.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmcolorFondo_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colord = new ColorDialog();
                colord.Color = componenteactual.Color;
                if (colord.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        seleccionados[i].Color_Fondo = colord.Color;
                    }
                }
                ControlZ();
                pbdxf.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Punteado_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < seleccionados.Count; i++)
                {
                    seleccionados[i].Punteado = true;
                }
                ControlZ();
                pbdxf.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Solido_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < seleccionados.Count; i++)
                {
                    seleccionados[i].Punteado = false;
                }
                ControlZ();
                pbdxf.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmgrosor_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGrosorLinea fgrosor = new FrmGrosorLinea();
                fgrosor.Grosor_Linea = Convert.ToDecimal(componenteactual.GrosorLinea);
                if (fgrosor.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        seleccionados[i].GrosorLinea = (float)fgrosor.Grosor_Linea;
                    }
                }
                ControlZ();
                pbdxf.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsmfuente_Click(object sender, EventArgs e)
        {
            try
            {
                FontDialog fontd = new FontDialog();
                if (componenteactual.GetType() == typeof(Cota))
                { fontd.Font = ((Cota)componenteactual).Font; }
                else if (componenteactual.GetType() == typeof(Texto))
                { fontd.Font = ((Texto)componenteactual).Font; }
                if (fontd.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        if (seleccionados[i].GetType() == typeof(Cota))
                        { ((Cota)seleccionados[i]).Font = fontd.Font; }
                        else if (seleccionados[i].GetType() == typeof(Texto))
                        { ((Texto)seleccionados[i]).Font = fontd.Font; }
                    }                    
                }
                ControlZ();
                pbdxf.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void girarHorizontalmenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionados.Count > 0)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        seleccionados[i].ReflejarHorizontal();
                    }
                }
                else
                {
                    for (int i = 0; i < ventana.ListaComponentes.Count; i++)
                    {
                        ventana.ListaComponentes[i].ReflejarHorizontal();
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void girarVerticalmenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionados.Count > 0)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        seleccionados[i].ReflejarVertical();
                    }
                }
                else
                {
                    for (int i = 0; i < ventana.ListaComponentes.Count; i++)
                    {
                        ventana.ListaComponentes[i].ReflejarVertical();
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void SeleccionMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                if (componenteactual != null)
                {
                    Formulador.Formularios_Ayuda.FrmFormuladorMin fform = new Formulador.Formularios_Ayuda.FrmFormuladorMin();
                    if (componenteactual.Formula_Material.StartsWith("="))
                    { fform.Formula = componenteactual.Formula_Material.Remove(0, 1); }
                    else
                    { fform.Formula = componenteactual.Formula_Material; }
                    fform.Analizador = this.analizador;
                    if (fform.ShowDialog() == DialogResult.OK)
                    {
                        componenteactual.Formula_Material = "=" + fform.Formula;
                    }
                    ControlZ();
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Igualar_Anchos_Click(object sender, EventArgs e)
        {
            try
            {
                float ancho_nuevo = componenteactual.RegionExterna.Width;
                for (int i = 0; i < seleccionados.Count - 1; i++)
                {

                    if (seleccionados[i].Punto1.X > seleccionados[i].Punto3.X)
                    {
                        seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto3.X + ancho_nuevo,
                            seleccionados[i].Punto1.Y);

                        seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto3.X + ancho_nuevo,
                            seleccionados[i].Punto2.Y);
                    }
                    else
                    {
                        seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto1.X + ancho_nuevo,
                            seleccionados[i].Punto3.Y);

                        seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto1.X + ancho_nuevo,
                            seleccionados[i].Punto4.Y);
                    }
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Igualar_Altos_Click(object sender, EventArgs e)
        {
            try
            {
                float alto_nuevo = componenteactual.RegionExterna.Height;
                for (int i = 0; i < seleccionados.Count - 1; i++)
                {
                    if (seleccionados[i].Punto1.Y > seleccionados[i].Punto3.Y)
                    {
                        seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X,
                            seleccionados[i].Punto3.Y + alto_nuevo);

                        seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X,
                            seleccionados[i].Punto3.Y + alto_nuevo);
                    }
                    else
                    {
                        seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X,
                            seleccionados[i].Punto1.Y + alto_nuevo);

                        seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X,
                            seleccionados[i].Punto1.Y + alto_nuevo);
                    }
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Alinear_Izquierda_Click(object sender, EventArgs e)
        {
            try
            {
                float x = componenteactual.RegionExterna.X;
                for (int i = 0; i < seleccionados.Count - 1; i++)
                {
                    float[] xs = new float[] { seleccionados[i].Punto1.X,
                                                seleccionados[i].Punto2.X,
                                                seleccionados[i].Punto3.X,
                                                seleccionados[i].Punto4.X};
                    float constante = x - xs.Min();
                    seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X + constante, seleccionados[i].Punto1.Y);
                    seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X + constante, seleccionados[i].Punto2.Y);
                    seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X + constante, seleccionados[i].Punto3.Y);
                    seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X + constante, seleccionados[i].Punto4.Y);
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Alinear_Arriba_Click(object sender, EventArgs e)
        {
            try
            {
                float y = componenteactual.RegionExterna.Y;
                for (int i = 0; i < seleccionados.Count - 1; i++)
                {
                    float[] ys = new float[] { seleccionados[i].Punto1.Y,
                                                seleccionados[i].Punto2.Y,
                                                seleccionados[i].Punto3.Y,
                                                seleccionados[i].Punto4.Y};
                    float constante = y - ys.Min();
                    seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X, seleccionados[i].Punto1.Y + constante);
                    seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X, seleccionados[i].Punto2.Y + constante);
                    seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X, seleccionados[i].Punto3.Y + constante);
                    seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X, seleccionados[i].Punto4.Y + constante);
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Alinear_Derecha_Click(object sender, EventArgs e)
        {
            try
            {
                float x = componenteactual.RegionExterna.X + componenteactual.RegionExterna.Width;
                for (int i = 0; i < seleccionados.Count - 1; i++)
                {
                    float[] xs = new float[] { seleccionados[i].Punto1.X,
                                                seleccionados[i].Punto2.X,
                                                seleccionados[i].Punto3.X,
                                                seleccionados[i].Punto4.X};
                    float constante = x - xs.Max();
                    seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X + constante, seleccionados[i].Punto1.Y);
                    seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X + constante, seleccionados[i].Punto2.Y);
                    seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X + constante, seleccionados[i].Punto3.Y);
                    seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X + constante, seleccionados[i].Punto4.Y);
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Alinear_Abajo_Click(object sender, EventArgs e)
        {
            try
            {
                float y = componenteactual.RegionExterna.Y + componenteactual.RegionExterna.Height;
                for (int i = 0; i < seleccionados.Count - 1; i++)
                {
                    float[] ys = new float[] { seleccionados[i].Punto1.Y,
                                                seleccionados[i].Punto2.Y,
                                                seleccionados[i].Punto3.Y,
                                                seleccionados[i].Punto4.Y};
                    float constante = y - ys.Max();
                    seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X, seleccionados[i].Punto1.Y + constante);
                    seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X, seleccionados[i].Punto2.Y + constante);
                    seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X, seleccionados[i].Punto3.Y + constante);
                    seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X, seleccionados[i].Punto4.Y + constante);
                }
                ControlZ();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Rotacion_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAnguloRotacion fangulo = new FrmAnguloRotacion();
                fangulo.Angulo = componenteactual.Rotacion;
                if (fangulo.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < seleccionados.Count; i++)
                    {
                        seleccionados[i].Rotacion = fangulo.Angulo;
                        
                    }
                }
                ControlZ();
                pbdxf.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        #endregion
        private void pbdxf_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {                
                if (sololectura) { return; }
                rec_seleccion = new RectangleF(0, 0, 1, 1);
                puntobase = e.Location;
                pbdxf.Focus();
                if (e.Button == MouseButtons.Left)
                {
                    mousepressed = true;
                    switch (tipofigura)
                    {
                        case TipoFigura.NINGUNA:
                            if (margenelementoActual != null)
                            {
                                if (ModifierKeys == Keys.Shift &&  !(System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.X) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Y)))
                                {
                                    #region Trasladar Completo
                                    PointF punto;
                                    ComponenteVentana componente;
                                    ventana.Obtener_Punto_y_Componente(e.Location, out punto, out componente);
                                    if (componente != null)
                                    {
                                        if (componente != componenteactual)
                                        {
                                            for (int i = 0; i < seleccionados.Count; i++)
                                            {
                                                float x = 0;
                                                float y = 0;
                                                switch (tipo_traslacion)
                                                {
                                                    case Tipo_Traslacion.ARRIBA_IZQUIERDA:
                                                        x = punto.X - seleccionados[i].Punto1.X;
                                                        y = punto.Y - seleccionados[i].Punto1.Y;
                                                        break;
                                                    case Tipo_Traslacion.ARRIBA_DERECHA:
                                                        x = punto.X - seleccionados[i].Punto4.X;
                                                        y = punto.Y - seleccionados[i].Punto4.Y;
                                                        break;
                                                    case Tipo_Traslacion.ABAJO_DERECHA:
                                                        x = punto.X - seleccionados[i].Punto3.X;
                                                        y = punto.Y - seleccionados[i].Punto3.Y;
                                                        break;
                                                    case Tipo_Traslacion.ABAJO_IZQUIERDA:
                                                        x = punto.X - seleccionados[i].Punto2.X;
                                                        y = punto.Y - seleccionados[i].Punto2.Y;
                                                        break;
                                                }
                                                seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X + x, seleccionados[i].Punto1.Y + y);
                                                seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X + x, seleccionados[i].Punto2.Y + y);
                                                seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X + x, seleccionados[i].Punto3.Y + y);
                                                seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X + x, seleccionados[i].Punto4.Y + y);
                                                tipo_traslacion = Tipo_Traslacion.ARRIBA_IZQUIERDA;
                                            }
                                            margenelementoActual.RedefinirPuntos();
                                        }
                                        else
                                        {
                                            if (punto == componenteactual.Punto1)
                                            { tipo_traslacion = Tipo_Traslacion.ARRIBA_IZQUIERDA; }
                                            else if (punto == componenteactual.Punto2)
                                            { tipo_traslacion = Tipo_Traslacion.ABAJO_IZQUIERDA; }
                                            else if (punto == componenteactual.Punto3)
                                            { tipo_traslacion = Tipo_Traslacion.ABAJO_DERECHA; }
                                            else if (punto == componenteactual.Punto4)
                                            { tipo_traslacion = Tipo_Traslacion.ARRIBA_DERECHA; }
                                        }
                                    }
                                    #endregion
                                }
                                else if (ModifierKeys == (Keys.Control | Keys.Shift) && !(System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.X) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Y)))
                                {
                                    #region Re-Dimensionar
                                    Tipo_Redimension tredimension =  Tipo_Redimension.ANCHO;
                                    ComponenteVentana componente;
                                    PointF punto_resultado = PointF.Empty;
                                    ventana.Obtener_Componente_Centrales(e.Location, out punto_resultado, out componente, out tredimension);

                                    if (componente != null)
                                    {
                                        if (componente != componenteactual)
                                        {
                                            for (int i = 0; i < seleccionados.Count; i++)
                                            {
                                                PointF[] puntos = new PointF[] { seleccionados[i].Punto1, seleccionados[i].Punto2 , seleccionados[i].Punto3 , seleccionados[i].Punto4 };
                                                switch (tipo_redimension)
                                                {
                                                    case Tipo_Redimension.X:
                                                        {
                                                            puntos = puntos.OrderBy(p => p.X).ToArray();
                                                            if (seleccionados[i].Punto1 == puntos[0] || seleccionados[i].Punto1 == puntos[1])
                                                            { seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X + (punto_resultado.X - seleccionados[i].Punto1.X), seleccionados[i].Punto1.Y); }
                                                            if (seleccionados[i].Punto2 == puntos[0] || seleccionados[i].Punto2 == puntos[1])
                                                            { seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X + (punto_resultado.X - seleccionados[i].Punto2.X), seleccionados[i].Punto2.Y); }
                                                            if (seleccionados[i].Punto3 == puntos[0] || seleccionados[i].Punto3 == puntos[1])
                                                            { seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X + (punto_resultado.X - seleccionados[i].Punto3.X), seleccionados[i].Punto3.Y); }
                                                            if (seleccionados[i].Punto4 == puntos[0] || seleccionados[i].Punto4 == puntos[1])
                                                            { seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X + (punto_resultado.X - seleccionados[i].Punto4.X), seleccionados[i].Punto4.Y); }
                                                            break; }
                                                    case Tipo_Redimension.Y:
                                                        {
                                                            puntos = puntos.OrderBy(p => p.Y).ToArray();
                                                            if (seleccionados[i].Punto1 == puntos[0] || seleccionados[i].Punto1 == puntos[1])
                                                            { seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X, seleccionados[i].Punto1.Y+ (punto_resultado.Y - seleccionados[i].Punto1.Y)); }
                                                            if (seleccionados[i].Punto2 == puntos[0] || seleccionados[i].Punto2 == puntos[1])
                                                            { seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X, seleccionados[i].Punto2.Y + (punto_resultado.Y - seleccionados[i].Punto2.Y)); }
                                                            if (seleccionados[i].Punto3 == puntos[0] || seleccionados[i].Punto3 == puntos[1])
                                                            { seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X, seleccionados[i].Punto3.Y + (punto_resultado.Y - seleccionados[i].Punto3.Y)); }
                                                            if (seleccionados[i].Punto4 == puntos[0] || seleccionados[i].Punto4 == puntos[1])
                                                            { seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X, seleccionados[i].Punto4.Y + (punto_resultado.Y - seleccionados[i].Punto4.Y)); }
                                                            break; }
                                                    case Tipo_Redimension.ANCHO:
                                                        {
                                                            puntos = puntos.OrderBy(p => p.X).ToArray();
                                                            if (seleccionados[i].Punto1 == puntos[2] || seleccionados[i].Punto1 == puntos[3])
                                                            { seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X + (punto_resultado.X - seleccionados[i].Punto1.X), seleccionados[i].Punto1.Y); }
                                                            if (seleccionados[i].Punto2 == puntos[2] || seleccionados[i].Punto2 == puntos[3])
                                                            { seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X + (punto_resultado.X - seleccionados[i].Punto2.X), seleccionados[i].Punto2.Y); }
                                                            if (seleccionados[i].Punto3 == puntos[2] || seleccionados[i].Punto3 == puntos[3])
                                                            { seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X + (punto_resultado.X - seleccionados[i].Punto3.X), seleccionados[i].Punto3.Y); }
                                                            if (seleccionados[i].Punto4 == puntos[2] || seleccionados[i].Punto4 == puntos[3])
                                                            { seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X + (punto_resultado.X - seleccionados[i].Punto4.X), seleccionados[i].Punto4.Y); }
                                                            break; }
                                                    case Tipo_Redimension.ALTO:
                                                        {
                                                            puntos = puntos.OrderBy(p => p.Y).ToArray();                                                            
                                                            if (seleccionados[i].Punto1 == puntos[2] || seleccionados[i].Punto1 == puntos[3])
                                                            { seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X, seleccionados[i].Punto1.Y + (punto_resultado.Y - seleccionados[i].Punto1.Y)); }
                                                            if (seleccionados[i].Punto2 == puntos[2] || seleccionados[i].Punto2 == puntos[3])
                                                            { seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X, seleccionados[i].Punto2.Y + (punto_resultado.Y - seleccionados[i].Punto2.Y)); }
                                                            if (seleccionados[i].Punto3 == puntos[2] || seleccionados[i].Punto3 == puntos[3])
                                                            { seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X, seleccionados[i].Punto3.Y + (punto_resultado.Y - seleccionados[i].Punto3.Y)); }
                                                            if (seleccionados[i].Punto4 == puntos[2] || seleccionados[i].Punto4 == puntos[3])
                                                            { seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X, seleccionados[i].Punto4.Y + (punto_resultado.Y - seleccionados[i].Punto4.Y)); }
                                                            break; }
                                                }
                                            }
                                            margenelementoActual.RedefinirPuntos();
                                        }
                                        else
                                        {
                                            tipo_redimension = tredimension;                                            
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    redimension_seleccionada = margenelementoActual.empezarRedimension(e.X, e.Y);
                                }
                            }
                            if (redimension_seleccionada == Click_Redimension.NINGUNA && ModifierKeys != Keys.Shift && ModifierKeys != (Keys.Control | Keys.Shift))
                            {
                                componenteactual = ventana.contienePunto(e.X, e.Y, ModifierKeys == Keys.Alt || ModifierKeys == (Keys.Control | Keys.Alt));
                                if (componenteactual != null)
                                {
                                    if (!seleccionados.Contains(componenteactual))
                                    {
                                        if (ModifierKeys == Keys.Control || ModifierKeys == (Keys.Control|Keys.Alt) || seleccionados.Count ==0)
                                        {
                                            seleccionados.Add(componenteactual);
                                        }
                                        else
                                        {
                                            seleccionados.Clear();
                                            seleccionados.Add(componenteactual);
                                        }
                                    }
                                    else
                                    {
                                    }
                                    margenelementoActual = new MargenRedimension(seleccionados);
                                }
                                else
                                {
                                    seleccionados.Clear();
                                }
                            }
                            break;
                        case TipoFigura.TRASLADAR:
                            pbdxf.Cursor = new Cursor(Properties.Resources.Mano_cerrada_24.GetHicon());
                            break;
                        case TipoFigura.COTA:
                            if (cantidadpresion == 0)
                            {
                                Formulador.Formularios_Ayuda.FrmFormuladorMin fcotas = new Formulador.Formularios_Ayuda.FrmFormuladorMin();
                                fcotas.Analizador = this.analizador;
                                if (fcotas.ShowDialog() == DialogResult.OK)
                                {
                                    componenteactual = new Cota(new PointF((e.X / ventana.zoom_factor) - ventana.traslacion_factor[0],
                                    (e.Y / ventana.zoom_factor) - ventana.traslacion_factor[1]), "Cota", fcotas.Formula, fcotas.Valor);
                                    cantidadpresion++;
                                }
                            }
                            else if (cantidadpresion == 1)
                            {
                                componenteactual.Punto3 = new PointF((e.X / ventana.zoom_factor) - ventana.traslacion_factor[0],
                                        (e.Y / ventana.zoom_factor) - ventana.traslacion_factor[1]);                                
                                cantidadpresion = 0;
                            }
                            break;
                        case TipoFigura.TEXTO:
                            {
                                Formulador.Formularios_Ayuda.FrmFormuladorMin ftexto = new Formulador.Formularios_Ayuda.FrmFormuladorMin();
                                ftexto.Analizador = this.analizador;
                                if (ftexto.ShowDialog() == DialogResult.OK)
                                {
                                    componenteactual = new Texto(new PointF((e.X/ventana.zoom_factor)-ventana.traslacion_factor[0],
                                        (e.Y/ventana.zoom_factor)-ventana.traslacion_factor[1]), "Texto", ftexto.Formula, ftexto.Valor);
                                }
                            }
                            break;
                        case TipoFigura.FLECHA:
                            if (cantidadpresion == 0)
                            {
                                componenteactual = new Flecha(new PointF((e.X / ventana.zoom_factor) - ventana.traslacion_factor[0],
                                        (e.Y / ventana.zoom_factor) - ventana.traslacion_factor[1]), "Flecha");
                                cantidadpresion++;                                
                            }
                            else if (cantidadpresion == 1)
                            {
                                componenteactual.Punto3 = new PointF((e.X / ventana.zoom_factor) - ventana.traslacion_factor[0],
                                        (e.Y / ventana.zoom_factor) - ventana.traslacion_factor[1]);
                                tipofigura = TipoFigura.NINGUNA;                                
                                cantidadpresion = 0;
                            }
                            break;
                        default:
                            if (cantidadpresion == 0)
                            {
                                DefinirActualSegunTipo((e.X / ventana.zoom_factor) - ventana.traslacion_factor[0],
                                    (e.Y / ventana.zoom_factor) - ventana.traslacion_factor[1]);
                                cantidadpresion++;
                            }
                            else if (cantidadpresion == 1)
                            {
                                componenteactual.Punto3 = new PointF((e.X / ventana.zoom_factor) - ventana.traslacion_factor[0],
                                        (e.Y / ventana.zoom_factor) - ventana.traslacion_factor[1]);
                                cantidadpresion = 0;
                            }
                            break;
                    }
                    if (componenteactual != null) { ventana.AgregarComponente(componenteactual); }
                    pbdxf.Refresh();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    DefinirMenuStrip();
                }               
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void pbdxf_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                pbdxf.Focus();
                if (sololectura) { return; }
                switch (tipofigura)
                {
                    case TipoFigura.NINGUNA:
                        if (mousepressed)
                        {
                            if (redimension_seleccionada != Click_Redimension.NINGUNA)
                            {
                                if (margenelementoActual != null && componenteactual != null)
                                {
                                    switch (redimension_seleccionada)
                                    {
                                        #region Arriba
                                        case Click_Redimension.ARRIBA:
                                            componenteactual.Punto1 = new PointF(componenteactual.Punto1.X,
                                                componenteactual.Punto1.Y + (e.Y - puntobase.Y));
                                            componenteactual.Punto4 = new PointF(componenteactual.Punto4.X,
                                                componenteactual.Punto4.Y + (e.Y - puntobase.Y));
                                            puntobase.Y = e.Y;
                                            break;
                                        #endregion
                                        #region Derecha
                                        case Click_Redimension.DERECHA:
                                            componenteactual.Punto3 = new PointF(componenteactual.Punto3.X + (e.X - puntobase.X),
                                                componenteactual.Punto3.Y);
                                            componenteactual.Punto4 = new PointF(componenteactual.Punto4.X + (e.X - puntobase.X),
                                                    componenteactual.Punto4.Y);
                                            puntobase.X = e.X;
                                            break;
                                        #endregion
                                        #region Abajo
                                        case Click_Redimension.ABAJO:
                                            componenteactual.Punto3 = new PointF(componenteactual.Punto3.X,
                                                componenteactual.Punto3.Y + (e.Y - puntobase.Y));
                                            componenteactual.Punto2 = new PointF(componenteactual.Punto2.X,
                                                    componenteactual.Punto2.Y + (e.Y - puntobase.Y));
                                            puntobase.Y = e.Y;
                                            break;
                                        #endregion
                                        #region Izquierda
                                        case Click_Redimension.IZQUIERDA:
                                            componenteactual.Punto1 = new PointF(componenteactual.Punto1.X + (e.X - puntobase.X),
                                                componenteactual.Punto1.Y);
                                            componenteactual.Punto2 = new PointF(componenteactual.Punto2.X + (e.X - puntobase.X),
                                                    componenteactual.Punto2.Y);
                                            puntobase.X = e.X;
                                            break;
                                        #endregion
                                        #region Punto 1
                                        case Click_Redimension.PUNTO1:
                                            {
                                                if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.X))
                                                {
                                                    componenteactual.Punto1 = new PointF(componenteactual.Punto1.X + (e.X - puntobase.X),
                                                    componenteactual.Punto1.Y);
                                                }
                                                else if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Y))
                                                {
                                                    componenteactual.Punto1 = new PointF(componenteactual.Punto1.X,
                                                    componenteactual.Punto1.Y + (e.Y - puntobase.Y));
                                                }
                                                else
                                                {
                                                    componenteactual.Punto1 = new PointF(componenteactual.Punto1.X + (e.X - puntobase.X),
                                                    componenteactual.Punto1.Y + (e.Y - puntobase.Y));
                                                }
                                                puntobase = e.Location;
                                                break;
                                            }
                                        #endregion
                                        #region Punto 2
                                        case Click_Redimension.PUNTO2:
                                            {
                                                if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.X))
                                                {
                                                    componenteactual.Punto2 = new PointF(componenteactual.Punto2.X + (e.X - puntobase.X),
                                                    componenteactual.Punto2.Y);
                                                }
                                                else if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Y))
                                                {
                                                    componenteactual.Punto2 = new PointF(componenteactual.Punto2.X,
                                                    componenteactual.Punto2.Y + (e.Y - puntobase.Y));
                                                }
                                                else
                                                {
                                                    componenteactual.Punto2 = new PointF(componenteactual.Punto2.X + (e.X - puntobase.X),
                                                    componenteactual.Punto2.Y + (e.Y - puntobase.Y));
                                                }
                                                puntobase = e.Location;
                                                break;
                                            }
                                        #endregion
                                        #region Punto 3
                                        case Click_Redimension.PUNTO3:
                                            {
                                                if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.X))
                                                {
                                                    componenteactual.Punto3 = new PointF(componenteactual.Punto3.X + (e.X - puntobase.X),
                                                    componenteactual.Punto3.Y);
                                                }
                                                else if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Y))
                                                {
                                                    componenteactual.Punto3 = new PointF(componenteactual.Punto3.X,
                                                    componenteactual.Punto3.Y + (e.Y - puntobase.Y));
                                                }
                                                else
                                                {
                                                    componenteactual.Punto3 = new PointF(componenteactual.Punto3.X + (e.X - puntobase.X),
                                                    componenteactual.Punto3.Y + (e.Y - puntobase.Y));
                                                }

                                                puntobase = e.Location;
                                                break;
                                            }
                                        #endregion
                                        #region Punto 4
                                        case Click_Redimension.PUNTO4:
                                            {
                                                if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.X))
                                                {
                                                    componenteactual.Punto4 = new PointF(componenteactual.Punto4.X + (e.X - puntobase.X),
                                                    componenteactual.Punto4.Y);
                                                }
                                                else if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Y))
                                                {
                                                    componenteactual.Punto4 = new PointF(componenteactual.Punto4.X,
                                                    componenteactual.Punto4.Y + (e.Y - puntobase.Y));
                                                }
                                                else
                                                {
                                                    componenteactual.Punto4 = new PointF(componenteactual.Punto4.X + (e.X - puntobase.X),
                                                    componenteactual.Punto4.Y + (e.Y - puntobase.Y));
                                                }
                                                puntobase = e.Location;
                                                break;
                                            }
                                        #endregion
                                        #region Punto Central
                                        case Click_Redimension.CENTRAL:
                                            {
                                                for (int i = 0; i < seleccionados.Count; i++)
                                                {
                                                    if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.X))
                                                    {
                                                        seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X + (e.X - puntobase.X),
                                                        seleccionados[i].Punto1.Y);

                                                        seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X + (e.X - puntobase.X),
                                                            seleccionados[i].Punto2.Y);

                                                        seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X + (e.X - puntobase.X),
                                                            seleccionados[i].Punto3.Y);

                                                        seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X + (e.X - puntobase.X),
                                                            seleccionados[i].Punto4.Y);
                                                    }
                                                    else if (ModifierKeys == Keys.Shift && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Y))
                                                    {
                                                        seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X,
                                                        seleccionados[i].Punto1.Y + (e.Y - puntobase.Y));

                                                        seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X,
                                                            seleccionados[i].Punto2.Y + (e.Y - puntobase.Y));

                                                        seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X,
                                                            seleccionados[i].Punto3.Y + (e.Y - puntobase.Y));

                                                        seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X,
                                                            seleccionados[i].Punto4.Y + (e.Y - puntobase.Y));
                                                    }
                                                    else
                                                    {
                                                        seleccionados[i].Punto1 = new PointF(seleccionados[i].Punto1.X + (e.X - puntobase.X),
                                                        seleccionados[i].Punto1.Y + (e.Y - puntobase.Y));

                                                        seleccionados[i].Punto2 = new PointF(seleccionados[i].Punto2.X + (e.X - puntobase.X),
                                                            seleccionados[i].Punto2.Y + (e.Y - puntobase.Y));

                                                        seleccionados[i].Punto3 = new PointF(seleccionados[i].Punto3.X + (e.X - puntobase.X),
                                                            seleccionados[i].Punto3.Y + (e.Y - puntobase.Y));

                                                        seleccionados[i].Punto4 = new PointF(seleccionados[i].Punto4.X + (e.X - puntobase.X),
                                                            seleccionados[i].Punto4.Y + (e.Y - puntobase.Y));
                                                    }
                                                }
                                                puntobase = e.Location;
                                                break;
                                            }
                                        #endregion
                                        #region Punto rotación
                                        case Click_Redimension.ROTADOR:
                                        {
                                                componenteactual.Rotacion -= (puntobase.Y - e.Location.Y);
                                                puntobase = e.Location;
                                            break;
                                        }
                                        #endregion
                                    }
                                    margenelementoActual.RedefinirPuntos();
                                }
                            }
                            else if( redimension_seleccionada == Click_Redimension.NINGUNA)
                            {
                                float[] xs = new float[] { puntobase.X, e.Location.X };
                                float[] ys = new float[] { puntobase.Y, e.Location.Y };
                                rec_seleccion = new RectangleF(xs.Min(), ys.Min(), xs.Max() - xs.Min(), ys.Max() - ys.Min());
                                ComponenteVentana[] cmps = ventana.ListaComponentes.Where(c => !seleccionados.Contains(c) && (rec_seleccion.Contains(c.Punto1) && rec_seleccion.Contains(c.Punto2) && rec_seleccion.Contains(c.Punto3) && rec_seleccion.Contains(c.Punto4))).ToArray();
                                if (cmps.Length > 0)
                                {
                                    seleccionados.AddRange(cmps);
                                    margenelementoActual = new MargenRedimension(seleccionados);
                                    componenteactual = cmps[cmps.Length - 1];
                                }
                            }
                        }
                        break;
                    case TipoFigura.TRASLADAR:
                        if (mousepressed)
                        {

                            ventana.Factor_Traslacion[0] += e.Location.X - puntobase.X;
                            ventana.Factor_Traslacion[1] += e.Location.Y - puntobase.Y;                            
                            if (seleccionados.Count > 0)
                            {
                                margenelementoActual.RedefinirPuntos();
                            }
                            puntobase = e.Location;
                        }
                        break;
                    case TipoFigura.COTA:
                    case TipoFigura.MARCO:
                    case TipoFigura.NAVE:
                    case TipoFigura.FIJO:
                    case TipoFigura.REJILLA:
                    case TipoFigura.ANGEO:
                    case TipoFigura.ELE:
                    case TipoFigura.ARCO:
                    case TipoFigura.FLECHA:
                    case TipoFigura.LINEA:
                    case TipoFigura.ANTICONDENSACION:
                        if (cantidadpresion == 1 && componenteactual != null)
                        {
                            componenteactual.Punto3 = new PointF((e.X / ventana.zoom_factor) - ventana.traslacion_factor[0],
                                        (e.Y / ventana.zoom_factor) - ventana.traslacion_factor[1]);
                            componenteactual.RecalcularPuntos();
                        }
                        break;
                }
                pbdxf.Refresh();

                #region Lineas__Direccion
                if (tipofigura != TipoFigura.NINGUNA)
                {
                    switch (ventana.InterseccionColision(new PointF(e.X, e.Y), componenteactual))
                    {
                        case TipoContacto.HORIZONTAL:
                            pbdxf.CreateGraphics().DrawLine(new Pen(new SolidBrush(Color.Green), 2),
                                   e.X, 0, e.X, pbdxf.Height);
                            break;
                        case TipoContacto.VERTICAL:
                            pbdxf.CreateGraphics().DrawLine(new Pen(new SolidBrush(Color.Red), 2),
                                   0, e.Y, pbdxf.Width, e.Y);
                            break;
                        case TipoContacto.INTERCEPTO:
                            pbdxf.CreateGraphics().FillRectangle(Brushes.Orange, e.X - 4, e.Y - 4, 8, 8);
                            break;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void pbdxf_MouseUp(object sender, MouseEventArgs e)
        {
            if (sololectura) { return; }
            try
            {                
                mousepressed = false;
                if (tipofigura == TipoFigura.TRASLADAR) { pbdxf.Cursor = new Cursor(Properties.Resources.Mano_abierta24.GetHicon()); }
                else { pbdxf.Cursor = Cursors.Cross; }
                ControlZ();
                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }       
        private void pbdxf_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;                                
                if (ventana != null)
                {
                    for (int i = 0; i < ventana.ListaComponentes.Count; i++)
                    {
                        ventana.ListaComponentes[i].Dibujar(e.Graphics, false);
                    }

                    if (seleccionados.Count > 0)
                    {
                        margenelementoActual?.Dibujar(e.Graphics);
                        if (ModifierKeys == Keys.Shift)
                        { ventana.Marcar_Puntos_Componentes(e.Graphics); }
                        else if (ModifierKeys == (Keys.Control | Keys.Shift))
                        {
                            ventana.Marcar_Centrales_Componentes(e.Graphics);
                        }
                    }
                }
                if (mousepressed && redimension_seleccionada == Click_Redimension.NINGUNA)
                {
                    Pen p = new Pen(Brushes.Blue);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                    e.Graphics.DrawRectangle(p, rec_seleccion.X, rec_seleccion.Y, rec_seleccion.Width, rec_seleccion.Height);                    
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tsherramientasdxf_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            componenteactual = null;
        }       
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            try
            {
                if (ventana != null)
                {
                    last_dxf = ObtenerDxf();
                    ventana = new Ventana(analizador, pbdxf.Size);
                    if (!string.IsNullOrEmpty(last_dxf)) { LeerDxf(last_dxf); }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void tbzoom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ventana.Factor_Zoom = Convert.ToSingle(tbzoom.Value) / 2;
                if (seleccionados.Count > 0)
                {
                    margenelementoActual.RedefinirPuntos();
                }
                pbdxf.Refresh();
                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Pbdxf_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (ModifierKeys == Keys.Control)
                {
                    if (e.Delta < 0)
                    {
                        if (tbzoom.Value > tbzoom.Minimum)
                        { tbzoom.Value -= 1; }
                    }
                    else
                    {
                        if (tbzoom.Value < tbzoom.Maximum)
                        { tbzoom.Value += 1; }
                    }
                }                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);                
            }
        }
        private void pbdxf_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {                
                if (!sololectura)
                {
                    #region Escape
                    if (e.KeyCode == Keys.Escape)
                    {                        
                        if (componenteactual != null && cantidadpresion == 1)
                        {
                            ventana.ListaComponentes.Remove(componenteactual);
                        }
                        cantidadpresion = 0;
                        tipofigura = TipoFigura.NINGUNA;
                        seleccionados.Clear();
                        componenteactual = null;
                        pbdxf.Refresh();                        
                    }
                    #endregion
                    else if (e.Control && e.KeyCode == Keys.C)
                    { Copiar_Click(null, null); }
                    else if (e.Control && e.KeyCode == Keys.V)
                    { Pegar_Click(null, null); }
                    else if (e.Control && e.KeyCode == Keys.Z)
                    { btndevolveraccion_Click(null, null); }

                    if (componenteactual != null)
                        if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                        {
                            tsmeliminar_Click(null, null);
                        }
                        else if (e.Shift && e.KeyCode == Keys.C)
                        {
                            componenteactual.FormaCircular = !componenteactual.FormaCircular;
                            pbdxf.Refresh();
                        }
                        else if (!e.Shift && e.Control && e.KeyCode == Keys.Up && seleccionados.Count > 1)
                        { Alinear_Arriba_Click(null, null); margenelementoActual?.RedefinirPuntos(); Refresh(); }
                        else if (!e.Shift && e.Control && e.KeyCode == Keys.Left && seleccionados.Count > 1)
                        { Alinear_Izquierda_Click(null, null); margenelementoActual?.RedefinirPuntos(); Refresh(); }
                        else if (!e.Shift && e.Control && e.KeyCode == Keys.Down && seleccionados.Count > 1)
                        { Alinear_Abajo_Click(null, null); margenelementoActual?.RedefinirPuntos(); Refresh(); }
                        else if (!e.Shift && e.Control && e.KeyCode == Keys.Right && seleccionados.Count > 1)
                        { Alinear_Derecha_Click(null, null); margenelementoActual?.RedefinirPuntos(); Refresh(); }
                        else if (e.Shift && e.Control && e.KeyCode == Keys.Down && seleccionados.Count > 1)
                        { Igualar_Altos_Click(null, null); margenelementoActual?.RedefinirPuntos(); Refresh(); }
                        else if (e.Shift && e.Control && e.KeyCode == Keys.Right && seleccionados.Count > 1)
                        { Igualar_Anchos_Click(null, null); margenelementoActual?.RedefinirPuntos(); Refresh(); }

                        #region Punteado o Solido
                        else if (e.Control && e.KeyCode == Keys.P)
                        {
                            if (seleccionados.Count > 0)
                            {
                                for (int i = 0; i < seleccionados.Count; i++)
                                {
                                    seleccionados[i].Punteado = !seleccionados[i].Punteado;
                                }
                                ControlZ();
                                pbdxf.Refresh();
                            }
                        }
                    #endregion
                }


            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

    }
}
