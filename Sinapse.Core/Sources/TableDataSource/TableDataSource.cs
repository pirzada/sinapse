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
    public class TableDataSource : IDataSource, ISerializableObject<TableDataSource>
    {
        
        private SerializableObject<TableDataSource> serializableObject;


        /// <summary>
        ///   The DataTable which holds the actual data.
        /// </summary>
        private DataTable dataTable;


        /// <summary>
        ///   The info and description associated which each DataTable column
        /// </summary>
        private TableDataSourceColumnCollection columns;




        /// <summary>
        ///   Creates a new TableDataSource object by using a DataTable.
        /// </summary>
        /// <param name="dataTable">
        ///   A DataTable which will be deep copied into this object.
        /// </param>
        public TableDataSource(DataTable dataTable)
        {
            this.serializableObject = new SerializableObject<TableDataSource>();

            this.dataTable = dataTable.Copy();
            this.Name = dataTable.TableName;
     
            // Creates the array of TableDataSourceColumns, which holds information
            //  and description for every DataColumn on the DataTable
            TableDataSourceColumn[] columns = new TableDataSourceColumn[dataTable.Columns.Count];
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = new TableDataSourceColumn(dataTable.Columns[i]); 
            }
            this.columns = new TableDataSourceColumnCollection(columns);

            // Creates the extra two columns for storing the Set and Subset
            DataColumn col = new DataColumn("@SET", typeof(int));
            dataTable.Columns.Add(col);
            this.columns.Add(col, SystemDataType.Nummeric, DataSourceRole.None);

            col = new DataColumn("@SUBSET", typeof(int));
            dataTable.Columns.Add(col);
            this.columns.Add(col, SystemDataType.Nummeric, DataSourceRole.None);
        }


        public TableDataSource(String name)
        {
            this.serializableObject = new SerializableObject<TableDataSource>();

            this.dataTable = new DataTable(name);
            this.Name = name;
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


        public DataView GetView(DataSourceSet set)
        {
            dataTable.Select("@SET = " + set);
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("@SET='{0}'", (int)set);
            return dataView;
        }


        public DataView GetView(DataSourceSet set, int subset)
        {
            dataTable.Select("@SET = " + set);
            DataView dataView = new DataView(this.dataTable);
            dataView.RowFilter = String.Format("@SET='{0}' AND @SUBSET='{1}'", (int)set, subset);
            return dataView;
        }


        public object[][] GetData(DataSourceSet set)
        {
            DataRow[] rows = dataTable.Select(String.Format("@SET='{0}'", (int)set));
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                data[i] = rows[i].ItemArray;
            }
            return data;
        }


        public object[][] GetData(DataSourceSet set, int subset)
        {
            DataRow[] rows = dataTable.Select(String.Format("@SET='{0}' AND @SUBSET='{1}'", (int)set, subset));
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                data[i] = rows[i].ItemArray;
            }
            return data;
        }

        public object[][] GetData(DataSourceSet set, DataSourceRole role)
        {
            DataRow[] rows = dataTable.Select(String.Format("@SET='{0}'", (int)set));
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                data[i] = GetData(rows[i], role);
            }
            return data;
        }

        public object[][] GetData(DataSourceSet set, int subset, DataSourceRole role)
        {
            DataRow[] rows = dataTable.Select(String.Format("@SET='{0}' AND @SUBSET='{1}'", (int)set, subset));
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





        #region ISerializableObject<TableDataSource> Members

        public String Name
        {
            get { return this.serializableObject.Name; }
            set { serializableObject.Name = value; }
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

        public static TableDataSource Open(string path)
        {
            return SerializableObject<TableDataSource>.Open(path);
        }

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
