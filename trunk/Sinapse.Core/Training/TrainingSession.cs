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
    ///   Encapsultates an Asynchronous and Thread-Safe way to train Backpropagation Networks
    ///   using crossvalidation and other advanced techniques. Also provides additional feedback
    ///   about current traning status.
    /// </summary>
    public class TrainingSession : WorkplaceContent, ISerializableObject<TrainingSession>
    {

        public enum SessionState { Stopped, Paused, Running, Error };

        //----------------------------------------

        private SerializableObject<TrainingSession> serializableObject;
        private DataSource dataSource;
        private ActivationNetworkSystem networkSystem;
        private string name;
        private TrainingStatus status;

        private TrainingOptions options;

        private List<Sinapse.Core.Training.TrainingSavepoint> savepoints;
        private TrainingStepCollection trainingSteps;


        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler Paused;
        public event EventHandler Completed;

        public event EventHandler StatusChanged;


        //----------------------------------------


        #region Constructors
        public TrainingSession()
        {
            
        }

        public TrainingSession(TrainingOptions options)
        {
            this.options = options;
        }
        #endregion


        //----------------------------------------


        #region Properties
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public TrainingStatus Status
        {
            get { return status; }
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        public void Start()
        {
            this.Start(null);
        }
        public void Start(TrainingOptions options)
        {
            this.options = options;

            this.trainingSteps.Add(new TrainingStep("Training Started", "Training session started with the following options"));

        }

        public void Stop()
        {
        }

        public void Pause()
        {
        }

        public void Reset()
        {
            this.status.Reset();
            this.networkSystem.Network.Randomize();
        }

        public void Goto(TrainingSavepoint savepoint)
        {

        }
        #endregion


        //----------------------------------------


        #region Protected Methods
        protected void OnStatusChanged()
        {
            if (this.StatusChanged != null)
                this.StatusChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion

        public List<TrainingSavepoint> Savepoints
        {
            get { return savepoints; }
        }

        public TrainingStepCollection Steps
        {
            get { return trainingSteps; }
        }


        #region ISerializableObject<TrainingSession> Members


        public string Description
        {
            get { return serializableObject.Description; }
            set { serializableObject.Description = value; }
        }


        public string Location
        {
            get { return serializableObject.Location; }
            protected set { serializableObject.Location = value; }
        }


        public string Remarks
        {
            get { return serializableObject.Remarks; }
            set { serializableObject.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return serializableObject.HasChanges; }
        }

        public bool Save(string path)
        {
            return serializableObject.Save(path);
        }

        public bool Save()
        {
            return serializableObject.Save();
        }

        public static TrainingSession Open(string path)
        {
            return SerializableObject<TrainingSession>.Open(path);
        }

        #endregion
    }


}
