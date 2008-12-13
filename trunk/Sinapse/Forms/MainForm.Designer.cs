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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newWorkplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileWizard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileRecentDatabases = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileRecentWorkplaces = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFilePreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExtensionsExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveNetworkDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseWorkplaceDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mruProviderDatabase = new Sinapse.Forms.Controls.MruComponent();
            this.mruProviderNetwork = new Sinapse.Forms.Controls.MruComponent();
            this.mruProviderWorkplace = new Sinapse.Forms.Controls.MruComponent();
            this.mruProviderSession = new Sinapse.Forms.Controls.MruComponent();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
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
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.dockMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelTitle.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.toolStripPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.DarkBlue;
            this.panelTitle.Controls.Add(this.lbVersion);
            this.panelTitle.Controls.Add(this.lbTitle);
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
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.MenuExtensionsExcel,
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
            this.newWorkplaceToolStripMenuItem,
            this.MenuFileWizard,
            this.toolStripSeparator6,
            this.MenuFileRecentDatabases,
            this.MenuFileRecentWorkplaces,
            this.MenuFileSeparator1,
            this.MenuFilePreferences,
            this.MenuFileSeparator2,
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(35, 20);
            this.MenuFile.Text = "&File";
            // 
            // newWorkplaceToolStripMenuItem
            // 
            this.newWorkplaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workplaceToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.dataSourceToolStripMenuItem,
            this.trainingSessionToolStripMenuItem});
            this.newWorkplaceToolStripMenuItem.Name = "newWorkplaceToolStripMenuItem";
            this.newWorkplaceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newWorkplaceToolStripMenuItem.Text = "New";
            // 
            // workplaceToolStripMenuItem
            // 
            this.workplaceToolStripMenuItem.Name = "workplaceToolStripMenuItem";
            this.workplaceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.workplaceToolStripMenuItem.Text = "Workplace";
            this.workplaceToolStripMenuItem.Click += new System.EventHandler(this.workplaceToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.systemToolStripMenuItem.Text = "System";
            this.systemToolStripMenuItem.Click += new System.EventHandler(this.systemToolStripMenuItem_Click);
            // 
            // dataSourceToolStripMenuItem
            // 
            this.dataSourceToolStripMenuItem.Name = "dataSourceToolStripMenuItem";
            this.dataSourceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.dataSourceToolStripMenuItem.Text = "Source";
            // 
            // trainingSessionToolStripMenuItem
            // 
            this.trainingSessionToolStripMenuItem.Name = "trainingSessionToolStripMenuItem";
            this.trainingSessionToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.trainingSessionToolStripMenuItem.Text = "Session";
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // MenuExtensionsExcel
            // 
            this.MenuExtensionsExcel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem});
            this.MenuExtensionsExcel.Enabled = false;
            this.MenuExtensionsExcel.Name = "MenuExtensionsExcel";
            this.MenuExtensionsExcel.Size = new System.Drawing.Size(71, 20);
            this.MenuExtensionsExcel.Text = "Extensions";
            this.MenuExtensionsExcel.Click += new System.EventHandler(this.MenuExtensionsExcel_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.excelToolStripMenuItem.Text = "Sinapse for Excel";
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
            // mruProviderDatabase
            // 
            this.mruProviderDatabase.Files = global::Sinapse.Properties.Settings.Default.history_Database;
            this.mruProviderDatabase.KeyMenuItem = this.MenuFileRecentDatabases;
            this.mruProviderDatabase.MaxPathLength = 96;
            this.mruProviderDatabase.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderDatabase_MenuItemClicked);
            // 
            // mruProviderNetwork
            // 
            this.mruProviderNetwork.Files = global::Sinapse.Properties.Settings.Default.history_Networks;
            this.mruProviderNetwork.MaxPathLength = 96;
            this.mruProviderNetwork.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderNetwork_MenuItemClicked);
            // 
            // mruProviderWorkplace
            // 
            this.mruProviderWorkplace.Files = global::Sinapse.Properties.Settings.Default.history_Workplace;
            this.mruProviderWorkplace.KeyMenuItem = this.MenuFileRecentWorkplaces;
            this.mruProviderWorkplace.MaxPathLength = 96;
            this.mruProviderWorkplace.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderWorkplace_MenuItemClicked);
            // 
            // mruProviderSession
            // 
            this.mruProviderSession.Files = global::Sinapse.Properties.Settings.Default.history_Sessions;
            this.mruProviderSession.MaxPathLength = 96;
            this.mruProviderSession.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderSession_MenuItemClicked);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 25);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(892, 577);
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
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(208, 25);
            this.toolStripMain.TabIndex = 19;
            // 
            // btnDatabaseNew
            // 
            this.btnDatabaseNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDatabaseNew.Image = global::Sinapse.Properties.Resources.file_new;
            this.btnDatabaseNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatabaseNew.Name = "btnDatabaseNew";
            this.btnDatabaseNew.Size = new System.Drawing.Size(23, 22);
            this.btnDatabaseNew.Text = "New Database";
            // 
            // btnDatabaseOpen
            // 
            this.btnDatabaseOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDatabaseOpen.Image = global::Sinapse.Properties.Resources.file_open;
            this.btnDatabaseOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatabaseOpen.Name = "btnDatabaseOpen";
            this.btnDatabaseOpen.Size = new System.Drawing.Size(23, 22);
            this.btnDatabaseOpen.Text = "Open Database";
            // 
            // btnDatabaseSave
            // 
            this.btnDatabaseSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDatabaseSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.btnDatabaseSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatabaseSave.Name = "btnDatabaseSave";
            this.btnDatabaseSave.Size = new System.Drawing.Size(23, 22);
            this.btnDatabaseSave.Text = "Save Database";
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAll.Image = global::Sinapse.Properties.Resources.file_saveall;
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
            // 
            // btnNetworkOpen
            // 
            this.btnNetworkOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNetworkOpen.Image = global::Sinapse.Properties.Resources.file_import;
            this.btnNetworkOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNetworkOpen.Name = "btnNetworkOpen";
            this.btnNetworkOpen.Size = new System.Drawing.Size(23, 22);
            this.btnNetworkOpen.Text = "Open Network";
            // 
            // btnNetworkSave
            // 
            this.btnNetworkSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNetworkSave.Image = global::Sinapse.Properties.Resources.file_export;
            this.btnNetworkSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNetworkSave.Name = "btnNetworkSave";
            this.btnNetworkSave.Size = new System.Drawing.Size(23, 22);
            this.btnNetworkSave.Text = "Save Network";
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
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Controls.Add(this.toolStripMain);
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 74);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(0);
            this.toolStripPanel1.Size = new System.Drawing.Size(892, 25);
            // 
            // dockMain
            // 
            this.dockMain.ActiveAutoHideContent = null;
            this.dockMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockMain.Location = new System.Drawing.Point(0, 99);
            this.dockMain.Name = "dockMain";
            this.dockMain.Size = new System.Drawing.Size(892, 574);
            this.dockMain.TabIndex = 21;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 673);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dockMain);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelTitle);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(200, 200);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "MainForm";
            this.Text = "Sinapse";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.toolStripPanel1.ResumeLayout(false);
            this.toolStripPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpContents;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpIndex;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpSearch;
        private System.Windows.Forms.ToolStripSeparator MenuHelpSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private System.Windows.Forms.OpenFileDialog openNetworkDialog;
        private System.Windows.Forms.SaveFileDialog saveNetworkDialog;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentDatabases;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentWorkplaces;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileWizard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.SaveFileDialog saveDatabaseDialog;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.FolderBrowserDialog browseWorkplaceDialog;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator2;
        private Sinapse.Forms.Controls.MruComponent mruProviderDatabase;
        private Sinapse.Forms.Controls.MruComponent mruProviderNetwork;
        private Sinapse.Forms.Controls.MruComponent mruProviderWorkplace;
        private Sinapse.Forms.Controls.MruComponent mruProviderSession;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.ToolStripMenuItem MenuFilePreferences;
        private System.Windows.Forms.ToolStripMenuItem MenuExtensionsExcel;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem newWorkplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnDatabaseNew;
        private System.Windows.Forms.ToolStripButton btnDatabaseOpen;
        private System.Windows.Forms.ToolStripButton btnDatabaseSave;
        private System.Windows.Forms.ToolStripButton btnSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnNetworkNew;
        private System.Windows.Forms.ToolStripButton btnNetworkOpen;
        private System.Windows.Forms.ToolStripButton btnNetworkSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnWizard;
        private System.Windows.Forms.ToolStripPanel toolStripPanel1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockMain;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}