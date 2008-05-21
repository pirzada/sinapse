/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
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

using AForge.Neuro;

using Sinapse.Core.Networks;
using Sinapse.Core.Networks.DataSources;
using Sinapse.Core.Networks.DataSources.Base;

namespace Sinapse.Core.Training
{

    /// <summary>
    ///   Encapsultates an Asynchronous and Thread-Safe way to train Backpropagation Networks
    ///   using crossvalidation and other advanced techniques. Also provides additional feedback
    ///   about current traning status.
    /// </summary>
    public class TrainingSession
    {

        public enum SessionState { Stopped, Paused, Running, Error };

        //----------------------------------------

        private SessionState m_currentState;
        
        private NetworkDataSourceBase m_networkDataSource;
        private NetworkContainer m_networkContainer;

        private TrainingOptions m_options;
        private TrainingStatus m_status;

        private TrainingSavepointCollection m_savepoints;

        private String m_message;

        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler Paused;

        public event EventHandler StatusChanged;
        public event EventHandler MessageChanged;


        //----------------------------------------


        #region Constructors
        public TrainingSession()
        {
            
        }

        public TrainingSession(TrainingOptions options)
        {
            this.m_options = options;
        }
        #endregion


        //----------------------------------------


        #region Properties
        #endregion


        //----------------------------------------


        #region Public Methods
        public void Start()
        {
            this.Start(null);
        }
        public void Start(TrainingOptions options)
        {
            if (options != null)
                this.m_options = options;

        }

        public void Stop()
        {
        }

        public void Pause()
        {
        }

        public void Rewind()
        {
            this.m_status.Reset();
            this.m_networkContainer.Network.Randomize();
        }

        public void Goto(TrainingSavepoint savepoint)
        {

        }
        #endregion


        //----------------------------------------


        #region Protected Methods
        protected void OnStatusChanged()
        {
            if (this.StatusChanged != null)
                this.StatusChanged.Invoke(this, EventArgs.Empty);
        }

        protected void OnMessageChanged()
        {
            if (this.MessageChanged != null)
                this.MessageChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion

    }
}
