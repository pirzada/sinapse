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


using AForge.Neuro;

using Sinapse.Data.Network;
using Sinapse.Data;


namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class PerformanceDialog : Form
    {

        private readonly string reportPath = Path.Combine(Application.StartupPath, @"Resources/NetworkReport.htm");

        private NetworkContainer m_network;
        private NetworkDatabase m_database;

        //----------------------------------------


        #region Constructor
        internal PerformanceDialog(NetworkContainer networkContainer, NetworkDatabase networkDatabase)
        {
            this.m_database = networkDatabase;
            this.m_network = networkContainer;
            
            this.InitializeComponent();
            
            this.webBrowser.DocumentText = this.CreateReport();
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
            this.webBrowser.ShowPrintDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.webBrowser.ShowSaveAsDialog();
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        internal string CreateReport()
        {
            DataRow[] selectedRows = m_database.DataTable.Select(NetworkDatabase.ColumnRoleId + "='" + (ushort)NetworkSet.Testing + "'");

            if (selectedRows.Length == 0)
                return "No records found!";


            StringBuilder strBuilder = new StringBuilder(this.getBaseReportText());

            strBuilder.Replace("[netName]", m_network.Name);
            strBuilder.Replace("[netType]", m_network.Type);
            strBuilder.Replace("[netLayout]", m_network.Layout);
            strBuilder.Replace("[netDescription]", m_network.Description);

            strBuilder.Replace("[setTrain]", m_database.TrainingSet.Count.ToString());
            strBuilder.Replace("[setValid]", m_database.ValidationSet.Count.ToString());
            strBuilder.Replace("[setTest]", m_database.TestingSet.Count.ToString());
            strBuilder.Replace("[TrainRMS]", m_network.Precision.ToString());
            strBuilder.Replace("[totalScore]", m_network.Score.ToString());
            strBuilder.Replace("[finalScore]", m_network.Score.ToString());


            strBuilder.Replace("[schInput]", generateColumns(m_network.Schema.InputColumns, true));
            strBuilder.Replace("[schOutput]", generateColumns(m_network.Schema.OutputColumns, true));


            strBuilder.Replace("[testResults]", generateResults(selectedRows));
            strBuilder.Replace("[netWeights]", generateWeights());

            strBuilder.Replace("[year]", DateTime.Now.Year.ToString());



            #region Scores Generation
            int hitTotal = 0;// hitPositive=0, hitNegative=0;
            int errorTotal = 0;// errorPositive=0, errorNegative=0;

            foreach (DataRow row in selectedRows)
            {
                foreach (String outputColumn in m_network.Schema.OutputColumns)
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



            return strBuilder.ToString();
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private string generateColumns(String[] columnArray, bool markCaptions)
        {
            String columns = String.Empty;

            foreach (String col in columnArray)
            {
                if (markCaptions && m_network.Schema.IsCategory(col))
                {
                    columns += "*";
                }

                columns += col;
                columns += ", ";
            }

            return columns;
        }


        private string generateWeights()
        {
            StringBuilder weigthBuilder = new StringBuilder();

            for (int i = 0; i < m_network.ActivationNetwork.LayersCount; ++i)
            {
                weigthBuilder.AppendFormat("&nbsp;<b><i>Layer #{0}</i></b><br>", i);

                for (int j = 0; j < m_network.ActivationNetwork[i].NeuronsCount; ++j)
                {
                    weigthBuilder.AppendFormat("&nbsp;&nbsp;<b>Neuron #{0}:</b><br>", j);

                    for (int k = 0; k < m_network.ActivationNetwork[i][j].InputsCount; k++)
                    {
                        weigthBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;[{0}]: {1}<br>", k, m_network.ActivationNetwork[i][j][k]);
                    }
                    weigthBuilder.Append("<br>");
                }
                weigthBuilder.Append("<br>");
            }
            return weigthBuilder.ToString();
        }


        private string generateScores()
        {
            return String.Empty;
        }


        private string generateResults(DataRow[] selectedRows)
        {
            StringBuilder resultBuilder = new StringBuilder();

            resultBuilder.Append("<table>");

            foreach (string inputCol in m_database.Schema.InputColumns)
            {
                resultBuilder.AppendFormat("<td nowrap>{0}</td>", inputCol);
            }

            foreach (string outputCol in m_database.Schema.OutputColumns)
            {
                resultBuilder.AppendFormat("<td nowrap>{0}</td>", outputCol);
            }

            foreach (string outputCol in m_database.Schema.OutputColumns)
            {
                resultBuilder.AppendFormat("<td nowrap><b>{0}</b></td>", outputCol);
                resultBuilder.Append("<td nowrap><b>Delta</b></td>");
            }

            foreach (DataRow row in selectedRows)
            {
                resultBuilder.Append("<tr>");
                foreach (string inputCol in m_database.Schema.InputColumns)
                {
                    resultBuilder.Append("<td nowrap>");
                    resultBuilder.Append(Double.Parse((string)row[inputCol]).ToString("G3"));
                    resultBuilder.Append("</td>");
                }
                foreach (string outputCol in m_database.Schema.OutputColumns)
                {
                    resultBuilder.Append("<td nowrap>");
                    resultBuilder.Append(Double.Parse((string)row[outputCol]).ToString("G3"));
                    resultBuilder.Append("</td>");
                }
                foreach (string outputCol in m_database.Schema.OutputColumns)
                {
                    resultBuilder.Append("<td nowrap>");
                    resultBuilder.Append(Double.Parse((string)row[NetworkDatabase.ColumnComputedPrefix + outputCol]).ToString("G3"));
                    resultBuilder.Append("</td>");
                    resultBuilder.Append("<td nowrap><b>");
                    resultBuilder.Append(Double.Parse((string)row[NetworkDatabase.ColumnDeltaPrefix + outputCol]).ToString("G3"));
                    resultBuilder.Append("</b></td>");
                }
                resultBuilder.Append("</tr>");

            }

            resultBuilder.Append("</table>");

            return resultBuilder.ToString();
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
                MessageBox.Show(ex.Message, "Error");
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