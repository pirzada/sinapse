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
using System.Text;
using System.IO;

using Sinapse.Data.Logging;


namespace Sinapse.Data
{

    /// <summary>
    /// Gives an application-wide way to log global actions or events
    /// </summary>
    internal static class HistoryListener
    {

        private static readonly HistoryEventCollection m_log = new HistoryEventCollection();

        public static HistoryEventCollection Log
        {
            get { return m_log; }
        }

        /// <summary>
        /// Writes an action to the log
        /// </summary>
        /// <param name="text">The action displayed text</param>
        public static void Write(string text)
        {
            m_log.Add(text);
        }

    }
}
