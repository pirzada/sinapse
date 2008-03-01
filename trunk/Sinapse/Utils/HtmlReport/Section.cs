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
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Sinapse.Utils.HtmlReport
{

    /// <summary>
    /// Class to hold HTMLReport section details
    /// </summary>
    public sealed class Section
    {
        public string GroupBy;
        public string TitlePrefix;
        public bool IncludeFooter;
        public bool GradientBackground;

        public bool IncludeTotal;
        public Section SubSection;
        /// <summary>
        /// HTMLReport Color code as string
        /// </summary>
        internal string backColor;
        internal Color cBackColor;
        internal int Level;
        internal bool isChartCreated;

        public bool IncludeChart;
        public string ChartTitle;
        public bool ChartShowAtBottom;
        public string ChartChangeOnField;
        public string ChartValueField = "Count";
        public bool ChartShowBorder;
        public string ChartLabelHeader = "Label";
        public string ChartPercentageHeader = "Percentage";
        public string ChartValueHeader = "Value";

        public Color BackColor
        {
            set { backColor = Util.GetHTMLColorString(value); cBackColor = value; }
            get { return cBackColor; }
        }

        public Section()
        {
            SubSection = null;
            BackColor = Color.FromArgb(240, 240, 240);
            ChartValueField = "Count";
            GradientBackground = false;
            ChartTitle = "&nbsp;";
        }

        public Section(string groupBy, string titlePrefix)
        {
            GroupBy = groupBy;
            TitlePrefix = titlePrefix;
            SubSection = null;
            BackColor = Color.FromArgb(240, 240, 240);
            ChartValueField = "Count";
            GradientBackground = false;
            ChartTitle = "&nbsp;";
        }

        public Section(string groupBy, string titlePrefix, Color bgcolor)
        {
            GroupBy = groupBy;
            TitlePrefix = titlePrefix;
            SubSection = null;
            BackColor = bgcolor;
            ChartValueField = "Count";
            GradientBackground = false;
            ChartTitle = "&nbsp;";
        }
    }

}
