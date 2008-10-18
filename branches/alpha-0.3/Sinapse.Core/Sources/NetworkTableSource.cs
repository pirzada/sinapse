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

using AForge.Mathematics;
using AForge;

namespace Sinapse.Core.Sources
{

    /// <summary>
    ///   This class encompass a Neural Network DataSource, or in other words, a
    ///   source of information that can be used to train and feed Neural Networks.
    ///   The source encompassed here is presented as a DataTable, which can be created
    ///   or imported from various other sources like Microsoft Excel or text files. 
    /// </summary>
    [Serializable]
    public class NetworkTableSource : NetworkDataSourceBase
    {

        private DataSet m_dataSet;
        private DataTable m_dataTable;
        private NetworkTableColumnCollection m_columns;

        //----------------------------------------

        #region Constructor
        /// <summary>Creates a new NetworkTableSource object.</summary>
        /// <param name="dataTable">A DataTable which will be deep copied into this object.</param>
        public NetworkTableSource(String title, DataTable dataTable)
            : base(title)
        {
            this.m_dataSet = new DataSet(title);
            this.m_dataTable = dataTable.Copy();
            this.m_dataSet.Tables.Add(m_dataTable);

            // For each column, create other 2 columns: columnName_networkanswer, columnName_networkdelta
            // if the column is a category, create another column columnName_index and another table
            // with the same name.

            NetworkTableColumn[] columns = new NetworkTableColumn[m_dataTable.Columns.Count];
            for (int i = 0; i < columns.Length; i++)
            {
                // User will determine the type of the data or it will be selected based on data type?
                columns[i] = new NetworkTableColumn(m_dataTable.Columns[i]); 
            }

          //  this.m_columns = new NetworkTableColumnCollection(dataTable);
        }

        public NetworkTableSource(String title, NetworkTableColumn[] columns)
            : base(title)
        {
            this.m_dataSet = new DataSet(title);
            this.m_dataTable = new DataTable();

            this.m_columns = new NetworkTableColumnCollection(columns);
        }
        #endregion

        //----------------------------------------

        #region Properties
        public NetworkTableColumnCollection Columns
        {
            get { return this.m_columns; }
        }
        #endregion

        //----------------------------------------

        #region Public Methods
        public override Matrix CreateVectors(NetworkDataSet set)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override DataView CreateDataView(NetworkDataSet set)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int InputsCount
        {
            get { return this.m_columns.Inputs.Length; }
        }

        public override int OutputsCount
        {
            get { return this.m_columns.Outputs.Length; }
        }
        #endregion

    }

    [Serializable]
    public class NetworkTableColumn
    {

        public enum ColumnRole { None, Input, Output };
        public enum ColumnData { Nummeric, Categoric, Boolean, Time };
        public enum ColumnRelevance { None, Low, Medium, High };

        private string m_columnDescription;
        private ColumnRole m_columnRole;
        private ColumnData m_columnData;
        private ColumnRelevance m_columnRelevance;

        private DataColumn m_dataColumn;
        private DataColumn m_networkAnswer;
        private DataColumn m_networkDelta;
        private DataColumn m_categoryIndex;

        private bool m_locked;

        // --------------------------------------

        #region Constructor
        public NetworkTableColumn(DataColumn relatedColumn, ColumnData data, ColumnRole role)
        {
            this.m_dataColumn = relatedColumn;

            this.m_columnData = data;
            this.m_columnRole = role;

            this.m_dataColumn.Table.Columns.Add(this.Name, typeof(double));
        }

        public NetworkTableColumn(DataColumn relatedColumn)
        {
            this.m_dataColumn = relatedColumn;

            //if (relatedColumn.DataType == typeof(String))
                //this.co
        }
        #endregion

        // --------------------------------------

        #region Properties
        public string Name
        {
            get { return this.m_dataColumn.ColumnName; }
            set { this.m_dataColumn.ColumnName = value; }
        }

        public string Caption
        {
            get { return this.m_dataColumn.Caption; }
            set { this.m_dataColumn.Caption = value; }
        }

        public string Description
        {
            get { return this.m_columnDescription; }
            set { this.m_columnDescription = value; }
        }

        public bool SchemaLocked
        {
            get { return this.m_locked; }
            internal set { this.m_locked = value; }
        }

        public ColumnRole Role
        {
            get { return this.m_columnRole; }
            set
            {
                if (!this.m_locked)
                    this.m_columnRole = value;
            }
        }

        public ColumnData Data
        {
            get { return this.m_columnData; }
            set
            {
                if (!this.m_locked)
                    this.m_columnData = value;
            }
        }

        public ColumnRelevance Relevance
        {
            get { return this.m_columnRelevance; }
            set { this.m_columnRelevance = value; }
        }

        public DataColumn DataColumn
        {
            get { return this.m_dataColumn; }
        }

        public DoubleRange DataRange
        {
            get
            {
                double max, min;
                max = (double)this.DataColumn.Table.Compute(String.Format("MAX([{0}])", this.Name), String.Empty);
                min = (double)this.DataColumn.Table.Compute(String.Format("MIN([{0}])", this.Name), String.Empty);
                return new DoubleRange(max, min);
            }
        }
        #endregion

        // --------------------------------------

        /*
        private void getCaptions()
        {
            if (this.m_columnData == ColumnData.Categoric)
            {
                
                //Extract Unique List from data:
                DataTable captions = this.m_relatedDataColumn.Table.DefaultView.ToTable(true, new string[] { this.m_relatedDataColumn.ColumnName });

                for (int i = 0; i < captions.Rows; i++)
                {
                //    this.m_categoryMap.Add(i, 
                }
            }
        }
         */ 
    }

    [Serializable]
    public sealed class NetworkTableColumnCollection :
        System.Collections.ObjectModel.ReadOnlyCollection<NetworkTableColumn>
    {

        private bool m_locked;

        // --------------------------------------

        #region Constructor
        internal NetworkTableColumnCollection(NetworkTableColumn[] columns)
            : base(columns)
        {
            m_locked = false;
        }
        #endregion

        // --------------------------------------

        #region Properties
        public bool SchemaLocked
        {
            get { return m_locked; }
            internal set
            {
                m_locked = value;

                foreach (NetworkTableColumn c in this)
                    c.SchemaLocked = value;
            }
        }

        public NetworkTableColumn this[DataColumn dataColumn]
        {
            get
            {
                foreach (NetworkTableColumn col in this)
                {
                    if (col.DataColumn == dataColumn)
                        return col;
                }
                throw new KeyNotFoundException();
            }
        }

        public NetworkTableColumn this[string columnName]
        {
            get
            {
                foreach (NetworkTableColumn col in this)
                {
                    if (col.Name == columnName)
                        return col;
                }
                throw new KeyNotFoundException();
            }
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

        public NetworkTableColumn[] Inputs
        {
            get { return Select(NetworkTableColumn.ColumnRole.Input); }
        }

        public NetworkTableColumn[] Outputs
        {
            get { return Select(NetworkTableColumn.ColumnRole.Output); }
        }
        #endregion

    }

}
