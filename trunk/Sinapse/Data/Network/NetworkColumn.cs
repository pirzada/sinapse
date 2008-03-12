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
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Text;

using AForge;

namespace Sinapse.Data.Network
{

    //TODO: Make real use of this class.
    internal enum NetworkColumnRole { None, Input, Output };

    [Serializable]
    internal sealed class NetworkColumn
    {

        private string name;
        private string header;
        private bool category;
        private NetworkColumnRole columnRole;
        private Hashtable categoryTable;
        private DoubleRange range;


        // --------------------------------------


        #region Constructor
        public NetworkColumn(string name, string header, bool category, NetworkColumnRole role)
        {
            this.name = name;
            this.header = header;
            this.category = category;
            this.columnRole = role;

            this.categoryTable = new Hashtable();
        }
        #endregion


        // --------------------------------------


        #region Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Header
        {
            get { return this.header; }
            set { this.header = value; }
        }
        public bool Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        public NetworkColumnRole ColumnRole
        {
            get { return this.columnRole; }
            set { this.columnRole = value; }
        }

        public DoubleRange Range
        {
            get { return this.range; }
            set { this.range = value; }
        }

        #endregion


        // --------------------------------------

    }

    [Serializable]
    internal sealed class NetworkColumnCollection : BindingList<NetworkColumn>
    {


        #region Constructor
        public NetworkColumnCollection()
        {

        }
        #endregion


        // --------------------------------------


        #region Public Methods
        public NetworkColumn[] Select(NetworkColumnRole columnRole)
        {
            List<NetworkColumn> search = new List<NetworkColumn>(this.Count);

            foreach (NetworkColumn col in this)
            {
                if (col.ColumnRole == columnRole)
                    search.Add(col);
            }

            return search.ToArray();
        }
        #endregion


        // --------------------------------------


        #region Private Methods
        #endregion

    }
}
