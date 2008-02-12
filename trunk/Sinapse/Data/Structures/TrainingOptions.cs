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

using Sinapse.Data.Structures;

namespace Sinapse.Data
{

    internal enum TrainingType { ByError, ByEpoch };

    internal struct TrainingOptions
    {

        public TrainingType TrainingType;

        public int limEpoch;
        public double limError;

        public double momentum;
        public double learningRate;

        public bool validateNetwork;

        [NonSerialized]
        public TrainingVectors TrainingVectors;

        [NonSerialized]
        public TrainingVectors ValidationVectors;

    }
}
