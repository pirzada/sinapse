using System;
using System.Collections.Generic;
using System.Text;

using AForge.Math;


namespace Sinapse.Core.Transformations
{
    public class RangeConversion : ITransformation
    {
        #region ITransformation Members

        public Matrix Apply(AForge.Math.Matrix m)
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

        #endregion
    }
}
