using System;
using System.Drawing;

namespace ControlesPersonalizados.Estructurador
{

    public class RegionEstructuras
    {
        #region Variables
        decimal x, y, ancho, alto, ancho_real, alto_real,ancho_diseno,alto_diseno;
        string estructura;
        DXF.Dibujante_DXF.Ventana arquitecto;        
        ConjuntoEstructural estructuras;
        RegionEstructuras owner;
        RegionEstructuras contendor_universal;
        RectangleF regioncontrolcontenedor;
        
        int indexhijoowner = -1;
        int idhijoowner = 0;
        string referencia_perfil = string.Empty;
        string acabado_perfil = "CR";
        internal decimal desfase = 0.0m;
        int nivel = 1;
        Tipo_Estructura tipoestructura = Tipo_Estructura.BASICO;
        Orientacion_Estructura orientacion_estructura = Orientacion_Estructura.ORIGEN;
        #endregion

        #region Constructor
        public RegionEstructuras(RegionEstructuras owner, decimal x, decimal y, decimal ancho, decimal alto)
        {
            this.owner = owner;
            this.x = x;
            this.y = y;
            this.ancho = ancho;
            this.alto = alto;
            estructuras = new ConjuntoEstructural(this);
        }
        public RegionEstructuras(decimal x, decimal y, decimal ancho, decimal alto)
        {
            this.x = x;
            this.y = y;
            this.ancho = ancho;
            this.alto = alto;
            estructuras = new ConjuntoEstructural(this);
        }
        #endregion

        #region Propiedades
        public RegionEstructuras Contenedor_General
        {
            get { return contendor_universal; }
            set { contendor_universal = value; }
        }
        public decimal Ancho_Real
        {
            get {
                if (contendor_universal == null)
                {
                    return ancho_real;
                }
                else
                {
                    return Math.Round(contendor_universal.ancho_real * ancho,0);
                }                
            }
            set {

                ancho_real = value;
            }
        }
        public decimal Alto_Real
        {
            get {
                if (contendor_universal == null)
                {
                    return alto_real;
                }
                else
                {
                    return Math.Round(contendor_universal.alto_real * alto);
                }                
            }
            set {
                alto_real = value;
            }
        }
       
        public decimal X_relativa
        {
            get
            {
                return x * (decimal)regioncontrolcontenedor.Width;
            }
        }        
        public decimal Y_relativa
        {
        get { return y * (decimal)regioncontrolcontenedor.Height; }
        }
        public decimal Ancho_Relativo
        {
        get { return ancho * (decimal)regioncontrolcontenedor.Width; }
        }
        public decimal Alto_Relativo
        {
        get { return alto * (decimal)regioncontrolcontenedor.Height; }
    }
        public decimal X
        {
            get { return x; }
            set { x = value; }
        }
        public decimal Y
        {
            get { return y; }
            set { y = value;}
        }
        public decimal Ancho
        {
            get { return ancho; }
            set { ancho = value;
            }
        }
        public decimal Alto
        {
            get { return alto; }
            set { alto = value;
            }
        }
        public RectangleF RegionControlContenedor
        {
            get { return regioncontrolcontenedor; }
            set
            {
                regioncontrolcontenedor = value;
                for (int i = 0; i < estructuras.Count; i++)
                {
                    estructuras[i].RegionControlContenedor = regioncontrolcontenedor;
                }
            }
        }
        public ConjuntoEstructural Estructuras
        {
            get { return estructuras; }
        }
        public string Estructura
        {
            get { return estructura; }
            set {
                estructura = value;
                if (!string.IsNullOrEmpty(estructura))
                { arquitecto.LeerDxfPersonalizado(estructura); }                
            }
        }
        public RegionEstructuras Contenedor
        {
            get { return owner; }
            set { owner = value; }
        }
        public DXF.Dibujante_DXF.Ventana Arquitecto
        {
            get { return arquitecto; }
            set { arquitecto = value;
                if (arquitecto != null)
                { estructura = arquitecto.obtenerDXFPersonalizado(); }
                else
                { estructura = string.Empty; }                
            }
        }
        public int Index_Hijo_Owner
        {
            get { return indexhijoowner; }
            set { indexhijoowner = value; }
        }
        public int Id_Hijo_Owner
        {
            get { return idhijoowner; }
            set { idhijoowner = value; }
        }
        public string Referencia_Perfil
        {
            get { return referencia_perfil; }
            set { referencia_perfil = value; }
        }
        public RegionEstructuras Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public decimal Desfase
        {
            get { return desfase; }
            set { desfase = value; }
        }
        public int Nivel
        {
            get {
                return nivel;
            }
            set {
                nivel = value;
            }
        }
        public string Acabado_Perfil
        {
            get { return acabado_perfil; }
            set { acabado_perfil = value; }
        }
        public Tipo_Estructura TipoEstructura
        {
            get { return tipoestructura; }
            set { tipoestructura = value; }
        }
        public Orientacion_Estructura OrientacionEstructura
        {
            get { return orientacion_estructura; }
            set { orientacion_estructura = value; }
        }
       
        #endregion

        public void Construir(Graphics g, bool marcadores)
        {
            try
            {
                RectangleF r = new RectangleF((float)X_relativa + (float)desfase,
                                            (float)Y_relativa + (float)desfase,
                                            (float)Ancho_Relativo - 2, (float)Alto_Relativo - 2);
                Pen lapiz = new Pen(Color.Black);
                if (marcadores)
                {
                    g.DrawString(Ancho_Real.ToString() + " | " + Alto_Real.ToString(), 
                        new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point((int)X_relativa, (int)Y_relativa));
                }
                
                switch (tipoestructura)
                {
                    case Tipo_Estructura.BASICO:
                        if (string.IsNullOrEmpty(Convert.ToString(estructura)))
                        {
                            g.DrawImage(new Bitmap(Convert.ToInt32(Ancho_Relativo),
                               Convert.ToInt32(Alto_Relativo)), r);
                        }
                        else
                        {
                            g.DrawImage(arquitecto.ObtenerImagen(), r);
                        }
                        break;
                    case Tipo_Estructura.PERFIL:
                        using (DXF.Dibujante_DXF.Diccionarios dic = new DXF.Dibujante_DXF.Diccionarios())
                        {
                            Color c = dic.ObtenerColorPerfil(acabado_perfil);
                            g.FillRectangle(new SolidBrush(c), r);
                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            Color cinv = Color.FromArgb(255, 255 - c.R, 255 - c.G, 255 - c.B);
                            if (r.Height > r.Width)
                            {
                                sf.FormatFlags = StringFormatFlags.DirectionVertical;
                            }
                            g.DrawString(referencia_perfil, new Font(SystemFonts.CaptionFont.FontFamily, SystemFonts.CaptionFont.Size, FontStyle.Bold),
                                new SolidBrush(cinv), r, sf);
                        }
                        break;
                    case Tipo_Estructura.ELE_ARRIBA:
                        lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawArc(lapiz, r.X, r.Y - 10, r.Width, 20, 0, 180);
                        g.DrawLine(lapiz, r.X, r.Y + r.Height, r.X + r.Width, r.Y + r.Height);                        
                        break;

                    case Tipo_Estructura.ELE_IZQUIERDA:
                        lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawArc(lapiz, r.X - 10, r.Y, 20, r.Height, 270, 180);
                        g.DrawLine(lapiz, r.X + r.Width, r.Y, r.X + r.Width, r.Y + r.Height);
                        break;
                    case Tipo_Estructura.ELE_ABAJO:
                        lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawArc(lapiz, r.X, r.Y + r.Height-10, r.Width, 20, 180, 180);
                        g.DrawLine(lapiz, r.X, r.Y , r.X + r.Width, r.Y);

                        break;
                    case Tipo_Estructura.ELE_DERECHA:
                        lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawArc(lapiz, r.X + r.Width -10, r.Y, 20, r.Height, 90, 180);
                        g.DrawLine(lapiz, r.X , r.Y, r.X, r.Y + r.Height);
                        break;
                }
                if (marcadores)
                {
                    g.DrawRectangle(Pens.Blue, r.X, r.Y, r.Width, r.Height);
                }
                else {
                    if (tipoestructura == Tipo_Estructura.BASICO || tipoestructura == Tipo_Estructura.PERFIL)
                    {
                        g.DrawRectangle(Pens.Black, r.X, r.Y, r.Width, r.Height);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #region Funciones
        public bool Contains(int x, int y)
        {
            return new System.Drawing.RectangleF((float)desfase + (((float)this.x) * regioncontrolcontenedor.Width),
               (float)desfase + ((float)this.y * regioncontrolcontenedor.Height), ((float)ancho * regioncontrolcontenedor.Width) - (float)desfase,
                ((float)alto * regioncontrolcontenedor.Height) - (float)desfase).Contains(x, y);
        }
        public bool Contains(System.Drawing.Point mouseposition)
        {
            return new System.Drawing.RectangleF((float)desfase + (((float)this.x) * regioncontrolcontenedor.Width),
               (float)desfase + ((float)this.y * regioncontrolcontenedor.Height), ((float)ancho * regioncontrolcontenedor.Width) - (float)desfase,
                ((float)alto * regioncontrolcontenedor.Height) - (float)desfase).Contains(mouseposition.X, mouseposition.Y);
        }
        private void doDuplicate(RegionEstructuras estBase, RegionEstructuras estDestino, bool conid)
        {
            for(int i=0; i< estBase.Estructuras.Count;i++)
            {
                RegionEstructuras est = new RegionEstructuras(estBase.Estructuras[i].x, estBase.Estructuras[i].y,
                    estBase.Estructuras[i].ancho, estBase.Estructuras[i].alto);
                est.RegionControlContenedor = estBase.Estructuras[i].regioncontrolcontenedor;
                est.Arquitecto = estBase.Estructuras[i].arquitecto;
                est.Estructura = estBase.Estructuras[i].estructura;
                est.Id_Hijo_Owner = conid?estBase.Estructuras[i].idhijoowner:-1;
                est.Index_Hijo_Owner = estBase.Estructuras[i].indexhijoowner;
                est.tipoestructura = estBase.Estructuras[i].tipoestructura;
                est.referencia_perfil = estBase.Estructuras[i].referencia_perfil;
                est.acabado_perfil = estBase.Estructuras[i].acabado_perfil;                
                estDestino.Estructuras.Add(est);
                if (estBase.Estructuras[i].Estructuras.Count > 0)
                {
                    doDuplicate(estBase.Estructuras[i], est, conid);
                }
            }
        }
        public RegionEstructuras Duplicate(bool conid)
        {
            RegionEstructuras est = new RegionEstructuras(x, y, ancho, alto);
            est.RegionControlContenedor = regioncontrolcontenedor;
            est.Arquitecto = arquitecto;
            est.Estructura = estructura;
            est.Id_Hijo_Owner = conid?idhijoowner:-1;
            est.Index_Hijo_Owner =  indexhijoowner;
            est.tipoestructura = tipoestructura;
            est.referencia_perfil = referencia_perfil;
            est.acabado_perfil = acabado_perfil;
            if (owner == null)
            {
                est.Ancho_Real = ancho_real;
                est.Alto_Real = alto_real;
            }
            doDuplicate(this, est, conid);
            return est;
        }
        #endregion
    }
}
