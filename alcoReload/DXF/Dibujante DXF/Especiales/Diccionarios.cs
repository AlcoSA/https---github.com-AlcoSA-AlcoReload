using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace DXF.Dibujante_DXF
{
    public class Diccionarios : IDisposable
    {
        Dictionary<string, Color> dic_acabados;
        Dictionary<string, Color> dic_colores;
        public Diccionarios()
        {
            dic_acabados = new Dictionary<string, Color>();
            dic_acabados.Add("PNM", Color.DarkGray);
            dic_acabados.Add("CR", Color.GhostWhite);
            dic_acabados.Add("NM", Color.Gainsboro);
            dic_acabados.Add("BC", Color.Peru);
            
            dic_acabados.Add("PB", Color.White);
            dic_acabados.Add("PN", Color.Black);
            dic_acabados.Add("PG", Color.DarkKhaki);
            dic_acabados.Add("GP", Color.Olive);            
            dic_acabados.Add("PBA", Color.SaddleBrown);
            dic_acabados.Add("BO", Color.Gray);
            dic_acabados.Add("PE", Color.GhostWhite);

            dic_colores = new Dictionary<string, Color>();
            dic_colores.Add("CL", Color.AliceBlue);
            dic_colores.Add("BR", Color.Khaki);
            dic_colores.Add("AZRF", Color.Azure);
            dic_colores.Add("BRRF", Color.DarkGoldenrod);
            dic_colores.Add("VA", Color.Honeydew);
            dic_colores.Add("VO", Color.LightCyan);
            dic_colores.Add("SG", Color.LightGreen);
            dic_colores.Add("GR", Color.LightSteelBlue);
            dic_colores.Add("AZ", Color.Azure);
            dic_colores.Add("AM", Color.SkyBlue);
            dic_colores.Add("CARF", Color.DeepSkyBlue);
            dic_colores.Add("CA", Color.DarkTurquoise);
            dic_colores.Add("GRRF", Color.WhiteSmoke);
            dic_colores.Add("BG", Color.MediumAquamarine);
            dic_colores.Add("AE", Color.SkyBlue);
            dic_colores.Add("ST450V", Color.SkyBlue);
        }

        public Color ObtenerColorVidrio(string color_vidrio)
        {
            Color color = Color.Transparent;

            if (!dic_colores.TryGetValue(color_vidrio, out color))            
            {
                color = Color.Transparent;
            }
            return color;
        }

        public Color ObtenerColorPerfil(string acabado)
        {
            Color color = Color.Transparent;

            if (!dic_acabados.TryGetValue(acabado, out color))
            {
                color = Color.Transparent;
            }
            return color;
        }

        public void Dispose()
        {
            dic_acabados.Clear();
            dic_colores.Clear();
            dic_acabados = null;
            dic_colores = null;
        }
    }
}
