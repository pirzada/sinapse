using System;
using System.Collections.Generic;
using System.Text;

using AForge.Statistics;

using System.ComponentModel;

namespace Sinapse.Core.Filters.Table
{
    
    [DisplayName("Normalization")]
    [Description("This normalizes things")]
    [Serializable]
    class Normalization : ICompleteFilter
    {
        [Flags]
        public enum NormalizationMethod
        {
            Normalize = 0,
            Standardize = 2,
            Both = Normalize | Standardize
        }

        private double[] mean;
        private double[] stdDev;
        private int[] columnIndexes;
        private NormalizationMethod method;
        private int inputCount;

        

        public Normalization()
        {

        }

        public string Name
        {
            get { return "Normalization"; }
        }

        public double[] Means
        {
            get { return mean; }
            set { mean = value; }
        }

        public double[] StdDevs
        {
            get { return stdDev; }
            set { stdDev = value; }
        }

        public int[] ColumnIndex
        {
            get { return columnIndexes; }
            set { columnIndexes = value; }
        }

        public NormalizationMethod Method
        {
            get { return method; }
            set { method = value; }
        }

        public int InputCount
        {
            get { return inputCount; }
            set { inputCount = value; }
        }

        public int OutputCount
        {
            get { return inputCount; }
        }


        public void Apply(object input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Apply(object[] input)
        {
            if ((method & NormalizationMethod.Normalize) ==
                NormalizationMethod.Normalize)
            {
                // Subtract mean
                for (int i = 0; i < columnIndexes.Length; i++)
                {
                    int j = columnIndexes[i];
                    input[j] = (double)input[j] - mean[j];    
                }
                
            }

            if ((method & NormalizationMethod.Standardize) ==
                NormalizationMethod.Standardize)
            {
                // Divide by Standard Deviation
                for (int i = 0; i < columnIndexes.Length; i++)
                {
                    int j = columnIndexes[i];
                    input[j] = (double)input[j] / stdDev[j];
                }
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
