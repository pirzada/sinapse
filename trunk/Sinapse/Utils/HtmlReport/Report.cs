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

/*************************************************************************** 
 * Class originally developed by Ambalavanar Thirugnanam                   *
 *  http://www.codeproject.com/cs/library/HTMLReportEngine.asp             *
 *                                                                         *
 *  This project license does not apply to this library.                   *
 *  Please contact the class author for more licensing info                *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Sinapse.Utils.HtmlReport
{

    /// <summary>
    /// Holds the report details and Methods to generate report.
    /// </summary>
    public sealed class HTMLReport
    {

        #region Class level variables
        private DataTable reportSource;
        private List<Section> sections;
        private string reportTitle;
        private string newline;
        private List<Field> reportFields;
        private int iLevel = 0;
        private string gradientStyle;
        private StringBuilder htmlContent;
        public string ReportFont;
        public string ValuesFont;
        //    public Font ReportFont;
        private Hashtable totalList;
        public List<String> TotalFields;
        public bool IncludeTotal;
        public bool AutoAlignTotalFields;
        //Chart fields
        public bool IncludeChart;
        public string ChartTitle;
        public bool ChartShowAtBottom;
        public string ChartChangeOnField;
        public string ChartValueField = "Count";
        public bool ChartShowBorder;
        public string ChartLabelHeader = "Label";
        public string ChartPercentageHeader = "Percentage";
        public string ChartValueHeader = "Value";
        #endregion

        //Constructor 
        public HTMLReport()
        {
            htmlContent = new StringBuilder();
            newline = "\n";
            sections = new List<Section>();
            reportFields = new List<Field>();
            ReportFont = "Arial";
            ValuesFont = "Arial";
            //    ReportFont = new Font(FontFamily.GenericSansSerif, 8f, GraphicsUnit.Pixel);
            gradientStyle = "FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=BackColor,endColorStr=#ffffff)";
            totalList = new Hashtable();
            TotalFields = new List<string>();
        }

        #region Public Properties
        /// <summary>
        /// Gets or Sets report source as DataSet.
        /// </summary>
        public DataTable ReportSource
        {
            get { return reportSource; }
            set { reportSource = value; }
        }

        /// <summary>
        /// Gets or Sets HTMLReport sections as ArrayList. Contains of objects of Section class.
        /// </summary>
        public List<Section> Sections
        {
            get { return sections; }
            set { sections = value; }
        }

        /// <summary>
        /// Gets or Sets HTMLReport title as string.
        /// </summary>
        public string ReportTitle
        {
            get { return reportTitle; }
            set { reportTitle = value; }
        }

        /// <summary>
        /// Gets or Sets report fields as ArrayList. Contains objects of Field class.
        /// </summary>
        public List<Field> ReportFields
        {
            get { return reportFields; }
            set { reportFields = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generates the HTMLReport Content for the given ReportSource.
        /// </summary>
        /// <returns>HTMLReport String</returns>
        public string GenerateReport()
        {
            foreach (Field fld in this.ReportFields)
            {
                if (!this.TotalFields.Contains(fld.FieldName) && fld.IsTotalField)
                {
                    TotalFields.Add(fld.FieldName);
                }
            }

            WriteTitle();
            WriteSections();
            WriteFooter();
            return htmlContent.ToString();
        }

        /// <summary>
        /// Generates and Saves the report into a file.
        /// </summary>
        /// <param name="fileName">HTMLReport HTMLReport file name</param>
        /// <returns>On success returns true</returns>
        public bool SaveReport(string fileName)
        {
            try
            {
                GenerateReport();
                StreamWriter sw = new StreamWriter(fileName);
                sw.Write(htmlContent.ToString());
                sw.Flush();
                sw.Close();
                return true;
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.WriteLine(exp.Message);
                return false;
            }
        }

        /// <summary>
        /// Writes CSS and HTMLReport title.
        /// </summary>
        private void WriteTitle()
        {
            htmlContent.Append("<HTML><HEAD>");
            htmlContent.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            htmlContent.Append("<TITLE>Report - " + reportTitle + "</TITLE></HEAD>" + newline);
            htmlContent.Append("<STYLE>" + newline);
            htmlContent.Append(" .TableStyle { border-collapse: collapse } " + newline);
            htmlContent.Append(" .TitleStyle { font-family: " + ReportFont + "; font-size:14pt } " + newline);
            htmlContent.Append(" .SectionHeader {font-family: " + ReportFont + "; font-size:9pt } " + newline);
            htmlContent.Append(" .DetailHeader {font-family: " + ReportFont + "; font-size:8pt } " + newline);
            htmlContent.Append(" .DetailData  {font-family: " + ValuesFont + "; font-size:8pt } " + newline);
            htmlContent.Append(" .ColumnHeaderStyle  {font-family: " + ReportFont + "; font-size:8pt; border-style:outset; border-width:1} " + newline);
            htmlContent.Append("</STYLE>" + newline);
            htmlContent.Append("<BODY TOPMARGIN=0 LEFTMARGIN=0 RIGHTMARGIN=0 BOTTOMMARGIN=0>" + newline);
            htmlContent.Append("<TABLE Width='100%' style='FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=#a9d4ff,endColorStr=#ffffff)' Cellpadding=5><TR><TD>");
            htmlContent.Append("<font face='" + ReportFont + "' size=6>" + ReportTitle + "</font>");
            htmlContent.Append("</TD></TR></TABLE>" + newline);
        }

        /// <summary>
        /// Generates all section contents
        /// </summary>
        private void WriteSections()
        {
            if (sections.Count == 0)
            {
                Section dummySection = new Section();
                dummySection.Level = 5;
                dummySection.ChartChangeOnField = this.ChartChangeOnField;
                dummySection.ChartLabelHeader = this.ChartLabelHeader;
                dummySection.ChartPercentageHeader = this.ChartPercentageHeader;
                dummySection.ChartShowAtBottom = this.ChartShowAtBottom;
                dummySection.ChartShowBorder = this.ChartShowAtBottom;
                dummySection.ChartTitle = this.ChartTitle;
                dummySection.ChartValueField = this.ChartValueField;
                dummySection.ChartValueHeader = this.ChartValueHeader;
                dummySection.IncludeChart = this.IncludeChart;
                htmlContent.Append("<TABLE Width='100%' class='TableStyle'  cellspacing=0 cellpadding=5 border=1>" + newline); //border=0
                if (this.IncludeChart && !this.ChartShowAtBottom)
                    GenerateBarChart("", dummySection);
                Hashtable total = WriteSectionDetail(null, "");
                if (this.IncludeTotal)
                {
                    dummySection.IncludeTotal = true;
                    WriteSectionFooter(dummySection, total);
                    //WriteSectionFooter(dummySection, "");
                }
                if (this.IncludeChart && this.ChartShowAtBottom)
                    GenerateBarChart("", dummySection);
                htmlContent.Append("</TABLE></BODY></HTML>");
            }
            foreach (Section section in sections)
            {
                iLevel = 0;
                htmlContent.Append("<TABLE Width='100%' class='TableStyle'  cellspacing=0 cellpadding=5 border=1>" + newline); //border=0
                RecurseSections(section, "");
                htmlContent.Append("</TABLE></BODY></HTML>");
            }
        }

        /// <summary>
        /// Writes the section header information.
        /// </summary>
        /// <param name="section">The section details as Section object</param>
        /// <param name="sectionValue">section group field data</param>
        private void WriteSectionHeader(Section section, string sectionValue)
        {
            string bg = section.backColor;
            string style = " style=\"font-family: " + ReportFont + "; font-weight:bold; font-size:";
            style += getFontSize(section.Level);
            if (section.GradientBackground)
                style += "; " + gradientStyle.Replace("BackColor", bg) + "\"";
            else style += "\" bgcolor='" + bg + "' ";

            htmlContent.Append("<TR><TD colspan='" + this.ReportFields.Count + "' " + style + " >");
            htmlContent.Append(section.TitlePrefix + sectionValue);
            htmlContent.Append("</TD></TR>" + newline);
        }

        /// <summary>
        /// Method to write Chart and Section data information
        /// </summary>
        /// <param name="section">the section details</param>
        /// <param name="criteria">the section selection criteria</param>
        private Hashtable WriteSectionDetail(Section section, string criteria)
        {
            Hashtable totalArray = new Hashtable();
            totalArray = PrepareData(totalArray);
            if (section == null)
            {
                section = new Section();
            }
            try
            {
                //Draw DetailHeader
                htmlContent.Append("<TR>" + newline);
                string cellParams = String.Empty;

                foreach (Field field in this.reportFields)
                {
                    cellParams = " bgcolor='" + Util.GetHTMLColorString(field.HeaderBackColor) + "' ";
                    if (field.Width != 0)
                        cellParams += " WIDTH=" + field.Width + " ";
                    cellParams += " ALIGN='" + field.Alignment.ToString() + "' ";
                    htmlContent.Append("  <TD " + cellParams + " class='ColumnHeaderStyle'><b>" + field.HeaderName + "</b></TD>" + newline);
                }
                htmlContent.Append("</TR>" + newline);

                //Draw Data
                if (criteria == null || criteria.Trim() == String.Empty)
                    criteria = String.Empty;
                else
                    criteria = criteria.Substring(3);


                foreach (DataRow dr in reportSource.Select(criteria))
                {
                    htmlContent.Append("<TR>" + newline);
                    foreach (Field field in this.reportFields)
                    {
                        cellParams = " bgcolor='" + Util.GetHTMLColorString(field.BackColor) + "' ";
                        if (field.Width != 0)
                            cellParams += " WIDTH=" + field.Width + " ";

                        //if total field, by default set to RIGHT align.
                        //if(this.TotalFields.Contains(field.FieldName))
                        if (AutoAlignTotalFields && field.IsTotalField)
                            cellParams += " align='right' ";
                        cellParams += " ALIGN='" + field.Alignment.ToString() + "' ";
                        htmlContent.Append("  <TD " + cellParams + " VALIGN='top' class='DetailData'>");

                        //Add the field value to the html table
                        if (dr[field.FieldName] is String && field.FormatString.Length > 0)
                        {
                            double value;
                            Double.TryParse((string)dr[field.FieldName], out value);
                            htmlContent.Append(value.ToString(field.FormatString));
                        }
                        else
                        {
                            htmlContent.Append(dr[field.FieldName].ToString());
                        }


                        htmlContent.Append("</TD>" + newline);
                    }

                    htmlContent.Append("</TR>" + newline);
                    try
                    {
                        foreach (string totalField in TotalFields)
                        {
                            totalArray[totalField] = float.Parse(totalArray[totalField].ToString()) +
                                float.Parse(dr[totalField].ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        //TODO: show error message at total field
                        htmlContent.Append("<p align=CENTER><b>Unable to generate report.<br>" + exp.Message + "</b></p>");
                    }
                }
            }
            catch (Exception err)
            {
                htmlContent.Append("<p align=CENTER><b>Unable to generate report.<br>" + err.Message + "</b></p>");
            }
            return totalArray;
        }

        /// <summary>
        /// Method to write section footer information.
        /// </summary>
        /// <param name="section">The section details</param>
        private void WriteSectionFooter(Section section, Hashtable totalArray)
        {
            string cellParams = "";
            //Include Total row if specified.
            if (section.IncludeTotal)
            {
                htmlContent.Append("<TR>" + newline);
                foreach (Field field in this.reportFields)
                {
                    cellParams = "";
                    if (field.Width != 0)
                        cellParams += " WIDTH=" + field.Width + " ";
                    cellParams += " style=\"font-family: " + ValuesFont + "; font-size:";
                    cellParams += getFontSize(section.Level - 1/*+1*/) + "; border-style:outline; border-width:1 \" ";
                    if (totalArray.Contains(field.FieldName))
                    {
                        htmlContent.Append("  <TD " + cellParams + " align='"+ field.Alignment.ToString() + "'><u>" + Double.Parse(totalArray[field.FieldName].ToString()).ToString(field.FormatString) + "</u></TD> " + newline);
                    }
                    else
                    {
                        htmlContent.Append("  <TD " + cellParams + ">&nbsp;</TD>" + newline);
                    }
                }
                htmlContent.Append("</TR>");
            }
        }


        /// <summary>
        /// Writes the HTMLReport closing tags
        /// </summary>
        private void WriteFooter()
        {
            htmlContent.Append("<BR>");
        }


        /// <summary>
        /// A recursive funtion to write all the section headers, details and footer content.
        /// </summary>
        /// <param name="section">the section details</param>
        /// <param name="criteria">section data selection criteria</param>
        private Hashtable RecurseSections(Section section, string criteria)
        {
            iLevel++;
            section.Level = iLevel;
            ArrayList result = GetDistinctValues(this.reportSource, section.GroupBy, criteria);
            Hashtable ht = new Hashtable();
            PrepareData(ht);
            foreach (object obj in result)
            {
                Hashtable sectionTotal = new Hashtable();
                PrepareData(sectionTotal);
                //Construct critiera string to select data for the current section
                string tcriteria = criteria + "and " + section.GroupBy + "='" + obj.ToString().Replace("'", "''") + "' ";
                WriteSectionHeader(section, obj.ToString());
                //If user not specified to display chart at bottom of the section
                if (section.IncludeChart && !section.ChartShowAtBottom && !section.isChartCreated)
                    GenerateBarChart(tcriteria, section);
                if (section.SubSection != null)
                {
                    sectionTotal = RecurseSections(section.SubSection, tcriteria);
                    iLevel--;
                }
                else
                {
                    sectionTotal = WriteSectionDetail(section, tcriteria);
                    ht = AccumulateTotal(ht, sectionTotal);
                }
                //If user specified to display chart at bottom of the section
                WriteSectionFooter(section, sectionTotal);
                if (section.IncludeChart && section.ChartShowAtBottom && !section.isChartCreated)
                    GenerateBarChart(tcriteria, section);
                section.isChartCreated = false;
            }
            if (section.Level < 2)
                htmlContent.Append("<TR><TD colspan='" + this.ReportFields.Count + "'>&nbsp;</TD></TR>");

            return ht;
        }

        /// <summary>
        /// Method to generate BarChart
        /// </summary>
        /// <param name="criteria">Section data selection criteria</param>
        /// <param name="changeOnField">Y-Axis data field</param>
        /// <param name="valueField">X-Axis data field (Send "count" as value for reporting record count)</param>
        /// <param name="showBorder">Enable or disable chart border</param>
        private void GenerateBarChart(string criteria, Section section)
        {
            string changeOnField = section.ChartChangeOnField;
            string valueField = section.ChartValueField;
            bool showBorder = section.ChartShowBorder;
            section.isChartCreated = true;
            string[] colors = { "#ff0000", "#ffff00", "#ff00ff", "#00ff00", "#00ffff", "#0000ff", "#ff0f0f", "#f0f000", "#ff00f0", "#0f00f0" };
            htmlContent.Append("<TR><TD colspan='" + this.ReportFields.Count + "' align=CENTER>" + newline);
            htmlContent.Append("<!--- Chart Table starts here -->" + newline);
            if (showBorder)
            {
                htmlContent.Append("<TABLE cellpadding=4 cellspacing=1 border=0 bgcolor='#f5f5f5' width=550> ");
            }
            else
            {
                htmlContent.Append("<TABLE border=0 cellspacing=5 width=550>");
            }
            if (criteria.ToUpper().StartsWith(" AND "))
            {
                criteria = criteria.Substring(3);
            }
            try
            {
                ArrayList result = GetDistinctValuesForChart(this.reportSource, criteria, changeOnField, valueField);
                ArrayList labels = (ArrayList)result[0];
                ArrayList values = (ArrayList)result[1];
                float total = 0;
                foreach (Object obj in values)
                {
                    total += float.Parse(obj.ToString());
                }
                int ChartWidth = 300;

                string barTitle = "<TR><TD class='DetailHeader' colspan=3 align='CENTER' width=550><B>ChartTitle</B></TD></TR>";
                htmlContent.Append(barTitle.Replace("ChartTitle", section.ChartTitle) + newline);

                string barTemplate = "<TR><TD Width=150 class='DetailData' align='right'>Label</TD>" + newline;
                barTemplate += " <TD  class='DetailData' Width=" + (ChartWidth + 25) + ">" + newline;
                barTemplate += "    <TABLE cellpadding=0 cellspacing=0 HEIGHT='20' WIDTH=" + ChartWidth + " class='TableStyle'>" + newline;
                barTemplate += "       <TR>" + newline;
                barTemplate += "          <TD Width=ChartWidth>" + newline;
                barTemplate += "             <TABLE class='TableStyle' HEIGHT='20' Width=ChartTWidth border=NOTZERO>" + newline;
                barTemplate += "                <TR>" + newline;
                barTemplate += "                   <TD Width=ChartWidth bgcolor='BackColor' Width=ChartWidth style=\"FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=0,startColorStr=BackColor,endColorStr=#ffffff); \"></TD>" + newline;
                barTemplate += "                </TR>" + newline;
                barTemplate += "             </TABLE>" + newline;
                barTemplate += "          </TD>" + newline;
                barTemplate += "          <TD class='DetailData'>&nbsp;Percentage</TD>" + newline;
                barTemplate += "       </TR>" + newline;
                barTemplate += "    </TABLE>";
                barTemplate += "</TD><TD Width=70 class='DetailData'>Value</TD></TR>";

                string barHTemplate = "<TR>" + newline;
                barHTemplate += " <TD Width=150  class='DetailData' align='right' bgColor='#e5e5e5'>Label</TD>" + newline;
                barHTemplate += " <TD  bgColor='#e5e5e5' class='DetailData' Width=" + (ChartWidth + 25) + ">";
                barHTemplate += "Percentage</TD>" + newline;
                barHTemplate += " <TD Width=25  class='DetailData' bgColor='#e5e5e5'>Value</TD></TR>";
                barHTemplate = barHTemplate.Replace("Label", section.ChartLabelHeader);
                barHTemplate = barHTemplate.Replace("Percentage", section.ChartPercentageHeader);
                barHTemplate = barHTemplate.Replace("Value", section.ChartValueHeader);
                htmlContent.Append(barHTemplate + newline);

                string temp;
                float width = 0;
                float val = 0;
                float percent = 0;
                int cntColor = 0;
                for (int i = 0; i < labels.Count; i++)
                {
                    temp = barTemplate;
                    val = float.Parse(values[i].ToString());
                    width = float.Parse(values[i].ToString()) * ChartWidth / total;
                    percent = float.Parse(values[i].ToString()) * 100 / total;

                    temp = temp.Replace("Label", labels[i].ToString());
                    if (percent == 0.0)
                    {
                        temp = temp.Replace("BackColor", "#f5f5f5");
                        temp = temp.Replace("NOTZERO", "0");
                    }
                    else
                    {
                        temp = temp.Replace("BackColor", colors[cntColor]);
                        temp = temp.Replace("NOTZERO", "1");
                    }
                    temp = temp.Replace("ChartTWidth", Decimal.Round((Decimal)(width + 2), 0).ToString());
                    temp = temp.Replace("ChartWidth", Decimal.Round((Decimal)width, 0).ToString());
                    temp = temp.Replace("Value", val.ToString());
                    temp = temp.Replace("Percentage", Decimal.Round((decimal)percent, 2).ToString() + "%");

                    htmlContent.Append(temp + newline);
                    cntColor++;
                    if (cntColor == 10)
                        cntColor = 0;
                }
            }
            catch (Exception err)
            {
                htmlContent.Append("<TR><TD valign=MIDDLE align=CENTER><b>Unable to Generate Chart.<br>" + err.Message + "</b></TD></TR>");
            }
            htmlContent.Append("</TABLE>" + newline);
            htmlContent.Append("<!--- Chart Table ends here -->");
            htmlContent.Append("</TD></TR>");
        }

        private string getFontSize(int level)
        {
            string fontSize = "";
            switch (level)
            {
                case 1:
                    fontSize = "12pt"; //14
                    break;
                case 2:
                    fontSize = "9pt"; //12
                    break;
                case 3:
                    fontSize = "8pt"; //10
                    break;
                default:
                    fontSize = "7pt"; //9
                    break;
            }
            return fontSize;
        }

        #region Calculations
        /// <summary>
        /// Method to get distinct values for given Column name from the dataset for generating Chart.
        /// </summary>
        /// <param name="dataSet">report source dataset</param>
        /// <param name="criteria">data selection criteria</param>
        /// <param name="changeOnField">Column name</param>
        /// <param name="valueField">Column name</param>
        /// <returns>List of distinct labels and values</returns>
        private ArrayList GetDistinctValuesForChart(DataTable dataTable, string criteria, string changeOnField, string valueField)
        {
            ArrayList result = new ArrayList();
            ArrayList distinctValues = new ArrayList();
            if (criteria == null || criteria.Trim() == "")
            {
                criteria = "";
            }
            else
            {
                criteria = criteria.Substring(3);
            }

            foreach (DataRow dr in dataTable.Select(criteria))
            {
                if (!distinctValues.Contains(dr[changeOnField].ToString()))
                {
                    distinctValues.Add(dr[changeOnField].ToString());
                }
            }
            ArrayList totalValues = new ArrayList();
            if (criteria.Trim() != "")
                criteria += " and ";
            foreach (object obj in distinctValues)
            {
                DataRow[] rows = reportSource.Select(criteria + changeOnField + "='" + obj.ToString().Replace("'", "''") + "' ");
                if (valueField.Trim().ToUpper() == "COUNT")
                {
                    totalValues.Add(rows.Length.ToString());
                }
                else
                {
                    float sum = 0;
                    foreach (DataRow row in rows)
                        sum += float.Parse(row[valueField].ToString());
                    totalValues.Add(sum.ToString());
                }
            }
            result.Add(distinctValues);
            result.Add(totalValues);
            return result;
        }


        /// <summary>
        /// Method to get distinct values for the column in the report source dataset
        /// </summary>
        /// <param name="dataSet">report source dataset</param>
        /// <param name="columnName">Column name</param>
        /// <param name="criteria">Data selection criteria</param>
        /// <returns>List of distinct values</returns>
        private ArrayList GetDistinctValues(DataTable dataTable, string columnName, string criteria)
        {
            ArrayList distinctValues = new ArrayList();
            if (criteria == null || criteria.Trim() == "")
            {
                criteria = String.Empty;
            }
            else
            {
                criteria = criteria.Substring(3);
            }

            foreach (DataRow dr in dataTable.Select(criteria))
            {
                if (!distinctValues.Contains(dr[columnName].ToString()))
                {
                    distinctValues.Add(dr[columnName].ToString());
                }
            }
            return distinctValues;
        }


        private Hashtable PrepareData(Hashtable totalArray)
        {
            foreach (object obj in TotalFields)
            {
                if (!totalArray.Contains(obj.ToString()))
                {
                    totalArray.Add(obj.ToString(), 0.0F);
                }
            }
            return totalArray;
        }

        private Hashtable AccumulateTotal(Hashtable totalTable1, Hashtable totalTable2)
        {
            foreach (object totalField in TotalFields)
            {
                totalTable1[totalField.ToString()] = float.Parse(totalTable1[totalField.ToString()].ToString()) +
                    float.Parse(totalTable2[totalField.ToString()].ToString());
            }
            return totalTable1;
        }
        #endregion

        #endregion

    }


}
