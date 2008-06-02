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
    public class Histogram
    {

        public enum SelectionRule { Scotts, Wand, FreedmanDiaconis };


        private int[] m_binValues;
        private double m_segmentSize;
        private int    m_segmentCount;
        private HistogramBinCollection m_binCollection;
        private DoubleRange m_range;
        private String m_title;

        //---------------------------------------------

        #region Constructors
        public Histogram()
            : this(String.Empty)
        {
        }

        public Histogram(String title)
        {
            this.m_title = title;
        }
        #endregion

        //---------------------------------------------

        #region Properties
        public int this[int index]
        {
            get { return m_binValues[index]; }
        }

        public String Title
        {
            get { return this.m_title; }
            set { this.m_title = value; }
        }

        public Double SegmentSize
        {
            get { return this.m_segmentSize; }
        }

        public int SegmentCount
        {
            get { return this.m_segmentCount; }
        }

        public int[] Values
        {
            get { return m_binValues; }
        }

        public DoubleRange Range
        {
            get { return m_range; }
        }

        public HistogramBinCollection Bins
        {
            get { return m_binCollection; }
        }
        #endregion

        //---------------------------------------------

        #region Public Methods
        public void Compute(Double[] data, SelectionRule rule)
        {
            //TODO: use a more object oriented approach other than enumerating rules

            double width = 1.0;

            switch (rule)
            {
                case SelectionRule.Scotts:
                    width = (3.5 * Tools.StandardDeviation(data)) / Math.Pow(data.Length, 1.0 / 3.0);
                    
                    break;

                case SelectionRule.FreedmanDiaconis:
                    //double width = 2.0 * Quartile.Range / Math.Pow(data.Length, 1.0 / 3.0);
                    break;

                default:
                    goto case SelectionRule.Scotts;
            }

            Compute(data, width);
        }

        public void Compute(Double[] data, double segmentSize)
        {
            this.m_range = DoubleRange.GetRange(data);
            this.m_segmentSize = segmentSize;
            this.m_segmentCount = (int)Math.Ceiling(m_range.Length / segmentSize);
            this.Compute(data);
        }

        public void Compute(Double[] data, int segmentCount)
        {
            this.m_range = DoubleRange.GetRange(data);
            this.m_segmentCount = segmentCount;
            this.m_segmentSize = this.m_range.Length / segmentCount;
            this.Compute(data);
        }

        public void Compute(Double[] data)
        {
            // Create Bins
            this.m_binValues = new int[this.m_segmentCount];
            HistogramBin[] bins = new HistogramBin[this.m_segmentCount];
            for (int i = 0; i < this.m_segmentCount; i++)
            {
                bins[i] = new HistogramBin(this, i);
            }
            this.m_binCollection = new HistogramBinCollection(bins);

            // Populate Bins
            for (int i = 0; i < data.Length; i++)
            {
                int index = (int)Math.Floor(RangeConversion.Convert(data[i], m_range, new DoubleRange(0, m_segmentCount)));
                index = Math.Min(Math.Max(0, index), m_segmentCount-1);
                this.m_binValues[index]++;
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
            // This method is buggy due to the finite precision of double numbers.
            foreach (HistogramBin bin in this)
            {
                if (bin.Range.IsInside(Math.Round(value,14)))
                    return bin;
            }
            return null;
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
                double min = this.m_histogram.Range.Min + this.m_histogram.SegmentSize * this.m_index;
                double max = min + this.m_histogram.SegmentSize;
                return new DoubleRange(min, max);
            }
        }

        public int Value
        {
            get { return this.m_histogram.Values[m_index]; }
            internal set { this.m_histogram.Values[m_index] = value; }
        }

    }
}
