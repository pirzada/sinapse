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
    /// <summary>
    /// Holds both input and output vectors to be fed to a neural network.
    /// </summary>
    internal struct TrainingVectors
    {

        public double[][] Input;
        public double[][] Output;


        public TrainingVectors(double[][] input, double[][] output)
        {
            this.Input = input;
            this.Output = output;
        }


        public bool IsEmpty
        {
            get
            {
                return (Input == null || Output == null ||
                    Input.Length == 0 || Output.Length == 0);
            }
        }

    }
}
