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

using Sinapse.Core.Systems;
using Sinapse.Core.Sources;


namespace Sinapse.Core.Training
{

    public enum TrainingSet { All, Training, Testing, Validation };

    /// <summary>
    ///   Encapsulates an Asynchronous and Thread-Safe way to train Backpropagation Networks
    ///   using crossvalidation and other advanced techniques. Also provides additional feedback
    ///   about current traning status.
    /// </summary>
    public class BackpropagationTrainingSession : TrainingSession, ISerializableObject<BackpropagationTrainingSession>
    {

        public enum SessionState { Stopped, Paused, Running, Error };

        //----------------------------------------

        private SerializableObject<BackpropagationTrainingSession> serializableObject;




        private ActivationNetwork activationNetwork;
        private TrainingStatus status;
        private TrainingOptions options;

        private BindingList<TrainingSavepoint> savepoints;

        public event EventHandler StatusChanged;


      



        public BackpropagationTrainingSession()
        {
            this.options = new TrainingOptions();
        }

        public BackpropagationTrainingSession(TrainingOptions options)
        {
            this.options = options;
        }



      


        #region Properties
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
            History.Add("Training Started", "Training session started with the following options");

            object trainingData = DataSource.GetData(Core.Sources.DataSource.Set.Training);
            double[][] inputData = (double[][])AdaptiveSystem.Preprocess.Apply(trainingData);
            
            
        }

        public void Start(TrainingOptions options)
        {
            options = options;

            Start();
        }

        public override void Stop()
        {
        }

        public override void Pause()
        {
        }

        public override void Reset()
        {
            this.status.Reset();
            this.activationNetwork.Randomize();
        }

        public void Goto(TrainingSavepoint savepoint)
        {

        }
        #endregion


     


        #region Protected Methods
        protected void OnStatusChanged()
        {
            if (this.StatusChanged != null)
                this.StatusChanged.Invoke(this, EventArgs.Empty);
        }

        protected override void OnAdaptiveSystemChanged()
        {
            base.OnAdaptiveSystemChanged();
            activationNetwork = (AdaptiveSystem as ActivationNetworkSystem).Network;
        }
        #endregion






        #region ISerializableObject<TrainingSession> Members


        public string Name
        {
            get { return serializableObject.Name; }
            set { serializableObject.Name = value; }
        }


        public string Description
        {
            get { return serializableObject.Description; }
            set { serializableObject.Description = value; }
        }


        public string Location
        {
            get { return serializableObject.Location; }
            set { serializableObject.Location = value; }
        }


        public string Remarks
        {
            get { return serializableObject.Remarks; }
            set { serializableObject.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return serializableObject.HasChanges; }
            set { serializableObject.HasChanges = value; }
        }

        public bool Save(string path)
        {
            return serializableObject.Save(path);
        }

        public bool Save()
        {
            return serializableObject.Save();
        }

        public static BackpropagationTrainingSession Open(string path)
        {
            return SerializableObject<BackpropagationTrainingSession>.Open(path);
        }


        #endregion
   

    }


}
