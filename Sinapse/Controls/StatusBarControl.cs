/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Data.Structures;
using Sinapse.Forms.Dialogs;


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

            this.progressBar.Visible = (progressBar.Value != 0);
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


        #region Control Events
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //TODO: Try to resize the progressbar to fit the control
            // (simulate a ProgressBar.Spring = true)
        }

        private void StatusBarControl_Load(object sender, EventArgs e)
        {
            HistoryListener.Log.ListChanged += history_logChanged;
        }

        private void history_logChanged(object sender, ListChangedEventArgs e)
        {
            this.lbStatus.Text = HistoryListener.Log.LastEvent.Action;
        }
        #endregion


        //---------------------------------------------


        #region Buttons
        private void lbStatus_Click(object sender, EventArgs e)
        {
            if (!HistoryDialog.Instance.Visible)
                HistoryDialog.Instance.Show(this.ParentForm);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.UpdateNetworkState(new TrainingStatus());
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (!StatusBarOptionsDialog.HasInstance)
                this.m_statusBarOptionsDialog = new StatusBarOptionsDialog();

            if (!this.m_statusBarOptionsDialog.Visible)
                this.m_statusBarOptionsDialog.Show(this.ParentForm);
        }
        #endregion


    }
}
