namespace Sinapse.Controls.SideTabControl
{
    partial class SideTabControl
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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new Dotnetrix.Controls.TabControlEX();
            this.tabDisplay = new Dotnetrix.Controls.TabPageEX();
            this.tabTraining = new Dotnetrix.Controls.TabPageEX();
            this.tabRanges = new Dotnetrix.Controls.TabPageEX();
            this.tabWorkplace = new Dotnetrix.Controls.TabPageEX();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Appearance = Dotnetrix.Controls.TabAppearanceEX.Bevel;
            this.tabControl.AutoLoadTabPages = true;
            this.tabControl.Controls.Add(this.tabDisplay);
            this.tabControl.Controls.Add(this.tabTraining);
            this.tabControl.Controls.Add(this.tabRanges);
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
            // tabDisplay
            // 
            this.tabDisplay.Location = new System.Drawing.Point(50, 4);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Size = new System.Drawing.Size(211, 447);
            this.tabDisplay.TabIndex = 1;
            this.tabDisplay.Text = "Network Status";
            // 
            // tabTraining
            // 
            this.tabTraining.Location = new System.Drawing.Point(27, 4);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Size = new System.Drawing.Size(234, 447);
            this.tabTraining.TabIndex = 0;
            this.tabTraining.Text = "Network Training";
            // 
            // tabRanges
            // 
            this.tabRanges.Location = new System.Drawing.Point(27, 4);
            this.tabRanges.Name = "tabRanges";
            this.tabRanges.Size = new System.Drawing.Size(234, 447);
            this.tabRanges.TabIndex = 2;
            this.tabRanges.Text = "Database Schema";
            // 
            // tabWorkplace
            // 
            this.tabWorkplace.Location = new System.Drawing.Point(50, 4);
            this.tabWorkplace.Name = "tabWorkplace";
            this.tabWorkplace.Size = new System.Drawing.Size(211, 447);
            this.tabWorkplace.TabIndex = 3;
            this.tabWorkplace.Text = "Workplace";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SideTabControl
            // 
            this.Controls.Add(this.tabControl);
            this.Size = new System.Drawing.Size(265, 455);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dotnetrix.Controls.TabControlEX tabControl;
        private Dotnetrix.Controls.TabPageEX tabDisplay;
        private Dotnetrix.Controls.TabPageEX tabTraining;
        private Dotnetrix.Controls.TabPageEX tabRanges;
        private Dotnetrix.Controls.TabPageEX tabWorkplace;
        private System.Windows.Forms.ImageList imageList;
    }
}
