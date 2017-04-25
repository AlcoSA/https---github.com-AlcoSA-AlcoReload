using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Multiusos
{
    public class OperacionesTeclado
    {
        #region Variables
        private List<Keys> numericas;
        private List<Keys> simbolosmatematicos;
        private List<Keys> simbolosmatematicosmodificador;
        private List<Keys> letras;
        private List<Keys> puntuacion;
        private List<Keys> puntuacionmodificador;
        private List<Keys> especiales;
        private Dictionary<Keys, char[]> teclasyvalores;
        #endregion

        #region Propiedades

        #endregion

        #region Enums
        public enum TipoTecla
        {         
            Letras,
            Numerica,
            SimboloMatematico,
            Puntuacion,
            Especiales,            
            Desconocida,
            Desconocida_con_Shift
        }
        #endregion

        #region Constructor
        public OperacionesTeclado()
        {
            numericas = new List<Keys>() { Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3,
            Keys.NumPad4,Keys.NumPad5,Keys.NumPad6,Keys.NumPad7,Keys.NumPad8,Keys.NumPad9,
            Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9};
            simbolosmatematicos = new List<Keys>() { Keys.Add, Keys.Divide, Keys.Multiply, Keys.Subtract,
            Keys.Oemplus, Keys.Oem102, Keys.OemMinus};
            simbolosmatematicosmodificador = new List<Keys>() { Keys.D0, Keys.D5, Keys.D8, Keys.D9,
                Keys.Oem1, Keys.Oem102 };
            puntuacion = new List<Keys>() { Keys.Decimal, Keys.OemPeriod, Keys.Oemcomma, Keys.OemMinus };
            puntuacionmodificador = new List<Keys>() { Keys.OemPeriod, Keys.Oemcomma, Keys.OemMinus};
            letras = new List<Keys>() { Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H,
                Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.Oem3, Keys.O, Keys.P, Keys.Q, Keys.R,
                Keys.S, Keys.T, Keys.U, Keys.V, Keys.X, Keys.Y, Keys.Z, Keys.Space};
            especiales = new List<Keys>();
            
            teclasyvalores = new Dictionary<Keys, char[]>();
            teclasyvalores.Add(Keys.A, new char[] { 'a', 'A' });teclasyvalores.Add(Keys.B, new char[] {'b', 'B' });teclasyvalores.Add(Keys.C, new char[] { 'c','C'});
            teclasyvalores.Add(Keys.D, new char[] { 'd', 'D' });teclasyvalores.Add(Keys.E, new char[] { 'e', 'E' });teclasyvalores.Add(Keys.F, new char[] { 'f', 'F' });
            teclasyvalores.Add(Keys.G, new char[] { 'g', 'G' });teclasyvalores.Add(Keys.H, new char[] { 'h', 'H' });teclasyvalores.Add(Keys.I, new char[] { 'i', 'I' });
            teclasyvalores.Add(Keys.J, new char[] { 'j', 'J' });teclasyvalores.Add(Keys.K, new char[] { 'k', 'K' });teclasyvalores.Add(Keys.L, new char[] { 'l', 'L' });
            teclasyvalores.Add(Keys.M, new char[] { 'm', 'M' });teclasyvalores.Add(Keys.N, new char[] { 'n', 'N' });teclasyvalores.Add(Keys.Oem3, new char[] { 'ñ', 'Ñ' });
            teclasyvalores.Add(Keys.O, new char[] { 'o', 'O' });teclasyvalores.Add(Keys.P, new char[] { 'p', 'P' });teclasyvalores.Add(Keys.Q, new char[] { 'q', 'Q' });
            teclasyvalores.Add(Keys.R, new char[] { 'r', 'R' });teclasyvalores.Add(Keys.S, new char[] { 's', 'S' });teclasyvalores.Add(Keys.T, new char[] { 't', 'T' });
            teclasyvalores.Add(Keys.U, new char[] { 'u', 'U' });teclasyvalores.Add(Keys.V, new char[] { 'v', 'V' });teclasyvalores.Add(Keys.X, new char[] { 'x', 'X' });
            teclasyvalores.Add(Keys.Y, new char[] { 'y', 'Y' });teclasyvalores.Add(Keys.Z, new char[] { 'z', 'Z' });
            teclasyvalores.Add(Keys.NumPad0, new char[] { '0', '\0' }); teclasyvalores.Add(Keys.NumPad1, new char[] { '1', '\0' }); teclasyvalores.Add(Keys.NumPad2, new char[] { '2', '\0' });
            teclasyvalores.Add(Keys.NumPad3, new char[] { '3', '\0' }); teclasyvalores.Add(Keys.NumPad4, new char[] { '4', '\0' }); teclasyvalores.Add(Keys.NumPad5, new char[] { '5', '\0' });
            teclasyvalores.Add(Keys.NumPad6, new char[] { '6', '\0' }); teclasyvalores.Add(Keys.NumPad7, new char[] { '7', '\0' }); teclasyvalores.Add(Keys.NumPad8, new char[] { '8', '\0' });
            teclasyvalores.Add(Keys.NumPad9, new char[] { '9', '\0' }); teclasyvalores.Add(Keys.D0, new char[] { '0', '=' });  teclasyvalores.Add(Keys.D1, new char[] { '1', '!' });
            teclasyvalores.Add(Keys.D2, new char[] { '2', '"' });teclasyvalores.Add(Keys.D3, new char[] { '3', '·' });teclasyvalores.Add(Keys.D4, new char[] { '4', '$' });
            teclasyvalores.Add(Keys.D5, new char[] { '5', '%' });teclasyvalores.Add(Keys.D6, new char[] { '6', '&' });teclasyvalores.Add(Keys.D7, new char[] { '7', '/' });
            teclasyvalores.Add(Keys.D8, new char[] { '8', '(' });teclasyvalores.Add(Keys.D9, new char[] { '9', ')' });
            teclasyvalores.Add(Keys.Add, new char[] { '+', '\0' });teclasyvalores.Add(Keys.Divide, new char[] { '/', '\0' });teclasyvalores.Add(Keys.Multiply, new char[] { '*', '\0' });
            teclasyvalores.Add(Keys.Subtract, new char[] { '-', '\0' });teclasyvalores.Add(Keys.Oemplus, new char[] { '+', '*' }); teclasyvalores.Add(Keys.Oem102, new char[] { '<', '>' });
            teclasyvalores.Add(Keys.Oem1, new char[] { '`', '^' });
            teclasyvalores.Add(Keys.OemMinus, new char[] { '-', '_' });teclasyvalores.Add(Keys.Decimal, new char[] { '.', '\0' });teclasyvalores.Add(Keys.OemPeriod, new char[] { '.', ':' });
            teclasyvalores.Add(Keys.Oemcomma, new char[] { ',', ';' }); teclasyvalores.Add(Keys.Space, new char[] { ' ', ' ' });
        }
            
        #endregion

        public TipoTecla DefinirTipoTecla(KeyEventArgs e)
        {
            try
            {
                if (!e.Shift && !e.Control && !e.Alt)
                {
                    if (numericas.Contains(e.KeyCode)) return TipoTecla.Numerica;
                    if (letras.Contains(e.KeyCode)) return TipoTecla.Letras;
                    if (puntuacion.Contains(e.KeyCode)) return TipoTecla.Puntuacion;
                    if (simbolosmatematicos.Contains(e.KeyCode)) return TipoTecla.SimboloMatematico;
                }
                else if (!e.Shift)
                {
                    if (simbolosmatematicosmodificador.Contains(e.KeyCode)) return TipoTecla.SimboloMatematico;
                    if (letras.Contains(e.KeyCode)) return TipoTecla.Letras;
                    if (puntuacionmodificador.Contains(e.KeyCode)) return TipoTecla.Puntuacion;

                }
                else if(e.Shift && e.KeyCode != Keys.ShiftKey)
                {
                    return TipoTecla.Desconocida_con_Shift;
                }
                return TipoTecla.Desconocida;
            }
            catch (Exception ex)
            {

                throw new Exception("Error obteniendo operaciones del teclado: " +  ex.Message, ex.InnerException);
            }
        }

        public char ObtenerValorTecla(KeyEventArgs e)
        {
            char valor = '\0';
            try
            {
                if (teclasyvalores.ContainsKey(e.KeyCode))
                {                    
                    char[] arraychar;
                    if (teclasyvalores.TryGetValue(e.KeyCode, out arraychar))
                    {
                        if (e.Shift || Control.IsKeyLocked(Keys.CapsLock))
                        {                            
                            valor = arraychar[1];
                        }
                        else
                        {
                            valor = arraychar[0];
                        }
                    }                    
                }
                return valor;
            }
            catch (Exception ex)
            {

                throw new Exception("Error Obteniendo el valor de la tecla: " + ex.Message, ex.InnerException);
            }
        }



    }
}
