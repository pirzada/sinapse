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

namespace Sinapse.Controls.Sidebar
{
    partial class SideDisplayControl
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
            this.lbTableTitle = new System.Windows.Forms.Label();
            this.lbInput = new System.Windows.Forms.Label();
            this.lbOutput = new System.Windows.Forms.Label();
            this.panelInputs = new System.Windows.Forms.FlowLayoutPanel();
            this.panelOutputs = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIntro
            // 
            this.lbIntro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIntro.Location = new System.Drawing.Point(18, 190);
            this.lbIntro.Name = "lbIntro";
            this.lbIntro.Size = new System.Drawing.Size(180, 44);
            this.lbIntro.TabIndex = 27;
            this.lbIntro.Text = "Please create or load a network to start working with.";
            this.lbIntro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescription.AutoEllipsis = true;
            this.lbDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDescription.Location = new System.Drawing.Point(16, 238);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(194, 48);
            this.lbDescription.TabIndex = 24;
            // 
            // lbDescriptionChange
            // 
            this.lbDescriptionChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescriptionChange.AutoSize = true;
            this.lbDescriptionChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDescriptionChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescriptionChange.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDescriptionChange.Location = new System.Drawing.Point(169, 220);
            this.lbDescriptionChange.Name = "lbDescriptionChange";
            this.lbDescriptionChange.Size = new System.Drawing.Size(41, 12);
            this.lbDescriptionChange.TabIndex = 23;
            this.lbDescriptionChange.Text = "[change]";
            this.lbDescriptionChange.Click += new System.EventHandler(this.lbDescription_Click);
            // 
            // lbDescriptionH
            // 
            this.lbDescriptionH.AutoSize = true;
            this.lbDescriptionH.Location = new System.Drawing.Point(6, 219);
            this.lbDescriptionH.Name = "lbDescriptionH";
            this.lbDescriptionH.Size = new System.Drawing.Size(63, 13);
            this.lbDescriptionH.TabIndex = 26;
            this.lbDescriptionH.Text = "Description:";
            // 
            // lbPrecisionH
            // 
            this.lbPrecisionH.AutoSize = true;
            this.lbPrecisionH.Location = new System.Drawing.Point(6, 195);
            this.lbPrecisionH.Name = "lbPrecisionH";
            this.lbPrecisionH.Size = new System.Drawing.Size(90, 13);
            this.lbPrecisionH.TabIndex = 25;
            this.lbPrecisionH.Text = "Answer precision:";
            // 
            // lbNetworkLayoutH
            // 
            this.lbNetworkLayoutH.AutoSize = true;
            this.lbNetworkLayoutH.Location = new System.Drawing.Point(6, 180);
            this.lbNetworkLayoutH.Name = "lbNetworkLayoutH";
            this.lbNetworkLayoutH.Size = new System.Drawing.Size(81, 13);
            this.lbNetworkLayoutH.TabIndex = 20;
            this.lbNetworkLayoutH.Text = "Network layout:";
            // 
            // lbErrorRate
            // 
            this.lbErrorRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbErrorRate.Location = new System.Drawing.Point(97, 195);
            this.lbErrorRate.Name = "lbErrorRate";
            this.lbErrorRate.Size = new System.Drawing.Size(113, 13);
            this.lbErrorRate.TabIndex = 19;
            // 
            // lbLayout
            // 
            this.lbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLayout.Location = new System.Drawing.Point(97, 180);
            this.lbLayout.Name = "lbLayout";
            this.lbLayout.Size = new System.Drawing.Size(113, 13);
            this.lbLayout.TabIndex = 22;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoEllipsis = true;
            this.lbName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbName.Location = new System.Drawing.Point(9, 143);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(201, 37);
            this.lbName.TabIndex = 21;
            this.lbName.Text = "Network Not Created";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Image = global::Sinapse.Properties.Resources.globe_128;
            this.pictureBox.Location = new System.Drawing.Point(0, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(216, 128);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 18;
            this.pictureBox.TabStop = false;
            // 
            // lbTableTitle
            // 
            this.lbTableTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTableTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableTitle.Location = new System.Drawing.Point(11, 298);
            this.lbTableTitle.Name = "lbTableTitle";
            this.lbTableTitle.Size = new System.Drawing.Size(195, 27);
            this.lbTableTitle.TabIndex = 28;
            this.lbTableTitle.Text = "This network has been designed to work with the following data:";
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput.Location = new System.Drawing.Point(10, 331);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(37, 12);
            this.lbInput.TabIndex = 28;
            this.lbInput.Text = "Inputs";
            // 
            // lbOutput
            // 
            this.lbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOutput.AutoSize = true;
            this.lbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutput.Location = new System.Drawing.Point(111, 331);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(45, 12);
            this.lbOutput.TabIndex = 28;
            this.lbOutput.Text = "Outputs";
            // 
            // panelInputs
            // 
            this.panelInputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelInputs.AutoScroll = true;
            this.panelInputs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelInputs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelInputs.Location = new System.Drawing.Point(13, 346);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(89, 153);
            this.panelInputs.TabIndex = 30;
            // 
            // panelOutputs
            // 
            this.panelOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOutputs.AutoScroll = true;
            this.panelOutputs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOutputs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelOutputs.Location = new System.Drawing.Point(113, 346);
            this.panelOutputs.Name = "panelOutputs";
            this.panelOutputs.Size = new System.Drawing.Size(89, 153);
            this.panelOutputs.TabIndex = 30;
            // 
            // SideDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panelOutputs);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.lbTableTitle);
            this.Controls.Add(this.lbIntro);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbDescriptionChange);
            this.Controls.Add(this.lbDescriptionH);
            this.Controls.Add(this.lbPrecisionH);
            this.Controls.Add(this.lbNetworkLayoutH);
            this.Controls.Add(this.lbErrorRate);
            this.Controls.Add(this.lbLayout);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox);
            this.Enabled = false;
            this.Name = "SideDisplayControl";
            this.Size = new System.Drawing.Size(216, 502);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIntro;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbDescriptionChange;
        private System.Windows.Forms.Label lbDescriptionH;
        private System.Windows.Forms.Label lbPrecisionH;
        private System.Windows.Forms.Label lbNetworkLayoutH;
        private System.Windows.Forms.Label lbErrorRate;
        private System.Windows.Forms.Label lbLayout;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbTableTitle;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.FlowLayoutPanel panelInputs;
        private System.Windows.Forms.FlowLayoutPanel panelOutputs;

    }
}
