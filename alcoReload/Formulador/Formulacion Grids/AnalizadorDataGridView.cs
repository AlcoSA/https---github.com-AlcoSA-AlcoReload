using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Formulador.Formulacion_Grids
{
    public class AnalizadorDataGridView : Formulacion_General.ValidacionesGenerales
    {
        DataGridView grid;
        public AnalizadorDataGridView(DataGridView datagridview)
        {
            grid = datagridview;
        }

        public bool Verificar(string expresion)
        {
            try
            {
                bool verificar = true;
                if (!VerificarParentesis(expresion)) { return false; }                           
                MatchCollection matches = analiza.Matches(expresion);
                for (int i = 0; i < matches.Count; i++)
                {
                    if (matches[i].Value.ToLower() == "tabla")
                    {
                        if (VerificarTiposTabla(i, matches))
                        {
                            i += 5;
                        }
                        else
                        { verificar = false; }
                    }
                    else if (EsParentesis(matches[i].Value) ||
                        EsSeparador(matches[i].Value) || EsCadenadeTexto(matches[i].Value))
                    {
                        
                    }
                    else if (exec.VariablesNumericas.ContainsKey(matches[i].Value) || EsNumerico(matches[i].Value))
                    {

                        if (!VerficarVariablePredefinidaoValorNumerico(i, matches))                        
                        { verificar = false; }

                    }
                    else if (exec.OperadoresMatematicos.Contains(matches[i].Value))
                    {
                        if (!VerificarOperadorMatematico(i, matches))                        
                        {verificar = false;}
                    }
                    else if (exec.OperadoresBooleanos.Contains(matches[i].Value))
                    {
                        if (!VerificarOperadorBooleano(i, matches))                        
                        {verificar = false;}
                    }
                    else if (exec.FuncionesMatematicas.ContainsKey(matches[i].Value) ||
                         exec.FuncionesCadena.ContainsKey(matches[i].Value))
                    {
                        if (!VerificarFuncion(i, matches))                        
                        {verificar = false;}
                    }
                    else if (string.IsNullOrEmpty(matches[i].Value) || string.IsNullOrWhiteSpace(matches[i].Value)){}
                    else
                    {
                        if (!VerificarInExistente(i, matches))                        
                        { verificar = false; }
                    }
                }
                return verificar;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public string Evaluar(string expresion)
        {
            try
            {
                List<string> exprParts = new List<string>();                
                MatchCollection matches = analiza.Matches(expresion);
                for (int i = 0; i < matches.Count; i++)
                {
                    if (matches[i].Value.ToLower() == "tabla")
                    {
                        exprParts.Add(Convert.ToString(grid[Convert.ToInt32(matches[i+4].Value), Convert.ToInt32(matches[i+2].Value)].Value));
                        i += 5;                        
                    }
                    else { exprParts.Add(matches[i].Value); }
                    
                }
                for (int i = 0; i < exprParts.Count; i++)
                {
                    if (EsNumerico(exprParts[i]))
                    {
                        exprParts[i] = Convert.ToDecimal(exprParts[i]).ToString();
                    }
                    exprParts[i] = exprParts[i].Replace("'", "");
                }
                return exec.Parse(exprParts);                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "0";
            }           
        }

        #region Validaciones
        private bool VerificarTiposTabla(int index, MatchCollection matches)
        {
            try
            {
                if (index +6 > matches.Count)
                {
                    mensajes.Add(new Formulador.Mensajes("Debe indicar la fila y la columna [TABLA(fila, columna)]."));
                    return false;
                }
                if (matches[index + 1].Value != "(" || matches[index + 5].Value != ")")
                {
                    mensajes.Add(new Formulador.Mensajes("la función 'TABLA' debe llevar los argumentos dentro de paréntesis [TABLA(fila, columna)]."));
                    return false;
                }
                if (!EsNumerico(matches[index + 2].Value) || !EsNumerico(matches[index + 4].Value))
                {
                    mensajes.Add(new Formulador.Mensajes("Los indicadores de fila y columna deben ser numericos [TABLA(fila, columna)]."));
                    return false;
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        #endregion

        #region Ayudas Formulación
        public Match ListaAyuda(string expresion, int selectionstart)
        {
            try
            {
                    MatchCollection matches = analiza.Matches(expresion);
                    int ultimoevaluar = 0;
                    for (int i = 0; i < matches.Count; i++)
                    {
                        if (matches[i].Index <= selectionstart && matches[i].Index + matches[i].Length >= selectionstart)
                        {
                            ultimoevaluar = i;
                            break;
                        }
                    }
                    return matches[ultimoevaluar];            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        #endregion

    }
}
