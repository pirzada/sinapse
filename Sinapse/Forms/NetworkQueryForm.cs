/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2007 Cesar Roberto de Souza <cesarsouza@gmail.com> *
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;

using Sinapse.Data;

namespace Sinapse.Forms
{
    internal sealed partial class NetworkQueryForm : Form
    {

        private NetworkContainer m_neuralNetwork;

        //---------------------------------------------

        #region Constructor
        internal NetworkQueryForm(NetworkContainer neuralNetwork)
        {
            InitializeComponent();

            this.m_neuralNetwork = neuralNetwork;
            this.networkDisplayControl.NeuralNetwork = neuralNetwork;
            this.networkDataQueryControl.NetworkData = new NetworkData(neuralNetwork.Schema);
            this.networkRangesControl.NetworkData = networkDataQueryControl.NetworkData;

        }
        #endregion

        //---------------------------------------------

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.networkDataQueryControl.Compute(this.m_neuralNetwork);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void networkDataQueryControl_Load(object sender, EventArgs e)
        {

        }

    }
}