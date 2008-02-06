using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;

using Sinapse.Data;



namespace Sinapse.Dialogs
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
        }
        #endregion

        //---------------------------------------------

        #region Properties

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

            if (rbBipolarSigmoid.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text, m_networkSchema,
                   new BipolarSigmoidFunction((double)numSigmoidAlpha.Value),
                   (int)nHidden1.Value);
            }
            else if (rbSigmoid.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text, m_networkSchema,
                     new SigmoidFunction((double)numSigmoidAlpha.Value),
                     (int)nHidden1.Value);
            }
            else if (rbThreshold.Checked)
            {
                neuralNetwork = new NetworkContainer(tbNetworkName.Text,
                    m_networkSchema,
                     new ThresholdFunction(),
                     (int)nHidden1.Value);
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
                case 0:
                    lbHidden1.Enabled = false;
                    nHidden1.Enabled = false;
                    break;
                case 1:
                    lbHidden2.Enabled = false;
                    nHidden2.Enabled = false;
                    goto case 1;
                case 2:
                    lbHidden3.Enabled = false;
                    nHidden3.Enabled = false;
                    goto case 2;
                case 3:
                    lbHidden4.Enabled = false;
                    nHidden4.Enabled = false;
                    goto case 3;
                default:
                    break;
            }
        }
        #endregion
             
    }
}