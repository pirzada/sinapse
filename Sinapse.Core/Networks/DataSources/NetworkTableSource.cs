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
using System.Collections;

using AForge.Math;

namespace Sinapse.Core.Networks.DataSources
{

    [Serializable]
    public class NetworkTableSource : Base.NetworkDataSourceBase
    {
        
        private DataTable m_dataTable;
        private NetworkTableColumnCollection m_columns;


        //----------------------------------------


        #region Constructor
        public NetworkTableSource(DataTable dataTable)
        {

        }
        #endregion


        //----------------------------------------


        #region Properties
        public NetworkTableColumnCollection Columns
        {
            get { return this.m_columns; }
            set { this.m_columns = value; }
        }

        public override Matrix CreateVectors(NetworkDataSet set)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override DataView CreateDataView(NetworkDataSet set)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int InputCount
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override int OutputCount
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        #endregion


    }

    [Serializable]
    public class NetworkTableColumn
    {

        public enum ColumnRole { None, Input, Output };

        private string name;
        private string header;
        private bool isNummeric;
        private ColumnRole columnRole;
        private Hashtable categoryTable;
  //      private DoubleRange range;


        // --------------------------------------


        #region Constructor
        public NetworkTableColumn(string name, string header, bool isNummeric, ColumnRole role)
        {
            this.name = name;
            this.header = header;
            this.isNummeric = isNummeric;
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
            get { return this.isNummeric; }
            set { this.isNummeric = value; }
        }

        public ColumnRole Role
        {
            get { return this.columnRole; }
            set { this.columnRole = value; }
        }

        #endregion


        // --------------------------------------

    }

    [Serializable]
    public sealed class NetworkTableColumnCollection : System.ComponentModel.BindingList<NetworkTableColumn>
    {


        #region Constructor
        public NetworkTableColumnCollection()
        {

        }
        #endregion


        // --------------------------------------


        #region Public Methods
        public NetworkTableColumn[] Select(NetworkTableColumn.ColumnRole columnRole)
        {
            List<NetworkTableColumn> search = new List<NetworkTableColumn>(this.Count);

            foreach (NetworkTableColumn col in this)
            {
                if (col.Role == columnRole)
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
