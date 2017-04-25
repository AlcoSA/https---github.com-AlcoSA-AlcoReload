using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Norma_NSR.NSR10
{
    public class Calculos_10
    {
        #region Variables Entrada
        string elemento = string.Empty;
        string referencia_perfil = string.Empty;
        Base_Reglas b23;
        Base_Reglas b24;
        decimal lx = 0;
        decimal Zx = 0;
        string localizacion = string.Empty;        
        decimal ancho_ventana =0;        
        decimal alto_ventana = 0;
        CATEGORIA_EXPOSICION rugosidad_terreno = CATEGORIA_EXPOSICION.B;
        PRESIONES_DISEGNO presion_diseño = PRESIONES_DISEGNO.ZONA_4_POSITIVO;
        decimal alto_entre_losas = 0;
        List<Parametros_Tabla_Final_10> lista;
        #endregion

        #region Variables Calculada
        decimal Mrs = 0;
        decimal deltha = 0;
        decimal viento_maximo_B23 = 0;
        decimal viento_maximo_B24 = 0;
        #endregion

        #region Propiedades Entrada
        public decimal Inercia
        {
            get { return lx; }
            set { lx = value; Calculo_de_Parametros(); }
        }
        public decimal Modulo_Seccion
        {
            get { return Zx; }
            set { Zx = value; Calculo_de_Parametros(); }
        }
        public string Localizacion
        {
            get { return localizacion; }
            set { localizacion = value; }
        }
        public decimal Ancho_Ventana
        {
            get { return ancho_ventana; }
            set { ancho_ventana = value; Calculo_de_Parametros(); }
        }
        public decimal Alto_Ventana
        {
            get { return alto_ventana; }
            set { alto_ventana = value; Calculo_de_Parametros(); }
        }
        public CATEGORIA_EXPOSICION Rugosidad_Terreno
        {
            get { return rugosidad_terreno; }
            set { rugosidad_terreno = value; Calculo_de_Parametros(); }
        }
        public PRESIONES_DISEGNO Presion_Diseño
        {
            get { return presion_diseño; }
            set { presion_diseño = value; Calculo_de_Parametros(); }
        }
        #endregion

        #region Propiedades Calculada
        public decimal Momento_Maximo
        {
            get { return Mrs; }            
        }
        public decimal Deflexion_Maxima
        {
            get { return deltha; }            
        }
        public decimal Viento_Maximo_B23
        {
            get { return viento_maximo_B23; }
        }
        public decimal Viento_Maximo_B24
        {
            get { return viento_maximo_B24; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b23"></param>
        /// <param name="b24"></param>
        /// <param name="inercia"></param>
        /// <param name="modulo_seccion"></param>
        /// <param name="ancho_ventana"></param>
        /// <param name="alto_ventana"></param>
        /// <param name="rugosidad_terreno"></param>
        /// <param name="presion_diseño"></param>
        /// <param name="alto_entre_losas"></param>
        public Calculos_10(string elemento, string referencia_perfil, Base_Reglas b23, Base_Reglas b24, decimal inercia, decimal modulo_seccion,
            string  localizacion ,decimal ancho_ventana, decimal alto_ventana, CATEGORIA_EXPOSICION rugosidad_terreno,
            PRESIONES_DISEGNO presion_diseño, decimal alto_entre_losas)
        {
            this.elemento = elemento;
            this.referencia_perfil = referencia_perfil;
            this.b23 = b23;
            this.b24 = b24;
            this.b23.Localizacion = localizacion;
            this.b24.Localizacion = localizacion;
            lx = inercia;
            Zx = modulo_seccion;
            this.localizacion = localizacion;
            this.ancho_ventana = ancho_ventana;
            this.alto_ventana = alto_ventana;
            this.rugosidad_terreno = rugosidad_terreno;
            this.presion_diseño = presion_diseño;
            this.alto_entre_losas = alto_entre_losas;
        }
        #endregion

        public void Calculo_de_Parametros()
        {
            try
            {
                viento_maximo_B23 = b23.Velocidad_Viento * 3600 / 1000;
                viento_maximo_B24 = b24.Velocidad_Viento * 3600 / 1000;
                Mrs = 0.8M * Zx * 1100 / 1000;
                deltha = alto_ventana / 175;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public List<Parametros_Tabla_Final_10> GenerarTabla()
        {
            lista = new List<Parametros_Tabla_Final_10>();
            try
            {                
                for (int i = 0; i < b23.Tabla_Cargas_Viento.Count; i++)
                {
                    Parametros_Tabla_Final_10 parametro = new Parametros_Tabla_Final_10();
                    #region Altura Instalación
                    parametro.Altura_Instalacion = b23.Tabla_Cargas_Viento[i].Z;
                    #endregion
                    #region Presión de diseño B23 - B24
                    switch (presion_diseño)
                    {
                        case PRESIONES_DISEGNO.ZONA_4_POSITIVO:
                            {
                                if (Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_4_Pos) < 40) { parametro.Presion_Diseño_B23 = 40; }
                                else { parametro.Presion_Diseño_B23 = Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_4_Pos); }
                                if (Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_4_Pos) < 40) { parametro.Presion_Diseño_B24 = 40; }
                                else { parametro.Presion_Diseño_B24 = Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_4_Pos); }
                                break;
                            }
                        case PRESIONES_DISEGNO.ZONA_4_NEGATIVO:
                            {
                                if (Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_4_Neg) < 40) { parametro.Presion_Diseño_B23 = 40; }
                                else { parametro.Presion_Diseño_B23 = Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_4_Neg); }
                                if (Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_4_Neg) < 40) { parametro.Presion_Diseño_B24 = 40; }
                                else { parametro.Presion_Diseño_B24 = Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_4_Neg); }
                                break;
                            }
                        case PRESIONES_DISEGNO.ZONA_5_POSITIVO:
                            {
                                if (Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_5_Pos) < 40) { parametro.Presion_Diseño_B23 = 40; }
                                else { parametro.Presion_Diseño_B23 = Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_5_Pos); }
                                if (Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_5_Pos) < 40) { parametro.Presion_Diseño_B24 = 40; }
                                else { parametro.Presion_Diseño_B24 = Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_5_Pos); }
                                break;
                            }
                        case PRESIONES_DISEGNO.ZONA_5_NEGATIVO:
                            {
                                if (Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_5_Neg) < 40) { parametro.Presion_Diseño_B23 = 40; }
                                else { parametro.Presion_Diseño_B23 = Math.Abs(b23.Tabla_Cargas_Viento[i].Zona_5_Neg); }
                                if (Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_5_Neg) < 40) { parametro.Presion_Diseño_B24 = 40; }
                                else { parametro.Presion_Diseño_B24 = Math.Abs(b24.Tabla_Cargas_Viento[i].Zona_5_Neg); }
                                break;
                            }
                    }
                    #endregion
                    #region w
                    parametro.W = ancho_ventana / 1000 * parametro.Presion_Diseño_B23;
                    #endregion
                    #region wu
                    parametro.Wu = ancho_ventana / 1000 * parametro.Presion_Diseño_B24;
                    #endregion
                    #region 0.1*wu
                    parametro.Centesima_de_Wu = 1*parametro.Wu/100;
                    #endregion
                    #region Mu
                    parametro.Mu = parametro.Centesima_de_Wu * (decimal)Math.Pow(Convert.ToDouble((alto_ventana / 10)), 2) / 8;
                    #endregion
                    #region Deflexion servicio
                    parametro.Deflexion_Servicio =((5 * Math.Abs((parametro.W / 100))  * (decimal)Math.Pow((double)(alto_ventana/10),4)) / (384 * 700000 * lx / 10000)) * 10;
                    #endregion
                    #region Resistencia
                    parametro.Resistencia = Mrs  > parametro.Mu;
                    #endregion
                    #region Deflexion
                    parametro.Deflexion = parametro.Deflexion_Servicio < deltha;
                    #endregion
                    lista.Add(parametro);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public DataSet RetornoparaInforme()
        {
            try
            {
                DataSet ds = new DataSet();
                #region Encabezado
                DataTable encabezadoCalculos = new DataTable();
                encabezadoCalculos.Columns.Add("elemento", typeof(string));
                encabezadoCalculos.Columns.Add("referencia_perfil", typeof(string));
                encabezadoCalculos.Columns.Add("inercia", typeof(decimal));
                encabezadoCalculos.Columns.Add("modulo_seccion", typeof(decimal));
                encabezadoCalculos.Columns.Add("momento_maximo", typeof(decimal));
                encabezadoCalculos.Columns.Add("localizacion", typeof(string));
                encabezadoCalculos.Columns.Add("viento_maximo_b23", typeof(decimal));
                encabezadoCalculos.Columns.Add("viento_maximo_b24", typeof(decimal));
                encabezadoCalculos.Columns.Add("ancho_ventana", typeof(decimal));
                encabezadoCalculos.Columns.Add("alto_ventana", typeof(decimal));
                encabezadoCalculos.Columns.Add("deflexion_maxima", typeof(decimal));
                encabezadoCalculos.Columns.Add("rugosidad_terreno", typeof(string));
                encabezadoCalculos.Columns.Add("presion_diseno", typeof(string));
                Retornos r = new Retornos();
                encabezadoCalculos.Rows.Add(elemento, referencia_perfil, lx, Zx, Mrs, localizacion, viento_maximo_B23, viento_maximo_B24,
                    ancho_ventana, alto_ventana, deltha, r.categoria_expo[(int)rugosidad_terreno-1],
                    r.presiones_diseno[(int)presion_diseño-1]);
                #endregion
                #region Tabla Cálculos
                DataTable tablaCalculos = new DataTable();
                tablaCalculos.Columns.Add("altura_instalacion", typeof(decimal));
                tablaCalculos.Columns.Add("presion_b23", typeof(decimal));
                tablaCalculos.Columns.Add("presion_b24", typeof(decimal));
                tablaCalculos.Columns.Add("w", typeof(decimal));
                tablaCalculos.Columns.Add("wu", typeof(decimal));
                tablaCalculos.Columns.Add("wu_centesima", typeof(decimal));
                tablaCalculos.Columns.Add("mu", typeof(decimal));
                tablaCalculos.Columns.Add("deflexion_servicio", typeof(decimal));
                tablaCalculos.Columns.Add("resistencia", typeof(bool));
                tablaCalculos.Columns.Add("deflexion", typeof(bool));
                foreach (Parametros_Tabla_Final_10 p in lista)
                {
                    tablaCalculos.Rows.Add(p.Altura_Instalacion, p.Presion_Diseño_B23, p.Presion_Diseño_B24,
                        p.W, p.Wu, p.Centesima_de_Wu, p.Mu, p.Deflexion_Servicio, p.Resistencia,
                        p.Deflexion);
                }
                #endregion
                ds.Tables.Add(encabezadoCalculos);
                ds.Tables.Add(tablaCalculos);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }


    }
}
