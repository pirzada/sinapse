using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Dialogs;

namespace Sinapse.Controls
{

    internal sealed partial class StatusBarControl : UserControl
    {

        private bool networkReady;


        //---------------------------------------------


        #region Constructor
        public StatusBarControl()
        {
            InitializeComponent();
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        internal void UpdateNetworkState(NetworkState networkState)
        {
            this.progressBar.Value = networkState.Progress;
            this.lbEpoch.Text = String.Format("Epoch: {0}", networkState.Epoch);
            this.lbTrainingError.Text = String.Format("Error: {0:0.00000}", networkState.ErrorTraining);
            this.lbValidationError.Text = String.Format("Validation: {0:0.00000}", networkState.ErrorValidation);
        }

        internal void UpdateSelectedItems(int selected, int total)
        {
            this.lbItems.Text = String.Format("{0}/{1}", selected, total);
        }
        #endregion

        //---------------------------------------------
       
        
        private void NewActionLogged(object sender, EventArgs e)
        {
            this.lbStatus.Text = HistoryLogger.GetLastLoggedAction();
        }


        private void StatusBarControl_Load(object sender, EventArgs e)
        {
            HistoryLogger.NewActionLogged += NewActionLogged;
        }


        private void progressBar_Click(object sender, EventArgs e)
        {
            new StatusBarOptions().Show();
        }


    }
}
