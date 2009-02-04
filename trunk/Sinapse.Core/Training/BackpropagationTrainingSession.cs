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
using System.Text;
using System.ComponentModel;

using AForge.Neuro;
using AForge.Neuro.Learning;

using Sinapse.Core.Documents;
using Sinapse.Core.Systems;
using Sinapse.Core.Sources;


namespace Sinapse.Core.Training
{


    /// <summary>
    ///   Encapsulates an Asynchronous and Thread-Safe way to train Backpropagation Networks
    ///   using crossvalidation and other advanced techniques. Also provides additional feedback
    ///   about current traning status.
    /// </summary>
    [Serializable]
    [DocumentDescription("Backpropagation Training Session",
        DefaultName = "trainingSession",
        Description = "Teaches a Source to an Activation Network using Backpropagation",
        Extension = ".session.bpp",
        IconPath = "Resources/Session.ico")]
    public class BackpropagationTrainingSession : TrainingSession, ISinapseDocument
    {

        private SerializableObject<BackpropagationTrainingSession> serializableObject;


        private ActivationNetwork activationNetwork;
        private TrainingStatus status;
        private TrainingOptions options;
        private BackgroundWorker backgroundWorker;
        private SessionState state = SessionState.Stopped;

        private BindingList<TrainingSavepoint> savepoints;

        public event EventHandler StatusChanged;




        public BackpropagationTrainingSession()
            : this(new TrainingOptions())
        {
        }

        public BackpropagationTrainingSession(TrainingOptions options)
        {
            this.options = options;

            this.backgroundWorker.DoWork += backgroundWorker_DoWork;
            this.backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }




        #region Properties
        public SessionState State
        {
            get { return state; }
        }

        public TrainingStatus Status
        {
            get { return status; }
        }

        public TrainingOptions Options
        {
            get { return options; }
            set { options = value; }
        }

        public BindingList<TrainingSavepoint> Savepoints
        {
            get { return savepoints; }
        }
        #endregion


     


        #region Public Methods
        public override void Start()
        {
            Start(Options);
        }

        public void Start(TrainingOptions options)
        {
            if (state == SessionState.Stopped)
            {
                History.Add("Training Starting", status, options);

                object[][] dataInput = DataSource.GetData(DataSourceSet.Training, InputOutput.Input);
                object[][] dataOutput = DataSource.GetData(DataSourceSet.Training, InputOutput.Output);

                AdaptiveSystem.Preprocess.Apply(dataInput);
                AdaptiveSystem.Postprocess.Revert(dataOutput);

                TrainingThreadParameters parameters;
                parameters.Options = this.Options.Copy();
                parameters.Inputs = convert(dataInput);
                parameters.Outputs = convert(dataOutput);


                backgroundWorker.RunWorkerAsync(parameters);
            }
            else if (state == SessionState.Paused)
            {
                History.Add("Training Resumed", status);
                state = SessionState.Running;
            }
        }

        public override void Stop()
        {
            if (state == SessionState.Running)
            {
                state = SessionState.Stopped;

                if (backgroundWorker.IsBusy)
                {
                    History.Add("Stop", status);
                    backgroundWorker.CancelAsync();
                }
            }
        }

        public override void Pause()
        {
            if (state == SessionState.Running)
            {
                state = SessionState.Paused;

                if (backgroundWorker.IsBusy)
                {
                    History.Add("Paused", status);
                    OnPaused(EventArgs.Empty);
                }
            }
        }

        public override void Reset()
        {
            status.Reset();
            activationNetwork.Randomize();
        }

        public void Goto(TrainingSavepoint savepoint)
        {

        }
        #endregion


     


        #region Protected Methods
        protected void OnStatusChanged(EventArgs e)
        {
            if (this.StatusChanged != null)
                this.StatusChanged.Invoke(this, e);
        }

        protected override void OnAdaptiveSystemChanged(EventArgs e)
        {
            base.OnAdaptiveSystemChanged(e);
            activationNetwork = (AdaptiveSystem as ActivationNetworkSystem).Network;
        }
        #endregion



        #region Worker Thread

        [Flags]
        private enum BackgroundWorkerUpdate
        {
            // TODO: Enforce the use of flags (optimize)
            //  Call ReportProgress only once every loop, by combining
            //  multiple BackgroundWorkerUpdate flags together.
            Error = 0,
            Starting = 2,
            NetworkSave = 4,
            Progress = 8,
            Completed = 16,
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            TrainingThreadParameters parameters = (TrainingThreadParameters)e.Argument;
            TrainingOptions options = parameters.Options;
            double[][] inputs = parameters.Inputs;
            double[][] outputs = parameters.Outputs;


            //Create Teacher
            BackPropagationLearning networkTeacher = new BackPropagationLearning(activationNetwork);
            networkTeacher.LearningRate = options.LearningRate1;
            networkTeacher.Momentum = options.Momentum;

            //Start Training
            bool stop = false;
            bool complete = false;
            int lastStatusEpoch = 0;
            int lastSaveEpoch = 0;
            int lastValidateEpoch = 0;

            backgroundWorker.ReportProgress(0, BackgroundWorkerUpdate.Starting);


            #region Main Training Loop

            while (!stop) 
            {
               
                // Run training epoch
                status.TrainingError = networkTeacher.RunEpoch(inputs, outputs);

                if (options.Validate && status.Epoch >= lastValidateEpoch + options.ValidateEpochs)
                    status.ValidationError = networkTeacher.MeasureEpochError(inputs, outputs);

                // Adjust Training Rate
                if (options.ChangeLearningRate)
                    networkTeacher.LearningRate = options.LearningRate2;
                


                // Register Savepoint
                if (options.MarkSavepoints &&
                    status.Epoch >= lastSaveEpoch + options.MarkSavepointsEpochs)
                {
                    backgroundWorker.ReportProgress(0, BackgroundWorkerUpdate.NetworkSave);
                    lastSaveEpoch = status.Epoch;
                }
                

                // Progress Indicator
                if (options.ReportProgress &&
                    status.Epoch >= lastStatusEpoch + options.ReportProgressEpochs)
                {
                    if (options.Limit ==  TrainingOptions.TrainingLimit.ByError)
                    {
                        if (status.TrainingError != 0) // Check to avoid division by zero
                            status.Progress = Math.Max(Math.Min((int)((options.LimitByError * 100) / status.TrainingError), 100), 0);
                    }
                    else if  (options.Limit ==  TrainingOptions.TrainingLimit.ByEpoch)
                    {
                        if (status.Epoch != 0) // Check to avoid division by zero
                            status.Progress = Math.Max(Math.Min((int)((status.Epoch * 100) / options.LimitByEpochs), 100), 0);
                    }

                    backgroundWorker.ReportProgress(0, BackgroundWorkerUpdate.Progress);
                    lastStatusEpoch = status.Epoch;
                }
                

                // Increment epoch counter
                ++status.Epoch;

                if (options.Delay)
                {
                    // Sleep thread according to specified delay
                    System.Threading.Thread.Sleep(options.DelayMilliseconds);
                }


                // Check stop conditions
                if ((options.Limit == TrainingOptions.TrainingLimit.ByError &&
                    status.TrainingError <= options.LimitByError) ||
                    (options.Limit == TrainingOptions.TrainingLimit.ByEpoch &&
                    status.Epoch >= options.LimitByEpochs))
                {
                    complete = true;
                    stop = true;
                }

                // Check for cancellation requests
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    stop = true;
                }
                while (state == SessionState.Paused)
                {
                    System.Threading.Thread.Sleep(1000);
                }


            } // End main training loop
            #endregion


            // Do a last update before exiting the thread
            if (complete) backgroundWorker.ReportProgress(0, BackgroundWorkerUpdate.Completed);
            else backgroundWorker.ReportProgress(0, BackgroundWorkerUpdate.Progress);
        }



        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            BackgroundWorkerUpdate updateType = (BackgroundWorkerUpdate)e.UserState;


            switch (updateType)
            {

                case BackgroundWorkerUpdate.NetworkSave:

                    Savepoints.Add(new TrainingSavepoint(activationNetwork, status));
 /*                   if ()
                    {
                        this.Savepoints.Save(...);
                        lastSavepointCompressionEpoch = options.EnableSavepointCompression;
                    }
  */ 
                    break;


                case BackgroundWorkerUpdate.Progress:
                    OnStatusChanged(EventArgs.Empty);
                    break;

                case BackgroundWorkerUpdate.Starting:
                    History.Add("Training Started", status);
                    break;

                case BackgroundWorkerUpdate.Error:
                    
                    break;

                case BackgroundWorkerUpdate.Completed:
                    OnStatusChanged(EventArgs.Empty);
                    OnCompleted(EventArgs.Empty);
                    break;

                default:
                    break;

            }
        }



        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw e.Error;
        }
#endregion



        


        #region ISerializableObject<TrainingSession> Members

        public bool Save(string path)
        {
            bool success = serializableObject.Save(path);
            if (success) this.HasChanges = false;
            return success;
        }

        public bool Save()
        {
            bool success = serializableObject.Save(File.FullName);
            if (success) this.HasChanges = false;
            return success;
        }

        public static BackpropagationTrainingSession Open(string path)
        {
            BackpropagationTrainingSession doc = SerializableObject<BackpropagationTrainingSession>.Open(path);
            doc.File = new System.IO.FileInfo(path);
            return doc;
        }

        public event EventHandler FileSaved
        {
            add { serializableObject.FileSaved += value; }
            remove { serializableObject.FileSaved -= value; }
        }
        #endregion





        #region ISinapseDocument Members
        private SinapseDocument sinapseDocument;

        public string Name
        {
            get { return sinapseDocument.Name; }
            set { sinapseDocument.Name = value; }
        }

        public string Description
        {
            get { return sinapseDocument.Description; }
            set { sinapseDocument.Description = value; }
        }

        public string Remarks
        {
            get { return sinapseDocument.Remarks; }
            set { sinapseDocument.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return sinapseDocument.HasChanges; }
            protected set { sinapseDocument.HasChanges = value; }
        }

        public System.IO.FileInfo File
        {
            get { return sinapseDocument.File; }
            set { sinapseDocument.File = value; }
        }

        public Workplace Owner
        {
            get { return sinapseDocument.Owner; }
            set { sinapseDocument.Owner = value; }
        }

        public event EventHandler SavepathChanged
        {
            add { sinapseDocument.SavepathChanged += value; }
            remove { sinapseDocument.SavepathChanged -= value; }
        }

        public event EventHandler ContentChanged
        {
            add { sinapseDocument.ContentChanged += value; }
            remove { sinapseDocument.ContentChanged -= value; }
        }
        #endregion



        private double[][] convert(object[][] x)
        {
            double[][] r = new double[x.Length][];
            for (int i = 0; i < x.Length; i++)
            {
                r[i] = new double[x[i].Length];
                for (int j = 0; j < r[i].Length; j++)
                {
                    r[i][j] = (double)x[i][j];
                }
            }
            return r;
        }

    }


}
