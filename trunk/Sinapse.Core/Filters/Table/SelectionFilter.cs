using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using AForge.Mathematics;


namespace Sinapse.Core.Filters.Table
{
    class SelectionFilter : IFilter
    {

        public string Name
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Description
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }


        public int InputCount
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int OutputCount
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Apply(object input)
        {
            if (input is DataView)
            {
            }
            else if (input is DataTable)
            {
                DataTable table = input as DataTable;
                
            }
            else if (input is Matrix)
            {
            }
            else // input is object[][]
            {

            }
        }

        public void Apply(object[] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Apply(object[][] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }



    }
}
