using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.InteropServices;

using Sinapse.Properties;

using WeifenLuo.WinFormsUI.Docking;

namespace Sinapse.Windows.Documents
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisibleAttribute(true)]
    public partial class StartPage : DockContent
    {
        private WebBrowser webBrowser1;
    
        public StartPage()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
        }

        public void OpenWorkspace(string path)
        {
        }

        public void OpenDocument(string path)
        {
        }

        public string CreateStartPage(string model)
        {
            StringBuilder sb = new StringBuilder(model);
            sb.Replace("<!--WORKPLACES-->", CreateFileListing("OpenWorkplace", Settings.Default.mruWorkplaces));
            sb.Replace("<!--DOCUMENTS-->",  CreateFileListing("OpenDocument", Settings.Default.mruDocuments));
            return sb.ToString();
        }

        public string CreateFileListing(string method, StringCollection workplaces)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string path in workplaces)
            {
                sb.AppendFormat("<li><a href=\"#\" onclick=\"window.external.{0}('{1}')\">{2}</a></li>\n",
                    method, path, System.IO.Path.GetFileNameWithoutExtension(path));
            }
            return sb.ToString();
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
            this.webBrowser1.ObjectForScripting = this;
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
