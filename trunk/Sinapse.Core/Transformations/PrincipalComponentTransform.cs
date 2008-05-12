using System;
using System.Collections.Generic;
using System.Text;

using AForge.Math;
using AForge.Statistics.SampleAnalysis;


namespace Sinapse.Core
{
    public class PrincipalComponentTransform : Sinapse.Core.Transformations.ITransformation
    {
        
        private PrincipalComponentAnalysis pca;

        
        // -------------------------------------------------


        #region Constructor
        public PrincipalComponentTransform()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        // -------------------------------------------------


        #region Properties
        public int Inputs
        {
            get { return 0; }
        }

        public int Outputs
        {
            get { return 0; }
        }
        #endregion


        // -------------------------------------------------


        #region Public Members
        public void Apply(Matrix m)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion


    }
}
