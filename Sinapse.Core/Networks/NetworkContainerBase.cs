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

using AForge.Neuro;
using AForge.Mathematics;

using Sinapse.Core.Transformations;

namespace Sinapse.Core.Networks
{

    /// <summary>
    ///   This class encompass a Neural Network inside a Input/Output structure which can
    ///   perform transformations on such data before feeding/reading the network. 
    /// </summary>
    public abstract class NetworkContainerBase
    {

        protected Network m_network;

        private String m_name;
        private String m_description;
        private String m_remarks;
        private DateTime m_creationTime;

        private ITransformationCollection m_inputTransformations;
        private ITransformationCollection m_outputTransformations;

        public event EventHandler NetworkContainerChanged;

        //----------------------------------------

        #region Constructor
        protected NetworkContainerBase()
        {
            m_inputTransformations = new ITransformationCollection();
            m_outputTransformations = new ITransformationCollection();
        }
        #endregion

        //----------------------------------------

        #region Properties
        public ITransformationCollection InputTransformations
        {
            get { return m_inputTransformations; }
        }

        public ITransformationCollection OutputTransformations
        {
            get { return m_outputTransformations; }
        }

        public Network Network
        {
            get { return m_network; }
        }

        /// <summary>Gets or sets the name of this network.</summary>
        public string Name
        {
            get { return this.m_name; }
            set
            {
                this.m_name = value;
                this.OnNetworkContainerChanged();
            }
        }

        /// <summary>Gets or sets this network description.</summary>
        public string Description
        {
            get { return this.m_description; }
            set
            {
                this.m_description = value;
                this.OnNetworkContainerChanged();
            }
        }

        /// <summary>Gets information about network usage, tips and other useful resources.</summary>
        public string Remarks
        {
            get { return this.m_remarks; }
            set { this.m_remarks = value; }
        }

        /// <summary>Gets a string representing the type of the network.</summary>
        public abstract string Type { get;}

        /// <summary>Gets the creation time of this network.</summary>
        public DateTime CreationTime
        {
            get { return this.m_creationTime; }
        }
        #endregion

        //----------------------------------------

        #region Public Methods
        public Matrix Compute(Matrix inputs)
        {
            inputs = this.InputTransformations.Apply(inputs);
            
            Matrix outputs = new Matrix(inputs.Rows, this.Network.OutputsCount);
            for (int i = 0; i < inputs.Rows; i++)
            {
                outputs[i] = Network.Compute(inputs[i]);
            }

            return this.OutputTransformations.Apply(outputs);
        }

        public Vector Compute(Vector inputs)
        {
            inputs = this.InputTransformations.Apply((Matrix)inputs)[0];
            return this.OutputTransformations.Apply((Matrix)Network.Compute(inputs))[0];
        }
        #endregion


        //----------------------------------------

        protected void OnNetworkContainerChanged()
        {
            if (this.NetworkContainerChanged != null)
                this.NetworkContainerChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
