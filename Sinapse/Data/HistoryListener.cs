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
using System.Text;
using System.IO;


namespace Sinapse.Data
{

    internal static class HistoryListener
    {

        public static EventHandler NewActionLogged;

        private static List<HistoryEvent> actionLog; 
        private static string lastLoggedAction = String.Empty;


        //---------------------------------------------


        internal static void Initialize()
        {
            if (actionLog == null)
                actionLog = new List<HistoryEvent>();
        }


        //---------------------------------------------


        #region Properties
        internal static HistoryEvent LastAction
        {
            get { return actionLog[actionLog.Count - 1]; }
        }

        internal static List<HistoryEvent> ActionLog
        {
            get { return actionLog; }
        }
        #endregion


        //---------------------------------------------


        internal static void Write(string text)
        {
            actionLog.Add(new HistoryEvent(text));

            if (NewActionLogged != null)
                NewActionLogged.Invoke(null, EventArgs.Empty);
        }

    }


    internal sealed class HistoryEvent
    {

        private DateTime time;
        private string action;


        //---------------------------------------------


        #region Constructor
        internal HistoryEvent(string text)
        {
            this.time = DateTime.Now;
            this.action = text;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal DateTime Time
        {
            get { return time; }
        }

        internal string Action
        {
            get { return action; }
        }
        #endregion


        //---------------------------------------------


        public override string ToString()
        {
            return String.Format("[{0}] {1}", time, action);
        }
    }
}
