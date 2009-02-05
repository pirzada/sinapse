using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Documents;
using Sinapse.WinForms.Documents;
using Sinapse.WinForms.ToolWindows;

using Sinapse.WinForms.Controls;

namespace Sinapse.WinForms.Core
{
    public sealed class Workbench
    {

        private DockPanel dockPanel;
        private DeserializeDockContent deserializeDockContent;
        private Workplace activeWorkplace;

        // Most Recently Used Lists
        private MruComponent mruWorkplaces;
        private MruComponent mruDocuments;


        // Default Tool Windows
        private WorkplaceExplorer toolWorkplaceWindow;
        private PropertyWindow toolPropertyWindow;
        private HistoryWindow toolHistoryWindow;
        private TaskWindow toolTaskWindow;

        // *Other Tool Windows can be specified by custom editors


        // Dialogs
        private OpenFileDialog workplaceOpenDialog;
        private OpenFileDialog documentOpenDialog;


        // Events
        public event CancelEventHandler WorkplaceClosing;
        public event EventHandler WorkplaceClosed;
        public event EventHandler WorkplaceOpened;
        public event EventHandler DocumentOpened;


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

        public MruComponent MruWorkplace
        {
            get { return mruWorkplaces; }
            set { mruWorkplaces = value; }
        }

        public MruComponent MruDocuments
        {
            get { return mruDocuments; }
            set { mruDocuments = value; }
        }
        #endregion


        #region Workplace Specific Methods
        public void OpenWorkplace(string fullName)
        {
            OpenWorkplace(DocumentManager.Open(fullName) as Workplace);
        }

        public void OpenWorkplace(Workplace workplace)
        {
            if (CloseWorkplace())
            {
                this.activeWorkplace = workplace;
                this.OnActiveWorkplaceOpen(EventArgs.Empty);

                mruWorkplaces.Insert(workplace.File.FullName);
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
        #endregion


        #region Document Specific Methods
        public void OpenDocument(String fullName)
        {
            OpenDocument(fullName, null);
        }

        public void OpenDocument(ISinapseDocument document)
        {
            // Now lets determine the adequate viewer for this document type
            Type viewerType = SinapseDocumentView.GetViewer(document);

            // Activate the viewer
            SinapseDocumentView viewer = Activator.CreateInstance(viewerType, this, document) as SinapseDocumentView;

            // And then show the viewer on the main window.
            viewer.DockHandler.Show(dockPanel, DockState.Document);
        }

         public void OpenDocument(String fullName, Workplace owner)
        {
            // First: verify if the document isn't already open
            IDockContent[] openDocuments = dockPanel.DocumentsToArray();

            foreach (SinapseDocumentView openDocument in openDocuments)
            {
                if (openDocument.Document != null && 
                    openDocument.Document.File.FullName == fullName)
                {
                    // The document was already open
                    openDocument.DockHandler.Show(); // Activate it
                    return;
                }
            }

            // The document wasn't open, lets open it:
            ISinapseDocument document = DocumentManager.Open(fullName);
            document.Owner = owner; // If we have an owner Workplace, set it

            // Now lets determine the adequate viewer for this document type
            Type viewerType = SinapseDocumentView.GetViewer(Utils.GetExtension(fullName, true));

            // Activate the viewer,
            SinapseDocumentView viewer = Activator.CreateInstance(viewerType, this, document) as SinapseDocumentView;

            // And then lets show the new viewer on the main window.
            viewer.DockHandler.Show(dockPanel, DockState.Document);

            mruDocuments.Insert(fullName);
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
            if (WorkplaceOpened != null)
                WorkplaceOpened.Invoke(this, e);
        }

        private void OnDocumentOpen(EventArgs e)
        {
            if (DocumentOpened != null)
                DocumentOpened.Invoke(this, e);
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
