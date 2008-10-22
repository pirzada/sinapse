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
    public class TableDataSource : DataSourceBase
    {

        /// <summary>
        /// The DataSet which holds the actual data. The first table (accessible by index 0) holds the actual data, the second table on the set holds the categories
        /// </summary>
        private DataSet m_dataSet;
        private DataTable m_dataTable;
        private TableDataSourceColumnCollection m_columns;

        //----------------------------------------

        #region Constructor
        /// <summary>Creates a new NetworkTableSource object.</summary>
        /// <param name="dataTable">A DataTable which will be deep copied into this object.</param>
        public TableDataSource(String title, DataTable dataTable)
            : base(title)
        {
            this.m_dataSet = new DataSet(title);
            this.m_dataTable = dataTable.Copy();
            this.m_dataSet.Tables.Add(m_dataTable);

            // For each column, create other 2 columns: columnName_networkanswer, columnName_networkdelta
            // if the column is a category, create another column columnName_index and another table
            // with the same name.

            TableDataSourceColumn[] columns = new TableDataSourceColumn[m_dataTable.Columns.Count];
            for (int i = 0; i < columns.Length; i++)
            {
                // User will determine the type of the data or it will be selected based on data type?
                columns[i] = new TableDataSourceColumn(m_dataTable.Columns[i]); 
            }

          //  this.m_columns = new NetworkTableColumnCollection(dataTable);
        }

        public TableDataSource(String title, TableDataSourceColumn[] columns)
            : base(title)
        {
            this.m_dataSet = new DataSet(title);
            this.m_dataTable = new DataTable();

            this.m_columns = new TableDataSourceColumnCollection(columns);
        }

        public TableDataSource(String title)
            : this(title, new DataTable())
        {
        }
        #endregion

        //----------------------------------------

        #region Properties
        public TableDataSourceColumnCollection Columns
        {
            get { return this.m_columns; }
        }
        #endregion

        //----------------------------------------

        #region Public Methods

        #endregion

    }

    [Serializable]
    public class TableDataSourceColumn
    {

        public enum TableDataSourceColumnRole { None, Input, Output };
  //      public enum ColumnRelevance { None, Low, Medium, High };

        private string m_columnDescription;
        private TableDataSourceColumnRole m_columnRole;
        private SystemInputOutputDataType m_columnDataType;
 //       private ColumnRelevance m_columnRelevance;

        private DataColumn m_dataColumn;
        private DataColumn m_networkAnswer;
        private DataColumn m_networkDelta;
        private DataColumn m_categoryIndex;


        // --------------------------------------

        #region Constructor
        public TableDataSourceColumn(DataColumn dataColumn, SystemInputOutputDataType type, TableDataSourceColumnRole role)
        {
            this.m_dataColumn = dataColumn;

            this.m_columnDataType = type;
            this.m_columnRole = role;

            this.m_dataColumn.Table.Columns.Add(this.Name, typeof(double));
        }

        public TableDataSourceColumn(DataColumn relatedColumn)
        {
            this.m_dataColumn = relatedColumn;
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

        public TableDataSourceColumnRole Role
        {
            get { return this.m_columnRole; }
            set
            {
                    this.m_columnRole = value;
            }
        }

        public SystemInputOutputDataType DataType
        {
            get { return this.m_columnDataType; }
            set
            {
                    this.m_columnDataType = value;
            }
        }
        /*
        public ColumnRelevance Relevance
        {
            get { return this.m_columnRelevance; }
            set { this.m_columnRelevance = value; }
        }
        */
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
    public sealed class TableDataSourceColumnCollection :
        System.Collections.ObjectModel.ReadOnlyCollection<TableDataSourceColumn>
    {


        // --------------------------------------

        #region Constructor
        internal TableDataSourceColumnCollection(TableDataSourceColumn[] columns)
            : base(columns)
        {
           
        }
        #endregion

        // --------------------------------------

        #region Properties
        public TableDataSourceColumn this[DataColumn dataColumn]
        {
            get
            {
                foreach (TableDataSourceColumn col in this)
                {
                    if (col.DataColumn == dataColumn)
                        return col;
                }
                throw new KeyNotFoundException();
            }
        }

        public TableDataSourceColumn this[string columnName]
        {
            get
            {
                foreach (TableDataSourceColumn col in this)
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
        public TableDataSourceColumn[] Select(TableDataSourceColumn.TableDataSourceColumnRole columnRole)
        {
            List<TableDataSourceColumn> search = new List<TableDataSourceColumn>(this.Count);

            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == columnRole)
                    search.Add(col);
            }

            return search.ToArray();
        }

        public TableDataSourceColumn[] Inputs
        {
            get { return Select(TableDataSourceColumn.TableDataSourceColumnRole.Input); }
        }

        public TableDataSourceColumn[] Outputs
        {
            get { return Select(TableDataSourceColumn.TableDataSourceColumnRole.Output); }
        }
        #endregion

    }

}
