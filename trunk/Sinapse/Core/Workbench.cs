using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
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
        private Workplace activeWorkplace;


        // Tool Windows
        private WorkplaceExplorer toolWorkplaceWindow;
        private PropertyWindow toolPropertyWindow;
        private HistoryWindow toolHistoryWindow;
        private TaskWindow toolTaskWindow;


        // Dialogs
        private OpenFileDialog workplaceOpenDialog;
        private OpenFileDialog documentOpenDialog;


        // Events
        public event CancelEventHandler WorkplaceClosing;
        public event EventHandler WorkplaceClosed;
        public event EventHandler WorkplaceOpen;



        public Workbench(DockPanel dockPanel)
        {
            this.dockPanel = dockPanel;
            this.deserializeDockContent = new DeserializeDockContent(getContentFromPersistString);

            this.toolWorkplaceWindow = new WorkplaceExplorer(this);
            this.toolPropertyWindow = new PropertyWindow(this);
            this.toolHistoryWindow = new HistoryWindow(this);
            this.toolTaskWindow = new TaskWindow(this);

            workplaceOpenDialog = new OpenFileDialog();
            documentOpenDialog = new OpenFileDialog();
        }



        #region Tool Windows
        public WorkplaceExplorer WorkplaceWindow
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



        #region Properties
        public Workplace Workplace
        {
            get { return activeWorkplace; }
        }
        #endregion


        #region Workplace Specific Methods
        public void OpenWorkplace(string fullName)
        {
            OpenWorkplace(SinapseDocument.Open(fullName) as Workplace);
        }

        public void OpenWorkplace(Workplace workplace)
        {
            if (CloseWorkplace())
            {
                this.activeWorkplace = workplace;
                this.OnActiveWorkplaceOpen(EventArgs.Empty);
            }
        }

        public void ShowOpenWorkplaceDialog()
        {
            workplaceOpenDialog.Title = "Open Workplace";
            workplaceOpenDialog.ValidateNames = true;
            workplaceOpenDialog.Filter = "Sinapse Workplaces (*.workplace)|*.workplace";
            workplaceOpenDialog.SupportMultiDottedExtensions = true;

            if (workplaceOpenDialog.ShowDialog(dockPanel) == DialogResult.OK)
                OpenWorkplace(workplaceOpenDialog.FileName);
        }
        #endregion


        #region Document Specific Methods
        public void OpenDocument(String fullName)
        {
            OpenDocument(new SinapseDocumentInfo(fullName, null));
        }

        public void OpenDocument(SinapseDocumentInfo documentInfo)
        {
            // First: verify if the document isn't already open
            IDockContent[] openDocuments = dockPanel.DocumentsToArray();

            foreach (SinapseDocumentView openDocument in openDocuments)
            {
                if (openDocument.Document != null && 
                    openDocument.Document.File.FullName == documentInfo.FullName)
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

        public void ShowOpenDocumentDialog()
        {
            workplaceOpenDialog.Title = "Open Document";
            workplaceOpenDialog.ValidateNames = true;
            workplaceOpenDialog.Filter = "Training Sessions (*.session.*)|*.session*|"+
                "Data Sources (*.source.*)|*.source*|" +
                "Adaptive Systems (*.system*)|*.system*";
            workplaceOpenDialog.SupportMultiDottedExtensions = true;

            if (workplaceOpenDialog.ShowDialog(dockPanel) == DialogResult.OK)
                OpenDocument(workplaceOpenDialog.FileName);
        }
        #endregion


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

            if (activeWorkplace != null)
                activeWorkplace.Save();
        }

        /// <summary>
        ///   Attempts to close all open documents belonging to the
        ///   given Workplace. If null, all documents will be closed.
        /// </summary>
        /// <param name="workplace">The workplace owning the documents to be closed.</param>
        /// <param name="askForUnsavedChanges">Asks confirmation before closing unsaved documents.</param>
        /// <returns>Returns true if all documents were closed, false if the operation was cancelled by the user.</returns>
        public bool CloseAllDocuments(Workplace workplace, bool askForUnsavedChanges)
        {
            IDockContent[] documents = dockPanel.DocumentsToArray();

            foreach (IDockContent content in documents)
            {
                if (content is SinapseDocumentView)
                {
                    SinapseDocumentView document = content as SinapseDocumentView;
                    if (askForUnsavedChanges && document.HasChanges)
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

        /// <summary>
        ///   Attempts to close all open documents.
        /// </summary>
        /// <param name="askForUnsavedChanges">Asks confirmation before closing unsaved documents.</param>
        /// <returns>Returns true if all documents were closed, false if the operation was cancelled by the user.</returns>
        public bool CloseAllDocuments(bool askForUnsavedChanges)
        {
            return CloseAllDocuments(null, askForUnsavedChanges);
        }


        public bool CloseWorkplace()
        {
            if (activeWorkplace != null)
            {
                CancelEventArgs e = new CancelEventArgs();
                this.OnActiveWorkplaceClosing(e);
                if (e.Cancel == true)
                    return false;

                if (this.CloseAllDocuments(this.activeWorkplace, true))
                {
                    this.activeWorkplace = null;
                    this.OnActiveWorkplaceClosed(EventArgs.Empty);
                    return true;
                }
                else return false;
            }
            else return true;
        }




        #region Event Handlers
        private void OnActiveWorkplaceClosing(CancelEventArgs e)
        {
            if (WorkplaceClosing != null)
                WorkplaceClosing.Invoke(this, e);
        }

        private void OnActiveWorkplaceClosed(EventArgs e)
        {
            if (WorkplaceClosed != null)
                WorkplaceClosed.Invoke(this, e);
        }

        private void OnActiveWorkplaceOpen(EventArgs e)
        {
            if (WorkplaceOpen != null)
                WorkplaceOpen.Invoke(this, e);
        }
        #endregion



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
            if (persistString.Equals(typeof(WorkplaceExplorer).ToString()))
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
