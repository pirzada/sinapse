using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using AForge.Math;
using AForge.Statistics;

namespace AForge.Statistics.Visualizations
{

    /// <summary>
    ///   In a more general mathematical sense, a histogram is a mapping Mi that counts
    ///   the number of observations that fall into various disjoint categories (known as bins).
    /// </summary>
    public class Histogram
    {

        public enum ViewMode { Standard, Cumulative };
        public enum IntervalSelectionMethod { Manual, Sturges, Scotts, FreedmanDiaconis };

        private string m_name;
        private int[] m_binValues;
        private double m_intervalSize;
        private SampleVector m_sourceData;
        private HistogramBinCollection m_binCollection;

        #region Constructors
        /// <summary>
        ///   
        /// </summary>
        /// <param name="data">Observations of a random variable.</param>
        public Histogram(double[] data)
        {
            this.m_sourceData = new SampleVector(data);
        }

        public Histogram(SampleVector data)
        {
            this.m_sourceData = data;
        }

        public Histogram(DataColumn data)
            : this(new SampleVector(data))
        {
        }
        #endregion


        #region Properties
        public String Title
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        public double Interval
        {
            get { return this.m_intervalSize; }
            set
            {
                this.m_intervalSize = value;
                this.Update();
            }
        }

        public SampleVector Source
        {
            get { return this.m_sourceData; }
            set
            {
                this.m_sourceData = value;
                this.Update();
            }
        }

        public int[] Values
        {
            get { return m_binValues; }
        }

        public DoubleRange Range
        {
            get { return this.m_sourceData.Range; }
        }
        #endregion


        #region Public Methods
        public void Update()
        {
            int segments = (int)System.Math.Ceiling(this.Range.Length / m_intervalSize);
            this.m_binValues = new int[segments];

            for (int i = 0; i < this.m_sourceData.Length; i++)
            {
                int index = (int)System.Math.Ceiling(this.m_sourceData[i] / segments);
                this.m_binValues[index]++;
            }

            HistogramBin[] bins = new HistogramBin[this.m_binValues.Length];
            for (int i = 0; i < this.m_binValues.Length; i++)
            {
                bins[i] = new HistogramBin(this, i);
            }
            this.m_binCollection = new HistogramBinCollection(bins);
        }
        #endregion
    }

    public class HistogramBinCollection : System.Collections.ObjectModel.ReadOnlyCollection<HistogramBin>
    {
        internal HistogramBinCollection(HistogramBin[] objects)
            : base(objects)
        {

        }
    }

    public class HistogramBin
    {

        int m_index;
        Histogram m_histogram;


        internal HistogramBin(Histogram histogram, int index)
        {
            this.m_index = index;
            this.m_histogram = histogram;
        }

        public DoubleRange Range
        {
            get
            {
                double min = this.m_histogram.Interval * this.m_index;
                double max = min + this.m_histogram.Interval;
                return new DoubleRange(min, max);
            }
        }

        public int Value
        {
            get { return m_histogram.Values[m_index]; }
        }
    }
}
