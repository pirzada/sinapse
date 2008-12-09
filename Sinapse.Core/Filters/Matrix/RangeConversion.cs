using System;
using System.Collections.Generic;
using System.Text;

using AForge.Mathematics;


namespace Sinapse.Core.Filters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///   Note: Once the network has been trained using a range conversion, please
    ///   make sure when testing and using the network the maximum and minimum values won't
    ///   ever be extrapolated, otherwise erratic behaviour of the network may occur.
    /// </remarks>
    public class RangeConversion : IFilter
    {


        public RangeConversion()
        {
            throw new NotImplementedException();

        }



        #region IFilter Members

        public object Input
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object Output
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void Apply()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Name
        {
            get { return "Range Conversion"; }
        }

        public string Description
        {
            get { return "Converts from a range to another"; }
        }

        public System.Windows.Forms.Control Control
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

    }
}
