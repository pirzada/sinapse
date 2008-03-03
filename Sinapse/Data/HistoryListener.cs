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


namespace Sinapse.Data
{

    internal static class HistoryListener
    {

        private static readonly HistoryEventCollection m_log = new HistoryEventCollection();

        public static HistoryEventCollection Log
        {
            get { return m_log; }
        }

        public static void Write(string text)
        {
            m_log.Add(text);
        }

    }


    internal sealed class HistoryEventCollection : BindingList<HistoryEvent>
    {

        public HistoryEvent LastEvent
        {
            get { return this[this.Count - 1]; }
        }

        public void Add(string text)
        {
            this.Add(new HistoryEvent(text));
        }        

        public string[] ToStringArray()
        {
            string[] lines = new string[this.Count];
            
            for (int i = 0; i < this.Count; ++i)
            {
                lines[i] = this[i].ToString();  
            }

            return lines;
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
