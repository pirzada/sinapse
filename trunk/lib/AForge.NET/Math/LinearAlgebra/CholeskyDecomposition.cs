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

namespace AForge.Math.LinearAlgebra
{
    /// <summary>
    /// In mathematics, the Cholesky decomposition is a matrix decomposition
    /// similar to LU decomposition, but applies only to symmetric and positive
    /// definite matrices.
    /// </summary>
    /// <remarks>
    /// Any square matrix A with non-zero pivots can be written as the product of a
    /// lower triangular matrix L and an upper triangular matrix U; this is called
    /// the LU decomposition. However, if A is symmetric and positive definite, we
    /// can choose the factors such that U is the transpose of L, and this is called
    /// the Cholesky decomposition. Both the LU and the Cholesky decomposition are
    /// used to solve systems of linear equations.
    /// 
    /// When it is applicable, the Cholesky decomposition is twice as efficient
    /// as the LU decomposition.
    /// 
    /// </remarks>
    public class CholeskyDecomposition
    {
    }
}
