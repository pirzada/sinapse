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

        public EventHandler OnTrainingComplete;

        public EventHandler OnDataNeeded;
        public EventHandler OnStatusChanged;

        private NetworkContainer m_neuralNetwork;

        private NetworkState m_networkState;
        private GraphDialog  m_graphDialog;
        


        //---------------------------------------------


        #region Constructor
        public SideTrainerControl()
        {
            InitializeComponent();

            this.m_graphDialog = new GraphDialog();
            this.m_networkState = new NetworkState();
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

        public NetworkState TrainingStatus
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
            this.m_graphDialog.Show();
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void Forget()
        {
            this.m_neuralNetwork.ActivationNetwork.Randomize();
            this.m_neuralNetwork.Precision = 0;
            this.m_networkState = new NetworkState();
            this.UpdateStatus("Network learnings cleared");
        }

        public void Stop()
        {
            this.m_networkState = new NetworkState();

            if (backgroundWorker.IsBusy)
            {
                this.UpdateStatus("Stopping Thread");
                this.backgroundWorker.CancelAsync();
            }
            else
            {
                this.UpdateStatus("Thread is not running");
            }
        }

        public void Pause()
        {
            if (backgroundWorker.IsBusy)
            {
                this.UpdateStatus("Pausing Thread");
                this.backgroundWorker.CancelAsync();
            }
            else
            {
                this.UpdateStatus("Thread is not running");
            }
        }

        public void Start()
        {
            if (this.backgroundWorker.IsBusy)
            {
                this.UpdateStatus("Trainer thread is busy!");
            }
            else
            {
                this.UpdateStatus("Gathering information...");

                if (this.OnDataNeeded != null)
                    this.OnDataNeeded.Invoke(this, EventArgs.Empty);
            }
        }

        public void Start(NetworkVectors trainingVectors, NetworkVectors validationVectors)
        {
            
            NetworkOptions options = new NetworkOptions();
            options.momentum = (double)numMomentum.Value;
            options.learningRate = (double)numLearningRate.Value;
            options.limError = (double)numErrorLimit.Value;
            options.limEpoch = (int)numEpochLimit.Value;
            options.TrainingVectors = trainingVectors;
            options.validateNetwork = cbValidate.Checked;

            options.TrainingType = rbErrorLimit.Checked ? TrainingType.ByError : TrainingType.ByEpoch;
                
            
            this.UpdateStatus("Starting thread");
            this.backgroundWorker.RunWorkerAsync(options);
        
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void UpdateStatus()
        {
            if (this.OnStatusChanged != null)
                this.OnStatusChanged.Invoke(this, EventArgs.Empty);
        }

        private void UpdateStatus(string text)
        {
            this.m_networkState.StatusText = text;
            this.UpdateStatus();
        }
        #endregion


        //---------------------------------------------


        #region Thread
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if (!(e.Argument is NetworkOptions))
            {
                this.m_networkState.StatusText = "Bad thread argument!";
                backgroundWorker.ReportProgress(0);
                e.Cancel = true;
                return;
            }
            

            NetworkOptions options = (NetworkOptions)e.Argument;                       
            

            //Create Teacher
            BackPropagationLearning networkTeacher = new BackPropagationLearning(m_neuralNetwork.ActivationNetwork);
            networkTeacher.LearningRate = options.learningRate;
            networkTeacher.Momentum = options.momentum;

            //Start Training
            bool stop = false;
            int lastReportEpoch = 0;
                              
            this.m_networkState.StatusText = "Training";
            backgroundWorker.ReportProgress(0);


            while (!stop)
            {


                #region Training Epoch
                this.m_networkState.TrainingErrorRate = networkTeacher.RunEpoch(options.TrainingVectors.Input, options.TrainingVectors.Output);
                this.m_graphDialog.TrainingCurve.AddPoint(m_networkState.Epoch, m_networkState.TrainingErrorRate);

                this.m_networkState.ValidationErrorRate = networkTeacher.MeasureEpochError(options.ValidationVectors.Input, options.ValidationVectors.Output);
                this.m_graphDialog.ValidationCurve.AddPoint(m_networkState.Epoch, m_networkState.ValidationErrorRate);

                m_networkState.Epoch++;
                #endregion


                #region GUI Update
                if (m_networkState.Epoch >= lastReportEpoch + Properties.Settings.Default.display_refreshRate)
                {
                    if (options.TrainingType == TrainingType.ByError)
                    {
                        if (m_networkState.TrainingErrorRate != 0)
                            m_networkState.Progress = Math.Max(Math.Min((int)((options.limError * 100) / m_networkState.TrainingErrorRate), 100), 0);
                    }
                    else
                    {
                        if (m_networkState.Epoch != 0)
                            m_networkState.Progress = Math.Max(Math.Min((int)((m_networkState.Epoch * 100) / options.limEpoch), 100), 0);
                    }

                    backgroundWorker.ReportProgress(0);
                    lastReportEpoch = m_networkState.Epoch;
                }
                #endregion


                //Determine if there is need to stop
                if (options.TrainingType == TrainingType.ByError)
                {
                    if (m_networkState.TrainingErrorRate <= options.limError)
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

            backgroundWorker.ReportProgress(100);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            NetworkState networkState = (NetworkState)e.UserState;
            this.m_networkState = networkState;

            if (this.m_graphDialog.Visible && this.m_graphDialog.AutoUpdate)
            {
                this.m_graphDialog.UpdateGraph();
            }

            this.UpdateStatus();
        }
        

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_neuralNetwork.Precision = this.m_networkState.TrainingErrorRate;
            
            if (e.Cancelled)
            {
                this.UpdateStatus("Training stopped");

            /*  if (this.OnTrainingCancelled != null)
                   this.OnTrainingCancelled.Invoke(this, EventArgs.Empty);
                                                                                */ 
            }
            else
            {
                this.UpdateStatus("Training Finished!");

                if (this.OnTrainingComplete != null)
                    this.OnTrainingComplete.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        
    }
}
