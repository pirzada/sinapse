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

    /// <summary>
    /// Holds information about the training process of a neural network
    /// </summary>
    [Serializable]
    internal sealed class TrainingSession : SerializableObject<TrainingSession>
    {
        //TODO: Properly use this class.

        private NetworkDatabase networkDatabase;
        private NetworkContainer networkContainer;

        private NetworkSavepointCollection savepointCollection;
        private TrainingStatus trainingStatus;
        private TrainingOptions trainingOptions;

        private HistoryEventCollection actionHistory;

        private bool trainingPaused;

/*
        private IPointListEdit m_trainingPoints;
        private IPointListEdit m_validationPoints;
        private IPointListEdit m_savePoints;
*/

        //---------------------------------------------


        #region Constructor
        public TrainingSession(NetworkDatabase networkDatabase, NetworkContainer networkContainer)
        {
            this.networkDatabase = networkDatabase;
            this.networkContainer = networkContainer;

            this.savepointCollection = new NetworkSavepointCollection(networkContainer);
            this.actionHistory = new HistoryEventCollection();
            this.trainingStatus = new TrainingStatus();
            this.trainingPaused = false;
            
        }
        #endregion


        //---------------------------------------------


        #region Properties
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

        public TrainingStatus Status
        {
            get { return this.trainingStatus; }
        }

        public TrainingOptions Options
        {
            get { return this.trainingOptions; }
            set { this.trainingOptions = value; }
        }

        public bool IsPaused
        {
            get { return this.trainingPaused; }
        }

        public HistoryEventCollection History
        {
            get { return this.actionHistory; }
        }
        #endregion


        //---------------------------------------------

        
        #region Public Methods
        #endregion

        
        //---------------------------------------------


        #region Private Methods
        #endregion

    }

}
