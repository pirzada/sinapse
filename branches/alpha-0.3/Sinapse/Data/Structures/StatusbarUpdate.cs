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

namespace Sinapse.Data.Structures
{

    // TODO: make future use of this class
    
    internal struct StatusbarUpdate
    {

        internal int Epoch;
        internal int Progress;
        internal double EpochsBySecond;
        internal double ErrorTraining;
        internal double ErrorValidation;
        internal int TrainingRound;


        internal void Reset()
        {
            Epoch = 0;
            Progress = 0;
            ErrorTraining = 0;
            ErrorValidation = 0;
            EpochsBySecond = 0;
            TrainingRound = 0;
        }
    }
}