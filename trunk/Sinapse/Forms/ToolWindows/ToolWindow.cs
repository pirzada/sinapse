using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.WinForms.Core;

namespace Sinapse.WinForms.ToolWindows
{
    public partial class ToolWindow : DockContent
    {
        Workbench workbench;

        public ToolWindow()
        {
            InitializeComponent();
        }

        public ToolWindow(Workbench workbench)
        {
            this.workbench = workbench;
        }

        public Workbench Workbench
        {
            get { return this.workbench; }
            set { this.workbench = value; }
        }
    }
}
