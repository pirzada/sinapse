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
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


using AForge.Neuro;

namespace Sinapse.Data
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

        internal DateTime CreationTime
        {
            get { return this.m_creationTime; }
        }
   /*
        internal int Epoch
        {
            get { return this.NetworkStatus.Epoch; }
        }

        internal double ErrorTraining
        {
            get { return this.NetworkStatus.ErrorTraining; }
        }

        internal double ValidationError
        {
            get { return this.NetworkStatus.ErrorValidation; }
        }
    */ 
        #endregion


        //---------------------------------------------


        #region Private Methods
        #endregion


    }

    
 
    [Serializable]
    internal sealed class NetworkSavepointCollection : List<NetworkSavepoint>
    {
        
        internal NetworkSavepointCollection()
        {
        }

        public void Add(ActivationNetwork network, TrainingStatus status)
        {
            this.Add(new NetworkSavepoint(network, status));
        }
        
     /*
        NetworkContainer m_networkContainer;

        internal NetworkSavepointCollection(NetworkContainer networkContainer)
        {
            this.m_networkContainer = networkContainer;
        }


     
        public void Restore(NetworkSavepoint networkSavepoint)
        {
            this.m_networkContainer.ActivationNetwork = networkSavepoint.ActivationNetwork;
            this.m_networkContainer.Precision = networkSavepoint.NetworkStatus.ErrorTraining;
        }

        public void Save(TrainingStatus trainingStatus)
        {
            this.Add(new NetworkSavepoint(m_networkContainer.ActivationNetwork, trainingStatus));
        }
      */
    }
  
     
}
