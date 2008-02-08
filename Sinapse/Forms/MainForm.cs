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

using Sinapse.Data;
using Sinapse.Data.Structures;
using Sinapse.Dialogs;

using AForge;
using AForge.Neuro;
using AForge.Controls;
using AForge.Neuro.Learning;

namespace Sinapse.Forms
{

    internal sealed partial class MainForm : Form
    {

        private NetworkContainer m_networkContainer;


        //---------------------------------------------


        #region Constructor & Destructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal NetworkContainer CurrentNetworkContainer
        {
            get
            {
                return m_networkContainer;
            }
            set
            {
                this.m_networkContainer = value;
                this.sideTrainerControl.NeuralNetwork = value;
                this.sideDisplayControl.NeuralNetwork = value;

                if (value != null)
                {
              //      this.MenuDatabase.Enabled = true;

              //      this.MenuWorkplaceOpen.Enabled = true;
              //      this.MenuFileSaveAs.Enabled = false;

              //      this.lbNeuronCount.Text = m_networkContainer.GetLayoutString();

                    this.m_networkContainer.OnSavePathChanged += neuralNetwork_SavePathChanged;
                    this.neuralNetwork_SavePathChanged(null, EventArgs.Empty);
                }
                else
                {
                    //No active network
                    this.lbNeuronCount.Text = "0";
              //      this.MenuDatabase.Enabled = false;
              //      this.MenuWorkplaceOpen.Enabled = false;
              //      this.MenuFileSaveAs.Enabled = false;
                }
            }
        }
        #endregion


        //---------------------------------------------


        #region MainForm Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Wire up controls and events
            this.tabControlNetworkData.OnDataChanged += networkDataControl_DataChanged;
            this.tabControlNetworkData.OnSchemaChanged += networkDataControl_SchemaChanged;
            this.tabControlNetworkData.OnSelectionChanged += networkDataControl_SelectionChanged;

            this.sideTrainerControl.OnStatusChanged += sideTrainerControl_StatusChanged;
            this.sideTrainerControl.OnDataNeeded += sideTrainerControl_DataNeeded;
            this.sideTrainerControl.OnTrainingComplete += sideTrainerControl_TrainingComplete;

            this.CurrentNetworkContainer = null;
            HistoryLogger.Write("Waiting data");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HistoryLogger.Write("Exiting...");

            if (this.sideTrainerControl.IsTraining)
            {
                this.sideTrainerControl.Stop();
            }
        }
        #endregion


        //---------------------------------------------


        #region Network Data Control Events
        private void networkDataControl_SchemaChanged(object sender, EventArgs e)
        {
            this.lbInputCount.Text = this.m_networkContainer.Schema.InputColumns.Length.ToString();
            this.lbOutputCount.Text = this.m_networkContainer.Schema.OutputColumns.Length.ToString();

            this.sideRangesControl.NetworkData = this.tabControlNetworkData.NetworkData;
            this.sideTrainerControl.NeuralNetwork = null;
        }


        private void networkDataControl_SelectionChanged(object sender, EventArgs e)
        {
            this.statusBarControl.UpdateSelectedItems(tabControlNetworkData.SelectedItemCount, tabControlNetworkData.ItemCount);
        }
        #endregion


        //---------------------------------------------


        #region Network Trainer Control Events
        private void sideTrainerControl_DataNeeded(object sender, EventArgs e)
        {
            NetworkVectors trainingVectors = this.tabControlNetworkData.NetworkData.CreateVectors(NetworkSet.Training);
            NetworkVectors validationVectors = this.tabControlNetworkData.NetworkData.CreateVectors(NetworkSet.Validation);

            this.sideTrainerControl.Start(trainingVectors, validationVectors);
        }

        private void sideTrainerControl_StatusChanged(object sender, EventArgs e)
        {
            this.statusBarControl.UpdateNetworkState(this.sideTrainerControl.NetworkState);
        }

        private void sideTrainerControl_TrainingComplete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Training completed. Would you like to start querying the Network?",
                "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.eventNetworkQuery(this, EventArgs.Empty);
            }
        }
        #endregion


        //---------------------------------------------


        #region Neural Network Events
        private void neuralNetwork_SavePathChanged(object sender, EventArgs e)
        {
            this.openFileDialog.FileName = this.m_networkContainer.LastSavePath;
            this.saveFileDialog.FileName = this.m_networkContainer.LastSavePath;

            this.MenuNetworkSaveAs.Enabled = (this.m_networkContainer.LastSavePath.Length > 0);
        }
        #endregion


        //---------------------------------------------


        #region Buttons & Menus

        private void eventShowWizard(object sender, EventArgs e)
        {
            ImportWizard importWizard = new ImportWizard();
            if (importWizard.ShowDialog(this) == DialogResult.OK)
            {
                this.tabControlNetworkData.NetworkData = importWizard.GetNetworkData();
                if (this.CurrentNetworkContainer == null)
                {
                    if (MessageBox.Show("Data imported successfuly. Would you like to create" +
                        "the neural network now?", "Import Complete", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        eventNetworkNew(this, e);
                    }
                }
            }
        }

        private void eventNetworkNew(object sender, EventArgs e)
        {
            if (this.CurrentNetworkContainer != null &&
                MessageBox.Show("Would you like to overwrite your current network?" +
                                "\nAny unsaved training sessions will be lost. Are you sure?",
                                "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                NetworkCreationDialog creationDlg = new NetworkCreationDialog(m_networkContainer.Schema);
                if (creationDlg.ShowDialog() == DialogResult.OK)
                {
                    this.CurrentNetworkContainer = creationDlg.CreateNetworkContainer();
                }
            }
        }


        private void eventNetworkSave(object sender, EventArgs e)
        {
            if (this.m_networkContainer.LastSavePath.Length > 0)
                this.networkSave(this.CurrentNetworkContainer.LastSavePath);

            else this.saveFileDialog.ShowDialog(this);
        }


        private void eventNetworkSaveAs(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog(this);
        }


        private void eventNetworkOpen(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog(this);
        }


        private void eventNetworkQuery(object sender, EventArgs e)
        {
            HistoryLogger.Write("Querying network");
            new NetworkInquirer(this.m_networkContainer).ShowDialog(this);
            HistoryLogger.Write("Ready");
        }


        private void eventShowHelp(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        #endregion


        //---------------------------------------------


        #region Open & Save Network
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkOpen(openFileDialog.FileName);
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkSave(saveFileDialog.FileName);
        }

        private void networkSave(string path)
        {
            try
            {
                NetworkContainer.Serialize(this.CurrentNetworkContainer, path);
            }
            catch
            {
                MessageBox.Show("Error saving network");
            }
        }

        private void networkOpen(string path)
        {
            NetworkContainer neuralNetwork = null;

            try
            {
                neuralNetwork = NetworkContainer.Deserialize(path);
            }
            catch
            {
                MessageBox.Show("Error opening network");
            }
            finally
            {
                if (neuralNetwork != null)
                {
                    this.CurrentNetworkContainer = neuralNetwork;
                }
            }
        }
        #endregion


        //---------------------------------------------


    }
}