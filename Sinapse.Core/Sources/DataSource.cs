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
using System.Data;

using AForge.Mathematics;

using Sinapse.Core.Filters;
using Sinapse.Core.Systems;


namespace Sinapse.Core.Sources
{

    
    /// <summary>
    ///   This class encompass a Adaptive System DataSource, or in other words, a
    ///   source of information that can be used to train and feed Adaptive Systems.
    ///   A common example of data sources are tables of sample data or a collection
    ///   of images.
    /// </summary>
    [Serializable]
    public abstract class DataSource : IWorkplaceContent, Sinapse.Core.ISerializableObject<DataSource>
    {
        private SerializableObject<DataSource> serializableObject;

        public event EventHandler NameChanged;

        //----------------------------------------

        #region Constructor
        protected DataSource(String name)
        {
            serializableObject = new SerializableObject<DataSource>();

            serializableObject.Name = name;
        }
        #endregion

        //----------------------------------------

        #region Properties
        public String Name
        {
            get { return this.serializableObject.Name; }
            set
            {
                serializableObject.Name = value;

                if (NameChanged != null)
                    NameChanged.Invoke(this, EventArgs.Empty);
            }
        }

        public String Description
        {
            get { return serializableObject.Description; }
            set { serializableObject.Description = value; }
        }

        public String Remarks
        {
            get { return serializableObject.Remarks; }
            set { serializableObject.Remarks = value; }
        }
        #endregion

        //----------------------------------------



        #region ISerializableObject<object> Members


        public string Location
        {
            get { return serializableObject.Location; }
            set { serializableObject.Location = value; }
        }

        public bool HasChanges
        {
            get { return serializableObject.HasChanges; }
            set { serializableObject.HasChanges = value; }
        }

        public bool Save(string path)
        {
            return serializableObject.Save(path);
        }

        public bool Save()
        {
            return serializableObject.Save();
        }

        public static DataSource Open(string path)
        {
            return SerializableObject<DataSource>.Open(path);
        }

        #endregion
    }
}
