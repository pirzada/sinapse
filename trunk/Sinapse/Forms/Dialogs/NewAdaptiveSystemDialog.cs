using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core;
using Sinapse.Core.Systems;

namespace Sinapse.Forms.Dialogs
{
    public partial class NewAdaptiveSystemDialog : Form
    {
        public NewAdaptiveSystemDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("Invalid filename");
                return;
            }
            if (!System.IO.Path.HasExtension(tbName.Text))
            {
                MessageBox.Show("Extension missing");
                return;
            }

            ActivationNetworkSystem ans = new ActivationNetworkSystem(tbName.Text);
            string path = System.IO.Path.Combine(Workplace.Active.FilePath, tbName.Text);
            ans.Save(path);
            Workplace.Active.AdaptiveSystems.Add(tbName.Text, typeof(ActivationNetworkSystem));

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}