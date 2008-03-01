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
using System.Diagnostics;
using System.IO;


using AForge.Neuro;

using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Utils.HtmlReport;

                        
namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class PerformanceDialog : Form
    {

        private readonly string reportPath = Path.Combine(Application.StartupPath, @"Resources/Templates/NetworkReport.htm");

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

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.webBrowser.ShowPrintPreviewDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog(this);
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            TextWriter textWriter = null;

            try
            {
                textWriter = new StreamWriter(saveFileDialog.FileName, false, Encoding.Default);
                textWriter.Write(this.webBrowser.DocumentText);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving testing report: " + ex.Message);
#if DEBUG
                throw ex;
#endif
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        internal string CreateReport()
        {
            
            DataRow[] selectedRows = this.m_database.DataTable.Select(
                String.Format("[{0}] = {1}", NetworkDatabase.ColumnRoleId, (ushort)NetworkSet.Testing));

            if (selectedRows.Length == 0)
                return "No records found!";

            int testingItems = selectedRows.Length * this.m_database.Schema.OutputColumns.Length;
            


            StringBuilder strBuilder = new StringBuilder(this.getBaseReportText());

            strBuilder.Replace("[netName]", m_network.Name);
            strBuilder.Replace("[netType]", m_network.Type);
            strBuilder.Replace("[netLayout]", m_network.Layout);
            strBuilder.Replace("[netDescription]", m_network.Description);

            strBuilder.Replace("[setTrain]", m_database.TrainingSet.Count.ToString());
            strBuilder.Replace("[setValid]", m_database.ValidationSet.Count.ToString());
            strBuilder.Replace("[setTest]", m_database.TestingSet.Count.ToString());
            strBuilder.Replace("[testItems]", testingItems.ToString());
            strBuilder.Replace("[TrainRMS]", m_network.Precision.ToString());


            strBuilder.Replace("[schInput]", generateColumns(m_network.Schema.InputColumns, true));
            strBuilder.Replace("[schOutput]", generateColumns(m_network.Schema.OutputColumns, true));

            strBuilder.Replace("[testResults]", generateResults());

            strBuilder.Replace("[netWeights]", generateWeights());

            strBuilder.Replace("[year]", DateTime.Now.Year.ToString());

                            

            #region Scores Generation
            int hitTotal = 0, hitPositive=0, hitNegative=0;
            int errorTotal = 0, errorPositive=0, errorNegative=0;
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

            finalScore = totalScore / testingItems;

            strBuilder.Replace("[totalScore]", totalScore.ToString("N6"));
            strBuilder.Replace("[finalScore]", finalScore.ToString("N6"));

            strBuilder.Replace("[rHits]", hitTotal.ToString("D3"));
            strBuilder.Replace("[rHitsPerc]", (hitTotal / testingItems).ToString("(000.00%)"));

            strBuilder.Replace("[rErrors]", errorTotal.ToString("D3"));
            strBuilder.Replace("[rErrorsPerc]", (errorTotal / testingItems).ToString("(000.00%)"));
            
            if (hitTotal != 0)
            {
                strBuilder.Replace("[rHitsP]", hitPositive.ToString("D3"));
                strBuilder.Replace("[rHitsN]", hitNegative.ToString("D3"));
                strBuilder.Replace("[rHitsPPerc]", (hitPositive / hitTotal).ToString("(000.00%)"));
                strBuilder.Replace("[rHitsNPerc]", (hitNegative / hitTotal).ToString("(000.00%)"));
            }
            else
            {
                strBuilder.Replace("[rHitsP]", "-");
                strBuilder.Replace("[rHitsN]", "-");
                strBuilder.Replace("[rHitsPPerc]", String.Empty);
                strBuilder.Replace("[rHitsNPerc]", String.Empty);
            }

            if (errorTotal != 0)
            {
                strBuilder.Replace("[rErrorsP]", errorPositive.ToString("D3"));
                strBuilder.Replace("[rErrorsN]", errorNegative.ToString("D3"));
                strBuilder.Replace("[rErrorsPPerc]", (errorPositive / errorTotal).ToString("(000.00%)"));
                strBuilder.Replace("[rErrorsNPerc]", (errorNegative / errorTotal).ToString("(000.00%)"));
            }
            else
            {
                strBuilder.Replace("[rErrorsP]", "-");
                strBuilder.Replace("[rErrorsN]", "-");
                strBuilder.Replace("[rErrorsPPerc]", String.Empty);
                strBuilder.Replace("[rErrorsNPerc]", String.Empty);
            }
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


        private string generateResults()
        {
            HTMLReport report = new HTMLReport();


            report.ReportTitle = "Network Test Performance Table";
            report.ReportFont = "Arial";
            report.IncludeTotal = true;
            report.ReportSource = m_database.TestingSet.ToTable();
           

           // Section section = new Section();

            foreach (string inputCol in this.m_database.Schema.InputColumns)
            {
                report.ReportFields.Add(new Field(inputCol, inputCol, 0, HtmlAlign.Center));
            }

            foreach (string outputCol in this.m_database.Schema.OutputColumns)
            {
                Field field;

                field = new Field(outputCol, outputCol, HtmlAlign.Center);
                field.HeaderBackColor = Color.LightSteelBlue;
                //field.FormatString = "+0.0000;-0.0000";
                report.ReportFields.Add(field);

                field = new Field(NetworkDatabase.ColumnComputedPrefix + outputCol, "Network Answer", 0, HtmlAlign.Center);
                field.HeaderBackColor = Color.LightSteelBlue;
                field.FormatString = "+0.0000;-0.0000";
                report.ReportFields.Add(field);
                
                field = new Field(NetworkDatabase.ColumnDeltaPrefix + outputCol, "Network Error", 0, HtmlAlign.Center);
                field.HeaderBackColor = Color.LightSteelBlue;
                field.FormatString = "+0.0000;-0.0000";
                field.IsTotalField = true;
                report.ReportFields.Add(field);
                
            }

            return report.GenerateReport();
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