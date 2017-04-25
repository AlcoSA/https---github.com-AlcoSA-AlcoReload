using System;
namespace DXF.Importador_DXF
{
    public class DXFMText : DXFInsert
    {
        public string addText;
        public AttachPoint attachmentpoint = AttachPoint.BottomLeft;
        public float height;
        public DXFVertex point1;
        public float rectHeight;
        public float rectWidth;
        public string text;

        public DXFMText()
        {
            Scale = new DXFVertex(1.0f, 1.0f, 1.0f);
            FColor = DXFConst.clByLayer;
            Matrix.IdentityMat();
        }

        private void AdjustChildren()
        {
            int I, K = 0;
            DXFText T;
            float X = 0, Y = 0;
            for (I = 0; I < FBlock.Entities.Count; I++)
            {
                T = (DXFText)FBlock.Entities[I];
                if (T.box.top != Y)
                {
                    Row(K, I, X);
                    K = I;
                }
                X = T.box.right;
                Y = T.box.top;
            }
            Row(FBlock.Entities.Count - 1, FBlock.Entities.Count, X);
        }

        private void Row(int AStart, int AEnd, float X)
        {
            int I;
            DXFText T;
            X = rectWidth - X;
            if (X < 0) return;
            if ((attachmentpoint == AttachPoint.TopCenter) || (attachmentpoint == AttachPoint.MiddleCenter) || (attachmentpoint == AttachPoint.BottomCenter)) X = X / 2;
            if (AStart < 0)
                AStart = 0;
            for (I = AStart; I < AEnd; I++)
            {
                T = (DXFText)FBlock.Entities[I];
                T.startPoint.X = T.startPoint.X + X;
                DXFConst.OffsetFRect(T.box, X, 0, 0);
            }
        }

        public override void ReadProperty()
        {
            switch (Converter.FCode)
            {
                case 2:
                case 42:
                case 43:
                case 72:
                case 73:
                    return;
                case 1:
                    text = addText + Converter.FValue;
                    break;
                case 3:
                    addText = addText + Converter.FValue;
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
                    rectWidth = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 44:
                    rectHeight = Convert.ToSingle(Converter.FValue, Converter.N);
                    break;
                case 71:
                    attachmentpoint = (AttachPoint)Convert.ToInt32(Converter.FValue);
                    break;
                default:
                    base.ReadProperty();
                    break;
            }
        }

        private void ReplaceNToDiameter(string S)
        {
            if (S.CompareTo('n') == 0) S = S.Replace("n", @"\U+2205");
        }


        public override void Loaded()
        {          
            base.Loaded();
        }
    }
}
