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
    [Serializable]
    public class Workplace : ISerializableObject<Workplace>
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

        private BindingList<WorkplaceContent> adaptiveSystems;
        private BindingList<WorkplaceContent> dataSources;
        private BindingList<WorkplaceContent> trainingSessions;


        public Workplace(string name, string location)
            : this()
        {
            serializableObject.FilePath = location;
            serializableObject.FileName = name + "." + DefaultExtension;
            serializableObject.Name = name;
        }

        public Workplace()
        {
            serializableObject = new SerializableObject<Workplace>(this);

            dataSources      = new BindingList<WorkplaceContent>();
            adaptiveSystems  = new BindingList<WorkplaceContent>();
            trainingSessions = new BindingList<WorkplaceContent>();
        }



        #region Properties
        public BindingList<WorkplaceContent> AdaptiveSystems
        {
            get { return adaptiveSystems; }
        }
        public BindingList<WorkplaceContent> DataSources
        {
            get { return dataSources; }
        }

        public BindingList<WorkplaceContent> TrainingSessions
        {
            get { return trainingSessions; }
        }
        #endregion



        #region SerializableObject Members

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

        public string Remarks
        {
            get { return serializableObject.Remarks; }
            set { serializableObject.Remarks = value; }
        }



        public string FileName
        {
            get { return serializableObject.FileName; }
            set { serializableObject.FileName = value; }
        }

        public string FilePath
        {
            get { return serializableObject.FilePath; }
            set { serializableObject.FilePath = value; }
        }

        public string DefaultExtension
        {
            get { return "swp"; }
        }

        public bool HasChanges
        {
            get { return serializableObject.HasChanges; }
            set { serializableObject.HasChanges = value; }
        }



        public string FullPath
        {
            get { return serializableObject.FullPath; }
        }


        public bool Save(string path)
        {
            return serializableObject.Save(path);
        }

        public bool Save()
        {
            return serializableObject.Save();
        }

        public static Workplace Open(string path)
        {
            return SerializableObject<Workplace>.Open(path);
        }
        #endregion


    }


}
