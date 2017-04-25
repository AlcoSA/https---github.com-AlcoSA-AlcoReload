using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.Filtro_DragDrop
{
   public class CambioCoincidenciaEventArgs
    {
        #region vars
        GridFiltrado.Elementos_Grid.TipoCoincidencia tipocoincidencia;
        #endregion
        #region props
        public GridFiltrado.Elementos_Grid.TipoCoincidencia TipoCoincidencia
        {
            get {
                return tipocoincidencia;
            }            
        }
        #endregion
        #region ctor
        public CambioCoincidenciaEventArgs(GridFiltrado.Elementos_Grid.TipoCoincidencia tipocoincidencia)
        {
            this.tipocoincidencia = tipocoincidencia;
        }            
        #endregion

    }
}
