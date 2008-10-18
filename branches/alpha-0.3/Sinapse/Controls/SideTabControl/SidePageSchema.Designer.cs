namespace Sinapse.Controls.SideTabControl
{
    partial class SidePageSchema
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutodetect = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.numRangeLow = new System.Windows.Forms.NumericUpDown();
            this.numRangeHigh = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(17, 104);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(194, 336);
            this.dataGridView.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 37;
            this.label2.Text = "Database Schema";
            // 
            // btnAutodetect
            // 
            this.btnAutodetect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutodetect.Image = global::Sinapse.Properties.Resources.upleft_arrow_48;
            this.btnAutodetect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutodetect.Location = new System.Drawing.Point(3, 446);
            this.btnAutodetect.Name = "btnAutodetect";
            this.btnAutodetect.Size = new System.Drawing.Size(208, 41);
            this.btnAutodetect.TabIndex = 4;
            this.btnAutodetect.Text = "Autodetect";
            this.btnAutodetect.UseVisualStyleBackColor = true;
            this.btnAutodetect.Click += new System.EventHandler(this.btnAutodetect_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Window;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.numRangeLow);
            this.panel.Controls.Add(this.numRangeHigh);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.btnAutodetect);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.dataGridView);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(219, 494);
            this.panel.TabIndex = 38;
            // 
            // numRangeLow
            // 
            this.numRangeLow.DecimalPlaces = 3;
            this.numRangeLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRangeLow.Location = new System.Drawing.Point(29, 71);
            this.numRangeLow.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeLow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numRangeLow.Name = "numRangeLow";
            this.numRangeLow.Size = new System.Drawing.Size(51, 20);
            this.numRangeLow.TabIndex = 41;
            this.numRangeLow.ValueChanged += new System.EventHandler(this.numRangeLow_ValueChanged);
            this.numRangeLow.Validating += new System.ComponentModel.CancelEventHandler(this.numRangeLow_Validating);
            // 
            // numRangeHigh
            // 
            this.numRangeHigh.DecimalPlaces = 3;
            this.numRangeHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRangeHigh.Location = new System.Drawing.Point(108, 71);
            this.numRangeHigh.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeHigh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numRangeHigh.Name = "numRangeHigh";
            this.numRangeHigh.Size = new System.Drawing.Size(51, 20);
            this.numRangeHigh.TabIndex = 42;
            this.numRangeHigh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeHigh.ValueChanged += new System.EventHandler(this.numRangeHigh_ValueChanged);
            this.numRangeHigh.Validating += new System.ComponentModel.CancelEventHandler(this.numRangeHigh_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Output normalization range:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SidePageSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Enabled = false;
            this.Name = "SidePageSchema";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(225, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutodetect;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numRangeLow;
        private System.Windows.Forms.NumericUpDown numRangeHigh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}
