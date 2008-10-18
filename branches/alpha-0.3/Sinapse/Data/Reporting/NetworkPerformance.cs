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
using System.Data;
using System.Text;

using Sinapse.Data.Network;

namespace Sinapse.Data.Reporting
{
    internal sealed class NetworkPerformance
    {

        private NetworkContainer m_network;
        private NetworkDatabase m_database;

        private DataTable m_scoreTable;


        //---------------------------------------------


        #region Constructor
        public NetworkPerformance(NetworkContainer network, NetworkDatabase database)
        {
            this.m_network = network;
            this.m_database = database;

            this.createTable();
            this.generate();
        }
        #endregion


        //---------------------------------------------


        #region Properties
        #endregion


        //---------------------------------------------


        #region Public Methods
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void createTable()
        {
            m_scoreTable = new DataTable("Network Performance");

            DataColumn col;
            col = new DataColumn("Name", typeof(String));
            col.AllowDBNull = false;
            col.DefaultValue = String.Empty;
            m_scoreTable.Columns.Add(col);
            m_scoreTable.PrimaryKey = new DataColumn[] { col };

            col = new DataColumn("Category", typeof(Boolean));
            col.AllowDBNull = false;
            col.DefaultValue = false;
            m_scoreTable.Columns.Add(col);

            col = new DataColumn("Hits", typeof(Int32));
            col.AllowDBNull = false;
            col.DefaultValue = 0;
            m_scoreTable.Columns.Add(col);

            col = new DataColumn("Errors", typeof(Int32));
            col.AllowDBNull = false;
            col.DefaultValue = 0;
            m_scoreTable.Columns.Add(col);

        }

        private void generate()
        {

            foreach (string inputColumn in this.m_database.Schema.InputColumns)
            {
                
            }
            
            
            int hitTotal = 0, hitPositive = 0, hitNegative = 0;
            int errorTotal = 0, errorPositive = 0, errorNegative = 0;
            double totalScore = 0, finalScore = 0;

            foreach (DataRow row in selectedRows)
            {
                foreach (String outputColumn in this.m_network.Schema.OutputColumns)
                {

                    totalScore += Math.Abs(Double.Parse((string)row[NetworkDatabase.ColumnDeltaPrefix + outputColumn]));

                    if (row[outputColumn].Equals(row[NetworkDatabase.ColumnComputedPrefix + outputColumn]))
                    {
                        hitTotal++;

                        if (row[outputColumn].Equals("1"))
                        {
                            hitPositive++;
                        }
                        else
                        {
                            hitNegative++;
                        }
                    }
                    else
                    {
                        errorTotal++;

                        if (row[outputColumn].Equals("1"))
                        {
                            errorPositive++;
                        }
                        else
                        {
                            errorNegative++;
                        }
                    }

                }
            }
        }
        #endregion


        //---------------------------------------------


        #region Report Generation

        #endregion

    }
}
