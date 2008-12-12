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

    [Serializable]
    public sealed class TrainingOptions
    {
        public enum TrainingLimit { None = 0, ByError = 1, ByEpoch = 2 };

        public TrainingLimit Limit;
        public int LimitByEpochs;
        public double LimitByError;

        public double Momentum;
        public double LearningRate1;
        public double LearningRate2;
        public bool ChangeLearningRate;

        public bool MarkSavepoints;
        public int MarkSavepointsEpochs;

        public bool Validate;
        public int ValidateEpochs;

        public bool RotateSubsets;
        public int RotateSubsetsEpochs;

        public bool CompressSavepoints;
        public int CompressSavepointsLimit;

        public bool ReportProgress;
        public int ReportProgressEpochs;

        public bool Delay;
        public int DelayMilliseconds;

        public TrainingOptions Copy()
        {
            TrainingOptions options = new TrainingOptions();
            options.Limit = Limit;
            options.LimitByEpochs = LimitByEpochs;

            throw new NotImplementedException();
        }

        public TrainingOptions()
        {
            Limit = TrainingLimit.ByError;
        }


    }
}
