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
            this.MenuFileNewWorkplace = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpenWorkplace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileWizard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileCloseWorkplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileRecentDatabases = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileRecentWorkplaces = new System.Windows.Forms.ToolStripMenuItem();
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
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mruProviderDatasource = new Sinapse.Forms.Controls.MruComponent();
            this.mruProviderSystem = new Sinapse.Forms.Controls.MruComponent();
            this.mruProviderWorkplace = new Sinapse.Forms.Controls.MruComponent();
            this.mruProviderTrainingSession = new Sinapse.Forms.Controls.MruComponent();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnDatabaseNew = new System.Windows.Forms.ToolStripButton();
            this.btnDatabaseOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWizard = new System.Windows.Forms.ToolStripButton();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.dockMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openWorkplaceDialog = new System.Windows.Forms.OpenFileDialog();
            this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilePreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
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
            this.openToolStripMenuItem,
            this.MenuFileWizard,
            this.toolStripSeparator1,
            this.MenuFileCloseWorkplace,
            this.toolStripSeparator6,
            this.MenuFileSave,
            this.MenuFileSaveAs,
            this.MenuFileSaveAll,
            this.MenuFileSeparator1,
            this.MenuFileRecentDatabases,
            this.MenuFileRecentWorkplaces,
            this.MenuFileSeparator2,
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(35, 20);
            this.MenuFile.Text = "&File";
            // 
            // newWorkplaceToolStripMenuItem
            // 
            this.newWorkplaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNewWorkplace,
            this.systemToolStripMenuItem,
            this.dataSourceToolStripMenuItem,
            this.trainingSessionToolStripMenuItem});
            this.newWorkplaceToolStripMenuItem.Name = "newWorkplaceToolStripMenuItem";
            this.newWorkplaceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newWorkplaceToolStripMenuItem.Text = "New";
            // 
            // MenuFileNewWorkplace
            // 
            this.MenuFileNewWorkplace.Name = "MenuFileNewWorkplace";
            this.MenuFileNewWorkplace.Size = new System.Drawing.Size(135, 22);
            this.MenuFileNewWorkplace.Text = "Workplace";
            this.MenuFileNewWorkplace.Click += new System.EventHandler(this.MenuFileNewWorkplace_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Enabled = false;
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // dataSourceToolStripMenuItem
            // 
            this.dataSourceToolStripMenuItem.Enabled = false;
            this.dataSourceToolStripMenuItem.Name = "dataSourceToolStripMenuItem";
            this.dataSourceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.dataSourceToolStripMenuItem.Text = "Source";
            // 
            // trainingSessionToolStripMenuItem
            // 
            this.trainingSessionToolStripMenuItem.Enabled = false;
            this.trainingSessionToolStripMenuItem.Name = "trainingSessionToolStripMenuItem";
            this.trainingSessionToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.trainingSessionToolStripMenuItem.Text = "Session";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileOpenWorkplace});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // MenuFileOpenWorkplace
            // 
            this.MenuFileOpenWorkplace.Name = "MenuFileOpenWorkplace";
            this.MenuFileOpenWorkplace.Size = new System.Drawing.Size(135, 22);
            this.MenuFileOpenWorkplace.Text = "Workplace";
            this.MenuFileOpenWorkplace.Click += new System.EventHandler(this.MenuFileOpenWorkplace_Click);
            // 
            // MenuFileWizard
            // 
            this.MenuFileWizard.Image = global::Sinapse.Properties.Resources.wizard;
            this.MenuFileWizard.Name = "MenuFileWizard";
            this.MenuFileWizard.Size = new System.Drawing.Size(177, 22);
            this.MenuFileWizard.Text = "Run &Wizard...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuFileCloseWorkplace
            // 
            this.MenuFileCloseWorkplace.Name = "MenuFileCloseWorkplace";
            this.MenuFileCloseWorkplace.Size = new System.Drawing.Size(177, 22);
            this.MenuFileCloseWorkplace.Text = "Close Workplace";
            this.MenuFileCloseWorkplace.Click += new System.EventHandler(this.MenuFileCloseWorkplace_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuFileSeparator1
            // 
            this.MenuFileSeparator1.Name = "MenuFileSeparator1";
            this.MenuFileSeparator1.Size = new System.Drawing.Size(174, 6);
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
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.MenuFilePreferences});
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
            // openDatabaseDialog
            // 
            this.openDatabaseDialog.DefaultExt = "sdo";
            this.openDatabaseDialog.Filter = "Sinapse Database Objects (*.sdo)|*.sdo|All Files (*.*)|*.*";
            this.openDatabaseDialog.Title = "Open Database";
            this.openDatabaseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openDatabaseDialog_FileOk);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Sinapse Neural Networking Tool";
            this.notifyIcon.Visible = true;
            // 
            // mruProviderDatasource
            // 
            this.mruProviderDatasource.Files = global::Sinapse.Properties.Settings.Default.history_Database;
            this.mruProviderDatasource.KeyMenuItem = this.MenuFileRecentDatabases;
            this.mruProviderDatasource.MaxPathLength = 96;
            this.mruProviderDatasource.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderDatabase_MenuItemClicked);
            // 
            // mruProviderSystem
            // 
            this.mruProviderSystem.Files = global::Sinapse.Properties.Settings.Default.history_Networks;
            this.mruProviderSystem.MaxPathLength = 96;
            this.mruProviderSystem.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderNetwork_MenuItemClicked);
            // 
            // mruProviderWorkplace
            // 
            this.mruProviderWorkplace.Files = global::Sinapse.Properties.Settings.Default.history_Workplace;
            this.mruProviderWorkplace.KeyMenuItem = this.MenuFileRecentWorkplaces;
            this.mruProviderWorkplace.MaxPathLength = 96;
            this.mruProviderWorkplace.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderWorkplace_MenuItemClicked);
            // 
            // mruProviderTrainingSession
            // 
            this.mruProviderTrainingSession.Files = global::Sinapse.Properties.Settings.Default.history_Sessions;
            this.mruProviderTrainingSession.MaxPathLength = 96;
            this.mruProviderTrainingSession.MenuItemClicked += new Sinapse.Forms.Controls.MruMenuItemClickedEventHandler(this.mruProviderSession_MenuItemClicked);
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
            this.btnSave,
            this.btnSaveAll,
            this.toolStripSeparator8,
            this.btnWizard});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(133, 25);
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
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::Sinapse.Properties.Resources.file_save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.MenuFileSave_Click);
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
            // openWorkplaceDialog
            // 
            this.openWorkplaceDialog.DefaultExt = "swp";
            this.openWorkplaceDialog.FileName = "Workplace";
            this.openWorkplaceDialog.Filter = "Sinapse Workplace (*.swp)|*.swp|All files (*.*)|*.*";
            // 
            // MenuFileSave
            // 
            this.MenuFileSave.Name = "MenuFileSave";
            this.MenuFileSave.Size = new System.Drawing.Size(177, 22);
            this.MenuFileSave.Text = "Save";
            this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
            // 
            // MenuFileSaveAll
            // 
            this.MenuFileSaveAll.Name = "MenuFileSaveAll";
            this.MenuFileSaveAll.Size = new System.Drawing.Size(177, 22);
            this.MenuFileSaveAll.Text = "Save All";
            this.MenuFileSaveAll.Click += new System.EventHandler(this.MenuFileSaveAll_Click);
            // 
            // MenuFilePreferences
            // 
            this.MenuFilePreferences.Image = global::Sinapse.Properties.Resources.configure_16;
            this.MenuFilePreferences.Name = "MenuFilePreferences";
            this.MenuFilePreferences.Size = new System.Drawing.Size(152, 22);
            this.MenuFilePreferences.Text = "Preferences";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // MenuFileSaveAs
            // 
            this.MenuFileSaveAs.Name = "MenuFileSaveAs";
            this.MenuFileSaveAs.Size = new System.Drawing.Size(177, 22);
            this.MenuFileSaveAs.Text = "Save As...";
            this.MenuFileSaveAs.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
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
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentDatabases;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRecentWorkplaces;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileWizard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator2;
        private Sinapse.Forms.Controls.MruComponent mruProviderDatasource;
        private Sinapse.Forms.Controls.MruComponent mruProviderSystem;
        private Sinapse.Forms.Controls.MruComponent mruProviderWorkplace;
        private Sinapse.Forms.Controls.MruComponent mruProviderTrainingSession;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.ToolStripMenuItem MenuExtensionsExcel;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWorkplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFileNewWorkplace;
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
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnWizard;
        private System.Windows.Forms.ToolStripPanel toolStripPanel1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockMain;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpenWorkplace;
        private System.Windows.Forms.OpenFileDialog openWorkplaceDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCloseWorkplace;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveAll;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuFilePreferences;
    }
}