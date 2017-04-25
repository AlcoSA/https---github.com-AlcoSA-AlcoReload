using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace DatagridTreeView
{
    internal class DataGridTreeViewDesigner : ControlDesigner
    {
        #region Variables
        private bool vIsMouseOverHSBar = false;
        private DesignerActionListCollection actionList;
        #endregion

        #region Propiedades
        private bool IsMouseOverHSBar
        {
            get { return vIsMouseOverHSBar; }
            set
            {
                this.vIsMouseOverHSBar = value;
            }
        }        
        private DataTreeGridView Owner
        {
            get
            {
                return (DataTreeGridView)base.Component;
            }
        }
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionList == null)
                {
                    actionList = new DesignerActionListCollection();
                    actionList.Add(new DataGridTreeViewActionList(this.Control));
                }
                return actionList;
            }
        }
        #endregion
    }
}
