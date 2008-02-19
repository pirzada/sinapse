namespace Sinapse.Controls.NetworkDataTab
{
    partial class TabPageGraph
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
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.cbAutoupdate = new System.Windows.Forms.CheckBox();
            this.cbSave = new System.Windows.Forms.CheckBox();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEpoch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValidation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl.IsShowCursorValues = true;
            this.zedGraphControl.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.PanButtons = System.Windows.Forms.MouseButtons.Right;
            this.zedGraphControl.ScrollGrace = 0;
            this.zedGraphControl.ScrollMaxX = 0;
            this.zedGraphControl.ScrollMaxY = 0;
            this.zedGraphControl.ScrollMaxY2 = 0;
            this.zedGraphControl.ScrollMinX = 0;
            this.zedGraphControl.ScrollMinY = 0;
            this.zedGraphControl.ScrollMinY2 = 0;
            this.zedGraphControl.Size = new System.Drawing.Size(483, 368);
            this.zedGraphControl.TabIndex = 3;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(3, 407);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(686, 42);
            this.trackBar.TabIndex = 4;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colEpoch,
            this.colTraining,
            this.colValidation});
            this.dataGridView.Location = new System.Drawing.Point(489, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(198, 368);
            this.dataGridView.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "epochs";
            // 
            // numRate
            // 
            this.numRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numRate.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Sinapse.Properties.Settings.Default, "graph_updateRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numRate.Location = new System.Drawing.Point(131, 376);
            this.numRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRate.Name = "numRate";
            this.numRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numRate.Size = new System.Drawing.Size(62, 20);
            this.numRate.TabIndex = 7;
            this.numRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRate.ThousandsSeparator = true;
            this.numRate.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            // 
            // cbAutoupdate
            // 
            this.cbAutoupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoupdate.AutoSize = true;
            this.cbAutoupdate.Checked = global::Sinapse.Properties.Settings.Default.graph_Autoupdate;
            this.cbAutoupdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoupdate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "graph_Autoupdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoupdate.Location = new System.Drawing.Point(12, 377);
            this.cbAutoupdate.Name = "cbAutoupdate";
            this.cbAutoupdate.Size = new System.Drawing.Size(113, 17);
            this.cbAutoupdate.TabIndex = 6;
            this.cbAutoupdate.Text = "Auto-update every";
            this.cbAutoupdate.UseVisualStyleBackColor = true;
            // 
            // cbSave
            // 
            this.cbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSave.AutoSize = true;
            this.cbSave.Checked = global::Sinapse.Properties.Settings.Default.training_Autosave;
            this.cbSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSave.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "training_Autosave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSave.Location = new System.Drawing.Point(489, 377);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(134, 17);
            this.cbSave.TabIndex = 6;
            this.cbSave.Text = "Enable network saving";
            this.cbSave.UseVisualStyleBackColor = true;
            // 
            // colIndex
            // 
            this.colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIndex.HeaderText = "#";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Width = 39;
            // 
            // colEpoch
            // 
            this.colEpoch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEpoch.HeaderText = "Epoch";
            this.colEpoch.Name = "colEpoch";
            this.colEpoch.ReadOnly = true;
            // 
            // colTraining
            // 
            this.colTraining.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTraining.HeaderText = "T";
            this.colTraining.Name = "colTraining";
            this.colTraining.ReadOnly = true;
            this.colTraining.Width = 39;
            // 
            // colValidation
            // 
            this.colValidation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValidation.HeaderText = "V";
            this.colValidation.Name = "colValidation";
            this.colValidation.ReadOnly = true;
            this.colValidation.Width = 39;
            // 
            // TabPageGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numRate);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.cbAutoupdate);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.zedGraphControl);
            this.Name = "TabPageGraph";
            this.Size = new System.Drawing.Size(690, 449);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numRate;
        private System.Windows.Forms.CheckBox cbAutoupdate;
        private System.Windows.Forms.CheckBox cbSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEpoch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraining;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValidation;
    }
}
