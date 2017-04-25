using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Importador_DXF
{
    public class DXFSection : DXFTable
    {
        public override void ReadProperty()
        {
            if ((Name == null) && (Converter.FCode == 2))
            {
                Name = Converter.FValue;
            }
            switch (Name)
            {
                case "BLOCKS":
                    Converter.FBlocks = this;
                    break;
                case "ENTITIES":
                    Converter.FEntities = this;
                    break;
            }
        }
    }
}
