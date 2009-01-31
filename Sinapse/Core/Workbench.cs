using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Forms.Documents;
using Sinapse.Forms.ToolWindows;


namespace Sinapse.Forms
{
    public sealed class Workbench
    {

        private DockPanel dockPanel;
        private DeserializeDockContent deserializeDockContent;


        // Tool Windows
        private WorkplaceWindow toolWorkplaceWindow;
        private PropertyWindow  toolPropertyWindow;
        private HistoryWindow   toolHistoryWindow;
        private TaskWindow      toolTaskWindow;



        public Workbench(DockPanel dockPanel)
        {
            this.dockPanel = dockPanel;
            this.deserializeDockContent = new DeserializeDockContent(getContentFromPersistString);

            this.toolWorkplaceWindow = new WorkplaceWindow();
            this.toolPropertyWindow = new PropertyWindow();
            this.toolHistoryWindow = new HistoryWindow();
            this.toolTaskWindow = new TaskWindow();
        }



        #region Tool Windows
        public WorkplaceWindow WorkplaceWindow
        {
            get { return toolWorkplaceWindow; } 
        }

        public PropertyWindow PropertyWindow
        {
            get { return toolPropertyWindow; }
        }

        public HistoryWindow HistoryWindow
        {
            get { return toolHistoryWindow; }
        }

        public TaskWindow TaskWindow
        {
            get { return toolTaskWindow; }
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

            foreach (IDockContent content in documents)
            {
                if (content is SinapseDocumentView)
                {
                    SinapseDocumentView document = content as SinapseDocumentView;
                    if (document.HasChanges)
                        document.Save();
                }
            }
        }

        public bool CloseAll()
        {
            IDockContent[] documents = dockPanel.DocumentsToArray();

            foreach (IDockContent content in documents)
            {
                if (content is SinapseDocumentView)
                {
                    SinapseDocumentView document = content as SinapseDocumentView;
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
            }
            return true;
        }





        #region Layout Persistance
        // Location for the Layout configuration of DockPanel
        private readonly string config =
            Path.Combine(Application.LocalUserAppDataPath, "DockPanel.xml");

        public void SaveLayout()
        {
            dockPanel.SaveAsXml(config);
        }

        public void LoadLayout()
        {
            if (File.Exists(config))
            dockPanel.LoadFromXml(config, deserializeDockContent);
        }

        private IDockContent getContentFromPersistString(string persistString)
        {
            if (persistString.Equals(typeof(WorkplaceWindow).ToString()))
                return toolWorkplaceWindow;
            else if (persistString.Equals(typeof(PropertyWindow).ToString()))
                return toolPropertyWindow;
            else if (persistString.Equals(typeof(HistoryWindow).ToString()))
                return toolHistoryWindow;
            else if (persistString.Equals(typeof(TaskWindow).ToString()))
                return toolTaskWindow;
            else return null;
        }
        #endregion

    }
}
