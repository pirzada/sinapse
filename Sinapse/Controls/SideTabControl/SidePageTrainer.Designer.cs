namespace Sinapse.Controls.SideTabControl
{
    partial class SidePageTrainer
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
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripBottom = new System.Windows.Forms.ToolStrip();
            this.btnForget = new System.Windows.Forms.ToolStripButton();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.panel = new System.Windows.Forms.Panel();
            this.rbErrorLimit = new System.Windows.Forms.RadioButton();
            this.rbEpochLimit = new System.Windows.Forms.RadioButton();
            this.numLearningRate = new System.Windows.Forms.NumericUpDown();
            this.cbGraphDisable = new System.Windows.Forms.CheckBox();
            this.numChangeRate = new System.Windows.Forms.NumericUpDown();
            this.cbSwitchGraph = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAutosave = new System.Windows.Forms.CheckBox();
            this.cbValidate = new System.Windows.Forms.CheckBox();
            this.numMomentum = new System.Windows.Forms.NumericUpDown();
            this.cbChangeRate = new System.Windows.Forms.CheckBox();
            this.numEpochLimit = new System.Windows.Forms.NumericUpDown();
            this.numErrorLimit = new System.Windows.Forms.NumericUpDown();
            this.numAutoSave = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripBottom.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMomentum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpochLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSave)).BeginInit();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 24);
            this.label2.TabIndex = 36;
            this.label2.Text = "Network Trainer";
            // 
            // toolStripBottom
            // 
            this.toolStripBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripBottom.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnForget,
            this.btnPrev,
            this.btnStart,
            this.btnPause,
            this.btnStop,
            this.btnNext});
            this.toolStripBottom.Location = new System.Drawing.Point(3, 414);
            this.toolStripBottom.Name = "toolStripBottom";
            this.toolStripBottom.Size = new System.Drawing.Size(219, 39);
            this.toolStripBottom.TabIndex = 41;
            this.toolStripBottom.Text = "toolStrip1";
            // 
            // btnForget
            // 
            this.btnForget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForget.Image = global::Sinapse.Properties.Resources.start1;
            this.btnForget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForget.Name = "btnForget";
            this.btnForget.Size = new System.Drawing.Size(36, 36);
            this.btnForget.Text = "Randomize (forget learnings)";
            this.btnForget.Click += new System.EventHandler(this.btnForget_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrev.Image = global::Sinapse.Properties.Resources.player_rew_32;
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(36, 36);
            this.btnPrev.Text = "Previous Savepoint";
            this.btnPrev.Click += new System.EventHandler(this.btnForget_Click);
            // 
            // btnStart
            // 
            this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStart.Image = global::Sinapse.Properties.Resources.player_play_32;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(36, 36);
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPause.Image = global::Sinapse.Properties.Resources.player_pause_32;
            this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(36, 36);
            this.btnPause.Text = "Pause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::Sinapse.Properties.Resources.player_stop_32;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 36);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::Sinapse.Properties.Resources.player_fwd;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 36);
            this.btnNext.Text = "Next Savepoint";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Window;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.rbErrorLimit);
            this.panel.Controls.Add(this.rbEpochLimit);
            this.panel.Controls.Add(this.numLearningRate);
            this.panel.Controls.Add(this.cbGraphDisable);
            this.panel.Controls.Add(this.numChangeRate);
            this.panel.Controls.Add(this.cbSwitchGraph);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.cbAutosave);
            this.panel.Controls.Add(this.cbValidate);
            this.panel.Controls.Add(this.numMomentum);
            this.panel.Controls.Add(this.cbChangeRate);
            this.panel.Controls.Add(this.numAutoSave);
            this.panel.Controls.Add(this.numEpochLimit);
            this.panel.Controls.Add(this.numErrorLimit);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(219, 411);
            this.panel.TabIndex = 39;
            // 
            // rbErrorLimit
            // 
            this.rbErrorLimit.AutoSize = true;
            this.rbErrorLimit.Checked = true;
            this.rbErrorLimit.Location = new System.Drawing.Point(9, 74);
            this.rbErrorLimit.Name = "rbErrorLimit";
            this.rbErrorLimit.Size = new System.Drawing.Size(84, 17);
            this.rbErrorLimit.TabIndex = 48;
            this.rbErrorLimit.TabStop = true;
            this.rbErrorLimit.Text = "By error limit:";
            this.rbErrorLimit.UseVisualStyleBackColor = true;
            // 
            // rbEpochLimit
            // 
            this.rbEpochLimit.AutoSize = true;
            this.rbEpochLimit.Location = new System.Drawing.Point(9, 48);
            this.rbEpochLimit.Name = "rbEpochLimit";
            this.rbEpochLimit.Size = new System.Drawing.Size(78, 17);
            this.rbEpochLimit.TabIndex = 49;
            this.rbEpochLimit.Text = "By epochs:";
            this.rbEpochLimit.UseVisualStyleBackColor = true;
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
            this.numLearningRate.Location = new System.Drawing.Point(126, 120);
            this.numLearningRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLearningRate.Name = "numLearningRate";
            this.numLearningRate.Size = new System.Drawing.Size(78, 20);
            this.numLearningRate.TabIndex = 37;
            this.numLearningRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLearningRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // cbGraphDisable
            // 
            this.cbGraphDisable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGraphDisable.AutoSize = true;
            this.cbGraphDisable.Checked = global::Sinapse.Properties.Settings.Default.graph_Disable;
            this.cbGraphDisable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "graph_Disable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbGraphDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGraphDisable.Location = new System.Drawing.Point(9, 366);
            this.cbGraphDisable.Name = "cbGraphDisable";
            this.cbGraphDisable.Size = new System.Drawing.Size(181, 16);
            this.cbGraphDisable.TabIndex = 43;
            this.cbGraphDisable.Text = "Disable graph (improves performance)";
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
            this.numChangeRate.Location = new System.Drawing.Point(126, 143);
            this.numChangeRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numChangeRate.Name = "numChangeRate";
            this.numChangeRate.Size = new System.Drawing.Size(78, 18);
            this.numChangeRate.TabIndex = 38;
            this.numChangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChangeRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // cbSwitchGraph
            // 
            this.cbSwitchGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSwitchGraph.AutoSize = true;
            this.cbSwitchGraph.Checked = global::Sinapse.Properties.Settings.Default.graph_Launch;
            this.cbSwitchGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSwitchGraph.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "graph_Launch", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSwitchGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSwitchGraph.Location = new System.Drawing.Point(9, 388);
            this.cbSwitchGraph.Name = "cbSwitchGraph";
            this.cbSwitchGraph.Size = new System.Drawing.Size(162, 16);
            this.cbSwitchGraph.TabIndex = 44;
            this.cbSwitchGraph.Text = "Launch graph when training starts";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Learning rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Momentum:";
            // 
            // cbAutosave
            // 
            this.cbAutosave.AutoSize = true;
            this.cbAutosave.Checked = global::Sinapse.Properties.Settings.Default.training_Autosave;
            this.cbAutosave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutosave.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "training_Autosave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutosave.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutosave.Location = new System.Drawing.Point(9, 268);
            this.cbAutosave.Name = "cbAutosave";
            this.cbAutosave.Size = new System.Drawing.Size(165, 16);
            this.cbAutosave.TabIndex = 46;
            this.cbAutosave.Text = "Enable network auto-saving every";
            this.cbAutosave.UseVisualStyleBackColor = true;
            // 
            // cbValidate
            // 
            this.cbValidate.Checked = global::Sinapse.Properties.Settings.Default.training_Crossvalidation;
            this.cbValidate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbValidate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.Properties.Settings.Default, "training_Crossvalidation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbValidate.Location = new System.Drawing.Point(9, 217);
            this.cbValidate.Name = "cbValidate";
            this.cbValidate.Size = new System.Drawing.Size(169, 45);
            this.cbValidate.TabIndex = 46;
            this.cbValidate.Text = "Enable network cross-validation (needs validation data)";
            this.cbValidate.UseVisualStyleBackColor = true;
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
            this.numMomentum.Location = new System.Drawing.Point(126, 167);
            this.numMomentum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMomentum.Name = "numMomentum";
            this.numMomentum.Size = new System.Drawing.Size(78, 20);
            this.numMomentum.TabIndex = 39;
            this.numMomentum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbChangeRate
            // 
            this.cbChangeRate.AutoSize = true;
            this.cbChangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChangeRate.Location = new System.Drawing.Point(9, 144);
            this.cbChangeRate.Name = "cbChangeRate";
            this.cbChangeRate.Size = new System.Drawing.Size(118, 16);
            this.cbChangeRate.TabIndex = 47;
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
            this.numEpochLimit.Location = new System.Drawing.Point(126, 48);
            this.numEpochLimit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numEpochLimit.Name = "numEpochLimit";
            this.numEpochLimit.Size = new System.Drawing.Size(78, 20);
            this.numEpochLimit.TabIndex = 41;
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
            this.numErrorLimit.Location = new System.Drawing.Point(126, 74);
            this.numErrorLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numErrorLimit.Name = "numErrorLimit";
            this.numErrorLimit.Size = new System.Drawing.Size(78, 20);
            this.numErrorLimit.TabIndex = 42;
            this.numErrorLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numErrorLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numAutoSave
            // 
            this.numAutoSave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numAutoSave.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Sinapse.Properties.Settings.Default, "training_AutosaveEpochs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numAutoSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAutoSave.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numAutoSave.Location = new System.Drawing.Point(30, 290);
            this.numAutoSave.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numAutoSave.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutoSave.Name = "numAutoSave";
            this.numAutoSave.Size = new System.Drawing.Size(57, 14);
            this.numAutoSave.TabIndex = 41;
            this.numAutoSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAutoSave.ThousandsSeparator = true;
            this.numAutoSave.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numAutoSave.Value = global::Sinapse.Properties.Settings.Default.training_AutosaveEpochs;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "epochs";
            // 
            // SideTrainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStripBottom);
            this.Name = "SideTrainerControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(225, 456);
            this.toolStripBottom.ResumeLayout(false);
            this.toolStripBottom.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMomentum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpochLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStripBottom;
        private System.Windows.Forms.ToolStripButton btnPrev;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnPause;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnForget;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RadioButton rbErrorLimit;
        private System.Windows.Forms.RadioButton rbEpochLimit;
        private System.Windows.Forms.NumericUpDown numLearningRate;
        private System.Windows.Forms.CheckBox cbGraphDisable;
        private System.Windows.Forms.NumericUpDown numChangeRate;
        private System.Windows.Forms.CheckBox cbSwitchGraph;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbValidate;
        private System.Windows.Forms.NumericUpDown numMomentum;
        private System.Windows.Forms.CheckBox cbChangeRate;
        private System.Windows.Forms.NumericUpDown numEpochLimit;
        private System.Windows.Forms.NumericUpDown numErrorLimit;
        private System.Windows.Forms.CheckBox cbAutosave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAutoSave;
    }
}
