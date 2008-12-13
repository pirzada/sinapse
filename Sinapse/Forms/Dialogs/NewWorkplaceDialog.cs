using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Sinapse.Core;

namespace Sinapse.Forms.Dialogs
{
    public partial class NewWorkplaceDialog : Form
    {
        private Workplace workplace;

        
        public NewWorkplaceDialog()
        {
            InitializeComponent();
        }

        public Workplace Workplace
        {
            get { return workplace; }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(cbLocation.Text) && tbName.Text.Length > 0)
            {
                this.workplace = new Workplace(tbName.Text, cbLocation.Text);
                this.Close();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.cbLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}