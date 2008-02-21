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
using Sinapse.Forms.Dialogs;


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

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.DoubleBuffer, true);

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

                this.tabControlSide.NetworkContainer = value;
                this.tabControlMain.NetworkContainer = value;

                if (value != null)
                {
                    this.toolStripTraining.Enabled = true;
                    this.btnNetworkSave.Enabled = true;
                    this.MenuNetworkSave.Enabled = true;
                    this.MenuNetworkSaveAs.Enabled = false;
                    this.MenuNetworkWeights.Enabled = true;

                    this.lbNeuronCount.Text = m_networkContainer.GetLayoutString();

                    this.m_networkContainer.NetworkSaved += new FileSystemEventHandler(currentNetwork_NetworkSaved);

                    if (this.m_networkContainer.IsSaved)
                        this.MenuNetworkSaveAs.Enabled = true;
                }
                else
                {
                    //No active network
                    this.toolStripTraining.Enabled = false;
                    this.btnNetworkSave.Enabled = false;
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

                this.tabControlSide.NetworkDatabase = value;
                this.tabControlMain.NetworkDatabase = value;

                if (value != null)
                {
                    this.btnDatabaseSave.Enabled = true;
                    this.MenuDatabaseSave.Enabled = true;
                    this.MenuDatabaseSaveAs.Enabled = false;
                    this.MenuDatabaseEdit.Enabled = true;

                    this.lbInputCount.Text = this.m_networkDatabase.Schema.InputColumns.Length.ToString();
                    this.lbOutputCount.Text = this.m_networkDatabase.Schema.OutputColumns.Length.ToString();


                    this.m_networkDatabase.DatabaseSaved += new FileSystemEventHandler(currentDatabase_DatabaseSaved);

                    if (this.m_networkDatabase.IsSaved)
                        this.MenuDatabaseSaveAs.Enabled = true;
                }
                else
                {
                    //No active data
                    this.btnDatabaseSave.Enabled = false;
                    this.MenuDatabaseSave.Enabled = false;
                    this.MenuDatabaseSaveAs.Enabled = false;
                    this.MenuDatabaseEdit.Enabled = false;

                    this.lbInputCount.Text = "00";
                    this.lbOutputCount.Text = "00";
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
                // Set form Sizing and Location
                this.Size = Properties.Settings.Default.main_Size;
                this.Location = Properties.Settings.Default.main_Location;
                this.WindowState = Properties.Settings.Default.main_WindowState;


                // Wire up controls and events
                this.tabControlMain.DataSelectionChanged += tabControlMain_SelectionChanged;
                this.tabControlSide.TrainerControl.GraphControl = this.tabControlMain.GraphControl;

                this.tabControlSide.TrainerControl.StatusChanged += sideTrainerControl_StatusChanged;
                this.tabControlSide.TrainerControl.TrainingComplete += sideTrainerControl_TrainingComplete;

                this.CurrentNetworkContainer = null;
                this.CurrentNetworkDatabase = null;
                this.CurrentNetworkWorkplace = null;

                HistoryListener.Write("Waiting data");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HistoryListener.Write("Exiting...");

            if (this.tabControlSide.TrainerControl.IsTraining)
                this.tabControlSide.TrainerControl.Stop();

            // Save settings before closing
            Properties.Settings.Default.main_WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.main_Size = this.Size;
                Properties.Settings.Default.main_Location = this.Location;
            }
            else
            {
                Properties.Settings.Default.main_Size = this.RestoreBounds.Size;
                Properties.Settings.Default.main_Location = this.RestoreBounds.Location;
            }
        }
        #endregion


        //---------------------------------------------


        #region Main Tab Control Events
        private void tabControlMain_SelectionChanged(object sender, EventArgs e)
        {
            this.statusBarControl.UpdateSelectedItems(tabControlMain.SelectedItemCount, tabControlMain.ItemCount);
        }
        #endregion


        //---------------------------------------------


        #region Network Trainer Control Events
        private void sideTrainerControl_StatusChanged(object sender, EventArgs e)
        {
            this.statusBarControl.UpdateNetworkState(this.tabControlSide.TrainerControl.NetworkState);
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
                this.CurrentNetworkDatabase = importWizard.GetNetworkData();
                if (this.CurrentNetworkContainer == null)
                {
                    if (MessageBox.Show("Data imported successfuly. Would you like to create" +
                        "the neural network now?", "Import Complete", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        this.MenuNetworkNew_Click(this, e);
                    }
                }
            }
        }

        private void MenuFileCloseNetwork_Click(object sender, EventArgs e)
        {
            this.CurrentNetworkContainer = null;
        }

        private void MenuFileCloseDatabase_Click(object sender, EventArgs e)
        {
            this.CurrentNetworkDatabase = null;
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
            if (this.m_networkDatabase == null)
            {
                MessageBox.Show("Please import or create a database schema before creating the Network.");
                return;
            }

            if (this.CurrentNetworkContainer == null || 
                (this.CurrentNetworkContainer != null &&
                MessageBox.Show("Would you like to overwrite your current network?" +
                                "\nAny unsaved training sessions will be lost",
                                "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                NetworkCreationDialog creationDlg = new NetworkCreationDialog(m_networkDatabase.Schema);
                if (creationDlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.CurrentNetworkContainer = creationDlg.CreateNetworkContainer();

                    if (Properties.Settings.Default.main_AutoSwitchToTrainingTab)
                    {
                        this.tabControlSide.TrainerControl.ShowTab();
                    }
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
            this.tabControlMain.QueryControl.Show();
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error saving network");
            }
        }

        private void networkOpen(string path)
        {
            NetworkContainer neuralNetwork = null;

            try
            {
                neuralNetwork = NetworkContainer.Deserialize(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error opening network");
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error saving database");
#if DEBUG
                throw e;
#endif
            }
         
        }

        private void databaseOpen(string path)
        {
            NetworkDatabase networkDatabase = null;

            try
            {
                networkDatabase = NetworkDatabase.Deserialize(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error opening database");
#if DEBUG
                throw e;
#endif
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