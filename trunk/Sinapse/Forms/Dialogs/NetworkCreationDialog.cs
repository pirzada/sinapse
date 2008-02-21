/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;
using Sinapse.Data.Network;


namespace Sinapse.Forms.Dialogs
{
    internal sealed partial class NetworkCreationDialog : Form
    {

        private NetworkSchema m_networkSchema;

        //---------------------------------------------


        #region Constructor
        public NetworkCreationDialog(NetworkSchema schema)
        {
            InitializeComponent();

            this.m_networkSchema = schema;
            this.cbHiddenLayerNumber.DataSource = new int[] { 0, 1, 2, 3, 4 };
        }
        #endregion


        //---------------------------------------------


        #region Properties

        #endregion


        //---------------------------------------------


        #region Control Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.setOptimal();
        }
        #endregion


        //---------------------------------------------


        #region Buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void btnOptimal_Click(object sender, EventArgs e)
        {
            this.setOptimal();
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public NetworkContainer CreateNetworkContainer()
        {
            NetworkContainer neuralNetwork = null;

            int[] hiddenLayers = new int[cbHiddenLayerNumber.SelectedIndex];

            switch (hiddenLayers.Length)
            {
                case 0:
                    break;
                case 1:
                    hiddenLayers[0] = (int)this.nHidden1.Value;
                    break;
                case 2:
                    hiddenLayers[1] = (int)this.nHidden2.Value;
                    goto case 1;
                case 3:
                    hiddenLayers[2] = (int)this.nHidden3.Value;
                    goto case 2;
                case 4:
                    hiddenLayers[3] = (int)this.nHidden4.Value;
                    goto case 3;
                default:
                    break;
            }


            if (rbBipolarSigmoid.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text, m_networkSchema,
                   new BipolarSigmoidFunction((double)numSigmoidAlpha.Value),
                   hiddenLayers);
            }
            else if (rbSigmoid.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text, m_networkSchema,
                     new SigmoidFunction((double)numSigmoidAlpha.Value),
                     hiddenLayers);
            }
            else if (rbThreshold.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text,
                    m_networkSchema,
                     new ThresholdFunction(),
                     hiddenLayers);
            }

            return neuralNetwork;
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void setOptimal()
        {
            this.rbBipolarSigmoid.Checked = true;
            this.cbHiddenLayerNumber.SelectedIndex = 1;
            this.nHidden1.Value = Math.Ceiling((decimal)(m_networkSchema.InputColumns.Length + m_networkSchema.OutputColumns.Length) / 2);
            this.numSigmoidAlpha.Value = 0.5M;
        }

        private void cbHiddenLayerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbHidden1.Enabled = false;
            nHidden1.Enabled = false;
            lbHidden2.Enabled = false;
            nHidden2.Enabled = false;
            lbHidden2.Enabled = false;
            nHidden2.Enabled = false;
            lbHidden3.Enabled = false;
            nHidden3.Enabled = false;
            lbHidden4.Enabled = false;
            nHidden4.Enabled = false;

            switch (cbHiddenLayerNumber.SelectedIndex)
            {
                case 1:
                    lbHidden1.Enabled = true;
                    nHidden1.Enabled = true;
                    break;
                case 2:
                    lbHidden2.Enabled = true;
                    nHidden2.Enabled = true;
                    goto case 1;
                case 3:
                    lbHidden3.Enabled = true;
                    nHidden3.Enabled = true;
                    goto case 2;
                case 4:
                    lbHidden4.Enabled = true;
                    nHidden4.Enabled = true;
                    goto case 3;
                default:
                    break;
            }
        }
        #endregion

            
    }
}