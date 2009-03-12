namespace Sinapse.WinForms.Forms.Documents.Systems.Controls
{
    partial class FilterProcessing
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.filterSequenceControl1 = new Sinapse.WinForms.Documents.Systems.Controls.FilterSequence();
            this.tableSourceViewer1 = new Sinapse.WinForms.Forms.Documents.Systems.Viewers.TableSourceViewer();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableSourceViewer1);
            this.splitContainer2.Size = new System.Drawing.Size(626, 453);
            this.splitContainer2.SplitterDistance = 160;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.filterSequenceControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvColumns);
            this.splitContainer1.Size = new System.Drawing.Size(160, 453);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvColumns
            // 
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(0, 0);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.Size = new System.Drawing.Size(160, 223);
            this.dgvColumns.TabIndex = 0;
            // 
            // filterSequenceControl1
            // 
            this.filterSequenceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterSequenceControl1.Filters = null;
            this.filterSequenceControl1.Location = new System.Drawing.Point(0, 0);
            this.filterSequenceControl1.Name = "filterSequenceControl1";
            this.filterSequenceControl1.Size = new System.Drawing.Size(160, 226);
            this.filterSequenceControl1.TabIndex = 0;
            // 
            // tableSourceViewer1
            // 
            this.tableSourceViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSourceViewer1.Location = new System.Drawing.Point(0, 0);
            this.tableSourceViewer1.Name = "tableSourceViewer1";
            this.tableSourceViewer1.Size = new System.Drawing.Size(462, 453);
            this.tableSourceViewer1.TabIndex = 0;
            // 
            // FilterProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "FilterProcessing";
            this.Size = new System.Drawing.Size(626, 453);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Sinapse.WinForms.Documents.Systems.Controls.FilterSequence filterSequenceControl1;
        private System.Windows.Forms.DataGridView dgvColumns;
        private Sinapse.WinForms.Forms.Documents.Systems.Viewers.TableSourceViewer tableSourceViewer1;
    }
}
