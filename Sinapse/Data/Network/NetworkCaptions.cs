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


namespace Sinapse.Data.Network
{
    [Serializable]
    internal sealed class NetworkCaptions
    {

        private readonly string ID = "ID";
        private DataSet dataCaptions;


        //---------------------------------------------


        #region Constructor
        /// <summary>
        /// Creates a new Network Data Captions database
        /// </summary>
        /// <param name="stringColumns">Array of columns names which contains categorical data.</param>
        public NetworkCaptions(string[] stringColumns)
        {
            this.dataCaptions = new DataSet("Data Categories");

            foreach (String strColumn in stringColumns)
            {
                this.dataCaptions.Tables.Add(strColumn);
            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void AutodetectCaptions(DataTable dataTable)
        {
            foreach (DataTable capTable in dataCaptions.Tables)
            {
                capTable.Clear();

                //Add a ID column
                DataColumn colId = new DataColumn(ID, typeof(int));
                colId.AutoIncrement = true;
                capTable.Columns.Add(colId);

                //Extract Unique List from data:
                capTable.Merge(dataTable.DefaultView.ToTable(true, new string[] { capTable.TableName }));

                //Set Primary Keys for faster searching:
                capTable.PrimaryKey = new DataColumn[] { colId };
            }
        }

        public int GetID(string columnName, string caption)
        {
            foreach (DataRow row in dataCaptions.Tables[columnName].Rows)
            {
                if (row[columnName].Equals(caption))
                    return (int)row[ID];
            }
            return -1;
        }

        public string GetCaption(string columnName, string id)
        {
            return GetCaption(columnName, Int32.Parse(id));
        }

        public string GetCaption(string columnName, int id)
        {
            foreach (DataRow row in dataCaptions.Tables[columnName].Rows)
            {
                if (row[ID].Equals(id))
                    return (string)row[columnName];
            }
            return String.Empty;
        }
        #endregion


    }
}
