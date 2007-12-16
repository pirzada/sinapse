/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2007 Cesar Roberto de Souza <cesarsouza@gmail.com> *
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

namespace Sinapse.Data
{
    /// <summary>
    /// Class to hold samples or query information
    /// </summary>
    internal sealed class NetworkData
    {

        public const string ColumnValidationId = "@_validationOnly";


        private NetworkSchema networkSchema;
        private DataTable dataTable;

        private enum NetworkSet { Training, Testing, Validation };


        //----------------------------------------


        #region Constructors
        public NetworkData(NetworkSchema schema, DataTable dataTable)
        {
            this.networkSchema = schema;
            this.dataTable = dataTable;

            this.createColumns(dataTable, schema);

            this.networkSchema.DataCategories.AutodetectCaptions(dataTable);
            this.networkSchema.DataRanges.AutodetectRanges(dataTable);
        }

        public NetworkData(NetworkSchema schema)
        {
            this.networkSchema = schema;
            this.dataTable = new DataTable();

            this.createColumns(dataTable, schema);

        }
        #endregion


        //----------------------------------------


        #region Properties
        internal NetworkSchema NetworkSchema
        {
            get { return this.networkSchema; }
        }

        internal DataTable DataTable
        {
            get { return this.dataTable; }
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        /// <summary>
        /// Creates the training vectors needed to fed a neural network with training data
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="outputData"></param>
        internal void CreateTrainingVectors(out double[][] inputData, out double[][] outputData)
        {
            this.createVectors(out inputData, out outputData, NetworkSet.Training);
        }


        /// <summary>
        /// Creates the validation vectors needed to validate a neural network through cross-validation
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="outputData"></param>
        internal void CreateValidationVectors(out double[][] inputData, out double[][] outputData)
        {
            this.createVectors(out inputData, out outputData, NetworkSet.Validation);
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

                DoubleRange range = this.networkSchema.DataRanges.GetRange(columnName);
                bool hasCaption = (Array.IndexOf(this.networkSchema.StringColumns, columnName) >= 0);

                double data;

                if (hasCaption)
                    data = this.networkSchema.DataCategories.GetID(columnName, (string)sourceRow[columnName]);
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

                DoubleRange range = this.networkSchema.DataRanges.GetRange(columnName);
                bool hasCaption = (Array.IndexOf(this.networkSchema.StringColumns, columnName) >= 0);

                double data = normalizedData[i] * (range.Max - range.Min) + range.Min;

                if (hasCaption)
                    dataRow[columnName] = this.networkSchema.DataCategories.GetCaption(columnName, (int)Math.Round(data));
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
        private void createColumns(DataTable dataTable, NetworkSchema schema)
        {
            DataColumn col;

            if (!dataTable.Columns.Contains(ColumnValidationId))
            {
                col = new DataColumn(ColumnValidationId, typeof(bool));
                col.AllowDBNull = false;
                col.DefaultValue = false;
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

    


        /// <summary>
        /// Creates the desired set of input or output vectors based on the current data.
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="outputData"></param>
        /// <param name="set"></param>
        private void createVectors(out double[][] inputData, out double[][] outputData, NetworkSet set)
        {

            string strQuery = String.Empty;

            switch (set)
            {
                case NetworkSet.Testing:
                    break;

                case NetworkSet.Training:
                    strQuery = String.Format("[{0}] = FALSE", ColumnValidationId);
                    break;

                case NetworkSet.Validation:
                    strQuery = String.Format("[{0}] = TRUE", ColumnValidationId);
                    break;
            }


            DataRow[] query = dataTable.Select(strQuery);

            inputData = new double[query.Length][];
            outputData = new double[query.Length][];

            for (int i = 0; i < query.Length; ++i)
            {
                inputData[i] = this.NormalizeRow(query[i], networkSchema.InputColumns);
                outputData[i] = this.NormalizeRow(query[i], networkSchema.OutputColumns);
            }
        }
        #endregion

        //----------------------------------------


    }
}
