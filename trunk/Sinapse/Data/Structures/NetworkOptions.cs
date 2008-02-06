using System;
using System.Collections.Generic;
using System.Text;

using Sinapse.Data.Structures;

namespace Sinapse.Data
{

    internal enum TrainingType { ByError, ByEpoch };

    internal struct NetworkOptions
    {

        public TrainingType TrainingType;

        public int limEpoch;
        public double limError;

        public double momentum;
        public double learningRate;

        public bool validateNetwork;


        [NonSerialized]
        public NetworkVectors TrainingVectors;

        [NonSerialized]
        public NetworkVectors ValidationVectors;

    }
}
