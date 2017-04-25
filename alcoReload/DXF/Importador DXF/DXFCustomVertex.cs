using System;
namespace DXF.Importador_DXF
{
    public class DXFCustomVertex : DXFVisibleEntity
    {
        #region Variables
        private DXFVertex point;
        #endregion
        #region Constructor
        public DXFCustomVertex() { point = new DXFVertex(); }
        #endregion
        #region Propiedades
        public DXFVertex Point
        {
            get { return point; }
            set { point = value; }
        }
        #endregion
        #region Procedmientos
        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 10:
                    point.X = Convert.ToSingle(Converter.FValue, Converter.N); ;
                    break;
                case 20:
                    point.Y = Convert.ToSingle(Converter.FValue, Converter.N); ;
                    break;
                case 30:
                    point.Z = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                default:
                    base.ReadProperty();
                    break;
            }
        }
        #endregion
    }
}
