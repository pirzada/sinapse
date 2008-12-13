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
    public class TableDataSource : IDataSource, ISerializableObject<TableDataSource>
    {

        private SinapseComponent workplaceComponent;
        private SerializableObject<TableDataSource> serializableObject;


        private DataTable dataTable;
        private TableDataSourceColumnCollection columns;

        [field: NonSerialized]
        public event EventHandler Changed;

        [field: NonSerialized]
        public event EventHandler DataChanged;


        /// <summary>
        ///   Creates a new TableDataSource object by using a DataTable.
        /// </summary>
        public TableDataSource()
            : this("New Table Source")
        {
        }


        public TableDataSource(String name)
        {
            // Initialize simulated multiple-inheritance helpers
            this.serializableObject = new SerializableObject<TableDataSource>(this);
            this.workplaceComponent = new SinapseComponent();

            this.dataTable = new DataTable(name);
            this.columns = new TableDataSourceColumnCollection();
            this.Name = name;

            // Create the extra two columns for storing the Set and Subset
            createExtendedColumns();

            HasChanges = true;
        }


        /// <summary>
        ///   Imports a DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        public void Import(DataTable table, TableDataSourceColumnCollection columns)
        {
            // Store the table and column information
            this.dataTable = table;
            this.columns = columns;

            // Create the extra two columns for storing the Set and Subset
            createExtendedColumns();

            HasChanges = true;
            OnChanged(EventArgs.Empty);
        }

        /// <summary>
        ///   Imports only matching columns from a DataTable
        /// </summary>
        /// <param name="table"></param>
        public void Import(DataTable table)
        {
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
                dataColumnInfo.Role = DataSourceRole.None;
                this.columns.Add(dataColumnInfo);

                dataColumn = new DataColumn("@SUBSET", typeof(int));
                dataColumn.DefaultValue = 0;
                this.dataTable.Columns.Add(dataColumn);

                dataColumnInfo = new TableDataSourceColumn(dataColumn);
                dataColumnInfo.Visible = false;
                dataColumnInfo.Role = DataSourceRole.None;
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


        public object[][] GetData(DataSourceSet set)
        {
            DataRow[] rows = dataTable.Select(String.Format("[@SET]='{0}'", (int)set));
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                data[i] = rows[i].ItemArray;
            }
            return data;
        }


        public object[][] GetData(DataSourceSet set, int subset)
        {
            DataRow[] rows = dataTable.Select(String.Format("[@SET]='{0}' AND [@SUBSET]='{1}'", (int)set, subset));
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                data[i] = rows[i].ItemArray;
            }
            return data;
        }

        public object[][] GetData(DataSourceSet set, DataSourceRole role)
        {
            DataRow[] rows = dataTable.Select(String.Format("[@SET]='{0}'", (int)set));
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                data[i] = GetData(rows[i], role);
            }
            return data;
        }

        public object[][] GetData(DataSourceSet set, int subset, DataSourceRole role)
        {
            DataRow[] rows = dataTable.Select(String.Format("[@SET]='{0}' AND [@SUBSET]='{1}'", (int)set, subset));
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                data[i] = GetData(rows[i], role);
            }
            return data;
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


        /// <summary>
        ///   Gets the input data stored inside a DataRow. The DataRow must be a
        ///   member of the internal DataTable of this TableDataSource.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public object[] GetData(DataRow row, DataSourceRole role)
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

        public void SetData(DataRow row, DataSourceRole role, object[] data)
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
        #endregion







        protected void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed.Invoke(this, e);
        }





        #region ISerializableObject<TableDataSource> Members


        public string FileName
        {
            get { return serializableObject.FileName; }
            set { serializableObject.FileName = value; }
        }

        public string FilePath
        {
            get { return serializableObject.FilePath; }
            set { serializableObject.FilePath = value; }
        }

        public string FullPath
        {
            get { return serializableObject.FullPath; }
        }

        public string DefaultExtension
        {
            get { return "stds"; }
        }

        public bool Save(string path)
        {
            bool success = serializableObject.Save(path);
            if (success) this.HasChanges = false;
            return success;
        }

        public bool Save()
        {
            bool success = serializableObject.Save();
            if (success) this.HasChanges = false;
            return success;
        }

        public static TableDataSource Open(string path)
        {
            return SerializableObject<TableDataSource>.Open(path);
        }


        public event EventHandler FileChanged
        {
            add { serializableObject.FileChanged += value; }
            remove { serializableObject.FileChanged -= value; }
        }
        #endregion





        #region IWorkplaceComponent Members

        public string Name
        {
            get { return workplaceComponent.Name; }
            set { workplaceComponent.Name = value; }
        }

        public string Description
        {
            get { return workplaceComponent.Description; }
            set { workplaceComponent.Description = value; }
        }

        public string Remarks
        {
            get { return workplaceComponent.Remarks; }
            set { workplaceComponent.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return workplaceComponent.HasChanges; }
            protected set { workplaceComponent.HasChanges = value; }
        }


        public event EventHandler Closed;

        #endregion





        #region IDataSource Members


        object IDataSource.GetData(DataSourceSet set)
        {
            return GetData(set);
        }

        object IDataSource.GetData(DataSourceSet set, int subset)
        {
            return GetData(set, subset);
        }

        object IDataSource.GetData(DataSourceSet set, DataSourceRole role)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        object IDataSource.GetData(DataSourceSet set, int subset, DataSourceRole role)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    }

}
