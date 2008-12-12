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
        private Matrix input;
        private Matrix output;
        private int components;
        

        // -------------------------------------------------


        #region Constructor
        public PrincipalComponent()
        {
            throw new System.NotImplementedException();
        }
        #endregion


        // -------------------------------------------------



        #region IFilter Members

        public object Input
        {
            get { return input; }
            set { this.input = (Matrix)value; }
        }

        public object Output
        {
            get { return output; }
            set { throw new InvalidOperationException(); }
        }

        public void Apply()
        {
            output = pca.Transform(input);
        }

        public System.Windows.Forms.Control Control
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return "Principal Component Filter"; }
        }

        public string Description
        {
            get
            {
                return "Projects the given input into an orthogonal space based on the " +
                         "feature vectors of a Principal Component Analysis.";
            }
        }

        #endregion

    }
}
