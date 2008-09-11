using System;
using System.Collections.Generic;
using System.Text;

using AForge.Mathematics;

namespace Sinapse.Core.Transformations
{
    public class ThresholdSeparation : ITransformation
    {

        //---------------------------------------------

        public Matrix Apply(Matrix m)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Matrix Revert(Matrix m)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Inputs
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int Outputs
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
}
