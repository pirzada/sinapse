namespace Sinapse.Dialogs
{
    partial class GraphDialog
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
            this.btnClear = new System.Windows.Forms.Button();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbAutoupdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(376, 187);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl.IsAntiAlias = true;
            this.zedGraphControl.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl.Margin = new System.Windows.Forms.Padding(0);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollMaxX = 0;
            this.zedGraphControl.ScrollMaxY = 0;
            this.zedGraphControl.ScrollMaxY2 = 0;
            this.zedGraphControl.ScrollMinX = 0;
            this.zedGraphControl.ScrollMinY = 0;
            this.zedGraphControl.ScrollMinY2 = 0;
            this.zedGraphControl.Size = new System.Drawing.Size(462, 184);
            this.zedGraphControl.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(277, 187);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbAutoupdate
            // 
            this.cbAutoupdate.AutoSize = true;
            this.cbAutoupdate.Location = new System.Drawing.Point(1, 190);
            this.cbAutoupdate.Name = "cbAutoupdate";
            this.cbAutoupdate.Size = new System.Drawing.Size(199, 17);
            this.cbAutoupdate.TabIndex = 3;
            this.cbAutoupdate.Text = "Auto-update during training proccess";
            this.cbAutoupdate.UseVisualStyleBackColor = true;
            // 
            // GraphDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 210);
            this.Controls.Add(this.cbAutoupdate);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Sinapse.Properties.Settings.Default, "Graph_location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = global::Sinapse.Properties.Settings.Default.Graph_location;
            this.Name = "GraphDialog";
            this.ShowInTaskbar = false;
            this.Text = "Training Graph";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphDialog_FormClosing);
            this.Load += new System.EventHandler(this.GraphDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox cbAutoupdate;
    }
}