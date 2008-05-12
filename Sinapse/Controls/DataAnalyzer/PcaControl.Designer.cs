namespace Sinapse.Controls.DataAnalyzer
{
    partial class PcaControl
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
            this.dataGridViewEx1 = new Sinapse.Forms.Controls.DataGridViewEx();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Location = new System.Drawing.Point(216, 3);
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.Size = new System.Drawing.Size(585, 324);
            this.dataGridViewEx1.TabIndex = 0;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(497, 333);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(304, 236);
            this.zedGraphControl1.TabIndex = 1;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(216, 333);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0;
            this.zedGraphControl2.ScrollMaxX = 0;
            this.zedGraphControl2.ScrollMaxY = 0;
            this.zedGraphControl2.ScrollMaxY2 = 0;
            this.zedGraphControl2.ScrollMinX = 0;
            this.zedGraphControl2.ScrollMinY = 0;
            this.zedGraphControl2.ScrollMinY2 = 0;
            this.zedGraphControl2.Size = new System.Drawing.Size(275, 236);
            this.zedGraphControl2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 546);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PcaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.dataGridViewEx1);
            this.Name = "PcaControl";
            this.Size = new System.Drawing.Size(804, 572);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sinapse.Forms.Controls.DataGridViewEx dataGridViewEx1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
