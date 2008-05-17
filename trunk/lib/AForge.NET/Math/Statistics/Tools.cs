// AForge Math Library
//
// Copyright © Andrew Kirillov, 2005-2007
// andrew.kirillov@gmail.com
//
// Modifications by Cesar Roberto de Souza, 2008
// cesarsouza@gmail.com

namespace AForge.Statistics
{
    using System;
    using AForge;
    using AForge.Math;

    /*
        /// <summary>
        /// Determines how a Matrix should be read during a Statistical operation.
        /// ObservationModel.Rows means each row of the matrix represents an observation
        /// of variables, while ObservationModel.Columns means each column of the matrix
        /// represents an observation of those variables. The most tipical usage, the
        /// table-model organization of data utilizes rows as observations of variables
        /// referenced by its columns.
        /// </summary>
        public enum ObservationModel { Rows, Columns };
     
    */

    public enum MeasureType { Sample, Population };



    /// <summary>
    /// Set of statistics functions
    /// </summary>
    /// 
    /// <remarks>The class represents collection of functions used
    /// in statistics. Every Matrix function assumes data is organized
    /// in a table-like model, where Columns represents variables and
    /// Rows represents a observation of each variable.</remarks>
    /// 
    public static class Tools
    {

        #region Common Statistics
        /// <summary>
        /// Calculate mean value
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// 
        /// <returns>Returns mean value</returns>
        /// 
        /// <remarks>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</remarks>
        /// 
        public static double Mean(double[] values)
        {
            double hits;
            double mean = 0;
            double total = 0;

            // for all values
            for (int i = 0, n = values.Length; i < n; i++)
            {
                hits = values[i];
                // accumulate mean
                mean += i * hits;
                // accumalate total
                total += hits;
            }
            return mean / total;
        }

        /// <summary>
        /// Calculate standard deviation
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// 
        /// <returns>Returns value of standard deviation</returns>
        /// 
        /// <remarks>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</remarks>
        /// 
        public static double StandardDeviation(double[] values)
        {
            return StandardDeviation(values, Mean(values));
        }

        /// <summary>
        /// Calculate standard deviation
        /// </summary>
        /// <param name="values"></param>
        /// <param name="mean">A previously computed mean vector for the data. Avoids duplicating computations.</param>
        /// <returns></returns>
        internal static double StandardDeviation(double[] values, double mean)
        {
            double stddev = 0;
            double centeredValue;
            double hits;
            double total = 0;

            // for all values
            for (int i = 0, n = values.Length; i < n; i++)
            {
                hits = values[i];
                centeredValue = (double)i - mean;

                // accumulate mean
                stddev += centeredValue * centeredValue * hits;
                // accumalate total
                total += hits;
            }

            return System.Math.Sqrt(stddev / total);
        }

        /// <summary>
        /// Calculate median value
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// 
        /// <returns>Returns value of median</returns>
        /// 
        /// <remarks>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</remarks>
        /// 
        public static double Median(double[] values)
        {

            double total = 0;
            double n = values.Length;

            // for all values
            for (int i = 0; i < n; i++)
            {
                // accumalate total
                total += values[i];
            }

            double halfTotal = total / 2;
            int median = 0;
            double v = 0;

            // find median value
            for (; median < n; median++)
            {
                v += values[median];
                if (v >= halfTotal)
                    break;
            }

            return median;
            
        }

        /// <summary>
        /// Calculate mean value
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// 
        /// <returns>Returns mean value</returns>
        /// 
        /// <remarks>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</remarks>
        /// 
        public static double Mean(int[] values)
        {
            int hits;
            int mean = 0;
            int total = 0;

            // for all values
            for (int i = 0, n = values.Length; i < n; i++)
            {
                hits = values[i];
                // accumulate mean
                mean += i * hits;
                // accumalate total
                total += hits;
            }
            return (double)mean / total;
        }

        /// <summary>
        /// Calculate standard deviation
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// 
        /// <returns>Returns value of standard deviation</returns>
        /// 
        /// <remarks>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</remarks>
        /// 
        public static double StandardDeviation(int[] values)
        {
            double mean = Mean(values);
            double stddev = 0;
            double centeredValue;
            int hits;
            int total = 0;

            // for all values
            for (int i = 0, n = values.Length; i < n; i++)
            {
                hits = values[i];
                centeredValue = (double)i - mean;

                // accumulate mean
                stddev += centeredValue * centeredValue * hits;
                // accumalate total
                total += hits;
            }

            return Math.Sqrt(stddev / total);
        }

        /// <summary>
        /// Calculate median value
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// 
        /// <returns>Returns value of median</returns>
        /// 
        /// <remarks>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</remarks>
        /// 
        public static int Median(int[] values)
        {
            int total = 0, n = values.Length;

            // for all values
            for (int i = 0; i < n; i++)
            {
                // accumalate total
                total += values[i];
            }

            int halfTotal = total / 2;
            int median = 0, v = 0;

            // find median value
            for (; median < n; median++)
            {
                v += values[median];
                if (v >= halfTotal)
                    break;
            }

            return median;
        }

        public static double Median(double[] values, bool sorted)
        {
            double[] data = new double[values.Length];
            values.CopyTo(data, 0); // Creates a copy of the given vector,

            if (!sorted) // So we can sort it without modifying the original array.
                Array.Sort(data); 

            int N = data.Length;

            if ((N % 2) == 0)
            {
                // N is even 
                return (data[N / 2] + data[(N / 2) + 1]) * 0.5;
            }
            else
            {
                // N is odd
                return data[(N + 1) / 2];
            }
        }

        /// <summary>
        /// Get range around median containing specified percentage of values
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// <param name="percent">Values percentage around median</param>
        /// 
        /// <returns>Returns the range which containes specifies percentage
        /// of values.</returns>
        /// 
        public static IntRange GetRange(int[] values, double percent)
        {
            int total = 0, n = values.Length;

            // for all values
            for (int i = 0; i < n; i++)
            {
                // accumalate total
                total += values[i];
            }

            int min, max, hits;
            int h = (int)(total * (percent + (1 - percent) / 2));

            // get range min value
            for (min = 0, hits = total; min < n; min++)
            {
                hits -= values[min];
                if (hits < h)
                    break;
            }
            // get range max value
            for (max = n - 1, hits = total; max >= 0; max--)
            {
                hits -= values[max];
                if (hits < h)
                    break;
            }
            return new IntRange(min, max);
        }

        /// <summary>
        /// Calculates an entropy.
        /// </summary>
        /// 
        /// <param name="values">Histogram array</param>
        /// 
        /// <returns>Returns entropy value</returns>
        /// 
        /// <remarks>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</remarks>
        /// 
        public static double Entropy(int[] values)
        {
            int n = values.Length;
            int total = 0;
            double entropy = 0;
            double p;

            // calculate total amount of hits
            for (int i = 0; i < n; i++)
            {
                total += values[i];
            }

            // for all values
            for (int i = 0; i < n; i++)
            {
                // get item's probability
                p = (double)values[i] / total;
                // calculate entropy
                if (p != 0)
                    entropy += (-p * Math.Log(p, 2));
            }
            return entropy;
        }


        public static double Covariance(double[] u, double[] v)
        {
            if (u.Length != v.Length)
            {
                throw new ArgumentException();
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
                usum += u[i];
                vsum += v[i];
            }
            // We are not calling the Mean method directly in order to use only one loop.
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

        public static double Variance(double[] values)
        {
            return Variance(values, Mean(values));
        }

        internal static double Variance(double[] values, double mean)
        {
            double variance = 0.0;
            
            for (int i = 0; i < values.Length; i++)
            {
                variance += Math.Pow(values[i] - mean, 2.0);
            }

            return (variance / ((double)(values.Length - 1)));
        }

        public static double Mode(double[] value)
        {
            int[] itemCount = new int[value.Length];
            double[] itemArray = new double[value.Length];
            int count = 0;
            
            for (int i = 0; i < value.Length; i++)
            {
                int index = Array.IndexOf<double>(itemArray, value[i], 0, count);

                if (index >= 0)
                {
                    itemCount[index]++;
                }
                else
                {
                    itemArray[count] = value[i];
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


        #endregion


        // ------------------------------------------------------------


        #region Matrix Statistics

        /// <summary>
        /// Calculate the matrix means' vector.
        /// </summary>
        /// 
        /// <param name="m">A matrix whose means will be calculated.</param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// <remarks></remarks>
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

        /// <summary>
        /// Calculate the matrix standard deviations vector.
        /// </summary>
        /// 
        /// <param name="m">A matrix whose deviations will be calculated.</param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// <remarks></remarks>
        public static Vector StandardDeviation(Matrix value)
        {
            return StandardDeviation(value, Mean(value));
        }

        internal static Vector StandardDeviation(Matrix value, double[] mean)
        {

            Vector std = new Vector(value.Columns); // Creates a new vector with the matrix column's count size

                for (int j = 0; j < value.Columns; j++)
                {
                    for (int i = 0; i < value.Rows; i++)
                    {
                        std[j] += System.Math.Pow((value[i, j] - mean[j]), 2);
                    }

                    std[j] = System.Math.Sqrt(std[j] / (double)(value.Columns - 1));

                    // The following is an inelegant but usual way to handle
                    //   near-zero std. dev. values, which below would cause a zero-divide.

                    if (std[j] <= Double.Epsilon)
                        std[j] = 1.0;
            }

            return std;
        }

        public static Vector Median(Matrix value)
        {
            Vector medians = new Vector(value.Columns);

            for (int i = 0; i < value.Columns; i++)
            {
                medians[i] = Median(value.GetColumn(i));
            }

            return medians;
        }

        public static Vector Variance(Matrix value)
        {
            return Variance(value, Mean(value));
        }

        internal static Vector Variance(Matrix value, double[] means)
        {
            Vector variance = new Vector(value.Columns);

            for (int i = 0; i < value.Columns; i++)
            {
                variance[i] = Variance(value.GetColumn(i), means[i]);
            }
            
            return variance;
        }

        public static Vector Mode(Matrix matrix)
        {
            Vector mode = new Vector(matrix.Columns);

            for (int i = 0; i < mode.Length; i++)
            {
                mode[i] = Mode(matrix.GetColumn(i));
            }

            return mode;
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

        /// <summary>Generates the Standard Scores, also known as Z-Scores, the core from the given data.</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Matrix ZScores(Matrix value)
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
        #endregion


    }
}
