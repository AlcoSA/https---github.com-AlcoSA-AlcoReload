using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using DatagridTreeView;
namespace Formulador.Formulacion_Grids
{
    public class AnalizadorTreeGridview : Formulacion_General.ValidacionesGenerales
    {
        DataTreeGridView grid;
        public AnalizadorTreeGridview(DataTreeGridView datagridview)
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
                    if (matches[i].Value.ToLower() == "padre")
                    {
                        if (VerificarTiposPadre(i, matches))
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
                        { verificar = false; }
                    }
                    else if (exec.OperadoresBooleanos.Contains(matches[i].Value))
                    {
                        if (!VerificarOperadorBooleano(i, matches))
                        { verificar = false; }
                    }
                    else if (exec.FuncionesMatematicas.ContainsKey(matches[i].Value) ||
                         exec.FuncionesCadena.ContainsKey(matches[i].Value))
                    {
                        if (!VerificarFuncion(i, matches))
                        { verificar = false; }
                    }
                    else if (string.IsNullOrEmpty(matches[i].Value) || string.IsNullOrWhiteSpace(matches[i].Value)) { }
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
                    if (matches[i].Value.ToLower() == "padre")
                    {
                        if (matches[i + 5].Value.ToLower() == "valor")
                        {                            
                            exprParts.Add(Convert.ToString(grid.Nodes[Convert.ToInt32(matches[i + 2].Value)].Cells[Convert.ToInt32(matches[i + 7].Value)].Value));
                            i += 8;
                        }
                        else if (matches[i + 5].Value.ToLower() == "hijo")
                        {                            
                            exprParts.Add(Convert.ToString(grid.Nodes[Convert.ToInt32(matches[i + 2].Value)].Nodes[Convert.ToInt32(matches[i + 7].Value)].Cells[Convert.ToInt32(matches[i + 9].Value)].Value));
                            i += 10;
                        }
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
        private bool VerificarTiposPadre(int index, MatchCollection matches)
        {
            try
            {
                if (index + 8 > matches.Count)
                {
                    mensajes.Add(new Formulador.Mensajes("Debe indicar la fila y la columna [TABLA(fila, columna)]."));
                    return false;
                }
                if (matches[index + 1].Value != "(" || matches[index + 3].Value != ")")
                {
                    mensajes.Add(new Formulador.Mensajes("la función 'PADRE' debe llevar los argumentos dentro de paréntesis [PADRE(fila)]."));
                    return false;
                }
                if (!EsNumerico(matches[index + 2].Value))
                {
                    mensajes.Add(new Formulador.Mensajes("El indicador de fila deben ser numérico [PADRE(fila)]."));
                    return false;
                }
                string[] lista = new string[] {"valor", "hijo"};
                string v = matches[index + 5].Value.ToLower();
                if (!lista.Contains(v))
                {
                    mensajes.Add(new Formulador.Mensajes("debe indicar un valor en el padre o en uno de sus hijos [PADRE(fila).VALOR(columna) | PADRE(fila).HIJO(fila, columna)]."));
                    return false;
                }
                if (v == lista[0])
                {
                    if (matches[index + 6].Value != "(" || matches[index + 8].Value != ")")
                    {
                        mensajes.Add(new Formulador.Mensajes("la función 'PADRE' y la sub-función 'VALOR' debe llevar los argumentos dentro de paréntesis  [PADRE(fila).VALOR[columna]]."));
                        return false;
                    }
                    if (!EsNumerico(matches[index + 7].Value))
                    {
                        mensajes.Add(new Formulador.Mensajes("El indicador de columna deben ser numérico [PADRE(fila).VALOR(columna)]."));
                        return false;
                    }
                }
                else if (v == lista[1])
                {
                    if (matches[index + 6].Value != "(" || matches[index + 10].Value != ")")
                    {
                        mensajes.Add(new Formulador.Mensajes("la función 'PADRE' y la sub-función 'HIJO' debe llevar los argumentos dentro de paréntesis  [PADRE(fila).HIJO[fila, columna]]."));
                        return false;
                    }
                    if (!EsNumerico(matches[index + 7].Value) || !EsNumerico(matches[index + 9].Value))
                    {
                        mensajes.Add(new Formulador.Mensajes("los indicadores de fila y de columna deben ser numéricos [PADRE(fila).HIJO(fila, columna)]."));
                        return false;
                    }
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
