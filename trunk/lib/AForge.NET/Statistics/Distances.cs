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

using AForge.Statistics.Visualizations;

namespace AForge.Statistics
{

    public class Distances
    {
        /// <summary>
        ///   In statistics, the Bhattacharyya distance measures the similarity
        ///   of two discrete probability distributions. It is usually used to
        ///   measure the separability of classes in classification.
        /// </summary>
        /// <remarks>
        ///   The input array is treated as histogram, i.e. its indexes
        ///   are treated as values of stochastic function, but array
        ///   values are treated as "probabilities" (total amount of hits).
        /// </remarks>
        public static double Bhattacharyya(int[] values)
        {

        }

        /// <summary>
        ///   In statistics, the Bhattacharya distance measures the similarity
        ///   of two discrete probability distributions. It is usually used to
        ///   measure the separability of classes in classification.
        /// </summary>
        /// <remarks>
        ///   The Bhattacharya coefficient is an approximate measurement of the
        ///   amount of overlap between two statistical samples. The coefficient
        ///   can be used to determine the relative closeness of the two samples
        ///   being considered.
        /// </remarks>
        public static double Bhattacharyya(double[] x, double[] y, int partitions)
        {


        }

        public static double Bhattacharyya(Histogram h1, Histogram h2)
        {

        }

        public static double Mahalanobis(double[] x, double[] y)
        {

        }





        /// <summary>
        ///   Calculates the Kullback-Leibler divergence between two probability distributions.
        ///   Please note this measure isn't really a distance measure since it is not symmetric.
        /// </summary>
        /// <remarks>
        ///      In probability theory and information theory, the Kullback–Leibler divergence
        ///   (also information divergence, information gain, or relative entropy) is a non-
        ///   commutative measure of the difference between two probability distributions P
        ///   and Q. KL measures the expected difference in the number of bits required to
        ///   code samples from P when using a code based on P, and when using a code based
        ///   on Q. Typically P represents the "true" distribution of data, observations,
        ///   or a precise calculated theoretical distribution. The measure Q typically
        ///   represents a theory, a model, a description or an approximation of P.
        /// 
        ///     It is a special case of a broader class of divergences called f-divergences.
        ///   Although it is often intuited as a distance metric, the KL divergence is not a
        ///   true metric since it is not symmetric (hence 'divergence' rather than 'distance').
        /// 
        ///     If a true symmetric metric is really required, one could compute
        ///   distance = RelativeEntropy(x, y) + RelativeEntropy(y, x) 
        /// 
        /// </remarks>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double RelativeEntropy(double[] x, double[] y)
        {

        }

    }


}
