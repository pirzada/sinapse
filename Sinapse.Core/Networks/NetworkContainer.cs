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
using AForge.Math;

using Sinapse.Core.Transformations;

namespace Sinapse.Core.Networks
{
    public abstract class NetworkContainer
    {

        private Network m_network;
        private NetworkMappings m_networkMapping;

        private ITransformationCollection m_inputTransformations;
        private ITransformationCollection m_outputTransformations;


        //----------------------------------------


        #region Constructor
        public NetworkContainer()
        {
        }

        public NetworkContainer(Network network)
        {
            this.m_network = network;
        }
        #endregion


        //----------------------------------------


        #region Properties
        public ITransformationCollection InputTransformation
        {
            get { return m_inputTransformations; }
        }

        public ITransformationCollection OutputTransformation
        {
            get { return m_outputTransformations; }
        }

        public int InputCount
        {
            get { return m_network.InputsCount; }
        }

        public int OutputCount
        {
            get { return m_network.Output.Length; }
        }

        public Network Network
        {
            get { return m_network; }
        }
        #endregion

        #region Public Methods
        public Matrix Compute(Matrix inputs)
        {
            return default(Matrix);
        }
        #endregion

    }
}
