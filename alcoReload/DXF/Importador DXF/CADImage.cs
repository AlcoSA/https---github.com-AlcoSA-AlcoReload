using System;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace DXF.Importador_DXF
{
    public delegate void CADEntityProc(DXFEntity Ent);
    public class CADImage
    {
        #region Variables
        private Point mbase;
        private DXFSection fblocks;
        private static Graphics fgraphics;
        private int fcode;
        private DXFSection fentities;
        private CADIterate fparams;
        protected StreamReader fstream;
        private DXFSection fmain;
        private string fvalue;
        private NumberFormatInfo n;
        private float fscale = 1;
        private DXFTable layers;
        #endregion
        #region Constructor
        public CADImage()
        {
            FParams = new CADIterate();
            N = new NumberFormatInfo();
            N.NumberDecimalSeparator = ".";
            FParams.Scale.X = 1;
            FParams.Scale.Y = 1;
            FParams.Scale.Z = 1;
        }
        #endregion
        #region Propiedades
        public Point Base
        {
            get { return mbase; }
            set { mbase = value; }
        }
        public DXFSection FBlocks
        {
            get { return fblocks; }
            set { fblocks = value; }
        }
        public Graphics fFGraphics
        {
            get { return fgraphics; }
            set { fgraphics = value; }
        }
        public int FCode
        {
            get { return fcode; }
            set { fcode = value; }
        }
        public DXFSection FEntities
        {
            get { return fentities; }
            set { fentities = value; }
        }
        public CADIterate FParams
        {
            get { return fparams; }
            set { fparams = value; }
        }
        protected StreamReader FStream;
        public DXFSection FMain
        {
            get { return fmain; }
            set { fmain = value; }
        }
        public string FValue
        {
            get { return fvalue; }
            set { fvalue = value; }
        }
        public NumberFormatInfo N
        {
            get { return n; }
            set { n = value; }
        }
        public float FScale
        {
            get { return fscale; }
            set { fscale = value; }
        }
        public DXFTable Layers
        {
            get { return layers; }
            set { layers = value; }
        }

        #endregion
        #region Procedimientos
        public DXFLayer LayerByName(string AName)
        {
            DXFLayer Result = null;
            if (layers == null) layers = new DXFTable();
            for (int i = 0; i < layers.Entities.Count; i++)
            {
                if (AName.ToLower() == ((DXFLayer)layers.Entities[i]).name.ToLower())
                    Result = ((DXFLayer)layers.Entities[i]);
            }
            if (Result == null)
            {
                Result = new DXFLayer();
                Result.name = AName;
                layers.AddEntity(Result);
            }
            return Result;
        }
        public void Draw(Graphics e)
        {
            if (FMain == null)
                return;
            fgraphics = e;
            //e.FillRectangle(new SolidBrush(Color.Black), e.VisibleClipBounds);
            fentities.Iterate(new CADEntityProc(DrawEntity), FParams);
        }
        protected static void DrawEntity(DXFEntity Ent)
        {
            Ent.Draw(fgraphics);
        }
        public DXFBlock FindBlock(string Name)
        {
            DXFBlock vB = null;
            foreach (DXFBlock vBlock in fblocks.Entities)
            {
                if (vBlock.Name == Name)
                {
                    vB = vBlock;
                }
            }
            return vB;

        }
        public void Iterate(CADEntityProc Proc, CADIterate Params)
        {
            FParams = Params;
            fentities.Iterate(Proc, Params);
        }
        public void LoadFromFile(string FileName)
        {
            FMain = new DXFSection();
            FMain.Converter = this;
            if (FStream == null)
            {
                FStream = new StreamReader(FileName);
            }
            FMain.Complex = true;
            FMain.ReadState();

        }
        public void LoadFromDXFString(string dxf)
        {
            FMain = new DXFSection();
            FMain.Converter = this;
            if (FStream == null)
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(dxf);                
                MemoryStream stream = new MemoryStream(byteArray);
                FStream = new StreamReader(stream);
            }
            FMain.Complex = true;
            FMain.ReadState();

        }
        public void StreamDispose()
        {
            FStream.Dispose();
        }
        public DXFVertex GetPoint(float x, float y, float z)
        {
            DXFVertex P = new DXFVertex();
            if (FParams.Matrix != null)
            {
                P.X = Base.X + FScale * (x * FParams.Scale.X + FParams.Matrix.data[3, 0]);
                P.Y = Base.Y - FScale * (y * FParams.Scale.Y + FParams.Matrix.data[3, 1]);
            }
            else
            {
                P.X = Base.X + FScale * (x * FParams.Scale.X);
                P.Y = Base.Y - FScale * (y * FParams.Scale.Y);
            }
            P.Z = z * FScale;
            return P;
        }
        public DXFVertex GetPoint(DXFVertex Point)
        {
            DXFVertex P = new DXFVertex();
            if (FParams.Matrix != null)
            {
                P.X = Base.X + FScale * (Point.X * FParams.Scale.X + FParams.Matrix.data[3, 0]);
                P.Y = Base.Y - FScale * (Point.Y * FParams.Scale.Y + FParams.Matrix.data[3, 1]);
            }
            else
            {
                P.X = Base.X + FScale * (Point.X * FParams.Scale.X);
                P.Y = Base.Y - FScale * (Point.Y * FParams.Scale.Y);
            }
            P.Z = Point.Z * FScale;
            return P;
        }
        public DXFEntity CreateEntity()
        {
            DXFEntity E;
            switch (FValue)
            {
                case "ENDSEC":
                    return null;
                case "ENDBLK":
                    return null;
                case "ENDTAB":
                    return null;
                case "LINE":
                    E = new DXFLine();
                    break;
                case "SECTION":
                    E = new DXFSection();
                    break;
                case "BLOCK":
                    E = new DXFBlock();
                    break;
                case "INSERT":
                    E = new DXFInsert();
                    break;
                case "TABLE":
                    E = new DXFTable();
                    break;
                case "CIRCLE":
                    E = new DXFCircle();
                    break;
                case "LAYER":
                    E = new DXFLayer();
                    break;
                case "TEXT":
                    E = new DXFText();
                    break;
                case "MTEXT":
                    E = new DXFMText();
                    break;
                case "ARC":
                    E = new DXFArc();
                    break;
                case "ELLIPSE":
                    E = new DXFEllipse();
                    break;
                case "LWPOLYLINE":
                    E = new DXFLwPolyline();
                    break;
                case "SPLINE":
                    E = new DXFSPLine();
                    break;
                default:
                    E = new DXFEntity();
                    break;
            }
            E.Converter = this;
            return E;
        }
        public void Next()
        {
            FCode = Convert.ToInt32(FStream.ReadLine());
            FValue = FStream.ReadLine();
        }
        public static Color IntToColor(int Value)
        {
            Color[] First = new Color[] {DXFConst.clByBlock, Color.Red, Color.Yellow,
                                            Color.Lime, Color.Aqua, Color.Blue, Color.Fuchsia,
                                            DXFConst.clNone, Color.Gray, Color.Silver};
            Color[] Last = new Color[] {DXFConst.clByBlock, Color.FromName("" + 0x282828),
                                           Color.FromName("" + 0x505050), Color.FromName("" + 0x787878),
                                           Color.FromName("" + 0xA0A0A0), Color.White};
            int V, H, L, S, Result;
            Result = Value;
            if (Result < 0) return First[7];
            V = Result & 255;
            if (V < 10) return First[V];
            else
            {
                if (V >= 250) return Last[V - 250];
                else
                {
                    H = (int)(V / 10) - 1;
                    L = V % 10;
                    S = L & 1;
                    L = 5 - (L >> 1);
                    Result = (RGB(H, S, L) << 16) + (RGB(H + 8, S, L) << 8) + RGB(H + 16, S, L);
                    if (Result != 0) Result = Result | 0x2000000;
                }
            }
            byte R, G, B;
            R = (byte)(Result >> 32);
            G = (byte)(Result >> 8);
            B = (byte)(Result >> 16);
            return Color.FromArgb(R, G, B);
        }
        private static byte RGB(int Index, int S, int L)
        {
            byte[] Pal = new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 51, 102, 204, 255, 255, 255,
                                        255, 255, 255, 255, 255, 255, 204, 102, 51};
            int Result;
            if (Index > 23) Index -= 24;
            Result = Pal[Index];
            if ((S != 0) && (Result < 204)) Result += 102;
            Result *= L;
            Result /= 5;
            return (byte)Result;
        }
        public void Loads(DXFEntity E)
        {
            E.Loaded();
        }
        #endregion
    }
}
