using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
namespace Formulador
{
    public class AnalizadorLexico : Formulacion_General.ValidacionesGenerales
    {
        #region Variables
        private ParametrosCollection paramlist;
        private ObjetosCollection objlist;
        private Descuentos descuentoslist;             
        private string valorfinal = string.Empty;        
        #endregion

        #region Constructor
        public AnalizadorLexico() : base()
        {
            if (Properties.Settings.Default.Consola)
            { Console.WriteLine("Iniciando analizador"); }
            paramlist = new ParametrosCollection();
            objlist = new ObjetosCollection();
            descuentoslist = new Descuentos();
            if (Properties.Settings.Default.Consola)
            { Console.WriteLine("Inicio ok"); }

        }
        #endregion

        #region Propiedades
        public ParametrosCollection ListaVariables
        {
            get
            {
                return paramlist;
            }
        }
        public ObjetosCollection ListaMateriales
        {
            get
            {
                return objlist;
            }
        }
        public Descuentos ListaDescuentos
        {
            get { return descuentoslist; }
        }
        public string ValorFinal
        {
            get
            {
                return valorfinal;
            }
        }
        #endregion

        #region Valoración Materiales
        private List<Parametro> valorados = new List<Parametro>();
        public List<Parametro> VerificarDependenciasEntreMateriales(string expresion)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio verificación entre dependencias"); }
                List<Parametro> dependencias = new List<Parametro>();
                MatchCollection matches = analiza.Matches(expresion);
                for (int i = 0; i < matches.Count; i++)
                {
                    if (objlist.Contains(matches[i].Value))
                    {
                        if (VerificarObjeto(i, matches))
                        {
                            Objeto obj = objlist[matches[i].Value, Convert.ToInt32(matches[i + 2].Value)];
                            i += 5;
                            if (obj.Parametros.Contains(matches[i].Value))
                            {
                                if (!valorados.Contains(obj.Parametros[matches[i].Value]))
                                {
                                    dependencias.Add(obj.Parametros[matches[i].Value]);
                                }
                            }
                        }
                    }
                }
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin verificación entre dependencias"); }
                return dependencias;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }
        }        
        public void ValorarElementosMaterial()
        {
            string error = string.Empty;
            string errord = string.Empty;
            string errorp = string.Empty;
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio valorar elementos material" ); }
                valorados.Clear();
                foreach (Objeto o in objlist)
                {
                    error = o.Nombre + "Del modelo: " + o.Id.ToString() +  "[" + Convert.ToString(o.Indice) + "] ";
                    if (Properties.Settings.Default.Consola)
                    { Console.WriteLine(error); }
                    o.Descuentos.All(d =>
                    {
                        errord = " Descuento :" + d.Nombre + " ";
                        if (!string.IsNullOrEmpty(d.formula))
                        {
                            errord = " Formula :" + d.formula + " ";
                            ValorarDescuento(d);
                        }                        
                        if (Properties.Settings.Default.Consola)
                        { Console.WriteLine(errord); }
                        return true;
                    });

                    o.Parametros.All(p =>
                    {
                        errorp = " Parámetro :" + p.Nombre + " " + " Formula: " + p.Formula;
                        if (!string.IsNullOrEmpty(p.Formula) && !valorados.Contains(p))
                        {
                            ValorarParametro(p);
                        }
                        if (Properties.Settings.Default.Consola)
                        { Console.WriteLine(errorp); }                        
                        errorp = string.Empty;
                        return true;
                    });
                }
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin valorar elementos material"); }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + error + "=>" + errord + "=>" + errorp + " => " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(error +  errord + errorp + " => " + ex.Message, ex.InnerException);
            }
        }
        public void ValorarMaterialIndividual( Objeto o)
        {
            string error = string.Empty;
            string errord = string.Empty;
            string errorp = string.Empty;
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio valorar material individual"); }
                valorados.Clear();

                error = o.Nombre + "[" + Convert.ToString(o.Indice) + "] ";
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine(error); }
                o.Descuentos.All(d =>
                {
                    errord = " Descuento :" + d.Nombre + " ";
                    if (!string.IsNullOrEmpty(d.formula))
                    {
                        errord = " Formula :" + d.formula + " ";
                        ValorarDescuento(d);
                    }
                    if (Properties.Settings.Default.Consola)
                    { Console.WriteLine(errord); }
                    return true;
                });

                o.Parametros.All(p =>
                {
                    errorp = " Parámetro :" + p.Nombre + " " + " Formula: " + p.Formula;
                    if (!string.IsNullOrEmpty(p.Formula) && !valorados.Contains(p))
                    {
                        ValorarParametro(p);
                    }
                    if (Properties.Settings.Default.Consola)
                    { Console.WriteLine(errorp); }
                    errorp = string.Empty;
                    return true;
                });
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin valorar material individual"); }

            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + error + "=>" + errord + "=>" + errorp + " => " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(error + errord + errorp + " => " + ex.Message, ex.InnerException);
            }
        }
        internal void ValorarDescuento(Descuento d)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio valorar descuento individual"); }
                List<Parametro> dependencias = VerificarDependenciasEntreMateriales(d.Formula);
                if (dependencias.Count > 0)
                {
                    foreach (Parametro pm in dependencias)
                    {
                        if (!string.IsNullOrEmpty(pm.Formula) && !valorados.Contains(pm))
                        {
                            ValorarParametro(pm);
                        }
                    }
                    d.Valor = Convert.ToDecimal(EjecutarExpresion(d.Formula.Remove(0, 1)));
                }
                else
                {
                    d.Valor = Convert.ToDecimal(EjecutarExpresion(d.Formula.Remove(0, 1)));
                }
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin valorar descuento individual"); }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        internal void ValorarParametro(Parametro p)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio valorar parámetro individual"); }
                List<Parametro> dependencias = VerificarDependenciasEntreMateriales(p.Formula);
                if (dependencias.Count > 0)
                {
                    foreach (Parametro pm in dependencias)
                    {
                        if (!string.IsNullOrEmpty(pm.Formula) && !valorados.Contains(pm))
                        {
                            if (pm.Valor != "0")
                            { ValorarParametro(pm); }                            
                        }
                    }                    
                    p.Valor = EjecutarExpresion(p.Formula.StartsWith("=") ? p.Formula.Remove(0, 1): p.Formula);    
                    valorados.Add(p);
                }
                else
                {
                    p.Valor = EjecutarExpresion(p.Formula.StartsWith("=") ? p.Formula.Remove(0, 1) : p.Formula);
                    valorados.Add(p);
                }
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin valorar parámetro individual"); }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Valoración Descuentos
        public void ValorarElementosDescuentos()
        {
            string error = string.Empty;
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio valoración elementos descuentos"); }                
                for (int i=0; i< descuentoslist.Count;i++)
                {
                    error = "Descuento: " +  descuentoslist[i].nombre + " Formula: " + descuentoslist[i].formula;
                    if(!string.IsNullOrEmpty(descuentoslist[i].formula))
                    {
                        ValorarDescuentoG(descuentoslist[i]);
                    }
                    if (Properties.Settings.Default.Consola)
                    { Console.WriteLine(error); }                    
                }
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin valoración elementos descuentos"); }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + error + " => " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(error + " => " + ex.Message, ex.InnerException);
            }
        }
        internal void ValorarDescuentoG(Descuento d)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio valorar descuentos"); }
                valorados.Clear();
                List<Parametro> dependencias = VerificarDependenciasEntreMateriales(d.Formula);
                if (dependencias.Count > 0)
                {
                    foreach (Parametro pm in dependencias)
                    {
                        if (!string.IsNullOrEmpty(pm.Formula) && !valorados.Contains(pm))
                        {
                            ValorarParametro(pm);
                        }
                    }                   
                }
                d.Valor = Convert.ToDecimal(EjecutarExpresion(d.Formula.StartsWith("=") ? d.Formula.Remove(0, 1) : d.Formula));
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("fin valorar descuentos"); }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Valoración Restricciones Parámetros Generales
        internal List<Restriccion> VerificarDependenciasEntreRestricciones(string expresion)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Inicio verificar dependencias entre restricciones");
                }
                List<Restriccion> dependecias = new List<Restriccion>();
                MatchCollection matches = analiza.Matches(expresion);
                for (int i = 0; i < matches.Count; i++)
                {
                    if (objlist.Contains(matches[i].Value))
                    {
                        if (VerificarObjeto(i, matches))
                        {                            
                            i += 5;                            
                        }
                    }
                    else if (paramlist.Contains(matches[i].Value))
                    {
                        bool restriccion = false;
                        if (VerificarVariable(i, matches, out restriccion))
                        {
                            if (restriccion)
                            {
                                Parametro param = paramlist[matches[i].Value];
                                i += 2;
                                dependecias.Add(param.Restricciones[matches[i].Value]);
                            }
                        }
                    }                    
                }
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Finalizo verificar dependencias entre restricciones");
                }
                return dependecias;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException));
                }
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public void ValorarRestricciones()

        {
            string error = string.Empty;
            try
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Inicio valoración restricciones");
                }
                List<Restriccion> valorados = new List<Restriccion>();
                paramlist.ToList().ForEach(delegate (Parametro p)
                {
                    p.Restricciones.ToList().ForEach(delegate (Restriccion r)
                    {
                        error = "Parametro: " + p.Nombre + " Restriccion: " + r.Nombre;
                        if (!string.IsNullOrEmpty(r.Formula) && !valorados.Contains(r))
                        {
                            ValorarRestriccion(r, ref valorados);
                        }
                    });
                });
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Fin valoración restricciones");
                }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException));
                }
                throw new Exception(error + " => " + ex.Message, ex.InnerException);
            }
        }
        internal void ValorarRestriccion(Restriccion r, ref List<Restriccion> valorados)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Inicio valorar restricción");
                }
                List<Restriccion> dependencias = VerificarDependenciasEntreRestricciones(r.Formula.StartsWith("=")? r.Formula.Remove(0,1):r.Formula);
                
                foreach (Restriccion rs in dependencias)
                {
                    ValorarRestriccion(rs, ref valorados);
                }
                if (!string.IsNullOrEmpty(r.Formula))
                { r.Valor = EjecutarExpresion(r.Formula.StartsWith("=") ? r.Formula.Remove(0, 1) : r.Formula); }                
                valorados.Add(r);
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Fin valorar restricción");
                }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException));
                }
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Verificación Dependencias
        public bool VerificarDependenciasConRestriccion(string parname)
        {
            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Verificando dependencia con restricción: " + parname);
            }
            if (paramlist.Contains(parname))
            {
                return VerificarDependenciasConRestriccion(paramlist[parname]);
            }
            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Verificando dependencia con restricción: " + parname);
            }
            return false;
        }
        public bool VerificarDependenciasConRestriccion(Parametro par)
        {
            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Verificando dependencia con restricción: " + par.Nombre);
            }
            for (int i = 0; i < paramlist.Count; i++)
            {
                if (paramlist[i] != par)
                {
                    for (int j = 0; j < paramlist[i].Restricciones.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(paramlist[i].Restricciones[j].Formula))
                        {
                            if (DependedeParametro(paramlist[i].Restricciones[j].Formula, par))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < objlist.Count; i++)
            {
                for (int j = 0; j < objlist[i].Parametros.Count; j++)
                {
                    if (!string.IsNullOrEmpty(objlist[i].Parametros[j].Formula))
                    {
                        if (DependedeParametro(objlist[i].Parametros[j].Formula, par))
                        {
                            return true;
                        }                        
                    }
                    for (int k = 0; k < objlist[i].Descuentos.Count; k++)
                    {
                        if (DependedeParametro(objlist[i].Descuentos[k].Formula, par))
                        {
                            return true;
                        }
                    }
                }
            }

            for (int i = 0; i < descuentoslist.Count; i++)
            {
                if (DependedeParametro(descuentoslist[i].Formula, par))
                {
                    return true;
                }                
            }

            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Fin verificando dependencia con restricción: " + par.Nombre);
            }
            return false;
        }
        internal bool DependedeParametro(string expresion, Parametro par)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Buscando dependencia de parámetro: " + par.Nombre);
                }
                List<Restriccion> dependecias = new List<Restriccion>();
                MatchCollection matches = analiza.Matches(expresion);
                for (int i = 0; i < matches.Count; i++)
                {
                    if (objlist.Contains(matches[i].Value))
                    {
                        if (VerificarObjeto(i, matches))
                        {
                            i += 5;
                        }
                    }
                    else if (paramlist.Contains(matches[i].Value))
                    {
                        if (paramlist[matches[i].Value] == par)
                        { return true; }
                    }
                }
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Fin Buscando dependencia de parámetro: " + par.Nombre);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public bool VerificarDependenciasConObjeto(int index, string objname )
        {
            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Verificando dependencias con objeto: " + objname);
            }
            if (objlist.Contains(objname, index))
            {
                return VerificarDependenciasConObjeto(objlist[objname, index]);
            }
            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Fin Verificando dependencias con objeto: " + objname);
            }
            return false;
        }
        public bool VerificarDependenciasConObjeto(Objeto obj)
        {
            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Verificando dependencias con objeto: " + obj.Nombre);
            }
            for (int i = 0; i < objlist.Count; i++)
            {
                if (objlist[i] != obj)
                {
                    for (int j = 0; j < objlist[i].Parametros.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(objlist[i].Parametros[j].Formula))
                        {
                            if (DependedeObjeto(objlist[i].Parametros[j].Formula, obj))
                            {
                                return true;
                            }
                        }
                        for (int k = 0; k < objlist[i].Descuentos.Count; k++)
                        {
                            if (DependedeObjeto(objlist[i].Descuentos[k].Formula, obj))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            if (Properties.Settings.Default.Consola)
            {
                Console.WriteLine("Fin Verificando dependencias con objeto: " + obj.Nombre);
            }
            return false;
        }
        internal bool DependedeObjeto(string expresion, Objeto obj)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Búsqueda dependencias en objeto: " + obj.Nombre);
                }
                List<Restriccion> dependecias = new List<Restriccion>();
                MatchCollection matches = analiza.Matches(expresion);
                for (int i = 0; i < matches.Count; i++)
                {
                    if (objlist.Contains(matches[i].Value))
                    {
                        if (objlist[matches[i].Value].Nombre == obj.Nombre)
                        {
                            if (objlist[matches[i].Value, Convert.ToInt32(matches[i+2].Value)] == obj)
                            {
                                return true;
                            }
                        }                        
                    }
                }
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Fin Búsqueda dependencias en objeto: " + obj.Nombre);
                }
                return false;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException));
                }
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        #endregion

        #region Procedimientos de verificación de sintaxis
        public bool VerificarSintaxis(string expresion, bool parsearExpresion)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Verificando Expresión: " + expresion);                    
                }
                if (!VerificarParentesis(expresion)) { return false; }
                List<string> exprParts = new List<string>();
                List<string> partesExpresionm = new List<string>();
                MatchCollection matches = analiza.Matches(expresion);
                bool validacion = true;
                for (int i = 0; i < matches.Count; i++)
                {
                    if (objlist.Contains(matches[i].Value))
                    {
                        if (VerificarObjeto(i, matches))
                        {
                            Objeto obj = objlist[matches[i].Value, Convert.ToInt32(matches[i + 2].Value)];
                            i += 5;
                            if (obj.Parametros.Contains(matches[i].Value))
                            { exprParts.Add(obj.Parametros[matches[i].Value].Valor); }
                            else if (obj.Descuentos.Contains(matches[i].Value))
                            {

                                exprParts.Add(obj.Descuentos[matches[i].Value].Valor.ToString());
                            }
                            else
                            {
                                mensajes.Add(new Formulador.Mensajes("El " + obj.Nombre + " " + obj.Indice + "No tiene el elemento: " + matches[i].Value));
                                validacion = false;                                
                            }
                        }
                        else { validacion = false; ; }
                    }
                    else if (paramlist.Contains(matches[i].Value))
                    {
                        bool restriccion = false;
                        if (VerificarVariable(i, matches, out restriccion))
                        {
                            if (restriccion)
                            {
                                Parametro param = paramlist[matches[i].Value];
                                i += 2;
                                exprParts.Add(param.Restricciones[matches[i].Value].Valor);
                            }
                            else
                            {
                                exprParts.Add(paramlist[matches[i].Value].Valor);
                            }
                        }
                        else { validacion = false; }
                    }
                    else if (descuentoslist.Contains(matches[i].Value))
                    {
                        if(VerificarDescuento(i, matches))
                        {
                            exprParts.Add(Convert.ToString(descuentoslist[matches[i].Value].valor));
                        }
                        else
                        { validacion = false; }                        
                    }
                    else if (EsParentesis(matches[i].Value) ||
                        EsSeparador(matches[i].Value) || EsCadenadeTexto(matches[i].Value))
                    {
                        exprParts.Add(matches[i].Value);
                    }
                    else if (exec.VariablesNumericas.ContainsKey(matches[i].Value) || EsNumerico(matches[i].Value))
                    {
                        if (VerficarVariablePredefinidaoValorNumerico(i, matches))
                        {
                            exprParts.Add(matches[i].Value);
                        }
                        else
                        { validacion = false; }

                    }
                    else if (exec.OperadoresMatematicos.Contains(matches[i].Value))
                    {
                        if (VerificarOperadorMatematico(i, matches))
                        {
                            exprParts.Add(matches[i].Value);
                        }
                        else
                        {
                            validacion = false;
                        }
                    }
                    else if (exec.OperadoresBooleanos.Contains(matches[i].Value))
                    {
                        if (VerificarOperadorBooleano(i, matches))
                        {
                            exprParts.Add(matches[i].Value);
                        }
                        else
                        {
                            validacion = false;
                        }
                    }
                    else if (exec.FuncionesMatematicas.ContainsKey(matches[i].Value) ||
                         exec.FuncionesCadena.ContainsKey(matches[i].Value))
                    {
                        if (VerificarFuncion(i, matches))
                        {
                            exprParts.Add(matches[i].Value);
                        }
                        else
                        {
                            validacion = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(matches[i].Value) || string.IsNullOrWhiteSpace(matches[i].Value))
                    {
                    }
                    else
                    {
                        if (VerificarInExistente(i, matches))
                        {
                            exprParts.Add(matches[i].Value);
                        }
                        else
                        { validacion = false; }
                    }
                }

                if (parsearExpresion && validacion)
                {
                    if (Properties.Settings.Default.Consola)
                    {                        
                        Console.WriteLine("Expresión Parseada: " + string.Join("", exprParts));
                    }
                    for (int i = 0; i < exprParts.Count; i++)
                    {
                        if (EsNumerico(exprParts[i]))
                        {
                            exprParts[i] = Convert.ToDecimal(exprParts[i]).ToString();
                        }
                        exprParts[i] = exprParts[i].Replace("'", "");
                    }
                    valorfinal = exec.Parse(exprParts);
                }
                if (Properties.Settings.Default.Consola)
                {
                    Console.WriteLine("Fin Verificando Expresión: " + expresion);
                }
                return validacion;
            }
            catch (Exception ex)
            {                
                mensajes.Add(new Formulador.Mensajes(ex.Message));
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public string EjecutarExpresion(string expresion)
        {
            List<string> exprParts = new List<string>();
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.Write("Ejecución Expresión: " + expresion); }                
                List<string> partesExpresionm = new List<string>();
                MatchCollection matches = analiza.Matches(expresion);
                for (int i = 0; i < matches.Count; i++)
                {
                    if (objlist.Contains(matches[i].Value))
                    {
                        List<Objeto> a = objlist.Where(x => x.Nombre == matches[i].Value).ToList();
                        Objeto obj = objlist[matches[i].Value, Convert.ToInt32(matches[i + 2].Value)];
                        i += 5;                        
                        if (obj.Parametros.Contains(matches[i].Value))
                        { exprParts.Add(obj.Parametros[matches[i].Value].Valor); }
                        else if (obj.Descuentos.Contains(matches[i].Value))
                        {exprParts.Add(obj.Descuentos[matches[i].Value].Valor.ToString());
                        }
                        else
                        {throw new Exception("El " + obj.Nombre + "[" + obj.Indice + "] No tiene el elemento: " + matches[i].Value);
                        }                            
                    }
                    else if (paramlist.Contains(matches[i].Value))
                    {
                        bool restriccion = false;
                        if (VerificarVariable(i, matches, out restriccion))
                        {
                            if (restriccion)
                            {
                                Parametro param = paramlist[matches[i].Value];
                                i += 2;
                                exprParts.Add(param.Restricciones[matches[i].Value].Valor);
                            }
                            else
                            {
                                exprParts.Add(paramlist[matches[i].Value].Valor);
                            }
                        }
                    }
                    else if (descuentoslist.Contains(matches[i].Value))
                    {
                        if (VerificarDescuento(i, matches))
                        {
                            exprParts.Add(Convert.ToString(descuentoslist[matches[i].Value].valor));
                        }
                    }
                    else if (EsParentesis(matches[i].Value) ||
                            EsSeparador(matches[i].Value) || EsCadenadeTexto(matches[i].Value))
                    {
                        exprParts.Add(matches[i].Value);
                    }
                    else if (exec.VariablesNumericas.ContainsKey(matches[i].Value) || EsNumerico(matches[i].Value))
                    {
                        exprParts.Add(matches[i].Value);
                    }
                    else if (exec.OperadoresMatematicos.Contains(matches[i].Value))
                    {
                            exprParts.Add(matches[i].Value);
                    }
                    else if (exec.OperadoresBooleanos.Contains(matches[i].Value))
                    {
                            exprParts.Add(matches[i].Value);
                    }
                    else if (exec.FuncionesMatematicas.ContainsKey(matches[i].Value) ||
                         exec.FuncionesCadena.ContainsKey(matches[i].Value))
                    {
                            exprParts.Add(matches[i].Value);
                    }
                    else if (string.IsNullOrEmpty(matches[i].Value) || string.IsNullOrWhiteSpace(matches[i].Value))
                    {
                    }
                    else
                    {
                            exprParts.Add(matches[i].Value);
                    }
                }
                if (Properties.Settings.Default.Consola)
                {                    
                    Console.WriteLine("| Parseada: " + string.Join("", exprParts));
                }                
                for (int i = 0; i < exprParts.Count; i++)
                {
                    if (EsNumerico(exprParts[i]))
                    {
                        exprParts[i] = Convert.ToDecimal(exprParts[i]).ToString();
                    }
                    exprParts[i] = exprParts[i].Replace("'", "");                    
                }
                if (Properties.Settings.Default.Consola)
                { Console.Write("Fin ejecución expresión: " + expresion); }
                return exec.Parse(exprParts);               
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.Write("Finalizo con errores: " + ex.Message + " | "  + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message + " | " +  string.Join("", exprParts.ToArray()) + Convert.ToString(ex.InnerException), ex.InnerException);
            }

        }        
        private bool VerificarObjeto(int index, MatchCollection matches)
        {
            try
            {
                if (index + 5 > matches.Count)
                { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", información incompleta", matches[index].Index, matches[index].Length)); return false; }
                if (index > 0)
                {
                    if (!(matches[index - 1].Value.Equals("(") || exec.OperadoresMatematicos.Contains(matches[index - 1].Value)))
                    { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", debe estar antecedido de un paréntesis de apertura o un operador.", matches[index].Index - 1, matches[index].Length + 1)); return false; }
                }
                if (!matches[index + 1].Value.Equals("("))
                { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", falta el paréntesis de apertura.", matches[index].Index, matches[index].Length + 1)); return false; }
                if (!matches[index + 3].Value.Equals(")"))
                { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", falta el paréntesis de cierre.", matches[index].Index, matches[index].Length + 3)); return false; }
                if (!EsNumerico(matches[index + 2].Value))
                { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", el valor entre paréntesis debe ser numérico.", matches[index].Index, matches[index].Length + 2)); return false; }
                if (!matches[index + 4].Value.Equals("."))
                { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", después del indicador de posición debe ir un punto, para indicar la variable que se usara.", matches[index].Index, matches[index].Length + 4)); return false; }
                int count = objlist.CountbyName(matches[index].Value);
                if (count < Convert.ToInt32(matches[index + 2].Value))
                { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", de este, solo hay " + count + "elementos, se ha indicado " + matches[index + 2].Value + "como índice")); return false; }
                Objeto obj = objlist[matches[index].Value, Convert.ToInt32(matches[index + 2].Value)];
                if (!obj.Parametros.Contains(matches[index + 5].Value) && !obj.Descuentos.Contains(matches[index + 5].Value))
                { mensajes.Add(new Mensajes("Error de sintaxis en el objeto " + matches[index].Value + ", el elemento: " + matches[index + 5].Value + ", no pertenece al objeto.", matches[index + 5].Index, matches[index + 5].Length)); return false; }
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error desconocido utilizando un objeto (vidrio, perfil o accesorio). " + ex.Message,
                    matches[index].Index, matches[index].Length));
                return false;
            }
        }
        private bool VerificarVariable(int index, MatchCollection matches, out bool tienerestriccion)
        {
            try
            {
                bool trestringe = false;
                if (index < matches.Count - 1)
                {
                    trestringe = matches[index + 1].Value.Equals(".");
                }
                tienerestriccion = trestringe;

                if (index > 0)
                {
                    if (!(matches[index - 1].Value.Equals("(") || matches[index - 1].Value.Equals(".") || matches[index - 1].Value.Equals(",") || exec.OperadoresMatematicos.Contains(matches[index - 1].Value) || string.IsNullOrWhiteSpace(matches[index - 1].Value)))
                    { mensajes.Add(new Mensajes("Error de sintaxis en la variable " + matches[index].Value + ", debe estar precedido de un paréntesis de apertura, un punto o un operador", matches[index - 1].Index, matches[index].Length + 1)); return false; }
                }
                if (trestringe)
                {
                    Parametro param = paramlist[matches[index].Value];
                    if (!param.Restricciones.Contains(matches[index + 2].Value))
                    { mensajes.Add(new Mensajes("Error de sintaxis en la variable " + matches[index].Value + ", la restricción:" + matches[index + 2].Value + ", no pertenece a la variable.", matches[index + 2].Index, matches[index + 2].Length)); return false; }
                }
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error utilizando una de las variables de la plantilla. " + ex.Message,
                    matches[index].Index, matches[index].Length));
                tienerestriccion = false;
                return false;
            }
        }
        private bool VerificarDescuento(int index, MatchCollection matches)
        {
            try
            {
                if (index > 0)
                {
                    if (!(matches[index - 1].Value.Equals("(") || matches[index - 1].Value.Equals(".") || matches[index - 1].Value.Equals(",") || exec.OperadoresMatematicos.Contains(matches[index - 1].Value) || string.IsNullOrWhiteSpace(matches[index - 1].Value)))
                    { mensajes.Add(new Mensajes("Error de sintaxis en el descuento " + matches[index].Value + ", debe estar precedido de un paréntesis de apertura, un punto o un operador", matches[index - 1].Index, matches[index].Length + 1)); return false; }
                }                
                return true;
            }
            catch (Exception ex)
            {
                mensajes.Add(new Mensajes("Error utilizando una de las variables de la plantilla. " + ex.Message,
                    matches[index].Index, matches[index].Length));
                return false;
            }
        }
        #endregion

        #region Ayudas Formulación

        private enum TipoItem
        {
            Objeto = 0,
            Variable = 1,
            VariableObjeto = 2,
            Restriccion = 3,
            Predeterminado = 4,
            DespuesVariable = 5,
            Ninguno = 6
        }

        private List<string> CargarListadeAyuda(bool cargarobjetos, bool cargarvariables,
            bool cargarvariablesnumericas, bool cargarfuncionesnumericas,
            bool cargarvariablescadena, bool cargarfuncionescadena, bool cargardescuentos)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio carga lista ayuda"); }
                List<string> listaretorno = new List<string>();
                if (cargarobjetos) listaretorno.AddRange(objlist.Select(x => x.Nombre).ToArray());                
                if (cargarvariables) listaretorno.AddRange(paramlist.Select(x => x.Nombre).ToArray());
                if (cargardescuentos) listaretorno.AddRange(descuentoslist.Select(x => x.Nombre).ToArray());
                if (cargarvariablesnumericas) listaretorno.AddRange(exec.VariablesNumericas.Keys);
                if (cargarfuncionesnumericas) listaretorno.AddRange(exec.FuncionesMatematicas.Keys);
                if (cargarvariablescadena) listaretorno.AddRange(exec.VariablesCadena.Keys);
                if (cargarfuncionescadena) listaretorno.AddRange(exec.FuncionesCadena.Keys);
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin carga lista ayuda"); }
                return listaretorno;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public List<string> ListaAyuda(string expresion, int selectionstart, out Match ultimoresultado)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio Lista Ayuda"); }
                ultimoresultado = null;
                List<string> listaretorno = new List<string>();
                if (expresion.Length <= 1 && !EsNumerico(expresion))
                {
                    listaretorno = CargarListadeAyuda(true, true, true, true, true, true, true);
                }
                else
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
                    ultimoresultado = matches[ultimoevaluar];
                    string nombreanterior = string.Empty;
                    int indiceanterior = -1;
                    List<string> listaposiblesvalores;
                    TipoItem anterior = validacionListaAyuda(matches, ultimoevaluar, out nombreanterior, out indiceanterior,out listaposiblesvalores);
                    switch (anterior)
                    {
                        case TipoItem.Objeto:
                            {
                                Objeto obj = objlist[nombreanterior, indiceanterior];
                                listaretorno.AddRange(obj.Parametros.Select(x => x.Nombre).ToArray());
                                listaretorno.AddRange(obj.Descuentos.Select(x => x.Nombre).ToArray());
                                break;
                            }
                        case TipoItem.VariableObjeto:
                            {
                                break;
                            }
                        case TipoItem.Variable:
                            {
                                listaretorno.AddRange(paramlist[nombreanterior].Restricciones.Select(x => x.Nombre).ToArray());                                
                                break;
                            }
                        case TipoItem.Restriccion:
                            {
                                break;
                            }
                        case TipoItem.Ninguno:
                            {
                                break;
                            }
                        case TipoItem.DespuesVariable:
                            {
                                listaretorno = listaposiblesvalores;
                                break;
                            }
                        default:
                            {
                                listaretorno = CargarListadeAyuda(true, true, true, true,
                                    true, true, true);
                                break;
                            }
                    }
                }
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Fin Lista Ayuda"); }
                return listaretorno;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException)); }
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private TipoItem validacionListaAyuda(MatchCollection matches, int ultimoaevaluar, out string nombreultimo, out int indiceultimo, out List<string> listaValores)
        {
            try
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("Inicio carga lista ayuda"); }
                nombreultimo = string.Empty;
                indiceultimo = 0;
                listaValores = new List<string>();

                if (matches[ultimoaevaluar].Value.Equals("."))
                {
                    if (matches[ultimoaevaluar - 1].Value.Equals(")"))
                    {
                        if (objlist.Contains(matches[ultimoaevaluar - 4].Value))
                        {
                            indiceultimo = Convert.ToInt32(matches[ultimoaevaluar - 2].Value);
                            nombreultimo = matches[ultimoaevaluar - 4].Value;
                            if (Properties.Settings.Default.Consola)
                            { Console.WriteLine("finalizo validación lista ayuda -> objeto"); }
                            return TipoItem.Objeto;
                        }
                    }
                    else
                    {
                        if (paramlist.Contains(matches[ultimoaevaluar - 1].Value))
                        {
                            if (ultimoaevaluar > 6)
                            {
                                if (objlist.Contains(matches[ultimoaevaluar - 6].Value))
                                {
                                    if (Properties.Settings.Default.Consola)
                                    { Console.WriteLine("finalizo validación lista ayuda -> variable objeto"); }
                                    return TipoItem.VariableObjeto;
                                }
                                else
                                {
                                    nombreultimo = matches[ultimoaevaluar - 1].Value;
                                    if (Properties.Settings.Default.Consola)
                                    { Console.WriteLine("finalizo validación lista ayuda -> variable general"); }
                                    return TipoItem.Variable;
                                }
                            }
                            else
                            {
                                nombreultimo = matches[ultimoaevaluar - 1].Value;
                                if (Properties.Settings.Default.Consola)
                                { Console.WriteLine("finalizo validación lista ayuda -> variable general"); }
                                return TipoItem.Variable;
                            }

                        }
                        else
                        {
                            if (matches[ultimoaevaluar - 3].Value.Equals(")"))
                            {
                                if (Properties.Settings.Default.Consola)
                                { Console.WriteLine("finalizo validación lista ayuda -> variables objeto"); }
                                return TipoItem.VariableObjeto;
                            }
                        }
                    }
                }
                else if (matches[ultimoaevaluar].Value.Equals("'") || matches[ultimoaevaluar].Value.StartsWith("'"))
                {
                    if ((matches[ultimoaevaluar - 1].Value.Equals("=")))
                    {
                        if (ultimoaevaluar >= 8)
                        {

                            if (objlist.Contains(matches[ultimoaevaluar - 7].Value, EsNumerico(matches[ultimoaevaluar - 5].Value) ? Convert.ToInt32(matches[ultimoaevaluar - 5].Value) : -1))
                            {
                                Objeto mobj = objlist[matches[ultimoaevaluar - 7].Value, Convert.ToInt32(matches[ultimoaevaluar - 5].Value)];
                                if (mobj.Parametros.Contains(matches[ultimoaevaluar - 2].Value))
                                {
                                    listaValores = mobj.Parametros[matches[ultimoaevaluar - 2].Value].PosiblesValores;
                                    if (Properties.Settings.Default.Consola)
                                    { Console.WriteLine("finalizo validación lista ayuda -> Después de variable"); }
                                    return TipoItem.DespuesVariable;
                                }
                            }
                            else if (paramlist.Contains(matches[ultimoaevaluar - 2].Value))
                            {
                                listaValores = paramlist[matches[ultimoaevaluar - 2].Value].PosiblesValores;
                                if (Properties.Settings.Default.Consola)
                                { Console.WriteLine("finalizo validación lista ayuda -> Después de variable"); }
                                return TipoItem.DespuesVariable;

                            }
                        }
                        else if (ultimoaevaluar >= 2)
                        {
                            if (paramlist.Contains(matches[ultimoaevaluar - 2].Value))
                            {
                                listaValores = paramlist[matches[ultimoaevaluar - 2].Value].PosiblesValores;
                                if (Properties.Settings.Default.Consola)
                                { Console.WriteLine("finalizo validación lista ayuda -> Después de variable"); }
                                return TipoItem.DespuesVariable;

                            }
                        }

                    }
                    else
                    {
                        if (Properties.Settings.Default.Consola)
                        { Console.WriteLine("finalizo validación lista ayuda -> ninguno"); }
                        return TipoItem.Ninguno;
                    }
                }
                else
                {
                    if (Properties.Settings.Default.Consola)
                    { Console.WriteLine("finalizo validación lista ayuda -> Predeterminado"); }
                    return TipoItem.Predeterminado;
                }
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("finalizo validación lista ayuda -> Predeterminado"); }
                return TipoItem.Predeterminado;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.Consola)
                { Console.WriteLine("finalizo con errores: " + ex.Message + " | " + Convert.ToString(ex.InnerException) + " | Por defecto retorna -> Ninguno"); }
                nombreultimo = string.Empty;
                indiceultimo = 0;
                listaValores = new List<string>();
                return TipoItem.Ninguno;
            }
        }

        #endregion

        #region reemplazos de formula
        public void reemplazar_elemento_en_formula(string original, string nuevo)
        {
            try
            {
                paramlist.ToList().ForEach(delegate (Parametro p) {
                    p.Formula = p.Formula.Replace(original, nuevo);
                });
                descuentoslist.ToList().ForEach(delegate (Descuento d) {
                    d.Formula = d.Formula.Replace(original, nuevo);
                });
                objlist.ToList().ForEach(delegate (Objeto o) {
                    o.Parametros.ToList().ForEach(delegate (Parametro p) {
                        p.Formula = p.Formula.Replace(original, nuevo);
                    });
                    o.Descuentos.ToList().ForEach(delegate (Descuento d) {
                        d.Formula = d.Formula.Replace(original, nuevo);
                    });
                });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion
        public void Dispose()
        {
            valorfinal = string.Empty;
            mensajes.Clear();
            paramlist.Clear();
            objlist.Clear();
            paramlist = null;
            objlist = null;
            exec = null;
            analiza = null;
        }
    }
}
