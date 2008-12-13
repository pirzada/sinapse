namespace Sinapse.Documents
{
    partial class NetworkSystemEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSource = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvInterfaceInputs = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInterfaceOutputs = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPreprocessing = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.inputFilters = new Sinapse.Controls.FilterSequenceControl();
            this.activationNetworkDesigner1 = new Sinapse.Editors.ActivationNetworkDesigner();
            this.outputFilters = new Sinapse.Controls.FilterSequenceControl();
            this.tabControl1.SuspendLayout();
            this.tabSource.SuspendLayout();
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
            this.tabPreprocessing.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSource);
            this.tabControl1.Controls.Add(this.tabPreprocessing);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(899, 580);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.splitContainer4);
            this.tabSource.Location = new System.Drawing.Point(4, 22);
            this.tabSource.Name = "tabSource";
            this.tabSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource.Size = new System.Drawing.Size(891, 554);
            this.tabSource.TabIndex = 0;
            this.tabSource.Text = "System Interface Specification";
            this.tabSource.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.button1);
            this.splitContainer4.Size = new System.Drawing.Size(885, 548);
            this.splitContainer4.SplitterDistance = 567;
            this.splitContainer4.TabIndex = 4;
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
            this.splitContainer3.Size = new System.Drawing.Size(567, 548);
            this.splitContainer3.SplitterDistance = 273;
            this.splitContainer3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvInterfaceInputs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 273);
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
            this.dgvInterfaceInputs.Size = new System.Drawing.Size(561, 254);
            this.dgvInterfaceInputs.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvInterfaceOutputs);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 271);
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
            this.dgvInterfaceOutputs.Size = new System.Drawing.Size(561, 252);
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
            // tabPreprocessing
            // 
            this.tabPreprocessing.Controls.Add(this.splitContainer2);
            this.tabPreprocessing.Location = new System.Drawing.Point(4, 22);
            this.tabPreprocessing.Name = "tabPreprocessing";
            this.tabPreprocessing.Size = new System.Drawing.Size(891, 554);
            this.tabPreprocessing.TabIndex = 3;
            this.tabPreprocessing.Text = "System Design";
            this.tabPreprocessing.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.outputFilters);
            this.splitContainer2.Size = new System.Drawing.Size(891, 554);
            this.splitContainer2.SplitterDistance = 707;
            this.splitContainer2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.inputFilters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.activationNetworkDesigner1);
            this.splitContainer1.Size = new System.Drawing.Size(707, 554);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 2;
            // 
            // inputFilters
            // 
            this.inputFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputFilters.Location = new System.Drawing.Point(0, 0);
            this.inputFilters.Name = "inputFilters";
            this.inputFilters.Size = new System.Drawing.Size(154, 554);
            this.inputFilters.TabIndex = 1;
            // 
            // activationNetworkDesigner1
            // 
            this.activationNetworkDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activationNetworkDesigner1.Location = new System.Drawing.Point(0, 0);
            this.activationNetworkDesigner1.Name = "activationNetworkDesigner1";
            this.activationNetworkDesigner1.Size = new System.Drawing.Size(549, 554);
            this.activationNetworkDesigner1.TabIndex = 1;
            // 
            // outputFilters
            // 
            this.outputFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputFilters.Location = new System.Drawing.Point(0, 0);
            this.outputFilters.Name = "outputFilters";
            this.outputFilters.Size = new System.Drawing.Size(180, 554);
            this.outputFilters.TabIndex = 0;
            // 
            // NetworkSystemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 580);
            this.Controls.Add(this.tabControl1);
            this.Name = "NetworkSystemEditor";
            this.TabText = "Adaptative System Designer";
            this.Text = "Adaptative System Designer";
            this.Load += new System.EventHandler(this.AdaptativeSystemEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
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
            this.tabPreprocessing.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSource;
        private System.Windows.Forms.TabPage tabPreprocessing;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvInterfaceInputs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvInterfaceOutputs;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Sinapse.Controls.FilterSequenceControl outputFilters;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Sinapse.Controls.FilterSequenceControl inputFilters;
        private Sinapse.Editors.ActivationNetworkDesigner activationNetworkDesigner1;
    }
}
