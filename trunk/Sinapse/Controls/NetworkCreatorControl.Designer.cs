namespace Sinapse.Controls
{
    partial class NetworkCreatorControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.numHiddenLayer = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numSigmoidAlpha = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOptimal = new System.Windows.Forms.Button();
            this.rbThreshold = new System.Windows.Forms.RadioButton();
            this.rbBipolarSigmoid = new System.Windows.Forms.RadioButton();
            this.rbSigmoid = new System.Windows.Forms.RadioButton();
            this.tbNetworkName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSigmoidAlpha)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sigmoid\'s alpha value:";
            // 
            // numHiddenLayer
            // 
            this.numHiddenLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numHiddenLayer.Location = new System.Drawing.Point(131, 182);
            this.numHiddenLayer.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numHiddenLayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHiddenLayer.Name = "numHiddenLayer";
            this.numHiddenLayer.Size = new System.Drawing.Size(58, 20);
            this.numHiddenLayer.TabIndex = 5;
            this.numHiddenLayer.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hidden layer neurons:";
            // 
            // numSigmoidAlpha
            // 
            this.numSigmoidAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numSigmoidAlpha.DecimalPlaces = 3;
            this.numSigmoidAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSigmoidAlpha.Location = new System.Drawing.Point(131, 155);
            this.numSigmoidAlpha.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSigmoidAlpha.Name = "numSigmoidAlpha";
            this.numSigmoidAlpha.Size = new System.Drawing.Size(58, 20);
            this.numSigmoidAlpha.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOptimal);
            this.groupBox1.Controls.Add(this.rbThreshold);
            this.groupBox1.Controls.Add(this.rbBipolarSigmoid);
            this.groupBox1.Controls.Add(this.rbSigmoid);
            this.groupBox1.Controls.Add(this.tbNetworkName);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numSigmoidAlpha);
            this.groupBox1.Controls.Add(this.numHiddenLayer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 247);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Creator";
            // 
            // btnOptimal
            // 
            this.btnOptimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptimal.Location = new System.Drawing.Point(9, 218);
            this.btnOptimal.Name = "btnOptimal";
            this.btnOptimal.Size = new System.Drawing.Size(91, 23);
            this.btnOptimal.TabIndex = 9;
            this.btnOptimal.Text = "Optimal Settings";
            this.btnOptimal.UseVisualStyleBackColor = true;
            this.btnOptimal.Click += new System.EventHandler(this.btnOptimal_Click);
            // 
            // rbThreshold
            // 
            this.rbThreshold.AutoSize = true;
            this.rbThreshold.Location = new System.Drawing.Point(24, 123);
            this.rbThreshold.Name = "rbThreshold";
            this.rbThreshold.Size = new System.Drawing.Size(72, 17);
            this.rbThreshold.TabIndex = 8;
            this.rbThreshold.Text = "Threshold";
            this.rbThreshold.UseVisualStyleBackColor = true;
            // 
            // rbBipolarSigmoid
            // 
            this.rbBipolarSigmoid.AutoSize = true;
            this.rbBipolarSigmoid.Location = new System.Drawing.Point(24, 100);
            this.rbBipolarSigmoid.Name = "rbBipolarSigmoid";
            this.rbBipolarSigmoid.Size = new System.Drawing.Size(97, 17);
            this.rbBipolarSigmoid.TabIndex = 8;
            this.rbBipolarSigmoid.Text = "Bipolar Sigmoid";
            this.rbBipolarSigmoid.UseVisualStyleBackColor = true;
            // 
            // rbSigmoid
            // 
            this.rbSigmoid.AutoSize = true;
            this.rbSigmoid.Checked = true;
            this.rbSigmoid.Location = new System.Drawing.Point(24, 77);
            this.rbSigmoid.Name = "rbSigmoid";
            this.rbSigmoid.Size = new System.Drawing.Size(62, 17);
            this.rbSigmoid.TabIndex = 8;
            this.rbSigmoid.TabStop = true;
            this.rbSigmoid.Text = "Sigmoid";
            this.rbSigmoid.UseVisualStyleBackColor = true;
            // 
            // tbNetworkName
            // 
            this.tbNetworkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNetworkName.Location = new System.Drawing.Point(9, 21);
            this.tbNetworkName.Name = "tbNetworkName";
            this.tbNetworkName.Size = new System.Drawing.Size(180, 20);
            this.tbNetworkName.TabIndex = 7;
            this.tbNetworkName.Text = "New Network";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(106, 218);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(83, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Activation Function";
            // 
            // NetworkCreatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "NetworkCreatorControl";
            this.Size = new System.Drawing.Size(195, 247);
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSigmoidAlpha)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numHiddenLayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSigmoidAlpha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox tbNetworkName;
        private System.Windows.Forms.RadioButton rbBipolarSigmoid;
        private System.Windows.Forms.RadioButton rbSigmoid;
        private System.Windows.Forms.RadioButton rbThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOptimal;
    }
}
