using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Reflection;


namespace DatagridTreeView
{
    internal class DataGridTreeViewActionList : DesignerActionList
    {
        #region Variables

        private DataTreeGridView owner;
        private DesignerActionUIService designerActionSvc;

        #endregion

        #region Eventos, Procedimientos y Funciones
        private void ChangePropertyValue(string propertyName, object value)
        {
            PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this.owner)[propertyName];
            if (propertyDescriptor != null)
            {
                propertyDescriptor.SetValue(this.owner, value);
                this.designerActionSvc.Refresh(this.owner);
            }
        }

        internal DataGridTreeViewActionList(IComponent component)
            : base(component)
        {
            this.owner = component as DataTreeGridView;
            this.designerActionSvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection collection = new DesignerActionItemCollection();
            collection.Add(new DesignerActionMethodItem(this, "OnEditColumns", "Editar Columnas...", "methods", true));
            collection.Add(new DesignerActionMethodItem(this, "OnAddColumn", "Agregar Columnas...", "methods", true));
            return collection;
        }

        //Este procedimiento se activa cuando es agregada una nueva columna
        public void OnAddColumn()
        {
            IDesignerHost designerHost = base.Component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
            DesignerTransaction designerTransaction = designerHost.CreateTransaction("Add column");
            DialogResult dialogResult = DialogResult.Cancel;
            Type type = Type.GetType("System.Windows.Forms.Design.DataGridViewAddColumnDialog, System.Design");
            if (type != null)
            {
                Form form = Activator.CreateInstance(type, new object[] { ((DataTreeGridView)base.Component).Columns, (DataGridView)base.Component }) as Form;
                MethodInfo method = form.GetType().GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic);
                if (method != null)
                    method.Invoke(form, new object[] { ((DataTreeGridView)base.Component).Columns.Count, true });
                try
                {
                    IUIService iUIService = base.Component.Site.GetService(typeof(IUIService)) as IUIService;
                    if (iUIService != null)
                        dialogResult = iUIService.ShowDialog(form);
                    else
                        dialogResult = form.ShowDialog(base.Component as IWin32Window);
                }
                finally
                {
                    if (dialogResult == DialogResult.OK)
                        designerTransaction.Commit();
                    else
                        designerTransaction.Cancel();
                }
            }
        }

        //Este procedimiento se activa cuando una columna es editada
        public void OnEditColumns()
        {
            IDesignerHost designerHost = base.Component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
            Type type = Type.GetType("System.Windows.Forms.Design.DataGridViewColumnCollectionDialog, System.Design");
            if (type != null)
            {  //Form form = Activator.CreateInstance(type, true) as Form;
                ConstructorInfo constructorInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
                Form form = (Form)constructorInfo.Invoke(BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { this.owner.Site }, Application.CurrentCulture);
                MethodInfo method = form.GetType().GetMethod("SetLiveDataGridView", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (method != null)
                    method.Invoke(form, new object[] { (DataGridView)this.Component });
                DesignerTransaction designerTransaction = designerHost.CreateTransaction("EditingColumns");
                DialogResult dialogResult = DialogResult.Cancel;
                try
                {
                    IUIService iUIService = base.Component.Site.GetService(typeof(IUIService)) as IUIService;
                    if (iUIService != null)
                        dialogResult = iUIService.ShowDialog(form);
                    else
                        dialogResult = form.ShowDialog(base.Component as IWin32Window);
                }
                finally
                {
                    if (dialogResult == DialogResult.OK)
                        designerTransaction.Commit();
                    else
                        designerTransaction.Cancel();
                }
            }

        }
        #endregion
    }

}