using System.Drawing;

namespace DXF.Importador_DXF
{
    public class DXFEntity
    {
        #region Variables
        private DXFLayer layer;
        private CADImage converter;
        private Color fcolor = DXFConst.clByLayer;
        private bool complex = false;
        private bool fvisible = true;
        #endregion
        #region Propiedades
        public DXFLayer Layer
        {
            get { return layer; }
            set { layer = value; }
        }
        public CADImage Converter
        {
            get { return converter; }
            set { converter = value; }
        }
        public Color FColor
        {
            get { return fcolor; }
            set { fcolor = value; }
        }
        public bool Complex
        {
            get { return complex; }
            set { complex = value; }
        }
        protected bool FVisible
        {
            get { return fvisible; }
            set { fvisible = value; }
        }
        #endregion
        #region Constructor

        #endregion
        #region Procedimientos
        public virtual void Draw(Graphics G) { }

        public virtual void Invoke(CADEntityProc Proc, CADIterate Params)
        {
            Proc(this);
        }

        public virtual bool AddEntity(DXFEntity E)
        {
            return false;
        }

        public virtual void ReadEntities()
        {
            DXFEntity E;
            do
            {
                if (Converter.FValue == "EOF")
                {
                    return;
                }
                E = Converter.CreateEntity();
                if (E == null)
                {
                    Converter.Next();
                    break;
                }
                E.ReadState();
                if (E.GetType().IsSubclassOf(typeof(DXFEntity)))
                {
                    AddEntity(E);
                }
                Converter.Loads(E);
            }
            while (true);
        }
        public void ReadProps()
        {
            while (true)
            {
                Converter.Next();
                switch (Converter.FCode)
                {
                    case 0:
                        return;
                    default:
                        ReadProperty();
                        break;
                }
            }
        }
        public virtual void ReadProperty() { }

        public void ReadState()
        {
            ReadProps();
            if (Complex)
            {
                ReadEntities();
            }
        }
        public virtual void Loaded() { }
        #endregion
    }
}
