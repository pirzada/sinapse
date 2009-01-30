using System;
using System.Collections.Generic;
using System.Text;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Windows.Documents;


namespace Sinapse.Windows
{
    internal sealed class Workbench
    {

        private DockPanel dockPanel;
        private Dictionary<SinapseDocumentInfo, ISinapseDocumentView> openDocuments;

        private WorkplaceWindow wWorkplace;
        private PropertyWindow  wProperty;
        private HistoryWindow   wHistory;
        private TaskWindow      wTask;

        private DeserializeDockContent deserializeDockContent;


        public Workbench(DockPanel dockPanel)
        {
            this.dockPanel = dockPanel;
            this.deserializeDockContent = new DeserializeDockContent(getContentFromPersistString);
        }


        public WorkplaceWindow WorkplaceWindow
        {
            get { return wWorkplace; } 
        }
        public PropertyWindow PropertyWindow
        {
            get { return wProperty; }
        }
        public HistoryWindow HistoryWindow
        {
            get { return wHistory; }
        }

        public TaskWindow TaskWindow
        {
            get { return wTask; }
        }

        public void Close()
        {
            IDockContent[] documents = dockPanel.DocumentsToArray();
            foreach (IDockContent content in documents)
                content.DockHandler.Close();
        }

        public void Save()
        {
        }

        public void Load()
        {
        }

        private IDockContent getContentFromPersistString(string persistString)
        {
            if (persistString.Equals(typeof(WorkplaceWindow)))
                return wWorkplace;
            else if (persistString.Equals(typeof(PropertyWindow).ToString()))
                return wProperty;
            else if (persistString.Equals(typeof(HistoryWindow).ToString()))
                return wHistory;
            else if (persistString.Equals(typeof(TaskWindow).ToString()))
                return wTask;
            else return null;
        }
        
    }
}
