using System;
using System.Drawing;

namespace DXF.Importador_DXF
{
    public class DXFLayer : DXFEntity
    {
        public Color color = DXFConst.clByLayer;
        public byte flags;
        public bool visible;
        public string name = "";

        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 70:
                    flags = (byte)Convert.ToInt32(Converter.FValue);
                    break;
                case 2:
                    name = "" + Converter.FValue;
                    break;
                case 62:
                    color = CADImage.IntToColor(Convert.ToInt32(Converter.FValue, Converter.N));
                    break;
            }
        }
        public override void Loaded()
        {
            if ((flags & 1) == 0) visible = true;
            else visible = false;
        }
    }
}
