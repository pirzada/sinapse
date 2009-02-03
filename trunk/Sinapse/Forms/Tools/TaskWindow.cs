using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Sinapse.Forms.ToolWindows
{
    public partial class TaskWindow : ToolWindow
    {
        public TaskWindow(Workbench workbench) : base(workbench)
        {
            InitializeComponent();
        }
    }
}