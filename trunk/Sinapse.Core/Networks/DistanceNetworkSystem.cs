using System;
using System.Collections.Generic;
using System.Text;

using AForge.Neuro;

namespace Sinapse.Core.Networks
{
    public class DistanceNetworkSystem : AdaptativeSystemBase
    {

        public DistanceNetworkSystem(int inputsCount, int neuronsCount)
        {
            m_network = new DistanceNetwork(inputsCount, neuronsCount);
        }

        public new DistanceNetwork Network
        {
            get { return this.m_network as DistanceNetwork; }
        }

        public override string Type
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
}
