using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core.Systems;

namespace Sinapse.Windows.Documents
{
    public partial class NetworkSystemEditor : DockContent, IWorkplaceDocument
    {

        private ActivationNetworkSystem system;

        public NetworkSystemEditor(ActivationNetworkSystem system)
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
            if (system.FullPath != String.Empty)
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
