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
    /// <summary>
    /// The Workplace is a collection of Network Systems, Data Sources and Training Sessions currently hosted in a usage session of the program.
    /// </summary>
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


        private SerializableObject<Workplace> serializableObject;


        private BindingList<AdaptiveSystem> adaptiveSystems;
        private BindingList<DataSource> dataSources;
        private BindingList<TrainingSession> trainingSessions;
       

        //List<NetworkReports> m_reports;

        public Workplace()
        {
            serializableObject = new SerializableObject<Workplace>();

            dataSources = new BindingList<DataSource>();
            adaptiveSystems = new BindingList<AdaptiveSystem>();
            trainingSessions = new BindingList<TrainingSession>();
        }


        #region Properties
        public BindingList<AdaptiveSystem> AdaptiveSystems
        {
            get { return adaptiveSystems; }
        }
        public BindingList<DataSource> DataSources
        {
            get { return dataSources; }
        }

        public BindingList<TrainingSession> TrainingSessions
        {
            get { return trainingSessions; }
        }

        public String Name
        {
            get { return serializableObject.Name; }
            set { serializableObject.Name = value; }
        }
        public String Description
        {
            get { return serializableObject.Description; }
            set { serializableObject.Description = value; }
        }
        #endregion
    }

    public interface WorkplaceContent
    {
    }
}
