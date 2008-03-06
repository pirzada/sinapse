namespace Sinapse.Controls.NetworkInspector
{
    partial class InspectorNeuronDetails
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
            this.lbFunction = new System.Windows.Forms.Label();
            this.lbThreshold = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Sinapse.Properties.Resources.magic8ball;
            // 
            // lbTitle
            // 
            this.lbTitle.Text = "Network Neuron";
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
            this.lbOutput.Size = new System.Drawing.Size(42, 13);
            this.lbOutput.TabIndex = 2;
            this.lbOutput.Text = "Output:";
            // 
            // lbFunction
            // 
            this.lbFunction.AutoSize = true;
            this.lbFunction.Location = new System.Drawing.Point(24, 185);
            this.lbFunction.Name = "lbFunction";
            this.lbFunction.Size = new System.Drawing.Size(51, 13);
            this.lbFunction.TabIndex = 7;
            this.lbFunction.Text = "Function:";
            // 
            // lbThreshold
            // 
            this.lbThreshold.AutoSize = true;
            this.lbThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThreshold.Location = new System.Drawing.Point(33, 199);
            this.lbThreshold.Name = "lbThreshold";
            this.lbThreshold.Size = new System.Drawing.Size(48, 12);
            this.lbThreshold.TabIndex = 7;
            this.lbThreshold.Text = "Threshold:";
            // 
            // InspectorNeuronDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbThreshold);
            this.Controls.Add(this.lbFunction);
            this.Controls.Add(this.lbOutput);
            this.Name = "InspectorNeuronDetails";
            this.Controls.SetChildIndex(this.lbType, 0);
            this.Controls.SetChildIndex(this.btnCompute, 0);
            this.Controls.SetChildIndex(this.lbOutput, 0);
            this.Controls.SetChildIndex(this.btnRandomize, 0);
            this.Controls.SetChildIndex(this.lbInputs, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            this.Controls.SetChildIndex(this.lbTitle, 0);
            this.Controls.SetChildIndex(this.lbFunction, 0);
            this.Controls.SetChildIndex(this.lbThreshold, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Label lbFunction;
        private System.Windows.Forms.Label lbThreshold;
    }
}
