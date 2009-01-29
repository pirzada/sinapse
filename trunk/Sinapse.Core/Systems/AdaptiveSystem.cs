using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Sinapse.Core.Filters;

namespace Sinapse.Core.Systems
{
    /// <summary>
    /// A AdaptiveSystem is a model which accepts an Input, processes the information and then produces out an Output, while being able to respond to environmental changes or changes in its interacting parts.
    /// </summary>
    /// <remarks>This is an abstract class and cannot be instantiated.</remarks>
    [Serializable]
    public abstract class AdaptiveSystem : ISinapseDocument
    {
        private SinapseDocument workplaceComponent;

        private SystemInputOutputCollection inputs;
        private SystemInputOutputCollection outputs;
        private FilterCollection preprocess;
        private FilterCollection postprocess;


        public AdaptiveSystem()
        {
            workplaceComponent = new SinapseDocument();

            inputs = new SystemInputOutputCollection();
            outputs = new SystemInputOutputCollection();
        }


        public SystemInputOutputCollection Inputs
        {
            get { return inputs; }
        }

        public SystemInputOutputCollection Outputs
        {
            get { return outputs; }
        }

        public FilterCollection Preprocess
        {
            get { return preprocess; }
            protected set { preprocess = value; }
        }

        public FilterCollection Postprocess
        {
            get { return postprocess; }
            protected set { postprocess = value; }
        }


      

        /// <summary>
        ///   Computes a set of inputs into a set of outputs.
        /// </summary>
        /// <remarks>
        ///  In the case the input consists of a single object (like a Matrix),
        ///  only it needs to be passed. It shouldn't be decomposed in smaller
        ///  parts, such as rows or vectors unless it is required by the system.
        /// </remarks>
        /// <param name="args">The inputs fed into the system.</param>
        /// <returns>The outputs computed using the given inputs.</returns>
        public abstract object[] Compute(params object[] args);

        public virtual object[][] Compute(params object[][] args)
        {
            object[][] output = new object[args.Length][];
            for (int i = 0; i < output.Length; i++)
			{
                output[i] = Compute(inputs[i]);
			}
            return output;
        }


        /// <summary>
        ///   Tests an Adaptive System for a set of inputs and outputs, verifying if
        ///   the computed output matches the expected output.
        /// </summary>
        /// <param name="input">The inputs to the system.</param>
        /// <param name="desiredOutput">The output the system was expected to give.</param>
        /// <param name="rawOutput">The raw (not postprocessed) output given by the system.</param>
        /// <param name="deviation">The deviation from the desired output to the raw output.</param>
        /// <returns>The normal, postprocessed output given by the system.</returns>
        public abstract object[] Test(object[] input, object[] desiredOutput,
            out double[] rawOutput, out double[] deviation);



        #region IWorkplaceComponent Members

        public string Name
        {
            get { return workplaceComponent.Name; }
            set { workplaceComponent.Name = value; }
        }

        public string Description
        {
               get { return workplaceComponent.Description; }
            set { workplaceComponent.Description = value; }
        }

        public string Remarks
        {
            get { return workplaceComponent.Remarks; }
            set { workplaceComponent.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return workplaceComponent.HasChanges; }
            protected set { workplaceComponent.HasChanges = value; }
        }

        public event EventHandler Changed;
        public event EventHandler Closed;

        #endregion
    }
}
