using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.Intellisens
{
    public class SeleccionCambiada_EventArgs
    {
        #region Variables
        string id, valorprimario, valorsecundario;
        DataRow fila;
        #endregion

        #region Constructor
        public SeleccionCambiada_EventArgs(string id ,string valorprimario, string valorsecundario, DataRow fila)
        {
            this.id = id;
            this.valorprimario = valorprimario;
            this.valorsecundario = valorsecundario;
            this.fila = fila;
        }
        #endregion

        #region Propiedades

        public string Id
        {
            get { return id; }
        }

        public string ValorPrimario
        {
            get { return valorprimario; }
        }
        public string ValorSecundario
        {
            get { return valorsecundario; }
        }
        public DataRow FilaSeleccionada
        {
            get { return fila; }
        }
        #endregion

    }
}
