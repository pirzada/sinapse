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

namespace AForge.Math.Statistic
{

    public enum DataModel { RowsAsObservations, ColumnsAsObservations };


    /// <summary>
    /// In statistics, a sample is a subset of a population.
    /// </summary>
    public class SampleMatrix : Matrix, ICloneable
    {

        private string[] m_colNames;


        //---------------------------------------------


        #region Constructors
        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The base matrix</param>
        /// <param name="model">The matrix model</param>
        public SampleMatrix(double[][] matrix, DataModel model)
            : base(matrix)
        {
            if (model == DataModel.ColumnsAsObservations)
                this.BaseMatrix = this.Transpose().ToDoubleArray();

            this.generateDefaultNames();
        }

        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The base matrix</param>
        /// <param name="model">The matrix model</param>
        public SampleMatrix(double[,] matrix, DataModel model)
            : base(matrix)
        {
            if (model == DataModel.ColumnsAsObservations)
                this.BaseMatrix = this.Transpose().ToDoubleArray();

            this.generateDefaultNames();
        }

        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The base matrix</param>
        /// <param name="model">The matrix model</param>
        public SampleMatrix(Matrix matrix, DataModel model)
            : base(new Matrix(matrix))
        {
            if (model == DataModel.ColumnsAsObservations)
                this.BaseMatrix = this.Transpose().ToDoubleArray();

            this.generateDefaultNames();
        }

        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The matrix to be copied.</param>
        public SampleMatrix(SampleMatrix matrix)
            : base((Matrix)matrix)
        {
            this.m_colNames = matrix.m_colNames;
 //           this.m_rowNames = matrix.m_rowNames;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        /// The number of observations contained on this sample
        /// </summary>
        public int Observations
        {
            get { return base.Rows; }
        }

        /// <summary>
        /// The number of variables (data dimension) of this sample
        /// </summary>
        public int Variables
        {
            get { return base.Columns; }
        }

     /*
        /// <summary>
        /// The row (observations) labels of this sample.
        /// </summary>
        public string[] RowNames
        {
              get { return this.m_rowNames; }
        }
     */

        /// <summary>
        /// The column (variables) labels of this sample.
        /// </summary>
        public string[] ColumnNames
        {
            get { return this.m_colNames; }
        }

        /// <summary>
        /// Retrieves a item from the sample
        /// </summary>
        /// <param name="variable">The variable index of the requested item</param>
        /// <param name="observation">The observation index of the requested item</param>
        /// <returns></returns>
        public new double this[int variable, int observation]
        {
            get
            {
                // Always consider columns as variables, rows as observations
                    return base[observation, variable];
            }
            set
            {
                    base[observation, variable] = value;
            }
        }

        /// <summary>
        /// Retrieves a item from the sample
        /// </summary>
        /// <param name="variable">The variable label of the requested item</param>
        /// <param name="observation">The observation index of the requested item</param>
        /// <returns></returns>
        public double this[string variable, int observation]
        {
            get
            {
                int index = Array.IndexOf(this.m_colNames, variable);
                return this[index, observation];
            }
            set
            {
                int index = Array.IndexOf(this.m_colNames, variable);
                this[index, observation] = value;
            }
        }

        /// <summary>
        /// Finds the empirical mean along each dimension
        /// </summary>
        public Vector Mean
        {
            get
            {
                Vector mean = new Vector(this.Variables);

                for (int i = 0; i < this.Variables; i++)
                {
                    for (int j = 0; j < this.Observations; j++)
                    {
                        mean[i] += this[i, j];
                    }

                    mean[i] /= (double)this.Observations;
                }

                return mean;
            }
        }

        /// <summary>
        /// Finds the empirical standard deviation along each dimension
        /// </summary>
        public Vector StandardDeviation
        {
            get
            {
                Vector mean = this.Mean;
                Vector std = new Vector(this.Variables);

                for (int i = 0; i < this.Variables; ++i)
                {
                    for (int j = 0; j < this.Observations; ++j)
                    {
                        std[i] += System.Math.Pow((this[i, j] - mean[i]), 2);
                    }

                    std[i] /= (double)this.Observations;
                    std[i] = System.Math.Sqrt(std[i]);

                    // The following in an inelegant but usual way to handle
                    //   near-zero std. dev. values, which below would cause a zero- divide.

                    if (std[i] <= Double.Epsilon)
                        std[i] = 1.0;
                }

                return std;
            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        /// <summary>
        /// Centers column data, subtracting the empirical mean
        /// from each variable.
        /// </summary>
        public void Center()
        {
            Vector mean = this.Mean;

            for (int i = 0; i < this.Variables; ++i)
            {
                for (int j = 0; j < this.Observations; ++j)
                {
                    this[i, j] -= mean[i];
                }
            }
        }

        /// <summary>
        /// Standardizes column data, removing the empirical
        /// standard deviation from each variable.
        /// </summary>
        public void Standardize()
        {
            Vector std = this.StandardDeviation;

            for (int i = 0; i < this.Variables; ++i)
            {
                for (int j = 0; j < this.Observations; ++j)
                {
                    this[i, j] /= System.Math.Sqrt(this.Observations) * std[i];
                }
            }
        }

        /// <summary>
        /// Calculates the covariance matrix of this samples, returning a new matrix object
        /// </summary>
        /// <remarks>
        /// In statistics and probability theory, the covariance matrix is a matrix of
        /// covariances between elements of a vector. It is the natural generalization
        /// to higher dimensions of the concept of the variance of a scalar-valued
        /// random variable.
        /// </remarks>
        /// <returns>The covariance matrix.</returns>
        public Matrix GenerateCovarianceMatrix()
        {
            SampleMatrix m = new SampleMatrix(this);
            m.Center();
            return (1.0 / (m.Observations - 1)) * m.Transpose() * (Matrix)m;
        }

        /// <summary>
        /// Calculates the correlation matrix of this samples, returning a new matrix object
        /// </summary>
        /// <remarks>
        /// In statistics and probability theory, the correlation matrix is the same
        /// as the covariance matrix of the standardized random variables.
        /// </remarks>
        /// <returns>The correlation matrix</returns>
        public Matrix GenerateCorrelationMatrix()
        {
            SampleMatrix m = new SampleMatrix(this);
            m.Center();
            m.Standardize();
            return (1.0 / (m.Observations - 1)) * m.Transpose() * (Matrix)m;
        }

        /// <summary>
        /// Converts this sample matrix to an ordinary matrix
        /// </summary>
        /// <returns></returns>
        public Matrix ToMatrix()
        {
            return this.ToMatrix(DataModel.RowsAsObservations);
        }

        /// <summary>
        /// Converts this sample matrix to an ordinary matrix, using the
        /// given data organization model
        /// </summary>
        /// <param name="model">The data model for the generated matrix</param>
        /// <returns></returns>
        public Matrix ToMatrix(DataModel model)
        {
            Matrix m = new Matrix(this.BaseMatrix);

            if (model == DataModel.RowsAsObservations)
                return m; 

            else return m.Transpose();
        }

        /// <summary>
        /// Converts this sample matrix to a string representation
        /// </summary>
        /// <returns></returns>
        public string ToString(bool includeHeaders)
        {
            if (includeHeaders)
            {
                String str = String.Empty;
                for (int i = 0; i < this.Variables; i++)
                {
                    str += m_colNames[i];

                    if (i < this.Variables - 1)
                        str += "\t";
                }

                return str + "\n" + base.ToString(); ;
            }
            else
            {
                return base.ToString();
            }
        }

        /// <summary>
        /// Creates a shallow copy of this object
        /// </summary>
        /// <returns>The new object.</returns>
        public override object Clone()
        {
            return new SampleMatrix(this);
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void generateDefaultNames()
        {
            m_colNames = new string[this.Variables];

            for (int i = 0; i < this.Variables; i++)
                m_colNames[i] = "Column " + i;
        }
        #endregion



    }
}
