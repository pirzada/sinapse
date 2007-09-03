using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;

namespace Sinapse.Controls
{
    internal sealed partial class NetworkRangesControl : UserControl
    {

        private NetworkData networkData;
        private bool readOnly;

        //---------------------------------------------

        #region Constructor
        public NetworkRangesControl()
        {
            InitializeComponent();
        }
        #endregion

        //---------------------------------------------

        #region Properties
        internal NetworkData NetworkData
        {
            get { return this.networkData; }
            set
            {
                if (value != null)
                {
                    this.Enabled = true;
                    this.networkData = value;
                    this.dataGridView.DataSource = this.networkData.NetworkSchema.DataRanges.Table;
                }
                else
                {
                    this.Enabled = false;
                    this.dataGridView.DataSource = null;
                    this.networkData = null;
                }
            }
        }

        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                this.readOnly = value;
                this.dataGridView.ReadOnly = value;
                this.btnAutodetect.Enabled = !value;
            }
        }
        #endregion

        //---------------------------------------------

        private void btnAutodetect_Click(object sender, EventArgs e)
        {
            this.networkData.NetworkSchema.DataRanges.AutodetectRanges(this.networkData.DataTable);
        }

    }
}
