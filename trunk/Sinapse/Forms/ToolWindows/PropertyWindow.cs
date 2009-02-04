using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.WinForms.Core;

namespace Sinapse.WinForms.ToolWindows
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

        public object SelectedObject
        {
            get { return this.propertyGrid.SelectedObject; }
            set { this.propertyGrid.SelectedObject = value; }
        }


    }
}
