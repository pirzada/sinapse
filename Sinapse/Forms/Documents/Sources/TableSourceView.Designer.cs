namespace Sinapse.WinForms.Documents
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.cbDataSet = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.captionLabel1 = new Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.captionLabel2 = new Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel();
            this.captionLabel3 = new Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel();
            this.captionLabel4 = new Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "stds";
            this.saveFileDialog.Filter = "Sinapse Table Data Source Files (*.stds)|*.stds|All files (*.*)|*.*";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.toolStripButton2,
            this.cbDataSet,
            this.toolStripLabel1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(63, 22);
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // cbDataSet
            // 
            this.cbDataSet.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbDataSet.Name = "cbDataSet";
            this.cbDataSet.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel1.Text = "Data Set:";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Edit Columns";
            // 
            // captionLabel1
            // 
            this.captionLabel1.AutoSize = true;
            this.captionLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.captionLabel1.Color = System.Drawing.Color.Honeydew;
            this.captionLabel1.Location = new System.Drawing.Point(3, 532);
            this.captionLabel1.Name = "captionLabel1";
            this.captionLabel1.Size = new System.Drawing.Size(58, 20);
            this.captionLabel1.TabIndex = 2;
            this.captionLabel1.Text = "Input";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 4);
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(828, 583);
            this.dataGridView1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.captionLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.captionLabel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.captionLabel4, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 615);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // captionLabel2
            // 
            this.captionLabel2.AutoSize = true;
            this.captionLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.captionLabel2.Color = System.Drawing.Color.Honeydew;
            this.captionLabel2.Location = new System.Drawing.Point(3, 592);
            this.captionLabel2.Name = "captionLabel2";
            this.captionLabel2.Size = new System.Drawing.Size(72, 20);
            this.captionLabel2.TabIndex = 3;
            this.captionLabel2.Text = "Training";
            // 
            // captionLabel3
            // 
            this.captionLabel3.AutoSize = true;
            this.captionLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.captionLabel3.Color = System.Drawing.Color.AliceBlue;
            this.captionLabel3.Location = new System.Drawing.Point(81, 592);
            this.captionLabel3.Name = "captionLabel3";
            this.captionLabel3.Size = new System.Drawing.Size(80, 20);
            this.captionLabel3.TabIndex = 3;
            this.captionLabel3.Text = "Validation";
            // 
            // captionLabel4
            // 
            this.captionLabel4.AutoSize = true;
            this.captionLabel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.captionLabel4.Color = System.Drawing.Color.LavenderBlush;
            this.captionLabel4.Location = new System.Drawing.Point(167, 592);
            this.captionLabel4.Name = "captionLabel4";
            this.captionLabel4.Size = new System.Drawing.Size(69, 20);
            this.captionLabel4.TabIndex = 3;
            this.captionLabel4.Text = "Testing";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // TableSourceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 640);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableSourceView";
            this.TabText = "DataSource Editor";
            this.Text = "Table Data Source Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripComboBox cbDataSet;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel captionLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel captionLabel2;
        private Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel captionLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private Sinapse.WinForms.Documents.Sources.Controls.CaptionLabel captionLabel4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
