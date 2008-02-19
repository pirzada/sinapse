namespace Sinapse.Controls.NetworkDataTab
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
            this.tabSetImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabTraining = new Dotnetrix.Controls.TabPageEX();
            this.tabValidation = new Dotnetrix.Controls.TabPageEX();
            this.tabTesting = new Dotnetrix.Controls.TabPageEX();
            this.tabQuery = new Dotnetrix.Controls.TabPageEX();
            this.tabGraph = new Dotnetrix.Controls.TabPageEX();
            this.tabPageTraining1 = new Sinapse.Controls.NetworkDataTab.TabPageTraining();
            this.tabPageValidation = new Sinapse.Controls.NetworkDataTab.TabPageValidation();
            this.tabPageTesting = new Sinapse.Controls.NetworkDataTab.TabPageTesting();
            this.tabPageQuery = new Sinapse.Controls.NetworkDataTab.TabPageQuery();
            this.tabPageGraph = new Sinapse.Controls.NetworkDataTab.TabPageGraph();
            this.tabControl.SuspendLayout();
            this.tabTraining.SuspendLayout();
            this.tabValidation.SuspendLayout();
            this.tabTesting.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.tabGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTraining);
            this.tabControl.Controls.Add(this.tabValidation);
            this.tabControl.Controls.Add(this.tabTesting);
            this.tabControl.Controls.Add(this.tabQuery);
            this.tabControl.Controls.Add(this.tabGraph);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ImageList = this.tabSetImageList;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(558, 445);
            this.tabControl.TabIndex = 0;
            // 
            // tabSetImageList
            // 
            this.tabSetImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabSetImageList.ImageStream")));
            this.tabSetImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabSetImageList.Images.SetKeyName(0, "Training.png");
            this.tabSetImageList.Images.SetKeyName(1, "Validating.png");
            this.tabSetImageList.Images.SetKeyName(2, "Testing.png");
            this.tabSetImageList.Images.SetKeyName(3, "Query.png");
            this.tabSetImageList.Images.SetKeyName(4, "Graph");
            // 
            // tabTraining
            // 
            this.tabTraining.Controls.Add(this.tabPageTraining1);
            this.tabTraining.ImageIndex = 0;
            this.tabTraining.Location = new System.Drawing.Point(4, 23);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Size = new System.Drawing.Size(550, 418);
            this.tabTraining.TabIndex = 0;
            this.tabTraining.Text = "Training Set";
            this.tabTraining.UseVisualStyleBackColor = true;
            // 
            // tabValidation
            // 
            this.tabValidation.Controls.Add(this.tabPageValidation);
            this.tabValidation.ImageIndex = 1;
            this.tabValidation.Location = new System.Drawing.Point(4, 23);
            this.tabValidation.Name = "tabValidation";
            this.tabValidation.Size = new System.Drawing.Size(550, 418);
            this.tabValidation.TabIndex = 1;
            this.tabValidation.Text = "Validation Set";
            this.tabValidation.UseVisualStyleBackColor = true;
            // 
            // tabTesting
            // 
            this.tabTesting.Controls.Add(this.tabPageTesting);
            this.tabTesting.ImageIndex = 2;
            this.tabTesting.Location = new System.Drawing.Point(4, 23);
            this.tabTesting.Name = "tabTesting";
            this.tabTesting.Size = new System.Drawing.Size(550, 418);
            this.tabTesting.TabIndex = 2;
            this.tabTesting.Text = "Testing Set";
            this.tabTesting.UseVisualStyleBackColor = true;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.tabPageQuery);
            this.tabQuery.ImageIndex = 3;
            this.tabQuery.Location = new System.Drawing.Point(4, 23);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Size = new System.Drawing.Size(550, 418);
            this.tabQuery.TabIndex = 3;
            this.tabQuery.Text = "Query";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // tabGraph
            // 
            this.tabGraph.Controls.Add(this.tabPageGraph);
            this.tabGraph.ImageIndex = 4;
            this.tabGraph.Location = new System.Drawing.Point(4, 23);
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.Size = new System.Drawing.Size(550, 418);
            this.tabGraph.TabIndex = 4;
            this.tabGraph.Text = "Graph";
            this.tabGraph.UseVisualStyleBackColor = true;
            // 
            // tabPageTraining1
            // 
            this.tabPageTraining1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageTraining1.Location = new System.Drawing.Point(0, 0);
            this.tabPageTraining1.Name = "tabPageTraining1";
            this.tabPageTraining1.Size = new System.Drawing.Size(550, 418);
            this.tabPageTraining1.TabIndex = 0;
            // 
            // tabPageValidation
            // 
            this.tabPageValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageValidation.Location = new System.Drawing.Point(0, 0);
            this.tabPageValidation.Name = "tabPageValidation";
            this.tabPageValidation.Size = new System.Drawing.Size(550, 418);
            this.tabPageValidation.TabIndex = 0;
            // 
            // tabPageTesting
            // 
            this.tabPageTesting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageTesting.Location = new System.Drawing.Point(0, 0);
            this.tabPageTesting.Name = "tabPageTesting";
            this.tabPageTesting.Size = new System.Drawing.Size(550, 418);
            this.tabPageTesting.TabIndex = 0;
            // 
            // tabPageQuery
            // 
            this.tabPageQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageQuery.Location = new System.Drawing.Point(0, 0);
            this.tabPageQuery.Name = "tabPageQuery";
            this.tabPageQuery.Size = new System.Drawing.Size(550, 418);
            this.tabPageQuery.TabIndex = 0;
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageGraph.Location = new System.Drawing.Point(0, 0);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Size = new System.Drawing.Size(550, 418);
            this.tabPageGraph.TabIndex = 0;
            // 
            // MainTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "MainTabControl";
            this.Size = new System.Drawing.Size(558, 445);
            this.tabControl.ResumeLayout(false);
            this.tabTraining.ResumeLayout(false);
            this.tabValidation.ResumeLayout(false);
            this.tabTesting.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.tabGraph.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dotnetrix.Controls.TabControlEX tabControl;
        private System.Windows.Forms.ImageList tabSetImageList;
        private Dotnetrix.Controls.TabPageEX tabTraining;
        private Dotnetrix.Controls.TabPageEX tabValidation;
        private Dotnetrix.Controls.TabPageEX tabTesting;
        private Dotnetrix.Controls.TabPageEX tabQuery;
        private Dotnetrix.Controls.TabPageEX tabGraph;
        private TabPageTraining tabPageTraining1;
        private TabPageValidation tabPageValidation;
        private TabPageTesting tabPageTesting;
        private TabPageQuery tabPageQuery;
        private TabPageGraph tabPageGraph;
    }
}
