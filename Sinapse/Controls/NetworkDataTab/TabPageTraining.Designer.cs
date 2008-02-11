namespace Sinapse.Controls.NetworkDataTab
{
    partial class TabPageTraining
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
            this.cbTrainingLayer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.Text = "Training Sets";
            // 
            // cbTrainingLayer
            // 
            this.cbTrainingLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTrainingLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainingLayer.FormattingEnabled = true;
            this.cbTrainingLayer.Location = new System.Drawing.Point(466, 7);
            this.cbTrainingLayer.Name = "cbTrainingLayer";
            this.cbTrainingLayer.Size = new System.Drawing.Size(92, 21);
            this.cbTrainingLayer.TabIndex = 29;
            this.cbTrainingLayer.SelectedIndexChanged += new System.EventHandler(this.cbTrainingSets_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Layer:";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.Image = global::Sinapse.Properties.Resources.edit_remove;
            this.btnDel.Location = new System.Drawing.Point(564, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(16, 16);
            this.btnDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnDel.TabIndex = 31;
            this.btnDel.TabStop = false;
            // 
            // TabPageTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbTrainingLayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDel);
            this.Name = "TabPageTraining";
            this.Load += new System.EventHandler(this.TabPageTraining_Load);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbTrainingLayer, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTrainingLayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnDel;


    }
}
