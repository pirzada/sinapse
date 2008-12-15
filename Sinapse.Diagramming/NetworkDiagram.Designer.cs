namespace Sinapse.Diagramming
{
    partial class NetworkDiagram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDiagram));
            this.diagramControl1 = new Netron.Diagramming.Win.DiagramControl();
            ((System.ComponentModel.ISupportInitialize)(this.diagramControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // diagramControl1
            // 
            this.diagramControl1.AllowDrop = true;
            this.diagramControl1.AutoScroll = true;
            this.diagramControl1.BackColor = System.Drawing.Color.White;
            this.diagramControl1.BackgroundType = Netron.Diagramming.Core.CanvasBackgroundTypes.FlatColor;
            this.diagramControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramControl1.Document = ((Netron.Diagramming.Core.Document)(resources.GetObject("diagramControl1.Document")));
            this.diagramControl1.EnableAddConnection = true;
            this.diagramControl1.Location = new System.Drawing.Point(0, 0);
            this.diagramControl1.Magnification = new System.Drawing.SizeF(100F, 100F);
            this.diagramControl1.Name = "diagramControl1";
            this.diagramControl1.Origin = new System.Drawing.Point(0, 0);
            this.diagramControl1.ShowPage = false;
            this.diagramControl1.ShowRulers = false;
            this.diagramControl1.Size = new System.Drawing.Size(455, 265);
            this.diagramControl1.TabIndex = 0;
            this.diagramControl1.Text = "diagramControl1";
            // 
            // NetworkDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.diagramControl1);
            this.Name = "NetworkDiagram";
            this.Size = new System.Drawing.Size(455, 265);
            ((System.ComponentModel.ISupportInitialize)(this.diagramControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Netron.Diagramming.Win.DiagramControl diagramControl1;
    }
}
