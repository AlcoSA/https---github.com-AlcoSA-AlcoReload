using System;
namespace DXF.Importador_DXF
{
    public class DXFPolyLine : DXFGroup
    {
        #region Variables
        private float startW;
        private float endW;
        private float globalW;
        private float lineTypeScale;
        private Polyline_flag flags = Polyline_flag.default_;
        private int meshM;
        private int meshN;
        #endregion
        #region Procedimientos
        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 40:
                    startW = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 41:
                    endW = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 43:
                    globalW = Convert.ToSingle(Converter.FValue, Converter.N);
                    if (globalW < DXFConst.accuracy) globalW = 0;
                    break;
                case 48:
                    lineTypeScale = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 70:
                    flags = (Polyline_flag)Convert.ToInt32(Converter.FValue);
                    break;
                case 71:
                    if (meshM == 0) meshM = Convert.ToInt32(Converter.FValue);
                    break;
                case 73:
                    meshM = Convert.ToInt32(Converter.FValue);
                    break;
                case 72:
                    if (meshN == 0) meshN = Convert.ToInt32(Converter.FValue);
                    break;
                case 74:
                    meshN = Convert.ToInt32(Converter.FValue);
                    break;
                default:
                    base.ReadProperty();
                    break;
            }
        }
        #endregion

    }
}
