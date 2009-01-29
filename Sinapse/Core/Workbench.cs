using System;
using System.Collections.Generic;
using System.Text;

using Sinapse.Core;
using Sinapse.Core.Workplace;


using Sinapse.Windows.Documents;

namespace Sinapse.Windows
{
    internal sealed class Workbench
    {

        private Workplace workplace;
        private Dictionary<SinapseDocumentInfo, ISinapseDocumentView> openDocuments;

        private WorkplaceWindow windowWorkplace;
        private PropertyWindow  windowProperties;
        private HistoryWindow   windowHistory;
        private TaskWindow      windowTask;


        public Workbench()
        {

        }

        
    }
}
