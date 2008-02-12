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

using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Controls;
using AForge;

using Sinapse.Data;
using Sinapse.Data.Structures;
using Sinapse.Dialogs;


namespace Sinapse.Controls.Sidebar
{

    internal sealed partial class SideTrainerControl : UserControl
    {

        public EventHandler TrainingComplete;

        public EventHandler DataNeeded;
        public EventHandler StatusChanged;

        private NetworkContainer m_neuralNetwork;

        private TrainingStatus m_networkState;
        private GraphDialog m_graphDialog;

        private bool m_trainingPaused;



        //---------------------------------------------


        #region Constructor
        internal SideTrainerControl()
        {
            InitializeComponent();

            this.m_graphDialog = new GraphDialog();
            this.m_networkState = new TrainingStatus();
        }
        #endregion


        //---------------------------------------------


        #region Control Events
        private void SideTrainerControl_Load(object sender, EventArgs e)
        {
            
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal NetworkContainer NeuralNetwork
        {
            get
            {
                return m_neuralNetwork;
            }
            set
            {
                if (value != null)
                {
                    this.m_neuralNetwork = value;
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                }

                this.UpdateStatus();

            }
        }

        public TrainingStatus NetworkState
        {
            get { return this.m_networkState; }
        }

        public bool IsTraining
        {
            get { return this.backgroundWorker.IsBusy; }
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

        private void pbGraph_Click(object sender, EventArgs e)
        {
            this.m_graphDialog.Show(this.ParentForm);
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void Close()
        {
            this.m_graphDialog.Close();
        }

        public void Forget()
        {
            this.m_neuralNetwork.ActivationNetwork.Randomize();
            this.m_neuralNetwork.Precision = 0;
            this.m_networkState = new TrainingStatus();
            HistoryListener.Write("Network learnings cleared");
            this.m_trainingPaused = false;
            this.UpdateStatus();
        }

        public void Stop()
        {
            this.m_networkState = new TrainingStatus();
            this.m_trainingPaused = false;

            this.UpdateStatus();

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

        public void Pause()
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

        public void Start()
        {
            if (this.backgroundWorker.IsBusy)
            {
                HistoryListener.Write("Trainer thread is busy!");
            }
            else
            {
                HistoryListener.Write("Gathering information...");

                if (this.DataNeeded != null)
                    this.DataNeeded.Invoke(this, EventArgs.Empty);
            }
        }

        public void Start(TrainingVectors trainingVectors, TrainingVectors validationVectors)
        {

            TrainingOptions options = new TrainingOptions();
            options.momentum = (double)numMomentum.Value;
            options.learningRate = (double)numLearningRate.Value;
            options.limError = (double)numErrorLimit.Value;
            options.limEpoch = (int)numEpochLimit.Value;
            options.TrainingVectors = trainingVectors;
            options.ValidationVectors = validationVectors;
            options.validateNetwork = cbValidate.Checked;

            options.TrainingType = rbErrorLimit.Checked ? TrainingType.ByError : TrainingType.ByEpoch;

            if (this.m_trainingPaused)
            {
                this.m_trainingPaused = false;
                this.m_graphDialog.ClearGraph();
            }

            if (this.cbGraph.Checked && !this.m_graphDialog.Visible)
                this.m_graphDialog.Show(this.ParentForm);

            HistoryListener.Write("Starting thread");
            this.backgroundWorker.RunWorkerAsync(options);

        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void UpdateStatus()
        {
            if (this.StatusChanged != null)
                this.StatusChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion


        //---------------------------------------------


        #region Thread
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
            BackPropagationLearning networkTeacher = new BackPropagationLearning(m_neuralNetwork.ActivationNetwork);
            networkTeacher.LearningRate = options.learningRate;
            networkTeacher.Momentum = options.momentum;

            //Start Training
            bool stop = false;
            int lastStatusEpoch = 0;
            int lastGraphEpoch = 0;

            backgroundWorker.ReportProgress(0, "Training");


            while (!stop)
            {

                #region Training Epoch
                this.m_networkState.ErrorTraining = networkTeacher.RunEpoch(options.TrainingVectors.Input, options.TrainingVectors.Output);
                this.m_networkState.ErrorValidation = networkTeacher.MeasureEpochError(options.ValidationVectors.Input, options.ValidationVectors.Output);
                #endregion


                #region Graph Update
                if (m_networkState.Epoch >= lastGraphEpoch + Properties.Settings.Default.graph_UpdateRate)
                {
                    this.m_graphDialog.TrainingPoints.Add(m_networkState.Epoch, m_networkState.ErrorTraining);
                    this.m_graphDialog.ValidationPoints.Add(m_networkState.Epoch, m_networkState.ErrorValidation);

                    if (this.m_graphDialog.Visible && this.m_graphDialog.AutoUpdate)
                    {
                        this.m_graphDialog.UpdateGraph();
                    }

                    lastGraphEpoch = m_networkState.Epoch;

                }
                #endregion


                #region GUI Update
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
                  
                    backgroundWorker.ReportProgress(0);
                    lastStatusEpoch = m_networkState.Epoch;
                }
                #endregion

                m_networkState.Epoch++;



                //Determine if there is need to stop
                if (options.TrainingType == TrainingType.ByError)
                {
                    if (m_networkState.ErrorTraining <= options.limError)
                        stop = true;
                }
                else
                {
                    if (m_networkState.Epoch >= options.limEpoch)
                        stop = true;
                }


                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    stop = true;
                }
            }

            backgroundWorker.ReportProgress(0);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Update Status Text
            string statusText = e.UserState as string;

            if (statusText != null)
                HistoryListener.Write(statusText);

            //Notify StatusbarControl to update information
            this.UpdateStatus();
        }


        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_neuralNetwork.Precision = this.m_networkState.ErrorTraining;

            if (e.Cancelled)
            {
                HistoryListener.Write("Training stopped");
            }
            else
            {
                HistoryListener.Write("Training Finished!");

                this.m_networkState.Progress = 100;
                this.UpdateStatus();

                if (this.TrainingComplete != null)
                    this.TrainingComplete.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion


    }
}
