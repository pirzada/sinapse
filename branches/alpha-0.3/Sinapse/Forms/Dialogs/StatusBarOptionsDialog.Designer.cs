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
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rbEpoch = new System.Windows.Forms.RadioButton();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(331, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 46);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "passed epochs";
            // 
            // rbEpoch
            // 
            this.rbEpoch.AutoSize = true;
            this.rbEpoch.Location = new System.Drawing.Point(12, 7);
            this.rbEpoch.Name = "rbEpoch";
            this.rbEpoch.Size = new System.Drawing.Size(89, 17);
            this.rbEpoch.TabIndex = 3;
            this.rbEpoch.Text = "Update every";
            this.rbEpoch.UseVisualStyleBackColor = true;
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
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
            this.label1.Location = new System.Drawing.Point(187, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "milliseconds.";
            // 
            // numTime
            // 
            this.numTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTime.Location = new System.Drawing.Point(107, 30);
            this.numTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTime.Minimum = new decimal(new int[] {
            500,
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
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(277, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(48, 46);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // StatusBarOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 57);
            this.Controls.Add(this.rbTime);
            this.Controls.Add(this.rbEpoch);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOK);
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbEpoch;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
    }
}