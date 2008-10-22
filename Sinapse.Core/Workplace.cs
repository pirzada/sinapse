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
using System.ComponentModel;
using System.Text;

using Sinapse.Core.Systems;
using Sinapse.Core.Sources;
using Sinapse.Core.Training;

namespace Sinapse.Core
{
    public class Workplace
    {

        #region Active Workplace Placeholder
        private static Workplace active;

        public static Workplace Active
        {
            get { return active; }
            set
            {
                if (value != active)
                {
                    active = value;

                    if (ActiveWorkplaceChanged != null)
                        ActiveWorkplaceChanged.Invoke(value, EventArgs.Empty);
                }
            }
        }

        public static event EventHandler ActiveWorkplaceChanged;
        #endregion


        private String m_name;     
        private String m_description;
        private DateTime m_creationTime;

        private BindingList<NetworkSystemBase> m_networks;
        private BindingList<DataSourceBase> m_dataSources;
        private BindingList<TrainingSession> m_trainingSessions;
       

        //List<NetworkReports> m_reports;

        public Workplace()
        {
            this.m_creationTime = DateTime.Now;
            this.m_networks = new BindingList<NetworkSystemBase>();
            this.m_dataSources = new BindingList<DataSourceBase>();
            this.m_trainingSessions = new BindingList<TrainingSession>();
        }


        #region Properties
        public BindingList<NetworkSystemBase> Systems
        {
            get { return m_networks; }
        }
        public BindingList<DataSourceBase> DataSources
        {
            get { return m_dataSources; }
        }

        public BindingList<TrainingSession> TrainingSessions
        {
            get { return m_trainingSessions; }
        }

        public String Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        public DateTime CreationTime
        {
            get { return m_creationTime; }
        }
        #endregion
    }

    public class WorkplaceContent
    {
    }
}
