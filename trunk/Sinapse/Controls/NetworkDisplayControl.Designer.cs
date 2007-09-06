/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2007 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

namespace Sinapse.Controls
{
    partial class NetworkDisplayControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDisplayControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbIntro = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbDescriptionChange = new System.Windows.Forms.Label();
            this.lbDescriptionH = new System.Windows.Forms.Label();
            this.lbPrecisionH = new System.Windows.Forms.Label();
            this.lbNetworkLayoutH = new System.Windows.Forms.Label();
            this.lbErrorRate = new System.Windows.Forms.Label();
            this.lbLayout = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbIntro);
            this.groupBox1.Controls.Add(this.lbDescription);
            this.groupBox1.Controls.Add(this.lbDescriptionChange);
            this.groupBox1.Controls.Add(this.lbDescriptionH);
            this.groupBox1.Controls.Add(this.lbPrecisionH);
            this.groupBox1.Controls.Add(this.lbNetworkLayoutH);
            this.groupBox1.Controls.Add(this.lbErrorRate);
            this.groupBox1.Controls.Add(this.lbLayout);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 285);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Network Status";
            // 
            // lbIntro
            // 
            this.lbIntro.Location = new System.Drawing.Point(28, 206);
            this.lbIntro.Name = "lbIntro";
            this.lbIntro.Size = new System.Drawing.Size(146, 44);
            this.lbIntro.TabIndex = 17;
            this.lbIntro.Text = "Please create or load a network to start working with.";
            this.lbIntro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescription.AutoEllipsis = true;
            this.lbDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDescription.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDescription.Location = new System.Drawing.Point(16, 254);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(178, 23);
            this.lbDescription.TabIndex = 16;
            this.lbDescription.Click += new System.EventHandler(this.lbDescription_Click);
            // 
            // lbDescriptionChange
            // 
            this.lbDescriptionChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescriptionChange.AutoSize = true;
            this.lbDescriptionChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDescriptionChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescriptionChange.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDescriptionChange.Location = new System.Drawing.Point(153, 236);
            this.lbDescriptionChange.Name = "lbDescriptionChange";
            this.lbDescriptionChange.Size = new System.Drawing.Size(41, 12);
            this.lbDescriptionChange.TabIndex = 16;
            this.lbDescriptionChange.Text = "[change]";
            this.lbDescriptionChange.Click += new System.EventHandler(this.lbDescription_Click);
            // 
            // lbDescriptionH
            // 
            this.lbDescriptionH.AutoSize = true;
            this.lbDescriptionH.Location = new System.Drawing.Point(6, 235);
            this.lbDescriptionH.Name = "lbDescriptionH";
            this.lbDescriptionH.Size = new System.Drawing.Size(63, 13);
            this.lbDescriptionH.TabIndex = 16;
            this.lbDescriptionH.Text = "Description:";
            // 
            // lbPrecisionH
            // 
            this.lbPrecisionH.AutoSize = true;
            this.lbPrecisionH.Location = new System.Drawing.Point(6, 211);
            this.lbPrecisionH.Name = "lbPrecisionH";
            this.lbPrecisionH.Size = new System.Drawing.Size(90, 13);
            this.lbPrecisionH.TabIndex = 16;
            this.lbPrecisionH.Text = "Answer precision:";
            // 
            // lbNetworkLayoutH
            // 
            this.lbNetworkLayoutH.AutoSize = true;
            this.lbNetworkLayoutH.Location = new System.Drawing.Point(6, 196);
            this.lbNetworkLayoutH.Name = "lbNetworkLayoutH";
            this.lbNetworkLayoutH.Size = new System.Drawing.Size(81, 13);
            this.lbNetworkLayoutH.TabIndex = 16;
            this.lbNetworkLayoutH.Text = "Network layout:";
            // 
            // lbErrorRate
            // 
            this.lbErrorRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbErrorRate.Location = new System.Drawing.Point(97, 211);
            this.lbErrorRate.Name = "lbErrorRate";
            this.lbErrorRate.Size = new System.Drawing.Size(97, 13);
            this.lbErrorRate.TabIndex = 16;
            // 
            // lbLayout
            // 
            this.lbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLayout.Location = new System.Drawing.Point(97, 196);
            this.lbLayout.Name = "lbLayout";
            this.lbLayout.Size = new System.Drawing.Size(97, 13);
            this.lbLayout.TabIndex = 16;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoEllipsis = true;
            this.lbName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbName.Location = new System.Drawing.Point(9, 159);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(185, 37);
            this.lbName.TabIndex = 16;
            this.lbName.Text = "Network Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(36, 27);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(128, 128);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 15;
            this.pictureBox.TabStop = false;
            // 
            // NetworkDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Enabled = false;
            this.Name = "NetworkDisplayControl";
            this.Size = new System.Drawing.Size(200, 285);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbDescriptionH;
        private System.Windows.Forms.Label lbPrecisionH;
        private System.Windows.Forms.Label lbNetworkLayoutH;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbErrorRate;
        private System.Windows.Forms.Label lbLayout;
        private System.Windows.Forms.Label lbDescriptionChange;
        private System.Windows.Forms.Label lbIntro;
    }
}
