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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Data;
using System.IO;

using AForge;  

using Sinapse.Data.Structures;


namespace Sinapse.Data.Network
{

    internal enum NetworkSet : ushort { Training = 0, Validation = 1, Testing = 2, Query = 3 };


    [Serializable]
    internal sealed class NetworkDatabase : SerializableObject<NetworkDatabase>
    {


        #region Const definitions
        public const string ColumnRoleId = "@_informationRoleId";
        public const string ColumnTrainingLayerId = "@_trainingLayerId";
        public const string ColumnComputedPrefix = "@_computed";
        public const string ColumnDeltaPrefix = "@_delta";
        #endregion


        //----------------------------------------


        private NetworkSchema m_networkSchema;
        private DataTable m_dataTable;

        //----------------------------------------


        #region Constructors
        public NetworkDatabase(NetworkSchema schema, DataTable dataTable)
        {
            this.m_networkSchema = schema;
            this.m_dataTable = dataTable;

            this.createColumns(dataTable, schema);

            this.m_networkSchema.DataCategories.AutodetectCaptions(dataTable);
            this.m_networkSchema.DataRanges.AutodetectRanges(dataTable);
        }

        public NetworkDatabase(NetworkSchema schema)
        {
            this.m_networkSchema = schema;
            this.m_dataTable = new DataTable();

            this.createColumns(m_dataTable, schema);
        }
        #endregion


        //----------------------------------------


        #region Properties
        internal NetworkSchema Schema
        {
            get { return this.m_networkSchema; }
        }

        internal DataTable DataTable
        {
            get { return this.m_dataTable; }
        }

        internal int TrainingLayerCount
        {
            get { return this.m_dataTable.DefaultView.ToTable(true, ColumnTrainingLayerId).Rows.Count; }
        }

        internal DataView TrainingSet
        {
            get { return this.createDataView(NetworkSet.Training); }
        }

        internal DataView TestingSet
        {
            get { return this.createDataView(NetworkSet.Testing); }
        }

        internal DataView ValidationSet
        {
            get { return this.createDataView(NetworkSet.Validation); }
        }       
        #endregion


        //----------------------------------------


        #region Public Methods

        internal void ImportData(DataTable dataTable, NetworkSet networkSet, int trainingSet)
        {
            this.createColumns(dataTable, m_networkSchema, networkSet, trainingSet);
            this.m_dataTable.Merge(dataTable, false, MissingSchemaAction.Ignore);
        }


        /// <summary>
        /// Creates the desired set of input or output vectors based on the current data.
        /// </summary>
        /// <param name="set">The set of data.</param>
        internal TrainingVectors CreateVectors(NetworkSet set)
        {
            return this.CreateVectors(set, 0);
        }

        /// <summary>
        /// Creates the desired set of input or output vectors based on the current data.
        /// </summary>
        /// <param name="set">The set of data.</param>
        /// <param name="trainingSet">The training subset of the data.</param>
        /// <returns></returns>
        internal TrainingVectors CreateVectors(NetworkSet networkSet, ushort trainingLayer)
        {

            TrainingVectors vectors;
            string strQuery = String.Empty;

            switch (networkSet)
            {
                case NetworkSet.Testing:
                    strQuery = String.Format("[{0}] = {1}",
                        ColumnRoleId, (ushort)NetworkSet.Testing);
                    break;

                
                case NetworkSet.Training:
                    strQuery = String.Format("[{0}] = {1}",
                    ColumnRoleId, (ushort)NetworkSet.Training);

                    if (trainingLayer > 0)
                    {
                        strQuery = String.Format("{0} AND [{1}] = {2}",
                            strQuery, ColumnTrainingLayerId, trainingLayer);
                    }
                    break;

             
                case NetworkSet.Validation:
                    strQuery = String.Format("[{0}] = {1}",
                        ColumnRoleId, (ushort)NetworkSet.Validation);
                    break;
            }


            DataRow[] query = m_dataTable.Select(strQuery);

            vectors.Input = new double[query.Length][];
            vectors.Output = new double[query.Length][];

            for (int i = 0; i < query.Length; ++i)
            {
                vectors.Input[i] = this.NormalizeRow(query[i], m_networkSchema.InputColumns);
                vectors.Output[i] = this.NormalizeRow(query[i], m_networkSchema.OutputColumns);
            }

            return vectors;
        }

        /// <summary>
        /// Normalizes the given datarow so the data can be interpreted by a neural network. Use the RevertRow method to revert the row back to its original state
        /// </summary>
        /// <param name="sourceRow">The source datarow</param>
        /// <param name="columnList">The list of column names</param>
        /// <returns>Returns the normalized vector</returns>
        internal double[] NormalizeRow(DataRow sourceRow, string[] columnList)
        {
            double[] doubleData = new double[columnList.Length];

            for (int i = 0; i < columnList.Length; i++)
            {
                doubleData[i] = this.NormalizeData(sourceRow, columnList[i]);
            /*  string columnName = columnList[i];

                DoubleRange range = this.m_networkSchema.DataRanges.GetRange(columnName);
                bool hasCaption = (Array.IndexOf(this.m_networkSchema.StringColumns, columnName) >= 0);

                double data;

                if (hasCaption)
                    data = this.m_networkSchema.DataCategories.GetID(columnName, (string)sourceRow[columnName]);
                else
                {
                    string strData = (string)sourceRow[columnName];
                    if (strData.Length > 0)
                        data = Double.Parse(strData);
                    else
                        data = 0;
                }

                doubleData[i] = (data - range.Min) / (range.Max - range.Min);
             */ 
            }

            return doubleData;
        }

        internal double NormalizeData(DataRow sourceRow, string columnName)
        {
            DoubleRange range = this.m_networkSchema.DataRanges.GetRange(columnName);
            bool hasCaption = (Array.IndexOf(this.m_networkSchema.StringColumns, columnName) >= 0);

            double data = 0;

            if (hasCaption)
                data = this.m_networkSchema.DataCategories.GetID(columnName, (string)sourceRow[columnName]);
            else
            {
                if (sourceRow[columnName] != DBNull.Value)
                {
                    string strData = (string)sourceRow[columnName];

                    if (strData.Length > 0)
                        data = Double.Parse(strData);
                }
            }

            return (data - range.Min) / (range.Max - range.Min);
        }

        /// <summary>
        /// Reverts any normalized output vector back to its original state.
        /// </summary>
        /// <param name="dataRow">The current data row</param>
        /// <param name="columnList">The list of column names used in the normalized vector</param>
        /// <param name="normalizedData">The normalized vector</param>
        internal void RevertRow(DataRow dataRow, string[] columnList, double[] normalizedData)
        {
            for (int i = 0; i < columnList.Length; i++)
            {
                dataRow[columnList[i]] = this.RevertData(columnList[i], normalizedData[i]);
    /*          string columnName = columnList[i];

                DoubleRange range = this.m_networkSchema.DataRanges.GetRange(columnName);
                bool hasCaption = (Array.IndexOf(this.m_networkSchema.StringColumns, columnName) >= 0);

                double data = normalizedData[i] * (range.Max - range.Min) + range.Min;

                if (hasCaption)
                    dataRow[columnName] = this.m_networkSchema.DataCategories.GetCaption(columnName, (int)Math.Round(data));
                else
                    dataRow[columnName] = data.ToString();
     */ 
            }
        }

        internal string RevertData(string columnName, double normalizedData)
        {
            string output;

            DoubleRange range = this.m_networkSchema.DataRanges.GetRange(columnName);
            bool hasCaption = (Array.IndexOf(this.m_networkSchema.StringColumns, columnName) >= 0);

            double data = normalizedData * (range.Max - range.Min) + range.Min;

            if (hasCaption)
                output = this.m_networkSchema.DataCategories.GetCaption(columnName, (int)Math.Round(data));
            else
                output = data.ToString();

            return output;
        }

        internal void ComputeRow(NetworkContainer networkContainer, DataRow dataRow, bool testingOnly)
        {
            double[] input = this.NormalizeRow(dataRow, this.Schema.InputColumns);
            double[] output = networkContainer.ActivationNetwork.Compute(input);

            string columnName;
            for (int i = 0; i < output.Length; ++i)
            {
                if (testingOnly)
                    columnName = ColumnComputedPrefix + this.Schema.OutputColumns[i];
                else columnName = this.Schema.OutputColumns[i];

                dataRow[columnName] =
                    this.RevertData(this.Schema.OutputColumns[i], output[i]);
            }

        }

        internal void ComputeTable(NetworkContainer networkContainer, bool testingOnly)
        {
            NetworkSet networkSet = testingOnly ? NetworkSet.Testing : NetworkSet.Query;

            DataRow[] result = this.m_dataTable.Select(String.Format("[{0}] = {1}",
                ColumnRoleId, (ushort)networkSet));

            foreach (DataRow dataRow in result)
            {
                ComputeRow(networkContainer, dataRow, testingOnly);
            }
        }


        /// <summary>
        /// Iterates the DataTable and validates categorical input fields
        /// </summary>
        /// <returns>Returns true in case of success, false otherwise</returns>
        internal bool ValidateTable()
        {
            bool success = true;

            foreach (DataRow row in this.m_dataTable.Rows)
            {
                foreach (string columnName in this.Schema.InputColumns)
                {
                    //Check if field is indeed a category
                    if (Array.IndexOf(this.Schema.StringColumns, columnName) >= 0)
                    {
                        string strData = (string)row[columnName];
                        if (this.Schema.DataCategories.GetID(columnName, strData) < 0)
                        {
                            row.RowError = "Invalid data at column " + columnName;
                            return false;
                        }
                    }
                }

            }
            return success;
        }

        /// <summary>
        /// Iterates the DataTable and rounds non-categorical output fields
        /// </summary>
        internal void Round(bool testingOnly, float threshold)
        {
            string columnName;
            double value, absDecValue;

            foreach (DataRow row in this.m_dataTable.Rows)
            {
                foreach (string outputColumn in this.Schema.OutputColumns)
                {
                    if (testingOnly)
                        columnName = ColumnComputedPrefix + outputColumn;
                    else columnName = outputColumn;

                    //Check if field isn't a category
                    if (!this.Schema.IsCategory(columnName))
                    {
                        if (Double.TryParse((string)row[columnName], out value))
                        {
                            absDecValue = Math.Abs(value - Math.Truncate(value));
                            if (value > 0 && absDecValue >= threshold ||
                                value < 0 && absDecValue <= threshold)
                            {
                                row[columnName] = Math.Ceiling(value).ToString();
                            }
                            else
                            {
                                row[columnName] = Math.Floor(value).ToString();
                            }
                        }
                    }
                }
            }
        }

        internal void Round(bool testingOnly)
        {
            this.Round(testingOnly, 0.5f);
        }

        internal double Score()
        {
            DataRow[] selectedRows = m_dataTable.Select(String.Format("[{0}] = {1}", ColumnRoleId, (ushort)NetworkSet.Testing));

            double sum = 0;
            foreach (DataRow row in selectedRows)
            {
                foreach (string outputColumn in Schema.OutputColumns)
                {
                    sum += Double.Parse((string)row[ColumnDeltaPrefix + outputColumn]);
                }
            }

            return sum;
        }

        internal double Score(string column)
        {
            DataRow[] selectedRows = m_dataTable.Select(String.Format("[{0}] = {1}",ColumnRoleId, (ushort)NetworkSet.Testing));

            double sum=0;
            foreach (DataRow row in selectedRows)
            {
                sum += Double.Parse((string)row[column]);
            }

            return sum;
        }

        /// <summary>
        /// Randomizes the order of the rows in a DataTable by pulling out a single row and moving it to the end for
        /// shuffleIterations iterations.
        /// </summary>
        /// <param name="shuffleIterations"></param>
        /// <returns></returns>
        internal void Shuffle(int shuffleIterations)
        {
            //TODO: shuffle only the training set, not the entire database!
            int index;
            int iterations = this.m_dataTable.Rows.Count * shuffleIterations;

            System.Random rnd = new Random();

            // Remove and throw to the end random rows until we have done so n*3 times (shuffles the dataset)
            for (int i = 0; i < shuffleIterations; i++)
            {
                index = rnd.Next(0, m_dataTable.Rows.Count - 1);
                this.m_dataTable.Rows.Add(m_dataTable.Rows[index].ItemArray);
                this.m_dataTable.Rows.RemoveAt(index);
            }
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private DataView createDataView(NetworkSet networkSet)
        {
            DataView dv = new DataView(this.DataTable);
            dv.RowFilter = String.Format("{0}='{1}'", NetworkDatabase.ColumnRoleId, (ushort)networkSet);
            return dv;
        }

        /// <summary>
        /// Creates the internal structure needed in the datatable, such as hidden columns and support data
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="schema"></param>
        private void createColumns(DataTable dataTable, NetworkSchema schema)
        {
            this.createColumns(dataTable, schema, NetworkSet.Training, 1);
        }

        /// <summary>
        /// Creates the internal structure needed in the datatable, such as hidden columns and support data
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="schema"></param>
        /// <param name="networkSet"></param>
        /// <param name="trainingSet"></param>
        private void createColumns(DataTable dataTable, NetworkSchema schema, NetworkSet networkSet, int trainingSet)
        {
            DataColumn col;

            if (!dataTable.Columns.Contains(ColumnRoleId))
            {
                col = new DataColumn(ColumnRoleId, typeof(ushort));
                col.AllowDBNull = false;
                col.DefaultValue = (ushort)networkSet;
                dataTable.Columns.Add(col);
            }

            if (!dataTable.Columns.Contains(ColumnTrainingLayerId))
            {
                col = new DataColumn(ColumnTrainingLayerId, typeof(int));
                col.AllowDBNull = false;
                col.DefaultValue = trainingSet;
                dataTable.Columns.Add(col);
            }

            foreach (String colName in schema.AllColumns)
            {
                if (!dataTable.Columns.Contains(colName))
                {
                    col = new DataColumn(colName, typeof(string));
                    col.AllowDBNull = false;
                    col.DefaultValue = String.Empty;
                    dataTable.Columns.Add(col);
                }
            }

            foreach (String colName in schema.OutputColumns)
            {
                if (!dataTable.Columns.Contains(ColumnComputedPrefix + colName))
                {
                    col = new DataColumn(ColumnComputedPrefix + colName, typeof(string));
                    col.AllowDBNull = false;
                    col.DefaultValue = String.Empty;
                    dataTable.Columns.Add(col);

                    col = new DataColumn(ColumnDeltaPrefix + colName, typeof(string));
                    col.AllowDBNull = false;
                    col.DefaultValue = String.Empty;

                    if (!schema.IsCategory(colName))
                    {
                        col.Expression = String.Format("IIF((LEN([{0}{1}]) > 0 AND LEN([{1}]) > 0), Convert([{0}{1}], System.Double) - Convert([{1}], System.Double), '0')", ColumnComputedPrefix, colName);
                    }
                    else
                    {
                        col.Expression = String.Format("IIF([{0}{1}] = [{1}], '0', '1')", ColumnComputedPrefix, colName);
                    }
                    dataTable.Columns.Add(col);
                }
            }
        }
        #endregion


        //----------------------------------------


    }
}
