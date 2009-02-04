namespace Sinapse.WinForms.ToolWindows
{
    partial class HistoryWindow
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
            this.components = new System.ComponentModel.Container();
            this.textBox = new System.Windows.Forms.TextBox();
            this.cbAutoscroll = new System.Windows.Forms.CheckBox();
            this.btnAutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BackColor = System.Drawing.SystemColors.Window;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(417, 122);
            this.textBox.TabIndex = 0;
            // 
            // cbAutoscroll
            // 
            this.cbAutoscroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoscroll.AutoSize = true;
            this.cbAutoscroll.Checked = global::Sinapse.WinForms.Properties.Settings.Default.history_AutoScroll;
            this.cbAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoscroll.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Sinapse.WinForms.Properties.Settings.Default, "history_AutoScroll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoscroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoscroll.Location = new System.Drawing.Point(2, 121);
            this.cbAutoscroll.Name = "cbAutoscroll";
            this.cbAutoscroll.Size = new System.Drawing.Size(66, 16);
            this.cbAutoscroll.TabIndex = 1;
            this.cbAutoscroll.Text = "Autoscroll";
            this.cbAutoscroll.UseVisualStyleBackColor = true;
            // 
            // btnAutoScroll
            // 
            this.btnAutoScroll.Checked = global::Sinapse.WinForms.Properties.Settings.Default.history_AutoScroll;
            this.btnAutoScroll.CheckOnClick = true;
            this.btnAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAutoScroll.Name = "btnAutoScroll";
            this.btnAutoScroll.Size = new System.Drawing.Size(136, 22);
            this.btnAutoScroll.Text = "Auto Scroll";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAutoScroll});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 26);
            // 
            // HistoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(417, 136);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.cbAutoscroll);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HideOnClose = true;
            this.Name = "HistoryPanel";
            this.TabText = "History Dialog";
            this.Text = "History Dialog";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox cbAutoscroll;
        private System.Windows.Forms.ToolStripMenuItem btnAutoScroll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    }
}