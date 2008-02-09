namespace Sinapse.Controls.NetworkDataTab
{
    partial class TabPageTesting
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
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.Text = "Testing Set";
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Image = global::Sinapse.Properties.Resources.switchuser;
            this.btnCompare.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompare.Location = new System.Drawing.Point(429, 372);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(80, 23);
            this.btnCompare.TabIndex = 29;
            this.btnCompare.Text = "Compare";
            this.btnCompare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Image = global::Sinapse.Properties.Resources.gear_22;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.Location = new System.Drawing.Point(354, 372);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(69, 23);
            this.btnQuery.TabIndex = 30;
            this.btnQuery.Text = "Query!";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // TabTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnQuery);
            this.Name = "TabTesting";
            this.Controls.SetChildIndex(this.btnQuery, 0);
            this.Controls.SetChildIndex(this.btnCompare, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnQuery;
    }
}
