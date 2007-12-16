using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Data
{

    internal sealed class NetworkOptions
    {

        public double errorLimit;
        public double momentum;
        public double learningRate;

        [NonSerialized]
        public double[][] input;

        [NonSerialized]
        public double[][] output;

        public NetworkOptions()
        {

        }

    }
}
