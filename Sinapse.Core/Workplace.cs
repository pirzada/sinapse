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
using System.IO;

using Sinapse.Core.Systems;
using Sinapse.Core.Sources;
using Sinapse.Core.Training;

namespace Sinapse.Core
{
    /// <summary>
    ///   The Workplace is a collection of Network Systems, Data Sources and
    ///   Training Sessions currently hosted in a usage session of the program.
    /// </summary>
    [Serializable]
    public class Workplace : ISerializableObject<Workplace>, ISinapseDocument
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
                    {
                        // We are trying to close the Active Workplace
                        CancelEventArgs e = new CancelEventArgs();
                        active.OnClosing(e);

                        if (e.Cancel == true) return; // Cancelled
                    }

                    active = value;

                    if (ActiveWorkplaceChanged != null)
                        ActiveWorkplaceChanged.Invoke(value, EventArgs.Empty);

                }
            }
        }

        public static event EventHandler ActiveWorkplaceChanged;
        #endregion

        private DirectoryInfo root;

        private SinapseDocumentInfoCollection documents;



        [field: NonSerialized]
        public event CancelEventHandler Closing;




        public Workplace(string name, FileInfo info)
        {
            
            // Initialize simulated multiple-inheritance helpers
            serializableObject = new SerializableObject<Workplace>(this);
            sinapseDocument = new SinapseDocument(name, info);

            documents = new SinapseDocumentInfoCollection(this);

            documents.ListChanged += new ListChangedEventHandler(workplaceItemsListChanged);
        }



        public SinapseDocumentInfoCollection Documents
        {
            get { return documents; }
        }

        public DirectoryInfo Root
        {
            get { return this.root; }
        }



        void workplaceItemsListChanged(object sender, ListChangedEventArgs e)
        {
            HasChanges = true;
        }

        protected void OnClosing(CancelEventArgs e)
        {
            if (Closing != null)
                Closing.Invoke(this, e);
        }






        #region SerializableObject Members
        private SerializableObject<Workplace> serializableObject;

 
        public bool Save(string path)
        {
            return serializableObject.Save(path);
        }

        public bool Save()
        {
            return serializableObject.Save(sinapseDocument.File.FullName);
        }

        public static Workplace Open(string path)
        {
            return SerializableObject<Workplace>.Open(path);
        }

        public event EventHandler FileSaved
        {
            add { serializableObject.FileSaved += value; }
            remove { serializableObject.FileSaved -= value; }
        }
        #endregion



        #region ISinapseDocument Members
        private SinapseDocument sinapseDocument;

        string ISinapseDocument.Name
        {
            get { return sinapseDocument.Name; }
            set { sinapseDocument.Name = value; }
        }

        string ISinapseDocument.Description
        {
            get { return sinapseDocument.Description; }
            set { sinapseDocument.Description = value; }
        }

        string ISinapseDocument.Remarks
        {
            get { return sinapseDocument.Remarks; }
            set { sinapseDocument.Remarks = value; }
        }

        FileInfo ISinapseDocument.File
        {
            get { throw new NotImplementedException(); }
        }

        bool HasChanges
        {
            get { throw new NotImplementedException(); }
        }

        event EventHandler Changed
        {
            add { sinapseDocument.Changed += value; }
            remove { sinapseDocument.Changed -= value; }
        }

        #endregion
    }


}
