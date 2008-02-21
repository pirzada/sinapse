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


namespace Sinapse.Data.Network
{
    [Serializable]
    internal sealed class NetworkRanges
    {

        private DataTable dataRanges;
        private DoubleRange activationFunctionRange;
     

        //---------------------------------------------

        #region Constructor
        public NetworkRanges(string[] allColumns, string[] stringColumns, DoubleRange activationFunctionRange)
        {
            this.dataRanges = new DataTable("Data Ranges");

            DataColumn dataColumn;
            
            dataColumn = new DataColumn("Column");
            dataColumn.DataType = typeof(string);
            dataColumn.AllowDBNull = false;
            dataColumn.DefaultValue = String.Empty;
            dataColumn.ReadOnly = true;
            this.dataRanges.Columns.Add(dataColumn);
            this.dataRanges.PrimaryKey = new DataColumn[] { dataColumn };

            dataColumn = new DataColumn("Normalize");
            dataColumn.DataType = typeof(bool);
            dataColumn.AllowDBNull = false;
            dataColumn.DefaultValue = true;
            this.dataRanges.Columns.Add(dataColumn);

            dataColumn = new DataColumn("Min");
            dataColumn.DataType = typeof(double);
            dataColumn.AllowDBNull = false;
            dataColumn.DefaultValue = 0D;
            this.dataRanges.Columns.Add(dataColumn);

            dataColumn = new DataColumn("Max");
            dataColumn.DataType = typeof(double);
            dataColumn.AllowDBNull = false;
            dataColumn.DefaultValue = 100D;
            this.dataRanges.Columns.Add(dataColumn);

            dataColumn = new DataColumn("String");
            dataColumn.DataType = typeof(bool);
            dataColumn.AllowDBNull = false;
            dataColumn.DefaultValue = false;
            dataColumn.ReadOnly = true;
            this.dataRanges.Columns.Add(dataColumn);

            foreach (string columnName in stringColumns)
            {
                this.dataRanges.Rows.Add(columnName, true, 0, 100, true);
            }

            foreach (string columnName in allColumns)
            {
                if (!this.dataRanges.Rows.Contains(columnName))
                    this.dataRanges.Rows.Add(columnName, true, 0, 100, false);
            }
        }

        public NetworkRanges(string[] allColumns, string[] stringColumns)
            : this(allColumns, stringColumns, new DoubleRange(0,1))
        {
        }
        #endregion

        //---------------------------------------------

        #region Properties
        public DataTable Table
        {
            get { return dataRanges; }
        }

        public DoubleRange ActivationFunctionRange
        {
            get { return activationFunctionRange; }
            set { activationFunctionRange = value; }
        }
        #endregion

        //---------------------------------------------

        #region Public Methods
        public DoubleRange GetRange(string column)
        {
            DataRow row = this.dataRanges.Rows.Find(column);
            double min;
            double max;

            if (row["Normalize"].Equals(true))
            {
                min = (double)row["Min"];
                max = (double)row["Max"];
            }
            else
            {
                min = Double.MinValue;
                max = Double.MaxValue;
            }
            return new DoubleRange(min, max);
        }

        public void AutodetectRanges(DataTable dataTable)
        {
            foreach (DataRow row in this.dataRanges.Rows)
            {
                string columnName = (string)row["Column"];

                if ((bool)row["String"])
                {
                    row["Max"] = dataTable.DefaultView.ToTable(true, columnName).Rows.Count;
                    row["Min"] = 0;
                }
                else
                {
                    row["Max"] = dataTable.Compute(String.Format("MAX([{0}])", columnName), "");
                    row["Min"] = dataTable.Compute(String.Format("MIN([{0}])", columnName), "");
                }
            }
        }
        #endregion

    }
}
