using System;
using System.Collections.Generic;
using System.Text;

using AForge.Statistics;


namespace Sinapse.Core.Filters.Table
{
    class Normalization : ICompleteFilter
    {
        [Flags]
        public enum Method
        {
            Normalize = 0,
            Standardize = 2,
            Both = Normalize | Standardize
        }

        private double mean;
        private double stdDev;
        private int columnIndex;
        private Method method;

        

        public Normalization()
        {

        }

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
            throw new Exception("The method or operation is not implemented.");
        }

        public void Apply(object[] input)
        {
            if ((method & Method.Normalize) == Method.Normalize)
            {
                // Subtract mean
                input[columnIndex] = (double)input[columnIndex] - mean;
            }

            if ((method & Method.Standardize) == Method.Standardize)
            {
                // Divide by Standard Deviation
                input[columnIndex] = (double)input[columnIndex]/stdDev;
            }
        }

        public void Apply(object[][] input)
        {
            foreach (object[] row in input)
            {
                Apply(row);
            }
        }



        public void Reverse(object input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Reverse(object[] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Reverse(object[][] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }
}
