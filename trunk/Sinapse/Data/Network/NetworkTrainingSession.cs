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

using Sinapse.Data;
using Sinapse.Data.Reporting;
using Sinapse.Data.Structures;


namespace Sinapse.Data.Network
{

    [Serializable]
    internal sealed class NetworkTrainingSession : SerializableObject<NetworkTrainingSession>
    {


        private NetworkDatabase m_networkDatabase;
        private NetworkContainer m_networkContainer;

        private NetworkSavepointCollection m_savepointCollection;

        //    private TrainingStatus m_trainingStatus;


        //---------------------------------------------


        #region Constructor
        public NetworkTrainingSession(NetworkDatabase networkDatabase, NetworkContainer networkContainer)
        {
            this.m_networkDatabase = networkDatabase;
            this.m_networkContainer = networkContainer;

            this.m_savepointCollection = new NetworkSavepointCollection(networkContainer);
            //this.m_trainingStatus = new TrainingStatus();

        }
        #endregion


        //---------------------------------------------


        #region Properties
        public NetworkDatabase Database
        {
            get { return this.m_networkDatabase; }
        }

        public NetworkContainer Network
        {
            get { return this.m_networkContainer; }
        }

        public NetworkSavepointCollection NetworkSavepoints
        {
            get { return this.m_savepointCollection; }
        }
        #endregion

    }
}
