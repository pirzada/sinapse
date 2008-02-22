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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

using AForge.Neuro;
using Sinapse.Data.Structures;


namespace Sinapse.Data.Network
{

    [Serializable]
    internal sealed class NetworkSavepoint
    {

        private MemoryStream m_memoryStream;
        private TrainingStatus m_networkStatus;
        private DateTime m_creationTime;


        //---------------------------------------------


        #region Constructor
        internal NetworkSavepoint(ActivationNetwork activationNetwork, TrainingStatus networkStatus)
        {
            this.m_memoryStream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(m_memoryStream, activationNetwork);
            this.m_memoryStream.Seek(0, SeekOrigin.Begin);
            
            this.m_networkStatus = networkStatus;
            this.m_creationTime = DateTime.Now;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal ActivationNetwork ActivationNetwork
        {
            get
            {
                BinaryFormatter bf = new BinaryFormatter();
                ActivationNetwork network = bf.Deserialize(m_memoryStream) as ActivationNetwork;
                return network;
            }
        }

        internal TrainingStatus NetworkStatus
        {
            get { return this.m_networkStatus; }
            set { this.m_networkStatus = value; }
        }

        public DateTime CreationTime
        {
            get { return this.m_creationTime; }
        }
   
        public int Epoch
        {
            get { return this.NetworkStatus.Epoch; }
        }

        public double ErrorTraining
        {
            get { return this.NetworkStatus.ErrorTraining; }
        }

        public double ErrorValidation
        {
            get { return this.NetworkStatus.ErrorValidation; }
        }
     
        #endregion


        //---------------------------------------------


        #region Private Methods
        #endregion


    }

    
 
    [Serializable]
    internal sealed class NetworkSavepointCollection : BindingList<NetworkSavepoint>
    {

        private NetworkSavepoint m_currentSavepoint;
        private NetworkContainer m_networkContainer;

   //     [NonSerialized]
   //     public EventHandler CurrentSavepointChanged;

        [NonSerialized]
        public EventHandler SavepointRegistered;

        [NonSerialized]
        public EventHandler SavepointRestored;

        //---------------------------------------------


        #region Constructor
        internal NetworkSavepointCollection(NetworkContainer networkContainer)
        {
            this.m_networkContainer = networkContainer;
            this.m_currentSavepoint = null;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public NetworkSavepoint CurrentSavepoint
        {
            get { return this.m_currentSavepoint; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void Restore(NetworkSavepoint networkSavepoint)
        {
            this.m_currentSavepoint = networkSavepoint;

   //         this.OnCurrentSavepointChanged();
            this.OnSavepointRestored();
        }

        public void Register(TrainingStatus trainingStatus)
        {
            this.m_currentSavepoint = new NetworkSavepoint(m_networkContainer.ActivationNetwork, trainingStatus);
            this.Add(m_currentSavepoint);

   //         this.OnCurrentSavepointChanged();
            this.OnSavepointRegistered();
        }
        #endregion


        //---------------------------------------------


    /*    private void OnCurrentSavepointChanged()
        {
            if (this.CurrentSavepointChanged != null)
                this.CurrentSavepointChanged.Invoke(this, EventArgs.Empty);
        }
    */
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
    }
  
     
}
