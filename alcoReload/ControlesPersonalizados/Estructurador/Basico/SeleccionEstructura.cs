using System.Drawing;
namespace ControlesPersonalizados.Estructurador
{
    public class SeleccionEstructura
    {
        #region Variables
        RegionEstructuras region;
        RectangleF rect_Arriba, rect_Abajo, rect_Derecha, rect_Izquierda;
        Contacto_Punto ultimo_en_seleccion = Contacto_Punto.NINGUNA;
        #endregion


        #region Propiedades
        public Contacto_Punto Ultimo_Seleccion
        {
            get { return ultimo_en_seleccion; }
            set { ultimo_en_seleccion = value; }
        }

        public RegionEstructuras Region
        {
            get { return region; }
            set { region = value;
                Definir_Puntos(value);
            }
        }
        #endregion

        public void Definir_Puntos(RegionEstructuras reg)
        {
            try
            {
                rect_Arriba = new RectangleF((float)reg.X_relativa + (float)(reg.Ancho_Relativo / 2) - 10,
                    (float)reg.Y_relativa - 4, 20, 8);
                rect_Abajo = new RectangleF((float)reg.X_relativa + (float)(reg.Ancho_Relativo / 2) - 10,
                    (float)reg.Y_relativa + (float)reg.Alto_Relativo - 4, 20, 8);
                rect_Izquierda = new RectangleF((float)reg.X_relativa - 4,
                    (float)reg.Y_relativa + (float)(reg.Alto_Relativo / 2) - 10, 8, 20);
                rect_Derecha = new RectangleF((float)reg.X_relativa + (float)reg.Ancho_Relativo - 4,
                    (float)reg.Y_relativa + (float)(reg.Alto_Relativo / 2) - 10, 8, 20);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
        }

        public SeleccionEstructura(RegionEstructuras reg)
        {
            region = reg;
            Definir_Puntos(reg);
        }

        public void SeleccionarPunto(PointF ubicar)
        {
            if (region.Owner != null)
            {
                if (region.X_relativa > region.Owner.X_relativa && region.Alto_Relativo == region.Owner.Alto_Relativo)
                {
                    if (rect_Izquierda.Contains(ubicar))
                    { ultimo_en_seleccion= Contacto_Punto.IZQUIERDA; }
                }
                if (region.Y_relativa > region.Owner.Y_relativa && region.Ancho_Relativo == region.Owner.Ancho_Relativo)
                {
                    if (rect_Arriba.Contains(ubicar))
                    { ultimo_en_seleccion= Contacto_Punto.ARRIBA; }
                }
                if (region.X_relativa + region.Ancho_Relativo < region.Owner.X_relativa + region.Owner.Ancho_Relativo && region.Alto_Relativo == region.Owner.Alto_Relativo)
                {
                    if (rect_Derecha.Contains(ubicar))
                    { ultimo_en_seleccion= Contacto_Punto.DERECHA; }
                }
                if ((region.Y_relativa + region.Alto_Relativo < region.Owner.Y_relativa + region.Owner.Alto_Relativo) && region.Ancho_Relativo == region.Owner.Ancho_Relativo)
                {
                    if (rect_Abajo.Contains(ubicar))
                    { ultimo_en_seleccion= Contacto_Punto.ABAJO; }
                }              
            }            
        }

        public Contacto_Punto ReconocimientodePuntos(PointF ubicar)
        {
            if (region.Owner != null)
            {
                if (region.TipoEstructura == Tipo_Estructura.BASICO)
                {
                    if (region.X_relativa > region.Owner.X_relativa && region.Alto_Relativo == region.Owner.Alto_Relativo)
                    {
                        if (rect_Izquierda.Contains(ubicar))
                        { return Contacto_Punto.IZQUIERDA; }
                    }
                    if (region.Y_relativa > region.Owner.Y_relativa && region.Ancho_Relativo == region.Owner.Ancho_Relativo)
                    {
                        if (rect_Arriba.Contains(ubicar))
                        { return Contacto_Punto.ARRIBA; }
                    }
                    if (region.X_relativa + region.Ancho_Relativo < region.Owner.X_relativa + region.Owner.Ancho_Relativo && region.Alto_Relativo == region.Owner.Alto_Relativo)
                    {
                        if (rect_Derecha.Contains(ubicar))
                        { return Contacto_Punto.DERECHA; }
                    }
                    if ((region.Y_relativa + region.Alto_Relativo < region.Owner.Y_relativa + region.Owner.Alto_Relativo) && region.Ancho_Relativo == region.Owner.Ancho_Relativo)
                    {
                        if (rect_Abajo.Contains(ubicar))
                        { return Contacto_Punto.ABAJO; }
                    }
                }
            }
            return Contacto_Punto.NINGUNA;
        }

        public void Dibujar(Graphics g)
        {
            #region Lápiz
            Pen p = new Pen(Color.Black, 1);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            #endregion
            g.DrawRectangle(p, (float)region.X_relativa, (float)region.Y_relativa,
                (float)region.Ancho_Relativo, (float)region.Alto_Relativo);

            if (region.Owner != null)
            {
                if (region.TipoEstructura == Tipo_Estructura.BASICO )
                {
                    if (region.X_relativa > region.Owner.X_relativa && region.Alto_Relativo == region.Owner.Alto_Relativo)
                    {
                        g.FillRectangle(Brushes.Red, rect_Izquierda);
                        g.DrawRectangle(Pens.LightGray, rect_Izquierda.X, rect_Izquierda.Y,
                            rect_Izquierda.Width, rect_Izquierda.Height);
                    }

                    if (region.Y_relativa > region.Owner.Y_relativa && region.Ancho_Relativo == region.Owner.Ancho_Relativo)
                    {
                        g.FillRectangle(Brushes.Red, rect_Arriba);
                        g.DrawRectangle(Pens.LightGray, rect_Arriba.X, rect_Arriba.Y,
                            rect_Arriba.Width, rect_Arriba.Height);
                    }

                    if (region.X_relativa + region.Ancho_Relativo < region.Owner.X_relativa + region.Owner.Ancho_Relativo && region.Alto_Relativo == region.Owner.Alto_Relativo)
                    {
                        g.FillRectangle(Brushes.Red, rect_Derecha);
                        g.DrawRectangle(Pens.LightGray, rect_Derecha.X, rect_Derecha.Y,
                            rect_Derecha.Width, rect_Derecha.Height);
                    }

                    if ((region.Y_relativa + region.Alto_Relativo < region.Owner.Y_relativa + region.Owner.Alto_Relativo) && region.Ancho_Relativo == region.Owner.Ancho_Relativo)
                    {
                        g.FillRectangle(Brushes.Red, rect_Abajo);
                        g.DrawRectangle(Pens.LightGray, rect_Abajo.X, rect_Abajo.Y,
                            rect_Abajo.Width, rect_Abajo.Height);
                    }
                }                
            }            
        }
    }
}
