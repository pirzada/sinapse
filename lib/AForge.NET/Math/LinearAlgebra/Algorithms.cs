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
    /// Static class to hold algorithms commonly used in Linear Algebra
    /// </summary>
    public static class Algorithms
    {

        /// <summary>
        /// This function reduces a real symmetric matrix to a
        /// symmetric tridiagonal matrix using and accumulating 
        /// orthogonal similarity transformations.
        /// </summary>
        /// <param name="matrix">The real symmetric input matrix.</param>
        /// <param name="diagonal">The obtained diagonal elements</param>
        /// <param name="subdiagonal">The obtained subdiagonal elements
        /// of the tridiagonal matrix in its last n-1 positions.</param>
        /// <param name="transformationMatrix">The orthogonal transformation matrix
        /// produced in the reduction</param>
        public static Matrix TridiagonalizeMatrix(Matrix matrix, out Vector diagonal, out Vector subdiagonal, out Matrix transformationMatrix)
        {
            //  This is derived from the Algol procedures tred2 by
            //  Bowdler, Martin, Reinsch, and Wilkinson, Handbook for
            //  Auto. Comp., Vol.ii-Linear Algebra, and the corresponding
            //  Fortran subroutine in EISPACK.


            int dimension = matrix.Rows;
            Matrix V = (Matrix)matrix.Clone();
            diagonal = new Vector(dimension);
            subdiagonal = new Vector(dimension);
            transformationMatrix = new Matrix(dimension);



            for (int j = 0; j < dimension; j++)
            {
                diagonal[j] = V[dimension - 1][j];
            }

            // Householder reduction to tridiagonal form.

            for (int i = dimension - 1; i > 0; i--)
            {

                // Scale to avoid under/overflow.

                double scale = 0.0;
                double h = 0.0;
                for (int k = 0; k < i; k++)
                {
                    scale = scale + System.Math.Abs(diagonal[k]);
                }
                if (scale == 0.0)
                {
                    subdiagonal[i] = diagonal[i - 1];
                    for (int j = 0; j < i; j++)
                    {
                        diagonal[j] = V[i - 1][j];
                        V[i][j] = 0.0;
                        V[j][i] = 0.0;
                    }
                }
                else
                {

                    // Generate Householder vector.

                    for (int k = 0; k < i; k++)
                    {
                        diagonal[k] /= scale;
                        h += diagonal[k] * diagonal[k];
                    }
                    double f = diagonal[i - 1];
                    double g = System.Math.Sqrt(h);
                    if (f > 0)
                    {
                        g = -g;
                    }
                    subdiagonal[i] = scale * g;
                    h = h - f * g;
                    diagonal[i - 1] = f - g;
                    for (int j = 0; j < i; j++)
                    {
                        subdiagonal[j] = 0.0;
                    }

                    // Apply similarity transformation to remaining columns.

                    for (int j = 0; j < i; j++)
                    {
                        f = diagonal[j];
                        V[j][i] = f;
                        g = subdiagonal[j] + V[j][j] * f;
                        for (int k = j + 1; k <= i - 1; k++)
                        {
                            g += V[k][j] * diagonal[k];
                            subdiagonal[k] += V[k][j] * f;
                        }
                        subdiagonal[j] = g;
                    }
                    f = 0.0;
                    for (int j = 0; j < i; j++)
                    {
                        subdiagonal[j] /= h;
                        f += subdiagonal[j] * diagonal[j];
                    }
                    double hh = f / (h + h);
                    for (int j = 0; j < i; j++)
                    {
                        subdiagonal[j] -= hh * diagonal[j];
                    }
                    for (int j = 0; j < i; j++)
                    {
                        f = diagonal[j];
                        g = subdiagonal[j];
                        for (int k = j; k <= i - 1; k++)
                        {
                            V[k][j] -= (f * subdiagonal[k] + g * diagonal[k]);
                        }
                        diagonal[j] = V[i - 1][j];
                        V[i][j] = 0.0;
                    }
                }
                diagonal[i] = h;
            }

            // Accumulate transformations.

            for (int i = 0; i < dimension - 1; i++)
            {
                V[dimension - 1][i] = V[i][i];
                V[i][i] = 1.0;
                double h = diagonal[i + 1];
                if (h != 0.0)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        diagonal[k] = V[k][i + 1] / h;
                    }
                    for (int j = 0; j <= i; j++)
                    {
                        double g = 0.0;
                        for (int k = 0; k <= i; k++)
                        {
                            g += V[k][i + 1] * V[k][j];
                        }
                        for (int k = 0; k <= i; k++)
                        {
                            V[k][j] -= g * diagonal[k];
                        }
                    }
                }
                for (int k = 0; k <= i; k++)
                {
                    V[k][i + 1] = 0.0;
                }
            }
            for (int j = 0; j < dimension; j++)
            {
                diagonal[j] = V[dimension - 1][j];
                V[dimension - 1][j] = 0.0;
            }
            V[dimension - 1][dimension - 1] = 1.0;
            subdiagonal[0] = 0.0;

            return V;
        }


        /// <summary>
        /// This function finds the eigenvalues and eigenvectors of
        /// a symmetric tridiagonal matrix by the QL algorithm.
        /// The eigenvectors of a full symmetric matrix can also be found
        /// if tred2 has been used to reduce this full matrix to tridiagonal form.
        /// </summary>
        /// <remarks> This is derived from the Algol procedures tql2, by
        //  Bowdler, Martin, Reinsch, and Wilkinson, Handbook for
        //  Auto. Comp., Vol.ii-Linear Algebra, and the corresponding
        //  Fortran subroutine in EISPACK.</remarks>
        /// <param name="matrix">The real symmetric tridiagonal matrix</param>
        /// <param name="diagonal">The diagonal of the tridiagonal input matrix</param>
        /// <param name="subdiagonal">The subdiagonal of the tridiagonal input matrix</param>
        /// <param name="transformationMatrix">the transformation matrix produced in
        /// the reduction by  tred2, if performed. If the eigenvectors of the
        /// tridiagonal matrix are desired, it must contain the identity matrix.</param>
        /// <param name="eigenValues">The vector of eigen values</param>
        /// <param name="eigenVectors">The matrix of eigen vectors</param>
        public static void DiagonalizeMatrix(Matrix matrix, Vector diagonal, Vector subdiagonal, Matrix transformationMatrix, out Vector eigenValues, out Matrix eigenVectors)
        {

            //  This is derived from the Algol procedures tql2, by
            //  Bowdler, Martin, Reinsch, and Wilkinson, Handbook for
            //  Auto. Comp., Vol.ii-Linear Algebra, and the corresponding
            //  Fortran subroutine in EISPACK.



            int dimension = matrix.Rows;
            eigenValues = (Vector)diagonal.Clone();
            eigenVectors = (Matrix)transformationMatrix.Clone();
            Vector e = (Vector)subdiagonal.Clone();


            for (int i = 1; i < dimension; i++)
            {
                e[i - 1] = e[i];
            }
            e[dimension - 1] = 0.0;

            double f = 0.0;
            double tst1 = 0.0;
            double eps = System.Math.Pow(2.0, -52.0);
            for (int l = 0; l < dimension; l++)
            {

                // Find small subdiagonal element

                tst1 = System.Math.Max(tst1, System.Math.Abs(eigenValues[l]) + System.Math.Abs(e[l]));
                int m = l;
                while (m < dimension)
                {
                    if (System.Math.Abs(e[m]) <= eps * tst1)
                    {
                        break;
                    }
                    m++;
                }

                // If m == l, d[l] is an eigenvalue,
                // otherwise, iterate.

                if (m > l)
                {
                    int iter = 0;
                    do
                    {
                        iter = iter + 1;  // (Could check iteration count here.)

                        // Compute implicit shift

                        double g = eigenValues[l];
                        double p = (eigenValues[l + 1] - g) / (2.0 * e[l]);
                        double r = Tools.Hypotenuse(p, 1.0);
                        if (p < 0)
                        {
                            r = -r;
                        }
                        eigenValues[l] = e[l] / (p + r);
                        eigenValues[l + 1] = e[l] * (p + r);
                        double dl1 = eigenValues[l + 1];
                        double h = g - eigenValues[l];
                        for (int i = l + 2; i < dimension; i++)
                        {
                            eigenValues[i] -= h;
                        }
                        f = f + h;

                        // Implicit QL transformation.

                        p = eigenValues[m];
                        double c = 1.0;
                        double c2 = c;
                        double c3 = c;
                        double el1 = e[l + 1];
                        double s = 0.0;
                        double s2 = 0.0;
                        for (int i = m - 1; i >= l; i--)
                        {
                            c3 = c2;
                            c2 = c;
                            s2 = s;
                            g = c * e[i];
                            h = c * p;
                            r = Tools.Hypotenuse(p, e[i]);
                            e[i + 1] = s * r;
                            s = e[i] / r;
                            c = p / r;
                            p = c * eigenValues[i] - s * g;
                            eigenValues[i + 1] = h + s * (c * g + s * eigenValues[i]);

                            // Accumulate transformation.

                            for (int k = 0; k < dimension; k++)
                            {
                                h = eigenVectors[k][i + 1];
                                eigenVectors[k][i + 1] = s * eigenVectors[k][i] + c * h;
                                eigenVectors[k][i] = c * eigenVectors[k][i] - s * h;
                            }
                        }
                        p = -s * s2 * c3 * el1 * e[l] / dl1;
                        e[l] = s * p;
                        eigenValues[l] = c * p;

                        // Check for convergence.

                    } while (System.Math.Abs(e[l]) > eps * tst1);
                }
                eigenValues[l] = eigenValues[l] + f;
                e[l] = 0.0;
            }

            // Sort eigenvalues and corresponding vectors.

            for (int i = 0; i < dimension - 1; i++)
            {
                int k = i;
                double p = eigenValues[i];
                for (int j = i + 1; j < dimension; j++)
                {
                    if (eigenValues[j] < p)
                    {
                        k = j;
                        p = eigenValues[j];
                    }
                }
                if (k != i)
                {
                    eigenValues[k] = eigenValues[i];
                    eigenValues[i] = p;
                    for (int j = 0; j < dimension; j++)
                    {
                        p = eigenVectors[j][i];
                        eigenVectors[j][i] = eigenVectors[j][k];
                        eigenVectors[j][k] = p;
                    }
                }
            }
        }

        /// <summary>
        /// Given a real general matrix, this function reduces a submatrix
        /// situated in rows and columns low through high to upper hessenberg
        /// form by orthogonal similarity transformations.
        /// </summary>
        /// <param name="matrix">The original matrix</param>
        /// <returns>The Hessenberg Matrix</returns>
        public static Matrix ReduceToHessenberg(Matrix matrix)
        {
            //  This is derived from the Algol procedures orthes and ortran,
            //  by Martin and Wilkinson, Handbook for Auto. Comp.,
            //  Vol.ii-Linear Algebra, and the corresponding
            //  Fortran subroutines in EISPACK.


            // Algorithm Adjust (for simplicity sake)
            int n = matrix.Columns;
            Matrix V = matrix;
            Matrix H = (Matrix)matrix.Clone();
            double[] ort = new double[matrix.Rows];


            // Initialize

            int low = 0;
            int high = n - 1;

            for (int m = low + 1; m <= high - 1; m++)
            {

                // Scale column.

                double scale = 0.0;
                for (int i = m; i <= high; i++)
                {
                    scale = scale + System.Math.Abs(H[i][m - 1]);
                }
                if (scale != 0.0)
                {

                    // Compute Householder transformation.

                    double h = 0.0;
                    for (int i = high; i >= m; i--)
                    {
                        ort[i] = H[i][m - 1] / scale;
                        h += ort[i] * ort[i];
                    }
                    double g = System.Math.Sqrt(h);
                    if (ort[m] > 0)
                    {
                        g = -g;
                    }
                    h = h - ort[m] * g;
                    ort[m] = ort[m] - g;

                    // Apply Householder similarity transformation
                    // H = (I-u*u'/h)*H*(I-u*u')/h)

                    for (int j = m; j < n; j++)
                    {
                        double f = 0.0;
                        for (int i = high; i >= m; i--)
                        {
                            f += ort[i] * H[i][j];
                        }
                        f = f / h;
                        for (int i = m; i <= high; i++)
                        {
                            H[i][j] -= f * ort[i];
                        }
                    }

                    for (int i = 0; i <= high; i++)
                    {
                        double f = 0.0;
                        for (int j = high; j >= m; j--)
                        {
                            f += ort[j] * H[i][j];
                        }
                        f = f / h;
                        for (int j = m; j <= high; j++)
                        {
                            H[i][j] -= f * ort[j];
                        }
                    }
                    ort[m] = scale * ort[m];
                    H[m][m - 1] = scale * g;
                }
            }

            // Accumulate transformations (Algol's ortran).

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    V[i][j] = (i == j ? 1.0 : 0.0);
                }
            }

            for (int m = high - 1; m >= low + 1; m--)
            {
                if (H[m][m - 1] != 0.0)
                {
                    for (int i = m + 1; i <= high; i++)
                    {
                        ort[i] = H[i][m - 1];
                    }
                    for (int j = m; j <= high; j++)
                    {
                        double g = 0.0;
                        for (int i = m; i <= high; i++)
                        {
                            g += ort[i] * V[i][j];
                        }
                        // Double division avoids possible underflow
                        g = (g / ort[m]) / H[m][m - 1];
                        for (int i = m; i <= high; i++)
                        {
                            V[i][j] += g * ort[i];
                        }
                    }
                }
            }

            return H;
        }


        /// <summary>
        /// This subroutine finds the eigenvalues and eigenvectors of a
        /// REAL UPPER Hessenberg matrix by the QR method. The eigenvectors
        /// of a REAL GENERAL matrix can also be found if  ELMHES  and  ELTRAN
        /// or  ORTHES  and  ORTRAN  have been used to reduce this general
        /// matrix to Hessenberg form and to accumulate the similarity transformations.
        /// </summary>
        /// <param name="hessenbergMatrix">The original hessenberg matrix</param>
        /// <param name="realEigenValues">The real part of the eigen values</param>
        /// <param name="imagEigenValues">The imaginary part of the eigen values</param>
        /// <param name="eigenVectors">The matrix of eigen vectors</param>
        public static void ReduceFromHessenbergToRealSchur(Matrix hessenbergMatrix, out Vector realEigenValues, out Vector imagEigenValues, out Matrix eigenVectors)
        {
            //  This is derived from the Algol procedure hqr2,
            //  by Martin and Wilkinson, Handbook for Auto. Comp.,
            //  Vol.ii-Linear Algebra, and the corresponding
            //  Fortran subroutine in EISPACK.


            // Algorithm Adjust (for simplicity sake)
            int dimension = hessenbergMatrix.Rows;
            realEigenValues = new Vector(dimension);
            imagEigenValues = new Vector(dimension);
            eigenVectors = new Matrix(dimension);

            Matrix H = (Matrix)hessenbergMatrix.Clone();


            // Initialize

            int nn = dimension;
            int n = nn - 1;
            int low = 0;
            int high = nn - 1;
            double eps = System.Math.Pow(2.0, -52.0);
            double exshift = 0.0;
            double p = 0, q = 0, r = 0, s = 0, z = 0, t, w, x, y;

            // Store roots isolated by balanc and compute matrix norm

            double norm = 0.0;
            for (int i = 0; i < nn; i++)
            {
                if (i < low | i > high)
                {
                    realEigenValues[i] = H[i][i];
                    imagEigenValues[i] = 0.0;
                }
                for (int j = System.Math.Max(i - 1, 0); j < nn; j++)
                {
                    norm = norm + System.Math.Abs(H[i][j]);
                }
            }

            // Outer loop over eigenvalue index

            int iter = 0;
            while (n >= low)
            {

                // Look for single small sub-diagonal element

                int l = n;
                while (l > low)
                {
                    s = System.Math.Abs(H[l - 1][l - 1]) + System.Math.Abs(H[l][l]);
                    if (s == 0.0)
                    {
                        s = norm;
                    }
                    if (System.Math.Abs(H[l][l - 1]) < eps * s)
                    {
                        break;
                    }
                    l--;
                }

                // Check for convergence
                // One root found

                if (l == n)
                {
                    H[n][n] = H[n][n] + exshift;
                    realEigenValues[n] = H[n][n];
                    imagEigenValues[n] = 0.0;
                    n--;
                    iter = 0;

                    // Two roots found

                }
                else if (l == n - 1)
                {
                    w = H[n][n - 1] * H[n - 1][n];
                    p = (H[n - 1][n - 1] - H[n][n]) / 2.0;
                    q = p * p + w;
                    z = System.Math.Sqrt(System.Math.Abs(q));
                    H[n][n] = H[n][n] + exshift;
                    H[n - 1][n - 1] = H[n - 1][n - 1] + exshift;
                    x = H[n][n];

                    // Real pair

                    if (q >= 0)
                    {
                        if (p >= 0)
                        {
                            z = p + z;
                        }
                        else
                        {
                            z = p - z;
                        }
                        realEigenValues[n - 1] = x + z;
                        realEigenValues[n] = realEigenValues[n - 1];
                        if (z != 0.0)
                        {
                            realEigenValues[n] = x - w / z;
                        }
                        imagEigenValues[n - 1] = 0.0;
                        imagEigenValues[n] = 0.0;
                        x = H[n][n - 1];
                        s = System.Math.Abs(x) + System.Math.Abs(z);
                        p = x / s;
                        q = z / s;
                        r = System.Math.Sqrt(p * p + q * q);
                        p = p / r;
                        q = q / r;

                        // Row modification

                        for (int j = n - 1; j < nn; j++)
                        {
                            z = H[n - 1][j];
                            H[n - 1][j] = q * z + p * H[n][j];
                            H[n][j] = q * H[n][j] - p * z;
                        }

                        // Column modification

                        for (int i = 0; i <= n; i++)
                        {
                            z = H[i][n - 1];
                            H[i][n - 1] = q * z + p * H[i][n];
                            H[i][n] = q * H[i][n] - p * z;
                        }

                        // Accumulate transformations

                        for (int i = low; i <= high; i++)
                        {
                            z = eigenVectors[i][n - 1];
                            eigenVectors[i][n - 1] = q * z + p * eigenVectors[i][n];
                            eigenVectors[i][n] = q * eigenVectors[i][n] - p * z;
                        }

                        // Complex pair

                    }
                    else
                    {
                        realEigenValues[n - 1] = x + p;
                        realEigenValues[n] = x + p;
                        imagEigenValues[n - 1] = z;
                        imagEigenValues[n] = -z;
                    }
                    n = n - 2;
                    iter = 0;

                    // No convergence yet

                }
                else
                {

                    // Form shift

                    x = H[n][n];
                    y = 0.0;
                    w = 0.0;
                    if (l < n)
                    {
                        y = H[n - 1][n - 1];
                        w = H[n][n - 1] * H[n - 1][n];
                    }

                    // Wilkinson's original ad hoc shift

                    if (iter == 10)
                    {
                        exshift += x;
                        for (int i = low; i <= n; i++)
                        {
                            H[i][i] -= x;
                        }
                        s = System.Math.Abs(H[n][n - 1]) + System.Math.Abs(H[n - 1][n - 2]);
                        x = y = 0.75 * s;
                        w = -0.4375 * s * s;
                    }

                    // MATLAB's new ad hoc shift

                    if (iter == 30)
                    {
                        s = (y - x) / 2.0;
                        s = s * s + w;
                        if (s > 0)
                        {
                            s = System.Math.Sqrt(s);
                            if (y < x)
                            {
                                s = -s;
                            }
                            s = x - w / ((y - x) / 2.0 + s);
                            for (int i = low; i <= n; i++)
                            {
                                H[i][i] -= s;
                            }
                            exshift += s;
                            x = y = w = 0.964;
                        }
                    }

                    iter = iter + 1;   // (Could check iteration count here.)

                    // Look for two consecutive small sub-diagonal elements

                    int m = n - 2;
                    while (m >= l)
                    {
                        z = H[m][m];
                        r = x - z;
                        s = y - z;
                        p = (r * s - w) / H[m + 1][m] + H[m][m + 1];
                        q = H[m + 1][m + 1] - z - r - s;
                        r = H[m + 2][m + 1];
                        s = System.Math.Abs(p) + System.Math.Abs(q) + System.Math.Abs(r);
                        p = p / s;
                        q = q / s;
                        r = r / s;
                        if (m == l)
                        {
                            break;
                        }
                        if (System.Math.Abs(H[m][m - 1]) * (System.Math.Abs(q) + System.Math.Abs(r)) <
                           eps * (System.Math.Abs(p) * (System.Math.Abs(H[m - 1][m - 1]) + System.Math.Abs(z) +
                           System.Math.Abs(H[m + 1][m + 1]))))
                        {
                            break;
                        }
                        m--;
                    }

                    for (int i = m + 2; i <= n; i++)
                    {
                        H[i][i - 2] = 0.0;
                        if (i > m + 2)
                        {
                            H[i][i - 3] = 0.0;
                        }
                    }

                    // Double QR step involving rows l:n and columns m:n

                    for (int k = m; k <= n - 1; k++)
                    {
                        bool notlast = (k != n - 1);
                        if (k != m)
                        {
                            p = H[k][k - 1];
                            q = H[k + 1][k - 1];
                            r = (notlast ? H[k + 2][k - 1] : 0.0);
                            x = System.Math.Abs(p) + System.Math.Abs(q) + System.Math.Abs(r);
                            if (x != 0.0)
                            {
                                p = p / x;
                                q = q / x;
                                r = r / x;
                            }
                        }
                        if (x == 0.0)
                        {
                            break;
                        }
                        s = System.Math.Sqrt(p * p + q * q + r * r);
                        if (p < 0)
                        {
                            s = -s;
                        }
                        if (s != 0)
                        {
                            if (k != m)
                            {
                                H[k][k - 1] = -s * x;
                            }
                            else if (l != m)
                            {
                                H[k][k - 1] = -H[k][k - 1];
                            }
                            p = p + s;
                            x = p / s;
                            y = q / s;
                            z = r / s;
                            q = q / p;
                            r = r / p;

                            // Row modification

                            for (int j = k; j < nn; j++)
                            {
                                p = H[k][j] + q * H[k + 1][j];
                                if (notlast)
                                {
                                    p = p + r * H[k + 2][j];
                                    H[k + 2][j] = H[k + 2][j] - p * z;
                                }
                                H[k][j] = H[k][j] - p * x;
                                H[k + 1][j] = H[k + 1][j] - p * y;
                            }

                            // Column modification

                            for (int i = 0; i <= System.Math.Min(n, k + 3); i++)
                            {
                                p = x * H[i][k] + y * H[i][k + 1];
                                if (notlast)
                                {
                                    p = p + z * H[i][k + 2];
                                    H[i][k + 2] = H[i][k + 2] - p * r;
                                }
                                H[i][k] = H[i][k] - p;
                                H[i][k + 1] = H[i][k + 1] - p * q;
                            }

                            // Accumulate transformations

                            for (int i = low; i <= high; i++)
                            {
                                p = x * eigenVectors[i][k] + y * eigenVectors[i][k + 1];
                                if (notlast)
                                {
                                    p = p + z * eigenVectors[i][k + 2];
                                    eigenVectors[i][k + 2] = eigenVectors[i][k + 2] - p * r;
                                }
                                eigenVectors[i][k] = eigenVectors[i][k] - p;
                                eigenVectors[i][k + 1] = eigenVectors[i][k + 1] - p * q;
                            }
                        }  // (s != 0)
                    }  // k loop
                }  // check convergence
            }  // while (n >= low)

            // Backsubstitute to find vectors of upper triangular form

            if (norm == 0.0)
            {
                return;
            }

            for (n = nn - 1; n >= 0; n--)
            {
                p = realEigenValues[n];
                q = imagEigenValues[n];

                // Real vector

                if (q == 0)
                {
                    int l = n;
                    H[n][n] = 1.0;
                    for (int i = n - 1; i >= 0; i--)
                    {
                        w = H[i][i] - p;
                        r = 0.0;
                        for (int j = l; j <= n; j++)
                        {
                            r = r + H[i][j] * H[j][n];
                        }
                        if (imagEigenValues[i] < 0.0)
                        {
                            z = w;
                            s = r;
                        }
                        else
                        {
                            l = i;
                            if (imagEigenValues[i] == 0.0)
                            {
                                if (w != 0.0)
                                {
                                    H[i][n] = -r / w;
                                }
                                else
                                {
                                    H[i][n] = -r / (eps * norm);
                                }

                                // Solve real equations

                            }
                            else
                            {
                                x = H[i][i + 1];
                                y = H[i + 1][i];
                                q = (realEigenValues[i] - p) * (realEigenValues[i] - p) + imagEigenValues[i] * imagEigenValues[i];
                                t = (x * s - z * r) / q;
                                H[i][n] = t;
                                if (System.Math.Abs(x) > System.Math.Abs(z))
                                {
                                    H[i + 1][n] = (-r - w * t) / x;
                                }
                                else
                                {
                                    H[i + 1][n] = (-s - y * t) / z;
                                }
                            }

                            // Overflow control

                            t = System.Math.Abs(H[i][n]);
                            if ((eps * t) * t > 1)
                            {
                                for (int j = i; j <= n; j++)
                                {
                                    H[j][n] = H[j][n] / t;
                                }
                            }
                        }
                    }

                    // Complex vector

                }
                else if (q < 0)
                {
                    int l = n - 1;

                    // Last vector component imaginary so matrix is triangular

                    if (System.Math.Abs(H[n][n - 1]) > System.Math.Abs(H[n - 1][n]))
                    {
                        H[n - 1][n - 1] = q / H[n][n - 1];
                        H[n - 1][n] = -(H[n][n] - p) / H[n][n - 1];
                    }
                    else
                    {
                        Complex cr = cdiv(0.0, -H[n - 1][n], H[n - 1][n - 1] - p, q);
                        H[n - 1][n - 1] = cr.Re;
                        H[n - 1][n] = cr.Im;
                    }
                    H[n][n - 1] = 0.0;
                    H[n][n] = 1.0;
                    for (int i = n - 2; i >= 0; i--)
                    {
                        double ra, sa, vr, vi;
                        ra = 0.0;
                        sa = 0.0;
                        for (int j = l; j <= n; j++)
                        {
                            ra = ra + H[i][j] * H[j][n - 1];
                            sa = sa + H[i][j] * H[j][n];
                        }
                        w = H[i][i] - p;

                        if (imagEigenValues[i] < 0.0)
                        {
                            z = w;
                            r = ra;
                            s = sa;
                        }
                        else
                        {
                            l = i;
                            if (imagEigenValues[i] == 0)
                            {
                                Complex cr = cdiv(-ra, -sa, w, q);
                                H[i][n - 1] = cr.Re;
                                H[i][n] = cr.Im;
                            }
                            else
                            {

                                // Solve complex equations

                                x = H[i][i + 1];
                                y = H[i + 1][i];
                                vr = (realEigenValues[i] - p) * (realEigenValues[i] - p) + imagEigenValues[i] * imagEigenValues[i] - q * q;
                                vi = (realEigenValues[i] - p) * 2.0 * q;
                                if (vr == 0.0 & vi == 0.0)
                                {
                                    vr = eps * norm * (System.Math.Abs(w) + System.Math.Abs(q) +
                                    System.Math.Abs(x) + System.Math.Abs(y) + System.Math.Abs(z));
                                }
                                Complex cr = cdiv(x * r - z * ra + q * sa, x * s - z * sa - q * ra, vr, vi);
                                H[i][n - 1] = cr.Re;
                                H[i][n] = cr.Im;
                                if (System.Math.Abs(x) > (System.Math.Abs(z) + System.Math.Abs(q)))
                                {
                                    H[i + 1][n - 1] = (-ra - w * H[i][n - 1] + q * H[i][n]) / x;
                                    H[i + 1][n] = (-sa - w * H[i][n] - q * H[i][n - 1]) / x;
                                }
                                else
                                {
                                    cr = cdiv(-r - y * H[i][n - 1], -s - y * H[i][n], z, q);
                                    H[i + 1][n - 1] = cr.Re;
                                    H[i + 1][n] = cr.Im;
                                }
                            }

                            // Overflow control

                            t = System.Math.Max(System.Math.Abs(H[i][n - 1]), System.Math.Abs(H[i][n]));
                            if ((eps * t) * t > 1)
                            {
                                for (int j = i; j <= n; j++)
                                {
                                    H[j][n - 1] = H[j][n - 1] / t;
                                    H[j][n] = H[j][n] / t;
                                }
                            }
                        }
                    }
                }
            }

            // Vectors of isolated roots

            for (int i = 0; i < nn; i++)
            {
                if (i < low | i > high)
                {
                    for (int j = i; j < nn; j++)
                    {
                        eigenVectors[i][j] = H[i][j];
                    }
                }
            }

            // Back transformation to get eigenvectors of original matrix

            for (int j = nn - 1; j >= low; j--)
            {
                for (int i = low; i <= high; i++)
                {
                    z = 0.0;
                    for (int k = low; k <= System.Math.Min(j, high); k++)
                    {
                        z = z + eigenVectors[i][k] * H[k][j];
                    }
                    eigenVectors[i][j] = z;
                }
            }

        }


        /// <summary>
        /// Temporary function to calculate a complex number scalar division.
        /// This function will be removed once the more complex algorithms gets
        /// properly written in C#, since they were adapted from Algol.
        /// </summary>
        /// <param name="xr">First number real part</param>
        /// <param name="xi">First number imaginary part</param>
        /// <param name="yr">Second number real part</param>
        /// <param name="yi">Second number imaginary part</param>
        /// <returns>The complex result of this division</returns>
        public static Complex cdiv(double xr, double xi, double yr, double yi)
        {

            Complex result = Complex.Zero;
            double r, d;

            if (System.Math.Abs(yr) > System.Math.Abs(yi))
            {
                r = yi / yr;
                d = yr + r * yi;
                result.Re = (xr + r * xi) / d;
                result.Im = (xi - r * xr) / d;
            }
            else
            {
                r = yr / yi;
                d = yi + r * yr;
                result.Re = (r * xr + xi) / d;
                result.Im = (r * xi - xr) / d;
            }

            return result;
        }
    }
}
