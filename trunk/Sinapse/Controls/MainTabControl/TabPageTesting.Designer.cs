namespace Sinapse.Controls.MainTabControl
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
            this.btnRound = new System.Windows.Forms.Button();
            this.panelNetworkCaption = new System.Windows.Forms.Panel();
            this.lbNetwork = new System.Windows.Forms.Label();
            this.panelDeltaCaption = new System.Windows.Forms.Panel();
            this.lbDelta = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Image = global::Sinapse.Properties.Resources.gear_22;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.Location = new System.Drawing.Point(340, 372);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(83, 23);
            this.btnQuery.TabIndex = 30;
            this.btnQuery.Text = "Compute!";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnRound
            // 
            this.btnRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRound.Image = global::Sinapse.Properties.Resources.precminus;
            this.btnRound.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRound.Location = new System.Drawing.Point(498, 5);
            this.btnRound.Name = "btnRound";
            this.btnRound.Size = new System.Drawing.Size(87, 23);
            this.btnRound.TabIndex = 30;
            this.btnRound.Text = "Round results";
            this.btnRound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRound.UseVisualStyleBackColor = true;
            this.btnRound.Click += new System.EventHandler(this.btnRound_Click);
            // 
            // panelNetworkCaption
            // 
            this.panelNetworkCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelNetworkCaption.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelNetworkCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNetworkCaption.Location = new System.Drawing.Point(148, 377);
            this.panelNetworkCaption.Name = "panelNetworkCaption";
            this.panelNetworkCaption.Size = new System.Drawing.Size(14, 12);
            this.panelNetworkCaption.TabIndex = 32;
            // 
            // lbNetwork
            // 
            this.lbNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNetwork.AutoSize = true;
            this.lbNetwork.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNetwork.Location = new System.Drawing.Point(165, 378);
            this.lbNetwork.Name = "lbNetwork";
            this.lbNetwork.Size = new System.Drawing.Size(61, 11);
            this.lbNetwork.TabIndex = 31;
            this.lbNetwork.Text = "Network";
            // 
            // panelDeltaCaption
            // 
            this.panelDeltaCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelDeltaCaption.BackColor = System.Drawing.Color.Khaki;
            this.panelDeltaCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeltaCaption.Location = new System.Drawing.Point(232, 377);
            this.panelDeltaCaption.Name = "panelDeltaCaption";
            this.panelDeltaCaption.Size = new System.Drawing.Size(14, 12);
            this.panelDeltaCaption.TabIndex = 34;
            // 
            // lbDelta
            // 
            this.lbDelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDelta.AutoSize = true;
            this.lbDelta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDelta.Location = new System.Drawing.Point(249, 378);
            this.lbDelta.Name = "lbDelta";
            this.lbDelta.Size = new System.Drawing.Size(45, 11);
            this.lbDelta.TabIndex = 33;
            this.lbDelta.Text = "Delta";
            // 
            // lbScore
            // 
            this.lbScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScore.AutoEllipsis = true;
            this.lbScore.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore.Location = new System.Drawing.Point(349, 15);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(142, 11);
            this.lbScore.TabIndex = 33;
            this.lbScore.Text = "Deviation:";
            // 
            // TabPageTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDeltaCaption);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.lbDelta);
            this.Controls.Add(this.panelNetworkCaption);
            this.Controls.Add(this.lbNetwork);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnRound);
            this.Controls.Add(this.btnQuery);
            this.Name = "TabPageTesting";
            this.Controls.SetChildIndex(this.btnQuery, 0);
            this.Controls.SetChildIndex(this.btnRound, 0);
            this.Controls.SetChildIndex(this.btnCompare, 0);
            this.Controls.SetChildIndex(this.lbNetwork, 0);
            this.Controls.SetChildIndex(this.panelNetworkCaption, 0);
            this.Controls.SetChildIndex(this.lbSetTitle, 0);
            this.Controls.SetChildIndex(this.lbDelta, 0);
            this.Controls.SetChildIndex(this.lbScore, 0);
            this.Controls.SetChildIndex(this.panelDeltaCaption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnRound;
        private System.Windows.Forms.Panel panelNetworkCaption;
        private System.Windows.Forms.Label lbNetwork;
        private System.Windows.Forms.Panel panelDeltaCaption;
        private System.Windows.Forms.Label lbDelta;
        private System.Windows.Forms.Label lbScore;
    }
}
