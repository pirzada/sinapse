namespace Sinapse.WinForms.Documents
{
    partial class NetworkSystemView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkSystemView));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControlEX1 = new Dotnetrix.Controls.TabControlEX();
            this.tabPageEX1 = new Dotnetrix.Controls.TabPageEX();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvInterfaceInputs = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInterfaceOutputs = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageEX2 = new Dotnetrix.Controls.TabPageEX();
            this.tabPageEX3 = new Dotnetrix.Controls.TabPageEX();
            this.tabControlEX1.SuspendLayout();
            this.tabPageEX1.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaceInputs)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaceOutputs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlEX1
            // 
            this.tabControlEX1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlEX1.Controls.Add(this.tabPageEX1);
            this.tabControlEX1.Controls.Add(this.tabPageEX2);
            this.tabControlEX1.Controls.Add(this.tabPageEX3);
            this.tabControlEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEX1.Location = new System.Drawing.Point(0, 0);
            this.tabControlEX1.Multiline = true;
            this.tabControlEX1.Name = "tabControlEX1";
            this.tabControlEX1.SelectedIndex = 0;
            this.tabControlEX1.Size = new System.Drawing.Size(899, 580);
            this.tabControlEX1.TabIndex = 0;
            // 
            // tabPageEX1
            // 
            this.tabPageEX1.Controls.Add(this.splitContainer4);
            this.tabPageEX1.Location = new System.Drawing.Point(4, 4);
            this.tabPageEX1.Name = "tabPageEX1";
            this.tabPageEX1.Size = new System.Drawing.Size(891, 551);
            this.tabPageEX1.TabIndex = 0;
            this.tabPageEX1.Text = "Input / Output Specification";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.button1);
            this.splitContainer4.Size = new System.Drawing.Size(891, 551);
            this.splitContainer4.SplitterDistance = 570;
            this.splitContainer4.TabIndex = 6;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(570, 551);
            this.splitContainer3.SplitterDistance = 272;
            this.splitContainer3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvInterfaceInputs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 272);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inputs";
            // 
            // dgvInterfaceInputs
            // 
            this.dgvInterfaceInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterfaceInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInterfaceInputs.Location = new System.Drawing.Point(3, 16);
            this.dgvInterfaceInputs.Name = "dgvInterfaceInputs";
            this.dgvInterfaceInputs.Size = new System.Drawing.Size(564, 253);
            this.dgvInterfaceInputs.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvInterfaceOutputs);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 275);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outputs";
            // 
            // dgvInterfaceOutputs
            // 
            this.dgvInterfaceOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterfaceOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInterfaceOutputs.Location = new System.Drawing.Point(3, 16);
            this.dgvInterfaceOutputs.Name = "dgvInterfaceOutputs";
            this.dgvInterfaceOutputs.Size = new System.Drawing.Size(564, 256);
            this.dgvInterfaceOutputs.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Match Input Source";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabPageEX2
            // 
            this.tabPageEX2.Location = new System.Drawing.Point(4, 4);
            this.tabPageEX2.Name = "tabPageEX2";
            this.tabPageEX2.Size = new System.Drawing.Size(891, 551);
            this.tabPageEX2.TabIndex = 1;
            this.tabPageEX2.Text = "Network Design";
            // 
            // tabPageEX3
            // 
            this.tabPageEX3.Location = new System.Drawing.Point(4, 4);
            this.tabPageEX3.Name = "tabPageEX3";
            this.tabPageEX3.Size = new System.Drawing.Size(891, 551);
            this.tabPageEX3.TabIndex = 2;
            this.tabPageEX3.Text = "Query";
            // 
            // NetworkSystemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 580);
            this.Controls.Add(this.tabControlEX1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkSystemView";
            this.TabText = "Adaptative System Designer";
            this.Text = "Adaptative System Designer";
            this.Load += new System.EventHandler(this.AdaptativeSystemEditor_Load);
            this.tabControlEX1.ResumeLayout(false);
            this.tabPageEX1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaceInputs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaceOutputs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Dotnetrix.Controls.TabControlEX tabControlEX1;
        private Dotnetrix.Controls.TabPageEX tabPageEX1;
        private Dotnetrix.Controls.TabPageEX tabPageEX2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvInterfaceInputs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvInterfaceOutputs;
        private System.Windows.Forms.Button button1;
        private Dotnetrix.Controls.TabPageEX tabPageEX3;
    }
}
