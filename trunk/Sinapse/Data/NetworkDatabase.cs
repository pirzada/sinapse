/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
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

using AForge;

using Sinapse.Data.Structures;

namespace Sinapse.Data
{

    public enum NetworkSet : ushort { Training = 0, Validation = 1, Testing = 2 };


    /// <summary>
    /// Class to hold samples or query information
    /// </summary>
    internal sealed class NetworkDatabase
    {

        public const string ColumnRoleId = "@_informationRoleId";
        public const string ColumnTrainingSetId = "@_trainingSetId";


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
        internal NetworkSchema NetworkSchema
        {
            get { return this.m_networkSchema; }
        }

        internal DataTable DataTable
        {
            get { return this.m_dataTable; }
        }

        internal int TrainingSets
        {
            get { return m_dataTable.DefaultView.ToTable(true, ColumnTrainingSetId).Select(ColumnRoleId + " = " + (ushort)NetworkSet.Testing).Length; }
        }

        #endregion


        //----------------------------------------


        #region Public Methods

        internal void ImportData(DataTable dataTable, NetworkSet networkSet, ushort trainingSet)
        {
            this.createColumns(dataTable, m_networkSchema, networkSet, trainingSet);
            this.m_dataTable.Merge(dataTable, false, MissingSchemaAction.Ignore);
        }


        /// <summary>
        /// Creates the desired set of input or output vectors based on the current data.
        /// </summary>
        /// <param name="set">The set of data.</param>
        internal NetworkVectors CreateVectors(NetworkSet set)
        {
            return this.CreateVectors(set, 0);
        }

        /// <summary>
        /// Creates the desired set of input or output vectors based on the current data.
        /// </summary>
        /// <param name="set">The set of data.</param>
        /// <param name="trainingSet">The training subset of the data.</param>
        /// <returns></returns>
        internal NetworkVectors CreateVectors(NetworkSet set, ushort trainingSet)
        {

            NetworkVectors vectors;
            string strQuery = String.Empty;

            switch (set)
            {
                case NetworkSet.Testing:
                    strQuery = String.Format("[{0}] = {1}",
                        ColumnRoleId, (ushort)NetworkSet.Testing);
                    break;

                
                case NetworkSet.Training:
                    strQuery = String.Format("[{0}] = {1}",
                    ColumnRoleId, (ushort)NetworkSet.Training);

                    if (trainingSet > 0)
                    {
                        strQuery = String.Format("{0} AND [{1}] = {2}",
                            strQuery, ColumnTrainingSetId, trainingSet);
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
                string columnName = columnList[i];

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
            }

            return doubleData;
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
                string columnName = columnList[i];

                DoubleRange range = this.m_networkSchema.DataRanges.GetRange(columnName);
                bool hasCaption = (Array.IndexOf(this.m_networkSchema.StringColumns, columnName) >= 0);

                double data = normalizedData[i] * (range.Max - range.Min) + range.Min;

                if (hasCaption)
                    dataRow[columnName] = this.m_networkSchema.DataCategories.GetCaption(columnName, (int)Math.Round(data));
                else
                    dataRow[columnName] = data.ToString();
            }
        }
        #endregion


        //----------------------------------------


        #region Private Methods
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
        private void createColumns(DataTable dataTable, NetworkSchema schema, NetworkSet networkSet, ushort trainingSet)
        {
            DataColumn col;

            if (!dataTable.Columns.Contains(ColumnRoleId))
            {
                col = new DataColumn(ColumnRoleId, typeof(ushort));
                col.AllowDBNull = false;
                col.DefaultValue = (ushort)networkSet;
                dataTable.Columns.Add(col);
            }

            if (!dataTable.Columns.Contains(ColumnTrainingSetId))
            {
                col = new DataColumn(ColumnTrainingSetId, typeof(ushort));
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
        }
        #endregion

        //----------------------------------------


    }
}
