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

using Sinapse.Core;
using Sinapse.Core.Systems;

namespace Sinapse.Core.Sources
{

    /// <summary>
    ///   This class encompass an adaptive system data source, or in other words, a
    ///   source of information that can be used to train and feed adptive systems.
    ///   The source encompassed here is presented as a DataTable, which can be created
    ///   or imported from various other sources like Microsoft Excel or text files. 
    /// </summary>
    [Serializable]
    public class TableDataSource : ISource, ISinapseDocument
    {

        
        private DataTable dataTable;
        private TableDataSourceColumnCollection columns;


        [field: NonSerialized]
        public event EventHandler DataChanged;



        public TableDataSource(String name, System.IO.FileInfo info)
        {
            // Initialize simulated multiple-inheritance helpers
            this.serializableObject = new SerializableObject<TableDataSource>(this);
            this.sinapseDocument = new SinapseDocument(name, info);

            this.dataTable = new DataTable(name);
            this.columns = new TableDataSourceColumnCollection(dataTable);
            this.Name = name;

            // Create the extra two columns for storing the Set and Subset
            createExtendedColumns();

            HasChanges = true;

            this.dataTable.ColumnChanged+= dataTable_Changed;
            this.dataTable.RowChanged += dataTable_Changed;
            this.dataTable.TableCleared += dataTable_Changed;
        }


        /// <summary>
        ///   Imports a DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        public void Import(DataTable table, TableDataSourceColumnCollection columns)
        {
            // Import the DataTable
            this.dataTable.Merge(table, true, MissingSchemaAction.Add);

            // Import the TableDataColumns (copy)
            this.columns.RaiseListChangedEvents = false;
            foreach (TableDataSourceColumn col in columns)
            {
                if (!this.columns.Contains(col.Name))
                {
                    TableDataSourceColumn newCol;
                    newCol = new TableDataSourceColumn(dataTable.Columns[col.Name]);
                //    newCol.Role = col.Role;
                    newCol.DataType = col.DataType;
                    newCol.Description = col.Description;
                    newCol.Visible = col.Visible;
                    this.columns.Add(newCol);
                }
            }
            this.columns.RaiseListChangedEvents = true;
            this.columns.ResetBindings();


            HasChanges = true;
            OnDataChanged(EventArgs.Empty);
        }

        /// <summary>
        ///   Imports only matching columns from a DataTable
        /// </summary>
        /// <param name="table"></param>
        public void Import(DataTable table, DataSourceSet set)
        {
            // Add a new column to the to-be-imported DataTable
            //  to determine which will be the default set when importing
            DataColumn col = new DataColumn("@SET", typeof(DataSourceSet));
            col.DefaultValue = set;
            table.Columns.Add(col);

            // Merge the two
            dataTable.Merge(table, true, MissingSchemaAction.Ignore);
            HasChanges = true;
        }


        private void createExtendedColumns()
        {
            if (!dataTable.Columns.Contains("@SET"))
            {
                DataColumn dataColumn;
                TableDataSourceColumn dataColumnInfo;

                dataColumn = new DataColumn("@SET", typeof(int));
                dataColumn.DefaultValue = DataSourceSet.Training;
                this.dataTable.Columns.Add(dataColumn);

                dataColumnInfo = new TableDataSourceColumn(dataColumn);
                dataColumnInfo.Visible = false;
              //  dataColumnInfo.Role = InputOutput.None;
                this.columns.Add(dataColumnInfo);

                dataColumn = new DataColumn("@SUBSET", typeof(int));
                dataColumn.DefaultValue = 0;
                this.dataTable.Columns.Add(dataColumn);

                dataColumnInfo = new TableDataSourceColumn(dataColumn);
                dataColumnInfo.Visible = false;
            //    dataColumnInfo.Role = InputOutput.None;
                this.columns.Add(dataColumnInfo);
            }
        }




        #region Properties
        [Browsable(false)]
        public TableDataSourceColumnCollection Columns
        {
            get { return columns; }
        }
        #endregion




        public DataTable CopySchema()
        {
            return dataTable.Clone();
        }

        public DataTable CopyTable()
        {
            return dataTable.Copy();
        }


        /// <summary>
        ///   Randomizes the order of the rows in a DataTable by pulling out a single
        ///   row and moving it to the end for the specified ammount of iterations.
        /// </summary>
        /// <param name="shuffleIterations"></param>
        /// <returns></returns>
        public void Shuffle(int iterations)
        {
            int index;
            iterations = this.dataTable.Rows.Count * iterations;

            System.Random rnd = new Random();

            // Remove and throw to the end random rows
            for (int i = 0; i < iterations; i++)
            {
                index = rnd.Next(0, dataTable.Rows.Count - 1);
                this.dataTable.Rows.Add(dataTable.Rows[index].ItemArray);
                this.dataTable.Rows.RemoveAt(index);
            }

            HasChanges = true;
        }

        /// <summary>
        ///   Randomizes the order of the rows in a DataTable
        /// </summary>
        /// <param name="shuffleIterations"></param>
        /// <returns></returns>
        public void Shuffle()
        {
            Shuffle(3);
        }


        #region DataTable Events
        private void dataTable_Changed(object sender, EventArgs e)
        {
            HasChanges = true;
            OnDataChanged(EventArgs.Empty);
        }
        #endregion


        #region Data Copy & Movement Operations
        public void CopyRowToSet(DataRow row, DataSourceSet set)
        {
            DataRow newRow = row.Table.NewRow();
            foreach (DataColumn col in row.Table.Columns)
            {
                newRow[col] = row[col];
            }

            newRow["@SET"] = set;
            row.Table.Rows.Add(newRow);

            HasChanges = true;
        }

        public void MoveRowToSet(DataRow row, DataSourceSet set)
        {
            row["@SET"] = set;

            HasChanges = true;
        }

        public void MoveRowToSubset(DataRow row, int subset)
        {
            row["@SUBSET"] = subset;

            HasChanges = true;
        }

        public void MoveRowToSubset(DataRow row, DataSourceSet set, int subset)
        {
            row["@SET"] = set;
            row["@SUBSET"] = subset;

            HasChanges = true;
        }

        #endregion




        #region Data Retrieval Methods
        public DataView GetView(DataSourceSet set)
        {
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("[@SET]='{0}'", (int)set);
            return dataView;
        }


        public DataView GetView(DataSourceSet set, int subset)
        {
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("[@SET]='{0}' AND [@SUBSET]='{1}'", (int)set, subset);
            return dataView;
        }

        public object[][] GetData(string[] columns, DataSourceSet set)
        {
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("[@SET]='{0}'", (int)set);
            DataTable newTable = dataView.ToTable(false, columns);
            return newTable.ToArray();
        }

        public object[][] GetData(DataSourceSet set)
        {
            DataRow[] rows = dataTable.Select(String.Format("[@SET]='{0}'", (int)set));
            return rows.ToArray();
        }


        public object[][] GetData(DataSourceSet set, int subset)
        {
            DataRow[] rows = dataTable.Select(String.Format("[@SET]='{0}' AND [@SUBSET]='{1}'", (int)set, subset));
            return rows.ToArray();
        }



        /*
                public DataTable GetData(DataSourceSet set, int subset, DataSourceRole role)
                {
                    DataView view = GetData(set, subset);
                    DataTable table = view.ToTable(false, this.columns.GetNames(role));
                    return table;
                }
        */
        public DataView GetExtendedView()
        {
            // For each output column, three extra columns should be added, one for
            //  storing the desired output as seen by a system, one for the raw output
            //  calculed by the system and other to show the deviation between those
            //  two raw outputs, the given by the system and the desired.

            throw new NotImplementedException();
        }

/*
        /// <summary>
        ///   Gets the input data stored inside a DataRow. The DataRow must be a
        ///   member of the internal DataTable of this TableDataSource.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public object[] GetData(DataRow row, InputOutput role)
        {
            if (row.Table != dataTable)
                throw new ArgumentException("row");

            object[] data = new object[columns.GetCount(role)];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = row[columns[i].DataColumn];
            }
            return data;
        }

        public void SetData(DataRow row, InputOutput role, object[] data)
        {
            if (row.Table != dataTable)
                throw new ArgumentException("row");

            data = new object[columns.GetCount(role)];
            for (int i = 0; i < data.Length; i++)
            {
                row[columns[i].DataColumn] = data[i];
            }

            HasChanges = true;
        }
 */ 
        #endregion







        protected void OnDataChanged(EventArgs e)
        {
            if (this.DataChanged != null)
                this.DataChanged.Invoke(this, e);
        }





        #region ISerializableObject<TableDataSource> Members
        private SerializableObject<TableDataSource> serializableObject;

        public bool Save(string path)
        {
            bool success = serializableObject.Save(path);
            if (success) this.HasChanges = false;
            return success;
        }

        public bool Save()
        {
            bool success = serializableObject.Save(File.FullName);
            if (success) this.HasChanges = false;
            return success;
        }

        public static TableDataSource Open(string path)
        {
            TableDataSource doc = SerializableObject<TableDataSource>.Open(path);
            doc.File = new System.IO.FileInfo(path);
            return doc;
        }

        public event EventHandler FileSaved
        {
            add { serializableObject.FileSaved += value; }
            remove { serializableObject.FileSaved -= value; }
        }
        #endregion





        #region IWorkplaceComponent Members
        private SinapseDocument sinapseDocument;

        public string Name
        {
            get { return sinapseDocument.Name; }
            set { sinapseDocument.Name = value; }
        }

        public string Description
        {
            get { return sinapseDocument.Description; }
            set { sinapseDocument.Description = value; }
        }

        public string Remarks
        {
            get { return sinapseDocument.Remarks; }
            set { sinapseDocument.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return sinapseDocument.HasChanges; }
            protected set { sinapseDocument.HasChanges = value; }
        }

        public System.IO.FileInfo File
        {
            get { return sinapseDocument.File; }
            set { sinapseDocument.File = value; }
        }

        public event EventHandler Changed;
        public event EventHandler Closed;

        public Workplace Owner
        {
            get { return sinapseDocument.Owner; }
            set { sinapseDocument.Owner = value; }
        }

        public event EventHandler SavepathChanged
        {
            add { sinapseDocument.SavepathChanged += value; }
            remove { sinapseDocument.SavepathChanged -= value; }
        }

        public event EventHandler ContentChanged
        {
            add { sinapseDocument.ContentChanged += value; }
            remove { sinapseDocument.ContentChanged -= value; }
        }
        #endregion





        #region IDataSource Members


        object ISource.GetData(DataSourceSet set)
        {
            return GetData(set);
        }

        object ISource.GetData(DataSourceSet set, int subset)
        {
            return GetData(set, subset);
        }

        #endregion


    }

}
