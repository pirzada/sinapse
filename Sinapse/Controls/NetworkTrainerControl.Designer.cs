namespace Sinapse.Controls
{
    partial class NetworkTrainerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkTrainerControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbRealTime = new System.Windows.Forms.CheckBox();
            this.errorChart = new AForge.Controls.Chart();
            this.cbChangeRate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numErrorLimit = new System.Windows.Forms.NumericUpDown();
            this.numMomentum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numChangeRate = new System.Windows.Forms.NumericUpDown();
            this.numLearningRate = new System.Windows.Forms.NumericUpDown();
            this.btnForget = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMomentum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbRealTime);
            this.groupBox1.Controls.Add(this.errorChart);
            this.groupBox1.Controls.Add(this.cbChangeRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numErrorLimit);
            this.groupBox1.Controls.Add(this.numMomentum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numChangeRate);
            this.groupBox1.Controls.Add(this.numLearningRate);
            this.groupBox1.Controls.Add(this.btnForget);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 276);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Trainer";
            // 
            // cbRealTime
            // 
            this.cbRealTime.AutoSize = true;
            this.cbRealTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRealTime.Location = new System.Drawing.Point(6, 139);
            this.cbRealTime.Name = "cbRealTime";
            this.cbRealTime.Size = new System.Drawing.Size(144, 16);
            this.cbRealTime.TabIndex = 15;
            this.cbRealTime.Text = "Update error chart in real time";
            this.cbRealTime.UseVisualStyleBackColor = true;
            this.cbRealTime.CheckedChanged += new System.EventHandler(this.cbRealTime_CheckedChanged);
            // 
            // errorChart
            // 
            this.errorChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.errorChart.Location = new System.Drawing.Point(6, 155);
            this.errorChart.Name = "errorChart";
            this.errorChart.RangeX = ((AForge.DoubleRange)(resources.GetObject("errorChart.RangeX")));
            this.errorChart.RangeY = ((AForge.DoubleRange)(resources.GetObject("errorChart.RangeY")));
            this.errorChart.Size = new System.Drawing.Size(183, 86);
            this.errorChart.TabIndex = 14;
            this.errorChart.Text = "Error Chart";
            // 
            // cbChangeRate
            // 
            this.cbChangeRate.AutoSize = true;
            this.cbChangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChangeRate.Location = new System.Drawing.Point(9, 52);
            this.cbChangeRate.Name = "cbChangeRate";
            this.cbChangeRate.Size = new System.Drawing.Size(118, 16);
            this.cbChangeRate.TabIndex = 13;
            this.cbChangeRate.Text = "change after first pass:";
            this.cbChangeRate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Error tolerance:";
            // 
            // numErrorLimit
            // 
            this.numErrorLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numErrorLimit.DecimalPlaces = 3;
            this.numErrorLimit.Location = new System.Drawing.Point(130, 109);
            this.numErrorLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numErrorLimit.Name = "numErrorLimit";
            this.numErrorLimit.Size = new System.Drawing.Size(58, 20);
            this.numErrorLimit.TabIndex = 12;
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
            this.numMomentum.Location = new System.Drawing.Point(130, 83);
            this.numMomentum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMomentum.Name = "numMomentum";
            this.numMomentum.Size = new System.Drawing.Size(59, 20);
            this.numMomentum.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Momentum:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
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
            this.numChangeRate.Location = new System.Drawing.Point(130, 51);
            this.numChangeRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numChangeRate.Name = "numChangeRate";
            this.numChangeRate.Size = new System.Drawing.Size(59, 18);
            this.numChangeRate.TabIndex = 9;
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
            this.numLearningRate.Location = new System.Drawing.Point(130, 28);
            this.numLearningRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLearningRate.Name = "numLearningRate";
            this.numLearningRate.Size = new System.Drawing.Size(59, 20);
            this.numLearningRate.TabIndex = 9;
            this.numLearningRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // btnForget
            // 
            this.btnForget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForget.Location = new System.Drawing.Point(132, 247);
            this.btnForget.Name = "btnForget";
            this.btnForget.Size = new System.Drawing.Size(57, 23);
            this.btnForget.TabIndex = 6;
            this.btnForget.Text = "Forget Learnings";
            this.btnForget.UseVisualStyleBackColor = true;
            this.btnForget.Click += new System.EventHandler(this.btnForget_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(69, 247);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(57, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(6, 247);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(57, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // NetworkTrainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "NetworkTrainerControl";
            this.Size = new System.Drawing.Size(195, 276);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMomentum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numMomentum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numLearningRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numErrorLimit;
        private System.Windows.Forms.CheckBox cbChangeRate;
        private System.Windows.Forms.NumericUpDown numChangeRate;
        private System.Windows.Forms.Button btnForget;
        private System.Windows.Forms.Button btnStop;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private AForge.Controls.Chart errorChart;
        private System.Windows.Forms.CheckBox cbRealTime;
    }
}
