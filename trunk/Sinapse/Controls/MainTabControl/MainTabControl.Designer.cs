namespace Sinapse.Controls.MainTabControl
{
    partial class MainTabControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabControl));
            this.tabControl = new Dotnetrix.Controls.TabControlEX();
            this.tabTraining = new Dotnetrix.Controls.TabPageEX();
            this.tabValidation = new Dotnetrix.Controls.TabPageEX();
            this.tabTesting = new Dotnetrix.Controls.TabPageEX();
            this.tabQuery = new Dotnetrix.Controls.TabPageEX();
            this.tabGraph = new Dotnetrix.Controls.TabPageEX();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = Dotnetrix.Controls.TabAppearanceEX.Bevel;
            this.tabControl.Controls.Add(this.tabTraining);
            this.tabControl.Controls.Add(this.tabValidation);
            this.tabControl.Controls.Add(this.tabTesting);
            this.tabControl.Controls.Add(this.tabQuery);
            this.tabControl.Controls.Add(this.tabGraph);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabControl.HotTrack = true;
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(558, 445);
            this.tabControl.TabIndex = 0;
            this.tabControl.UseVisualStyles = false;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabTraining
            // 
            this.tabTraining.ImageIndex = 0;
            this.tabTraining.Location = new System.Drawing.Point(4, 25);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Size = new System.Drawing.Size(550, 416);
            this.tabTraining.TabIndex = 0;
            // 
            // tabValidation
            // 
            this.tabValidation.ImageIndex = 1;
            this.tabValidation.Location = new System.Drawing.Point(4, 25);
            this.tabValidation.Name = "tabValidation";
            this.tabValidation.Size = new System.Drawing.Size(550, 416);
            this.tabValidation.TabIndex = 1;
            // 
            // tabTesting
            // 
            this.tabTesting.ImageIndex = 2;
            this.tabTesting.Location = new System.Drawing.Point(4, 25);
            this.tabTesting.Name = "tabTesting";
            this.tabTesting.Size = new System.Drawing.Size(550, 416);
            this.tabTesting.TabIndex = 2;
            // 
            // tabQuery
            // 
            this.tabQuery.ImageIndex = 3;
            this.tabQuery.Location = new System.Drawing.Point(4, 25);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Size = new System.Drawing.Size(550, 416);
            this.tabQuery.TabIndex = 3;
            // 
            // tabGraph
            // 
            this.tabGraph.ImageIndex = 4;
            this.tabGraph.Location = new System.Drawing.Point(4, 25);
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.Size = new System.Drawing.Size(550, 416);
            this.tabGraph.TabIndex = 4;
            this.tabGraph.Text = "Training History";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Training.png");
            this.imageList.Images.SetKeyName(1, "Validating.png");
            this.imageList.Images.SetKeyName(2, "Testing.png");
            this.imageList.Images.SetKeyName(3, "Query.png");
            this.imageList.Images.SetKeyName(4, "Graph");
            // 
            // MainTabControl
            // 
            this.Controls.Add(this.tabControl);
            this.Size = new System.Drawing.Size(558, 445);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dotnetrix.Controls.TabControlEX tabControl;
        private System.Windows.Forms.ImageList imageList;
        private Dotnetrix.Controls.TabPageEX tabTraining;
        private Dotnetrix.Controls.TabPageEX tabValidation;
        private Dotnetrix.Controls.TabPageEX tabTesting;
        private Dotnetrix.Controls.TabPageEX tabQuery;
        private Dotnetrix.Controls.TabPageEX tabGraph;
    }
}
