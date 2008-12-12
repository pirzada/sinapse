// AForge Library
//
// Copyright © Andrew Kirillov, 2006
// andrew.kirillov@gmail.com
//

namespace AForge
{
    using System;

    /// <summary>
    /// Represents a double range with minimum and maximum values
    /// </summary>
    [Serializable]
    public class DoubleRange : IFormattable
    {
        private double min, max;


        /// <summary>
        ///   Gets or sets the minimum value of this range.
        /// </summary>
        public double Min
        {
            get { return this.min; }
            set { this.min = value; }
        }

        /// <summary>
        ///   Gets or sets the maximum value of this range.
        /// </summary>
        public double Max
        {
            get { return this.max; }
            set { this.max = value; }
        }

        /// <summary>
        ///   Gets the length of the range (the difference between maximum and minimum values).
        /// </summary>
        public double Length
        {
            get { return (max - min); }
        }


        /// <summary>
        ///   Initializes a new instance of the <see cref="DoubleRange"/> class.
        /// </summary>
        /// <param name="min">Minimum value of the range.</param>
        /// <param name="max">Maximum value of the range.</param>
        public DoubleRange(double min, double max)
        {
            this.min = min;
            this.max = max;
        }


        /// <summary>
        ///   Checks if the specified value is inside this range.
        /// </summary>
        /// <param name="x">Value to check</param>
        /// <returns>
        ///   <b>True</b> if the specified range overlaps with this range or
        ///   <b>false</b> otherwise.
        /// </returns>
        public bool IsInside(double x)
        {
            return ((x >= min) && (x <= max));
        }

        /// <summary>
        ///   Checks if the specified range is inside this range.
        /// </summary>
        /// <param name="range">Range to check</param>
        /// <returns>
        ///   <b>True</b> if the specified range overlaps with this range or
        ///   <b>false</b> otherwise.
        /// </returns>
        public bool IsInside(DoubleRange range)
        {
            return ((IsInside(range.min)) && (IsInside(range.max)));
        }

        /// <summary>
        ///   Checks if the specified range overlaps with this range
        /// </summary>
        /// <param name="range">Range to check for overlapping</param>
        /// <returns>
        ///   <b>True</b> if the specified range overlaps with this range or
        ///   <b>false</b> otherwise.
        /// </returns>
        public bool IsOverlapping(DoubleRange range)
        {
            return ((IsInside(range.min)) || (IsInside(range.max)));
        }


        /// <summary>
        ///   Converts the nummeric values of this instance to its
        ///   equivalent string representation.
        /// </summary>
        /// <returns>A System.String representing the current range.</returns>
        public override string ToString()
        {
            return ToString(String.Empty, null);
        }

        /// <summary>
        ///   Converts the nummeric values of this instance to its equivalent
        ///   string representation using the specified format information.
        /// </summary>
        /// <param name="format">A nummeric format string.</param>
        /// <returns>A System.String representing the current range.</returns>
        public string ToString(string format)
        {
            return ToString(format, null);
        }

        /// <summary>
        ///   Converts the nummeric values of this instance to its equivalent
        ///   string representation using the specified format information.
        /// </summary>
        /// <param name="format">A nummeric format string.</param>
        /// <param name="provider">A System.IFormatProvider that supplies culture specific formatting information.</param>
        /// <returns>A System.String representing the current range.</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return String.Concat(min.ToString(format), '-', max.ToString(format));
        }


        /// <summary>
        ///   Converts a DoubleRange object into its IntRange equivalent.
        /// </summary>
        /// <param name="range">The DoubleRange to be converted.</param>
        /// <returns>The equivalent IntRange.</returns>
        public static explicit operator IntRange(DoubleRange range)
        {
            return new IntRange((int)range.min, (int)range.max);
        }


        /// <summary>
        ///   Gets a real range of values from a double[] array.
        /// </summary>
        /// <param name="values">A real number array.</param>
        /// <returns>The given values' range.</returns>
        public static DoubleRange GetRange(double[] values)
        {
            double max = values[0];
            double min = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];

                if (values[i] < min)
                    min = values[i];
            }

            return new DoubleRange(min, max);
        }

        /// <summary>
        ///   Converts a value from a scale to another.
        /// </summary>
        /// <param name="x">The value to convert.</param>
        /// <param name="from">The scale in which x is measured.</param>
        /// <param name="dest">The destination scale for x.</param>
        /// <returns>The value of x in the destination scale.</returns>
        public static double Convert(double x, DoubleRange from, DoubleRange dest)
        {
            return ((x - from.Min) * (dest.Length) / (from.Length)) + dest.Min;
        }

    }
}
