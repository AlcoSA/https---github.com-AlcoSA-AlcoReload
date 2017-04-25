
using System.ComponentModel;

namespace System.Windows.Forms
{
    public class RibbonMenuItem : RibbonButton
    {
        #region Variables

        #endregion

        #region Constructor

        public RibbonMenuItem()
        {
            DropDownArrowDirection = RibbonArrowDirection.Left;
            SetDropDownMargin(new Padding(10));
        }

        public RibbonMenuItem(string text): this()
        {
            Text = text;
        }



        #endregion

        #region Propiedades

        public override System.Drawing.Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                base.Image = value;

                SmallImage = value;
            }
        }

        [Browsable(false)]
        public override System.Drawing.Image SmallImage
        {
            get
            {
                return base.SmallImage;
            }
            set
            {
                base.SmallImage = value;
            }
        }

        #endregion

        #region Sobre-Escritos

        public override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Site != null && this.Site.DesignMode == true)
            {
                base.OnMouseDown(e);                
            }
        }

        public override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!Enabled) return;            
            if (!(this.Site != null && this.Site.DesignMode == true))
            {                
                if (DropDownItems.Count > 0)
                {
                    if (!DropDownVisible)
                    {
                        ShowDropDown();
                    }
                }
            }                  
        }

        public override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!Enabled) return;
            if (!(this.Site != null && this.Site.DesignMode == true))
            {                
                if (DropDownVisible)
                {
                    CloseDropDown();
                }
            }
        }

        public override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        #endregion
    }
}

