/***************************************************************************
 *                                                                         *
 *  Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com>  *
 *                                                                         *
 *  Please note that this code is not part of the original AForge.NET      *
 *  library. This extension was created to support new features needed by  *
 *  Sinapse, a neural networking tool software. Unless otherwise advised,  *
 *  this code relies under protection of the GNU General Public License v3 *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Data;

using AForge.Mathematics;
using AForge.Statistics;


namespace AForge.Statistics.Visualizations
{

    /// <summary>
    ///   In a more general mathematical sense, a histogram is a mapping Mi that counts
    ///   the number of observations that fall into various disjoint categories (known as bins).
    /// </summary>
    /// <remarks>
    ///   This class represents a Discrete or Continuous Histogram mapping. To use it as a
    ///   discrete histogram, pass a bin size (length) of 1. To use it as a continuous mapping,
    ///   pass any real number instead.
    /// </remarks>
    public class Histogram
    {

        /// <summary>
        ///   Defines a rule to select the width of bins to be used in a Histogram.
        /// </summary>
        public enum SelectionRule
        { 
            /// <summary>
            ///   Use the Scott's rule to select the best width for histogram bins.
            /// </summary>
            Scotts,
            /// <summary>
            ///   Use the Wand's rule to select the best width for histogram bins. 
            /// </summary>
            Wand,
            /// <summary>
            ///   Use the FreedmanDiacones rule to select the best width for histogram bins.
            /// </summary>
            FreedmanDiaconis
        };


        private int[] m_binValues;
        internal double m_binWidth;
        private  int    m_binCount;
        private double  m_total;
        private HistogramBinCollection m_binCollection;
        private DoubleRange m_range;

        private String m_title;


        //---------------------------------------------

        #region Constructors
        /// <summary>
        ///   Constructs an empty histogram
        /// </summary>
        public Histogram()
            : this(String.Empty)
        {
        }

        /// <summary>
        ///   Constructs an empty histogram
        /// </summary>
        /// <param name="title">The title of this histogram.</param>
        public Histogram(String title)
        {
            this.m_title = title;
        }

        /// <summary>
        ///   Constructs an discrete histogram using already given histogram bins in int[] form.
        /// </summary>
        /// <param name="histogram"></param>
        public Histogram(int[] histogram)
            : this(histogram, 1.0f)
        {
        }

        /// <summary>
        ///   Constructs an continuous histogram using already given histogram bins in int[] form.
        /// </summary>
        /// <param name="histogram"></param>
        public Histogram(int[] histogram, double binSize)
        {
            m_binValues = histogram;
            m_binCount = histogram.Length;
            m_binWidth = binSize;
            m_range = Histogram.Tools.GetRange(histogram, m_binWidth, 1.0f);
            m_total = Histogram.Tools.Sum(histogram, binSize);
        }


        /// <summary>
        ///   Constructs an histogram computing the given data in double[] form.
        /// </summary>
        /// <param name="data"></param>
        public Histogram(double[] data)
        {
            this.Compute(data, SelectionRule.Scotts);
        }
        #endregion

        //---------------------------------------------

        #region Properties
        /// <summary>Gets the Bin values of this Histogram.</summary>
        /// <param name="index">Bin index.</param>
        /// <returns>The number of hits of the selected bin.</returns>
        public int this[int index]
        {
            get { return m_binValues[index]; }
        }

        /// <summary>Gets the name for this Histogram.</summary>
        public String Title
        {
            get { return this.m_title; }
            set { this.m_title = value; }
        }

        /// <summary>Gets the Bin values for this Histogram.</summary>
        public int[] Values
        {
            get { return m_binValues; }
        }

        /// <summary>Gets the total ammount of Bins for this Histogram.</summary>
        public int Count
        {
            get { return m_binCount; }
        }

        /// <summary>Gets the total sum for the values on this Histogram.</summary>
        public double Total
        {
            get { return m_total; }
        }

        /// <summary>Gets the Range of the values in this Histogram.</summary>
        public DoubleRange Range
        {
            get { return m_range; }
        }

        /// <summary>Gets the collection of bins of this Histogram.</summary>
        public HistogramBinCollection Bins
        {
            get { return m_binCollection; }
        }
        #endregion

        //---------------------------------------------

        #region Public Methods
        /// <summary>
        ///   Computes (populates) an Histogram mapping with values from a sample. A selection rule
        ///   can be (optionally) chosen to better organize the histogram.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rule"></param>
        public void Compute(Double[] data, SelectionRule rule)
        {
            //TODO: use a more object oriented approach other than enumerating rules

            double width = 1.0;

            switch (rule)
            {
                case SelectionRule.Scotts:
                    width = (3.5 * Statistics.Tools.StandardDeviation(data)) / Math.Pow(data.Length, 1.0 / 3.0);
                    break;

                case SelectionRule.FreedmanDiaconis:
                    throw new NotImplementedException();
                    //double width = 2.0 * Quartile.Range / Math.Pow(data.Length, 1.0 / 3.0);
                    break;

                case SelectionRule.Wand:
                    throw new NotImplementedException();
                    break;

                default:
                    goto case SelectionRule.Scotts;
            }

            this.Compute(data, width);
        }

        /// <summary>
        ///   Computes (populates) an Histogram mapping with values from a sample. A selection rule
        ///   can be (optionally) chosen to optimize the histogram visualization.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="segmentSize"></param>
        public void Compute(Double[] data, double segmentSize)
        {
            this.m_range = DoubleRange.GetRange(data);
            this.m_binWidth = segmentSize;
            this.m_binCount = (int)Math.Ceiling(m_range.Length / segmentSize);
            this.Compute(data);
        }

        /// <summary>
        ///   Computes (populates) an Histogram mapping with values from a sample. A selection rule
        ///   can be (optionally) chosen to better organize the histogram.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="segmentCount"></param>
        public void Compute(Double[] data, int segmentCount)
        {
            this.m_range = DoubleRange.GetRange(data);
            this.m_binCount = segmentCount;
            this.m_binWidth = this.m_range.Length / segmentCount;
            this.Compute(data);
        }

        /// <summary>
        ///   Computes (populates) an Histogram mapping with values from a sample. A selection rule
        ///   can be (optionally) chosen to better organize the histogram.
        /// </summary>
        /// <param name="data"></param>
        public void Compute(Double[] data)
        {
            // Create additional information
            this.m_total = ((Vector)data).Sum;

            // Create Bins
            this.m_binValues = new int[this.m_binCount];
            HistogramBin[] bins = new HistogramBin[this.m_binCount];
            for (int i = 0; i < this.m_binCount; i++)
            {
                bins[i] = new HistogramBin(this, i);
            }
            this.m_binCollection = new HistogramBinCollection(bins);

            // Populate Bins
            for (int i = 0; i < data.Length; i++)
            {
                int index = (int)Math.Floor(Mathematics.Tools.Scale(data[i], m_range, new DoubleRange(0, m_binCount)));
                index = Math.Min(Math.Max(0, index), m_binCount - 1);
                this.m_binValues[index]++;
            }
        }

        public void GetGoodnessOfFitTest()
        {
            throw new NotImplementedException();
        }
        #endregion

        //---------------------------------------------

        #region Operators
        public static implicit operator int[](Histogram value)
        {
            return value.m_binValues;
        }
        #endregion

        //---------------------------------------------

        #region Histogram Statistic Tools
        /// <summary>
        ///   This static class provides statistical tools to work with Histograms.
        /// </summary>
        public static class Tools
        {

            /// <summary>
            ///   Reconstructs the original data that originated the given Histogram.
            /// </summary>
            /// <param name="values"></param>
            /// <param name="binSize"></param>
            /// <returns></returns>
            public static Double[] Reconstruct(int[] values, double binSize)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///   Estimates a Histogram mean value.
            /// </summary>
            /// <param name="values">Histogram array.</param>
            /// <returns>Returns mean value.</returns>
            /// <remarks>
            ///   The input array is treated as histogram, i.e. its indexes
            ///   are treated as values of stochastic function, but array
            ///   values are treated as "probabilities" (total amount of hits).
            /// </remarks>
            public static double Mean(int[] values, double binSize)
            {
                /*
                     For the "best" estimate, we shall assume that the data is uniformly spread
                   within each class. (There are other ways to define "best", which will produce
                   different results.) This is equivalent for purposes of calculating the mean
                   to putting all the individuals in each class at the class mark.
                              
                */

                int hitsCount = 0;
                double sum = 0.0;

                // for all values
                for (int i = 0; i < values.Length; i++)
                {
                    // accumulate mean
                    sum += i * binSize * values[i];

                    // accumulate total
                    hitsCount += values[i];
                }
                return sum / hitsCount;
            }


            /// <summary>
            ///   Estimates a Histogram mean value.
            /// </summary>
            /// <param name="values">Histogram array.</param>
            /// <returns>Returns mean value.</returns>
            /// <remarks>
            ///   The input array is treated as histogram, i.e. its indexes
            ///   are treated as values of stochastic function, but array
            ///   values are treated as "probabilities" (total amount of hits).
            /// </remarks>
            public static double Mean(int[] values)
            {
                return (double)Mean(values, 1.0);
            }

            /// <summary>
            ///   Estimates a Histogram standard deviation.
            /// </summary>
            /// <param name="values">Histogram array.</param>
            /// <returns>Returns value of standard deviation.</returns>
            /// <remarks>
            ///   The input array is treated as histogram, i.e. its indexes
            ///   are treated as values of stochastic function, but array
            ///   values are treated as "probabilities" (total amount of hits).
            /// </remarks>
            public static double StandardDeviation(int[] values, double binSize)
            {
                double mean = Mean(values, binSize);
                double stddev = 0.0;
                double centeredValue = 0.0;
                int hitsCount = 0;

                // for all values
                for (int i = 0; i < values.Length; i++)
                {
                    centeredValue = (i * binSize) - mean;

                    // accumulate mean
                    stddev += centeredValue * centeredValue * values[i];

                    // accumulate total
                    hitsCount += values[i];
                }

                return Math.Sqrt(stddev / hitsCount);
            }

            /// <summary>
            ///   Estimates a Histogram standard deviation.
            /// </summary>
            /// <param name="values">Histogram array.</param>
            /// <returns>Returns value of standard deviation.</returns>
            /// <remarks>
            ///   The input array is treated as histogram, i.e. its indexes
            ///   are treated as values of stochastic function, but array
            ///   values are treated as "probabilities" (total amount of hits).
            /// </remarks>
            public static double StandardDeviation(int[] values)
            {
                return (double)StandardDeviation(values, 1.0);
            }

            /// <summary>
            ///   Calculate median value.
            /// </summary>
            /// 
            /// <param name="values">Histogram array.</param>
            /// 
            /// <returns>Returns value of median.</returns>
            /// 
            /// <remarks>
            ///   The input array is treated as histogram, i.e. its indexes
            ///   are treated as values of stochastic function, but array
            ///   values are treated as "probabilities" (total amount of hits).
            /// </remarks>
            public static double Median(int[] values, double binSize)
            {
                /*               
             
                    A histogram is constructed so that area is proportional to the number of individuals,
                  hence seeking the value with half the individuals above it and half the individual
                  below it is seeking the value where the area under the histogram to the right of it
                  is equal to the area under the histogram to the left of it. Suppose each of the
                  rectangles in a histogram has a base of 25, and the heights are 3, 7, 8, 10, 1, and 1.
              
                    Thus the total area of the histogram is 3x25+7x25+8x25+10x25+1x25+1x25=750. We want
                  the value with area 750/2=375 to the right of it and 375 to the left of it. The area
                  of the first rectangle is 75, which is less than 375; the area of the first two
                  rectangles is 75+175=250, which is still less than 375; the area of the first three
                  rectangles is 75+175+200=450 which is greater than 375. Therefore we need an area
                  of 375-(75+175)=125 from the third rectangle to get the middle.
              
                   Since the height of the third rectangle is 8, we must use 125/8=15.62 of its base to
                  get the requisite area. The third rectangle begins at 137.5; upon adding 15.62 to that
                  we get 153.12, which is the "best" estimate for the median.
              
                 */

                double total = Sum(values, binSize);

                double halfTotal = total / 2;
                double lastCumulative = 0.0;
                double cumulative = 0.0;
                double medianArea = 0.0;
                double median = 0.0;

                for (int i = 0; i < values.Length; i++)
                {
                    lastCumulative = cumulative;
                    cumulative += values[i];

                    if (lastCumulative < halfTotal &&
                        cumulative > halfTotal)
                    {
                        medianArea = cumulative - lastCumulative;
                        median = values[i] + medianArea / values[i];
                        continue;
                    }

                }

                return median;
            }

            public static int Median(int[] values)
            {
                return (int)Median(values, 1.0);
            }

            public static double Sum(int[] values, double binSize)
            {
                double sum = 0.0;

                for (int i = 0; i < values.Length; i++)
                {
                    sum += values[i] * i * binSize;
                }

                return sum;
            }

            public static int Sum(int[] values)
            {
                return (int)Sum(values, 1.0);
            }

            /// <summary>
            ///   Calculate an entropy.
            /// </summary>
            /// 
            /// <param name="values">Histogram array.</param>
            /// 
            /// <returns>Returns entropy value.</returns>
            /// 
            /// <remarks>
            ///   The input array is treated as histogram, i.e. its indexes
            ///   are treated as values of stochastic function, but array
            ///   values are treated as "probabilities" (total amount of hits).
            /// </remarks>
            public static double Entropy(int[] values, double binSize)
            {
                /*  
                      The histogram entropy is defined to be the negation of the sum of
                    the products of the probability associated with each bin with the
                    base-2 log of the probability.
                
                */

                int n = values.Length;
                double sum = 0.0;
                double entropy = 0.0;
                double p = 0.0;

                sum = Sum(values, binSize);

                // for all values
                for (int i = 0; i < n; i++)
                {
                    // get item's probability
                    p = (double)values[i] / sum;

                    // calculate entropy
                    if (p != 0)
                        entropy += (-p * Math.Log(p, 2));
                }
                return entropy;
            }

            public static double Entropy(int[] values)
            {
                return Entropy(values, 1.0);
            }

            /// <summary>
            ///   Get range around median containing specified percentage of values.
            /// </summary>
            /// 
            /// <param name="values">Histogram array.</param>
            /// <param name="percent">Values percentage around median.</param>
            /// 
            /// <returns>Returns the range which containes specifies percentage
            /// of values.</returns>
            /// 
            /// <remarks>
            ///   The input array is treated as histogram, i.e. its indexes
            ///   are treated as values of stochastic function, but array
            ///   values are treated as "probabilities" (total amount of hits).
            /// </remarks>
            public static DoubleRange GetRange(int[] values, double binSize, float percent)
            {
                throw new NotImplementedException();

         /*       int total = Sum(values, binSize);

                int min, max, hits;
                int h = (int)(total * (percent + (1 - percent) / 2));
                int n = values.Length;
                int nM1 = n - 1;

                // skip left portion
                for (min = 0, hits = total; min < n; min++)
                {
                    hits -= values[min];
                    if (hits < h)
                        break;
                }
                // skip right portion
                for (max = nM1, hits = total; max >= 0; max--)
                {
                    hits -= values[max];
                    if (hits < h)
                        break;
                }
                // return range between left and right boundaries
                return new DoubleRange(
                   ((double)min / nM1) * range.Length + range.Min,
                    ((double)max / nM1) * range.Length + range.Min);
          */ 
            }


            public static IntRange GetRange(int[] values, float percent)
            {
                return (IntRange)GetRange(values, 1.0, percent);
            }
        }
        #endregion

    }


    public class HistogramBinCollection : System.Collections.ObjectModel.ReadOnlyCollection<HistogramBin>
    {
        internal HistogramBinCollection(HistogramBin[] objects)
            : base(objects)
        {

        }

        public HistogramBin Search(double value)
        {
            // This method sometimes fails due to the finite precision of double numbers.
            foreach (HistogramBin bin in this)
            {
             // if (bin.Range.IsInside(Math.Round(value,14)))
                if (bin.Range.IsInside(value))
                    return bin;
            }
            return null;
        }
    }

    
    /// <summary>
    ///   A "bin" is a container, where each element stores the total number of observations of a sample
    ///   whose values lie within a given range. A histogram of a sample consists of a list of such bins
    ///   whose range does not overlap with each other; or in other words, bins that are mutually exclusive.
    /// </summary>
    public class HistogramBin
    {

        private int m_index;
        private Histogram m_histogram;


        internal HistogramBin(Histogram histogram, int index)
        {
            this.m_index = index;
            this.m_histogram = histogram;
        }

        /// <summary>Gets the actual range of data this bin represents.</summary>
        public DoubleRange Range
        {
            get
            {
                double min = this.m_histogram.Range.Min + this.m_histogram.m_binWidth * this.m_index;
                double max = min + this.m_histogram.m_binWidth;
                return new DoubleRange(min, max);
            }
        }

        /// <summary>Gets the Width (range) for this histogram bin.</summary>
        public double Width
        {
            get { return this.m_histogram.m_binWidth; }
        }

        /// <summary>
        ///   Gets the Value (number of occurances of a variable in a range)
        ///   for this histogram bin.
        /// </summary>
        public int Value
        {
            get { return this.m_histogram.Values[m_index]; }
            internal set { this.m_histogram.Values[m_index] = value; }
        }

    }
}
