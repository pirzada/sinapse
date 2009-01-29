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

namespace Sinapse.Data.Logging
{

    [Flags]
    internal enum EventVisibility
    {
        None = 0,
        User = 2,
        Report = 4,
        Debug = 8,
    }

    /// <summary>
    /// A history event to hold information about a given action
    /// </summary>
    [Serializable]
    internal sealed class HistoryEvent
    {

        private string m_action;
        private string m_detail;
        private EventVisibility m_visible;
        private DateTime m_time;


        //---------------------------------------------


        #region Constructor
        internal HistoryEvent(string text)
            : this(text, String.Empty, EventVisibility.User)
        {
        }

        internal HistoryEvent(string text, string detail, EventVisibility visible)
        {
            this.m_time = DateTime.Now;
            this.m_action = text;
            this.m_detail = detail;
            this.m_visible = visible;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        /// The creation time of this registered event.
        /// </summary>
        internal DateTime Time
        {
            get { return this.m_time; }
        }

        /// <summary>
        /// The action registered
        /// </summary>
        internal string Action
        {
            get { return this.m_action; }
        }

        internal EventVisibility Visible
        {
            get { return this.m_visible; }
            set { this.m_visible = value; }
        }

        /// <summary>
        /// The detail about the registered action.
        /// </summary>
        internal string Details
        {
            get { return this.m_detail; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public override string ToString()
        {
            return this.ToString(false);
        }

        public string ToString(bool showDetail)
        {
            return String.Format("[{0}] {1} - {2}", m_time, m_action, m_detail);
        }
        #endregion

    }

    /// <summary>
    /// A collection of History Events
    /// </summary>
    internal sealed class HistoryEventCollection : BindingList<HistoryEvent>
    {

        public HistoryEvent LastEvent
        {
            get { return this[this.Count - 1]; }
        }

        //---------------------------------------------


        public void Add(string text)
        {
            this.Add(new HistoryEvent(text));
        }

        public void Add(string text, string detail)
        {
            this.Add(new HistoryEvent(text, detail, EventVisibility.User));
        }

        public void Add(string text, string detail, EventVisibility visible)
        {
            this.Add(new HistoryEvent(text, detail, visible));
        }


        //---------------------------------------------


        public string[] ToStringArray()
        {
            return this.ToStringArray(false);
        }

        public string[] ToStringArray(bool detail)
        {
            string[] lines = new string[this.Count];

            for (int i = 0; i < this.Count; ++i)
            {
                lines[i] = this[i].ToString();
            }

            return lines;
        }

    }

}