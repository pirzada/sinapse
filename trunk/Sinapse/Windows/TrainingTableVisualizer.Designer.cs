namespace Sinapse.Windows
{
    partial class TrainingTableVisualizer
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCompute = new System.Windows.Forms.ToolStripButton();
            this.btnReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCurrentValidation = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCurrentTesting = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(629, 422);
            this.dataGridView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.btnCompute,
            this.btnReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(629, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCompute
            // 
            this.btnCompute.Image = global::Sinapse.Properties.Resources.run;
            this.btnCompute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(70, 22);
            this.btnCompute.Text = "Compute";
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // btnReport
            // 
            this.btnReport.Image = global::Sinapse.Properties.Resources.view_details;
            this.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(65, 22);
            this.btnReport.Text = "Analyze";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCurrentValidation,
            this.btnCurrentTesting});
            this.toolStripDropDownButton1.Image = global::Sinapse.Properties.Resources.txt;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(92, 22);
            this.toolStripDropDownButton1.Text = "Current Set";
            // 
            // btnCurrentValidation
            // 
            this.btnCurrentValidation.Name = "btnCurrentValidation";
            this.btnCurrentValidation.Size = new System.Drawing.Size(152, 22);
            this.btnCurrentValidation.Text = "Validation";
            // 
            // btnCurrentTesting
            // 
            this.btnCurrentTesting.Name = "btnCurrentTesting";
            this.btnCurrentTesting.Size = new System.Drawing.Size(152, 22);
            this.btnCurrentTesting.Text = "Testing";
            // 
            // TrainingTableVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 447);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TrainingTableVisualizer";
            this.TabText = "Table Visualizer";
            this.Text = "Table Visualizer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCompute;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnCurrentValidation;
        private System.Windows.Forms.ToolStripMenuItem btnCurrentTesting;
        private System.Windows.Forms.ToolStripButton btnReport;
    }
}