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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using AForge.Neuro;
using AForge;

namespace Sinapse.Controls
{
    internal sealed partial class NetworkCreatorControl : UserControl
    {

        private NetworkSchema m_networkSchema;
        private NetworkContainer m_neuralNetwork;

        public EventHandler OnNetworkCreated;

        //---------------------------------------------

        #region Constructor
        public NetworkCreatorControl()
        {
            InitializeComponent();
        }
        #endregion

        //---------------------------------------------

        #region Properties
        internal NetworkSchema NetworkSchema
        {
            get { return m_networkSchema; }
            set
            {
                this.m_networkSchema = value;

                if (m_networkSchema != null)
                {
                    this.Enabled = true;
                    this.setOptimal();
                }
                else
                {
                    this.Enabled = false;
                }
            }
        }

        internal NetworkContainer NeuralNetwork
        {
            get { return this.m_neuralNetwork; }
        }
        #endregion

        //---------------------------------------------

        #region Buttons
        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.m_neuralNetwork = this.createNetwork();
            if (OnNetworkCreated != null)
                this.OnNetworkCreated.Invoke(this, EventArgs.Empty);
        }        

        private void btnOptimal_Click(object sender, EventArgs e)
        {
            this.setOptimal();
        }
        #endregion

        //---------------------------------------------

        #region Private Methods
        private void setOptimal()
        {
            this.rbBipolarSigmoid.Checked = true;
            this.numHiddenLayer.Value = Math.Ceiling((decimal)(m_networkSchema.InputColumns.Length + m_networkSchema.OutputColumns.Length) / 2);
            this.numSigmoidAlpha.Value = 0.5M;
        }


        private NetworkContainer createNetwork()
        {
            NetworkContainer neuralNetwork;

            if (rbBipolarSigmoid.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text,
                    m_networkSchema,
                   new BipolarSigmoidFunction((double)numSigmoidAlpha.Value),
                   (int)numHiddenLayer.Value);
            }
            else if (rbSigmoid.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text,
                    m_networkSchema,
                     new SigmoidFunction((double)numSigmoidAlpha.Value),
                     (int)numHiddenLayer.Value);
            }
            else if (rbThreshold.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text,
                    m_networkSchema,
                     new ThresholdFunction(),
                     (int)numHiddenLayer.Value);
            }
            else
            {
                rbBipolarSigmoid.Checked = true;
                neuralNetwork = this.createNetwork();
            }

            return neuralNetwork;
        }
        #endregion

    }
}
