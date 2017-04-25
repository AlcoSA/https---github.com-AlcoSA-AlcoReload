using System.Collections.Generic;
using System.Drawing;

namespace RichTextBoxSintaxHighLight
{
    public class ConfiguracionSintaxis
    {
        #region Variables
        Dictionary<string, Color> listaregistros;
        string identificadorcomentario = string.Empty;
        Color colorcomentarios = Color.Green;
        Color colorcadenas = Color.Maroon;
        Color colornumeros = Color.Black;
        bool comentarioshabilitados = false;
        bool identificacionnumeros = true;
        bool identificacioncadenas = true;
        #endregion

        #region Constructor
        public ConfiguracionSintaxis()
        {
            listaregistros = new Dictionary<string, Color>();
        }
        #endregion

        #region Propiedades

        

        public Dictionary<string, Color> PalabrasClave
        {
            get { return listaregistros; }
        }

        public string Comentario
        {
            get { return identificadorcomentario; }
            set { identificadorcomentario = value; }
        }
        public Color ColorComentarios
        {
            get { return colorcomentarios; }
            set { colorcomentarios = value; }
        }
        public bool ComentariosHabilitados
        {
            get { return comentarioshabilitados; }
            set { comentarioshabilitados = value; }
        }
        public bool IdentificacionNumericaHabilitada
        {
            get { return identificacionnumeros; }
            set { identificacionnumeros = value; }
        }
        public bool IdentificacionCadenas
        {
            get { return identificacioncadenas; }
            set { identificacioncadenas = value; }
        }
        public Color ColorCadenasdeTexto
        {
            get { return colorcadenas; }
            set { colorcadenas = value; }
        }
        public Color ColorNumeros
        {
            get { return colornumeros; }
            set { colornumeros = value; }
        }
        #endregion
    }
}
