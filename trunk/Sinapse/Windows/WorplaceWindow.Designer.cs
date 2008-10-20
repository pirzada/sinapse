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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(273, 357);
            this.treeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Workspace");
            this.imageList1.Images.SetKeyName(1, "Folder");
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            // WorkplaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 382);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WorkplaceWindow";
            this.TabText = "Workplace Explorer";
            this.Text = "Workplace Explorer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnAddSourceTable;
        private System.Windows.Forms.ToolStripMenuItem imageSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem distanceActivationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnAddSystemActivation;
        private System.Windows.Forms.ToolStripMenuItem neocognitronToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.Label label1;
    }
}
