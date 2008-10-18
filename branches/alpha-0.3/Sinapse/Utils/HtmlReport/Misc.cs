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
 *  Please contact the class author for more info about licensing          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Sinapse.Utils.HtmlReport
{

    public enum HtmlAlign
    {
        Left, Right, Center
    }

    internal class Util
    {
        public static string GetHTMLColorString(Color color)
        {
            if (color.IsNamedColor)
                return color.Name;
            else
                return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}
