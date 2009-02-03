using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Sinapse.Forms.ToolWindows
{
    public partial class PropertyWindow : ToolWindow
    {

        public PropertyWindow(Workbench workbench) : base(workbench)
        {
            InitializeComponent();
        }

        public PropertyGrid PropertyGrid
        {
            get { return this.propertyGrid; }
        }

    }
}
