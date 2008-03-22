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

using AForge.Math;

namespace AForge.Math.LinearAlgebra
{

    /// <summary>
    /// In the mathematical discipline of linear algebra, eigendecomposition
    /// or sometimes spectral decomposition is the factorization of a matrix
    /// into a canonical form, whereby the matrix is represented in terms of
    /// its eigenvalues and eigenvectors.
    /// </summary>
    /// <remarks>
    ///  If A is symmetric, then A = V*D*V' where the eigenvalue matrix D is
    ///  diagonal and the eigenvector matrix V is orthogonal.
    /// 
    ///     i.e. A = V.times(D.times(V.transpose())) and 
    ///     V.times(V.transpose()) equals the identity matrix.
    /// 
    /// 
    ///  If A is not symmetric, then the eigenvalue matrix D is block diagonal
    ///  with the real eigenvalues in 1-by-1 blocks and any complex eigenvalues,
    ///  lambda + i*mu, in 2-by-2 blocks, [lambda, mu; -mu, lambda].  The
    ///  columns of V represent the eigenvectors in the sense that A*V = V*D,
    ///  
    ///     i.e. A.times(V) equals V.times(D).  The matrix V may be badly
    ///     conditioned, or even singular, so the validity of the equation
    ///     A = V*D*inverse(V) depends upon V.cond().
    /// 
    /// </remarks>
    public class EigenValueDecomposition
    {

        private int m_dimension;
        private Matrix m_matrix;

        private Vector m_eigenValuesReal;
        private Vector m_eigenValuesImag;
        private Matrix m_eigenVectors;


        //---------------------------------------------


        #region Constructor
        /// <summary>
        /// Class to encompass the EigenValue decomposition of square matrices
        /// </summary>
        /// <param name="matrix">The matrix to be decomposed. The original matrix contents are left unchanged.</param>
        public EigenValueDecomposition(Matrix matrix)
        {
            if (matrix.IsSquare == false)
                throw new Exception("EigenValue decomposition can only be performed on a square matrix");

            this.m_matrix = matrix;
            this.m_dimension = matrix.Rows;

            this.m_eigenVectors = new Matrix(m_dimension);
            this.m_eigenValuesReal = new Vector(m_dimension);
            this.m_eigenValuesImag = new Vector(m_dimension);
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public Vector EigenValuesReal
        {
            get { return this.m_eigenValuesReal; }
        }

        public Vector EigenValuesImaginary
        {
            get { return this.m_eigenValuesImag; }
        }

        public Matrix EigenVectors
        {
            get { return this.m_eigenVectors; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        /// <summary>
        /// Performs the eigen value decomposition
        /// </summary>
        public void Decompose()
        {
            if (this.m_matrix.IsSymmetric)
            {
                Vector diagonal, subdiagonal;
                Matrix transformationMatrix;

                Matrix tridiagonalMatrix = Algorithms.TridiagonalizeMatrix(this.m_matrix, out diagonal, out subdiagonal, out transformationMatrix);
                Algorithms.DiagonalizeMatrix(tridiagonalMatrix, diagonal, subdiagonal, Matrix.Identity(m_dimension), out m_eigenValuesReal, out m_eigenVectors);
            }
            else
            {
                Matrix hessenbergMatrix = Algorithms.ReduceToHessenberg(this.m_matrix);
                Algorithms.ReduceFromHessenbergToRealSchur(hessenbergMatrix, out m_eigenValuesReal, out m_eigenValuesImag, out m_eigenVectors);
            }
        }

        /// <summary>
        /// Performs the eigen value decomposition
        /// </summary>
        /// <param name="eigenValuesReal"></param>
        /// <param name="eigenValuesImaginary"></param>
        /// <param name="eigenVectors"></param>
        public void Decompose(out Vector eigenValuesReal, out Vector eigenValuesImaginary, out Matrix eigenVectors)
        {
            this.Decompose();
            eigenValuesReal = this.m_eigenValuesReal;
            eigenValuesImaginary = this.m_eigenValuesImag;
            eigenVectors = this.m_eigenVectors;
        }

        /// <summary>
        /// Performs the eigen value decomposition
        /// </summary>
        /// <param name="eigenValues"></param>
        /// <param name="eigenVectors"></param>
        public void Decompose(out Vector eigenValues, out Matrix eigenVectors)
        {
            this.Decompose();
            eigenValues = this.m_eigenValuesReal;
            eigenVectors = this.m_eigenVectors;
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        #endregion


    }
}
