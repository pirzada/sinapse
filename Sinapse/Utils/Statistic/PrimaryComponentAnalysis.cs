/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

using AForge.Math;

namespace Sinapse.Utils.Statistic
{
    internal sealed class PrimaryComponentAnalysis
    {
        /*
         
         Suppose you have data comprising a set of observations of M variables, and you want
         to reduce the data so that each observation can be described with only L variables,
         L < M. Suppose further, that the data are arranged as a set of N data vectors X1...Xn
         with each Xn  representing a single grouped observation of the M variables.
         
           - Write X1...Xn  as column vectors, each of which has M rows.
           - Place the column vectors into a single matrix X of dimensions M × N.
         
         So each row (M) represents a variable, each column (N) represents a observation of those variables.
        
         
         Steps:

             * Step 1: Get some data
             * Step 2: Subtract the mean
             * Step 3: Calculate the covariance matrix
             * Step 4: Calculate the eigenvectors and eigenvalues of the covariance matrix
             * Step 5: Choosing components and forming a feature vector
             * Step 5: Deriving the new data set
         
        */

        private Matrix m_originalData;
        private Matrix m_adjustedData;
        private double[] m_means;
        private double[] m_stdDev;
        private double[] m_eigenvalues;


        //---------------------------------------------


        #region Constructor
        public PrimaryComponentAnalysis(double[][] data)
            : this(new Matrix(data))
        {
        }

        public PrimaryComponentAnalysis(Matrix data)
        {
            // Step 1: Get some data
            this.m_originalData = data;
            this.m_adjustedData = new Matrix(data.Rows, data.Columns);
            

            // Step 2.1: Calculate variables (rows) means
            for (int i = 0; i < this.m_originalData.Rows; ++i)
            {
                this.m_means[i] = Statistics.Mean(m_originalData[i]);

                for (int j = 0; j < this.m_originalData.Columns; ++j)
                {
                    // Step 2.2: Create adjusted matrix with subtracted mean
                    this.m_adjustedData[i,j] = this.m_originalData[i][j] - this.m_means[i];
                }
            }


            // Step 3: Calculate the covariance matrix
            Matrix cov = (1.0 / this.Observations) * (this.m_adjustedData * this.m_adjustedData.Transpose());


            // Step 4: Calculate the eigenvectors and eigenvalues of the covariance matrix

            

        }
        #endregion


        //---------------------------------------------


        #region Properties
        /*     public double[] CumulativeVarianceProportions
        {
            get { }
        }
*/
        /// <summary>
        /// Returns the original supplied data to be analyzed.
        /// </summary>
        public Matrix OriginalData
        {
            get { return this.m_originalData;  }
        }

        /// <summary>
        /// Returns the adjust matrix calculated subtracting the means from the original data.
        /// </summary>
        public Matrix AdjustedData
        {
            get { return this.m_adjustedData; }
        }


        public double[] Eigenvalues
        {
            get { return this.m_eigenvalues; }
        }
   /*     public bool IsCentered
        {
            get { }
        }
        public bool IsScaled
        {
            get { }
        }
        public double[] Item
        {
            get { }
        }
        public double[][] Loadings
        {
            get { }
        }
     */   public double[] Means
        {
            get { return this.m_means; }
        }
    /*    public double[] Norms
        {
            get { }
        }
     */
        public int Observations
        {
            get { return this.m_originalData.Columns;  }
        }
        public int Variables
        {
            get { return this.m_originalData.Rows; }
        }
     /*   public double[][] Scores
        {
            get { }
        }
      */ 
        public double[] StandardDeviations
        {
            get { return this.m_stdDev; }
        }

 /*       public double[] VarianceProportions
        {
            get { }
        }
  */ 
        #endregion


        //---------------------------------------------


        #region Public Methods
   /*     public int Threshold(double varianceProportion)
        {
        }
    */ 
        #endregion


        //---------------------------------------------


        #region Private Methods
      
        #endregion


        //---------------------------------------------

    }
}
