namespace Sinapse.Controls.Sidebar
{
    partial class SideTrainerControl
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
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.rbErrorLimit = new System.Windows.Forms.RadioButton();
            this.rbEpochLimit = new System.Windows.Forms.RadioButton();
            this.cbValidationStop = new System.Windows.Forms.CheckBox();
            this.cbValidate = new System.Windows.Forms.CheckBox();
            this.cbChangeRate = new System.Windows.Forms.CheckBox();
            this.numEpochLimit = new System.Windows.Forms.NumericUpDown();
            this.numErrorLimit = new System.Windows.Forms.NumericUpDown();
            this.numMomentum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numChangeRate = new System.Windows.Forms.NumericUpDown();
            this.numLearningRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.pbStart = new System.Windows.Forms.PictureBox();
            this.pbForget = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numEpochLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMomentum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbForget)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // rbErrorLimit
            // 
            this.rbErrorLimit.AutoSize = true;
            this.rbErrorLimit.Checked = true;
            this.rbErrorLimit.Location = new System.Drawing.Point(12, 47);
            this.rbErrorLimit.Name = "rbErrorLimit";
            this.rbErrorLimit.Size = new System.Drawing.Size(84, 17);
            this.rbErrorLimit.TabIndex = 31;
            this.rbErrorLimit.TabStop = true;
            this.rbErrorLimit.Text = "By error limit:";
            this.rbErrorLimit.UseVisualStyleBackColor = true;
            // 
            // rbEpochLimit
            // 
            this.rbEpochLimit.AutoSize = true;
            this.rbEpochLimit.Location = new System.Drawing.Point(12, 21);
            this.rbEpochLimit.Name = "rbEpochLimit";
            this.rbEpochLimit.Size = new System.Drawing.Size(78, 17);
            this.rbEpochLimit.TabIndex = 32;
            this.rbEpochLimit.Text = "By epochs:";
            this.rbEpochLimit.UseVisualStyleBackColor = true;
            // 
            // cbValidationStop
            // 
            this.cbValidationStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbValidationStop.Location = new System.Drawing.Point(12, 274);
            this.cbValidationStop.Name = "cbValidationStop";
            this.cbValidationStop.Size = new System.Drawing.Size(169, 31);
            this.cbValidationStop.TabIndex = 28;
            this.cbValidationStop.Text = "Stop training when validation error start increasing";
            // 
            // cbValidate
            // 
            this.cbValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbValidate.Location = new System.Drawing.Point(12, 211);
            this.cbValidate.Name = "cbValidate";
            this.cbValidate.Size = new System.Drawing.Size(169, 45);
            this.cbValidate.TabIndex = 29;
            this.cbValidate.Text = "Enable network cross-validation (needs validation data)";
            this.cbValidate.UseVisualStyleBackColor = true;
            // 
            // cbChangeRate
            // 
            this.cbChangeRate.AutoSize = true;
            this.cbChangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChangeRate.Location = new System.Drawing.Point(12, 124);
            this.cbChangeRate.Name = "cbChangeRate";
            this.cbChangeRate.Size = new System.Drawing.Size(118, 16);
            this.cbChangeRate.TabIndex = 30;
            this.cbChangeRate.Text = "change after first pass:";
            this.cbChangeRate.UseVisualStyleBackColor = true;
            // 
            // numEpochLimit
            // 
            this.numEpochLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numEpochLimit.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numEpochLimit.Location = new System.Drawing.Point(121, 21);
            this.numEpochLimit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numEpochLimit.Name = "numEpochLimit";
            this.numEpochLimit.Size = new System.Drawing.Size(60, 20);
            this.numEpochLimit.TabIndex = 26;
            this.numEpochLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numEpochLimit.ThousandsSeparator = true;
            this.numEpochLimit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numErrorLimit
            // 
            this.numErrorLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numErrorLimit.DecimalPlaces = 4;
            this.numErrorLimit.Location = new System.Drawing.Point(121, 47);
            this.numErrorLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numErrorLimit.Name = "numErrorLimit";
            this.numErrorLimit.Size = new System.Drawing.Size(60, 20);
            this.numErrorLimit.TabIndex = 27;
            this.numErrorLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numErrorLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numMomentum
            // 
            this.numMomentum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numMomentum.DecimalPlaces = 3;
            this.numMomentum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMomentum.Location = new System.Drawing.Point(129, 164);
            this.numMomentum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMomentum.Name = "numMomentum";
            this.numMomentum.Size = new System.Drawing.Size(52, 20);
            this.numMomentum.TabIndex = 25;
            this.numMomentum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Momentum:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Learning rate:";
            // 
            // numChangeRate
            // 
            this.numChangeRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numChangeRate.DecimalPlaces = 3;
            this.numChangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangeRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numChangeRate.Location = new System.Drawing.Point(129, 123);
            this.numChangeRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numChangeRate.Name = "numChangeRate";
            this.numChangeRate.Size = new System.Drawing.Size(52, 18);
            this.numChangeRate.TabIndex = 24;
            this.numChangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChangeRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numLearningRate
            // 
            this.numLearningRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numLearningRate.DecimalPlaces = 3;
            this.numLearningRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLearningRate.Location = new System.Drawing.Point(129, 100);
            this.numLearningRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLearningRate.Name = "numLearningRate";
            this.numLearningRate.Size = new System.Drawing.Size(52, 20);
            this.numLearningRate.TabIndex = 23;
            this.numLearningRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLearningRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Error tolerance (%):";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(129, 323);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 25;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 24);
            this.label2.TabIndex = 36;
            this.label2.Text = "Network Trainer";
            // 
            // pbGraph
            // 
            this.pbGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbGraph.Image = global::Sinapse.Properties.Resources.function;
            this.pbGraph.Location = new System.Drawing.Point(160, 411);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(32, 32);
            this.pbGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbGraph.TabIndex = 35;
            this.pbGraph.TabStop = false;
            this.pbGraph.Click += new System.EventHandler(this.pbGraph_Click);
            // 
            // pbStop
            // 
            this.pbStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStop.Image = global::Sinapse.Properties.Resources.player_stop_32;
            this.pbStop.Location = new System.Drawing.Point(122, 411);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(32, 32);
            this.pbStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbStop.TabIndex = 35;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pbPause
            // 
            this.pbPause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPause.Image = global::Sinapse.Properties.Resources.player_pause_32;
            this.pbPause.Location = new System.Drawing.Point(84, 411);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(32, 32);
            this.pbPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPause.TabIndex = 35;
            this.pbPause.TabStop = false;
            this.pbPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pbStart
            // 
            this.pbStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStart.Image = global::Sinapse.Properties.Resources.player_play_32;
            this.pbStart.Location = new System.Drawing.Point(46, 411);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(32, 32);
            this.pbStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbStart.TabIndex = 35;
            this.pbStart.TabStop = false;
            this.pbStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbForget
            // 
            this.pbForget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbForget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbForget.Image = global::Sinapse.Properties.Resources.player_rew_32;
            this.pbForget.Location = new System.Drawing.Point(8, 411);
            this.pbForget.Name = "pbForget";
            this.pbForget.Size = new System.Drawing.Size(32, 32);
            this.pbForget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbForget.TabIndex = 35;
            this.pbForget.TabStop = false;
            this.pbForget.Click += new System.EventHandler(this.btnForget_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbErrorLimit);
            this.panel1.Controls.Add(this.rbEpochLimit);
            this.panel1.Controls.Add(this.cbValidationStop);
            this.panel1.Controls.Add(this.cbValidate);
            this.panel1.Controls.Add(this.cbChangeRate);
            this.panel1.Controls.Add(this.numEpochLimit);
            this.panel1.Controls.Add(this.numErrorLimit);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.numMomentum);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numChangeRate);
            this.panel1.Controls.Add(this.numLearningRate);
            this.panel1.Location = new System.Drawing.Point(6, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 362);
            this.panel1.TabIndex = 37;
            // 
            // SideTrainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbGraph);
            this.Controls.Add(this.pbStop);
            this.Controls.Add(this.pbPause);
            this.Controls.Add(this.pbStart);
            this.Controls.Add(this.pbForget);
            this.Name = "SideTrainerControl";
            this.Size = new System.Drawing.Size(201, 456);
            ((System.ComponentModel.ISupportInitialize)(this.numEpochLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMomentum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbForget)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.RadioButton rbErrorLimit;
        private System.Windows.Forms.RadioButton rbEpochLimit;
        private System.Windows.Forms.CheckBox cbValidationStop;
        private System.Windows.Forms.CheckBox cbValidate;
        private System.Windows.Forms.CheckBox cbChangeRate;
        private System.Windows.Forms.NumericUpDown numEpochLimit;
        private System.Windows.Forms.NumericUpDown numErrorLimit;
        private System.Windows.Forms.NumericUpDown numMomentum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numChangeRate;
        private System.Windows.Forms.NumericUpDown numLearningRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pbForget;
        private System.Windows.Forms.PictureBox pbStart;
        private System.Windows.Forms.PictureBox pbPause;
        private System.Windows.Forms.PictureBox pbStop;
        private System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
