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

        private NeuralNetwork m_neuralNetwork;

        //---------------------------------------------

        #region Constructor
        internal NetworkQueryForm(NeuralNetwork neuralNetwork)
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

    }
}