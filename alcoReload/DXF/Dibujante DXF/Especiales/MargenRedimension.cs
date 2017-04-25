using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace DXF.Dibujante_DXF.Especiales
{
    public class MargenRedimension
    {
        #region Variables
        private List<ComponenteVentana> componentes;
        private RectangleF region_seleccionada;
        private RectangleF recleft;
        private RectangleF recpoint1;
        private RectangleF rectop;
        private RectangleF recpoint2;
        private RectangleF recright;
        private RectangleF recpoint3;
        private RectangleF recbottom;
        private RectangleF recpoint4;
        private RectangleF reccentral;
        private RectangleF recrotador;
        #endregion

        #region Constructor
        public MargenRedimension(List<ComponenteVentana> componentes)
        {
            this.componentes = componentes;
            RedefinirPuntos();
        }
        #endregion

        #region Propiedades
        //public ComponenteVentana Componente
        //{
        //    get
        //    { return micomponente; }
        //    set
        //    { micomponente = value; }
        //}

        #endregion
        public RectangleF ObtenerRegionMultiple()
        {
            List<float> xs = new List<float>();
            List<float> ys = new List<float>();
            for (int i = 0; i < componentes.Count; i++)
            {
                xs.AddRange(new float[] { componentes[i].Punto1.X, componentes[i].Punto2.X,
                    componentes[i].Punto3.X, componentes[i].Punto4.X });
                ys.AddRange(new float[] { componentes[i].Punto1.Y, componentes[i].Punto2.Y,
                    componentes[i].Punto3.Y, componentes[i].Punto4.Y });
            }
            return new RectangleF(xs.Min(), ys.Min(), xs.Max() - xs.Min(), ys.Max() - ys.Min());
        }
        public void RedefinirPuntos()
        {
            if (componentes.Count > 1)
            {
                region_seleccionada = ObtenerRegionMultiple();
            }
            else
            {
                region_seleccionada = componentes[0].RegionExterna;
            }
            region_seleccionada.X -= 5; region_seleccionada.Y -= 5;
            region_seleccionada.Width += 10; region_seleccionada.Height += 10;
            float midX = region_seleccionada.X + (region_seleccionada.Width / 2);
            float midY = region_seleccionada.Y + (region_seleccionada.Height / 2);
            if (componentes.Count == 1)
            {                
                ComponenteVentana componente = componentes[0];
                PointF p1 = new PointF((componente.Punto1.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                    (componente.Punto1.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);
                PointF p2 = new PointF((componente.Punto2.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                        (componente.Punto2.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);
                PointF p3 = new PointF((componente.Punto3.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                    (componente.Punto3.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);
                PointF p4 = new PointF((componente.Punto4.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                    (componente.Punto4.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);
                if (componente.GetType() == typeof(Cota) || componente.GetType() == typeof(Linea) ||
                    componente.GetType() == typeof(Flecha))
                {
                    recpoint1 = new RectangleF(p1.X - 4, p1.Y - 4, 8F, 8F);
                    recpoint3 = new RectangleF(p3.X - 4, p3.Y - 4, 8F, 8F);
                }
                else if (componente.GetType() == typeof(Texto))
                {
                    recrotador = new RectangleF(region_seleccionada.X + region_seleccionada.Width, region_seleccionada.Y - 5,
                        10F, 10F);
                }
                else if (componente.GetType() == typeof(Ele))
                {
                    
                    rectop = new RectangleF(midX - 4, region_seleccionada.Y - 4, 8F, 8F);
                    recleft = new RectangleF(region_seleccionada.X - 4, midY - 4, 8F, 8F);
                    recright = new RectangleF(region_seleccionada.X + region_seleccionada.Width - 4, midY - 4, 8F, 8F);
                    recbottom = new RectangleF(midX, region_seleccionada.Y + region_seleccionada.Height - 4, 8F, 8F);
                    recrotador = new RectangleF(region_seleccionada.X + region_seleccionada.Width + 5, region_seleccionada.Y - 10,
                                            10F, 10F);
                }
                else if (componente.GetType() == typeof(Arco))
                {
                    recpoint1 = new RectangleF(p1.X - 4, p1.Y - 4, 8F, 8F);
                    recpoint3 = new RectangleF(p3.X - 4, p3.Y - 4, 8F, 8F);
                    rectop = new RectangleF(midX - 4, region_seleccionada.Y - 4, 8F, 8F);
                    recleft = new RectangleF(region_seleccionada.X - 4, midY - 4, 8F, 8F);
                    recright = new RectangleF(region_seleccionada.X + region_seleccionada.Width - 4, midY - 4, 8F, 8F);
                    recbottom = new RectangleF(midX, region_seleccionada.Y + region_seleccionada.Height - 4, 8F, 8F);
                    recrotador = new RectangleF(region_seleccionada.X + region_seleccionada.Width + 5, region_seleccionada.Y - 10,
                        10F, 10F);
                }
                else
                {
                    rectop = new RectangleF(midX - 4, region_seleccionada.Y - 4, 8F, 8F);
                    recleft = new RectangleF(region_seleccionada.X - 4, midY - 4, 8F, 8F);
                    recright = new RectangleF(region_seleccionada.X + region_seleccionada.Width - 4, midY - 4, 8F, 8F);
                    recbottom = new RectangleF(midX, region_seleccionada.Y + region_seleccionada.Height - 4, 8F, 8F);
                    recpoint1 = new RectangleF(p1.X - 4, p1.Y - 4, 8F, 8F);
                    recpoint2 = new RectangleF(p2.X - 4, p2.Y - 4, 8F, 8F);
                    recpoint3 = new RectangleF(p3.X - 4, p3.Y - 4, 8F, 8F);
                    recpoint4 = new RectangleF(p4.X - 4, p4.Y - 4, 8F, 8F);
                    recrotador = new RectangleF(region_seleccionada.X + region_seleccionada.Width + 5, region_seleccionada.Y - 10,
                                            10F, 10F);
                }                
            }
            reccentral = new RectangleF(region_seleccionada.X + (region_seleccionada.Width / 2) - 5,
                    region_seleccionada.Y + (region_seleccionada.Height / 2) -5, 10F, 10F);

        }
        public Click_Redimension empezarRedimension(float x, float y)
        {
            try
            {
                if (componentes.Count == 1)
                {
                    ComponenteVentana componente = componentes[0];
                    #region Puntos
                    PointF p1 = new PointF((componente.Punto1.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                        (componente.Punto1.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);
                    PointF p2 = new PointF((componente.Punto2.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                        (componente.Punto2.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);

                    PointF p3 = new PointF((componente.Punto3.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                        (componente.Punto3.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);
                    PointF p4 = new PointF((componente.Punto4.X * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[0],
                        (componente.Punto4.Y * componente.Owner.zoom_factor) + componente.Owner.traslacion_factor[1]);
                    #endregion
                    #region Izquierda
                    if (recleft != null)
                    {
                        if (recleft.Contains(x, y))
                        {
                            if (recleft.Contains(p1.X-4, y) || recleft.Contains(p2.X-4, y))
                            {
                                return Click_Redimension.IZQUIERDA;
                            }
                            else
                            {
                                return Click_Redimension.DERECHA;
                            }
                        }
                    }
                    #endregion
                    #region Punto 1
                    if (recpoint1 != null)
                    {
                        if (recpoint1.Contains(x, y))
                        {
                            return Click_Redimension.PUNTO1;
                        }
                    }
                    #endregion
                    #region Arriba
                    if (rectop != null)
                    {
                        if (rectop.Contains(x, y))
                        {
                            if (rectop.Contains(x, p1.Y - 4) || rectop.Contains(x, p4.Y - 4))
                            {
                                return Click_Redimension.ARRIBA;
                            }
                            else
                            {
                                return Click_Redimension.ABAJO;
                            }
                        }
                    }
                    #endregion
                    #region Punto 2
                    if (recpoint2 != null)
                    {
                        if (recpoint2.Contains(x, y))
                        {
                            return Click_Redimension.PUNTO2;
                        }
                    }
                    #endregion
                    #region Derecha
                    if (recright != null)
                    {
                        if (recright.Contains(x, y))
                        {
                            if (recright.Contains(p3.X +4, y) || recright.Contains(p4.X + 4, y))
                            {
                                return Click_Redimension.DERECHA;
                            }
                            else
                            {
                                return Click_Redimension.IZQUIERDA;
                            }
                        }
                    }
                    #endregion
                    #region Punto 3
                    if (recpoint3 != null)
                    {
                        if (recpoint3.Contains(x, y))
                        {
                            return Click_Redimension.PUNTO3;
                        }
                    }
                    #endregion
                    #region Abajo
                    if (recbottom != null)
                    {
                        if (recbottom.Contains(x, y))
                        {
                            if (recbottom.Contains(x, p1.Y + 4) || recbottom.Contains(x, p4.Y + 4))
                            {
                                return Click_Redimension.ARRIBA;
                            }
                            else
                            {
                                return Click_Redimension.ABAJO;
                            }
                        }
                    }

                    #endregion
                    #region Punto 4
                    if (recpoint4 != null)
                    {
                        if (recpoint4.Contains(x, y))
                        {
                            return Click_Redimension.PUNTO4;
                        }
                    }
                    #endregion
                }

                if (reccentral != null)
                { if (reccentral.Contains(x, y)) return Click_Redimension.CENTRAL; }
                if (recrotador != null)
                { if (recrotador.Contains(x, y)) return Click_Redimension.ROTADOR; }
                return Click_Redimension.NINGUNA;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void Dibujar(Graphics g)
        {
            try
            {
                Pen lapiz = new Pen(new SolidBrush(Color.Black));
                lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(lapiz, region_seleccionada.X, region_seleccionada.Y,
                    region_seleccionada.Width, region_seleccionada.Height);                
                if (recleft != null)
                {
                    g.FillRectangle(Brushes.Green, recleft);
                    g.DrawRectangle(Pens.Gray, recleft.X, recleft.Y, recleft.Width, recleft.Height);
                }
                if (rectop != null)
                {
                    g.FillRectangle(Brushes.Green, rectop);
                    g.DrawRectangle(Pens.Gray, rectop.X, rectop.Y, rectop.Width, rectop.Height);
                }
                if (recright != null)
                {
                    g.FillRectangle(Brushes.Green, recright);
                    g.DrawRectangle(Pens.Gray, recright.X, recright.Y, recright.Width, recright.Height);
                }
                if (recbottom != null)
                {
                    g.FillRectangle(Brushes.Green, recbottom);
                    g.DrawRectangle(Pens.Gray, recbottom.X, recbottom.Y, recbottom.Width, recbottom.Height);
                }

                if (recpoint1 != null)
                {
                    g.FillRectangle(Brushes.Blue, recpoint1);
                    g.DrawString("1", new Font("Calibri", 5), Brushes.Black, recpoint1);
                    g.DrawRectangle(Pens.Gray, recpoint1.X, recpoint1.Y, recpoint1.Width, recpoint1.Height);
                }
                if (recpoint2 != null)
                {
                    g.FillRectangle(Brushes.Blue, recpoint2);
                    g.DrawString("2", new Font("Calibri", 5), Brushes.Black, recpoint2);
                    g.DrawRectangle(Pens.Gray, recpoint2.X, recpoint2.Y, recpoint2.Width, recpoint2.Height);
                }
                if (recpoint3 != null)
                {
                    g.FillRectangle(Brushes.Blue, recpoint3);
                    g.DrawString("3", new Font("Calibri", 5), Brushes.Black, recpoint3);
                    g.DrawRectangle(Pens.Gray, recpoint3.X, recpoint3.Y, recpoint3.Width, recpoint3.Height);
                }
                if (recpoint4 != null)
                {
                    g.FillRectangle(Brushes.Blue, recpoint4);
                    g.DrawString("4", new Font("Calibri", 5), Brushes.Black, recpoint4);
                    g.DrawRectangle(Pens.Gray, recpoint4.X, recpoint4.Y, recpoint4.Width, recpoint4.Height);
                }
                if (reccentral != null)
                {
                    g.FillEllipse(Brushes.Red, reccentral);
                    g.DrawEllipse(Pens.Gray, reccentral.X, reccentral.Y, reccentral.Width, reccentral.Height);
                }
                if (recrotador != null)
                {
                    g.FillEllipse(Brushes.Red, recrotador);
                    g.DrawEllipse(Pens.Gray, recrotador.X, recrotador.Y, recrotador.Width, recrotador.Height);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

    }
}
