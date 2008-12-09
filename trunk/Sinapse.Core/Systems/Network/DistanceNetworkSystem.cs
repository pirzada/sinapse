using System;
using System.Collections.Generic;
using System.Text;

using AForge.Neuro;

namespace Sinapse.Core.Systems
{
    public class DistanceNetworkSystem : NetworkSystem
    {

        public DistanceNetworkSystem(int inputsCount, int neuronsCount)
        {
            network = new DistanceNetwork(inputsCount, neuronsCount);
        }

        public new DistanceNetwork Network
        {
            get { return this.network as DistanceNetwork; }
        }

        public override string Type
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override object Compute(object input)
        {
            throw new NotImplementedException();
        }
    }
}
