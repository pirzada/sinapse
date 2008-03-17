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
            this.lbVersion = new System.Windows.Forms.Label();
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
            this.MenuFileRecentDatabases = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileRecentNetworks = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileRecentSessions = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileRecentWorkplaces = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilePreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWorkplaceSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuWorkplaceComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSessionNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSessionOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSessionSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSessionSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSessionClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSessionProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileDatabaseClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDatabaseSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuDatabaseEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuNetworkWeights = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkCodeGenerator = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkCodeGeneratorANSIC = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkCodeGeneratorCpp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkCodeGeneratorCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkCodeGeneratorJava = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkCodeGeneratorMatlab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuNetworkCodeGeneratorOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveNetworkDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControlSide = new Sinapse.Controls.SideTabControl.SideTabControl();
            this.tabControlMain = new Sinapse.Controls.MainTabControl.MainTabControl();
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
            this.toolStripTesting = new System.Windows.Forms.ToolStrip();
            this.btnTestCompute = new System.Windows.Forms.ToolStripButton();
            this.btnTestReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTestRound = new System.Windows.Forms.ToolStripDropDownButton();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestRound10 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestRound25 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestRound50 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestRound75 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestRound90 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseWorkplaceDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusBarControl = new Sinapse.Controls.StatusBarControl();
            this.mruProviderDatabase = new Sinapse.Components.MruProvider();
            this.mruProviderNetwork = new Sinapse.Components.MruProvider();
            this.mruProviderWorkplace = new Sinapse.Components.MruProvider();
            this.mruProviderSession = new Sinapse.Components.MruProvider();
            this.panelTitle.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.toolStripTraining.SuspendLayout();
            this.toolStripTesting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.DarkBlue;
            this.panelTitle.Controls.Add(this.lbVersion);
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
            this.panelTitle.Size = new System.Drawing.Size(892, 50);
            this.panelTitle.TabIndex = 5;
            // 
            // lbVersion
            // 
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbVersion.Location = new System.Drawing.Point(358, 35);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(55, 13);
            this.lbVersion.TabIndex = 0;
            this.lbVersion.Text = "v0.0.0.0";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lbTitleNeurons.Location = new System.Drawing.Point(594, 31);
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
            this.lbTitleInputs.Location = new System.Drawing.Point(705, 31);
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
            this.lbNeuronCount.Location = new System.Drawing.Point(658, 31);
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
            this.lbInputCount.Location = new System.Drawing.Point(753, 31);
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
            this.lbTitleOutputs.Location = new System.Drawing.Point(800, 31);
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
            this.lbOutputCount.Location = new System.Drawing.Point(857, 31);
            this.lbOutputCount.Name = "lbOutputCount";
            this.lbOutputCount.Size = new System.Drawing.Size(19, 13);
            this.lbOutputCount.TabIndex = 0;
            this.lbOutputCount.Text = "00";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuWorkplace,
            this.sessionToolStripMenuItem,
            this.MenuDatabase,
            this.MenuNetwork,
            this.MenuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 50);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(892, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileWizard,
            this.toolStripSeparator6,
            this.MenuFileRecentDatabases,
            this.MenuFileRecentNetworks,
            this.MenuFileRecentSessions,
            this.MenuFileRecentWorkplaces,
            this.MenuFileSeparator1,
            this.MenuFilePreferences,
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
            this.MenuFileWizard.Text = "Run &Wizard...";
            this.MenuFileWizard.Click += new System.EventHandler(this.MenuFileWizard_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuFileRecentDatabases
            // 
            this.MenuFileRecentDatabases.Name = "MenuFileRecentDatabases";
            this.MenuFileRecentDatabases.Size = new System.Drawing.Size(177, 22);
            this.MenuFileRecentDatabases.Text = "Recent &Databases";
            // 
            // MenuFileRecentNetworks
            // 
            this.MenuFileRecentNetworks.Name = "MenuFileRecentNetworks";
            this.MenuFileRecentNetworks.Size = new System.Drawing.Size(177, 22);
            this.MenuFileRecentNetworks.Text = "Recent &Networks";
            // 
            // MenuFileRecentSessions
            // 
            this.MenuFileRecentSessions.Name = "MenuFileRecentSessions";
            this.MenuFileRecentSessions.Size = new System.Drawing.Size(177, 22);
            this.MenuFileRecentSessions.Text = "Recent &Sessions";
            // 
            // MenuFileRecentWorkplaces
            // 
            this.MenuFileRecentWorkplaces.Name = "MenuFileRecentWorkplaces";
            this.MenuFileRecentWorkplaces.Size = new System.Drawing.Size(177, 22);
            this.MenuFileRecentWorkplaces.Text = "Recent &Workplaces";
            // 
            // MenuFileSeparator1
            // 
            this.MenuFileSeparator1.Name = "MenuFileSeparator1";
            this.MenuFileSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuFilePreferences
            // 
            this.MenuFilePreferences.Image = global::Sinapse.Properties.Resources.configure_16;
            this.MenuFilePreferences.Name = "MenuFilePreferences";
            this.MenuFilePreferences.Size = new System.Drawing.Size(177, 22);
            this.MenuFilePreferences.Text = "Preferences";
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
            this.MenuFileExit.Text = "E&xit";
            // 
            // MenuWorkplace
            // 
            this.MenuWorkplace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuWorkplaceNew,
            this.MenuWorkplaceOpen,
            this.MenuWorkplaceSave,
            this.MenuWorkplaceSaveAs,
            this.MenuWorkplaceClose,
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
            // 
            // MenuWorkplaceOpen
            // 
            this.MenuWorkplaceOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.MenuWorkplaceOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuWorkplaceOpen.Name = "MenuWorkplaceOpen";
            this.MenuWorkplaceOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuWorkplaceOpen.Size = new System.Drawing.Size(171, 22);
            this.MenuWorkplaceOpen.Text = "&Open";
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
            // 
            // MenuWorkplaceClose
            // 
            this.MenuWorkplaceClose.Image = global::Sinapse.Properties.Resources.file_close_round;
            this.MenuWorkplaceClose.Name = "MenuWorkplaceClose";
            this.MenuWorkplaceClose.Size = new System.Drawing.Size(171, 22);
            this.MenuWorkplaceClose.Text = "&Close";
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
            this.MenuWorkplaceComparison.Text = "Co&mparison Chart";
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSessionNew,
            this.MenuSessionOpen,
            this.MenuSessionSave,
            this.MenuSessionSaveAs,
            this.MenuSessionClose,
            this.toolStripSeparator1,
            this.MenuSessionProperties});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.sessionToolStripMenuItem.Text = "Session";
            // 
            // MenuSessionNew
            // 
            this.MenuSessionNew.Image = global::Sinapse.Properties.Resources.file_new;
            this.MenuSessionNew.Name = "MenuSessionNew";
            this.MenuSessionNew.Size = new System.Drawing.Size(152, 22);
            this.MenuSessionNew.Text = "&New";
            this.MenuSessionNew.Click += new System.EventHandler(this.MenuSessionNew_Click);
            // 
            // MenuSessionOpen
            // 
            this.MenuSessionOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.MenuSessionOpen.Name = "MenuSessionOpen";
            this.MenuSessionOpen.Size = new System.Drawing.Size(152, 22);
            this.MenuSessionOpen.Text = "&Open";
            this.MenuSessionOpen.Click += new System.EventHandler(this.MenuSessionOpen_Click);
            // 
            // MenuSessionSave
            // 
            this.MenuSessionSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.MenuSessionSave.Name = "MenuSessionSave";
            this.MenuSessionSave.Size = new System.Drawing.Size(152, 22);
            this.MenuSessionSave.Text = "&Save";
            this.MenuSessionSave.Click += new System.EventHandler(this.MenuSessionSave_Click);
            // 
            // MenuSessionSaveAs
            // 
            this.MenuSessionSaveAs.Image = global::Sinapse.Properties.Resources.file_saveas;
            this.MenuSessionSaveAs.Name = "MenuSessionSaveAs";
            this.MenuSessionSaveAs.Size = new System.Drawing.Size(152, 22);
            this.MenuSessionSaveAs.Text = "Save &As";
            this.MenuSessionSaveAs.Click += new System.EventHandler(this.MenuSessionSaveAs_Click);
            // 
            // MenuSessionClose
            // 
            this.MenuSessionClose.Image = global::Sinapse.Properties.Resources.file_close_round;
            this.MenuSessionClose.Name = "MenuSessionClose";
            this.MenuSessionClose.Size = new System.Drawing.Size(152, 22);
            this.MenuSessionClose.Text = "&Close";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuSessionProperties
            // 
            this.MenuSessionProperties.Image = global::Sinapse.Properties.Resources.kdb_form;
            this.MenuSessionProperties.Name = "MenuSessionProperties";
            this.MenuSessionProperties.Size = new System.Drawing.Size(152, 22);
            this.MenuSessionProperties.Text = "&Properties";
            // 
            // MenuDatabase
            // 
            this.MenuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDatabaseNew,
            this.MenuDatabaseOpen,
            this.MenuDatabaseSave,
            this.MenuDatabaseSaveAs,
            this.MenuFileDatabaseClose,
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
            this.MenuDatabaseNew.Size = new System.Drawing.Size(143, 22);
            this.MenuDatabaseNew.Text = "&New";
            this.MenuDatabaseNew.Click += new System.EventHandler(this.MenuFileWizard_Click);
            // 
            // MenuDatabaseOpen
            // 
            this.MenuDatabaseOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.MenuDatabaseOpen.Name = "MenuDatabaseOpen";
            this.MenuDatabaseOpen.Size = new System.Drawing.Size(143, 22);
            this.MenuDatabaseOpen.Text = "&Open";
            this.MenuDatabaseOpen.Click += new System.EventHandler(this.MenuDatabaseOpen_Click);
            // 
            // MenuDatabaseSave
            // 
            this.MenuDatabaseSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.MenuDatabaseSave.Name = "MenuDatabaseSave";
            this.MenuDatabaseSave.Size = new System.Drawing.Size(143, 22);
            this.MenuDatabaseSave.Text = "&Save";
            this.MenuDatabaseSave.Click += new System.EventHandler(this.MenuDatabaseSave_Click);
            // 
            // MenuDatabaseSaveAs
            // 
            this.MenuDatabaseSaveAs.Image = global::Sinapse.Properties.Resources.file_saveas;
            this.MenuDatabaseSaveAs.Name = "MenuDatabaseSaveAs";
            this.MenuDatabaseSaveAs.Size = new System.Drawing.Size(143, 22);
            this.MenuDatabaseSaveAs.Text = "Save &As";
            this.MenuDatabaseSaveAs.Click += new System.EventHandler(this.MenuDatabaseSaveAs_Click);
            // 
            // MenuFileDatabaseClose
            // 
            this.MenuFileDatabaseClose.Image = global::Sinapse.Properties.Resources.file_close_round;
            this.MenuFileDatabaseClose.Name = "MenuFileDatabaseClose";
            this.MenuFileDatabaseClose.Size = new System.Drawing.Size(143, 22);
            this.MenuFileDatabaseClose.Text = "&Close";
            // 
            // MenuDatabaseSeparator
            // 
            this.MenuDatabaseSeparator.Name = "MenuDatabaseSeparator";
            this.MenuDatabaseSeparator.Size = new System.Drawing.Size(140, 6);
            // 
            // MenuDatabaseEdit
            // 
            this.MenuDatabaseEdit.Image = global::Sinapse.Properties.Resources.edit;
            this.MenuDatabaseEdit.Name = "MenuDatabaseEdit";
            this.MenuDatabaseEdit.Size = new System.Drawing.Size(143, 22);
            this.MenuDatabaseEdit.Text = "&Edit Schema";
            this.MenuDatabaseEdit.Click += new System.EventHandler(this.MenuDatabaseEdit_Click);
            // 
            // MenuNetwork
            // 
            this.MenuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNetworkNew,
            this.MenuNetworkOpen,
            this.MenuNetworkSave,
            this.MenuNetworkSaveAs,
            this.MenuNetworkClose,
            this.MenuNetworkSeparator,
            this.MenuNetworkWeights,
            this.MenuNetworkCodeGenerator});
            this.MenuNetwork.Name = "MenuNetwork";
            this.MenuNetwork.Size = new System.Drawing.Size(59, 20);
            this.MenuNetwork.Text = "&Network";
            // 
            // MenuNetworkNew
            // 
            this.MenuNetworkNew.Image = global::Sinapse.Properties.Resources.network_16;
            this.MenuNetworkNew.Name = "MenuNetworkNew";
            this.MenuNetworkNew.Size = new System.Drawing.Size(162, 22);
            this.MenuNetworkNew.Text = "&New";
            this.MenuNetworkNew.Click += new System.EventHandler(this.MenuNetworkNew_Click);
            // 
            // MenuNetworkOpen
            // 
            this.MenuNetworkOpen.Image = global::Sinapse.Properties.Resources.file_import;
            this.MenuNetworkOpen.Name = "MenuNetworkOpen";
            this.MenuNetworkOpen.Size = new System.Drawing.Size(162, 22);
            this.MenuNetworkOpen.Text = "&Open";
            this.MenuNetworkOpen.Click += new System.EventHandler(this.MenuNetworkOpen_Click);
            // 
            // MenuNetworkSave
            // 
            this.MenuNetworkSave.Image = global::Sinapse.Properties.Resources.file_export;
            this.MenuNetworkSave.Name = "MenuNetworkSave";
            this.MenuNetworkSave.Size = new System.Drawing.Size(162, 22);
            this.MenuNetworkSave.Text = "&Save";
            this.MenuNetworkSave.Click += new System.EventHandler(this.MenuNetworkSave_Click);
            // 
            // MenuNetworkSaveAs
            // 
            this.MenuNetworkSaveAs.Image = global::Sinapse.Properties.Resources.file_saveas;
            this.MenuNetworkSaveAs.Name = "MenuNetworkSaveAs";
            this.MenuNetworkSaveAs.Size = new System.Drawing.Size(162, 22);
            this.MenuNetworkSaveAs.Text = "Save &As";
            this.MenuNetworkSaveAs.Click += new System.EventHandler(this.MenuNetworkSaveAs_Click);
            // 
            // MenuNetworkClose
            // 
            this.MenuNetworkClose.Image = global::Sinapse.Properties.Resources.file_close_round;
            this.MenuNetworkClose.Name = "MenuNetworkClose";
            this.MenuNetworkClose.Size = new System.Drawing.Size(162, 22);
            this.MenuNetworkClose.Text = "&Close";
            // 
            // MenuNetworkSeparator
            // 
            this.MenuNetworkSeparator.Name = "MenuNetworkSeparator";
            this.MenuNetworkSeparator.Size = new System.Drawing.Size(159, 6);
            // 
            // MenuNetworkWeights
            // 
            this.MenuNetworkWeights.Image = global::Sinapse.Properties.Resources.view_magfit;
            this.MenuNetworkWeights.Name = "MenuNetworkWeights";
            this.MenuNetworkWeights.Size = new System.Drawing.Size(162, 22);
            this.MenuNetworkWeights.Text = "Show &Weigths";
            this.MenuNetworkWeights.Click += new System.EventHandler(this.MenuNetworkShowWeight_Click);
            // 
            // MenuNetworkCodeGenerator
            // 
            this.MenuNetworkCodeGenerator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNetworkCodeGeneratorANSIC,
            this.MenuNetworkCodeGeneratorCpp,
            this.MenuNetworkCodeGeneratorCSharp,
            this.MenuNetworkCodeGeneratorJava,
            this.MenuNetworkCodeGeneratorMatlab,
            this.toolStripSeparator3,
            this.MenuNetworkCodeGeneratorOptions});
            this.MenuNetworkCodeGenerator.Image = global::Sinapse.Properties.Resources.build;
            this.MenuNetworkCodeGenerator.Name = "MenuNetworkCodeGenerator";
            this.MenuNetworkCodeGenerator.Size = new System.Drawing.Size(162, 22);
            this.MenuNetworkCodeGenerator.Text = "Code &Generator";
            // 
            // MenuNetworkCodeGeneratorANSIC
            // 
            this.MenuNetworkCodeGeneratorANSIC.Image = global::Sinapse.Properties.Resources.source_c;
            this.MenuNetworkCodeGeneratorANSIC.Name = "MenuNetworkCodeGeneratorANSIC";
            this.MenuNetworkCodeGeneratorANSIC.Size = new System.Drawing.Size(122, 22);
            this.MenuNetworkCodeGeneratorANSIC.Text = "ANSI C";
            // 
            // MenuNetworkCodeGeneratorCpp
            // 
            this.MenuNetworkCodeGeneratorCpp.Image = global::Sinapse.Properties.Resources.source_cpp;
            this.MenuNetworkCodeGeneratorCpp.Name = "MenuNetworkCodeGeneratorCpp";
            this.MenuNetworkCodeGeneratorCpp.Size = new System.Drawing.Size(122, 22);
            this.MenuNetworkCodeGeneratorCpp.Text = "C++";
            // 
            // MenuNetworkCodeGeneratorCSharp
            // 
            this.MenuNetworkCodeGeneratorCSharp.Image = global::Sinapse.Properties.Resources.page_white_csharp;
            this.MenuNetworkCodeGeneratorCSharp.Name = "MenuNetworkCodeGeneratorCSharp";
            this.MenuNetworkCodeGeneratorCSharp.Size = new System.Drawing.Size(122, 22);
            this.MenuNetworkCodeGeneratorCSharp.Text = "C#";
            // 
            // MenuNetworkCodeGeneratorJava
            // 
            this.MenuNetworkCodeGeneratorJava.Image = global::Sinapse.Properties.Resources.source_java;
            this.MenuNetworkCodeGeneratorJava.Name = "MenuNetworkCodeGeneratorJava";
            this.MenuNetworkCodeGeneratorJava.Size = new System.Drawing.Size(122, 22);
            this.MenuNetworkCodeGeneratorJava.Text = "Java";
            // 
            // MenuNetworkCodeGeneratorMatlab
            // 
            this.MenuNetworkCodeGeneratorMatlab.Image = global::Sinapse.Properties.Resources.kformula_kfo;
            this.MenuNetworkCodeGeneratorMatlab.Name = "MenuNetworkCodeGeneratorMatlab";
            this.MenuNetworkCodeGeneratorMatlab.Size = new System.Drawing.Size(122, 22);
            this.MenuNetworkCodeGeneratorMatlab.Text = "Matlab";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(119, 6);
            // 
            // MenuNetworkCodeGeneratorOptions
            // 
            this.MenuNetworkCodeGeneratorOptions.Name = "MenuNetworkCodeGeneratorOptions";
            this.MenuNetworkCodeGeneratorOptions.Size = new System.Drawing.Size(122, 22);
            this.MenuNetworkCodeGeneratorOptions.Text = "Options";
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
            this.MenuHelpContents.Size = new System.Drawing.Size(129, 22);
            this.MenuHelpContents.Text = "&Contents";
            this.MenuHelpContents.Click += new System.EventHandler(this.MenuHelpContents_Click);
            // 
            // MenuHelpIndex
            // 
            this.MenuHelpIndex.Enabled = false;
            this.MenuHelpIndex.Name = "MenuHelpIndex";
            this.MenuHelpIndex.Size = new System.Drawing.Size(129, 22);
            this.MenuHelpIndex.Text = "&Index";
            // 
            // MenuHelpSearch
            // 
            this.MenuHelpSearch.Enabled = false;
            this.MenuHelpSearch.Name = "MenuHelpSearch";
            this.MenuHelpSearch.Size = new System.Drawing.Size(129, 22);
            this.MenuHelpSearch.Text = "&Search";
            // 
            // MenuHelpSeparator
            // 
            this.MenuHelpSeparator.Name = "MenuHelpSeparator";
            this.MenuHelpSeparator.Size = new System.Drawing.Size(126, 6);
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Image = global::Sinapse.Properties.Resources.network_16;
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(129, 22);
            this.MenuHelpAbout.Text = "&About...";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // openNetworkDialog
            // 
            this.openNetworkDialog.DefaultExt = "ann";
            this.openNetworkDialog.Filter = "Sinapse Network Objects (*.ann)|*.ann|All Files (*.*)|*.*";
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
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(892, 552);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 74);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(892, 577);
            this.toolStripContainer.TabIndex = 16;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripMain);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripTraining);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripTesting);
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
            this.splitContainer.Panel1.Controls.Add(this.tabControlSide);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainer.Size = new System.Drawing.Size(892, 552);
            this.splitContainer.SplitterDistance = 263;
            this.splitContainer.TabIndex = 17;
            // 
            // tabControlSide
            // 
            this.tabControlSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSide.Location = new System.Drawing.Point(0, 0);
            this.tabControlSide.Name = "tabControlSide";
            this.tabControlSide.Size = new System.Drawing.Size(263, 552);
            this.tabControlSide.TabIndex = 0;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Size = new System.Drawing.Size(625, 552);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedControlChanged += new System.EventHandler(this.tabControlMain_SelectedControlChanged);
            this.tabControlMain.DataSelectionChanged += new System.EventHandler(this.tabControlMain_SelectionChanged);
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
            this.btnSaveAll.Image = global::Sinapse.Properties.Resources.file_saveall;
            this.btnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(23, 22);
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
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
            this.btnNetworkOpen.Image = global::Sinapse.Properties.Resources.file_import;
            this.btnNetworkOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNetworkOpen.Name = "btnNetworkOpen";
            this.btnNetworkOpen.Size = new System.Drawing.Size(23, 22);
            this.btnNetworkOpen.Text = "Open Network";
            this.btnNetworkOpen.Click += new System.EventHandler(this.MenuNetworkOpen_Click);
            // 
            // btnNetworkSave
            // 
            this.btnNetworkSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNetworkSave.Image = global::Sinapse.Properties.Resources.file_export;
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
            this.toolStripTraining.Location = new System.Drawing.Point(211, 0);
            this.toolStripTraining.Name = "toolStripTraining";
            this.toolStripTraining.Size = new System.Drawing.Size(206, 25);
            this.toolStripTraining.TabIndex = 3;
            // 
            // btnTrainForget
            // 
            this.btnTrainForget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainForget.Image = global::Sinapse.Properties.Resources.player_start_16;
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
            // toolStripTesting
            // 
            this.toolStripTesting.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripTesting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTestCompute,
            this.btnTestReport,
            this.toolStripSeparator2,
            this.btnTestRound});
            this.toolStripTesting.Location = new System.Drawing.Point(419, 0);
            this.toolStripTesting.Name = "toolStripTesting";
            this.toolStripTesting.Size = new System.Drawing.Size(91, 25);
            this.toolStripTesting.TabIndex = 2;
            // 
            // btnTestCompute
            // 
            this.btnTestCompute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTestCompute.Image = global::Sinapse.Properties.Resources.restart;
            this.btnTestCompute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTestCompute.Name = "btnTestCompute";
            this.btnTestCompute.Size = new System.Drawing.Size(23, 22);
            this.btnTestCompute.Text = "Compute Testing Set";
            this.btnTestCompute.Click += new System.EventHandler(this.btnTestCompute_Click);
            // 
            // btnTestReport
            // 
            this.btnTestReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTestReport.Image = global::Sinapse.Properties.Resources.switchuser;
            this.btnTestReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTestReport.Name = "btnTestReport";
            this.btnTestReport.Size = new System.Drawing.Size(23, 22);
            this.btnTestReport.Text = "Generate Testing Performance Report";
            this.btnTestReport.Click += new System.EventHandler(this.btnTestReport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTestRound
            // 
            this.btnTestRound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTestRound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdToolStripMenuItem,
            this.btnTestRound10,
            this.btnTestRound25,
            this.btnTestRound50,
            this.btnTestRound75,
            this.btnTestRound90});
            this.btnTestRound.Image = global::Sinapse.Properties.Resources.precminus;
            this.btnTestRound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTestRound.Name = "btnTestRound";
            this.btnTestRound.Size = new System.Drawing.Size(29, 22);
            this.btnTestRound.Text = "Round Results";
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.thresholdToolStripMenuItem.Text = "Threshold";
            // 
            // btnTestRound10
            // 
            this.btnTestRound10.Name = "btnTestRound10";
            this.btnTestRound10.Size = new System.Drawing.Size(141, 22);
            this.btnTestRound10.Tag = 0.1F;
            this.btnTestRound10.Text = "0.10";
            this.btnTestRound10.Click += new System.EventHandler(this.btnTestRound_Click);
            // 
            // btnTestRound25
            // 
            this.btnTestRound25.Name = "btnTestRound25";
            this.btnTestRound25.Size = new System.Drawing.Size(141, 22);
            this.btnTestRound25.Tag = 0.25F;
            this.btnTestRound25.Text = "0.25";
            this.btnTestRound25.Click += new System.EventHandler(this.btnTestRound_Click);
            // 
            // btnTestRound50
            // 
            this.btnTestRound50.Name = "btnTestRound50";
            this.btnTestRound50.Size = new System.Drawing.Size(141, 22);
            this.btnTestRound50.Tag = 0.5F;
            this.btnTestRound50.Text = "0.50";
            this.btnTestRound50.Click += new System.EventHandler(this.btnTestRound_Click);
            // 
            // btnTestRound75
            // 
            this.btnTestRound75.Name = "btnTestRound75";
            this.btnTestRound75.Size = new System.Drawing.Size(141, 22);
            this.btnTestRound75.Tag = 0.75F;
            this.btnTestRound75.Text = "0.75";
            this.btnTestRound75.Click += new System.EventHandler(this.btnTestRound_Click);
            // 
            // btnTestRound90
            // 
            this.btnTestRound90.Name = "btnTestRound90";
            this.btnTestRound90.Size = new System.Drawing.Size(141, 22);
            this.btnTestRound90.Tag = 0.9F;
            this.btnTestRound90.Text = "0.90";
            this.btnTestRound90.Click += new System.EventHandler(this.btnTestRound_Click);
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
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Sinapse Neural Networking Tool";
            this.notifyIcon.Visible = true;
            // 
            // statusBarControl
            // 
            this.statusBarControl.AutoSize = true;
            this.statusBarControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusBarControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBarControl.Location = new System.Drawing.Point(0, 651);
            this.statusBarControl.Name = "statusBarControl";
            this.statusBarControl.Size = new System.Drawing.Size(892, 22);
            this.statusBarControl.TabIndex = 17;
            // 
            // mruProviderDatabase
            // 
            this.mruProviderDatabase.FilePathList = global::Sinapse.Properties.Settings.Default.history_Database;
            this.mruProviderDatabase.MenuItem = this.MenuFileRecentDatabases;
            this.mruProviderDatabase.MenuItemClicked += new Sinapse.Components.MruMenuItemClickedEventHandler(this.mruProviderDatabase_MenuItemClicked);
            // 
            // mruProviderNetwork
            // 
            this.mruProviderNetwork.FilePathList = global::Sinapse.Properties.Settings.Default.history_Networks;
            this.mruProviderNetwork.MenuItem = this.MenuFileRecentNetworks;
            this.mruProviderNetwork.MenuItemClicked += new Sinapse.Components.MruMenuItemClickedEventHandler(this.mruProviderNetwork_MenuItemClicked);
            // 
            // mruProviderWorkplace
            // 
            this.mruProviderWorkplace.FilePathList = global::Sinapse.Properties.Settings.Default.history_Workplace;
            this.mruProviderWorkplace.MenuItem = this.MenuFileRecentWorkplaces;
            this.mruProviderWorkplace.MenuItemClicked += new Sinapse.Components.MruMenuItemClickedEventHandler(this.mruProviderWorkplace_MenuItemClicked);
            // 
            // mruProviderSession
            // 
            this.mruProviderSession.FilePathList = global::Sinapse.Properties.Settings.Default.history_Sessions;
            this.mruProviderSession.MenuItem = this.MenuFileRecentSessions;
            this.mruProviderSession.MenuItemClicked += new Sinapse.Components.MruMenuItemClickedEventHandler(this.mruProviderSession_MenuItemClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 673);
            this.Controls.Add(this.toolStripContainer);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.statusBarControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(200, 200);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "MainForm";
            this.Text = "Sinapse";
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
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.toolStripTraining.ResumeLayout(false);
            this.toolStripTraining.PerformLayout();
            this.toolStripTesting.ResumeLayout(false);
            this.toolStripTesting.PerformLayout();
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
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripButton btnDatabaseSave;
        private System.Windows.Forms.ToolStripButton btnNetworkNew;
        private System.Windows.Forms.ToolStripButton btnWizard;
        private Sinapse.Controls.MainTabControl.MainTabControl tabControlMain;
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
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplaceSave;
        private System.Windows.Forms.ToolStripMenuItem MenuDatabaseSave;
        private System.Windows.Forms.SaveFileDialog saveDatabaseDialog;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.FolderBrowserDialog browseWorkplaceDialog;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator2;
        private System.Windows.Forms.ToolStripButton btnDatabaseNew;
        private System.Windows.Forms.ToolStripButton btnNetworkOpen;
        private System.Windows.Forms.ToolStripButton btnSaveAll;
        private Sinapse.Controls.SideTabControl.SideTabControl tabControlSide;
        private Sinapse.Components.MruProvider mruProviderDatabase;
        private Sinapse.Components.MruProvider mruProviderNetwork;
        private Sinapse.Components.MruProvider mruProviderWorkplace;
        private System.Windows.Forms.ToolStrip toolStripTesting;
        private System.Windows.Forms.ToolStripButton btnTestCompute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton btnTestRound;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnTestRound10;
        private System.Windows.Forms.ToolStripMenuItem btnTestRound25;
        private System.Windows.Forms.ToolStripMenuItem btnTestRound50;
        private System.Windows.Forms.ToolStripMenuItem btnTestRound75;
        private System.Windows.Forms.ToolStripMenuItem btnTestRound90;
        private System.Windows.Forms.ToolStripButton btnTestReport;
        private System.Windows.Forms.ToolStrip toolStripTraining;
        private System.Windows.Forms.ToolStripButton btnTrainForget;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton btnTrainBack;
        private System.Windows.Forms.ToolStripButton btnTrainStart;
        private System.Windows.Forms.ToolStripButton btnTrainPause;
        private System.Windows.Forms.ToolStripButton btnTrainStop;
        private System.Windows.Forms.ToolStripButton btnTrainNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnTrainGraph;
        private System.Windows.Forms.ToolStripButton btnTrainQuery;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSessionNew;
        private System.Windows.Forms.ToolStripMenuItem MenuSessionOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSessionSave;
        private System.Windows.Forms.ToolStripMenuItem MenuSessionSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkCodeGenerator;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkCodeGeneratorANSIC;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkCodeGeneratorCpp;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkCodeGeneratorCSharp;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkCodeGeneratorJava;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkCodeGeneratorMatlab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkCodeGeneratorOptions;
        private System.Windows.Forms.ToolStripMenuItem MenuSessionProperties;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentSessions;
        private Sinapse.Components.MruProvider mruProviderSession;
        private System.Windows.Forms.ToolStripMenuItem MenuSessionClose;
        private System.Windows.Forms.ToolStripMenuItem MenuFileDatabaseClose;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkClose;
        private System.Windows.Forms.ToolStripMenuItem MenuFilePreferences;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkplaceClose;
    }
}