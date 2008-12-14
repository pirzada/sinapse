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
using System.Runtime.Serialization;

using Sinapse.Core.Systems;
using Sinapse.Core.Sources;
using Sinapse.Core.Training;

namespace Sinapse.Core
{
    /// <summary>
    /// The Workplace is a collection of Network Systems, Data Sources and Training Sessions currently hosted in a usage session of the program.
    /// </summary>
    [Serializable]
    public class Workplace : ISerializableObject<Workplace>, ISinapseComponent
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
                    if (value == null)
                        active.OnClosing(EventArgs.Empty);

                    active = value;

                    if (value == null)
                        active.OnClosed(EventArgs.Empty);

                    if (ActiveWorkplaceChanged != null)
                        ActiveWorkplaceChanged.Invoke(value, EventArgs.Empty);

                }
            }
        }

        public static event EventHandler ActiveWorkplaceChanged;
        #endregion



        private SerializableObject<Workplace> serializableObject;
        private SinapseComponent workplaceComponent;

        private WorkplaceItemCollection adaptiveSystems;
        private WorkplaceItemCollection dataSources;
        private WorkplaceItemCollection trainingSessions;


        [field: NonSerialized]
        public event EventHandler Changed;

        [field: NonSerialized]
        public event EventHandler Closed;

        [field: NonSerialized]
        public event EventHandler Closing;



        public Workplace(string name, string location)
            : this()
        {
            serializableObject.FilePath = location;
            serializableObject.FileName = name + "." + DefaultExtension;
            workplaceComponent.Name = name;
        }

        public Workplace()
        {
            // Initialize simulated multiple-inheritance helpers
            serializableObject = new SerializableObject<Workplace>(this);
            workplaceComponent = new SinapseComponent();

            dataSources = new WorkplaceItemCollection(this);
            adaptiveSystems = new WorkplaceItemCollection(this);
            trainingSessions = new WorkplaceItemCollection(this);

            dataSources.ListChanged += new ListChangedEventHandler(workplaceItemsListChanged);
            adaptiveSystems.ListChanged += new ListChangedEventHandler(workplaceItemsListChanged);
            trainingSessions.ListChanged += new ListChangedEventHandler(workplaceItemsListChanged);
        }

/*
        [OnDeserialized]
        private void onDeserializing(StreamingContext context)
        {
            dataSources.Owner = this;
            adaptiveSystems.Owner = this;
            trainingSessions.Owner = this;
        }

        [OnSerializing]
        private void onSerializing(StreamingContext context)
        {
            
        }
*/


        public WorkplaceItemCollection AdaptiveSystems
        {
            get { return adaptiveSystems; }
        }
        public WorkplaceItemCollection DataSources
        {
            get { return dataSources; }
        }

        public WorkplaceItemCollection TrainingSessions
        {
            get { return trainingSessions; }
        }



        void workplaceItemsListChanged(object sender, ListChangedEventArgs e)
        {
            HasChanges = true;
        }

        protected void OnClosing(EventArgs e)
        {
            if (Closing != null)
                Closing.Invoke(this, e);
        }

        protected void OnClosed(EventArgs e)
        {
            if (Closed != null)
                Closed.Invoke(this, e);
        }


        #region IWorkplaceComponent Members

        public string Name
        {
            get { return workplaceComponent.Name; }
            set { workplaceComponent.Name = value; }
        }

        public string Description
        {
            get { return workplaceComponent.Description; }
            set { workplaceComponent.Description = value; }
        }

        public string Remarks
        {
            get { return workplaceComponent.Remarks; }
            set { workplaceComponent.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return workplaceComponent.HasChanges; }
            protected set { workplaceComponent.HasChanges = value; }
        }
        #endregion




        #region SerializableObject Members


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


        public string FullPath
        {
            get { return serializableObject.FullPath; }
        }


        public bool Save(string path)
        {
            bool success = serializableObject.Save(path);
            if (success) this.HasChanges = false;
            return success;
        }

        public bool Save()
        {
            bool success = serializableObject.Save();
            if (success) this.HasChanges = false;
            return success;
        }

        public static Workplace Open(string path)
        {
            return SerializableObject<Workplace>.Open(path);
        }

        public event EventHandler FileChanged
        {
            add { serializableObject.FileChanged += value; }
            remove { serializableObject.FileChanged -= value; }
        }
        #endregion


    }


}
