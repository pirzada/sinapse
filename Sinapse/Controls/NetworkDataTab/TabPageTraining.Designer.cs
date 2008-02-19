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
            this.lbLayer = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.PictureBox();
            this.btnShuffle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).BeginInit();
            this.SuspendLayout();
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
            // lbLayer
            // 
            this.lbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLayer.AutoSize = true;
            this.lbLayer.Location = new System.Drawing.Point(426, 11);
            this.lbLayer.Name = "lbLayer";
            this.lbLayer.Size = new System.Drawing.Size(36, 13);
            this.lbLayer.TabIndex = 30;
            this.lbLayer.Text = "Layer:";
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
            // btnShuffle
            // 
            this.btnShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShuffle.Image = global::Sinapse.Properties.Resources.quick_restart;
            this.btnShuffle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShuffle.Location = new System.Drawing.Point(439, 372);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(70, 23);
            this.btnShuffle.TabIndex = 32;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // TabPageTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.cbTrainingLayer);
            this.Controls.Add(this.lbLayer);
            this.Controls.Add(this.btnDel);
            this.Name = "TabPageTraining";
            this.Controls.SetChildIndex(this.lbSetTitle, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.lbLayer, 0);
            this.Controls.SetChildIndex(this.cbTrainingLayer, 0);
            this.Controls.SetChildIndex(this.btnShuffle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTrainingLayer;
        private System.Windows.Forms.Label lbLayer;
        private System.Windows.Forms.PictureBox btnDel;
        private System.Windows.Forms.Button btnShuffle;


    }
}
