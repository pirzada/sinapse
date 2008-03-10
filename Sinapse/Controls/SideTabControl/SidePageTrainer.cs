/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
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

using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;

using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Data.Structures;
using Sinapse.Forms.Dialogs;


namespace Sinapse.Controls.SideTabControl
{

    internal sealed partial class SidePageTrainer : Sinapse.Controls.Base.TabPageControlBase
    {

        internal EventHandler TrainingComplete;
        internal EventHandler StatusChanged;

        private NetworkContainer m_networkContainer;
        private NetworkDatabase m_networkDatabase;

        private TrainingStatus m_networkState;
        private Sinapse.Controls.MainTabControl.TabPageGraph m_graphControl;

        private bool m_trainingPaused;
        private double m_epochsBySecond;
        private int m_lastTickEpoch;



        //---------------------------------------------


        #region Constructor
        internal SidePageTrainer()
        {
            InitializeComponent();

            this.cbTrainingLayer.DataSource = new object[] { "All", 1, 2, 3, 4, 5, };
            this.m_networkState = new TrainingStatus();
        }
        #endregion


        //---------------------------------------------


        #region Control Events
        private void timer_Tick(object sender, EventArgs e)
        {
            m_epochsBySecond = (m_networkState.Epoch - m_lastTickEpoch)*2;
            m_lastTickEpoch = m_networkState.Epoch;

            if (Properties.Settings.Default.display_UpdateByTime)
                this.updateStatus();
        }

        private void cbAutosave_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.training_Autosave = cbAutosave.Checked;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal NetworkContainer NetworkContainer
        {
            get { return this.m_networkContainer; }
            set
            {
                this.m_networkContainer = value;

                if (value != null)
                {
                    this.m_networkContainer.Savepoints.SavepointRestored +=
                        networkContainer_SavepointRestored;
                }
                else
                {
                    this.m_networkState = new TrainingStatus();
                    this.m_trainingPaused = false;
                    this.m_graphControl.ClearGraph();
                }

                this.updateEnabled();
                this.updateStatus();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal NetworkDatabase NetworkDatabase
        {
            get { return this.m_networkDatabase; }
            set
            {
                this.m_networkDatabase = value;

                if (value != null)
                {
                }
                else
                {
                    this.m_networkState = new TrainingStatus();
                    this.m_trainingPaused = false;
                    this.m_graphControl.ClearGraph();
                    this.updateStatus();
                }

                this.updateEnabled();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal TrainingStatus NetworkState
        {
            get { return this.m_networkState; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsTraining
        {
            get { return this.backgroundWorker.IsBusy; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Sinapse.Controls.MainTabControl.TabPageGraph GraphControl
        {
            get { return this.m_graphControl; }
            set { this.m_graphControl = value; }
        }
        #endregion


        //---------------------------------------------


        #region Buttons
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Stop();
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            this.Forget();
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        internal void Forget()
        {
            this.m_networkContainer.ActivationNetwork.Randomize();
            this.m_networkContainer.Precision = 0;
            this.m_networkState = new TrainingStatus();
            HistoryListener.Write("Network learnings cleared");
            this.m_trainingPaused = false;
            this.m_graphControl.ClearGraph();
            this.updateStatus();
        }

        internal void Stop()
        {
            this.m_networkState = new TrainingStatus();
            this.m_trainingPaused = false;

            this.updateStatus();

            if (backgroundWorker.IsBusy)
            {
                HistoryListener.Write("Stopping Thread");
                this.backgroundWorker.CancelAsync();
            }
            else
            {
                HistoryListener.Write("Thread is not running");
            }
        }

        internal void Pause()
        {
            if (backgroundWorker.IsBusy)
            {
                HistoryListener.Write("Pausing Thread");
                this.backgroundWorker.CancelAsync();

                this.m_trainingPaused = true;
            }
            else
            {
                HistoryListener.Write("Thread is not running");
            }
        }

        internal void Start()
        {
            if (this.backgroundWorker.IsBusy)
            {
                HistoryListener.Write("Trainer thread is busy!");
            }
            else
            {
                HistoryListener.Write("Gathering information...");

                TrainingOptions options = new TrainingOptions();
                options.momentum = (double)numMomentum.Value;
                options.firstLearningRate = (double)numLearningRate.Value;
                options.limError = (double)numErrorLimit.Value;
                options.limEpoch = (int)numEpochLimit.Value;


                if (cbTrainingLayer.SelectedIndex == 0)
                {
                    options.TrainingVectors = this.NetworkDatabase.CreateVectors(NetworkSet.Training);
                }
                else
                {
                    options.TrainingVectors = this.NetworkDatabase.CreateVectors(NetworkSet.Training, (ushort)cbTrainingLayer.SelectedIndex);
                }


                options.ValidationVectors = this.NetworkDatabase.CreateVectors(NetworkSet.Validation);
                options.validateNetwork = cbValidate.Checked;

                options.secondLearningRate = cbChangeRate.Checked ? (double?)numChangeRate.Value : options.secondLearningRate = null;

                if (rbEpochLimit.Checked)
                options.TrainingType = TrainingType.ByEpoch;
                else if (rbErrorLimit.Checked)
                    options.TrainingType = TrainingType.ByError;
                else if (rbManual.Checked)
                    options.TrainingType = TrainingType.Manual;

                if (this.m_trainingPaused)
                {   // Network is paused, then
                    this.m_trainingPaused = false;
                }
                else
                {   // Network is stopped, then
                    this.m_graphControl.ClearGraph();
                }

                if (this.cbSwitchGraph.Checked)
                {
                    this.m_graphControl.ShowTab();
                }


                HistoryListener.Write("Starting thread");
                this.backgroundWorker.RunWorkerAsync(options);
            }
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void updateStatus()
        {
            if (this.StatusChanged != null)
                this.StatusChanged.Invoke(this, EventArgs.Empty);
        }

        private void updateEnabled()
        {
            this.Enabled = (this.m_networkDatabase != null && this.m_networkContainer != null);
            this.m_graphControl.UpdateEnabled();
        }

        private void networkContainer_SavepointRestored(object sender, EventArgs e)
        {
            this.m_networkState = this.m_networkContainer.Savepoints.CurrentSavepoint.NetworkStatus;
            this.updateStatus();
        }
        #endregion


        //---------------------------------------------


        #region Worker Thread
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (!(e.Argument is TrainingOptions))
            {
                backgroundWorker.ReportProgress(0, "Bad thread argument!");
                e.Cancel = true;
                return;
            }

            TrainingOptions options = (TrainingOptions)e.Argument;


            //Create Teacher
            BackPropagationLearning networkTeacher = new BackPropagationLearning(m_networkContainer.ActivationNetwork);
            networkTeacher.LearningRate = options.firstLearningRate;
            networkTeacher.Momentum = options.momentum;

            //Start Training
            bool stop = false;
            int lastStatusEpoch = 0;
            int lastGraphEpoch = 0;
            int lastSaveEpoch = 0;

            backgroundWorker.ReportProgress(0, "Training...");


            while (!stop)
            {

                #region Training Epoch
                this.m_networkState.ErrorTraining = networkTeacher.RunEpoch(options.TrainingVectors.Input, options.TrainingVectors.Output);
                this.m_networkState.ErrorValidation = networkTeacher.MeasureEpochError(options.ValidationVectors.Input, options.ValidationVectors.Output);

                // Adjust Training Rate
                if (options.secondLearningRate.HasValue)
                    networkTeacher.LearningRate = options.secondLearningRate.Value;
                #endregion


                #region Mark Network Savepoint
                if (Properties.Settings.Default.training_Autosave == true &&
                    m_networkState.Epoch >= lastSaveEpoch + Properties.Settings.Default.training_AutosaveEpochs)
                {
                    m_networkState.NextUpdateType = UpdateType.NetworkSave;
                    backgroundWorker.ReportProgress(0);
                    lastSaveEpoch = m_networkState.Epoch;
                }
                #endregion

                #region Graph Update
                if (Properties.Settings.Default.graph_Disable == false &&
                    m_networkState.Epoch >= lastGraphEpoch + Properties.Settings.Default.graph_UpdateRate)
                {
                    m_networkState.NextUpdateType = UpdateType.Graph;
                    backgroundWorker.ReportProgress(0);
                    lastGraphEpoch = m_networkState.Epoch;
                }
                #endregion

                #region Statusbar Update
                if (m_networkState.Epoch >= lastStatusEpoch + Properties.Settings.Default.display_UpdateRate)
                {
                    if (options.TrainingType == TrainingType.ByError)
                    {
                        if (m_networkState.ErrorTraining != 0)
                            m_networkState.Progress = Math.Max(Math.Min((int)((options.limError * 100) / m_networkState.ErrorTraining), 100), 0);
                    }
                    else
                    {
                        if (m_networkState.Epoch != 0)
                            m_networkState.Progress = Math.Max(Math.Min((int)((m_networkState.Epoch * 100) / options.limEpoch), 100), 0);
                    }

                    backgroundWorker.ReportProgress(0, "Training...");
                    lastStatusEpoch = m_networkState.Epoch;
                }
                #endregion


                m_networkState.Epoch++;


                #region Stop Conditions
                if (options.TrainingType == TrainingType.ByError)
                {
                    if (m_networkState.ErrorTraining <= options.limError)
                        stop = true;
                }
                else if (options.TrainingType == TrainingType.ByEpoch)
                {
                    if (m_networkState.Epoch >= options.limEpoch)
                        stop = true;
                }


                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    stop = true;
                }
                #endregion

            }
            backgroundWorker.ReportProgress(0);
        }


        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            switch (m_networkState.NextUpdateType)
            {

                case UpdateType.NetworkSave:
                    m_networkContainer.Savepoints.Register(m_networkState);
      //              HistoryListener.Write("Savepoint Marked");
                    break;


                case UpdateType.Graph:
                    this.m_graphControl.TrainingPoints.Add(m_networkState.Epoch, m_networkState.ErrorTraining);
                    this.m_graphControl.ValidationPoints.Add(m_networkState.Epoch, m_networkState.ErrorValidation);

                    if (Properties.Settings.Default.graph_Autoupdate)
                    {
                        this.m_graphControl.UpdateGraph();
                    }
                    break;


                case UpdateType.Statusbar:

                    if (Properties.Settings.Default.display_UpdateByTime == false)
                    {
                        string statusText = e.UserState as string;

                        if (statusText != null)
                            HistoryListener.Write(statusText);

                        this.updateStatus();
                    }
                    break;


                default:
                    goto case UpdateType.Statusbar;
            }

            m_networkState.NextUpdateType = UpdateType.Statusbar;
        }


        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_networkContainer.Precision = this.m_networkState.ErrorTraining;

            if (e.Cancelled)
            {
                HistoryListener.Write("Training stopped");
            }
            else
            {
                HistoryListener.Write("Training Finished!");

                this.m_networkState.Progress = 100;
                this.updateStatus();

                if (this.TrainingComplete != null)
                    this.TrainingComplete.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion


    }
}
