using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;


namespace Sinapse.Forms.Documents
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
                this.document.DocumentChanged += new EventHandler(document_DocumentChanged);
                this.document.FileSaved += new EventHandler(document_FileSaved);

                saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = DocumentCache.GetExtension(document.GetType());
            }
        }

        public SinapseDocumentView()
        {

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
        private void updateCaption()
        {
            this.Name = this.document.Name;
            this.Text = this.document.Name;

            this.TabText = this.document.Name;

            if (this.Document.HasChanges)
                this.TabText = this.Name + "*";
        }
        #endregion


        #region Event Handling
        void document_FileSaved(object sender, EventArgs e)
        {
            updateCaption();
        }

        void document_DocumentChanged(object sender, EventArgs e)
        {
            updateCaption();
        }
        #endregion



        #region Static Methods
        private static Dictionary<Type, Type> viewers; // <Document Type, Viewer Type>

        public static void ConstructCache()
        {
            viewers = new Dictionary<Type, Type>();

            Type[] types = Sinapse.Utils.GetTypesImplementingInterface(
              Assembly.GetAssembly(typeof(SinapseDocumentView)), typeof(SinapseDocumentView));

            foreach (Type viewer in types)
            {
                object[] attr = viewer.GetCustomAttributes(typeof(DocumentViewer), false);
                if (attr.Length > 0)
                {
                    viewers.Add((attr[0] as DocumentViewer).DocumentType, viewer);
                }
            }
        }

        public static Type GetViewer(Type document)
        {
            if (viewers == null)
                ConstructCache();
            return viewers[document];
        }
        #endregion

    }

}
