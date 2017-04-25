using System.Windows.Forms.Design.Behavior;
using System.Drawing;

namespace System.Windows.Forms
{
    public class RibbonPanelGlyph
        : Glyph
    {
        BehaviorService _behaviorService;
        RibbonTab _tab;
        RibbonTabDesigner _componentDesigner;
        Size size;

        public RibbonPanelGlyph(BehaviorService behaviorService, RibbonTabDesigner designer, RibbonTab tab)
            : base(new RibbonPanelGlyphBehavior(designer, tab))
        {
            _behaviorService = behaviorService;
            _componentDesigner = designer;
            _tab = tab;
            size = new Size(80, 16);
        }

        public override Rectangle Bounds
        {
            get
            {
                if (!_tab.Active || !_tab.Owner.Tabs.Contains(_tab))
                {
                    return Rectangle.Empty;
                }
                Point edge = _behaviorService.ControlToAdornerWindow(_tab.Owner);
                Point pnl = new Point(5, _tab.TabBounds.Bottom + 5);
                if (_tab.Panels.Count > 0)
                {
                   RibbonPanel p = _tab.Panels[_tab.Panels.Count - 1];
                   if (_tab.Owner.RightToLeft == RightToLeft.No)
                     pnl.X = p.Bounds.Right + 5;
                   else
                      pnl.X = p.Bounds.Left - 5 - size.Width;
                }
               return new Rectangle(
                    edge.X + pnl.X,
                    edge.Y + pnl.Y,
                    size.Width, size.Height);
            }
        }

        public override Cursor GetHitTest(System.Drawing.Point p)
        {
            if (Bounds.Contains(p))
            {
                return Cursors.Hand;
            }

            return null;
        }


        public override void Paint(PaintEventArgs pe)
        {
            using (SolidBrush b = new SolidBrush(Color.FromArgb(50, Color.Blue)))
            {
                pe.Graphics.FillRectangle(b, Bounds);
            }
            StringFormat sf = new StringFormat(); sf.Alignment = StringAlignment.Center; sf.LineAlignment = StringAlignment.Center;
            pe.Graphics.DrawString("Agregar Panel", SystemFonts.DefaultFont, Brushes.White, Bounds, sf);
        }
    }

    public class RibbonPanelGlyphBehavior
        : Behavior
    {
        RibbonTab _tab;
        RibbonTabDesigner _designer;

        public RibbonPanelGlyphBehavior(RibbonTabDesigner designer, RibbonTab tab)
        {
            _designer = designer;
            _tab = tab;
        }



        public override bool OnMouseUp(Glyph g, MouseButtons button)
        {
            _designer.AddPanel(this, EventArgs.Empty);
            return base.OnMouseUp(g, button);
        }
    }
}
