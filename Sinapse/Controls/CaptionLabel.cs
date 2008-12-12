using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Controls
{
    public partial class CaptionLabel : UserControl
    {

        private System.Windows.Forms.Panel paneColor;
        private System.Windows.Forms.Label lbCaption;


        public CaptionLabel()
        {
            InitializeComponent();
            lbCaption.Text = this.Text;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return lbCaption.Text; }
            set { lbCaption.Text = value; }
        }

        public Color Color
        {
            get { return paneColor.BackColor; }
            set { paneColor.BackColor = value; }
        }



        private void InitializeComponent()
        {
            this.paneColor = new System.Windows.Forms.Panel();
            this.lbCaption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // paneColor
            // 
            this.paneColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paneColor.Location = new System.Drawing.Point(3, 2);
            this.paneColor.Name = "paneColor";
            this.paneColor.Size = new System.Drawing.Size(15, 15);
            this.paneColor.TabIndex = 1;
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Location = new System.Drawing.Point(24, 3);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(69, 13);
            this.lbCaption.TabIndex = 2;
            this.lbCaption.Text = this.Name;
            // 
            // CaptionLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.lbCaption);
            this.Controls.Add(this.paneColor);
            this.Name = "CaptionLabel";
            this.Size = new System.Drawing.Size(96, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}
