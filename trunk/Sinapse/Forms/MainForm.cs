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
            get {
                return m_networkContainer;
            }
            set
            {
                this.m_networkContainer = value;
                this.networkTrainerControl.NeuralNetwork = value;
                this.networkDisplayControl.NeuralNetwork = value;

                if (value != null)
                {
                    this.MenuNetwork.Enabled = true;

                    this.MenuFileSave.Enabled = true;
                    this.MenuFileSaveAs.Enabled = false;
                    
                    this.lbNeuronCount.Text = m_networkContainer.GetLayoutString();

                    this.m_networkContainer.OnSavePathChanged += neuralNetwork_SavePathChanged;
                    this.neuralNetwork_SavePathChanged(null, EventArgs.Empty);
                }
                else
                {
                    //No active network
                    this.lbNeuronCount.Text = "0";
                    this.MenuNetwork.Enabled = false;
                    this.MenuFileSave.Enabled = false;
                    this.MenuFileSaveAs.Enabled = false;
                }
            }
        }
        #endregion

        //---------------------------------------------

        #region MainForm Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Wire up controls and events
         /*   this.networkDataControl.OnDataChanged += networkDataControl_DataChanged;
            this.networkDataControl.OnSchemaChanged += networkDataControl_SchemaChanged;
            this.networkDataControl.OnSelectionChanged += networkDataControl_SelectionChanged;
         */   this.networkTrainerControl.OnStatusChanged += networkTrainerControl_StatusChanged;
            this.networkTrainerControl.OnDataNeeded += networkTrainerControl_DataNeeded;
            this.networkTrainerControl.OnTrainingComplete += networkTrainerControl_TrainingComplete;

            this.CurrentNetworkContainer = null;
            this.UpdateStatus("Waiting data");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.UpdateStatus("Exiting...");

            if (this.networkTrainerControl.IsTraining)
            {
                this.networkTrainerControl.Stop();
            }
        }
        #endregion

        //---------------------------------------------

        #region Network Data Control Events
        private void networkDataControl_SchemaChanged(object sender, EventArgs e)
        {
            this.lbInputCount.Text = this.m_networkContainer.Schema.InputColumns.Length.ToString();
            this.lbOutputCount.Text = this.m_networkContainer.Schema.OutputColumns.Length.ToString();

            //this.networkRangesControl.NetworkData = this.networkDataControl.NetworkData;
            //this.networkTrainerControl.NeuralNetwork = null;
        }

        private void networkDataControl_DataChanged(object sender, EventArgs e)
        {
//            this.lbItems.Text = String.Format("{0}/{1}", this.networkDataControl.ItemCount, this.networkDataControl.SelectedItemCount);
        }

        private void networkDataControl_SelectionChanged(object sender, EventArgs e)
        {
  //          this.lbItems.Text = String.Format("{0}/{1}", this.networkDataControl.ItemCount, this.networkDataControl.SelectedItemCount);
        }
        #endregion


        //---------------------------------------------


        #region Network Trainer Control Events
        private void networkTrainerControl_DataNeeded(object sender, EventArgs e)
        {
//            NetworkVectors trainingVectors = this.networkDataControl.NetworkData.CreateTrainingVectors();
//            NetworkVectors validationVectors = this.networkDataControl.NetworkData.CreateValidationVectors();
            
  //          this.networkTrainerControl.Start(trainingVectors, validationVectors);
        }

        private void networkTrainerControl_StatusChanged(object sender, EventArgs e)
        {
            this.lbStatus.Text = this.networkTrainerControl.TrainingStatus.StatusText;
            this.progressBar.Value = this.networkTrainerControl.TrainingStatus.Progress;
            this.lbStatusEpoch.Text = String.Format("Epoch: {0}", this.networkTrainerControl.TrainingStatus.Epoch);
            this.lbStatusError.Text = String.Format("Error Rate: {0:0.00000}", this.networkTrainerControl.TrainingStatus.TrainingErrorRate);
        }

        private void networkTrainerControl_TrainingComplete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Training completed. Would you like to start querying the Network?",
                "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                 this.MenuNetworkQuery_Click(this, EventArgs.Empty);
            }
        }
        #endregion


        //---------------------------------------------


        #region Neural Network Events
        private void neuralNetwork_SavePathChanged(object sender, EventArgs e)
        {
            this.openFileDialog.FileName = this.m_networkContainer.LastSavePath;
            this.saveFileDialog.FileName = this.m_networkContainer.LastSavePath;

            this.MenuFileSaveAs.Enabled = (this.m_networkContainer.LastSavePath.Length > 0);
        }
        #endregion


        //---------------------------------------------

        #region Menus
        private void MenuNetworkNew_Click(object sender, EventArgs e)
        {
            //if (this.net
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

        private void MenuFileNew_Click(object sender, EventArgs e)
        {
            ImportWizard importWizard = new ImportWizard();
            if (importWizard.ShowDialog(this) == DialogResult.OK)
            {
   //             this.networkDataControl.NetworkData = importWizard.GetNetworkData();
                this.CurrentNetworkContainer = null;
            }
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            if (this.m_networkContainer.LastSavePath.Length > 0)
                this.networkSave(this.CurrentNetworkContainer.LastSavePath);

            else this.saveFileDialog.ShowDialog(this);
        }

        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog(this);
        }

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog(this);
        }

        private void MenuNetworkQuery_Click(object sender, EventArgs e)
        {
            this.UpdateStatus("Querying network");
            new NetworkInquirer(this.m_networkContainer).ShowDialog(this);
            this.UpdateStatus("Ready");
        }

        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        #endregion

        //---------------------------------------------

        #region Statusbar Update
        private void UpdateStatus(string text)
        {
            this.lbStatus.Text = text;
        }
        #endregion

        //---------------------------------------------

        #region Open & Save Network
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkLoad(openFileDialog.FileName);
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

        private void networkLoad(string path)
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

        private void Show_VisualOptions(object sender, EventArgs e)
        {
            new StatusBarOptions().Show(this);
        }

    }
}