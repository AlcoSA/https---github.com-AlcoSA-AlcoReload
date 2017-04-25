using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public class Filtro
    {
        #region delg
        public delegate void Valor_Changed(object sender, FiltroValorChangedEventargs e);
        public event Valor_Changed ValorChanged;
        protected virtual void OnValor_Changed(FiltroValorChangedEventargs e)
        {
            ValorChanged?.Invoke(this, e);
        }
        #endregion
        #region var
        string nombre_columna = string.Empty;
        object valor = string.Empty;
        TipoCoincidencia tipocoincidencia = TipoCoincidencia.IGUALQUE;
        TipoValor tipovalor = TipoValor.TEXTO;
        TipoFiltro tipofiltro = TipoFiltro.FILTRO_DRAGDROP;
        #endregion

        #region props
        public string Nombre_Columna
        {
            get { return nombre_columna; }
            set { nombre_columna = value; }
        }
        public object Valor
        {
            get { return valor; }
            set { valor = value;
                OnValor_Changed(new FiltroValorChangedEventargs(this)); 
            }
        }
        public TipoCoincidencia TipoCoincidencia
        {
            get { return tipocoincidencia; }
            set { tipocoincidencia = value; }
        }
        public TipoValor TipoValor
        {
            get { return tipovalor; }
            set { tipovalor = value; }
        }
        public TipoFiltro TipoFiltro
        {
            get { return tipofiltro; }
            set { tipofiltro = value; }
        }
        #endregion

        #region ctor
        public Filtro(string nombre_columna, object valor, TipoValor tipovalor, TipoCoincidencia tipocoincidencia,
            TipoFiltro tipofiltro)
        {
            this.nombre_columna = nombre_columna;
            this.valor = valor;
            this.tipovalor = tipovalor;
            this.tipocoincidencia = tipocoincidencia;
            this.tipofiltro = tipofiltro;
        }
        public Filtro(string nombre_columna, object valor, TipoValor tipovalor, TipoCoincidencia tipocoincidencia)
        {
            this.nombre_columna = nombre_columna;
            this.valor = valor;
            this.tipovalor = tipovalor;
            this.tipocoincidencia = tipocoincidencia;
        }
        public Filtro(string nombre_columna, object valor, TipoValor tipovalor ,TipoFiltro tipofiltro)
        {
            this.nombre_columna = nombre_columna;
            this.valor = valor;
            this.tipovalor = tipovalor;
            this.tipofiltro = tipofiltro;
        }
        public Filtro(string nombre_columna, object valor, TipoValor tipovalor)
        {
            this.nombre_columna = nombre_columna;
            this.valor = valor;
            this.tipovalor = tipovalor;
        }
        #endregion

        #region procs
        public void Cambiar_Valor_Sin_Trigger(object nuevo_valor)
        {
            valor = nuevo_valor;
        }
        #endregion


    }
}
