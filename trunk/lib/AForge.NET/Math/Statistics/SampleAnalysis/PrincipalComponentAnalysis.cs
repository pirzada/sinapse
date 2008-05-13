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
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

using AForge.Math;
using AForge.Math.LinearAlgebra.Decompositions;
using AForge.Statistics;


namespace AForge.Statistics.SampleAnalysis
{

    public class PrincipalComponent
    {

        private int m_index;
        private Vector m_value;
        private PrincipalComponentAnalysis m_analysis;


        #region Constructor
        internal PrincipalComponent(PrincipalComponentAnalysis analysis, int index)
        {
            this.m_index = index;
            this.m_analysis = analysis;
        }
        #endregion

        #region Properties
        public int Index
        {
            get { return this.m_index; }
        }

        public PrincipalComponentAnalysis Analysis
        {
            get { return this.m_analysis; }
        }

        public double Proportion
        {
            get { return this.m_analysis.Proportions[m_index]; }
        }

        public double CumulativeProportion
        {
            get { return this.m_analysis.CumulativeProportions[m_index]; }
        }

        public double EigenValue
        {
            get { return this.m_analysis.EigenValues[m_index]; }
        }

        public Vector Value
        {
            get { return (Vector)this.m_analysis.ComponentMatrix.GetColumn(m_index); }
        }
        #endregion

    }

    public class PrincipalComponentCollection : ReadOnlyCollection<PrincipalComponent>
    {
        internal PrincipalComponentCollection(PrincipalComponent[] components)
            : base(components)
        {
        }
    }


    /// <summary>
    ///   Principal component analysis (PCA) is a technique used to reduce
    ///   multidimensional data sets to lower dimensions for analysis.
    /// </summary>
    /// <remarks>
    ///   Principal Components Analysis or the Karhunen-Loeve expansion is a
    ///   classical method for dimensionality reduction or exploratory data
    ///   analysis.
    ///  
    ///   Mathematically, PCA is a process that decomposes the covariance matrix of a matrix
    ///   into two parts: eigenvalues and column eigenvectors, whereas Singular Value Decomposition
    ///   (SVD) decomposes a matrix per se into three parts: singular values, column eigenvectors,
    ///   and row eigenvectors. The relationships between PCA and SVD lie in that the eigenvalues 
    ///   are the square of the singular values and the column vectors are the same for both.   
    ///</remarks>
    public sealed class PrincipalComponentAnalysis
    {

        private Matrix m_sourceMatrix;
        private Matrix m_resultMatrix;
                                                              
        private Vector m_singularValues;
        private Vector m_eigenValues;
        private Vector m_proportions;
        private Matrix m_components;
        private Vector m_cumulativeProportions;
        private PrincipalComponentCollection m_componentCollection;

        private bool m_center;
        private bool m_standardize;
        private bool m_computed;

        //---------------------------------------------


        #region Constructor
        /// <summary>Constructs the Principal Component Analysis.</summary>
        /// <param name="matrix">The source matrix.</param>
        /// <param name="model">The sample model used by the given matrix.</param>
        public PrincipalComponentAnalysis(Matrix matrix, SampleMatrix.DataModel model)
            : this(new SampleMatrix(matrix, model))
        {
        }

        /// <summary>Constructs the Principal Component Analysis.</summary>
        /// <param name="data"></param>
        public PrincipalComponentAnalysis(SampleMatrix data)
        {
            this.m_sourceMatrix = data;
            this.m_standardize = true;
            this.m_center = true;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        /// Returns the original supplied data to be analyzed.
        /// </summary>
        public Matrix SourceMatrix
        {
            get { return this.m_sourceMatrix; }
        }

        /// <summary>Gets the matrix whose columns contain the principal components.</summary>
        public Matrix ComponentMatrix
        {
            get { return this.m_components; }
        }

        /// <summary>Gets the Principal Components in a object-oriented fashion.</summary>
        public PrincipalComponentCollection Components
        {
            get { return m_componentCollection; }
        }

        public Vector Proportions
        {
            get { return m_proportions; }
        }

        public Vector CumulativeProportions
        {
            get { return m_cumulativeProportions; }
        }

        public Vector SingularValues
        {
            get { return m_singularValues; }
        }

        public Vector EigenValues
        {
            get { return m_eigenValues; }
        }

        public bool Center
        {
            get { return this.m_center; }
            set { this.m_center = value; }
        }

        public bool Standardize
        {
            get { return this.m_standardize; }
            set { this.m_standardize = value; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods

        /// <summary>Computes the Principal Component Analysis algorithm.</summary>
        public void Compute()
        {

            Matrix matrix = this.m_sourceMatrix.Clone();
            
            if (this.m_center)
            {
                SampleMatrix.Center(matrix);
            }
            if (this.m_standardize)
            {
                SampleMatrix.Standardize(matrix);
            }


            // Perform the Singular Value Decomposition (SVD) of the standardized matrix
            SingularValueDecomposition singularDecomposition = new SingularValueDecomposition(matrix);
            this.m_singularValues = new Vector(singularDecomposition.Diagonal);

            // The eigen values are the square of the singular values
            this.m_eigenValues = Vector.Pow(this.m_singularValues, 2);

            /* The principal components of 'sourceMatrix' are the eigenvectors of Cov(sourceMatrix). If we
             * calculate the SVD of 'matrix' (which is sourceMatrix standardized), the columns of matrix V
             * (right side of SVD) are the principal components of sourceMatrix.  */
            
            // The right singular vectors contains the principal components of the data matrix
            this.m_components = singularDecomposition.RightSingularVectors;

            // Calculate proportions and cumulative proportions
            this.m_proportions = Vector.Pow(this.m_singularValues, 2);
            this.m_proportions = this.m_proportions * (1.0 / this.m_proportions.Sum);

            this.m_cumulativeProportions = new Vector(this.m_sourceMatrix.Columns);
            this.m_cumulativeProportions[0] = this.m_proportions[0];
            for (int i = 1; i < this.m_cumulativeProportions.Length; i++)
            {
                this.m_cumulativeProportions[i] = this.m_cumulativeProportions[i - 1] + this.m_proportions[i];
            }

            // Calculate the resultant orthogonal data matrix (considering all components)
            this.m_resultMatrix = this.m_sourceMatrix * this.m_components;

        }

        /// <summary>Applies the found orthogonal transformation to a given matrix</summary>
        /// <param name="matrix">The matrix to be transformed.</param>
        /// <param name="components">The number of components to consider.</param>
        public Matrix Apply(Matrix matrix, int components)
        {
            return matrix * this.m_components;
        }

        public Matrix Apply(Matrix matrix, float threshold)
        {
            throw new NotImplementedException();
        }

        #endregion


        //---------------------------------------------

    }
}
