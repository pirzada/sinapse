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

namespace AForge.Math
{
    /// <summary>
    /// In mathematics, a matrix (plural matrices) is a rectangular
    /// table of elements (or entries), which may be numbers or, more
    /// generally, any abstract quantities that can be added and multiplied.
    /// </summary>
    public class Matrix : ICloneable
    {

        private double[][] m_matrix; // works faster than using [,]
        private int m_cols;       
        private int m_rows;

     
        //---------------------------------------------


        #region Constructors
        /// <summary>
        /// Creates a new matrix object.
        /// </summary>
        /// <param name="matrix">The base double[][] matrix</param>
        public Matrix(double[][] matrix)
        {
            this.m_matrix = matrix;
            this.m_rows = matrix.GetLength(0);
            if (this.m_rows > 0)
            {
                this.m_cols = matrix[0].GetLength(0);
            }
            else this.m_cols = 0;
        }

        /// <summary>
        /// Creates a new matrix object.
        /// </summary>
        /// <param name="matrix">The base double[,] matrix</param>
        public Matrix(double[,] matrix)
        {
            this.m_rows = matrix.GetLength(0);
            this.m_cols = matrix.GetLength(1);
            this.m_matrix = new double[m_rows][];

            for (int i = 0; i < m_rows; i++)
            {
                this.m_matrix[i] = new double[m_cols];
                for (int j = 0; j < m_cols; j++)
                {
                    this.m_matrix[i][j] = matrix[i, j];
                }
            }
        }

        /// <summary>
        /// Creates a new copy of a matrix object
        /// </summary>
        /// <param name="matrix">The matrix to be copied.</param>
        public Matrix(Matrix matrix)
        {
            this.m_matrix = matrix.m_matrix;
            this.m_cols = matrix.m_cols;
            this.m_rows = matrix.m_rows;
        }

        /// <summary>
        /// Creates a new matrix object.
        /// </summary>
        /// <param name="rows">The matrix number of rows.</param>
        /// <param name="columns">The matrix number of columns.</param>
        public Matrix(int rows, int columns)
        {
            this.m_matrix = new double[rows][];
            for (int i = 0; i < rows; ++i)
            {
                this.m_matrix[i] = new double[columns];
            }

            this.m_rows = rows;
            this.m_cols = columns;
        }

        /// <summary>
        /// Creates a new square matrix object
        /// </summary>
        /// <param name="dimension">The square dimension of the matrix</param>
        public Matrix(int dimension)
            : this(dimension, dimension)
        {
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        /// Retrieves a matrix element
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get { return this.m_matrix[i][j]; }
            set { this.m_matrix[i][j] = value; }
        }

        /// <summary>
        /// Retrieves a matrix row
        /// </summary>
        /// <param name="i">The row index</param>
        /// <returns></returns>
        public double[] this[int i]
        {
            get { return this.GetRow(i); }
            set { this.SetRow(i, value); }
        }

        /// <summary>
        /// Returns number of columns (usually represented by n) of this matrix
        /// </summary>
        public int Columns
        {
            get { return this.m_cols; }
        }

        /// <summary>
        /// Returns number of rows (usually represented by m) of this matrix
        /// </summary>
        public int Rows
        {
            get { return this.m_rows; }
        }

        /// <summary>
        /// A square matrix is a matrix which has the same number of rows and columns.
        /// </summary>
        public bool IsSquare
        {
            get { return (this.Rows == this.Columns); }
        }

        /// <summary>
        /// In linear algebra, a symmetric matrix is a
        /// square matrix that is equal to its transpose.
        /// </summary>
        public bool IsSymmetric
        {
            get
            {
                if (this.IsSquare == false)
                    return false;

                for (int i = 0; i < this.Rows; ++i)
                {
                    for (int j = 0; j < this.Rows; ++j)
                    {
                        if (this[i, j] != this[j, i])
                            return false;
                    }
                }
                
                return true;
            }
        }

        /// <summary>
        /// In linear algebra, the main diagonal (sometimes leading diagonal)
        /// of a square matrix is the diagonal which runs from the top left
        /// corner to the bottom right corner.
        /// </summary>
        public Vector MainDiagonal
        {
            get
            {
                if (!this.IsSquare)
                    return null;

                Vector d = new Vector(this.Rows);

                for (int i = 0; i < this.Rows; i++)
                {
                    d[i] = this[i][i];
                }

                return d;
            }
        }

        /// <summary>
        /// In linear algebra, the trace of an n-by-n square matrix A is defined
        /// to be the sum of the elements on the main diagonal (the diagonal from
        /// the upper left to the lower right) of A
        /// </summary>
        public double Trace
        {
            get
            {
                double sum = 0.0;
                Vector d = MainDiagonal;
                if (d != null)
                {
                    for (int i = 0; i < this.Rows; i++)
                        sum += d[i];
                }
                return sum;
            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        /// <summary>
        /// Swaps two columns of this matrix
        /// </summary>
        /// <param name="column1">The first column index to be swapped</param>
        /// <param name="column2">The second column index to be swapped</param>
        public void SwapColumns(int column1, int column2)
        {
            double[] aux = this.GetCol(column1);
            this.SetCol(column1, this.GetCol(column2));
            this.SetCol(column2, aux);
        }

        /// <summary>
        /// Swaps two rows of this matrix
        /// </summary>
        /// <param name="row1">The first row index to be swapped</param>
        /// <param name="row2">The second row index to be swapped</param>
        public void SwapRows(int row1, int row2)
        {
            double[] aux = this.GetRow(row1);
            this.SetRow(row1, this.GetRow(row2));
            this.SetRow(row2, aux);
        }

        /// <summary>
        /// Gets a entire row of the matrix as a double array
        /// </summary>
        /// <param name="index">The row's index</param>
        /// <returns>The row double array</returns>
        public double[] GetRow(int index)
        {
            return this.m_matrix[index];
        }

        /// <summary>
        /// Sets a entire row of the matrix based on a double array
        /// </summary>
        /// <param name="index">The row's index</param>
        /// <param name="row">The row new double array</param>
        public void SetRow(int index, double[] row)
        {
            if (row.Length != this.Columns)
                throw new ArgumentException("The supplied row has a different number of columns than this matrix", "row");

            this.m_matrix[index] = row;
        }

        /// <summary>
        /// Gets a entire row of the matrix as a double array
        /// </summary>
        /// <param name="index">The row's index</param>
        /// <returns>The row double array</returns>
        public double[] GetCol(int index)
        {
            double[] col = new double[this.Rows];

            for (int i = 0; i < col.Length; i++)
            {
                col[i] = this[i, index];
            }

            return col;
        }

        /// <summary>
        /// Sets a entire column of the matrix based on a double array
        /// </summary>
        /// <param name="index">The column's index</param>
        /// <param name="column">The column new double array</param>
        public void SetCol(int index, double[] column)
        {
            if (column.Length != this.Rows)
                throw new ArgumentException("The supplied column has a different number of rows than this matrix", "row");

            for (int i = 0; i < column.Length; i++)
            {
                this[i, index] = column[i];
            }
        }

        /// <summary>
        /// Returns the transpose of the this matrix
        /// </summary>
        public Matrix Transpose()
        {
            Matrix transposeMatrix = new Matrix(this.Columns, this.Rows);
            for (int i = 0; i < transposeMatrix.Rows; ++i)
            {
                for (int j = 0; j < transposeMatrix.Columns; ++j)
                {
                    transposeMatrix[i, j] = this[j, i];
                }
            }
            return transposeMatrix;
        }

        /// <summary>
        /// Creates a shallow copy of this object
        /// </summary>
        /// <returns>The new object.</returns>
        public virtual object Clone()
        {
            return new Matrix(this);
        }

        /// <summary>
        /// Converts this matrix to a string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = String.Empty;
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    str += this[i, j].ToString();

                    if (j < this.Columns - 1)
                        str += "\t";
                }
                if (i < this.Rows - 1)
                    str += "\n";
            }
            return str;
        }

        public double[][] ToDoubleArray()
        {
            return (double[][])this.m_matrix.Clone();
        }

        public double[,] ToDoubleMatrix()
        {
            double[,] m = new double[this.m_rows, this.m_cols];

            for (int i = 0; i < this.m_rows; ++i)
            {
                for (int j = 0; j < this.m_cols; ++j)
                {
                    m[i, j] = this.m_matrix[i][j];
                }
            }
            return m;
        }

        /// <summary>
        /// Compares two columns for dimension equality
        /// </summary>
        /// <param name="b">The second matrix</param>
        /// <returns></returns>
        public bool DimensionEquals(Matrix b)
        {
            return (this.Rows == b.Rows || this.Columns == b.Columns);
        }
        #endregion


        //---------------------------------------------


        #region Protected Methods
        protected double[][] BaseMatrix
        {
            get { return this.m_matrix; }
            set { this.m_matrix = value; }
        }
        #endregion


        //---------------------------------------------


        #region Operators
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            return Matrix.Multiply(matrix1, matrix2);
        }

        public static Matrix operator *(Matrix matrix, double x)
        {
            return Matrix.Multiply(matrix, x);
        }

        public static Matrix operator *(double x, Matrix matrix)
        {
            return Matrix.Multiply(matrix, x);
        }

        public static Matrix operator *(Matrix matrix, int n)
        {
            return Matrix.Multiply(matrix, n);
        }

        private static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns != matrix2.Rows)
            {
                throw new Exception("Can't multiply matrices with unmatching dimensions");
            }

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        private static Matrix Multiply(Matrix matrix, double x)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result[i, j] = matrix[i, j] * x;
                }
            }
            return result;
        }

        private static Matrix Multiply(Matrix matrix, int n)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Rows; ++i)
            {
                for (int j = 0; j < matrix.Columns; ++j)
                {
                    result[i, j] = matrix[i, j] * n;
                }
            }
            return result;
        }
        #endregion


        //---------------------------------------------


        #region Static Methods
        public static Matrix Identity(int dimension)
        {
            Matrix m = new Matrix(dimension);
            for (int i = 0; i < dimension; i++)
                m[i, i] = 1;

            return m;
        }
        #endregion

    }
}
