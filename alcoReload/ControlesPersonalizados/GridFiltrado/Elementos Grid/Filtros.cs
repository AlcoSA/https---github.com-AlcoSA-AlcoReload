using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public class Filtros : IList<Filtro>
    {
        #region vars
        List<Filtro> lista;
        #endregion
        #region ctor
        public Filtros() { lista = new List<Filtro>(); }
        #endregion
        public Filtro this[int index]
        {
            get
            {
                return lista[index];
            }

            set
            {
                lista[index] = value;
            }
        }
        public Filtro this[string nombre_columna]
        {
            get
            {
                return lista.FirstOrDefault(x=> x.Nombre_Columna == nombre_columna);
            }
        }

        public Filtro this[string nombre_columna, TipoFiltro tipofiltro]
        {
            get
            {
                return lista.FirstOrDefault(x => x.Nombre_Columna == nombre_columna && x.TipoFiltro==tipofiltro);
            }
        }

        public int Count
        {
            get
            {
                return lista.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Filtro item)
        {
            lista.Add(item);
        }

        public void Clear()
        {
            lista.Clear();
        }

        public string ObtenerFiltroSelect()
        {
            try
            {
                string filtro = string.Empty;
                List<string> lf = new List<string>();
                lista.ForEach(
                    delegate (Filtro f)
                    {
                        switch (f.TipoValor)
                        {
                            case TipoValor.MULTIPLES_VALORES_TEXTO:
                                object[] vals = (object[])f.Valor;
                                vals = vals.Select(x => "'" + Convert.ToString(x) + "'").ToArray();
                                lf.Add(f.Nombre_Columna + " IN (" + string.Join(", ", vals) + ")");
                                break;
                            case TipoValor.MULTIPLES_VALORES_NUMERICOS:
                                object[] vns = (object[])f.Valor;
                                lf.Add(f.Nombre_Columna + " IN (" + string.Join(", ", vns) + ")");
                                break;
                            case TipoValor.MULTIPLES_VALORES_FECHA:
                                object[] vfs = (object[])f.Valor;
                                string[] vfss = vfs.Select(x => "#" + Convert.ToDateTime(x).ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern + " " +
                                    CultureInfo.InvariantCulture.DateTimeFormat.LongTimePattern) + "#").ToArray();
                                lf.Add("Convert(" + f.Nombre_Columna + ", 'System.String')" + " IN (" + string.Join(", ", vfss) + ")");
                                break;
                            case TipoValor.FECHA:
                                DateTime[] fs = (DateTime[])f.Valor;
                                lf.Add("(" + f.Nombre_Columna + " > #" + fs[0].ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern) + "# and "
                                    + f.Nombre_Columna + " < #" + fs[1].ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern) + "#)");
                                break;
                            case TipoValor.NUMERICO:
                                switch (f.TipoCoincidencia)
                                {
                                    case TipoCoincidencia.IGUALQUE:
                                        {
                                            lf.Add(f.Nombre_Columna + " = " + Convert.ToString(f.Valor));
                                            break; }
                                    case TipoCoincidencia.MAYORQUE:
                                        {
                                            lf.Add(f.Nombre_Columna + " > " + Convert.ToString(f.Valor));
                                            break; }
                                    case TipoCoincidencia.MENORQUE:
                                        {
                                            lf.Add(f.Nombre_Columna + " < " + Convert.ToString(f.Valor));
                                            break; }
                                    case TipoCoincidencia.MAYOROIGUALQUE:
                                        {
                                            lf.Add(f.Nombre_Columna + " >= " + Convert.ToString(f.Valor));
                                            break; }
                                    case TipoCoincidencia.MENORIGUALQUE:
                                        {
                                            lf.Add(f.Nombre_Columna + " <= " + Convert.ToString(f.Valor));
                                            break; }
                                }
                                
                                break;
                            default:
                                switch (f.TipoCoincidencia)
                                {
                                    case TipoCoincidencia.COMO:
                                        {
                                            lf.Add(f.Nombre_Columna + " like '%" + Convert.ToString(f.Valor).Replace("%", "[%]") + "%'");
                                            break;
                                        }
                                    case TipoCoincidencia.IGUALQUE:
                                        {
                                            lf.Add(f.Nombre_Columna + " = '" + Convert.ToString(f.Valor).Replace("%", "[%]") + "'");
                                            break;
                                        }
                                }                                
                                break;
                        }
                    }
                );
                filtro = string.Join(" and ", lf.ToArray());
                return filtro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        public bool Contains(Filtro item)
        {
            return lista.Contains(item);
        }
        public bool Contains(string nombre_columna)
        {
            return lista.FirstOrDefault(x=> x.Nombre_Columna == nombre_columna) != null;
        }

        public void CopyTo(Filtro[] array, int arrayIndex)
        {
            lista.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Filtro> GetEnumerator()
        {
            return lista.GetEnumerator();
        }

        public int IndexOf(Filtro item)
        {
            return lista.IndexOf(item);
        }

        public void Insert(int index, Filtro item)
        {
            lista.Insert(index, item);
        }

        public bool Remove(Filtro item)
        {
            return lista.Remove(item);
        }

        public void RemoveAt(int index)
        {
            lista.RemoveAt(index);
        }
        public void RemoveAt(string nombre_columna)
        {
            Filtro f = lista.FirstOrDefault(x => x.Nombre_Columna == nombre_columna);
            if (f != null)
            { Remove(f); }            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lista.GetEnumerator();
        }
    }
}
