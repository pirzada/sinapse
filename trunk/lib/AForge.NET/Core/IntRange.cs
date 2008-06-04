// AForge Library
//
// Copyright © Andrew Kirillov, 2006
// andrew.kirillov@gmail.com
//
// Modifications by Cesar Roberto de Souza, 2008
// cesarsouza@gmail.com

namespace AForge
{
    using System;

    /// <summary>
    /// Represents an integer range with minimum and maximum values.
    /// </summary>
    [Serializable]
    public class IntRange
    {
        private int min, max;


        /// <summary>
        ///   Gets or sets the minimum value of this range.
        /// </summary>
        public int Min
        {
            get { return this.min; }
            set { this.min = value; }
        }

        /// <summary>
        ///   Gets or sets the maximum value of this range.
        /// </summary>
        public int Max
        {
            get { return this.max; }
            set { this.max = value; }
        }

        /// <summary>
        ///   Gets the length of the range (the difference between maximum and minimum values).
        /// </summary>
        public int Length
        {
            get { return (max - min); }
        }


        /// <summary>
        ///   Initializes a new instance of the <see cref="IntRange"/> class.
        /// </summary>
        /// <param name="min">Minimum value of the range.</param>
        /// <param name="max">Maximum value of the range.</param>
        public IntRange(int min, int max)
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
        public bool IsInside(int x)
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
        public bool IsInside(IntRange range)
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
        public bool IsOverlapping(IntRange range)
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
        ///   Converts a IntRange object into its DoubleRange equivalent.
        /// </summary>
        /// <param name="range">The IntRange to be converted.</param>
        /// <returns>The equivalent DoubleRange.</returns>
        public static explicit operator DoubleRange(IntRange range)
        {
            return new DoubleRange(range.min, range.max);
        }


        /// <summary>
        ///   Gets a discrete range of values from a int[] array.
        /// </summary>
        /// <param name="values">A natural number array.</param>
        /// <returns>The given values' range.</returns>
        public static IntRange GetRange(int[] values)
        {
            int max = values[0];
            int min = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];

                if (values[i] < min)
                    min = values[i];
            }

            return new IntRange(min, max);
        }
    }
}
