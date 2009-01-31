using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Windows.Documents;


namespace Sinapse.Windows
{
    public sealed class Workbench
    {

        private DockPanel dockPanel;
        private DeserializeDockContent deserializeDockContent;


        // Tool Windows
        private WorkplaceWindow twWorkplace;
        private PropertyWindow  twProperty;
        private HistoryWindow   twHistory;
        private TaskWindow      twTask;

        




        public Workbench(DockPanel dockPanel)
        {
            this.dockPanel = dockPanel;
            this.deserializeDockContent = new DeserializeDockContent(getContentFromPersistString);
        }



        #region Properties
        public WorkplaceWindow WorkplaceWindow
        {
            get { return twWorkplace; } 
        }
        public PropertyWindow PropertyWindow
        {
            get { return twProperty; }
        }
        public HistoryWindow HistoryWindow
        {
            get { return twHistory; }
        }

        public TaskWindow TaskWindow
        {
            get { return twTask; }
        }

        public SinapseDocumentView ActiveDocumentView
        {
            get { return (dockPanel.ActiveDocument as SinapseDocumentView); }
        }
        #endregion




        public void OpenDocument(String fullName)
        {
            OpenDocument(new SinapseDocumentInfo(fullName, false));
        }

        public void OpenDocument(SinapseDocumentInfo documentInfo)
        {
            // First: verify if the document isn't already open
            IDockContent[] openDocuments = dockPanel.DocumentsToArray();

            foreach (SinapseDocumentView openDocument in openDocuments)
            {
                if (openDocument.Document.File.FullName == documentInfo.FullName)
                {
                    // The document was already open
                    openDocument.DockHandler.Show(); // Activate it
                    return;
                }
            }
            
            // The document wasn't open, lets open it:
            ISinapseDocument document = documentInfo.Open();

            // Now lets determine the adequate viewer for this document type
            Type viewerType = SinapseDocumentView.GetViewer(document.GetType());

            // Activate the viewer,
            SinapseDocumentView viewer = Activator.CreateInstance(viewerType, this, document) as SinapseDocumentView;

            // And then lets show the new viewer on the main window.
            viewer.DockHandler.Show(dockPanel, DockState.Document);
        }

        public void SaveAll()
        {
            IDockContent[] documents = dockPanel.DocumentsToArray();

            foreach (SinapseDocumentView document in documents)
            {
                if (document.HasChanges)
                    document.Save();
            }
        }

        public bool CloseAll()
        {
            IDockContent[] documents = dockPanel.DocumentsToArray();

            foreach (SinapseDocumentView document in documents)
            {
                if (document.HasChanges)
                {
                    DialogResult r = MessageBox.Show(String.Format("Save changes to {0}?", document.Name),
                        "Save changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                        document.Save();
                    else if (r == DialogResult.Cancel)
                        return false;
                }
            }
            return true;
        }





        #region Layout Persistance
        // Location for the Layout configuration of DockPanel
        private readonly string config =
            Path.Combine(Application.LocalUserAppDataPath, "DockPanel.xml");

        public void Save()
        {
            dockPanel.SaveAsXml(config);
        }

        public void Load()
        {
            dockPanel.LoadFromXml(config, deserializeDockContent);
        }

        private IDockContent getContentFromPersistString(string persistString)
        {
            if (persistString.Equals(typeof(WorkplaceWindow)))
                return twWorkplace;
            else if (persistString.Equals(typeof(PropertyWindow).ToString()))
                return twProperty;
            else if (persistString.Equals(typeof(HistoryWindow).ToString()))
                return twHistory;
            else if (persistString.Equals(typeof(TaskWindow).ToString()))
                return twTask;
            else return null;
        }
        #endregion

    }
}
