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
using System.IO;

using Sinapse.Data;
using Sinapse.Data.Structures;
using Sinapse.Dialogs;


namespace Sinapse.Forms
{

    internal sealed partial class MainForm : Form
    {

        private NetworkContainer m_networkContainer;
        private NetworkDatabase m_networkDatabase;
        private NetworkWorkplace m_networkWorkplace;


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
                return this.m_networkContainer;
            }
            set
            {
                this.m_networkContainer = value;
                this.sideTrainerControl.NeuralNetwork = value;
                this.sideDisplayControl.NeuralNetwork = value;

                if (value != null)
                {
                    this.MenuNetworkSave.Enabled = true;
                    this.MenuNetworkSaveAs.Enabled = false;
                    this.MenuNetworkWeights.Enabled = true;

                    this.lbNeuronCount.Text = m_networkContainer.GetLayoutString();


                    this.m_networkContainer.NetworkSaved += new FileSystemEventHandler(currentNetwork_NetworkSaved);
                }
                else
                {
                    //No active network
                    this.MenuNetworkSave.Enabled = false;
                    this.MenuNetworkSaveAs.Enabled = false;
                    this.MenuNetworkWeights.Enabled = false;
                }


            }
        }

        internal NetworkDatabase CurrentNetworkDatabase
        {
            get
            {
                return this.m_networkDatabase;
            }
            set
            {
                this.m_networkDatabase = value;

                this.tabControlNetworkData.NetworkData = value;
                this.sideRangesControl.NetworkData = value;


                if (value != null)
                {
                    this.MenuDatabaseSave.Enabled = true;
                    this.MenuDatabaseSaveAs.Enabled = false;
                    this.MenuDatabaseEdit.Enabled = true;

                    this.lbInputCount.Text = this.m_networkDatabase.Schema.InputColumns.Length.ToString();
                    this.lbOutputCount.Text = this.m_networkDatabase.Schema.OutputColumns.Length.ToString();

                    this.m_networkDatabase.DatabaseSaved += new FileSystemEventHandler(currentDatabase_DatabaseSaved);
                }
                else
                {
                    //No active data
                    this.MenuDatabaseSave.Enabled = false;
                    this.MenuDatabaseSaveAs.Enabled = false;
                    this.MenuDatabaseEdit.Enabled = false;

                    this.lbInputCount.Text = "0";
                    this.lbOutputCount.Text = "0";
                }
            }
        }

        internal NetworkWorkplace CurrentNetworkWorkplace
        {
            get
            {
                return this.m_networkWorkplace;
            }
            set
            {
                this.m_networkWorkplace = value;

                if (value != null)
                {
                }
                else
                {
                }
            }
        }
        #endregion


        //---------------------------------------------


        #region MainForm Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //Wire up controls and events
                //this.tabControlNetworkData.DataChanged += networkDataControl_SelectionChanged;
                this.tabControlNetworkData.SelectionChanged += networkDataControl_SelectionChanged;

                this.sideTrainerControl.StatusChanged += sideTrainerControl_StatusChanged;
                this.sideTrainerControl.DataNeeded += sideTrainerControl_DataNeeded;
                this.sideTrainerControl.TrainingComplete += sideTrainerControl_TrainingComplete;

                this.CurrentNetworkContainer = null;
                this.CurrentNetworkDatabase = null;
                this.CurrentNetworkWorkplace = null;
                HistoryListener.Write("Waiting data");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HistoryListener.Write("Exiting...");

            if (this.sideTrainerControl.IsTraining)
            {
                this.sideTrainerControl.Stop();
            }
        }
        #endregion


        //---------------------------------------------


        #region Network Data Control Events
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
                this.MenuNetworkQuery_Click(this, EventArgs.Empty);
            }
        }
        #endregion


        //---------------------------------------------


        #region Object Events
        private void currentNetwork_NetworkSaved(object sender, FileSystemEventArgs e)
        {
            this.openNetworkDialog.FileName = e.FullPath;
            this.saveNetworkDialog.FileName = e.FullPath;

            this.MenuNetworkSaveAs.Enabled = true;
        }

        private void currentDatabase_DatabaseSaved(object sender, FileSystemEventArgs e)
        {
            this.openDatabaseDialog.FileName = e.FullPath;
            this.saveDatabaseDialog.FileName = e.FullPath;

            this.MenuDatabaseSaveAs.Enabled = true;
        }

        private void currentWorkplace_WorkplaceSaved(object sender, FileSystemEventArgs e)
        {
        }
        #endregion


        //---------------------------------------------


        #region Menu File
        private void MenuFileWizard_Click(object sender, EventArgs e)
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
                        MenuNetworkNew_Click(this, e);
                    }
                }
            }
        }
        #endregion


        #region Menu Database
        private void MenuDatabaseSave_Click(object sender, EventArgs e)
        {
            if (this.CurrentNetworkDatabase.IsSaved)
                this.databaseSave(this.CurrentNetworkDatabase.LastSavePath);

            else this.saveDatabaseDialog.ShowDialog(this);
        }


        private void MenuDatabaseSaveAs_Click(object sender, EventArgs e)
        {
            this.saveDatabaseDialog.ShowDialog(this);
        }


        private void MenuDatabaseOpen_Click(object sender, EventArgs e)
        {
            this.openDatabaseDialog.ShowDialog(this);
        }
        #endregion


        #region Menu Network
        private void MenuNetworkNew_Click(object sender, EventArgs e)
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

        private void MenuNetworkSave_Click(object sender, EventArgs e)
        {
            if (this.CurrentNetworkContainer.IsSaved)
                this.networkSave(this.CurrentNetworkContainer.LastSavePath);

            else this.saveNetworkDialog.ShowDialog(this);
        }


        private void MenuNetworkSaveAs_Click(object sender, EventArgs e)
        {
            this.saveNetworkDialog.ShowDialog(this);
        }


        private void MenuNetworkOpen_Click(object sender, EventArgs e)
        {
            this.openNetworkDialog.ShowDialog(this);
        }

        private void MenuNetworkQuery_Click(object sender, EventArgs e)
        {
            HistoryListener.Write("Querying network");
            new NetworkInquirer(this.m_networkContainer).ShowDialog(this);
            HistoryListener.Write("Ready");
        }

        private void MenuNetworkShowWeight_Click(object sender, EventArgs e)
        {
        }
        #endregion


        #region Menu Help
        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().Show(this);
        }
        #endregion


        //---------------------------------------------


        #region File Dialogs
        private void openNetworkDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkOpen(openNetworkDialog.FileName);
        }

        private void saveNetworkDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkSave(saveNetworkDialog.FileName);
        }

        private void openDatabaseDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.databaseOpen(openDatabaseDialog.FileName);
        }

        private void saveDatabaseDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.databaseSave(saveDatabaseDialog.FileName);
        }
        #endregion


        //---------------------------------------------


        #region Open & Save Network
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


        #region Open & Save Database
        private void databaseSave(string path)
        {
            try
            {
                NetworkDatabase.Serialize(this.CurrentNetworkDatabase, path);
            }
            catch
            {
                MessageBox.Show("Error saving database");
            }
        }

        private void databaseOpen(string path)
        {
            NetworkDatabase networkDatabase = null;

            try
            {
                networkDatabase = NetworkDatabase.Deserialize(path);
            }
            catch
            {
                MessageBox.Show("Error opening database");
            }
            finally
            {
                if (networkDatabase != null)
                {
                    this.CurrentNetworkDatabase = networkDatabase;
                }
            }
        }
        #endregion


        #region Open & Save Workplace
        #endregion


        //---------------------------------------------


    }
}