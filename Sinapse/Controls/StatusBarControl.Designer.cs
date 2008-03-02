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
            this.btnClear = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOptions = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.lbItems,
            this.btnClear,
            this.btnOptions});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(988, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = false;
            this.lbStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(206, 17);
            this.lbStatus.Spring = true;
            this.lbStatus.Text = "lbStatus";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbStatus.Click += new System.EventHandler(this.lbStatus_Click);
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(330, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lbEpoch
            // 
            this.lbEpoch.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbEpoch.Name = "lbEpoch";
            this.lbEpoch.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbEpoch.Size = new System.Drawing.Size(54, 17);
            this.lbEpoch.Text = "lbEpoch";
            // 
            // lbTrainingError
            // 
            this.lbTrainingError.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbTrainingError.Name = "lbTrainingError";
            this.lbTrainingError.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTrainingError.Size = new System.Drawing.Size(87, 17);
            this.lbTrainingError.Text = "lbTrainingError";
            // 
            // lbValidationError
            // 
            this.lbValidationError.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbValidationError.Name = "lbValidationError";
            this.lbValidationError.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbValidationError.Size = new System.Drawing.Size(95, 17);
            this.lbValidationError.Text = "lbValidationError";
            // 
            // lbItems
            // 
            this.lbItems.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lbItems.Name = "lbItems";
            this.lbItems.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbItems.Size = new System.Drawing.Size(68, 17);
            this.lbItems.Text = "lbSelection";
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClear.Image = global::Sinapse.Properties.Resources.edit_clear;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.IsLink = true;
            this.btnClear.Margin = new System.Windows.Forms.Padding(3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(16, 16);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOptions.Image = global::Sinapse.Properties.Resources.panel_settings;
            this.btnOptions.IsLink = true;
            this.btnOptions.Margin = new System.Windows.Forms.Padding(3);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(16, 16);
            this.btnOptions.Text = "Options";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // StatusBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.statusStrip);
            this.Name = "StatusBarControl";
            this.Size = new System.Drawing.Size(988, 22);
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
        private System.Windows.Forms.ToolStripStatusLabel btnClear;
        private System.Windows.Forms.ToolStripStatusLabel btnOptions;
    }
}
