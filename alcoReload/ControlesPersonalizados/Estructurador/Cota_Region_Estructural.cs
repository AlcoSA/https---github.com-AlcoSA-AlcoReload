using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ControlesPersonalizados.Estructurador
{
    //[Serializable]
    public class Cota_Region_Estructural
    {
        #region Variables
        RegionEstructuras propietario = null;
        Tipo_Cota orientacion = Tipo_Cota.HORIZONTAL;
        string texto = string.Empty;
        bool habilitado = false;
        #endregion

        #region Constructor
        public Cota_Region_Estructural(RegionEstructuras propietario)
        {
            this.propietario = propietario;
        }
        public Cota_Region_Estructural(RegionEstructuras propietario, Tipo_Cota orientacion, string texto)
        {
            this.propietario = propietario;
            this.orientacion = orientacion;
            this.texto = texto;
        }
        #endregion

        #region Propiedades
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        public RectangleF Region
        {
            get {
                float desf = (propietario.Nivel-1) * 10;
                switch (orientacion)
                {
                    case Tipo_Cota.HORIZONTAL:
                        return new RectangleF((float)(propietario.X_relativa + propietario.desfase),
                            (float)propietario.Y_relativa + desf+4, (float)propietario.Ancho_Relativo, 16);                        
                    case Tipo_Cota.VERTICAL:
                        return new RectangleF((float)propietario.X_relativa + desf +4,
                            (float)propietario.Y_relativa + (float)propietario.desfase, 16,
                            (float)propietario.Alto_Relativo);                        
                    case Tipo_Cota.CENTRAL:
                        Bitmap bmp = new Bitmap(200, 100);
                        Graphics g = Graphics.FromImage(bmp);
                        StringFormat sf = new StringFormat();
                        if (this.propietario.Alto_Relativo > propietario.Ancho_Relativo)
                        { sf.FormatFlags = StringFormatFlags.DirectionVertical;
                            Size s = g.MeasureString(this.texto, new Font("Calibri", 9F), Point.Empty, sf).ToSize();
                            return new RectangleF((float)(propietario.X_relativa + propietario.desfase),
                                (float)propietario.Y_relativa + (float)(propietario.Alto_Relativo / 2),
                                s.Width + 3, s.Height + 3);
                        }
                        else
                        {
                            Size s = g.MeasureString(this.texto, new Font("Calibri", 9F), Point.Empty, sf).ToSize();
                            return new RectangleF((float)propietario.X_relativa + (float)(propietario.Ancho_Relativo / 2),
                                (float)propietario.Y_relativa + (float)propietario.desfase,
                                s.Width + 3, s.Height + 3);
                        }
                        
                        
                        
                }
                return new RectangleF(0, 0, 0, 0);
                
            }
        }
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }
        public Tipo_Cota Orientacion
        {
            get { return orientacion; }            
        }
        public RegionEstructuras Propietario
        {
            get { return propietario; }
        }
        #endregion

        public bool ContienePunto(float x, float y)
        {
            try
            {
                return Region.Contains(x, y);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
                throw;
            }
        }
        public void Dibujar(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen p = new Pen(Brushes.Red, 1F);            
            GraphicsPath start_path = new GraphicsPath();
            start_path.AddLine(new System.Drawing.Point(-5, 0), new System.Drawing.Point(5, 0));
            CustomLineCap c_cap = new CustomLineCap(null, start_path);
            p.EndCap = System.Drawing.Drawing2D.LineCap.Custom;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Custom;
            p.CustomStartCap = c_cap;
            p.CustomEndCap = c_cap;
            float desfCota = 10 * propietario.Nivel;
            float resx = (float)(propietario.X_relativa + (propietario.Ancho_Relativo / 2));
            float resY = (float)(propietario.Y_relativa + (propietario.Alto_Relativo / 2));
            switch (orientacion)
            {
                case Tipo_Cota.HORIZONTAL:
                    g.DrawLine(p, (float)(propietario.X_relativa + 1 + propietario.desfase),
                    (float)propietario.Y_relativa + desfCota,
                    (float)(propietario.X_relativa + propietario.desfase + propietario.Ancho_Relativo) - 5,
                    (float)propietario.Y_relativa + desfCota);
                    g.DrawString(texto, new Font("Calibri", 9F), Brushes.Red, resx,
                        (float)propietario.Y_relativa + desfCota - 1);
                    break;
                case Tipo_Cota.VERTICAL:
                    StringFormat sf = new StringFormat();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    g.DrawLine(p, (float)propietario.X_relativa + desfCota,
                                (float)propietario.Y_relativa + 1 + (float)propietario.desfase,
                                (float)propietario.X_relativa + desfCota,
                                (float)(propietario.Y_relativa + propietario.desfase + propietario.Ancho_Relativo - 5));
                    g.DrawString(texto, new Font("Calibri", 9F), Brushes.Red, (float)propietario.X_relativa + desfCota - 3, resY, sf);
                    break;
                case Tipo_Cota.CENTRAL:
                    StringFormat sfo = new StringFormat();
                    
                    if (this.propietario.Alto_Relativo > propietario.Ancho_Relativo)
                    {
                        sfo.FormatFlags = StringFormatFlags.DirectionVertical;
                        g.DrawString("•" + texto, new Font("Calibri", 9F),
                            Brushes.Red, (float)propietario.X_relativa + (float)propietario.desfase, resY, sfo);
                    }
                    else
                    {
                        g.DrawString("•" + texto, new Font("Calibri", 9F), Brushes.Red,
                            (float)propietario.X_relativa, resY, sfo);
                    }
                    
                    break;
            }
        }
    }
}
