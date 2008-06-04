// AForge Math Library
//
// Copyright © Andrew Kirillov, 2005-2007
// andrew.kirillov@gmail.com
//
// Modificiations by César Roberto de Souza, 2008
// cesarsouza@gmail.com
//

namespace AForge.Mathematics
{
	using System;

	/// <summary>
	/// Set of tool functions
	/// </summary>
	/// 
	/// <remarks>The class contains different utility functions.</remarks>
	/// 
	public class Tools
	{
		/// <summary>
		/// Calculates power of 2
		/// </summary>
		/// 
		/// <param name="power">Power</param>
		/// 
		/// <returns>Returns specified power of 2 in the case if power is in the range of
		/// [0, 30]. Otherwise returns 0.</returns>
		/// 
		public static int Pow2( int power )
		{
			return ( ( power >= 0 ) && ( power <= 30 ) ) ? ( 1 << power ) : 0;
		}

		/// <summary>
		/// Checks if the specified integer is power of 2
		/// </summary>
		/// 
		/// <param name="x">Integer number to check</param>
		/// 
		/// <returns>Returns <b>true</b> if the specified number is power of 2.
		/// Otherwise returns <b>false</b>.</returns>
		/// 
		public static bool IsPowerOf2( int x ) 
		{
			return ( x & ( x - 1 ) ) == 0;
		}

		/// <summary>
		/// Get base of binary logarithm
		/// </summary>
		/// 
		/// <param name="x">Source integer number</param>
		/// 
		/// <returns>Power of the number (base of binary logarithm).</returns>
		/// 
		public static int Log2( int x )
		{
			if ( x <= 65536 )
			{
				if ( x <= 256 )
				{
					if ( x <= 16 )
					{
						if ( x <= 4 )
						{
							if ( x <= 2 )
							{
								if ( x <= 1 )
									return 0;
								return 1;
							}
							return 2;
						}
						if ( x <= 8 )
							return 3;
						return 4;
					}
					if ( x <= 64 )
					{
						if ( x <= 32 )
							return 5;
						return 6;
					}
					if ( x <= 128 )
						return 7;
					return 8;
				}
				if ( x <= 4096 )
				{
					if ( x <= 1024 )
					{
						if ( x <= 512 )
							return 9;
						return 10;
					}
					if ( x <= 2048 )
						return 11;
					return 12;
				}
				if ( x <= 16384 )
				{
					if ( x <= 8192 )
						return 13;
					return 14;
				}
				if ( x <= 32768 )
					return 15;
				return 16;
			}

			if ( x <= 16777216 )
			{
				if ( x <= 1048576 )
				{
					if ( x <= 262144 )
					{
						if ( x <= 131072 )
							return 17;
						return 18;
					}
					if ( x <= 524288 )
						return 19;
					return 20;
				}
				if ( x <= 4194304 ) 
				{
					if ( x <= 2097152 )
						return 21;
					return 22;
				}
				if ( x <= 8388608 )
					return 23;
				return 24;
			}
			if ( x <= 268435456 )
			{
				if ( x <= 67108864 )
				{
					if ( x <= 33554432 )
						return 25;
					return 26;
				}
				if ( x <= 134217728 )
					return 27;
				return 28;
			}
			if ( x <= 1073741824 )
			{
				if ( x <= 536870912 )
					return 29;
				return 30;
			}
			return 31;
		}

        /// <summary>
        /// Hypotenuse calculus without overflow/underflow
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>The hypotenuse Sqrt(a^2 + b^2)</returns>
        public static double Hypotenuse(double a, double b)
        {
            double r = 0.0;

            if (System.Math.Abs(a) > System.Math.Abs(b))
            {
                r = b / a;
                r = System.Math.Abs(a) * System.Math.Sqrt(1 + r * r);
            }
            else if (b != 0)
            {
                r = a / b;
                r = System.Math.Abs(b) * System.Math.Sqrt(1 + r * r);
            }

            return r;
        }

        /// <summary>
        ///   Scales a variable from a scale into another, effectively
        ///   performing a rule of three on scales bundaries.
        /// </summary>
        /// <param name="x">The variable to be scaled.</param>
        /// <param name="from">The original scale of the variable.</param>
        /// <param name="to">The destination scale of the variable.</param>
        /// <returns>The scaled variable.</returns>
        public static double Scale(double x, DoubleRange from, DoubleRange to)
        {
            return ((x - from.Min) * to.Length / from.Length) + to.Min;
        }

        /// <summary>
        ///   Scales variables from a scale into another, effectively
        ///   performing a rule of three on scales bundaries.
        /// </summary>
        /// <param name="x">The variables to be scaled.</param>
        /// <param name="from">The original scale of the variables.</param>
        /// <param name="to">The destination scale of the variables.</param>
        /// <returns>The scaled variables.</returns>
        public double[] Scale(double[] x, DoubleRange from, DoubleRange to)
        {
            double[] r = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                r[i] = Scale(x[i], from, to);
            }
            return r;
        }
	}
}
