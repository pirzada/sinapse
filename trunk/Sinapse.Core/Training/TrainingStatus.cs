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

namespace Sinapse.Core.Training
{
    public sealed class TrainingStatus
    {

        internal int epoch;
        internal int progress;

        internal double trainingError;
        internal double validationError;

        internal double epochsPerSecond;
        internal int trainingRound;


        //----------------------------------------


        #region Constructor
        public TrainingStatus()
        {

        }
        #endregion


        //----------------------------------------


        #region Properties
        public int Epoch
        {
            get { return this.epoch; }
        }

        public double ValidationError
        {
            get { return this.validationError; }

        }

        public double TrainingError
        {
            get { return this.trainingError; }
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        public void Reset()
        {
            this.epoch = 0;
            this.progress = 0;
            this.trainingError = 0.0;
            this.validationError = 0.0;
            this.epochsPerSecond = 0;
            this.trainingRound = 0;
        }
        #endregion

    }
}
