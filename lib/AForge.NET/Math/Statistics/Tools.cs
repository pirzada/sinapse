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
using AForge;
using AForge.Mathematics;


namespace AForge.Statistics
{

    public enum MeasureType { Sample, Population };



    /// <summary>
    ///     Set of statistics functions
    /// </summary>
    /// 
    /// <remarks>
    ///     The class represents collection of functions used
    ///     in statistics. Every Matrix function assumes data is organized
    ///     in a table-like model, where Columns represents variables and
    ///     Rows represents a observation of each variable.
    /// </remarks>
    /// 
    public static class Tools
    {

        #region Vector Statistics
        /// <summary>Computes the Mean of the given values.</summary>
        /// <param name="vector">A double array containing the vector members.</param>
        /// <returns>The mean of the given data.</returns>
        public static double Mean(params double[] values)
        {
            double sum = 0.0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum / ((double)values.Length);
        }

        /// <summary>Computes the Mean of the given values.</summary>
        /// <param name="vector">An integer array containing the vector members.</param>
        /// <returns>The mean of the given data.</returns>
        public static double Mean(params int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum / ((double)values.Length);
        }


        /// <summary>Computes the Standard Deviation of the given values.</summary>
        /// <param name="vector">A double array containing the vector members.</param>
        /// <returns>The standard deviation of the given data.</returns>
        public static double StandardDeviation(params double[] values)
        {
            return StandardDeviation(values, Mean(values));
        }

        internal static double StandardDeviation(double[] values, double mean)
        {
            return System.Math.Sqrt(Variance(values, mean));
        }

        /// <summary>Computes the Standard Deviation of the given values.</summary>
        /// <param name="vector">An integer array containing the vector members.</param>
        /// <returns>The standard deviation of the given data.</returns>
        public static double StandardDeviation(params int[] values)
        {
            return StandardDeviation(values,Mean(values));
        }

        internal static double StandardDeviation(int[] values, double mean)
        {
            return System.Math.Pow(Variance(values, mean), 2);
        }


        /// <summary>Computes the Median of the given values.</summary>
        /// <param name="vector">A double array containing the vector members.</param>
        /// <returns>The median of the given data.</returns>
        public static double Median(params double[] values)
        {
            return Median(false, values);
        }

        /// <summary>Computes the Median of the given values.</summary>
        /// <param name="values">An integer array containing the vector members.</param>
        /// <param name="alreadySorted">A boolean parameter informing if the given values have already been sorted.</param>
        /// <returns>The median of the given data.</returns>
        public static double Median(bool alreadySorted, params double[] values)
        {
            double[] data = new double[values.Length];
            values.CopyTo(data, 0); // Creates a copy of the given values,

            if (!alreadySorted) // So we can sort it without modifying the original array.
                Array.Sort(data);

            int N = data.Length;

            if ((N % 2) == 0)
                return (data[N / 2] + data[(N / 2) + 1]) * 0.5; // N is even 
            else return data[(N + 1) / 2];                      // N is odd
        }

        /// <summary>Computes the Median of the given values.</summary>
        /// <param name="vector">An integer array containing the vector members.</param>
        /// <returns>The median of the given data.</returns>
        public static double Median(params int[] values)
        {
            return Median(false, values);
        }

        /// <summary>Computes the Median of the given values.</summary>
        /// <param name="values">An integer array containing the vector members.</param>
        /// <param name="alreadySorted">A boolean parameter informing if the given values have already been sorted.</param>
        /// <returns>The median of the given data.</returns>
        public static double Median(bool alreadySorted, params int[] values)
        {
            int[] data = new int[values.Length];
            values.CopyTo(data, 0); // Creates a copy of the given values,

            if (!alreadySorted) // So we can sort it without modifying the original array.
                Array.Sort(data);

            int N = data.Length;

            if ((N % 2) == 0)
                return (data[N / 2] + data[(N / 2) + 1]) * 0.5; // N is even 
            else return data[(N + 1) / 2];                      // N is odd
        }


        /// <summary>Computes the Variance of the given values.</summary>
        /// <param name="vector">A double precision number array containing the vector members.</param>
        /// <returns>The variance of the given data.</returns>
        public static double Variance(params double[] values)
        {
            return Variance(values, Mean(values));
        }

        internal static double Variance(double[] values, double mean)
        {
            double sum1 = 0.0;
            double sum2 = 0.0;
            double x = 0.0;
                        
            for (int i = 0; i < values.Length; i++)
            {
                x = values[i] - mean;
                sum1 += (x);
                sum2 += System.Math.Pow(x, 2);
            }

            return (sum2 - System.Math.Pow(sum1, 2) / values.Length) / (values.Length - 1);
        }

        /// <summary>Computes the Variance of the given values.</summary>
        /// <param name="vector">An integer number array containing the vector members.</param>
        /// <returns>The variance of the given data.</returns>
        public static double Variance(params int[] values)
        {
            return Variance(values, Mean(values));
        }

        internal static double Variance(int[] values, double mean)
        {
            double sum1 = 0.0;
            double sum2 = 0.0;
            double x = 0.0;

            for (int i = 0; i < values.Length; i++)
            {
                x = values[i] - mean;
                sum1 += (x);
                sum2 += System.Math.Pow(x, 2);
            }

            return (sum2 - System.Math.Pow(sum1, 2) / values.Length) / (values.Length - 1);
        }


        /// <summary>Computes the Mode of the given values.</summary>
        /// <param name="values">A double precision number array containing the vector values.</param>
        /// <returns>The variance of the given data.</returns>
        public static double Mode(params double[] values)
        {
            int[] itemCount = new int[values.Length];
            double[] itemArray = new double[values.Length];
            int count = 0;
            
            for (int i = 0; i < values.Length; i++)
            {
                int index = Array.IndexOf<double>(itemArray, values[i], 0, count);

                if (index >= 0)
                {
                    itemCount[index]++;
                }
                else
                {
                    itemArray[count] = values[i];
                    itemCount[count] = 1;
                    count++;
                }
            }

            int maxValue = 0;
            int maxIndex = 0;

            for (int i = 0; i < count; i++)
            {
                if (itemCount[i] > maxValue)
                {
                    maxValue = itemCount[i];
                    maxIndex = i;
                }
            }

            return itemArray[maxIndex];
        }

        /// <summary>Computes the Mode of the given values.</summary>
        /// <param name="values">An integer number array containing the vector values.</param>
        /// <returns>The mode of the given data.</returns>
        public static double Mode(params int[] values)
        {
            int[] itemCount = new int[values.Length];
            int[] itemArray = new int[values.Length];
            int count = 0;

            for (int i = 0; i < values.Length; i++)
            {
                int index = Array.IndexOf<int>(itemArray, values[i], 0, count);

                if (index >= 0)
                {
                    itemCount[index]++;
                }
                else
                {
                    itemArray[count] = values[i];
                    itemCount[count] = 1;
                    count++;
                }
            }

            int maxValue = 0;
            int maxIndex = 0;

            for (int i = 0; i < count; i++)
            {
                if (itemCount[i] > maxValue)
                {
                    maxValue = itemCount[i];
                    maxIndex = i;
                }
            }

            return itemArray[maxIndex];
        }


        /// <summary>Computes the Covariance between two values arrays.</summary>
        /// <param name="u">A double precision number array containing the first vector members.</param>
        /// <param name="v">A double precision number array containing the second vector members.</param>
        /// <returns>The variance of the given data.</returns>
        public static double Covariance(double[] u, double[] v)
        {
            if (u.Length != v.Length)
            {
                throw new ArgumentException("Vector sizes must be equal.", "u");
            }
            if (u.Length == 0)
            {
                throw new ArgumentException();
            }

            double usum = 0.0;
            double vsum = 0.0;

            // Calculate Sums for each vector
            for (int i = 0; i < u.Length; i++)
            {
                usum += u[i];  // We are not calling the Mean method
                vsum += v[i];  // directly in order to use only one loop.
            }

            double umean = usum / ((double)u.Length);
            double vmean = vsum / ((double)v.Length);

            double covariance = 0.0;
            for (int i = 0; i < u.Length; i++)
            {
                covariance += (u[i] - umean) * (v[i] - vmean);
            }

            // Return the Sample variance
            return (covariance / ((double)(u.Length - 1)));

            // TODO: return also the population variance
        }
        #endregion


        // ------------------------------------------------------------


        #region Matrix Statistics

        /// <summary>Calculates the matrix Mean vector.</summary>
        /// <param name="m">A matrix whose means will be calculated.</param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        public static Vector Mean(Matrix value)
        {
            Vector mean;

            mean = new Vector(value.Columns);
            for (int j = 0; j < value.Columns; j++)
            {
                for (int i = 0; i < value.Rows; i++)
                {
                    mean[j] += value[i, j];
                }

                mean[j] = mean[j] / (double)value.Rows;
            }

            return mean;
        }


        /// <summary>Calculates the matrix Standard Deviations vector.</summary>
        /// <param name="m">A matrix whose deviations will be calculated.</param>
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        public static Vector StandardDeviation(Matrix value)
        {
            return StandardDeviation(value, Mean(value));
        }

        internal static Vector StandardDeviation(Matrix value, double[] mean)
        {
            return Vector.Sqrt(Variance(value, mean));
        }


        /// <summary>Calculates the matrix Medians vector.</summary>
        /// <param name="m">A matrix whose deviations will be calculated.</param>
        /// <returns>Returns a vector containing the medians of the given matrix.</returns>
        public static Vector Median(Matrix value)
        {
            Vector medians = new Vector(value.Columns);

            for (int i = 0; i < value.Columns; i++)
            {
                medians[i] = Median(value.GetColumn(i));
            }

            return medians;
        }


        /// <summary>Calculates the matrix Modes vector.</summary>
        /// <param name="m">A matrix whose modes will be calculated.</param>
        /// <returns>Returns a vector containing the modes of the given matrix.</returns>
        public static Vector Mode(Matrix matrix)
        {
            Vector mode = new Vector(matrix.Columns);

            for (int i = 0; i < mode.Length; i++)
            {
                mode[i] = Mode(matrix.GetColumn(i));
            }

            return mode;
        }


        /// <summary>Calculates the matrix Medians vector.</summary>
        /// <param name="m">A matrix whose deviations will be calculated.</param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        public static Vector Variance(Matrix value)
        {
            return Variance(value, Mean(value));
        }

        internal static Vector Variance(Matrix value, double[] means)
        {
            Vector variance = new Vector(value.Columns);

            for (int i = 0; i < value.Columns; i++)
            {
                //TODO: Substitute this with the complete matrix variance algorithm
                variance[i] = Variance(value.GetColumn(i), means[i]);
            }
            
            return variance;
        }


        /// <summary>Calculates the covariance matrix of a sample matrix, returning a new matrix object</summary>
        /// <remarks>
        ///   In statistics and probability theory, the covariance matrix is a matrix of
        ///   covariances between elements of a vector. It is the natural generalization
        ///   to higher dimensions of the concept of the variance of a scalar-valued
        ///   random variable.
        /// </remarks>
        /// <returns>The covariance matrix.</returns>
        public static Matrix Covariance(Matrix matrix)
        {
            return Covariance(matrix, Mean(matrix));
        }

        internal static Matrix Covariance(Matrix matrix, double[] mean)
        {
              if (matrix.Rows == 1)
              {
                  throw new ArgumentException("Sample has only one observation.","matrix");
              }

              Matrix cov = new Matrix(matrix.Columns);

              for (int i = 0; i < cov.Columns; i++)
              {
                  Vector column = matrix.GetColumn(i);
                  cov[i, i] = Variance(column, mean[i]); // diagonal has the variances

                  for (int j = i + 1; j < cov.Columns; j++)
                  {
                      cov[i, j] = Covariance(column, matrix.GetColumn(j));
                      cov[j, i] = cov[i, j]; // Matrix is symmetric
                  }
              }
              return cov;
        }


        /// <summary>Calculates the correlation matrix of this samples, returning a new matrix object</summary>
        /// <remarks>
        /// In statistics and probability theory, the correlation matrix is the same
        /// as the covariance matrix of the standardized random variables.
        /// </remarks>
        /// <returns>The correlation matrix</returns>
        public static Matrix Correlation(Matrix matrix)
        {
            Matrix scores = ZScores(matrix);
            return Covariance(scores);
        }


        /// <summary>Generates the Standard Scores, also known as Z-Scores, the core from the given data.</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Matrix ZScores(Matrix value)
        {
            double[] mean = Mean(value);
            return ZScores(value, mean, StandardDeviation(value, mean));
        }

        /// <summary>Generates the Standard Scores, also known as Z-Scores, the core from the given data.</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SampleMatrix ZScores(SampleMatrix value)
        {
            double[] mean = Mean(value);
            return ZScores(value, mean, StandardDeviation(value, mean));
        }

        internal static Matrix ZScores(Matrix value, double[] mean, double[] stdDev)
        {
            Matrix m = value.Clone();

            Center(m, mean);
            Standardize(m, stdDev);

            return m;
        }

        internal static SampleMatrix ZScores(SampleMatrix value, double[] mean, double[] stdDev)
        {
            SampleMatrix m = value.Clone();

            Center(m, mean);
            Standardize(m, stdDev);

            return m;
        }


        /// <summary>Centers column data, subtracting the empirical mean from each variable.</summary>
        /// <param name="m">A matrix where each column represent a variable and each row represent a observation.</param>
        public static void Center(Matrix value)
        {
            Center(value, Mean(value));
        }

        internal static void Center(Matrix value, double[] mean)
        {
            for (int i = 0; i < value.Rows; i++)
            {
                for (int j = 0; j < value.Columns; j++)
                {
                    value[i, j] = value[i, j] - mean[j];
                }
            }
        }


        /// <summary>Standardizes column data, removing the empirical standard deviation from each variable.</summary>
        /// <param name="m">A matrix where each column represent a variable and each row represent a observation.</param>
        /// <remarks>This method does not remove the empirical mean prior to execution.</remarks>
        public static void Standardize(Matrix value)
        {
            Standardize(value, StandardDeviation(value));
        }

        internal static void Standardize(Matrix value, double[] std)
        {
            for (int i = 0; i < value.Rows; i++)
            {
                for (int j = 0; j < value.Columns; j++)
                {
                    value[i, j] = value[i, j] / std[j];
                }
            }
        }
        #endregion


        // ------------------------------------------------------------


    }
}
