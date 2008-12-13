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
    public partial class NetworkSystemEditor : DockContent, IWorkplaceDocument
    {

        private NetworkSystem system;

        public NetworkSystemEditor(NetworkSystem system)
        {
            InitializeComponent();
            this.system = system;
        }

        private void AdaptativeSystemEditor_Load(object sender, EventArgs e)
        {
            this.dgvInterfaceInputs.DataSource = this.system.Inputs;
            this.dgvInterfaceOutputs.DataSource = this.system.Outputs;
        }







        #region IWorkplaceDocument Members

        public void Save()
        {
            if (system.Location != String.Empty)
                system.Save();
            else SaveAs();
        }

        public void SaveAs()
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                system.Save(saveFileDialog.FileName);
            }
        }

        public ToolStripMenuItem[] MenuItems
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public ToolStrip[] ToolStrips
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
