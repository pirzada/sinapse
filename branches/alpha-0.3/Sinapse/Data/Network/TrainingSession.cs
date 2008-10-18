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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Data;
using System.IO;

using ZedGraph;

using Sinapse.Data;
using Sinapse.Data.Logging;
using Sinapse.Data.Reporting;
using Sinapse.Data.Structures;


namespace Sinapse.Data.Network
{

    internal enum TrainingState { Stopped, Paused, Running }

    /// <summary>
    /// Holds information about the training process of a neural network
    /// </summary>
    [Serializable]
    internal sealed class TrainingSession : SerializableObject<TrainingSession>
    {
        //TODO: Properly use this class.

        private String name;
        private String description;

        private String networkDatabasePath;
        private String networkContainerPath;

        private NetworkSavepointCollection savepointCollection;
        private TrainingStatus networkState;
        private TrainingOptions trainingOptions;
        private TrainingState trainingState;

        private HistoryEventCollection actionHistory;

        private IPointListEdit listTrainingPoints;
        private IPointListEdit listValidationPoints;
        private IPointListEdit listCurrentSavepoint;
        private IPointListEdit listSavepoints;


        [NonSerialized]
        private NetworkDatabase networkDatabase;

        [NonSerialized]
        private NetworkContainer networkContainer;

        //---------------------------------------------


        #region Constructor
        public TrainingSession(string name, NetworkDatabase networkDatabase, NetworkContainer networkContainer)
        {
            this.name = name;

            this.networkDatabase = networkDatabase;
            this.networkContainer = networkContainer;

            this.networkContainerPath = String.Empty;
            this.networkDatabasePath = String.Empty;

            this.savepointCollection = new NetworkSavepointCollection(networkContainer);
            this.actionHistory = new HistoryEventCollection();
            this.networkState = new TrainingStatus();
            this.trainingState = TrainingState.Stopped;

            this.networkDatabase.ObjectSaved += networkDatabase_ObjectSaved;
            this.networkContainer.ObjectSaved += networkContainer_ObjectSaved;

            this.savepointCollection.CurrentSavepointChanged += savepointCollection_CurrentSavepointChanged;
            this.savepointCollection.SavepointRegistered += savepointCollection_SavepointRegistered;
            this.savepointCollection.SavepointRestored += savepointCollection_SavepointRestored;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public String DatabasePath
        {
            get { return this.networkDatabasePath; }
            set { this.networkDatabasePath = value; }
        }

        public String NetworkPath
        {
            get { return this.networkContainerPath; }
            set { this.networkContainerPath = value; }
        }

        public NetworkDatabase Database
        {
            get { return this.networkDatabase; }
        }

        public NetworkContainer Network
        {
            get { return this.networkContainer; }
        }

        public NetworkSavepointCollection NetworkSavepoints
        {
            get { return this.savepointCollection; }
        }

        public TrainingState Status
        {
            get { return this.trainingState; }
        }

        public TrainingStatus NetworkState
        {
            get { return this.networkState; }
            set { this.networkState = value; }
        }

        public TrainingOptions Options
        {
            get { return this.trainingOptions; }
            set { this.trainingOptions = value; }
        }

        public HistoryEventCollection History
        {
            get { return this.actionHistory; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void ResetStatus()
        {
            this.networkState = new TrainingStatus();
        }

        public NetworkDatabase OpenDatabase()
        {
            return NetworkDatabase.Deserialize(networkDatabasePath);
        }

        public NetworkContainer OpenNetwork()
        {
            return NetworkContainer.Deserialize(networkContainerPath);
        }

        public void ReloadNetwork()
        {
            this.networkContainer = OpenNetwork();
        }

        public void ReloadDatabase()
        {
            this.networkDatabase = OpenDatabase();
        }

        public void ReloadAll()
        {
            this.ReloadDatabase();
            this.ReloadNetwork();
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        protected override void OnObjectSaved(FileSystemEventArgs e)
        {
            base.OnObjectSaved(e);
            
            this.networkDatabasePath = Sinapse.Utils.Misc.GetRelativePath(this.LastSavePath, e.FullPath);
            this.networkContainerPath = Sinapse.Utils.Misc.GetRelativePath(this.LastSavePath, e.FullPath);
        }

        protected override void OnObjectOpened()
        {
            base.OnObjectOpened();

            //this.ReloadAll();
        }

        private void networkDatabase_ObjectSaved(object sender, FileSystemEventArgs e)
        {
            this.networkDatabasePath = Sinapse.Utils.Misc.GetRelativePath(this.LastSavePath, e.FullPath);
        }

        private void networkContainer_ObjectSaved(object sender, FileSystemEventArgs e)
        {
            this.networkContainerPath = Sinapse.Utils.Misc.GetRelativePath(this.LastSavePath, e.FullPath);
        }

        private void savepointCollection_CurrentSavepointChanged(object sender, EventArgs e)
        {
        }

        private void savepointCollection_SavepointRegistered(object sender, EventArgs e)
        {
            this.actionHistory.Add("Savepoint marked",
                String.Format("Saved epoch was {0}, training error was {1}, validation error was {2}",
                this.networkState.Epoch, this.networkState.ErrorTraining, this.networkState.ErrorValidation));

        }

        private void savepointCollection_SavepointRestored(object sender, EventArgs e)
        {
            this.actionHistory.Add("Savepoint restored",
                String.Format("Current epoch is now {0}, training error is {1}, validation error is {2}",
                this.networkState.Epoch, this.networkState.ErrorTraining, this.networkState.ErrorValidation));

        }
        #endregion


    }
}
