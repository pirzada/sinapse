using System;
using System.Collections.Generic;
using System.Text;

using AForge.Neuro;

namespace Sinapse.Core.Systems
{
    public class ActivationNetworkSystem : NetworkSystemBase
    {


        #region Constructor
        public ActivationNetworkSystem(IActivationFunction function, int inputsCount, params int[] neuronsCount)
        {
            this.m_network = new ActivationNetwork(function, inputsCount, neuronsCount);
        }

        public ActivationNetworkSystem()
        {
        }
        #endregion

        //---------------------------------------------

        #region Properties
        public new ActivationNetwork Network
        {
            get { return m_network as ActivationNetwork; }
        }

        public override string Type
        {
            get { return "Activation Network"; }
        }

        public string Function
        {
            get { return this.Network[0][0].ActivationFunction.GetType().Name; }
        }
        #endregion

        //---------------------------------------------

    }
}
