/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2007 Cesar Roberto de Souza <cesarsouza@gmail.com> *
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

namespace Sinapse.Data
{
    internal sealed class NetworkState
    {
        public int Epoch;
        public double ErrorRate;
        public string StatusText;
        public List<Double> ErrorList;

        public NetworkState()
        {
            this.Epoch = 0;
            this.ErrorRate = 0D;
            this.ErrorList = new List<double>();
            this.StatusText = String.Empty;
        }

        public double[,] GetErrors()
        {
            //Create error's dynamics
            //Array's length cannot exceed 16000!
            double[,] errorMatrix = new double[ErrorList.Count, 2];
            for (int i = 0; i < ErrorList.Count; i++)
            {
                errorMatrix[i, 0] = i;
                errorMatrix[i, 1] = ErrorList[i];
            }
            return errorMatrix;
        }


    }
}
