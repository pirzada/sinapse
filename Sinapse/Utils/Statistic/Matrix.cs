using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Utils.Statistic
{
    class Matrix
    {

        private double[][] matrix; // Faster than using [,]
        private int columns;       
        private int rows;


        /// <summary>
        /// Creates a new matrix element
        /// </summary>
        /// <param name="matrix">The base double[][] matrix</param>
        public Matrix(double[][] matrix)
        {
            this.matrix = matrix;
            this.rows = matrix.GetLength(0);
            this.columns = matrix.GetLength(1);
        }

        /// <summary>
        /// Creates a new matrix element
        /// </summary>
        /// <param name="lines">The matrix number of lines</param>
        /// <param name="columns">The matrix number of columns</param>
        public Matrix(int rows, int columns)
        {
            this.matrix = new double[rows][];
            for (int i = 0; i < rows; ++i)
            {
                this.matrix[i] = new double[columns];
            }

            this.rows = rows;
            this.columns = columns;
        }

        /// <summary>
        /// Retrieves a matrix element
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get { return this.matrix[i][j]; }
            set { this.matrix[i][j] = value; }
        }

        /// <summary>
        /// Retrieves a matrix row
        /// </summary>
        /// <param name="i">The row index</param>
        /// <returns></returns>
        public double[] this[int i]
        {
            get { return this.matrix[i]; }
        }

        /// <summary>
        /// Returns the width (number of columns) of this matrix
        /// </summary>
        public int Columns
        {
            get { return this.columns; }
        }

        /// <summary>
        /// Returns the height (number of lines) of this matrix
        /// </summary>
        public int Rows
        {
            get { return this.rows; }
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

            for (int i = 0; i < result.Rows; ++i)
            {
                for (int j = 0; j < result.Columns; ++j)
                {
                    for (int k = 0; k < matrix1.Columns; ++k)
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

            for (int i = 0; i < matrix.Rows; ++i)
            {
                for (int j = 0; j < matrix.Columns; ++j)
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
                    str += this[i, j].ToString() + "\t";
                str += "\n";
            }
            return str;
        }

        public double[][] ToDoubleArray()
        {
            return this.matrix;
        }

    }
}
