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
    class NetworkData
    {

        private NetworkSchema networkSchema;
        private DataTable dataTable;


        //----------------------------------------

        #region Constructor & Destructor
        public NetworkData(NetworkSchema schema, DataTable dataTable)
        {
            this.networkSchema = schema;
            this.dataTable = dataTable;

            this.networkSchema.DataCategories.AutodetectCaptions(dataTable);
            this.networkSchema.DataRanges.AutodetectRanges(dataTable);
        }

        public NetworkData(NetworkSchema schema)
        {
            this.networkSchema = schema;
            this.dataTable = new DataTable();

            DataColumn column;

            foreach (String colName in this.networkSchema.AllColumns)
            {
                column = new DataColumn(colName, typeof(string));
                column.AllowDBNull = false;
                column.DefaultValue = String.Empty;
                dataTable.Columns.Add(column);
            }
        }
        #endregion

        //----------------------------------------

        #region Properties
        internal NetworkSchema NetworkSchema
        {
            get { return networkSchema; }
        }

        internal DataTable DataTable
        {
            get { return dataTable; }
        }
        #endregion

        //----------------------------------------

        #region Public Methods
        internal void CreateVectors(out double[][] inputData, out double[][] outputData)
        {
            inputData = new double[dataTable.Rows.Count][];
            outputData = new double[dataTable.Rows.Count][];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                inputData[i] = this.NormalizeRow(dataTable.Rows[i], networkSchema.InputColumns);
                outputData[i] = this.NormalizeRow(dataTable.Rows[i], networkSchema.OutputColumns);
            }
        }
        #endregion

        //----------------------------------------

        #region Private Methods
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


    }
}
