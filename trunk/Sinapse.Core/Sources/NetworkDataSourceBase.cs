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
using System.Data;

using AForge.Math;

using Sinapse.Core.Transformations;
using Sinapse.Core.Networks;


namespace Sinapse.Core.Sources
{

    public enum NetworkDataSet { Training, Testing, Validation };


    [Serializable]
    public abstract class NetworkDataSourceBase
    {

        public abstract Matrix CreateVectors(NetworkDataSet set);

        public abstract DataView CreateDataView(NetworkDataSet set);

        public abstract int InputCount { get; }
        public abstract int OutputCount { get; }


        public bool IsCompatible(NetworkContainer network)
        {
            return (network.InputCount == this.InputCount && network.OutputCount == this.OutputCount);
        }

    }
}
