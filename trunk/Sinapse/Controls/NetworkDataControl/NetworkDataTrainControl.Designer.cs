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
    partial class NetworkDataTrainControl
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDataTrainControl));
            this.label3 = new System.Windows.Forms.Label();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.panelValidationCaption = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuValidationAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuValidationRem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "(0 %)";
            this.label3.Visible = false;
            // 
            // btnShuffle
            // 
            this.btnShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShuffle.Image = ((System.Drawing.Image)(resources.GetObject("btnShuffle.Image")));
            this.btnShuffle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShuffle.Location = new System.Drawing.Point(418, 348);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(78, 23);
            this.btnShuffle.TabIndex = 19;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // panelValidationCaption
            // 
            this.panelValidationCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelValidationCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelValidationCaption.Location = new System.Drawing.Point(161, 353);
            this.panelValidationCaption.Name = "panelValidationCaption";
            this.panelValidationCaption.Size = new System.Drawing.Size(14, 12);
            this.panelValidationCaption.TabIndex = 18;
            this.panelValidationCaption.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 11);
            this.label4.TabIndex = 17;
            this.label4.Text = "Validation";
            this.label4.Visible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuValidationAdd,
            this.MenuValidationRem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(192, 70);
            // 
            // MenuValidationAdd
            // 
            this.MenuValidationAdd.Name = "MenuValidationAdd";
            this.MenuValidationAdd.Size = new System.Drawing.Size(191, 22);
            this.MenuValidationAdd.Text = "Use as validation data";
            this.MenuValidationAdd.Click += new System.EventHandler(this.MenuValidationAdd_Click);
            // 
            // MenuValidationRem
            // 
            this.MenuValidationRem.Name = "MenuValidationRem";
            this.MenuValidationRem.Size = new System.Drawing.Size(191, 22);
            this.MenuValidationRem.Text = "Use as training data";
            this.MenuValidationRem.Click += new System.EventHandler(this.MenuValidationRem_Click);
            // 
            // NetworkDataTrainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.panelValidationCaption);
            this.Controls.Add(this.label4);
            this.Name = "NetworkDataTrainControl";
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.panelValidationCaption, 0);
            this.Controls.SetChildIndex(this.btnShuffle, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.Panel panelValidationCaption;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuValidationAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuValidationRem;
    }
}
