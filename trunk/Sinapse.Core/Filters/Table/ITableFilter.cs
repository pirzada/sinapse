using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Sinapse.Core.Filters.Table
{
    public interface ITableFilter
    {

        public DataTable Input
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

        public override object Output
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            protected set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override void Apply()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
