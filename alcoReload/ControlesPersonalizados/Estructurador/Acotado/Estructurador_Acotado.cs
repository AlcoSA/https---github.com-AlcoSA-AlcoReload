using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
namespace ControlesPersonalizados.Estructurador
{
    public delegate void ValorCota_Cambiado(object sender, ValorCotaCambiado_EventArgs e);
    
    public partial class Estructurador_Acotado : UserControl
    {
        #region Delegados
        public event ValorCota_Cambiado valor_Cota_Cambiado;
        protected virtual void OnValor_Cota_Cambiado(ValorCotaCambiado_EventArgs e)
        {
            valor_Cota_Cambiado?.Invoke(this, e);
        }
        #endregion

        #region Variables
        RegionEstructuras regionppal;
        Cota_Region_Estructural region_cota_seleccionada;
        private decimal desfase = 10m;
        private List<Cota_Region_Estructural> cotas;
        #endregion

        #region Propiedades
        public RegionEstructuras EstructuraPrincipal
        {
            get { return regionppal; }
            set
            {
                regionppal = value;                
            }
        }
        public Cota_Region_Estructural Cota_Seleccionada
        {
            get { return region_cota_seleccionada; }
            set { region_cota_seleccionada = value; }
        }
        public decimal Desfase
        {
            get { return desfase; }
            set { desfase = value;
                regionppal.Desfase = desfase;
                this.Refresh();
            }
        }
        public List<Cota_Region_Estructural> Cotas
        {
            get { return cotas; }
            set { cotas = value; }
        }

        #endregion

        public Estructurador_Acotado()
        {            
            InitializeComponent();
            regionppal = new RegionEstructuras(0, 0, this.Width, this.Height);
            cotas = new List<Cota_Region_Estructural>();
        }

        #region Procedimientos
        //private RegionEstructuras IdentificarRegion(RegionEstructuras reg, Point p)
        //{
        //    try
        //    {
        //        RegionEstructuras r = reg;
        //        for (int i = 0; i < reg.Estructuras.Count; i++)
        //        {
        //            if (reg.Estructuras[i].Contains(p))
        //            {
        //                r = IdentificarRegion(reg.Estructuras[i], p);
        //            }
        //        }                
        //        return r;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //}
        private void SeleccionarCota(RegionEstructuras reg, Point p)
        {
            try
            {
                region_cota_seleccionada = cotas.FirstOrDefault(x => x.Region.Contains(p));
                if (region_cota_seleccionada != null) { this.Refresh(); }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void DibujarTodos(RegionEstructuras r)
        {
            try
            {
                r.Construir(this.CreateGraphics(), true);
                for (int i = 0; i < r.Estructuras.Count; i++)
                {
                    DibujarTodos(r.Estructuras[i]);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void ModificarValorCota(Object sender, EventArgs e)
        {
            try
            {
                FrmCambioValorCota fcambio = new FrmCambioValorCota();
                fcambio.ValorCota = Convert.ToDecimal(region_cota_seleccionada.Texto);
                if (fcambio.ShowDialog() == DialogResult.OK)
                {
                    OnValor_Cota_Cambiado(new ValorCotaCambiado_EventArgs(region_cota_seleccionada, region_cota_seleccionada.Texto, Convert.ToString(fcambio.ValorCota)));
                    region_cota_seleccionada.Texto = Convert.ToString(fcambio.ValorCota);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        public RegionEstructuras[] ObtenerRegionxId(RegionEstructuras reg, int id)
        {
            try
            {                

                return reg.Estructuras.Where(e => e.Id_Hijo_Owner == id).ToArray();

                //for (int i = 0; i < reg.Estructuras.Count; i++)
                //{
                //    if (reg.Estructuras[i].Id_Hijo_Owner == id)
                //    {
                //        return reg.Estructuras[i];
                //    }
                //}
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        private void Estructurador_Acotado_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (regionppal == null)
                { regionppal = new RegionEstructuras(0, 0, 1, 1); }
                else
                {
                    if (regionppal.Estructuras.Count <= 0 && string.IsNullOrEmpty(regionppal.Estructura))
                    {
                        regionppal = new RegionEstructuras(0, 0, 1, 1);
                    }
                }
                regionppal.Desfase = desfase;
                regionppal.RegionControlContenedor = new RectangleF(0, 0, this.Width - (float)desfase, 
                    this.Height - (float)desfase);                
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Estructurador_Acotado_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DibujarTodos(regionppal);
                if (cotas != null)
                {
                    for (int i = 0; i < cotas.Count; i++)
                    {
                        cotas[i].Dibujar(e.Graphics);
                    }
                }                
                if (region_cota_seleccionada != null)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.DodgerBlue)),
                        region_cota_seleccionada.Region);
                    var r = region_cota_seleccionada.Region;
                    e.Graphics.DrawRectangle(Pens.DodgerBlue, r.X,
                        r.Y, r.Width, r.Height);
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Estructurador_Acotado_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                SeleccionarCota(regionppal, e.Location);
                if (e.Button == MouseButtons.Right && region_cota_seleccionada !=null)
                {
                    ContextMenuStrip cms = new ContextMenuStrip();
                    cms.Items.Add("Modificar Valor Cota", null, ModificarValorCota);
                    cms.Show(this, e.Location);
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }       

    }
}
