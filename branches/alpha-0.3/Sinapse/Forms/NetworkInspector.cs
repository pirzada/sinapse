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
using System.IO;
using System.Windows.Forms;

using AForge.Neuro;

using Sinapse.Data.Network;


namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class NetworkInspectorDialog : Form
    {

        private NetworkContainer m_networkContainer;


        //----------------------------------------


        #region Constructor
        public NetworkInspectorDialog(NetworkContainer networkContainer)
        {
            this.m_networkContainer = networkContainer;

            InitializeComponent();
        }
        #endregion


        //----------------------------------------


        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.populateTreeView(m_networkContainer);
        }
        #endregion

        
        //----------------------------------------


        #region Form Buttons
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.FilterIndex = 1;
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.ShowDialog(this);
        }

        private void btnTextExport_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.FilterIndex = 2;
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.ShowDialog(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.populateTreeView(m_networkContainer);
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog.DefaultExt == "txt")
                this.m_networkContainer.TxtExport(saveFileDialog.FileName);
            else this.m_networkContainer.XmlExport(saveFileDialog.FileName);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.m_networkContainer.XmlImport(openFileDialog.FileName);
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void populateTreeView(NetworkContainer networkContainer)
        {

            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            TreeNode networkNode;
            TreeNode[] layerNodes;
            TreeNode[] neuronNodes;
            TreeNode[] weightNodes;

            layerNodes = new TreeNode[networkContainer.ActivationNetwork.LayersCount];
            for (int i = 0; i < networkContainer.ActivationNetwork.LayersCount; ++i)
            {
                neuronNodes = new TreeNode[networkContainer.ActivationNetwork[i].NeuronsCount];
                for (int j = 0; j < networkContainer.ActivationNetwork[i].NeuronsCount; ++j)
                {
                    weightNodes = new TreeNode[networkContainer.ActivationNetwork[i][j].InputsCount];
                    for (int k = 0; k < networkContainer.ActivationNetwork[i][j].InputsCount; ++k)
                    {
                        weightNodes[k] = new TreeNode(String.Format("[{0}]: {1}", k + 1,
                            networkContainer.ActivationNetwork[i][j][k]), 3, 3);
                        weightNodes[k].Tag = networkContainer.ActivationNetwork[i][j];
                        weightNodes[k].ForeColor = Color.Gray;
                    }
                    neuronNodes[j] = new TreeNode(String.Format("Neuron {0}", j + 1), 2, 2,
                        weightNodes);
                    neuronNodes[j].Tag = networkContainer.ActivationNetwork[i][j];
                }
                layerNodes[i] = new TreeNode(String.Format("Layer {0}", i + 1), 1, 1,
                    neuronNodes);
                layerNodes[i].Tag = networkContainer.ActivationNetwork[i];
            }

            networkNode = new TreeNode(networkContainer.Name, 0, 0, layerNodes);
            networkNode.Tag = networkContainer;

            treeView.Nodes.Add(networkNode);
            treeView.SelectedNode = networkNode;

            treeView.EndUpdate();
        }
        #endregion


        //----------------------------------------


        #region Controls Events
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag is Neuron)
                    this.inspectorNeuronDetails.ShowDetails(e.Node.Tag as Neuron);

                if (e.Node.Tag is Layer)
                    this.inspectorLayerDetails.ShowDetails(e.Node.Tag as Layer);

                if (e.Node.Tag is NetworkContainer)
                    this.inspectorNetworkDetails.ShowDetails(e.Node.Tag as NetworkContainer);
            }
        }

        private void inspectorDetails_NetworkChanged(object sender, EventArgs e)
        {
            this.populateTreeView(m_networkContainer);
        }
        #endregion


        //----------------------------------------


    }
}