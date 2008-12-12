using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using AForge.Mathematics;
using AForge;

namespace Sinapse.Core.Filters
{
    public class Discretization : ICompleteFilter
    {

        float midpoint;
        DoubleRange range;
        int inputCount;
        int columnIndex;
        MidpointRounding midpointRounding;
        bool symmetric;

        public Discretization()
        {

        }

        public float Midpoint
        {
            get { return midpoint; }
            set
            {
                if (midpoint <= 0f || midpoint >= 1f)
                    throw new ArgumentOutOfRangeException("Tolerance");

                midpoint = value;
            }
        }

        /// <summary>
        ///   Gets or sets a boolean value indicating if a symmetric
        ///   rounding should be performed. Default is false.
        /// </summary>
        /// <remarks>
        ///   In Symmetric rounding, positive and negative numbers round
        ///   in opposite directions.
        /// </remarks>
        public bool Symmetric
        {
            get { return symmetric; }
            set { symmetric = value; }
        }

        public DoubleRange Range
        {
            get { return range; }
            set { range = value; }
        }

        public string Name
        {
            get { return "Discretization Filter"; }
        }

        public string Description
        {
            get { return "Transforms a continuous variables into discrete values"; }
        }

        public int InputCount
        {
            get { return inputCount; }
        }

        public int OutputCount
        {
            get { return inputCount; }
        }



        public void Apply(object input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Apply(object[] input)
        {
            double v = (double)input[columnIndex];
            double t = symmetric ? Math.Abs(v) : v;

            if (midpointRounding == MidpointRounding.AwayFromZero)
                t = (t >= (Math.Floor(t) + midpoint)) ? Math.Ceiling(t) : Math.Floor(t);
            else
                t = (t > (Math.Floor(t) + midpoint)) ? Math.Ceiling(t) : Math.Floor(t);

            v = (symmetric && v < 0) ? -t : t;

            // Assert we are inside the specified boundary
            input[columnIndex] = Math.Max(Math.Min(v, range.Max), range.Min);
        }

        public void Apply(object[][] input)
        {
            foreach (object[] row in input)
            {
                Apply(row);
            }
        }



        public void Reverse(object input)
        {
            // Converting from discrete to continuous
            // Do nothing, just fall through

            // TODO: A more complex filter could be written for
            // handling more elaborate discrete/continuous conversion
        }

        public void Reverse(object[] input)
        {
            // Do nothing, just fall through
        }

        public void Reverse(object[][] input)
        {
            // Do nothing, just fall through
        }
    }
}
