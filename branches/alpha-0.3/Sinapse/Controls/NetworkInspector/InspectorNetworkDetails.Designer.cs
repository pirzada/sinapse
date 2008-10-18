namespace Sinapse.Controls.NetworkInspector
{
    partial class InspectorNetworkDetails
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
            this.lbOutputs = new System.Windows.Forms.Label();
            this.lbFunction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Sinapse.Properties.Resources.agt_web;
            // 
            // lbTitle
            // 
            this.lbTitle.Text = "Network Details";
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
            // lbOutputs
            // 
            this.lbOutputs.AutoSize = true;
            this.lbOutputs.Location = new System.Drawing.Point(24, 255);
            this.lbOutputs.Name = "lbOutputs";
            this.lbOutputs.Size = new System.Drawing.Size(47, 13);
            this.lbOutputs.TabIndex = 2;
            this.lbOutputs.Text = "Outputs:";
            // 
            // lbFunction
            // 
            this.lbFunction.AutoSize = true;
            this.lbFunction.Location = new System.Drawing.Point(24, 185);
            this.lbFunction.Name = "lbFunction";
            this.lbFunction.Size = new System.Drawing.Size(51, 13);
            this.lbFunction.TabIndex = 2;
            this.lbFunction.Text = "Function:";
            // 
            // InspectorNetworkDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbOutputs);
            this.Controls.Add(this.lbFunction);
            this.Name = "InspectorNetworkDetails";
            this.Controls.SetChildIndex(this.lbInputs, 0);
            this.Controls.SetChildIndex(this.lbFunction, 0);
            this.Controls.SetChildIndex(this.lbOutputs, 0);
            this.Controls.SetChildIndex(this.lbType, 0);
            this.Controls.SetChildIndex(this.btnCompute, 0);
            this.Controls.SetChildIndex(this.btnRandomize, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            this.Controls.SetChildIndex(this.lbTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOutputs;
        private System.Windows.Forms.Label lbFunction;
    }
}
