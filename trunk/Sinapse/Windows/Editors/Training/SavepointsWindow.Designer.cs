namespace Sinapse.Windows.Training
{
    partial class SavepointsWindow
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
            this.btnSaveCurrent = new System.Windows.Forms.ToolStripButton();
            this.btnRevert = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectBest = new System.Windows.Forms.Button();
            this.cbAutoScroll = new System.Windows.Forms.CheckBox();
            this.colEpoch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValidationError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEpoch,
            this.colTrainingError,
            this.colValidationError});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(238, 402);
            this.dataGridView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveCurrent,
            this.btnRevert});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(238, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSaveCurrent
            // 
            this.btnSaveCurrent.Image = global::Sinapse.Properties.Resources.file_save;
            this.btnSaveCurrent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveCurrent.Name = "btnSaveCurrent";
            this.btnSaveCurrent.Size = new System.Drawing.Size(91, 22);
            this.btnSaveCurrent.Text = "Save Current";
            // 
            // btnRevert
            // 
            this.btnRevert.Image = global::Sinapse.Properties.Resources.quick_restart;
            this.btnRevert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(121, 22);
            this.btnRevert.Text = "Revert To Selection";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelectBest);
            this.panel1.Controls.Add(this.cbAutoScroll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 28);
            this.panel1.TabIndex = 3;
            // 
            // btnSelectBest
            // 
            this.btnSelectBest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectBest.Location = new System.Drawing.Point(86, 3);
            this.btnSelectBest.Name = "btnSelectBest";
            this.btnSelectBest.Size = new System.Drawing.Size(149, 23);
            this.btnSelectBest.TabIndex = 1;
            this.btnSelectBest.Text = "Select Best";
            this.btnSelectBest.UseVisualStyleBackColor = true;
            this.btnSelectBest.Click += new System.EventHandler(this.btnSelectBest_Click);
            // 
            // cbAutoScroll
            // 
            this.cbAutoScroll.AutoSize = true;
            this.cbAutoScroll.Location = new System.Drawing.Point(6, 7);
            this.cbAutoScroll.Name = "cbAutoScroll";
            this.cbAutoScroll.Size = new System.Drawing.Size(77, 17);
            this.cbAutoScroll.TabIndex = 0;
            this.cbAutoScroll.Text = "Auto Scroll";
            this.cbAutoScroll.UseVisualStyleBackColor = true;
            // 
            // colEpoch
            // 
            this.colEpoch.DataPropertyName = "Epoch";
            this.colEpoch.HeaderText = "Epoch";
            this.colEpoch.Name = "colEpoch";
            this.colEpoch.ReadOnly = true;
            // 
            // colTrainingError
            // 
            this.colTrainingError.DataPropertyName = "TrainingError";
            this.colTrainingError.HeaderText = "Training";
            this.colTrainingError.Name = "colTrainingError";
            this.colTrainingError.ReadOnly = true;
            // 
            // colValidationError
            // 
            this.colValidationError.DataPropertyName = "ValidationError";
            this.colValidationError.HeaderText = "Validation";
            this.colValidationError.Name = "colValidationError";
            this.colValidationError.ReadOnly = true;
            // 
            // SavepointsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 455);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SavepointsWindow";
            this.TabText = "Savepoints";
            this.Text = "Savepoints";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSaveCurrent;
        private System.Windows.Forms.ToolStripButton btnRevert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelectBest;
        private System.Windows.Forms.CheckBox cbAutoScroll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEpoch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainingError;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValidationError;
    }
}