namespace Sinapse.Windows.Editors.AdaptiveSystems
{
    partial class ActivationNetworkDesigner
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.inputFilters = new Sinapse.Controls.FilterSequenceControl();
            this.activationNetworkDesigner1 = new Sinapse.Windows.Editors.AdaptiveSystems.Controls.ActivationNetworkOptions();
            this.outputFilters = new Sinapse.Controls.FilterSequenceControl();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer2.Size = new System.Drawing.Size(916, 597);
            this.splitContainer2.SplitterDistance = 755;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
            this.splitContainer1.Size = new System.Drawing.Size(755, 597);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 2;
            // 
            // inputFilters
            // 
            this.inputFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputFilters.Filters = null;
            this.inputFilters.Location = new System.Drawing.Point(0, 0);
            this.inputFilters.Name = "inputFilters";
            this.inputFilters.Size = new System.Drawing.Size(153, 597);
            this.inputFilters.TabIndex = 1;
            // 
            // activationNetworkDesigner1
            // 
            this.activationNetworkDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activationNetworkDesigner1.Location = new System.Drawing.Point(0, 0);
            this.activationNetworkDesigner1.Name = "activationNetworkDesigner1";
            this.activationNetworkDesigner1.Size = new System.Drawing.Size(598, 597);
            this.activationNetworkDesigner1.TabIndex = 1;
            // 
            // outputFilters
            // 
            this.outputFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputFilters.Filters = null;
            this.outputFilters.Location = new System.Drawing.Point(0, 0);
            this.outputFilters.Name = "outputFilters";
            this.outputFilters.Size = new System.Drawing.Size(157, 597);
            this.outputFilters.TabIndex = 0;
            // 
            // ActivationNetworkDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 597);
            this.Controls.Add(this.splitContainer2);
            this.Name = "ActivationNetworkDesigner";
            this.TabText = "NetworkSystemDesign";
            this.Text = "NetworkSystemDesign";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Sinapse.Controls.FilterSequenceControl inputFilters;
        private Sinapse.Controls.FilterSequenceControl outputFilters;
        private Sinapse.Windows.Editors.AdaptiveSystems.Controls.ActivationNetworkOptions activationNetworkDesigner1;
    }
}