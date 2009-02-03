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

using Sinapse.Properties;

using WeifenLuo.WinFormsUI.Docking;

namespace Sinapse.Forms.Documents
{


    public partial class StartPage : SinapseDocumentView
    {
        private WebBrowser webBrowser1;
        private ScriptingObject scriptingObject;
        private String address;

    
        public StartPage(Workbench workbench) : base(workbench, null)
        {
            address = Path.Combine(Application.StartupPath,
                Sinapse.Properties.Settings.Default.startpage_path);
            
         
            InitializeComponent();

            scriptingObject = new ScriptingObject();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            this.webBrowser1.Url = new Uri(address);
            this.webBrowser1.ObjectForScripting = scriptingObject;
        }

        public void Refresh()
        {
        }



        public string CreateStartPage(string model)
        {
            StringBuilder sb = new StringBuilder(model);
            sb.Replace("<!--WORKPLACES-->", CreateFileListing("WorkplaceOpenPath", Settings.Default.mruWorkplaces));
            sb.Replace("<!--DOCUMENTS-->",  CreateFileListing("DocumentOpenPath", Settings.Default.mruDocuments));
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
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(569, 312);
            this.webBrowser1.TabIndex = 0;
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

            public ScriptingObject()
            {

            }



            #region Workplace Actions
            public void WorkplaceOpenPath(string path)
            {
             
            }

            public void WorkplaceOpen()
            {
            }

            public void WorkplaceNew()
            {
                new Sinapse.Forms.Dialogs.NewWorkplaceDialog().ShowDialog();
            }
            #endregion



            #region Document Actions
            public void DocumentOpenPath(string path)
            {
            }

            public void DocumentOpen()
            {
            }

            public void DocumentNew()
            {
            }
            #endregion


        }

    }
}
