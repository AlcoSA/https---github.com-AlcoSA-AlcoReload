using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace Formulador
{
    public class Ejecutor
    {
        #region Variables
        private List<string> operadoresmatematicos = new List<string>();
        private List<string> operadoresbooleanos = new List<string>();
        private Dictionary<string, Func<object, object, decimal>> accionoperadores = new Dictionary<string, Func<object, object, decimal>>();
        
        private Dictionary<string, Func<decimal[], decimal>> funcionesmatematicas = new Dictionary<string, Func<decimal[], decimal>>();
        private Dictionary<string, Func<string[], object>> funcionescadena = new Dictionary<string, Func<string[], object>>();
        private Dictionary<string, decimal> variablesnumericas = new Dictionary<string, decimal>();
        private Dictionary<string, string> variablescadena = new Dictionary<string, string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Este constructor añade algunos operadores básicos, funciones y variables
        /// para el analizador. Tenga en cuenta que las banderas booleanas se pueden cambiar
        /// </summary>
        /// <param name="CargarFuncionesMatematicasPredefinidas">Carga: "abs", "cos", "cosh", "arccos", "sin", "sinh", "arcsin", "tan", "tanh", "arctan", "sqrt", "rem", "round"</param>
        /// <param name="CargarOperadoresPredefinidos">Carga: "%", "*", ":", "/", "+", "-", ">", "&lt;", "="</param>
        /// <param name="CargarVariablesNumericasPredefinidias">Carga "pi" y "e"</param>
        public Ejecutor(bool CargarFuncionesMatematicasPredefinidas = true, bool CargarOperadoresPredefinidos = true,
            bool CargarVariablesNumericasPredefinidias = true, bool loadPreDefinedStringVariables = true, bool loadPreDefinedStringFunctions = true)
        {
            if (Properties.Settings.Default.Consola)
            { Console.WriteLine("Iniciando Ejecutor"); }
            if (CargarOperadoresPredefinidos)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Cargando operadores matemáticos..."); }
                operadoresmatematicos.Add("%"); 
                operadoresmatematicos.Add("^");
                operadoresmatematicos.Add(":");
                operadoresmatematicos.Add("/");
                operadoresmatematicos.Add("*");
                operadoresmatematicos.Add("-");
                operadoresmatematicos.Add("+");
                operadoresbooleanos.Add("<");
                operadoresbooleanos.Add(">");
                operadoresbooleanos.Add("=");
                operadoresbooleanos.Add("<=");               
                operadoresbooleanos.Add(">=");
                operadoresbooleanos.Add("<>");
                accionoperadores.Add("%", (numberA, numberB) => Convert.ToDecimal(numberA) % Convert.ToDecimal(numberB));
                accionoperadores.Add("^", (numberA, numberB) => (decimal)Math.Pow(Convert.ToDouble(numberA), Convert.ToDouble(numberB)));
                accionoperadores.Add(":", (numberA, numberB) => (decimal)numberB == 0 ? 0 : (decimal)numberA / (decimal)numberB);
                accionoperadores.Add("/", (numberA, numberB) => (decimal)numberB == 0 ? 0: (decimal)numberA / (decimal)numberB);
                accionoperadores.Add("*", (numberA, numberB) => (decimal)numberA * (decimal)numberB);
                accionoperadores.Add("+", (numberA, numberB) => (decimal)numberA + (decimal)numberB);
                accionoperadores.Add("-", (numberA, numberB) => (decimal)numberA - (decimal)numberB);
                accionoperadores.Add(">", (numberA, numberB) => Convert.ToDecimal( numberA) > Convert.ToDecimal(numberB) ? 1 : 0);
                accionoperadores.Add("<", (numberA, numberB) => Convert.ToDecimal(numberA) < Convert.ToDecimal(numberB) ? 1 : 0);
                accionoperadores.Add("<=", (numberA, numberB) => Convert.ToDecimal(numberA) <= Convert.ToDecimal(numberB) ? 1 : 0);
                accionoperadores.Add(">=", (numberA, numberB) => Convert.ToDecimal(numberA) >= Convert.ToDecimal(numberB) ? 1 : 0);
                accionoperadores.Add("=", (cadena1, cadena2) => string.Equals(cadena1,cadena2) ? 1 : 0);
                accionoperadores.Add("<>", (cadena1, cadena2) =>  !string.Equals(cadena1, cadena2) ? 1 : 0);
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("fin carga operadores matemático"); }
            }
            if (CargarVariablesNumericasPredefinidias)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Cargando variables numéricas universales..."); }
                variablesnumericas.Add("pi", (decimal)3.14159265358979);                
                variablesnumericas.Add("e", (decimal)2.71828182845904);                
                variablesnumericas.Add("mayor", (decimal)0.61803398874989);
                variablesnumericas.Add("menor", (decimal)0.38196601125011);
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("fin carga variables numéricas universales"); }
            }


            if (CargarFuncionesMatematicasPredefinidas)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Cargando funciones matemáticas..."); }
                funcionesmatematicas.Add("ABSOLUTO", x => (decimal)Math.Abs((double)x[0]));
                funcionesmatematicas.Add("COSENO", x => (decimal)Math.Cos((double)x[0]));
                funcionesmatematicas.Add("COSENOH", x => (decimal)Math.Cosh((double)x[0]));
                funcionesmatematicas.Add("ARCCOSENO", x => (decimal)Math.Acos((double)x[0]));
                funcionesmatematicas.Add("SENO", x => (decimal)Math.Sin((double)x[0]));
                funcionesmatematicas.Add("SENOH", x => (decimal)Math.Sinh((double)x[0]));
                funcionesmatematicas.Add("ARCSENO", x => (decimal)Math.Asin((double)x[0]));
                funcionesmatematicas.Add("TAN", x => (decimal)Math.Tan((double)x[0]));
                funcionesmatematicas.Add("TANH", x => (decimal)Math.Tanh((double)x[0]));
                funcionesmatematicas.Add("ARCTAN", x => (decimal)Math.Atan((double)x[0]));
                funcionesmatematicas.Add("RAIZCUADRADA", x => (decimal)Math.Sqrt((double)x[0]));
                funcionesmatematicas.Add("REM", x => (decimal)Math.IEEERemainder((double)x[0], (double)x[1]));
                funcionesmatematicas.Add("RAIZ", x => (decimal)Math.Pow((double)x[0], 1.0 / (double)x[1]));              
                funcionesmatematicas.Add("POTENCIA", x => (decimal)Math.Pow((double)x[0], (double)x[1]));
                funcionesmatematicas.Add("EXP", x => (decimal)Math.Exp((double)x[0]));
                funcionesmatematicas.Add("LOG", delegate (decimal[] input)
                {
                    switch (input.Length)
                    {
                        case 1:
                            return (decimal)Math.Log((double)input[0]);
                        case 2:
                            return (decimal)Math.Log((double)input[0], (double)input[1]);
                        default:
                            return 0; 
                    }
                });
                funcionesmatematicas.Add("REDONDEAR", delegate (decimal[] input)
                {
                    switch (input.Length)
                    {
                        case 0:
                            {
                                return 0;                                
                            }
                        case 1:
                            {
                                return (decimal)Math.Round(Convert.ToDouble(input[0]));
                            }
                        default:
                            {
                                return (decimal)Math.Round(Convert.ToDouble(input[0]), Convert.ToInt32(input[1]));
                            }
                    }
                });
                funcionesmatematicas.Add("TRUNCAR", x => (decimal)(x[0] < 0.0m ? -Math.Floor(-(double)x[0]) : Math.Floor((double)x[0])));
                funcionesmatematicas.Add("REDONDEARENCIMA", x => (decimal)Math.Ceiling((double)x[0]));
                funcionesmatematicas.Add("REDONDEARABAJO", x => (decimal)Math.Floor((double)x[0]));
                funcionesmatematicas.Add("SIGNO", x => (decimal)Math.Sign((double)x[0]));
                funcionesmatematicas.Add("PROMEDIO", delegate (decimal[] input)
                {
                    return input.Sum() / input.Length;

                });
                funcionesmatematicas.Add("MAX", delegate (decimal[] input)
                {
                    return input.Max();

                });
                funcionesmatematicas.Add("MIN", delegate (decimal[] input)
                {
                    return input.Min();

                });
                funcionesmatematicas.Add("GRADOS", x => (decimal)((x[0] * 180) / Convert.ToDecimal(Math.PI)));

                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin carga funciones matemáticas"); }
            }


            if (loadPreDefinedStringVariables)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Cargando variables de cadena"); }
                VariablesCadena.Add("HOY", DateTime.Now.ToString());
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin carga variables de cadena"); }
            }
            if (loadPreDefinedStringFunctions)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Cargando funciones de cadena..."); }
                FuncionesCadena.Add("NUMEROTEXTO", x => ToText(double.Parse(x[0])));
                FuncionesCadena.Add("FORMATOFECHA", delegate (string[] input) //input[0] La fecha input[1] El formato
                {
                    switch (input.Length)
                    {
                        case 1:
                            if (string.IsNullOrEmpty(input[0]))
                            {
                                return string.Empty;
                            }
                            else
                            {
                                DateTime mdate = DateTime.Now;
                                if (DateTime.TryParse(input[0], out mdate))
                                {
                                    return mdate.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    return "No se puede convertir [" + input[0] + "] a un valor de fecha";
                                }
                            }
                        case 2:
                            if (string.IsNullOrEmpty(input[0]))
                            {
                                return string.Empty;
                            }
                            else
                            {
                                DateTime mdate = DateTime.Now;
                                if (DateTime.TryParse(input[0], out mdate))
                                {
                                    return mdate.ToString(input[1]);
                                }
                                else
                                {
                                    return "No se puede convertir [" + input[0] + "] a un valor de fecha";
                                }
                            }
                        default:
                            return DateTime.Now.ToString("dd/MM/yyyy"); // false
                    }
                });
                FuncionesCadena.Add("CONCATENAR", delegate (string[] input)
                {
                    string concatenate = string.Empty;
                    for (int i = 0; i < input.Length; i++)
                    {
                        concatenate += input[i].ToString();
                    }
                    return concatenate;
                });
                FuncionesCadena.Add("FORMATONUMERO", delegate (string[] input)
                {
                    decimal mnumber = 0;
                    string mformat = string.Empty;
                    if (decimal.TryParse(input[0], out mnumber))
                    {
                        switch (input.Length)
                        {
                            case 0:
                                mformat = "N0";
                                break;
                            case 1:
                                mformat = "N0";
                                break;
                            default:
                                mformat = input[0];
                                break;
                        }
                    }
                    return mnumber.ToString(mformat);

                });
                FuncionesCadena.Add("SI", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 0:
                            {
                                return "FALSO";                                
                            }
                        case 1:
                            {
                                if (Convert.ToBoolean(Convert.ToInt32(input[0]))) return "VERDADERO";
                                else  return "FALSO";                                
                            }
                        case 2:
                            {
                                if (Convert.ToBoolean(Convert.ToInt32(input[0]))) return input[1];
                                else return "FALSO";                                
                            }
                        default:
                            {
                                if (Convert.ToBoolean(Convert.ToInt32(input[0]))) return input[1];
                                else return input[2];                                
                            }  
                    }
                });
                FuncionesCadena.Add("Y", delegate (string[] input)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (!Convert.ToBoolean(Convert.ToInt32(input[i]))) return 0;
                    }
                    return 1;
                });
                FuncionesCadena.Add("O", delegate (string[] input)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (Convert.ToBoolean(Convert.ToInt32(input[i]))) return 1;
                    }
                    return 0;
                });
                FuncionesCadena.Add("MAYUSCULAS", x => x[0].ToUpper());
                FuncionesCadena.Add("MINUSCULAS", x => x[0].ToLower());
                FuncionesCadena.Add("ESPACIOS", x => x[0].Trim());
                FuncionesCadena.Add("IGUAL", x => Convert.ToInt32( x[0].Equals(x[1])));
                FuncionesCadena.Add("LARGO", x => x[0].Length);
                FuncionesCadena.Add("REPETIR", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 0:
                            {
                                return string.Empty;
                            }
                        case 1:
                            {
                                return input[0];
                            }
                        default:
                            {
                                string cadenarepetida= string.Empty;
                                for (int i = 0; i < Convert.ToInt32(input[1]);i++)
                                {
                                    cadenarepetida += input[0].ToString();
                                }
                                return cadenarepetida;
                            }
                    }
                });
                FuncionesCadena.Add("SUSTITUIR", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 3:
                            {
                                return input[0].Replace(input[1], input[2]);
                            }
                        default:
                            {
                                return string.Empty;
                            }
                    }
                });
                FuncionesCadena.Add("EXTRAER", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 2:
                            {
                                return input[0].Substring(Convert.ToInt32(input[1]));
                            }
                        case 3:
                            {
                                return input[0].Substring(Convert.ToInt32(input[1]), Convert.ToInt32(input[2]));
                            }
                        default:
                            {
                                return string.Empty;
                            }
                    }
                });
                FuncionesCadena.Add("ENCONTRAR", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 2:
                            {                                
                                return input[0].IndexOf(input[1]);
                            }
                        case 3:
                            {
                                return input[0].IndexOf(input[1], Convert.ToInt32(input[2]));
                            }
                        default:
                            {
                                return -1;
                            }
                    }
                });
                FuncionesCadena.Add("IZQUIERDA", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 0:
                            {
                                return string.Empty;
                            }
                        case 1:
                            {
                                if (input[0].Length > 0) return input[0].Substring(0, 1);
                                else return string.Empty;                             
                            }
                        default:
                            {
                                if (Convert.ToInt32(input[1]) < input[0].Length) return input[0].Substring(0, Convert.ToInt32(input[1]));
                                else return string.Empty;                                
                            }
                    }
                });
                FuncionesCadena.Add("DERECHA", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 0:
                            {
                                return "ERROR";
                            }
                        case 1:
                            {

                                if (input[0].Length > 0) return input[0].Substring(input[0].Length - 2, 1);
                                else return string.Empty;
                            }
                        default:
                            {
                                if (Convert.ToInt32(input[1]) < input[0].Length) return input[0].Substring(input[0].Length - (Convert.ToInt32(input[1]) +1), Convert.ToInt32(input[1]));
                                else return "ERROR";
                            }
                    }
                });
                funcionescadena.Add("EVALUAR", delegate (string[] input)
                {
                    if (input.Length > 0)
                    {
                        return Parse(input[0]);
                    }
                    else
                    {
                        return "0";
                    }

                });
                //Para el correcto funcionamiento la cantidad de elementos entre la entrada y la salida debe ser el mismo
                funcionescadena.Add("BUSQUEDADATOS", delegate (string[] input)
                {
                    int c = input.Count(x => x == ";");
                    switch (c)
                    {
                        case 0:
                            return string.Empty;
                        case 1:
                            return string.Empty;
                        case 2:
                            {
                                int e = Array.IndexOf(input, ";");
                                int s = Array.IndexOf(input, ";", e + 1);
                                string[] entrada = new string[e];
                                string[] salida = new string[s - e];
                                string filtro = input[s + 1];
                                Array.Copy(input, 0, entrada, 0, e);
                                Array.Copy(input, e + 1, salida, 0, s - e - 1);
                                int ind = Array.IndexOf(entrada, filtro);
                                if (ind >= 0) { return salida[Array.IndexOf(entrada, filtro)]; }
                                else { return "sin coincidencias"; }
                            }
                        case 3:
                            {
                                int i = Array.IndexOf(input, ";");
                                int m = Array.IndexOf(input, ";", i + 1);
                                int l = Array.IndexOf(input, ";", m + 1);
                                string[] entrada = new string[i];
                                string[] salida = new string[m - i];
                                string filtro = input[m + 1];
                                bool decision = Convert.ToBoolean(Convert.ToInt32(input[l + 1]));
                                Array.Copy(input, 0, entrada, 0, i);
                                Array.Copy(input, i + 1, salida, 0, m - i - 1);
                                List<string> resultado = new List<string>();
                                for (int j = 0; j < entrada.Length; j++)
                                {
                                    if (entrada[j]==filtro)
                                    {
                                        resultado.Add(salida[j]);
                                    }
                                }
                                if (decision)
                                {                                    
                                    if(resultado.Count>0)
                                    {
                                        return string.Join("\n", resultado.ToArray());
                                    }
                                    else { return "sin coincidencias"; }                                    
                                }
                                else
                                {
                                    int ind = Array.IndexOf(entrada, filtro);
                                    if (resultado.Count > 0) { return resultado[0]; }
                                    else { return "sin coincidencias"; }
                                }                                
                            }
                    }                    
                    return string.Empty;
                });
                funcionescadena.Add("PRIMERO", delegate (string[] input)
                {
                    return input.FirstOrDefault();
                });
                funcionescadena.Add("ULTIMO", delegate (string[] input)
                {
                    return input.LastOrDefault();
                });
                funcionescadena.Add("UNIR", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 0:
                            {
                                return "ERROR";}
                        case 1:
                            {
                                return input[0];}
                        default:
                            {
                                string separador = input[input.Length - 1];
                                string[] n_input = new string[input.Length-1];
                                for (int i = 0; i < input.Length - 1; i++)
                                {
                                    n_input[i] = input[i];
                                }
                                return string.Join(separador, n_input);}
                    }                    
                });
                funcionescadena.Add("AGRUPAR_Y_UNIR", delegate (string[] input)
                {
                    switch (input.Length)
                    {
                        case 0:
                            {
                                return "ERROR";}
                        case 1:
                            {
                                return input[0];}
                        default:
                            {
                                input= input.GroupBy(x => x).Select(y => y.First()).ToArray();
                                string separador = input[input.Length - 1];
                                string[] n_input = new string[input.Length-1];
                                for (int i = 0; i < input.Length - 1; i++)
                                {
                                    n_input[i] = input[i];
                                }
                                return string.Join(separador, n_input);}
                    }                    
                });
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("fin carga funciones de cadena"); }
            }
        }
        #endregion
        #region Propiedades

        /// <summary>
        ///Todos los operadores deben estar dentro de esta propiedad. 
        ///El primer operador se ejecuta primero y así sucesivamente. El operador sólo puede ser un carácter.
        /// </summary>
        public List<string> OperadoresMatematicos
        {
            get { return operadoresmatematicos; }
            set { operadoresmatematicos = value; }
        }

        public List<string> OperadoresBooleanos
        {
            get { return operadoresbooleanos; }
            set { operadoresbooleanos = value; }
        }
        /// <summary>
        /// Al añadir una variable en la propiedad OperatorList, necesita asignar cómo debería funcionar ese operador.
        /// </summary>
        public Dictionary<string, Func<object, object, decimal>> AccionOperadores
        {
            get { return accionoperadores; }
            set { accionoperadores = value; }
        }
        /// <summary>
        /// Todos las funciones matemáticas que se definan deben estar dentro de esta propiedad
        /// </summary>
        public Dictionary<string, Func<decimal[], decimal>> FuncionesMatematicas
        {
            get { return funcionesmatematicas; }
            set { funcionesmatematicas = value; }
        }
        /// <summary>
        /// Todos las funciones tipo string que se definan deben estar dentro de esta propiedad
        /// </summary>
        public Dictionary<string, Func<string[], object>> FuncionesCadena
        {
            get { return funcionescadena; }
            set { funcionescadena = value; }
        }
        /// <summary>
        /// Las variables que se quieran definir deben estar dentro de esta variable
        /// </summary>
        public Dictionary<string, decimal> VariablesNumericas
        {
            get { return variablesnumericas; }
            set { variablesnumericas = value; }
        }
        /// <summary>
        /// Las variables que se quieran definir deben estar dentro de esta variable
        /// </summary>
        public Dictionary<string, string> VariablesCadena
        {
            get { return variablescadena; }
            set { variablescadena = value; }
        }
        /// <summary>
        /// Al convertir el resultado del método Parse o método ProgrammaticallyParse ToString(),
        /// por favor utilice este CultureInfo.
        /// </summary>
        #endregion      

        #region Procedimientos

        /// <summary>
        /// Procesa una expresión matemática y realiza el respectivo calculo
        /// </summary>
        /// <param name="Expresion">expresión que se va a evaluar</param>
        /// <returns></returns>
        public string Parse(string Expresion)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio parseo  expresión"); }
                string respuesta = ParserLogica(Scanner(Expresion));                
                if (Properties.Settings.Default.Consola)                
                { Console.WriteLine("Fin parseo"); }
                return respuesta;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }
        /// <summary>
        ///  Procesa una expresión matemática en forma de lista y realiza el respectivo calculo
        /// </summary>
        /// <param name="Expression">lista de tokens</param>
        /// <returns></returns>
        public string Parse(List<string> Expression)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio parseo arreglo de tokens"); }
                string respuesta = ParserLogica(Expression);
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin parseo"); }
                return respuesta;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }
        /// <summary>
        /// Esto convertirá una expresión de cadena en una lista de tokens que luego pueden ser ejecutados 
        /// por los métodos Parse.
        /// </summary>
        /// <param name="Expresion"></param>
        /// <returns>ReadOnlyCollection</returns>
        public List<string> ObtenerTokens(string Expresion)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio obtener tokens"); }
                List<string> respuesta = Scanner(Expresion);
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin obtener tokens"); }
                return respuesta;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        /// <summary>
        /// Esto corregirá sqrt () y arctan () escrito en diferentes formas.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string Correcion(string input)
        {
            try
            {
                input = System.Text.RegularExpressions.Regex.Replace(input, "\\b(sqr|sqrt)\\b", "sqrt", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                input = System.Text.RegularExpressions.Regex.Replace(input, "\\b(atan2|arctan2)\\b", "arctan2", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                return input;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        private List<string> Scanner(string expr)
        {
            var tokens = new List<string>();
            var vector = "";
            try
            {
                //Reglas aritméticas básicas
                expr = expr.Replace("+-", "-");
                expr = expr.Replace("-+", "-");
                expr = expr.Replace("--", "+");
                for (var i = 0; i < expr.Length; i++)
                {
                    var ch = expr[i];

                    if (char.IsWhiteSpace(ch)) { }
                    else if (Char.IsLetter(ch))
                    {
                        if (i != 0 && (Char.IsDigit(expr[i - 1]) || Char.IsDigit(expr[i - 1]) || expr[i - 1] == ')'))
                        {
                            tokens.Add("*");
                        }
                        vector = vector + ch;

                        while ((i + 1) < expr.Length && Char.IsLetterOrDigit(expr[i + 1])) //aquí es que es posible elegir si desea que las variables que sólo contienen letras con o sin dígitos.
                        {
                            i++;
                            vector = vector + expr[i];
                        }

                        tokens.Add(vector);
                        vector = "";
                    }
                    else if (Char.IsDigit(ch))
                    {
                        vector = vector + ch;
                        while ((i + 1) < expr.Length && (Char.IsDigit(expr[i + 1]) || expr[i + 1] == '.')) // removed || _expr[i + 1] == ','
                        {
                            i++;
                            vector = vector + expr[i];
                        }
                        tokens.Add(vector);
                        vector = "";
                    }
                    else if ((i + 1) < expr.Length && (ch == '-' || ch == '+') && Char.IsDigit(expr[i + 1]) && (i == 0 || OperadoresMatematicos.IndexOf(expr[i - 1].ToString(CultureInfo.InvariantCulture)) != -1 || ((i - 1) > 0 && expr[i - 1] == '(')))
                    {
                        vector = vector + ch;
                        while ((i + 1) < expr.Length && (Char.IsDigit(expr[i + 1]) || expr[i + 1] == '.')) // removed || _expr[i + 1] == ','
                        {
                            i++;
                            vector = vector + expr[i];
                        }

                        tokens.Add(vector);
                        vector = "";
                    }
                    else if (ch == '(')
                    {
                        if (i != 0 && (Char.IsDigit(expr[i - 1]) || Char.IsDigit(expr[i - 1]) || expr[i - 1] == ')'))
                        {
                            tokens.Add("*");

                            // Si quitamos esta línea (arriba), que sería capaz de tener los números en nombres de las funciones. Sin embargo, no se puede evaluar 3 (2 + 2)
                            tokens.Add("(");
                        }
                        else
                            tokens.Add("(");
                    }
                    else if (ch == char.Parse("'"))
                    {
                        i++;
                        while ((i + 1) < expr.Length && (expr[i] != char.Parse("'"))) // removed || _expr[i + 1] == ','
                        {
                            vector = vector + expr[i];
                            i++;
                        }
                        tokens.Add(vector);
                        vector = string.Empty;
                    }
                    else
                    {
                        tokens.Add(ch.ToString());
                    }
                }
                return tokens;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private string ParserLogica(List<string> tokens)
        {
            // CALCULANDO EXPRESIONES QUE ESTAN DENTRO DE PARENTESIS
            // Reemplazo de variables
            if (tokens.Count > 0)
            {
                for (var i = 0; i < tokens.Count; i++)
                {
                    if (VariablesNumericas.Keys.Contains(tokens[i]))
                    {
                        tokens[i] = VariablesNumericas[tokens[i]].ToString();
                    }
                    if (VariablesCadena.Keys.Contains(tokens[i]))
                    {
                        tokens[i] = VariablesCadena[tokens[i]].ToString();
                    }
                }
                while (tokens.IndexOf("(") != -1)
                {
                    // Obteniendo los datos entre paréntesis "(", ")"
                    var open = tokens.LastIndexOf("(");
                    var close = tokens.IndexOf(")", open);
                    if (open >= close)
                    {
                        throw new ArithmeticException("Hay paréntesis o corchetes sin cerrar! tkn: " + open.ToString(CultureInfo.InvariantCulture));
                    }
                    var roughExpr = new List<string>();
                    for (var i = open + 1; i < close; i++)
                    {
                        roughExpr.Add(tokens[i]);
                    }
                    string result = string.Empty;
                    var functioName = tokens[open == 0 ? 0 : open - 1];
                    var args = new decimal[0];
                    var argS = new string[0];
                    if (FuncionesMatematicas.Keys.Contains(functioName))
                    {
                        if (roughExpr.Contains(","))
                        {
                            // Convirtiendo todos los argumentos en arreglos decimales
                            for (var i = 0; i < roughExpr.Count; i++)
                            {
                                var firstCommaOrEndOfExpression = roughExpr.IndexOf(",", i) != -1 ? roughExpr.IndexOf(",", i) : roughExpr.Count;
                                var defaultExpr = new List<string>();

                                while (i < firstCommaOrEndOfExpression)
                                {
                                    defaultExpr.Add(roughExpr[i]);
                                    i++;
                                }
                                Array.Resize(ref args, args.Length + 1);
                                if (defaultExpr.Count == 0)
                                {
                                    args[args.Length - 1] = 0;
                                }
                                else
                                {
                                    args[args.Length - 1] = CalculoOperacionesAritmeticasBasicas(defaultExpr);
                                }
                            }                            
                            result = Math.Round( FuncionesMatematicas[functioName](args), 4).ToString();
                        }
                        else
                        {
                            decimal v = FuncionesMatematicas[functioName](new[] { CalculoOperacionesAritmeticasBasicas(roughExpr) });
                            result = Math.Round(v, 4).ToString();
                        }
                    }
                    else if (FuncionesCadena.Keys.Contains(functioName))
                    {

                        if (roughExpr.Contains(","))
                        {
                            // Convirtiendo todos los argumentos en arreglos decimales
                            for (var i = 0; i < roughExpr.Count; i++)
                            {
                                var firstCommaOrEndOfExpression = roughExpr.IndexOf(",", i) != -1 ? roughExpr.IndexOf(",", i) : roughExpr.Count;
                                var defaultExpr = new List<string>();

                                while (i < firstCommaOrEndOfExpression)
                                {
                                    defaultExpr.Add(roughExpr[i]);
                                    i++;
                                }
                                // cambiando el tamaño del array de argumentos
                                Array.Resize(ref argS, argS.Length + 1);

                                if (defaultExpr.Count == 0)
                                {
                                    argS[argS.Length - 1] = "";
                                }
                                else
                                {
                                    if (esAritmetica(defaultExpr))
                                    {
                                        argS[argS.Length - 1] = CalculoOperacionesAritmeticasBasicas(defaultExpr).ToString();
                                    }
                                    else if (esBoleana(defaultExpr))
                                    {
                                        argS[argS.Length - 1] = CalculoOperacionesBoleanas(defaultExpr).ToString();
                                    }
                                    else
                                    {
                                        argS[argS.Length - 1] = defaultExpr[0];
                                    }
                                }
                            }

                            // Finalmente, pasando los argumentos para la función dada
                            result = FuncionesCadena[functioName](argS).ToString();
                        }
                        else
                        {
                            // pero si sólo tenemos un argumento, entonces pasarlo directamente a la función
                            if (esAritmetica(roughExpr))
                            {
                                result = FuncionesCadena[functioName](new[] { CalculoOperacionesAritmeticasBasicas(roughExpr).ToString() }).ToString();
                            }
                            else if (esBoleana(roughExpr))
                            {
                                result = FuncionesCadena[functioName](new[] { CalculoOperacionesBoleanas(roughExpr).ToString() }).ToString();
                            }
                            else
                            {
                                if (roughExpr.Count > 1)
                                {
                                    throw new ArithmeticException("Hay un error de sintaxis en la formula: " + functioName);
                                }
                                else
                                { result = FuncionesCadena[functioName](new[] { roughExpr[0] }).ToString(); }
                            }
                        }
                    }
                    else
                    {
                        // Si no hay función se necesita para ejecutar siguiente expresión, pasarlo
                        // Para el método de "BasicArithmeticalExpression".
                        if (esAritmetica(roughExpr))
                        {
                            result = CalculoOperacionesAritmeticasBasicas(roughExpr).ToString();
                        }
                        else if (esBoleana(roughExpr))
                        {
                            result = CalculoOperacionesBoleanas(roughExpr).ToString();
                        }
                        
                    }
                    // Cuando se han hecho todos los cálculos
                    // Reemplazamos el "soporte de la apertura con el resultado"
                    // Y eliminar el resto.
                    tokens[open] = result.ToString();
                    tokens.RemoveRange(open + 1, close - open);
                    if (FuncionesMatematicas.Keys.Contains(functioName) || FuncionesCadena.Keys.Contains(functioName))
                    {
                        // Si se ejecuta una función, la eliminación
                        // El nombre de función también.
                        tokens.RemoveAt(open - 1);
                    }
                }
                // En este punto, deberíamos haber reemplazado todos los soportes con los valores adecuados,
                //por lo que simplemente puede calcular la expresión.
                if (tokens.Count == 1)
                {
                    return tokens[0];
                }
                else
                {
                    if (esAritmetica(tokens))
                    {
                        return CalculoOperacionesAritmeticasBasicas(tokens).ToString();
                    }
                    if (esBoleana(tokens))
                    {
                        return CalculoOperacionesBoleanas(tokens).ToString();
                    }
                    else
                    {
                        string r = string.Empty;
                        for(int i=0;i<tokens.Count;i++)
                        {
                            r += tokens[i];
                        }
                        throw new Exception("Hay un error en la formula. Revise la información.\n -> Resultado parcial: " + r);
                    }
                }
            }
            else
            {
                return "";
            }

        }

        private bool esAritmetica(List<string> tokens)
        {
            bool isarithmetical = false;
            switch (tokens.Count)
            {
                case 1:
                    decimal n;
                    isarithmetical = decimal.TryParse(tokens[0], out n);
                    break;
                default:
                    for (int i = 0; i < tokens.Count; i++)
                    {
                        decimal ns;
                        bool isar = decimal.TryParse(tokens[i], out ns);
                        if (!(operadoresmatematicos.Contains(tokens[i])) && !(isar) && !(funcionesmatematicas.Keys.Contains(tokens[i])))
                        {
                            return false;
                        }
                        else
                        {
                            isarithmetical = true;
                        }
                    }
                    break;
            }
            return isarithmetical;
        }

        private bool esBoleana(List<string> tokens)
        {
            bool isboolean = false;
            switch (tokens.Count)
            {
                case 1:
                    bool n;
                    isboolean = bool.TryParse(tokens[0], out n);
                    break;
                case 2:                    
                    break;
                case 3:
                    return operadoresbooleanos.Contains(tokens[1]);
                case 4:
                    return operadoresbooleanos.Contains(tokens[1] + tokens[2]);
                default:
                    break;
            }
            return isboolean;
        }

        private decimal CalculoOperacionesBoleanas(List<string> tokens)
        {
            switch (tokens.Count)
            {
                case 0:
                    return 0;
                case 1:
                    return Convert.ToDecimal(tokens[0]);
                case 2:
                    return 0;             
            }
            foreach (var op in operadoresbooleanos)
            {
                while (tokens.IndexOf(op) != -1)
                {
                    var opPlace = tokens.IndexOf(op);
                    var moreOp = 0;
                    var extraop = string.Empty;
                    if (operadoresbooleanos.Contains(tokens[opPlace + 1]))
                    {
                        extraop = tokens[opPlace + 1];
                        moreOp = 1;
                    }
                    var expressionA = tokens[opPlace - 1];
                    var expressionB = tokens[opPlace + moreOp + 1];
                    var result = AccionOperadores[op + extraop](expressionA, expressionB);

                    tokens[opPlace - 1] = result.ToString();
                    tokens.RemoveRange(opPlace, 2 + moreOp);
                }
            }
            return Convert.ToDecimal(tokens[0]);
        }

        private decimal CalculoOperacionesAritmeticasBasicas(List<string> tokens)
        {
            try
            {
                switch (tokens.Count)
                {
                    case 1:
                        return Convert.ToDecimal(tokens[0]);
                    case 2:
                        {
                            var op = tokens[0];

                            if (op == "-" || op == "+")
                                return Convert.ToDecimal((op == "+" ? "" : (tokens[1].Substring(0, 1) == "-" ? "" : "-")) + tokens[1]);

                            return AccionOperadores[op](0, Convert.ToDecimal(tokens[1]));
                        }
                    case 0:
                        return 0;
                    case 3:
                        {
                            var opPlace = tokens[1];
                            var numberA = Convert.ToDecimal(tokens[0].Replace(",", "."));
                            var numberB = Convert.ToDecimal(tokens[2].Replace(",", "."));
                            var result = AccionOperadores[opPlace](numberA, numberB);
                            tokens[0] = result.ToString();
                            tokens.RemoveRange(1, 2);
                            return Math.Round(Convert.ToDecimal(tokens[0]), 4);
                        }
                }
                string experror = string.Empty;
                for (int i = 0; i < tokens.Count; i++)
                { experror += tokens[i]; }
                foreach (var op in OperadoresMatematicos)
                {
                    while (tokens.IndexOf(op) != -1)
                    {
                        var opPlace = tokens.IndexOf(op);
                        var numberA = 0m;
                        var numberB = 0m;
                        int remover = 0;
                        if (OperadoresMatematicos.Contains(tokens[opPlace + 1]))
                        {

                            if (tokens[opPlace + 1] == "-")
                            {
                                numberA = Convert.ToDecimal(tokens[opPlace - 1].Replace(",", "."));
                                numberB = Convert.ToDecimal(tokens[opPlace + 2].Replace(",", ".")) * -1;
                            }
                            else if (tokens[opPlace + 1] == "+")
                            {
                                numberA = Convert.ToDecimal(tokens[opPlace - 1].Replace(",", "."));
                                numberB = Convert.ToDecimal(tokens[opPlace + 2].Replace(",", "."));
                            }
                            else
                            {
                                throw new Exception("La expresión " + experror + " no se puede ejecutar");
                            }
                            remover = 3;
                        }
                        else
                        {
                            numberA = Convert.ToDecimal(tokens[opPlace - 1].Replace(",", "."));
                            numberB = Convert.ToDecimal(tokens[opPlace + 1].Replace(",", "."));
                            remover = 2;
                        }
                        var result = AccionOperadores[op](numberA, numberB);
                        tokens[opPlace - 1] = result.ToString();
                        tokens.RemoveRange(opPlace, remover);
                    }
                }
                return Math.Round(Convert.ToDecimal(tokens[0]), 4);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        #endregion

        #region Funciones Especiales Creadas

        private string ToText(double value)
        {
            string Num2Text = "";
            Int64 intpart = Convert.ToInt64(value);
            Num2Text = cToText(intpart);
            return Num2Text;
        }
        private string cToText(Int64 value)
        {
            string Num2Text = "";
            if (value < 0) return "menos " + ToText(Math.Abs(value));

            if (value == 0) Num2Text = "cero";
            else if (value == 1) Num2Text = "uno";
            else if (value == 2) Num2Text = "dos";
            else if (value == 3) Num2Text = "tres";
            else if (value == 4) Num2Text = "cuatro";
            else if (value == 5) Num2Text = "cinco";
            else if (value == 6) Num2Text = "seis";
            else if (value == 7) Num2Text = "siete";
            else if (value == 8) Num2Text = "ocho";
            else if (value == 9) Num2Text = "nueve";
            else if (value == 10) Num2Text = "diez";
            else if (value == 11) Num2Text = "once";
            else if (value == 12) Num2Text = "doce";
            else if (value == 13) Num2Text = "trece";
            else if (value == 14) Num2Text = "catorce";
            else if (value == 15) Num2Text = "quince";
            else if (value < 20) Num2Text = "dieci" + ToText(value - 10);
            else if (value == 20) Num2Text = "veinte";
            else if (value < 30) Num2Text = "veinti" + ToText(value - 20);
            else if (value == 30) Num2Text = "treinta";
            else if (value == 40) Num2Text = "cuarenta";
            else if (value == 50) Num2Text = "cincuenta";
            else if (value == 60) Num2Text = "sesenta";
            else if (value == 70) Num2Text = "setenta";
            else if (value == 80) Num2Text = "ochenta";
            else if (value == 90) Num2Text = "noventa";
            else if (value < 100)
            {
                Int64 u = value % 10;
                Num2Text = string.Format("{0} y {1}", ToText((value / 10) * 10), (u == 1 ? "uno" : ToText(value % 10)));
            }
            else if (value == 100) Num2Text = "cien";
            else if (value < 200) Num2Text = "ciento " + ToText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = ToText((value / 100)) + "cientos";
            else if (value == 500) Num2Text = "quinientos";
            else if (value == 700) Num2Text = "setecientos";
            else if (value == 900) Num2Text = "novecientos";
            else if (value < 1000) Num2Text = string.Format("{0} {1}", ToText((value / 100) * 100), ToText(value % 100));
            else if (value == 1000) Num2Text = "mil";
            else if (value < 2000) Num2Text = "mil " + ToText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = ToText((value / 1000)) + " mil";
                if ((value % 1000) > 0) Num2Text += " " + ToText(value % 1000);
            }
            else if (value == 1000000) Num2Text = "un millón";
            else if (value < 2000000) Num2Text = "un millón " + ToText(value % 1000000);
            else
            {
                Num2Text = ToText((value / 1000000)) + " millones";
                if ((value - (value / 1000000) * 1000000) > 0) Num2Text += " " + ToText(value - (value / 1000000) * 1000000);
            }
            return Num2Text.ToUpper();
        }

        #endregion
    }
}
