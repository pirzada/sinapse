namespace Sinapse.Controls.NetworkInspector
{
    partial class InspectorLayerDetails
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
            this.lbOutput = new System.Windows.Forms.Label();
            this.lbNeuron = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Sinapse.Properties.Resources.kded;
            // 
            // lbTitle
            // 
            this.lbTitle.Text = "Network Layer";
            // 
            // btnRandomize
            // 
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // btnCompute
            // 
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // lbInputs
            // 
            this.lbInputs.Location = new System.Drawing.Point(24, 233);
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Location = new System.Drawing.Point(24, 255);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(47, 13);
            this.lbOutput.TabIndex = 2;
            this.lbOutput.Text = "Outputs:";
            // 
            // lbNeuron
            // 
            this.lbNeuron.AutoSize = true;
            this.lbNeuron.Location = new System.Drawing.Point(24, 185);
            this.lbNeuron.Name = "lbNeuron";
            this.lbNeuron.Size = new System.Drawing.Size(50, 13);
            this.lbNeuron.TabIndex = 2;
            this.lbNeuron.Text = "Neurons:";
            // 
            // InspectorLayerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.lbNeuron);
            this.Name = "InspectorLayerDetails";
            this.Controls.SetChildIndex(this.lbNeuron, 0);
            this.Controls.SetChildIndex(this.lbType, 0);
            this.Controls.SetChildIndex(this.lbInputs, 0);
            this.Controls.SetChildIndex(this.btnCompute, 0);
            this.Controls.SetChildIndex(this.btnRandomize, 0);
            this.Controls.SetChildIndex(this.lbOutput, 0);
            this.Controls.SetChildIndex(this.lbTitle, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Label lbNeuron;

    }
}
