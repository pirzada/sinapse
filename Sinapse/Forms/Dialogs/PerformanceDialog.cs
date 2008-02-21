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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;

namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class PerformanceDialog : Form
    {


        //----------------------------------------


        #region Constructor
        internal PerformanceDialog()
        {
            InitializeComponent();
        }

        internal PerformanceDialog(NetworkContainer network, DataTable dataTable)
        {
            this.richTextBox.Text = this.createReport(network, dataTable);
        }
        #endregion


        //----------------------------------------


        #region Form Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private string createReport(NetworkContainer network, DataTable dataTable)
        {
            DataRow[] selectedRows = dataTable.Select(NetworkDatabase.ColumnRoleId + "='" + (ushort)NetworkSet.Testing + "'");

            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("{\rtf\ansi {\bNetwork Testing Performance Report\b0");
            strBuilder.AppendLine("----------------------------------");
            strBuilder.AppendLine();

            strBuilder.AppendLine("\bNetwork Details:\b0");
            strBuilder.AppendLine("Name: " + network.Name);
            strBuilder.AppendLine("Description: " + network.Description);
            strBuilder.AppendLine();

            strBuilder.AppendLine("\bNetwork Schema:\b0");
            strBuilder.Append("\bInputs:\b0 ");

            foreach (string inputColumn in network.Schema.InputColumns)
            {
                strBuilder.Append(inputColumn + ", ");
            }
            strBuilder.AppendLine();

            strBuilder.Append("\bOutputs:\b0 ");
            foreach (string outputColumn in network.Schema.OutputColumns)
            {
                strBuilder.Append(outputColumn + ", ");
            }
            strBuilder.AppendLine();


            strBuilder.AppendLine("\bTest Summary\b0");
            strBuilder.AppendLine("----------------------------------");

         /*   int errorCount, matchCount;
            int falsePositives, truePositives;
            int falseNegatives, trueNegatives;
         */ 
            foreach (DataRow row in selectedRows)
            {
                foreach (string outputColumn in network.Schema.OutputColumns)
                {
          //          int targetValue, networkValue;
                  //  Math.Round((double)row[outputColumn]);
                }
            }
             


            strBuilder.AppendLine("\bTest Details\b0");
            strBuilder.AppendLine("----------------------------------");

            foreach (string outputColumn in network.Schema.OutputColumns)
            {
                strBuilder.AppendFormat("\t\b{0}\b0\tNetwork)", outputColumn);
            }
            strBuilder.AppendLine();

            foreach (DataRow row in selectedRows)
            {
                foreach (string outputColumn in network.Schema.OutputColumns)
                {
                    strBuilder.AppendFormat("\t{0}\t{1}", row[outputColumn], row[outputColumn + NetworkDatabase.ColumnComputedPrefix]);
                }
            }
            strBuilder.AppendLine("}}");

            return strBuilder.ToString();
        }
        #endregion






    }
}