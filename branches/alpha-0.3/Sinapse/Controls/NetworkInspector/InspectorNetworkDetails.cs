using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;

using Sinapse.Data.Network;
using Sinapse.Controls.NetworkInspector.Base;


namespace Sinapse.Controls.NetworkInspector
{

    internal sealed partial class InspectorNetworkDetails : InspectorPanelBase
    {

        private NetworkContainer m_networkContainer;


        //----------------------------------------


        #region Constructor
        public InspectorNetworkDetails()
        {
            InitializeComponent();

            this.Visible = false;
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        public void ShowDetails(NetworkContainer network)
        {
            this.Show();
            this.BringToFront();

            this.m_networkContainer = network;

            this.lbType.Text = "Type: " + network.ActivationNetwork.GetType().Name;
            this.lbFunction.Text = "Function: " + m_networkContainer.Function;
            this.lbInputs.Text = "Inputs: " + network.ActivationNetwork.InputsCount;
            this.lbOutputs.Text = "Outputs: " + network.ActivationNetwork[network.ActivationNetwork.LayersCount - 1].NeuronsCount;
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void btnRandomize_Click(object sender, EventArgs e)
        {
            if (m_networkContainer != null && m_networkContainer.ActivationNetwork != null)
            {
                this.m_networkContainer.ActivationNetwork.Randomize();
                this.OnNetworkChanged();
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
