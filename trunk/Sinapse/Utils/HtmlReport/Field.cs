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
 * Modifications by Cesar Roberto de Souza                                 *
 *  (added support for number format specification)                        *
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
    /// Class to hold HTMLReport field details
    /// </summary>
    public sealed class Field
    {

        private string m_fieldName;
        private string m_headerName;
        private string m_formatString;
        private Color m_backColor;
        private Color m_headerBackColor;
        private HtmlAlign m_align = HtmlAlign.Left;
        private bool m_totalField = false;
        private int m_width;


        //----------------------------------------


        #region Constructor
        public Field()
        {
            this.m_fieldName = String.Empty;
            this.m_headerName = "Column Header";
            this.m_backColor = Color.White;
            this.m_headerBackColor = Color.White;
            this.FormatString = String.Empty;
            this.Width = 0;
        }

        public Field(string fieldName, string headerName)
            : this()
        {
            this.m_fieldName = fieldName;
            this.m_headerName = headerName;
        }

        public Field(string fieldName, string headerName, int width)
            : this(fieldName, headerName)
        {
            this.m_width = width;
        }

        public Field(string fieldName, string headerName, int width, Color bgcolor)
            : this(fieldName, headerName, width)
        {
            this.m_backColor = bgcolor;
        }

        public Field(string fieldName, string headerName, int width, HtmlAlign textAlignment)
            : this(fieldName, headerName, width)
        {
            this.m_align = textAlignment;
        }

        public Field(string fieldName, string headerName, int width, HtmlAlign textAlignment, Color bgColor, Color headerBgColor)
            : this(fieldName, headerName, width, textAlignment)
        {
            BackColor = bgColor;
            HeaderBackColor = headerBgColor;
        }


        public Field(string fieldName, string headerName, Color headerBgColor)
            : this(fieldName, headerName)
        {
            this.m_headerBackColor = headerBgColor;
        }

        public Field(string fieldName, string headerName, HtmlAlign textAlignment)
            : this(fieldName, headerName)
        {
            this.m_align = textAlignment;
        }
        #endregion


        //----------------------------------------


        #region Properties
        public HtmlAlign Alignment
        {
            set { this.m_align = value; }
            get { return this.m_align; }
        }

        public Color BackColor
        {
            get { return this.m_backColor; }
            set { this.m_backColor = value; }
        }

        public Color HeaderBackColor
        {
            get { return this.m_headerBackColor; }
            set { this.m_headerBackColor = value; }
        }

        public int Width
        {
            get { return this.m_width; }
            set { this.m_width = value; }
        }

        public string FieldName
        {
            get { return this.m_fieldName; }
            set { this.m_fieldName = value; }
        }

        public string HeaderName
        {
            get { return this.m_headerName; }
            set { this.m_headerName = value; }
        }

        public string FormatString
        {
            get { return this.m_formatString; }
            set { this.m_formatString = value; }
        }

        internal bool IsTotalField
        {
            get { return this.m_totalField; }
            set { this.m_totalField = value; }
        }
        #endregion

    }		

}
