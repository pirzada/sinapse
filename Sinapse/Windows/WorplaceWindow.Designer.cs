namespace Sinapse.Windows
{
    partial class WorkplaceWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkplaceWindow));
            this.treeViewWorkplace = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAddSourceTable = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAddSystemActivation = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceActivationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neocognitronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.menuSource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuTraining = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuSource.SuspendLayout();
            this.menuTraining.SuspendLayout();
            this.menuSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewWorkplace
            // 
            this.treeViewWorkplace.ImageIndex = 0;
            this.treeViewWorkplace.ImageList = this.imageList;
            this.treeViewWorkplace.Location = new System.Drawing.Point(0, 25);
            this.treeViewWorkplace.Name = "treeViewWorkplace";
            this.treeViewWorkplace.SelectedImageIndex = 0;
            this.treeViewWorkplace.Size = new System.Drawing.Size(273, 357);
            this.treeViewWorkplace.TabIndex = 0;
            this.treeViewWorkplace.DoubleClick += new System.EventHandler(this.treeViewWorkplace_DoubleClick);
            this.treeViewWorkplace.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewWorkplace_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Workspace");
            this.imageList.Images.SetKeyName(1, "Folder");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(273, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Sinapse.Properties.Resources.documentinfo;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Properties";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Sinapse.Properties.Resources.reload;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Refresh";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSourceTable,
            this.imageSourceToolStripMenuItem,
            this.videoSourceToolStripMenuItem,
            this.soundSourceToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Add Source";
            // 
            // btnAddSourceTable
            // 
            this.btnAddSourceTable.Name = "btnAddSourceTable";
            this.btnAddSourceTable.Size = new System.Drawing.Size(151, 22);
            this.btnAddSourceTable.Text = "Table Source";
            this.btnAddSourceTable.Click += new System.EventHandler(this.btnAddSourceTable_Click);
            // 
            // imageSourceToolStripMenuItem
            // 
            this.imageSourceToolStripMenuItem.Enabled = false;
            this.imageSourceToolStripMenuItem.Name = "imageSourceToolStripMenuItem";
            this.imageSourceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.imageSourceToolStripMenuItem.Text = "Image Source";
            // 
            // videoSourceToolStripMenuItem
            // 
            this.videoSourceToolStripMenuItem.Enabled = false;
            this.videoSourceToolStripMenuItem.Name = "videoSourceToolStripMenuItem";
            this.videoSourceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.videoSourceToolStripMenuItem.Text = "Video Source";
            // 
            // soundSourceToolStripMenuItem
            // 
            this.soundSourceToolStripMenuItem.Enabled = false;
            this.soundSourceToolStripMenuItem.Name = "soundSourceToolStripMenuItem";
            this.soundSourceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.soundSourceToolStripMenuItem.Text = "Sound Source";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSystemActivation,
            this.distanceActivationToolStripMenuItem,
            this.neocognitronToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton2.Text = "Add System";
            // 
            // btnAddSystemActivation
            // 
            this.btnAddSystemActivation.Name = "btnAddSystemActivation";
            this.btnAddSystemActivation.Size = new System.Drawing.Size(176, 22);
            this.btnAddSystemActivation.Text = "Activation Network";
            // 
            // distanceActivationToolStripMenuItem
            // 
            this.distanceActivationToolStripMenuItem.Enabled = false;
            this.distanceActivationToolStripMenuItem.Name = "distanceActivationToolStripMenuItem";
            this.distanceActivationToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.distanceActivationToolStripMenuItem.Text = "Distance Network";
            // 
            // neocognitronToolStripMenuItem
            // 
            this.neocognitronToolStripMenuItem.Enabled = false;
            this.neocognitronToolStripMenuItem.Name = "neocognitronToolStripMenuItem";
            this.neocognitronToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.neocognitronToolStripMenuItem.Text = "Neocognitron";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "Add Training Session";
            // 
            // menuSource
            // 
            this.menuSource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSourceToolStripMenuItem});
            this.menuSource.Name = "contextMenuStrip1";
            this.menuSource.Size = new System.Drawing.Size(105, 26);
            // 
            // addNewSourceToolStripMenuItem
            // 
            this.addNewSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.soundToolStripMenuItem});
            this.addNewSourceToolStripMenuItem.Name = "addNewSourceToolStripMenuItem";
            this.addNewSourceToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.addNewSourceToolStripMenuItem.Text = "Add";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tableToolStripMenuItem.Text = "Table";
            this.tableToolStripMenuItem.Click += new System.EventHandler(this.btnAddSourceTable_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.soundToolStripMenuItem.Text = "Sound";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 357);
            this.label1.TabIndex = 2;
            this.label1.Text = "No Workplace loaded. Please click the \'New\' menu  and select \'Workplace\' to begin" +
                ".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuTraining
            // 
            this.menuTraining.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuTraining.Name = "contextMenuStrip1";
            this.menuTraining.Size = new System.Drawing.Size(105, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem1.Text = "Add";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem2.Text = "Table";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem3.Text = "Image";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem4.Text = "Video";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem5.Text = "Sound";
            // 
            // menuSystem
            // 
            this.menuSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6});
            this.menuSystem.Name = "contextMenuStrip1";
            this.menuSystem.Size = new System.Drawing.Size(105, 26);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "Add";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem7.Text = "Table";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem8.Text = "Image";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem9.Text = "Video";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem10.Text = "Sound";
            // 
            // WorkplaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 382);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewWorkplace);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WorkplaceWindow";
            this.TabText = "Workplace Explorer";
            this.Text = "Workplace Explorer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuSource.ResumeLayout(false);
            this.menuTraining.ResumeLayout(false);
            this.menuSystem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewWorkplace;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnAddSourceTable;
        private System.Windows.Forms.ToolStripMenuItem imageSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem distanceActivationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnAddSystemActivation;
        private System.Windows.Forms.ToolStripMenuItem neocognitronToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem addNewSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuTraining;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ContextMenuStrip menuSystem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
    }
}
