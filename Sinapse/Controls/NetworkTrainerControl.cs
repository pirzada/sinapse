/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2007 Cesar Roberto de Souza <cesarsouza@gmail.com> *
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


namespace Sinapse.Controls
{
    internal sealed partial class NetworkTrainerControl : UserControl
    {

        private const string errorLabel = "errorMatrix";
        private const string crossLabel = "crossMatrix";

      //  public EventHandler OnTrainingStarted;
      //  public EventHandler OnTrainingStopped;
        public EventHandler OnTrainingComplete;

        public EventHandler OnDataNeeded;
        public EventHandler OnStatusChanged;

        private NetworkContainer m_neuralNetwork;
        private int m_epoch;
        private int m_progress;
        private bool m_autoUpdate;
        private double m_errorRate;
        private string m_statusText;

        private int m_statusRefresh = 500;


        //---------------------------------------------

        #region Constructor
        public NetworkTrainerControl()
        {
            InitializeComponent();

            this.m_statusText = String.Empty;
        }
        #endregion

        //---------------------------------------------

        #region Properties
        internal NetworkContainer NeuralNetwork
        {
            get { return m_neuralNetwork; }
            set
            {
                if (value != null)
                {
                    this.m_neuralNetwork = value;
                    this.Enabled = true;
                }
                else this.Enabled = false;

                this.setTrainingInfo(0, 0, 0);
                this.errorChart.RemoveAllDataSeries();
            }
        }

        public string Status
        {
            get { return this.m_statusText; }
        }

        public double ErrorRate
        {
            get { return this.m_errorRate; }
        }

        public int Epoch
        {
            get { return this.m_epoch; }
        }

        public int Progress
        {
            get { return this.m_progress; }
        }

        public bool IsTraining
        {
            get { return this.backgroundWorker.IsBusy; }
        }

        public int StatusRefreshRate
        {
            get { return m_statusRefresh; }
            set { m_statusRefresh = value; }
        }
        #endregion

        //---------------------------------------------

       
        #region Buttons
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker.IsBusy)
            {
                this.setStatus("Trainer thread is busy!");
            }
            else
            {
                this.setStatus("Gathering information...");

                if (this.OnDataNeeded != null)
                    this.OnDataNeeded.Invoke(this, EventArgs.Empty);
            }
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
            this.m_neuralNetwork.ActivationNetwork.Randomize();
            this.m_neuralNetwork.Precision = 0;
            this.setTrainingInfo(0, 0, 0);
            this.setStatus("Network learnings cleared");
            
        }
        #endregion

        //---------------------------------------------

        #region Public Methods
        public void Stop()
        {
            if (backgroundWorker.IsBusy)
            {
                this.setStatus("Stopping Thread");
                this.backgroundWorker.CancelAsync();
            }
            else
            {
                this.setStatus("Thread is not running");
            }

            this.setTrainingInfo(0, 0, 0);
        }

        public void Pause()
        {
            if (backgroundWorker.IsBusy)
            {
                this.setStatus("Pausing Thread");
                this.backgroundWorker.CancelAsync();
            }
            else
            {
                this.setStatus("Thread is not running");
            }
        }

        public void Start(NetworkVectors trainingVectors, NetworkVectors validationVectors)
        {
            NetworkOptions options = new NetworkOptions();
            options.momentum = (double)numMomentum.Value;
            options.learningRate = (double)numLearningRate.Value;
            options.errorLimit = (double)numErrorLimit.Value;
            options.TrainingVectors = trainingVectors;

            if (cbValidate.Checked && !validationVectors.isEmpty)
                options.ValidationVectors = validationVectors;
            else options.ValidationVectors = null;

            options.epochLimit = (int)numEpochLimit.Value;
            options.errorBased = rbErrorLimit.Checked;

            this.setStatus("Starting thread");
            this.backgroundWorker.RunWorkerAsync(options);
        }
        #endregion

        //---------------------------------------------

        #region Private Methods
        private void setStatus(string text)
        {
            this.m_statusText = text;

            if (this.OnStatusChanged != null)
                this.OnStatusChanged.Invoke(this, EventArgs.Empty);
        }

        private void setTrainingInfo(int epochs, double errorRate, int progress)
        {
            this.m_epoch = epochs;
            this.m_errorRate = errorRate;
            this.m_progress = progress;

            if (this.OnStatusChanged != null)
                this.OnStatusChanged.Invoke(this, EventArgs.Empty);
        }

        private void cbRealTime_CheckedChanged(object sender, EventArgs e)
        {
            this.m_autoUpdate = cbRealTime.Checked;
        }
        #endregion

        //---------------------------------------------

        #region Thread
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            NetworkState networkState = new NetworkState();
            networkState.Epoch = m_epoch;
            networkState.TrainingErrorRate = m_errorRate;
            
            NetworkOptions options = e.Argument as NetworkOptions;

            if (options == null)
            {
                networkState.StatusText = "Bad thread argument!";
                backgroundWorker.ReportProgress(0, networkState);
                e.Cancel = true;
                return;
            }

            //Create Teacher
            BackPropagationLearning networkTeacher = new BackPropagationLearning(m_neuralNetwork.ActivationNetwork);
            networkTeacher.LearningRate = options.learningRate;
            networkTeacher.Momentum = options.momentum;

            //Start Training
            //TODO: Implement proper training dividing data into training and validation sets
            int progress = 0;
            int lastReportEpoch = 0;
            bool stop = false;

            networkState.StatusText = "Training";
            backgroundWorker.ReportProgress(0, networkState);

            while (!stop)
            {

                //Run currentEpoch of learning procedure
                networkState.TrainingErrorRate = networkTeacher.RunEpoch(options.TrainingVectors.Input, options.TrainingVectors.Output);
                networkState.TrainingErrorList.Add(networkState.TrainingErrorRate);

                if (options.ValidationVectors.HasValue)
                {
                    networkState.ValidationErrorRate = networkTeacher.MeasureEpochError(options.ValidationVectors.Value.Input, options.ValidationVectors.Value.Output);
                    networkState.ValidationErrorList.Add(networkState.ValidationErrorRate);
                }

                networkState.Epoch++;

                //Updates GUI almost every 500 iterations
                if (networkState.Epoch >= lastReportEpoch + m_statusRefresh)
                {
                    if (options.errorBased)
                    {
                        if (networkState.TrainingErrorRate != 0)
                            progress = Math.Max(Math.Min((int)((options.errorLimit * 100) / networkState.TrainingErrorRate), 100), 0);
                        //else progress = 100;
                    }
                    else
                    {
                        if (networkState.Epoch != 0)
                            progress = Math.Max(Math.Min((int)((networkState.Epoch * 100) / options.epochLimit), 100), 0);
                    }

                    backgroundWorker.ReportProgress(progress, networkState);
                    lastReportEpoch = networkState.Epoch;
                }

                //Determine if there is need to stop
                if (options.errorBased)
                {
                    if (networkState.TrainingErrorRate <= options.errorLimit)
                        stop = true;
                }
                else if (networkState.Epoch >= options.epochLimit)
                    stop = true;


                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    stop = true;
                }
            }

            e.Result = networkState;
            backgroundWorker.ReportProgress(100, networkState);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            NetworkState networkState = e.UserState as NetworkState;

            if (networkState != null)
            {
                this.m_epoch = networkState.Epoch;
                this.m_errorRate = networkState.TrainingErrorRate;
                this.m_statusText = networkState.StatusText;
                this.m_progress = e.ProgressPercentage;

                if (this.m_autoUpdate)
                {
                    this.errorChart.RemoveAllDataSeries();
                    this.errorChart.AddDataSeries(errorLabel, Color.Red, Chart.SeriesType.Line, 1, true);
                    this.errorChart.AddDataSeries(crossLabel, Color.Blue, Chart.SeriesType.Line, 1, true);
                    this.errorChart.RangeX = new DoubleRange(0, networkState.Epoch);
                    this.errorChart.UpdateDataSeries(errorLabel, networkState.GetTrainingErrors());

                    if (networkState.ValidationErrorList.Count > 0)
                        this.errorChart.UpdateDataSeries(crossLabel, networkState.GetValidationErrors());
                }

                if (this.OnStatusChanged != null)
                    this.OnStatusChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_neuralNetwork.Precision = this.m_errorRate;
            
            if (e.Cancelled)
            {
                this.setStatus("Training stopped");
            }
            else
            {
                this.setStatus("Done");

                NetworkState networkState = e.Result as NetworkState;
                if (networkState != null)
                {
                    this.errorChart.RemoveAllDataSeries();
                    this.errorChart.AddDataSeries(errorLabel, Color.Red, Chart.SeriesType.Line, 1, true);
                    this.errorChart.AddDataSeries(crossLabel, Color.Blue, Chart.SeriesType.Line, 1, true);
                    this.errorChart.RangeX = new DoubleRange(0, networkState.Epoch);
                    this.errorChart.UpdateDataSeries(errorLabel, networkState.GetTrainingErrors());
                    
                    if (networkState.ValidationErrorList.Count > 0)
                        this.errorChart.UpdateDataSeries(crossLabel, networkState.GetValidationErrors());
                }

                if (this.OnTrainingComplete != null)
                    this.OnTrainingComplete.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        
    }
}
