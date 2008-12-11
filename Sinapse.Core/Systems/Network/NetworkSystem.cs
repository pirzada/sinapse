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
using AForge.Mathematics;

using Sinapse.Core.Filters;

namespace Sinapse.Core.Systems
{

    /// <summary>
    /// NetworkSystem is a system which contains a Neural Network as its core.
    /// </summary>
    /// <remarks>This is an abstract class and cannot be instantiated.</remarks>
    public abstract class NetworkSystem : Sinapse.Core.Systems.AdaptiveSystem
    {

        protected Network network;


        //----------------------------------------

        #region Constructor
        protected NetworkSystem()
        {
            
        }
        #endregion

        //----------------------------------------


        #region Properties


        public Network Network
        {
            get { return network; }
            protected set { network = value; }
        }


        /// <summary>Gets a string representing the type of the network.</summary>
        public abstract string Type { get;}
        #endregion


        //----------------------------------------

        #region Public Methods
        public override object[] Compute(params object[] input)
        {
            double[] procInput;
            object[] procOutput;


            // Apply Input Filtering
            try
            {
                procInput = (double[])Preprocess.Apply(input);
            }
            catch (Filters.InputMismatchException exception)
            {
                throw new Filters.InputMismatchException(
                    "Exception ocurred while appling Input filtering", exception);
            }


            // Calculate Network Answers
            double[] output = Network.Compute((double[])procInput);


            // Apply Output Filtering
            try
            {
                procOutput = (object[])Postprocess.Apply(output);
            }
            catch (Filters.InputMismatchException exception)
            {
                throw new Filters.InputMismatchException(
                    "Exception ocurred while appling Output filtering", exception);
            }


            // Return final result
            return procOutput;
        }
        #endregion



    }
}
