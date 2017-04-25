using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControlesPersonalizados.Estructurador
{
    public delegate void cambio_medidas(object sender, Cambio_Medidas_Eventargs e);
    public partial class EstructuradorGrafico : UserControl
    {
        #region Delegados
        public event cambio_medidas Cambio_Medidas;
        protected virtual void OnCambio_Medidas(Cambio_Medidas_Eventargs e)
        {
            Cambio_Medidas?.Invoke(this, e);
        }

        #endregion
        #region Variables
        RegionEstructuras regionppal;
        RegionEstructuras region_seleccionada;
        SeleccionEstructura seleccion_region;
        Point ultimaposcursor;
        #region Re-Dimensionar
        private bool mousepresed = false;
        private PointF ultimaPresion;
        #endregion
        #endregion
        #region Propiedades
        public RegionEstructuras EstructuraPrincipal
        {
            get { return regionppal; }
            set
            {
                decimal ancho_real = regionppal.Ancho_Real;
                decimal alto_real = regionppal.Alto_Real;
                regionppal = value;
                regionppal.RegionControlContenedor = new RectangleF(0, 0, this.Width, this.Height);
                regionppal.Ancho_Real = ancho_real; regionppal.Alto_Real = alto_real;
                seleccion_region = null;
                //region_seleccionada = null;
                this.Refresh();
            }
        }
        #endregion
        #region Constructor
        public EstructuradorGrafico()
        {
            InitializeComponent();
        }
        #endregion
        #region Procedimientos
        public void ObtenerxIndex(int index, RegionEstructuras base_busquedad, ref RegionEstructuras resultado)
        {
            try
            {
                foreach (var bb in base_busquedad.Estructuras)
                {
                    if (resultado != null) { break; }
                    if (bb.Index_Hijo_Owner == index)
                    {
                        resultado = bb;
                    }                    
                    ObtenerxIndex(index, bb, ref resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }       
        private RegionEstructuras IdentificarRegion(RegionEstructuras reg, Point p)
        {
            try
            {
                RegionEstructuras r = reg;
                for (int i = 0; i < reg.Estructuras.Count; i++)
                {
                    if (reg.Estructuras[i].Contains(p))
                    {
                        r = IdentificarRegion(reg.Estructuras[i], p);
                    }
                }
                seleccion_region = new SeleccionEstructura(r);
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public RegionEstructuras IdentificarRegion()
        {
            try
            {
                return IdentificarRegion(regionppal, ultimaposcursor); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void DividirRegion(RegionEstructuras reg, int divisiones, bool vertical)
        {
            try
            {
                if (reg != null)
                {                    
                    if (reg.TipoEstructura == Tipo_Estructura.BASICO)
                    {
                        reg.Id_Hijo_Owner = 0;
                        reg.Index_Hijo_Owner = -1;
                        reg.Estructura = null;
                        reg.Estructuras.Clear();
                        decimal ancho = reg.Ancho / divisiones;
                        decimal alto = reg.Alto / divisiones;
                        for (int i = 0; i < divisiones; i++)
                        {
                            if (vertical)
                            {
                                RegionEstructuras r = new RegionEstructuras(reg,
                                    reg.X, reg.Y + (alto * i), reg.Ancho, alto);
                                r.OrientacionEstructura = Orientacion_Estructura.VERTICAL;
                                reg.Estructuras.Add(r);
                            }
                            else
                            {
                                RegionEstructuras r = new RegionEstructuras(reg, reg.X + (ancho * i),
                                    reg.Y, ancho, reg.Alto);
                                r.OrientacionEstructura = Orientacion_Estructura.HORIZONTAL;
                                reg.Estructuras.Add(r);
                            }
                        }
                        this.Refresh();
                    }                    
                }
                else
                {
                    MessageBox.Show("No hay una región seleccionada");
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        public void DividirRegion(int divisiones, bool vertical)
        {
            try
            {
                if (region_seleccionada != null)
                {
                    if (region_seleccionada.TipoEstructura == Tipo_Estructura.BASICO)
                    {
                        region_seleccionada.Id_Hijo_Owner = 0;
                        region_seleccionada.Index_Hijo_Owner = -1;
                        region_seleccionada.Estructura = null;
                        region_seleccionada.Estructuras.Clear();
                        decimal ancho = region_seleccionada.Ancho / divisiones;
                        decimal alto = region_seleccionada.Alto / divisiones;
                        for (int i = 0; i < divisiones; i++)
                        {
                            if (vertical)
                            {
                                RegionEstructuras r = new RegionEstructuras(region_seleccionada,
                                    region_seleccionada.X, region_seleccionada.Y + (alto * i), region_seleccionada.Ancho, alto);
                                r.OrientacionEstructura = Orientacion_Estructura.VERTICAL;
                                region_seleccionada.Estructuras.Add(r);
                            }
                            else
                            {
                                RegionEstructuras r = new RegionEstructuras(region_seleccionada, region_seleccionada.X + (ancho * i),
                                    region_seleccionada.Y, ancho, region_seleccionada.Alto);
                                r.OrientacionEstructura = Orientacion_Estructura.HORIZONTAL;
                                region_seleccionada.Estructuras.Add(r);
                            }
                        }
                        this.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("No hay una región seleccionada");
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void DividirRegion(object sender, EventArgs e)
        {
            try
            {
                FrmDivisionesEstructura fde = new FrmDivisionesEstructura();
                if (fde.ShowDialog() == DialogResult.OK)
                {
                    region_seleccionada.Id_Hijo_Owner = 0;
                    region_seleccionada.Index_Hijo_Owner = -1;
                    region_seleccionada.Estructura = null;
                    decimal ancho = region_seleccionada.Ancho / fde.Divisiones;
                    decimal alto = region_seleccionada.Alto / fde.Divisiones;
                    for (int i = 0; i < fde.Divisiones; i++)
                    {
                        if (fde.Horizontal)
                        {
                            RegionEstructuras r = new RegionEstructuras(region_seleccionada,
                                region_seleccionada.X, alto * i, region_seleccionada.Ancho, alto);
                            r.OrientacionEstructura = Orientacion_Estructura.VERTICAL;
                            region_seleccionada.Estructuras.Add(r);
                        }
                        else
                        {
                            RegionEstructuras r = new RegionEstructuras(region_seleccionada, ancho * i,
                                region_seleccionada.Y, ancho, region_seleccionada.Alto);
                                r.OrientacionEstructura = Orientacion_Estructura.HORIZONTAL;
                            region_seleccionada.Estructuras.Add(r);
                        }
                    }                    
                    region_seleccionada = null;
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void EsPared(object sender, EventArgs e)
        {
            try
            {
                region_seleccionada.Referencia_Perfil = string.Empty;
                region_seleccionada.TipoEstructura = Tipo_Estructura.BASICO;
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void EliminarRegion(object sender, EventArgs e)
        {
            try
            {
                if (region_seleccionada.Contenedor != null)
                {
                    if (region_seleccionada.Contenedor.Estructuras.Count == 2)
                    {
                        region_seleccionada.Contenedor.Estructura = region_seleccionada.Estructura;
                        region_seleccionada.Contenedor.Estructuras.Clear();
                    }
                    else if (region_seleccionada.Contenedor.Estructuras.Count > 2)
                    {
                        RegionEstructuras pest = region_seleccionada.Contenedor;
                        pest.Estructuras.Remove(region_seleccionada);
                        bool vertical = pest.Estructuras.GroupBy(est => est.X).Count() == 1 ? true : false;
                        decimal ancho = pest.Ancho_Relativo / pest.Estructuras.Count;
                        decimal alto = pest.Alto_Relativo / pest.Estructuras.Count;
                        for (int i = 0; i < pest.Estructuras.Count; i++)
                        {
                            if (vertical)
                            {
                                pest.Estructuras[i].Y = (alto * i) / this.Height;
                                pest.Estructuras[i].Alto = alto / this.Height;
                            }
                            else
                            {
                                pest.Estructuras[i].X = (ancho * i) / this.Width;
                                pest.Estructuras[i].Ancho = ancho / this.Width;
                            }
                        }
                    }                    
                }
                region_seleccionada = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void LimpiarRegion(object sender, EventArgs e)
        {
            try
            {
                region_seleccionada = null;
                regionppal.Estructuras.Clear();
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void QuitarEstructura(object sender, EventArgs e)
        {
            try
            {
                region_seleccionada.Estructura = string.Empty;
                region_seleccionada.Index_Hijo_Owner = -1;
                region_seleccionada.Id_Hijo_Owner = 0;
                region_seleccionada.Arquitecto = null;
                region_seleccionada = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Ele_Arriba(object sender, EventArgs e)
        {
            try
            {
                region_seleccionada.Estructura = string.Empty;
                region_seleccionada.Index_Hijo_Owner = -1;
                region_seleccionada.Id_Hijo_Owner = 0;
                region_seleccionada.Arquitecto = null;
                region_seleccionada.Referencia_Perfil = string.Empty;
                region_seleccionada.TipoEstructura = Tipo_Estructura.ELE_ARRIBA;
                region_seleccionada = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Ele_Izquierda(object sender, EventArgs e)
        {
            try
            {
                region_seleccionada.Estructura = string.Empty;
                region_seleccionada.Index_Hijo_Owner = -1;
                region_seleccionada.Id_Hijo_Owner = 0;
                region_seleccionada.Arquitecto = null;
                region_seleccionada.Referencia_Perfil = string.Empty;
                region_seleccionada.TipoEstructura = Tipo_Estructura.ELE_IZQUIERDA;
                region_seleccionada = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Ele_Abajo(object sender, EventArgs e)
        {
            try
            {
                region_seleccionada.Estructura = string.Empty;
                region_seleccionada.Index_Hijo_Owner = -1;
                region_seleccionada.Id_Hijo_Owner = 0;
                region_seleccionada.Arquitecto = null;
                region_seleccionada.Referencia_Perfil = string.Empty;
                region_seleccionada.TipoEstructura = Tipo_Estructura.ELE_ABAJO;
                region_seleccionada = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Ele_Derecha(object sender, EventArgs e)
        {
            try
            {
                region_seleccionada.Estructura = string.Empty;
                region_seleccionada.Index_Hijo_Owner = -1;
                region_seleccionada.Id_Hijo_Owner = 0;
                region_seleccionada.Arquitecto = null;
                region_seleccionada.Referencia_Perfil = string.Empty;
                region_seleccionada.TipoEstructura = Tipo_Estructura.ELE_DERECHA;
                region_seleccionada = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        public Bitmap ObtenerImagen()
        {
            try
            {
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(bmp);
                DibujarTodos(regionppal, g);
                return bmp;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void DibujarTodos(RegionEstructuras r, Graphics g)
        {
            try
            {
                r.Construir(g, true);
                for (int i = 0; i < r.Estructuras.Count; i++)
                {
                    DibujarTodos(r.Estructuras[i], g);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private bool Busqueda_bano_Arriba(RegionEstructuras regionBusqueda, int index)
        {
            try
            {                
                for (int i = index; i >= 0; i--)
                {
                    if (i != index)
                    {
                        if (regionBusqueda.Estructuras[i].TipoEstructura == Tipo_Estructura.BASICO)
                        {
                            return true;
                        }
                    }                    
                }
                
                return false;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }        
        private bool Busqueda_bano_Abajo(RegionEstructuras regionBusqueda, int index)
        {
            try
            {                
                for (int i = index; i < regionBusqueda.Estructuras.Count; i++)
                {
                    if (i != index)
                    {
                        if (regionBusqueda.Estructuras[i].TipoEstructura == Tipo_Estructura.BASICO)
                        {
                            return true;
                        }
                    }
                    
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void Desplazamiento_Arriba(RegionEstructuras region, int cur_index, decimal mov_result)
        {
            try
            {
                if (Busqueda_bano_Arriba(region.Owner, cur_index) ||
                    (region != region_seleccionada && region.TipoEstructura == Tipo_Estructura.BASICO))
                {
                    if (region == region_seleccionada || region.TipoEstructura != Tipo_Estructura.BASICO)
                        region.Y += mov_result;

                    if (region.TipoEstructura == Tipo_Estructura.BASICO)
                    {
                        region.Alto -= mov_result * (region == region_seleccionada ? 1 : -1);
                    }
                    if (region.TipoEstructura != Tipo_Estructura.BASICO || region == region_seleccionada)
                    {
                        Desplazamiento_Arriba(region.Owner.Estructuras[cur_index - 1],
                              cur_index - 1, mov_result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void Desplazamiento_Abajo(RegionEstructuras region, int cur_index, decimal mov_result)
        {
            try
            {
                if (Busqueda_bano_Abajo(region.Owner, cur_index) ||
                    (region != region_seleccionada && region.TipoEstructura == Tipo_Estructura.BASICO))
                {
                    if (region.TipoEstructura != Tipo_Estructura.BASICO || region != region_seleccionada)
                    { region.Y += mov_result * (region!=region_seleccionada?1:0); }

                    if (region.TipoEstructura == Tipo_Estructura.BASICO)
                    { region.Alto += mov_result * (region == region_seleccionada ? 1 : -1); }

                    if (region.TipoEstructura != Tipo_Estructura.BASICO || region == region_seleccionada)
                    {
                        Desplazamiento_Abajo(region.Owner.Estructuras[cur_index + 1],
                              cur_index + 1, mov_result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void Desplazamiento_Izquierda(RegionEstructuras region, int cur_index, decimal mov_result)
        {
            try
            {
                if (Busqueda_bano_Arriba(region_seleccionada.Owner, cur_index) ||
                    (region != region_seleccionada && region.TipoEstructura == Tipo_Estructura.BASICO))
                {
                    if (region == region_seleccionada || region.TipoEstructura != Tipo_Estructura.BASICO)
                        region.X += mov_result;

                    if (region.TipoEstructura == Tipo_Estructura.BASICO)
                    {
                        region.Ancho -= mov_result * (region == region_seleccionada ? 1 : -1);
                    }
                    if (region.TipoEstructura != Tipo_Estructura.BASICO || region == region_seleccionada)
                    {
                        Desplazamiento_Izquierda(region.Owner.Estructuras[cur_index - 1],
                              cur_index - 1, mov_result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }        
        private void Desplazamiento_Derecha(RegionEstructuras region, int cur_index, decimal mov_result)
        {
            try
            {
                if (Busqueda_bano_Abajo(region.Owner, cur_index) ||
                    (region != region_seleccionada && region.TipoEstructura == Tipo_Estructura.BASICO))
                {
                    if (region.TipoEstructura != Tipo_Estructura.BASICO || region != region_seleccionada)
                    { region.X += mov_result * (region != region_seleccionada ? 1 : 0); }

                    if (region.TipoEstructura == Tipo_Estructura.BASICO)
                    { region.Ancho += mov_result * (region == region_seleccionada ? 1 : -1); }

                    if (region.TipoEstructura != Tipo_Estructura.BASICO || region == region_seleccionada)
                    {
                        Desplazamiento_Derecha(region.Owner.Estructuras[cur_index + 1],
                              cur_index + 1, mov_result);
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void AcomodacionInternaRegion(RegionEstructuras region, decimal mov_result, int tipo_movimiento)
        {
            try
            {
                for (int i = 0; i < region.Estructuras.Count; i++) {
                    switch (tipo_movimiento)
                    {
                        case 1: //ARRIBA
                            {
                                if (region.Estructuras.Count - 1 > i)
                                {
                                    if (region.Estructuras[i].TipoEstructura == Tipo_Estructura.BASICO)
                                    { region.Estructuras[i].Alto += mov_result;  }
                                    else
                                    { region.Estructuras[i].Y += mov_result; }
                                }
                                break;
                            }
                        case 2://IZQUIERDA
                            {
                                if (region.Estructuras.Count - 1 > i)
                                {
                                    if (region.Estructuras[i].TipoEstructura == Tipo_Estructura.BASICO)
                                    { region.Estructuras[i].Ancho += mov_result; }
                                    else
                                    { region.Estructuras[i].X += mov_result; }
                                }
                                break;
                            }
                        case 3: // ABAJO
                            {
                                if (region.Estructuras.Count-1 > i)
                                {
                                    if (region.Estructuras[i].TipoEstructura == Tipo_Estructura.BASICO)
                                    {
                                        region.Estructuras[i].Y += mov_result;
                                        region.Estructuras[i].Alto -= mov_result;                                        
                                    }
                                    else
                                    {
                                        region.Estructuras[i].Y -= mov_result;
                                    }
                                }
                                break;
                            }
                        default: //DERECHA
                            {
                                if (region.Estructuras.Count - 1 > i)
                                {
                                    if (region.Estructuras[i].TipoEstructura == Tipo_Estructura.BASICO)
                                    {
                                        region.Estructuras[i].X += mov_result;
                                        region.Estructuras[i].Ancho -= mov_result;  }
                                    else
                                    {
                                        region.Estructuras[i].X += mov_result;
                                    }
                                }
                                break;
                            }
                    }
                    AcomodacionInternaRegion(region.Estructuras[i], mov_result, tipo_movimiento);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void ReorganizarconMovimientoArriba(RegionEstructuras reg)
        {
            try
            {
                int sel_ind = region_seleccionada.Owner.Estructuras.IndexOf(reg);
                RegionEstructuras owner = region_seleccionada.Owner;
                for (int i = sel_ind - 1; i >= 0; i--)
                {
                    RegionEstructuras r = owner.Estructuras[i];
                    if (r.TipoEstructura == Tipo_Estructura.BASICO)
                    {
                        r.Alto = owner.Estructuras[i + 1].Y - r.Y;
                        break;
                    }
                    else
                    {
                        r.Y = owner.Estructuras[i + 1].Y - 0.03m;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void ReorganizarconMovimientoAbajo(RegionEstructuras reg)
        {
            try
            {
                if (reg.Owner != null)
                {

                    int sel_ind = region_seleccionada.Owner.Estructuras.IndexOf(reg);
                    if (sel_ind < reg.Owner.Estructuras.Count - 1)
                    {
                        RegionEstructuras nregion = reg.Owner.Estructuras[sel_ind + 1];
                        decimal altooriginal = nregion.Alto;
                        nregion.Alto += nregion.Y - (reg.Y + reg.Alto);
                        nregion.Y = reg.Y + reg.Alto;

                        for (int i = 0; i < nregion.Estructuras.Count; i++)
                        {
                            if (nregion.Estructuras[i].Alto - (nregion.Y - (reg.Y + reg.Alto)) < nregion.Alto)
                            {
                                DividirRegion(nregion, nregion.Estructuras.Count, false);
                                break;
                            }
                            else
                            {
                                nregion.Estructuras[i].Y = nregion.Y;
                                nregion.Estructuras[i].Alto = nregion.Alto;
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
        private void ReorganizarconMovimientoIzquierda(RegionEstructuras reg)
        {
            try
            {
                int sel_ind = region_seleccionada.Owner.Estructuras.IndexOf(reg);
                RegionEstructuras owner = region_seleccionada.Owner;
                for (int i = sel_ind-1; i >= 0; i--)
                {
                    RegionEstructuras r = owner.Estructuras[i];
                    if (r.TipoEstructura == Tipo_Estructura.BASICO)
                    {
                        r.Ancho = owner.Estructuras[i+1].X -  r.X;
                        break;
                    }
                    else
                    {
                        r.X = owner.Estructuras[i + 1].X - 0.03m;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void ReorganizarconMovimientoDerecha(RegionEstructuras reg)
        {
            try
            {
                if (reg.Owner != null)
                {
                    int sel_ind = region_seleccionada.Owner.Estructuras.IndexOf(reg);
                    if (sel_ind < reg.Owner.Estructuras.Count - 1)
                    {
                        RegionEstructuras nregion = reg.Owner.Estructuras[sel_ind + 1];
                        nregion.Ancho += nregion.X - (reg.X + reg.Ancho);
                        nregion.X = reg.X + reg.Ancho;

                        for (int i = 0; i < nregion.Estructuras.Count; i++)
                        {
                            if (nregion.Estructuras[i].Ancho - (nregion.X - (reg.X + reg.Ancho)) < nregion.Ancho)
                            {
                                DividirRegion(nregion, nregion.Estructuras.Count, true);
                                break;
                            }
                            else
                            {
                                nregion.Estructuras[i].X = nregion.X;
                                nregion.Estructuras[i].Ancho = nregion.Ancho;
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
        #endregion
        private void EstructuradorGrafico_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                region_seleccionada = IdentificarRegion(regionppal, e.Location);
                ultimaposcursor = e.Location;
                if (e.Button == MouseButtons.Right && region_seleccionada != null)
                {                    
                    ContextMenuStrip cms = new ContextMenuStrip();                    
                    cms.Items.Add("Eliminar Región", null, EliminarRegion);                    
                    if (region_seleccionada.TipoEstructura == Tipo_Estructura.BASICO)
                    {
                        cms.Items.Add("Dividir Región", null, DividirRegion);
                        cms.Items.Add("Quitar Estructura", null, QuitarEstructura);                       
                    }
                    else
                    {
                        cms.Items.Add("Marcar como pared", null, EsPared);                        
                    }
                    ToolStripMenuItem m = new ToolStripMenuItem("ELES");
                    cms.Items.Add(m);
                    if (region_seleccionada.TipoEstructura != Tipo_Estructura.ELE_ARRIBA)
                    { m.DropDownItems.Add("Marcar como Ele Arriba",null, Ele_Arriba); }
                    if (region_seleccionada.TipoEstructura != Tipo_Estructura.ELE_IZQUIERDA)
                    { m.DropDownItems.Add("Marcar como Ele Izquierda",null, Ele_Izquierda); }
                    if (region_seleccionada.TipoEstructura != Tipo_Estructura.ELE_ABAJO)
                    { m.DropDownItems.Add("Marcar como Ele Abajo",null, Ele_Abajo); }
                    if (region_seleccionada.TipoEstructura != Tipo_Estructura.ELE_DERECHA)
                    { m.DropDownItems.Add("Marcar como Ele Derecha",null, Ele_Derecha); }

                    cms.Items.Add("Limpiar Todo", null, LimpiarRegion);
                    cms.Show(this, e.Location);
                }
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }        
        private void EstructuradorGrafico_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DibujarTodos(regionppal, e.Graphics);
                if (region_seleccionada != null)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.LightBlue)),
                        new RectangleF((float)region_seleccionada.X_relativa, 
                        (float)region_seleccionada.Y_relativa,
                        (float)region_seleccionada.Ancho_Relativo,
                        (float)region_seleccionada.Alto_Relativo));
                    e.Graphics.DrawRectangle(Pens.LightBlue,
                        (float)region_seleccionada.X_relativa,
                        (float)region_seleccionada.Y_relativa,
                        (float)region_seleccionada.Ancho_Relativo,
                        (float)region_seleccionada.Alto_Relativo);                    
                    if(seleccion_region != null)
                    {
                        seleccion_region.Dibujar(e.Graphics);
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);                
            }
        }
        private void EstructuradorGrafico_SizeChanged(object sender, EventArgs e)
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
                regionppal.RegionControlContenedor = new RectangleF(0, 0, this.Width, this.Height);
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);                
            }            
        }
        private void EstructuradorGrafico_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                RegionEstructuras reg = IdentificarRegion(regionppal, this.PointToClient(System.Windows.Forms.Control.MousePosition));
                object[] data = (object[])e.Data.GetData(typeof(object[]).ToString());
                switch (Convert.ToInt32(data[0]))
                {
                    case 1: //DISEÑOS/

                        {
                            //if (reg.Ancho_Real + 1 < Convert.ToDecimal(data[4]) || reg.Ancho_Real - 1 > Convert.ToDecimal(data[4]))
                            //{
                            //    if (MessageBox.Show("El ancho del diseño: " + data[4] + ", no corresponde al ancho de la región: " + reg.Ancho_Real.ToString() + ". ¿Desea que se adapte al tamaño de la region?", "Cambio de medidas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            //    {
                            //        Cambio_Medidas_Eventargs cmedidas = new Cambio_Medidas_Eventargs(Convert.ToInt32(data[3]), Convert.ToInt32(data[2]),
                            //            reg.Ancho_Real, reg.Alto_Real);
                            //        OnCambio_Medidas(cmedidas);
                            //    }
                            //    else
                            //    { return; }
                            //}
                            //if (reg.Alto_Real + 1 < Convert.ToDecimal(data[5]) || reg.Alto_Real - 1 > Convert.ToDecimal(data[5]))
                            //{
                            //    if (MessageBox.Show("El alto del diseño: " + data[5] + ", no corresponde al alto de la región: " + reg.Alto_Real.ToString() + ". ¿Desea que se adapte al tamaño de la region?", "Cambio de medidas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            //    {
                            //        Cambio_Medidas_Eventargs cmedidas = new Cambio_Medidas_Eventargs(Convert.ToInt32(data[3]), Convert.ToInt32(data[2]),
                            //            reg.Ancho_Real, reg.Alto_Real);
                            //        OnCambio_Medidas(cmedidas);
                            //    }
                            //    else
                            //    { return; }
                            //}
                            DXF.Dibujante_DXF.Ventana vn = (DXF.Dibujante_DXF.Ventana)data[1];
                            reg.Arquitecto = vn;
                            reg.Index_Hijo_Owner = Convert.ToInt32(data[2]);
                            reg.Id_Hijo_Owner = Convert.ToInt32(data[3]);
                            reg.Estructura = vn.obtenerDXFPersonalizado();
                            reg.TipoEstructura = Tipo_Estructura.BASICO;
                            reg.Referencia_Perfil = string.Empty;
                            break;
                        }
                    case 3: //PERFILERIA
                        {
                            if (reg.Owner != null)
                            {
                                bool con_estruc = false;
                                bool continuar = true;
                                foreach (var r in reg.Owner.Estructuras)
                                {
                                    if (!string.IsNullOrEmpty(r.Estructura) || r.Arquitecto!=null)
                                    {
                                        con_estruc = true;
                                    }
                                    
                                }
                                if (con_estruc)
                                {
                                    if (MessageBox.Show("Los diseños que estan en la region padre seran eliminados. ¿Desea continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        continuar = true; ;
                                    }
                                    else
                                    {
                                        continuar = false;
                                    }
                                }
                                if (continuar)
                                {
                                    foreach (var r in reg.Owner.Estructuras)
                                    {
                                        r.Estructura = string.Empty;
                                        r.Arquitecto = null;
                                    }
                                    int c = reg.Owner.Estructuras.Where(x => x.TipoEstructura == Tipo_Estructura.BASICO).Count();
                                    if (c >= 2)
                                    {
                                        if (reg.OrientacionEstructura == Orientacion_Estructura.VERTICAL)
                                        {
                                            //if (reg.Ancho_Real + 1 < Convert.ToDecimal(data[5]) || reg.Ancho_Real - 1 > Convert.ToDecimal(data[5]))
                                            //{
                                            //    if (MessageBox.Show("la dimensión del perfil: " + data[5] + ", no corresponde al ancho de la región: " + reg.Ancho_Real.ToString() + ". ¿Desea que se adapte al tamaño de la region ? ", "Cambio de medidas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            //    {
                                            //        Cambio_Medidas_Eventargs cmedidas = new Cambio_Medidas_Eventargs(Convert.ToInt32(data[3]), Convert.ToInt32(data[2]),
                                            //            reg.Ancho_Real, reg.Alto_Real);
                                            //        OnCambio_Medidas(cmedidas);
                                            //    }
                                            //    else
                                            //    { return; }                                                
                                            //}
                                        }
                                        else
                                        {                                            

                                            //if (reg.Alto_Real + 1 < Convert.ToDecimal(data[5]) || reg.Alto_Real - 1 > Convert.ToDecimal(data[5]))
                                            //{
                                            //    if (MessageBox.Show("la dimensión del perfil: " + data[5] + ", no corresponde al alto de la región: " + reg.Ancho_Real.ToString() + ". ¿Desea que se adapte al tamaño de la region ? ", "Cambio de medidas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            //    {
                                            //        Cambio_Medidas_Eventargs cmedidas = new Cambio_Medidas_Eventargs(Convert.ToInt32(data[3]), Convert.ToInt32(data[2]),
                                            //                                                reg.Ancho_Real, reg.Alto_Real);
                                            //        OnCambio_Medidas(cmedidas);                                                    
                                            //    }
                                            //    else
                                            //    { return; }                                                
                                            //}
                                        }
                                        reg.Arquitecto = null;
                                        reg.Referencia_Perfil = Convert.ToString(data[1]);
                                        reg.Index_Hijo_Owner = Convert.ToInt32(data[2]);
                                        reg.Id_Hijo_Owner = Convert.ToInt32(data[3]);
                                        reg.Estructura = string.Empty;
                                        reg.TipoEstructura = Tipo_Estructura.PERFIL;
                                        reg.Acabado_Perfil = Convert.ToString(data[4]);
                                        int sel_ind = reg.Owner.Estructuras.IndexOf(reg);
                                        decimal var_num = 0;
                                        if (reg.OrientacionEstructura == Orientacion_Estructura.HORIZONTAL)
                                        {
                                            var_num = Convert.ToDecimal(data[6]) / reg.Contenedor_General.Ancho_Real;
                                            if (sel_ind == reg.Owner.Estructuras.Count - 1)
                                            {
                                                reg.X += reg.Ancho - var_num; reg.Ancho = var_num;
                                                ReorganizarconMovimientoIzquierda(reg);
                                            }
                                            else
                                            {
                                                reg.Ancho = var_num; ReorganizarconMovimientoDerecha(reg);
                                            }
                                        }
                                        else
                                        {
                                            var_num = Convert.ToDecimal(data[6]) / reg.Contenedor_General.Alto_Real;
                                            if (sel_ind == reg.Owner.Estructuras.Count - 1)
                                            {
                                                reg.Y += reg.Alto - var_num; reg.Alto = var_num;
                                                ReorganizarconMovimientoArriba(reg);
                                            }
                                            else
                                            {
                                                reg.Alto = var_num; ReorganizarconMovimientoAbajo(reg);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe haber al menos 2 regiones disponible para " +
                                             "agregar mas perfilería");
                                    }
                                }
                            }
                            break; }
                }                
                this.Refresh();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }        
        private void EstructuradorGrafico_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(object[]).ToString()))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void EstructuradorGrafico_MouseDown(object sender, MouseEventArgs e)
        {            
            try
            {
                if(seleccion_region != null)
                {
                    seleccion_region.SeleccionarPunto(e.Location);
                }
                ultimaPresion = e.Location;
                mousepresed = true;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void EstructuradorGrafico_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (mousepresed)
                {
                    if (seleccion_region != null)
                    {            
                        if(region_seleccionada != regionppal && region_seleccionada != null && region_seleccionada.Owner !=null)
                        {
                            int sel_ind = region_seleccionada.Owner.Estructuras.IndexOf(region_seleccionada);
                            float mov_result = 0;
                            switch (seleccion_region.Ultimo_Seleccion)
                            {                                
                                case Contacto_Punto.ARRIBA:
                                    Desplazamiento_Arriba(region_seleccionada, sel_ind,
                                        (decimal)(e.Location.Y - ultimaPresion.Y) / this.Height);
                                    ultimaPresion = e.Location;
                                    seleccion_region.Region = region_seleccionada;
                                    break;
                                case Contacto_Punto.ABAJO:                                    
                                    Desplazamiento_Abajo(region_seleccionada, sel_ind,
                                        (decimal)(e.Location.Y - ultimaPresion.Y) / this.Height);
                                    ultimaPresion = e.Location;
                                    seleccion_region.Region = region_seleccionada;
                                    break;
                                case Contacto_Punto.DERECHA:
                                    mov_result = (e.Location.X - ultimaPresion.X) / this.Width;
                                    Desplazamiento_Derecha(region_seleccionada,sel_ind, 
                                        (decimal)(e.Location.X - ultimaPresion.X) / this.Width);                      
                                    ultimaPresion = e.Location;
                                    seleccion_region.Region = region_seleccionada;
                                    break;
                                case Contacto_Punto.IZQUIERDA:                                    
                                    Desplazamiento_Izquierda(region_seleccionada,sel_ind, 
                                        (decimal)(e.Location.X - ultimaPresion.X) / this.Width);
                                    ultimaPresion = e.Location;
                                    seleccion_region.Region = region_seleccionada;
                                    break;
                                default:
                                    break;
                            }
                            this.Refresh();
                        }                        
                    }
                }
                else
                {
                    #region Cambio de Cursor
                    if (seleccion_region != null)
                    {
                        Contacto_Punto cp = seleccion_region.ReconocimientodePuntos(e.Location);
                        switch (cp)
                        {
                            case Contacto_Punto.ARRIBA:
                            case Contacto_Punto.ABAJO:
                                this.Cursor = Cursors.SizeNS;
                                break;

                            case Contacto_Punto.DERECHA:
                            case Contacto_Punto.IZQUIERDA:
                                this.Cursor = Cursors.SizeWE;
                                break;
                            default:
                                this.Cursor = Cursors.Default;
                                break;
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
        private void EstructuradorGrafico_MouseUp(object sender, MouseEventArgs e)
        {            
            try
            {
                mousepresed = false;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
