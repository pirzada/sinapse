namespace Sinapse.Controls.SideTabControl
{
    partial class SidebarControl
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
            this.tabControl = new Dotnetrix.Controls.TabControlEX();
            this.tabContext = new Dotnetrix.Controls.TabPageEX();
            this.tabWorkplace = new Dotnetrix.Controls.TabPageEX();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Appearance = Dotnetrix.Controls.TabAppearanceEX.Bevel;
            this.tabControl.AutoLoadTabPages = true;
            this.tabControl.Controls.Add(this.tabContext);
            this.tabControl.Controls.Add(this.tabWorkplace);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(265, 455);
            this.tabControl.TabIndex = 17;
            this.tabControl.UseVisualStyles = false;
            // 
            // tabContext
            // 
            this.tabContext.Location = new System.Drawing.Point(27, 4);
            this.tabContext.Name = "tabContext";
            this.tabContext.Size = new System.Drawing.Size(234, 447);
            this.tabContext.TabIndex = 1;
            this.tabContext.Text = "Context";
            // 
            // tabWorkplace
            // 
            this.tabWorkplace.Location = new System.Drawing.Point(27, 4);
            this.tabWorkplace.Name = "tabWorkplace";
            this.tabWorkplace.Size = new System.Drawing.Size(234, 447);
            this.tabWorkplace.TabIndex = 2;
            this.tabWorkplace.Text = "Workplace";
            // 
            // SidebarControl
            // 
            this.Controls.Add(this.tabControl);
            this.Size = new System.Drawing.Size(265, 455);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dotnetrix.Controls.TabControlEX tabControl;
        private Dotnetrix.Controls.TabPageEX tabContext;
        private Dotnetrix.Controls.TabPageEX tabWorkplace;
    }
}
