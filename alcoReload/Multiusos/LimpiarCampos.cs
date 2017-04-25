using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Multiusos
{
    public class LimpiarCampos
    {
        public void Limpiar(Control formulario)
        {
            try
            {
                foreach (Control ctrl in formulario.Controls)
                {
                    if (ctrl is TabControl){
                        Limpiar(ctrl);
                    }

                    if (ctrl is TabPage){
                        Limpiar(ctrl);
                    }

                    foreach (Control c in ctrl.Controls)
                    {
                        if (c is TextBox){
                            ((TextBox)c).Text = string.Empty;
                        }

                        if (c is ComboBox){
                            ((ComboBox)c).SelectedValue = 0;
                        }

                        if (c is NumericUpDown){
                            ((NumericUpDown)c).Value = 0;
                        }

                        if (c is DateTimePicker){
                            ((DateTimePicker)c).Value = DateTime.Now;
                        }

                        if (c is CheckBox){
                            ((CheckBox)c).Checked = false;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
