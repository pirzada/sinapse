using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;

namespace Sinapse.Controls.NetworkDataTab
{
    internal partial class TabPageQuery : Sinapse.Controls.NetworkDataTab.TabPageBase
    {

        //----------------------------------------


        #region Constructor
        public TabPageQuery()
        {
            InitializeComponent();
            SetUp(NetworkSet.Query, "Network Query");
        }
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnCurrentNetworkChanged()
        {
            this.Enabled = (this.NetworkContainer != null);

            if (this.NetworkContainer != null)
            {
                this.NetworkDatabase = new NetworkDatabase(this.NetworkContainer.Schema);
                //this.BindingSource.DataSource = m_networkDatabase;
            }
            else
            {
                this.NetworkDatabase = null;
                //this.BindingSource.DataSource = null;
            }
        }
        #endregion


        //----------------------------------------


        #region Buttons
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            this.NetworkDatabase.ComputeTable(this.NetworkContainer, false);

        }

        private void btnRound_Click(object sender, EventArgs e)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            this.NetworkDatabase.Round(false);
        }
        #endregion



        //----------------------------------------


    }
}

