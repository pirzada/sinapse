using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core.Systems;

namespace Sinapse.Documents
{
    public partial class AdaptiveSystemEditor : DockContent
    {

        private NetworkSystem system;

        public AdaptiveSystemEditor(NetworkSystem system)
        {
            InitializeComponent();
            this.system = system;
        }

        private void AdaptativeSystemEditor_Load(object sender, EventArgs e)
        {
            this.dgvInterfaceInputs.DataSource = this.system.Inputs;
            this.dgvInterfaceOutputs.DataSource = this.system.Outputs;
        }
    }
}
