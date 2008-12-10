using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Filters.Table
{
    /// <summary>
    ///   This filter can replace strings into numbers, indexing every different
    ///  word in a Dictionary, deleting the column and then inserting a new column
    ///  with only nummeric (integer) data.
    /// </summary>
    class CategorizationFilter : IFilter
    {
        Dictionary<int, string> dictionary;


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
