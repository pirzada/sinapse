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
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.IO;
                             
using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Utils.HtmlReport;


namespace Sinapse.Data.Reporting
{

    internal sealed class ReportGenerator : Component
    {

        private string reportPath = Path.Combine(Application.StartupPath, @"Resources/Templates/NetworkReport.htm");

        private Color[] tableHeaderColors;
        private Color[] tableBodyColors;

        private NetworkContainer m_networkContainer;
        private NetworkDatabase m_networkDatabase;

        private StringBuilder reportBuilder;
        private BackgroundWorker backgroundWorker;

        private bool includeNetworkDetails;
        private bool includeTestingDetails;
        private bool includeTestingSummary;
        private bool includeTrainingDetails;
        private bool includeNormalizationInfo;
        private bool includeNetworkWeights;


        public event ProgressChangedEventHandler ProgressChanged;
        public event EventHandler ReportComplete;


        //---------------------------------------------


        public ReportGenerator(NetworkContainer network, NetworkDatabase database)
        {
            this.m_networkContainer = network;
            this.m_networkDatabase = database;

            this.reportBuilder = new StringBuilder();

            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = false;
            this.backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);

            this.tableHeaderColors = new Color[] {
                Color.FromArgb(227,242,255),
                Color.AliceBlue };

            this.tableBodyColors = new Color[] { 
                Color.White    
            };

        }


        //---------------------------------------------

        #region Properties
        public Color[] TableHeaderColors
        {
            get { return tableHeaderColors; }
            set { tableHeaderColors = value; }
        }

        public Color[] TableBodyColors
        {
            get { return tableBodyColors; }
            set { tableBodyColors = value; }
        }
        #endregion


        //---------------------------------------------


        public string Generate()
        {
            
            return this.reportBuilder.ToString();
        }

        public void GenerateAsync()
        {
            this.backgroundWorker.RunWorkerAsync();
        }


        //---------------------------------------------


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(0);

            DataRow[] selectedRows = this.m_database.DataTable.Select(
                String.Format("[{0}] = {1}", NetworkDatabase.ColumnRoleId, (ushort)NetworkSet.Testing));

            if (selectedRows.Length == 0)
            {
                e.Result = "No records found!";
                return;
            }

            int testingItems = selectedRows.Length * this.m_database.Schema.OutputColumns.Length;

            backgroundWorker.ReportProgress(10);

            StringBuilder strBuilder = new StringBuilder(this.getBaseReportText());

            strBuilder.Replace("[netName]", m_network.Name);
            strBuilder.Replace("[netType]", m_network.Type);
            strBuilder.Replace("[netLayout]", m_network.Layout);
            strBuilder.Replace("[netFunction]", m_network.Function);
            strBuilder.Replace("[netDescription]", m_network.Description);

            strBuilder.Replace("[trainEntryCount]", m_database.TrainingSet.Count.ToString());
            strBuilder.Replace("[validEntryCount]", m_database.ValidationSet.Count.ToString());
            strBuilder.Replace("[testEntryCount]", m_database.TestingSet.Count.ToString());
            strBuilder.Replace("[testItemsCount]", testingItems.ToString());
            strBuilder.Replace("[trainDeviation]", m_network.Precision.ToString());

            strBuilder.Replace("[year]", DateTime.Now.Year.ToString());

            backgroundWorker.ReportProgress(20);

            this.generateColumns();
            backgroundWorker.ReportProgress(30);

            this.generateResultTable();
            backgroundWorker.ReportProgress(50);

            this.generateRangeTable();
            backgroundWorker.ReportProgress(60);

            this.generateWeights();
            backgroundWorker.ReportProgress(70);

            this.generateScores();
            backgroundWorker.ReportProgress(80);

            e.Result = strBuilder.ToString();
        }


        //---------------------------------------------


        #region Report Section Generation
        private void generateColumns()
        {
            strBuilder.Replace("[schInput]", generateColumns(m_network.Schema.InputColumns, true));
            strBuilder.Replace("[schOutput]", generateColumns(m_network.Schema.OutputColumns, true));
        }

        private string generateColumns(String[] columnArray, bool markCaptions)
        {
            String columns = String.Empty;

            for (int i = 0; i < columnArray.Length; ++i)
            {
                if (markCaptions && m_network.Schema.IsCategory(columnArray[i]))
                    columns += "<i>";

                columns += columnArray[i];

                if (markCaptions && m_network.Schema.IsCategory(columnArray[i]))
                    columns += "</i>";

                if (i < columnArray.Length - 1)
                    columns += ", ";
            }

            return columns;
        }

        private void generateWeights()
        {
            StringBuilder weigthBuilder = new StringBuilder();

            for (int i = 0; i < m_network.ActivationNetwork.LayersCount; ++i)
            {
                weigthBuilder.AppendFormat("&nbsp;<b><i>Layer #{0}</i></b><br>", i + 1);

                for (int j = 0; j < m_network.ActivationNetwork[i].NeuronsCount; ++j)
                {
                    weigthBuilder.AppendFormat("&nbsp;&nbsp;<b>Neuron #{0}:</b><br>", j + 1);

                    for (int k = 0; k < m_network.ActivationNetwork[i][j].InputsCount; k++)
                    {
                        weigthBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;[{0}]: {1}<br>", k, m_network.ActivationNetwork[i][j][k]);
                    }
                    weigthBuilder.Append("<br>");
                }
                weigthBuilder.Append("<br>");
            }

            strBuilder.Replace("[netWeights]", weigthBuilder.ToString());
        }

        private void generateScores()
        {
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

            finalScore = totalScore / testingItems;

            strBuilder.Replace("[totalDeviation]", totalScore.ToString("N6"));
            strBuilder.Replace("[finalDeviation]", finalScore.ToString("N6"));

            strBuilder.Replace("[hits]", hitTotal.ToString());
            strBuilder.Replace("[hits%]", ((float)hitTotal / testingItems).ToString("0.00%"));

            strBuilder.Replace("[errors]", errorTotal.ToString());
            strBuilder.Replace("[errors%]", ((float)errorTotal / testingItems).ToString("0.00%"));

            if (hitTotal != 0)
            {
                strBuilder.Replace("[hitsP]", hitPositive.ToString());
                strBuilder.Replace("[hitsN]", hitNegative.ToString());
                strBuilder.Replace("[hitsP%]", ((float)hitPositive / hitTotal).ToString("0.00%"));
                strBuilder.Replace("[hitsN%]", ((float)hitNegative / hitTotal).ToString("0.00%"));
            }
            else
            {
                strBuilder.Replace("[hitsP]", "-");
                strBuilder.Replace("[hitsN]", "-");
                strBuilder.Replace("[hitsP%]", String.Empty);
                strBuilder.Replace("[hitsN%]", String.Empty);
            }

            if (errorTotal != 0)
            {
                strBuilder.Replace("[errorsP]", errorPositive.ToString());
                strBuilder.Replace("[errorsN]", errorNegative.ToString());
                strBuilder.Replace("[errorsP%]", ((float)errorPositive / errorTotal).ToString("0.00%"));
                strBuilder.Replace("[errorsN%]", ((float)errorNegative / errorTotal).ToString("0.00%"));
            }
            else
            {
                strBuilder.Replace("[errorsP]", "-");
                strBuilder.Replace("[errorsN]", "-");
                strBuilder.Replace("[errorsP%]", String.Empty);
                strBuilder.Replace("[errorsN%]", String.Empty);
            }
        }

        private void generateRangeTable()
        {
            HTMLReport htmlReport = new HTMLReport();


            htmlReport.ReportTitle = "Data Ranges";
            htmlReport.ReportFont = "Arial";
            htmlReport.ValuesFont = "Courier New";
            htmlReport.IncludeTitle = false;

            htmlReport.ReportSource = m_database.Schema.DataRanges.Table;


            htmlReport.ReportFields.Add(new Field("Column", "Label", tableHdColors[0]));
            htmlReport.ReportFields.Add(new Field("Normalize", "Normalize", tableHdColors[0]));
            htmlReport.ReportFields.Add(new Field("Min", "Min", tableHdColors[0]));
            htmlReport.ReportFields.Add(new Field("Max", "Max", tableHdColors[0]));
            htmlReport.ReportFields.Add(new Field("String", "Category", tableHdColors[0]));


            m_reportBuilder.Replace("[netRanges]", htmlReport.GenerateReport());


            if (m_network.Schema.DataRanges.ActivationFunctionRange != null)
            {
                htmlReport.Replace("[funcRange]", String.Format("{0}~{1}",
                    m_network.Schema.DataRanges.ActivationFunctionRange.Min,
                    m_network.Schema.DataRanges.ActivationFunctionRange.Max));
            }
            else htmlReport.Replace("[funcRange]", "-");


        }

        private void generateResultTable()
        {
            HTMLReport htmlReport = new HTMLReport();


            htmlReport.ReportTitle = "Network Test Performance Table";
            htmlReport.ReportFont = "Arial";
            htmlReport.ValuesFont = "Courier New";
            htmlReport.IncludeTotal = true;

            htmlReport.ReportSource = m_database.TestingSet.ToTable();

            int colorBgIndex = 0, colorHdIndex = 0;

            foreach (string inputCol in this.m_database.Schema.InputColumns)
            {
                Field field = new Field(inputCol, inputCol, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                htmlReport.ReportFields.Add(field);
            }

            colorHdIndex = getNextIndex(tableHdColors, colorHdIndex);
            colorBgIndex = getNextIndex(tableBgColors, colorBgIndex);

            foreach (string outputCol in this.m_database.Schema.OutputColumns)
            {
                Field field;

                field = new Field(outputCol, outputCol, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                htmlReport.ReportFields.Add(field);

                field = new Field(NetworkDatabase.ColumnComputedPrefix + outputCol, "Network Answer", 0, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                if (!m_database.Schema.IsCategory(outputCol))
                    field.FormatString = "+0.0000;-0.0000";
                htmlReport.ReportFields.Add(field);

                field = new Field(NetworkDatabase.ColumnDeltaPrefix + outputCol, "Network Error", 0, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                field.FormatString = "+0.0000;-0.0000";
                field.IsTotalField = true;
                htmlReport.ReportFields.Add(field);

                colorHdIndex = getNextIndex(tableHdColors, colorHdIndex);
                colorBgIndex = getNextIndex(tableBgColors, colorBgIndex);

            }

            this.reportBuilder.Replace("[testTable]", htmlReport.GenerateReport());
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private string getReportTemplate()
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
                               
        private int getNextIndex(Color[] colorArray, int index)
        {
            if (colorArray.Length > 0)
                index = (index + 1) % (colorArray.Length);
            else index = 0;

            return index;
        }
        #endregion

    }
}
