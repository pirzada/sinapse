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
    public class TrainingOptions
    {
        public enum TrainingMethod { ByError, ByEpoch, Manual };

        private TrainingMethod m_method;
        private int    epochLimit;
        private double errorLimit;

        private double momentum;
        private double learningRate1;
        private double learningRate2;
        private bool changeLearningRate;

        private int? saveEpochs;
        private int? validateEpochs;
        private int? testingEpochs;

        public TrainingOptions()
        {
            this.m_method = TrainingMethod.ByError;
        }


    }
}
