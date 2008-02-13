namespace Sinapse.Dialogs
{
    partial class GraphDialog
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
            this.btnClear = new System.Windows.Forms.Button();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbAutoupdate = new System.Windows.Forms.CheckBox();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(431, 253);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl.IsShowCursorValues = true;
            this.zedGraphControl.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl.Margin = new System.Windows.Forms.Padding(0);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.PanButtons = System.Windows.Forms.MouseButtons.Right;
            this.zedGraphControl.ScrollGrace = 0;
            this.zedGraphControl.ScrollMaxX = 0;
            this.zedGraphControl.ScrollMaxY = 0;
            this.zedGraphControl.ScrollMaxY2 = 0;
            this.zedGraphControl.ScrollMinX = 0;
            this.zedGraphControl.ScrollMinY = 0;
            this.zedGraphControl.ScrollMinY2 = 0;
            this.zedGraphControl.Size = new System.Drawing.Size(517, 250);
            this.zedGraphControl.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(332, 253);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbAutoupdate
            // 
            this.cbAutoupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoupdate.AutoSize = true;
            this.cbAutoupdate.Checked = global::Sinapse.Properties.Settings.Default.graph_Autoupdate;
            this.cbAutoupdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoupdate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "graph_Autoupdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoupdate.Location = new System.Drawing.Point(1, 256);
            this.cbAutoupdate.Name = "cbAutoupdate";
            this.cbAutoupdate.Size = new System.Drawing.Size(113, 17);
            this.cbAutoupdate.TabIndex = 3;
            this.cbAutoupdate.Text = "Auto-update every";
            this.cbAutoupdate.UseVisualStyleBackColor = true;
            // 
            // numRate
            // 
            this.numRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numRate.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Sinapse.Properties.Settings.Default, "graph_updateRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numRate.Location = new System.Drawing.Point(120, 255);
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
            this.numRate.TabIndex = 4;
            this.numRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRate.ThousandsSeparator = true;
            this.numRate.Value = global::Sinapse.Properties.Settings.Default.graph_UpdateRate;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "epochs";
            // 
            // GraphDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 276);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numRate);
            this.Controls.Add(this.cbAutoupdate);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = new System.Drawing.Point(600, 500);
            this.Name = "GraphDialog";
            this.ShowInTaskbar = false;
            this.Text = "Training Graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphDialog_FormClosing);
            this.Load += new System.EventHandler(this.GraphDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox cbAutoupdate;
        private System.Windows.Forms.NumericUpDown numRate;
        private System.Windows.Forms.Label label1;
    }
}