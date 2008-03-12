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
//using Sinapse.Data.Reporting;


namespace Sinapse.Data.Network
{


    [Serializable]
    internal sealed class NetworkWorkplace : SerializableObject<NetworkWorkplace>
    {

        private TrainingSessionCollection m_trainingSessions;


        //----------------------------------------


        #region Constructor
        internal NetworkWorkplace()
        {
            this.m_trainingSessions = new TrainingSessionCollection();
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        #endregion


        //----------------------------------------


        #region Private Methods
        #endregion


    }

    [Serializable]
    internal sealed class TrainingSessionCollection : BindingList<NetworkTrainingSession>
    {
    }

}
