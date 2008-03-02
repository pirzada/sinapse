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

    internal sealed partial class NetworkReportDialog : Form
    {

        private readonly string reportPath = Path.Combine(Application.StartupPath, @"Resources/Templates/NetworkReport.htm");

        private Color[] tableHdColors;
        private Color[] tableBgColors;

        private NetworkContainer m_network;
        private NetworkDatabase m_database;

        //----------------------------------------


        #region Constructor
        internal NetworkReportDialog(NetworkContainer networkContainer, NetworkDatabase networkDatabase)
        {
            this.m_database = networkDatabase;
            this.m_network = networkContainer;

            this.tableHdColors = new Color[] {
             // Color.FromArgb(214, 236, 255),
                Color.FromArgb(227,242,255),
                Color.AliceBlue };

            this.tableBgColors = new Color[] { 
     //           Color.Azure, 
                Color.White    
            };

            this.InitializeComponent();

            this.webBrowser.DocumentText = this.CreateReport();
        }
        #endregion


        //----------------------------------------


        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.DesignMode)
            {
                // Set form Sizing and Location
                if (!Properties.Settings.Default.report_FirstLoad)
                {
                    this.Size = Properties.Settings.Default.report_Size;
                    this.Location = Properties.Settings.Default.report_Location;
                    this.WindowState = Properties.Settings.Default.report_WindowState;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // Save settings before closing
            Properties.Settings.Default.report_FirstLoad = false;
            Properties.Settings.Default.report_WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.report_Size = this.Size;
                Properties.Settings.Default.report_Location = this.Location;
            }
            else
            {
                Properties.Settings.Default.report_Size = this.RestoreBounds.Size;
                Properties.Settings.Default.report_Location = this.RestoreBounds.Location;
            }

        }
        #endregion


        //----------------------------------------


        #region Form Buttons
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
        public string CreateReport()
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

            strBuilder.Replace("[trainEntryCount]", m_database.TrainingSet.Count.ToString());
            strBuilder.Replace("[validEntryCount]", m_database.ValidationSet.Count.ToString());
            strBuilder.Replace("[testEntryCount]", m_database.TestingSet.Count.ToString());
            strBuilder.Replace("[testItemsCount]", testingItems.ToString());
            strBuilder.Replace("[trainDeviation]", m_network.Precision.ToString());


            strBuilder.Replace("[schInput]", generateColumns(m_network.Schema.InputColumns, true));
            strBuilder.Replace("[schOutput]", generateColumns(m_network.Schema.OutputColumns, true));

            strBuilder.Replace("[testTable]", generateResults());

            strBuilder.Replace("[netWeights]", generateWeights());

            strBuilder.Replace("[year]", DateTime.Now.Year.ToString());



            #region Scores Generation
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
            #endregion


            return strBuilder.ToString();
        }
        #endregion


        //----------------------------------------


        #region Private Methods
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
            report.ValuesFont = "Courier New";
            report.IncludeTotal = true;

            report.ReportSource = m_database.TestingSet.ToTable();


            int colorBgIndex = 0, colorHdIndex = 0;

            foreach (string inputCol in this.m_database.Schema.InputColumns)
            {
                Field field = new Field(inputCol, inputCol, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                report.ReportFields.Add(field);
            }

            colorHdIndex = getNextIndex(tableHdColors, colorHdIndex);
            colorBgIndex = getNextIndex(tableBgColors, colorBgIndex);

            foreach (string outputCol in this.m_database.Schema.OutputColumns)
            {
                Field field;

                field = new Field(outputCol, outputCol, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                report.ReportFields.Add(field);

                field = new Field(NetworkDatabase.ColumnComputedPrefix + outputCol, "Network Answer", 0, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                if (!m_database.Schema.IsCategory(outputCol))
                    field.FormatString = "+0.0000;-0.0000";
                report.ReportFields.Add(field);

                field = new Field(NetworkDatabase.ColumnDeltaPrefix + outputCol, "Network Error", 0, HtmlAlign.Center);
                field.HeaderBackColor = tableHdColors[colorHdIndex];
                field.BackColor = tableBgColors[colorBgIndex];
                field.FormatString = "+0.0000;-0.0000";
                field.IsTotalField = true;
                report.ReportFields.Add(field);

                colorHdIndex = getNextIndex(tableHdColors, colorHdIndex);
                colorBgIndex = getNextIndex(tableBgColors, colorBgIndex);

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


        private int getNextIndex(Color[] colorArray, int index)
        {
            if (colorArray.Length > 0)
                index = (index + 1) % (colorArray.Length );
            else index = 0;

            return index;
        }
        #endregion


    }
}