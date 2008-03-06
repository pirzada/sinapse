namespace Sinapse.Forms.Dialogs
{
    partial class NetworkInspectorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkInspectorDialog));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.inspectorNetworkDetails = new Sinapse.Controls.NetworkInspector.InspectorNetworkDetails();
            this.inspectorNeuronDetails = new Sinapse.Controls.NetworkInspector.InspectorNeuronDetails();
            this.inspectorLayerDetails = new Sinapse.Controls.NetworkInspector.InspectorLayerDetails();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.inspectorNetworkDetails);
            this.splitContainer.Panel2.Controls.Add(this.inspectorNeuronDetails);
            this.splitContainer.Panel2.Controls.Add(this.inspectorLayerDetails);
            this.splitContainer.Size = new System.Drawing.Size(410, 341);
            this.splitContainer.SplitterDistance = 197;
            this.splitContainer.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(197, 341);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Network");
            this.imageList.Images.SetKeyName(1, "Layer");
            this.imageList.Images.SetKeyName(2, "Neuron");
            this.imageList.Images.SetKeyName(3, "Weight");
            // 
            // inspectorNetworkDetails
            // 
            this.inspectorNetworkDetails.BackColor = System.Drawing.SystemColors.Window;
            this.inspectorNetworkDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inspectorNetworkDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectorNetworkDetails.Location = new System.Drawing.Point(0, 0);
            this.inspectorNetworkDetails.Name = "inspectorNetworkDetails";
            this.inspectorNetworkDetails.Size = new System.Drawing.Size(209, 341);
            this.inspectorNetworkDetails.TabIndex = 2;
            this.inspectorNetworkDetails.Visible = false;
            // 
            // inspectorNeuronDetails
            // 
            this.inspectorNeuronDetails.BackColor = System.Drawing.SystemColors.Window;
            this.inspectorNeuronDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inspectorNeuronDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectorNeuronDetails.Location = new System.Drawing.Point(0, 0);
            this.inspectorNeuronDetails.Name = "inspectorNeuronDetails";
            this.inspectorNeuronDetails.Size = new System.Drawing.Size(209, 341);
            this.inspectorNeuronDetails.TabIndex = 1;
            this.inspectorNeuronDetails.Visible = false;
            this.inspectorNeuronDetails.NetworkChanged += new System.EventHandler(this.inspectorDetails_NetworkChanged);
            // 
            // inspectorLayerDetails
            // 
            this.inspectorLayerDetails.BackColor = System.Drawing.SystemColors.Window;
            this.inspectorLayerDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inspectorLayerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectorLayerDetails.Location = new System.Drawing.Point(0, 0);
            this.inspectorLayerDetails.Name = "inspectorLayerDetails";
            this.inspectorLayerDetails.Size = new System.Drawing.Size(209, 341);
            this.inspectorLayerDetails.TabIndex = 0;
            this.inspectorLayerDetails.Visible = false;
            this.inspectorLayerDetails.NetworkChanged += new System.EventHandler(this.inspectorDetails_NetworkChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.btnExport,
            this.toolStripSeparator1,
            this.btnUpdate});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(410, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImport.Image = global::Sinapse.Properties.Resources.file_import;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(23, 22);
            this.btnImport.Text = "Import Network";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::Sinapse.Properties.Resources.file_export;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 22);
            this.btnExport.Text = "Export Network";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUpdate
            // 
            this.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdate.Image = global::Sinapse.Properties.Resources.quick_restart;
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(23, 22);
            this.btnUpdate.Text = "Update Network Info";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // NetworkInspectorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 366);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkInspectorDialog";
            this.Text = "Network Inspector";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ImageList imageList;
        private Sinapse.Controls.NetworkInspector.InspectorNetworkDetails inspectorNetworkDetails;
        private Sinapse.Controls.NetworkInspector.InspectorNeuronDetails inspectorNeuronDetails;
        private Sinapse.Controls.NetworkInspector.InspectorLayerDetails inspectorLayerDetails;
    }
}