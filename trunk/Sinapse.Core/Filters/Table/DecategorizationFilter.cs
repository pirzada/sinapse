using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Filters.Table
{
    /// <summary>
    ///   This filter reverts a categorization filter, by using the same dictionary
    ///  to recreate the old column of string values. However, since this will be tipically
    ///  the output of a Adaptive System, we cannot garantee every nummeric value
    ///  encountered will be found on the dictionary
    /// </summary>
    class DecategorizationFilter : IFilter
    {
        bool includeErrorColumn;
        string columnName;




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
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Apply()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Name
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Description
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public System.Windows.Forms.Control Control
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
