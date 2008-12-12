using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Training
{
    struct TrainingThreadParameters
    {
        public TrainingOptions Options;
        public double[][] Inputs;
        public double[][] Outputs;

        public TrainingThreadParameters(double[][] inputs, double[][] outputs, TrainingOptions options)
        {
            Inputs = inputs;
            Outputs = outputs;
            Options = options;
        }
    }
}
