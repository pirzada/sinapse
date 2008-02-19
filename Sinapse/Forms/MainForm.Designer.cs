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

namespace Sinapse.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbTitleNeurons = new System.Windows.Forms.Label();
            this.lbTitleInputs = new System.Windows.Forms.Label();
            this.lbNeuronCount = new System.Windows.Forms.Label();
            this.lbInputCount = new System.Windows.Forms.Label();
            this.lbTitleOutputs = new System.Windows.Forms.Label();
            this.lbOutputCount = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileWizard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileRecentWorkplaces = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileRecentDatabases = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileRecentNetworks = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileCloseNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileCloseDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuWorkplaceComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuDatabaseEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuNetworkWeights = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.sideTrainerControl = new Sinapse.Controls.Sidebar.SideTrainerControl();
            this.MenuHelpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveNetworkDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControlSidebar = new Dotnetrix.Controls.TabControlEX();
            this.tabStatus = new Dotnetrix.Controls.TabPageEX();
            this.sideDisplayControl = new Sinapse.Controls.Sidebar.SideDisplayControl();
            this.tabTraining = new Dotnetrix.Controls.TabPageEX();
            this.tabData = new Dotnetrix.Controls.TabPageEX();
            this.sideRangesControl = new Sinapse.Controls.Sidebar.SideRangesControl();
            this.tabWorkplace = new Dotnetrix.Controls.TabPageEX();
            this.tabControlNetworkData = new Sinapse.Controls.NetworkDataTab.NetworkDataTabControl();
            this.tabSetImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnDatabaseNew = new System.Windows.Forms.ToolStripButton();
            this.btnDatabaseOpen = new System.Windows.Forms.ToolStripButton();
            this.btnDatabaseSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNetworkNew = new System.Windows.Forms.ToolStripButton();
            this.btnNetworkOpen = new System.Windows.Forms.ToolStripButton();
            this.btnNetworkSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWizard = new System.Windows.Forms.ToolStripButton();
            this.toolStripTraining = new System.Windows.Forms.ToolStrip();
            this.btnTrainForget = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTrainBack = new System.Windows.Forms.ToolStripButton();
            this.btnTrainStart = new System.Windows.Forms.ToolStripButton();
            this.btnTrainPause = new System.Windows.Forms.ToolStripButton();
            this.btnTrainStop = new System.Windows.Forms.ToolStripButton();
            this.btnTrainNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTrainGraph = new System.Windows.Forms.ToolStripButton();
            this.btnTrainQuery = new System.Windows.Forms.ToolStripButton();
            this.saveDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseWorkplaceDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusBarControl = new Sinapse.Controls.StatusBarControl();
            this.sideTrainerControl = new Sinapse.Controls.Sidebar.SideTrainerControl();
            this.panelTitle.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControlSidebar.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.tabTraining.SuspendLayout();
            this.tabData.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.toolStripTraining.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.DarkBlue;
            this.panelTitle.Controls.Add(this.lbTitle);
            this.panelTitle.Controls.Add(this.lbTitleNeurons);
            this.panelTitle.Controls.Add(this.lbTitleInputs);
            this.panelTitle.Controls.Add(this.lbNeuronCount);
            this.panelTitle.Controls.Add(this.lbInputCount);
            this.panelTitle.Controls.Add(this.lbTitleOutputs);
            this.panelTitle.Controls.Add(this.lbOutputCount);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(792, 50);
            this.panelTitle.TabIndex = 5;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lbTitle.Location = new System.Drawing.Point(12, 8);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(397, 29);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Sinapse Neural Networking Tool";
            // 
            // lbTitleNeurons
            // 
            this.lbTitleNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitleNeurons.AutoSize = true;
            this.lbTitleNeurons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleNeurons.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbTitleNeurons.Location = new System.Drawing.Point(494, 31);
            this.lbTitleNeurons.Name = "lbTitleNeurons";
            this.lbTitleNeurons.Size = new System.Drawing.Size(58, 13);
            this.lbTitleNeurons.TabIndex = 0;
            this.lbTitleNeurons.Text = "Neurons:";
            // 
            // lbTitleInputs
            // 
            this.lbTitleInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitleInputs.AutoSize = true;
            this.lbTitleInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleInputs.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbTitleInputs.Location = new System.Drawing.Point(605, 31);
            this.lbTitleInputs.Name = "lbTitleInputs";
            this.lbTitleInputs.Size = new System.Drawing.Size(46, 13);
            this.lbTitleInputs.TabIndex = 0;
            this.lbTitleInputs.Text = "Inputs:";
            // 
            // lbNeuronCount
            // 
            this.lbNeuronCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNeuronCount.AutoSize = true;
            this.lbNeuronCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbNeuronCount.Location = new System.Drawing.Point(558, 31);
            this.lbNeuronCount.Name = "lbNeuronCount";
            this.lbNeuronCount.Size = new System.Drawing.Size(19, 13);
            this.lbNeuronCount.TabIndex = 0;
            this.lbNeuronCount.Text = "00";
            // 
            // lbInputCount
            // 
            this.lbInputCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInputCount.AutoSize = true;
            this.lbInputCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbInputCount.Location = new System.Drawing.Point(653, 31);
            this.lbInputCount.Name = "lbInputCount";
            this.lbInputCount.Size = new System.Drawing.Size(19, 13);
            this.lbInputCount.TabIndex = 0;
            this.lbInputCount.Text = "00";
            // 
            // lbTitleOutputs
            // 
            this.lbTitleOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitleOutputs.AutoSize = true;
            this.lbTitleOutputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleOutputs.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbTitleOutputs.Location = new System.Drawing.Point(700, 31);
            this.lbTitleOutputs.Name = "lbTitleOutputs";
            this.lbTitleOutputs.Size = new System.Drawing.Size(55, 13);
            this.lbTitleOutputs.TabIndex = 0;
            this.lbTitleOutputs.Text = "Outputs:";
            // 
            // lbOutputCount
            // 
            this.lbOutputCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOutputCount.AutoSize = true;
            this.lbOutputCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbOutputCount.Location = new System.Drawing.Point(757, 31);
            this.lbOutputCount.Name = "lbOutputCount";
            this.lbOutputCount.Size = new System.Drawing.Size(19, 13);
            this.lbOutputCount.TabIndex = 0;
            this.lbOutputCount.Text = "00";
            // 
            // sideTrainerControl
            // 
            this.sideTrainerControl.BackColor = System.Drawing.SystemColors.Control;
            this.sideTrainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideTrainerControl.Location = new System.Drawing.Point(0, 0);
            this.sideTrainerControl.Name = "sideTrainerControl";
            this.sideTrainerControl.Padding = new System.Windows.Forms.Padding(3);
            this.sideTrainerControl.Size = new System.Drawing.Size(232, 444);
            this.sideTrainerControl.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuWorkplace,
            this.MenuDatabase,
            this.MenuNetwork,
            this.MenuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 50);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileWizard,
            this.toolStripSeparator6,
            this.MenuFileRecentWorkplaces,
            this.MenuFileRecentDatabases,
            this.MenuFileRecentNetworks,
            this.MenuFileSeparator1,
            this.MenuFileCloseNetwork,
            this.MenuFileCloseDatabase,
            this.MenuFileSeparator2,
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(35, 20);
            this.MenuFile.Text = "&File";
            // 
            // MenuFileWizard
            // 
            this.MenuFileWizard.Image = global::Sinapse.Properties.Resources.wizard;
            this.MenuFileWizard.Name = "MenuFileWizard";
            this.MenuFileWizard.Size = new System.Drawing.Size(177, 22);
            this.MenuFileWizard.Text = "Run Wizard...";
            this.MenuFileWizard.Click += new System.EventHandler(this.MenuFileWizard_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuFileRecentWorkplaces
            // 
            this.MenuFileRecentWorkplaces.Name = "MenuFileRecentWorkplaces";
            this.MenuFileRecentWorkplaces.Size = new System.Drawing.Size(177, 22);
            this.MenuFileRecentWorkplaces.Text = "Recent Workplaces";
            // 
            // MenuFileRecentDatabases
            // 
            this.MenuFileRecentDatabases.Name = "MenuFileRecentDatabases";
            this.MenuFileRecentDatabases.Size = new System.Drawing.Size(177, 22);
            this.MenuFileRecentDatabases.Text = "Recent Databases";
            // 
            // MenuFileRecentNetworks
            // 
            this.MenuFileRecentNetworks.Name = "MenuFileRecentNetworks";
            this.MenuFileRecentNetworks.Size = new System.Drawing.Size(177, 22);
            this.MenuFileRecentNetworks.Text = "Recent Networks";
            // 
            // MenuFileSeparator1
            // 
            this.MenuFileSeparator1.Name = "MenuFileSeparator1";
            this.MenuFileSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuFileCloseNetwork
            // 
            this.MenuFileCloseNetwork.Name = "MenuFileCloseNetwork";
            this.MenuFileCloseNetwork.Size = new System.Drawing.Size(177, 22);
            this.MenuFileCloseNetwork.Text = "Close Network";
            this.MenuFileCloseNetwork.Click += new System.EventHandler(this.MenuFileCloseNetwork_Click);
            // 
            // MenuFileCloseDatabase
            // 
            this.MenuFileCloseDatabase.Name = "MenuFileCloseDatabase";
            this.MenuFileCloseDatabase.Size = new System.Drawing.Size(177, 22);
            this.MenuFileCloseDatabase.Text = "Close Database";
            this.MenuFileCloseDatabase.Click += new System.EventHandler(this.MenuFileCloseDatabase_Click);
            // 
            // MenuFileSeparator2
            // 
            this.MenuFileSeparator2.Name = "MenuFileSeparator2";
            this.MenuFileSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Image = global::Sinapse.Properties.Resources.shutdown;
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(177, 22);
            this.MenuFileExit.Text = "Exit";
            // 
            // MenuWorkplace
            // 
            this.MenuWorkplace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuWorkplaceNew,
            this.MenuWorkplaceOpen,
            this.MenuWorkplaceSave,
            this.MenuWorkplaceSaveAs,
            this.MenuWorkplaceSeparator,
            this.MenuWorkplaceComparison});
            this.MenuWorkplace.Enabled = false;
            this.MenuWorkplace.Name = "MenuWorkplace";
            this.MenuWorkplace.Size = new System.Drawing.Size(69, 20);
            this.MenuWorkplace.Text = "&Workplace";
            // 
            // MenuWorkplaceNew
            // 
            this.MenuWorkplaceNew.Image = global::Sinapse.Properties.Resources.file_new;
            this.MenuWorkplaceNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuWorkplaceNew.Name = "MenuWorkplaceNew";
            this.MenuWorkplaceNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MenuWorkplaceNew.Size = new System.Drawing.Size(171, 22);
            this.MenuWorkplaceNew.Text = "&New";
            this.MenuWorkplaceNew.Click += new System.EventHandler(this.MenuNetworkNew_Click);
            // 
            // MenuWorkplaceOpen
            // 
            this.MenuWorkplaceOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.MenuWorkplaceOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuWorkplaceOpen.Name = "MenuWorkplaceOpen";
            this.MenuWorkplaceOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuWorkplaceOpen.Size = new System.Drawing.Size(171, 22);
            this.MenuWorkplaceOpen.Text = "&Open";
            this.MenuWorkplaceOpen.Click += new System.EventHandler(this.MenuNetworkSave_Click);
            // 
            // MenuWorkplaceSave
            // 
            this.MenuWorkplaceSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.MenuWorkplaceSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuWorkplaceSave.Name = "MenuWorkplaceSave";
            this.MenuWorkplaceSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuWorkplaceSave.Size = new System.Drawing.Size(171, 22);
            this.MenuWorkplaceSave.Text = "&Save";
            // 
            // MenuWorkplaceSaveAs
            // 
            this.MenuWorkplaceSaveAs.Image = global::Sinapse.Properties.Resources.file_saveas;
            this.MenuWorkplaceSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuWorkplaceSaveAs.Name = "MenuWorkplaceSaveAs";
            this.MenuWorkplaceSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuWorkplaceSaveAs.Size = new System.Drawing.Size(171, 22);
            this.MenuWorkplaceSaveAs.Text = "Save &As";
            this.MenuWorkplaceSaveAs.Click += new System.EventHandler(this.MenuNetworkOpen_Click);
            // 
            // MenuWorkplaceSeparator
            // 
            this.MenuWorkplaceSeparator.Name = "MenuWorkplaceSeparator";
            this.MenuWorkplaceSeparator.Size = new System.Drawing.Size(168, 6);
            // 
            // MenuWorkplaceComparison
            // 
            this.MenuWorkplaceComparison.Image = global::Sinapse.Properties.Resources.volume_manager_16;
            this.MenuWorkplaceComparison.Name = "MenuWorkplaceComparison";
            this.MenuWorkplaceComparison.Size = new System.Drawing.Size(171, 22);
            this.MenuWorkplaceComparison.Text = "&Comparison Chart";
            // 
            // MenuDatabase
            // 
            this.MenuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDatabaseNew,
            this.MenuDatabaseOpen,
            this.MenuDatabaseSave,
            this.MenuDatabaseSaveAs,
            this.MenuDatabaseSeparator,
            this.MenuDatabaseEdit});
            this.MenuDatabase.Name = "MenuDatabase";
            this.MenuDatabase.Size = new System.Drawing.Size(65, 20);
            this.MenuDatabase.Text = "&Database";
            // 
            // MenuDatabaseNew
            // 
            this.MenuDatabaseNew.Image = global::Sinapse.Properties.Resources.file_new;
            this.MenuDatabaseNew.Name = "MenuDatabaseNew";
            this.MenuDatabaseNew.Size = new System.Drawing.Size(152, 22);
            this.MenuDatabaseNew.Text = "&New";
            this.MenuDatabaseNew.Click += new System.EventHandler(this.MenuFileWizard_Click);
            // 
            // MenuDatabaseOpen
            // 
            this.MenuDatabaseOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.MenuDatabaseOpen.Name = "MenuDatabaseOpen";
            this.MenuDatabaseOpen.Size = new System.Drawing.Size(152, 22);
            this.MenuDatabaseOpen.Text = "&Open";
            this.MenuDatabaseOpen.Click += new System.EventHandler(this.MenuDatabaseOpen_Click);
            // 
            // MenuDatabaseSave
            // 
            this.MenuDatabaseSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.MenuDatabaseSave.Name = "MenuDatabaseSave";
            this.MenuDatabaseSave.Size = new System.Drawing.Size(152, 22);
            this.MenuDatabaseSave.Text = "&Save";
            this.MenuDatabaseSave.Click += new System.EventHandler(this.MenuDatabaseSave_Click);
            // 
            // MenuDatabaseSaveAs
            // 
            this.MenuDatabaseSaveAs.Image = global::Sinapse.Properties.Resources.file_saveas;
            this.MenuDatabaseSaveAs.Name = "MenuDatabaseSaveAs";
            this.MenuDatabaseSaveAs.Size = new System.Drawing.Size(152, 22);
            this.MenuDatabaseSaveAs.Text = "Save &As";
            this.MenuDatabaseSaveAs.Click += new System.EventHandler(this.MenuDatabaseSaveAs_Click);
            // 
            // MenuDatabaseSeparator
            // 
            this.MenuDatabaseSeparator.Name = "MenuDatabaseSeparator";
            this.MenuDatabaseSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuDatabaseEdit
            // 
            this.MenuDatabaseEdit.Image = global::Sinapse.Properties.Resources.edit;
            this.MenuDatabaseEdit.Name = "MenuDatabaseEdit";
            this.MenuDatabaseEdit.Size = new System.Drawing.Size(152, 22);
            this.MenuDatabaseEdit.Text = "&Edit Schema";
            // 
            // MenuNetwork
            // 
            this.MenuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNetworkNew,
            this.MenuNetworkOpen,
            this.MenuNetworkSave,
            this.MenuNetworkSaveAs,
            this.MenuNetworkSeparator,
            this.MenuNetworkWeights});
            this.MenuNetwork.Name = "MenuNetwork";
            this.MenuNetwork.Size = new System.Drawing.Size(59, 20);
            this.MenuNetwork.Text = "&Network";
            // 
            // MenuNetworkNew
            // 
            this.MenuNetworkNew.Image = global::Sinapse.Properties.Resources.network_16;
            this.MenuNetworkNew.Name = "MenuNetworkNew";
            this.MenuNetworkNew.Size = new System.Drawing.Size(153, 22);
            this.MenuNetworkNew.Text = "&New";
            this.MenuNetworkNew.Click += new System.EventHandler(this.MenuNetworkNew_Click);
            // 
            // MenuNetworkOpen
            // 
            this.MenuNetworkOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.MenuNetworkOpen.Name = "MenuNetworkOpen";
            this.MenuNetworkOpen.Size = new System.Drawing.Size(153, 22);
            this.MenuNetworkOpen.Text = "&Open";
            this.MenuNetworkOpen.Click += new System.EventHandler(this.MenuNetworkOpen_Click);
            // 
            // MenuNetworkSave
            // 
            this.MenuNetworkSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.MenuNetworkSave.Name = "MenuNetworkSave";
            this.MenuNetworkSave.Size = new System.Drawing.Size(153, 22);
            this.MenuNetworkSave.Text = "&Save";
            this.MenuNetworkSave.Click += new System.EventHandler(this.MenuNetworkSave_Click);
            // 
            // MenuNetworkSaveAs
            // 
            this.MenuNetworkSaveAs.Image = global::Sinapse.Properties.Resources.file_saveas;
            this.MenuNetworkSaveAs.Name = "MenuNetworkSaveAs";
            this.MenuNetworkSaveAs.Size = new System.Drawing.Size(153, 22);
            this.MenuNetworkSaveAs.Text = "Save &As";
            this.MenuNetworkSaveAs.Click += new System.EventHandler(this.MenuNetworkSaveAs_Click);
            // 
            // MenuNetworkSeparator
            // 
            this.MenuNetworkSeparator.Name = "MenuNetworkSeparator";
            this.MenuNetworkSeparator.Size = new System.Drawing.Size(150, 6);
            // 
            // MenuNetworkWeights
            // 
            this.MenuNetworkWeights.Image = global::Sinapse.Properties.Resources.view_magfit;
            this.MenuNetworkWeights.Name = "MenuNetworkWeights";
            this.MenuNetworkWeights.Size = new System.Drawing.Size(153, 22);
            this.MenuNetworkWeights.Text = "Show &Weigths";
            this.MenuNetworkWeights.Click += new System.EventHandler(this.MenuNetworkShowWeight_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpContents,
            this.MenuHelpIndex,
            this.MenuHelpSearch,
            this.MenuHelpSeparator,
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(40, 20);
            this.MenuHelp.Text = "&Help";
            // 
            // MenuHelpContents
            // 
            this.MenuHelpContents.Image = global::Sinapse.Properties.Resources.help;
            this.MenuHelpContents.Name = "MenuHelpContents";
            this.MenuHelpContents.Size = new System.Drawing.Size(152, 22);
            this.MenuHelpContents.Text = "&Contents";
            // 
            // MenuHelpIndex
            // 
            this.MenuHelpIndex.Enabled = false;
            this.MenuHelpIndex.Name = "MenuHelpIndex";
            this.MenuHelpIndex.Size = new System.Drawing.Size(152, 22);
            this.MenuHelpIndex.Text = "&Index";
            // 
            // MenuHelpSearch
            // 
            this.MenuHelpSearch.Enabled = false;
            this.MenuHelpSearch.Name = "MenuHelpSearch";
            this.MenuHelpSearch.Size = new System.Drawing.Size(152, 22);
            this.MenuHelpSearch.Text = "&Search";
            // 
            // MenuHelpSeparator
            // 
            this.MenuHelpSeparator.Name = "MenuHelpSeparator";
            this.MenuHelpSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Image = global::Sinapse.Properties.Resources.network_16;
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(152, 22);
            this.MenuHelpAbout.Text = "&About...";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // openNetworkDialog
            // 
            this.openNetworkDialog.DefaultExt = "ann";
            this.openNetworkDialog.Filter = "Network Objects (*.ann)|*.ann|All Files (*.*)|*.*";
            this.openNetworkDialog.Title = "Open Network Object";
            this.openNetworkDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openNetworkDialog_FileOk);
            // 
            // saveNetworkDialog
            // 
            this.saveNetworkDialog.DefaultExt = "ann";
            this.saveNetworkDialog.Filter = "Network Objects (*.ann)|*.ann|All Files (*.*)|*.*";
            this.saveNetworkDialog.Title = "Save Network Object";
            this.saveNetworkDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveNetworkDialog_FileOk);
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(792, 452);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 74);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(792, 477);
            this.toolStripContainer.TabIndex = 16;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripMain);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripTraining);
            this.toolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 25);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabControlSidebar);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControlNetworkData);
            this.splitContainer.Size = new System.Drawing.Size(792, 452);
            this.splitContainer.SplitterDistance = 263;
            this.splitContainer.TabIndex = 17;
            // 
            // tabControlSidebar
            // 
            this.tabControlSidebar.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlSidebar.Appearance = Dotnetrix.Controls.TabAppearanceEX.Bevel;
            this.tabControlSidebar.AutoLoadTabPages = true;
            this.tabControlSidebar.Controls.Add(this.tabStatus);
            this.tabControlSidebar.Controls.Add(this.tabTraining);
            this.tabControlSidebar.Controls.Add(this.tabData);
            this.tabControlSidebar.Controls.Add(this.tabWorkplace);
            this.tabControlSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSidebar.HotColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabControlSidebar.HotTrack = true;
            this.tabControlSidebar.Location = new System.Drawing.Point(0, 0);
            this.tabControlSidebar.Multiline = true;
            this.tabControlSidebar.Name = "tabControlSidebar";
            this.tabControlSidebar.SelectedIndex = 1;
            this.tabControlSidebar.Size = new System.Drawing.Size(263, 452);
            this.tabControlSidebar.TabIndex = 16;
            this.tabControlSidebar.UseVisualStyles = false;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.sideDisplayControl);
            this.tabStatus.Location = new System.Drawing.Point(27, 4);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(232, 444);
            this.tabStatus.TabIndex = 1;
            this.tabStatus.Text = "Network Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // sideDisplayControl
            // 
            this.sideDisplayControl.BackColor = System.Drawing.SystemColors.Window;
            this.sideDisplayControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sideDisplayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideDisplayControl.Enabled = false;
            this.sideDisplayControl.Location = new System.Drawing.Point(3, 3);
            this.sideDisplayControl.Name = "sideDisplayControl";
            this.sideDisplayControl.ReadOnly = false;
            this.sideDisplayControl.Size = new System.Drawing.Size(226, 438);
            this.sideDisplayControl.TabIndex = 16;
            // 
            // tabTraining
            // 
            this.tabTraining.Controls.Add(this.sideTrainerControl);
            this.tabTraining.Location = new System.Drawing.Point(27, 4);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Size = new System.Drawing.Size(232, 444);
            this.tabTraining.TabIndex = 0;
            this.tabTraining.Text = "Network Trainer";
            this.tabTraining.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.sideRangesControl);
            this.tabData.Location = new System.Drawing.Point(27, 4);
            this.tabData.Name = "tabData";
            this.tabData.Size = new System.Drawing.Size(232, 444);
            this.tabData.TabIndex = 3;
            this.tabData.Text = "Training Data";
            // 
            // sideRangesControl
            // 
            this.sideRangesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideRangesControl.Enabled = false;
            this.sideRangesControl.Location = new System.Drawing.Point(0, 0);
            this.sideRangesControl.Name = "sideRangesControl";
            this.sideRangesControl.ReadOnly = false;
            this.sideRangesControl.Size = new System.Drawing.Size(232, 444);
            this.sideRangesControl.TabIndex = 15;
            // 
            // tabWorkplace
            // 
            this.tabWorkplace.Enabled = false;
            this.tabWorkplace.Location = new System.Drawing.Point(27, 4);
            this.tabWorkplace.Name = "tabWorkplace";
            this.tabWorkplace.Size = new System.Drawing.Size(232, 444);
            this.tabWorkplace.TabIndex = 4;
            this.tabWorkplace.Text = "Workplace";
            // 
            // tabControlNetworkData
            // 
            this.tabControlNetworkData.Appearance = Dotnetrix.Controls.TabAppearanceEX.Bevel;
            this.tabControlNetworkData.AutoLoadTabPages = true;
            this.tabControlNetworkData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlNetworkData.HotColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabControlNetworkData.ImageList = this.tabSetImageList;
            this.tabControlNetworkData.Location = new System.Drawing.Point(0, 0);
            this.tabControlNetworkData.Name = "tabControlNetworkData";
            this.tabControlNetworkData.Size = new System.Drawing.Size(525, 452);
            this.tabControlNetworkData.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlNetworkData.TabIndex = 0;
            this.tabControlNetworkData.UseVisualStyles = false;
            // 
            // tabSetImageList
            // 
            this.tabSetImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabSetImageList.ImageStream")));
            this.tabSetImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabSetImageList.Images.SetKeyName(0, "Training.png");
            this.tabSetImageList.Images.SetKeyName(1, "Validating.png");
            this.tabSetImageList.Images.SetKeyName(2, "Testing.png");
            this.tabSetImageList.Images.SetKeyName(3, "Query.png");
            this.tabSetImageList.Images.SetKeyName(4, "Graph");
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDatabaseNew,
            this.btnDatabaseOpen,
            this.btnDatabaseSave,
            this.btnSaveAll,
            this.toolStripSeparator8,
            this.btnNetworkNew,
            this.btnNetworkOpen,
            this.btnNetworkSave,
            this.toolStripSeparator7,
            this.btnWizard});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(3, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(206, 25);
            this.toolStripMain.TabIndex = 0;
            // 
            // btnDatabaseNew
            // 
            this.btnDatabaseNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDatabaseNew.Image = global::Sinapse.Properties.Resources.file_new;
            this.btnDatabaseNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatabaseNew.Name = "btnDatabaseNew";
            this.btnDatabaseNew.Size = new System.Drawing.Size(23, 22);
            this.btnDatabaseNew.Text = "New Database";
            this.btnDatabaseNew.Click += new System.EventHandler(this.MenuFileWizard_Click);
            // 
            // btnDatabaseOpen
            // 
            this.btnDatabaseOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDatabaseOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.btnDatabaseOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatabaseOpen.Name = "btnDatabaseOpen";
            this.btnDatabaseOpen.Size = new System.Drawing.Size(23, 22);
            this.btnDatabaseOpen.Text = "Open Database";
            this.btnDatabaseOpen.Click += new System.EventHandler(this.MenuDatabaseOpen_Click);
            // 
            // btnDatabaseSave
            // 
            this.btnDatabaseSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDatabaseSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.btnDatabaseSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatabaseSave.Name = "btnDatabaseSave";
            this.btnDatabaseSave.Size = new System.Drawing.Size(23, 22);
            this.btnDatabaseSave.Text = "Save Database";
            this.btnDatabaseSave.Click += new System.EventHandler(this.MenuDatabaseSave_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAll.Image = global::Sinapse.Properties.Resources.save_all;
            this.btnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(23, 22);
            this.btnSaveAll.Text = "Save All";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNetworkNew
            // 
            this.btnNetworkNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNetworkNew.Image = global::Sinapse.Properties.Resources.network_16;
            this.btnNetworkNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNetworkNew.Name = "btnNetworkNew";
            this.btnNetworkNew.Size = new System.Drawing.Size(23, 22);
            this.btnNetworkNew.Text = "New Network";
            this.btnNetworkNew.Click += new System.EventHandler(this.MenuNetworkNew_Click);
            // 
            // btnNetworkOpen
            // 
            this.btnNetworkOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNetworkOpen.Image = global::Sinapse.Properties.Resources.netjaxer;
            this.btnNetworkOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNetworkOpen.Name = "btnNetworkOpen";
            this.btnNetworkOpen.Size = new System.Drawing.Size(23, 22);
            this.btnNetworkOpen.Text = "Open Network";
            this.btnNetworkOpen.Click += new System.EventHandler(this.MenuNetworkOpen_Click);
            // 
            // btnNetworkSave
            // 
            this.btnNetworkSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNetworkSave.Image = global::Sinapse.Properties.Resources.file_export_16;
            this.btnNetworkSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNetworkSave.Name = "btnNetworkSave";
            this.btnNetworkSave.Size = new System.Drawing.Size(23, 22);
            this.btnNetworkSave.Text = "Save Network";
            this.btnNetworkSave.Click += new System.EventHandler(this.MenuNetworkSave_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnWizard
            // 
            this.btnWizard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWizard.Image = global::Sinapse.Properties.Resources.wizard;
            this.btnWizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWizard.Name = "btnWizard";
            this.btnWizard.Size = new System.Drawing.Size(23, 22);
            this.btnWizard.Text = "Run wizard";
            this.btnWizard.Click += new System.EventHandler(this.MenuFileWizard_Click);
            // 
            // toolStripTraining
            // 
            this.toolStripTraining.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripTraining.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTrainForget,
            this.toolStripSeparator11,
            this.btnTrainBack,
            this.btnTrainStart,
            this.btnTrainPause,
            this.btnTrainStop,
            this.btnTrainNext,
            this.toolStripSeparator10,
            this.btnTrainGraph,
            this.btnTrainQuery});
            this.toolStripTraining.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripTraining.Location = new System.Drawing.Point(406, 0);
            this.toolStripTraining.Name = "toolStripTraining";
            this.toolStripTraining.Size = new System.Drawing.Size(206, 25);
            this.toolStripTraining.TabIndex = 1;
            // 
            // btnTrainForget
            // 
            this.btnTrainForget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainForget.Image = global::Sinapse.Properties.Resources.start;
            this.btnTrainForget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainForget.Name = "btnTrainForget";
            this.btnTrainForget.Size = new System.Drawing.Size(23, 22);
            this.btnTrainForget.Text = "toolStripButton1";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTrainBack
            // 
            this.btnTrainBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainBack.Image = global::Sinapse.Properties.Resources.player_rew_16;
            this.btnTrainBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainBack.Name = "btnTrainBack";
            this.btnTrainBack.Size = new System.Drawing.Size(23, 22);
            this.btnTrainBack.Text = "Previous Savepoint";
            // 
            // btnTrainStart
            // 
            this.btnTrainStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainStart.Image = global::Sinapse.Properties.Resources.player_play_16;
            this.btnTrainStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainStart.Name = "btnTrainStart";
            this.btnTrainStart.Size = new System.Drawing.Size(23, 22);
            this.btnTrainStart.Text = "Start Training";
            // 
            // btnTrainPause
            // 
            this.btnTrainPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainPause.Image = global::Sinapse.Properties.Resources.player_pause_16;
            this.btnTrainPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainPause.Name = "btnTrainPause";
            this.btnTrainPause.Size = new System.Drawing.Size(23, 22);
            this.btnTrainPause.Text = "Pause Training";
            // 
            // btnTrainStop
            // 
            this.btnTrainStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainStop.Image = global::Sinapse.Properties.Resources.player_stop_16;
            this.btnTrainStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainStop.Name = "btnTrainStop";
            this.btnTrainStop.Size = new System.Drawing.Size(23, 22);
            this.btnTrainStop.Text = "Stop Training";
            // 
            // btnTrainNext
            // 
            this.btnTrainNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainNext.Image = global::Sinapse.Properties.Resources.player_fwd_16;
            this.btnTrainNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainNext.Name = "btnTrainNext";
            this.btnTrainNext.Size = new System.Drawing.Size(23, 22);
            this.btnTrainNext.Text = "Next Savepoint";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTrainGraph
            // 
            this.btnTrainGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainGraph.Image = global::Sinapse.Properties.Resources.oscilloscope;
            this.btnTrainGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainGraph.Name = "btnTrainGraph";
            this.btnTrainGraph.Size = new System.Drawing.Size(23, 22);
            this.btnTrainGraph.Text = "Show progress graph";
            // 
            // btnTrainQuery
            // 
            this.btnTrainQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainQuery.Image = global::Sinapse.Properties.Resources.gear_16;
            this.btnTrainQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainQuery.Name = "btnTrainQuery";
            this.btnTrainQuery.Size = new System.Drawing.Size(23, 22);
            this.btnTrainQuery.Text = "Query Network";
            // 
            // saveDatabaseDialog
            // 
            this.saveDatabaseDialog.DefaultExt = "sdo";
            this.saveDatabaseDialog.Filter = "Sinapse Database Objects (*.sdo)|*.sdo|All Files (*.*)|*.*";
            this.saveDatabaseDialog.Title = "Save Database";
            this.saveDatabaseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDatabaseDialog_FileOk);
            // 
            // openDatabaseDialog
            // 
            this.openDatabaseDialog.DefaultExt = "sdo";
            this.openDatabaseDialog.Filter = "Sinapse Database Objects (*.sdo)|*.sdo|All Files (*.*)|*.*";
            this.openDatabaseDialog.Title = "Open Database";
            this.openDatabaseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openDatabaseDialog_FileOk);
            // 
            // browseWorkplaceDialog
            // 
            this.browseWorkplaceDialog.Description = "Select the workplace directory";
            this.browseWorkplaceDialog.RootFolder = System.Environment.SpecialFolder.Personal;
            // 
            // statusBarControl
            // 
            this.statusBarControl.AutoSize = true;
            this.statusBarControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusBarControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBarControl.Location = new System.Drawing.Point(0, 551);
            this.statusBarControl.Name = "statusBarControl";
            this.statusBarControl.Size = new System.Drawing.Size(792, 22);
            this.statusBarControl.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.toolStripContainer);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.statusBarControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(200, 200);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "MainForm";
            this.Text = "Sinapse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.tabControlSidebar.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.tabTraining.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.toolStripTraining.ResumeLayout(false);
            this.toolStripTraining.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbTitleInputs;
        private System.Windows.Forms.Label lbInputCount;
        private System.Windows.Forms.Label lbTitleOutputs;
        private System.Windows.Forms.Label lbOutputCount;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuDatabase;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplace;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplaceNew;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplaceSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplaceOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuDatabaseNew;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpContents;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpIndex;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpSearch;
        private System.Windows.Forms.ToolStripSeparator MenuHelpSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private System.Windows.Forms.OpenFileDialog openNetworkDialog;
        private System.Windows.Forms.SaveFileDialog saveNetworkDialog;
        private System.Windows.Forms.Label lbTitleNeurons;
        private System.Windows.Forms.Label lbNeuronCount;
        private System.Windows.Forms.ToolStripSeparator MenuWorkplaceSeparator;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnNetworkSave;
        private System.Windows.Forms.ToolStripButton btnDatabaseOpen;
        private System.Windows.Forms.ToolStrip toolStripTraining;
        private System.Windows.Forms.ToolStripButton btnTrainStart;
        private System.Windows.Forms.ToolStripButton btnTrainPause;
        private System.Windows.Forms.ToolStripButton btnTrainStop;
        private System.Windows.Forms.ToolStripButton btnTrainBack;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Dotnetrix.Controls.TabControlEX tabControlSidebar;
        private Dotnetrix.Controls.TabPageEX tabTraining;
        private Dotnetrix.Controls.TabPageEX tabStatus;
        private Dotnetrix.Controls.TabPageEX tabData;
        private Sinapse.Controls.Sidebar.SideRangesControl sideRangesControl;
        private Sinapse.Controls.Sidebar.SideDisplayControl sideDisplayControl;
        private System.Windows.Forms.ToolStripButton btnDatabaseSave;
        private System.Windows.Forms.ToolStripButton btnTrainQuery;
        private System.Windows.Forms.ToolStripButton btnNetworkNew;
        private System.Windows.Forms.ToolStripButton btnWizard;
        private Sinapse.Controls.NetworkDataTab.NetworkDataTabControl tabControlNetworkData;
        private System.Windows.Forms.ImageList tabSetImageList;
        private Sinapse.Controls.StatusBarControl statusBarControl;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuDatabaseSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuDatabaseOpen;
        private System.Windows.Forms.ToolStripSeparator MenuDatabaseSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuNetwork;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentDatabases;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentWorkplaces;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentNetworks;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuDatabaseEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkNew;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkOpen;
        private System.Windows.Forms.ToolStripSeparator MenuNetworkSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkWeights;
        private System.Windows.Forms.ToolStripMenuItem MenuFileWizard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplaceComparison;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkSave;
        private Dotnetrix.Controls.TabPageEX tabWorkplace;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplaceSave;
        private System.Windows.Forms.ToolStripMenuItem MenuDatabaseSave;
        private System.Windows.Forms.SaveFileDialog saveDatabaseDialog;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.FolderBrowserDialog browseWorkplaceDialog;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCloseNetwork;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCloseDatabase;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator2;
        private System.Windows.Forms.ToolStripButton btnDatabaseNew;
        private System.Windows.Forms.ToolStripButton btnNetworkOpen;
        private System.Windows.Forms.ToolStripButton btnSaveAll;
        private System.Windows.Forms.ToolStripButton btnTrainForget;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton btnTrainNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnTrainGraph;
        private Sinapse.Controls.Sidebar.SideTrainerControl sideTrainerControl;
    }
}