using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ControlesPersonalizados.Editor_RTF
{
    public class DocumentoRTF
    {
        #region Estructuras
        public enum TipoVineta
        {
            NINGUNO = 0,
            PUNTO_NEGRO = 1,
            PUNTO_BLANCO = 2,
            CUADRADO = 3,
            FLECHA = 4
        }

        public enum TipoEnumerador
        {
            NINGUNO = 0,
            NUMERO_PUNTO = 1,
            NUMERO_PARENTESIS = 2,
            ROMANO_MAYUSCULA = 3,
            ROMANO_MINUSCULA = 4,
            LETRAS_MAYUSCULA = 5,
            LETRAS_MINUSCULA = 6
        }
        #endregion

        #region Trabajo Word
        public void Exportar_a_PDF(string rutaorigen, string rutadestino)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = false;
                Microsoft.Office.Interop.Word.Document documento = app.Documents.Open(FileName: rutaorigen);
                documento.SaveAs2(rutadestino, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                app.Quit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void Exportar_a_WORD(string rutaorigen, string rutadestino)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = false;
                Microsoft.Office.Interop.Word.Document documento = app.Documents.Open(FileName: rutaorigen);
                documento.SaveAsQuickStyleSet(rutadestino);
                //documento.SaveAs2(rutadestino);
                app.Quit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        public string Base_TipoWord(string[] fuentes, Color[] colores, string contenido= "")
        {
            try
            {
                StringBuilder rtfBase = new StringBuilder();
                rtfBase.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang9226").AppendLine();
                rtfBase.Append(@"{\fonttbl").AppendLine();
                for(int i=0;i<fuentes.Length;i++)
                { rtfBase.Append(@"{\f" + i.ToString() + "\fnil\fcharset0" + fuentes[i] + ";}").AppendLine(); }            
                rtfBase.Append(@"}").AppendLine();
                rtfBase.Append(@"{\colortbl");
                for(int i=0;i<colores.Length;i++)
                {rtfBase.Append(String.Format(@";\red{0}\green{1}\blue{2}\", colores[i].R, colores[i].G, colores[i].B)).AppendLine();}
                rtfBase.Append(@";}").AppendLine();
                rtfBase.Append(@"\viewkind4\uc1\pard\fs24\lang1034").AppendLine();
                rtfBase.Append(contenido).AppendLine();
                rtfBase.Append(@"}").AppendLine();
                return rtfBase.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string Encabezado_TipoWord(string contenidoEncabezado)
        {
            try
            {
                StringBuilder encabezado = new StringBuilder();
                encabezado.Append(@"{\headerr \ltrpar \pard\plain \ltrpar\s15\ql \li0\ri0\widctlpar").AppendLine();
                encabezado.Append(@"\tqc\tx4419\tqr\tx8838\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 \rtlch\fcs1 \af31507\afs22\alang1025 \ltrch\fcs0 \f31506\fs22\lang9226\langfe1033\cgrid\langnp9226\langfenp1033 {\rtlch\fcs1 \af31507 \ltrch\fcs0").AppendLine();
                encabezado.Append(@"\lang3082\langfe1033\langnp3082\insrsid8219663 ").AppendLine();
                encabezado.AppendLine(contenidoEncabezado);
                encabezado.Append(@"}{\rtlch\fcs1 \af31507 \ltrch\fcs0 \lang3082\langfe1033\langnp3082\insrsid8219663\charrsid8219663 ").AppendLine();
                encabezado.Append(@"}}").AppendLine();
            return encabezado.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string Cuerpo_TipoWord(string contenidocuerpo)
        {
            try
            {
                StringBuilder cuerpo = new StringBuilder();
                cuerpo.Append(@"{\rtlch\fcs1 \af0 \ltrch\fcs0 \insrsid11141738 ").AppendLine();
                cuerpo.AppendLine(contenidocuerpo);
                cuerpo.Append("}").AppendLine();
                return cuerpo.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string PiedePagina_TipoWord(string contenidopiedepagina)
        {
            try
            {
                StringBuilder pdep = new StringBuilder();
                //Parametrizacion del Pie de Pagina
                pdep.Append(@"{\footerr \ltrpar \pard\plain \ltrpar\s17\qr \li0\ri0\widctlpar\tqc\tx4419");
                pdep.Append(@"\tqr\tx8838\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0");
                pdep.Append(@"\pararsid13904245 \rtlch\fcs1 \af31507\afs22\alang1025 \ltrch\fcs0 ");
                pdep.Append(@"\fs22\lang9226\langfe9226\loch\af31506\hich\af31506\dbch\af31505");
                pdep.Append(@"\cgrid\langnp9226\langfenp9226 ").AppendLine();
                //Alineaciones
                pdep.Append(@"{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\lang3082\langfe1033\langnp3082\langfenp1033\insrsid11141738");
                pdep.Append(@"\charrsid11141738 \par }");
                pdep.Append(@"\pard \ltrpar\s17\qr \li0\ri0\sa160\sl259\slmult1\widctlpar\tqc\tx4419\tqr");
                pdep.Append(@"\tx8838\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid13904245 ").AppendLine();
                //Contenido General
                pdep.Append(@"{\rtlch\fcs1 \af0 \ltrch\fcs0 \lang3082\langfe1033\langnp3082\insrsid11141738");
                pdep.Append(@" \hich\af1\dbch\af31505\loch\f1");
                pdep.Append(contenidopiedepagina);
                pdep.Append(@"\par}").AppendLine();

                #region Paginacion
                //Agregando palabra (Pagina)
                pdep.Append(@"{\rtlch\fcs1 \af1 \ltrch\fcs0 ");
                pdep.Append(@"\f1\lang3082\langfe1033\langnp3082\langfenp1033\insrsid10510734\charrsid11141738 ");
                pdep.Append(@"\hich\af1\dbch\af31505\loch\f1 \hich\f1 P\'e1\loch\f1 gina }").AppendLine();
                //Agregando numero pagina
                pdep.Append(@"{\field{\*\fldinst {\rtlch\fcs1 \ab\af1 \ltrch\fcs0 ");
                pdep.Append(@"\b\f1\lang3082\langfe1033\langnp3082\langfenp1033\insrsid10510734");
                pdep.Append(@"\charrsid11141738 \hich\af1\dbch\af31505\loch\f1 PAGE}}"); //Clave
                pdep.Append(@"{\fldrslt {\rtlch\fcs1 \ab\af1 \ltrch\fcs0 \b\f1\lang1024");
                pdep.Append(@"\langfe1024\noproof\langnp3082\langfenp1033\insrsid13904245 ");
                pdep.Append(@"\hich\af1\dbch\af31505\loch\f1 5}}}").AppendLine();
                //Agregando cantidad total de paginas
                pdep.Append(@"\sectd \ltrsect\linex0\endnhere\sectdefaultcl\sftnbj ");
                pdep.Append(@"{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\lang3082\langfe1033\langnp3082");
                pdep.Append(@"\langfenp1033\insrsid10510734\charrsid11141738 \hich\af1");
                pdep.Append(@"\dbch\af31505\loch\f1  de }{\field{\*\fldinst{");
                pdep.Append(@"\rtlch\fcs1 \ab\af1 \ltrch\fcs0 \b\f1\lang3082\langfe1033");
                pdep.Append(@"\langnp3082\langfenp1033\insrsid10510734\charrsid11141738 ");
                pdep.Append(@"\hich\af1\dbch\af31505\loch\f1 NUMPAGES}}").AppendLine();
                //Finalización Pie de Pagina
                pdep.Append(@"{\fldrslt {\rtlch\fcs1 \ab\af1 \ltrch\fcs0 ");
                pdep.Append(@"\b\f1\lang1024\langfe1024\noproof\langnp3082\langfenp1033\insrsid13904245 ");
                pdep.Append(@"\hich\af1\dbch\af31505\loch\f1 5}}}\sectd \ltrsect\linex0");
                pdep.Append(@"\endnhere\sectdefaultcl\sftnbj {\rtlch\fcs1 \af31507 \ltrch\fcs0 \insrsid14108830 ");
                pdep.Append(@"\par }}").AppendLine();
                #endregion
                return pdep.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public int PixelesATwips(int valor)
        {
            return valor * 15;
        }
        public string Tabla(int filas, int columnas, int anchodocumento)
        {
            StringBuilder tabla = new StringBuilder();
            int anchotwips = PixelesATwips(anchodocumento);
            int finalcolumna = anchotwips / columnas;
            tabla.Append(@"{\trowd\trgaph100").AppendLine();
            for(int i=1;i<=columnas;i++)
            {
                tabla.Append(@"\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10").AppendLine(); //Bordes top left bottom right
                tabla.Append(@"\cellx" + Convert.ToString(finalcolumna * i)).AppendLine(); ;
            }
            for(int i=0;i<filas;i++)
            {
                tabla.Append(@"\intbl\ltrpar\sl252\slmult1\f0\fs22").AppendLine();
                for (int j = 1; j <= columnas; j++)
                {
                    tabla.Append(@"\cell");
                }
                tabla.Append(@"\row").AppendLine();
            }
            tabla.Append("}");  
            return tabla.ToString();
        }

        public string Tabla(object[,] matriz, int anchodocumento, bool encabezado = false)
        {
            StringBuilder tabla = new StringBuilder();
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);
            int anchotwips = PixelesATwips(anchodocumento);
            Bitmap bmp = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(bmp);
            List<int> ancho_columnas = new List<int>();
            for (int j = 0; j < columnas; j++)
            {
                ancho_columnas.Add(0);
            }
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                  int ancho = Convert.ToInt32( g.MeasureString(Convert.ToString(matriz[i, j]), new Font("arial", 11)).Width);
                    if (ancho > ancho_columnas[j])
                    {
                        ancho_columnas[j] = ancho;
                    }
                }
            }
            decimal sum_anchos = (decimal)ancho_columnas.Sum();
            for (int j = 0; j < columnas; j++)
            {
                int ancho_anterior = (j > 0 ? ancho_columnas[j - 1] : 0);
                int ancho_actual = (int)((decimal)anchotwips * (((decimal)ancho_columnas[j]-10) / sum_anchos));
                ancho_columnas[j] = ancho_anterior + ancho_actual;
            }

            tabla.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang308");
            tabla.Append(@"{\fonttbl {\f0\fnil\fcharset0 Bookman Old Style;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}").AppendLine();        
            tabla.Append(@"{\colortbl;\red0\green0\blue0;\red194\green194\blue194;}");
            tabla.Append(@"\viewkind4\uc1").AppendLine();

            for (int i = 0; i < filas; i++)
            {
                tabla.Append(@"\trowd\trgaph70");
                #region Bordes Fila
                tabla.Append(@"\trbrdrt\brdrs\brdrw10 "); //Borde Arriba
                tabla.Append(@"\trbrdrl\brdrs\brdrw10 "); // Borde Izquierda
                tabla.Append(@"\trbrdrb\brdrs\brdrw10 "); //Borde Abajo
                tabla.Append(@"\trbrdrr\brdrs\brdrw10 "); //Borde Derecha
                #endregion
                for (int k = 0; k < columnas; k++)
                {
                    #region Bordes Celda
                    tabla.Append(@"\clbrdrt\brdrw15\brdrs "); //Borde arriba
                    tabla.Append(@"\clbrdrl\brdrw15\brdrs "); //Borde izquierda
                    tabla.Append(@"\clbrdrb\brdrw15\brdrs "); //Borde abajo
                    tabla.Append(@"\clbrdrr\brdrw15\brdrs "); //Borde izquierda
                    #endregion                    
                    tabla.Append(@"\cellx" + ancho_columnas[k]); //Convert.ToString(finalcolumna * k)) ;
                    
                }
                if (encabezado && i==0)
                { tabla.Append(@"\intbl\highlight2\cf1\b\f1\fs12 "); }
                else { tabla.Append(@"\intbl\highlight0\cf1\f0\fs12 "); }

                for (int j = 0; j < columnas; j++)
                {
                    tabla.Append(Convert.ToString(matriz[i, j]) + @"\cell ");
                }
                tabla.Append(@"\row").AppendLine();
            }
            tabla.Append(@"\pard").AppendLine();
            tabla.Append("}");
            return tabla.ToString();
        }


        public string[] ObtenerLista(string texto)
        {
            char reemplazo = Convert.ToChar(" ");
            texto = texto.Replace('\t', reemplazo);
            texto = texto.Replace('\u00B7', reemplazo);
            texto = texto.Replace('\u00A7', reemplazo);
            texto = texto.Replace('o', reemplazo);
            texto = texto.Replace('Ø', reemplazo);
            texto = texto.Replace(" ", "");
            Regex numeros = new Regex(@"[0-9]+([.]|[)])");
            texto = numeros.Replace(texto, "");
            Regex letras = new Regex(@"[a-zA-ZñÑ]+([.]|[)])");
            texto = letras.Replace(texto, "");
            return texto.Split(new char[] { '\r', '\n' }).Where(x=> !(string.IsNullOrEmpty(x) && string.IsNullOrWhiteSpace(x))).ToArray();
        }

        public string ListaVinetas(TipoVineta vineta, string[] lista, string fuente)
        {
            try
            {
                StringBuilder listaVinetas = new StringBuilder();
                listaVinetas.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang9226").AppendLine();
                listaVinetas.Append(@"{\fonttbl").AppendLine();
                if (vineta != TipoVineta.NINGUNO)
                {
                    listaVinetas.Append(@"{\f0\fnil\fprq2\fcharset2 Wingdings;}");
                    listaVinetas.Append(@"{\f1\froman\fprq2\fcharset2 Symbol;}");
                    listaVinetas.Append(@"{\f2\fmodern\fprq1\fcharset0 Courier New;}");
                    listaVinetas.Append(@"{\f3\froman\fprq2\fcharset0 " + fuente + @";}}");
                }
                else
                {
                    listaVinetas.Append(@"{\f0\froman\fprq2\fcharset0 " + fuente + @";}}");
                }
                listaVinetas.Append(@"\viewkind4\uc1\pard").AppendLine();
                if (vineta == TipoVineta.NINGUNO)
                {
                    listaVinetas.Append(@"\fi0\li0\slmult1").AppendLine();
                    for (int i = 0; i < lista.Length; i++)
                    {
                        listaVinetas.Append(lista[i].Trim() + @"\par").AppendLine();
                    }
                }
                else
                {
                    listaVinetas.Append(@"\ltrpar\slmult1").AppendLine();
                    for (int i = 0; i < lista.Length; i++)
                    {
                        switch (vineta)
                        {
                            case TipoVineta.NINGUNO:
                                break;
                            case TipoVineta.PUNTO_NEGRO:
                                listaVinetas.Append(@"\f1\'b7\tab\f3 " + lista[i].Trim() + @"\par").AppendLine();
                                break;
                            case TipoVineta.PUNTO_BLANCO:
                                listaVinetas.Append(@"\f2 o\tab\f3 " + lista[i].Trim() + @"\par").AppendLine();
                                break;
                            case TipoVineta.CUADRADO:
                                listaVinetas.Append(@"\f0\'a7\tab\f3 " + lista[i].Trim() + @"\par").AppendLine();
                                break;
                            case TipoVineta.FLECHA:
                                listaVinetas.Append(@"\f0\'d8\tab\f3 " + lista[i].Trim() + @"\par").AppendLine();
                                break;
                        }
                    }
                    listaVinetas.Append(@"\pard\ltrpar\par").AppendLine();
                }
                listaVinetas.Append("}");
                return listaVinetas.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        private string Romano(int numero)
        {
            string romano = string.Empty;
            string[] unidad = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] decenas = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] centena = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            int un = numero % 10;
            int dec = Convert.ToInt32(numero / 10);
            int cen = Convert.ToInt32(numero / 100);
            romano = centena[cen] + decenas[dec] + unidad[un];
            return romano;
        }

        private string Abecedario(int numero)
        {            
            string[] abc = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
            return abc[numero];
        }

        public string ListaEnumerada(TipoEnumerador enumerador, string[] lista, string fuente)
        {
            StringBuilder listaEnumerada = new StringBuilder();
            listaEnumerada.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang9226").AppendLine();
            listaEnumerada.Append(@"{\fonttbl").AppendLine();
            listaEnumerada.Append(@"{\f0\froman\fprq2\fcharset0 " + fuente + @";}}");
            listaEnumerada.Append(@"\viewkind4\uc1\pard").AppendLine();
            if (enumerador == TipoEnumerador.NINGUNO)
            {
                listaEnumerada.Append(@"\fi0\li0\slmult1").AppendLine();
                for (int i = 0; i < lista.Length; i++)
                {
                    listaEnumerada.Append(lista[i].Trim() + @"\par").AppendLine();
                }
            }
            else
            {
                listaEnumerada.Append(@"\ltrpar\slmult1").AppendLine();
                for (int i = 0; i < lista.Length; i++)
                {
                    switch (enumerador)
                    {
                        case TipoEnumerador.NUMERO_PUNTO:
                            listaEnumerada.Append((i+1) + @". \tab\f0 " + lista[i].Trim() + @"\par").AppendLine();
                            break;
                        case TipoEnumerador.NUMERO_PARENTESIS:
                            listaEnumerada.Append((i+1) + @") \tab\f0 " + lista[i].Trim() + @"\par").AppendLine();
                            break;
                        case TipoEnumerador.ROMANO_MAYUSCULA:
                            listaEnumerada.Append(Romano(i+1) + @". \tab\f0 " + lista[i].Trim() + @"\par").AppendLine();
                            break;
                        case TipoEnumerador.ROMANO_MINUSCULA:
                            listaEnumerada.Append(Romano(i + 1).ToLower() + "." + @" \tab\f0 " + lista[i].Trim() + @"\par").AppendLine();
                            break;
                        case TipoEnumerador.LETRAS_MAYUSCULA:
                            listaEnumerada.Append(Abecedario(i).ToUpper() + "." + @" \tab\f0 " + lista[i].Trim() + @"\par").AppendLine();
                            break;
                        case TipoEnumerador.LETRAS_MINUSCULA:
                            listaEnumerada.Append(Abecedario(i) + ")" + @" \tab\f0 " + lista[i].Trim() + @"\par").AppendLine();
                            break;
                    }
                }
                listaEnumerada.Append(@"\pard\ltrpar\par").AppendLine();
            }
            listaEnumerada.Append("}");
            return listaEnumerada.ToString();
        }
    }
}
