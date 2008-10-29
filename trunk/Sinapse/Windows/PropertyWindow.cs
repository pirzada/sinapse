using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Sinapse.Windows
{
    public partial class PropertyWindow : DockContent
    {

        public PropertyWindow()
        {
            InitializeComponent();
        }

        public PropertyGrid PropertyGrid
        {
            get { return this.propertyGrid; }
        }

    }
}
