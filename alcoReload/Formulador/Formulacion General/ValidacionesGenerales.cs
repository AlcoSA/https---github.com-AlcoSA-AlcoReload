using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Formulador.Formulacion_General
{
    public class ValidacionesGenerales
    {
        #region Variables
        protected List<Mensajes> mensajes;
        protected Ejecutor exec;
        protected Regex analiza;
        #endregion

        #region Constructor
        public ValidacionesGenerales()
        {
            mensajes = new List<Mensajes>();
            exec = new Ejecutor();
            string ctexto = Regex.Escape("'") + "(.*?)'";
            analiza = new Regex(@"\^|[0-9]+(\.[0-9]+)?|[a-zA-ZñÑ_0-9]+" + "|" + ctexto + @"|[" + Regex.Escape("'") + "]|[()]|[=]|[.]|[+]|[-]|[*]|[/]|[:]|[<]|[>]|[%]|[,]");
        }
        #endregion

        #region Propiedades
        public List<Mensajes> Mensajes
        {
            get
            { return mensajes; }
        }
        public Ejecutor EjecutorFormulas
        {
            get
            {
                return exec;
            }
        }

        #endregion

        #region Generales
        public string[] ObtenerElementos(string expresion)
        {
            MatchCollection matches = analiza.Matches(expresion);
            return matches.Cast<Match>().Select(x => x.Value).ToArray();
        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Verifica si un carácter cumple ciertos requisitos
        /// </summary>
        /// <param name="car"> Elemento que se va a evaluar </param>
        /// <param name="vespacioovacio"> Verificar si es un espacio </param>
        /// <param name="vopmatematico"> Verificar si es un operador matematico </param>
        /// <param name="vopbool"> Verificar si es un operador booleano </param>
        /// <param name="vparentabre"> Verificar si es un parentesis de apertura </param>
        /// <param name="vparentcierra"> Verificar si es un parentesis de cierre</param>
        /// <param name="vcoma"> Verificar si es una coma </param>
        /// <param name="vdelimitadorstring"> Verificar si es un (') delimitador de string </param>
        /// <returns></returns>
        protected bool tipoParametroVerificacion(string car, bool vespacioovacio = false, bool vopmatematico = false, bool vopbool = false,
    bool vparentabre = false, bool vparentcierra = false, bool vcoma = false, bool vdelimitadorstring = false)
        {
            try
            {
                bool esvalido = false;
                if ((string.IsNullOrWhiteSpace(car) && vespacioovacio) ||
                    (exec.OperadoresMatematicos.Contains(car) && vopmatematico) ||
                    (exec.OperadoresBooleanos.Contains(car) && vopbool) ||
                    (car.Equals("(") && vparentabre) ||
                    (car.Equals(")") && vparentcierra) ||
                    (car.Equals("'") && vdelimitadorstring) ||
                    (car.Equals(",") && vcoma))
                {
                    esvalido = true;
                }
                return esvalido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        protected bool VerificarInExistente(int index, MatchCollection matches)
        {
            try
            {
                bool istring = false;
                if (index <= 0)
                {
                    mensajes.Add(new Mensajes("Error de sintaxis en el valor " + matches[index].Value + ", como es un objeto desconocido el sistema asume que es un valor de cadena," +
                         "por lo tanto debe ir dentro de comillas simple, ejemplo 'Variable'", matches[index].Index, matches[index].Length)); return false;
                }

                if (!tipoParametroVerificacion(matches[index - 1].Value,
                    vdelimitadorstring: true) || index == matches.Count - 1)
                {
                    mensajes.Add(new Mensajes("Error de sintaxis en el valor " + matches[index].Value + ", como es un objeto desconocido el sistema asume que es un valor de cadena," +
                      "por lo tanto debe ir dentro de comillas simple, ejemplo 'Variable'", matches[index].Index, matches[index].Length)); return false;
                }
                else
                {
                    istring = true;
                }

                if (!tipoParametroVerificacion(car: matches[index - 1].Value, vespacioovacio: true,
                    vopmatematico: true, vopbool: true, vparentabre: true)
                    && !istring)
                { mensajes.Add(new Mensajes("Error de sintaxis en el valor " + matches[index].Value + ", debe estar precedido de un paréntesis de apertura o un operador", matches[index - 1].Index, matches[index].Length + 1)); return false; }

                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error desconocido. Llamada con malos usos." + ex.Message,
                    matches[index].Index, matches[index].Length));
                return false;
            }
        }
        protected bool VerficarVariablePredefinidaoValorNumerico(int index, MatchCollection matches)
        {
            try
            {
                if (index > 0)
                {
                    string expAtras = matches[index - 1].Value;
                    if (!tipoParametroVerificacion(expAtras, vespacioovacio: true,
                        vcoma: true, vparentabre: true, vopmatematico: true, vopbool: true))
                    {
                        mensajes.Add(new Mensajes("Error de sintaxis, el valor de: " + matches[index].Value +
                      " esta antecedido por un elemento que no corresponde (" + expAtras + ")", matches[index].Index, matches[index].Length)); return false;
                    }

                    if (index < matches.Count - 1)
                    {
                        string expAdelante = matches[index + 1].Value;
                        if (!tipoParametroVerificacion(expAdelante, vespacioovacio: true, vcoma: true, vparentcierra: true, vopmatematico: true, vopbool: true))
                        { mensajes.Add(new Mensajes("Error de sintaxis, el valor de: " + matches[index].Value + " esta precedido por un elemento que no corresponde (" + expAdelante + ")", matches[index].Index, matches[index].Length)); return false; }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error desconocido en el uso de variables del sistema o valores numéricos. " + ex.Message,
                    matches[index].Index, matches[index].Length));
                return false;
            }
        }
        protected bool VerificarFuncion(int index, MatchCollection matches)
        {
            try
            {
                if (index >= matches.Count)
                { mensajes.Add(new Mensajes("Error de sintaxis, La función: " + matches[index].Value + ", debe tener parámetros", matches[index].Index, matches[index].Length)); return false; }
                if (!tipoParametroVerificacion(matches[index + 1].Value, vparentabre: true))
                { mensajes.Add(new Mensajes("Error de sintaxis, La función: " + matches[index].Value + ", debe tener parámetros. Falta el paréntesis de apertura", matches[index - 1].Index, matches[index - 1].Length)); return false; }
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error desconocido en la llamada a una función. " + ex.Message, matches[index].Index, matches[index].Length));
                return false;
            }
        }
        protected bool VerificarOperadorMatematico(int index, MatchCollection matches)
        {
            try
            {
                if (index == matches.Count - 1)
                { mensajes.Add(new Mensajes("Error de sintaxis, Una formula no debe terminar con un operador.", matches[index].Index, matches[index].Length)); return false; }
                if (tipoParametroVerificacion(matches[index + 1].Value, vopmatematico: true) && !matches[index + 1].Value.Equals("-"))
                { mensajes.Add(new Mensajes("No deben haber dos o más operadores juntos.")); return false; }
                if (index > 0)
                {
                    if (tipoParametroVerificacion(matches[index - 1].Value, vopmatematico: true) && !matches[index].Value.Equals("-"))
                    { mensajes.Add(new Mensajes("No deben haber dos o más operadores juntos.", matches[index].Index, matches[index].Length)); return false; }
                    if (tipoParametroVerificacion(matches[index - 1].Value, vparentabre: true) && !matches[index].Value.Equals("-"))
                    { mensajes.Add(new Mensajes("Un operador no debe estar antecedido por un paréntesis de apertura '('.", matches[index - 1].Index, matches[index].Length + 1)); return false; }
                    if (tipoParametroVerificacion(matches[index + 1].Value, vparentcierra: true))
                    { mensajes.Add(new Mensajes("Un operador no debe estar precedido por un paréntesis de cierre ')'.", matches[index].Index, matches[index].Length)); return false; }
                }
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error desconocido en la validación de un operador. " + ex.Message, matches[index].Index, matches[index].Length));
                return false;
            }
        }
        protected bool VerificarOperadorBooleano(int index, MatchCollection matches)
        {
            try
            {
                if (index == matches.Count - 1)
                { mensajes.Add(new Mensajes("Error de sintaxis, Una formula no debe terminar con un operador.", matches[index].Index, matches[index].Length)); return false; }
                if (tipoParametroVerificacion(matches[index + 1].Value, vopmatematico: true))
                { mensajes.Add(new Mensajes("Un operador de comparación, no debe estar seguido de uno matemático.")); return false; }
                if (index > 0)
                {
                    if (tipoParametroVerificacion(matches[index - 1].Value, vopmatematico: true))
                    { mensajes.Add(new Mensajes("No deben haber dos o más operadores juntos.", matches[index].Index, matches[index].Length)); return false; }
                    if (tipoParametroVerificacion(matches[index - 1].Value, vparentabre: true))
                    { mensajes.Add(new Mensajes("Un operador no debe estar antecedido por un paréntesis de apertura '('.", matches[index - 1].Index, matches[index].Length + 1)); return false; }
                    if (tipoParametroVerificacion(matches[index + 1].Value, vparentcierra: true))
                    { mensajes.Add(new Mensajes("Un operador no debe estar precedido por un paréntesis de cierre ')'.", matches[index].Index, matches[index].Length)); return false; }
                }
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error desconocido en la validación de un operador. " + ex.Message, matches[index].Index, matches[index].Length));
                return false;
            }
        }
        protected bool EsNumerico(string valor)
        {
            try
            {
                double opc1 = 0;
                decimal opc2 = 0;               
                return double.TryParse(valor, out opc1) || decimal.TryParse(valor, out opc2);
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes(ex.Message));
                return false;
            }
        }
        protected bool EsParentesis(string valor)
        {
            return tipoParametroVerificacion(valor, vparentabre: true, vparentcierra: true);
        }
        protected bool EsSeparador(string valor)
        {
            return tipoParametroVerificacion(valor, vcoma: true);
        }
        protected bool EsCadenadeTexto(string valor)
        {
            int inicio = valor.IndexOf("'");
            int fin = valor.IndexOf("'");
            if (inicio >= 0)
            { return true; }
            else
            { return false; }
        }
        protected bool VerificarParentesis(string expresion)
        {
            try
            {
                if (expresion.Count(x => x.Equals('(')) != expresion.Count(x => x.Equals(')')))
                { mensajes.Add(new Mensajes("Error de sintaxis. La cantidad de paréntesis de cierre ')' no corresponde a la cantidad de paréntesis de apertura '('")); return false; }
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error validando el uso de los paréntesis. " + ex.Message));
                return false;
            }
        }
        #endregion

    }
}
