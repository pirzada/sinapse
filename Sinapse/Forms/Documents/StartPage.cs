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
using System.IO;

using Sinapse.WinForms.Properties;
using Sinapse.WinForms.Core;


namespace Sinapse.WinForms.Documents
{


    public partial class StartPage : SinapseDocumentView
    {
        private WebBrowser webBrowser1;
        private ScriptingObject scriptingObject;
        private String address;
        private String pageModel;

    
        public StartPage(Workbench workbench) : base(workbench, null)
        {
            address = Path.Combine(Application.StartupPath,
                Sinapse.WinForms.Properties.Settings.Default.startpage_path);
            
         
            InitializeComponent();

            this.scriptingObject = new ScriptingObject(workbench);
            this.webBrowser1.Url = new Uri(address);
            this.webBrowser1.ObjectForScripting = scriptingObject;
        }


        private void documentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement col;

            // Create Most Recently Used Workplaces List
            col = this.webBrowser1.Document.GetElementById("recentWorkplaces");
            if (col != null)
            {
                col.InnerHtml = createFileListing("WorkplaceOpenPath", Settings.Default.mruWorkplaces);
            }

            // Create Most Recently Used Document List
            col = this.webBrowser1.Document.GetElementById("recentDocuments");
            if (col != null)
            {
                col.InnerHtml = createFileListing("DocumentOpenPath", Settings.Default.mruDocuments);
            }
        }



        private string createFileListing(string method, StringCollection files)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach(string path in files)
            {
                string safePath = path.Replace(@"\",@"\\");
                sb.AppendFormat("<li><a href=\"#\" onclick=\"window.external.{0}('{1}')\">{2}</a></li>\n",
                    method, safePath, System.IO.Path.GetFileNameWithoutExtension(path));
            }
            sb.Append("</ul>");
            return sb.ToString();
        }






        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(569, 312);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.documentCompleted);
            // 
            // StartPage
            // 
            this.ClientSize = new System.Drawing.Size(569, 312);
            this.Controls.Add(this.webBrowser1);
            this.Name = "StartPage";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Start Page";
            this.Text = "Start Page";
            this.ResumeLayout(false);

        }


        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [ComVisibleAttribute(true)]
        public class ScriptingObject
        {
            Workbench workbench;


            public ScriptingObject(Workbench workbench)
            {
                this.workbench = workbench;
            }



            #region Workplace Actions
            public void WorkplaceOpenPath(string path)
            {
                workbench.OpenWorkplace(path);
            }

            public void WorkplaceOpen()
            {
                workbench.ShowOpenWorkplaceDialog();
            }

            public void WorkplaceNew()
            {
                new Sinapse.WinForms.Dialogs.NewWorkplaceDialog(workbench).ShowDialog();
            }
            #endregion




            #region Document Actions
            public void DocumentOpenPath(string path)
            {
                workbench.OpenDocument(path);
            }

            public void DocumentOpen()
            {
                workbench.ShowOpenDocumentDialog();
            }

            public void DocumentNew()
            {
                new Sinapse.WinForms.Dialogs.NewDocumentDialog(workbench).ShowDialog();
            }
            #endregion


        }



    }
}
