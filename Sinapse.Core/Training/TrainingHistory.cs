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

namespace Sinapse.Core.Training
{

    /// <summary>
    /// A Training Step is the record of an event occured during the training of a Neural Network. For example, a change in the learning rate, the pausing of the trainment, the restart of the proccess, etc.
    /// </summary>
    public sealed class TrainingHistoryEvent
    {

        private string action;
        private string detail;
        private DateTime time;
        private TrainingOptions options;
        private TrainingStatus status;


        //---------------------------------------------


        #region Constructor
        public TrainingHistoryEvent(string text)
            : this(text, String.Empty)
        {
        }

        public TrainingHistoryEvent(string text, string detail)
        {
            this.time = DateTime.Now;
            this.action = text;
            this.detail = detail;
        }

        public TrainingHistoryEvent(string text, string detail, TrainingStatus status) : this(text, detail)
        {
            this.status = status.Copy();
        }

        public TrainingHistoryEvent(string text, string detail, TrainingStatus status, TrainingOptions options)
            : this(text, detail, status)
        {
            this.time = DateTime.Now;
            this.options = options.Copy();
        }

        public TrainingHistoryEvent(string text, TrainingStatus status)
            : this(text, String.Empty, status)
        {
        }

        public TrainingHistoryEvent(string text, TrainingStatus status, TrainingOptions options)
            : this(text, String.Empty, status, options)
        {
        }

        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>Gets the creation time of this action.</summary>
        public DateTime Time
        {
            get { return time; }
        }

        /// <summary>Get the action registered.</summary>
        public string Action
        {
            get { return action; }
        }

        /// <summary>Gets details about the registered action.</summary>
        public string Details
        {
            get { return detail; }
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
            return String.Format("[{0}] {1} - {2}", time, action, detail);
        }
        #endregion

    }

    /// <summary>
    /// A collection of History Events
    /// </summary>
    public sealed class TrainingHistory : BindingList<TrainingHistoryEvent>
    {


        public void Add(string text, string detail)
        {
            Add(new TrainingHistoryEvent(text, detail));
        }

        public void Add(string text, TrainingStatus status)
        {
            Add(new TrainingHistoryEvent(text, status));
        }

        public void Add(string text, string detail, TrainingStatus status)
        {
            Add(new TrainingHistoryEvent(text, detail, status));
        }

        public void Add(string text, string detail, TrainingStatus status, TrainingOptions options)
        {
            Add(new TrainingHistoryEvent(text, detail, status, options));
        }

        public void Add(string text, TrainingStatus status, TrainingOptions options)
        {
            Add(new TrainingHistoryEvent(text, status, options));
        }



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