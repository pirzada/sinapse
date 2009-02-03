using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Systems;

using Sinapse.Forms.Editors.AdaptiveSystems;
using Sinapse.Forms.Editors.AdaptiveSystems.Controls;

namespace Sinapse.Forms.Documents
{
    [DocumentViewer(typeof(Workplace))]
    internal partial class WorkplaceView : SinapseDocumentView
    {
        public WorkplaceView()
        {
            InitializeComponent();
        }
    }
}
