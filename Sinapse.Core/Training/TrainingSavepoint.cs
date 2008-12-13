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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

using AForge.Neuro;

using Sinapse.Core;
using Sinapse.Core.Systems;


namespace Sinapse.Core.Training
{
    /// <summary>
    /// A Savepoint stores the Network state during a Training Session.
    /// </summary>
    [Serializable]
    public sealed class TrainingSavepoint
    {

        private MemoryStream memoryStream;
        private TrainingStatus networkStatus;
        private DateTime creationTime;


        //---------------------------------------------


        #region Constructor
        public TrainingSavepoint(Network network, TrainingStatus networkStatus)
        {
            this.memoryStream = new MemoryStream();

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memoryStream, network);
            this.memoryStream.Seek(0, SeekOrigin.Begin);

            this.networkStatus = networkStatus;
            this.creationTime = DateTime.Now;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public Network Network
        {
            get
            {
                BinaryFormatter bf = new BinaryFormatter();
                memoryStream.Seek(0, SeekOrigin.Begin);
                ActivationNetwork network = bf.Deserialize(memoryStream) as ActivationNetwork;
                return network;
            }
        }

        public TrainingStatus NetworkStatus
        {
            get { return this.networkStatus; }
            set { this.networkStatus = value; }
        }

        public DateTime CreationTime
        {
            get { return this.creationTime; }
        }

        #endregion


        //---------------------------------------------


        #region Private Methods
        #endregion


    }



    [Serializable]
    internal sealed class TrainingSavepointCollection : System.ComponentModel.BindingList<TrainingSavepoint>
    {

        private TrainingSavepoint m_currentSavepoint;
        private ActivationNetworkSystem m_networkContainer;

        [NonSerialized]
        public EventHandler CurrentChanged;

        [NonSerialized]
        public EventHandler SavepointRegistered;

        [NonSerialized]
        public EventHandler SavepointRestored;


        //---------------------------------------------


        #region Constructor
        public TrainingSavepointCollection(ActivationNetworkSystem networkContainer)
        {
            this.m_networkContainer = networkContainer;
            this.m_currentSavepoint = null;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public TrainingSavepoint Current
        {
            get { return this.m_currentSavepoint; }
        }

        public TrainingSavepoint Optimal
        {
            get
            {
                TrainingSavepoint bestSavepoint = null;

                foreach (TrainingSavepoint sp in this)
                {
                    if (bestSavepoint == null /*|| sp.ErrorValidation <= bestSavepoint.ErrorValidation*/)
                        bestSavepoint = sp;
                }

                return bestSavepoint;
            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void Restore(TrainingSavepoint networkSavepoint)
        {
            this.m_currentSavepoint = networkSavepoint;

            this.OnCurrentSavepointChanged();
            this.OnSavepointRestored();
        }

        public void Add(TrainingStatus trainingStatus)
        {
            this.m_currentSavepoint = new TrainingSavepoint(m_networkContainer.Network, trainingStatus);
            this.Add(m_currentSavepoint);

            this.OnCurrentSavepointChanged();
            this.OnSavepointRegistered();
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void OnCurrentSavepointChanged()
        {
            if (this.CurrentChanged != null)
                this.CurrentChanged.Invoke(this, EventArgs.Empty);
        }

        private void OnSavepointRegistered()
        {
            if (this.SavepointRegistered != null)
                this.SavepointRegistered.Invoke(this, EventArgs.Empty);
        }

        private void OnSavepointRestored()
        {
            if (this.SavepointRestored != null)
                this.SavepointRestored.Invoke(this, EventArgs.Empty);
        }
        #endregion


    }    

}
