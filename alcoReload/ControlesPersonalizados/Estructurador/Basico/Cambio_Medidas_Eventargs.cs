using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.Estructurador
{
    public class Cambio_Medidas_Eventargs
    {
        decimal ancho, alto;
        int id_item, index;

        public Cambio_Medidas_Eventargs(int id_item, int index, decimal ancho, decimal alto)
        {
            this.id_item = id_item;
            this.index = index;
            this.ancho = ancho;
            this.alto = alto;
        }

        public decimal Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }
        public decimal Alto
        {
            get { return alto; }
            set { alto = value; }
        }
        public int Id_Item
        {
            get { return id_item; }
            set { id_item = value; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        
    }
}
