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
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Data;

namespace AForge.Mathematics
{

    public class Vector  : System.ComponentModel.IListSource
    {               // Consider switching to IList<Double>

        private double[] m_data;
        private int m_length; // cache vector size for performance


        //---------------------------------------------


        #region Constructor
        private Vector()
        {
        }

        public Vector(int size)
        {
            this.m_data = new double[size];
            this.m_length = size;
        }

        public Vector(params double[] values)
        {
            this.m_data = (Double[])values.Clone();
            this.m_length = values.GetLength(0);
        }

        public Vector(DataColumn dataColumn)
            : this(dataColumn.Table.Rows.Count)
        {

            if (dataColumn.DataType == typeof(System.String))
            {
                for (int i = 0; i < this.Length; i++)
                    this.baseArray[i] = Double.Parse((String)dataColumn.Table.Rows[i][dataColumn]);
            }
            else if (dataColumn.DataType == typeof(System.Boolean))
            {
                for (int i = 0; i < this.Length; i++)
                    this.baseArray[i] = (Boolean)dataColumn.Table.Rows[i][dataColumn] ? 1.0 : 0.0;
            }
            else
            {
                for (int i = 0; i < this.Length; i++)
                    this.baseArray[i] = (Double)dataColumn.Table.Rows[i][dataColumn];
            }
        }

        public Vector(List<Double> values)
        {
            this.m_data = values.ToArray();
            this.m_length = this.m_data.Length;
        }

        public Vector(IList values)
        {
            this.m_data = new double[values.Count];
            values.CopyTo(m_data, 0);
            this.m_length = m_data.Length;
        }

        public Vector(IListSource values)
            : this(values.GetList())
        {
        }

        public Vector(Vector vector)
        {
            this.m_data = (Double[])vector.m_data.Clone();
            this.m_length = vector.m_length;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal double[] baseArray
        {
            get { return m_data; }
        }

        public double this[int index]
        {
            get { return this.m_data[index]; }
            set { this.m_data[index] = value; }
        }

        public double Norm
        {
            get
            {
                double sum = 0.0;
                for (int i = 0; i < this.m_length; i++)
                {
                    sum += System.Math.Pow(this.m_data[i], 2);
                }
                return System.Math.Sqrt(sum);
            }
        }

        public double Sum
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < this.m_length; i++)
                {
                    sum += this.m_data[i];
                }
                return sum;
            }
        }

        public int Length
        {
            get { return this.m_length; }
        }

        public DoubleRange Range
        {
            get { return GetRange(this); }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public bool IsOrthogonal(Vector vector)
        {
            return (this * vector) == 0;
        }

        public void Swap(int i, int j)
        {
            double aux = this[i];
            this[i] = this[j];
            this[j] = aux;
        }

        public void Reverse()
        {
            Array.Reverse(this.m_data);
        }

        public Matrix Transpose()
        {
            Matrix m = new Matrix(this.Length, 1);
            m.SetColumn(1, this.m_data);
            return m;
        }

        /// <summary>Creates a deep copy of the AForge.Math.Vector.</summary>
        public Vector Clone()
        {
            return new Vector(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.m_length; i++)
            {
                sb.Append( this.m_data[i]);

                if (i < this.m_length - 1)
                    sb.Append( "\t");
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return this.m_data.GetHashCode() ^ this.m_length.GetHashCode();
        }
        #endregion


        //---------------------------------------------


        #region Interfaces & Bindings
        IList IListSource.GetList()
        {
            return this.baseArray;
        }

        bool IListSource.ContainsListCollection
        {
            get { return false; }
        }
        #endregion


        //---------------------------------------------



        #region Operators
        /// <summary>Determines weather two instances are equal.</summary>
        public override bool Equals(object obj)
        {
            return Equals(this, obj as Vector);
        }

        /// <summary>Determines weather two instances are equal.</summary>
        public static bool Equals(Vector left, Vector right)
        {
            if (((object)left) == ((object)right))
            {
                return true;
            }

            if ((((object)left) == null) || (((object)right) == null))
            {
                return false;
            }

            if (!DimensionEquals(left, right))
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                    if (left[i] != right[i])
                    {
                        return false;
                }
            }

            return true;
        }

        /// <summary>Determines weather two instances have dimension equality.</summary>
        public bool DimensionEquals(Vector value)
        {
            return DimensionEquals(this, value);
        }

        /// <summary>Determines weather two instances have dimension equality.</summary>
        public static bool DimensionEquals(Vector left, Vector right)
        {
            return (left.m_length == right.m_length);
        }

        /// <summary>Unary minus.</summary>
        public static Vector Negate(Vector value)
        {
            return Multiply(value, -1.0);
        }

		/// <summary>Unary minus.</summary>
        public static Vector operator -(Vector value)
        {
            return Negate(value);
        }

		/// <summary>Vector equality.</summary>
        public static bool operator==(Vector left, Vector right)
		{
			return Equals(left, right);
		}

		/// <summary>Vector inequality.</summary>
        public static bool operator!=(Vector left, Vector right)
		{
			return !Equals(left, right);
		}

		/// <summary>Vector addition.</summary>
        public static Vector Add(Vector left, Vector right)
		{
			if (left == null)
			{
				throw new ArgumentNullException("left");
			}

			if (right == null)
			{
				throw new ArgumentNullException("right");
			}

			if (!DimensionEquals(left, right))
			{
				throw new ArgumentException("Vector dimension do not match.");
			}

            Vector r = new Vector(left.m_length);
            for (int i = 0; i < left.m_length; i++)
            {
                r.m_data[i] = left.m_data[i] + right.m_data[i];
            }
			return r;
		}

		/// <summary>Matrix addition.</summary>
        public static Vector operator +(Vector left, Vector right)
		{
			return Add(left, right);
		}

		/// <summary>Matrix subtraction.</summary>
        public static Vector Subtract(Vector left, Vector right)
		{
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            if (!DimensionEquals(left, right))
            {
                throw new ArgumentException("Vector dimension do not match.");
            }

            Vector r = new Vector(left.m_length);
            for (int i = 0; i < left.m_length; i++)
            {
                r.m_data[i] = left.m_data[i] - right.m_data[i];
            }
            return r;
		}

		/// <summary>Matrix subtraction.</summary>
        public static Vector operator-(Vector left, Vector right)
		{
			return Subtract(left, right);
		}

		/// <summary>Matrix-scalar multiplication.</summary>
        public static Vector Multiply(Vector left, double right)
		{
			if (left == null)
			{
				throw new ArgumentNullException("left");
			}

            Vector r = new Vector(left.m_length);
            for (int i = 0; i < left.m_length; i++)
            {
                r[i] = left.m_data[i] * right;
            }
			return r;
		}

        /// <summary>Vector-scalar multiplication.</summary>
        public static Vector operator *(Vector left, double right)
		{
			return Multiply(left, right);
		}

        /// <summary>Vector-scalar multiplication.</summary>
        public static Vector operator *(double left, Vector right)
        {
            return Multiply(right,left);
        }

        public static double InnerProduct(Vector left, Vector right)
        {
            if (!Vector.DimensionEquals(left, right))
                throw new ArgumentException("Vector lengths does not match");

            double sum = 0.0;
            for (int i = 0; i < left.m_length; i++)
            {
                sum += left[i] * right[i];
            }
            return sum;
        }

        public static Vector OuterProduct(Vector left, Vector right)
        {
            throw new NotImplementedException();
        }

        /// <summary>Vector cross product.</summary>
        /// <remarks>This is the standard inner product of the orthonormal Euclidean space</remarks>
        public static Vector operator ^(Vector left, Vector right)
        {
            return OuterProduct(left, right); 
        }

        /// <summary>Vector dot product.</summary>
        /// <remarks>This is the standard inner product of the orthonormal Euclidean space</remarks>
        public static Double operator *(Vector left, Vector right)
        {
            return InnerProduct(left, right);
        }

        public static Vector Divide(Vector left, double right)
        {
            return Multiply(left, 1.0 / right);
        }

        public static Vector operator /(Vector left, double right)
        {
            return Divide(left, right);
        }

        public static Vector operator /(double left, Vector right)
        {
            return Divide(right, left);
        }

   /*
        public static explicit operator double[](Vector vector)
        {
            return (double[])vector.m_data;
        }
   */

        public static implicit operator Vector(double[] vector)
        {
            Vector r = new Vector();
            r.m_data = vector;
            r.m_length = vector.Length;
            return r;
        }

        /// <summary>Returns the vector in a double[] form.</summary>
        public static implicit operator double[](Vector vector)
        {
            return (double[])vector.m_data;
        }
        #endregion


        //---------------------------------------------


        #region Static Methods
        public static Vector Pow(Vector value, double power)
        {
            Vector r = value.Clone();
            for (int i = 0; i < r.m_data.Length; i++)
            {
                r.m_data[i] = System.Math.Pow(r.m_data[i], power);
            }
            return r;
        }

        public static Vector Sqrt(Vector value)
        {
            Vector r = value.Clone();
            for (int i = 0; i < r.m_data.Length; i++)
            {
                r.m_data[i] = System.Math.Sqrt(r.m_data[i]);
            }
            return r;
        }
        public static void Normalize(Vector vector)
        {
            double norm = vector.Norm;

            for (int i = 0; i < vector.m_length; i++)
            {
                vector[i] = vector[i] / norm;
            }
         }

        public static double Max(Vector vector)
        {
            double max = vector[0];

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] > max)
                    max = vector[i];
            }

            return max;
        }

        public static double Min(Vector vector)
        {
            double min = vector[0];

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] < min)
                    min = vector[i];
            }

            return min;
        }

        public static DoubleRange GetRange(Vector vector)
        {
            return DoubleRange.GetRange(vector.m_data);
        }
        #endregion

    }
}
