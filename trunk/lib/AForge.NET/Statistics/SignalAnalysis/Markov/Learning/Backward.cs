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
    public class Backward : MarkovLearningAlgorithm
    {

        HiddenMarkovModel model;

        public Backward(HiddenMarkovModel model)
        {
            this.model = model;
        }


        public void Run(int[] observations)
        {

        }

        public Matrix Run(int[] observations)
        {
            int T = o.length;
            Matrix bwd = new Matrix(numStates, T);

            // Initialization (time 0)
            for (int i = 0; i < numStates; i++)
            {
                bwd[i][T - 1] = 1.0;
            }

            // Induction
            for (int t = T - 2; t >= 0; t--)
            {
                for (int i = 0; i < model.StatesCount; i++)
                {
                    bwd[i][t] = 0.0;

                    for (int j = 0; j < model.StatesCount; j++)
                        bwd[i][t] += (bwd[j][t + 1] * a[i][j] * b[j][o[t + 1]]);
                }
            }

            return bwd;
        }
    }
}
