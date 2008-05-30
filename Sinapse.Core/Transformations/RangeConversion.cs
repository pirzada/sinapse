using System;
using System.Collections.Generic;
using System.Text;

using AForge.Math;


namespace Sinapse.Core.Transformations
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///   Note: Once the network has been trained using a range conversion, please
    ///   make sure when testing and using the network the maximum and minimum values won't
    ///   ever be extrapolated, otherwise erratic behaviour of the network may occur.
    /// </remarks>
    public class RangeConversion : ITransformation
    {

        AForge.Math.RangeConversion rangeConversion;


        public RangeConversion()
        {
            throw new NotImplementedException();

        }

        public Matrix Apply(Matrix m)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Vector Apply(Vector v)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Matrix Revert(Matrix m)
        {
            throw new NotImplementedException();
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
