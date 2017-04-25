using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class BarradeProgresoPersonalizada : UserControl
    {
        #region Constantes
        private const int INTERVALO_PREDETERMINADO = 60;
        private readonly Color COLOR_TICK_PREDETERMINADO = Color.FromArgb(58, 58, 58);
        private const int ANCHO_TICK = 2;
        private const int MINIMO_RADIO_INTERNO = 4;
        private const int MINIMO_RADIO_EXTERNO = 8;
        private Size TAMANIO_PREDETERMINADO = new Size(28, 28);
        private const int ANCHO_MINIMO_LAPIZ = 2;
        private const float FACTOR_RADIO_INTERNO = 0.175F;
        private const float FACTOR_RADIO_EXTERNO = 0.3125F;
        #endregion
        #region Variables
        private int intervalo;
        private string proceso;
        private float porcentajeEjecucion =0;
        Pen lapiz = null;
        PointF puntocentral = new PointF();
        int radiointerno = 0;
        int radioexterno = 0;
        int alphainicial = 0;
        int cantidadradios = 0;
        int cambioenalpha = 0;
        int limiteinferiorenalfa = 0;
        bool ShowPorcentaje = false;
        float anguloinicial = 0;
        float incrementoangular = 0;
        Direction direccionderotacion;
        System.Timers.Timer timer = null;
        List<Radio> listaradios = null;
        #endregion
        #region Constructor
        public BarradeProgresoPersonalizada()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            this.TickColor = COLOR_TICK_PREDETERMINADO;
            this.MinimumSize = TAMANIO_PREDETERMINADO;
            this.Intervalo = INTERVALO_PREDETERMINADO;
            this.AnguloInicial = 30;
            cantidadradios = 12;
            alphainicial = 255;
            limiteinferiorenalfa = 15;
            lapiz = new Pen(TickColor, ANCHO_TICK);
            lapiz.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            lapiz.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.DireccionRotativa = Direction.MANECILLASRELOJ;
            CalcularRadios();
            timer = new System.Timers.Timer(this.Intervalo);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerElapsed);
            CentrarAlContenedor();
            lbPorcentaje.Visible = ShowPorcentaje;
        }
        #endregion
        #region Enums

        public enum Direction
        {
            MANECILLASRELOJ = 0,
            CONTRAMANECILLASRELOJ = 1
        }

        #endregion
        #region Estructuras de control

        struct Radio
        {
            public PointF StartPoint;
            public PointF EndPoint;

            public Radio(PointF pt1, PointF pt2)
            {
                StartPoint = pt1;
                EndPoint = pt2;
            }
        }

        #endregion
        #region Propiedades
        public bool showPorcentaje
        {
            get {return ShowPorcentaje; }
            set {lbPorcentaje.Visible=value; }
        }
        /// <summary>
        /// Time interval for each tick.
        /// </summary>
        public int Intervalo
        {
            get
            {
                return intervalo;
            }
            set
            {
                if (value > 0)
                {
                    intervalo = value;
                }
                else
                {
                    intervalo = INTERVALO_PREDETERMINADO;
                }
            }
        }

        public Color TickColor { get; set; }

        public Direction DireccionRotativa
        {
            get
            {
                return direccionderotacion;
            }
            set
            {
                direccionderotacion = value;
                CalcularRadios();
            }
        }

        public float AnguloInicial
        {
            get
            {
                return anguloinicial;
            }
            set
            {
                anguloinicial = value;
                CalcularAlpha();
            }
        }

        /// <summary>
        /// Proceso actual en ejecución
        /// </summary>
        public string ProcesoActual
        {
            get
            {
                return proceso;
            }
            set
            {
                this.LbProcess.Text = value + "...";
                this.proceso = value;
            }
        }
        public float PorcentajeEjecucion
        {
            get {
                return porcentajeEjecucion;
            }
            set {
                this.lbPorcentaje.Text = Math.Round(value, 2).ToString() + "%";
                CalcularPosicionPorcentaje();
            }
        }

        #endregion
        #region Procedimientos
        private void CalcularRadios()
        {
            CheckForIllegalCrossThreadCalls = true;
            listaradios = new List<Radio>();
            incrementoangular = (360 / (float)cantidadradios);
            cambioenalpha = (int)((255 - limiteinferiorenalfa) / cantidadradios);
            int ancho = (this.Width < this.Height) ? this.Width : this.Height;
            puntocentral = new PointF(this.Width / 2, this.Height / 2);
            lapiz.Width = (int)(ancho / 15);
            if (lapiz.Width < ANCHO_MINIMO_LAPIZ) lapiz.Width = ANCHO_MINIMO_LAPIZ;
            radiointerno = (int)(ancho * FACTOR_RADIO_INTERNO);
            if (radiointerno < MINIMO_RADIO_INTERNO) radiointerno = MINIMO_RADIO_INTERNO;
            radioexterno = (int)(ancho * FACTOR_RADIO_EXTERNO);
            if (radioexterno < MINIMO_RADIO_EXTERNO) radioexterno = MINIMO_RADIO_EXTERNO;
            float angulo = 0;
            for (int i = 0; i < cantidadradios; i++)
            {
                PointF pt1 = new PointF(radiointerno * (float)Math.Cos(ConvertirGradosaRadianes(angulo)) + puntocentral.X,
                    radiointerno * (float)Math.Sin(ConvertirGradosaRadianes(angulo)) + puntocentral.Y);
                PointF pt2 = new PointF(radioexterno * (float)Math.Cos(ConvertirGradosaRadianes(angulo)) + puntocentral.X,
                    radioexterno * (float)Math.Sin(ConvertirGradosaRadianes(angulo)) + puntocentral.Y);
                Radio radio = new Radio(pt1, pt2);
                listaradios.Add(radio);
                if (direccionderotacion == Direction.MANECILLASRELOJ) { angulo -= incrementoangular; }
                else if (direccionderotacion == Direction.CONTRAMANECILLASRELOJ) { angulo += incrementoangular; }
            }
        }
        private void CalcularAlpha()
        {
            if (direccionderotacion == Direction.MANECILLASRELOJ)
            {
                if (anguloinicial >= 0)
                {
                    alphainicial = 255 - (((int)((anguloinicial % 360) / incrementoangular) + 1) * cambioenalpha);
                }
                else
                {
                    alphainicial = 255 - (((int)((360 + (anguloinicial % 360)) / incrementoangular) + 1) * cambioenalpha);
                }
            }
            else if (direccionderotacion == Direction.CONTRAMANECILLASRELOJ)
            {
                if (anguloinicial >= 0)
                {
                    alphainicial = 255 - (((int)((360 - (anguloinicial % 360)) / incrementoangular) + 1) * cambioenalpha);
                }
                else
                {
                    alphainicial = 255 - (((int)(((360 - anguloinicial) % 360) / incrementoangular) + 1) * cambioenalpha);
                }
            }
        }
        private void CalcularPosicionPorcentaje()
        {
            try
            {
     
                this.lbPorcentaje.Location = new Point((this.Width / 2)+5 , (this.Height / 2)-4 );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void CentrarAlContenedor()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        #endregion
        #region Overrides Eventos

        protected override void OnClientSizeChanged(EventArgs e)
        {
            CalcularRadios();
        }

        void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DireccionRotativa == Direction.MANECILLASRELOJ)
            {
                anguloinicial += incrementoangular;

                if (anguloinicial >= 360)
                    anguloinicial = 0;
            }
            else if (DireccionRotativa == Direction.CONTRAMANECILLASRELOJ)
            {
                anguloinicial -= incrementoangular;

                if (anguloinicial <= -360)
                    anguloinicial = 0;
            }
            alphainicial -= cambioenalpha;
            if (alphainicial < limiteinferiorenalfa)
                alphainicial = 255 - cambioenalpha;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            int alpha = alphainicial;
            Pen fondoCirculo = new Pen(Color.White);            
            Point centro = new Point(this.Width / 2, this.Height / 2);
            for (int i = 0; i < cantidadradios; i++)
            {
                lapiz.Color = Color.FromArgb(alpha, this.TickColor);
                e.Graphics.DrawLine(lapiz, listaradios[i].StartPoint, listaradios[i].EndPoint);
                alpha -= cambioenalpha;
                if (alpha < limiteinferiorenalfa) alpha = 255 - cambioenalpha;
            }
        }
        #endregion
        #region Conversiones

        private double ConvertirGradosaRadianes(float degrees)
        {
            return ((Math.PI / (double)180) * degrees);
        }

        #endregion
        #region Principales

        public void Start()
        {
            if (timer != null)
            {
                timer.Interval = this.Intervalo;
                timer.Enabled = true;
            }
        }

        public void Stop()
        {
            if (timer != null)
            {
                timer.Enabled = false;
            }
        }

        #endregion

    }
}
