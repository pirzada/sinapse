using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Sinapse.Windows.Documents
{
    public partial class StartPage : DockContent
    {
        private WebBrowser webBrowser1;
    
        public StartPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(292, 266);
            this.webBrowser1.TabIndex = 0;
            // 
            // StartPage
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.webBrowser1);
            this.Name = "StartPage";
            this.TabText = "Start Page";
            this.Text = "Start Page";
            this.ResumeLayout(false);

        }
    }
}
