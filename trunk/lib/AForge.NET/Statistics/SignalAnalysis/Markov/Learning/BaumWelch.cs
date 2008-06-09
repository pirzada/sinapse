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
    ///   Baum-Welch algorithm for hidden Markov models. Given an observation
    ///   sequence o, it will train this HMM using the given observation sequence
    ///   to increase the probability of producing such sequence.
    /// </summary>
    public class BaumWelch : MarkovLearningAlgorithm
    {

        private HiddenMarkovModel model;
        private int steps;

        /// <summary>
        ///   Constructs the BaumWelch learning algorithm for Hidden Markov Models.
        /// </summary>
        /// <param name="model">The hidden Markov model to operate on.</param>
        public BaumWelch(HiddenMarkovModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o">The observation sequence.</param>
        public void Run(int[] observation)
        {

          Matrix fwd;
          Matrix bwd;


          for (int s = 0; s < steps; s++)
          {
              // calculation of Forward and Backward Variables from the current model
              fwd = forwardProc(o);
              bwd = backwardProc(o);

              // re-estimation of initial state probabilities
              for (int i = 0; i < numStates; i++)
                  pi1[i] = gamma(i, 0, o, fwd, bwd);

              // re-estimation of transition probabilities
              for (int i = 0; i < numStates; i++)
              {
                  for (int j = 0; j < numStates; j++)
                  {
                      double num = 0;
                      double denom = 0;

                      for (int t = 0; t <= (T - 1); t++)
                      {
                          num += xi(t, i, j, o, fwd, bwd);
                          denom += gamma(i, t, o, fwd, bwd);
                      }

                      a1[i][j] = divide(num, denom);
                  }
              }

              // re-estimation of emission probabilities
              for (int i = 0; i < numStates; i++)
              {
                  for (int k = 0; k < sigmaSize; k++)
                  {
                      double num = 0;
                      double denom = 0;

                      for (int t = 0; t <= (T - 1); t++)
                      {
                          double g = gamma(i, t, o, fwd, bwd);
                          num += (g * ((k == o[t]) ? 1 : 0));
                          denom += g;
                      }

                      b1[i][k] = divide(num, denom);
                  }
              }
          }
        }
    }
}
