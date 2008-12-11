using System;
using System.Collections.Generic;
using System.Text;

using AForge.Neuro;

namespace Sinapse.Core.Systems
{
    public class ActivationNetworkSystem : NetworkSystem, ISerializableObject<ActivationNetworkSystem>
    {


        #region Constructor
        public ActivationNetworkSystem(IActivationFunction function, int inputsCount, params int[] neuronsCount)
        {
            Network = new ActivationNetwork(function, inputsCount, neuronsCount);
        }

        public ActivationNetworkSystem()
        {
        }
        #endregion



        #region Properties
        public new ActivationNetwork Network
        {
            get { return network as ActivationNetwork; }
            set { network = value; }
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






        public override object[][] Compute(params object[][] args)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override object[] Test(object[] input, object[] desiredOutput, out double[] rawOutput, out double[] deviation)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
