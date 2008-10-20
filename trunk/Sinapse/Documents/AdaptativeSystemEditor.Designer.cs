namespace Sinapse.Documents
{
    partial class AdaptativeSystemEditor
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
            this.button1 = new System.Windows.Forms.Button();
            this.tabPreprocessing = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabDesign = new System.Windows.Forms.TabPage();
            this.tabPostprocessing = new System.Windows.Forms.TabPage();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.dataGraphView1 = new Sinapse.Forms.Controls.DataGraphView();
            this.activationNetworkDesigner1 = new Sinapse.Editors.ActivationNetworkDesigner();
            this.tabControl1.SuspendLayout();
            this.tabSource.SuspendLayout();
            this.tabPreprocessing.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabDesign.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSource);
            this.tabControl1.Controls.Add(this.tabPreprocessing);
            this.tabControl1.Controls.Add(this.tabDesign);
            this.tabControl1.Controls.Add(this.tabPostprocessing);
            this.tabControl1.Controls.Add(this.tabOutput);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 666);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.button1);
            this.tabSource.Location = new System.Drawing.Point(4, 22);
            this.tabSource.Name = "tabSource";
            this.tabSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource.Size = new System.Drawing.Size(912, 640);
            this.tabSource.TabIndex = 0;
            this.tabSource.Text = "Interface Specification";
            this.tabSource.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(764, 6);
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
            this.tabPreprocessing.Size = new System.Drawing.Size(912, 640);
            this.tabPreprocessing.TabIndex = 3;
            this.tabPreprocessing.Text = "Preprocessing Filters";
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
            this.splitContainer2.Size = new System.Drawing.Size(912, 640);
            this.splitContainer2.SplitterDistance = 725;
            this.splitContainer2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGraphView1);
            this.splitContainer1.Size = new System.Drawing.Size(725, 640);
            this.splitContainer1.SplitterDistance = 505;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(725, 505);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabDesign
            // 
            this.tabDesign.Controls.Add(this.activationNetworkDesigner1);
            this.tabDesign.Location = new System.Drawing.Point(4, 22);
            this.tabDesign.Name = "tabDesign";
            this.tabDesign.Size = new System.Drawing.Size(912, 640);
            this.tabDesign.TabIndex = 5;
            this.tabDesign.Text = "System Design";
            this.tabDesign.UseVisualStyleBackColor = true;
            // 
            // tabPostprocessing
            // 
            this.tabPostprocessing.Location = new System.Drawing.Point(4, 22);
            this.tabPostprocessing.Name = "tabPostprocessing";
            this.tabPostprocessing.Size = new System.Drawing.Size(912, 640);
            this.tabPostprocessing.TabIndex = 4;
            this.tabPostprocessing.Text = "Post-processing Filters";
            this.tabPostprocessing.UseVisualStyleBackColor = true;
            // 
            // tabOutput
            // 
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(912, 640);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output Destiny";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // dataGraphView1
            // 
            this.dataGraphView1.DataMember = null;
            this.dataGraphView1.DataSource = null;
            this.dataGraphView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGraphView1.Location = new System.Drawing.Point(0, 0);
            this.dataGraphView1.Name = "dataGraphView1";
            this.dataGraphView1.Size = new System.Drawing.Size(725, 131);
            this.dataGraphView1.TabIndex = 0;
            this.dataGraphView1.Text = "dataGraphView1";
            // 
            // activationNetworkDesigner1
            // 
            this.activationNetworkDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activationNetworkDesigner1.Location = new System.Drawing.Point(0, 0);
            this.activationNetworkDesigner1.Name = "activationNetworkDesigner1";
            this.activationNetworkDesigner1.Size = new System.Drawing.Size(912, 640);
            this.activationNetworkDesigner1.TabIndex = 0;
            // 
            // AdaptativeSystemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 666);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdaptativeSystemEditor";
            this.TabText = "Adaptative System Designer";
            this.Text = "Adaptative System Designer";
            this.tabControl1.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            this.tabPreprocessing.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabDesign.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSource;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TabPage tabPreprocessing;
        private System.Windows.Forms.TabPage tabPostprocessing;
        private System.Windows.Forms.TabPage tabDesign;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Sinapse.Forms.Controls.DataGraphView dataGraphView1;
        private System.Windows.Forms.Button button1;
        private Sinapse.Editors.ActivationNetworkDesigner activationNetworkDesigner1;
    }
}
