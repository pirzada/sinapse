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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Sinapse.Data;
using AForge;

namespace Sinapse.Controls
{
    internal partial class NetworkDataQueryControl : Sinapse.Controls.NetworkDataControl
    {

        #region Constructor
        public NetworkDataQueryControl()
        {
            InitializeComponent();
        }
        #endregion

        //----------------------------------------

        #region Properties
        #endregion

        //----------------------------------------

        #region Public Methods
        internal void Compute(NetworkContainer neuralNetwork)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            double[] input;
            double[] output;

            foreach (DataRow row in this.m_networkData.DataTable.Rows)
            {
                input = this.m_networkData.NormalizeRow(row, this.m_networkData.Schema.InputColumns);
                output = neuralNetwork.ActivationNetwork.Compute(input);
                this.m_networkData.RevertRow(row, this.m_networkData.Schema.OutputColumns, output);
            }
        }


        /// <summary>
        /// Iterates the DataTable and validates categorical input fields
        /// </summary>
        /// <returns>Returns true in case of success, false otherwise</returns>
        internal bool ValidateInput()
        {
            bool success = true;

            foreach (DataRow row in this.m_networkData.DataTable.Rows)
            {
                foreach (string columnName in this.m_networkData.Schema.InputColumns)
                {
                    //Check if field is indeed a category
                    if (Array.IndexOf(this.m_networkData.Schema.StringColumns, columnName) >= 0)
                    {
                        string strData = (string)row[columnName];
                        if (this.m_networkData.Schema.DataCategories.GetID(columnName, strData) < 0)
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
        /// Interates the DataTable and rounds non-categorical output fields
        /// </summary>
        internal void Round()
        {
            foreach (DataRow row in this.m_networkData.DataTable.Rows)
            {
                foreach (string columnName in this.m_networkData.Schema.OutputColumns)
                {
                    //Check if field isn't a category
                    if (Array.IndexOf(this.m_networkData.Schema.StringColumns, columnName) == -1)
                    {
                        double value = Double.Parse((string)row[columnName]);
                        row[columnName] = Math.Round(value).ToString();
                    }
                }
            }
        }
        #endregion

        //----------------------------------------

        #region Private Methods
        #endregion

    }
}

