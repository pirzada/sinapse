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
using System.Collections.Generic;
using System.Text;
using System.IO;

using Sinapse.Data;
using Sinapse.Data.Reporting;


namespace Sinapse.Data.Network
{

    [Serializable]
    internal sealed class NetworkWorkplace
    {

        private List<WorkplaceEntry> m_entryList;


        #region Constructor
        internal NetworkWorkplace()
        {
        }
        #endregion


    }

    internal sealed class WorkplaceEntry
    {

        private NetworkContainer m_networkContainer;
        private NetworkPerformance m_networkPerformance;
        private NetworkDatabase m_networkDatabase;
        
        public WorkplaceEntry()
        {

        }
    }

}
