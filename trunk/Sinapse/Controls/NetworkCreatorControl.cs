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
        private NeuralNetwork m_neuralNetwork;

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

        internal NeuralNetwork NeuralNetwork
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


        private NeuralNetwork createNetwork()
        {
            NeuralNetwork neuralNetwork;

            if (rbBipolarSigmoid.Checked)
            {
                neuralNetwork = new NeuralNetwork(tbNetworkName.Text,
                    m_networkSchema,
                   new BipolarSigmoidFunction((double)numSigmoidAlpha.Value),
                   (int)numHiddenLayer.Value);
            }
            else if (rbSigmoid.Checked)
            {
                neuralNetwork = new NeuralNetwork(tbNetworkName.Text,
                    m_networkSchema,
                     new SigmoidFunction((double)numSigmoidAlpha.Value),
                     (int)numHiddenLayer.Value);
            }
            else if (rbThreshold.Checked)
            {
                neuralNetwork = new NeuralNetwork(tbNetworkName.Text,
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
