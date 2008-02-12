using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Dialogs
{
    public partial class StatusBarOptions : Form
    {

        public StatusBarOptions()
        {
            InitializeComponent();
            numRate.Value = Properties.Settings.Default.display_UpdateRate;
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.display_UpdateRate = (int)numRate.Value;
            this.Close();
        }

    }
}