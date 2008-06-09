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

using AForge.Mathematics;
using AForge.Statistics.SignalAnalysis.Markov;

namespace AForge.Statistics.SignalAnalysis.Markov.Learning
{


    /// <summary>
    ///   The forward-backward algorithm is a dynamic programming algorithm
    ///   for computing the probability of a particular observation sequence,
    ///   given the parameters of the model, in the context of hidden Markov models.
    /// </summary>
    /// <remarks>
    ///   The algorithm is composed of three steps: Computing forward probabilities,
    ///   computing backward probabilities and computing smoothed values. The forward
    ///   and backward steps are often called forward message pass and backward message
    ///   pass. The wording originates from the way the algorithm processes the given
    ///   observation sequence. First the algorithm moves forward starting with the
    ///   first observation in the sequence and going to the last, and then returning
    ///   back to the first. At each single observation in the sequence probabilities
    ///   to be used for calculations at the next observation are computed. During the
    ///   backward pass the algorithm simultaneously performes the smoothing step. This
    ///   step allows the algorithm to take into account any past observations of output
    ///   for computing more accurate results.
    /// </remarks>
    public class Forward : MarkovLearningAlgorithm
    {


        public Forward(HiddenMarkovModel model)
        {
        }

        public void Run(int[] observation)
        {
            this.Model.
        }

        public Matrix Run(int[] observations)
        {
            int T = observations.Length;
            Matrix fwd = new Matrix(numStates, T);

            // Initialization (time 0)
            for (int i = 0; i < numStates; i++)
            {
                fwd[i][0] = pi[i] * b[i][o[0]];
            }

            // Induction
            for (int t = 0; t <= (T - 2); t++)
            {
                for (int j = 0; j < model.StatesCount; j++)
                {
                    fwd[j][t + 1] = 0.0;

                    for (int i = 0; i < model.StatesCount; i++)
                    {
                        fwd[j][t + 1] += (fwd[i][t] * a[i][j]);
                    }
                    fwd[j][t + 1] *= b[j][o[t + 1]];
                }
            }

            return fwd;
        }

    }
}
