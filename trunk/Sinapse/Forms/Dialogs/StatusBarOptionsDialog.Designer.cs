namespace Sinapse.Forms.Dialogs
{
    partial class StatusBarOptionsDialog
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
            this.btnApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rbEpoch = new System.Windows.Forms.RadioButton();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(273, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(48, 46);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "OK";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "passed epochs";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // rbEpoch
            // 
            this.rbEpoch.AutoSize = true;
            this.rbEpoch.Checked = true;
            this.rbEpoch.Location = new System.Drawing.Point(12, 7);
            this.rbEpoch.Name = "rbEpoch";
            this.rbEpoch.Size = new System.Drawing.Size(89, 17);
            this.rbEpoch.TabIndex = 3;
            this.rbEpoch.TabStop = true;
            this.rbEpoch.Text = "Update every";
            this.rbEpoch.UseVisualStyleBackColor = true;
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.Enabled = false;
            this.rbTime.Location = new System.Drawing.Point(12, 30);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(63, 17);
            this.rbTime.TabIndex = 3;
            this.rbTime.Text = "or every";
            this.rbTime.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(187, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "milliseconds.";
            this.label1.Click += new System.EventHandler(this.label2_Click);
            // 
            // numTime
            // 
            this.numTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Sinapse.Properties.Settings.Default, "display_UpdateTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numTime.Enabled = false;
            this.numTime.Location = new System.Drawing.Point(107, 30);
            this.numTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(74, 20);
            this.numTime.TabIndex = 1;
            this.numTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTime.ThousandsSeparator = true;
            this.numTime.Value = global::Sinapse.Properties.Settings.Default.display_UpdateTime;
            // 
            // numRate
            // 
            this.numRate.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Sinapse.Properties.Settings.Default, "display_UpdateRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numRate.Location = new System.Drawing.Point(107, 7);
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
            this.numRate.Size = new System.Drawing.Size(74, 20);
            this.numRate.TabIndex = 1;
            this.numRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRate.ThousandsSeparator = true;
            this.numRate.Value = global::Sinapse.Properties.Settings.Default.display_UpdateRate;
            // 
            // StatusBarOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 57);
            this.Controls.Add(this.rbTime);
            this.Controls.Add(this.rbEpoch);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.numTime);
            this.Controls.Add(this.numRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StatusBarOptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status Bar Options";
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRate;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbEpoch;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.Label label1;
    }
}