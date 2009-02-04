using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Documents;

using Sinapse.WinForms.Core;


namespace Sinapse.WinForms.Documents
{

    public class SinapseDocumentView : DockContent
    {

        private ISinapseDocument document;
        private Workbench workbench;
        private SaveFileDialog saveFileDialog;

        

        public SinapseDocumentView(Workbench workbench, ISinapseDocument document)
        {
            this.workbench = workbench;
            this.document = document;

            if (document != null)
            {
                this.document.ContentChanged += new EventHandler(document_DocumentChanged);
                this.document.FileSaved += new EventHandler(document_FileSaved);

                saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = DocumentManager.GetExtension(document.GetType());
            }
        }

        public SinapseDocumentView()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UpdateCaption();
        }

        



        #region Properties
        public virtual ISinapseDocument Document
        {
            get { return document; }
        }

        protected SaveFileDialog SaveFileDialog
        {
            get { return saveFileDialog; }
        }

        protected Workbench Workbench
        {
            get { return workbench; }
        }

        public bool HasChanges
        {
            get { 
                if (document != null)
                return document.HasChanges;
                return false;
            }
        }
        #endregion




        #region Public (Virtual) Methods
        public virtual void Save()
        {
            if (document.File != null)
                document.Save();
            else SaveAs();
        }

        public virtual void SaveAs()
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
            }
        }

        public virtual void Copy()
        {
        }
        
        public virtual void Paste()
        {
        }

        public virtual void Cut()
        {
        }

        public virtual void Undo()
        {
        }

        public virtual void Redo()
        {
        }
        #endregion


        #region Private Methods
        protected void UpdateCaption()
        {
            if (this.document != null)
            {
                this.Name = this.document.Name;
                this.Text = this.document.Name;

                this.TabText = this.document.Name;

                if (this.Document.HasChanges)
                    this.TabText = this.Name + "*";
            }
        }
        #endregion


        #region Event Handling
        void document_FileSaved(object sender, EventArgs e)
        {
            UpdateCaption();
        }

        void document_DocumentChanged(object sender, EventArgs e)
        {
            UpdateCaption();
        }
        #endregion




        #region Static Methods
        private static Dictionary<String, Type> viewers; // <Document Extension, Viewer Type>

        public static void BuildCache()
        {
            viewers = new Dictionary<String, Type>();

            Type[] types = Sinapse.Utils.GetTypesImplementingInterface(
              Assembly.GetAssembly(typeof(SinapseDocumentView)), typeof(SinapseDocumentView));

            foreach (Type viewer in types)
            {
                object[] attr = viewer.GetCustomAttributes(typeof(DocumentViewer), false);
                if (attr.Length > 0)
                {
                    viewers.Add((attr[0] as DocumentViewer).Extension, viewer);
                }
            }
        }

        public static Type GetViewer(String extension)
        {
            if (viewers == null)
                BuildCache();
            return viewers[extension];
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SinapseDocumentView
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "SinapseDocumentView";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SinapseDocumentView_MouseClick);
            this.ResumeLayout(false);

        }

        private void SinapseDocumentView_MouseClick(object sender, MouseEventArgs e)
        {

        }

    }

}
