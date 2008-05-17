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
using System.Text;

using AForge.Math;

namespace AForge.Statistics.SampleAnalysis
{
    

    public class DescriptiveAnalysis
    {

        private Vector m_mean;
        private Vector m_stdDev;
        private Vector m_variance;
        private Vector m_median;
        private Vector m_mode;

        private Matrix m_covMatrix;
        private Matrix m_corMatrix;
        private Matrix m_zScores;
        private Matrix m_dScores;

        private DescriptiveMeasureCollection m_measuresCollection;

        private Matrix m_sourceData;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public DescriptiveAnalysis(Matrix data)
        {
            this.m_sourceData = data;
            
            
            // Run analysis
            this.m_mean = Statistics.Tools.Mean(data);
            this.m_stdDev = Statistics.Tools.StandardDeviation(data, m_mean);
            
            this.m_dScores = m_sourceData.Clone();
            Statistics.Tools.Center(m_dScores, m_mean);
            
            this.m_zScores = Statistics.Tools.ZScores(data, m_mean, m_stdDev);

            this.m_median = Statistics.Tools.Median(data);
            this.m_mode = Statistics.Tools.Mode(data);
            this.m_variance = Statistics.Tools.Variance(data, m_mean);

            this.m_covMatrix = Statistics.Tools.Covariance(data, m_mean);
            this.m_corMatrix = Statistics.Tools.Covariance(m_zScores);

            
            // Create object-oriented structure to access data
            DescriptiveMeasures[] measures = new DescriptiveMeasures[m_sourceData.Columns];
            for (int i = 0; i < measures.Length; i++)
            {
                measures[i] = new DescriptiveMeasures(this, i); 
            }
            this.m_measuresCollection = new DescriptiveMeasureCollection(measures);

        }


        #region Properties
        public Matrix Source
        {
            get { return m_sourceData; }
        }

        /// <summary>
        /// Gets the mean subtracted data.
        /// </summary>
        public Matrix DeviationScores
        {
            get { return this.m_dScores; }
        }

        /// <summary>
        /// Gets the mean subtracted and deviation divided data. Also known as Z-Scores.
        /// </summary>
        public Matrix StandardScores
        {
            get { return this.m_zScores; }
        }

        /// <summary>
        /// Gets the Covariance Matrix
        /// </summary>
        /// <seealso cref="AForge.Statistics.Tools.CovarianceMatrix"/>
        public Matrix CovarianceMatrix
        {
            get { return m_covMatrix; }
        }

        /// <summary>
        /// Gets the Correlation Matrix
        /// </summary>
        /// <seealso cref="AForge.Statistics.Tools.CorrelationMatrix"/>
        public Matrix CorrelationMatrix
        {
            get { return m_corMatrix; }
        }

        /// <summary>
        /// Gets a vector containing the Mean of each column of data.
        /// </summary>
        public Vector Means
        {
            get { return m_mean; }
        }

        /// <summary>
        /// Gets a vector containing the Standard Deviation of each column of data.
        /// </summary>
        public Vector StandardDeviations
        {
            get { return m_stdDev; }
        }

        /// <summary>
        /// Gets a vector containing the Mode of each column of data.
        /// </summary>
        public Vector Modes
        {
            get { return m_mode; }
        }

        /// <summary>
        /// Gets a vector containing the Median of each column of data.
        /// </summary>
        public Vector Medians
        {
            get { return m_median; }
        }

        /// <summary>
        /// Gets a vector containing the Variance of each column of data.
        /// </summary>
        public Vector Variances
        {
            get { return m_variance; }
        }

        /// <summary>
        /// Gets a collection of DescriptiveMeasures objects that can be bound to a DataGridView.
        /// </summary>
        public DescriptiveMeasureCollection Measures
        {
            get { return m_measuresCollection; }
        }
        #endregion


    }


    public class DescriptiveMeasures
    {

        private DescriptiveAnalysis m_analysis;
        private int m_index;
        
        public DescriptiveMeasures(DescriptiveAnalysis analysis, int index)
        {
            this.m_analysis = analysis;
            this.m_index = index;
        }

        public int Index
        {
            get { return m_index; }
        }

        public double Mean
        {
         get { return m_analysis.Means[m_index]; }
        }

        public double StandardDeviation
        {
            get { return m_analysis.StandardDeviations[m_index]; }
        }

        public double Median
        {
            get { return m_analysis.Medians[m_index]; }
        }

        public double Mode
        {
            get { return m_analysis.Modes[m_index]; }
        }

        public double Variance
        {
            get { return m_analysis.Variances[m_index]; }
        }

    }


    public class DescriptiveMeasureCollection : System.Collections.ObjectModel.ReadOnlyCollection<DescriptiveMeasures>
    {
        internal DescriptiveMeasureCollection(DescriptiveMeasures[] components)
            : base(components)
        {

        }
    }
}
