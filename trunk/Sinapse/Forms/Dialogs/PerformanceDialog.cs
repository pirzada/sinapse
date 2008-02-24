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
using System.IO;


using Sinapse.Data.Network;
using Sinapse.Data;


namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class PerformanceDialog : Form
    {

        private readonly string reportPath = Path.Combine(Application.StartupPath, @"Resources/NetworkReport.rtf");

        //----------------------------------------


        #region Constructor
        internal PerformanceDialog()
        {
            InitializeComponent();
        }

        internal PerformanceDialog(NetworkContainer networkContainer, NetworkDatabase networkDatabase)
        {
            InitializeComponent();

            this.richTextBox.Rtf = this.createReport(networkContainer, networkDatabase);
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
        private string createReport(NetworkContainer network, NetworkDatabase database)
        {
            DataRow[] selectedRows = database.DataTable.Select(NetworkDatabase.ColumnRoleId + "='" + (ushort)NetworkSet.Testing + "'");

            if (selectedRows.Length == 0)
                return "No records found";


            StringBuilder strBuilder = new StringBuilder(this.getBaseReportText());

            strBuilder.Replace("[netName]",network.Name);
            strBuilder.Replace("[netLayout]", network.GetLayoutString());
            strBuilder.Replace("[netDescription]", network.Description);

            strBuilder.Replace("[setTrain]", database.TrainingSet.Count.ToString());
            strBuilder.Replace("[setValid]", database.ValidationSet.Count.ToString());
            strBuilder.Replace("[setTest]", database.TestingSet.Count.ToString());
            strBuilder.Replace("[TrainRMS]", network.Precision.ToString());
            //strBuilder.Replace("[TestRMS]", 


            //networkDatabase.CreateVectors(NetworkSet.Testing);


            #region Columns Generation
            String columns = String.Empty;
            foreach (String inputColumn in network.Schema.InputColumns)
            {
                if (network.Schema.IsCategory(inputColumn))
                {
                    columns += "*";
                }

                    columns += inputColumn + " ";
            }
            strBuilder.Replace("[schInput]", columns);

            columns = String.Empty;
            foreach (String outputColumn in network.Schema.OutputColumns)
            {
                if (network.Schema.IsCategory(outputColumn))
                {
                    columns += "*";
                }

                columns += outputColumn + " ";
            }
            strBuilder.Replace("[schOutput]", columns);

            columns = String.Empty;
            foreach (String outputColumn in network.Schema.OutputColumns)
            {
                if (network.Schema.IsCategory(outputColumn))
                {
                    columns += "*";
                }

                columns += outputColumn + " ";
            }
            strBuilder.Replace("[calOutput]", columns);
            #endregion


            #region Scores Generation
            int hitTotal = 0;// hitPositive=0, hitNegative=0;
            int errorTotal = 0;// errorPositive=0, errorNegative=0;

            foreach (DataRow row in selectedRows)
            {
                foreach (String outputColumn in network.Schema.OutputColumns)
                {
                    if (row[outputColumn].Equals(row[NetworkDatabase.ColumnComputedPrefix + outputColumn]))
                    {
                        hitTotal++;
                    }
                    else
                    {
                        errorTotal++;
                    }
                }
            }

            strBuilder.Replace("[rHits]", hitTotal.ToString());
            strBuilder.Replace("[rErrors]", errorTotal.ToString());
            strBuilder.Replace("[rHitsPerc]", (hitTotal / selectedRows.Length).ToString("N3"));
            strBuilder.Replace("[rErrorsPerc]", (errorTotal / selectedRows.Length).ToString("N3"));

            #endregion


      /* 
            #region Results Generation
            foreach (DataRow dataRow in 
            #endregion
       */


            return strBuilder.ToString();
        }

        private string getBaseReportText()
        {
            TextReader textReader = null;
            String baseReport = null;

            try
            {
                textReader = new StreamReader(this.reportPath, Encoding.Default);
            }
            catch (Exception ex)
            {
                HistoryListener.Write("Error creating the report");
                MessageBox.Show(ex.Message, "Error creating the report");
#if DEBUG
                throw ex;
#endif
            }
            finally
            {
                if (textReader != null)
                {
                    baseReport = textReader.ReadToEnd();
                    textReader.Close();
                }
            }

            return baseReport; 
        }
        #endregion






    }
}