using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ControlesPersonalizados.Intellisens
{
    public delegate void Selected_value_changed(object sender, SeleccionCambiada_EventArgs e);
    public delegate void User_Edit(object sender, EventArgs e);
    public partial class intellises : TextBox
    {
        #region Delegados
        public event Selected_value_changed selected_value_changed;
        protected virtual void OnSelected_value_changed(SeleccionCambiada_EventArgs e)
        {
            selected_value_changed?.Invoke(this, e);
        }
        public event User_Edit User_Edit;
        protected virtual void OnUser_Edit(EventArgs e)
        {
            User_Edit?.Invoke(this, e);
        }
        #endregion

        #region variables
        private DataTable tablafuente;
        private DataTable tablafiltro = new DataTable();
        private string[] columnsToFilter;
        private string[] columnsToShow;
        private string colToReturn;
        private string id_column_Name;
        private int dropdown_Width = 250;
        private int Items_DropDown = 5;
        private string selected_rowid;
        private string alternativeColumn;
        private string value2;
        private DataRow rowToReturn;
        internal bool grid_showed = false;
        private bool key_press_text_edited = false;
        #endregion

        #region propiedades

        /// <summary>
        /// tabla que será filtrada por el textbox
        /// </summary>
        public DataTable TablaFuente
        {
            get { return tablafuente; }
            set { tablafuente = value; }
        }
        /// <summary>
        /// nombre de la columna que será filtrada por el textbox
        /// </summary>
        [Browsable(true)]
        public string[] ColumnsToFilter
        {
            get { return columnsToFilter; }
            set { columnsToFilter = value; }
        }
        /// <summary>
        /// nombre de la columnas a mostrar
        /// </summary>
        [Browsable(true)]
        public string[] ColumnsToShow
        {
            get { return columnsToShow; }
            set { columnsToShow = value; }
        }
        [Browsable(true)]

        public int Maximo_Items_DropDown
        {
            get { return Items_DropDown; }
            set { Items_DropDown = value; }
        }
        /// <summary>
        /// Define el ancho del desplegable
        /// </summary>
        [Browsable(true)]
        public int Dropdown_Width
        {
            get { return dropdown_Width; }
            set { dropdown_Width = value; }
        }

        /// <summary>
        /// Nombre de la columna que retorna el valor seleccionado
        /// </summary>
        [Browsable(true)]
        public string ColToReturn {
            get { return colToReturn; }
            set { colToReturn = value; }
        }
        /// <summary>
        /// Nombre de la columna que contendrá el Id
        /// </summary>
        [Browsable(true)]
        public string Id_Column_Name
        {
            get { return id_column_Name; }
            set { id_column_Name = value; }
        }
        /// <summary>
        ///Nombre de la columna que contendrá el Id del registro en la base de datos. 
        /// </summary>
        public string Seleted_rowid
        {
            get { return selected_rowid; }
            set { selected_rowid = value;
            }
        }
        /// <summary>
        ///valor que almacena el valor altenativo que devuelve el datagrid al seleccionar 
        /// el registro.
        /// </summary>
        public string Value2
        {
            get { return value2;}
            set { value2 = value; }
        }        
        /// <summary>
        /// valor que almacena el valor altenativo que devuelve el datagrid al seleccionar 
        /// el registro.
        /// </summary>
        [Browsable(true)]
        public string AlternativeColumn
        {
            get { return alternativeColumn; }
            set { alternativeColumn = value; }
        }
        /// <summary>
        /// contiene la fila comleta seleccionada.
        /// </summary>
        public DataRow selected_item
        {
            get
            {
                { return rowToReturn; }
            }
            set
            {
                rowToReturn = value;
                if (value != null)
                {
                    selected_rowid = Convert.ToString(value[id_column_Name]);                    
                    if (!string.IsNullOrEmpty(alternativeColumn))
                    {
                        value2 = Convert.ToString(value[alternativeColumn]);
                        OnSelected_value_changed(new SeleccionCambiada_EventArgs(Convert.ToString(value[id_column_Name]),
                            Convert.ToString(value[colToReturn]), Convert.ToString(value[alternativeColumn]), value));
                    }
                    else
                    {
                        OnSelected_value_changed(new SeleccionCambiada_EventArgs(Convert.ToString(value[id_column_Name]), 
                            Convert.ToString(value[colToReturn]), string.Empty, value));
                    }
                    this.Parent.SelectNextControl(this, true, true, true, true);                    
                }
                else
                {
                    selected_rowid = "";                    
                    value2 = string.Empty;
                    OnSelected_value_changed(new SeleccionCambiada_EventArgs("0", string.Empty, string.Empty, value));
                }            

            }
        }
        #endregion

        #region procedimientos_generales

        public intellises()
        {
            InitializeComponent();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            key_press_text_edited = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            key_press_text_edited = false;
            if (tablafuente != null)
            {
                Multiusos.OperacionesTeclado t = new Multiusos.OperacionesTeclado();
                if (t.DefinirTipoTecla(e) != Multiusos.OperacionesTeclado.TipoTecla.Desconocida
                    || e.KeyCode == Keys.Back || e.KeyCode == Keys.Down)
                {
                    base.OnKeyUp(e);
                    FrmIntelisense fi = new FrmIntelisense();
                    fi.TablaFuente = tablafuente;
                    fi.ColumnasVisibles = columnsToShow;
                    fi.Filtros = columnsToFilter;
                    fi.ColumnaSeleccionada = colToReturn;
                    fi.ColumnaIdComparacion = id_column_Name;
                    fi.ControlBase = this;
                    fi.Filtro = this.Text;
                    fi.Location = this.Parent.PointToScreen(this.Location);
                    fi.Location = new Point(fi.Location.X, fi.Location.Y + this.Height);
                    fi.Show();
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (grid_showed || key_press_text_edited)
            {
                OnUser_Edit(e);
            }
        }
    }
    #endregion
}
