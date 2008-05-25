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
using AForge;

namespace Sinapse.Core.Sources
{

    [Serializable]
    public class NetworkTableSource : NetworkDataSourceBase
    {
        
        private DataTable m_baseDataTable;
        private NetworkTableColumnCollection m_columns;

        //----------------------------------------

        #region Constructor
        public NetworkTableSource(DataTable dataTable)
        {
            this.m_baseDataTable = dataTable;
            this.m_columns = new NetworkTableColumnCollection(dataTable);
        }
        #endregion

        //----------------------------------------

        #region Properties
        public NetworkTableColumnCollection Columns
        {
            get { return this.m_columns; }
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

        public enum ColumnRole { NotUsed=0, Input=1, Output=1 };
        public enum ColumnData { Nummeric, Categoric, Boolean, Time };

        private string m_columnName;
        private string m_columnCaption;
        private DataColumn m_relatedDataColumn;
        private ColumnRole m_columnRole;
        private Hashtable m_categoryMap;
        private DoubleRange m_dataRange;


        // --------------------------------------

        #region Constructor
        public NetworkTableColumn(string name, string header, ColumnRole role, DataColumn relatedColumn)
        {
            this.m_relatedDataColumn = relatedColumn;

            this.m_columnName = name;
            this.m_columnCaption = header;
            this.m_columnRole = role;

            this.m_categoryMap = new Hashtable();
        }

        public NetworkTableColumn(DataColumn relatedColumn)
        {
            this.m_relatedDataColumn = relatedColumn;
            this.m_columnName = relatedColumn.ColumnName;
            this.m_columnCaption = relatedColumn.Caption;

            this.m_categoryMap = new Hashtable();
        }
        #endregion

        // --------------------------------------

        #region Properties
        public string Name
        {
            get { return this.m_columnName; }
            set { this.m_columnName = value; }
        }

        public string Header
        {
            get { return this.m_columnCaption; }
            set { this.m_columnCaption = value; }
        }

        public ColumnRole Role
        {
            get { return this.m_columnRole; }
            set { this.m_columnRole = value; }
        }

        public DataColumn TableColumn
        {
            get { return this.m_relatedDataColumn; }
        }
        #endregion

        // --------------------------------------

    }

    [Serializable]
    public sealed class NetworkTableColumnCollection : System.ComponentModel.BindingList<NetworkTableColumn>
    {
        //TODO: Evaluate changing to ReadOnlyCollection or similar

        #region Constructor
        internal NetworkTableColumnCollection()
        {

        }

        internal NetworkTableColumnCollection(DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                this.Add(column); 
            }
        }
        #endregion

        // --------------------------------------

        #region Properties

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

        public void Add(DataColumn col)
        {
            this.Add(new NetworkTableColumn(col));
        }
        #endregion

        // --------------------------------------

        #region Private Methods
        #endregion

    }

}
