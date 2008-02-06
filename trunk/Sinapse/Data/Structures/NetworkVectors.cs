using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Data.Structures
{
    struct NetworkVectors
    {

        public double[][] Input;
        public double[][] Output;

        public NetworkVectors(double[][] input, double[][] output)
        {
            this.Input = input;
            this.Output = output;
        }


        public bool IsEmpty
        {
            get
            {
                return (Input == null || Output == null || Input.Length == 0 || Output.Length == 0);
            }
        }

    }
}
