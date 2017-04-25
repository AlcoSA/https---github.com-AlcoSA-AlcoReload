using System;
using System.Drawing;

namespace DXF.Importador_DXF
{
    public class DXFText : DXFCustomVertex
    {        
        public FRect box;        
        public string text = string.Empty;
        public float height;
        public DXFMText mText;
        public float obliqueAngle;
        public DXFVertex point1;
        public float rotation;
        public float scale;
        public DXFVertex startPoint;
        public Text_Generation_Flag text_gen_flag = Text_Generation_Flag.default_;

        public Alingment horizontalalign = Alingment.left;
        public Alingment verticalalign = Alingment.left;
        

        public bool winFont;


        private void SetTextStr(string Value)
        {
            int vPos, I;
            text = Value;
            if (DXFConst.macroStrings != null)
            {
                for (I = 0; I < DXFConst.macroStrings.Count; I++)
                {
                    vPos = ((string)DXFConst.macroStrings[I]).IndexOf("=");
                    if (vPos == 0) continue;
                    text.Replace((string)DXFConst.macroStrings[I],
                        ((string)DXFConst.macroStrings[I]).Substring(vPos + 1, ((string)DXFConst.macroStrings[I]).Length));
                }
            }
            text = text.Replace("%%d", "°");
            text = text.Replace("%%p", "±");
            text = text.Replace("%%u", @"\L");
            text = text.Replace("%%127", "?");
            text = text.Replace("%%128", "ˆ");
            text = text.Replace("%%176", "°");
            text = text.Replace("%%179", "?");
            text = text.Replace("%%c", @"\U+2205");
            DXFConst.ReplaceNToDiameter(text);
        }



        public override void ReadProperty()
        {            
            switch (Converter.FCode)
            {
                case 1:
                    SetTextStr(Converter.FValue);
                    break;
                case 7:
                    break;
                case 10:
                    startPoint.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 20:
                    startPoint.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 30:
                    startPoint.Z = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 11:
                    point1.X = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 21:
                    point1.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 31:
                    point1.Z = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 40:
                    height = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 41:
                    scale = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 50:
                    rotation = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 51:
                   obliqueAngle = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 71:
                    text_gen_flag = (Text_Generation_Flag)Convert.ToInt32(Converter.FValue);
                    break;
                case 72:
                    horizontalalign = (Alingment)Convert.ToInt32(Converter.FValue);
                    break;
                case 73:
                    verticalalign = (Alingment)Convert.ToInt32(Converter.FValue);
                    break;
                default:
                    base.ReadProperty();
                    break;
            }
        }

        public override void Invoke(CADEntityProc Proc, CADIterate Params)
        {
            if (mText == null) Proc(this);
            else
                mText.Invoke(Proc, Converter.FParams);
        }

        public override void Loaded()
        {
            if (Layer == null) Layer = Converter.LayerByName("0");
        }

        public override void Draw(Graphics G)
        {
            DXFVertex P1;
            Color RealColor = DXFConst.EntColor(this, Converter.FParams.Insert);
            if (RealColor == DXFConst.clNone) RealColor = Color.Black;
            P1 = this.Converter.GetPoint(startPoint);
            float h1 = height * Converter.FScale;
            P1.Y = P1.Y - h1;
            SolidBrush br1 = new SolidBrush(RealColor);
            Font f1 = new Font("Times New Roman", h1);
            if (FVisible)
            {
                if (rotation == 90)
                    G.DrawString(text, f1,
                                 br1, P1.X - h1, P1.Y - (text.Length * h1 / 1.6f),
                                 new StringFormat(StringFormatFlags.DirectionVertical));
                else
                    G.DrawString(text, f1, br1, P1.X, P1.Y);
            }
        }
    }
}
