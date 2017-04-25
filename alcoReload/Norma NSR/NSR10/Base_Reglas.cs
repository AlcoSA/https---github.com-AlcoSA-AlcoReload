using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Norma_NSR.NSR10
{
    public class Base_Reglas
    {
        #region Ubicación Variables

        //_____________
        //|     |     |	|
        //|     |     |	|
        //|     |     |	B
        //|     |     |	|
        //|     |     | |
        //|_____|_____|	|
        //_______L______

        //                      _
        //      / \             |
        //    /     \       _   |
        //  / theta  \      |   |
        ///__)________\ _   |   |
        //|     |     |	|   |   hr
        //|     |     |	|   h   |
        //|     |     |	he  |   |
        //|     |     |	|   |   |
        //|     |     | |   |   |
        //|_____|_____|	|   |   |
        //_______L______        

        #endregion

        #region Variables Entrada
        protected string version = string.Empty;
        protected string elemento = string.Empty;
        protected string localizacion = string.Empty;        
        protected decimal V = 1;
        protected GRUPO_USO grupo_uso = GRUPO_USO.IV;
        protected CATEGORIA_EXPOSICION categoria_exposision = CATEGORIA_EXPOSICION.B;
        protected decimal hr = 0;
        protected decimal he = 0;
        protected decimal L = 0;
        protected decimal B = 0;
        protected TIPO_CUBIERTA tipo_cubierta = TIPO_CUBIERTA.UNA_PENDIENTE;
        protected decimal Kzt = 1;
        protected decimal Kd = 0.85M;
        protected TIPO_EDIFICACION tipo_edificacion = TIPO_EDIFICACION.EDIFICIO_CERRADO;
        protected bool posibilidad_huracan = false;
        protected decimal altura_losas = 3;
        protected COMPONENTE componente = COMPONENTE.VENTANA;
        protected decimal AE = 0;
        protected List<Parametros_Cargas_Viento> lista_cargas_viento = null;
        #endregion

        #region Variables Resultantes

        protected decimal theta = 0;
        #region Comentario Altura Media Cubierta
        //La Altura media de la Cubierta, h, se determina de la siguiente manera:
        //Para edificios con angulo de la cubierta > 10 grados:  h = (hr+he)/2
        //Para edificios con angulo de la cubierta <= 10 grados:  h = he
        protected decimal h = 0;
        #endregion
        protected decimal GCp = 0;

        #region Coeficientes de Presión Externa en Muro
        //FIG.B.6.5-8A - Muros para edificios con h <= 18m

        //Positivo: Zona 4 y 5
        //    (GCp) = 1.0                                  para A <= 0.9 m2
        //   (GCp) = 1.1766-0.1766*logA para  0.9 < A <= 46.5m2
        //    (GCp) = 0.7                                  para A > 46.5m2
        //Negativo: Zona 4
        //    (GCp) = -1.1                                 para A <= 0.9 m2
        //   (GCp) = -1.2766+0.1766*logA para  0.9 < A <= 46.5m2
        //    (GCp) = -0.8                                 para A > 46.5m2
        //Negativo: Zona 5
        //    (GCp) = -1.4                                 para A <= 0.9 m2
        //   (GCp) = -1.7532+0.3532*logA para  0.9 < A <= 46.5m2
        //    (GCp) = -0.8                                 para A > 46.5m2

        //FIG.B.6.5-14 - Muros para edificios con h > 18m

        //Positivo: Zona 4 & 5
        //    (GCp) = 0.9                                  para A <= 1.9 m2
        //   (GCp) = 1.1792-0.2146*logA para  1.9 < A <= 46.5m2
        //    (GCp) = 0.6                                  para A > 46.5m2
        //Negativo: Zona 4
        //    (GCp) = -0.9                                 para A <= 1.9 m2
        //   (GCp) = -1.0861+0.1431*logA para  1.9 < A <= 46.5m2
        //    (GCp) = -0.7                                 para A > 46.5m2
        //Negativo: Zona 5
        //    (GCp) = -1.8                                 para A <= 1.9 m2
        //   (GCp) = -2.5445+0.5723*logA para  1.9 < A <= 46.5m2
        //    (GCp) = -1.0                                 para A > 46.5m2

        protected decimal Gcp_Zona4_pos = 0;
        protected decimal Gcp_Zona4_neg = 0;
        protected decimal Gcp_Zona5_pos = 0;
        protected decimal Gcp_Zona5_neg = 0;
        #endregion

        #region Coeficientes de Presión interna
        //Coeficientes de presión interna, GCpi (Figura B.6.5 - 2)

        //Clasificación del Cerramiento GCpi
        //Edificios Abiertos                                        0.00
        //Edificios Parcialmente Cerrados                           0.55
        //                                                          -0.55
        //Edificios Cerrados                                        0.18
        //                                                          -0.18
        //Notas:
        //1. Los signos positivos y negativos significan presiones y succiones
        //actuando sobre las superficies internas, respectivamente.
        //2. Los valores de GCpi deberán ser utilizados con qz y qh según se
        //especifica en B.6.5.12.
        //3. Se deben considerar dos casos para determinar los requerimientos
        //de la carga crítica para la condición apropiada:
        //(i) Un valor positivo de GCpi aplicado sobre todas las superficies
        //internas.
        //(ii) Un valor negativo de GCpi aplicado sobre todas las superficies
        //internas
        //4. No se tiene en cuenta el factor de reducción de GCpi para edificios
        //de gran volumen, Ri.
        protected decimal GCPi_positivo = 0;
        protected decimal GCPi_negativo = 0;
        #endregion        

        #region Escalares
        //Si  z <= 4m  entonces:  Kz = 2.01*(4/zg)^(2/a) ,  Si  z > 4m entonces:  Kz = 2.01*(z/zg)^(2/a)  (Tabla B.6.5-3, Caso 1a)
        #region Comentario de alpha y zg
        //Constante de Exposición del Terreno(Tabla B.6.5.-2)
        //       Exposición a           alpha       zg(m)
        //              B               7.0         365.8
        //              C               9.5         374.3
        //              D               11.5        213.4
        protected decimal alpha = 7.0M;
        protected decimal zg = 365.8M;
        #endregion
        #region Comentario Kh
        //(Tabla B.6.5-3, Caso 1a)
        protected decimal kh = 0;
        #endregion
        #region Comentario I
        //        Factor de Importancia.I (Cargas de Viento) (Tabla B.6.5-1)                
        //Categoría Regiones no propensas a huracanes, y                Regiones con posibilidades
        //                 regiones con posibilidad de huracanes de de huracanes y V > 45 m/s
        //      V = 40 − 45 m/s
        //I                               0.87                                                                  0.77
        //       II                              1.00                                                                   1.00
        //      III                              1.15                                                                  1.15
        //      IV                               1.15                                                                  1.15                    
        // Nota: Las categorías de los edificios y de las estructuras se listan en la sección A.2.5     
        protected decimal i = 1.15M;
        #endregion
        #region Comentario qh
        //Presión por velocidad: qz = 0.0625*Kz* Kzt*Kd* V 2*I(B.6.5.10, Eq.B.6.5-13)
        protected decimal qh = 0; //Kg/m^2
        #endregion

        #endregion 

        
        protected decimal menor_LoB = 0;
        protected decimal LoB01 = 0;
        protected decimal LoB04h = 0;
        protected decimal LoB004 = 0;
        protected decimal LoB1m = 0;
        protected decimal anchoa = 0;
        #endregion

        #region Propiedades Variables Entrada
        public string Localizacion
        {
            get { return localizacion; }
            set { localizacion = value; }
        }
        public decimal Velocidad_Viento
        {
            get { return V; }
            set { V = value; Calculo_de_parametros_resultantes(); }
        }
        public GRUPO_USO Grupo_Uso
        {
            get { return grupo_uso; }
            set { grupo_uso = value; Calculo_de_parametros_resultantes(); }
        }
        public CATEGORIA_EXPOSICION Categoria_Exposicion
        {
            get { return categoria_exposision; }
            set { categoria_exposision = value; Calculo_de_parametros_resultantes(); }
        }
        public decimal Altura_Caballete
        {
            get { return hr; }
            set { hr = value; Calculo_de_parametros_resultantes(); }
        }
        public decimal Altura_Alero
        {
            get { return he; }
            set { he = value; Calculo_de_parametros_resultantes(); }
        }
        public decimal Ancho_Edificio
        {
            get { return L; }
            set { L = value; Calculo_de_parametros_resultantes(); }
        }
        public decimal Largo_Edificio
        {
            get { return B; }
            set { B = value; Calculo_de_parametros_resultantes(); }
        }
        public TIPO_CUBIERTA Tipo_Cubierta
        {
            get { return tipo_cubierta; }
            set { tipo_cubierta = value; Calculo_de_parametros_resultantes(); }
        }
        public decimal Factor_Topografico
        {
            get { return Kzt; }
            set { Kzt = value; Calculo_de_parametros_resultantes(); }
        }
        public decimal Factor_Direccionalidad
        {
            get { return Kd; }
            set { Kd = value; Calculo_de_parametros_resultantes(); }
        }
        public TIPO_EDIFICACION Tipo_Edificacion
        {
            get { return tipo_edificacion; }
            set { tipo_edificacion = value; Calculo_de_parametros_resultantes(); }
        }
        public bool Posibilidad_Huracan
        {
            get { return posibilidad_huracan; }
            set { posibilidad_huracan = value; Calculo_de_parametros_resultantes(); }
        }
        public COMPONENTE Componente
        {
            get { return componente; }
            set { componente = value; }
        }

        /// <summary>
        /// Esta corresponde al área de la ventana ancho*alto
        /// utilizando el sistema métrico internacional
        /// </summary>
        public decimal Area_Efectiva
        {
            get { return AE; }
            set{ AE = value; Calculo_de_parametros_resultantes(); }
        }
        public decimal AlturaEntreLosas
        {
            get { return altura_losas; }
            set { altura_losas = value; }
        }
        #endregion

        #region Propiedades Variables Resultantes
        public decimal Angulo_Cubierta_theta
        {
            get { return theta; }
        }
        public decimal Altura_Media_Cubierta_h
        {
            get { return h; }
        }
        public decimal Factor_Reduccion_GCp
        {
            get { return GCp; }
        }
        public decimal Coeficiente_Presion_Externa_Zona4_Pos
        {
            get { return Gcp_Zona4_pos; }
        }
        public decimal Coeficiente_Presion_Externa_Zona4_Neg
        {
            get { return Gcp_Zona4_neg; }
        }
        public decimal Coeficiente_Presion_Externa_Zona5_Pos
        {
            get { return Gcp_Zona5_pos; }
        }
        public decimal Coeficiente_Presion_Externa_Zona5_Neg
        {
            get { return Gcp_Zona5_neg; }
        }
        public decimal Coeficiente_Presion_Interna_Pos
        {
            get { return GCPi_positivo; }
        }
        public decimal Coeficiente_Presion_Interna_Neg
        {
            get { return GCPi_negativo; }
        }
        public decimal Alpha
        {
            get { return alpha; }
        }
        public decimal Altura_Nominal_Capa_Atmosferica_zg
        {
            get { return zg; }
        }
        public decimal Coeficiente_exposición_presion_dinamica_Kh
        {
            get { return kh; }
        }
        public decimal Factor_Importancia_I
        {
            get { return i; }
        }
        public decimal Presion_Por_Velocidad_Qh
        {
            get { return qh; }
        }
        public List<Parametros_Cargas_Viento> Tabla_Cargas_Viento
        {
            get { return lista_cargas_viento; }
        }
        #endregion

        #region Constructor

        public Base_Reglas()
        {
        }

        public Base_Reglas(string version,string elemento,decimal velocidad_viento, GRUPO_USO grupo_uso, CATEGORIA_EXPOSICION categoria_expo,
            decimal altura_caballete, decimal altura_alero, decimal ancho_edificio, decimal largo_edificio,
            TIPO_CUBIERTA tipo_cubierta, TIPO_EDIFICACION tipo_edificacion, decimal area_efectiva,decimal altura_losas, decimal factor_topografico = 1,
            decimal factor_direccionalidad = 0.85M, bool posibilidad_huracan = false)
        {
            this.version = version;
            this.elemento = elemento;
            V = velocidad_viento;
            this.grupo_uso = grupo_uso;
            categoria_exposision = categoria_expo;
            hr = altura_caballete;
            he = altura_alero;
            L = ancho_edificio;
            B = largo_edificio;
            this.tipo_cubierta = tipo_cubierta;
            this.tipo_edificacion = tipo_edificacion;
            AE = area_efectiva;
            Kzt = factor_topografico;
            Kd = factor_direccionalidad;
            this.altura_losas = altura_losas;
            this.posibilidad_huracan = posibilidad_huracan;
            Calculo_de_parametros_resultantes();
        }

        #endregion

        public void Calculo_de_parametros_resultantes()
        {
            try
            {
                #region Calculo angulo de la cubierta theta
                if (L > 0)
                {
                    if (tipo_cubierta == TIPO_CUBIERTA.DOS_AGUAS)
                    {
                        theta = Convert.ToDecimal(Math.Atan(Convert.ToDouble((hr - he) / (L / 2))));
                    }
                    else
                    {
                        theta = Convert.ToDecimal(Math.Atan(Convert.ToDouble((hr - he) / L)));
                    }
                }
                #endregion
                #region Calculo altura media de la cubierta h
                if (theta <= 10)
                { h = he; }
                else
                { h = he + ((hr + he) / 2); }
                #endregion
                #region Calculo Factor de Reducción del GCp
                if (h <= 18)
                {
                    if (theta <= 10)
                    { GCp = 0.9M; }
                    else
                    { GCp = 1; }
                }
                #endregion
                #region Calculo Coeficiente de Presión Externa Zona 4-5 Positivo
                if (h <= 18)
                {
                    if (AE <= 0.9M) { Gcp_Zona4_pos = GCp; Gcp_Zona5_pos = Gcp_Zona4_pos; }
                    else if (AE <= 46.5M) { Gcp_Zona4_pos = GCp * (1.1766M - 0.1766M * Convert.ToDecimal(Math.Log10(Convert.ToDouble(AE / 0.0929M)))); Gcp_Zona5_pos = Gcp_Zona4_pos; }
                    else { Gcp_Zona4_pos = GCp * 0.7M; Gcp_Zona5_pos = Gcp_Zona4_pos; }
                }
                else
                {
                    if (AE <= 1.8M) { Gcp_Zona4_pos = 0.9M; Gcp_Zona5_pos = Gcp_Zona4_pos; }
                    else if (AE <= 46.5M) { Gcp_Zona4_pos = 1.1792M - 0.2146M * Convert.ToDecimal(Math.Log10(Convert.ToDouble(AE / 0.0929M))); Gcp_Zona5_pos = Gcp_Zona4_pos; }
                    else { Gcp_Zona4_pos = 0.6M; Gcp_Zona5_pos = Gcp_Zona4_pos; }
                }
                #endregion
                #region Calculo Coeficiente de Presión Externa Zona 4 Negativo
                if (h <= 18)
                {
                    if (AE <= 0.9M) { Gcp_Zona4_neg = GCp * (-1.1M); }
                    else if (AE <= 46.5M) { Gcp_Zona4_neg = GCp * (-1.2766M - 0.1766M * Convert.ToDecimal(Math.Log10(Convert.ToDouble(AE / 0.0929M)))); }
                    else { Gcp_Zona4_neg = GCp * (-0.8M); }
                }
                else
                {
                    if (AE <= 1.8M) { Gcp_Zona4_neg = -0.9M; }
                    else if (AE <= 46.5M) { Gcp_Zona4_neg = -1.0861M + 0.1431M * Convert.ToDecimal(Math.Log10(Convert.ToDouble(AE / 0.0929M))); }
                    else { Gcp_Zona4_neg = -0.7M; }
                }
                #endregion
                #region Calculo Coeficiente de Presión Externa Zona 5 Negativo
                if (h <= 18)
                {
                    if (AE <= 0.9M) { Gcp_Zona5_neg = GCp * (-1.4M); }
                    else if (AE <= 46.5M) { Gcp_Zona5_neg = GCp * (-1.7532M - 0.3532M * Convert.ToDecimal(Math.Log(Convert.ToDouble(AE / 0.929M)))); }
                    else { Gcp_Zona5_neg = GCp * (-0.8M); }
                }
                else
                {
                    if (AE <= 1.8M) { Gcp_Zona5_neg = -1.8M; }
                    else if (AE <= 46.5M) { Gcp_Zona5_neg = -2.5445M - 0.5723M * Convert.ToDecimal(Math.Log(Convert.ToDouble(AE / 0.0929M))); }
                    else { Gcp_Zona5_neg = -1M; }
                }
                #endregion
                #region Calculo Menor de L o B
                menor_LoB = L <= B ? L : B;
                #endregion
                #region Calculo 0.1*(L o B)
                LoB01 = 0.1M * menor_LoB;
                #endregion
                #region Calculo Comparando  0.4*h

                if (h <= 18)
                {
                    if (LoB01 < (0.4M * h)) { LoB04h = LoB01; }
                    else { LoB04h = (0.4M * h); }
                }

                #endregion
                #region Calculo Comparando 0.04 * (L o B)
                if (h <= 18)
                {
                    if (LoB04h >= 0.04M * menor_LoB) { LoB004 = LoB04h; }
                    else { LoB004 = 0.04M * menor_LoB; }
                }
                #endregion
                #region Calculo Comparando con 1m
                if (h <= 18)
                {
                    if (LoB004 >= 1) { LoB1m = LoB004; }
                    else { LoB1m = 1; }
                }
                else
                {
                    if (LoB01 >= 1) { LoB1m = LoB01; }
                    else { LoB1m = 1; }
                }
                #endregion
                #region Calculo 'a'
                anchoa = LoB1m;
                #endregion
                #region Calculo Presión Interna Positiva
                GCPi_positivo = tipo_edificacion == TIPO_EDIFICACION.EDIFICIO_CERRADO ? 0.18M : 0.55M;
                #endregion
                #region Calculo Presión Interna Negativo
                GCPi_negativo = tipo_edificacion == TIPO_EDIFICACION.EDIFICIO_CERRADO ? -0.18M : -0.55M;
                #endregion
                #region Calculo alpha
                switch (categoria_exposision)
                {
                    case CATEGORIA_EXPOSICION.B:
                        {
                            alpha = 7;
                            break;
                        }
                    case CATEGORIA_EXPOSICION.C:
                        {
                            alpha = 9.5M;
                            break;
                        }
                    case CATEGORIA_EXPOSICION.D:
                        {
                            alpha = 11.5M;
                            break;
                        }
                }
                #endregion
                #region Calculo zg
                switch (categoria_exposision)
                {
                    case CATEGORIA_EXPOSICION.B:
                        {
                            zg = 365.8M;
                            break;
                        }
                    case CATEGORIA_EXPOSICION.C:
                        {
                            zg = 274.3M;
                            break;
                        }
                    case CATEGORIA_EXPOSICION.D:
                        {
                            zg = 213.4M;
                            break;
                        }
                }
                #endregion
                #region Calculo Kh
                switch (categoria_exposision)
                {
                    case CATEGORIA_EXPOSICION.B:
                        {
                            if (h < 9)
                            {
                                kh = 2.01M * Convert.ToDecimal(Math.Pow((double)(9 / zg), (double)(2 / alpha)));
                            }
                            else
                            { kh = 2.01M * Convert.ToDecimal(Math.Pow((double)(h / zg), (double)(2 / alpha))); }
                            break;
                        }
                    case CATEGORIA_EXPOSICION.C:
                    case CATEGORIA_EXPOSICION.D:
                        {
                            if (h < 4)
                            {
                                kh = 2.01M * Convert.ToDecimal(Math.Pow((double)(4 / zg), (double)(2 / alpha)));
                            }
                            else
                            { kh = 2.01M * Convert.ToDecimal(Math.Pow((double)(h / zg), (double)(2 / alpha))); }
                            break;
                        }

                }
                #endregion
                #region Calculo I
                switch (grupo_uso)
                {
                    case GRUPO_USO.I:
                        {
                            if (!posibilidad_huracan)
                            {
                                i = 0.87M;
                            }
                            else
                            {
                                if (V <= 45)
                                { i = 0.87M; }
                                else
                                { i = 0.77M; }
                            }
                            break;
                        }
                    case GRUPO_USO.II:
                        {
                            i = 1;
                            break;
                        }
                    case GRUPO_USO.III:
                    case GRUPO_USO.IV:
                        {
                            i = 1.15M;
                            break;
                        }

                }
                #endregion
                #region Calculo qh
                qh = 0.0625M * kh * Kzt * Kd * (V*V) * i;
                #endregion
                CrearTabla();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public List<Parametros_Cargas_Viento> CrearTabla()
        {
            lista_cargas_viento = new List<Parametros_Cargas_Viento>();
            try
            {
                for (decimal z = 0; z <= hr+altura_losas; z += altura_losas)
                {
                    Parametros_Cargas_Viento parametro = new Parametros_Cargas_Viento();
                    #region Calculo Z
                    if (z <= hr)
                    { parametro.Z = z; }
                    else
                    {
                        if (lista_cargas_viento.Where(x => x.Z == z).Count() > 0)
                        { break; }
                        else
                        { parametro.Z = hr; }
                    }
                    #endregion

                    #region Calculo Kz
                    if (h <= 18)
                    { parametro.Kz = kh; }
                    else
                    {
                        if (z <= 9 && categoria_exposision == CATEGORIA_EXPOSICION.B)
                        { parametro.Kz = 0.7M; }
                        else if (z <= 4 && categoria_exposision == CATEGORIA_EXPOSICION.C)
                        { parametro.Kz = 0.85M; }
                        else if (z <= 4 && categoria_exposision == CATEGORIA_EXPOSICION.D)
                        { parametro.Kz = 1.03M; }
                        else
                        {
                            parametro.Kz =2.01m * (decimal)Math.Pow(Convert.ToDouble((z / zg)), Convert.ToDouble(2 / alpha));
                        }
                    }
                    #endregion

                    #region Calculo qz

                    if (h <= 18)
                    { parametro.qZ = qh; }
                    else
                    { parametro.qZ = 0.0625M * parametro.Kz * Kzt * Kd * i * (decimal)Math.Pow((double)V, 2); }

                    #endregion

                    #region Calculo Zona 4 +
                    if (h <= 18)
                    { parametro.Zona_4_Pos = qh * (Gcp_Zona4_pos - GCPi_negativo); }
                    else
                    { parametro.Zona_4_Pos = parametro.qZ * Gcp_Zona4_pos - qh * GCPi_negativo; }
                    #endregion

                    #region Calculo Zona 4 -
                    if (h <= 18)
                    { parametro.Zona_4_Neg = qh * (Gcp_Zona4_neg - GCPi_positivo); }
                    else
                    { parametro.Zona_4_Neg = qh * Gcp_Zona4_neg - qh * GCPi_positivo; }
                    #endregion

                    #region Calculo Zona 5 +
                    if (h <= 18)
                    { parametro.Zona_5_Pos = qh * (Gcp_Zona5_pos - GCPi_negativo); }
                    else
                    { parametro.Zona_5_Pos = parametro.qZ * Gcp_Zona5_pos - qh * GCPi_negativo; }
                    #endregion

                    #region Calculo Zona 5 -
                    if (h <= 18)
                    { parametro.Zona_5_Neg = qh * (Gcp_Zona5_neg - GCPi_positivo); }
                    else
                    { parametro.Zona_5_Neg = qh * Gcp_Zona5_neg - qh * GCPi_positivo; }
                    #endregion

                    lista_cargas_viento.Add(parametro);
                }
                return lista_cargas_viento;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Generando Tabla: " + ex.Message, ex.InnerException);
            }
        }

        public DataSet RetornoparaInforme()
        {
            try
            {
                DataSet ds = new DataSet();
                #region Encabezado
                DataTable tablaencabezado = new DataTable();
                tablaencabezado.Columns.Add("version", typeof(string));
                tablaencabezado.Columns.Add("elemento", typeof(string));
                tablaencabezado.Columns.Add("localizacion", typeof(string));
                tablaencabezado.Columns.Add("velocidad_viento", typeof(decimal));
                tablaencabezado.Columns.Add("grupo_uso", typeof(string));
                tablaencabezado.Columns.Add("categoria_exposicion", typeof(string));
                tablaencabezado.Columns.Add("altura_caballete", typeof(decimal));
                tablaencabezado.Columns.Add("altura_alero", typeof(decimal));
                tablaencabezado.Columns.Add("ancho_edificio", typeof(decimal));
                tablaencabezado.Columns.Add("largo_edificio", typeof(decimal));
                tablaencabezado.Columns.Add("tipo_cubierta", typeof(string));
                tablaencabezado.Columns.Add("factor_topografico", typeof(decimal));
                tablaencabezado.Columns.Add("factor_direccionalidad", typeof(decimal));
                tablaencabezado.Columns.Add("tipo_edificacion", typeof(string));
                tablaencabezado.Columns.Add("posibilidad_huracan", typeof(bool));
                tablaencabezado.Columns.Add("componente", typeof(string));
                tablaencabezado.Columns.Add("area_efectiva", typeof(decimal));
                tablaencabezado.Columns.Add("angulo_cubierta", typeof(decimal));
                tablaencabezado.Columns.Add("altura_media", typeof(decimal));
                tablaencabezado.Columns.Add("GCP_zona4_pos", typeof(decimal));
                tablaencabezado.Columns.Add("GCP_zona4_neg", typeof(decimal));
                tablaencabezado.Columns.Add("GCP_zona5_pos", typeof(decimal));
                tablaencabezado.Columns.Add("GCP_zona5_neg", typeof(decimal));
                tablaencabezado.Columns.Add("GCPi_pos", typeof(decimal));
                tablaencabezado.Columns.Add("GCPi_neg", typeof(decimal));
                tablaencabezado.Columns.Add("alpha", typeof(decimal));
                tablaencabezado.Columns.Add("zg", typeof(decimal));
                tablaencabezado.Columns.Add("kh", typeof(decimal));
                tablaencabezado.Columns.Add("I", typeof(decimal));
                tablaencabezado.Columns.Add("qH", typeof(decimal));
                tablaencabezado.Columns.Add("ancho_a", typeof(decimal));
                Retornos r = new Retornos();
                tablaencabezado.Rows.Add(
                    version,
                    elemento,
                    localizacion,
                    V,
                    r.grupo_uso[(int)grupo_uso-1],
                    r.categoria_expo[(int)categoria_exposision-1],
                    hr,
                    he,
                    L,
                    B,
                    r.tipo_cubierta[(int)tipo_cubierta-1],
                    Kzt, Kd, r.tipo_edificacion[(int)tipo_edificacion-1],
                    posibilidad_huracan, r.componente[(int)componente-1],
                    AE,
                    theta,
                    h,
                    Gcp_Zona4_pos,
                    Gcp_Zona4_neg,
                    Gcp_Zona5_pos,
                    Gcp_Zona5_neg,
                    GCPi_positivo,
                    GCPi_negativo,
                    alpha,
                    zg,
                    kh,
                    i,
                    qh,
                    anchoa);
                #endregion
                #region Tabla Cálculos
                DataTable tablaCalculos = new DataTable();
                tablaCalculos.Columns.Add("z", typeof(decimal));
                tablaCalculos.Columns.Add("Kz", typeof(decimal));
                tablaCalculos.Columns.Add("qZ", typeof(decimal));
                tablaCalculos.Columns.Add("zona4pos", typeof(decimal));
                tablaCalculos.Columns.Add("zona4neg", typeof(decimal));
                tablaCalculos.Columns.Add("zona5pos", typeof(decimal));
                tablaCalculos.Columns.Add("zona5neg", typeof(decimal));
                foreach (Parametros_Cargas_Viento p in lista_cargas_viento)
                {
                    tablaCalculos.Rows.Add(p.Z, p.Kz, p.qZ, p.Zona_4_Pos, p.Zona_4_Neg,
                        p.Zona_5_Pos, p.Zona_5_Neg);
                }
                #endregion
                ds.Tables.Add(tablaencabezado);
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
