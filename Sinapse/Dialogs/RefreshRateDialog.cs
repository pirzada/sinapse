using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Dialogs
{
    public partial class RefreshRateDialog : Form
    {

        public EventHandler RefreshRateChanged;

        public RefreshRateDialog()
        {
            InitializeComponent();
        }

        public int RefreshRate
        {
            get { return (int)numRate.Value; }
            set { numRate.Value = value; }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (RefreshRateChanged != null)
            {
                RefreshRateChanged.Invoke(this, EventArgs.Empty);
            }

            this.Close();
        }
    }
}