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
using System.Data;

using AForge.Mathematics;

using Sinapse.Core.Transformations;
using Sinapse.Core.Networks;


namespace Sinapse.Core.Sources
{

    public enum NetworkDataSet { Training, Testing, Validation };


    /// <summary>
    ///   This class encompass a Neural Network DataSource, or in other words, a
    ///   source of information that can be used to train and feed Neural Networks.
    ///   A common example of data sources are tables of sample data or a collection
    ///   of images.
    /// </summary>
    [Serializable]
    public abstract class NetworkDataSourceBase
    {

        private String m_title;
        private String m_description;
        private String m_remarks;

        //----------------------------------------

        #region Constructor
        protected NetworkDataSourceBase(String title)
        {
            this.m_title = title;
            this.m_description = String.Empty;
            this.m_remarks = String.Empty;
        }
        #endregion

        //----------------------------------------

        #region Abstract Methods
        public abstract Matrix CreateVectors(NetworkDataSet set);
        public abstract DataView CreateDataView(NetworkDataSet set);

        public abstract int InputsCount { get; }
        public abstract int OutputsCount { get; }
        #endregion

        //----------------------------------------

        #region Properties
        public String Name
        {
            get { return this.m_title; }
            set { this.m_title = value; }
        }

        public String Description
        {
            get { return this.m_description; }
            set { this.m_description = value; }
        }

        public String Remarks
        {
            get { return this.m_remarks; }
            set { this.m_remarks = value; }
        }
        #endregion

        //----------------------------------------

        #region Public Methods
        public bool IsCompatible(NetworkContainerBase network)
        {
            return (network.Network.InputsCount == this.InputsCount && network.Network.OutputsCount == this.OutputsCount);
        }
        #endregion

    }
}
