using System;
using System.Collections.Generic;
using System.Text;

using Sinapse.Data.Structures;

namespace Sinapse.Data
{

    internal sealed class NetworkOptions
    {


        public bool errorBased; //Set to true to error limit based training;
                                // false to default epoch limit based training.

        public int epochLimit;
        public double errorLimit;

        public double momentum;
        public double learningRate;


        [NonSerialized]
        public NetworkVectors TrainingVectors;

        [NonSerialized]
        public NetworkVectors? ValidationVectors;


        public NetworkOptions()
        {

        }

    }
}
