using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Filters
{
    class ChangeColumns : Sinapse.Core.Transformations.ITransformation
    {
        #region ITransformation Members

        public AForge.Mathematics.Matrix Apply(AForge.Mathematics.Matrix source)
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
