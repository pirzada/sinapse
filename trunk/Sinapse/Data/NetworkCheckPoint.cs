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

using AForge.Neuro;

namespace Sinapse.Data
{

    [Serializable]
    internal sealed class NetworkCheckPoint
    {

        private ActivationNetwork m_activationNetwork;
        private TrainingStatus m_networkStatus;
        private DateTime m_creationTime;


        //---------------------------------------------


        #region Constructor
        internal NetworkCheckPoint(ActivationNetwork activationNetwork, TrainingStatus networkStatus)
        {
            this.m_activationNetwork = activationNetwork;
            this.m_networkStatus = networkStatus;
            this.m_creationTime = DateTime.Now;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal ActivationNetwork ActivationNetwork
        {
            get { return this.m_activationNetwork; }
            set { this.m_activationNetwork = value; }
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
        #endregion


    }

    /*
 
    [Serializable]
    internal sealed class NetworkCheckPointCollection : ICollection<NetworkCheckPoint>, IList<NetworkCheckPoint>
    {
        internal NetworkCheckPointCollection()
        {
        }
    }
  
    */ 
}
