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

        //output vocabulary
        private Matrix V;

        //initial state probabilities
        private Vector pi;

        //transition probabilities
        private Matrix A;

        //emission probabilities
        private Matrix B;


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
            this.a = new Matrix(numStates);
            this.b = new Matrix(numStates, sigmaSize);
            
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

        #region Public Properties
        public int StatesCount
        {
            get { return numStates; }
        }

        public double[] StateProbabilities
        {
            get { return this.pi; }
            internal set { this.pi = value; }
        }

        public double[] TransitionProbabilities
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
        public double Estimate(SampleVector vector)
        {
            return 0;
        }
        #endregion

    }
}
