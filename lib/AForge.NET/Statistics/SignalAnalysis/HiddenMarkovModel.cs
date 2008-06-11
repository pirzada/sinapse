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


namespace AForge.Statistics.SignalAnalysis.Markov
{

    /// <summary>
    ///   Hidden Markov Model
    /// </summary>
    /// <remarks>
    ///  An Hidden Markov Model (HMM) is composed of:
    ///   <ul>
    ///   <li><i>States</i>: each state has a given probability of being initial
    ///   (<i>Pi</i>) and an associated observation probability function
    ///   (<i>opdf</i>).  Each state is associated to an index; the first state
    ///   is numbered 0, the last n-1 (where n is the number of states in the HMM);
    ///   this number is given as an argument to the various functions to refer to
    ///   the matching state. </li>
    ///   <li><i>transition probabilities</i>: that is, the probability of going
    ///   from state <i>i</i> to state <i>j</i> (<i>a<sub>i,j</sub></i>).</li>
    ///   </ul>
    /// </remarks>
    public class HiddenMarkovModel
    {

        // Resource: http://paulsonb.blogspot.com/2008/01/introduction-to-hidden-markov-models.html


        //Size of output vocabulary
        private int sigmaSize;
        private int numStates;
        private int dimensions;

        //initial state probabilities
        private double[] pi;
        
        //output vocabulary
        private Matrix V;

        //transition probabilities
        private Matrix A;

        //emission probabilities
        private Matrix B;



        #region Constructors
        /// <summary>
        ///   Constructs a new Hidden Markov Model.
        /// </summary>
        /// <param name="numStates">The number of states to be used in the model.</param>
        /// <param name="sigmaSize">The size of the output vocabulary used in the model.</param>
        /// <param name="dimensions">The number of dimensions of the observation symbols.</param>
        public HiddenMarkovModel(int numStates, int sigmaSize, int dimensions)
        {
            if (numStates < 1)
                throw new ArgumentOutOfRangeException("numStates");
            if (sigmaSize < 1)
                throw new ArgumentOutOfRangeException("sigmaSize");
            if (dimensions < 0)
                throw new ArgumentOutOfRangeException("dimensions");

            this.dimensions = dimensions;
            this.numStates = numStates;
            this.sigmaSize = sigmaSize;

            this.pi = new Vector(numStates);
            this.A = new Matrix(numStates);
            this.B = new Matrix(numStates, sigmaSize);

            if (dimensions > 0)
                this.V = new Matrix(sigmaSize, dimensions);
        }

        /// <summary>
        ///   Constructs a new Hidden Markov Model.
        /// </summary>
        /// <param name="numStates">The number of states to be used in the model.</param>
        /// <param name="sigmaSize">The size of the output vocabulary used in the model.</param>
        public HiddenMarkovModel(int numStates, int sigmaSize)
            : this(numStates, sigmaSize, 0)
        {
        }
        #endregion




        #region Public Properties
        public Vector States
        {
            get { return this.pi; }
            internal set { this.pi = value; }
        }

        public Matrix TransitionProbabilities
        {
            get { return this.A; }
            internal set { this.A = value; }
        }

        public Matrix EmissionProbabilities
        {
            get { return this.B; }
            internal set { this.B = value; }
        }
        #endregion





        #region Public Methods
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
        public Matrix Backward(int[] observations)
        {
            int T = observations.Length;
            Matrix bwd = new Matrix(numStates, T);

            // Initialization (time 0)
            for (int i = 0; i < numStates; i++)
            {
                bwd[i][T - 1] = 1.0;
            }

            // Induction
            for (int t = T - 2; t >= 0; t--)
            {
                for (int i = 0; i < this.numStates; i++)
                {
                    bwd[i][t] = 0.0;

                    for (int j = 0; j < this.numStates; j++)
                        bwd[i][t] += (bwd[j][t + 1] * A[i][j] * B[j][observations[t + 1]]);
                }
            }

            return bwd;
        }

        public Matrix Forward(int[] observations)
        {
            int T = observations.Length;
            Matrix fwd = new Matrix(numStates, T);

            // Initialization (time 0)
            for (int i = 0; i < numStates; i++)
            {
                fwd[i][0] = pi[i] * B[i][observations[0]];
            }

            // Induction
            for (int t = 0; t <= (T - 2); t++)
            {
                for (int j = 0; j < this.numStates; j++)
                {
                    fwd[j][t + 1] = 0.0;

                    for (int i = 0; i < this.numStates; i++)
                    {
                        fwd[j][t + 1] += (fwd[i][t] * A[i][j]);
                    }
                    fwd[j][t + 1] *= B[j][observations[t + 1]];
                }
            }

            return fwd;
        }


        public Matrix Estimate(int[] observations)
        {

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

            int T = observations.Length;
            int min_state;
            double min_weight;
            double weight;
            int[] Q = new int[T];
            int[,] sTable = new int[numStates, T];
            Matrix aTable = new Matrix(numStates, T);
            Matrix answer = new Matrix(2, T);

            // calulate accumulations and best states for time 0
            for (int i = 0; i < numStates; i++)
            {
                aTable[i][0] = (-1 * Math.Log(pi[i])) - Math.Log(B[i][observations[0]]);
                sTable[i, 0] = 0;
            }

            // fill up the rest of the tables
            for (int t = 1; t < T; t++)
            {
                for (int j = 0; j < numStates; j++)
                {
                    min_weight = aTable[0][t - 1] - Math.Log(A[0][j]);
                    min_state = 0;

                    for (int i = 1; i < numStates; i++)
                    {
                        weight = aTable[i][t - 1] - Math.Log(A[i][j]);

                        if (weight < min_weight)
                        {
                            min_weight = weight;
                            min_state = i;
                        }
                    }

                    aTable[j][t] = min_weight - Math.Log(B[j][observations[t]]);
                    sTable[j, t] = min_state;
                }
            }

            // find minimum value for time T-1
            min_weight = aTable[0][T - 1];
            min_state = 1;

            for (int i = 1; i < numStates; i++)
            {
                if (aTable[i][T - 1] < min_weight)
                {
                    min_weight = aTable[i][T - 1];
                    min_state = i;
                }
            }

            // trace back to find the optimized state sequence
            Q[T - 1] = min_state;

            for (int t = T - 2; t >= 0; t--)
                Q[t] = sTable[Q[t + 1], t + 1];

            // store answers and return them
            answer[0][0] = min_weight;

            for (int i = 0; i < T; i++)
                answer[1][i] = Q[i];

            return answer;
        }


        /// <summary>
        ///   Baum-Welch algorithm for hidden Markov models. Given an observation
        ///   sequence o, it will train this HMM using the given observation sequence
        ///   to increase the probability of producing such sequence.
        /// </summary>
        public void Train(int[] observation, int steps)
        {

            Matrix fwd;
            Matrix bwd;

            for (int s = 0; s < steps; s++)
            {
                // calculation of Forward and Backward Variables from the current model
                fwd = Forward(observation);
                bwd = Backward(observation);

                // re-estimation of initial state probabilities
                for (int i = 0; i < numStates; i++)
                {
                    this.pi[i] = gamma(i, 0, observation, fwd, bwd);
                }

                // re-estimation of transition probabilities
                for (int i = 0; i < numStates; i++)
                {
                    for (int j = 0; j < numStates; j++)
                    {
                        double num = 0;
                        double denom = 0;

                        for (int t = 0; t <= (observation.Length - 1); t++)
                        {
                            num += xi(t, i, j, observation, fwd, bwd);
                            denom += gamma(i, t, observation, fwd, bwd);
                        }

                        A[i][j] = num / denom;
                    }
                }

                // re-estimation of emission probabilities
                for (int i = 0; i < numStates; i++)
                {
                    for (int k = 0; k < sigmaSize; k++)
                    {
                        double num = 0;
                        double denom = 0;

                        for (int t = 0; t <= (observation.Length - 1); t++)
                        {
                            double g = gamma(i, t, observation, fwd, bwd);
                            num += (g * ((k == observation[t]) ? 1 : 0));
                            denom += g;
                        }

                        B[i][k] = num / denom;
                    }
                }
            }
        #endregion



        }
    }
}
