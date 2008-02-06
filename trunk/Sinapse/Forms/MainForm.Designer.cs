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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNetworkName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbNeuronCount = new System.Windows.Forms.Label();
            this.lbInputCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbOutputCount = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lbStatusEpoch = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusError = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.tabSetImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTraining = new System.Windows.Forms.ToolStrip();
            this.btnTrainForget = new System.Windows.Forms.ToolStripButton();
            this.btnTrainStart = new System.Windows.Forms.ToolStripButton();
            this.btnTrainPause = new System.Windows.Forms.ToolStripButton();
            this.btnTrainStop = new System.Windows.Forms.ToolStripButton();
            this.btnTrainQuery = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tcSidebar = new Dotnetrix.Controls.TabControlEX();
            this.tabStatus = new Dotnetrix.Controls.TabPageEX();
            this.networkDisplayControl = new Sinapse.Controls.Sidebar.SideDisplayControl();
            this.tabData = new Dotnetrix.Controls.TabPageEX();
            this.networkRangesControl = new Sinapse.Controls.Sidebar.SideRangesControl();
            this.tabSets = new Dotnetrix.Controls.TabPageEX();
            this.tabTraining = new Dotnetrix.Controls.TabPageEX();
            this.networkTrainerControl = new Sinapse.Controls.Sidebar.SideTrainerControl();
            this.trainingTabControl = new Sinapse.Controls.TrainingTabs.TrainingTabControl();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.toolStripTraining.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tcSidebar.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tabTraining.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Controls.Add(this.lbNetworkName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbNeuronCount);
            this.panel1.Controls.Add(this.lbInputCount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbOutputCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 50);
            this.panel1.TabIndex = 5;
            // 
            // lbNetworkName
            // 
            this.lbNetworkName.AutoSize = true;
            this.lbNetworkName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNetworkName.ForeColor = System.Drawing.SystemColors.Window;
            this.lbNetworkName.Location = new System.Drawing.Point(12, 8);
            this.lbNetworkName.Name = "lbNetworkName";
            this.lbNetworkName.Size = new System.Drawing.Size(397, 29);
            this.lbNetworkName.TabIndex = 0;
            this.lbNetworkName.Text = "Sinapse Neural Networking Tool";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(718, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Neurons:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Location = new System.Drawing.Point(829, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Inputs:";
            // 
            // lbNeuronCount
            // 
            this.lbNeuronCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNeuronCount.AutoSize = true;
            this.lbNeuronCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbNeuronCount.Location = new System.Drawing.Point(782, 31);
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
            this.lbInputCount.Location = new System.Drawing.Point(877, 31);
            this.lbInputCount.Name = "lbInputCount";
            this.lbInputCount.Size = new System.Drawing.Size(19, 13);
            this.lbInputCount.TabIndex = 0;
            this.lbInputCount.Text = "00";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.AliceBlue;
            this.label8.Location = new System.Drawing.Point(924, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Outputs:";
            // 
            // lbOutputCount
            // 
            this.lbOutputCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOutputCount.AutoSize = true;
            this.lbOutputCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbOutputCount.Location = new System.Drawing.Point(981, 31);
            this.lbOutputCount.Name = "lbOutputCount";
            this.lbOutputCount.Size = new System.Drawing.Size(19, 13);
            this.lbOutputCount.TabIndex = 0;
            this.lbOutputCount.Text = "00";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.progressBar,
            this.lbStatusEpoch,
            this.lbStatusError,
            this.lbItems,
            this.toolStripDropDownButton1});
            this.statusStrip.Location = new System.Drawing.Point(0, 644);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.DoubleClick += new System.EventHandler(this.Show_VisualOptions);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = false;
            this.lbStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(250, 17);
            this.lbStatus.Text = "Status";
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lbStatusEpoch
            // 
            this.lbStatusEpoch.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbStatusEpoch.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbStatusEpoch.Name = "lbStatusEpoch";
            this.lbStatusEpoch.Size = new System.Drawing.Size(61, 17);
            this.lbStatusEpoch.Spring = true;
            // 
            // lbStatusError
            // 
            this.lbStatusError.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbStatusError.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbStatusError.Name = "lbStatusError";
            this.lbStatusError.Size = new System.Drawing.Size(61, 17);
            this.lbStatusError.Spring = true;
            // 
            // lbItems
            // 
            this.lbItems.AutoSize = false;
            this.lbItems.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbItems.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(80, 17);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Image = global::Sinapse.Properties.Resources.greenled;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(96, 17);
            this.toolStripDropDownButton1.Text = "Network Active";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuNetwork,
            this.MenuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 50);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNew,
            this.MenuFileOpen,
            this.toolStripSeparator,
            this.MenuFileSave,
            this.MenuFileSaveAs,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(35, 20);
            this.MenuFile.Text = "&File";
            // 
            // MenuFileNew
            // 
            this.MenuFileNew.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileNew.Image")));
            this.MenuFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileNew.Name = "MenuFileNew";
            this.MenuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MenuFileNew.Size = new System.Drawing.Size(151, 22);
            this.MenuFileNew.Text = "&New";
            this.MenuFileNew.Click += new System.EventHandler(this.MenuFileNew_Click);
            // 
            // MenuFileOpen
            // 
            this.MenuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileOpen.Image")));
            this.MenuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileOpen.Name = "MenuFileOpen";
            this.MenuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuFileOpen.Size = new System.Drawing.Size(151, 22);
            this.MenuFileOpen.Text = "&Open";
            this.MenuFileOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // MenuFileSave
            // 
            this.MenuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileSave.Image")));
            this.MenuFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileSave.Name = "MenuFileSave";
            this.MenuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuFileSave.Size = new System.Drawing.Size(151, 22);
            this.MenuFileSave.Text = "&Save";
            this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
            // 
            // MenuFileSaveAs
            // 
            this.MenuFileSaveAs.Name = "MenuFileSaveAs";
            this.MenuFileSaveAs.Size = new System.Drawing.Size(151, 22);
            this.MenuFileSaveAs.Text = "Save &As";
            this.MenuFileSaveAs.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(151, 22);
            this.MenuFileExit.Text = "E&xit";
            // 
            // MenuNetwork
            // 
            this.MenuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNetworkNew,
            this.MenuNetworkQuery});
            this.MenuNetwork.Name = "MenuNetwork";
            this.MenuNetwork.Size = new System.Drawing.Size(59, 20);
            this.MenuNetwork.Text = "Network";
            // 
            // MenuNetworkNew
            // 
            this.MenuNetworkNew.Name = "MenuNetworkNew";
            this.MenuNetworkNew.Size = new System.Drawing.Size(115, 22);
            this.MenuNetworkNew.Text = "New";
            this.MenuNetworkNew.Click += new System.EventHandler(this.MenuNetworkNew_Click);
            // 
            // MenuNetworkQuery
            // 
            this.MenuNetworkQuery.Name = "MenuNetworkQuery";
            this.MenuNetworkQuery.Size = new System.Drawing.Size(115, 22);
            this.MenuNetworkQuery.Text = "Query";
            this.MenuNetworkQuery.Click += new System.EventHandler(this.MenuNetworkQuery_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(40, 20);
            this.MenuHelp.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Enabled = false;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Enabled = false;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(129, 22);
            this.MenuHelpAbout.Text = "&About...";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ann";
            this.openFileDialog.Filter = "Network Objects (*.ann)|*.ann|All Files (*.*)|*.*";
            this.openFileDialog.Title = "Open Network Object";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Network Objects (*.ann)|*.ann|All Files (*.*)|*.*";
            this.saveFileDialog.Title = "Save Network Object";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1016, 545);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 74);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1016, 570);
            this.toolStripContainer.TabIndex = 16;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripMain);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripTraining);
            this.toolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 25);
            // 
            // tabSetImageList
            // 
            this.tabSetImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabSetImageList.ImageStream")));
            this.tabSetImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabSetImageList.Images.SetKeyName(0, "Training.png");
            this.tabSetImageList.Images.SetKeyName(1, "Validating.png");
            this.tabSetImageList.Images.SetKeyName(2, "Testing.png");
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnLoad,
            this.btnImport,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(3, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(125, 25);
            this.toolStripMain.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::Sinapse.Properties.Resources.filenew;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "New";
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoad.Image = global::Sinapse.Properties.Resources.folder;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(23, 22);
            this.btnLoad.Text = "toolStripButton2";
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImport.Image = global::Sinapse.Properties.Resources.webexport_16;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(23, 22);
            this.btnImport.Text = "toolStripButton1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Sinapse.Properties.Resources.network_16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripTraining
            // 
            this.toolStripTraining.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripTraining.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTrainForget,
            this.btnTrainStart,
            this.btnTrainPause,
            this.btnTrainStop,
            this.btnTrainQuery});
            this.toolStripTraining.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripTraining.Location = new System.Drawing.Point(128, 0);
            this.toolStripTraining.Name = "toolStripTraining";
            this.toolStripTraining.Size = new System.Drawing.Size(125, 25);
            this.toolStripTraining.TabIndex = 1;
            // 
            // btnTrainForget
            // 
            this.btnTrainForget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainForget.Image = global::Sinapse.Properties.Resources.player_rew_16;
            this.btnTrainForget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainForget.Name = "btnTrainForget";
            this.btnTrainForget.Size = new System.Drawing.Size(23, 22);
            this.btnTrainForget.Text = "Forget";
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
            this.btnTrainStop.Image = global::Sinapse.Properties.Resources.player_stop1;
            this.btnTrainStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainStop.Name = "btnTrainStop";
            this.btnTrainStop.Size = new System.Drawing.Size(23, 22);
            this.btnTrainStop.Text = "Stop Training";
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
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tcSidebar);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.trainingTabControl);
            this.splitContainer.Size = new System.Drawing.Size(1016, 545);
            this.splitContainer.SplitterDistance = 236;
            this.splitContainer.TabIndex = 17;
            // 
            // tcSidebar
            // 
            this.tcSidebar.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcSidebar.Appearance = Dotnetrix.Controls.TabAppearanceEX.Bevel;
            this.tcSidebar.AutoLoadTabPages = true;
            this.tcSidebar.Controls.Add(this.tabStatus);
            this.tcSidebar.Controls.Add(this.tabData);
            this.tcSidebar.Controls.Add(this.tabSets);
            this.tcSidebar.Controls.Add(this.tabTraining);
            this.tcSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSidebar.HotColor = System.Drawing.SystemColors.MenuHighlight;
            this.tcSidebar.HotTrack = true;
            this.tcSidebar.Location = new System.Drawing.Point(0, 0);
            this.tcSidebar.Multiline = true;
            this.tcSidebar.Name = "tcSidebar";
            this.tcSidebar.SelectedIndex = 0;
            this.tcSidebar.Size = new System.Drawing.Size(236, 545);
            this.tcSidebar.TabIndex = 16;
            this.tcSidebar.UseVisualStyles = false;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.networkDisplayControl);
            this.tabStatus.Location = new System.Drawing.Point(27, 4);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(205, 537);
            this.tabStatus.TabIndex = 1;
            this.tabStatus.Text = "Network Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // networkDisplayControl
            // 
            this.networkDisplayControl.BackColor = System.Drawing.SystemColors.Window;
            this.networkDisplayControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.networkDisplayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkDisplayControl.Enabled = false;
            this.networkDisplayControl.Location = new System.Drawing.Point(3, 3);
            this.networkDisplayControl.Name = "networkDisplayControl";
            this.networkDisplayControl.ReadOnly = false;
            this.networkDisplayControl.Size = new System.Drawing.Size(199, 531);
            this.networkDisplayControl.TabIndex = 16;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.networkRangesControl);
            this.tabData.Location = new System.Drawing.Point(27, 4);
            this.tabData.Name = "tabData";
            this.tabData.Size = new System.Drawing.Size(205, 537);
            this.tabData.TabIndex = 3;
            this.tabData.Text = "Training Data";
            // 
            // networkRangesControl
            // 
            this.networkRangesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkRangesControl.Enabled = false;
            this.networkRangesControl.Location = new System.Drawing.Point(0, 0);
            this.networkRangesControl.Name = "networkRangesControl";
            this.networkRangesControl.ReadOnly = false;
            this.networkRangesControl.Size = new System.Drawing.Size(205, 537);
            this.networkRangesControl.TabIndex = 15;
            // 
            // tabSets
            // 
            this.tabSets.Location = new System.Drawing.Point(27, 4);
            this.tabSets.Name = "tabSets";
            this.tabSets.Size = new System.Drawing.Size(205, 537);
            this.tabSets.TabIndex = 4;
            this.tabSets.Text = "Training Sets";
            // 
            // tabTraining
            // 
            this.tabTraining.Controls.Add(this.networkTrainerControl);
            this.tabTraining.Location = new System.Drawing.Point(27, 4);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Size = new System.Drawing.Size(205, 537);
            this.tabTraining.TabIndex = 0;
            this.tabTraining.Text = "Network Trainer";
            this.tabTraining.UseVisualStyleBackColor = true;
            // 
            // networkTrainerControl
            // 
            this.networkTrainerControl.BackColor = System.Drawing.SystemColors.Control;
            this.networkTrainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkTrainerControl.Enabled = false;
            this.networkTrainerControl.Location = new System.Drawing.Point(0, 0);
            this.networkTrainerControl.Name = "networkTrainerControl";
            this.networkTrainerControl.Size = new System.Drawing.Size(205, 537);
            this.networkTrainerControl.TabIndex = 12;
            // 
            // trainingTabControl
            // 
            this.trainingTabControl.Appearance = Dotnetrix.Controls.TabAppearanceEX.Bevel;
            this.trainingTabControl.AutoLoadTabPages = true;
            this.trainingTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainingTabControl.HotColor = System.Drawing.SystemColors.MenuHighlight;
            this.trainingTabControl.ImageList = this.tabSetImageList;
            this.trainingTabControl.Location = new System.Drawing.Point(0, 0);
            this.trainingTabControl.Name = "trainingTabControl";
            this.trainingTabControl.Size = new System.Drawing.Size(776, 545);
            this.trainingTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.trainingTabControl.TabIndex = 0;
            this.trainingTabControl.UseVisualStyles = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 666);
            this.Controls.Add(this.toolStripContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Sinapse.Properties.Settings.Default, "Main_Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("WindowState", global::Sinapse.Properties.Settings.Default, "Main_windowState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::Sinapse.Properties.Settings.Default.Main_Location;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "MainForm";
            this.Text = "Sinapse";
            this.WindowState = global::Sinapse.Properties.Settings.Default.Main_windowState;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.toolStripTraining.ResumeLayout(false);
            this.toolStripTraining.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.tcSidebar.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabTraining.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNetworkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbInputCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbOutputCount;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusEpoch;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusError;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuNetwork;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileNew;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkQuery;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private Sinapse.Controls.Sidebar.SideTrainerControl networkTrainerControl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNeuronCount;
        private System.Windows.Forms.ToolStripStatusLabel lbItems;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStrip toolStripTraining;
        private System.Windows.Forms.ToolStripButton btnTrainStart;
        private System.Windows.Forms.ToolStripButton btnTrainPause;
        private System.Windows.Forms.ToolStripButton btnTrainStop;
        private System.Windows.Forms.ToolStripButton btnTrainForget;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkNew;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Dotnetrix.Controls.TabControlEX tcSidebar;
        private Dotnetrix.Controls.TabPageEX tabTraining;
        private Dotnetrix.Controls.TabPageEX tabStatus;
        private Dotnetrix.Controls.TabPageEX tabData;
        private Sinapse.Controls.Sidebar.SideRangesControl networkRangesControl;
        private Sinapse.Controls.Sidebar.SideDisplayControl networkDisplayControl;
        private Dotnetrix.Controls.TabPageEX tabSets;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnTrainQuery;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private Sinapse.Controls.TrainingTabs.TrainingTabControl trainingTabControl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDropDownButton1;
        private System.Windows.Forms.ImageList tabSetImageList;
    }
}