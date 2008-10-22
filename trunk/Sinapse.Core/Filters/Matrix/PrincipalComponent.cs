/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

using AForge.Mathematics;
using AForge.Statistics.DataAnalysis;


namespace Sinapse.Core.Filters
{

    public class PrincipalComponent : IFilter
    {
        
        private PrincipalComponentAnalysis pca;
        private int m_components;
        

        // -------------------------------------------------


        #region Constructor
        public PrincipalComponent()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        // -------------------------------------------------


        #region Properties
        public int Inputs
        {
            get { return pca.EigenValues.Length; }
        }

        public int Outputs
        {
            get { return m_components; }
        }
        #endregion


        // -------------------------------------------------


        #region Public Members
        public Matrix Apply(Matrix source)
        {
            return pca.Transform(source);
        }
        #endregion


    }
}
