namespace Sinapse.Controls
{
    partial class StatusBarControl
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lbEpoch = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbTrainingError = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbValidationError = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.progressBar,
            this.lbEpoch,
            this.lbTrainingError,
            this.lbValidationError,
            this.lbItems});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1048, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = false;
            this.lbStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(250, 17);
            this.lbStatus.Text = "lbStatus";
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // lbEpoch
            // 
            this.lbEpoch.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbEpoch.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbEpoch.Name = "lbEpoch";
            this.lbEpoch.Size = new System.Drawing.Size(73, 17);
            this.lbEpoch.Spring = true;
            this.lbEpoch.Text = "lbEpoch";
            // 
            // lbTrainingError
            // 
            this.lbTrainingError.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbTrainingError.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbTrainingError.Name = "lbTrainingError";
            this.lbTrainingError.Size = new System.Drawing.Size(73, 17);
            this.lbTrainingError.Spring = true;
            this.lbTrainingError.Text = "lbTrainingError";
            // 
            // lbValidationError
            // 
            this.lbValidationError.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbValidationError.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbValidationError.Name = "lbValidationError";
            this.lbValidationError.Size = new System.Drawing.Size(73, 17);
            this.lbValidationError.Spring = true;
            this.lbValidationError.Text = "lbValidationError";
            // 
            // lbItems
            // 
            this.lbItems.AutoSize = false;
            this.lbItems.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbItems.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(80, 17);
            this.lbItems.Text = "lbSelection";
            // 
            // StatusBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.statusStrip);
            this.Name = "StatusBarControl";
            this.Size = new System.Drawing.Size(1048, 22);
            this.Load += new System.EventHandler(this.StatusBarControl_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lbEpoch;
        private System.Windows.Forms.ToolStripStatusLabel lbValidationError;
        private System.Windows.Forms.ToolStripStatusLabel lbItems;
        private System.Windows.Forms.ToolStripStatusLabel lbTrainingError;
    }
}
