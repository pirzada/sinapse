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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;

using Sinapse.Controls.NetworkInspector.Base;


namespace Sinapse.Controls.NetworkInspector
{
    internal sealed partial class InspectorLayerDetails : InspectorPanelBase
    {

        private Layer m_layer;


        //----------------------------------------


        #region Constructor
        public InspectorLayerDetails()
        {
            InitializeComponent();

            this.Visible = false;
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        public void ShowDetails(Layer layer)
        {
            this.Show();
            this.BringToFront();

            this.m_layer = layer;

            lbType.Text = "Type: " + layer.GetType().Name;
            lbInputs.Text = "Inputs: " + layer.InputsCount;
            lbOutput.Text = "Outputs: " + layer.Output.Length;
            lbNeuron.Text = "Neurons: " + layer.NeuronsCount;
            
        }
        #endregion


        //----------------------------------------


        private void btnRandomize_Click(object sender, EventArgs e)
        {
            if (m_layer != null)
            {
                m_layer.Randomize();
                this.OnNetworkChanged();
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {

        }
    }
}
