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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;
//using Sinapse.Data.Network;


namespace Sinapse.Forms.Dialogs
{
    internal sealed partial class CreateNetworkDialog : Form
    {

     //   private NetworkSchema m_networkSchema;

        //---------------------------------------------


        #region Constructor
        public CreateNetworkDialog(NetworkSchema schema)
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


        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.setOptimal();
        }
        #endregion


        //---------------------------------------------


        #region Control Events
        private void rbSigmoid_CheckedChanged(object sender, EventArgs e)
        {
    //        numRangeHigh.Minimum = 0;
    //        numRangeHigh.Maximum = 1;

   //         numRangeLow.Minimum = 0;
   //         numRangeLow.Maximum = 1;
        }

        private void rbBipolarSigmoid_CheckedChanged(object sender, EventArgs e)
        {
   //         numRangeHigh.Minimum = -1;
   //         numRangeHigh.Maximum = 1;

   //         numRangeLow.Minimum = -1;
   //         numRangeLow.Maximum = 1;
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
            if (this.validateInput())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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

            IActivationFunction activationFunction = null;

            if (this.rbBipolarSigmoid.Checked)
            {
                activationFunction = new BipolarSigmoidFunction((double)numSigmoidAlpha.Value);
            }
            else if (this.rbSigmoid.Checked)
            {
                activationFunction = new SigmoidFunction((double)numSigmoidAlpha.Value);
            }
            else if (this.rbThreshold.Checked)
            {
                activationFunction = new ThresholdFunction();
            }

            neuralNetwork = new NetworkContainer(
                    tbNetworkName.Text,
                    m_networkSchema,
                    activationFunction,
                    hiddenLayers);


 //         neuralNetwork.Schema.DataRanges.ActivationFunctionRange = new AForge.DoubleRange((double)numRangeLow.Value, (double)numRangeHigh.Value);


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
  //          this.numRangeHigh.Value = 0.85M;
  //          this.numRangeLow.Value = -0.85M;
        }

        private void cbHiddenLayerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbHidden1.Enabled = false;
            this.nHidden1.Enabled = false;
            this.lbHidden2.Enabled = false;
            this.nHidden2.Enabled = false;
            this.lbHidden2.Enabled = false;
            this.nHidden2.Enabled = false;
            this.lbHidden3.Enabled = false;
            this.nHidden3.Enabled = false;
            this.lbHidden4.Enabled = false;
            this.nHidden4.Enabled = false;

            switch (cbHiddenLayerNumber.SelectedIndex)
            {
                case 1:
                    this.lbHidden1.Enabled = true;
                    this.nHidden1.Enabled = true;
                    break;
                case 2:
                    this.lbHidden2.Enabled = true;
                    this.nHidden2.Enabled = true;
                    goto case 1;
                case 3:
                    this.lbHidden3.Enabled = true;
                    this.nHidden3.Enabled = true;
                    goto case 2;
                case 4:
                    this.lbHidden4.Enabled = true;
                    this.nHidden4.Enabled = true;
                    goto case 3;
                default:
                    break;
            }
        }

        private bool validateInput()
        {
  /*          if (numRangeLow.Value >= numRangeHigh.Value)
            {
  //              errorProvider.SetError(numRangeHigh, "The maximum output value should be greather than the minimum choosen value");
                return false;
            }
            */
            return true;
        }

        #endregion

            
    }
}