namespace Sinapse.Forms.Documents
{
    partial class TableSourceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableSourceView));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTable = new System.Windows.Forms.ToolStripButton();
            this.btnOverview = new System.Windows.Forms.ToolStripButton();
            this.btnNotes = new System.Windows.Forms.ToolStripButton();
            this.btnColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "stds";
            this.saveFileDialog.Filter = "Sinapse Table Data Source Files (*.stds)|*.stds|All files (*.*)|*.*";
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel.Location = new System.Drawing.Point(0, 25);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(834, 615);
            this.dockPanel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOverview,
            this.btnTable,
            this.btnColumns,
            this.btnNotes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTable
            // 
            this.btnTable.Image = ((System.Drawing.Image)(resources.GetObject("btnTable.Image")));
            this.btnTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(53, 22);
            this.btnTable.Text = "Table";
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnOverview
            // 
            this.btnOverview.Image = ((System.Drawing.Image)(resources.GetObject("btnOverview.Image")));
            this.btnOverview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(73, 22);
            this.btnOverview.Text = "Overview";
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // btnNotes
            // 
            this.btnNotes.Image = ((System.Drawing.Image)(resources.GetObject("btnNotes.Image")));
            this.btnNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(55, 22);
            this.btnNotes.Text = "Notes";
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // btnColumns
            // 
            this.btnColumns.Image = ((System.Drawing.Image)(resources.GetObject("btnColumns.Image")));
            this.btnColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColumns.Name = "btnColumns";
            this.btnColumns.Size = new System.Drawing.Size(67, 22);
            this.btnColumns.Text = "Columns";
            this.btnColumns.Click += new System.EventHandler(this.btnColumns_Click);
            // 
            // TableDataSourceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 640);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TableDataSourceEditor";
            this.TabText = "DataSource Editor";
            this.Text = "Table Data Source Editor";
            this.Load += new System.EventHandler(this.TableDataSourceEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOverview;
        private System.Windows.Forms.ToolStripButton btnTable;
        private System.Windows.Forms.ToolStripButton btnNotes;
        private System.Windows.Forms.ToolStripButton btnColumns;
    }
}
