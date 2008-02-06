namespace Sinapse.Dialogs
{
    partial class NetworkCreationDialog
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
            this.btnOptimal = new System.Windows.Forms.Button();
            this.rbThreshold = new System.Windows.Forms.RadioButton();
            this.rbBipolarSigmoid = new System.Windows.Forms.RadioButton();
            this.rbSigmoid = new System.Windows.Forms.RadioButton();
            this.tbNetworkName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lbHidden1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numSigmoidAlpha = new System.Windows.Forms.NumericUpDown();
            this.nHidden1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbHiddenLayerNumber = new System.Windows.Forms.ComboBox();
            this.nHidden2 = new System.Windows.Forms.NumericUpDown();
            this.nHidden3 = new System.Windows.Forms.NumericUpDown();
            this.gbHiddenLayers = new System.Windows.Forms.GroupBox();
            this.nHidden4 = new System.Windows.Forms.NumericUpDown();
            this.lbHidden2 = new System.Windows.Forms.Label();
            this.lbHidden3 = new System.Windows.Forms.Label();
            this.lbHidden4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSigmoidAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden3)).BeginInit();
            this.gbHiddenLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOptimal
            // 
            this.btnOptimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptimal.Location = new System.Drawing.Point(292, 155);
            this.btnOptimal.Name = "btnOptimal";
            this.btnOptimal.Size = new System.Drawing.Size(116, 23);
            this.btnOptimal.TabIndex = 20;
            this.btnOptimal.Text = "Optimal Settings";
            this.btnOptimal.UseVisualStyleBackColor = true;
            // 
            // rbThreshold
            // 
            this.rbThreshold.AutoSize = true;
            this.rbThreshold.Location = new System.Drawing.Point(15, 65);
            this.rbThreshold.Name = "rbThreshold";
            this.rbThreshold.Size = new System.Drawing.Size(72, 17);
            this.rbThreshold.TabIndex = 17;
            this.rbThreshold.Text = "Threshold";
            this.rbThreshold.UseVisualStyleBackColor = true;
            // 
            // rbBipolarSigmoid
            // 
            this.rbBipolarSigmoid.AutoSize = true;
            this.rbBipolarSigmoid.Location = new System.Drawing.Point(15, 42);
            this.rbBipolarSigmoid.Name = "rbBipolarSigmoid";
            this.rbBipolarSigmoid.Size = new System.Drawing.Size(97, 17);
            this.rbBipolarSigmoid.TabIndex = 18;
            this.rbBipolarSigmoid.Text = "Bipolar Sigmoid";
            this.rbBipolarSigmoid.UseVisualStyleBackColor = true;
            // 
            // rbSigmoid
            // 
            this.rbSigmoid.AutoSize = true;
            this.rbSigmoid.Checked = true;
            this.rbSigmoid.Location = new System.Drawing.Point(15, 19);
            this.rbSigmoid.Name = "rbSigmoid";
            this.rbSigmoid.Size = new System.Drawing.Size(62, 17);
            this.rbSigmoid.TabIndex = 19;
            this.rbSigmoid.TabStop = true;
            this.rbSigmoid.Text = "Sigmoid";
            this.rbSigmoid.UseVisualStyleBackColor = true;
            // 
            // tbNetworkName
            // 
            this.tbNetworkName.Location = new System.Drawing.Point(67, 12);
            this.tbNetworkName.Name = "tbNetworkName";
            this.tbNetworkName.Size = new System.Drawing.Size(198, 20);
            this.tbNetworkName.TabIndex = 16;
            this.tbNetworkName.Text = "New Network";
            // 
            // btnCreate
            // 
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreate.Location = new System.Drawing.Point(292, 237);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(116, 23);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create!";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // lbHidden1
            // 
            this.lbHidden1.AutoSize = true;
            this.lbHidden1.Enabled = false;
            this.lbHidden1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHidden1.Location = new System.Drawing.Point(25, 31);
            this.lbHidden1.Name = "lbHidden1";
            this.lbHidden1.Size = new System.Drawing.Size(84, 13);
            this.lbHidden1.TabIndex = 10;
            this.lbHidden1.Text = "Hidden layer #1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sigmoid\'s alpha value:";
            // 
            // numSigmoidAlpha
            // 
            this.numSigmoidAlpha.DecimalPlaces = 3;
            this.numSigmoidAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSigmoidAlpha.Location = new System.Drawing.Point(177, 52);
            this.numSigmoidAlpha.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSigmoidAlpha.Name = "numSigmoidAlpha";
            this.numSigmoidAlpha.Size = new System.Drawing.Size(77, 20);
            this.numSigmoidAlpha.TabIndex = 13;
            // 
            // nHidden1
            // 
            this.nHidden1.Enabled = false;
            this.nHidden1.Location = new System.Drawing.Point(143, 27);
            this.nHidden1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nHidden1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHidden1.Name = "nHidden1";
            this.nHidden1.Size = new System.Drawing.Size(60, 20);
            this.nHidden1.TabIndex = 14;
            this.nHidden1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSigmoid);
            this.groupBox1.Controls.Add(this.rbBipolarSigmoid);
            this.groupBox1.Controls.Add(this.rbThreshold);
            this.groupBox1.Location = new System.Drawing.Point(285, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 100);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activation Function";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Number of hidden layers:";
            // 
            // cbHiddenLayerNumber
            // 
            this.cbHiddenLayerNumber.FormattingEnabled = true;
            this.cbHiddenLayerNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cbHiddenLayerNumber.Location = new System.Drawing.Point(177, 79);
            this.cbHiddenLayerNumber.Name = "cbHiddenLayerNumber";
            this.cbHiddenLayerNumber.Size = new System.Drawing.Size(77, 21);
            this.cbHiddenLayerNumber.Sorted = true;
            this.cbHiddenLayerNumber.TabIndex = 24;
            this.cbHiddenLayerNumber.SelectedIndexChanged += new System.EventHandler(this.cbHiddenLayerNumber_SelectedIndexChanged);
            // 
            // nHidden2
            // 
            this.nHidden2.Enabled = false;
            this.nHidden2.Location = new System.Drawing.Point(143, 53);
            this.nHidden2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nHidden2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHidden2.Name = "nHidden2";
            this.nHidden2.Size = new System.Drawing.Size(60, 20);
            this.nHidden2.TabIndex = 14;
            this.nHidden2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nHidden3
            // 
            this.nHidden3.Enabled = false;
            this.nHidden3.Location = new System.Drawing.Point(143, 79);
            this.nHidden3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nHidden3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHidden3.Name = "nHidden3";
            this.nHidden3.Size = new System.Drawing.Size(60, 20);
            this.nHidden3.TabIndex = 14;
            this.nHidden3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbHiddenLayers
            // 
            this.gbHiddenLayers.Controls.Add(this.nHidden1);
            this.gbHiddenLayers.Controls.Add(this.nHidden2);
            this.gbHiddenLayers.Controls.Add(this.nHidden3);
            this.gbHiddenLayers.Controls.Add(this.nHidden4);
            this.gbHiddenLayers.Controls.Add(this.lbHidden1);
            this.gbHiddenLayers.Controls.Add(this.lbHidden2);
            this.gbHiddenLayers.Controls.Add(this.lbHidden3);
            this.gbHiddenLayers.Controls.Add(this.lbHidden4);
            this.gbHiddenLayers.Location = new System.Drawing.Point(39, 119);
            this.gbHiddenLayers.Name = "gbHiddenLayers";
            this.gbHiddenLayers.Size = new System.Drawing.Size(226, 140);
            this.gbHiddenLayers.TabIndex = 25;
            this.gbHiddenLayers.TabStop = false;
            this.gbHiddenLayers.Text = "Number of neurons in hidden layers";
            // 
            // nHidden4
            // 
            this.nHidden4.Enabled = false;
            this.nHidden4.Location = new System.Drawing.Point(143, 105);
            this.nHidden4.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nHidden4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHidden4.Name = "nHidden4";
            this.nHidden4.Size = new System.Drawing.Size(60, 20);
            this.nHidden4.TabIndex = 14;
            this.nHidden4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbHidden2
            // 
            this.lbHidden2.AutoSize = true;
            this.lbHidden2.Enabled = false;
            this.lbHidden2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHidden2.Location = new System.Drawing.Point(25, 57);
            this.lbHidden2.Name = "lbHidden2";
            this.lbHidden2.Size = new System.Drawing.Size(84, 13);
            this.lbHidden2.TabIndex = 10;
            this.lbHidden2.Text = "Hidden layer #2";
            // 
            // lbHidden3
            // 
            this.lbHidden3.AutoSize = true;
            this.lbHidden3.Enabled = false;
            this.lbHidden3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHidden3.Location = new System.Drawing.Point(25, 83);
            this.lbHidden3.Name = "lbHidden3";
            this.lbHidden3.Size = new System.Drawing.Size(84, 13);
            this.lbHidden3.TabIndex = 10;
            this.lbHidden3.Text = "Hidden layer #3";
            // 
            // lbHidden4
            // 
            this.lbHidden4.AutoSize = true;
            this.lbHidden4.Enabled = false;
            this.lbHidden4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHidden4.Location = new System.Drawing.Point(25, 109);
            this.lbHidden4.Name = "lbHidden4";
            this.lbHidden4.Size = new System.Drawing.Size(84, 13);
            this.lbHidden4.TabIndex = 10;
            this.lbHidden4.Text = "Hidden layer #4";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(292, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NetworkCreationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 272);
            this.Controls.Add(this.gbHiddenLayers);
            this.Controls.Add(this.cbHiddenLayerNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOptimal);
            this.Controls.Add(this.tbNetworkName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numSigmoidAlpha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NetworkCreationDialog";
            this.Text = "Create new Neural Network...";
            ((System.ComponentModel.ISupportInitialize)(this.numSigmoidAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden3)).EndInit();
            this.gbHiddenLayers.ResumeLayout(false);
            this.gbHiddenLayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHidden4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOptimal;
        private System.Windows.Forms.RadioButton rbThreshold;
        private System.Windows.Forms.RadioButton rbBipolarSigmoid;
        private System.Windows.Forms.RadioButton rbSigmoid;
        private System.Windows.Forms.TextBox tbNetworkName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lbHidden1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSigmoidAlpha;
        private System.Windows.Forms.NumericUpDown nHidden1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbHiddenLayerNumber;
        private System.Windows.Forms.NumericUpDown nHidden2;
        private System.Windows.Forms.NumericUpDown nHidden3;
        private System.Windows.Forms.GroupBox gbHiddenLayers;
        private System.Windows.Forms.NumericUpDown nHidden4;
        private System.Windows.Forms.Label lbHidden2;
        private System.Windows.Forms.Label lbHidden3;
        private System.Windows.Forms.Label lbHidden4;
        private System.Windows.Forms.Button btnCancel;
    }
}