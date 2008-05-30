using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AForge.Statistics
{

    /// <summary>
    /// Sample Variable
    /// </summary>
    public class SampleVector : AForge.Math.Vector
    {

        string m_colName;

        public SampleVector(string name, params double[] values)
            : base(values)
        {
            this.m_colName = name;
        }

        public SampleVector(params double[] values)
            : this(String.Empty, values)
        {
        }

        public SampleVector(int size, string name) : base(size)
        {
            this.m_colName = name;
        }

        public SampleVector(int size)
            : this(size, String.Empty)
        {
        }

        public SampleVector(DataColumn dataColumn)
            : base(dataColumn)
        {
            this.m_colName = dataColumn.ColumnName;
        }

    }
}
