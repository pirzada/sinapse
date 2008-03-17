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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Data;
using System.IO;

using Sinapse.Data;


namespace Sinapse.Data.Network
{

    [Serializable]
    internal sealed class NetworkWorkplace : SerializableObject<NetworkWorkplace>
    {

        private String m_name;
        private String m_description;
        private DateTime m_creationTime;
        private TrainingSessionCollection m_trainingSessions;


        //----------------------------------------


        #region Constructor
        public NetworkWorkplace()
        {
            this.m_name = "New Workplace";
            this.m_description = String.Empty;
            this.m_creationTime = DateTime.Now;
            this.m_trainingSessions = new TrainingSessionCollection();
        }
        #endregion


        //----------------------------------------


        #region Properties
        public String Name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        public TrainingSessionCollection Sessions
        {
            get { return this.m_trainingSessions;    }
        }
        #endregion


        //----------------------------------------


        #region Object Events
        #endregion


        //----------------------------------------


        #region Public Methods
        #endregion


        //----------------------------------------


        #region Private Methods
        #endregion


    }

    [Serializable]
    internal sealed class TrainingSessionCollection : BindingList<TrainingSession>
    {

    }

}
