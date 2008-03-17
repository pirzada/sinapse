namespace Sinapse.Controls.MainTabControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSavepointClear = new System.Windows.Forms.Button();
            this.btnSavepointLoad = new System.Windows.Forms.Button();
            this.btnSavepointMark = new System.Windows.Forms.Button();
            this.cbAutoscroll = new System.Windows.Forms.CheckBox();
            this.cbAutoupdate = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.zedGraphControl.Size = new System.Drawing.Size(472, 368);
            this.zedGraphControl.TabIndex = 3;
            this.zedGraphControl.DoubleClick += new System.EventHandler(this.zedGraphControl_DoubleClick);
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar.Location = new System.Drawing.Point(0, 407);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(690, 42);
            this.trackBar.TabIndex = 4;
            this.trackBar.TickFrequency = 5;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip.SetToolTip(this.trackBar, "Training delay: Move this trackbar to the right to increase training delay (work " +
                    "slower); move left to decrease training delay (work faster)");
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEpoch,
            this.colTraining,
            this.colValidation});
            this.dataGridView.Location = new System.Drawing.Point(481, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(206, 349);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            this.dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "epochs";
            // 
            // numRate
            // 
            this.numRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numRate.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Sinapse.Properties.Settings.Default, "graph_updateRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRate.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRate.Location = new System.Drawing.Point(119, 378);
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
            this.numRate.Size = new System.Drawing.Size(62, 18);
            this.numRate.TabIndex = 7;
            this.numRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRate.ThousandsSeparator = true;
            this.numRate.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(395, 378);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 21);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(314, 378);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 21);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSavepointClear
            // 
            this.btnSavepointClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavepointClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavepointClear.Location = new System.Drawing.Point(628, 378);
            this.btnSavepointClear.Name = "btnSavepointClear";
            this.btnSavepointClear.Size = new System.Drawing.Size(59, 21);
            this.btnSavepointClear.TabIndex = 10;
            this.btnSavepointClear.Text = "Clear";
            this.btnSavepointClear.UseVisualStyleBackColor = true;
            this.btnSavepointClear.Click += new System.EventHandler(this.btnSavepointClear_Click);
            // 
            // btnSavepointLoad
            // 
            this.btnSavepointLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavepointLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavepointLoad.Location = new System.Drawing.Point(565, 378);
            this.btnSavepointLoad.Name = "btnSavepointLoad";
            this.btnSavepointLoad.Size = new System.Drawing.Size(59, 21);
            this.btnSavepointLoad.TabIndex = 10;
            this.btnSavepointLoad.Text = "Restore";
            this.btnSavepointLoad.UseVisualStyleBackColor = true;
            this.btnSavepointLoad.Click += new System.EventHandler(this.btnSavepointLoad_Click);
            // 
            // btnSavepointMark
            // 
            this.btnSavepointMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavepointMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavepointMark.Location = new System.Drawing.Point(500, 378);
            this.btnSavepointMark.Name = "btnSavepointMark";
            this.btnSavepointMark.Size = new System.Drawing.Size(59, 21);
            this.btnSavepointMark.TabIndex = 10;
            this.btnSavepointMark.Text = "Mark";
            this.btnSavepointMark.UseVisualStyleBackColor = true;
            this.btnSavepointMark.Click += new System.EventHandler(this.btnSavepointMark_Click);
            // 
            // cbAutoscroll
            // 
            this.cbAutoscroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAutoscroll.AutoSize = true;
            this.cbAutoscroll.Checked = global::Sinapse.Properties.Settings.Default.graph_autoScrollSavepoints;
            this.cbAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoscroll.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "graph_autoScrollSavepoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoscroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoscroll.Location = new System.Drawing.Point(625, 356);
            this.cbAutoscroll.Name = "cbAutoscroll";
            this.cbAutoscroll.Size = new System.Drawing.Size(66, 16);
            this.cbAutoscroll.TabIndex = 11;
            this.cbAutoscroll.Text = "Autoscroll";
            this.cbAutoscroll.UseVisualStyleBackColor = true;
            // 
            // cbAutoupdate
            // 
            this.cbAutoupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoupdate.AutoSize = true;
            this.cbAutoupdate.Checked = global::Sinapse.Properties.Settings.Default.graph_Autoupdate;
            this.cbAutoupdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoupdate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "graph_Autoupdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoupdate.Location = new System.Drawing.Point(12, 380);
            this.cbAutoupdate.Name = "cbAutoupdate";
            this.cbAutoupdate.Size = new System.Drawing.Size(101, 16);
            this.cbAutoupdate.TabIndex = 6;
            this.cbAutoupdate.Text = "Auto-update every";
            this.cbAutoupdate.UseVisualStyleBackColor = true;
            // 
            // colEpoch
            // 
            this.colEpoch.DataPropertyName = "Epoch";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colEpoch.DefaultCellStyle = dataGridViewCellStyle4;
            this.colEpoch.HeaderText = "Epoch";
            this.colEpoch.Name = "colEpoch";
            // 
            // colTraining
            // 
            this.colTraining.DataPropertyName = "ErrorTraining";
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.colTraining.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTraining.HeaderText = "Training";
            this.colTraining.Name = "colTraining";
            // 
            // colValidation
            // 
            this.colValidation.DataPropertyName = "ErrorValidation";
            dataGridViewCellStyle6.Format = "N4";
            this.colValidation.DefaultCellStyle = dataGridViewCellStyle6;
            this.colValidation.HeaderText = "Validation";
            this.colValidation.Name = "colValidation";
            // 
            // TabPageGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Controls.Add(this.cbAutoscroll);
            this.Controls.Add(this.btnSavepointMark);
            this.Controls.Add(this.btnSavepointLoad);
            this.Controls.Add(this.btnSavepointClear);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numRate);
            this.Controls.Add(this.cbAutoupdate);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.zedGraphControl);
            this.DoubleBuffered = true;
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
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSavepointClear;
        private System.Windows.Forms.Button btnSavepointLoad;
        private System.Windows.Forms.Button btnSavepointMark;
        private System.Windows.Forms.CheckBox cbAutoscroll;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEpoch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraining;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValidation;
    }
}
