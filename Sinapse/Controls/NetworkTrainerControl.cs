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


namespace Sinapse.Controls
{
    internal sealed partial class NetworkTrainerControl : UserControl
    {

        private const string errorLabel = "errorMatrix";

      //  public EventHandler OnTrainingStarted;
      //  public EventHandler OnTrainingStopped;
        public EventHandler OnTrainingComplete;

        public EventHandler OnDataNeeded;
        public EventHandler OnStatusChanged;

        private NeuralNetwork m_neuralNetwork;
        private int m_epoch;
        private int m_progress;
        private bool m_autoUpdate;
        private double m_errorRate;
        private string m_statusText;

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
        internal NeuralNetwork NeuralNetwork
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
        }

        public void Start(double[][] input, double[][] output)
        {
            NetworkOptions options = new NetworkOptions();
            options.momentum = (double)numMomentum.Value;
            options.learningRate = (double)numLearningRate.Value;
            options.errorLimit = (double)numErrorLimit.Value;
            options.input = input;
            options.output = output;

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
                networkState.ErrorRate = networkTeacher.RunEpoch(options.input, options.output);
                networkState.ErrorList.Add(networkState.ErrorRate);
                networkState.Epoch++;

                //Updates GUI almost every 500 iterations
                if (networkState.Epoch > lastReportEpoch + 499)
                {
                    if (networkState.ErrorRate != 0)
                        progress = Math.Max(Math.Min((int)((options.errorLimit * 100) / networkState.ErrorRate), 100), 0);
                    //else progress = 100;

                    backgroundWorker.ReportProgress(progress, networkState);
                    lastReportEpoch = networkState.Epoch;
                }

                //Determine if there is need to stop
                if (networkState.ErrorRate <= options.errorLimit)
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
                this.m_errorRate = networkState.ErrorRate;
                this.m_statusText = networkState.StatusText;
                this.m_progress = e.ProgressPercentage;

                if (this.m_autoUpdate)
                {
                    this.errorChart.RemoveAllDataSeries();
                    this.errorChart.AddDataSeries(errorLabel, Color.Red, Chart.SeriesType.Line, 1, true);
                    this.errorChart.RangeX = new DoubleRange(0, networkState.Epoch);
                    this.errorChart.UpdateDataSeries(errorLabel, networkState.GetErrors());
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
                this.setStatus("Training cancelled");
                this.setTrainingInfo(0, 0, 0);
            }
            else
            {
                this.setStatus("Done");

                NetworkState networkState = e.Result as NetworkState;
                if (networkState != null)
                {
                    this.errorChart.RemoveAllDataSeries();
                    this.errorChart.AddDataSeries(errorLabel, Color.Red, Chart.SeriesType.Line, 1, true);
                    this.errorChart.RangeX = new DoubleRange(0, networkState.Epoch);
                    this.errorChart.UpdateDataSeries(errorLabel, networkState.GetErrors());
                }

                if (this.OnTrainingComplete != null)
                    this.OnTrainingComplete.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

    }
}
