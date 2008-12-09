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
    public sealed class TrainingStep
    {

        private string m_action;
        private string m_detail;
        private DateTime m_time;
        private TrainingOptions m_options;
        private TrainingStatus m_status;


        //---------------------------------------------


        #region Constructor
        internal TrainingStep(string text)
            : this(text, String.Empty)
        {
        }

        internal TrainingStep(string text, string detail)
        {
            this.m_time = DateTime.Now;
            this.m_action = text;
            this.m_detail = detail;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>Gets the creation time of this action.</summary>
        public DateTime Time
        {
            get { return this.m_time; }
        }

        /// <summary>Get the action registered.</summary>
        public string Action
        {
            get { return this.m_action; }
        }

        /// <summary>Gets details about the registered action.</summary>
        public string Details
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
    public sealed class TrainingStepCollection : BindingList<TrainingStep>
    {




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