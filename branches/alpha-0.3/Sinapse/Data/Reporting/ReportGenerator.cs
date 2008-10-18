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
using System.Data;
using System.IO;
                             
using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Utils.HtmlReport;


namespace Sinapse.Data.Reporting
{

    internal sealed class ReportGenerator
    {

        private string reportPath = Path.Combine(Application.StartupPath, @"Resources/Templates/NetworkReport.htm");

        private Color[] tableHeaderColors;
        private Color[] tableBodyColors;

        private NetworkContainer m_network;
        private NetworkDatabase m_database;

        private DataRow[]  testingRows;
        private int testingItems;

        private StringBuilder reportBuilder;

      /*
        private bool includeNetworkDetails;
        private bool includeSchemaDetails;
        private bool includeTrainingDetails;
        private bool includeTestingSummary;
        private bool includeTestingDetails;
        private bool includeNormalizationInfo;
        private bool includeNetworkWeights;
       */

        //---------------------------------------------


        public ReportGenerator(NetworkContainer network, NetworkDatabase database)
        {
            
            this.m_network = network;
            this.m_database = database;


            this.testingRows = this.m_database.DataTable.Select(
                String.Format("[{0}] = {1}", NetworkDatabase.ColumnRoleId, (ushort)NetworkSet.Testing));
            this.testingItems = testingRows.Length * this.m_database.Schema.OutputColumns.Length;


            this.tableHeaderColors = new Color[]
            {
                Color.FromArgb(227,242,255),
                Color.AliceBlue
            };

            this.tableBodyColors = new Color[]
            { 
                Color.White    
            };


            if (testingRows.Length > 0)
                this.reportBuilder = new StringBuilder(this.getReportTemplate());
            else this.reportBuilder = new StringBuilder("No testing items found.");
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

        public String Report
        {
            get { return this.reportBuilder.ToString(); }
        }
        #endregion


        //---------------------------------------------


        public string GenerateAll()
        {
            this.GenerateHeader();
            this.GenerateNetworkDetails();
            this.GenerateSchemaDetails();
            this.GenerateTrainingDetails();
            this.GenerateTestingSummary();
            this.GenerateTestingDetails();
            this.GenerateNormalization();
            this.GenerateWeights();
            this.GenerateFooter();

            return this.reportBuilder.ToString();
        }

        public void Reset()
        {
            this.reportBuilder = new StringBuilder(this.getReportTemplate());
        }


        //---------------------------------------------


        #region Report Section Generation
        public void GenerateHeader()
        {
        }

        public void GenerateNetworkDetails()
        {
            reportBuilder.Replace("[netName]", m_network.Name);
            reportBuilder.Replace("[netType]", m_network.Type);
            reportBuilder.Replace("[netLayout]", m_network.Layout);
            reportBuilder.Replace("[netFunction]", m_network.Function);
            reportBuilder.Replace("[netDescription]", m_network.Description);
        }

        public void GenerateSchemaDetails()
        {
            reportBuilder.Replace("[schInput]", generateColumns(m_network.Schema.InputColumns, true));
            reportBuilder.Replace("[schOutput]", generateColumns(m_network.Schema.OutputColumns, true));
        }

        public void GenerateTrainingDetails()
        {
            reportBuilder.Replace("[trainEntryCount]", m_database.TrainingSet.Count.ToString());
            reportBuilder.Replace("[validEntryCount]", m_database.ValidationSet.Count.ToString());
            reportBuilder.Replace("[testEntryCount]", m_database.TestingSet.Count.ToString());
            reportBuilder.Replace("[testItemsCount]", testingItems.ToString());
            reportBuilder.Replace("[trainDeviation]", m_network.Precision.ToString());
        }

        public void GenerateTestingSummary()
        {
            int hitTotal = 0, hitPositive = 0, hitNegative = 0;
            int errorTotal = 0, errorPositive = 0, errorNegative = 0;
            double totalScore = 0, finalScore = 0;

            foreach (DataRow row in this.testingRows)
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

            reportBuilder.Replace("[totalDeviation]", totalScore.ToString("N6"));
            reportBuilder.Replace("[finalDeviation]", finalScore.ToString("N6"));

            reportBuilder.Replace("[hits]", hitTotal.ToString());
            reportBuilder.Replace("[hits%]", ((float)hitTotal / testingItems).ToString("0.00%"));

            reportBuilder.Replace("[errors]", errorTotal.ToString());
            reportBuilder.Replace("[errors%]", ((float)errorTotal / testingItems).ToString("0.00%"));

            if (hitTotal != 0)
            {
                reportBuilder.Replace("[hitsP]", hitPositive.ToString());
                reportBuilder.Replace("[hitsN]", hitNegative.ToString());
                reportBuilder.Replace("[hitsP%]", ((float)hitPositive / hitTotal).ToString("0.00%"));
                reportBuilder.Replace("[hitsN%]", ((float)hitNegative / hitTotal).ToString("0.00%"));
            }
            else
            {
                reportBuilder.Replace("[hitsP]", "-");
                reportBuilder.Replace("[hitsN]", "-");
                reportBuilder.Replace("[hitsP%]", String.Empty);
                reportBuilder.Replace("[hitsN%]", String.Empty);
            }

            if (errorTotal != 0)
            {
                reportBuilder.Replace("[errorsP]", errorPositive.ToString());
                reportBuilder.Replace("[errorsN]", errorNegative.ToString());
                reportBuilder.Replace("[errorsP%]", ((float)errorPositive / errorTotal).ToString("0.00%"));
                reportBuilder.Replace("[errorsN%]", ((float)errorNegative / errorTotal).ToString("0.00%"));
            }
            else
            {
                reportBuilder.Replace("[errorsP]", "-");
                reportBuilder.Replace("[errorsN]", "-");
                reportBuilder.Replace("[errorsP%]", String.Empty);
                reportBuilder.Replace("[errorsN%]", String.Empty);
            }
        }

        public void GenerateTestingDetails()
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
                field.HeaderBackColor = tableHeaderColors[colorHdIndex];
                field.BackColor = tableBodyColors[colorBgIndex];
                htmlReport.ReportFields.Add(field);
            }

            colorHdIndex = getNextIndex(tableHeaderColors, colorHdIndex);
            colorBgIndex = getNextIndex(tableBodyColors, colorBgIndex);

            foreach (string outputCol in this.m_database.Schema.OutputColumns)
            {
                Field field;

                field = new Field(outputCol, outputCol, HtmlAlign.Center);
                field.HeaderBackColor = tableHeaderColors[colorHdIndex];
                field.BackColor = tableBodyColors[colorBgIndex];
                htmlReport.ReportFields.Add(field);

                field = new Field(NetworkDatabase.ColumnComputedPrefix + outputCol, "Network Answer", 0, HtmlAlign.Center);
                field.HeaderBackColor = tableHeaderColors[colorHdIndex];
                field.BackColor = tableBodyColors[colorBgIndex];
                if (!m_database.Schema.IsCategory(outputCol))
                    field.FormatString = "+0.0000;-0.0000";
                htmlReport.ReportFields.Add(field);

                field = new Field(NetworkDatabase.ColumnDeltaPrefix + outputCol, "Network Error", 0, HtmlAlign.Center);
                field.HeaderBackColor = tableHeaderColors[colorHdIndex];
                field.BackColor = tableBodyColors[colorBgIndex];
                field.FormatString = "+0.0000;-0.0000";
                field.IsTotalField = true;
                htmlReport.ReportFields.Add(field);

                colorHdIndex = getNextIndex(tableHeaderColors, colorHdIndex);
                colorBgIndex = getNextIndex(tableBodyColors, colorBgIndex);

            }

            this.reportBuilder.Replace("[testTable]", htmlReport.GenerateReport());
        }

        public void GenerateNormalization()
        {
            HTMLReport htmlReport = new HTMLReport();


            htmlReport.ReportTitle = "Data Ranges";
            htmlReport.ReportFont = "Arial";
            htmlReport.ValuesFont = "Courier New";
            htmlReport.IncludeTitle = false;

            htmlReport.ReportSource = m_database.Schema.DataRanges.Table;


            htmlReport.ReportFields.Add(new Field("Column", "Label", tableHeaderColors[0]));
            htmlReport.ReportFields.Add(new Field("Normalize", "Normalize", tableHeaderColors[0]));
            htmlReport.ReportFields.Add(new Field("Min", "Min", tableHeaderColors[0]));
            htmlReport.ReportFields.Add(new Field("Max", "Max", tableHeaderColors[0]));
            htmlReport.ReportFields.Add(new Field("String", "Category", tableHeaderColors[0]));


            reportBuilder.Replace("[netRanges]", htmlReport.GenerateReport());


            if (m_network.Schema.DataRanges.ActivationFunctionRange != null)
            {
                reportBuilder.Replace("[funcRange]", String.Format("{0}~{1}",
                    m_network.Schema.DataRanges.ActivationFunctionRange.Min,
                    m_network.Schema.DataRanges.ActivationFunctionRange.Max));
            }
            else reportBuilder.Replace("[funcRange]", "-");


        }

        public void GenerateWeights()
        {
            StringBuilder weightBuilder = new StringBuilder();

            for (int i = 0; i < m_network.ActivationNetwork.LayersCount; ++i)
            {
                weightBuilder.AppendFormat("&nbsp;<b><i>Layer #{0}</i></b><br>", i + 1);

                for (int j = 0; j < m_network.ActivationNetwork[i].NeuronsCount; ++j)
                {
                    
                    weightBuilder.AppendFormat("&nbsp;&nbsp;<b>Neuron #{0}:</b><br>", j + 1);
                    //weightBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;<i>Function: {0}</i>", (m_network.ActivationNetwork[i][j] as AForge.Neuro.ActivationNeuron).ActivationFunction.GetType().Name);
                    weightBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;<i>Threshold (Bias): {0}</i><br>",(m_network.ActivationNetwork[i][j] as AForge.Neuro.ActivationNeuron).Threshold);


                    for (int k = 0; k < m_network.ActivationNetwork[i][j].InputsCount; ++k)
                    {
                        weightBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;[{0}]: {1}<br>", k, m_network.ActivationNetwork[i][j][k]);
                    }

                    weightBuilder.Append("<br>");
                }

                weightBuilder.Append("<br>");
            }

            reportBuilder.Replace("[netWeights]", weightBuilder.ToString());
        }

        public void GenerateFooter()
        {
            reportBuilder.Replace("[year]", DateTime.Now.Year.ToString());
        }
        #endregion


        //---------------------------------------------


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
                throw;
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
