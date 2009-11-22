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
    [DocumentDescription("Table Data Source",
        DefaultName="tableSource",
        Description="Table Data Source",
        Extension=".source.tds",
        IconPath="Resources/Source.ico")]
    [Serializable]
    public class TableDataSource : ISource, ISinapseDocument
    {

        private DataTable dataTable;


        [field: NonSerialized]
        public event EventHandler DataChanged;



        /// <summary>
        ///   Creates a new Table Data Source object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        public TableDataSource(String name, System.IO.FileInfo info)
        {
            // Initialize simulated multiple-inheritance helpers
            this.serializableObject = new SerializableObject<TableDataSource>(this);
            this.sinapseDocument = new SinapseDocument(name, info);

            this.dataTable = new DataTable(name);
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
        public void Import(DataTable table)
        {
            // Import the DataTable
            this.dataTable.Merge(table, true, MissingSchemaAction.Add);


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

        public void RemoveOutliers()
        {
            throw new NotImplementedException();
        }

        private void createExtendedColumns()
        {
            if (!dataTable.Columns.Contains("@SET"))
            {
                DataColumn dataColumn;

                dataColumn = new DataColumn("@SET", typeof(int));
                dataColumn.DefaultValue = DataSourceSet.Training;
                this.dataTable.Columns.Add(dataColumn);

                dataColumn = new DataColumn("@SUBSET", typeof(int));
                dataColumn.DefaultValue = 0;
                this.dataTable.Columns.Add(dataColumn);

            }
        }






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

        public object GetData(string[] columns, DataSourceSet set)
        {
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("[@SET]='{0}'", (int)set);
            DataTable newTable = dataView.ToTable(false, columns);
            return newTable;
        }

        public object GetData(DataSourceSet set)
        {
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("[@SET]='{0}'", (int)set);
            DataTable newTable = dataView.ToTable(false);
            return newTable;
        }

        public object GetData(DataSourceSet set, int subset)
        {
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("[@SET]='{0}' AND [@SUBSET]='{1}'", (int)set, subset);
            DataTable newTable = dataView.ToTable(false);
            return newTable;
        }
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



    }

}
