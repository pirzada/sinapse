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

        private StatusBarOptionsDialog m_statusBarOptionsDialog;

        //---------------------------------------------


        #region Constructor
        public StatusBarControl()
        {
            InitializeComponent();

            this.m_statusBarOptionsDialog = new StatusBarOptionsDialog();
            this.ResetControl();
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        internal void UpdateNetworkState(TrainingStatus networkState)
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

        internal void ResetControl()
        {
            this.UpdateNetworkState(new TrainingStatus());
            this.UpdateSelectedItems(0, 0);
            this.lbStatus.Text = String.Empty;
        }
        #endregion

        //---------------------------------------------


        private void NewActionLogged(object sender, EventArgs e)
        {
            this.lbStatus.Text = HistoryListener.GetLastLoggedAction();
        }


        private void StatusBarControl_Load(object sender, EventArgs e)
        {
            HistoryListener.NewActionLogged += NewActionLogged;
        }


        private void progressBar_Click(object sender, EventArgs e)
        {
            if (!this.m_statusBarOptionsDialog.Visible)
            {
                this.m_statusBarOptionsDialog.Show(this);
            }
        }


    }
}
