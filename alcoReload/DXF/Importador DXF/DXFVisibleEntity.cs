using System;

namespace DXF.Importador_DXF
{
    public class DXFVisibleEntity : DXFEntity
    {
        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 8:
                    Layer = Converter.LayerByName(Converter.FValue);
                    break;
            }
        }
    }
}
