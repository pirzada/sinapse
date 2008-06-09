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

namespace AForge.Statistics.SignalAnalysis.Markov.Learning
{
    /// <summary>
    ///   The Viterbi algorithm is a dynamic programming algorithm for finding
    ///   the most likely sequence of hidden states – called the Viterbi path –
    ///   that results in a sequence of observed events, especially in the
    ///   context of hidden Markov models.
    /// </summary>
    public class Viterbi : MarkovLearningAlgorithm
    {


        public Viterbi(HiddenMarkovModel model)
        {
        }


        /**
        * Viterbi algorithm for hidden Markov models. Given an observation
        * sequence o, Viterbi finds the best possible state sequence for o on
        * this HMM, along with the state optimized probability.
        *
        * @param o the observation sequence
        *
        * @return a 2d array consisting of the minimum cost, U, at position (0,0)
        *         and the best possible path beginning at (1,0). The state
        *         optimized probability is Euler's number raised to the power of
        *         -U.
        */
        public void Run(int[] observations)
        {

        }

        public Matrix Run(int[] observations)
        {
        int T = o.length;
        int min_state;
        double min_weight;
        double weight;
        double stateOptProb = 0.0;
        int[] Q = new int[T];
        int[][] sTable = new int[numStates][T];
        double[][] aTable = new double[numStates][T];
        double[][] answer = new double[2][T];

        // calulate accumulations and best states for time 0
        for (int i = 0; i < numStates; i++) {
            aTable[i][0] = (-1 * Math.log(pi[i])) - Math.log(b[i][o[0]]);
            sTable[i][0] = 0;
        }

        // fill up the rest of the tables
        for (int t = 1; t < T; t++) {
            for (int j = 0; j < numStates; j++) {
                min_weight = aTable[0][t - 1] - Math.log(a[0][j]);
                min_state = 0;

                for (int i = 1; i < numStates; i++) {
                    weight = aTable[i][t - 1] - Math.log(a[i][j]);

                    if (weight < min_weight) {
                        min_weight = weight;
                        min_state = i;
                    }
                }

                aTable[j][t] = min_weight - Math.log(b[j][o[t]]);
                sTable[j][t] = min_state;
            }
        }

        // find minimum value for time T-1
        min_weight = aTable[0][T - 1];
        min_state = 1;

        for (int i = 1; i < numStates; i++) {
            if (aTable[i][T - 1] < min_weight) {
                min_weight = aTable[i][T - 1];
                min_state = i;
            }
        }

        // trace back to find the optimized state sequence
        Q[T - 1] = min_state;

        for (int t = T - 2; t >= 0; t--)
            Q[t] = sTable[Q[t + 1]][t + 1];

        // store answers and return them
        answer[0][0] = min_weight;

        for (int i = 0; i < T; i++)
            answer[1][i] = Q[i];

        return answer;
        }

    }
}
