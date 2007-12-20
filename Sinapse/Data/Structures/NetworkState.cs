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
        public double TrainingErrorRate;
        public double ValidationErrorRate;
        public string StatusText;
        public List<Double> TrainingErrorList;
        public List<Double> ValidationErrorList;

        public NetworkState()
        {
            this.Epoch = 0;
            this.TrainingErrorRate = 0D;
            this.ValidationErrorRate = 0D;
            this.TrainingErrorList = new List<double>();
            this.ValidationErrorList = new List<double>();
            this.StatusText = String.Empty;
        }

        public double[,] GetTrainingErrors()
        {
            //Create error's dynamics
            double[,] errorMatrix;
            try
            {
                errorMatrix = new double[TrainingErrorList.Count, 2];

                for (int i = 0; i < TrainingErrorList.Count; i++)
                {
                    errorMatrix[i, 0] = i;
                    errorMatrix[i, 1] = TrainingErrorList[i];
                }
            }
            catch
            {
                errorMatrix = new double[1, 2];
                errorMatrix.Initialize();
            }
            return errorMatrix;
        }

        public double[,] GetValidationErrors()
        {
            //Create error's dynamics
            double[,] errorMatrix;
            try
            {
                errorMatrix = new double[ValidationErrorList.Count, 2];

                for (int i = 0; i < ValidationErrorList.Count; i++)
                {
                    errorMatrix[i, 0] = i;
                    errorMatrix[i, 1] = ValidationErrorList[i];
                }
            }
            catch
            {
                errorMatrix = new double[1, 2];
                errorMatrix.Initialize();
            }
            return errorMatrix;
        }


    }
}
