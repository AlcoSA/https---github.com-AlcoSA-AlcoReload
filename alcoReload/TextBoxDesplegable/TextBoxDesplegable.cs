using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBoxDesplegable
{
    public partial class TextBoxDesplegable : Component
    {
        public TextBoxDesplegable()
        {
            InitializeComponent();
        }

        public TextBoxDesplegable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
