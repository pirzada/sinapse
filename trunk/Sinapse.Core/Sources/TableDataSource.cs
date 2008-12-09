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
using System.ComponentModel;

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
    public class TableDataSource : DataSource
    {

        /// <summary>
        ///   The DataTable which holds the actual data.
        /// </summary>
        private DataTable m_dataTable;


        /// <summary>
        ///   The info and description associated which each DataTable column
        /// </summary>
        private TableDataSourceColumnCollection m_columns;


        //----------------------------------------


        #region Constructor
        /// <summary>
        ///   Creates a new NetworkTableSource object.
        /// </summary>
        /// <param name="dataTable">
        ///   A DataTable which will be deep copied into this object.
        /// </param>
        public TableDataSource(DataTable dataTable)
            : base(dataTable.TableName)
        {
            this.m_dataTable = dataTable.Copy();
     
            TableDataSourceColumn[] columns = new TableDataSourceColumn[m_dataTable.Columns.Count];
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = new TableDataSourceColumn(m_dataTable.Columns[i]); 
            }

            this.m_columns = new TableDataSourceColumnCollection(columns);
        }

        public TableDataSource(String title, TableDataSourceColumn[] columns)
            : base(title)
        {
            this.m_dataTable = new DataTable(title);

            this.m_columns = new TableDataSourceColumnCollection(columns);
        }

        public TableDataSource(String title)
            : this(new DataTable(title))
        {
        }
        #endregion


        //----------------------------------------


        #region Properties
        [Browsable(false)]
        public TableDataSourceColumnCollection Columns
        {
            get { return this.m_columns; }
        }

        [Browsable(false)]
        public DataTable DataTable
        {
            get { return this.m_dataTable; }
        }
        #endregion


        //----------------------------------------


        #region Public Methods

        #endregion


    }

    [Serializable]
    public class TableDataSourceColumn
    {

        private string m_columnDescription;
        private SystemDataType m_columnDataType;
        private DataColumn m_dataColumn;



        #region Constructor
        public TableDataSourceColumn(DataColumn dataColumn, SystemDataType type)
        {
            this.m_dataColumn = dataColumn;
            this.m_columnDataType = type;

            this.m_dataColumn.Table.Columns.Add(this.Name, typeof(double));
        }

        public TableDataSourceColumn(DataColumn relatedColumn)
        {
            this.m_dataColumn = relatedColumn;
        }
        #endregion



        #region Properties
        /// <summary>
        ///   The name for this Table Column
        /// </summary>
        public string Name
        {
            get { return this.m_dataColumn.ColumnName; }
            set { this.m_dataColumn.ColumnName = value; }
        }

        /// <summary>
        ///   The display text for this Table Column
        /// </summary>
        public string Caption
        {
            get { return this.m_dataColumn.Caption; }
            set { this.m_dataColumn.Caption = value; }
        }

        /// <summary>
        ///   Gets or sets a text describing which information this Column contains.
        /// </summary>
        public string Description
        {
            get { return this.m_columnDescription; }
            set { this.m_columnDescription = value; }
        }

        public SystemDataType DataType
        {
            get { return this.m_columnDataType; }
            set
            {
                    this.m_columnDataType = value;
            }
        }

        public DataColumn DataColumn
        {
            get { return this.m_dataColumn; }
        }

        #endregion

        // --------------------------------------

    }

    [Serializable]
    public sealed class TableDataSourceColumnCollection :
        System.ComponentModel.BindingList<TableDataSourceColumn>
    {


       

        #region Constructor
        internal TableDataSourceColumnCollection(TableDataSourceColumn[] columns)
            : base(columns)
        {
           
        }
        #endregion

       

        #region Properties
        /// <summary>
        ///   Gets the associated column info for the given DataColumn.
        /// </summary>
        /// <param name="dataColumn"></param>
        /// <returns></returns>
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

        /// <summary>
        ///   Gets the associated column info for the given column name.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
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


    }

}
