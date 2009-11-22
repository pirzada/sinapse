using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Sinapse.Core;
using Sinapse.WinForms.Core;

namespace Sinapse.WinForms.Dialogs
{
    public partial class NewWorkplaceDialog : Form
    {
        private Workbench workbench;


        public NewWorkplaceDialog(Workbench workbench)
        {
            InitializeComponent();

            this.workbench = workbench;
        }

        public Workbench Workbench
        {
            get { return workbench; }
            set { workbench = value; }
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cbLocation.Items.Add(Properties.Settings.Default.workplaces_path);
            cbLocation.SelectedIndex = 0;
            tbName.Text = "workplace1";
        }





        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = cbLocation.Text;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.cbLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Check if we already have a Workplace open
            if (workbench.Workplace != null)
            {
                // Try to close and check if successful
                if (workbench.CloseAllDocuments(true) == false)
                {
                    this.Close(); // the operation was cancelled by the user.
                    return;
                }
            }


            // Verify if name is good
            if (tbName.Text.Length > 0)
            {
                string location = cbLocation.Text;

                // Check if directory exists
                if (!Directory.Exists(location))
                {
                    // Directory does not exist
                    DialogResult r = MessageBox.Show("Directory creation","The directory does not exist. Do you want Sinapse to automatically create it for you?", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        Directory.CreateDirectory(location);
                    }
                    else return;
                }

                Sinapse.Data.HistoryListener.Write("Creating Workplace Directory");
                
                if (cbCreateFolder.Checked)
                {
                    location = Path.Combine(location, tbName.Text);
                    Directory.CreateDirectory(location);
                }


                Sinapse.Data.HistoryListener.Write("Creating Workplace");

                Workplace workplace = new Workplace(tbName.Text,
                    new FileInfo(Path.Combine(location, tbName.Text + ".workplace")));

                workplace.Save(); // creates the directory structure
                workbench.OpenWorkplace(workplace); // opens the workplace in the current workbench.
                
                this.Close();
            }
        }

    }
}